using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Services;

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