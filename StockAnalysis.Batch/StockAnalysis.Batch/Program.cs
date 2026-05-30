using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Dtos;
using StockAnalysis.Batch.Models;
using StockAnalysis.Batch.Services;

// ==============================
// 実行フラグ
// true にした処理だけ実行される。
// 開発中に不要なAPI呼び出しを防ぐために使う。
// ==============================

const bool RUN_FINANCIAL_IMPORT = true;
const bool RUN_PRICE_IMPORT = false;
const bool RUN_COMPANY_IMPORT = false;

// ==============================
// appsettings.json 読み込み
// ==============================

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile(
        "appsettings.json",
        optional: false,
        reloadOnChange: true)
    .Build();

// ==============================
// Azure SQL Database 接続文字列取得
// ==============================

var connectionString =
    configuration.GetConnectionString(
        "DefaultConnection");

// ==============================
// EF Core設定
// Azure SQLの一時切断対策として
// EnableRetryOnFailure を設定
// ==============================

var options =
    new DbContextOptionsBuilder<StockAnalysisDbContext>()
        .UseSqlServer(
            connectionString,
            sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(10),
                    errorNumbersToAdd: null);
            })
        .Options;

// ==============================
// DB Context 作成
// ==============================

await using var db =
    new StockAnalysisDbContext(options);

// ==============================
// DB接続確認
// ==============================

Console.WriteLine(
    "Azure SQL Databaseへ接続確認中...");

var companyCount =
    await db.Companies.CountAsync();

Console.WriteLine(
    $"Companies件数: {companyCount}");

// ==============================
// HttpClient 作成
// 全API通信で共通利用する。
// ==============================

using var httpClient = new HttpClient();

// ==============================
// 財務情報取得
// ==============================

if (RUN_FINANCIAL_IMPORT)
{
    Console.WriteLine();
    Console.WriteLine(
        "==============================");

    Console.WriteLine(
        "財務情報取得開始");

    Console.WriteLine(
        "==============================");

    // 財務情報取得サービス作成
    var financialService =
        new JQuantsFinancialService(
            httpClient,
            configuration);

    // まずはトヨタのみで確認
    var financials =
        await financialService.GetFinancialsAsync(
            "72030");

    Console.WriteLine(
        $"財務件数: {financials.Count}");

    // 先頭5件だけConsole表示
    foreach (var item in financials.Take(5))
    {
        Console.WriteLine(
            $"{item.Code} " +
            $"{item.DisclosedDate} " +
            $"{item.NetSales}");
    }

    Console.WriteLine(
        "FinancialStatementsへ保存中...");

    // DB保存
    await SaveFinancialsAsync(
        db,
        financials);

    Console.WriteLine(
        "FinancialStatements保存完了");
}

// ==============================
// 株価取得
// ==============================

if (RUN_PRICE_IMPORT)
{
    Console.WriteLine();
    Console.WriteLine(
        "==============================");

    Console.WriteLine(
        "株価取得開始");

    Console.WriteLine(
        "==============================");

    // 株価取得サービス作成
    var priceService =
        new JQuantsPriceService(
            httpClient,
            configuration);

    // まずは代表銘柄のみ
    var targetCodes = new[]
    {
        "72030", // トヨタ
        "67580", // ソニーG
        "99840", // ソフトバンクG
        "83060", // 三菱UFJ
        "94320"  // NTT
    };

    // 銘柄ごとに取得
    foreach (var code in targetCodes)
    {
        Console.WriteLine(
            $"{code} の株価取得中...");

        var prices =
            await priceService.GetPricesAsync(
                code);

        Console.WriteLine(
            $"{code}: 取得件数 {prices.Count}");

        // 0件ならスキップ
        if (prices.Count == 0)
        {
            Console.WriteLine(
                $"{code}: データなし");

            continue;
        }

        // DB保存
        await SavePricesAsync(
            db,
            prices);

        Console.WriteLine(
            $"{code}: 保存完了");
    }
}

// ==============================
// Companies取得
// 今は未使用
// ==============================

