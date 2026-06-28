using Microsoft.EntityFrameworkCore;
using Microsoft.ML;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;
using StockAnalysis.Batch.Services;
using System.Globalization;
using StockAnalysis.Batch.Services.Ml.Base;
using StockAnalysis.Batch.Models.Ml;

namespace StockAnalysis.Batch.Services;

public class MlStopLossPredictionService
{
    private readonly StockAnalysisDbContext _db;

    private readonly MLContext _mlContext;

    private readonly Dictionary<string, TechnicalFeatureValues?> _technicalFeatureCache = new();

    private readonly Dictionary<string, List<PriceDaily>> _priceHistoryCache = new();

    private readonly MlRegressionPipelineFactory _regressionPipelineFactory;

    private readonly MlRegressionEvaluator _regressionEvaluator;

    private readonly MlRegressionTrainer _regressionTrainer;

    private readonly MlModelStore _modelStore;

    private readonly MlFeatureCalculationService _featureCalculationService;

    private readonly MlPredictionEngineStore<MlStopLossInput, MlStopLossOutput> _predictionEngineStore;
    public MlStopLossPredictionService(StockAnalysisDbContext db)
    {
        _db = db;
        _featureCalculationService = new MlFeatureCalculationService(_db);

        _mlContext = new MLContext(seed: 1);

        _regressionEvaluator = new MlRegressionEvaluator(_mlContext);
        _regressionPipelineFactory = new MlRegressionPipelineFactory(_mlContext);

        _regressionTrainer = new MlRegressionTrainer(
            _mlContext,
            _regressionPipelineFactory);

        _modelStore = new MlModelStore(_mlContext);

        _predictionEngineStore =
            new MlPredictionEngineStore<MlStopLossInput, MlStopLossOutput>(
                _mlContext,
                _modelStore);
    }

    /// <summary>
    /// StopLoss回帰モデルを学習し、評価結果と最新ランキングを出力する。
    /// 学習処理・評価処理・モデル保存はRegression共通基盤へ委譲する。
    /// </summary>
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

        // 共通Trainerで時系列分割・FastTree回帰学習・検証データ予測を行う。
        var trainingResult = _regressionTrainer.TrainFastTree(
            inputs,
            GetFeatureColumns());

        var model = trainingResult.Model;
        var trainSet = trainingResult.TrainSet;
        var predictions = trainingResult.Predictions;

        // 回帰モデル共通Evaluatorで評価指標を出力する。
        _regressionEvaluator.Evaluate(
            modelTitle: "StopLoss",
            predictions: predictions);

        // 学習済みStopLossモデルを共通ModelStore経由で保存する。
        var modelPath = _modelStore.SaveModel(
            model,
            trainSet.Schema,
            "stoploss-model");

        Console.WriteLine($"モデル保存: {modelPath}");

