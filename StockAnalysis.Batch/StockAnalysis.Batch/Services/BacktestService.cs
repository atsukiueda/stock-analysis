using Microsoft.EntityFrameworkCore;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;

namespace StockAnalysis.Batch.Services;

public class BacktestService
{
    private readonly StockAnalysisDbContext _db;

    private readonly Dictionary<string, decimal?> _entryPriceCache = new();

    private readonly Dictionary<string, List<PriceDaily>> _futurePricesCache = new();

    public BacktestService(StockAnalysisDbContext db)
    {
        _db = db;
    }

    public async Task RunAsync(
        DateTime startDate,
        DateTime endDate,
        int topCount = 5)
    {

        var up5Service = new MlUp5PredictionService(_db);
        var up10Service = new MlUp10PredictionService(_db);
        var takeProfitService = new MlTakeProfitPredictionService(_db);
        var stopLossService = new MlStopLossPredictionService(_db);

        var scenarios = new List<BacktestScenario>
        {
            new()
            {
                Name = "TpExtreme",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m
            },
            new()
            {
                Name = "TpExtreme_TP10",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,
                MinExpectedTakeProfit = 10m
            },
            new()
            {
                Name = "TpExtreme_TP15",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,
                MinExpectedTakeProfit = 15m
            }
        };

        var resultsByScenario = scenarios.ToDictionary(
            x => x.Name,
            _ => new List<BacktestTradeResult>());

        var tradeDates = await _db.StockScoresDaily
            .Where(x => x.ScoreDate >= startDate)
            .Where(x => x.ScoreDate <= endDate)
            .Select(x => x.ScoreDate)
            .Distinct()
            .OrderBy(x => x)
            .ToListAsync();

        foreach (var tradeDate in tradeDates)
        {
            var dailyResultsByScenario = await RunSingleDateAsync(
                tradeDate,
                topCount,
                scenarios,
                up5Service,
                up10Service,
                takeProfitService,
                stopLossService);

            foreach (var scenario in scenarios)
            {
                resultsByScenario[scenario.Name]
                    .AddRange(dailyResultsByScenario[scenario.Name]);
            }
        }

        foreach (var scenario in scenarios)
        {
            PrintSummary(
                scenario,
                resultsByScenario[scenario.Name]);
        }
    }

