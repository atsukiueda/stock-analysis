using StockAnalysis.Batch.Models.Ml;

namespace StockAnalysis.Batch.Factories;

/// <summary>
/// ウォークフォワード検証で使用する学習期間・検証期間を生成するFactory。
/// </summary>
public static class TrainingPeriodFactory
{
    /// <summary>
    /// Up5モデル用の標準ウォークフォワード期間を作成する。
    /// </summary>
    /// <returns>ウォークフォワード検証用の期間一覧。</returns>
    public static IReadOnlyList<TrainingPeriod> CreateUp5WalkForwardPeriods()
    {
        return new List<TrainingPeriod>
    {
        new()
        {
            TrainFrom = new DateTime(2026, 4, 1),
            TrainTo = new DateTime(2026, 5, 15),
            TestFrom = new DateTime(2026, 5, 16),
            TestTo = new DateTime(2026, 5, 29),
            ModelName = "up5_20260401_20260515"
        }
    };
    }
}