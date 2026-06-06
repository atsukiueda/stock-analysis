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
    ScreeningCondition? condition = null)
    {
        condition ??= new ScreeningCondition();

        var latestDate =
            await _db.StockScoresDaily
                .MaxAsync(x => x.ScoreDate);

        var latestMarket =
            await _db.MarketScoresDaily
                .OrderByDescending(x => x.ScoreDate)
                .FirstAsync();

        var query = _db.StockScoresDaily
            .Where(x => x.ScoreDate == latestDate)
            .Join(
                _db.Companies,
                score => score.Code,
                company => company.Code,
                (score, company) => new
                {
                    Score = score,
                    Company = company
                });

        if (condition.MinFinancialScore.HasValue)
        {
            query = query.Where(x =>
                x.Score.FinancialScore >= condition.MinFinancialScore.Value);
        }

        if (condition.MinGrowthScore.HasValue)
        {
            query = query.Where(x =>
                x.Score.GrowthScore >= condition.MinGrowthScore.Value);
        }

        if (condition.MinDividendScore.HasValue)
        {
            query = query.Where(x =>
                x.Score.DividendScore >= condition.MinDividendScore.Value);
        }

        if (condition.MinRoeScore.HasValue)
        {
            query = query.Where(x =>
                x.Score.RoeScore >= condition.MinRoeScore.Value);
        }

        if (condition.MinPerScore.HasValue)
        {
            query = query.Where(x =>
                x.Score.PerScore >= condition.MinPerScore.Value);
        }

        if (condition.MinPbrScore.HasValue)
        {
            query = query.Where(x =>
                x.Score.PbrScore >= condition.MinPbrScore.Value);
        }

        if (condition.MinTechnicalScore.HasValue)
        {
            query = query.Where(x =>
                x.Score.TechnicalScore >= condition.MinTechnicalScore.Value);
        }

        if (condition.MinMarketScore.HasValue)
        {
            query = query.Where(x =>
                x.Score.MarketScore >= condition.MinMarketScore.Value);
        }

        if (!string.IsNullOrWhiteSpace(condition.MarketName))
        {
            query = query.Where(x =>
                x.Company.MarketName == condition.MarketName);
        }

        if (condition.MinSwingScore.HasValue)
        {
            query = query.Where(x =>
                x.Score.SwingScore >= condition.MinSwingScore.Value);
        }

        var sourceItems =
            await query.ToListAsync();

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
                    DividendScore = x.Score.DividendScore,
                    RoeScore = x.Score.RoeScore,
                    PerScore = x.Score.PerScore,
                    PbrScore = x.Score.PbrScore,
                    TechnicalScore = x.Score.TechnicalScore,
                    MarketScore = x.Score.MarketScore,
                    MarketRegimeBonus = bonus,
                    SwingScore = x.Score.SwingScore,

                    TotalScore = x.Score.TotalScore + bonus
                };
            })
            .OrderByDescending(x => x.TotalScore)
            .ThenByDescending(x => x.FinancialScore)
            .Take(condition.TopCount)
            .ToList();

        return results;
    }
}