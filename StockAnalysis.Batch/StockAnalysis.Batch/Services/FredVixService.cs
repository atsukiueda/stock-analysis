using System.Text.Json;
using Microsoft.Extensions.Configuration;
using StockAnalysis.Batch.Dtos;

namespace StockAnalysis.Batch.Services;

public class FredVixService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public FredVixService(
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<List<FredObservationDto>> GetVixAsync()
    {
        var apiKey = _configuration["Fred:ApiKey"];

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException("FRED APIキーが未設定です。");
        }

        var url =
            "https://api.stlouisfed.org/fred/series/observations" +
            "?series_id=VIXCLS" +
            "&file_type=json" +
            $"&api_key={apiKey}";

        var response = await _httpClient.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"FRED VIX取得失敗: {(int)response.StatusCode} {json}");
        }

        var result =
            JsonSerializer.Deserialize<FredObservationResponse>(json);

        return result?.Observations ?? [];
    }
}