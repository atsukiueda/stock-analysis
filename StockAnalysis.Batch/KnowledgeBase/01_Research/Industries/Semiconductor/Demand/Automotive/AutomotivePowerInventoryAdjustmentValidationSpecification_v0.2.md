# Automotive Power Inventory Adjustment Validation Specification

**Research Domain**: Semiconductor Industry
**Research Package**: Automotive Demand
**Research Category**: Component Validation Specification
**Knowledge Scope**: Automotive / Power Semiconductor
**Component**: Inventory Adjustment
**Version**: 0.2
**Status**: Candidate Validation Specification / EDINET Feasibility Validated
**Reviewer Status**: EDINET Acquisition Feasibility Review Passed
**Last Updated**: 2026-07-13

---

# 1. Purpose（目的）

本Specification（仕様）は、Automotive Power Semiconductor Demand
（車載パワー半導体需要）におけるInventory Adjustment Component
（在庫調整構成要素）の有効性を検証するための標準を定義する。

本Componentの目的は、

```text
End Demand
（最終需要）
```

と

```text
Semiconductor Revenue
（半導体売上）
```

の乖離を説明することである。

本Researchでは、

```text
Inventory Decline = Positive
```

または

```text
Inventory Increase = Negative
```

という固定解釈を採用しない。

Inventory Observation（在庫観測）を、

* Revenue Trend（売上動向）
* Margin Trend（利益率動向）
* Guidance Direction（ガイダンス方向）
* Customer Inventory Commentary（顧客在庫コメント）
* Future Revenue（将来売上）

と組み合わせて検証する。

---

# 2. Research Objective（研究目的）

Inventory Adjustment Componentが、

以下のいずれかへContribution
（寄与）するかをEvidenceに基づいて判断する。

* Future Revenue Growth
* Future Margin Change
* Future Guidance Direction
* Company Ranking
* Future Stock Return
* Advisor False Positive Reduction

本Componentの理論的重要性を証明することが目的ではない。

投資判断への実際のContributionを検証することを目的とする。

---

# 3. Research Success Criteria（調査成功条件）

以下のいずれかをEvidenceで判断できた場合、
本Researchは成功とする。

## Success Pattern A

Inventory Adjustment Componentが、
複数企業・複数Walk Forward Windowで安定したContributionを持つ。

## Success Pattern B

特定Regime、Company、SubSectorでのみ有効である。

この場合、

```text
Conditionally Validated
```

として適用Scopeを限定する。

## Success Pattern C

予測力は低いが、

```text
EV需要は改善しているが在庫調整が継続している
```

等のAdvisor Explanationへ有効である。

この場合、

```text
Context Only
```

とする。

## Success Pattern D

Investment Contributionが確認できない。

この場合、

ML・Decision Engineから除外する。

Knowledge Objectを作成しない、
または重要度を下げる判断もResearch成功とする。

---

# 4. Current Data Source Constraint（現在のデータソース制約）

## Fact

J-Quants `/fins/details` は、
四半期Financial Statement
（財務諸表）情報を取得できる。

レスポンスには、

* DiscDate
* DiscTime
* Code
* Document Type
* Financial Statement Items

が含まれる。

Financial Statement Itemsは、
XBRLに紐付くVerbose Label
（詳細ラベル）をKeyとして提供される。

## Current Operational Constraint

現在利用中のJ-Quants Light Planでは、
財務情報はSummary Data
（サマリー財務情報）のみが対象である。

Financial Statement Data
（BS / PL / CFを含む財務諸表データ）は、
現在の公式料金表ではPremium Plan対象である。

したがって、

```text
J-Quants /fins/details
```

を現在のProduction Sourceとして前提にしない。

---

# 5. Data Source Strategy（データソース戦略）

Inventory Observationについて、
以下のSource Priorityを採用候補とする。

## Priority 1：Existing Database / Existing Financial Acquisition

現在のStock Analysis Systemで既に取得・保存している財務データを確認する。

確認対象：

* Inventory
* Current Assets
* Revenue
* Cost of Sales
* Total Assets
* Operating Income

