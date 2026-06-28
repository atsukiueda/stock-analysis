using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;
using System.Globalization;
using StockAnalysis.Batch.Services.Ml.Base;

namespace StockAnalysis.Batch.Services;

public class MlTakeProfitPredictionService
{
    private readonly StockAnalysisDbContext _db;

    private readonly MLContext _mlContext;

    private readonly Dictionary<DateTime, MarketFeatureValues> _marketFeatureCache = new();

    private readonly Dictionary<string, TechnicalFeatureValues?> _technicalFeatureCache = new();

    private readonly Dictionary<string, List<PriceDaily>> _priceHistoryCache = new();

    private readonly Dictionary<string, List<MarketIndexDaily>> _marketIndexHistoryCache = new();

    private readonly MlRegressionPipelineFactory _regressionPipelineFactory;

    private readonly MlRegressionEvaluator _regressionEvaluator;

    private readonly MlRegressionTrainer _regressionTrainer;

    private readonly MlModelStore _modelStore;

    private readonly MlPredictionEngineStore<MlTakeProfitInput, MlTakeProfitOutput> _predictionEngineStore;

    public MlTakeProfitPredictionService(StockAnalysisDbContext db)
    {
        _db = db;
        _mlContext = new MLContext(seed: 1);
        _regressionEvaluator = new MlRegressionEvaluator(_mlContext);
        _regressionPipelineFactory = new MlRegressionPipelineFactory(_mlContext);
        _regressionTrainer = new MlRegressionTrainer(
            _mlContext,
            _regressionPipelineFactory);
        _modelStore = new MlModelStore(_mlContext);

        _predictionEngineStore =
            new MlPredictionEngineStore<MlTakeProfitInput, MlTakeProfitOutput>(
            _mlContext,
            _modelStore);
    }

    public async Task TrainAndEvaluateAsync()
    {
        var inputs = await CreateTrainingInputsAsync();

        if (inputs.Count < 100)
        {
            Console.WriteLine($"学習データが少なすぎます。件数: {inputs.Count}");
            return;
        }

        Console.WriteLine($"DataCount: {inputs.Count}");
        Console.WriteLine($"AvgLabel: {inputs.Average(x => x.FutureMaxReturn10):F2}%");
        Console.WriteLine($"MaxLabel: {inputs.Max(x => x.FutureMaxReturn10):F2}%");
        Console.WriteLine($"MinLabel: {inputs.Min(x => x.FutureMaxReturn10):F2}%");

        // 共通Trainerで時系列分割・FastTree回帰学習・検証データ予測を行う。
        var trainingResult = _regressionTrainer.TrainFastTree(
            inputs,
            GetFeatureColumns());

        var model = trainingResult.Model;
        var trainSet = trainingResult.TrainSet;
        var predictions = trainingResult.Predictions;

        _regressionEvaluator.Evaluate(
            modelTitle: "TakeProfit",
            predictions: predictions);

        // 学習済みTakeProfitモデルを共通ModelStore経由で保存する。
        var modelPath = _modelStore.SaveModel(
            model,
            trainSet.Schema,
            "takeprofit-model");

        Console.WriteLine($"モデル保存: {modelPath}");

        await ShowLatestPredictionRankingAsync(model);
    }

    /// <summary>
    /// CSVキャッシュからTakeProfit学習用入力データを作成する。
    /// 学習時のAzure SQLアクセスと特徴量再計算を避けるために使用する。
    /// </summary>
    /// <returns>TakeProfit学習用入力データ。</returns>
    private Task<List<MlTakeProfitInput>> CreateTrainingInputsAsync()
    {
        // CSVキャッシュから学習データを読み込み、時系列順に並べる。
        var inputs = LoadTrainingDataFromCsv()
            .OrderBy(x => x.TradeDate)
            .ToList();

        return Task.FromResult(inputs);
    }