        await ShowLatestPredictionRankingAsync(model);
    }

    /// <summary>
    /// CSVキャッシュからStopLoss学習用入力データを作成する。
    /// 学習時のAzure SQLアクセスと特徴量再計算を避けるために使用する。
    /// </summary>
    /// <returns>StopLoss学習用入力データ。</returns>
    private Task<List<MlStopLossInput>> CreateTrainingInputsAsync()
    {
        // CSVキャッシュから学習データを読み込み、時系列順に並べる。
        var inputs = LoadTrainingDataFromCsv()
            .OrderBy(x => x.TradeDate)
            .ToList();

        return Task.FromResult(inputs);
    }

    /// <summary>
    /// CSVキャッシュからStopLoss学習用データを読み込む。
    /// 学習・特徴量重要度分析でDBアクセスと特徴量再計算を避けるために使用する。
    /// </summary>
    /// <returns>StopLoss学習用入力データ。</returns>
    private List<MlStopLossInput> LoadTrainingDataFromCsv()
    {
        var path = Path.Combine(
            AppContext.BaseDirectory,
            "MlCache",
            "stoploss_training_data.csv");

        if (!File.Exists(path))
        {
            throw new FileNotFoundException(
                $"StopLoss学習用CSVキャッシュが見つかりません。先にRUN_EXPORT_STOPLOSS_TRAINING_CACHE=trueで出力してください: {path}");
        }

        var lines = File.ReadAllLines(path)
            .Skip(1);

        var list = new List<MlStopLossInput>();

        foreach (var line in lines)
        {
            // 空行は学習データとして扱わない。
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            var c = line.Split(',');

            // CSV列数が想定と異なる場合は、キャッシュ生成ミスとして明示的に停止する。
            if (c.Length < 21)
            {
                throw new InvalidOperationException(
                    $"StopLoss学習用CSVの列数が不足しています。Columns:{c.Length}, Line:{line}");
            }

            list.Add(new MlStopLossInput
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
                        MarketScore = ParseFloat(c[10]),

                        Momentum5 = ParseFloat(c[11]),
                        Momentum25 = ParseFloat(c[12]),
                        DeviationFromMa25 = ParseFloat(c[13]),
                        VolumeRatio5 = ParseFloat(c[14]),
                        ClosePositionInRange25 = ParseFloat(c[15]),
                        Ma25Slope = ParseFloat(c[16]),

                        TopixMomentum25 = ParseFloat(c[17]),
                        UsdJpyMomentum25 = ParseFloat(c[18]),
                        VixMomentum25 = ParseFloat(c[19]),

                        FutureMinReturn10 = ParseFloat(c[20])
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
    /// StopLoss回帰モデルで使用する特徴量列名を取得する。
    /// Feature Importanceの結果から、GrowthScore、SwingScore、MarketScoreは残し、
    /// Ma75Slope、Sp500Momentum25、NasdaqMomentum25は除外している。
    /// </summary>
    /// <returns>StopLoss回帰モデルで使用する特徴量列名。</returns>
    private static string[] GetFeatureColumns()
    {
        return
        [
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

            nameof(MlStopLossInput.TopixMomentum25),
            nameof(MlStopLossInput.UsdJpyMomentum25),
            nameof(MlStopLossInput.VixMomentum25)
        ];
    }

    /// <summary>
    /// StopLoss回帰モデルで使用する基本パイプラインを作成する。
    /// 実際の特徴量結合・正規化はMlRegressionPipelineFactoryへ委譲する。
    /// </summary>
    /// <returns>特徴量変換パイプライン。</returns>
    private IEstimator<ITransformer> CreateBasePipeline()
    {
        // StopLossモデル固有の特徴量一覧を取得する。
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

            // 市場特徴量は共通特徴量計算サービスから取得する。
            var marketFeatures =
                await _featureCalculationService.GetMarketFeaturesAsync(
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

    public async Task<Dictionary<string, decimal>> PredictLatestStopLossAsync()
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

        // 市場特徴量は共通特徴量計算サービスから取得する。
        var marketFeatures =
            await _featureCalculationService.GetMarketFeaturesAsync(latestScoreDate);

        var inputs = new List<MlStopLossInput>();
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

            inputs.Add(new MlStopLossInput
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
            .CreateEnumerable<MlStopLossOutput>(
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
    /// StopLossモデルを読み込む。
    /// 実際の読込・キャッシュ処理は共通ModelStoreへ委譲する。
    /// </summary>
    /// <returns>読み込み済みStopLossモデル。</returns>
    private ITransformer LoadModel()
    {
        return _modelStore.GetOrLoadModel(
            modelName: "stoploss-model",
            modelTitle: "StopLoss");
    }

    /// <summary>
    /// 指定スコア行に対してStopLoss予測値を算出する。
    /// 特徴量計算はMlFeatureCalculationServiceへ委譲する。
    /// </summary>
    /// <param name="score">予測対象のスコア行。</param>
    /// <returns>予測StopLoss。特徴量不足時はnull。</returns>
    public async Task<decimal?> PredictAsync(StockScoreDaily score)
    {
        // 共通PredictionEngineStoreからStopLoss用PredictionEngineを取得する。
        var predictionEngine = _predictionEngineStore.GetOrCreatePredictionEngine(
            modelName: "stoploss-model",
            modelTitle: "StopLoss");

        // テクニカル特徴量は共通特徴量計算サービスから取得する。
        var technicalFeatures =
            await _featureCalculationService.GetTechnicalFeaturesAsync(
                score.Code,
                score.ScoreDate);

        if (technicalFeatures == null)
        {
            return null;
        }

        // 市場特徴量は共通特徴量計算サービスから取得する。
        var marketFeatures =
            await _featureCalculationService.GetMarketFeaturesAsync(score.ScoreDate);

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
            UsdJpyMomentum25 = marketFeatures.UsdJpyMomentum25,
            VixMomentum25 = marketFeatures.VixMomentum25
        };

        var prediction = predictionEngine.Predict(input);

        return Math.Min(
            0m,
            Math.Round((decimal)prediction.Score, 4));
    }

    /// <summary>
    /// StopLoss回帰モデルの特徴量重要度を分析する。
    /// CSVキャッシュから学習データを読み込み、Permutation Feature Importanceを実行する。
    /// </summary>
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

        // 回帰モデル共通Evaluatorで評価指標を出力する。
        _regressionEvaluator.Evaluate(
            modelTitle: "StopLoss",
            predictions: predictions);

        var permutationMetrics =
            _mlContext.Regression.PermutationFeatureImportance(
                model,
                transformedTestSet,
                labelColumnName: "Label",
                permutationCount: 5);

        var featureNames = GetFeatureColumns();

        Console.WriteLine();
        Console.WriteLine("=== StopLoss 特徴量重要度 ===");

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