既存DBにInventoryが存在する場合、
最優先で再利用可能性を確認する。

---

## Priority 2：Company Official Financial Statements

対象企業の公式IR資料から取得する。

対象：

* Balance Sheet
* Consolidated Financial Statements
* Annual Report
* Quarterly Financial Results

Acquisition Candidate：

```text
Official Document Detection
↓
Document Acquisition
↓
Inventory Label Detection
↓
Raw Observation Extraction
↓
Reviewer Check
↓
Approved Observation
```

---

## Priority 3：EDINET / XBRL-based Acquisition

国内企業について、
EDINET Document List APIおよび書類取得APIから取得した
有価証券報告書のCSV / Raw XBRLをInventory Observation Source候補とする。

Initial Cross-company Validationでは、
以下7社を対象にInventory関連Factの取得構造を確認した。

* ROHM
* Fuji Electric
* Sanken Electric
* Torex Semiconductor
* Kioxia Holdings
* Tokyo Electron
* Renesas Electronics

Initial Validation Result：

```text
EDINET Inventory Acquisition Feasibility
=
PASS
```

確認済みEvidence：

* Document List APIから対象有価証券報告書を実Responseで特定可能
* CSV Available / XBRL Available Flagを確認可能
* XBRL変換CSVからInventory関連Concept Candidateを探索可能
* Raw XBRL InstanceからQName / Namespace / ContextRef / UnitRef / Decimals / Valueを確認可能
* J-GAAPおよびIFRSのInventory Total / Component Factを取得可能
* Consolidated / NonConsolidated Contextを分離可能
* Instant / Duration Factを分離可能
* Company Extension Conceptが存在する
* Component SumとReported Inventory TotalをCross-check可能

したがって、
EDINET / XBRL-based Acquisitionは単なるFeasibility Research Candidateではなく、

```text
Prototype Dataset Source Candidate
```

へ昇格する。

ただし、
Production Source正式採用はHistorical Coverage、
Quarterly Filing Coverage、Failure Handling、
Taxonomy Version差およびOperational Costを追加Validationした後に判断する。

---

## Priority 4：J-Quants Premium

以下の場合のみ再検討する。

* Inventory ComponentのInvestment Contributionが高い
* IR / EDINET取得コストが高い
* Premium Plan追加コストを正当化できる
* 他KnowledgeでもFinancial Statement Dataを広く利用する

Premium Planへ移行するためにKnowledgeを採用してはならない。

Knowledge Contributionが高い場合に、
Data Costを再評価する。

---

# 6. Candidate Inventory Observations（在庫観測候補）

| Observation                        | Definition |     Initial Priority |
| ---------------------------------- | ---------- | -------------------: |
| Inventory                          | 棚卸資産絶対額    |               Medium |
| Inventory Growth                   | 棚卸資産増減率    |                 High |
| Inventory / Revenue                | 在庫売上比率     |            Very High |
| Inventory Days                     | 在庫日数       |                 High |
| Inventory Change vs Revenue Change | 在庫・売上変化差   |            Very High |
| Segment Inventory                  | Segment在庫  | High where available |
| Inventory Write-down               | 在庫評価損      |               Medium |
| Customer Inventory Commentary      | 顧客在庫コメント   |    High Experimental |
| Destocking Commentary              | 在庫削減コメント   |    High Experimental |

---

# 7. Inventory Absolute Value（在庫絶対額）

## Candidate Definition

企業が開示するInventory
（棚卸資産）残高をRaw Observationとして保存する。

```text
Inventory_t
```

## Initial Judgment

在庫絶対額単独では、
企業規模差の影響が大きい。

したがって、

```text
Inventory Absolute Value
```

を直接Company Ranking Featureとして使用しない。

Primary Usage：

* Derived Metric Calculation
* Within-company Historical Context

---

# 8. Inventory Growth（在庫増減率）

## Candidate Formula

```text
InventoryGrowthYoY
=
(Inventory_t - Inventory_t-4Q)
/
Inventory_t-4Q
```

四半期データを前提とする場合、
前年同期比をPrimary Candidateとする。

