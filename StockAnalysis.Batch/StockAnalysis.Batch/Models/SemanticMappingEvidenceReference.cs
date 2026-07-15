using System;

namespace StockAnalysis.Batch.Models
{
    /// <summary>
    /// Semantic Mapping Ruleを支持するEvidence Artifactの参照情報を表すEntity。
    ///
    /// Research Sheet、Cross-standard Evidence、Architecture Artifact等の
    /// Evidenceそのものではなく、Repository上のArtifact Path及び
    /// Reviewer Decision等の参照情報を保持する。
    ///
    /// 本EntityはEvidence Bodyの保存やEvidence品質評価そのものは担当しない。
    /// </summary>
    public class SemanticMappingEvidenceReference
    {
        /// <summary>
        /// Semantic Mapping Evidence Referenceの内部ID。
        ///
        /// Azure SQLのIDENTITY(1,1)によって生成される。
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// このEvidence Referenceが支持するSemantic Mapping Ruleの内部ID。
        /// </summary>
        public int MappingRuleId { get; set; }

        /// <summary>
        /// Evidence Referenceを一意に識別するEvidence Code。
        ///
        /// 例:
        /// EV-INV-001
        /// EV-INV-011
        /// </summary>
        public string EvidenceCode { get; set; } = string.Empty;

        /// <summary>
        /// Evidenceの種類を表すCode。
        ///
        /// 例:
        /// ResearchSheet
        /// CrossStandardEvidence
        /// ConsolidationReview
        /// ArchitectureArtifact
        /// PrimarySourceReference
        /// </summary>
        public string EvidenceTypeCode { get; set; } = string.Empty;

        /// <summary>
        /// Evidence ArtifactのRepository相対Path。
        ///
        /// Production Mapping Ruleが、
        /// どのResearch Evidenceに基づいて承認されたかを
        /// 追跡するために使用する。
        /// </summary>
        public string ArtifactPath { get; set; } = string.Empty;

        /// <summary>
        /// Evidence Artifactの内容またはMapping Ruleとの関係を説明する。
        ///
        /// 説明が不要な場合はnullとする。
        /// </summary>
        public string? EvidenceDescription { get; set; }

        /// <summary>
        /// Evidence ArtifactのVersion。
        ///
        /// 明示的なVersion管理がない場合はnullとする。
        /// </summary>
        public string? EvidenceVersion { get; set; }

        /// <summary>
        /// Evidenceに関連するReviewer Decision Code。
        ///
        /// 例:
        /// Approve
        /// ConditionalApprove
        /// Reject
        /// Defer
        ///
        /// Reviewer Decisionを個別Evidenceへ紐付けない場合はnullとする。
        /// </summary>
        public string? ReviewerDecisionCode { get; set; }

        /// <summary>
        /// Evidenceまたは関連MappingがReviewされた日時。
        ///
        /// Review日時が未設定の場合はnullとする。
        /// </summary>
        public DateTime? ReviewedAt { get; set; }

        /// <summary>
        /// レコード作成日時。
        ///
        /// 原則としてDatabase側のDefault Constraintによって生成される。
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// このEvidence Referenceが支持するSemantic Mapping Rule。
        /// </summary>
        public SemanticMappingRule MappingRule { get; set; } = null!;
    }
}
