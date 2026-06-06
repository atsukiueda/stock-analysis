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

    public async Task<List<SwingTradeAdvice>> GetSwingTradeAdvicesAsync(
    int topCount = 10)
    {
        var latestDate =
            await _db.StockScoresDaily
                .MaxAsync(x => x.ScoreDate);

        var sourceItems = await _db.StockScoresDaily
            .Where(x => x.ScoreDate == latestDate)
            .Where(x => x.SwingScore >= 60)
            .Where(x => x.TechnicalScore >= 20)
            .Join(
                _db.Companies,
                score => score.Code,
                company => company.Code,
                (score, company) => new
                {
                    Score = score,
                    Company = company
                })
            .OrderByDescending(x => x.Score.SwingScore)
            .Take(topCount)
            .ToListAsync();

        var results = new List<SwingTradeAdvice>();

        foreach (var item in sourceItems)
        {
            var latestPrice = await _db.PricesDaily
                .Where(x => x.Code == item.Score.Code)
                .Where(x => x.TradeDate <= latestDate)
                .Where(x => x.ClosePrice != null)
                .OrderByDescending(x => x.TradeDate)
                .FirstOrDefaultAsync();

            if (latestPrice == null ||
                latestPrice.ClosePrice == null ||
                latestPrice.ClosePrice <= 0)
            {
                continue;
            }

            var entryPrice =
                latestPrice.ClosePrice.Value;

            var takeProfitPrice =
                Math.Round(entryPrice * 1.05m, 2);

            var stopLossPrice =
                Math.Round(entryPrice * 0.97m, 2);

            results.Add(new SwingTradeAdvice
            {
                Code = item.Score.Code,
                CompanyName = item.Company.CompanyName,
                TradeDate = latestPrice.TradeDate,
                EntryPrice = entryPrice,
                TakeProfitPrice = takeProfitPrice,
                StopLossPrice = stopLossPrice,
                SwingScore = item.Score.SwingScore,
                Comment =
                    $"SwingScore {item.Score.SwingScore}. " +
                    $"終値付近でのエントリー想定。利確目安+5%、損切目安-3%。"
            });
        }

        return results;
    }
}