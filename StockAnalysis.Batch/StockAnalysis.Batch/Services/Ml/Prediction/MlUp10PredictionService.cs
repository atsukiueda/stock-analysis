using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.ML.Trainers.FastTree;
using System.Globalization;
using StockAnalysis.Batch.Models.Ml;
using StockAnalysis.Batch.Services.Ml.Base;
using StockAnalysis.Batch.Services.Ml.Features;

namespace StockAnalysis.Batch.Services.Ml.Prediction;

public class MlUp10PredictionService : MlBinaryPredictionServiceBase
{
    private const string ModelDirectory = "Models";

    private const string ModelPath = "Models/up10-model.zip";

    private readonly StockAnalysisDbContext _db;

    private readonly MlFeatureCalculationService _featureCalculationService;

    private readonly Dictionary<DateTime, MlMarketFeatures> _marketFeatureCache = new();

    private readonly Dictionary<string, MlTechnicalFeatures?> _technicalFeatureCache = new();

    private readonly Dictionary<string, List<PriceDaily>> _priceHistoryCache = new();

    private readonly Dictionary<string, List<MarketIndexDaily>> _marketIndexHistoryCache = new();

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    /// <param name="db">DBコンテキスト。</param>
    public MlUp10PredictionService(StockAnalysisDbContext db)
    {
        _db = db;
        _featureCalculationService = new MlFeatureCalculationService(db);
    }

    public async Task TrainAndEvaluateAsync()
    {
        var excludedNameKeywords = new[]
    {
        "ＥＴＦ",
        "ETF",
        "投信",
        "上場投信",
        "インデックスファンド",
        "ＮＥＸＴ　ＦＵＮＤＳ",
        "MAXIS",
        "ｉＦｒｅｅＥＴＦ",
        "iFreeETF",
        "グローバルＸ",
        "REIT",
        "リート",
        "ETN",
        "ＳＰＤＲ",
        "SPDR",
        "ゴールド・シェア",
        "Gold Shares"
    };

        var inputs = await CreateTrainingInputsAsync();

        if (inputs.Count < 50)
        {
            Console.WriteLine($"学習データが少なすぎます。件数: {inputs.Count}");
            return;
        }

        var positiveCount = inputs.Count(x => x.Up5);
        var negativeCount = inputs.Count - positiveCount;

        Console.WriteLine($"DataCount: {inputs.Count}");
        Console.WriteLine($"Up10=True : {positiveCount}");
        Console.WriteLine($"Up10=False: {negativeCount}");
        Console.WriteLine($"PositiveRate: {(double)positiveCount / inputs.Count:P2}");

        // 共通基底クラスでSdca/FastTreeを比較し、採用モデルを保存する。
        var bestModel = await TrainBestModelAsync();

        // 必要に応じて最新スコアの予測ランキングを表示する。
        await ShowLatestPredictionRankingAsync(bestModel, excludedNameKeywords);
    }

