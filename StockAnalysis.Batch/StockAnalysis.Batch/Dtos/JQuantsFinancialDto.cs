using System.Text.Json.Serialization;

namespace StockAnalysis.Batch.Dtos;

public class JQuantsFinancialResponse
{
    [JsonPropertyName("data")]
    public List<JQuantsFinancialDto> Data { get; set; } = [];
}

public class JQuantsFinancialDto
{
    [JsonPropertyName("DiscNo")]
    public string? DisclosureNumber { get; set; }

    [JsonPropertyName("DiscDate")]
    public string? DisclosedDate { get; set; }

    [JsonPropertyName("Code")]
    public string? Code { get; set; }

    [JsonPropertyName("DocType")]
    public string? TypeOfDocument { get; set; }

    [JsonPropertyName("Sales")]
    public string? NetSales { get; set; }

    [JsonPropertyName("OP")]
    public string? OperatingProfit { get; set; }

    [JsonPropertyName("NP")]
    public string? Profit { get; set; }

    [JsonPropertyName("EPS")]
    public string? EarningsPerShare { get; set; }

    [JsonPropertyName("EqAR")]
    public string? EquityToAssetRatio { get; set; }

    [JsonPropertyName("BPS")]
    public string? BookValuePerShare { get; set; }

    [JsonPropertyName("DivAnn")]
    public string? ResultDividendPerShareAnnual { get; set; }

    [JsonPropertyName("FDivAnn")]
    public string? ForecastDividendPerShareAnnual { get; set; }
}