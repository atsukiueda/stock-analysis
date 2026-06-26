using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.ML.Trainers.FastTree;
using StockAnalysis.Batch.Models.Ml;
using StockAnalysis.Batch.Services.Interfaces;

namespace StockAnalysis.Batch.Services;

public class MlUp5PredictionService : IMlWalkForwardTrainingService
{
    private const string ModelDirectory = "Models";

    private const string DefaultModelName = "up5-model";

    private readonly StockAnalysisDbContext _db;
    private readonly MLContext _mlContext;

    private readonly Dictionary<DateTime, MarketFeatureValues> _marketFeatureCache = new();

    private readonly Dictionary<string, TechnicalFeatureValues?> _technicalFeatureCache = new();

    private readonly Dictionary<string, List<PriceDaily>> _priceHistoryCache = new();

    private readonly Dictionary<string, List<MarketIndexDaily>> _marketIndexHistoryCache = new();

    public MlUp5PredictionService(StockAnalysisDbContext db)
    {
        _db = db;
        _mlContext = new MLContext(seed: 1);
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

            var technicalFeatures = await GetTechnicalFeaturesWithCacheAsync(
                score.Code,
                score.ScoreDate);

            if (technicalFeatures == null)
            {
                continue;
            }

            var marketFeatures = await CalculateMarketFeaturesAsync(score.ScoreDate);

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

    private class MlStockPredictionWithLabel
    {
        public bool Label { get; set; }

        public bool PredictedLabel { get; set; }

        public float Probability { get; set; }

        public float Score { get; set; }
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

    private class ModelEvaluationResult
    {
        public required string ModelName { get; set; }

        public double Accuracy { get; set; }

        public double Auc { get; set; }

        public double F1Score { get; set; }

        public int PredictedPositiveCount { get; set; }

        public int PredictedNegativeCount { get; set; }

        public int Top20HitCount { get; set; }

        public double Top20HitRate { get; set; }
    }

    private ModelEvaluationResult EvaluateModel(
    string modelName,
    ITransformer model,
    IDataView testSet)
    {
        var predictions = model.Transform(testSet);

        var predictionRows = _mlContext.Data
            .CreateEnumerable<MlStockPredictionWithLabel>(
                predictions,
                reuseRowObject: false)
            .ToList();

        var predictedPositiveCount = predictionRows.Count(x => x.PredictedLabel);
        var predictedNegativeCount = predictionRows.Count - predictedPositiveCount;

        var top20 = predictionRows
            .OrderByDescending(x => x.Probability)
            .Take(20)
            .ToList();

        var top20HitCount = top20.Count(x => x.Label);
        var top20HitRate = top20.Count == 0
            ? 0
            : (double)top20HitCount / top20.Count;

        var metrics = _mlContext.BinaryClassification.Evaluate(
            predictions,
            labelColumnName: "Label");

        Console.WriteLine();
        Console.WriteLine($"=== {modelName} 評価結果 ===");
        Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
        Console.WriteLine($"AUC     : {metrics.AreaUnderRocCurve:P2}");
        Console.WriteLine($"F1Score : {metrics.F1Score:P2}");
        Console.WriteLine($"Predicted True : {predictedPositiveCount}");
        Console.WriteLine($"Predicted False: {predictedNegativeCount}");
        Console.WriteLine($"Test Top20 HitCount: {top20HitCount}");
        Console.WriteLine($"Test Top20 HitRate : {top20HitRate:P2}");

        return new ModelEvaluationResult
        {
            ModelName = modelName,
            Accuracy = metrics.Accuracy,
            Auc = metrics.AreaUnderRocCurve,
            F1Score = metrics.F1Score,
            PredictedPositiveCount = predictedPositiveCount,
            PredictedNegativeCount = predictedNegativeCount,
            Top20HitCount = top20HitCount,
            Top20HitRate = top20HitRate
        };
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

        var marketFeatures = await GetMarketFeaturesWithCacheAsync(latestScoreDate);

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

        var dataView = _mlContext.Data.LoadFromEnumerable(inputs);

        var predictions = model.Transform(dataView);

        var predictionRows = _mlContext.Data
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

    private readonly Dictionary<string, ITransformer> _loadedModelCache = new();

    private readonly Dictionary<string, PredictionEngine<MlStockPredictionInput, MlStockPredictionOutput>> _predictionEngineCache = new();

    /// <summary>
    /// 指定されたモデル名のUp5モデルを読み込む。
    /// 同じモデルはキャッシュし、毎回zipを読み直さない。
    /// </summary>
    /// <param name="modelName">モデル名。拡張子なし。</param>
    /// <returns>読み込み済みモデル。</returns>
    private ITransformer GetOrLoadModel(string modelName)
    {
        if (_loadedModelCache.TryGetValue(modelName, out var cachedModel))
        {
            return cachedModel;
        }

        var modelPath = CreateModelPath(modelName);

        if (!File.Exists(modelPath))
        {
            throw new FileNotFoundException(
                $"Up5モデルが見つかりません: {modelPath}");
        }

        var model = _mlContext.Model.Load(modelPath, out _);

        _loadedModelCache[modelName] = model;

        return model;
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
        var model = GetOrLoadModel(modelName);

        if (!_predictionEngineCache.TryGetValue(modelName, out var predictionEngine))
        {
            predictionEngine =
                _mlContext.Model.CreatePredictionEngine<MlStockPredictionInput, MlStockPredictionOutput>(model);

            _predictionEngineCache[modelName] = predictionEngine;
        }

        var technicalFeatures = await GetTechnicalFeaturesWithCacheAsync(
            score.Code,
            score.ScoreDate);

        if (technicalFeatures == null)
        {
            return null;
        }

        var marketFeatures = await GetMarketFeaturesWithCacheAsync(score.ScoreDate);

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
            ClosePositionInRange25 = technicalFeatures.ClosePositionInRange25,
            Ma25Slope = technicalFeatures.Ma25Slope,
            Ma75Slope = technicalFeatures.Ma75Slope,

            TopixMomentum25 = marketFeatures.TopixMomentum25,
            Sp500Momentum25 = marketFeatures.Sp500Momentum25,
            NasdaqMomentum25 = marketFeatures.NasdaqMomentum25,
            UsdJpyMomentum25 = marketFeatures.UsdJpyMomentum25,
            VixMomentum25 = marketFeatures.VixMomentum25
        };

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
    /// ウォークフォワード検証では、このメソッドで未来データ混入を防ぐ。
    /// </summary>
    /// <param name="period">学習期間と保存モデル名を表す期間定義。</param>
    /// <returns>学習済みUp5モデル。</returns>
    private async Task<ITransformer> TrainBestModelAsync(TrainingPeriod period)
    {
        var inputs = await CreateTrainingInputsAsync(period);

        if (inputs.Count < 50)
        {
            throw new InvalidOperationException(
                $"Up5学習データが少なすぎます。Model:{period.ModelName}, Count:{inputs.Count}");
        }

        var orderedInputs = inputs
            .OrderBy(x => x.TradeDate)
            .ToList();

        var trainSet = _mlContext.Data.LoadFromEnumerable(orderedInputs);

        var basePipeline = CreateBasePipeline();

        var sdcaPipeline = basePipeline.Append(
            _mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                labelColumnName: "Label",
                featureColumnName: "Features"));

        var fastTreePipeline = basePipeline.Append(
            _mlContext.BinaryClassification.Trainers.FastTree(
                labelColumnName: "Label",
                featureColumnName: "Features",
                numberOfLeaves: 8,
                numberOfTrees: 100,
                minimumExampleCountPerLeaf: 10));

        // 学習期間内の最終20%を疑似検証データとして使い、採用モデルを選ぶ。
        // 本物のウォークフォワード評価は別途 TestFrom-TestTo のバックテストで行う。
        var validationStartIndex = (int)(orderedInputs.Count * 0.8);

        var trainInputs = orderedInputs
            .Take(validationStartIndex)
            .ToList();

        var validationInputs = orderedInputs
            .Skip(validationStartIndex)
            .ToList();

        var modelTrainSet = _mlContext.Data.LoadFromEnumerable(trainInputs);
        var validationSet = _mlContext.Data.LoadFromEnumerable(validationInputs);

        var sdcaModel = sdcaPipeline.Fit(modelTrainSet);
        var fastTreeModel = fastTreePipeline.Fit(modelTrainSet);

        var sdcaResult = EvaluateModel(
            modelName: "SdcaLogisticRegression",
            model: sdcaModel,
            testSet: validationSet);

        var fastTreeResult = EvaluateModel(
            modelName: "FastTree",
            model: fastTreeModel,
            testSet: validationSet);

        ITransformer bestModel;

        if (fastTreeResult.Top20HitRate >= sdcaResult.Top20HitRate)
        {
            bestModel = fastTreeModel;
        }
        else
        {
            bestModel = sdcaModel;
        }

        var bestModelName = fastTreeResult.Top20HitRate >= sdcaResult.Top20HitRate
            ? "FastTree"
            : "SdcaLogisticRegression";

        Console.WriteLine();
        Console.WriteLine($"=== Up5 採用モデル: {bestModelName} ===");
        Console.WriteLine($"ModelName : {period.ModelName}");
        Console.WriteLine($"TrainDate : {period.TrainFrom:yyyy-MM-dd} - {period.TrainTo:yyyy-MM-dd}");

        Directory.CreateDirectory(Path.Combine(AppContext.BaseDirectory, ModelDirectory));

        var modelPath = CreateModelPath(period.ModelName);

        _mlContext.Model.Save(
            bestModel,
            trainSet.Schema,
            modelPath);

        Console.WriteLine($"モデル保存: {modelPath}");

        return bestModel;
    }

    private IEstimator<ITransformer> CreateBasePipeline()
    {
        return _mlContext.Transforms.Concatenate(
                "Features",
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
                nameof(MlStockPredictionInput.Ma75Slope))
            .Append(_mlContext.Transforms.NormalizeMinMax("Features"));
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
        "ETN"
    };

        var trainingSourceRows = await _db.MlTrainingData
            .AsNoTracking()
            .Where(x => x.FutureReturn5 != null)
            .Where(x => x.TradeDate >= period.TrainFrom)
            .Where(x => x.TradeDate <= period.TrainTo)
            .Join(
                _db.Companies,
                ml => ml.Code,
                company => company.Code,
                (ml, company) => new
                {
                    Ml = ml,
                    Company = company
                })
            .Where(x => x.Company.IsActive)
            .ToListAsync();

        var inputs = new List<MlStockPredictionInput>();

        foreach (var row in trainingSourceRows
                     .Where(x => !excludedNameKeywords.Any(keyword =>
                         x.Company.CompanyName.Contains(keyword)))
                     .OrderBy(x => x.Ml.TradeDate))
        {
            var technicalFeatures = await CalculateTechnicalFeaturesAsync(
                row.Ml.Code,
                row.Ml.TradeDate);

            if (technicalFeatures == null)
            {
                continue;
            }

            var marketFeatures = await CalculateMarketFeaturesAsync(
                row.Ml.TradeDate);

            inputs.Add(new MlStockPredictionInput
            {
                TradeDate = row.Ml.TradeDate,

                FinancialScore = row.Ml.FinancialScore,
                GrowthScore = row.Ml.GrowthScore,
                DividendScore = row.Ml.DividendScore,
                RoeScore = row.Ml.RoeScore,
                PerScore = row.Ml.PerScore,
                PbrScore = row.Ml.PbrScore,
                TechnicalScore = row.Ml.TechnicalScore,
                SwingScore = row.Ml.SwingScore,
                MarketScore = row.Ml.MarketScore,

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
                VixMomentum25 = marketFeatures.VixMomentum25,

                Up5 = row.Ml.Up5
            });
        }

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

    /// <summary>
    /// Up5モデルの保存パスを作成する。
    /// ウォークフォワードでは period.ModelName ごとに別ファイルへ保存する。
    /// </summary>
    /// <param name="modelName">モデル名。拡張子なしを想定する。</param>
    /// <returns>モデルzipファイルのパス。</returns>
    private static string CreateModelPath(string modelName)
    {
        return Path.Combine(
            AppContext.BaseDirectory,
            ModelDirectory,
            $"{modelName}.zip");
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