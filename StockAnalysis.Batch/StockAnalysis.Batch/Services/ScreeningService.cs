using Microsoft.EntityFrameworkCore;
using StockAnalysis.Batch.Data;

namespace StockAnalysis.Batch.Services;

public class ScreeningService
{
    private readonly StockAnalysisDbContext _db;

    public ScreeningService(
        StockAnalysisDbContext db)
    {
        _db = db;
    }

    public async Task<List<ScreeningResult>> GetTopStocksAsync(
        int topCount = 20)
    {
        var latestDate =
            await _db.StockScoresDaily
                .MaxAsync(x => x.ScoreDate);

        return await _db.StockScoresDaily
            .Where(x => x.ScoreDate == latestDate)
            .Join(
                _db.Companies,
                score => score.Code,
                company => company.Code,
                (score, company) =>
                    new ScreeningResult
                    {
                        Code = score.Code,
                        CompanyName = company.CompanyName,

                        TotalScore = score.TotalScore,
                        FinancialScore = score.FinancialScore,
                        TechnicalScore = score.TechnicalScore,
                        MarketScore = score.MarketScore
                    })
            .OrderByDescending(x => x.TotalScore)
            .ThenByDescending(x => x.FinancialScore)
            .Take(topCount)
            .ToListAsync();
    }
}