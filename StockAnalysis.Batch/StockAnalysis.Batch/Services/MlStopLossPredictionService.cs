using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;

namespace StockAnalysis.Batch.Services;

public class MlStopLossPredictionService
{
    private const string ModelDirectory = "Models";

    private const string ModelPath = "Models/stoploss-model.zip";

    private readonly StockAnalysisDbContext _db;

    private readonly MLContext _mlContext;

    public MlStopLossPredictionService(StockAnalysisDbContext db)
    {
        _db = db;
        _mlContext = new MLContext(seed: 1);
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
        Console.WriteLine($"AvgLabel: {inputs.Average(x => x.FutureMinReturn10):F2}%");
        Console.WriteLine($"MaxLabel: {inputs.Max(x => x.FutureMinReturn10):F2}%");
        Console.WriteLine($"MinLabel: {inputs.Min(x => x.FutureMinReturn10):F2}%");

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

        var pipeline = CreateBasePipeline()
            .Append(_mlContext.Regression.Trainers.FastTree(
                labelColumnName: "Label",
                featureColumnName: "Features",
                numberOfLeaves: 16,
                numberOfTrees: 200,
                minimumExampleCountPerLeaf: 10));

        var model = pipeline.Fit(trainSet);

        var predictions = model.Transform(testSet);

        var metrics = _mlContext.Regression.Evaluate(
            predictions,
            labelColumnName: "Label",
            scoreColumnName: "Score");

        Console.WriteLine();
        Console.WriteLine("=== StopLoss 回帰モデル 評価結果 ===");
        Console.WriteLine($"RSquared: {metrics.RSquared:F4}");
        Console.WriteLine($"RMSE    : {metrics.RootMeanSquaredError:F4}");
        Console.WriteLine($"MAE     : {metrics.MeanAbsoluteError:F4}");

        Directory.CreateDirectory(ModelDirectory);

        _mlContext.Model.Save(
            model,
            trainSet.Schema,
            ModelPath);

        Console.WriteLine($"モデル保存: {ModelPath}");

        await ShowLatestPredictionRankingAsync(model);
    }

    private async Task<List<MlStopLossInput>> CreateTrainingInputsAsync()
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
            .Where(x => x.FutureMinReturn10 != null)
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

        var inputs = new List<MlStopLossInput>();

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

            inputs.Add(new MlStopLossInput
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

                FutureMinReturn10 = (float)row.Ml.FutureMinReturn10!.Value
            });
        }

        return inputs;
    }

    private IEstimator<ITransformer> CreateBasePipeline()
    {
        return _mlContext.Transforms.Concatenate(
                "Features",
                nameof(MlStopLossInput.FinancialScore),
                nameof(MlStopLossInput.GrowthScore),
                nameof(MlStopLossInput.DividendScore),
                nameof(MlStopLossInput.RoeScore),
                nameof(MlStopLossInput.PerScore),
                nameof(MlStopLossInput.PbrScore),
                nameof(MlStopLossInput.TechnicalScore),
                nameof(MlStopLossInput.SwingScore),
                nameof(MlStopLossInput.MarketScore),
                nameof(MlStopLossInput.Momentum5),
                nameof(MlStopLossInput.Momentum25),
                nameof(MlStopLossInput.DeviationFromMa25),
                nameof(MlStopLossInput.VolumeRatio5),
                nameof(MlStopLossInput.ClosePositionInRange25),
                nameof(MlStopLossInput.Ma25Slope),
                nameof(MlStopLossInput.Ma75Slope),
                nameof(MlStopLossInput.TopixMomentum25),
                nameof(MlStopLossInput.Sp500Momentum25),
                nameof(MlStopLossInput.NasdaqMomentum25),
                nameof(MlStopLossInput.UsdJpyMomentum25),
                nameof(MlStopLossInput.VixMomentum25))
            .Append(_mlContext.Transforms.NormalizeMinMax("Features"));
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
            _mlContext.Model.CreatePredictionEngine<MlStopLossInput, MlStopLossOutput>(model);

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

            var input = new MlStopLossInput
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

                TopixMomentum25 = marketFeatures.TopixMomentum25,
                Sp500Momentum25 = marketFeatures.Sp500Momentum25,
                NasdaqMomentum25 = marketFeatures.NasdaqMomentum25,
                UsdJpyMomentum25 = marketFeatures.UsdJpyMomentum25,
                VixMomentum25 = marketFeatures.VixMomentum25
            };

            var prediction = predictionEngine.Predict(input);

            ranking.Add(new
            {
                row.Score.Code,
                row.Company.CompanyName,
                row.Score.TotalScore,
                row.Score.SwingScore,
                ExpectedStopLoss = prediction.Score
            });
        }

        Console.WriteLine();
        Console.WriteLine($"=== 最新スコア StopLoss 予測ランキング: {latestScoreDate:yyyy-MM-dd} ===");

        foreach (var item in ranking
                     .OrderBy(x => x.ExpectedStopLoss)
                     .Take(20))
        {
            Console.WriteLine(
                $"{item.Code} {item.CompanyName} " +
                $"Total:{item.TotalScore} " +
                $"Swing:{item.SwingScore} " +
                $"ExpectedSL:{item.ExpectedStopLoss:F2}%");
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
        var prices = await _db.PricesDaily
            .Where(x => x.Code == code)
            .Where(x => x.TradeDate <= tradeDate)
            .Where(x => x.ClosePrice != null)
            .OrderByDescending(x => x.TradeDate)
            .Take(80)
            .OrderBy(x => x.TradeDate)
            .ToListAsync();

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

    private async Task<float> CalculateMarketMomentum25Async(
        string indexName,
        DateTime tradeDate)
    {
        var prices = await _db.MarketIndicesDaily
            .Where(x => x.IndexName == indexName)
            .Where(x => x.TradeDate <= tradeDate)
            .Where(x => x.CloseValue != null)
            .OrderByDescending(x => x.TradeDate)
            .Take(25)
            .OrderBy(x => x.TradeDate)
            .ToListAsync();

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

    public async Task<Dictionary<string, decimal>> PredictLatestStopLossAsync()
    {
        var model = LoadModel();

        var latestScoreDate = await _db.StockScoresDaily
            .MaxAsync(x => x.ScoreDate);

        var latestScoreRows = await _db.StockScoresDaily
            .Where(x => x.ScoreDate == latestScoreDate)
            .ToListAsync();

        var predictionEngine =
            _mlContext.Model.CreatePredictionEngine<MlStopLossInput, MlStopLossOutput>(model);

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

            var marketFeatures = await CalculateMarketFeaturesAsync(
                score.ScoreDate);

            var input = new MlStopLossInput
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

            result[score.Code] = (decimal)prediction.Score;
        }

        return result;
    }

    private ITransformer LoadModel()
    {
        if (!File.Exists(ModelPath))
        {
            throw new FileNotFoundException(
                $"StopLossモデルが見つかりません。先にRUN_ML_STOP_LOSS_TRAINING=trueで学習してください: {ModelPath}");
        }

        return _mlContext.Model.Load(ModelPath, out _);
    }
}