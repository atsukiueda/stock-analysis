using Microsoft.EntityFrameworkCore;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;

namespace StockAnalysis.Batch.Services;

public class MarketScoreService
{
    private readonly StockAnalysisDbContext _db;

    public MarketScoreService(StockAnalysisDbContext db)
    {
        _db = db;
    }

    public async Task<MarketScoreDaily?> CalculateLatestAsync()
    {
        var latestTopix = await GetLatestIndexAsync("TOPIX");

        if (latestTopix == null)
        {
            return null;
        }

        var scoreDate = latestTopix.TradeDate;

        var topixScore = await CalculateTopixTrendScoreAsync(scoreDate);
        var sp500Score = await CalculateSp500TrendScoreAsync(scoreDate);
        var nasdaqScore = await CalculateNasdaqTrendScoreAsync(scoreDate);
        var usdJpyScore = await CalculateUsdJpyScoreAsync(scoreDate);
        var vixScore = await CalculateVixScoreAsync(scoreDate);
        var topixMomentumScore = await CalculateTopixMomentumScoreAsync(scoreDate);

        var totalScore =
            topixScore +
            sp500Score +
            nasdaqScore +
            usdJpyScore +
            vixScore +
            topixMomentumScore;

        var regime = totalScore switch
        {
            >= 80 => "StrongRiskOn",
            >= 60 => "RiskOn",
            >= 40 => "Neutral",
            >= 20 => "RiskOff",
            _ => "StrongRiskOff"
        };

        var now = DateTime.Now;

        return new MarketScoreDaily
        {
            ScoreDate = scoreDate,

            TopixTrendScore = topixScore,
            Sp500TrendScore = sp500Score,
            NasdaqTrendScore = nasdaqScore,
            UsdJpyScore = usdJpyScore,
            VixScore = vixScore,
            TopixMomentumScore = topixMomentumScore,

            TotalScore = totalScore,
            MarketRegime = regime,

            Comment =
                $"TOPIX:{topixScore}, " +
                $"SP500:{sp500Score}, " +
                $"NASDAQ:{nasdaqScore}, " +
                $"USDJPY:{usdJpyScore}, " +
                $"VIX:{vixScore}, " +
                $"TOPIX Momentum:{topixMomentumScore}",

            CreatedAt = now,
            UpdatedAt = now
        };
    }

    public async Task SaveAsync(MarketScoreDaily score)
    {
        var existing = await _db.MarketScoresDaily.FindAsync(
            score.ScoreDate);

        if (existing == null)
        {
            _db.MarketScoresDaily.Add(score);
        }
        else
        {
            existing.TopixTrendScore = score.TopixTrendScore;
            existing.Sp500TrendScore = score.Sp500TrendScore;
            existing.NasdaqTrendScore = score.NasdaqTrendScore;
            existing.UsdJpyScore = score.UsdJpyScore;
            existing.VixScore = score.VixScore;
            existing.TopixMomentumScore = score.TopixMomentumScore;
            existing.TotalScore = score.TotalScore;
            existing.MarketRegime = score.MarketRegime;
            existing.Comment = score.Comment;
            existing.UpdatedAt = DateTime.Now;
        }

        await _db.SaveChangesAsync();
    }

    private async Task<MarketIndexDaily?> GetLatestIndexAsync(
        string indexCode)
    {
        return await _db.MarketIndicesDaily
            .Where(x =>
                x.IndexCode == indexCode &&
                x.CloseValue != null)
            .OrderByDescending(x => x.TradeDate)
            .FirstOrDefaultAsync();
    }

    private async Task<int> CalculateTopixTrendScoreAsync(
        DateTime scoreDate)
    {
        return await CalculateDualMovingAverageScoreAsync(
            indexCode: "TOPIX",
            scoreDate: scoreDate,
            shortMaxScore: 15,
            longMaxScore: 15);
    }

    private async Task<int> CalculateSp500TrendScoreAsync(
        DateTime scoreDate)
    {
        return await CalculateDualMovingAverageScoreAsync(
            indexCode: "SP500",
            scoreDate: scoreDate,
            shortMaxScore: 10,
            longMaxScore: 10);
    }

    private async Task<int> CalculateNasdaqTrendScoreAsync(
        DateTime scoreDate)
    {
        var latest = await GetLatestBeforeAsync(
            "NASDAQ",
            scoreDate);

        if (latest?.CloseValue == null)
        {
            return 0;
        }

        var ma25 = await CalculateMovingAverageAsync(
            "NASDAQ",
            latest.TradeDate,
            25);

        if (ma25 == null)
        {
            return 0;
        }

        var ratio =
            latest.CloseValue.Value / ma25.Value;

        return ratio switch
        {
            >= 1.03m => 10,
            > 1.00m => 7,
            _ => 0
        };
    }

