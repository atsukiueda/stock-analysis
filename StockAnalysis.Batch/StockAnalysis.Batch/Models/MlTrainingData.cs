namespace StockAnalysis.Batch.Models;

public class MlTrainingData
{
    public int Id { get; set; }

    public string Code { get; set; } = "";

    public DateTime TradeDate { get; set; }

    public int FinancialScore { get; set; }
    public int GrowthScore { get; set; }
    public int DividendScore { get; set; }
    public int RoeScore { get; set; }
    public int PerScore { get; set; }
    public int PbrScore { get; set; }
    public int TechnicalScore { get; set; }
    public int SwingScore { get; set; }
    public int MarketScore { get; set; }

    public decimal? FutureReturn5 { get; set; }
    public decimal? FutureReturn10 { get; set; }
    public decimal? FutureReturn20 { get; set; }

    public bool Up5 { get; set; }
    public bool Up10 { get; set; }
    public bool Up20 { get; set; }

    public DateTime CreatedAt { get; set; }
}