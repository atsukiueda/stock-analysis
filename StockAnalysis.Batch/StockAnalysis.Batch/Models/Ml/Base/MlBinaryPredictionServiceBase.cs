using Microsoft.ML;
using StockAnalysis.Batch.Models;
using StockAnalysis.Batch.Models.Ml;

namespace StockAnalysis.Batch.Services.Ml.Base;

/// <summary>
/// Up5、Up10などの二値分類MLモデルで共通利用する基底サービス。
/// 学習・評価・モデル保存など、二値分類で共通化できる処理を段階的に集約する。
/// </summary>
public abstract class MlBinaryPredictionServiceBase
{
    /// <summary>
    /// ML.NETの共通コンテキスト。
    /// </summary>
    protected readonly MLContext MlContext;

    /// <summary>
    /// 二値分類モデルの評価処理。
    /// </summary>
    private readonly MlBinaryEvaluator _binaryEvaluator;

    /// <summary>
    /// 二値分類モデルのパイプライン生成処理。
    /// </summary>
    private readonly MlBinaryPipelineFactory _pipelineFactory;

    /// <summary>
    /// ML.NETモデルの保存・読込・キャッシュ処理。
    /// </summary>
    private readonly MlModelStore _modelStore;

    /// <summary>
    /// PredictionEngineの作成・キャッシュ処理。
    /// </summary>
    private readonly MlPredictionEngineStore _predictionEngineStore;

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    protected MlBinaryPredictionServiceBase()
    {
        MlContext = new MLContext(seed: 1);
        _binaryEvaluator = new MlBinaryEvaluator(MlContext);
        _pipelineFactory = new MlBinaryPipelineFactory(MlContext);
        _binaryTrainer = new MlBinaryTrainer(
            MlContext,
            _binaryEvaluator,
            _pipelineFactory);
        _modelStore = new MlModelStore(MlContext);
        _predictionEngineStore = new MlPredictionEngineStore(
            MlContext,
            _modelStore);
    }

    /// <summary>
    /// 二値分類モデルの学習・候補モデル比較処理。
    /// </summary>
    private readonly MlBinaryTrainer _binaryTrainer;

    /// <summary>
    /// モデル学習に使用する特徴量列名を取得する。
    /// Up5、Up10など、モデルごとに採用特徴量が異なる可能性があるため、派生クラス側で定義する。
    /// </summary>
    /// <returns>特徴量列名の配列。</returns>
    protected abstract string[] GetFeatureColumns();

    /// <summary>
    /// 二値分類モデルで共通利用する基本パイプラインを作成する。
    /// 実際のパイプライン生成はMlBinaryPipelineFactoryへ委譲する。
    /// </summary>
    /// <returns>特徴量変換パイプライン。</returns>
    protected IEstimator<ITransformer> CreateBasePipeline()
    {
        // 派生クラスが定義した特徴量列を取得する。
        var featureColumns = GetFeatureColumns();

        // パイプライン生成を専用クラスへ委譲し、Baseクラスの肥大化を防ぐ。
        return _pipelineFactory.CreateBasePipeline(featureColumns);
    }

    /// <summary>
    /// モデル選択時に使用する検証データ比率。
    /// </summary>
    private const double ValidationRate = 0.2;

