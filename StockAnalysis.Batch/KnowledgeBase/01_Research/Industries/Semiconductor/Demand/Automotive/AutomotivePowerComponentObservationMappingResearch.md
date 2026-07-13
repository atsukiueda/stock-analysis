# Automotive Power Component Observation Mapping Research

**Research Domain**: Semiconductor Industry
**Research Package**: Automotive Demand
**Research Category**: Observation Mapping / Knowledge Transformation
**Knowledge Scope**: Automotive / Power Semiconductor
**Version**: 0.1
**Status**: Candidate Design
**Reviewer Status**: Pending Validation
**Last Updated**: 2026-07-11

---

# 1. Research Objective（研究目的）

Automotive Power Demand Composite Score
（車載パワー半導体需要複合スコア）候補を構成する5 Component
（5構成要素）について、

各Observation（観測項目）がどのComponentへ属するかを定義する。

対象Componentは以下とする。

1. End Demand Component（最終需要）
2. Semiconductor Demand Component（半導体需要）
3. Inventory Adjustment Component（在庫調整）
4. Capacity Risk Component（供給能力リスク）
5. Commercialization Component（商用化）

本Researchでは、Observationの二重計上を防止し、

```text
One Observation
→ One Primary Component
```

を原則とする。

必要な場合のみSecondary Context
（補助Context）として他Componentから参照する。

---

# 2. Research Success Criteria（調査成功条件）

以下をすべて定義できた場合、本Researchを完了候補とする。

* ObservationごとのPrimary Component
* Secondary Context利用可否
* Observation Direction
* Update Frequency
* Disclosure Status
* Point-in-time利用条件
* Double Counting Rule
* Missing Data Rule
* Component利用上限
* Validation方法

---

# 3. Mapping Principles（マッピング原則）

## 3.1 Primary Component Principle（主構成要素原則）

各Observationは、原則として一つのPrimary Componentのみへ所属する。

例：

```text
EV Sales Growth
→ End Demand
```

同じEV Sales Growthを

```text
End Demand
Semiconductor Demand
Commercialization
```

のすべてへ直接加点してはならない。

---

## 3.2 Secondary Context Principle（補助Context原則）

Observationは他Componentの解釈条件として参照できる。

例：

```text
EV Sales Growth
```

Primary Component：

```text
End Demand
```

Secondary Context：

```text
Semiconductor Demandとの乖離確認
Capacity Risk判定時の需要確認
```

Secondary Contextとして参照しても、
Component Scoreへ重複加点しない。

---

## 3.3 Observation Is Not Interpretation

（Observationと解釈を分離する）

以下はObservationである。

```text
Inventory Growth = +15%
```

以下はInterpretationである。

```text
Inventory Pressure
```

Raw Observationを直接Knowledge Stateへ変換しない。

必ずTransformation Ruleを経由する。

---

## 3.4 Direction Must Be Context-aware

（方向性はContext依存とする）

同じObservationでも、常にPositiveまたはNegativeとは限らない。

例：

```text
CapEx Increase
```

以下の両方があり得る。

```text
Demand-backed Expansion
```

または

```text
Capacity Oversupply Risk
```

したがってCapEx単独へ固定方向を付与しない。

---

# 4. Component A Mapping: End Demand（最終需要）

## 4.1 Purpose

完成車および電動車市場側で、
実際の最終需要が拡大・縮小しているかを観測する。

## 4.2 Observation Mapping

| Observation               | Primary    | Direction Candidate         | Availability             | Initial Status   |
| ------------------------- | ---------- | --------------------------- | ------------------------ | ---------------- |
| Global EV Sales Growth    | End Demand | Higher = Positive candidate | High                     | Adopt Candidate  |
| Regional EV Sales Growth  | End Demand | Exposure-adjusted           | High                     | Strong Candidate |
| BEV Sales Growth          | End Demand | Positive candidate          | High                     | Candidate        |
| PHEV Sales Growth         | End Demand | Unknown Weight              | Medium                   | Candidate        |
| HEV Sales Growth          | End Demand | Unknown Weight              | High in selected regions | Candidate        |
| EV Penetration Change     | End Demand | Positive candidate          | High                     | Strong Candidate |
| Vehicle Production Growth | End Demand | Weak Positive candidate     | High                     | Supporting       |
| OEM Production Guidance   | End Demand | Directional                 | Medium                   | Candidate        |
| Vehicle Inventory         | End Demand | Context-dependent           | Medium                   | Experimental     |

## 4.3 Excluded Observations

以下はEnd Demandへ直接投入しない。

* Semiconductor Revenue
* SiC Revenue
* Company Inventory
* CapEx
* Design Win
* Mass Production Start

理由：

完成車側需要ではなく、
半導体企業側または商用化状態を示すため。

---

# 5. Component B Mapping: Semiconductor Demand（半導体需要）