## Alternative Candidate

```text
InventoryGrowthQoQ
=
(Inventory_t - Inventory_t-1Q)
/
Inventory_t-1Q
```

QoQは短期変化を把握できるが、
季節性の影響を受ける可能性がある。

## Initial Decision

```text
YoY = Primary Candidate
QoQ = Experimental Candidate
```

Validationで変更可能とする。

---

# 9. Inventory / Revenue（在庫売上比率）

## Candidate Formula

```text
InventoryToRevenue
=
Inventory_t
/
RevenueReference_t
```

ただし、

```text
RevenueReference_t
```

の定義を固定しなければならない。

---

## Candidate A：Quarter Revenue

```text
Inventory_t
/
QuarterRevenue_t
```

### Concern

Balance Sheetは期末Stock
（時点残高）である。

RevenueはQuarter Flow
（期間フロー）である。

単純比率は計算できるが、
四半期季節性の影響を受ける可能性がある。

---

## Candidate B：Trailing Twelve Month Revenue

```text
InventoryToRevenueTTM
=
Inventory_t
/
RevenueTTM_t
```

### Positive Point

季節性を一定程度抑制できる可能性がある。

### Concern

InventoryとRevenueの時間尺度が異なる。

---

## Candidate C：Annualized Quarter Revenue

```text
InventoryToAnnualizedRevenue
=
Inventory_t
/
(QuarterRevenue_t × 4)
```

### Concern

Quarter Revenueを単純Annualizeすると、
季節性・急変時に歪む可能性がある。

---

## Initial Research Decision

以下を並行Validationする。

```text
Inventory / Quarter Revenue
Inventory / TTM Revenue
```

Annualized Quarter Revenueは初期優先度を下げる。

Full Dataset結果を見て最適式を選択してはならない。

Training / Validation Window内で比較する。

---

# 10. Inventory Days（在庫日数）

## Standard Concept

一般的なInventory Daysは、
InventoryとCost of Sales
（売上原価）を用いて算出する。

Candidate Formula：

```text
InventoryDays
=
AverageInventory
/
CostOfSales
×
PeriodDays
```

---

## Average Inventory Candidate

```text
AverageInventory
=
(InventoryPeriodStart + InventoryPeriodEnd)
/
2
```

## Quarterly Candidate

```text
InventoryDaysQuarter
=
AverageInventoryQuarter
/
QuarterCostOfSales
×
QuarterDays
```

## TTM Candidate

```text
InventoryDaysTTM
=
AverageInventory
/
CostOfSalesTTM
×
365
```

---

## Current Constraint

Cost of Salesの継続取得可能性を確認する必要がある。

現在のJ-Quants Light Planでは、
詳細財務諸表項目をProduction Sourceとして前提にできない。

したがってInventory Daysは、

```text
Conditional Production Candidate
```

とする。

Cost of Sales Sourceを確定できない場合、

初期Production Datasetから除外する。

---

# 11. Inventory Change vs Revenue Change

（在庫変化と売上変化の乖離）

## Research Hypothesis

Inventory Adjustmentの状態は、
Inventory Growth単独より、

```text
Inventory Growth
-
Revenue Growth
```

の相対関係で説明できる可能性がある。

## Candidate Metric

```text
InventoryRevenueGrowthGap
=
InventoryGrowthYoY
-
RevenueGrowthYoY
```

### Example A

```text
Inventory Growth: +20%
Revenue Growth: -10%

Gap: +30pt
```

Inventory Pressure Candidate。

### Example B

```text
Inventory Growth: -15%
Revenue Growth: +5%

Gap: -20pt
```

Inventory Normalization Candidate。

---

## Important Constraint

これは現時点ではInference-based Metric Candidateである。

正方向・負方向の解釈を固定しない。

例えば大幅な在庫削減が、

* 正常化
* 深刻な需要悪化
* Supply Constraint

のいずれである可能性もある。

Revenue、Margin、GuidanceとのValidationが必要。

---

# 12. Candidate Transformation States（変換状態候補）

## State A：Inventory Pressure

