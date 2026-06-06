using System.Text.Json;
using Microsoft.Extensions.Configuration;
using StockAnalysis.Batch.Dtos;

namespace StockAnalysis.Batch.Services;

public class AlphaVantageFxService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public AlphaVantageFxService(
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<Dictionary<string, AlphaVantageFxDailyDto>> GetUsdJpyDailyAsync()
    {
        var apiKey = _configuration["AlphaVantage:ApiKey"];

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException("Alpha Vantage APIキーが未設定です。");
        }

        var url =
            "https://www.alphavantage.co/query" +
            "?function=FX_DAILY" +
            "&from_symbol=USD" +
            "&to_symbol=JPY" +
            "&outputsize=full" +
            $"&apikey={apiKey}";

        var response = await _httpClient.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"USDJPY取得失敗: {(int)response.StatusCode} {json}");
        }

        var result =
            JsonSerializer.Deserialize<AlphaVantageFxResponse>(json);

        return result?.DailyItems ?? [];
    }
}