    private async Task<Dictionary<string, List<BacktestTradeResult>>> RunSingleDateAsync(
        DateTime entryDate,
        int topCount,
        List<BacktestScenario> scenarios,
        MlUp5PredictionService up5Service,
        MlUp10PredictionService up10Service,
        MlTakeProfitPredictionService takeProfitService,
        MlStopLossPredictionService stopLossService)
    {
        var latestMarket = await _db.MarketScoresDaily
            .Where(x => x.ScoreDate <= entryDate)
            .OrderByDescending(x => x.ScoreDate)
            .FirstOrDefaultAsync();

        var sourceRows = await _db.StockScoresDaily
            .Where(x => x.ScoreDate == entryDate)
            .Join(
                _db.Companies,
                score => score.Code,
                company => company.Code,
                (score, company) => new
                {
                    Score = score,
                    Company = company
                })
            .Where(x => x.Company.IsActive)
            .ToListAsync();

        sourceRows = sourceRows
            .Where(x => !IsExcludedCompany(x.Company.CompanyName))
            .ToList();

        var rankingRows = new List<BacktestCandidate>();

        foreach (var row in sourceRows)
        {
            var bonus = GetMarketRegimeBonus(
                row.Company.MarketName,
                latestMarket?.MarketRegime ?? "");

            var totalScore = row.Score.TotalScore + bonus;

            var up5Probability = await up5Service.PredictAsync(row.Score);
            var up10Probability = await up10Service.PredictAsync(row.Score);
            var expectedTakeProfit = await takeProfitService.PredictAsync(row.Score);
            var expectedStopLoss = await stopLossService.PredictAsync(row.Score);

            if (up5Probability == null ||
                up10Probability == null ||
                expectedTakeProfit == null ||
                expectedStopLoss == null)
            {
                continue;
            }

            rankingRows.Add(new BacktestCandidate
            {
                Score = row.Score,
                Company = row.Company,
                TotalScore = totalScore,
                Up5Probability = up5Probability.Value,
                Up10Probability = up10Probability.Value,
                ExpectedTakeProfit = expectedTakeProfit.Value,
                ExpectedStopLoss = expectedStopLoss.Value
            });
        }

        var resultsByScenario = scenarios.ToDictionary(
            x => x.Name,
            _ => new List<BacktestTradeResult>());

        foreach (var scenario in scenarios)
        {
            var candidates = rankingRows
                .Where(x =>
                    scenario.MinExpectedTakeProfit == null ||
                    x.ExpectedTakeProfit >= scenario.MinExpectedTakeProfit.Value)
                .Select(x =>
                {
                    x.AiRankingScore =
                        (x.Up5Probability * scenario.Up5Weight)
                        + (x.Up10Probability * scenario.Up10Weight)
                        + (x.ExpectedTakeProfit * scenario.TakeProfitWeight)
                        - (Math.Abs(x.ExpectedStopLoss) * scenario.StopLossWeight)
                        + (x.TotalScore * scenario.TotalScoreWeight);

                    return x;
                })
                .OrderByDescending(x => x.AiRankingScore)
                .Take(topCount)
                .ToList();

            foreach (var candidate in candidates)
            {
                var entryPrice = await GetEntryPriceWithCacheAsync(
                    candidate.Score.Code,
                    entryDate);

                if (entryPrice == null || entryPrice <= 0)
                {
                    continue;
                }

                var expectedTakeProfit = candidate.ExpectedTakeProfit;
                var expectedStopLoss = candidate.ExpectedStopLoss;

                var clippedTakeProfit = Math.Clamp(
                    expectedTakeProfit,
                    3m,
                    20m);

                var clippedStopLoss = Math.Clamp(
                    expectedStopLoss,
                    -15m,
                    -3m);

                var takeProfitPrice = Math.Round(
                    entryPrice.Value * (1 + clippedTakeProfit / 100m),
                    2);

                var stopLossPrice = Math.Round(
                    entryPrice.Value * (1 + clippedStopLoss / 100m),
                    2);

                var futurePrices = await GetFuturePricesWithCacheAsync(
                    candidate.Score.Code,
                    entryDate);

                if (futurePrices.Count < 10)
                {
                    continue;
                }

                var exitDate = futurePrices[^1].TradeDate;
                var exitPrice = futurePrices[^1].ClosePrice ?? entryPrice.Value;
                var exitReason = "TimeExit";

                foreach (var price in futurePrices)
                {
                    if (price.LowPrice != null &&
                        price.LowPrice <= stopLossPrice)
                    {
                        exitDate = price.TradeDate;
                        exitPrice = stopLossPrice;
                        exitReason = "StopLoss";
                        break;
                    }

                    if (price.HighPrice != null &&
                        price.HighPrice >= takeProfitPrice)
                    {
                        exitDate = price.TradeDate;
                        exitPrice = takeProfitPrice;
                        exitReason = "TakeProfit";
                        break;
                    }
                }

                var returnRate =
                    Math.Round(
                        (exitPrice - entryPrice.Value) / entryPrice.Value * 100m,
                        4);

                resultsByScenario[scenario.Name].Add(new BacktestTradeResult
                {
                    Code = candidate.Score.Code,
                    CompanyName = candidate.Company.CompanyName,
                    EntryDate = entryDate,
                    EntryPrice = entryPrice.Value,
                    TakeProfitPrice = takeProfitPrice,
                    StopLossPrice = stopLossPrice,
                    ExitDate = exitDate,
                    ExitPrice = exitPrice,
                    ReturnRate = returnRate,
                    ExitReason = exitReason,
                    HoldingDays = futurePrices.Count(x => x.TradeDate <= exitDate),
                    Up5Probability = candidate.Up5Probability,
                    Up10Probability = candidate.Up10Probability,
                    ExpectedTakeProfit = expectedTakeProfit,
                    ExpectedStopLoss = expectedStopLoss,
                    AiRankingScore = candidate.AiRankingScore
                });
            }
        }

        return resultsByScenario;
    }

    private async Task<decimal?> GetEntryPriceWithCacheAsync(
    string code,
    DateTime entryDate)
    {
        var key = $"{code}_{entryDate:yyyyMMdd}";

        if (_entryPriceCache.TryGetValue(key, out var cached))
        {
            return cached;
        }

        var entryPrice = await _db.PricesDaily
            .Where(x => x.Code == code)
            .Where(x => x.TradeDate == entryDate)
            .Select(x => x.ClosePrice)
            .FirstOrDefaultAsync();

        _entryPriceCache[key] = entryPrice;

        return entryPrice;
    }

