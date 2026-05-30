using System.Text.Json;
using Microsoft.Extensions.Configuration;
using StockAnalysis.Batch.Dtos;

namespace StockAnalysis.Batch.Services;

public class JQuantsFinancialService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public JQuantsFinancialService(
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<List<JQuantsFinancialDto>> GetFinancialsAsync(
        string code)
    {
        var apiKey = _configuration["JQuants:ApiKey"];

        using var request = new HttpRequestMessage(
            HttpMethod.Get,
            $"https://api.jquants.com/v2/fins/summary?code={code}");

        request.Headers.Add(
            "x-api-key",
            apiKey);

        var response =
            await _httpClient.SendAsync(request);

        var json =
            await response.Content.ReadAsStringAsync();

        Console.WriteLine(
            json[..Math.Min(json.Length, 2000)]);

        if (!response.IsSuccessStatusCode)
        {
            throw new HttpRequestException(
                $"財務取得失敗: {(int)response.StatusCode} {json}");
        }

        var result =
            JsonSerializer.Deserialize<JQuantsFinancialResponse>(
                json);

        return result?.Data ?? [];
    }
}