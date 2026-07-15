using System;
using System.Collections.Generic;

namespace StockAnalysis.Batch.Models
{
    /// <summary>
    /// Source Concept IdentityからCanonical Semantic Roleへの
    /// Semantic Mapping Ruleを表すEntity。
    ///
    /// 1レコードが1つのMapping Rule Versionを表し、
    /// Source Concept、Mapping Class、Governance Status、
    /// Reviewer Status及びVersion Lineageを保持する。
    ///
    /// 本EntityはMapping Ruleの永続化状態を表すものであり、
    /// Runtime Mapping判定やScope評価処理そのものは担当しない。
    /// </summary>
    public class SemanticMappingRule
    {
        /// <summary>
        /// Semantic Mapping Ruleの内部ID。
        ///
        /// Azure SQLのIDENTITY(1,1)によって生成される。
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Mapping Ruleを識別するMapping Code。
        ///
        /// 例:
        /// MAP-INV-001
        /// MAP-INV-011
        ///
        /// MappingVersionとの組み合わせによって
        /// Mapping Rule Versionを一意に識別する。
        /// </summary>
        public string MappingCode { get; set; } = string.Empty;

        /// <summary>
        /// Mapping RuleのVersion。
        ///
        /// Mappingの意味、Scope、Evidence等が変更された場合、
        /// 既存Versionを上書きせず新しいVersionを作成する。
        /// </summary>
        public int MappingVersion { get; set; }

        /// <summary>
        /// Source ConceptのNamespace URI。
        ///
        /// QName Prefixではなく、
        /// Source Concept Identityを構成する主要要素として使用する。
        /// </summary>
        public string SourceNamespaceUri { get; set; } = string.Empty;

        /// <summary>
        /// Source ConceptのLocal Name。
        ///
        /// SourceNamespaceUriとの組み合わせによって
        /// Source Concept Identityを識別する。
        /// </summary>
        public string SourceLocalName { get; set; } = string.Empty;

        /// <summary>
        /// Source ConceptのQName。
        ///
        /// 監査、表示及びデバッグ用途として保持する。
        /// QName PrefixはNamespace Aliasであるため、
        /// Source ConceptのPrimary Identityとしては使用しない。
        /// </summary>
        public string? SourceQName { get; set; }

        /// <summary>
        /// Source Conceptが属するTaxonomy Family Code。
        ///
        /// 例:
        /// jppfs
        /// jpigp
        /// CompanyExtension
        /// </summary>
        public string? TaxonomyFamilyCode { get; set; }

        /// <summary>
        /// Source Conceptの種類を表すCode。
        ///
        /// 例:
        /// StandardTaxonomy
        /// CompanyExtension
        /// OtherExtension
        /// Unknown
        /// </summary>
        public string SourceTypeCode { get; set; } = string.Empty;

        /// <summary>
        /// Source Conceptに適用されるAccounting Standard Code。
        ///
        /// 例:
        /// JapaneseGAAP
        /// IFRS
        ///
        /// 適用対象外または未確定の場合はnullとする。
        /// </summary>
        public string? AccountingStandardCode { get; set; }

        /// <summary>
        /// Mapping先となるCanonical Semantic Roleの内部ID。
        /// </summary>
        public int CanonicalRoleId { get; set; }

        /// <summary>
        /// Mapping Class Code。
        ///
        /// 例:
        /// M1
        /// M2
        /// M3
        /// M4
        ///
        /// M5はUnmappedを表すため、
        /// Executable Mapping Ruleとしては保持しない。
        /// </summary>
        public string MappingClassCode { get; set; } = string.Empty;

        /// <summary>
        /// Mapping RuleのGovernance Status Code。
        ///
        /// 例:
        /// Draft
        /// ResearchApproved
        /// ArchitectureApproved
        /// CatalogApproved
        /// ProductionApproved
        /// Active
        /// Superseded
        /// </summary>
        public string StatusCode { get; set; } = string.Empty;

        /// <summary>
        /// Research Reviewerの判定Status Code。
        /// </summary>
        public string ResearchReviewerStatusCode { get; set; } = string.Empty;

        /// <summary>
        /// Architecture Reviewerの判定Status Code。
        /// </summary>
        public string ArchitectureReviewerStatusCode { get; set; } = string.Empty;

        /// <summary>
        /// Production Reviewerの判定Status Code。
        ///
        /// ProductionReviewerStatusCodeが承認状態であっても、
        /// Mapping Ruleが自動的にActiveになるわけではない。
        /// </summary>
        public string ProductionReviewerStatusCode { get; set; } = string.Empty;

        /// <summary>
        /// Mapping Ruleの有効開始日時。
        ///
        /// 有効開始日時が設定されていない場合はnullとする。
        /// </summary>
        public DateTime? EffectiveFrom { get; set; }

        /// <summary>
        /// Mapping Ruleの有効終了日時。
        ///
        /// 現行Ruleなど、有効終了日時が未確定の場合はnullとする。
        /// </summary>
        public DateTime? EffectiveTo { get; set; }

        /// <summary>
        /// このMapping Ruleを置き換える後継Mapping Rule ID。
        ///
        /// 現行Ruleまたは後継Ruleが存在しない場合はnullとする。
        /// </summary>
        public int? SupersededByMappingRuleId { get; set; }

        /// <summary>
        /// Mapping Ruleが最後にReviewされた日時。
        ///
        /// Reviewが未実施の場合はnullとする。
        /// </summary>
        public DateTime? ReviewedAt { get; set; }

        /// <summary>
        /// レコード作成日時。
        ///
        /// 原則としてDatabase側のDefault Constraintによって生成される。
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// レコード最終更新日時。
        ///
        /// 未更新の場合はnullとする。
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// このMapping RuleのMapping先となるCanonical Semantic Role。
        /// </summary>
        public SemanticCanonicalRole CanonicalRole { get; set; } = null!;

        /// <summary>
        /// このMapping Ruleを置き換える後継Mapping Rule。
        ///
        /// 後継Ruleが存在しない場合はnullとする。
        /// </summary>
        public SemanticMappingRule? SupersededByMappingRule { get; set; }

        /// <summary>
        /// このMapping Ruleによって置き換えられた旧Mapping RuleのCollection。
        ///
        /// Version lineageの逆方向Navigationとして使用する。
        /// </summary>
        public ICollection<SemanticMappingRule> SupersededMappingRules { get; set; }
            = new List<SemanticMappingRule>();

        /// <summary>
        /// このMapping Ruleに設定されたScope ConditionのCollection。
        ///
        /// Scopeが存在しない場合、
        /// Source Concept及びEffective Boundary内ではGlobal Mappingとして扱う。
        /// </summary>
        public ICollection<SemanticMappingScope> Scopes { get; set; }
            = new List<SemanticMappingScope>();

        /// <summary>
        /// このMapping Ruleを支持するEvidence ReferenceのCollection。
        ///
        /// Research Sheet、Cross-standard Evidence、
        /// Architecture Artifact等が関連付く。
        /// </summary>
        public ICollection<SemanticMappingEvidenceReference> EvidenceReferences { get; set; }
            = new List<SemanticMappingEvidenceReference>();
    }
}
