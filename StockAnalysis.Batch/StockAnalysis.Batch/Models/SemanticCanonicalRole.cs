using System;
using System.Collections.Generic;

namespace StockAnalysis.Batch.Models
{
    /// <summary>
    /// Canonical Semantic Roleを表すEntity。
    ///
    /// EDINET等のSource ConceptをSemantic Mappingする際の、
    /// 正規化された意味上の到達先を管理する。
    ///
    /// 例:
    /// InventoryTotal
    /// FinishedGoods
    /// WorkInProcess
    /// RawMaterials
    ///
    /// 本EntityはGovernance Dataを表すものであり、
    /// Runtime Mapping処理やCanonicalization処理そのものは担当しない。
    /// </summary>
    public class SemanticCanonicalRole
    {
        /// <summary>
        /// Canonical Semantic Roleの内部ID。
        ///
        /// Azure SQLのIDENTITY(1,1)によって生成される。
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Canonical Semantic Roleを一意に識別するRole Code。
        ///
        /// 例:
        /// InventoryTotal
        /// WorkInProcess
        /// RawMaterials
        ///
        /// RoleVersionとの組み合わせによって
        /// Canonical Role Versionを一意に識別する。
        /// </summary>
        public string RoleCode { get; set; } = string.Empty;

        /// <summary>
        /// Canonical Semantic Roleの表示名。
        /// </summary>
        public string RoleName { get; set; } = string.Empty;

        /// <summary>
        /// Canonical Semantic Roleが属するDomain Code。
        ///
        /// Phase AではInventory Domainを識別するために使用する。
        /// </summary>
        public string DomainCode { get; set; } = string.Empty;

        /// <summary>
        /// Canonical Semantic Roleの意味及び利用目的を説明する。
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Canonical Semantic RoleのRole Type Code。
        ///
        /// Total、Component、Combined等の
        /// Semantic Role上の分類を保持する。
        /// </summary>
        public string RoleTypeCode { get; set; } = string.Empty;

        /// <summary>
        /// 複数の意味要素を統合したCombined Conceptであるかを示す。
        ///
        /// trueの場合、より狭い単一Roleへ
        /// 安易に縮約してはならない。
        /// </summary>
        public bool IsCombinedConcept { get; set; }

        /// <summary>
        /// Residual Conceptであるかを示す。
        ///
        /// 例としてOtherInventoriesのような
        /// 残余的なSemantic Roleを識別するために使用する。
        /// </summary>
        public bool IsResidualConcept { get; set; }

        /// <summary>
        /// 利用可能なScopeが限定されるCanonical Roleであるかを示す。
        ///
        /// trueの場合、Runtime利用時には
        /// Mapping Scopeとの組み合わせによる慎重な判定が必要となる。
        /// </summary>
        public bool IsLimitedScope { get; set; }

        /// <summary>
        /// Canonical Semantic RoleのGovernance Status Code。
        /// </summary>
        public string StatusCode { get; set; } = string.Empty;

        /// <summary>
        /// Canonical Semantic RoleのVersion。
        ///
        /// RoleCodeとの組み合わせによって
        /// Canonical Role Versionを一意に識別する。
        /// </summary>
        public int RoleVersion { get; set; }

        /// <summary>
        /// Canonical Semantic Roleの有効開始日時。
        ///
        /// 有効開始日時が設定されていない場合はnullとする。
        /// </summary>
        public DateTime? EffectiveFrom { get; set; }

        /// <summary>
        /// Canonical Semantic Roleの有効終了日時。
        ///
        /// 現行Roleなど、有効終了日時が未確定の場合はnullとする。
        /// </summary>
        public DateTime? EffectiveTo { get; set; }

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
        /// このCanonical Semantic Roleを参照する
        /// Semantic Mapping RuleのCollection。
        ///
        /// 1つのCanonical Roleに対して、
        /// 複数のSource Concept Mapping Ruleが関連付くことができる。
        /// </summary>
        public ICollection<SemanticMappingRule> MappingRules { get; set; }
            = new List<SemanticMappingRule>();
    }
}
