using Microsoft.ML;
using StockAnalysis.Batch.Models;

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
    /// FastTree回帰モデルを学習し、評価用予測結果を返す。
    /// 時系列データのためランダム分割せず、末尾20%を検証データとして使う。
    /// </summary>
    /// <param name="inputs">学習対象データ。</param>
    /// <param name="featureColumns">学習に使用する特徴量列名。</param>
    /// <returns>学習結果。</returns>
    public MlRegressionTrainingResult TrainFastTree(
        List<MlTakeProfitInput> inputs,
        string[] featureColumns)
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

        // 回帰モデル用の特徴量変換Pipelineを作成する。
        var pipeline = _pipelineFactory
            .CreateBasePipeline(featureColumns)
            .Append(_mlContext.Regression.Trainers.FastTree(
                labelColumnName: "Label",
                featureColumnName: "Features",
                numberOfLeaves: 16,
                numberOfTrees: 200,
                minimumExampleCountPerLeaf: 10));

        // FastTree回帰モデルを学習する。
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
}