## 5.1 Purpose

車載Power Semiconductor企業側で、
実際の半導体需要が改善・悪化しているかを観測する。

## 5.2 Observation Mapping

| Observation                     | Primary              | Direction Candidate            | Availability  | Initial Status             |
| ------------------------------- | -------------------- | ------------------------------ | ------------- | -------------------------- |
| Automotive Power Revenue Growth | Semiconductor Demand | Higher = Positive candidate    | Medium        | Strong Candidate           |
| SiC Device Revenue Growth       | Semiconductor Demand | Higher = Positive candidate    | Low to Medium | Strong where available     |
| Automotive Revenue Growth       | Semiconductor Demand | Higher = Positive candidate    | Medium        | Candidate                  |
| Automotive Book-to-Bill         | Semiconductor Demand | Above / Below parity           | Low           | High Value where available |
| Power Guidance Direction        | Semiconductor Demand | Improving / Stable / Weakening | Medium        | Strong Candidate           |
| SiC Guidance Direction          | Semiconductor Demand | Improving / Stable / Weakening | Medium        | Strong Candidate           |
| Customer Demand Commentary      | Semiconductor Demand | Qualitative Direction          | Medium        | Candidate                  |
| Regional Demand Commentary      | Semiconductor Demand | Exposure-adjusted              | Medium        | Candidate                  |

## 5.3 Critical Separation Rule

以下を分離する。

```text
SiC Device Revenue
≠
SiC Module Revenue
≠
SiC Substrate Revenue
```

開示上分離できない場合、

```text
SiC Revenue
```

として上位概念で保持する。

推測によってDevice / Module / Substrateへ配賦してはならない。

---

# 6. Component C Mapping: Inventory Adjustment（在庫調整）

## 6.1 Purpose

End DemandとSemiconductor Demandの乖離を説明する。

## 6.2 Observation Mapping

| Observation                   | Primary              | Direction Candidate          | Availability  | Initial Status   |
| ----------------------------- | -------------------- | ---------------------------- | ------------- | ---------------- |
| Total Inventory Growth        | Inventory Adjustment | Context-dependent            | High          | Candidate        |
| Inventory / Revenue           | Inventory Adjustment | Higher may indicate pressure | Derived       | Strong Candidate |
| Inventory Days                | Inventory Adjustment | Higher may indicate pressure | Derived       | Candidate        |
| Segment Inventory             | Inventory Adjustment | Context-dependent            | Low to Medium | High Value       |
| Customer Inventory Commentary | Inventory Adjustment | Qualitative Direction        | Medium        | Strong Candidate |
| Destocking Commentary         | Inventory Adjustment | Directional                  | Medium        | Strong Candidate |
| Inventory Write-down          | Inventory Adjustment | Negative / Stress candidate  | High          | Supporting       |
| Inventory Recovery            | Inventory Adjustment | Normalization candidate      | Medium        | Supporting       |

## 6.3 Interpretation Constraint

```text
Inventory Decline
```

を単独でPositiveと判定しない。

以下を同時確認する。

* Revenue Trend
* Guidance
* Inventory / Revenue
* Customer Inventory Commentary

例：

```text
Inventory Decline
+
Revenue Collapse
```

は、

```text
Demand Recovery
```

を意味しない。

---

# 7. Component D Mapping: Capacity Risk（供給能力リスク）

## 7.1 Purpose

設備投資・能力増強と実需の整合性を観測する。

## 7.2 Observation Mapping

| Observation              | Primary           | Direction Candidate         | Availability  | Initial Status       |
| ------------------------ | ----------------- | --------------------------- | ------------- | -------------------- |
| CapEx Growth             | Capacity Risk     | No fixed direction          | High          | Candidate            |
| SiC-specific CapEx       | Capacity Risk     | No fixed direction          | Medium        | Strong Candidate     |
| Fab Expansion            | Capacity Risk     | No fixed direction          | Medium        | Candidate            |
| Wafer Capacity Expansion | Capacity Risk     | No fixed direction          | Low to Medium | Candidate            |
| Utilization              | Capacity Risk     | Context-dependent           | Low           | High Value / Limited |
| Underutilization Cost    | Capacity Risk     | Higher = Negative candidate | Medium        | Strong Candidate     |
| Inventory Growth         | Secondary Context | Supporting                  | High          | Reference Only       |
| Revenue Growth           | Secondary Context | Supporting                  | High          | Reference Only       |
| Guidance Direction       | Secondary Context | Supporting                  | Medium        | Reference Only       |

## 7.3 Double Counting Rule

Inventory GrowthはInventory Adjustment Componentへ所属する。

Capacity Riskでは参照のみ行う。

Revenue GrowthはSemiconductor Demandへ所属する。

Capacity Riskでは需要整合性確認にのみ利用する。

---

