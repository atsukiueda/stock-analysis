# EDINET Inventory Cross-company Validation Sanken Electric Result

## 1. Document Purpose

本書は、EDINET Inventory Cross-company Validation Initial SampleにおけるSlot 2 Company、

```text
サンケン電気株式会社
Sanken Electric Co., Ltd.
```

について、最新Annual Securities ReportのEDINET CSV及びRaw XBRLを確認し、Inventory Extraction Structureを分類したResearch Result Artifactである。

本書の目的はサンケン電気のInvestment Evaluationを行うことではない。

目的は以下である。

> ROHM及び富士電機で確認したJapanese GAAP Inventory Component Structure及びCSV First Architecture Candidateが、Power Semiconductor-focused Companyであるサンケン電気でも成立するかを検証する。

Status：

```text
Research Artifact
Cross-company Validation Result
Company Validation Completed
Research Reviewer Evaluated
Production Architecture Not Approved
```

---

# 2. Validation Company

```text
Company:
サンケン電気株式会社

English Name:
Sanken Electric Co., Ltd.

Security Code:
67070

EDINET Code:
E01790
```

Validation Slot：

```text
Slot 2
Power Semiconductor Contrast
```

Company Selection時点では以下のStatusであった。

```text
Conditional Accept
```

Condition：

```text
Latest EDINET annual filing availability
Current accounting standard
Consolidated financial statements availability
```

本ValidationによりMandatory Conditionを確認した。

Final Slot Status：

```text
ACCEPT
```

---

# 3. Target Filing

EDINET Document List API実Responseから以下を確認した。

```text
Document ID:
S100YI8X

Document Description:
有価証券報告書－第109期
(2025/04/01－2026/03/31)

Document Type:
120

Period Start:
2025-04-01

Period End:
2026-03-31

Submitted At:
2026-06-24 15:30

Withdrawal Status:
0

Disclosure Status:
0

CSV Flag:
1

XBRL Flag:
1
```

Result：

```text
Filing Discovery:
PASS
```

Filing IdentityはEDINET Document List API実ResponseをEvidenceとする。

---

# 4. Accounting Standard Validation

Consolidated Audit Opinionでは、連結財務諸表について、

```text
我が国において一般に公正妥当と認められる企業会計の基準
```

への準拠が確認された。

Classification：

```text
Japanese GAAP
```

Result：

```text
PASS
```

Company Selection時点の、

```text
Japanese GAAP Candidate
```

はCurrent Annual Filing Evidenceによって確認された。

Slot 2 Conditional Accept Conditionは解除する。

---

# 5. CSV ZIP Structure

EDINET CSV ZIPでは以下3 Entryを確認した。

```text
XBRL_TO_CSV/
jpaud-aai-cc-001_E01790-000_2026-03-31_01_2026-06-24.csv

XBRL_TO_CSV/
jpaud-aar-cn-001_E01790-000_2026-03-31_01_2026-06-24.csv

XBRL_TO_CSV/
jpcrp030000-asr-001_E01790-000_2026-03-31_01_2026-06-24.csv
```

Inventory Financial Factsは以下のAnnual Securities Report CSV内で確認した。

```text
jpcrp030000-asr-001
```

Result：

```text
CSV Acquisition:
PASS

Annual Securities Report CSV Identification:
PASS
```

---

# 6. CSV Inventory Source Facts

CSVから以下のConsolidated Inventory Component Factsを確認した。

## 6.1 Merchandise and Finished Goods

Concept：

```text
jppfs_cor:MerchandiseAndFinishedGoods
```

Prior：

```text
Context:
Prior1YearInstant

Consolidation:
Consolidated

Period Type:
Instant

Unit:
JPY

Value:
11,911,000,000
```

Current：

```text
Context:
CurrentYearInstant

Consolidation:
Consolidated

Period Type:
Instant

Unit:
JPY

Value:
15,132,000,000
```

---

## 6.2 Work in Process

Concept：

```text
jppfs_cor:WorkInProcess
```

Prior：

```text
Context:
Prior1YearInstant

Consolidation:
Consolidated

Period Type:
Instant

Unit:
JPY

Value:
24,810,000,000
```

Current：

```text
Context:
CurrentYearInstant

Consolidation:
Consolidated

Period Type:
Instant

Unit:
JPY

Value:
26,462,000,000
```

---

## 6.3 Raw Materials and Supplies

Concept：

```text
jppfs_cor:RawMaterialsAndSupplies
```

Prior：

