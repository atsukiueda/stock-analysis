namespace StockAnalysis.Batch.Models;

public class MarketScoreDaily
{
    public DateTime ScoreDate { get; set; }

    public int TopixTrendScore { get; set; }
    public int Sp500TrendScore { get; set; }
    public int NasdaqTrendScore { get; set; }
    public int UsdJpyScore { get; set; }
    public int VixScore { get; set; }

    public int TotalScore { get; set; }

    public string? MarketRegime { get; set; }
    public string? Comment { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public int TopixMomentumScore { get; set; }
}