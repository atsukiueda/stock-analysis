using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;
using static System.Formats.Asn1.AsnWriter;
using Microsoft.ML.Trainers.FastTree;

namespace StockAnalysis.Batch.Services;

public class MlUp5PredictionService
{
    private const string ModelDirectory = "Models";

    private const string ModelPath = "Models/up5-model.zip";

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

        var trainingSourceRows = await _db.MlTrainingData
            .Where(x => x.FutureReturn5 != null)
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

            var marketFeatures = await CalculateMarketFeaturesAsync(row.Ml.TradeDate);

            inputs.Add(new MlStockPredictionInput
            {
                FinancialScore = row.Ml.FinancialScore,
                GrowthScore = row.Ml.GrowthScore,
                DividendScore = row.Ml.DividendScore,
                RoeScore = row.Ml.RoeScore,
                PerScore = row.Ml.PerScore,
                PbrScore = row.Ml.PbrScore,
                TechnicalScore = row.Ml.TechnicalScore,
                SwingScore = row.Ml.SwingScore,
                MarketScore = row.Ml.MarketScore,
                TradeDate = row.Ml.TradeDate,
                TopixMomentum25 = marketFeatures.TopixMomentum25,
                Sp500Momentum25 = marketFeatures.Sp500Momentum25,
                NasdaqMomentum25 = marketFeatures.NasdaqMomentum25,
                UsdJpyMomentum25 = marketFeatures.UsdJpyMomentum25,
                VixMomentum25 = marketFeatures.VixMomentum25,
                Momentum5 = technicalFeatures.Momentum5,
                Momentum25 = technicalFeatures.Momentum25,
                DeviationFromMa25 = technicalFeatures.DeviationFromMa25,
                VolumeRatio5 = technicalFeatures.VolumeRatio5,
                ClosePositionInRange25 = technicalFeatures.ClosePositionInRange25,

                Up5 = row.Ml.Up5
            });
        }

        if (inputs.Count < 50)
        {
            Console.WriteLine($"学習データが少なすぎます。件数: {inputs.Count}");
            return;
        }

        var positiveCount = inputs.Count(x => x.Up5);
        var negativeCount = inputs.Count - positiveCount;

        Console.WriteLine($"DataCount: {inputs.Count}");
        Console.WriteLine($"Up5=True : {positiveCount}");
        Console.WriteLine($"Up5=False: {negativeCount}");
        Console.WriteLine($"PositiveRate: {(double)positiveCount / inputs.Count:P2}");

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

                Console.WriteLine($"TrainCount: {trainInputs.Count}");
                Console.WriteLine($"TestCount : {testInputs.Count}");
                Console.WriteLine($"TrainDate : {trainInputs.Min(x => x.TradeDate):yyyy-MM-dd} - {trainInputs.Max(x => x.TradeDate):yyyy-MM-dd}");
                Console.WriteLine($"TestDate  : {testInputs.Min(x => x.TradeDate):yyyy-MM-dd} - {testInputs.Max(x => x.TradeDate):yyyy-MM-dd}");

        var basePipeline = _mlContext.Transforms.Concatenate(
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

        var sdcaModel = sdcaPipeline.Fit(trainSet);
        var fastTreeModel = fastTreePipeline.Fit(trainSet);

        var sdcaResult = EvaluateModel(
            modelName: "SdcaLogisticRegression",
            model: sdcaModel,
            testSet: testSet);

        var fastTreeResult = EvaluateModel(
            modelName: "FastTree",
            model: fastTreeModel,
            testSet: testSet);

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
        Console.WriteLine($"=== 採用モデル: {bestModelName} ===");

        Directory.CreateDirectory(ModelDirectory);

        _mlContext.Model.Save(
            bestModel,
            trainSet.Schema,
            ModelPath);

        Console.WriteLine($"モデル保存: {ModelPath}");

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
            _mlContext.Model.CreatePredictionEngine<MlStockPredictionInput, MlStockPredictionOutput>(model);

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
        Console.WriteLine($"=== 最新スコア Up5 予測ランキング: {latestScoreDate:yyyy-MM-dd} ===");

        foreach (var item in ranking)
        {
            Console.WriteLine(
                $"{item.Code} {item.CompanyName} Total:{item.TotalScore} Swing:{item.SwingScore} Up5Prob:{item.Up5Probability:P2}");
        }
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
            .Where(x => x.ScoreDate == latestScoreDate)
            .ToListAsync();

        var predictionEngine =
            _mlContext.Model.CreatePredictionEngine<MlStockPredictionInput, MlStockPredictionOutput>(model);

        var result = new Dictionary<string, decimal>();

        foreach (var score in latestScoreRows)
        {
            var technicalFeatures = await CalculateTechnicalFeaturesAsync(
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

            result[score.Code] = (decimal)prediction.Probability * 100m;
        }

        return result;
    }

    private ITransformer? _loadedModel;
    private PredictionEngine<MlStockPredictionInput, MlStockPredictionOutput>? _predictionEngine;

    private ITransformer GetOrLoadModel()
    {
        if (_loadedModel != null)
        {
            return _loadedModel;
        }

        var modelPath = Path.Combine(
            AppContext.BaseDirectory,
            "Models",
            "up5-model.zip");

        if (!File.Exists(modelPath))
        {
            throw new FileNotFoundException(
                $"Up5モデルが見つかりません: {modelPath}");
        }

        _loadedModel = _mlContext.Model.Load(modelPath, out _);

        return _loadedModel;
    }

    public async Task<decimal?> PredictAsync(StockScoreDaily score)
    {
        var model = GetOrLoadModel();

        _predictionEngine ??=
            _mlContext.Model.CreatePredictionEngine<MlStockPredictionInput, MlStockPredictionOutput>(model);

        var technicalFeatures = await GetTechnicalFeaturesWithCacheAsync(
            score.Code,
            score.ScoreDate);

        if (technicalFeatures == null)
        {
            return null;
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
            ClosePositionInRange25 = technicalFeatures.ClosePositionInRange25,
            Ma25Slope = technicalFeatures.Ma25Slope,
            Ma75Slope = technicalFeatures.Ma75Slope,

            TopixMomentum25 = marketFeatures.TopixMomentum25,
            Sp500Momentum25 = marketFeatures.Sp500Momentum25,
            NasdaqMomentum25 = marketFeatures.NasdaqMomentum25,
            UsdJpyMomentum25 = marketFeatures.UsdJpyMomentum25,
            VixMomentum25 = marketFeatures.VixMomentum25
        };

        var prediction = _predictionEngine.Predict(input);

        return Math.Round((decimal)prediction.Probability * 100m, 4);
    }

    private async Task<ITransformer> TrainBestModelAsync()
    {
        var inputs = await CreateTrainingInputsAsync();

        var orderedInputs = inputs
            .OrderBy(x => x.TradeDate)
            .ToList();

        var trainCount = (int)(orderedInputs.Count * 0.8);

        var trainInputs = orderedInputs
            .Take(trainCount)
            .ToList();

        var trainSet = _mlContext.Data.LoadFromEnumerable(trainInputs);

        var basePipeline = CreateBasePipeline();

        var sdcaPipeline = basePipeline.Append(
            _mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                labelColumnName: "Label",
                featureColumnName: "Features"));

        return sdcaPipeline.Fit(trainSet);
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

    private async Task<List<MlStockPredictionInput>> CreateTrainingInputsAsync()
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
            .Where(x => x.FutureReturn5 != null)
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

    private ITransformer LoadModel()
    {
        if (!File.Exists(ModelPath))
        {
            throw new FileNotFoundException(
                $"Up5モデルが見つかりません。先にRUN_ML_UP5_TRAINING=trueで学習してください: {ModelPath}");
        }

        return _mlContext.Model.Load(ModelPath, out _);
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
}