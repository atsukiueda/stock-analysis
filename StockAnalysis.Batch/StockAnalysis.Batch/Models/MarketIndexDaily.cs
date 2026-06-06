namespace StockAnalysis.Batch.Models;

public class MarketIndexDaily
{
    public string IndexCode { get; set; } = string.Empty;
    public DateTime TradeDate { get; set; }
    public string IndexName { get; set; } = string.Empty;

    public decimal? OpenValue { get; set; }
    public decimal? HighValue { get; set; }
    public decimal? LowValue { get; set; }
    public decimal? CloseValue { get; set; }
    public long? Volume { get; set; }

    public string Source { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}