    private async Task<List<PriceDaily>> GetFuturePricesWithCacheAsync(
        string code,
        DateTime entryDate)
    {
        var key = $"{code}_{entryDate:yyyyMMdd}";

        if (_futurePricesCache.TryGetValue(key, out var cached))
        {
            return cached;
        }

        var futurePrices = await _db.PricesDaily
            .Where(x => x.Code == code)
            .Where(x => x.TradeDate > entryDate)
            .OrderBy(x => x.TradeDate)
            .Take(10)
            .ToListAsync();

        _futurePricesCache[key] = futurePrices;

        return futurePrices;
    }

    private void PrintSummary(
        BacktestScenario scenario,
        List<BacktestTradeResult> results)
    {
        Console.WriteLine();
        Console.WriteLine("=== バックテスト結果 ===");

        Console.WriteLine($"Scenario: {scenario.Name}");

        Console.WriteLine(
            $"Weights Up5:{scenario.Up5Weight} " +
            $"Up10:{scenario.Up10Weight} " +
            $"TP:{scenario.TakeProfitWeight} " +
            $"SL:{scenario.StopLossWeight} " +
            $"Total:{scenario.TotalScoreWeight} " +
            $"MinTP:{scenario.MinExpectedTakeProfit?.ToString("F0") ?? "None"}");

        if (results.Count == 0)
        {
            Console.WriteLine("取引結果がありません。");
            return;
        }

        var winCount = results.Count(x => x.ReturnRate > 0);
        var loseCount = results.Count(x => x.ReturnRate <= 0);

        var avgReturn = results.Average(x => x.ReturnRate);
        var totalReturn = results.Sum(x => x.ReturnRate);

        var takeProfitCount = results.Count(x => x.ExitReason == "TakeProfit");
        var stopLossCount = results.Count(x => x.ExitReason == "StopLoss");
        var timeExitCount = results.Count(x => x.ExitReason == "TimeExit");

        var avgHoldingDays = results.Average(x => x.HoldingDays);

        var grossProfit = results
            .Where(x => x.ReturnRate > 0)
            .Sum(x => x.ReturnRate);

        var grossLoss = results
            .Where(x => x.ReturnRate < 0)
            .Sum(x => Math.Abs(x.ReturnRate));

        var profitFactor = grossLoss > 0
            ? grossProfit / grossLoss
            : 0m;

        var maxConsecutiveLosses = 0;
        var currentConsecutiveLosses = 0;

        foreach (var result in results.OrderBy(x => x.EntryDate))
        {
            if (result.ReturnRate <= 0)
            {
                currentConsecutiveLosses++;

                if (currentConsecutiveLosses > maxConsecutiveLosses)
                {
                    maxConsecutiveLosses = currentConsecutiveLosses;
                }
            }
            else
            {
                currentConsecutiveLosses = 0;
            }
        }

        var avgExpectedTakeProfit = results.Average(x => x.ExpectedTakeProfit);
        var maxExpectedTakeProfit = results.Max(x => x.ExpectedTakeProfit);
        var minExpectedTakeProfit = results.Min(x => x.ExpectedTakeProfit);

        var avgExpectedStopLoss = results.Average(x => x.ExpectedStopLoss);
        var maxExpectedStopLoss = results.Max(x => x.ExpectedStopLoss);
        var minExpectedStopLoss = results.Min(x => x.ExpectedStopLoss);

        var takeProfitNegativeCount = results.Count(x => x.ExpectedTakeProfit < 0);
        var stopLossPositiveCount = results.Count(x => x.ExpectedStopLoss > 0);

        Console.WriteLine($"TradeCount : {results.Count}");
        Console.WriteLine($"WinCount   : {winCount}");
        Console.WriteLine($"LoseCount  : {loseCount}");
        Console.WriteLine($"WinRate    : {(decimal)winCount / results.Count:P2}");
        Console.WriteLine($"AvgReturn  : {avgReturn:F2}%");
        Console.WriteLine($"TotalReturn: {totalReturn:F2}%");
        Console.WriteLine($"TP Count   : {takeProfitCount}");
        Console.WriteLine($"SL Count   : {stopLossCount}");
        Console.WriteLine($"TimeExit   : {timeExitCount}");
        Console.WriteLine($"AvgHoldingDays : {avgHoldingDays:F2}");
        Console.WriteLine($"ProfitFactor   : {profitFactor:F2}");
        Console.WriteLine($"MaxLoseStreak  : {maxConsecutiveLosses}");
        Console.WriteLine($"AvgExpectedTP : {avgExpectedTakeProfit:F2}%");
        Console.WriteLine($"MaxExpectedTP : {maxExpectedTakeProfit:F2}%");
        Console.WriteLine($"MinExpectedTP : {minExpectedTakeProfit:F2}%");
        Console.WriteLine($"TP Negative   : {takeProfitNegativeCount}");
        Console.WriteLine($"AvgExpectedSL : {avgExpectedStopLoss:F2}%");
        Console.WriteLine($"MaxExpectedSL : {maxExpectedStopLoss:F2}%");
        Console.WriteLine($"MinExpectedSL : {minExpectedStopLoss:F2}%");
        Console.WriteLine($"SL Positive   : {stopLossPositiveCount}");

    //    Console.WriteLine();
    //    Console.WriteLine("=== 取引明細 TOP 30 ===");

    //    foreach (var item in results
    //                 .OrderByDescending(x => x.EntryDate)
    //                 .ThenByDescending(x => x.AiRankingScore)
    //                 .Take(30))
    //    {
    //        Console.WriteLine(
    //            $"{item.EntryDate:yyyy-MM-dd} " +
    //            $"{item.Code} {item.CompanyName} " +
    //            $"Entry:{item.EntryPrice:F2} " +
    //            $"Up5:{item.Up5Probability:F2}% " +
    //            $"Up10:{item.Up10Probability:F2}% " +
    //            $"TP:{item.TakeProfitPrice:F2} " +
    //            $"SL:{item.StopLossPrice:F2} " +
    //            $"TPExp:{item.ExpectedTakeProfit:F2}% " +
    //            $"SLExp:{item.ExpectedStopLoss:F2}% " +
    //            $"Exit:{item.ExitPrice:F2} " +
    //            $"Return:{item.ReturnRate:F2}% " +
    //            $"Reason:{item.ExitReason}");
    //    }
    }

