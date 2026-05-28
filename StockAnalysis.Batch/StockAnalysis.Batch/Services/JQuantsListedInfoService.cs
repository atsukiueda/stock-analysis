using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;

namespace StockAnalysis.Batch.Services;

public class JQuantsListedInfoService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public JQuantsListedInfoService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<List<JQuantsListedInfo>> GetListedInfoAsync()
    {
        var apiKey = _configuration["JQuants:ApiKey"];

        if (string.IsNullOrWhiteSpace(apiKey))
            throw new InvalidOperationException("J-Quants APIキーが未設定です。");

        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            "https://api.jquants.com/v2/equities/master"
        );

        request.Headers.Add("x-api-key", apiKey);

        var response = await _httpClient.SendAsync(request);

        var json = await response.Content.ReadAsStringAsync();

        Console.WriteLine("=== J-Quants Response ===");
        Console.WriteLine(json[..Math.Min(json.Length, 1000)]);
        Console.WriteLine("=========================");

        if (!response.IsSuccessStatusCode)
            throw new HttpRequestException($"上場銘柄一覧取得失敗: {(int)response.StatusCode} {json}");

        var result = JsonSerializer.Deserialize<JQuantsListedInfoResponse>(json);

        return result?.Data ?? [];
    }
}

public class JQuantsListedInfoResponse
{
    [JsonPropertyName("data")]
    public List<JQuantsListedInfo> Data { get; set; } = [];
}

public class JQuantsListedInfo
{
    [JsonPropertyName("Code")]
    public string Code { get; set; } = string.Empty;

    [JsonPropertyName("CompanyName")]
    public string CompanyName { get; set; } = string.Empty;

    [JsonPropertyName("MarketCodeName")]
    public string? MarketName { get; set; }

    [JsonPropertyName("Sector33CodeName")]
    public string? Sector33Name { get; set; }
}