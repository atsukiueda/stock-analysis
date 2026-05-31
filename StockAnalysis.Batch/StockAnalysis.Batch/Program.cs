using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Dtos;
using StockAnalysis.Batch.Models;
using StockAnalysis.Batch.Services;

// ==============================
// 実行フラグ
// 必要な処理だけ true にする。
// APIを無駄に叩かないため、開発中は1つだけtrue推奨。
// ==============================

const bool RUN_FINANCIAL_IMPORT = false;
const bool RUN_PRICE_IMPORT = false;
const bool RUN_MARKET_INDEX_IMPORT = false;
const bool RUN_USDJPY_IMPORT = false;
const bool RUN_SP500_IMPORT = false;
const bool RUN_NASDAQ_IMPORT = false;
const bool RUN_VIX_IMPORT = false;
const bool RUN_MARKET_SCORE_CALCULATION = true;

// ==============================
// appsettings.json 読み込み
// ==============================

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// ==============================
// Azure SQL Database 接続設定
// ==============================

var connectionString = configuration.GetConnectionString("DefaultConnection");

var options = new DbContextOptionsBuilder<StockAnalysisDbContext>()
    .UseSqlServer(
        connectionString,
        sqlOptions =>
        {
            // Azure SQLの一時的な接続失敗対策
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null);
        })
    .Options;

await using var db = new StockAnalysisDbContext(options);

// ==============================
// DB接続確認
// ==============================

Console.WriteLine("Azure SQL Databaseへ接続確認中...");

var companyCount = await db.Companies.CountAsync();

Console.WriteLine($"Companies件数: {companyCount}");

var alphaVantageApiKey =
    configuration["AlphaVantage:ApiKey"];

Console.WriteLine(
    $"Alpha Vantage API Key Length: {alphaVantageApiKey?.Length}");

// ==============================
// API通信用 HttpClient
// ==============================

using var httpClient = new HttpClient();

// ==============================
// 財務情報取得
// ==============================

if (RUN_FINANCIAL_IMPORT)
{
    Console.WriteLine();
    Console.WriteLine("=== 財務情報取得開始 ===");

    var financialService = new JQuantsFinancialService(
        httpClient,
        configuration);

    // まずはトヨタのみ
    var financials = await financialService.GetFinancialsAsync("72030");

    Console.WriteLine($"財務件数: {financials.Count}");

    foreach (var item in financials.Take(5))
    {
        Console.WriteLine(
            $"{item.Code} " +
            $"{item.DisclosedDate} " +
            $"{item.NetSales}");
    }

    Console.WriteLine("FinancialStatementsへ保存中...");

    await SaveFinancialsAsync(db, financials);

    Console.WriteLine("FinancialStatements保存完了");
}

// ==============================
// 株価取得
// ==============================

if (RUN_PRICE_IMPORT)
{
    Console.WriteLine();
    Console.WriteLine("=== 株価取得開始 ===");

    var priceService = new JQuantsPriceService(
        httpClient,
        configuration);

    // まずは代表5銘柄のみ
    var targetCodes = new[]
    {
        "72030", // トヨタ自動車
        "67580", // ソニーグループ
        "99840", // ソフトバンクグループ
        "83060", // 三菱UFJ
        "94320"  // NTT
    };

    foreach (var code in targetCodes)
    {
        Console.WriteLine($"{code} の株価取得中...");

        var prices = await priceService.GetPricesAsync(code);

        Console.WriteLine($"{code}: 取得件数 {prices.Count}");

        if (prices.Count == 0)
        {
            Console.WriteLine($"{code}: 取得データなし。スキップします。");
            continue;
        }

        await SavePricesAsync(db, prices);

        Console.WriteLine($"{code}: 保存完了");
    }
}

// ==============================
// 市場指数取得
// ==============================

if (RUN_MARKET_INDEX_IMPORT)
{
    Console.WriteLine();
    Console.WriteLine("=== 市場指数取得開始 ===");

    var topixService = new JQuantsTopixService(
        httpClient,
        configuration);

    var topixItems = await topixService.GetTopixAsync();

    Console.WriteLine($"TOPIX取得件数: {topixItems.Count}");

    foreach (var item in topixItems.Take(5))
    {
        Console.WriteLine(
            $"{item.Date} " +
            $"{item.Close}");
    }

    Console.WriteLine("MarketIndicesDailyへ保存中...");

    await SaveTopixAsync(db, topixItems);

    Console.WriteLine("MarketIndicesDaily保存完了");
}

