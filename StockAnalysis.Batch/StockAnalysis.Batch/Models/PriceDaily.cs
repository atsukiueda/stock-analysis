namespace StockAnalysis.Batch.Models;

public class PriceDaily
{
    public string Code { get; set; } = string.Empty;
    public DateTime TradeDate { get; set; }

    public decimal? OpenPrice { get; set; }
    public decimal? HighPrice { get; set; }
    public decimal? LowPrice { get; set; }
    public decimal? ClosePrice { get; set; }

    public long? Volume { get; set; }
    public decimal? TurnoverValue { get; set; }

    public decimal? AdjustmentClose { get; set; }
    public long? AdjustmentVolume { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}