    private async Task<int> CalculateUsdJpyScoreAsync(
        DateTime scoreDate)
    {
        var items = await _db.MarketIndicesDaily
            .Where(x =>
                x.IndexCode == "USDJPY" &&
                x.TradeDate <= scoreDate &&
                x.CloseValue != null)
            .OrderByDescending(x => x.TradeDate)
            .Take(6)
            .ToListAsync();

        if (items.Count < 6)
        {
            return 0;
        }

        var latest = items[0].CloseValue!.Value;
        var fiveDaysAgo = items[5].CloseValue!.Value;

        var changeRate =
            latest / fiveDaysAgo - 1m;

        return changeRate switch
        {
            >= 0.02m => 10,
            > 0m => 7,
            _ => 0
        };
    }

    private async Task<int> CalculateVixScoreAsync(
        DateTime scoreDate)
    {
        var vix = await GetLatestBeforeAsync(
            "VIX",
            scoreDate);

        if (vix?.CloseValue == null)
        {
            return 0;
        }

        return vix.CloseValue.Value switch
        {
            < 15m => 20,
            < 20m => 15,
            < 25m => 10,
            < 30m => 5,
            _ => 0
        };
    }

    private async Task<int> CalculateTopixMomentumScoreAsync(
    DateTime scoreDate)
    {
        var items = await _db.MarketIndicesDaily
            .Where(x =>
                x.IndexCode == "TOPIX" &&
                x.TradeDate <= scoreDate &&
                x.CloseValue != null)
            .OrderByDescending(x => x.TradeDate)
            .Take(6)
            .ToListAsync();

        if (items.Count < 6)
        {
            return 0;
        }

        var latest = items[0].CloseValue!.Value;
        var fiveDaysAgo = items[5].CloseValue!.Value;

        var changeRate =
            latest / fiveDaysAgo - 1m;

        return changeRate switch
        {
            >= 0.02m => 10,
            >= 0m => 7,
            >= -0.02m => 3,
            _ => 0
        };
    }

    private async Task<int> CalculateDualMovingAverageScoreAsync(
        string indexCode,
        DateTime scoreDate,
        int shortMaxScore,
        int longMaxScore)
    {
        var latest = await GetLatestBeforeAsync(
            indexCode,
            scoreDate);

        if (latest?.CloseValue == null)
        {
            return 0;
        }

        var ma25 = await CalculateMovingAverageAsync(
            indexCode,
            latest.TradeDate,
            25);

        var ma75 = await CalculateMovingAverageAsync(
            indexCode,
            latest.TradeDate,
            75);

        if (ma25 == null || ma75 == null)
        {
            return 0;
        }

        var score = 0;

        score += CalculateMaRatioScore(
            latest.CloseValue.Value,
            ma25.Value,
            shortMaxScore);

        score += CalculateMaRatioScore(
            latest.CloseValue.Value,
            ma75.Value,
            longMaxScore);

        return score;
    }

    private static int CalculateMaRatioScore(
        decimal close,
        decimal movingAverage,
        int maxScore)
    {
        var ratio = close / movingAverage;

        if (ratio >= 1.03m)
        {
            return maxScore;
        }

        if (ratio > 1.00m)
        {
            return (int)Math.Round(
                maxScore * 0.7m);
        }

        return 0;
    }

    private async Task<MarketIndexDaily?> GetLatestBeforeAsync(
        string indexCode,
        DateTime scoreDate)
    {
        return await _db.MarketIndicesDaily
            .Where(x =>
                x.IndexCode == indexCode &&
                x.TradeDate <= scoreDate &&
                x.CloseValue != null)
            .OrderByDescending(x => x.TradeDate)
            .FirstOrDefaultAsync();
    }

    private async Task<decimal?> CalculateMovingAverageAsync(
        string indexCode,
        DateTime baseDate,
        int days)
    {
        var closes = await _db.MarketIndicesDaily
            .Where(x =>
                x.IndexCode == indexCode &&
                x.TradeDate <= baseDate &&
                x.CloseValue != null)
            .OrderByDescending(x => x.TradeDate)
            .Take(days)
            .Select(x => x.CloseValue!.Value)
            .ToListAsync();

        if (closes.Count < days)
        {
            return null;
        }

        return closes.Average();
    }
}