// ==============================
// USDJPY取得
// ==============================

if (RUN_USDJPY_IMPORT)
{
    Console.WriteLine();
    Console.WriteLine("=== USDJPY取得開始 ===");

    var fxService = new AlphaVantageFxService(
        httpClient,
        configuration);

    var usdJpyItems = await fxService.GetUsdJpyDailyAsync();

    Console.WriteLine($"USDJPY取得件数: {usdJpyItems.Count}");

    foreach (var item in usdJpyItems.Take(5))
    {
        Console.WriteLine(
            $"{item.Key} " +
            $"{item.Value.Close}");
    }

    Console.WriteLine(
    "MarketIndicesDailyへ保存中...");

    await SaveUsdJpyAsync(
        db,
        usdJpyItems);

    Console.WriteLine(
        "USDJPY保存完了");
}

// ==============================
// SP500取得
// ==============================

if (RUN_SP500_IMPORT)
{
    Console.WriteLine();
    Console.WriteLine("=== SP500取得開始 ===");

    var indexService = new AlphaVantageIndexService(
        httpClient,
        configuration);

    var sp500Items = await indexService.GetDailyAsync("SPY");

    Console.WriteLine($"SP500取得件数: {sp500Items.Count}");

    foreach (var item in sp500Items.Take(5))
    {
        Console.WriteLine(
            $"{item.Key} " +
            $"{item.Value.Close}");
    }

    Console.WriteLine(
    "MarketIndicesDailyへ保存中...");

    await SaveSp500Async(
        db,
        sp500Items);

    Console.WriteLine(
        "SP500保存完了");
}

// ==============================
// NASDAQ取得
// ==============================

if (RUN_NASDAQ_IMPORT)
{
    Console.WriteLine();
    Console.WriteLine("=== NASDAQ取得開始 ===");

    var indexService = new AlphaVantageIndexService(
        httpClient,
        configuration);

    // QQQはNASDAQ100連動ETF。
    // 開発初期のNASDAQ系市況 proxy として利用する。
    var nasdaqItems = await indexService.GetDailyAsync("QQQ");

    Console.WriteLine($"NASDAQ取得件数: {nasdaqItems.Count}");

    foreach (var item in nasdaqItems.Take(5))
    {
        Console.WriteLine(
            $"{item.Key} " +
            $"{item.Value.Close}");
    }

    Console.WriteLine("MarketIndicesDailyへ保存中...");

    await SaveNasdaqAsync(
        db,
        nasdaqItems);

    Console.WriteLine("NASDAQ保存完了");
}

// ==============================
// VIX取得
// ==============================

if (RUN_VIX_IMPORT)
{
    Console.WriteLine();
    Console.WriteLine("=== VIX取得開始 ===");

    var vixService = new FredVixService(
        httpClient,
        configuration);

    var vixItems = await vixService.GetVixAsync();

    Console.WriteLine($"VIX取得件数: {vixItems.Count}");

    foreach (var item in vixItems
                 .Where(x => x.Value != ".")
                 .TakeLast(5))
    {
        Console.WriteLine(
            $"{item.Date} {item.Value}");
    }

    Console.WriteLine("MarketIndicesDailyへ保存中...");

    await SaveVixAsync(db, vixItems);

    Console.WriteLine("VIX保存完了");
}

// ==============================
// 市場スコア計算
// ==============================

if (RUN_MARKET_SCORE_CALCULATION)
{
    Console.WriteLine();
    Console.WriteLine("=== 市場スコア計算開始 ===");

    var marketScoreService =
        new MarketScoreService(db);

    var score =
        await marketScoreService.CalculateLatestAsync();

    if (score == null)
    {
        Console.WriteLine("市場スコアを計算できませんでした。");
    }
    else
    {
        Console.WriteLine(
            $"ScoreDate: {score.ScoreDate:yyyy-MM-dd}");

        Console.WriteLine(
            $"TotalScore: {score.TotalScore}");

        Console.WriteLine(
            $"MarketRegime: {score.MarketRegime}");

        Console.WriteLine(
            $"Comment: {score.Comment}");

        await marketScoreService.SaveAsync(score);

        Console.WriteLine("MarketScoresDaily保存完了");
    }
}

