using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using StockAnalysis.Batch.Backtest;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;
using System.Text;
using StockAnalysis.Batch.Backtest.Analysis;
using StockAnalysis.Batch.Backtest.Report;
using StockAnalysis.Batch.Backtest.Scenario;

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
    private const bool ShowMomentum25Analysis = true;
    private const bool ShowMomentum5Analysis = true;
    private const bool ShowRegimeAnalysis = false;
    private const bool ShowExpectedTpAnalysis = false;

    private readonly StockAnalysisDbContext _db;

    private readonly Dictionary<string, decimal?> _entryPriceCache = new();

    private readonly Dictionary<string, List<PriceDaily>> _futurePricesCache = new();

    private readonly Dictionary<string, List<PriceDaily>> _priceHistoryCache = new();

    private readonly BacktestAnalyzer _backtestAnalyzer = new();

    private readonly BacktestReporter _backtestReporter = new();

    private readonly ScenarioFactory _scenarioFactory = new();

    public BacktestService(StockAnalysisDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// バックテストを実行する。
    /// ウォークフォワードでは、指定されたUp5モデルを使用する。
    /// </summary>
    /// <param name="startDate">開始日</param>
    /// <param name="endDate">終了日</param>
    /// <param name="topCount">1日あたりの候補数</param>
    /// <param name="up5ModelName">
    /// 使用するUp5モデル名。
    /// nullの場合は既存のデフォルトモデルを使用する。
    /// </param>
    public async Task RunAsync(
        DateTime startDate,
        DateTime endDate,
        int topCount = 5,
        string? up5ModelName = null)
    {

        var up5Service = new MlUp5PredictionService(_db);
        var up10Service = new MlUp10PredictionService(_db);
        var takeProfitService = new MlTakeProfitPredictionService(_db);
        var stopLossService = new MlStopLossPredictionService(_db);
        var filterAnalysisRows = new List<FilterAnalysisRow>();
        var filterRecorder = new FilterAnalysisRecorder();

        var scenarios = _scenarioFactory.CreateReboundWalkForwardBaseScenarios();

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

        Console.WriteLine();
        Console.WriteLine("=== 感度分析サマリー ===");

        foreach (var tradeDate in tradeDates)
        {
            var dailyResultsByScenario = await RunSingleDateAsync(
                tradeDate,
                topCount,
                scenarios,
                up5Service,
                up10Service,
                takeProfitService,
                stopLossService,
                up5ModelName,
                filterRecorder);

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

        // 感度分析結果をCSV出力するために、各シナリオの集計結果を保持する
        var sensitivityResults = new List<SensitivityResult>();

        foreach (var scenario in scenarios)
        {
            // シナリオごとの取引結果を取得する
            var results = resultsByScenario[scenario.Name];

            // CSV出力用に集計結果を作成する
            var sensitivityResult = _backtestAnalyzer.AnalyzeSensitivity(
                scenario,
                results);

            // 後でまとめてCSV出力するため、リストに追加する
            sensitivityResults.Add(sensitivityResult);

            // コンソールにも短いサマリーを表示する
            _backtestReporter.PrintCompactSummary(sensitivityResult);
        }

        // すべてのシナリオ出力後に、感度分析結果をCSV保存する
        _backtestReporter.ExportSensitivityResultsToCsv(sensitivityResults);
        _backtestReporter.ExportFilterAnalysisToCsv(
            filterRecorder.GetRows());
        _backtestReporter.PrintSensitivityHeader();
    }

    private async Task<Dictionary<string, List<BacktestTradeResult>>> RunSingleDateAsync(
        DateTime entryDate,
        int topCount,
        List<BacktestScenario> scenarios,
        MlUp5PredictionService up5Service,
        MlUp10PredictionService up10Service,
        MlTakeProfitPredictionService takeProfitService,
        MlStopLossPredictionService stopLossService,
        string? up5ModelName,
        FilterAnalysisRecorder filterRecorder)
    {
        var executionSettings = new BacktestExecutionSettings();

        var latestMarket = await _db.MarketScoresDaily
            .Where(x => x.ScoreDate <= entryDate)
            .OrderByDescending(x => x.ScoreDate)
            .FirstOrDefaultAsync();

        var currentRegime = latestMarket?.MarketRegime ?? "";

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

        var nullUp5Count = 0;
        var nullUp10Count = 0;
        var nullTakeProfitCount = 0;
        var nullStopLossCount = 0;
        var nullMomentum25Count = 0;

        foreach (var row in sourceRows)
        {
            var bonus = GetMarketRegimeBonus(
                row.Company.MarketName,
                latestMarket?.MarketRegime ?? "");

            var totalScore = row.Score.TotalScore + bonus;

            decimal? up5Probability;

            if (string.IsNullOrWhiteSpace(up5ModelName))
            {
                up5Probability =
                    await up5Service.PredictAsync(row.Score);
            }
            else
            {
                up5Probability =
                    await up5Service.PredictAsync(
                        row.Score,
                        up5ModelName);
            }
            var up10Probability = await up10Service.PredictAsync(row.Score);
            var expectedTakeProfit = await takeProfitService.PredictAsync(row.Score);
            var expectedStopLoss = await stopLossService.PredictAsync(row.Score);

            if (up5Probability == null)
            {
                nullUp5Count++;
            }

            if (up10Probability == null)
            {
                nullUp10Count++;
            }

            if (expectedTakeProfit == null)
            {
                nullTakeProfitCount++;
            }

            if (expectedStopLoss == null)
            {
                nullStopLossCount++;
            }

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
                nullMomentum25Count++;
                continue;
            }

            var momentum5 = await CalculateMomentum5Async(
                row.Score.Code,
                row.Score.ScoreDate);

            if (momentum5 == null)
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

                Momentum5 = momentum5.Value,
                Momentum25 = momentum25.Value,

                // ====================================
                // StockScoresDaily からスコア系特徴量をコピー
                // 後で勝ち銘柄・負け銘柄の特徴差を分析するため
                // ====================================
                FinancialScore = row.Score.FinancialScore,
                GrowthScore = row.Score.GrowthScore,
                TechnicalScore = row.Score.TechnicalScore,
                SwingScore = row.Score.SwingScore,
                TotalScoreValue = row.Score.TotalScore,
            });
        }

        var resultsByScenario = scenarios.ToDictionary(
            x => x.Name,
            _ => new List<BacktestTradeResult>());

        foreach (var scenario in scenarios)
        {
            if (scenario.AllowedRegimes != null &&
                !scenario.AllowedRegimes.Contains(currentRegime))
            {
                continue;
            }
            if (scenario.EntryDateFrom != null &&
                entryDate < scenario.EntryDateFrom.Value)
            {
                continue;
            }

            if (scenario.EntryDateTo != null &&
                entryDate > scenario.EntryDateTo.Value)
            {
                continue;
            }

            // ====================================
            // フィルタ通過件数を段階的に集計する。
            // どの条件で候補が消えているかを分析するため、Whereを一括チェーンせず段階ごとに分ける。
            // ====================================

            var diagnostic = new ScenarioFilterDiagnostics
            {
                ScenarioName = scenario.Name,
                EntryDate = entryDate,
                RankingCount = rankingRows.Count
            };

            var filteredCandidates = rankingRows.AsEnumerable();

            if (scenario.AllowedRegimes != null)
            {
                filteredCandidates = filteredCandidates
                    .Where(_ => scenario.AllowedRegimes.Contains(currentRegime));
            }

            var regimePassed = filteredCandidates.ToList();

            diagnostic.RegimePassCount = regimePassed.Count;

            filteredCandidates = regimePassed.AsEnumerable();

            if (scenario.MinExpectedTakeProfit != null)
            {
                filteredCandidates = filteredCandidates
                    .Where(x => x.ExpectedTakeProfit >= scenario.MinExpectedTakeProfit.Value);
            }

            if (scenario.MaxExpectedTakeProfit != null)
            {
                filteredCandidates = filteredCandidates
                    .Where(x => x.ExpectedTakeProfit < scenario.MaxExpectedTakeProfit.Value);
            }

            if (scenario.ExcludeExpectedTakeProfitMin != null &&
                scenario.ExcludeExpectedTakeProfitMax != null)
            {
                filteredCandidates = filteredCandidates
                    .Where(x =>
                        x.ExpectedTakeProfit < scenario.ExcludeExpectedTakeProfitMin.Value ||
                        x.ExpectedTakeProfit >= scenario.ExcludeExpectedTakeProfitMax.Value);
            }

            var expectedTpPassed = filteredCandidates.ToList();

            diagnostic.ExpectedTpPassCount = expectedTpPassed.Count;

            filteredCandidates = expectedTpPassed.AsEnumerable();

            if (scenario.MinMomentum25 != null)
            {
                filteredCandidates = filteredCandidates
                    .Where(x => x.Momentum25 >= scenario.MinMomentum25.Value);
            }

            if (scenario.MaxMomentum25 != null)
            {
                filteredCandidates = filteredCandidates
                    .Where(x => x.Momentum25 <= scenario.MaxMomentum25.Value);
            }

            if (scenario.ExcludeMomentum25Min != null &&
                scenario.ExcludeMomentum25Max != null)
            {
                filteredCandidates = filteredCandidates
                    .Where(x =>
                        x.Momentum25 < scenario.ExcludeMomentum25Min.Value ||
                        x.Momentum25 >= scenario.ExcludeMomentum25Max.Value);
            }

            var momentum25Passed = filteredCandidates.ToList();

            diagnostic.Momentum25PassCount = momentum25Passed.Count;

            filteredCandidates = momentum25Passed.AsEnumerable();

            if (scenario.MinMomentum5 != null)
            {
                filteredCandidates = filteredCandidates
                    .Where(x => x.Momentum5 >= scenario.MinMomentum5.Value);
            }

            if (scenario.MaxMomentum5 != null)
            {
                filteredCandidates = filteredCandidates
                    .Where(x => x.Momentum5 <= scenario.MaxMomentum5.Value);
            }

            var momentum5Passed = filteredCandidates.ToList();

            diagnostic.Momentum5PassCount = momentum5Passed.Count;

            // ====================================
            // ExpectedValue と AiRankingScore を計算する。
            // EV条件は計算後でないと適用できないため、この段階で実施する。
            // ====================================

            foreach (var candidate in momentum5Passed)
            {
                var up10Rate = candidate.Up10Probability / 100m;

                var expectedValue =
                    (up10Rate * candidate.ExpectedTakeProfit)
                    - ((1m - up10Rate) * Math.Abs(candidate.ExpectedStopLoss));

                candidate.ExpectedValue = expectedValue;

                if (scenario.Name.StartsWith("ExpectedValue"))
                {
                    candidate.AiRankingScore = expectedValue;
                }
                else
                {
                    candidate.AiRankingScore =
                        expectedValue
                        + (candidate.Up5Probability * 0.05m)
                        + (candidate.TotalScore * scenario.TotalScoreWeight);
                }
            }

            filteredCandidates = momentum5Passed.AsEnumerable();

            if (scenario.MinExpectedValue != null)
            {
                filteredCandidates = filteredCandidates
                    .Where(x => x.ExpectedValue >= scenario.MinExpectedValue.Value);
            }

            if (scenario.MaxExpectedValue != null)
            {
                filteredCandidates = filteredCandidates
                    .Where(x => x.ExpectedValue <= scenario.MaxExpectedValue.Value);
            }

            var expectedValuePassed = filteredCandidates.ToList();

            diagnostic.ExpectedValuePassCount = expectedValuePassed.Count;

            var candidates = expectedValuePassed
                .OrderByDescending(x => x.AiRankingScore)
                .Take(Math.Min(topCount, executionSettings.MaxEntriesPerDay))
                .ToList();

            foreach (var selected in candidates)
            {
                filterRecorder.Record(
                    entryDate,
                    scenario.Name,
                    selected.Score.Code,
                    selected.Company.CompanyName,
                    currentRegime,
                    selected.Up5Probability,
                    selected.Up10Probability,
                    selected.ExpectedTakeProfit,
                    selected.ExpectedStopLoss,
                    selected.ExpectedValue,
                    selected.Momentum25,
                    selected.Momentum5,
                    selected.AiRankingScore,
                    "Selected");
            }

            diagnostic.FinalCandidateCount = candidates.Count;

            // 候補が0件になるシナリオだけ、原因追跡用に出力する。
            // 出力しすぎるとコンソールが読みにくくなるため、0件時に限定する。
            if (diagnostic.FinalCandidateCount == 0 &&
                diagnostic.RankingCount > 0)
            {
                Console.WriteLine(
                    $"FilterDiag {diagnostic.EntryDate:yyyy-MM-dd} " +
                    $"{diagnostic.ScenarioName} " +
                    $"Ranking:{diagnostic.RankingCount} " +
                    $"Regime:{diagnostic.RegimePassCount} " +
                    $"TP:{diagnostic.ExpectedTpPassCount} " +
                    $"M25:{diagnostic.Momentum25PassCount} " +
                    $"M5:{diagnostic.Momentum5PassCount} " +
                    $"EV:{diagnostic.ExpectedValuePassCount} " +
                    $"Final:{diagnostic.FinalCandidateCount}");
            }

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

                var maxHoldingDays =
                    scenario.MaxHoldingBusinessDays
                    ?? 10;

                if (futurePrices.Count == 0)
                {
                    continue;
                }

                var holdingPrices = futurePrices
                    .Take(maxHoldingDays)
                    .ToList();

                var exitDate = holdingPrices[^1].TradeDate;
                var exitPrice = holdingPrices[^1].ClosePrice ?? entryPrice;
                var exitReason = "TimeExit";

                foreach (var price in holdingPrices)
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

                    Momentum5 = candidate.Momentum5,
                    Momentum25 = candidate.Momentum25,

                    // ====================================
                    // ここから特徴量分析用
                    // AIが選んだ銘柄・捨てた銘柄の差分を見るため、
                    // バックテスト結果にもスコア系特徴量を保存する
                    // ====================================
                    FinancialScore = candidate.FinancialScore,
                    GrowthScore = candidate.GrowthScore,
                    TechnicalScore = candidate.TechnicalScore,
                    SwingScore = candidate.SwingScore,
                    TotalScore = candidate.TotalScore,

                    DeviationFromMa25 = candidate.DeviationFromMa25,
                    ClosePositionInRange25 = candidate.ClosePositionInRange25,
                    VolumeRatio5 = candidate.VolumeRatio5,
                });
            }
        }
        if (entryDate.Year == 2024 && sourceRows.Count > 0)
        {
            Console.WriteLine(
                $"Date:{entryDate:yyyy-MM-dd} " +
                $"Source:{sourceRows.Count} " +
                $"Ranking:{rankingRows.Count} " +
                $"NullUp5:{nullUp5Count} " +
                $"NullUp10:{nullUp10Count} " +
                $"NullTP:{nullTakeProfitCount} " +
                $"NullSL:{nullStopLossCount} " +
                $"NullM25:{nullMomentum25Count}");
        }

        return resultsByScenario;
    }

    // ====================================
    // Momentum5を計算する
    // 5営業日前の終値から現在の終値までの騰落率を求める
    // 直近急落・短期リバウンド候補の判定に使う
    // ====================================
    private async Task<decimal?> CalculateMomentum5Async(
        string code,
        DateTime tradeDate)
    {
        var prices = await GetPriceHistoryWithCacheAsync(code);

        var targetPrices = prices
            .Where(x => x.TradeDate <= tradeDate)
            .Where(x => x.ClosePrice != null)
            .TakeLast(6)
            .ToList();

        if (targetPrices.Count < 6)
        {
            return null;
        }

        var latest = targetPrices[^1].ClosePrice;
        var close5Ago = targetPrices[0].ClosePrice;

        if (latest == null ||
            close5Ago == null ||
            close5Ago <= 0)
        {
            return null;
        }

        return Math.Round(
            (latest.Value - close5Ago.Value) / close5Ago.Value * 100m,
            4);
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
        Console.WriteLine("=== Regime別 EV統計 ===");

        foreach (var group in results.GroupBy(x => x.MarketRegime))
        {
            Console.WriteLine(
                $"{group.Key,-15} " +
                $"AvgEV:{group.Average(x => x.ExpectedValue),8:F2} " +
                $"AvgTP:{group.Average(x => x.ExpectedTakeProfit),8:F2} " +
                $"AvgSL:{group.Average(x => x.ExpectedStopLoss),8:F2}");
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

        Console.WriteLine();
        Console.WriteLine("=== 全トレード明細 ===");

        foreach (var trade in results
            .OrderByDescending(x => x.ReturnRate))
        {
            Console.WriteLine(
                $"{trade.EntryDate:yyyy-MM-dd} " +
                $"{trade.Code} " +
                $"{trade.CompanyName} " +
                $"Ret:{trade.ReturnRate:F2}% " +
                $"M5:{trade.Momentum5:F2} " +
                $"M25:{trade.Momentum25:F2} " +
                $"TP:{trade.ExpectedTakeProfit:F2} " +
                $"EV:{trade.ExpectedValue:F2}");
        }

        Console.WriteLine();
        Console.WriteLine("=== TP25 M25<-10 Trades ===");

        foreach (var trade in results
            .OrderBy(x => x.EntryDate))
        {
            Console.WriteLine(
                $"{trade.EntryDate:yyyy-MM-dd} " +
                $"{trade.Code} " +
                $"{trade.CompanyName} " +
                $"Ret:{trade.ReturnRate:F2}% " +
                $"M25:{trade.Momentum25:F2} " +
                $"TP:{trade.ExpectedTakeProfit:F2} " +
                $"EV:{trade.ExpectedValue:F2}");
        }

        if (ShowMomentum25Analysis)
        {
            PrintMomentum25Summary(results);
        }

        if (ShowMomentum5Analysis)
        {
            PrintMomentum5Summary(results);
        }

        if (ShowRegimeAnalysis)
        {
            PrintRegimeMomentum25Summary(results);
            PrintRegimeMomentum5Summary(results);
        }

        if (ShowExpectedTpAnalysis)
        {
            PrintExpectedTakeProfitSummary(results);
        }

        PrintYearlySummary(results);
        PrintMonthlySummary(results);
    }

    // ====================================
    // 年別成績を表示する
    // 戦略が特定年度だけ強いのかを確認する
    // ====================================
    private void PrintYearlyPerformance(
        List<BacktestTradeResult> trades)
    {
        Console.WriteLine();
        Console.WriteLine("=== Yearly Performance ===");

        var groups = trades
            .GroupBy(x => x.EntryDate.Year)
            .OrderBy(x => x.Key);

        foreach (var group in groups)
        {
            var yearTrades = group.ToList();

            var winCount =
                yearTrades.Count(x => x.ReturnRate > 0);

            var winRate =
                (decimal)winCount /
                yearTrades.Count * 100m;

            var grossProfit =
                yearTrades
                    .Where(x => x.ReturnRate > 0)
                    .Sum(x => x.NetProfitAmount);

            var grossLoss =
                Math.Abs(
                    yearTrades
                        .Where(x => x.ReturnRate <= 0)
                        .Sum(x => x.NetProfitAmount));

            var pf =
                grossLoss == 0
                    ? 0
                    : grossProfit / grossLoss;

            var netProfit =
                yearTrades.Sum(x => x.NetProfitAmount);

            Console.WriteLine();

            Console.WriteLine(
                $"{group.Key}");

            Console.WriteLine(
                $"Trades : {yearTrades.Count}");

            Console.WriteLine(
                $"WinRate : {winRate:F2}%");

            Console.WriteLine(
                $"NetProfit : {netProfit:N0}");

            Console.WriteLine(
                $"PF : {pf:F2}");
        }
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

    private void PrintMomentum25Summary(List<BacktestTradeResult> trades)
    {
        Console.WriteLine();
        Console.WriteLine("=== Momentum25別成績 ===");

        var groups = trades
            .GroupBy(x =>
            {
                if (x.Momentum25 <= -30) return "M25 <= -30";
                if (x.Momentum25 <= -20) return "-30 < M25 <= -20";
                if (x.Momentum25 <= -10) return "-20 < M25 <= -10";
                if (x.Momentum25 <= 0) return "-10 < M25 <= 0";
                return "0 < M25";
            })
            .OrderBy(x => x.Key);

        foreach (var group in groups)
        {
            PrintTradeGroupSummary(group.Key, group.ToList());
        }
    }

    private void PrintExpectedTakeProfitSummary(List<BacktestTradeResult> trades)
    {
        Console.WriteLine();
        Console.WriteLine("=== ExpectedTP別成績 ===");

        var groups = trades
            .GroupBy(x =>
            {
                if (x.ExpectedTakeProfit >= 30) return "ExpectedTP >= 30%";
                if (x.ExpectedTakeProfit >= 20) return "20% <= ExpectedTP < 30%";
                if (x.ExpectedTakeProfit >= 10) return "10% <= ExpectedTP < 20%";
                return "ExpectedTP < 10%";
            })
            .OrderBy(x => x.Key);

        foreach (var group in groups)
        {
            PrintTradeGroupSummary(group.Key, group.ToList());
        }
    }

    private void PrintMomentum5Summary(List<BacktestTradeResult> trades)
    {
        Console.WriteLine();
        Console.WriteLine("=== Momentum5別成績 ===");

        var groups = trades
            .GroupBy(x =>
            {
                if (x.Momentum5 <= -20) return "M5 <= -20";
                if (x.Momentum5 <= -10) return "-20 < M5 <= -10";
                if (x.Momentum5 <= 0) return "-10 < M5 <= 0";
                if (x.Momentum5 <= 10) return "0 < M5 <= 10";

                return "10 < M5";
            });

        foreach (var group in groups)
        {
            PrintTradeGroupSummary(group.Key, group.ToList());
        }
    }

    private void PrintRegimeMomentum5Summary(List<BacktestTradeResult> trades)
    {
        Console.WriteLine();
        Console.WriteLine("=== Regime × Momentum5別成績 ===");

        var groups = trades
            .GroupBy(x =>
            {
                var band =
                    x.Momentum5 <= -20 ? "M5 <= -20" :
                    x.Momentum5 <= -10 ? "-20 < M5 <= -10" :
                    x.Momentum5 <= 0 ? "-10 < M5 <= 0" :
                    x.Momentum5 <= 10 ? "0 < M5 <= 10" :
                    "10 < M5";

                return $"{x.MarketRegime} / {band}";
            });

        foreach (var group in groups)
        {
            PrintTradeGroupSummary(group.Key, group.ToList());
        }
    }

    private void PrintTradeGroupSummary(string groupName, List<BacktestTradeResult> trades)
    {
        if (trades.Count == 0)
        {
            return;
        }

        var winTrades = trades.Where(x => x.ReturnRate > 0).ToList();
        var loseTrades = trades.Where(x => x.ReturnRate <= 0).ToList();

        var tradeCount = trades.Count;
        var winCount = winTrades.Count;

        var winRate = (double)winCount / tradeCount * 100.0;
        var avgReturn = trades.Average(x => x.ReturnRate);

        var grossProfit = winTrades.Sum(x => x.ReturnRate);
        var grossLoss = Math.Abs(loseTrades.Sum(x => x.ReturnRate));
        var profitFactor = grossLoss == 0 ? 999 : grossProfit / grossLoss;

        var totalReturn = trades.Sum(x => x.ReturnRate);

        Console.WriteLine();
        Console.WriteLine($"[{groupName}]");
        Console.WriteLine($"TradeCount : {tradeCount}");
        Console.WriteLine($"WinRate    : {winRate:F2}%");
        Console.WriteLine($"AvgReturn  : {avgReturn:F2}%");
        Console.WriteLine($"TotalReturn: {totalReturn:F2}%");
        Console.WriteLine($"PF         : {profitFactor:F2}");
    }

    /// <summary>
    /// 年別成績を表示する
    /// </summary>
    private void PrintYearlySummary(
        List<BacktestTradeResult> trades)
    {
        Console.WriteLine();
        Console.WriteLine("=== 年別成績 ===");

        var groups = trades
            .GroupBy(x => x.EntryDate.Year)
            .OrderBy(x => x.Key);

        foreach (var group in groups)
        {
            var winTrades = group.Where(x => x.ReturnRate > 0).ToList();
            var loseTrades = group.Where(x => x.ReturnRate <= 0).ToList();

            var grossProfit = winTrades.Sum(x => x.ReturnRate);
            var grossLoss = Math.Abs(loseTrades.Sum(x => x.ReturnRate));

            var profitFactor =
                grossLoss == 0
                    ? 999
                    : grossProfit / grossLoss;

            Console.WriteLine(
                $"{group.Key} " +
                $"Trades:{group.Count(),3} " +
                $"WinRate:{group.Count(x => x.ReturnRate > 0) * 100.0 / group.Count():F2}% " +
                $"TotalReturn:{group.Sum(x => x.ReturnRate):F2}% " +
                $"PF:{profitFactor:F2}");
        }
    }

    /// <summary>
    /// 月別成績を表示する
    /// </summary>
    private void PrintMonthlySummary(
        List<BacktestTradeResult> trades)
    {
        Console.WriteLine();
        Console.WriteLine("=== 月別成績 ===");

        var groups = trades
            .GroupBy(x => $"{x.EntryDate.Year}-{x.EntryDate.Month:00}")
            .OrderBy(x => x.Key);

        foreach (var group in groups)
        {
            var winTrades = group.Where(x => x.ReturnRate > 0).ToList();
            var loseTrades = group.Where(x => x.ReturnRate <= 0).ToList();

            var grossProfit = winTrades.Sum(x => x.ReturnRate);
            var grossLoss = Math.Abs(loseTrades.Sum(x => x.ReturnRate));

            var profitFactor =
                grossLoss == 0
                    ? 999
                    : grossProfit / grossLoss;

            Console.WriteLine(
                $"{group.Key} " +
                $"Trades:{group.Count(),3} " +
                $"WinRate:{group.Count(x => x.ReturnRate > 0) * 100.0 / group.Count():F2}% " +
                $"TotalReturn:{group.Sum(x => x.ReturnRate):F2}% " +
                $"PF:{profitFactor:F2}");
        }
    }

    private void PrintRegimeMomentum25Summary(List<BacktestTradeResult> trades)
    {
        Console.WriteLine();
        Console.WriteLine("=== Regime × Momentum25別成績 ===");

        var groups = trades
            .GroupBy(x =>
            {
                var m25Band =
                    x.Momentum25 <= -30 ? "M25 <= -30" :
                    x.Momentum25 <= -20 ? "-30 < M25 <= -20" :
                    x.Momentum25 <= -10 ? "-20 < M25 <= -10" :
                    x.Momentum25 <= 0 ? "-10 < M25 <= 0" :
                    "0 < M25";

                return $"{x.MarketRegime} / {m25Band}";
            })
            .OrderBy(x => x.Key);

        foreach (var group in groups)
        {
            PrintTradeGroupSummary(group.Key, group.ToList());
        }
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

    /// <summary>
    /// バックテストシナリオごとのフィルタ通過件数を保持する。
    /// どの条件で候補が落ちているかを分析するために使用する。
    /// </summary>
    private sealed class ScenarioFilterDiagnostics
    {
        public string ScenarioName { get; set; } = "";

        public DateTime EntryDate { get; set; }

        public int RankingCount { get; set; }

        public int RegimePassCount { get; set; }

        public int ExpectedTpPassCount { get; set; }

        public int Momentum25PassCount { get; set; }

        public int Momentum5PassCount { get; set; }

        public int ExpectedValuePassCount { get; set; }

        public int FinalCandidateCount { get; set; }
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

        public decimal Momentum5 { get; set; }

        public decimal FinancialScore { get; set; }
        public decimal GrowthScore { get; set; }
        public decimal TechnicalScore { get; set; }
        public decimal SwingScore { get; set; }
        public decimal TotalScoreValue { get; set; }

        public decimal DeviationFromMa25 { get; set; }
        public decimal ClosePositionInRange25 { get; set; }
        public decimal VolumeRatio5 { get; set; }
    }
}