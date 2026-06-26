using StockAnalysis.Batch.Models.Ml;

namespace StockAnalysis.Batch.Services.Interfaces;

/// <summary>
/// ウォークフォワード検証で使用するMLモデル学習サービスの共通インターフェース。
/// Up5、Up10、TakeProfit、StopLossなどのモデル学習処理を共通化する。
/// </summary>
public interface IMlWalkForwardTrainingService
{
    /// <summary>
    /// 指定された学習期間でモデルを学習し、指定されたモデル名で保存する。
    /// </summary>
    /// <param name="period">学習期間・テスト期間・モデル名を持つ期間定義。</param>
    Task TrainAndEvaluateAsync(TrainingPeriod period);
}