using Microsoft.EntityFrameworkCore;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;

namespace StockAnalysis.Batch.Services;

public sealed class BacktestExecutionSettings
{
    public int MaxEntriesPerDay { get; set; } = 3;
    public decimal EntrySlippageRate { get; set; } = 0.002m;
    public decimal ExitSlippageRate { get; set; } = 0.002m;
    public decimal FeeRate { get; set; } = 0.0005m;
    public decimal TaxRate { get; set; } = 0.20315m;

    public decimal InitialCapital { get; set; } = 1_000_000m;

    public decimal PositionSize { get; set; } = 200_000m;

    // 最大保有銘柄数
    public int MaxOpenPositions { get; set; } = 5;

    // 100株単位で保有する
    public int LotSize { get; set; } = 100;
}

public class BacktestService
{
    private readonly StockAnalysisDbContext _db;

    private readonly Dictionary<string, decimal?> _entryPriceCache = new();

    private readonly Dictionary<string, List<PriceDaily>> _futurePricesCache = new();

    private readonly Dictionary<string, List<PriceDaily>> _priceHistoryCache = new();

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
            },
            new()
            {
                Name = "TpExtreme_TPUnder15",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,
                MaxExpectedTakeProfit = 15m
            },
            new()
            {
                Name = "TpExtreme_TP10To15",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,
                MinExpectedTakeProfit = 10m,
                MaxExpectedTakeProfit = 15m
            },
            new()
            {
                Name = "ExpectedValueOnly",
                Up5Weight = 0m,
                Up10Weight = 0m,
                TakeProfitWeight = 0m,
                StopLossWeight = 0m,
                TotalScoreWeight = 0m
            },
            new()
            {
                Name = "ExpectedValue_TPUnder15",
                Up5Weight = 0m,
                Up10Weight = 0m,
                TakeProfitWeight = 0m,
                StopLossWeight = 0m,
                TotalScoreWeight = 0m,
                MaxExpectedTakeProfit = 15m
            },
            new()
            {
                Name = "TpExtreme_M25_15",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,
                MaxMomentum25 = 15m
            },
            new()
            {
                Name = "TpExtreme_M25_10",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,
                MaxMomentum25 = 10m
            },
            new()
            {
                Name = "TpExtreme_M25_5",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,
                MaxMomentum25 = 5m
            },
            new()
            {
                Name = "TpExtreme_M25_0",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,
                MaxMomentum25 = 0m
            },
            new()
            {
                Name = "TpExtreme_M25_10_TP15",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,

                MaxExpectedTakeProfit = 15m,
                MaxMomentum25 = 10m
            },
            new()
            {
                Name = "TpExtreme_M25_10_TP20",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,
            
                MaxExpectedTakeProfit = 20m,
                MaxMomentum25 = 10m
            },
            new()
            {
                Name = "TpExtreme_M25_10_TPUnder15",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,

                // 現王者 TpExtreme_M25_10 の条件。
                // Momentum25が10%を超える銘柄は過熱・反落リスクが高いため除外する。
                MaxMomentum25 = 10m,

                // TpExtreme_TPUnder15 の安定性を取り込む。
                // TP予測が高すぎる銘柄は過熱銘柄を拾いやすいため、15%未満に制限する。
                MaxExpectedTakeProfit = 15m
            },
            new()
            {
                Name = "TpExtreme_M25_0_10",
            
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,
            
                MinMomentum25 = 0m,
                MaxMomentum25 = 10m
            },
            new()
            {
                Name = "TpExtreme_M25_ExcludeMinus10To0",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,
            
                // 元の王者 TpExtreme_M25_10 と同じく、
                // Momentum25が10%を超える過熱銘柄は除外する。
                MaxMomentum25 = 10m,
            
                // ただし M25 < -10 は利益源だったため残す。
                // 弱かった -10 <= M25 < 0 の帯だけを除外する。
                ExcludeMomentum25Min = -10m,
                ExcludeMomentum25Max = 0m
            },
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

        var executionSettings = new BacktestExecutionSettings();

        var openPositionsByScenario = scenarios.ToDictionary(
            x => x.Name,
            _ => new List<OpenBacktestPosition>());

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
                var openPositions = openPositionsByScenario[scenario.Name];

                // すでに決済済みのポジションを除外
                // ExitDate == tradeDate のものは保守的にまだ拘束中とみなす
                openPositions.RemoveAll(x => x.ExitDate < tradeDate);

                var availableSlots =
                    executionSettings.MaxOpenPositions - openPositions.Count;

                if (availableSlots <= 0)
                {
                    continue;
                }

                var holdingCodes = openPositions
                    .Select(x => x.Code)
                    .ToHashSet();

                var executableTrades = dailyResultsByScenario[scenario.Name]
                    .Where(x => !holdingCodes.Contains(x.Code))
                    .OrderByDescending(x => x.AiRankingScore)
                    .Take(availableSlots)
                    .ToList();

                resultsByScenario[scenario.Name]
                    .AddRange(executableTrades);

                foreach (var trade in executableTrades)
                {
                    openPositions.Add(new OpenBacktestPosition
                    {
                        Code = trade.Code,
                        EntryDate = trade.EntryDate,
                        ExitDate = trade.ExitDate ?? trade.EntryDate
                    });
                }
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
        var executionSettings = new BacktestExecutionSettings();

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

            var momentum25 = await CalculateMomentum25Async(
                row.Score.Code,
                row.Score.ScoreDate);

            if (momentum25 == null)
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
                ExpectedStopLoss = expectedStopLoss.Value,
                Momentum25 = momentum25.Value
            });
        }

        var resultsByScenario = scenarios.ToDictionary(
            x => x.Name,
            _ => new List<BacktestTradeResult>());

        foreach (var scenario in scenarios)
        {
            var candidates = rankingRows
        .Where(x =>
            // ExpectedTakeProfit の下限フィルタ。
            // TP10以上など、予測利確幅が小さすぎる銘柄を除外したい場合に使う。
            scenario.MinExpectedTakeProfit == null ||
            x.ExpectedTakeProfit >= scenario.MinExpectedTakeProfit.Value)

        .Where(x =>
            // ExpectedTakeProfit の上限フィルタ。
            // TPが高すぎる銘柄は過熱銘柄を拾う可能性があるため、
            // TP15未満・TP20未満などの検証に使う。
            scenario.MaxExpectedTakeProfit == null ||
            x.ExpectedTakeProfit < scenario.MaxExpectedTakeProfit.Value)

        .Where(x =>
            // Momentum25 の下限フィルタ。
            // 今回追加した TpExtreme_M25_0_10 では、
            // Momentum25 が 0% 未満の銘柄を除外する。
            // これがないと MinMomentum25 を設定しても結果が変わらない。
            scenario.MinMomentum25 == null ||
            x.Momentum25 >= scenario.MinMomentum25.Value)

        .Where(x =>
            // Momentum25 の上限フィルタ。
            // Momentum25 が高すぎる銘柄は過熱・反落リスクが高いため、
            // M25_10 などの検証で使用する。
            scenario.MaxMomentum25 == null ||
            x.Momentum25 <= scenario.MaxMomentum25.Value)

        .Where(x =>
            // Momentum25 の除外レンジフィルタ。
            // 例：ExcludeMomentum25Min = -10, ExcludeMomentum25Max = 0 の場合、
            // -10 <= Momentum25 < 0 の銘柄を候補から除外する。
            //
            // TpExtreme_M25_ExcludeMinus10To0 では、
            // M25 < -10 は強かったため残し、
            // -10〜0 の弱い帯だけを除外する目的で使う。
            scenario.ExcludeMomentum25Min == null ||
            scenario.ExcludeMomentum25Max == null ||
            x.Momentum25 < scenario.ExcludeMomentum25Min.Value ||
            x.Momentum25 >= scenario.ExcludeMomentum25Max.Value)
        .Select(x =>
        {
            var up10Rate = x.Up10Probability / 100m;

            var expectedValue =
                (up10Rate * x.ExpectedTakeProfit)
                - ((1m - up10Rate) * Math.Abs(x.ExpectedStopLoss));

            x.ExpectedValue = expectedValue;

            if (scenario.Name.StartsWith("ExpectedValue"))
            {
                x.AiRankingScore = expectedValue;
            }
            else
            {
                // ExpectedValue単体は怪しいが、ランキング式に混ぜた状態では
                // TpExtreme_M25_10 が最良だったため、現時点ではこちらを基準にする。
                x.AiRankingScore =
                    expectedValue
                    + (x.Up5Probability * 0.05m)
                    + (x.TotalScore * scenario.TotalScoreWeight);
            }

            return x;
        })
                .OrderByDescending(x => x.AiRankingScore)
                .Take(Math.Min(topCount, executionSettings.MaxEntriesPerDay))
                .ToList();

            foreach (var candidate in candidates)
            {
                var entryPriceRow = await GetNextBusinessDayEntryPriceWithCacheAsync(
                    candidate.Score.Code,
                    entryDate);

                if (entryPriceRow == null ||
                    entryPriceRow.OpenPrice == null ||
                    entryPriceRow.OpenPrice <= 0)
                {
                    continue;
                }

                var actualEntryDate = entryPriceRow.TradeDate;
                var entryPrice = entryPriceRow.OpenPrice.Value;

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
                    entryPrice * (1 + clippedTakeProfit / 100m),
                    2);

                var stopLossPrice = Math.Round(
                    entryPrice * (1 + clippedStopLoss / 100m),
                    2);

                var futurePrices = await GetFuturePricesWithCacheAsync(
                    candidate.Score.Code,
                    actualEntryDate);

                if (futurePrices.Count < 10)
                {
                    continue;
                }

                var exitDate = futurePrices[^1].TradeDate;
                var exitPrice = futurePrices[^1].ClosePrice ?? entryPrice;
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

                var shares = CalculateShares(
                    entryPrice,
                    executionSettings.PositionSize,
                    executionSettings.LotSize);

                if (shares <= 0)
                {
                    continue;
                }

                var profitAmount = CalculateProfitAmount(
                    entryPrice,
                    exitPrice,
                    shares,
                    executionSettings);

                var investedAmount =
                    entryPrice * shares;

                var returnRate =
                    investedAmount > 0
                        ? Math.Round(profitAmount.NetProfit / investedAmount * 100m, 4)
                        : 0m;

                resultsByScenario[scenario.Name].Add(new BacktestTradeResult
                {
                    Code = candidate.Score.Code,
                    CompanyName = candidate.Company.CompanyName,
                    EntryDate = actualEntryDate,
                    EntryPrice = entryPrice,
                    TakeProfitPrice = takeProfitPrice,
                    StopLossPrice = stopLossPrice,
                    ExitDate = exitDate,
                    ExitPrice = exitPrice,
                    ReturnRate = returnRate,
                    ExitReason = exitReason,
                    HoldingDays = futurePrices.Count(x => x.TradeDate <= exitDate),
                    MarketRegime = latestMarket?.MarketRegime ?? "Unknown",
                    Shares = shares,
                    GrossProfitAmount = profitAmount.GrossProfit,
                    NetProfitAmount = profitAmount.NetProfit,
                    Up5Probability = candidate.Up5Probability,
                    Up10Probability = candidate.Up10Probability,
                    ExpectedTakeProfit = expectedTakeProfit,
                    ExpectedStopLoss = expectedStopLoss,
                    ExpectedValue = candidate.ExpectedValue,
                    AiRankingScore = candidate.AiRankingScore,
                    Momentum25 = candidate.Momentum25,
                });
            }
        }

        return resultsByScenario;
    }

    private async Task<decimal?> CalculateMomentum25Async(
    string code,
    DateTime tradeDate)
    {
        var prices = await GetPriceHistoryWithCacheAsync(code);

        var targetPrices = prices
            .Where(x => x.TradeDate <= tradeDate)
            .Where(x => x.ClosePrice != null)
            .TakeLast(26)
            .ToList();

        if (targetPrices.Count < 26)
        {
            return null;
        }

        var latest = targetPrices[^1].ClosePrice;
        var close25Ago = targetPrices[0].ClosePrice;

        if (latest == null ||
            close25Ago == null ||
            close25Ago <= 0)
        {
            return null;
        }

        return Math.Round(
            (latest.Value - close25Ago.Value) / close25Ago.Value * 100m,
            4);
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

    private async Task<List<PriceDaily>> GetPriceHistoryWithCacheAsync(string code)
    {
        if (_priceHistoryCache.TryGetValue(code, out var cached))
        {
            return cached;
        }

        var prices = await _db.PricesDaily
            .Where(x => x.Code == code)
            .Where(x => x.ClosePrice != null)
            .OrderBy(x => x.TradeDate)
            .ToListAsync();

        _priceHistoryCache[code] = prices;

        return prices;
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
            $"MinTP:{scenario.MinExpectedTakeProfit?.ToString("F0") ?? "None"} " +
            $"MaxTP:{scenario.MaxExpectedTakeProfit?.ToString("F0") ?? "None"}");

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

        var executionSettings = new BacktestExecutionSettings();

        var capital = executionSettings.InitialCapital;
        var equityPeak = capital;
        var maxDrawdown = 0m;

        foreach (var result in results.OrderBy(x => x.EntryDate))
        {
            capital += result.NetProfitAmount;

            if (capital > equityPeak)
            {
                equityPeak = capital;
            }

            var drawdown = equityPeak > 0
                ? (equityPeak - capital) / equityPeak * 100m
                : 0m;

            if (drawdown > maxDrawdown)
            {
                maxDrawdown = drawdown;
            }
        }

        var netProfit = capital - executionSettings.InitialCapital;

        var capitalReturn =
            netProfit / executionSettings.InitialCapital * 100m;

        Console.WriteLine($"TradeCount : {results.Count}");
        Console.WriteLine($"WinCount   : {winCount}");
        Console.WriteLine($"LoseCount  : {loseCount}");
        Console.WriteLine($"WinRate    : {(decimal)winCount / results.Count:P2}");
        Console.WriteLine($"AvgReturn  : {avgReturn:F2}%");
        Console.WriteLine($"TotalReturn: {totalReturn:F2}%");
        Console.WriteLine($"InitialCapital : {executionSettings.InitialCapital:N0}");
        Console.WriteLine($"FinalCapital   : {capital:N0}");
        Console.WriteLine($"NetProfit      : {netProfit:N0}");
        Console.WriteLine($"CapitalReturn  : {capitalReturn:F2}%");
        Console.WriteLine($"MaxDrawdown    : {maxDrawdown:F2}%");
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

        Console.WriteLine();
        Console.WriteLine("=== Regime別成績 ===");

        foreach (var regimeGroup in results
                     .GroupBy(x => x.MarketRegime)
                     .OrderBy(x => x.Key))
        {
            var regimeResults = regimeGroup.ToList();

            var regimeTradeCount = regimeResults.Count;
            var regimeWinCount = regimeResults.Count(x => x.ReturnRate > 0);
            var regimeLoseCount = regimeResults.Count(x => x.ReturnRate <= 0);

            var regimeGrossProfit = regimeResults
                .Where(x => x.NetProfitAmount > 0)
                .Sum(x => x.NetProfitAmount);

            var regimeGrossLoss = regimeResults
                .Where(x => x.NetProfitAmount < 0)
                .Sum(x => Math.Abs(x.NetProfitAmount));

            var regimeProfitFactor = regimeGrossLoss > 0
                ? regimeGrossProfit / regimeGrossLoss
                : 0m;

            var regimeNetProfit = regimeResults.Sum(x => x.NetProfitAmount);

            var regimeCapitalReturn =
                regimeNetProfit / executionSettings.InitialCapital * 100m;

            Console.WriteLine(
                $"{regimeGroup.Key,-15} " +
                $"Trades:{regimeTradeCount,4} " +
                $"WinRate:{(decimal)regimeWinCount / regimeTradeCount:P2} " +
                $"NetProfit:{regimeNetProfit,10:N0} " +
                $"CapitalReturn:{regimeCapitalReturn,7:F2}% " +
                $"PF:{regimeProfitFactor:F2}");
        }

        Console.WriteLine();
        Console.WriteLine("=== ExpectedTP帯別成績 ===");

        var tpBuckets = new[]
        {
            new { Name = "TP < 10", Min = decimal.MinValue, Max = 10m },
            new { Name = "TP 10-15", Min = 10m, Max = 15m },
            new { Name = "TP 15-20", Min = 15m, Max = 20m },
            new { Name = "TP 20-25", Min = 20m, Max = 25m },
            new { Name = "TP >= 25", Min = 25m, Max = decimal.MaxValue }
        };

        foreach (var bucket in tpBuckets)
        {
            var bucketResults = results
                .Where(x => x.ExpectedTakeProfit >= bucket.Min)
                .Where(x => x.ExpectedTakeProfit < bucket.Max)
                .ToList();

            if (bucketResults.Count == 0)
            {
                continue;
            }

            var bucketWinCount = bucketResults.Count(x => x.ReturnRate > 0);
            var bucketNetProfit = bucketResults.Sum(x => x.NetProfitAmount);

            var bucketGrossProfit = bucketResults
                .Where(x => x.NetProfitAmount > 0)
                .Sum(x => x.NetProfitAmount);

            var bucketGrossLoss = bucketResults
                .Where(x => x.NetProfitAmount < 0)
                .Sum(x => Math.Abs(x.NetProfitAmount));

            var bucketProfitFactor = bucketGrossLoss > 0
                ? bucketGrossProfit / bucketGrossLoss
                : 0m;

            var bucketCapitalReturn =
                bucketNetProfit / executionSettings.InitialCapital * 100m;

            Console.WriteLine(
                $"{bucket.Name,-10} " +
                $"Trades:{bucketResults.Count,4} " +
                $"WinRate:{(decimal)bucketWinCount / bucketResults.Count:P2} " +
                $"NetProfit:{bucketNetProfit,10:N0} " +
                $"CapitalReturn:{bucketCapitalReturn,7:F2}% " +
                $"PF:{bucketProfitFactor:F2}");
        }

        Console.WriteLine();
        Console.WriteLine("=== TP×Momentum25 成績 ===");

        var tpMomentumGroups = results
            .GroupBy(x =>
            {
                var tpBand =
                    x.ExpectedTakeProfit < 10m ? "TP<10" :
                    x.ExpectedTakeProfit < 15m ? "TP10-15" :
                    x.ExpectedTakeProfit < 20m ? "TP15-20" :
                    x.ExpectedTakeProfit < 25m ? "TP20-25" :
                    "TP>=25";

                var mBand =
                    x.Momentum25 < -10m ? "M<-10" :
                    x.Momentum25 < -5m ? "M-10--5" :
                    x.Momentum25 < 0m ? "M-5-0" :
                    x.Momentum25 < 5m ? "M0-5" :
                    x.Momentum25 < 10m ? "M5-10" :
                    x.Momentum25 < 15m ? "M10-15" :
                    "M>=15";

                return $"{tpBand} / {mBand}";
            })
            .OrderBy(x => x.Key);

        foreach (var group in tpMomentumGroups)
        {
            var crossTradeCount = group.Count();

            if (crossTradeCount < 3)
            {
                continue;
            }

            var crossWinCount = group.Count(x => x.NetProfitAmount > 0);
            var crossNetProfit = group.Sum(x => x.NetProfitAmount);

            var crossGrossProfit = group
                .Where(x => x.NetProfitAmount > 0)
                .Sum(x => x.NetProfitAmount);

            var crossGrossLoss = group
                .Where(x => x.NetProfitAmount < 0)
                .Sum(x => Math.Abs(x.NetProfitAmount));

            var crossProfitFactor = crossGrossLoss > 0
                ? crossGrossProfit / crossGrossLoss
                : 0m;

            var crossCapitalReturn =
                crossNetProfit / executionSettings.InitialCapital * 100m;

            Console.WriteLine(
                $"{group.Key,-24} " +
                $"Trades:{crossTradeCount,4} " +
                $"WinRate:{(decimal)crossWinCount / crossTradeCount:P2} " +
                $"NetProfit:{crossNetProfit,10:N0} " +
                $"CapitalReturn:{crossCapitalReturn,7:F2}% " +
                $"PF:{crossProfitFactor:F2}");
        }

        Console.WriteLine();
        Console.WriteLine("=== Momentum25帯別成績 ===");

        var momentumBuckets = new[]
        {
            new { Name = "M25 < -10", Min = decimal.MinValue, Max = -10m },
            new { Name = "M25 -10--5", Min = -10m, Max = -5m },
            new { Name = "M25 -5-0", Min = -5m, Max = 0m },
            new { Name = "M25 0-5", Min = 0m, Max = 5m },
            new { Name = "M25 5-10", Min = 5m, Max = 10m },
            new { Name = "M25 10-15", Min = 10m, Max = 15m },
            new { Name = "M25 >= 15", Min = 15m, Max = decimal.MaxValue }
        };

        foreach (var bucket in momentumBuckets)
        {
            var bucketResults = results
                .Where(x => x.Momentum25 >= bucket.Min)
                .Where(x => x.Momentum25 < bucket.Max)
                .ToList();

            if (bucketResults.Count == 0)
            {
                continue;
            }

            var bucketWinCount = bucketResults.Count(x => x.ReturnRate > 0);
            var bucketNetProfit = bucketResults.Sum(x => x.NetProfitAmount);

            var bucketGrossProfit = bucketResults
                .Where(x => x.NetProfitAmount > 0)
                .Sum(x => x.NetProfitAmount);

            var bucketGrossLoss = bucketResults
                .Where(x => x.NetProfitAmount < 0)
                .Sum(x => Math.Abs(x.NetProfitAmount));

            var bucketProfitFactor = bucketGrossLoss > 0
                ? bucketGrossProfit / bucketGrossLoss
                : 0m;

            var bucketCapitalReturn =
                bucketNetProfit / executionSettings.InitialCapital * 100m;

            Console.WriteLine(
                $"{bucket.Name,-12} " +
                $"Trades:{bucketResults.Count,4} " +
                $"WinRate:{(decimal)bucketWinCount / bucketResults.Count:P2} " +
                $"NetProfit:{bucketNetProfit,10:N0} " +
                $"CapitalReturn:{bucketCapitalReturn,7:F2}% " +
                $"PF:{bucketProfitFactor:F2}");
        }

        Console.WriteLine();
        Console.WriteLine("=== ExpectedValue帯別成績 ===");

        var evBuckets = new[]
        {
            new { Name = "EV < 0", Min = decimal.MinValue, Max = 0m },
            new { Name = "EV 0-3", Min = 0m, Max = 3m },
            new { Name = "EV 3-6", Min = 3m, Max = 6m },
            new { Name = "EV 6-9", Min = 6m, Max = 9m },
            new { Name = "EV >= 9", Min = 9m, Max = decimal.MaxValue }
        };

        foreach (var bucket in evBuckets)
        {
            var bucketResults = results
                .Where(x => x.ExpectedValue >= bucket.Min)
                .Where(x => x.ExpectedValue < bucket.Max)
                .ToList();

            // 該当トレードがないEV帯は表示しない。
            // サンプルゼロの帯を出すと、比較時にノイズになるため除外する。
            if (bucketResults.Count == 0)
            {
                continue;
            }

            var bucketWinCount = bucketResults.Count(x => x.ReturnRate > 0);
            var bucketNetProfit = bucketResults.Sum(x => x.NetProfitAmount);

            var bucketGrossProfit = bucketResults
                .Where(x => x.NetProfitAmount > 0)
                .Sum(x => x.NetProfitAmount);

            var bucketGrossLoss = bucketResults
                .Where(x => x.NetProfitAmount < 0)
                .Sum(x => Math.Abs(x.NetProfitAmount));

            // 損失がゼロの場合、PFは理論上無限大になる。
            // ただし表示上は既存仕様に合わせて 0 とする。
            var bucketProfitFactor = bucketGrossLoss > 0
                ? bucketGrossProfit / bucketGrossLoss
                : 0m;

            // 初期資金に対して、このEV帯だけでどれだけ資金を増減させたかを見る。
            var bucketCapitalReturn =
                bucketNetProfit / executionSettings.InitialCapital * 100m;

            Console.WriteLine(
                $"{bucket.Name,-8} " +
                $"Trades:{bucketResults.Count,4} " +
                $"WinRate:{(decimal)bucketWinCount / bucketResults.Count:P2} " +
                $"NetProfit:{bucketNetProfit,10:N0} " +
                $"CapitalReturn:{bucketCapitalReturn,7:F2}% " +
                $"PF:{bucketProfitFactor:F2}");
        }

        // ExpectedValue全体統計はEV帯ごとのループ内ではなく、
        // 全バケット表示後に1回だけ出す。
        // これにより、同じAvgEV/MaxEV/MinEVが何度も表示されるバグを防ぐ。
        Console.WriteLine();
        Console.WriteLine("=== ExpectedValue統計 ===");

        Console.WriteLine(
            $"AvgEV : {results.Average(x => x.ExpectedValue):F4}");

        Console.WriteLine(
            $"MaxEV : {results.Max(x => x.ExpectedValue):F4}");

        Console.WriteLine(
            $"MinEV : {results.Min(x => x.ExpectedValue):F4}");
    }

    private async Task<PriceDaily?> GetNextBusinessDayEntryPriceWithCacheAsync(
    string code,
    DateTime signalDate)
    {
        var prices = await GetFuturePricesWithCacheAsync(
            code,
            signalDate);

        var entryPriceRow = prices
            .Where(x => x.TradeDate > signalDate)
            .Where(x => x.OpenPrice != null)
            .Where(x => x.OpenPrice > 0)
            .OrderBy(x => x.TradeDate)
            .FirstOrDefault();

        return entryPriceRow;
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

    private static int CalculateShares(
    decimal entryPrice,
    decimal positionSize,
    int lotSize)
    {
        if (entryPrice <= 0)
        {
            return 0;
        }

        var lotAmount = entryPrice * lotSize;

        var lotCount = Math.Floor(positionSize / lotAmount);

        return (int)lotCount * lotSize;
    }

    private static (decimal GrossProfit, decimal NetProfit) CalculateProfitAmount(
    decimal entryPrice,
    decimal exitPrice,
    int shares,
    BacktestExecutionSettings settings)
    {
        var actualEntryPrice =
            entryPrice * (1 + settings.EntrySlippageRate);

        var actualExitPrice =
            exitPrice * (1 - settings.ExitSlippageRate);

        var buyAmount = actualEntryPrice * shares;
        var sellAmount = actualExitPrice * shares;

        var buyFee = buyAmount * settings.FeeRate;
        var sellFee = sellAmount * settings.FeeRate;

        var grossProfit =
            sellAmount - buyAmount - buyFee - sellFee;

        var netProfit = grossProfit > 0
            ? grossProfit * (1 - settings.TaxRate)
            : grossProfit;

        return (
            Math.Round(grossProfit, 0),
            Math.Round(netProfit, 0));
    }

    private sealed class OpenBacktestPosition
    {
        public string Code { get; set; } = "";
        public DateTime EntryDate { get; set; }
        public DateTime ExitDate { get; set; }
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

        public decimal ExpectedValue { get; set; }

        public decimal Momentum25 { get; set; }
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
        public decimal? MaxExpectedTakeProfit { get; set; }

        public decimal? MaxMomentum25 { get; set; }
        public decimal? MinMomentum25 { get; set; }

        // Momentum25の特定レンジを除外するための下限。
        // 例：-10 <= Momentum25 < 0 を除外したい場合、
        // ExcludeMomentum25Min = -10m を設定する。
        public decimal? ExcludeMomentum25Min { get; set; }

        // Momentum25の特定レンジを除外するための上限。
        // 例：-10 <= Momentum25 < 0 を除外したい場合、
        // ExcludeMomentum25Max = 0m を設定する。
        public decimal? ExcludeMomentum25Max { get; set; }
    }
}