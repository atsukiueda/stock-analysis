using System.Text.Json;
using Microsoft.Extensions.Configuration;
using StockAnalysis.Batch.Dtos;

namespace StockAnalysis.Batch.Services;

public class JQuantsTopixService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public JQuantsTopixService(
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<List<JQuantsTopixDto>> GetTopixAsync()
    {
        var apiKey = _configuration["JQuants:ApiKey"];

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException("J-Quants APIキーが未設定です。");
        }

        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            "https://api.jquants.com/v2/indices/bars/daily/topix");

        request.Headers.Add("x-api-key", apiKey);

        var response = await _httpClient.SendAsync(request);
        var json = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"TOPIX取得失敗: {(int)response.StatusCode} {json}");
        }

        var result = JsonSerializer.Deserialize<JQuantsTopixResponse>(json);

        return result?.Data ?? [];
    }
}