namespace StockAnalysis.Batch.Models;

public class FinancialStatement
{
    public string DisclosureNumber { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;

    public DateTime? DisclosedDate { get; set; }
    public DateTime? FiscalYearEnd { get; set; }

    public string? TypeOfDocument { get; set; }

    public decimal? NetSales { get; set; }
    public decimal? OperatingProfit { get; set; }
    public decimal? Profit { get; set; }
    public decimal? EarningsPerShare { get; set; }
    public decimal? EquityToAssetRatio { get; set; }
    public decimal? BookValuePerShare { get; set; }

    public decimal? ResultDividendPerShareAnnual { get; set; }
    public decimal? ForecastDividendPerShareAnnual { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}