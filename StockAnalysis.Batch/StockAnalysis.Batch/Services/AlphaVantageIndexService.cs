using System.Text.Json;
using Microsoft.Extensions.Configuration;
using StockAnalysis.Batch.Dtos;

namespace StockAnalysis.Batch.Services;

public class AlphaVantageIndexService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public AlphaVantageIndexService(
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<Dictionary<string, AlphaVantageDailyDto>> GetDailyAsync(
        string symbol)
    {
        var apiKey = _configuration["AlphaVantage:ApiKey"];

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException("Alpha Vantage APIキーが未設定です。");
        }

        var url =
            "https://www.alphavantage.co/query" +
            "?function=TIME_SERIES_DAILY" +
            $"&symbol={symbol}" +
            $"&apikey={apiKey}";

        var response = await _httpClient.GetAsync(url);
        var json = await response.Content.ReadAsStringAsync();
        // レスポンス確認用
        Console.WriteLine(
            json[..Math.Min(json.Length, 2000)]);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"Alpha Vantage取得失敗: {(int)response.StatusCode} {json}");
        }

        var result =
            JsonSerializer.Deserialize<AlphaVantageTimeSeriesResponse>(json);

        return result?.DailyItems ?? [];
    }
}