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

    /// <summary>
    /// Canonical Semantic Role Master。
    /// </summary>
    public DbSet<SemanticCanonicalRole> SemanticCanonicalRoles { get; set; }

    /// <summary>
    /// Source ConceptからCanonical Semantic Roleへの
    /// Semantic Mapping Rule Version。
    /// </summary>
    public DbSet<SemanticMappingRule> SemanticMappingRules { get; set; }

    /// <summary>
    /// Semantic Mapping Ruleに対するScope Condition。
    /// </summary>
    public DbSet<SemanticMappingScope> SemanticMappingScopes { get; set; }

    /// <summary>
    /// Semantic Mapping Ruleを支持するEvidence Artifact Reference。
    /// </summary>
    public DbSet<SemanticMappingEvidenceReference>
        SemanticMappingEvidenceReferences
    { get; set; }

    /// <summary>
    /// 明示的にRejectされたSemantic Mapping Decision。
    /// </summary>
    public DbSet<SemanticRejectedMappingDecision>
        SemanticRejectedMappingDecisions
    { get; set; }

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

        // ============================================================
        // Semantic Mapping Phase A
        // SemanticCanonicalRole
        // ============================================================
        //
        // Canonical Semantic Role Masterの
        // Table名、Key、Column制約及びIndexを
        // 適用済みAzure SQL DDLと一致させる。
        modelBuilder.Entity<SemanticCanonicalRole>(entity =>
        {
            // Table名を明示する。
            entity.ToTable("SemanticCanonicalRoles");

            // Primary Keyを設定する。
            entity.HasKey(x => x.Id);

            // IdはDatabaseのIDENTITY(1,1)によって生成される。
            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Canonical Semantic Roleを識別するBusiness Code。
            entity.Property(x => x.RoleCode)
                .IsRequired()
                .HasMaxLength(100);

            // Human-readable Role Name。
            entity.Property(x => x.RoleName)
                .IsRequired()
                .HasMaxLength(200);

            // Canonical Semantic Roleが属するDomain Code。
            entity.Property(x => x.DomainCode)
                .IsRequired()
                .HasMaxLength(100);

            // Canonical Semantic Roleの意味及び利用目的。
            entity.Property(x => x.Description)
                .IsRequired()
                .HasMaxLength(1000);

            // Total、Component、CombinedComponent等のRole Type Code。
            entity.Property(x => x.RoleTypeCode)
                .IsRequired()
                .HasMaxLength(50);

            // Combined Concept Flag。
            entity.Property(x => x.IsCombinedConcept)
                .IsRequired();

            // Residual Concept Flag。
            entity.Property(x => x.IsResidualConcept)
                .IsRequired();

            // Limited Scope Flag。
            entity.Property(x => x.IsLimitedScope)
                .IsRequired();

            // Canonical Semantic RoleのGovernance Status Code。
            entity.Property(x => x.StatusCode)
                .IsRequired()
                .HasMaxLength(50);

            // Canonical Semantic Role Version。
            entity.Property(x => x.RoleVersion)
                .IsRequired();

            // Roleの有効開始日時。
            entity.Property(x => x.EffectiveFrom);

            // Roleの有効終了日時。
            entity.Property(x => x.EffectiveTo);

            // レコード作成日時。
            //
            // Database側にDefault Constraintが存在するため、
            // Database-generated valueとして扱う。
            entity.Property(x => x.CreatedAt)
                .ValueGeneratedOnAdd();

            // レコード最終更新日時。
            entity.Property(x => x.UpdatedAt);

            // RoleCode + RoleVersionの組み合わせを一意にする。
            entity.HasIndex(x => new
            {
                x.RoleCode,
                x.RoleVersion
            })
                .IsUnique();

            // Domain及びStatusによる検索用Index。
            entity.HasIndex(x => new
            {
                x.DomainCode,
                x.StatusCode
            });

            // 1つのCanonical Roleに複数のMapping Ruleを関連付ける。
            //
            // Mapping Rule側のCanonicalRoleIdをForeign Keyとして使用し、
            // Governance履歴を保護するためCascade Deleteは使用しない。
            entity.HasMany(x => x.MappingRules)
                .WithOne(x => x.CanonicalRole)
                .HasForeignKey(x => x.CanonicalRoleId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        // ============================================================
        // Semantic Mapping Phase A
        // SemanticMappingRule
        // ============================================================
        //
        // Source Concept IdentityからCanonical Semantic Roleへの
        // Mapping Rule Versionを表すEntityについて、
        // 適用済みAzure SQL DDLと一致するように
        // Table、Column制約、Index及びRelationshipを設定する。
        modelBuilder.Entity<SemanticMappingRule>(entity =>
        {
            // Table名を明示する。
            entity.ToTable("SemanticMappingRules");

            // Primary Keyを設定する。
            entity.HasKey(x => x.Id);

            // IdはDatabaseのIDENTITY(1,1)によって生成される。
            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Mapping Ruleを識別するBusiness Code。
            entity.Property(x => x.MappingCode)
                .IsRequired()
                .HasMaxLength(50);

            // Mapping Rule Version。
            entity.Property(x => x.MappingVersion)
                .IsRequired();

            // Source ConceptのNamespace URI。
            //
            // QName Prefixではなく、
            // Source Concept Identityの主要要素として保持する。
            entity.Property(x => x.SourceNamespaceUri)
                .IsRequired()
                .HasMaxLength(1000);

            // Source ConceptのLocal Name。
            entity.Property(x => x.SourceLocalName)
                .IsRequired()
                .HasMaxLength(300);

            // Source ConceptのQName。
            //
            // 監査及びデバッグ用途のため、
            // Database定義どおりnullableとする。
            entity.Property(x => x.SourceQName)
                .HasMaxLength(500);

            // Source Conceptが属するTaxonomy Family Code。
            entity.Property(x => x.TaxonomyFamilyCode)
                .HasMaxLength(100);

            // StandardTaxonomy、CompanyExtension等のSource Type Code。
            entity.Property(x => x.SourceTypeCode)
                .IsRequired()
                .HasMaxLength(50);

            // JapaneseGAAP、IFRS等のAccounting Standard Code。
            //
            // 適用対象外または未確定の場合があるためnullableとする。
            entity.Property(x => x.AccountingStandardCode)
                .HasMaxLength(50);

            // Mapping先Canonical Semantic RoleのForeign Key。
            entity.Property(x => x.CanonicalRoleId)
                .IsRequired();

            // M1、M2、M3、M4等のMapping Class Code。
            entity.Property(x => x.MappingClassCode)
                .IsRequired()
                .HasMaxLength(10);

            // Mapping RuleのGovernance Status Code。
            entity.Property(x => x.StatusCode)
                .IsRequired()
                .HasMaxLength(50);

            // Research Reviewer Status Code。
            entity.Property(x => x.ResearchReviewerStatusCode)
                .IsRequired()
                .HasMaxLength(50);

            // Architecture Reviewer Status Code。
            entity.Property(x => x.ArchitectureReviewerStatusCode)
                .IsRequired()
                .HasMaxLength(50);

            // Production Reviewer Status Code。
            entity.Property(x => x.ProductionReviewerStatusCode)
                .IsRequired()
                .HasMaxLength(50);

            // Mapping Ruleの有効開始日時。
            entity.Property(x => x.EffectiveFrom);

            // Mapping Ruleの有効終了日時。
            entity.Property(x => x.EffectiveTo);

            // このMapping Ruleを置き換える後継Mapping Rule ID。
            //
            // 現行Ruleまたは後継Ruleが存在しない場合はnullとする。
            entity.Property(x => x.SupersededByMappingRuleId);

            // Mapping Ruleの最終Review日時。
            entity.Property(x => x.ReviewedAt);

            // レコード作成日時。
            //
            // Database側のDEFAULT SYSDATETIME()によって生成される。
            entity.Property(x => x.CreatedAt)
                .ValueGeneratedOnAdd();

            // レコード最終更新日時。
            entity.Property(x => x.UpdatedAt);

            // MappingCode + MappingVersionの組み合わせを一意にする。
            entity.HasIndex(x => new
            {
                x.MappingCode,
                x.MappingVersion
            })
                .IsUnique();

            // Source Concept候補検索用Index。
            //
            // Database側ではSourceLocalName + StatusCodeをKeyとし、
            // Namespace等はInclude Columnとして定義している。
            //
            // EF CoreのHasIndexではInclude Columnまで再現しないため、
            // 既存Database Indexをそのまま利用する。
            entity.HasIndex(x => new
            {
                x.SourceLocalName,
                x.StatusCode
            });

            // Canonical Role及びStatusによる検索用Index。
            entity.HasIndex(x => new
            {
                x.CanonicalRoleId,
                x.StatusCode
            });

            // Taxonomy Family、Local Name、Statusによる検索用Index。
            entity.HasIndex(x => new
            {
                x.TaxonomyFamilyCode,
                x.SourceLocalName,
                x.StatusCode
            });

            // Canonical Semantic RoleとのRelationship。
            //
            // SemanticCanonicalRole側でもRelationshipを設定しているが、
            // ここでもFKとDelete Behaviorを明示する。
            entity.HasOne(x => x.CanonicalRole)
                .WithMany(x => x.MappingRules)
                .HasForeignKey(x => x.CanonicalRoleId)
                .OnDelete(DeleteBehavior.NoAction);

            // Mapping Rule Version LineageのSelf-reference。
            //
            // SupersededByMappingRuleIdは、
            // このRuleを置き換える後継Ruleを参照する。
            //
            // Cascade Deleteは使用しない。
            entity.HasOne(x => x.SupersededByMappingRule)
                .WithMany(x => x.SupersededMappingRules)
                .HasForeignKey(x => x.SupersededByMappingRuleId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        // ============================================================
        // Semantic Mapping Phase A
        // SemanticMappingScope
        // ============================================================
        //
        // Semantic Mapping Ruleに対するScope Conditionを表すEntityについて、
        // 適用済みAzure SQL DDLと一致するように
        // Table、Column制約、Index及びRelationshipを設定する。
        modelBuilder.Entity<SemanticMappingScope>(entity =>
        {
            // Table名を明示する。
            entity.ToTable("SemanticMappingScopes");

            // Primary Keyを設定する。
            entity.HasKey(x => x.Id);

            // IdはDatabaseのIDENTITY(1,1)によって生成される。
            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // このScope Conditionが属するMapping RuleのForeign Key。
            entity.Property(x => x.MappingRuleId)
                .IsRequired();

            // TaxonomyVersion、AccountingStandard、EdinetCode等の
            // Scope種別を表すCode。
            entity.Property(x => x.ScopeTypeCode)
                .IsRequired()
                .HasMaxLength(50);

            // Equals、BetweenInclusive等の比較方法を表すCode。
            entity.Property(x => x.ScopeOperatorCode)
                .IsRequired()
                .HasMaxLength(50);

            // Equals条件で使用する単一のScope値。
            //
            // Operatorによっては使用しないためnullableとする。
            entity.Property(x => x.ScopeValue)
                .HasMaxLength(1000);

            // FromInclusiveまたはBetweenInclusive条件で使用する開始値。
            //
            // Operatorによっては使用しないためnullableとする。
            entity.Property(x => x.ScopeValueFrom)
                .HasMaxLength(1000);

            // ToInclusiveまたはBetweenInclusive条件で使用する終了値。
            //
            // Operatorによっては使用しないためnullableとする。
            entity.Property(x => x.ScopeValueTo)
                .HasMaxLength(1000);

            // Mapping適用時に必須となるScope Conditionかを示す。
            entity.Property(x => x.IsRequired)
                .IsRequired();

            // レコード作成日時。
            //
            // Database側のDEFAULT SYSDATETIME()によって生成される。
            entity.Property(x => x.CreatedAt)
                .ValueGeneratedOnAdd();

            // Mapping Rule単位でScope Conditionを取得するためのIndex。
            entity.HasIndex(x => x.MappingRuleId);

            // Mapping Rule及びScope Type単位で
            // Scope Conditionを検索するためのIndex。
            entity.HasIndex(x => new
            {
                x.MappingRuleId,
                x.ScopeTypeCode
            });

            // Semantic Mapping RuleとのRelationship。
            //
            // 1つのMapping Ruleに対して
            // 複数のScope Conditionを関連付ける。
            //
            // Governance履歴を保護するため、
            // Cascade Deleteは使用しない。
            entity.HasOne(x => x.MappingRule)
                .WithMany(x => x.Scopes)
                .HasForeignKey(x => x.MappingRuleId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        // ============================================================
        // Semantic Mapping Phase A
        // SemanticMappingEvidenceReference
        // ============================================================
        //
        // Semantic Mapping Ruleを支持するEvidence Artifact Referenceを表すEntityについて、
        // 適用済みAzure SQL DDLと一致するように
        // Table、Column制約、Index及びRelationshipを設定する。
        modelBuilder.Entity<SemanticMappingEvidenceReference>(entity =>
        {
            // Table名を明示する。
            entity.ToTable("SemanticMappingEvidenceReferences");

            // Primary Keyを設定する。
            entity.HasKey(x => x.Id);

            // IdはDatabaseのIDENTITY(1,1)によって生成される。
            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // このEvidence Referenceが支持するMapping RuleのForeign Key。
            entity.Property(x => x.MappingRuleId)
                .IsRequired();

            // Evidence Referenceを一意に識別するEvidence Code。
            entity.Property(x => x.EvidenceCode)
                .IsRequired()
                .HasMaxLength(50);

            // ResearchSheet、CrossStandardEvidence等の
            // Evidence Type Code。
            entity.Property(x => x.EvidenceTypeCode)
                .IsRequired()
                .HasMaxLength(50);

            // Evidence ArtifactのRepository相対Path。
            //
            // Production Mapping Ruleが、
            // どのResearch Evidenceに基づいているかを
            // Traceできるように保持する。
            entity.Property(x => x.ArtifactPath)
                .IsRequired()
                .HasMaxLength(1000);

            // Evidence Artifactの内容または
            // Mapping Ruleとの関係を説明する補足情報。
            entity.Property(x => x.EvidenceDescription)
                .HasMaxLength(1000);

            // Evidence ArtifactのVersion。
            //
            // 明示的なVersionが存在しない場合はnullとする。
            entity.Property(x => x.EvidenceVersion)
                .HasMaxLength(100);

            // Evidenceに関連するReviewer Decision Code。
            //
            // 個別EvidenceにReviewer Decisionを紐付けない場合は
            // nullを許容する。
            entity.Property(x => x.ReviewerDecisionCode)
                .HasMaxLength(50);

            // Evidenceまたは関連MappingがReviewされた日時。
            entity.Property(x => x.ReviewedAt);

            // レコード作成日時。
            //
            // Database側のDEFAULT SYSDATETIME()によって生成される。
            entity.Property(x => x.CreatedAt)
                .ValueGeneratedOnAdd();

            // EvidenceCodeはDatabase上で一意である。
            entity.HasIndex(x => x.EvidenceCode)
                .IsUnique();

            // Mapping Rule単位でEvidence Referenceを取得するためのIndex。
            entity.HasIndex(x => x.MappingRuleId);

            // Semantic Mapping RuleとのRelationship。
            //
            // 1つのMapping Ruleに対して、
            // 複数のEvidence Referenceを関連付ける。
            //
            // Governance履歴を保護するため、
            // Cascade Deleteは使用しない。
            entity.HasOne(x => x.MappingRule)
                .WithMany(x => x.EvidenceReferences)
                .HasForeignKey(x => x.MappingRuleId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        // ============================================================
        // Semantic Mapping Phase A
        // SemanticRejectedMappingDecision
        // ============================================================
        //
        // Semantic Mapping Research及びReviewにおいて
        // 明示的にRejectされたMapping Decisionを表すEntityについて、
        // 適用済みAzure SQL DDLと一致するように
        // Table、Column制約及びIndexを設定する。
        //
        // 本EntityはExecutable Mapping Ruleではなく、
        // Negative Knowledge及びGovernance Historyを保持する。
        modelBuilder.Entity<SemanticRejectedMappingDecision>(entity =>
        {
            // Table名を明示する。
            entity.ToTable("SemanticRejectedMappingDecisions");

            // Primary Keyを設定する。
            entity.HasKey(x => x.Id);

            // IdはDatabaseのIDENTITY(1,1)によって生成される。
            entity.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            // Rejected Mapping Decisionを識別するDecision Code。
            entity.Property(x => x.DecisionCode)
                .IsRequired()
                .HasMaxLength(50);

            // Rejected Mapping Decision Version。
            entity.Property(x => x.DecisionVersion)
                .IsRequired();

            // Reject対象となったSource ConceptのNamespace URI。
            //
            // QName Prefixではなく、
            // Source Concept Identityの主要要素として保持する。
            entity.Property(x => x.SourceNamespaceUri)
                .IsRequired()
                .HasMaxLength(1000);

            // Reject対象となったSource ConceptのLocal Name。
            entity.Property(x => x.SourceLocalName)
                .IsRequired()
                .HasMaxLength(300);

            // Reject対象となったSource ConceptのQName。
            //
            // 監査及びResearch Traceability用途のため、
            // Database定義どおりnullableとする。
            entity.Property(x => x.SourceQName)
                .HasMaxLength(500);

            // Mapping先としてRejectされたCanonical Role Code。
            //
            // Historical Candidateや、
            // Canonical Role Masterへ登録されなかったCandidateも
            // 保存可能とするためForeign Keyにはしない。
            entity.Property(x => x.RejectedCanonicalRoleCode)
                .IsRequired()
                .HasMaxLength(100);

            // RejectされたRoleに代わって採用または推奨された
            // Replacement Canonical Role Code。
            //
            // Replacementが存在しない場合はnullとする。
            entity.Property(x => x.ReplacementCanonicalRoleCode)
                .HasMaxLength(100);

            // Mapping CandidateをRejectした理由の分類Code。
            entity.Property(x => x.ReasonCode)
                .IsRequired()
                .HasMaxLength(100);

            // Mapping CandidateをRejectした具体的な理由。
            entity.Property(x => x.ReasonDescription)
                .IsRequired()
                .HasMaxLength(2000);

            // Rejected Mapping Decisionを支持するEvidence Artifactの
            // Repository相対Path。
            entity.Property(x => x.EvidenceArtifactPath)
                .IsRequired()
                .HasMaxLength(1000);

            // Rejected Mapping DecisionのGovernance Status Code。
            entity.Property(x => x.DecisionStatusCode)
                .IsRequired()
                .HasMaxLength(50);

            // Rejected Mapping DecisionがReviewされた日時。
            entity.Property(x => x.ReviewedAt);

            // レコード作成日時。
            //
            // Database側のDEFAULT SYSDATETIME()によって生成される。
            entity.Property(x => x.CreatedAt)
                .ValueGeneratedOnAdd();

            // レコード最終更新日時。
            entity.Property(x => x.UpdatedAt);

            // DecisionCode + DecisionVersionの組み合わせを一意にする。
            entity.HasIndex(x => new
            {
                x.DecisionCode,
                x.DecisionVersion
            })
                .IsUnique();

            // Source Concept Local Nameによる検索用Index。
            entity.HasIndex(x => x.SourceLocalName);

            // RejectされたCanonical Role Codeによる検索用Index。
            entity.HasIndex(x => x.RejectedCanonicalRoleCode);
        });
    }
}