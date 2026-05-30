using System.Text.Json.Serialization;

namespace StockAnalysis.Batch.Dtos;

public class JQuantsPriceResponse
{
    [JsonPropertyName("data")]
    public List<JQuantsPriceDto> DailyQuotes { get; set; } = [];
}

public class JQuantsPriceDto
{
    [JsonPropertyName("Code")]
    public string Code { get; set; } = string.Empty;

    [JsonPropertyName("Date")]
    public string Date { get; set; } = string.Empty;

    [JsonPropertyName("O")]
    public decimal? Open { get; set; }

    [JsonPropertyName("H")]
    public decimal? High { get; set; }

    [JsonPropertyName("L")]
    public decimal? Low { get; set; }

    [JsonPropertyName("C")]
    public decimal? Close { get; set; }

    [JsonPropertyName("Vo")]
    public decimal? Volume { get; set; }

    [JsonPropertyName("Va")]
    public decimal? TurnoverValue { get; set; }

    [JsonPropertyName("AdjFactor")]
    public decimal? AdjustmentFactor { get; set; }

    [JsonPropertyName("AdjC")]
    public decimal? AdjustmentClose { get; set; }

    [JsonPropertyName("AdjVo")]
    public decimal? AdjustmentVolume { get; set; }
}