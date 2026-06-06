namespace StockAnalysis.Batch.Models;

public class SwingTradeAdvice
{
    public string Code { get; set; } = "";

    public string CompanyName { get; set; } = "";

    public DateTime TradeDate { get; set; }

    public decimal EntryPrice { get; set; }

    public decimal TakeProfitPrice { get; set; }

    public decimal StopLossPrice { get; set; }

    public int SwingScore { get; set; }

    public string Comment { get; set; } = "";
}