```text
Context:
Prior1YearInstant

Consolidation:
Consolidated

Period Type:
Instant

Unit:
JPY

Value:
6,949,000,000
```

Current：

```text
Context:
CurrentYearInstant

Consolidation:
Consolidated

Period Type:
Instant

Unit:
JPY

Value:
5,928,000,000
```

---

# 7. Inventory Structure Classification

Validation Scopeでは以下3 Component Source Factsを確認した。

```text
MerchandiseAndFinishedGoods
WorkInProcess
RawMaterialsAndSupplies
```

Consolidated Total Inventoryとして採用可能な単一Numeric Source Factは確認していない。

Classification：

```text
Type B
Component Facts Only
```

Result：

```text
PASS
```

ROHM及び富士電機と同一のStandard Taxonomy Component Patternである。

---

# 8. Raw XBRL Cross-check

Target Raw XBRL Instance：

```text
XBRL/PublicDoc/
jpcrp030000-asr-001_E01790-000_2026-03-31_01_2026-06-24.xbrl
```

CSVで確認した6 Inventory Component FactsをRaw XBRLと比較した。

## Merchandise and Finished Goods

Prior：

```text
QName:
jppfs_cor:MerchandiseAndFinishedGoods

ContextRef:
Prior1YearInstant

UnitRef:
JPY

Decimals:
-6

Value:
11,911,000,000
```

Current：

```text
ContextRef:
CurrentYearInstant

UnitRef:
JPY

Decimals:
-6

Value:
15,132,000,000
```

Result：

```text
MATCH
```

---

## Work in Process

Prior：

```text
QName:
jppfs_cor:WorkInProcess

ContextRef:
Prior1YearInstant

UnitRef:
JPY

Decimals:
-6

Value:
24,810,000,000
```

Current：

```text
ContextRef:
CurrentYearInstant

UnitRef:
JPY

Decimals:
-6

Value:
26,462,000,000
```

Result：

```text
MATCH
```

---

## Raw Materials and Supplies

Prior：

```text
QName:
jppfs_cor:RawMaterialsAndSupplies

ContextRef:
Prior1YearInstant

UnitRef:
JPY

Decimals:
-6

Value:
6,949,000,000
```

Current：

```text
ContextRef:
CurrentYearInstant

UnitRef:
JPY

Decimals:
-6

Value:
5,928,000,000
```

Result：

```text
MATCH
```

---

# 9. CSV / XBRL Match Result

```text
Target Facts:
6

Matched Facts:
6

Mismatch:
0
```

Final Result：

```text
6 / 6 MATCH
```

Validation：

```text
Concept:
MATCH

Context:
MATCH

Unit:
MATCH

Value:
MATCH

Decimals:
-6 Confirmed
```

Reviewer Decision：

```text
CSV Primary Candidate:
PASS
```

---

# 10. Context Validation

Raw XBRLには同一Inventory Conceptについて、Consolidated及びNon-consolidated Contextが存在する。

Example：

```text
jppfs_cor:MerchandiseAndFinishedGoods
```

Consolidated Current：

```text
ContextRef:
CurrentYearInstant

Value:
15,132,000,000
```

Non-consolidated Current：

```text
ContextRef:
CurrentYearInstant_NonConsolidatedMember

Value:
14,175,000,000
```

したがって、

```text
Concept QName
```

のみではTarget Factを一意に決定できない。

Required Extraction Dimensions：

```text
Concept
Context
Consolidation Semantics
Period Semantics
Unit
```

Research Finding：

```text
Context validation is mandatory.
```

---

# 11. Excluded Inventory-related Facts

以下をInventory Balance Sheet Stock ValueとしてRejectする。

## Cash Flow Inventory Change

```text
jppfs_cor:DecreaseIncreaseInInventoriesOpeCF
```

Characteristics：

```text
Duration
Cash Flow
Inventory Change
```

Classification：

```text
REJECT
```

---

## Inventory Write-down

```text
jpcrp_cor:WriteDownsOfInventories
```

Characteristics：

```text
Duration
Inventory Write-down
```

Classification：

```text
REJECT AS INVENTORY BALANCE
```

---

## Inventory Note TextBlock

```text
jpcrp_cor:NotesRegardingWriteDownsOfInventoriesTextBlock
```

Characteristics：

```text
TextBlock
Inventory Accounting Note
```

Classification：

```text
REJECT AS DIRECT NUMERIC INVENTORY BALANCE FACT
```

Research Finding：

