using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Services;
using StockAnalysis.Batch.Models;
using StockAnalysis.Batch.Dtos;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");

var options = new DbContextOptionsBuilder<StockAnalysisDbContext>()
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

await using var db = new StockAnalysisDbContext(options);

Console.WriteLine("Azure SQL Databaseへ接続確認中...");

var companyCount = await db.Companies.CountAsync();

Console.WriteLine($"Companies件数: {companyCount}");

using var httpClient = new HttpClient();

//var listedInfoService = new JQuantsListedInfoService(
//    httpClient,
//    configuration);

//Console.WriteLine("J-Quants 上場銘柄一覧取得中...");

//var listedItems = await listedInfoService.GetListedInfoAsync();

//Console.WriteLine($"取得件数: {listedItems.Count}");

//foreach (var item in listedItems.Take(5))
//{
//    Console.WriteLine(
//        $"{item.Code} " +
//        $"{item.CompanyName} " +
//        $"{item.MarketName} " +
//        $"{item.Sector33Name}");
//}

//Console.WriteLine("Companiesへ保存中...");

//var now = DateTime.Now;
//var savedCount = 0;
//var updatedCount = 0;

//foreach (var item in listedItems)
//{
//    if (string.IsNullOrWhiteSpace(item.Code))
//    {
//        continue;
//    }

//    var company = await db.Companies.FindAsync(item.Code);
//    // 会社情報追加
//    if (company == null)
//    {
//        db.Companies.Add(new Company
//        {
//            Code = item.Code,
//            CompanyName = item.CompanyName,
//            CompanyNameEnglish = item.CompanyNameEnglish,
//            MarketCode = item.MarketCode,
//            MarketName = item.MarketName,
//            Sector17Code = item.Sector17Code,
//            Sector17Name = item.Sector17Name,
//            Sector33Code = item.Sector33Code,
//            Sector33Name = item.Sector33Name,
//            IsActive = true,
//            CreatedAt = now,
//            UpdatedAt = now
//        });

//        savedCount++;
//    }
//    // 会社情報更新
//    else
//    {
//        company.CompanyName = item.CompanyName;
//        company.CompanyNameEnglish = item.CompanyNameEnglish;
//        company.MarketCode = item.MarketCode;
//        company.MarketName = item.MarketName;
//        company.Sector17Code = item.Sector17Code;
//        company.Sector17Name = item.Sector17Name;
//        company.Sector33Code = item.Sector33Code;
//        company.Sector33Name = item.Sector33Name;
//        company.IsActive = true;
//        company.UpdatedAt = now;

//        updatedCount++;
//    }
//}

//await db.SaveChangesAsync();

//Console.WriteLine($"Companies保存完了: 追加 {savedCount}件 / 更新 {updatedCount}件");

// J-Quantsの株価取得サービスを作成する。
// HttpClientはAPI通信、configurationはappsettings.jsonのAPIキー取得に使う。
var priceService = new JQuantsPriceService(
    httpClient,
    configuration);

// まずは全銘柄ではなく、代表的な5銘柄だけで動作確認する。
// いきなり全銘柄を取得すると、エラー時の切り分けが難しくなるため。
var targetCodes = new[]
{
    "72030", // トヨタ自動車
    "67580", // ソニーグループ
    "99840", // ソフトバンクグループ
    "83060", // 三菱UFJフィナンシャル・グループ
    "94320"  // 日本電信電話
};

// 銘柄ごとにJ-Quants APIから日足株価を取得し、PricesDailyテーブルへ保存する。
foreach (var code in targetCodes)
{
    Console.WriteLine($"{code} の株価取得中...");

    // 指定銘柄の日足株価を取得する。
    var prices = await priceService.GetPricesAsync(code);

    Console.WriteLine($"{code}: 取得件数 {prices.Count}");

    // 取得件数が0件の場合は、保存処理をせず次の銘柄へ進む。
    // 銘柄コード違い、API制限、対象期間外などの可能性がある。
    if (prices.Count == 0)
    {
        Console.WriteLine($"{code}: 取得データがないためスキップします。");
        continue;
    }

    // DBへUPSERTする。
    // 既存データがあれば更新、なければ追加する。
    await SavePricesAsync(db, prices);

    Console.WriteLine($"{code}: 保存完了");
}

// 日足株価データをPricesDailyテーブルへ保存する。
// 主キーは Code + TradeDate のため、同じ銘柄・同じ日付なら更新する。
static async Task SavePricesAsync(
    StockAnalysisDbContext db,
    List<JQuantsPriceDto> prices)
{
    var now = DateTime.Now;

    foreach (var item in prices)
    {
        // CodeまたはDateが空の場合は保存できないためスキップする。
        if (string.IsNullOrWhiteSpace(item.Code) ||
            string.IsNullOrWhiteSpace(item.Date))
        {
            continue;
        }

        // J-QuantsのDateは文字列なので、DB保存用にDateTimeへ変換する。
        var tradeDate = DateTime.Parse(item.Date);

        // 既に同じ銘柄・同じ日付のデータが存在するか確認する。
        var price = await db.PricesDaily.FindAsync(
            item.Code,
            tradeDate);

        if (price == null)
        {
            // 未登録の場合は新規追加する。
            db.PricesDaily.Add(new PriceDaily
            {
                Code = item.Code,
                TradeDate = tradeDate,

                OpenPrice = item.Open,
                HighPrice = item.High,
                LowPrice = item.Low,
                ClosePrice = item.Close,

                // J-Quants V2では出来高がdecimalで返るため、
                // DBのBIGINTに合わせてlongへ変換する。
                Volume = item.Volume.HasValue
                    ? (long)item.Volume.Value
                    : null,

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
            // 登録済みの場合は最新値で更新する。
            price.OpenPrice = item.Open;
            price.HighPrice = item.High;
            price.LowPrice = item.Low;
            price.ClosePrice = item.Close;

            price.Volume = item.Volume.HasValue
                ? (long)item.Volume.Value
                : null;

            price.TurnoverValue = item.TurnoverValue;
            price.AdjustmentClose = item.AdjustmentClose;

            price.AdjustmentVolume = item.AdjustmentVolume.HasValue
                ? (long)item.AdjustmentVolume.Value
                : null;

            price.UpdatedAt = now;
        }
    }

    // まとめてDBへ反映する。
    await db.SaveChangesAsync();
}