    private async Task ShowLatestPredictionRankingAsync(
        ITransformer model,
        string[] excludedNameKeywords)
    {
        var latestScoreDate = await _db.StockScoresDaily
            .MaxAsync(x => x.ScoreDate);

        var latestScoreRows = await _db.StockScoresDaily
            .Where(x => x.ScoreDate == latestScoreDate)
            .Join(
                _db.Companies,
                score => score.Code,
                company => company.Code,
                (score, company) => new
                {
                    Score = score,
                    Company = company
                })
            .Where(x => x.Company.IsActive)
            .ToListAsync();

        latestScoreRows = latestScoreRows
            .Where(x => !excludedNameKeywords.Any(keyword =>
                x.Company.CompanyName.Contains(keyword)))
            .OrderByDescending(x => x.Score.TotalScore)
            .Take(100)
            .ToList();

        var predictionEngine =
            MlContext.Model.CreatePredictionEngine<MlStockPredictionInput, MlStockPredictionOutput>(model);

        var rankingSource = new List<dynamic>();

        foreach (var x in latestScoreRows)
        {
            var score = x.Score;

            var technicalFeatures = await _featureCalculationService.GetTechnicalFeaturesAsync(
                score.Code,
                score.ScoreDate);

            if (technicalFeatures == null)
            {
                continue;
            }

            var marketFeatures = await _featureCalculationService.GetMarketFeaturesAsync(
                score.ScoreDate);

            var input = new MlStockPredictionInput
            {
                FinancialScore = score.FinancialScore,
                GrowthScore = score.GrowthScore,
                DividendScore = score.DividendScore,
                RoeScore = score.RoeScore,
                PerScore = score.PerScore,
                PbrScore = score.PbrScore,
                TechnicalScore = score.TechnicalScore,
                SwingScore = score.SwingScore,
                MarketScore = score.MarketScore,

                Momentum5 = technicalFeatures.Momentum5,
                Momentum25 = technicalFeatures.Momentum25,
                DeviationFromMa25 = technicalFeatures.DeviationFromMa25,
                VolumeRatio5 = technicalFeatures.VolumeRatio5,
                Ma25Slope = technicalFeatures.Ma25Slope,
                Ma75Slope = technicalFeatures.Ma75Slope,
                ClosePositionInRange25 = technicalFeatures.ClosePositionInRange25
            };

            var prediction = predictionEngine.Predict(input);

            rankingSource.Add(new
            {
                score.Code,
                x.Company.CompanyName,
                score.TotalScore,
                score.SwingScore,
                Up5Probability = prediction.Probability
            });
        }

        var ranking = rankingSource
            .OrderByDescending(x => x.Up5Probability)
            .Take(20)
            .ToList();

        Console.WriteLine();
        Console.WriteLine($"=== 最新スコア Up10 予測ランキング: {latestScoreDate:yyyy-MM-dd} ===");

        foreach (var item in ranking)
        {
            Console.WriteLine(
                $"{item.Code} {item.CompanyName} Total:{item.TotalScore} Swing:{item.SwingScore} Up10Prob:{item.Up5Probability:P2}");
        }
    }

    private async Task<MlTechnicalFeatures?> CalculateTechnicalFeaturesAsync(
    string code,
    DateTime tradeDate)
    {
        var allPrices = await GetPriceHistoryWithCacheAsync(code);

        var prices = allPrices
            .Where(x => x.TradeDate <= tradeDate)
            .TakeLast(80)
            .ToList();

        if (prices.Count < 80)
        {
            return null;
        }

        var latest = prices[^1];

        if (latest.ClosePrice == null || latest.ClosePrice <= 0)
        {
            return null;
        }

        var latestClose = latest.ClosePrice.Value;

        var close5Ago = prices[^6].ClosePrice;
        var close25Ago = prices[^26].ClosePrice;

        if (close5Ago == null || close5Ago <= 0 ||
            close25Ago == null || close25Ago <= 0)
        {
            return null;
        }

        var latest25Prices = prices.TakeLast(25).ToList();
        var previous25Prices = prices.Skip(prices.Count - 30).Take(25).ToList();

        var latest75Prices = prices.TakeLast(75).ToList();
        var previous75Prices = prices.Skip(prices.Count - 80).Take(75).ToList();

        var ma25 = latest25Prices.Average(x => x.ClosePrice!.Value);
        var previousMa25 = previous25Prices.Average(x => x.ClosePrice!.Value);

        var ma75 = latest75Prices.Average(x => x.ClosePrice!.Value);
        var previousMa75 = previous75Prices.Average(x => x.ClosePrice!.Value);

        var avgVolume5 = prices
            .TakeLast(5)
            .Where(x => x.Volume != null)
            .Average(x => x.Volume!.Value);

        var avgVolume25 = latest25Prices
            .Where(x => x.Volume != null)
            .Average(x => x.Volume!.Value);

        var high25 = latest25Prices
            .Where(x => x.HighPrice != null)
            .Max(x => x.HighPrice!.Value);

        var low25 = latest25Prices
            .Where(x => x.LowPrice != null)
            .Min(x => x.LowPrice!.Value);

        var range25 = high25 - low25;

        return new MlTechnicalFeatures
        {
            Momentum5 = (float)((latestClose - close5Ago.Value) / close5Ago.Value * 100m),
            Momentum25 = (float)((latestClose - close25Ago.Value) / close25Ago.Value * 100m),
            DeviationFromMa25 = ma25 <= 0
                ? 0
                : (float)((latestClose - ma25) / ma25 * 100m),
            VolumeRatio5 = avgVolume25 <= 0
                ? 0
                : (float)(avgVolume5 / avgVolume25),
            ClosePositionInRange25 = range25 <= 0
                ? 0.5f
                : (float)((latestClose - low25) / range25),
            Ma25Slope = previousMa25 <= 0
                ? 0
                : (float)((ma25 - previousMa25) / previousMa25 * 100m),
            Ma75Slope = previousMa75 <= 0
                ? 0
                : (float)((ma75 - previousMa75) / previousMa75 * 100m)
        };
    }