```text
Inventory Growth > Revenue Growth
+
Weakening Revenue
+
Weak or Stable-negative Guidance

↓

Inventory Pressure Candidate
```

---

## State B：Inventory Normalization

```text
Inventory Growth Declining
+
Revenue Stabilizing
+
Guidance Stable or Improving

↓

Inventory Normalization Candidate
```

---

## State C：Demand Collapse / Forced Destocking

```text
Inventory Sharp Decline
+
Revenue Sharp Decline
+
Margin Deterioration
+
Weak Guidance

↓

Demand Collapse / Forced Destocking Candidate
```

---

## State D：Demand-backed Inventory Build

```text
Inventory Growth
+
Revenue Growth
+
Positive Guidance
+
Stable Margin

↓

Demand-backed Inventory Build Candidate
```

---

## State E：Uncertain

```text
Conflicting Evidence
or
Insufficient Observation Coverage

↓

Uncertain
```

単純なNeutralへ変換しない。

---

# 13. Validation Targets（検証Target）

## Primary Target A：Future Revenue Growth

Horizons：

* t+1 Quarter
* t+2 Quarters
* t+4 Quarters

最優先Targetとする。

---

## Primary Target B：Future Margin Change

Horizons：

* t+1 Quarter
* t+2 Quarters
* t+4 Quarters

Candidate Metrics：

* Operating Margin Change
* Gross Margin Change
* Segment Margin Change where available

---

## Secondary Target C：Future Guidance Direction

* Next Earnings
* Next Two Earnings

---

## Investment Target D：Future Stock Return

Primary Candidate：

* 20 Trading Days
* 60 Trading Days
* 120 Trading Days

Inventory Knowledgeの採否をStock Return単独で判断しない。

---

# 14. Initial Lag Candidates（初期Lag候補）

| Observation         | Target       | Lag Candidates   |
| ------------------- | ------------ | ---------------- |
| Inventory Growth    | Revenue      | 1Q / 2Q / 4Q     |
| Inventory / Revenue | Revenue      | 1Q / 2Q / 4Q     |
| Inventory Days      | Revenue      | 1Q / 2Q / 4Q     |
| Inventory Growth    | Margin       | 1Q / 2Q / 4Q     |
| Inventory / Revenue | Margin       | 1Q / 2Q / 4Q     |
| Inventory Gap       | Revenue      | 1Q / 2Q / 4Q     |
| Inventory State     | Stock Return | 20D / 60D / 120D |

LagはTraining / Validation Periodで選択する。

Test Periodを見て変更しない。

---

# 15. Baseline Comparison（Baseline比較）

以下を比較する。

## Baseline 0

```text
No Inventory Knowledge
```

## Baseline 1

```text
Inventory Growth only
```

## Candidate 2

```text
Inventory Growth
+
Inventory / Revenue
```

## Candidate 3

```text
Inventory Growth
+
Inventory / Revenue
+
Revenue Growth Gap
```

## Candidate 4

```text
Inventory Component
+
Guidance Direction
```

## Candidate 5

```text
Full Inventory Adjustment State
```

最も複雑なCandidateを自動採用しない。

Simpler Model
（単純モデル）と比較して追加価値を確認する。

---

# 16. Ablation Test（除去テスト）

Full Inventory Componentから、
以下を一つずつ除去する。

```text
- Inventory Growth
- Inventory / Revenue
- Inventory Days
- Inventory Revenue Growth Gap
- Guidance
- Customer Inventory Commentary
```

除去しても結果が変わらないObservationは、
重要度を下げる。

定性的Observationが定量Featureへ追加価値を持たない場合、
Advisor Context専用へ降格する。

---

# 17. Cross-company Validation（企業横断検証）

Initial Acquisition Feasibility Validation Companies：

* ROHM
* Fuji Electric
* Sanken Electric
* Torex Semiconductor
* Kioxia Holdings
* Tokyo Electron
* Renesas Electronics

上記7社について、
EDINET CSV / Raw XBRL上のInventory TotalまたはInventory Component Factを確認した。

この7社は、

