using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Services;
using StockAnalysis.Batch.Models;

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");

var options = new DbContextOptionsBuilder<StockAnalysisDbContext>()
    .UseSqlServer(connectionString)
    .Options;

await using var db = new StockAnalysisDbContext(options);

Console.WriteLine("Azure SQL Databaseへ接続確認中...");

var companyCount = await db.Companies.CountAsync();

Console.WriteLine($"Companies件数: {companyCount}");

using var httpClient = new HttpClient();

var listedInfoService = new JQuantsListedInfoService(
    httpClient,
    configuration);

Console.WriteLine("J-Quants 上場銘柄一覧取得中...");

var listedItems = await listedInfoService.GetListedInfoAsync();

Console.WriteLine($"取得件数: {listedItems.Count}");

foreach (var item in listedItems.Take(5))
{
    Console.WriteLine(
        $"{item.Code} " +
        $"{item.CompanyName} " +
        $"{item.MarketName} " +
        $"{item.Sector33Name}");
}

Console.WriteLine("Companiesへ保存中...");

var now = DateTime.Now;
var savedCount = 0;
var updatedCount = 0;

foreach (var item in listedItems)
{
    if (string.IsNullOrWhiteSpace(item.Code))
    {
        continue;
    }

    var company = await db.Companies.FindAsync(item.Code);
    // 会社情報追加
    if (company == null)
    {
        db.Companies.Add(new Company
        {
            Code = item.Code,
            CompanyName = item.CompanyName,
            CompanyNameEnglish = item.CompanyNameEnglish,
            MarketCode = item.MarketCode,
            MarketName = item.MarketName,
            Sector17Code = item.Sector17Code,
            Sector17Name = item.Sector17Name,
            Sector33Code = item.Sector33Code,
            Sector33Name = item.Sector33Name,
            IsActive = true,
            CreatedAt = now,
            UpdatedAt = now
        });

        savedCount++;
    }
    // 会社情報更新
    else
    {
        company.CompanyName = item.CompanyName;
        company.CompanyNameEnglish = item.CompanyNameEnglish;
        company.MarketCode = item.MarketCode;
        company.MarketName = item.MarketName;
        company.Sector17Code = item.Sector17Code;
        company.Sector17Name = item.Sector17Name;
        company.Sector33Code = item.Sector33Code;
        company.Sector33Name = item.Sector33Name;
        company.IsActive = true;
        company.UpdatedAt = now;

        updatedCount++;
    }
}

await db.SaveChangesAsync();

Console.WriteLine($"Companies保存完了: 追加 {savedCount}件 / 更新 {updatedCount}件");