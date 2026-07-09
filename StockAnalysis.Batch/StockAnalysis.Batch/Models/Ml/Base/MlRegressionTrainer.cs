using Microsoft.ML;
using StockAnalysis.Batch.Models;
using System.Linq.Expressions;
using StockAnalysis.Batch.Models.Ml;

namespace StockAnalysis.Batch.Services.Ml.Base;

/// <summary>
/// 回帰モデルの学習処理を担当するクラス。
/// TakeProfit、StopLossなどの回帰モデルで共通利用する。
/// </summary>
public class MlRegressionTrainer
{
    private const double ValidationRate = 0.2;

    private readonly MLContext _mlContext;
    private readonly MlRegressionPipelineFactory _pipelineFactory;

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    /// <param name="mlContext">ML.NET共通コンテキスト。</param>
    /// <param name="pipelineFactory">回帰モデル用Pipeline生成処理。</param>
    public MlRegressionTrainer(
        MLContext mlContext,
        MlRegressionPipelineFactory pipelineFactory)
    {
        _mlContext = mlContext;
        _pipelineFactory = pipelineFactory;
    }

    /// <summary>
    /// 指定された回帰アルゴリズムでモデルを学習し、評価用予測結果を返す。
    /// 時系列データのためランダム分割せず、末尾20%を検証データとして使う。
    /// </summary>
    /// <typeparam name="TInput">回帰モデルの入力データ型。</typeparam>
    /// <param name="modelType">学習に使用する回帰アルゴリズム種別。</param>
    /// <param name="inputs">学習対象データ。</param>
    /// <param name="featureColumns">学習に使用する特徴量列名。</param>
    /// <returns>学習結果。</returns>
    public MlRegressionTrainingResult Train<TInput>(
        MlRegressionModelType modelType,
        List<TInput> inputs,
        string[] featureColumns)
        where TInput : class, IMlRegressionInput
    {
        // 時系列データなので、ランダムシャッフルせず日付順で並べる。
        var orderedInputs = inputs
            .OrderBy(x => x.TradeDate)
            .ToList();

        // 学習期間内の末尾20%を検証データとして使う。
        var trainCount = (int)(orderedInputs.Count * (1.0 - ValidationRate));

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

        // モデル種別に応じた回帰Pipelineを作成する。
        var pipeline = CreateTrainingPipeline(
            modelType,
            featureColumns);

        // 指定された回帰モデルを学習する。
        var model = pipeline.Fit(trainSet);

        // 検証データに対して予測を実行する。
        var predictions = model.Transform(testSet);

        return new MlRegressionTrainingResult
        {
            Model = model,
            TrainSet = trainSet,
            Predictions = predictions
        };
    }

    /// <summary>
    /// 回帰モデル種別に応じた学習Pipelineを作成する。
    /// 特徴量変換は共通化し、Trainerのみをモデル種別で切り替える。
    /// </summary>
    /// <param name="modelType">学習に使用する回帰アルゴリズム種別。</param>
    /// <param name="featureColumns">学習に使用する特徴量列名。</param>
    /// <returns>学習Pipeline。</returns>
    private IEstimator<ITransformer> CreateTrainingPipeline(
        MlRegressionModelType modelType,
        string[] featureColumns)
    {
        // 特徴量結合・正規化までは全モデルで共通化する。
        var basePipeline = _pipelineFactory.CreateBasePipeline(featureColumns);

        return modelType switch
        {
            MlRegressionModelType.FastTree =>
                basePipeline.Append(_mlContext.Regression.Trainers.FastTree(
                    labelColumnName: "Label",
                    featureColumnName: "Features",
                    numberOfLeaves: 16,
                    numberOfTrees: 200,
                    minimumExampleCountPerLeaf: 10)),

            MlRegressionModelType.LightGbm =>
                basePipeline.Append(_mlContext.Regression.Trainers.LightGbm(
                    labelColumnName: "Label",
                    featureColumnName: "Features",
                    numberOfLeaves: 31,
                    numberOfIterations: 200,
                    minimumExampleCountPerLeaf: 20,
                    learningRate: 0.05)),

            MlRegressionModelType.FastForest =>
                basePipeline.Append(_mlContext.Regression.Trainers.FastForest(
                    labelColumnName: "Label",
                    featureColumnName: "Features",
                    numberOfLeaves: 32,
                    numberOfTrees: 300,
                    minimumExampleCountPerLeaf: 10)),

            _ => throw new NotSupportedException(
                $"未対応の回帰モデル種別です: {modelType}")
        };
    }
}