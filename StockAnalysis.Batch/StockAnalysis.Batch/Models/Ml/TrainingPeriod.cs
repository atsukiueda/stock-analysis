namespace StockAnalysis.Batch.Models.Ml;

/// <summary>
/// 機械学習モデルの学習期間を表す
/// </summary>
public class TrainingPeriod
{
    /// <summary>
    /// 学習開始日
    /// </summary>
    public required DateTime TrainFrom { get; init; }

    /// <summary>
    /// 学習終了日
    /// </summary>
    public required DateTime TrainTo { get; init; }

    /// <summary>
    /// モデル名
    /// 例: up5_2022_2023
    /// </summary>
    public required string ModelName { get; init; }

    /// <summary>
    /// テスト開始日
    /// </summary>
    public DateTime? TestFrom { get; init; }

    /// <summary>
    /// テスト終了日
    /// </summary>
    public DateTime? TestTo { get; init; }
}