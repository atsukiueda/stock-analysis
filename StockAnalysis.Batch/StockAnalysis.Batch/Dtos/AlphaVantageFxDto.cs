using System.Text.Json.Serialization;

namespace StockAnalysis.Batch.Dtos;

public class AlphaVantageFxResponse
{
    [JsonPropertyName("Meta Data")]
    public AlphaVantageFxMetaData? MetaData { get; set; }

    [JsonPropertyName("Time Series FX (Daily)")]
    public Dictionary<string, AlphaVantageFxDailyDto> DailyItems { get; set; } = [];
}

public class AlphaVantageFxMetaData
{
    [JsonPropertyName("1. Information")]
    public string? Information { get; set; }

    [JsonPropertyName("2. From Symbol")]
    public string? FromSymbol { get; set; }

    [JsonPropertyName("3. To Symbol")]
    public string? ToSymbol { get; set; }
}

public class AlphaVantageFxDailyDto
{
    [JsonPropertyName("1. open")]
    public string? Open { get; set; }

    [JsonPropertyName("2. high")]
    public string? High { get; set; }

    [JsonPropertyName("3. low")]
    public string? Low { get; set; }

    [JsonPropertyName("4. close")]
    public string? Close { get; set; }
}