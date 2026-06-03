using Microsoft.EntityFrameworkCore;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;

namespace StockAnalysis.Batch.Services;

public class StockScoreService
{
    private readonly StockAnalysisDbContext _db;

    public StockScoreService(StockAnalysisDbContext db)
    {
        _db = db;
    }

    public async Task<StockScoreDaily?> CalculateAsync(string code)
    {
        var latestPrice = await _db.PricesDaily
            .Where(x => x.Code == code && x.ClosePrice != null)
            .OrderByDescending(x => x.TradeDate)
            .FirstOrDefaultAsync();

        if (latestPrice == null)
        {
            return null;
        }

        var scoreDate = latestPrice.TradeDate;

        var financialScore = await CalculateFinancialScoreAsync(code);
        var growthScore = await CalculateGrowthScoreAsync(code);
        var technicalScore = await CalculateTechnicalScoreAsync(code, scoreDate);
        var marketScore = await CalculateMarketScoreAsync(scoreDate);
        var dividendScore = await CalculateDividendScoreAsync(code);
        var roeScore = await CalculateRoeScoreAsync(code);
        var perScore = await CalculatePerScoreAsync(code);

        var totalScore =
            financialScore +
            growthScore +
            dividendScore +
            roeScore +
            perScore +
            technicalScore +
            marketScore;

        var now = DateTime.Now;

        return new StockScoreDaily
        {
            Code = code,
            ScoreDate = scoreDate,

            FinancialScore = financialScore,
            GrowthScore = growthScore,
            TechnicalScore = technicalScore,
            MarketScore = marketScore,
            TotalScore = totalScore,
            DividendScore = dividendScore,
            RoeScore = roeScore,
            PerScore = perScore,

            CreatedAt = now,
            UpdatedAt = now
        };
    }

    public async Task SaveAsync(StockScoreDaily score)
    {
        var existing = await _db.StockScoresDaily.FindAsync(
            score.Code,
            score.ScoreDate);

        if (existing == null)
        {
            _db.StockScoresDaily.Add(score);
        }
        else
        {
            existing.FinancialScore = score.FinancialScore;
            existing.GrowthScore = score.GrowthScore;
            existing.TechnicalScore = score.TechnicalScore;
            existing.MarketScore = score.MarketScore;
            existing.TotalScore = score.TotalScore;
            existing.DividendScore = score.DividendScore;
            existing.RoeScore = score.RoeScore;
            existing.PerScore = score.PerScore;
            existing.UpdatedAt = DateTime.Now;
        }

        await _db.SaveChangesAsync();
    }

    public async Task GenerateAllAsync()
    {
        var codes = await _db.Companies
            .Where(x => x.IsActive)
            .Where(x => x.MarketName != "その他")
            .Where(x => x.MarketName != "TOKYO PRO MARKET")
            .OrderBy(x => x.Code)
            .Select(x => x.Code)
            .ToListAsync();

        Console.WriteLine(
            $"対象銘柄数: {codes.Count}");

        foreach (var code in codes)
        {
            var score =
                await CalculateAsync(code);

            if (score == null)
            {
                continue;
            }

            await SaveAsync(score);
        }
    }

    private async Task<int> CalculateFinancialScoreAsync(
    string code)
    {
        var financial = await _db.FinancialStatements
            .Where(x => x.Code == code)
            .Where(x =>
                x.NetSales != null &&
                x.OperatingProfit != null &&
                x.EarningsPerShare != null &&
                x.EquityToAssetRatio != null)
            .OrderByDescending(x => x.DisclosedDate)
            .FirstOrDefaultAsync();

        if (financial == null)
        {
            return 0;
        }

        var score = 0;

        // 売上高スコア：最大15点
        if (financial.NetSales >= 1_000_000_000_000m) // 1兆円以上
        {
            score += 15;
        }
        else if (financial.NetSales >= 100_000_000_000m) // 1000億円以上
        {
            score += 10;
        }
        else if (financial.NetSales >= 10_000_000_000m) // 100億円以上
        {
            score += 5;
        }

        // 営業利益スコア：最大10点
        if (financial.OperatingProfit > 0)
        {
            score += 10;
        }

        // EPSスコア：最大15点
        if (financial.EarningsPerShare >= 100m)
        {
            score += 15;
        }
        else if (financial.EarningsPerShare >= 30m)
        {
            score += 10;
        }
        else if (financial.EarningsPerShare > 0)
        {
            score += 5;
        }

        // 自己資本比率スコア：最大10点
        if (financial.EquityToAssetRatio >= 0.70m)
        {
            score += 10;
        }
        else if (financial.EquityToAssetRatio >= 0.50m)
        {
            score += 7;
        }
        else if (financial.EquityToAssetRatio >= 0.30m)
        {
            score += 3;
        }

        return score;
    }

