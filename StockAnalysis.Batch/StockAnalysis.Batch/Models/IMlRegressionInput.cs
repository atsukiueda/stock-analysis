namespace StockAnalysis.Batch.Models;

/// <summary>
/// 回帰モデル入力データの共通インターフェース。
/// 時系列分割に必要な取引日を型として保証する。
/// </summary>
public interface IMlRegressionInput
{
    /// <summary>
    /// 学習・検証データの時系列分割に使用する取引日。
    /// </summary>
    DateTime TradeDate { get; set; }
}