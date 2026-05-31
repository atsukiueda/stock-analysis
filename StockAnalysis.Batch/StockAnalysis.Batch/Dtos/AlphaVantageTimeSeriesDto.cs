using System.Text.Json.Serialization;

namespace StockAnalysis.Batch.Dtos;

public class AlphaVantageTimeSeriesResponse
{
    [JsonPropertyName("Meta Data")]
    public AlphaVantageTimeSeriesMetaData? MetaData { get; set; }

    [JsonPropertyName("Time Series (Daily)")]
    public Dictionary<string, AlphaVantageDailyDto> DailyItems { get; set; } = [];
}

public class AlphaVantageTimeSeriesMetaData
{
    [JsonPropertyName("1. Information")]
    public string? Information { get; set; }

    [JsonPropertyName("2. Symbol")]
    public string? Symbol { get; set; }
}

public class AlphaVantageDailyDto
{
    [JsonPropertyName("1. open")]
    public string? Open { get; set; }

    [JsonPropertyName("2. high")]
    public string? High { get; set; }

    [JsonPropertyName("3. low")]
    public string? Low { get; set; }

    [JsonPropertyName("4. close")]
    public string? Close { get; set; }

    [JsonPropertyName("5. volume")]
    public string? Volume { get; set; }
}