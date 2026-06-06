using Microsoft.EntityFrameworkCore;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;

namespace StockAnalysis.Batch.Services;

public class MlTrainingDataService
{
    private readonly StockAnalysisDbContext _db;

    public MlTrainingDataService(StockAnalysisDbContext db)
    {
        _db = db;
    }

    public async Task GenerateAsync()
    {
        var scores = await _db.StockScoresDaily
            .OrderBy(x => x.Code)
            .ThenBy(x => x.ScoreDate)
            .ToListAsync();

        Console.WriteLine($"学習データ対象スコア件数: {scores.Count}");

        foreach (var score in scores)
        {
            var basePrice = await _db.PricesDaily
                .Where(x => x.Code == score.Code)
                .Where(x => x.TradeDate == score.ScoreDate)
                .Where(x => x.ClosePrice != null)
                .FirstOrDefaultAsync();

            if (basePrice?.ClosePrice == null ||
                basePrice.ClosePrice <= 0)
            {
                continue;
            }

            var futurePrices = await _db.PricesDaily
                .Where(x => x.Code == score.Code)
                .Where(x => x.TradeDate > score.ScoreDate)
                .Where(x => x.ClosePrice != null)
                .OrderBy(x => x.TradeDate)
                .Take(20)
                .ToListAsync();

            var future5 = futurePrices.Count >= 5
                ? futurePrices[4]
                : null;

            var future10 = futurePrices.Count >= 10
                ? futurePrices[9]
                : null;

            var future20 = futurePrices.Count >= 20
                ? futurePrices[19]
                : null;

            var futureReturn5 = CalculateReturn(
                basePrice.ClosePrice,
                future5?.ClosePrice);

            var futureReturn10 = CalculateReturn(
                basePrice.ClosePrice,
                future10?.ClosePrice);

            var futureReturn20 = CalculateReturn(
                basePrice.ClosePrice,
                future20?.ClosePrice);

            var existing = await _db.MlTrainingData
                .FirstOrDefaultAsync(x =>
                    x.Code == score.Code &&
                    x.TradeDate == score.ScoreDate);

            if (existing == null)
            {
                _db.MlTrainingData.Add(new MlTrainingData
                {
                    Code = score.Code,
                    TradeDate = score.ScoreDate,

                    FinancialScore = score.FinancialScore,
                    GrowthScore = score.GrowthScore,
                    DividendScore = score.DividendScore,
                    RoeScore = score.RoeScore,
                    PerScore = score.PerScore,
                    PbrScore = score.PbrScore,
                    TechnicalScore = score.TechnicalScore,
                    SwingScore = score.SwingScore,
                    MarketScore = score.MarketScore,

                    FutureReturn5 = futureReturn5,
                    FutureReturn10 = futureReturn10,
                    FutureReturn20 = futureReturn20,

                    Up5 = futureReturn5 >= 3m,
                    Up10 = futureReturn10 >= 5m,
                    Up20 = futureReturn20 >= 8m,

                    CreatedAt = DateTime.Now
                });
            }
        }

        await _db.SaveChangesAsync();

        Console.WriteLine("ML学習データ生成完了");
    }

    private static decimal? CalculateReturn(
        decimal? basePrice,
        decimal? futurePrice)
    {
        if (basePrice == null ||
            futurePrice == null ||
            basePrice <= 0)
        {
            return null;
        }

        return
            (futurePrice.Value - basePrice.Value)
            / basePrice.Value
            * 100m;
    }
}