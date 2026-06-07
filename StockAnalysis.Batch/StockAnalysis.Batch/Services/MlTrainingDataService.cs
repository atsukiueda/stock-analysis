using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;
using static System.Formats.Asn1.AsnWriter;

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
            var company = await _db.Companies
                .FirstOrDefaultAsync(x => x.Code == score.Code);

            if (company == null)
            {
                continue;
            }

            if (company.CompanyName.Contains("ＥＴＦ") ||
                company.CompanyName.Contains("ETF") ||
                company.CompanyName.Contains("投信"))
            {
                continue;
            }

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

            decimal? futureMaxReturn10 = null;
            decimal? futureMinReturn10 = null;

            var future10Prices = futurePrices
                .Take(10)
                .ToList();

            if (future10Prices.Count == 10)
            {
                var maxHigh10 = future10Prices
                    .Where(x => x.HighPrice != null)
                    .Max(x => x.HighPrice);

                var minLow10 = future10Prices
                    .Where(x => x.LowPrice != null)
                    .Min(x => x.LowPrice);

                if (maxHigh10 != null)
                {
                    futureMaxReturn10 =
                        Math.Round(
                            (maxHigh10.Value - basePrice.ClosePrice.Value)
                            / basePrice.ClosePrice.Value
                            * 100m,
                            4);
                }

                if (futureMaxReturn10 != null)
                {
                    futureMaxReturn10 =
                        Math.Min(futureMaxReturn10.Value, 50m);
                }

                if (minLow10 != null)
                {
                    futureMinReturn10 =
                        Math.Round(
                            (minLow10.Value - basePrice.ClosePrice.Value)
                            / basePrice.ClosePrice.Value
                            * 100m,
                            4);
                }

                if (futureMinReturn10 != null)
                {
                    futureMinReturn10 =
                        Math.Max(futureMinReturn10.Value, -30m);
                }
            }

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
                    FutureMaxReturn10 = futureMaxReturn10,
                    FutureMinReturn10 = futureMinReturn10,

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