using System.Text.Json.Serialization;

namespace StockAnalysis.Batch.Dtos;

public class FredObservationResponse
{
    [JsonPropertyName("observations")]
    public List<FredObservationDto> Observations { get; set; } = [];
}

public class FredObservationDto
{
    [JsonPropertyName("date")]
    public string Date { get; set; } = string.Empty;

    [JsonPropertyName("value")]
    public string? Value { get; set; }
}