    private async Task<MlTechnicalFeatures?> GetTechnicalFeaturesWithCacheAsync(
    string code,
    DateTime tradeDate)
    {
        var key = $"{code}_{tradeDate:yyyyMMdd}";

        if (_technicalFeatureCache.TryGetValue(key, out var cached))
        {
            return cached;
        }

        var technicalFeatures = await _featureCalculationService.GetTechnicalFeaturesAsync(
            code,
            tradeDate);

        _technicalFeatureCache[key] = technicalFeatures;

        return technicalFeatures;
    }

    private async Task<MlMarketFeatures> CalculateMarketFeaturesAsync(
        DateTime tradeDate)
    {
        return new MlMarketFeatures
        {
            TopixMomentum25 = await CalculateMarketMomentum25Async("TOPIX", tradeDate),
            Sp500Momentum25 = await CalculateMarketMomentum25Async("SP500", tradeDate),
            NasdaqMomentum25 = await CalculateMarketMomentum25Async("NASDAQ", tradeDate),
            UsdJpyMomentum25 = await CalculateMarketMomentum25Async("USDJPY", tradeDate),
            VixMomentum25 = await CalculateMarketMomentum25Async("VIX", tradeDate)
        };
    }

    private async Task<MlMarketFeatures> GetMarketFeaturesWithCacheAsync(
        DateTime tradeDate)
    {
        if (_marketFeatureCache.TryGetValue(tradeDate, out var cached))
        {
            return cached;
        }

        var marketFeatures = await CalculateMarketFeaturesAsync(tradeDate);

        _marketFeatureCache[tradeDate] = marketFeatures;

        return marketFeatures;
    }

    private async Task<float> CalculateMarketMomentum25Async(
    string indexName,
    DateTime tradeDate)
    {
        var allPrices = await GetMarketIndexHistoryWithCacheAsync(indexName);

        var prices = allPrices
            .Where(x => x.TradeDate <= tradeDate)
            .TakeLast(25)
            .ToList();

        if (prices.Count < 25)
        {
            return 0;
        }

        var first = prices[0].CloseValue;
        var latest = prices[^1].CloseValue;

        if (first == null || first <= 0 || latest == null)
        {
            return 0;
        }

        return (float)((latest.Value - first.Value) / first.Value * 100m);
    }

    public async Task<Dictionary<string, decimal>> PredictLatestUp10ProbabilitiesAsync()
    {
        var model = LoadModel();

        var latestScoreDate = await _db.StockScoresDaily
            .MaxAsync(x => x.ScoreDate);

        var latestScoreRows = await _db.StockScoresDaily
            .AsNoTracking()
            .Where(x => x.ScoreDate == latestScoreDate)
            .ToListAsync();

        var targetCodes = latestScoreRows
            .Select(x => x.Code)
            .Distinct()
            .ToList();

        var priceHistoryMap = await GetPriceHistoryMapAsync(targetCodes);

        var marketFeatures = await _featureCalculationService.GetMarketFeaturesAsync(
            latestScoreDate);

        var inputs = new List<MlStockPredictionInput>();
        var codeList = new List<string>();

        foreach (var score in latestScoreRows)
        {
            if (!priceHistoryMap.TryGetValue(score.Code, out var allPrices))
            {
                continue;
            }

            var technicalFeatures = CalculateTechnicalFeaturesFromPrices(
                allPrices,
                score.ScoreDate);

            if (technicalFeatures == null)
            {
                continue;
            }

            inputs.Add(new MlStockPredictionInput
            {
                FinancialScore = score.FinancialScore,
                GrowthScore = score.GrowthScore,
                DividendScore = score.DividendScore,
                RoeScore = score.RoeScore,
                PerScore = score.PerScore,
                PbrScore = score.PbrScore,
                TechnicalScore = score.TechnicalScore,
                SwingScore = score.SwingScore,
                MarketScore = score.MarketScore,

                Momentum5 = technicalFeatures.Momentum5,
                Momentum25 = technicalFeatures.Momentum25,
                DeviationFromMa25 = technicalFeatures.DeviationFromMa25,
                VolumeRatio5 = technicalFeatures.VolumeRatio5,
                ClosePositionInRange25 = technicalFeatures.ClosePositionInRange25,
                Ma25Slope = technicalFeatures.Ma25Slope,
                Ma75Slope = technicalFeatures.Ma75Slope,

                TopixMomentum25 = marketFeatures.TopixMomentum25,
                Sp500Momentum25 = marketFeatures.Sp500Momentum25,
                NasdaqMomentum25 = marketFeatures.NasdaqMomentum25,
                UsdJpyMomentum25 = marketFeatures.UsdJpyMomentum25,
                VixMomentum25 = marketFeatures.VixMomentum25
            });

            codeList.Add(score.Code);
        }

        if (inputs.Count == 0)
        {
            return new Dictionary<string, decimal>();
        }

        var dataView = MlContext.Data.LoadFromEnumerable(inputs);

        var predictions = model.Transform(dataView);

        var predictionRows = MlContext.Data
            .CreateEnumerable<MlStockPredictionOutput>(
                predictions,
                reuseRowObject: false)
            .ToList();

        var result = new Dictionary<string, decimal>();

        for (var i = 0; i < predictionRows.Count; i++)
        {
            result[codeList[i]] = Math.Round(
                (decimal)predictionRows[i].Probability * 100m,
                4);
        }

        return result;
    }