// ==============================
// 株価保存
// ==============================

static async Task SavePricesAsync(
    StockAnalysisDbContext db,
    List<JQuantsPriceDto> prices)
{
    var now = DateTime.Now;

    foreach (var item in prices)
    {
        if (string.IsNullOrWhiteSpace(item.Code) ||
            string.IsNullOrWhiteSpace(item.Date))
        {
            continue;
        }

        var tradeDate = DateTime.Parse(item.Date);

        var price = await db.PricesDaily.FindAsync(
            item.Code,
            tradeDate);

        if (price == null)
        {
            db.PricesDaily.Add(new PriceDaily
            {
                Code = item.Code,
                TradeDate = tradeDate,
                OpenPrice = item.Open,
                HighPrice = item.High,
                LowPrice = item.Low,
                ClosePrice = item.Close,
                Volume = item.Volume.HasValue ? (long)item.Volume.Value : null,
                TurnoverValue = item.TurnoverValue,
                AdjustmentClose = item.AdjustmentClose,
                AdjustmentVolume = item.AdjustmentVolume.HasValue
                    ? (long)item.AdjustmentVolume.Value
                    : null,
                CreatedAt = now,
                UpdatedAt = now
            });
        }
        else
        {
            price.OpenPrice = item.Open;
            price.HighPrice = item.High;
            price.LowPrice = item.Low;
            price.ClosePrice = item.Close;
            price.Volume = item.Volume.HasValue ? (long)item.Volume.Value : null;
            price.TurnoverValue = item.TurnoverValue;
            price.AdjustmentClose = item.AdjustmentClose;
            price.AdjustmentVolume = item.AdjustmentVolume.HasValue
                ? (long)item.AdjustmentVolume.Value
                : null;
            price.UpdatedAt = now;
        }
    }

    await db.SaveChangesAsync();
}

// ==============================
// 財務保存
// ==============================

static async Task SaveFinancialsAsync(
    StockAnalysisDbContext db,
    List<JQuantsFinancialDto> financials)
{
    var now = DateTime.Now;

    foreach (var item in financials)
    {
        if (string.IsNullOrWhiteSpace(item.DisclosureNumber) ||
            string.IsNullOrWhiteSpace(item.Code))
        {
            continue;
        }

        var financial = await db.FinancialStatements.FindAsync(
            item.DisclosureNumber);

        if (financial == null)
        {
            db.FinancialStatements.Add(new FinancialStatement
            {
                DisclosureNumber = item.DisclosureNumber,
                Code = item.Code,
                DisclosedDate = ParseDate(item.DisclosedDate),
                TypeOfDocument = item.TypeOfDocument,
                NetSales = ParseDecimal(item.NetSales),
                OperatingProfit = ParseDecimal(item.OperatingProfit),
                Profit = ParseDecimal(item.Profit),
                EarningsPerShare = ParseDecimal(item.EarningsPerShare),
                EquityToAssetRatio = ParseDecimal(item.EquityToAssetRatio),
                BookValuePerShare = ParseDecimal(item.BookValuePerShare),
                ResultDividendPerShareAnnual = ParseDecimal(item.ResultDividendPerShareAnnual),
                ForecastDividendPerShareAnnual = ParseDecimal(item.ForecastDividendPerShareAnnual),
                CreatedAt = now,
                UpdatedAt = now
            });
        }
        else
        {
            financial.Code = item.Code;
            financial.DisclosedDate = ParseDate(item.DisclosedDate);
            financial.TypeOfDocument = item.TypeOfDocument;
            financial.NetSales = ParseDecimal(item.NetSales);
            financial.OperatingProfit = ParseDecimal(item.OperatingProfit);
            financial.Profit = ParseDecimal(item.Profit);
            financial.EarningsPerShare = ParseDecimal(item.EarningsPerShare);
            financial.EquityToAssetRatio = ParseDecimal(item.EquityToAssetRatio);
            financial.BookValuePerShare = ParseDecimal(item.BookValuePerShare);
            financial.ResultDividendPerShareAnnual = ParseDecimal(item.ResultDividendPerShareAnnual);
            financial.ForecastDividendPerShareAnnual = ParseDecimal(item.ForecastDividendPerShareAnnual);
            financial.UpdatedAt = now;
        }
    }

    await db.SaveChangesAsync();
}