    private static bool IsExcludedCompany(string companyName)
    {
        var keywords = new[]
        {
            "ＥＴＦ",
            "ETF",
            "投信",
            "上場投信",
            "インデックスファンド",
            "ＮＥＸＴ　ＦＵＮＤＳ",
            "MAXIS",
            "ｉＦｒｅｅＥＴＦ",
            "iFreeETF",
            "グローバルＸ",
            "REIT",
            "リート",
            "ETN",
            "ＳＰＤＲ",
            "SPDR",
            "ゴールド・シェア",
            "Gold Shares"
        };

        return keywords.Any(companyName.Contains);
    }

    private static int GetMarketRegimeBonus(
        string? marketName,
        string marketRegime)
    {
        return marketRegime switch
        {
            "StrongRiskOn" => marketName switch
            {
                "グロース" => 5,
                "スタンダード" => 2,
                "プライム" => 0,
                _ => 0
            },
            "RiskOff" => marketName switch
            {
                "プライム" => 5,
                "スタンダード" => 2,
                "グロース" => 0,
                _ => 0
            },
            _ => 0
        };
    }

    private class BacktestCandidate
    {
        public StockScoreDaily Score { get; set; } = null!;

        public Company Company { get; set; } = null!;

        public int TotalScore { get; set; }

        public decimal Up5Probability { get; set; }

        public decimal Up10Probability { get; set; }

        public decimal ExpectedTakeProfit { get; set; }

        public decimal ExpectedStopLoss { get; set; }

        public decimal AiRankingScore { get; set; }
    }

    private class BacktestScenario
    {
        public string Name { get; set; } = "";

        public decimal Up5Weight { get; set; }

        public decimal Up10Weight { get; set; }

        public decimal TakeProfitWeight { get; set; }

        public decimal StopLossWeight { get; set; }

        public decimal TotalScoreWeight { get; set; }

        public decimal? MinExpectedTakeProfit { get; set; }
    }
}