```text
Inventory Knowledge Validation Company Universe
```

を正式確定するものではない。

目的は、

```text
Cross-company Inventory Acquisition Structure Validation
```

である。

Power Semiconductor Company Universeは別Researchで正式確定する。

Validationを以下へ分ける。

## Within-company

```text
Company Inventory
→ Same Company Future Revenue
```

## Cross-company

```text
Normalized Inventory Metrics
→ Future Revenue
across Company Universe
```

## Company-specific

企業横断で無効だが、
特定企業で有効な場合、

```text
Company-specific Knowledge
```

とする。

全企業共通Ruleへ昇格しない。

---

# 18. Accounting Definition Risk（会計定義リスク）

企業・会計基準によりInventory項目の定義差が存在する可能性がある。

確認対象：

* Inventories
* Merchandise
* Finished Goods
* Work in Process
* Raw Materials
* Supplies

本Componentの初期共通Observationでは、

```text
Total Inventories
```

を優先する。

Initial 7-company Validationにより、
Inventory Component QNameは固定Schemaではないことを確認した。

Observed Concept Variation Candidate：

```text
MerchandiseAndFinishedGoods
FinishedGoods
WorkInProcess
SemiFinishedProductsAndWorkInProgress
RawMaterials
RawMaterialsAndSupplies
OtherInventories
```

IFRSでは、

```text
jpigp_cor:InventoriesCAIFRS
```

をInventory Total Conceptとして確認した企業がある。

また、
Kioxia HoldingsではInventory Componentに
Company Extension Conceptが存在することを確認した。

したがって、

```text
Inventory Component Extraction
≠
Fixed QName List Only
```

と判断する。

Production Architecture Candidate：

```text
Raw XBRL Fact
↓
Concept Identification
↓
Context Validation
↓
Unit Validation
↓
Semantic Component Mapping
↓
Canonical Inventory Component
```

Canonical Semantic Role Candidate：

```text
FinishedGoods
WorkInProcess
RawMaterials
Other
```

ただし、
このSemantic Mappingは現時点ではArchitecture Finding Candidateであり、
Production Mapping Ruleとして確定しない。

企業固有Taxonomy Extensionに依存する項目を、
QName一致のみでProduction Common Featureへ使用してはならない。

さらに、
Consolidated FactとNonConsolidated Factを混在させてはならない。

Primary Candidate Context：

```text
CurrentYearInstant
Prior1YearInstant
```

以下のようなNonConsolidated Member付きContextは、
Common Consolidated Observationから分離する。

```text
CurrentYearInstant_NonConsolidatedMember
Prior1YearInstant_NonConsolidatedMember
```

また、
Cash Flow上のInventory Change等のDuration Factを、
Balance Sheet Inventory Stockと混同してはならない。

```text
Instant Fact
≠
Duration Fact
```

---

# 19. Quarterly Flow Risk（四半期フロー値リスク）

Quarter RevenueおよびCost of Salesについて、

累計値と単四半期値を混同してはならない。

例：

```text
Q2 YTD Revenue
≠
Q2 Standalone Revenue
```

Standalone Quarterが必要な場合、

```text
Q2 Standalone
=
Q2 YTD
-
Q1 YTD
```

等のDerived Calculationが必要になる可能性がある。

Derived Valueとして明示し、
Transformation Lineageを保持する。

---

# 20. Point-in-Time Requirement（時点整合要件）

Inventory Featureは、

財務資料のPeriod Endではなく、
Disclosure Date / Approved AsOfDate以降のみ使用する。

例：

```text
Inventory Period End:
2025-12-31

Disclosure:
2026-02-05

Prediction:
2026-01-20
```

Prediction時点では使用禁止。

Feature Snapshotは後日再計算して上書きしない。

---

# 21. Data Source Decision（データソース判断）

## Current Decision

J-Quants `/fins/details` を現在のProduction Requirementとしない。

理由：

現在のLight Planでは詳細財務諸表が対象外であるため。

## Initial Path