// ==============================
// TOPIX保存
// ==============================

static async Task SaveTopixAsync(
    StockAnalysisDbContext db,
    List<JQuantsTopixDto> topixItems)
{
    var now = DateTime.Now;

    foreach (var item in topixItems)
    {
        if (string.IsNullOrWhiteSpace(item.Date))
        {
            continue;
        }

        var tradeDate = DateTime.Parse(item.Date);

        var index = await db.MarketIndicesDaily.FindAsync(
            "TOPIX",
            tradeDate);

        if (index == null)
        {
            db.MarketIndicesDaily.Add(new MarketIndexDaily
            {
                IndexCode = "TOPIX",
                IndexName = "TOPIX",
                TradeDate = tradeDate,
                OpenValue = item.Open,
                HighValue = item.High,
                LowValue = item.Low,
                CloseValue = item.Close,
                Volume = null,
                Source = "J-Quants",
                CreatedAt = now,
                UpdatedAt = now
            });
        }
        else
        {
            index.IndexName = "TOPIX";
            index.OpenValue = item.Open;
            index.HighValue = item.High;
            index.LowValue = item.Low;
            index.CloseValue = item.Close;
            index.Source = "J-Quants";
            index.UpdatedAt = now;
        }
    }

    await db.SaveChangesAsync();
}

// ==============================
// USDJPY保存
// ==============================

static async Task SaveUsdJpyAsync(
    StockAnalysisDbContext db,
    Dictionary<string, AlphaVantageFxDailyDto> usdJpyItems)
{
    var now = DateTime.Now;

    foreach (var item in usdJpyItems)
    {
        var tradeDate =
            DateTime.Parse(item.Key);

        var index =
            await db.MarketIndicesDaily.FindAsync(
                "USDJPY",
                tradeDate);

        var open =
            ParseDecimal(item.Value.Open);

        var high =
            ParseDecimal(item.Value.High);

        var low =
            ParseDecimal(item.Value.Low);

        var close =
            ParseDecimal(item.Value.Close);

        if (index == null)
        {
            db.MarketIndicesDaily.Add(
                new MarketIndexDaily
                {
                    IndexCode = "USDJPY",
                    IndexName = "USD/JPY",

                    TradeDate = tradeDate,

                    OpenValue = open,
                    HighValue = high,
                    LowValue = low,
                    CloseValue = close,

                    Volume = null,

                    Source = "AlphaVantage",

                    CreatedAt = now,
                    UpdatedAt = now
                });
        }
        else
        {
            index.OpenValue = open;
            index.HighValue = high;
            index.LowValue = low;
            index.CloseValue = close;

            index.Source = "AlphaVantage";

            index.UpdatedAt = now;
        }
    }

    await db.SaveChangesAsync();
}

// ==============================
// SP500保存
// ==============================

static async Task SaveSp500Async(
    StockAnalysisDbContext db,
    Dictionary<string, AlphaVantageDailyDto> sp500Items)
{
    var now = DateTime.Now;

    foreach (var item in sp500Items)
    {
        var tradeDate =
            DateTime.Parse(item.Key);

        var index =
            await db.MarketIndicesDaily.FindAsync(
                "SP500",
                tradeDate);

        var open =
            ParseDecimal(item.Value.Open);

        var high =
            ParseDecimal(item.Value.High);

        var low =
            ParseDecimal(item.Value.Low);

        var close =
            ParseDecimal(item.Value.Close);

        long? volume =
            long.TryParse(
                item.Value.Volume,
                out var vol)
                ? vol
                : null;

        if (index == null)
        {
            db.MarketIndicesDaily.Add(
                new MarketIndexDaily
                {
                    IndexCode = "SP500",
                    IndexName = "S&P500",

                    TradeDate = tradeDate,

                    OpenValue = open,
                    HighValue = high,
                    LowValue = low,
                    CloseValue = close,

                    Volume = volume,

                    Source = "AlphaVantage",

                    CreatedAt = now,
                    UpdatedAt = now
                });
        }
        else
        {
            index.OpenValue = open;
            index.HighValue = high;
            index.LowValue = low;
            index.CloseValue = close;
            index.Volume = volume;

            index.UpdatedAt = now;
        }
    }

    await db.SaveChangesAsync();
}

