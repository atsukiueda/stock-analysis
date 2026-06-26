namespace StockAnalysis.Batch.Backtest.Analysis;

/// <summary>
/// 感度分析結果
/// </summary>
public class SensitivityResult
{
    public string ScenarioName { get; set; } = "";

    public int TradeCount { get; set; }

    public decimal WinRate { get; set; }

    public decimal CapitalReturn { get; set; }

    public decimal MaxDrawdown { get; set; }

    public decimal ProfitFactor { get; set; }

    public double AvgHoldingDays { get; set; }
}