```text
Existing DB確認
↓
EDINET Source Feasibility確認
↓
Initial 7-company Cross-company Validation
↓
CSV / Raw XBRL Cross-check
↓
Inventory Dataset Prototype Design
↓
Historical / Quarterly Coverage Validation
↓
Knowledge Contribution Validation
↓
Data Cost Review
```

Initial 7-company Cross-company Validationは完了した。

Current Decision：

```text
EDINET Inventory Acquisition Feasibility
=
PASS
```

したがって、
次PhaseではEDINETをPrototype Dataset Source Candidateとして扱う。

ただし、
Production Source正式採用は未決定である。

Inventory KnowledgeのContributionが高い場合のみ、
J-Quants Premium等の有償Sourceを再検討する。

---

# 22. Operational Feasibility Decision（運用可能性判断）

| Metric                       | Current Decision              |
| ---------------------------- | ----------------------------- |
| Inventory Growth             | Strong Candidate              |
| Inventory / Revenue          | Strong Candidate              |
| Inventory Days               | Conditional                   |
| Inventory Revenue Growth Gap | Strong Experimental Candidate |
| Segment Inventory            | Company-specific              |
| Customer Commentary          | Experimental / Advisor        |
| Destocking Commentary        | Experimental / Advisor        |

---

# 23. Validation Result Classification（検証結果分類）

| Status                  | Meaning             |
| ----------------------- | ------------------- |
| Validated               | 複数Window・複数企業で安定    |
| Conditionally Validated | Regime・Company限定    |
| Context Only            | Advisor説明のみ有用       |
| Experimental            | 結果不安定・Evidence不足    |
| Rejected                | Contributionなし      |
| Invalid Test            | LeakageまたはDataset不備 |

---

# 24. Knowledge Importance Update Rule（重要度更新規則）

## Validated

ML・Decision Engine候補。

Initial Importance維持または上昇。

## Conditionally Validated

Scopeを限定する。

例：

```text
Power Semiconductor
+
Inventory Adjustment Regime
```

のみ利用。

## Context Only

Advisor説明専用。

ML Featureから除外。

## Rejected

ML・Company Score・Decision Engineから除外。

Research Importanceが高かったことを理由に残さない。

---

# 25. Independent Reviewer Judgment（独立レビュー判定）

## Research Reviewer

**判定：承認**

Inventory Growth単独ではなく、

* Inventory / Revenue
* Inventory Revenue Growth Gap
* Revenue
* Margin
* Guidance

との組み合わせをValidationする方針を支持する。

特にInventory Declineを無条件にPositiveとしないことを必須とする。

## Engineering / ML Reviewer

**判定：強く承認**

最初のPrototypeでは以下を優先する。

```text
InventoryGrowthYoY
InventoryToRevenueQuarter
InventoryToRevenueTTM
InventoryRevenueGrowthGap
```

Inventory DaysはCost of Sales Source確定後に追加する。

最初からすべてをFeature化しない。

## ADR Reviewer

**判定：承認**

現在のJ-Quants Light Planで取得できない詳細財務項目を、
Production Architectureの必須前提にしない判断を支持する。

Knowledge Contribution確認後にData Source Costを再評価する。

---

# 26. Final Decision（現時点の決定）

Inventory Adjustment Componentの最初のValidation Candidateは、

```text
Inventory Growth YoY
Inventory / Quarter Revenue
Inventory / TTM Revenue
Inventory Revenue Growth Gap
```

とする。

Inventory DaysはCost of Sales取得Source確認までConditionalとする。

J-Quants Premiumを現時点で必須要件としない。

EDINET Initial 7-company Cross-company Validationの結果、
Inventory Totalおよび主要Inventory Componentを
CSV / Raw XBRLから取得・Cross-checkできることを確認した。

したがって、

```text
EDINET
=
Prototype Dataset Source Candidate
```

とする。

Raw XBRL Fact Validationでは、
最低限以下を保持・検証する。

```text
QName
Namespace
ContextRef
UnitRef
Decimals
Raw Value
```

Component Sum Validationでは、
単純なExact Equalityのみを前提にしない。

東京エレクトロンValidationで確認したように、
開示精度およびDecimalsを考慮する必要がある。