    /// <summary>
    /// デフォルトUp10モデルを読み込む。
    /// 同じモデルは共通基底クラスでキャッシュし、毎回zipを読み直さない。
    /// </summary>
    /// <returns>読み込み済みモデル。</returns>
    private ITransformer GetOrLoadModel()
    {
        return GetOrLoadModel(
            modelName: "up10-model",
            modelTitle: "Up10");
    }

    public async Task<decimal?> PredictAsync(StockScoreDaily score)
    {
        // 共通基底クラスから、デフォルトUp10モデル用のPredictionEngineを取得する。
        var predictionEngine = GetOrCreatePredictionEngine(
            modelName: "up10-model",
            modelTitle: "Up10");

        var technicalFeatures = await GetTechnicalFeaturesWithCacheAsync(
            score.Code,
            score.ScoreDate);

        if (technicalFeatures == null)
        {
            return null;
        }

        var marketFeatures = await GetMarketFeaturesWithCacheAsync(score.ScoreDate);

        // 銘柄スコア・テクニカル特徴量・市場特徴量からML入力を作成する。
        var input = CreatePredictionInput(
            score,
            technicalFeatures,
            marketFeatures);

        var prediction = predictionEngine.Predict(input);

        return Math.Round((decimal)prediction.Probability * 100m, 4);
    }

    /// <summary>
    /// 全期間データを使って、Up10の最良モデルを学習する。
    /// 共通基底クラスの二値分類学習処理を利用する。
    /// </summary>
    /// <returns>学習済みUp10モデル。</returns>
    private async Task<ITransformer> TrainBestModelAsync()
    {
        // CSVキャッシュからUp10入力データを取得する。
        var inputs = await CreateTrainingInputsAsync();

        // 共通基底クラスでSdca/FastTreeの学習・評価・採用・保存を行う。
        return await TrainBestModelAsync(
            inputs: inputs,
            modelName: "up10-model",
            modelTitle: "Up10",
            trainFrom: DateTime.MinValue,
            trainTo: DateTime.MaxValue);
    }

    /// <summary>
    /// Up10モデルで使用する特徴量列名を取得する。
    /// Up10は現時点で市場モメンタム特徴量も含めて評価する。
    /// </summary>
    /// <returns>Up10モデルで使用する特徴量列名。</returns>
    protected override string[] GetFeatureColumns()
    {
        return
        [
            nameof(MlStockPredictionInput.FinancialScore),
            nameof(MlStockPredictionInput.GrowthScore),
            nameof(MlStockPredictionInput.DividendScore),
            nameof(MlStockPredictionInput.RoeScore),
            nameof(MlStockPredictionInput.PerScore),
            nameof(MlStockPredictionInput.PbrScore),
            nameof(MlStockPredictionInput.TechnicalScore),
            nameof(MlStockPredictionInput.SwingScore),
            nameof(MlStockPredictionInput.MarketScore),
            nameof(MlStockPredictionInput.Momentum5),
            nameof(MlStockPredictionInput.Momentum25),
            nameof(MlStockPredictionInput.DeviationFromMa25),
            nameof(MlStockPredictionInput.VolumeRatio5),
            nameof(MlStockPredictionInput.ClosePositionInRange25),
            nameof(MlStockPredictionInput.TopixMomentum25),
            nameof(MlStockPredictionInput.Sp500Momentum25),
            nameof(MlStockPredictionInput.NasdaqMomentum25),
            nameof(MlStockPredictionInput.UsdJpyMomentum25),
            nameof(MlStockPredictionInput.VixMomentum25),
            nameof(MlStockPredictionInput.Ma25Slope),
            nameof(MlStockPredictionInput.Ma75Slope)
        ];
    }

