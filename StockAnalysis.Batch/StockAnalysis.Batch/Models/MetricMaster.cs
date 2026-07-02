using StockAnalysis.Batch.Models.Ml;

namespace StockAnalysis.Batch.Models;

/// <summary>
/// 投資評価指標のマスター。
/// サブセクター別評価ポリシー、Evidence、Advisor説明で共通利用する。
/// </summary>
public class MetricMaster
{
    /// <summary>
    /// 評価指標ID。
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 評価指標コード。
    /// 例：RevenueGrowth、OperatingMargin、ROE、PER。
    /// </summary>
    public string MetricCode { get; set; } = "";

    /// <summary>
    /// 評価指標名。
    /// 例：売上成長率、営業利益率、自己資本利益率。
    /// </summary>
    public string MetricName { get; set; } = "";

    /// <summary>
    /// 評価指標カテゴリ。
    /// 例：Growth、Profitability、Valuation、Financial、Dividend、Technical、Market。
    /// </summary>
    public string Category { get; set; } = "";

    /// <summary>
    /// 評価指標の説明。
    /// Advisorの説明文生成にも利用する。
    /// </summary>
    public string Description { get; set; } = "";

    /// <summary>
    /// 単位。
    /// 例：%、倍、円、score、0-1。
    /// </summary>
    public string Unit { get; set; } = "";

    /// <summary>
    /// 指標値の評価方式。
    /// Higher、Lower、Range、Contextで評価ロジックを切り替える。
    /// </summary>
    public MetricEvaluationType EvaluationType { get; set; }

    /// <summary>
    /// 算出方法。
    /// 手計算・SQL・バッチ・ML特徴量のどれで算出するかを説明する。
    /// </summary>
    public string CalculationMethod { get; set; } = "";

    /// <summary>
    /// 利用用途。
    /// 例：SubSectorPolicy、MLFeature、Advisor、BacktestAnalysis。
    /// </summary>
    public string UsedFor { get; set; } = "";

    /// <summary>
    /// 初期重要度の目安。
    /// Evidence蓄積前の仮置き値として使用する。
    /// 0.0〜10.0。
    /// </summary>
    public decimal InitialImportanceHint { get; set; }

    /// <summary>
    /// Evidenceとして要求する検証内容。
    /// 例：バックテスト、Feature Importance、業界常識、外部研究。
    /// </summary>
    public string EvidenceRequirement { get; set; } = "";

    /// <summary>
    /// 表示順。
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// 有効フラグ。
    /// </summary>
    public bool IsActive { get; set; } = true;
}