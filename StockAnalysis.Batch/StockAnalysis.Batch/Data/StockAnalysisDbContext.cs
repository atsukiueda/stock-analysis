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

    public DbSet<MlTrainingData> MlTrainingData => Set<MlTrainingData>();

    public DbSet<MetricMaster> MetricMasters { get; set; }

    /// <summary>
    /// 投資セクターマスター。
    /// </summary>
    public DbSet<SectorMaster> SectorMasters { get; set; }

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

        modelBuilder.Entity<MlTrainingData>(entity =>
        {
            entity.ToTable("MlTrainingData");
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => new
            {
                e.Code,
                e.TradeDate
            }).IsUnique();
        });

        modelBuilder.Entity<MetricMaster>(entity =>
        {
            entity.ToTable("MetricMasters");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.MetricCode)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.MetricName)
                .HasMaxLength(100)
                .IsRequired();

            entity.Property(x => x.Category)
                .HasMaxLength(50)
                .IsRequired();

            entity.Property(x => x.Description)
                .HasMaxLength(1000);

            entity.Property(x => x.Unit)
                .HasMaxLength(50);

            entity.Property(x => x.EvaluationType)
                .HasConversion<int>()
                .IsRequired();

            entity.Property(x => x.CalculationMethod)
                .HasMaxLength(2000);

            entity.Property(x => x.UsedFor)
                .HasMaxLength(500);

            entity.Property(x => x.InitialImportanceHint)
                .HasColumnType("decimal(4,1)");

            entity.Property(x => x.EvidenceRequirement)
                .HasMaxLength(2000);

            entity.HasIndex(x => x.MetricCode)
                .IsUnique();
        });

        // 投資セクターマスターの設定
        modelBuilder.Entity<SectorMaster>(entity =>
        {
            // テーブル名を明示する
            entity.ToTable("SectorMasters");

            // 主キーを設定する
            entity.HasKey(x => x.Id);

            // セクターコードは内部識別子のため一意制約を設定する
            entity.HasIndex(x => x.SectorCode)
                .IsUnique()
                .HasDatabaseName("UX_SectorMasters_SectorCode");

            // セクターコードを設定する
            entity.Property(x => x.SectorCode)
                .IsRequired()
                .HasMaxLength(50);

            // セクター名を設定する
            entity.Property(x => x.SectorName)
                .IsRequired()
                .HasMaxLength(100);

            // セクター英語名を設定する
            entity.Property(x => x.SectorNameEn)
                .HasMaxLength(100);

            // セクター説明を設定する
            entity.Property(x => x.Description)
                .HasMaxLength(1000);

            // 有効フラグを設定する
            entity.Property(x => x.IsActive)
                .IsRequired()
                .HasDefaultValue(true);

            // 表示順を設定する
            entity.Property(x => x.DisplayOrder)
                .IsRequired()
                .HasDefaultValue(0);

            // 作成日時を設定する
            entity.Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("SYSUTCDATETIME()");

            // 更新日時を設定する
            entity.Property(x => x.UpdatedAt)
                .IsRequired()
                .HasDefaultValueSql("SYSUTCDATETIME()");
        });
    }
}