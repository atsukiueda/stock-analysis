namespace StockAnalysis.Batch.Services.Ml.Prediction;

/// <summary>
/// 回帰予測Providerとアンサンブル重みを保持する。
/// </summary>
public sealed class RegressionPredictionProviderWeight
{
    /// <summary>
    /// 回帰予測Provider。
    /// </summary>
    public required IRegressionPredictionProvider Provider { get; init; }

    /// <summary>
    /// アンサンブル時の重み。
    /// 0以下の場合は無効な重みとして扱う。
    /// </summary>
    public decimal Weight { get; init; }
}