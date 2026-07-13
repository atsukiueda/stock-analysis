using System.Text.Json.Serialization;

namespace StockAnalysis.Batch.Dtos;

/// <summary>
/// EDINET書類一覧APIのレスポンスを表す。
/// Prototypeでは書類メタデータ取得のみに使用する。
/// </summary>
public class EdinetDocumentListResponse
{
    /// <summary>
    /// EDINET APIのメタデータ。
    /// </summary>
    [JsonPropertyName("metadata")]
    public EdinetMetadata? Metadata { get; set; }

    /// <summary>
    /// 指定日に提出された書類一覧。
    /// </summary>
    [JsonPropertyName("results")]
    public List<EdinetDocumentDto> Results { get; set; } = [];
}

/// <summary>
/// EDINET APIレスポンスのメタデータを表す。
/// </summary>
public class EdinetMetadata
{
    /// <summary>
    /// APIのタイトル。
    /// </summary>
    [JsonPropertyName("title")]
    public string? Title { get; set; }

    /// <summary>
    /// EDINET APIが認識したRequest Parameter。
    /// Prototypeではdateとtypeの確認に使用する。
    /// </summary>
    [JsonPropertyName("parameter")]
    public EdinetParameter? Parameter { get; set; }

    /// <summary>
    /// APIレスポンスに含まれる対象件数情報。
    /// </summary>
    [JsonPropertyName("resultset")]
    public EdinetResultSet? ResultSet { get; set; }

    /// <summary>
    /// EDINET側でResponseが生成された日時。
    /// </summary>
    [JsonPropertyName("processDateTime")]
    public string? ProcessDateTime { get; set; }

    /// <summary>
    /// APIレスポンスのステータス。
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// APIレスポンスメッセージ。
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }
}

/// <summary>
/// EDINET APIが認識したRequest Parameterを表す。
/// </summary>
public class EdinetParameter
{
    /// <summary>
    /// APIが認識したファイル日付。
    /// </summary>
    [JsonPropertyName("date")]
    public string? Date { get; set; }

    /// <summary>
    /// APIが認識した取得情報種別。
    /// 2の場合は提出書類一覧及びメタデータ。
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; set; }
}

/// <summary>
/// EDINET書類一覧APIの件数情報を表す。
/// </summary>
public class EdinetResultSet
{
    /// <summary>
    /// 指定日の提出書類件数。
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }
}

/// <summary>
/// EDINET提出書類のメタデータを表す。
/// </summary>
public class EdinetDocumentDto
{
    /// <summary>
    /// EDINET書類管理ID。
    /// </summary>
    [JsonPropertyName("docID")]
    public string? DocumentId { get; set; }

    /// <summary>
    /// 提出者のEDINETコード。
    /// </summary>
    [JsonPropertyName("edinetCode")]
    public string? EdinetCode { get; set; }

    /// <summary>
    /// 証券コード。
    /// </summary>
    [JsonPropertyName("secCode")]
    public string? SecurityCode { get; set; }

    /// <summary>
    /// 提出者名称。
    /// </summary>
    [JsonPropertyName("filerName")]
    public string? FilerName { get; set; }

    /// <summary>
    /// 府令コード。
    /// </summary>
    [JsonPropertyName("ordinanceCode")]
    public string? OrdinanceCode { get; set; }

    /// <summary>
    /// 様式コード。
    /// </summary>
    [JsonPropertyName("formCode")]
    public string? FormCode { get; set; }

    /// <summary>
    /// 書類種別コード。
    /// </summary>
    [JsonPropertyName("docTypeCode")]
    public string? DocumentTypeCode { get; set; }

    /// <summary>
    /// 対象期間開始日。
    /// </summary>
    [JsonPropertyName("periodStart")]
    public string? PeriodStart { get; set; }

    /// <summary>
    /// 対象期間終了日。
    /// </summary>
    [JsonPropertyName("periodEnd")]
    public string? PeriodEnd { get; set; }

    /// <summary>
    /// EDINETへの提出日時。
    /// Point-in-time評価で重要な時間情報。
    /// </summary>
    [JsonPropertyName("submitDateTime")]
    public string? SubmitDateTime { get; set; }

    /// <summary>
    /// 親書類ID。
    /// 訂正書類等の関係確認候補として保持する。
    /// </summary>
    [JsonPropertyName("parentDocID")]
    public string? ParentDocumentId { get; set; }

    /// <summary>
    /// 操作日時。
    /// </summary>
    [JsonPropertyName("opeDateTime")]
    public string? OperationDateTime { get; set; }

    /// <summary>
    /// 取下げ状態。
    /// </summary>
    [JsonPropertyName("withdrawalStatus")]
    public string? WithdrawalStatus { get; set; }

    /// <summary>
    /// 書類情報修正状態。
    /// </summary>
    [JsonPropertyName("docInfoEditStatus")]
    public string? DocumentInfoEditStatus { get; set; }

    /// <summary>
    /// 開示状態。
    /// </summary>
    [JsonPropertyName("disclosureStatus")]
    public string? DisclosureStatus { get; set; }

    /// <summary>
    /// XBRLファイル有無。
    /// </summary>
    [JsonPropertyName("xbrlFlag")]
    public string? XbrlFlag { get; set; }

    /// <summary>
    /// XBRL変換CSVファイル有無。
    /// </summary>
    [JsonPropertyName("csvFlag")]
    public string? CsvFlag { get; set; }

    /// <summary>
    /// 書類概要。
    /// Console Prototypeで書類識別に使用する。
    /// </summary>
    [JsonPropertyName("docDescription")]
    public string? DocumentDescription { get; set; }
}