    private async Task<int> CalculateTechnicalScoreAsync(
        string code,
        DateTime scoreDate)
    {
        var priceCount = await _db.PricesDaily
            .Where(x =>
                x.Code == code &&
                x.ClosePrice != null)
            .CountAsync();
        if (priceCount < 200)
        {
            Console.WriteLine(
                $"{code}: 上場期間不足のためテクニカル評価対象外");

            return 0;
        }

        var latest = await _db.PricesDaily
            .Where(x =>
                x.Code == code &&
                x.TradeDate <= scoreDate &&
                x.ClosePrice != null)
            .OrderByDescending(x => x.TradeDate)
            .FirstOrDefaultAsync();

        if (latest?.ClosePrice == null)
        {
            return 0;
        }

        var ma25 = await CalculateMovingAverageAsync(code, scoreDate, 25);
        var ma75 = await CalculateMovingAverageAsync(code, scoreDate, 75);

        var score = 0;

        if (ma25 != null && latest.ClosePrice > ma25)
        {
            score += 10;
        }

        if (ma75 != null && latest.ClosePrice > ma75)
        {
            score += 10;
        }

        if (ma25 != null && ma75 != null && ma25 > ma75)
        {
            score += 10;
        }

        return score;
    }

    private async Task<int> CalculateMarketScoreAsync(DateTime scoreDate)
    {
        var marketScore = await _db.MarketScoresDaily
            .Where(x => x.ScoreDate <= scoreDate)
            .OrderByDescending(x => x.ScoreDate)
            .FirstOrDefaultAsync();

        if (marketScore == null)
        {
            return 0;
        }

        return marketScore.TotalScore switch
        {
            >= 80 => 20,
            >= 60 => 15,
            >= 40 => 10,
            >= 20 => 5,
            _ => 0
        };
    }

    private async Task<decimal?> CalculateMovingAverageAsync(
        string code,
        DateTime scoreDate,
        int days)
    {
        var closes = await _db.PricesDaily
            .Where(x =>
                x.Code == code &&
                x.TradeDate <= scoreDate &&
                x.ClosePrice != null)
            .OrderByDescending(x => x.TradeDate)
            .Take(days)
            .Select(x => x.ClosePrice!.Value)
            .ToListAsync();

        if (closes.Count < days)
        {
            return null;
        }

        return closes.Average();
    }

    private async Task<int> CalculateGrowthScoreAsync(string code)
    {
        var statements = await _db.FinancialStatements
            .Where(x => x.Code == code)
            .Where(x => x.TypeOfDocument != null)
            .Where(x => x.TypeOfDocument.StartsWith("FYFinancialStatements"))
            .Where(x => x.NetSales != null)
            .Where(x => x.OperatingProfit != null)
            .Where(x => x.EarningsPerShare != null)
            .OrderByDescending(x => x.DisclosedDate)
            .Take(2)
            .ToListAsync();

        if (statements.Count < 2)
        {
            return 0;
        }

        var latest = statements[0];
        var previous = statements[1];

        var salesGrowthRate = CalculateGrowthRate(
            latest.NetSales,
            previous.NetSales);

        var operatingProfitGrowthRate = CalculateGrowthRate(
            latest.OperatingProfit,
            previous.OperatingProfit);

        var epsGrowthRate = CalculateGrowthRate(
            latest.EarningsPerShare,
            previous.EarningsPerShare);

        var score = 0;

        score += ToGrowthPoint(salesGrowthRate);
        score += ToGrowthPoint(operatingProfitGrowthRate);
        score += ToGrowthPoint(epsGrowthRate);

        return score;
    }

    private static decimal CalculateGrowthRate(
        decimal? current,
        decimal? previous)
    {
        if (current == null || previous == null)
        {
            return 0;
        }

        if (previous <= 0)
        {
            return 0;
        }

        return ((current.Value - previous.Value) / previous.Value) * 100m;
    }