```text
Inventory Keyword Match
≠
Inventory Balance Fact
```

---

# 12. Derived Consolidated Inventory Observation

Three Consolidated Component Source Factsを合算する。

## Prior

```text
11,911,000,000
+
24,810,000,000
+
6,949,000,000
=
43,670,000,000 JPY
```

## Current

```text
15,132,000,000
+
26,462,000,000
+
5,928,000,000
=
47,522,000,000 JPY
```

Derived Total Candidate：

```text
Prior:
43,670,000,000 JPY

Current:
47,522,000,000 JPY
```

Derived Inventory YoY Candidate：

```text
47,522 / 43,670 - 1
≈ +8.82%
```

Evidence Classification：

```text
Component Values:
Source Facts

Inventory Total:
Derived Observation

Inventory YoY:
Derived Observation
```

Investment Interpretation：

```text
NOT EVALUATED
```

---

# 13. Precision and Rounding Research Finding

本Validationでは重要なPrecision Issueを確認した。

Individual Financial Statement Audit TextBlockでは、2026年3月31日時点の棚卸資産について以下が記載されている。

```text
Reported Inventory:
20,942百万円
```

構成項目：

```text
商品及び製品
仕掛品
原材料及び貯蔵品
```

Raw XBRL上のCurrent Non-consolidated Component Factsは以下である。

```text
MerchandiseAndFinishedGoods:
14,175,000,000

WorkInProcess:
5,403,000,000

RawMaterialsAndSupplies:
1,363,000,000
```

Component Sum：

```text
14,175
+
5,403
+
1,363
=
20,941百万円
```

Reported Text Value：

```text
20,942百万円
```

Difference：

```text
1百万円
```

---

# 14. Raw XBRL Precision Evidence

対象3 Component Source Factsはいずれも、

```text
Decimals:
-6
```

である。

Therefore：

```text
Source Fact Precision Candidate:
Million JPY level
```

## Important

CSV及びRaw XBRL Valueは一致している。

```text
CSV ↔ XBRL:
MATCH
```

したがって確認されたDifferenceは、

```text
CSV Error
```

または、

```text
CSV ↔ XBRL Mismatch
```

ではない。

---

# 15. Rounding Difference Classification

## Fact

```text
Reported Display Total:
20,942百万円

Component Fact Sum:
20,941百万円

Difference:
1百万円

Component Decimals:
-6
```

## Inference

Source Component Factのprecision及びrounding semanticsにより、Component SumとReported Display Totalの間に1百万円差が発生している可能性がある。

Classification：

```text
Rounding / Precision Difference Candidate
```

Status：

```text
Inference
Not Proven General Rule
```

## Reviewer Decision

以下を禁止する。

```text
Derived Component Sum must always equal
a displayed reported total exactly.
```

Exact EqualityをGeneric Validation Ruleとして採用してはならない。

---

# 16. Architecture Implication of Precision

Derived Financial Observationを構成する場合、Source LineageにはValueだけでなくPrecision Metadataを保持する必要がある可能性がある。

Candidate Metadata：

```text
Source Concept
Source Raw Value
Source Decimals
Source Unit

Calculation Precision
Calculation Formula
Formula Version

Derived Value

Reported Total if available
Reported Total Source

Difference
Tolerance Evaluation
Difference Classification
```

## Important

本書ではProduction Tolerance Ruleを決定しない。

例えば、

```text
Allow difference <= 1 million JPY
```

のようなRuleをHardcodeしてはならない。

Toleranceは以下を考慮して別Researchで定義する必要がある。

```text
Decimals
Number of Components
Calculation Semantics
Source Unit
Reported Unit
Rounding Method
Materiality
```

---

# 17. ROHM and Fuji Electric Comparison

ROHM：

```text
Japanese GAAP
Type B

MerchandiseAndFinishedGoods
WorkInProcess
RawMaterialsAndSupplies

CSV / XBRL:
MATCH
```

Fuji Electric：

```text
Japanese GAAP
Type B

MerchandiseAndFinishedGoods
WorkInProcess
RawMaterialsAndSupplies

CSV / XBRL:
6 / 6 MATCH
```

Sanken Electric：

```text
Japanese GAAP
Type B

MerchandiseAndFinishedGoods
WorkInProcess
RawMaterialsAndSupplies

CSV / XBRL:
6 / 6 MATCH
```

Cross-company Finding：

```text
3 Japanese GAAP Companies
show the same standard
three-component inventory pattern.
```

