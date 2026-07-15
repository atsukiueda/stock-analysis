using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysis.Batch.Models
{
    /// <summary>
    /// Semantic Mapping Research及びReviewにおいて、
    /// 明示的にRejectされたMapping Decisionを表すEntity。
    ///
    /// 誤ったSemantic Mapping CandidateをNegative Knowledgeとして保存し、
    /// 将来のResearch、Architecture Review及びProduction Reviewにおいて
    /// 同じ誤ったMapping判断が繰り返されることを防ぐ。
    ///
    /// 本EntityはExecutable Mapping Ruleではなく、
    /// Governance上のRejected Decisionを独立して保持する。
    /// </summary>
    public class SemanticRejectedMappingDecision
    {
        /// <summary>
        /// Rejected Mapping Decisionの内部ID。
        ///
        /// Azure SQLのIDENTITY(1,1)によって生成される。
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Rejected Mapping Decisionを識別するDecision Code。
        ///
        /// DecisionVersionとの組み合わせによって
        /// Rejected Mapping Decision Versionを一意に識別する。
        /// </summary>
        public string DecisionCode { get; set; } = string.Empty;

        /// <summary>
        /// Rejected Mapping DecisionのVersion。
        ///
        /// Decision内容、EvidenceまたはReplacement判断が変更された場合、
        /// 既存Versionを上書きせず新しいVersionとして管理する。
        /// </summary>
        public int DecisionVersion { get; set; }

        /// <summary>
        /// Reject対象となったSource ConceptのNamespace URI。
        ///
        /// QName Prefixではなく、
        /// Source Concept Identityを構成する主要要素として使用する。
        /// </summary>
        public string SourceNamespaceUri { get; set; } = string.Empty;

        /// <summary>
        /// Reject対象となったSource ConceptのLocal Name。
        ///
        /// SourceNamespaceUriとの組み合わせによって
        /// Source Concept Identityを識別する。
        /// </summary>
        public string SourceLocalName { get; set; } = string.Empty;

        /// <summary>
        /// Reject対象となったSource ConceptのQName。
        ///
        /// 監査、表示及びResearch Traceabilityのために保持する。
        /// QNameが保存されていない場合はnullとする。
        /// </summary>
        public string? SourceQName { get; set; }

        /// <summary>
        /// Mapping先としてRejectされたCanonical Role Code。
        ///
        /// この値はForeign Keyではなく、
        /// Reject時点のSemantic Candidateを表す文字列Codeとして保持する。
        ///
        /// Historical Candidateや、最終的にCanonical Role Masterへ
        /// 登録されなかったCandidateを保持できるようにするため、
        /// SemanticCanonicalRoleとのNavigation Propertyは持たない。
        /// </summary>
        public string RejectedCanonicalRoleCode { get; set; } = string.Empty;

        /// <summary>
        /// RejectされたCanonical Roleに代わって採用された、
        /// または推奨されたReplacement Canonical Role Code。
        ///
        /// Replacementが存在しない場合、
        /// またはUnmappedとして維持する場合はnullとする。
        ///
        /// Historical Decisionを現在のCanonical Role Masterから
        /// 独立して保持するため、Foreign Keyとはしない。
        /// </summary>
        public string? ReplacementCanonicalRoleCode { get; set; }

        /// <summary>
        /// Mapping CandidateをRejectした理由を分類するReason Code。
        ///
        /// 例:
        /// SemanticNarrowing
        /// CombinedConceptLoss
        /// ResidualConceptLoss
        /// InsufficientEvidence
        /// ScopeMismatch
        ///
        /// 実際に利用可能なCodeはDatabase Governance Ruleに従う。
        /// </summary>
        public string ReasonCode { get; set; } = string.Empty;

        /// <summary>
        /// Mapping CandidateをRejectした具体的な理由。
        ///
        /// Reviewerが将来Decisionを再検証できるよう、
        /// Reject理由のSemantic及びEvidence上の根拠を保持する。
        /// </summary>
        public string ReasonDescription { get; set; } = string.Empty;

        /// <summary>
        /// Rejected Mapping Decisionを支持するEvidence Artifactの
        /// Repository相対Path。
        ///
        /// Research Sheet、Cross-standard Evidence、
        /// Architecture Review等へのTraceabilityを保持する。
        /// </summary>
        public string EvidenceArtifactPath { get; set; } = string.Empty;

        /// <summary>
        /// Rejected Mapping DecisionのGovernance Status Code。
        ///
        /// DecisionのReview及びLifecycle状態を保持する。
        /// </summary>
        public string DecisionStatusCode { get; set; } = string.Empty;

        /// <summary>
        /// Rejected Mapping DecisionがReviewされた日時。
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
    }
}