// ==============================
// NASDAQ保存
// ==============================

static async Task SaveNasdaqAsync(
    StockAnalysisDbContext db,
    Dictionary<string, AlphaVantageDailyDto> nasdaqItems)
{
    var now = DateTime.Now;

    foreach (var item in nasdaqItems)
    {
        var tradeDate = DateTime.Parse(item.Key);

        var index = await db.MarketIndicesDaily.FindAsync(
            "NASDAQ",
            tradeDate);

        var open = ParseDecimal(item.Value.Open);
        var high = ParseDecimal(item.Value.High);
        var low = ParseDecimal(item.Value.Low);
        var close = ParseDecimal(item.Value.Close);

        long? volume =
            long.TryParse(
                item.Value.Volume,
                out var vol)
                ? vol
                : null;

        if (index == null)
        {
            db.MarketIndicesDaily.Add(
                new MarketIndexDaily
                {
                    IndexCode = "NASDAQ",
                    IndexName = "NASDAQ100 / QQQ",
                    TradeDate = tradeDate,
                    OpenValue = open,
                    HighValue = high,
                    LowValue = low,
                    CloseValue = close,
                    Volume = volume,
                    Source = "AlphaVantage",
                    CreatedAt = now,
                    UpdatedAt = now
                });
        }
        else
        {
            index.IndexName = "NASDAQ100 / QQQ";
            index.OpenValue = open;
            index.HighValue = high;
            index.LowValue = low;
            index.CloseValue = close;
            index.Volume = volume;
            index.Source = "AlphaVantage";
            index.UpdatedAt = now;
        }
    }

    await db.SaveChangesAsync();
}

// ==============================
// VIX保存
// ==============================

static async Task SaveVixAsync(
    StockAnalysisDbContext db,
    List<FredObservationDto> vixItems)
{
    var now = DateTime.Now;

    foreach (var item in vixItems)
    {
        if (string.IsNullOrWhiteSpace(item.Date) ||
            string.IsNullOrWhiteSpace(item.Value) ||
            item.Value == ".")
        {
            continue;
        }

        var tradeDate = DateTime.Parse(item.Date);
        var close = ParseDecimal(item.Value);

        var index = await db.MarketIndicesDaily.FindAsync(
            "VIX",
            tradeDate);

        if (index == null)
        {
            db.MarketIndicesDaily.Add(
                new MarketIndexDaily
                {
                    IndexCode = "VIX",
                    IndexName = "CBOE Volatility Index",
                    TradeDate = tradeDate,
                    OpenValue = null,
                    HighValue = null,
                    LowValue = null,
                    CloseValue = close,
                    Volume = null,
                    Source = "FRED",
                    CreatedAt = now,
                    UpdatedAt = now
                });
        }
        else
        {
            index.IndexName = "CBOE Volatility Index";
            index.CloseValue = close;
            index.Source = "FRED";
            index.UpdatedAt = now;
        }
    }

    await db.SaveChangesAsync();
}

// ==============================
// 文字列→decimal変換
// J-Quants V2の財務数値は文字列で返るため。
// 空文字はnull扱い。
// ==============================

static decimal? ParseDecimal(string? value)
{
    if (string.IsNullOrWhiteSpace(value))
    {
        return null;
    }

    return decimal.TryParse(value, out var result)
        ? result
        : null;
}

// ==============================
// 文字列→DateTime変換
// ==============================

static DateTime? ParseDate(string? value)
{
    if (string.IsNullOrWhiteSpace(value))
    {
        return null;
    }

    return DateTime.TryParse(value, out var result)
        ? result
        : null;
}