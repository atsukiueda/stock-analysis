using System;

namespace StockAnalysis.Batch.Models
{
    /// <summary>
    /// Semantic Mapping Ruleに対するScope Conditionを表すEntity。
    ///
    /// Mapping Ruleを適用可能なTaxonomy、Accounting Standard、
    /// Company、EDINET Code等の条件を保持する。
    ///
    /// 本EntityはScope条件の永続化状態を表すものであり、
    /// RuntimeでのScope評価処理そのものは担当しない。
    /// </summary>
    public class SemanticMappingScope
    {
        /// <summary>
        /// Semantic Mapping Scopeの内部ID。
        ///
        /// Azure SQLのIDENTITY(1,1)によって生成される。
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// このScope Conditionが属するSemantic Mapping Ruleの内部ID。
        /// </summary>
        public int MappingRuleId { get; set; }

        /// <summary>
        /// Scopeの種類を表すCode。
        ///
        /// 例:
        /// TaxonomyFamily
        /// TaxonomyVersion
        /// AccountingStandard
        /// CompanyCode
        /// EdinetCode
        /// FilingFamily
        /// Namespace
        /// </summary>
        public string ScopeTypeCode { get; set; } = string.Empty;

        /// <summary>
        /// Scope条件の比較方法を表すOperator Code。
        ///
        /// 例:
        /// Equals
        /// FromInclusive
        /// ToInclusive
        /// BetweenInclusive
        /// </summary>
        public string ScopeOperatorCode { get; set; } = string.Empty;

        /// <summary>
        /// Equals条件で使用する単一のScope値。
        ///
        /// Equals以外のOperatorでは原則nullとする。
        /// </summary>
        public string? ScopeValue { get; set; }

        /// <summary>
        /// FromInclusiveまたはBetweenInclusive条件で使用する開始値。
        ///
        /// 対象Operatorで使用しない場合はnullとする。
        /// </summary>
        public string? ScopeValueFrom { get; set; }

        /// <summary>
        /// ToInclusiveまたはBetweenInclusive条件で使用する終了値。
        ///
        /// 対象Operatorで使用しない場合はnullとする。
        /// </summary>
        public string? ScopeValueTo { get; set; }

        /// <summary>
        /// このScope ConditionがMapping適用時に必須であるかを示す。
        ///
        /// Phase Aでは原則trueとして使用する。
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// レコード作成日時。
        ///
        /// 原則としてDatabase側のDefault Constraintによって生成される。
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// このScope Conditionが属するSemantic Mapping Rule。
        /// </summary>
        public SemanticMappingRule MappingRule { get; set; } = null!;
    }
}
