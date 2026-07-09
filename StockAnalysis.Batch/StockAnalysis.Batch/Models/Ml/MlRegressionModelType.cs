namespace StockAnalysis.Batch.Models.Ml;

/// <summary>
/// 回帰モデルの学習アルゴリズム種別。
/// FastTree、LightGBM、FastForestなどを横並び比較するために使用する。
/// </summary>
public enum MlRegressionModelType
{
    /// <summary>
    /// ML.NET標準のFastTree回帰モデル。
    /// 現在の既定モデル。
    /// </summary>
    FastTree,

    /// <summary>
    /// LightGBM回帰モデル。
    /// 次フェーズで追加予定。
    /// </summary>
    LightGbm,

    /// <summary>
    /// FastForest回帰モデル。
    /// LightGBM比較後に追加予定。
    /// </summary>
    FastForest
}