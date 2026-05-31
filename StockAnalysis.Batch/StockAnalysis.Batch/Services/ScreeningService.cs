using Microsoft.EntityFrameworkCore;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;

namespace StockAnalysis.Batch.Services;

public class ScreeningService
{
    private readonly StockAnalysisDbContext _db;

    public ScreeningService(
        StockAnalysisDbContext db)
    {
        _db = db;
    }

    private static int GetMarketRegimeBonus(
    string marketName,
    string marketRegime)
    {
        if (marketRegime == "StrongRiskOn")
        {
            return marketName switch
            {
                "グロース" => 5,
                "スタンダード" => 2,
                _ => 0
            };
        }

        if (marketRegime.Contains("RiskOff"))
        {
            return marketName switch
            {
                "プライム" => 5,
                "スタンダード" => 2,
                _ => 0
            };
        }

        return 0;
    }

    public async Task<List<ScreeningResult>> GetTopStocksAsync(
    int topCount = 20)
    {
        var latestDate =
            await _db.StockScoresDaily
                .MaxAsync(x => x.ScoreDate);

        var latestMarket =
            await _db.MarketScoresDaily
                .OrderByDescending(x => x.ScoreDate)
                .FirstAsync();

        var sourceItems = await _db.StockScoresDaily
            .Where(x => x.ScoreDate == latestDate)
            .Join(
                _db.Companies,
                score => score.Code,
                company => company.Code,
                (score, company) =>
                    new
                    {
                        Score = score,
                        Company = company
                    })
            .ToListAsync();

        var results = sourceItems
            .Select(x =>
            {
                var bonus = GetMarketRegimeBonus(
                    x.Company.MarketName,
                    latestMarket.MarketRegime ?? "");

                return new ScreeningResult
                {
                    Code = x.Score.Code,
                    CompanyName = x.Company.CompanyName,

                    FinancialScore = x.Score.FinancialScore,
                    GrowthScore = x.Score.GrowthScore,
                    TechnicalScore = x.Score.TechnicalScore,
                    MarketScore = x.Score.MarketScore,
                    MarketRegimeBonus = bonus,

                    TotalScore = x.Score.TotalScore + bonus
                };
            })
            .OrderByDescending(x => x.TotalScore)
            .ThenByDescending(x => x.FinancialScore)
            .Take(topCount)
            .ToList();

        return results;
    }
}