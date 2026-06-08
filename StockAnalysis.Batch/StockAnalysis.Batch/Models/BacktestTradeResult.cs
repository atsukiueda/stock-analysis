namespace StockAnalysis.Batch.Models;

public class BacktestTradeResult
{
    public string Code { get; set; } = "";

    public string CompanyName { get; set; } = "";

    public DateTime EntryDate { get; set; }

    public decimal EntryPrice { get; set; }

    public decimal TakeProfitPrice { get; set; }

    public decimal StopLossPrice { get; set; }

    public DateTime? ExitDate { get; set; }

    public decimal? ExitPrice { get; set; }

    public decimal ReturnRate { get; set; }

    public string ExitReason { get; set; } = "";

    public int HoldingDays { get; set; }

    public decimal Up5Probability { get; set; }

    public decimal Up10Probability { get; set; }

    public decimal ExpectedTakeProfit { get; set; }

    public decimal ExpectedStopLoss { get; set; }

    public decimal AiRankingScore { get; set; }
}