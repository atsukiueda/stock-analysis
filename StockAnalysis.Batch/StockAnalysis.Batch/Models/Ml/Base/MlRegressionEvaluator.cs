using Microsoft.ML;

namespace StockAnalysis.Batch.Services.Ml.Base;

/// <summary>
/// 回帰モデルの評価処理を担当するクラス。
/// TakeProfit、StopLossなどの回帰モデルで共通利用する。
/// </summary>
public class MlRegressionEvaluator
{
    private readonly MLContext _mlContext;

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    /// <param name="mlContext">ML.NET共通コンテキスト。</param>
    public MlRegressionEvaluator(MLContext mlContext)
    {
        _mlContext = mlContext;
    }

    /// <summary>
    /// 回帰モデルを評価する。
    /// </summary>
    /// <param name="modelTitle">モデル表示名。</param>
    /// <param name="predictions">予測済みデータ。</param>
    /// <returns>回帰モデル評価結果。</returns>
    public MlRegressionModelEvaluationResult Evaluate(
        string modelTitle,
        IDataView predictions)
    {
        // ML.NET標準の回帰評価指標を計算する。
        var metrics = _mlContext.Regression.Evaluate(
            predictions,
            labelColumnName: "Label",
            scoreColumnName: "Score");

        Console.WriteLine();
        Console.WriteLine($"=== {modelTitle} 回帰モデル 評価結果 ===");
        Console.WriteLine($"RSquared: {metrics.RSquared:F4}");
        Console.WriteLine($"RMSE    : {metrics.RootMeanSquaredError:F4}");
        Console.WriteLine($"MAE     : {metrics.MeanAbsoluteError:F4}");

        return new MlRegressionModelEvaluationResult
        {
            RSquared = metrics.RSquared,
            RootMeanSquaredError = metrics.RootMeanSquaredError,
            MeanAbsoluteError = metrics.MeanAbsoluteError
        };
    }
}