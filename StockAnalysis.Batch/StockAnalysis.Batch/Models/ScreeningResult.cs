public class ScreeningResult
{
    public string Code { get; set; } = "";

    public string CompanyName { get; set; } = "";

    public int TotalScore { get; set; }

    public int FinancialScore { get; set; }

    public int GrowthScore { get; set; }

    public int TechnicalScore { get; set; }

    public int MarketScore { get; set; }

    public int MarketRegimeBonus { get; set; }

    public int DividendScore { get; set; }

    public int RoeScore { get; set; }

    public int PerScore { get; set; }

    public int PbrScore { get; set; }

    public int SwingScore { get; set; }

    public decimal Up5Probability { get; set; }

    public decimal AiRankingScore { get; set; }

    public decimal Up10Probability { get; set; }

    public decimal ExpectedTakeProfit { get; set; }

    public decimal ExpectedStopLoss { get; set; }

    public decimal EntryPrice { get; set; }

    public decimal TakeProfitPrice { get; set; }

    public decimal StopLossPrice { get; set; }
}