namespace StockAnalysis.Batch.Models;

/// <summary>
/// 投資セクターマスター。
/// Knowledge Baseにおける投資判断用の大分類を管理する。
/// </summary>
public class SectorMaster
{
    /// <summary>
    /// セクターID。
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// セクターコード。
    /// 内部識別子として利用するため、原則変更禁止。
    /// </summary>
    public string SectorCode { get; set; } = string.Empty;

    /// <summary>
    /// セクター名。
    /// </summary>
    public string SectorName { get; set; } = string.Empty;

    /// <summary>
    /// セクター英語名。
    /// </summary>
    public string? SectorNameEn { get; set; }

    /// <summary>
    /// セクター説明。
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// 有効フラグ。
    /// </summary>
    public bool IsActive { get; set; } = true;

    /// <summary>
    /// 表示順。
    /// </summary>
    public int DisplayOrder { get; set; }

    /// <summary>
    /// 作成日時。
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 更新日時。
    /// </summary>
    public DateTime UpdatedAt { get; set; }
}