if (RUN_COMPANY_IMPORT)
{
    Console.WriteLine(
        "Companies Import は未実装");
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
        // 必須項目不足ならスキップ
        if (string.IsNullOrWhiteSpace(item.Code) ||
            string.IsNullOrWhiteSpace(item.Date))
        {
            continue;
        }

        // 日付変換
        var tradeDate =
            DateTime.Parse(item.Date);

        // 既存確認
        var price =
            await db.PricesDaily.FindAsync(
                item.Code,
                tradeDate);

        // 新規追加
        if (price == null)
        {
            db.PricesDaily.Add(
                new PriceDaily
                {
                    Code = item.Code,
                    TradeDate = tradeDate,

                    OpenPrice = item.Open,
                    HighPrice = item.High,
                    LowPrice = item.Low,
                    ClosePrice = item.Close,

                    Volume =
                        item.Volume.HasValue
                        ? (long)item.Volume.Value
                        : null,

                    TurnoverValue =
                        item.TurnoverValue,

                    AdjustmentClose =
                        item.AdjustmentClose,

                    AdjustmentVolume =
                        item.AdjustmentVolume.HasValue
                        ? (long)item.AdjustmentVolume.Value
                        : null,

                    CreatedAt = now,
                    UpdatedAt = now
                });
        }
        else
        {
            // 更新
            price.OpenPrice = item.Open;
            price.HighPrice = item.High;
            price.LowPrice = item.Low;
            price.ClosePrice = item.Close;

            price.Volume =
                item.Volume.HasValue
                ? (long)item.Volume.Value
                : null;

            price.TurnoverValue =
                item.TurnoverValue;

            price.AdjustmentClose =
                item.AdjustmentClose;

            price.AdjustmentVolume =
                item.AdjustmentVolume.HasValue
                ? (long)item.AdjustmentVolume.Value
                : null;

            price.UpdatedAt = now;
        }
    }

    // DB反映
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
        // 必須項目不足ならスキップ
        if (string.IsNullOrWhiteSpace(
                item.DisclosureNumber) ||
            string.IsNullOrWhiteSpace(
                item.Code))
        {
            continue;
        }

        // 既存確認
        var financial =
            await db.FinancialStatements.FindAsync(
                item.DisclosureNumber);

        // 新規追加
        if (financial == null)
        {
            db.FinancialStatements.Add(
                new FinancialStatement
                {
                    DisclosureNumber =
                        item.DisclosureNumber,

                    Code = item.Code,

                    DisclosedDate =
                        ParseDate(
                            item.DisclosedDate),

                    TypeOfDocument =
                        item.TypeOfDocument,

                    NetSales =
                        ParseDecimal(
                            item.NetSales),

                    OperatingProfit =
                        ParseDecimal(
                            item.OperatingProfit),

                    Profit =
                        ParseDecimal(
                            item.Profit),

                    EarningsPerShare =
                        ParseDecimal(
                            item.EarningsPerShare),

                    EquityToAssetRatio =
                        ParseDecimal(
                            item.EquityToAssetRatio),

                    BookValuePerShare =
                        ParseDecimal(
                            item.BookValuePerShare),

                    ResultDividendPerShareAnnual =
                        ParseDecimal(
                            item.ResultDividendPerShareAnnual),

                    ForecastDividendPerShareAnnual =
                        ParseDecimal(
                            item.ForecastDividendPerShareAnnual),

                    CreatedAt = now,
                    UpdatedAt = now
                });
        }
        else
        {
            // 更新
            financial.Code = item.Code;

            financial.DisclosedDate =
                ParseDate(
                    item.DisclosedDate);

            financial.TypeOfDocument =
                item.TypeOfDocument;

            financial.NetSales =
                ParseDecimal(
                    item.NetSales);

            financial.OperatingProfit =
                ParseDecimal(
                    item.OperatingProfit);

            financial.Profit =
                ParseDecimal(
                    item.Profit);

            financial.EarningsPerShare =
                ParseDecimal(
                    item.EarningsPerShare);

            financial.EquityToAssetRatio =
                ParseDecimal(
                    item.EquityToAssetRatio);

            financial.BookValuePerShare =
                ParseDecimal(
                    item.BookValuePerShare);

            financial.ResultDividendPerShareAnnual =
                ParseDecimal(
                    item.ResultDividendPerShareAnnual);

            financial.ForecastDividendPerShareAnnual =
                ParseDecimal(
                    item.ForecastDividendPerShareAnnual);

            financial.UpdatedAt = now;
        }
    }

    // DB反映
    await db.SaveChangesAsync();
}

// ==============================
// decimal変換
// 空文字はnullにする
// ==============================

static decimal? ParseDecimal(
    string? value)
{
    if (string.IsNullOrWhiteSpace(value))
    {
        return null;
    }

    return decimal.TryParse(
        value,
        out var result)
        ? result
        : null;
}

// ==============================
// DateTime変換
// 空文字はnullにする
// ==============================

static DateTime? ParseDate(
    string? value)
{
    if (string.IsNullOrWhiteSpace(value))
    {
        return null;
    }

    return DateTime.TryParse(
        value,
        out var result)
        ? result
        : null;
}