    private static int ToGrowthPoint(decimal growthRate)
    {
        if (growthRate >= 50m)
        {
            return 10;
        }

        if (growthRate >= 20m)
        {
            return 5;
        }

        return 0;
    }

    private static int ToDividendPoint(decimal dividendYield)
    {
        if (dividendYield >= 5m)
        {
            return 20;
        }

        if (dividendYield >= 4m)
        {
            return 15;
        }

        if (dividendYield >= 3m)
        {
            return 10;
        }

        if (dividendYield >= 2m)
        {
            return 5;
        }

        return 0;
    }

    private async Task<int> CalculateDividendScoreAsync(string code)
    {
        var financial = await _db.FinancialStatements
            .Where(x => x.Code == code)
            .Where(x => x.TypeOfDocument != null)
            .Where(x => x.TypeOfDocument.StartsWith("FYFinancialStatements"))
            .OrderByDescending(x => x.DisclosedDate)
            .FirstOrDefaultAsync();

        if (financial == null)
        {
            return 0;
        }

        var latestPrice = await _db.PricesDaily
            .Where(x => x.Code == code)
            .Where(x => x.ClosePrice != null)
            .OrderByDescending(x => x.TradeDate)
            .FirstOrDefaultAsync();

        if (latestPrice == null)
        {
            return 0;
        }

        if (latestPrice.ClosePrice == null ||
            latestPrice.ClosePrice <= 0)
        {
            return 0;
        }

        var dividendPerShare =
            financial.ForecastDividendPerShareAnnual
            ?? financial.ResultDividendPerShareAnnual;

        if (dividendPerShare == null)
        {
            return 0;
        }

        var dividendYield =
            dividendPerShare.Value
            / latestPrice.ClosePrice.Value
            * 100m;

        return ToDividendPoint(dividendYield);
    }

    private async Task<int> CalculateRoeScoreAsync(string code)
    {
        var financial = await _db.FinancialStatements
            .Where(x => x.Code == code)
            .Where(x => x.TypeOfDocument != null)
            .Where(x => x.TypeOfDocument.StartsWith("FYFinancialStatements"))
            .OrderByDescending(x => x.DisclosedDate)
            .FirstOrDefaultAsync();

        if (financial == null)
        {
            return 0;
        }

        if (financial.EarningsPerShare == null ||
            financial.BookValuePerShare == null)
        {
            return 0;
        }

        if (financial.BookValuePerShare <= 0)
        {
            return 0;
        }

        var roe =
            financial.EarningsPerShare.Value
            / financial.BookValuePerShare.Value
            * 100m;

        return ToRoePoint(roe);
    }

    private static int ToRoePoint(decimal roe)
    {
        if (roe >= 15m)
        {
            return 20;
        }

        if (roe >= 10m)
        {
            return 15;
        }

        if (roe >= 8m)
        {
            return 10;
        }

        if (roe >= 5m)
        {
            return 5;
        }

        return 0;
    }

    private async Task<int> CalculatePerScoreAsync(
    string code)
    {
        var financial = await _db.FinancialStatements
            .Where(x => x.Code == code)
            .Where(x => x.TypeOfDocument != null)
            .Where(x => x.TypeOfDocument.StartsWith(
                "FYFinancialStatements"))
            .OrderByDescending(x => x.DisclosedDate)
            .FirstOrDefaultAsync();

        if (financial == null)
        {
            return 0;
        }

        if (financial.EarningsPerShare == null ||
            financial.EarningsPerShare <= 0)
        {
            return 0;
        }

        var latestPrice = await _db.PricesDaily
            .Where(x => x.Code == code)
            .Where(x => x.ClosePrice != null)
            .OrderByDescending(x => x.TradeDate)
            .FirstOrDefaultAsync();

        if (latestPrice == null)
        {
            return 0;
        }

        var per =
            latestPrice.ClosePrice.Value
            / financial.EarningsPerShare.Value;

        return ToPerPoint(per);
    }

    private static int ToPerPoint(decimal per)
    {
        if (per <= 10m)
        {
            return 20;
        }

        if (per <= 15m)
        {
            return 15;
        }

        if (per <= 20m)
        {
            return 10;
        }

        if (per <= 30m)
        {
            return 5;
        }

        return 0;
    }
}