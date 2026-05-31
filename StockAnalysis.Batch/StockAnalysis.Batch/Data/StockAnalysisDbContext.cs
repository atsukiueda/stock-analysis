using Microsoft.EntityFrameworkCore;
using StockAnalysis.Batch.Models;

namespace StockAnalysis.Batch.Data;

public class StockAnalysisDbContext : DbContext
{
    public StockAnalysisDbContext(DbContextOptions<StockAnalysisDbContext> options)
        : base(options)
    {
    }

    public DbSet<Company> Companies => Set<Company>();
    public DbSet<PriceDaily> PricesDaily => Set<PriceDaily>();
    public DbSet<FinancialStatement> FinancialStatements => Set<FinancialStatement>();

    public DbSet<MarketIndexDaily> MarketIndicesDaily => Set<MarketIndexDaily>();

    public DbSet<MarketScoreDaily> MarketScoresDaily => Set<MarketScoreDaily>();

    public DbSet<StockScoreDaily> StockScoresDaily => Set<StockScoreDaily>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.ToTable("Companies");
            entity.HasKey(e => e.Code);
        });

        modelBuilder.Entity<PriceDaily>(entity =>
        {
            entity.ToTable("PricesDaily");
            entity.HasKey(e => new { e.Code, e.TradeDate });
        });

        modelBuilder.Entity<FinancialStatement>(entity =>
        {
            entity.ToTable("FinancialStatements");
            entity.HasKey(e => e.DisclosureNumber);
        });

        modelBuilder.Entity<MarketIndexDaily>(entity =>
        {
            entity.ToTable("MarketIndicesDaily");
            entity.HasKey(e => new { e.IndexCode, e.TradeDate });
        });

        modelBuilder.Entity<MarketScoreDaily>(entity =>
        {
            entity.ToTable("MarketScoresDaily");
            entity.HasKey(e => e.ScoreDate);
        });

        modelBuilder.Entity<StockScoreDaily>(entity =>
        {
            entity.ToTable("StockScoresDaily");

            entity.HasKey(e =>
                new
                {
                    e.Code,
                    e.ScoreDate
                });
        });
    }
}