    /// <summary>
    /// CSVキャッシュからTakeProfit学習用データを読み込む。
    /// 学習・特徴量重要度分析でDBアクセスと特徴量再計算を避けるために使用する。
    /// </summary>
    /// <returns>TakeProfit学習用入力データ。</returns>
    private List<MlTakeProfitInput> LoadTrainingDataFromCsv()
    {
        var path = Path.Combine(
            AppContext.BaseDirectory,
            "MlCache",
            "takeprofit_training_data.csv");

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
                $"TakeProfit学習用CSVキャッシュが見つかりません。先にRUN_EXPORT_TAKEPROFIT_TRAINING_CACHE=trueで出力してください: {path}");
        }

        var lines = File.ReadAllLines(path)
            .Skip(1);

        var list = new List<MlTakeProfitInput>();

        foreach (var line in lines)
        {
            // 空行は学習データとして扱わない。
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            var c = line.Split(',');

            // CSV列数が想定と異なる場合は、キャッシュ生成ミスとして明示的に停止する。
            if (c.Length < 17)
            {
                throw new InvalidOperationException(
                    $"TakeProfit学習用CSVの列数が不足しています。Columns:{c.Length}, Line:{line}");
            }

            list.Add(new MlTakeProfitInput
            {
                TradeDate = DateTime.Parse(
                    c[0],
                    CultureInfo.InvariantCulture),

                FinancialScore = ParseFloat(c[2]),
                GrowthScore = ParseFloat(c[3]),
                DividendScore = ParseFloat(c[4]),
                RoeScore = ParseFloat(c[5]),
                PerScore = ParseFloat(c[6]),
                PbrScore = ParseFloat(c[7]),
                TechnicalScore = ParseFloat(c[8]),
                SwingScore = ParseFloat(c[9]),
                Momentum5 = ParseFloat(c[10]),
                Momentum25 = ParseFloat(c[11]),
                DeviationFromMa25 = ParseFloat(c[12]),
                ClosePositionInRange25 = ParseFloat(c[13]),
                Ma25Slope = ParseFloat(c[14]),

                TopixMomentum25 = ParseFloat(c[15]),

                FutureMaxReturn10 = ParseFloat(c[16])
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

    /// <summary>
    /// TakeProfit回帰モデルで使用する特徴量列名を取得する。
    /// Feature Importanceの結果から、寄与が弱かったMarketScore、VolumeRatio5、Ma75Slopeは除外している。
    /// </summary>
    /// <returns>TakeProfit回帰モデルで使用する特徴量列名。</returns>
    private static string[] GetFeatureColumns()
    {
        return
        [
            nameof(MlTakeProfitInput.FinancialScore),
        nameof(MlTakeProfitInput.GrowthScore),
        nameof(MlTakeProfitInput.DividendScore),
        nameof(MlTakeProfitInput.RoeScore),
        nameof(MlTakeProfitInput.PerScore),
        nameof(MlTakeProfitInput.PbrScore),
        nameof(MlTakeProfitInput.TechnicalScore),
        nameof(MlTakeProfitInput.SwingScore),

        nameof(MlTakeProfitInput.Momentum5),
        nameof(MlTakeProfitInput.Momentum25),
        nameof(MlTakeProfitInput.DeviationFromMa25),
        nameof(MlTakeProfitInput.ClosePositionInRange25),
        nameof(MlTakeProfitInput.Ma25Slope),

        nameof(MlTakeProfitInput.TopixMomentum25)
        ];
    }

    /// <summary>
    /// TakeProfit回帰モデルで使用する基本パイプラインを作成する。
    /// 実際の特徴量結合・正規化はMlRegressionPipelineFactoryへ委譲する。
    /// </summary>
    /// <returns>特徴量変換パイプライン。</returns>
    private IEstimator<ITransformer> CreateBasePipeline()
    {
        // TakeProfitモデル固有の特徴量一覧を取得する。
        var featureColumns = GetFeatureColumns();

        // 回帰パイプライン生成を専用Factoryへ委譲する。
        return _regressionPipelineFactory.CreateBasePipeline(featureColumns);
    }

    private async Task ShowLatestPredictionRankingAsync(ITransformer model)
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

        latestScoreRows = latestScoreRows
            .Where(x => !excludedNameKeywords.Any(keyword =>
                x.Company.CompanyName.Contains(keyword)))
            .ToList();

        var predictionEngine =
            _mlContext.Model.CreatePredictionEngine<MlTakeProfitInput, MlTakeProfitOutput>(model);

        var ranking = new List<dynamic>();

        foreach (var row in latestScoreRows)
        {
            var technicalFeatures = await CalculateTechnicalFeaturesAsync(
                row.Score.Code,
                row.Score.ScoreDate);

            if (technicalFeatures == null)
            {
                continue;
            }

            var marketFeatures = await CalculateMarketFeaturesAsync(
                row.Score.ScoreDate);

            var input = new MlTakeProfitInput
            {
                FinancialScore = row.Score.FinancialScore,
                GrowthScore = row.Score.GrowthScore,
                DividendScore = row.Score.DividendScore,
                RoeScore = row.Score.RoeScore,
                PerScore = row.Score.PerScore,
                PbrScore = row.Score.PbrScore,
                TechnicalScore = row.Score.TechnicalScore,
                SwingScore = row.Score.SwingScore,
                MarketScore = row.Score.MarketScore,

                Momentum5 = technicalFeatures.Momentum5,
                Momentum25 = technicalFeatures.Momentum25,
                DeviationFromMa25 = technicalFeatures.DeviationFromMa25,
                VolumeRatio5 = technicalFeatures.VolumeRatio5,
                ClosePositionInRange25 = technicalFeatures.ClosePositionInRange25,
                Ma25Slope = technicalFeatures.Ma25Slope,
                Ma75Slope = technicalFeatures.Ma75Slope,

                // TakeProfitモデルではFeature Importanceの結果から
                // 米国指数・為替・VIX系の寄与がほぼゼロだった。
                // 学習時と予測時の特徴量を一致させるため、ここでも削除する。
                TopixMomentum25 = marketFeatures.TopixMomentum25
            };

            var prediction = predictionEngine.Predict(input);

            ranking.Add(new
            {
                row.Score.Code,
                row.Company.CompanyName,
                row.Score.TotalScore,
                row.Score.SwingScore,
                ExpectedTakeProfit = prediction.Score
            });
        }

        Console.WriteLine();
        Console.WriteLine($"=== 最新スコア TakeProfit 予測ランキング: {latestScoreDate:yyyy-MM-dd} ===");

        foreach (var item in ranking
                     .OrderByDescending(x => x.ExpectedTakeProfit)
                     .Take(20))
        {
            Console.WriteLine(
                $"{item.Code} {item.CompanyName} " +
                $"Total:{item.TotalScore} " +
                $"Swing:{item.SwingScore} " +
                $"ExpectedTP:{item.ExpectedTakeProfit:F2}%");
        }
    }

    private class TechnicalFeatureValues
    {
        public float Momentum5 { get; set; }

        public float Momentum25 { get; set; }

        public float DeviationFromMa25 { get; set; }

        public float VolumeRatio5 { get; set; }

        public float ClosePositionInRange25 { get; set; }

        public float Ma25Slope { get; set; }

        public float Ma75Slope { get; set; }
    }

    private class MarketFeatureValues
    {
        public float TopixMomentum25 { get; set; }

        public float Sp500Momentum25 { get; set; }

        public float NasdaqMomentum25 { get; set; }

        public float UsdJpyMomentum25 { get; set; }

        public float VixMomentum25 { get; set; }
    }

    private async Task<TechnicalFeatureValues?> CalculateTechnicalFeaturesAsync(
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

        return new TechnicalFeatureValues
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

    private async Task<TechnicalFeatureValues?> GetTechnicalFeaturesWithCacheAsync(
    string code,
    DateTime tradeDate)
    {
        var key = $"{code}_{tradeDate:yyyyMMdd}";

        if (_technicalFeatureCache.TryGetValue(key, out var cached))
        {
            return cached;
        }

        var technicalFeatures = await CalculateTechnicalFeaturesAsync(
            code,
            tradeDate);

        _technicalFeatureCache[key] = technicalFeatures;

        return technicalFeatures;
    }

    private async Task<MarketFeatureValues> CalculateMarketFeaturesAsync(
        DateTime tradeDate)
    {
        return new MarketFeatureValues
        {
            TopixMomentum25 = await CalculateMarketMomentum25Async("TOPIX", tradeDate),
            Sp500Momentum25 = await CalculateMarketMomentum25Async("SP500", tradeDate),
            NasdaqMomentum25 = await CalculateMarketMomentum25Async("NASDAQ", tradeDate),
            UsdJpyMomentum25 = await CalculateMarketMomentum25Async("USDJPY", tradeDate),
            VixMomentum25 = await CalculateMarketMomentum25Async("VIX", tradeDate)
        };
    }

    private async Task<MarketFeatureValues> GetMarketFeaturesWithCacheAsync(
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

    /// <summary>
    /// TakeProfitモデルを読み込む。
    /// 実際の読込・キャッシュ処理は共通ModelStoreへ委譲する。
    /// </summary>
    /// <returns>読み込み済みTakeProfitモデル。</returns>
    private ITransformer LoadModel()
    {
        return _modelStore.GetOrLoadModel(
            modelName: "takeprofit-model",
            modelTitle: "TakeProfit");
    }

    public async Task<Dictionary<string, decimal>> PredictLatestTakeProfitAsync()
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

        var marketFeatures = await GetMarketFeaturesWithCacheAsync(latestScoreDate);

        var inputs = new List<MlTakeProfitInput>();
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

            inputs.Add(new MlTakeProfitInput
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

                TopixMomentum25 = marketFeatures.TopixMomentum25
            });

            codeList.Add(score.Code);
        }

        if (inputs.Count == 0)
        {
            return new Dictionary<string, decimal>();
        }

        var dataView = _mlContext.Data.LoadFromEnumerable(inputs);
        var predictions = model.Transform(dataView);

        var predictionRows = _mlContext.Data
            .CreateEnumerable<MlTakeProfitOutput>(
                predictions,
                reuseRowObject: false)
            .ToList();

        var result = new Dictionary<string, decimal>();

        for (var i = 0; i < predictionRows.Count; i++)
        {
            result[codeList[i]] = Math.Round(
                (decimal)predictionRows[i].Score,
                4);
        }

        return result;
    }

    /// <summary>
    /// TakeProfitモデルを読み込む。
    /// 実際の読込・キャッシュ処理は共通ModelStoreへ委譲する。
    /// </summary>
    /// <returns>読み込み済みTakeProfitモデル。</returns>
    private ITransformer GetOrLoadModel()
    {
        return _modelStore.GetOrLoadModel(
            modelName: "takeprofit-model",
            modelTitle: "TakeProfit");
    }

    public async Task<decimal?> PredictAsync(StockScoreDaily score)
    {
        // 共通PredictionEngineStoreからTakeProfit用PredictionEngineを取得する。
        var predictionEngine = _predictionEngineStore.GetOrCreatePredictionEngine(
            modelName: "takeprofit-model",
            modelTitle: "TakeProfit");

        var technicalFeatures = await GetTechnicalFeaturesWithCacheAsync(
            score.Code,
            score.ScoreDate);

        if (technicalFeatures == null)
        {
            return null;
        }

        var marketFeatures = await GetMarketFeaturesWithCacheAsync(score.ScoreDate);

        var input = new MlTakeProfitInput
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

            TopixMomentum25 = marketFeatures.TopixMomentum25
        };

        var prediction = predictionEngine.Predict(input);

        return Math.Max(
            0m,
            Math.Round((decimal)prediction.Score, 4));
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

    public async Task AnalyzeFeatureImportanceAsync()
    {
        var inputs = await CreateTrainingInputsAsync();

        if (inputs.Count < 100)
        {
            Console.WriteLine($"特徴量重要度分析に必要なデータが少なすぎます。件数: {inputs.Count}");
            return;
        }

        var orderedInputs = inputs
            .OrderBy(x => x.TradeDate)
            .ToList();

        var trainCount = (int)(orderedInputs.Count * 0.8);

        var trainInputs = orderedInputs
            .Take(trainCount)
            .ToList();

        var testInputs = orderedInputs
            .Skip(trainCount)
            .ToList();

        var trainSet = _mlContext.Data.LoadFromEnumerable(trainInputs);
        var testSet = _mlContext.Data.LoadFromEnumerable(testInputs);

        var basePipeline = CreateBasePipeline();

        var featureTransformer = basePipeline.Fit(trainSet);

        var transformedTrainSet = featureTransformer.Transform(trainSet);
        var transformedTestSet = featureTransformer.Transform(testSet);

        var trainer = _mlContext.Regression.Trainers.FastTree(
            labelColumnName: "Label",
            featureColumnName: "Features",
            numberOfLeaves: 16,
            numberOfTrees: 200,
            minimumExampleCountPerLeaf: 10);

        var model = trainer.Fit(transformedTrainSet);

        var predictions = model.Transform(transformedTestSet);

        _regressionEvaluator.Evaluate(
            modelTitle: "TakeProfit",
            predictions: predictions);

        var permutationMetrics =
            _mlContext.Regression.PermutationFeatureImportance(
                model,
                transformedTestSet,
                labelColumnName: "Label",
                permutationCount: 5);

        var featureNames = GetFeatureColumns();

        Console.WriteLine();
        Console.WriteLine("=== TakeProfit 特徴量重要度 ===");

        var ranking = permutationMetrics
            .Select((item, index) => new
            {
                FeatureName = featureNames[index],
                RSquaredDrop = item.RSquared.Mean,
                RmseIncrease = item.RootMeanSquaredError.Mean,
                MaeIncrease = item.MeanAbsoluteError.Mean
            })
            .OrderByDescending(x => Math.Abs(x.RSquaredDrop))
            .ToList();

        foreach (var item in ranking)
        {
            Console.WriteLine(
                $"{item.FeatureName,-30} " +
                $"RSquaredDrop:{item.RSquaredDrop:F6} " +
                $"RMSE:{item.RmseIncrease:F6} " +
                $"MAE:{item.MaeIncrease:F6}");
        }
    }

    private TechnicalFeatureValues? CalculateTechnicalFeaturesFromPrices(
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

        return new TechnicalFeatureValues
        {
            Momentum5 = (float)((latestClose - close5Ago.Value) / close5Ago.Value * 100m),
            Momentum25 = (float)((latestClose - close25Ago.Value) / close25Ago.Value * 100m),
            DeviationFromMa25 = ma25 <= 0 ? 0 : (float)((latestClose - ma25) / ma25 * 100m),
            VolumeRatio5 = avgVolume25 <= 0 ? 0 : (float)(avgVolume5 / avgVolume25),
            ClosePositionInRange25 = range25 <= 0 ? 0.5f : (float)((latestClose - low25) / range25),
            Ma25Slope = previousMa25 <= 0 ? 0 : (float)((ma25 - previousMa25) / previousMa25 * 100m),
            Ma75Slope = previousMa75 <= 0 ? 0 : (float)((ma75 - previousMa75) / previousMa75 * 100m)
        };
    }
}