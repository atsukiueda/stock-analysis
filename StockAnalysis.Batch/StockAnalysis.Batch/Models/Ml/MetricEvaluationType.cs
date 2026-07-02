namespace StockAnalysis.Batch.Models.Ml;

/// <summary>
/// 評価指標の評価方式を表す。
/// </summary>
public enum MetricEvaluationType
{
    /// <summary>
    /// 値が高いほど評価が高い。
    /// 例：ROE、営業利益率、売上成長率。
    /// </summary>
    Higher = 1,

    /// <summary>
    /// 値が低いほど評価が高い。
    /// 例：PER、PBR、D/Eレシオ。
    /// </summary>
    Lower = 2,

    /// <summary>
    /// 適正範囲に近いほど評価が高い。
    /// 例：配当性向。
    /// </summary>
    Range = 3,

    /// <summary>
    /// 市況・サブセクター・戦略によって評価が変わる。
    /// 例：Momentum5、Momentum25、MarketScore。
    /// </summary>
    Context = 4
}