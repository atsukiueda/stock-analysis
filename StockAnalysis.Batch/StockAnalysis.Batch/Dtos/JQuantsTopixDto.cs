using System.Text.Json.Serialization;

namespace StockAnalysis.Batch.Dtos;

public class JQuantsTopixResponse
{
    [JsonPropertyName("data")]
    public List<JQuantsTopixDto> Data { get; set; } = [];
}

public class JQuantsTopixDto
{
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
}