    /// <summary>
    /// 二値分類モデルを学習し、検証結果が良いモデルを保存する。
    /// SdcaLogisticRegressionとFastTreeを比較し、Top20HitRateが高いモデルを採用する。
    /// </summary>
    /// <param name="inputs">学習対象データ。</param>
    /// <param name="modelName">保存するモデル名。拡張子なし。</param>
    /// <param name="modelTitle">ログ表示用モデル名。例: Up5。</param>
    /// <param name="trainFrom">学習開始日。</param>
    /// <param name="trainTo">学習終了日。</param>
    /// <returns>採用された学習済みモデル。</returns>
    protected Task<ITransformer> TrainBestModelAsync(
        List<MlStockPredictionInput> inputs,
        string modelName,
        string modelTitle,
        DateTime trainFrom,
        DateTime trainTo)
    {
        // データ件数が少なすぎる場合は、学習しても評価が不安定になるため停止する。
        if (inputs.Count < 50)
        {
            throw new InvalidOperationException(
                $"{modelTitle}学習データが少なすぎます。Model:{modelName}, Count:{inputs.Count}");
        }

        // 候補モデルの学習・評価・採用判定を専用クラスへ委譲する。
        var trainingResult = _binaryTrainer.TrainBestModel(
            inputs,
            GetFeatureColumns());

        Console.WriteLine();
        Console.WriteLine($"=== {modelTitle} 採用モデル: {trainingResult.BestModelName} ===");
        Console.WriteLine($"ModelName : {modelName}");
        Console.WriteLine($"TrainDate : {trainFrom:yyyy-MM-dd} - {trainTo:yyyy-MM-dd}");

        // 採用モデルをzipとして保存する。
        var modelPath = _modelStore.SaveModel(
            trainingResult.BestModel,
            trainingResult.TrainSet.Schema,
            modelName);

        Console.WriteLine($"モデル保存: {modelPath}");

        return Task.FromResult(trainingResult.BestModel);
    }

    /// <summary>
    /// 二値分類モデルを評価する。
    /// 実際の評価処理はMlBinaryEvaluatorへ委譲する。
    /// </summary>
    /// <param name="modelName">評価対象モデル名。</param>
    /// <param name="model">学習済みモデル。</param>
    /// <param name="testSet">評価用データ。</param>
    /// <returns>評価結果。</returns>
    protected MlBinaryModelEvaluationResult EvaluateModel(
        string modelName,
        ITransformer model,
        IDataView testSet)
    {
        // 評価処理を専用クラスへ委譲し、Baseクラスの肥大化を防ぐ。
        return _binaryEvaluator.Evaluate(
            modelName,
            model,
            testSet);
    }

    /// <summary>
    /// 指定されたモデル名のPredictionEngineを取得する。
    /// 実際の作成・キャッシュ処理はMlPredictionEngineStoreへ委譲する。
    /// </summary>
    /// <param name="modelName">モデル名。拡張子なし。</param>
    /// <param name="modelTitle">ログ・例外表示用モデル名。例: Up5。</param>
    /// <returns>PredictionEngine。</returns>
    protected PredictionEngine<MlStockPredictionInput, MlStockPredictionOutput> GetOrCreatePredictionEngine(
        string modelName,
        string modelTitle)
    {
        return _predictionEngineStore.GetOrCreatePredictionEngine(
            modelName,
            modelTitle);
    }

    /// <summary>
    /// 指定されたモデル名の学習済みモデルを取得する。
    /// 実際の保存・読込処理はMlModelStoreへ委譲する。
    /// </summary>
    /// <param name="modelName">モデル名。拡張子なし。</param>
    /// <param name="modelTitle">ログ・例外表示用モデル名。例: Up5。</param>
    /// <returns>読み込み済みモデル。</returns>
    protected ITransformer GetOrLoadModel(
        string modelName,
        string modelTitle)
    {
        return _modelStore.GetOrLoadModel(
            modelName,
            modelTitle);
    }

    /// <summary>
    /// 銘柄スコア、テクニカル特徴量、市場特徴量からML予測入力を作成する。
    /// Up5、Up10など、同じ特徴量構造を使う二値分類モデルで共通利用する。
    /// </summary>
    /// <param name="score">予測対象日の銘柄スコア。</param>
    /// <param name="technicalFeatures">対象銘柄のテクニカル特徴量。</param>
    /// <param name="marketFeatures">対象日の市場特徴量。</param>
    /// <returns>ML.NET予測入力。</returns>
    protected MlStockPredictionInput CreatePredictionInput(
        StockScoreDaily score,
        MlTechnicalFeatures technicalFeatures,
        MlMarketFeatures marketFeatures)
    {
        // 銘柄スコア、テクニカル特徴量、市場特徴量をML.NET入力クラスへ集約する。
        return new MlStockPredictionInput
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
    }
}