# 8. Component E Mapping: Commercialization（商用化）

## 8.1 Purpose

製品・技術が研究開発段階から、
実際の商用需要へ移行しているかを観測する。

## 8.2 Observation Mapping

| Observation           | Primary           | Direction Candidate       | Availability  | Initial Status   |
| --------------------- | ----------------- | ------------------------- | ------------- | ---------------- |
| Design Win            | Commercialization | Weak Positive candidate   | Medium        | Low Weight       |
| Customer Nomination   | Commercialization | Positive candidate        | Medium        | Candidate        |
| Mass Production Start | Commercialization | Positive candidate        | Medium        | Strong Candidate |
| Revenue Contribution  | Commercialization | Strong Positive candidate | Low to Medium | High Value       |
| Repeat Adoption       | Commercialization | Positive candidate        | Low           | High Value       |
| Expanded Adoption     | Commercialization | Positive candidate        | Low           | High Value       |
| Product Announcement  | None              | No score                  | High          | Evidence Only    |
| Technology Roadmap    | None              | No score                  | Medium        | Context Only     |

## 8.3 Commercialization Maturity Candidate

```text
Stage 0
Product Announcement

Stage 1
Design Win

Stage 2
Customer Nomination

Stage 3
Mass Production Start

Stage 4
Revenue Contribution

Stage 5
Repeat / Expanded Adoption
```

現時点ではStage間隔を等価とみなさない。

Score WeightはValidation後に決定する。

---

# 9. Complete Observation Mapping（全体マッピング）

| Observation              | Primary Component    | Secondary Context    |
| ------------------------ | -------------------- | -------------------- |
| EV Sales Growth          | End Demand           | Capacity Risk        |
| EV Penetration           | End Demand           | Semiconductor Demand |
| Regional EV Sales        | End Demand           | Company Exposure     |
| Vehicle Production       | End Demand           | Semiconductor Demand |
| Automotive Power Revenue | Semiconductor Demand | Capacity Risk        |
| SiC Device Revenue       | Semiconductor Demand | Commercialization    |
| Automotive Book-to-Bill  | Semiconductor Demand | Inventory Adjustment |
| Power / SiC Guidance     | Semiconductor Demand | Capacity Risk        |
| Inventory Growth         | Inventory Adjustment | Capacity Risk        |
| Inventory / Revenue      | Inventory Adjustment | Capacity Risk        |
| Customer Destocking      | Inventory Adjustment | Semiconductor Demand |
| CapEx Growth             | Capacity Risk        | None                 |
| SiC CapEx                | Capacity Risk        | Semiconductor Demand |
| Utilization              | Capacity Risk        | Inventory Adjustment |
| Underutilization Cost    | Capacity Risk        | Semiconductor Demand |
| Design Win               | Commercialization    | Semiconductor Demand |
| Mass Production Start    | Commercialization    | Semiconductor Demand |
| Revenue Contribution     | Commercialization    | Semiconductor Demand |

Secondary Contextは直接加点しない。

---

# 10. Observation State Requirements（観測状態要件）

各Observationは以下を持つ。

| Field             | Requirement |
| ----------------- | ----------- |
| ObservationCode   | Required    |
| ObservationDate   | Required    |
| ApplicablePeriod  | Required    |
| PublishedDate     | Required    |
| AsOfDate          | Required    |
| RawValue          | Conditional |
| NormalizedValue   | Conditional |
| Unit              | Conditional |
| Direction         | Derived     |
| DisclosureStatus  | Required    |
| SourceDocument    | Required    |
| SourceAuthority   | Required    |
| DefinitionVersion | Required    |
| ReviewStatus      | Required    |
| Confidence        | Required    |

ObservationCode等の正式Catalog設計はCatalog Phaseで行う。

---

# 11. Point-in-Time Rule（時点管理規則）

ObservationはApplicable Period
（対象期間）ではなく、

```text
AsOfDate
```

以前に利用可能だったかでML・Backtest利用可否を判断する。

例：

```text
Applicable Period:
FY2025 Q4

Published Date:
2026-05-08

As Of Date:
2026-05-08 or Review Approval Date
```

2026-05-07以前のBacktestへ使用してはならない。

Review Approvalが必須のKnowledge利用では、
ReviewedAt以降のみ利用可能とする。

---

# 12. Observation Conflict Rule（観測競合規則）

異なるComponentが異なる方向を示す場合、
強制的に平均化しない。

例：

```text
End Demand          Positive
Semiconductor Demand Negative
Inventory Adjustment Negative
Capacity Risk        Neutral
Commercialization    Positive
```

この場合、

```text
Mixed
```

または

```text
End-demand-led Recovery
with Semiconductor Adjustment
```

として状態管理する。

単純平均によりNeutralへ圧縮し、
情報を失ってはならない。

---

# 13. Missing Observation Rule（欠損Observation規則）

