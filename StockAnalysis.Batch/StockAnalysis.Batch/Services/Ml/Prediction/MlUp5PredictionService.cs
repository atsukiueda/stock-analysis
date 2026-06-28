using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.ML.Trainers.FastTree;
using StockAnalysis.Batch.Models.Ml;
using StockAnalysis.Batch.Services.Interfaces;
using System.Globalization;
using StockAnalysis.Batch.Services.Ml.Base;
using StockAnalysis.Batch.Services.Ml.Features;

namespace StockAnalysis.Batch.Services.Ml.Prediction;

public class MlUp5PredictionService : MlBinaryPredictionServiceBase, IMlWalkForwardTrainingService
{

    private const string DefaultModelName = "up5-model";

    private readonly StockAnalysisDbContext _db;

    private readonly MlFeatureCalculationService _featureCalculationService;

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    /// <param name="db">DBコンテキスト。</param>
    public MlUp5PredictionService(
        StockAnalysisDbContext db)
    {
        _db = db;
        _featureCalculationService = new MlFeatureCalculationService(db);
    }

    /// <summary>
    /// 既存処理との互換性を保つため、全期間データでUp5モデルを学習・評価する。
    /// 新規のウォークフォワード検証では TrainingPeriod 指定版を使用する。
    /// </summary>
    public Task TrainAndEvaluateAsync()
    {
        var period = new TrainingPeriod
        {
            TrainFrom = DateTime.MinValue,
            TrainTo = DateTime.MaxValue,
            TestFrom = DateTime.MinValue,
            TestTo = DateTime.MaxValue,
            ModelName = DefaultModelName
        };

        return TrainAndEvaluateAsync(period);
    }

    /// <summary>
    /// 指定されたTrainingPeriodに従ってUp5モデルを学習・保存する。
    /// ここでは学習期間内の評価までを行い、TestFrom-TestToの本番評価はバックテスト側で行う。
    /// </summary>
    /// <param name="period">学習期間・テスト期間・モデル名を持つ期間定義。</param>
    public async Task TrainAndEvaluateAsync(TrainingPeriod period)
    {
        var inputs = await CreateTrainingInputsAsync(period);

        if (inputs.Count < 50)
        {
            Console.WriteLine($"学習データが少なすぎます。Model:{period.ModelName}, 件数:{inputs.Count}");
            return;
        }

        var positiveCount = inputs.Count(x => x.Up5);
        var negativeCount = inputs.Count - positiveCount;

        Console.WriteLine();
        Console.WriteLine("=== Up5 学習データ概要 ===");
        Console.WriteLine($"ModelName   : {period.ModelName}");
        Console.WriteLine($"TrainPeriod : {period.TrainFrom:yyyy-MM-dd} - {period.TrainTo:yyyy-MM-dd}");
        Console.WriteLine($"TestPeriod  : {period.TestFrom:yyyy-MM-dd} - {period.TestTo:yyyy-MM-dd}");
        Console.WriteLine($"DataCount   : {inputs.Count}");
        Console.WriteLine($"Up5=True    : {positiveCount}");
        Console.WriteLine($"Up5=False   : {negativeCount}");
        Console.WriteLine($"PositiveRate: {(double)positiveCount / inputs.Count:P2}");

        var bestModel = await TrainBestModelAsync(period);

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

        //await ShowLatestPredictionRankingAsync(bestModel, excludedNameKeywords);
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

            var marketFeatures = await _featureCalculationService.GetMarketFeaturesAsync(score.ScoreDate);

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

            rankingSource.Add(new
            {
                score.Code,
                x.Company.CompanyName,
                score.TotalScore,
                score.SwingScore
            });
        }

        //var ranking = rankingSource
        //    .OrderByDescending(x => x.Up5Probability)
        //    .Take(20)
        //    .ToList();

        //Console.WriteLine();
        //Console.WriteLine($"=== 最新スコア Up5 予測ランキング: {latestScoreDate:yyyy-MM-dd} ===");

