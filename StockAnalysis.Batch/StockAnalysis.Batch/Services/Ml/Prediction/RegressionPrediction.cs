namespace StockAnalysis.Batch.Services.Ml.Prediction;

/// <summary>
/// TakeProfit / StopLoss の回帰予測結果を表す。
/// </summary>
public sealed class RegressionPrediction
{
    /// <summary>
    /// 予測TakeProfit。
    /// 特徴量不足やモデル未取得時はnull。
    /// </summary>
    public decimal? TakeProfit { get; init; }

    /// <summary>
    /// 予測StopLoss。
    /// 特徴量不足やモデル未取得時はnull。
    /// </summary>
    public decimal? StopLoss { get; init; }
}