Component内のObservationが不足する場合、

```text
Missing
```

として管理する。

以下は禁止する。

```text
Missing → 0
Missing → Neutral
Missing → Peer Average
```

Validation後、Model-specific Imputation
（モデル固有欠損補完）を採用する場合のみ例外とする。

---

# 14. Component Confidence（構成要素信頼度）

各ComponentはScoreとは別にConfidenceを持つ。

## Candidate Factors

* Observation Coverage
* Source Authority
* Definition Stability
* Update Recency
* Review Status
* Conflicting Evidence

例：

```text
Semiconductor Demand Score: 75
Confidence: High
```

と

```text
Semiconductor Demand Score: 75
Confidence: Low
```

は同じ意味ではない。

ConfidenceをInvestment Scoreへ直接加点しない。

---

# 15. Initial Component Adoption Decision（初期採用判断）

| Component            | Initial Decision       | Reason           |
| -------------------- | ---------------------- | ---------------- |
| End Demand           | Adopt Candidate        | EV・地域統計を継続取得可能   |
| Semiconductor Demand | Strong Adopt Candidate | 企業売上・Guidanceに近い |
| Inventory Adjustment | Strong Adopt Candidate | 需要との乖離説明に必要      |
| Capacity Risk        | Adopt Candidate        | CapEx誤解釈防止に必要    |
| Commercialization    | Conditional Candidate  | 売上寄与まで確認できる場合に有効 |

---

# 16. Initial Importance Hypothesis（初期重要度仮説）

これはOperational Weightではない。

```text
Semiconductor Demand
    ↓
Inventory Adjustment
    ↓
End Demand
    ↓
Capacity Risk
    ↓
Commercialization
```

の順で投資判断Contributionが高い可能性がある。

**Status**

Hypothesis。

理由：

Semiconductor DemandとInventory Adjustmentは、
企業売上・業績へ比較的近いObservationだからである。

ただし、Walk ForwardおよびAblation Test前にWeightへ反映しない。

---

# 17. Validation Requirements（検証要件）

## Component-level Validation

各Componentについて以下を確認する。

* Future Revenueとの関係
* Future Marginとの関係
* Future Stock Returnとの関係
* Company Rankingへの寄与
* Advisor False Positive削減
* Walk Forward Stability

## Observation-level Ablation

Component内のObservationを一つずつ除去する。

例：

```text
Inventory Component

Full
vs
- Inventory Growth
vs
- Inventory / Revenue
vs
- Customer Commentary
```

Contributionが確認できないObservationは重要度を下げる。

---

# 18. Reviewer Judgment（レビュアー判定）

## Research Reviewer

**判定：承認**

Primary ComponentとSecondary Contextを分離したことにより、
Observationの二重計上リスクが抑制されている。

特に以下を評価する。

* EV SalesをSemiconductor Demandへ直接加点しない。
* InventoryをCapacity Riskへ重複加点しない。
* CapExへ固定方向を付けない。
* Commercializationを段階管理する。

## Engineering / ML Reviewer

**判定：承認**

初期DatasetではComposite Scoreを作らず、
5 ComponentとConfidenceを分離して保存することを推奨する。

例：

```text
AutomotivePowerEndDemand
AutomotivePowerEndDemandConfidence

AutomotivePowerSemiconductorDemand
AutomotivePowerSemiconductorDemandConfidence

AutomotivePowerInventoryAdjustment
AutomotivePowerInventoryConfidence

AutomotivePowerCapacityRisk
AutomotivePowerCapacityRiskConfidence

AutomotivePowerCommercialization
AutomotivePowerCommercializationConfidence
```

ただし正式なカラム・EntityはCatalog / DDL Phaseで決定する。

## ADR Reviewer

**判定：承認**

ObservationのPrimary Ownership
（主所属）を一つに限定し、
Secondary Contextは参照用途に限定する設計を支持する。

これはDouble Counting
（二重計上）を防止する重要なArchitecture Decisionである。

ADR Candidateとして登録対象とする。

---

# 19. Final Decision（現時点の決定）

Automotive Power Demandについて、

Observationを5 Componentへ明示的にMappingする。

各Observationは原則一つのPrimary Componentのみを持つ。

Secondary ContextはTransformation Ruleから参照できるが、
直接Scoreへ重複加点しない。

5 ComponentはValidation前にComposite Scoreへ圧縮しない。

---

# 20. Next Actions（次の作業）

1. Data Availability Matrix（データ利用可能性マトリクス）を作成する。
2. 各Observationの更新頻度・取得履歴期間を確認する。
3. Point-in-time利用可能性を分類する。
4. Lead-Lag Validation Specification（先行・遅行検証仕様）を作成する。
5. Component単位のKnowledge Object Candidateを作成する。
6. ADR CandidateへObservation Primary Ownership Ruleを登録する。