        //foreach (var item in ranking)
        //{
        //    Console.WriteLine(
        //        $"{item.Code} {item.CompanyName} Total:{item.TotalScore} Swing:{item.SwingScore} Up5Prob:{item.Up5Probability:P2}");
        //}
    }

    public async Task<Dictionary<string, decimal>> PredictLatestProbabilitiesAsync()
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
    /// 指定されたモデル名のUp5モデルを読み込む。
    /// 同じモデルは共通基底クラスでキャッシュし、毎回zipを読み直さない。
    /// </summary>
    /// <param name="modelName">モデル名。拡張子なし。</param>
    /// <returns>読み込み済みモデル。</returns>
    private ITransformer GetOrLoadModel(string modelName)
    {
        return GetOrLoadModel(
            modelName: modelName,
            modelTitle: "Up5");
    }

    /// <summary>
    /// 既存処理との互換性を保つため、デフォルトUp5モデルを読み込む。
    /// </summary>
    /// <returns>読み込み済みモデル。</returns>
    private ITransformer GetOrLoadModel()
    {
        return GetOrLoadModel(DefaultModelName);
    }

    /// <summary>
    /// 既存処理との互換性を保つため、デフォルトUp5モデルで予測する。
    /// </summary>
    /// <param name="score">予測対象日の銘柄スコア。</param>
    /// <returns>Up5上昇確率。計算不能な場合はnull。</returns>
    public Task<decimal?> PredictAsync(StockScoreDaily score)
    {
        return PredictAsync(score, DefaultModelName);
    }

    /// <summary>
    /// 指定されたモデル名のUp5モデルを使って、対象銘柄の5営業日上昇確率を予測する。
    /// ウォークフォワード検証では、テスト年に対応するモデル名を指定する。
    /// </summary>
    /// <param name="score">予測対象日の銘柄スコア。</param>
    /// <param name="modelName">使用するモデル名。例: up5_2022_2023。</param>
    /// <returns>Up5上昇確率。計算不能な場合はnull。</returns>
    public async Task<decimal?> PredictAsync(
        StockScoreDaily score,
        string modelName)
    {
        // 共通基底クラスから、モデル名単位でキャッシュされたPredictionEngineを取得する。
        var predictionEngine = GetOrCreatePredictionEngine(
            modelName: modelName,
            modelTitle: "Up5");

        var technicalFeatures = await _featureCalculationService.GetTechnicalFeaturesAsync(
            score.Code,
            score.ScoreDate);

        if (technicalFeatures == null)
        {
            return null;
        }

        var marketFeatures = await _featureCalculationService.GetMarketFeaturesAsync(
            score.ScoreDate);

        // 銘柄スコア・テクニカル特徴量・市場特徴量からML入力を作成する。
        var input = CreatePredictionInput(
            score,
            technicalFeatures,
            marketFeatures);

        var prediction = predictionEngine.Predict(input);

        return Math.Round((decimal)prediction.Probability * 100m, 4);
    }

    /// <summary>
    /// 既存処理との互換性を保つため、全期間データでUp5モデルを学習する。
    /// 新規のウォークフォワード検証では TrainingPeriod 指定版を使用する。
    /// </summary>
    /// <returns>学習済みUp5モデル。</returns>
    private Task<ITransformer> TrainBestModelAsync()
    {
        var period = new TrainingPeriod
        {
            TrainFrom = DateTime.MinValue,
            TrainTo = DateTime.MaxValue,
            TestFrom = DateTime.MinValue,
            TestTo = DateTime.MaxValue,
            ModelName = DefaultModelName
        };

        return TrainBestModelAsync(period);
    }

    /// <summary>
    /// 指定された学習期間のデータだけを使って、Up5の最良モデルを学習する。
    /// 共通基底クラスの二値分類学習処理を利用し、未来データ混入を防ぐ。
    /// </summary>
    /// <param name="period">学習期間と保存モデル名を表す期間定義。</param>
    /// <returns>学習済みUp5モデル。</returns>
    private async Task<ITransformer> TrainBestModelAsync(TrainingPeriod period)
    {
        // CSVキャッシュから学習期間内のUp5入力データを取得する。
        var inputs = await CreateTrainingInputsAsync(period);

        // 共通基底クラスでSdca/FastTreeの学習・評価・採用・保存を行う。
        return await TrainBestModelAsync(
            inputs: inputs,
            modelName: period.ModelName,
            modelTitle: "Up5",
            trainFrom: period.TrainFrom,
            trainTo: period.TrainTo);
    }

    /// <summary>
    /// Up5モデルで使用する特徴量列名を取得する。
    /// Feature Importance検証でAUC悪化が確認されたため、現時点では一部の市場特徴量を除外している。
    /// </summary>
    /// <returns>Up5モデルで使用する特徴量列名。</returns>
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
            nameof(MlStockPredictionInput.Ma25Slope),
            nameof(MlStockPredictionInput.Ma75Slope)
        ];
    }

    /// <summary>
    /// 既存処理との互換性を保つため、全期間を対象にUp5学習入力を作成する。
    /// 新規のウォークフォワード検証では TrainingPeriod 指定版を使用する。
    /// </summary>
    /// <returns>Up5学習用入力データ。</returns>
    private Task<List<MlStockPredictionInput>> CreateTrainingInputsAsync()
    {
        var period = new TrainingPeriod
        {
            TrainFrom = DateTime.MinValue,
            TrainTo = DateTime.MaxValue,
            TestFrom = DateTime.MinValue,
            TestTo = DateTime.MaxValue,
            ModelName = DefaultModelName
        };

        return CreateTrainingInputsAsync(period);
    }

    private async Task<List<MlStockPredictionInput>> CreateTrainingInputsAsync(
    TrainingPeriod period)
    {
        // CSVキャッシュから学習データを読み込む。
        var inputs = LoadTrainingDataFromCsv();

        // 学習期間のみ抽出する。
        inputs = inputs
            .Where(x =>
                x.TradeDate >= period.TrainFrom &&
                x.TradeDate <= period.TrainTo)
            .OrderBy(x => x.TradeDate)
            .ToList();

        return inputs;
    }

    /// <summary>
    /// 既存処理との互換性を保つため、デフォルトUp5モデルを読み込む。
    /// </summary>
    /// <returns>読み込み済みモデル。</returns>
    private ITransformer LoadModel()
    {
        return GetOrLoadModel(DefaultModelName);
    }

    private async Task<Dictionary<string, List<PriceDaily>>> GetPriceHistoryMapAsync(
    IReadOnlyCollection<string> codes)
    {
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

    /// <summary>
    /// 指定された学習期間のデータを使って、Up5モデルの特徴量重要度を分析する。
    /// ウォークフォワード期間ごとに、どの特徴量が効いているかを確認するために使用する。
    /// </summary>
    /// <param name="period">学習期間・検証期間・モデル名を持つ期間定義。</param>
    public async Task AnalyzeFeatureImportanceAsync(
        TrainingPeriod period)
    {
        Console.WriteLine();
        Console.WriteLine("=== Up5 Feature Importance 開始 ===");
        Console.WriteLine($"ModelName : {period.ModelName}");
        Console.WriteLine($"Train     : {period.TrainFrom:yyyy-MM-dd} - {period.TrainTo:yyyy-MM-dd}");

        var inputs = await CreateTrainingInputsAsync(period);

        if (inputs.Count < 100)
        {
            Console.WriteLine($"特徴量重要度分析にはデータが少なすぎます。件数:{inputs.Count}");
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

        var trainSet = MlContext.Data.LoadFromEnumerable(trainInputs);
        var testSet = MlContext.Data.LoadFromEnumerable(testInputs);

        var pipeline = CreateBasePipeline()
            .Append(MlContext.BinaryClassification.Trainers.FastTree(
                labelColumnName: "Label",
                featureColumnName: "Features",
                numberOfLeaves: 8,
                numberOfTrees: 100,
                minimumExampleCountPerLeaf: 10));

        var model = pipeline.Fit(trainSet);

        var transformedTestSet = model.Transform(testSet);

        var baselineMetrics = MlContext.BinaryClassification.Evaluate(
            transformedTestSet,
            labelColumnName: "Label");

        Console.WriteLine();
        Console.WriteLine("=== Baseline ===");
        Console.WriteLine($"Accuracy: {baselineMetrics.Accuracy:P2}");
        Console.WriteLine($"AUC     : {baselineMetrics.AreaUnderRocCurve:P2}");
        Console.WriteLine($"F1Score : {baselineMetrics.F1Score:P2}");

        var featureNames = new[]
        {
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
            //nameof(MlStockPredictionInput.Sp500Momentum25),
            //nameof(MlStockPredictionInput.NasdaqMomentum25),
            //nameof(MlStockPredictionInput.UsdJpyMomentum25),
            //nameof(MlStockPredictionInput.VixMomentum25),
            nameof(MlStockPredictionInput.Ma25Slope),
            nameof(MlStockPredictionInput.Ma75Slope)
        };

        var results = new List<(string FeatureName, double AucDrop, double AccuracyDrop, double F1Drop)>();

        foreach (var featureName in featureNames)
        {
            var shuffledInputs = testInputs
                .Select(x => CloneInput(x))
                .ToList();

            ShuffleFeature(
                shuffledInputs,
                featureName);

            var shuffledSet =
                MlContext.Data.LoadFromEnumerable(shuffledInputs);

            var shuffledPredictions =
                model.Transform(shuffledSet);

            var shuffledMetrics =
                MlContext.BinaryClassification.Evaluate(
                    shuffledPredictions,
                    labelColumnName: "Label");

            results.Add((
                FeatureName: featureName,
                AucDrop: baselineMetrics.AreaUnderRocCurve - shuffledMetrics.AreaUnderRocCurve,
                AccuracyDrop: baselineMetrics.Accuracy - shuffledMetrics.Accuracy,
                F1Drop: baselineMetrics.F1Score - shuffledMetrics.F1Score));
        }

        foreach (var item in results.OrderByDescending(x => x.AucDrop))
        {
            Console.WriteLine(
                $"{item.FeatureName,-28} " +
                $"AucDrop:{item.AucDrop,8:F4} " +
                $"AccuracyDrop:{item.AccuracyDrop,8:F4} " +
                $"F1Drop:{item.F1Drop,8:F4}");
        }

        Console.WriteLine("=== Up5 Feature Importance 終了 ===");
    }

    private static MlStockPredictionInput CloneInput(MlStockPredictionInput source)
    {
        return new MlStockPredictionInput
        {
            TradeDate = source.TradeDate,

            FinancialScore = source.FinancialScore,
            GrowthScore = source.GrowthScore,
            DividendScore = source.DividendScore,
            RoeScore = source.RoeScore,
            PerScore = source.PerScore,
            PbrScore = source.PbrScore,
            TechnicalScore = source.TechnicalScore,
            SwingScore = source.SwingScore,
            MarketScore = source.MarketScore,

            Momentum5 = source.Momentum5,
            Momentum25 = source.Momentum25,
            DeviationFromMa25 = source.DeviationFromMa25,
            VolumeRatio5 = source.VolumeRatio5,
            ClosePositionInRange25 = source.ClosePositionInRange25,
            Ma25Slope = source.Ma25Slope,
            Ma75Slope = source.Ma75Slope,

            TopixMomentum25 = source.TopixMomentum25,
            Sp500Momentum25 = source.Sp500Momentum25,
            NasdaqMomentum25 = source.NasdaqMomentum25,
            UsdJpyMomentum25 = source.UsdJpyMomentum25,
            VixMomentum25 = source.VixMomentum25,

            Up5 = source.Up5
        };
    }

    private static void ShuffleFeature(
        List<MlStockPredictionInput> inputs,
        string featureName)
    {
        var random = new Random(1);

        var values = inputs
            .Select(x => GetFeatureValue(x, featureName))
            .OrderBy(_ => random.Next())
            .ToList();

        for (var i = 0; i < inputs.Count; i++)
        {
            SetFeatureValue(
                inputs[i],
                featureName,
                values[i]);
        }
    }

    private static float GetFeatureValue(
        MlStockPredictionInput input,
        string featureName)
    {
        return featureName switch
        {
            nameof(MlStockPredictionInput.FinancialScore) => input.FinancialScore,
            nameof(MlStockPredictionInput.GrowthScore) => input.GrowthScore,
            nameof(MlStockPredictionInput.DividendScore) => input.DividendScore,
            nameof(MlStockPredictionInput.RoeScore) => input.RoeScore,
            nameof(MlStockPredictionInput.PerScore) => input.PerScore,
            nameof(MlStockPredictionInput.PbrScore) => input.PbrScore,
            nameof(MlStockPredictionInput.TechnicalScore) => input.TechnicalScore,
            nameof(MlStockPredictionInput.SwingScore) => input.SwingScore,
            nameof(MlStockPredictionInput.MarketScore) => input.MarketScore,
            nameof(MlStockPredictionInput.Momentum5) => input.Momentum5,
            nameof(MlStockPredictionInput.Momentum25) => input.Momentum25,
            nameof(MlStockPredictionInput.DeviationFromMa25) => input.DeviationFromMa25,
            nameof(MlStockPredictionInput.VolumeRatio5) => input.VolumeRatio5,
            nameof(MlStockPredictionInput.ClosePositionInRange25) => input.ClosePositionInRange25,
            nameof(MlStockPredictionInput.TopixMomentum25) => input.TopixMomentum25,
            nameof(MlStockPredictionInput.Sp500Momentum25) => input.Sp500Momentum25,
            nameof(MlStockPredictionInput.NasdaqMomentum25) => input.NasdaqMomentum25,
            nameof(MlStockPredictionInput.UsdJpyMomentum25) => input.UsdJpyMomentum25,
            nameof(MlStockPredictionInput.VixMomentum25) => input.VixMomentum25,
            nameof(MlStockPredictionInput.Ma25Slope) => input.Ma25Slope,
            nameof(MlStockPredictionInput.Ma75Slope) => input.Ma75Slope,
            _ => 0f
        };
    }

    private static void SetFeatureValue(
        MlStockPredictionInput input,
        string featureName,
        float value)
    {
        switch (featureName)
        {
            case nameof(MlStockPredictionInput.FinancialScore):
                input.FinancialScore = value;
                break;
            case nameof(MlStockPredictionInput.GrowthScore):
                input.GrowthScore = value;
                break;
            case nameof(MlStockPredictionInput.DividendScore):
                input.DividendScore = value;
                break;
            case nameof(MlStockPredictionInput.RoeScore):
                input.RoeScore = value;
                break;
            case nameof(MlStockPredictionInput.PerScore):
                input.PerScore = value;
                break;
            case nameof(MlStockPredictionInput.PbrScore):
                input.PbrScore = value;
                break;
            case nameof(MlStockPredictionInput.TechnicalScore):
                input.TechnicalScore = value;
                break;
            case nameof(MlStockPredictionInput.SwingScore):
                input.SwingScore = value;
                break;
            case nameof(MlStockPredictionInput.MarketScore):
                input.MarketScore = value;
                break;
            case nameof(MlStockPredictionInput.Momentum5):
                input.Momentum5 = value;
                break;
            case nameof(MlStockPredictionInput.Momentum25):
                input.Momentum25 = value;
                break;
            case nameof(MlStockPredictionInput.DeviationFromMa25):
                input.DeviationFromMa25 = value;
                break;
            case nameof(MlStockPredictionInput.VolumeRatio5):
                input.VolumeRatio5 = value;
                break;
            case nameof(MlStockPredictionInput.ClosePositionInRange25):
                input.ClosePositionInRange25 = value;
                break;
            case nameof(MlStockPredictionInput.TopixMomentum25):
                input.TopixMomentum25 = value;
                break;
            case nameof(MlStockPredictionInput.Sp500Momentum25):
                input.Sp500Momentum25 = value;
                break;
            case nameof(MlStockPredictionInput.NasdaqMomentum25):
                input.NasdaqMomentum25 = value;
                break;
            case nameof(MlStockPredictionInput.UsdJpyMomentum25):
                input.UsdJpyMomentum25 = value;
                break;
            case nameof(MlStockPredictionInput.VixMomentum25):
                input.VixMomentum25 = value;
                break;
            case nameof(MlStockPredictionInput.Ma25Slope):
                input.Ma25Slope = value;
                break;
            case nameof(MlStockPredictionInput.Ma75Slope):
                input.Ma75Slope = value;
                break;
        }
    }

    /// <summary>
    /// CSVキャッシュからUp5学習用データを読み込む。
    /// 学習・特徴量重要度分析・ウォークフォワード検証でDBアクセスを避けるために使用する。
    /// </summary>
    /// <returns>Up5学習用入力データ。</returns>
    private List<MlStockPredictionInput> LoadTrainingDataFromCsv()
    {
        var path = Path.Combine(
            AppContext.BaseDirectory,
            "MlCache",
            "up5_training_data.csv");

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
                $"Up5学習用CSVキャッシュが見つかりません。先にExportUp5TrainingDataAsyncを実行してください: {path}");
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

            // CSV列数が想定と異なる場合は、キャッシュの生成ミスとして明示的に止める。
            if (c.Length < 25)
            {
                throw new InvalidOperationException(
                    $"Up5学習用CSVの列数が不足しています。Columns:{c.Length}, Line:{line}");
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

                Up5 = bool.Parse(c[24])
            });
        }

        return list;
    }

    /// <summary>
    /// CSV文字列をfloat値へ変換する。
    /// 空文字は0として扱い、CSVキャッシュ生成時の欠損値で学習処理が停止しないようにする。
    /// </summary>f
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
}