Evidence Strength：

```text
SUPPORTED BY THREE COMPANY VALIDATIONS
```

Limitation：

```text
All three companies are related to
power / semiconductor business clusters.
```

Therefore：

```text
Business Model Cluster Bias remains.
```

---

# 18. CSV First Architecture Evidence

サンケン電気ではCSVから以下を取得できた。

```text
Concept QName
Label
Context
Consolidation Classification
Period Type
Unit
Value
```

6 Target FactについてRaw XBRLと一致した。

Current Architecture Candidate：

```text
CSV Primary
+
XBRL Validation / Fallback
```

Sanken Result：

```text
CSV Primary Candidate:
PASS
```

Cross-company State：

```text
ROHM:
PASS

Fuji Electric:
PASS

Sanken Electric:
PASS
```

Status：

```text
STRONGLY SUPPORTED WITHIN CURRENT SAMPLE CLUSTER

NOT APPROVED AS GENERIC PRODUCTION ARCHITECTURE
```

---

# 19. Research Reviewer Evaluation

## Filing Identity

```text
PASS
```

## Accounting Standard

```text
PASS
Japanese GAAP
```

## Slot 2 Conditional Accept

```text
CONDITION SATISFIED
ACCEPT
```

## CSV Acquisition

```text
PASS
```

## Inventory Fact Identification

```text
PASS
```

## Context Validation

```text
PASS
```

## Raw XBRL Cross-check

```text
PASS
6 / 6 MATCH
```

## Inventory Structure Classification

```text
PASS
Type B
```

## Source Fact / Derived Observation Separation

```text
PASS
```

## Precision / Rounding Finding

```text
NEW RESEARCH FINDING
```

## Production Architecture

```text
NOT APPROVED
```

---

# 20. Final Research Reviewer Decision

```text
SANKEN ELECTRIC VALIDATION
PASS
```

Inventory Structure：

```text
TYPE B
COMPONENT FACTS ONLY
```

CSV First Architecture Candidate：

```text
SUPPORTED
```

Raw XBRL：

```text
VALIDATION SUCCESS
```

Precision Finding：

```text
DERIVED OBSERVATION
PRECISION / ROUNDING GOVERNANCE REQUIRED
```

Production Adoption：

```text
NOT APPROVED
```

---

# 21. Research Backlog Candidate

本Validationで以下のResearch Backlog Candidateが発生した。

```text
Derived Financial Observation
Precision and Rounding Governance
```

Research Questions：

```text
How should XBRL decimals be preserved?

How should derived calculation precision be determined?

How should component sum and reported total differences be evaluated?

Should reported total and derived total coexist?

How should tolerance depend on source decimals?

How should calculation lineage record rounding?
```

Status：

```text
BACKLOG CANDIDATE
```

本Cross-company Validationを中断して即Researchしない。

Current Validation Sampleを継続する。

---

# 22. Current Cross-company Validation State

```text
Reference:
ROHM
COMPLETED
PASS
TYPE B

Slot 1:
Fuji Electric
COMPLETED
PASS
TYPE B

Slot 2:
Sanken Electric
COMPLETED
PASS
TYPE B

Slot 3:
Torex Semiconductor
NEXT

Slot 4:
Kioxia Holdings
NOT STARTED

Slot 5:
Tokyo Electron
NOT STARTED

Slot 6:
Renesas Electronics
NOT STARTED
```

Current Structure Evidence：

```text
ROHM:
Type B

Fuji Electric:
Type B

Sanken Electric:
Type B
```

Structure Saturation：

```text
NOT REACHED
```

Reason：

```text
Business Model Cluster Bias remains.
IFRS not yet validated.
Equipment company not yet validated.
Analog-focused company not yet validated.
```

---

# 23. Exact Next Task

次のTaskは以下とする。

```text
Torex Semiconductor EDINET Inventory Validation
```

Purpose：

> Japanese GAAPでありながら、Power Device ManufacturerではなくAnalog / Power Management ICを中心とする企業でInventory Structure Variationを確認する。

Mandatory First Gate：

```text
Latest Annual Filing Discovery
Company Identity
Security Code
EDINET Code
Document ID
Document Type
Period
Submitted At
CSV Flag
XBRL Flag
Accounting Standard
```

Important：

```text
ROHM
Fuji Electric
Sanken Electric
```

で確認した3 Component PatternをTorexへ事前適用しない。

Torex Validationは、

```text
Business Model Cluster Bias
```

を低減する最初のValidationである。