Production Validation Candidate：

```text
Reported Inventory Total
vs
Component Sum
↓
Decimals-aware Reconciliation
```

Tolerance Ruleは別SpecificationまたはDataset Designで正式定義する。

Validation結果が低い場合、
Inventory ComponentのImportanceを容赦なく下げる。

Validation結果が安定して高い場合、
有償Data Sourceを含めて取得基盤を再評価する。

---

# 27. Next Actions（次の作業）

1. Initial 7-company EDINET Inventory Acquisition Feasibility ValidationをResearch Evidenceとして固定する。
2. Inventory Raw Observation / Semantic Component MappingのResearch Asset境界を定義する。
3. ROHMをReference CompanyとしてHistorical Filing Coverageを確認する。
4. Quarterly FilingにおけるInventory Observation Coverageを確認する。
5. Inventory / Revenue算出用Revenue Definitionを確定する。
6. Decimals-aware Component Reconciliation Rule Candidateを設計する。
7. Power Semiconductor Company Universe Researchへ進む。
8. Prototype Dataset設計はCatalog / DDL前には実装しない。

---

# 28. EDINET Initial Cross-company Validation Result

## Validation Scope

Initial EDINET Inventory Acquisition Feasibility Validationでは、
以下7社の有価証券報告書を対象とした。

| Company | Accounting / Structure Observation |
| --- | --- |
| ROHM | J-GAAP Inventory Component Candidate |
| Fuji Electric | J-GAAP / Consolidated and NonConsolidated Context Variation |
| Sanken Electric | J-GAAP Inventory Component and Write-down Fact |
| Torex Semiconductor | J-GAAP / Thousand-yen Precision Fact |
| Kioxia Holdings | IFRS / Inventory Total / Company Extension Component |
| Tokyo Electron | J-GAAP / Component Sum Precision Difference Candidate |
| Renesas Electronics | IFRS / Inventory Total and Three-component Exact Reconciliation |

## Validation Result

```text
Initial 7-company Cross-company Inventory Validation
=
CLOSED / PASS
```

## Evidence-based Findings

### Finding 1：Inventory Total Acquisition is Feasible

J-GAAP / IFRS企業を含むInitial Sampleで、
Inventory TotalまたはInventory Totalを裏付けるComponent Factを確認できた。

IFRS Sampleでは、

```text
jpigp_cor:InventoriesCAIFRS
```

をInventory Total Conceptとして確認した。

### Finding 2：Inventory Component QName is not a Fixed Schema

企業・会計基準・開示構造により、
Inventory Component ConceptにVariationが存在する。

したがって、
Fixed QName ListのみをExtraction Architectureとしない。

### Finding 3：Semantic Mapping Layer is Required

Raw Conceptを直接ML Feature名へ変換せず、
Semantic Component Mapping Layerを設けるArchitecture Candidateを採用する。

### Finding 4：Context Validation is Mandatory

以下を分離する。

```text
Consolidated
vs
NonConsolidated

Current
vs
Prior

Instant
vs
Duration
```

ContextRef文字列の単純一致のみを最終Production Ruleとするかは、
追加Validation後に判断する。

### Finding 5：Unit and Decimals are Validation Evidence

Inventory Fact Extractionでは、

```text
UnitRef
Decimals
```

をRaw Fact Evidenceとして保持する。

Component SumとReported TotalのReconciliationでは、
Decimals-aware Validationが必要である。

### Finding 6：CSV and Raw XBRL Cross-check is Required during Research Validation

Initial Researchでは、

```text
XBRL-converted CSV
↓
Candidate Discovery
↓
Raw XBRL Fact Cross-check
```

の順序が有効であった。

Production Runtimeで常に二重取得することを意味しない。

Research Validation ProcessとProduction Acquisition Architectureを混同しない。

## Reviewer Gate

```text
EDINET Inventory Acquisition Feasibility
=
PASS

Production Source Final Adoption
=
NOT YET DECIDED
```

次Phaseでは、
Historical / Quarterly CoverageとDataset Design Requirementを確認する。
