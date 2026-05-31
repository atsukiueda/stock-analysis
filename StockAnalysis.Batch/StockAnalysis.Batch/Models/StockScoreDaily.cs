namespace StockAnalysis.Batch.Models;

public class StockScoreDaily
{
    public string Code { get; set; } = string.Empty;

    public DateTime ScoreDate { get; set; }

    public int FinancialScore { get; set; }
    public int TechnicalScore { get; set; }
    public int MarketScore { get; set; }

    public int TotalScore { get; set; }

    public int GrowthScore { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}