    /// <summary>
    /// CSVキャッシュからUp10学習用入力データを作成する。
    /// 学習時のAzure SQLアクセスと特徴量再計算を避けるために使用する。
    /// </summary>
    /// <returns>Up10学習用入力データ。</returns>
    private Task<List<MlStockPredictionInput>> CreateTrainingInputsAsync()
    {
        var inputs = LoadTrainingDataFromCsv()
            .OrderBy(x => x.TradeDate)
            .ToList();

        return Task.FromResult(inputs);
    }

    private ITransformer LoadModel()
    {
        if (!File.Exists(ModelPath))
        {
            throw new FileNotFoundException(
                $"Up10モデルが見つかりません。先にRUN_ML_UP10_TRAINING=trueで学習してください: {ModelPath}");
        }

        return MlContext.Model.Load(ModelPath, out _);
    }

    /// <summary>
    /// CSVキャッシュからUp10学習用データを読み込む。
    /// </summary>
    /// <returns>Up10学習用入力データ。</returns>
    private List<MlStockPredictionInput> LoadTrainingDataFromCsv()
    {
        var path = Path.Combine(
            AppContext.BaseDirectory,
            "MlCache",
            "up10_training_data.csv");

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
                $"Up10学習用CSVキャッシュが見つかりません。先にExportUp10TrainingDataAsyncを実行してください: {path}");
        }

        var lines = File.ReadAllLines(path)
            .Skip(1);

        var list = new List<MlStockPredictionInput>();

        foreach (var line in lines)
        {
            // 空行は学習データとして扱わない。
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            var c = line.Split(',');

            // CSV列数が想定と異なる場合は、キャッシュ生成ミスとして明示的に停止する。
            if (c.Length < 25)
            {
                throw new InvalidOperationException(
                    $"Up10学習用CSVの列数が不足しています。Columns:{c.Length}, Line:{line}");
            }

            list.Add(new MlStockPredictionInput
            {
                TradeDate = DateTime.Parse(
                    c[0],
                    CultureInfo.InvariantCulture),

                Code = c[1],

                FinancialScore = ParseFloat(c[2]),
                GrowthScore = ParseFloat(c[3]),
                DividendScore = ParseFloat(c[4]),
                RoeScore = ParseFloat(c[5]),
                PerScore = ParseFloat(c[6]),
                PbrScore = ParseFloat(c[7]),
                TechnicalScore = ParseFloat(c[8]),
                SwingScore = ParseFloat(c[9]),
                MarketScore = ParseFloat(c[10]),

                Momentum5 = ParseFloat(c[11]),
                Momentum25 = ParseFloat(c[12]),
                DeviationFromMa25 = ParseFloat(c[13]),
                VolumeRatio5 = ParseFloat(c[14]),
                ClosePositionInRange25 = ParseFloat(c[15]),
                Ma25Slope = ParseFloat(c[16]),
                Ma75Slope = ParseFloat(c[17]),

                TopixMomentum25 = ParseFloat(c[18]),
                Sp500Momentum25 = ParseFloat(c[19]),
                NasdaqMomentum25 = ParseFloat(c[20]),
                UsdJpyMomentum25 = ParseFloat(c[21]),
                VixMomentum25 = ParseFloat(c[22]),

                // Up10サービスでは、共通入力クラスのLabel列としてUp5プロパティを流用する。
                // ML.NET側ではColumnName("Label")が付いているため、ここにUp10ラベルを入れる。
                Up5 = bool.Parse(c[24])
            });
        }

        return list;
    }

    /// <summary>
    /// CSV文字列をfloat値へ変換する。
    /// 空文字は0として扱う。
    /// </summary>
    /// <param name="value">CSVから読み込んだ文字列。</param>
    /// <returns>float値。</returns>
    private static float ParseFloat(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return 0f;
        }

        return float.Parse(
            value,
            CultureInfo.InvariantCulture);
    }

    private async Task<List<PriceDaily>> GetPriceHistoryWithCacheAsync(string code)
    {
        if (_priceHistoryCache.TryGetValue(code, out var cached))
        {
            return cached;
        }

        var prices = await _db.PricesDaily
            .Where(x => x.Code == code)
            .Where(x => x.ClosePrice != null)
            .OrderBy(x => x.TradeDate)
            .ToListAsync();

        _priceHistoryCache[code] = prices;

        return prices;
    }

    private async Task<List<MarketIndexDaily>> GetMarketIndexHistoryWithCacheAsync(
    string indexName)
    {
        if (_marketIndexHistoryCache.TryGetValue(indexName, out var cached))
        {
            return cached;
        }

        var prices = await _db.MarketIndicesDaily
            .Where(x => x.IndexName == indexName)
            .Where(x => x.CloseValue != null)
            .OrderBy(x => x.TradeDate)
            .ToListAsync();

        _marketIndexHistoryCache[indexName] = prices;

        return prices;
    }

    private async Task<Dictionary<string, List<PriceDaily>>> GetPriceHistoryMapAsync(
    IReadOnlyCollection<string> codes)
    {
        if (codes.Count == 0)
        {
            return new Dictionary<string, List<PriceDaily>>();
        }

        var prices = await _db.PricesDaily
            .AsNoTracking()
            .Where(x => codes.Contains(x.Code))
            .Where(x => x.ClosePrice != null)
            .OrderBy(x => x.Code)
            .ThenBy(x => x.TradeDate)
            .ToListAsync();

        return prices
            .GroupBy(x => x.Code)
            .ToDictionary(
                g => g.Key,
                g => g.ToList());
    }

    private MlTechnicalFeatures? CalculateTechnicalFeaturesFromPrices(
    List<PriceDaily> allPrices,
    DateTime tradeDate)
    {
        var prices = allPrices
            .Where(x => x.TradeDate <= tradeDate)
            .TakeLast(80)
            .ToList();

        if (prices.Count < 80)
        {
            return null;
        }

        var latest = prices[^1];

        if (latest.ClosePrice == null || latest.ClosePrice <= 0)
        {
            return null;
        }

        var latestClose = latest.ClosePrice.Value;

        var close5Ago = prices[^6].ClosePrice;
        var close25Ago = prices[^26].ClosePrice;

        if (close5Ago == null || close5Ago <= 0 ||
            close25Ago == null || close25Ago <= 0)
        {
            return null;
        }

        var latest25Prices = prices.TakeLast(25).ToList();
        var previous25Prices = prices.Skip(prices.Count - 30).Take(25).ToList();

        var latest75Prices = prices.TakeLast(75).ToList();
        var previous75Prices = prices.Skip(prices.Count - 80).Take(75).ToList();

        var ma25 = latest25Prices.Average(x => x.ClosePrice!.Value);
        var previousMa25 = previous25Prices.Average(x => x.ClosePrice!.Value);

        var ma75 = latest75Prices.Average(x => x.ClosePrice!.Value);
        var previousMa75 = previous75Prices.Average(x => x.ClosePrice!.Value);

        var avgVolume5 = prices
            .TakeLast(5)
            .Where(x => x.Volume != null)
            .Average(x => x.Volume!.Value);

        var avgVolume25 = latest25Prices
            .Where(x => x.Volume != null)
            .Average(x => x.Volume!.Value);

        var high25 = latest25Prices
            .Where(x => x.HighPrice != null)
            .Max(x => x.HighPrice!.Value);

        var low25 = latest25Prices
            .Where(x => x.LowPrice != null)
            .Min(x => x.LowPrice!.Value);

        var range25 = high25 - low25;

        return new MlTechnicalFeatures
        {
            Momentum5 = (float)((latestClose - close5Ago.Value) / close5Ago.Value * 100m),

            Momentum25 = (float)((latestClose - close25Ago.Value) / close25Ago.Value * 100m),

            DeviationFromMa25 = ma25 <= 0
                ? 0
                : (float)((latestClose - ma25) / ma25 * 100m),

            VolumeRatio5 = avgVolume25 <= 0
                ? 0
                : (float)(avgVolume5 / avgVolume25),

            ClosePositionInRange25 = range25 <= 0
                ? 0.5f
                : (float)((latestClose - low25) / range25),

            Ma25Slope = previousMa25 <= 0
                ? 0
                : (float)((ma25 - previousMa25) / previousMa25 * 100m),

            Ma75Slope = previousMa75 <= 0
                ? 0
                : (float)((ma75 - previousMa75) / previousMa75 * 100m)
        };
    }
}