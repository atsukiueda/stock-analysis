namespace StockAnalysis.Batch.Models;

public class Company
{
    public string Code { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;

    public string? CompanyNameEnglish { get; set; }

    public string? MarketCode { get; set; }
    public string? MarketName { get; set; }

    public string? Sector17Code { get; set; }
    public string? Sector17Name { get; set; }

    public string? Sector33Code { get; set; }
    public string? Sector33Name { get; set; }

    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}