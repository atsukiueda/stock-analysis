using Microsoft.ML;
using StockAnalysis.Batch.Models;
using StockAnalysis.Batch.Models.Ml;

namespace StockAnalysis.Batch.Services.Ml.Base;

/// <summary>
/// 二値分類モデルの学習・候補モデル比較を担当するクラス。
/// SdcaLogisticRegressionとFastTreeを学習し、Top20HitRateが高いモデルを採用する。
/// </summary>
public class MlBinaryTrainer
{
    private const double ValidationRate = 0.2;

    private readonly MLContext _mlContext;
    private readonly MlBinaryEvaluator _evaluator;
    private readonly MlBinaryPipelineFactory _pipelineFactory;

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    /// <param name="mlContext">ML.NET共通コンテキスト。</param>
    /// <param name="evaluator">二値分類モデル評価処理。</param>
    /// <param name="pipelineFactory">Pipeline生成処理。</param>
    public MlBinaryTrainer(
        MLContext mlContext,
        MlBinaryEvaluator evaluator,
        MlBinaryPipelineFactory pipelineFactory)
    {
        _mlContext = mlContext;
        _evaluator = evaluator;
        _pipelineFactory = pipelineFactory;
    }

    /// <summary>
    /// 二値分類モデルを学習し、検証結果が良い候補モデルを返す。
    /// 時系列データのためランダム分割せず、末尾20%を検証データとして使う。
    /// </summary>
    /// <param name="inputs">学習対象データ。</param>
    /// <param name="featureColumns">学習に使用する特徴量列名。</param>
    /// <returns>採用モデル、採用モデル名、学習用DataView。</returns>
    public MlBinaryTrainingResult TrainBestModel(
        List<MlStockPredictionInput> inputs,
        string[] featureColumns)
    {
        // 時系列データなので、ランダムシャッフルせず日付順で並べる。
        var orderedInputs = inputs
            .OrderBy(x => x.TradeDate)
            .ToList();

        // 学習期間内の最終20%を疑似検証データとして使う。
        var validationStartIndex = (int)(orderedInputs.Count * (1.0 - ValidationRate));

        var trainInputs = orderedInputs
            .Take(validationStartIndex)
            .ToList();

        var validationInputs = orderedInputs
            .Skip(validationStartIndex)
            .ToList();

        var trainSet = _mlContext.Data.LoadFromEnumerable(trainInputs);
        var validationSet = _mlContext.Data.LoadFromEnumerable(validationInputs);

        // 特徴量変換パイプラインを作成する。
        var basePipeline = _pipelineFactory.CreateBasePipeline(featureColumns);

        // 線形モデルを作成する。
        var sdcaPipeline = basePipeline.Append(
            _mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(
                labelColumnName: "Label",
                featureColumnName: "Features"));

        // 非線形モデルを作成する。
        var fastTreePipeline = basePipeline.Append(
            _mlContext.BinaryClassification.Trainers.FastTree(
                labelColumnName: "Label",
                featureColumnName: "Features",
                numberOfLeaves: 8,
                numberOfTrees: 100,
                minimumExampleCountPerLeaf: 10));

        // 候補モデルを学習する。
        var sdcaModel = sdcaPipeline.Fit(trainSet);
        var fastTreeModel = fastTreePipeline.Fit(trainSet);

        // 検証データで評価する。
        var sdcaResult = _evaluator.Evaluate(
            modelName: "SdcaLogisticRegression",
            model: sdcaModel,
            testSet: validationSet);

        var fastTreeResult = _evaluator.Evaluate(
            modelName: "FastTree",
            model: fastTreeModel,
            testSet: validationSet);

        // スイングトレード用途では、確率上位候補の質を重視する。
        var useFastTree = fastTreeResult.Top20HitRate >= sdcaResult.Top20HitRate;

        ITransformer bestModel;

        if (useFastTree)
        {
            bestModel = fastTreeModel;
        }
        else
        {
            bestModel = sdcaModel;
        }

        var bestModelName = useFastTree
            ? "FastTree"
            : "SdcaLogisticRegression";

        return new MlBinaryTrainingResult
        {
            BestModel = bestModel,
            BestModelName = bestModelName,
            TrainSet = trainSet
        };
    }
}