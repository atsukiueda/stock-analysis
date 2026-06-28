using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;
using StockAnalysis.Batch.Services.Ml.Prediction;

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
        var totalSw = Stopwatch.StartNew();
        var stepSw = Stopwatch.StartNew();

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

        query = query.Where(x =>
            !x.Company.CompanyName.Contains("ＥＴＦ") &&
            !x.Company.CompanyName.Contains("ETF") &&
            !x.Company.CompanyName.Contains("投信") &&
            !x.Company.CompanyName.Contains("ＮＥＸＴ　ＦＵＮＤＳ") &&
            !x.Company.CompanyName.Contains("インデックスファンド"));

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

        var up5Service = new MlUp5PredictionService(_db);

        var up5ProbabilityMap =
            await up5Service.PredictLatestProbabilitiesAsync();

        Console.WriteLine(
            $"Up5 : {stepSw.Elapsed.TotalSeconds:F2} sec");

        stepSw.Restart();

        var up10Service = new MlUp10PredictionService(_db);

        var up10ProbabilityMap =
            await up10Service.PredictLatestUp10ProbabilitiesAsync();

        Console.WriteLine(
            $"Up10 : {stepSw.Elapsed.TotalSeconds:F2} sec");

        stepSw.Restart();

        var takeProfitService = new MlTakeProfitPredictionService(_db);

        var takeProfitMap =
            await takeProfitService.PredictLatestTakeProfitAsync();

        Console.WriteLine(
            $"TakeProfit : {stepSw.Elapsed.TotalSeconds:F2} sec");

        stepSw.Restart();

        var stopLossService = new MlStopLossPredictionService(_db);

        var stopLossMap =
            await stopLossService.PredictLatestStopLossAsync();

        Console.WriteLine(
            $"StopLoss : {stepSw.Elapsed.TotalSeconds:F2} sec");

        stepSw.Restart();

        var results = sourceItems
            .Select(x =>
            {
                var bonus = GetMarketRegimeBonus(
                    x.Company.MarketName,
                    latestMarket.MarketRegime ?? "");

                var up5Probability = up5ProbabilityMap.TryGetValue(
                    x.Score.Code,
                    out var up5)
                    ? up5
                    : 0m;

                var up10Probability = up10ProbabilityMap.TryGetValue(
                    x.Score.Code,
                    out var up10)
                    ? up10
                    : 0m;

                var expectedTakeProfit = takeProfitMap.TryGetValue(
                    x.Score.Code,
                    out var tp)
                    ? tp
                    : 0m;

                var expectedStopLoss = stopLossMap.TryGetValue(
                    x.Score.Code,
                    out var sl)
                    ? sl
                    : 0m;

                var latestPrice = _db.PricesDaily
                    .Where(p => p.Code == x.Score.Code)
                    .Where(p => p.TradeDate == x.Score.ScoreDate)
                    .Select(p => p.ClosePrice)
                    .FirstOrDefault();

                var entryPrice = latestPrice ?? 0m;

                var clippedTakeProfit = Math.Clamp(
                    expectedTakeProfit,
                    3m,
                    20m);

                var clippedStopLoss = Math.Clamp(
                    expectedStopLoss,
                    -15m,
                    -3m);

                return new ScreeningResult
                {
                    Code = x.Score.Code,
                    CompanyName = x.Company.CompanyName,
                    Up5Probability = up5Probability,

                    Up10Probability = up10Probability,

                    AiRankingScore =
                        (up5Probability * 0.1m)
                        + (up10Probability * 0.1m)
                        + (expectedTakeProfit * 0.8m)
                        - (Math.Abs(expectedStopLoss) * 0.1m)
                        + ((x.Score.TotalScore + bonus) * 0.5m),

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

                    TotalScore = x.Score.TotalScore + bonus,

                    ExpectedTakeProfit = expectedTakeProfit,

                    ExpectedStopLoss = expectedStopLoss,

                    EntryPrice = entryPrice,

                    TakeProfitPrice = entryPrice > 0
                        ? Math.Round(entryPrice * (1 + clippedTakeProfit / 100m), 2)
                        : 0m,

                                        StopLossPrice = entryPrice > 0
                        ? Math.Round(entryPrice * (1 + clippedStopLoss / 100m), 2)
                        : 0m,
                };
            })
            .Where(x => x.ExpectedTakeProfit >= 15m)
            .OrderByDescending(x => x.AiRankingScore)
            .ThenByDescending(x => x.Up5Probability)
            .ThenByDescending(x => x.TotalScore)
            .Take(condition.TopCount)
            .ToList();

        totalSw.Stop();

        Console.WriteLine(
            $"Screening Total : {totalSw.Elapsed.TotalSeconds:F2} sec");

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

        var targetCodes = sourceItems
            .Select(x => x.Score.Code)
            .Distinct()
            .ToList();

        var priceRows = await _db.PricesDaily
            .Where(x => targetCodes.Contains(x.Code))
            .Where(x => x.TradeDate <= latestDate)
            .Where(x => x.ClosePrice != null)
            .Where(x => x.ClosePrice > 0)
            .Select(x => new
            {
                x.Code,
                x.TradeDate,
                x.ClosePrice
            })
            .ToListAsync();

        var latestPriceMap = priceRows
            .GroupBy(x => x.Code)
            .Select(g => g
                .OrderByDescending(x => x.TradeDate)
                .First())
            .ToDictionary(x => x.Code);

        foreach (var item in sourceItems)
        {
            if (!latestPriceMap.TryGetValue(item.Score.Code, out var latestPrice))
            {
                continue;
            }

            var entryPrice = latestPrice.ClosePrice!.Value;

            var takeProfitPrice = Math.Round(entryPrice * 1.05m, 2);
            var stopLossPrice = Math.Round(entryPrice * 0.97m, 2);

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