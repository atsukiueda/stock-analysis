namespace StockAnalysis.Batch.Models;

public class ScreeningCondition
{
    public int TopCount { get; set; } = 20;

    public int? MinFinancialScore { get; set; }
    public int? MinGrowthScore { get; set; }
    public int? MinDividendScore { get; set; }
    public int? MinRoeScore { get; set; }
    public int? MinPerScore { get; set; }
    public int? MinPbrScore { get; set; }
    public int? MinTechnicalScore { get; set; }
    public int? MinMarketScore { get; set; }

    public string? MarketName { get; set; }

    public int? MinSwingScore { get; set; }
}