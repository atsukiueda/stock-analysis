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
}