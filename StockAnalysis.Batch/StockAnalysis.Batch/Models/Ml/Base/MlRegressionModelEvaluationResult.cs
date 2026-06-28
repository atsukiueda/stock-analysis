namespace StockAnalysis.Batch.Services.Ml.Base;

/// <summary>
/// 回帰モデルの評価結果を保持する。
/// TakeProfit、StopLossなどの回帰モデルで共通利用する。
/// </summary>
public class MlRegressionModelEvaluationResult
{
    /// <summary>
    /// 決定係数。
    /// </summary>
    public double RSquared { get; set; }

    /// <summary>
    /// 二乗平均平方根誤差。
    /// </summary>
    public double RootMeanSquaredError { get; set; }

    /// <summary>
    /// 平均絶対誤差。
    /// </summary>
    public double MeanAbsoluteError { get; set; }
}