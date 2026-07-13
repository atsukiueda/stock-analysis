# EDINET Inventory Cross-company Validation Fuji Electric Result

## 1. Document Purpose

本書は、EDINET Inventory Cross-company Validation Initial SampleにおけるSlot 1 Company、

```text
富士電機株式会社
Fuji Electric Co., Ltd.
```

について、最新Annual Securities ReportのEDINET CSV及びRaw XBRLを確認し、Inventory Extraction Structureを分類したResearch Result Artifactである。

本書の目的は富士電機のInvestment Evaluationを行うことではない。

目的は以下である。

> ROHM Prototypeで確認したInventory Extraction Structure及びCSV First Architecture Candidateが、異なるCorporate Structureを持つJapanese GAAP Companyでも成立するかを検証する。

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
富士電機株式会社

English Name:
Fuji Electric Co., Ltd.

Security Code:
65040

EDINET Code:
E01740
```

Validation Slot：

```text
Slot 1
Power Semiconductor Reference
```

Business Structure Pre-screening：

```text
Power Semiconductor
Automotive Power Semiconductor
IGBT
SiC

Diversified Corporate Structure
```

Important：

```text
Company-level Inventory
≠
Semiconductor Segment Inventory
```

Company-level Inventory FactをSemiconductor Inventoryとして解釈しない。

---

# 3. Target Filing

EDINET Document List API実Responseから以下を確認した。

```text
Document ID:
S100YEEB

Document Description:
有価証券報告書－第150期
(2025/04/01－2026/03/31)

Document Type:
120

Period Start:
2025-04-01

Period End:
2026-03-31

Submitted At:
2026-06-19 15:00

Withdrawal Status:
0

Disclosure Status:
0

CSV Flag:
1

XBRL Flag:
1
```

Filing IdentityはEDINET API実ResponseをEvidenceとする。

EDINET Code及びDocument IDを推測していない。

---

# 4. Accounting Standard Validation

Annual Securities Report内のConsolidated Audit Opinionでは、Consolidated Financial Statementsについて、

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

Pre-screening Accounting Standard CandidateとEDINET Filing Evidenceは整合した。

---

# 5. CSV ZIP Structure

EDINET CSV ZIPでは以下3 Entryを確認した。

```text
XBRL_TO_CSV/
jpaud-aai-cc-001_E01740-000_2026-03-31_01_2026-06-19.csv

XBRL_TO_CSV/
jpaud-aar-cn-001_E01740-000_2026-03-31_01_2026-06-19.csv

XBRL_TO_CSV/
jpcrp030000-asr-001_E01740-000_2026-03-31_01_2026-06-19.csv
```

Inventory Financial Factsは、

```text
jpcrp030000-asr-001
```

CSV内で確認した。

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

## Merchandise and Finished Goods

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
84,472,000,000
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
98,282,000,000
```

---

## Work in Process

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
55,156,000,000
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
59,797,000,000
```

---

## Raw Materials and Supplies

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
99,021,000,000
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
98,994,000,000
```

---

# 7. Inventory Structure Classification

CSV Researchでは以下3 Component Factを確認した。

```text
MerchandiseAndFinishedGoods
WorkInProcess
RawMaterialsAndSupplies
```

Validation Scope内では、Consolidated Total Inventory Source Factを確認していない。

Classification：

```text
Type B
Component Facts Only
```

Result：

```text
PASS
```

Important：

```text
Type B
does not mean
Inventory Total is unavailable.
```

Component Source FactsからTotal Candidateを算出可能である。

ただし算出値はSource Factではない。

---

# 8. Raw XBRL Cross-check

CSVで確認した6 FactについてRaw XBRL InstanceをCross-checkした。

Target Instance：

```text
XBRL/PublicDoc/
jpcrp030000-asr-001_E01740-000_2026-03-31_01_2026-06-19.xbrl
```

## Merchandise and Finished Goods

```text
QName:
jppfs_cor:MerchandiseAndFinishedGoods

Prior ContextRef:
Prior1YearInstant

Prior UnitRef:
JPY

Prior Decimals:
-6

Prior Value:
84,472,000,000
```

```text
Current ContextRef:
CurrentYearInstant

Current UnitRef:
JPY

Current Decimals:
-6

Current Value:
98,282,000,000
```

Result：

```text
MATCH
```

---

## Work in Process

```text
QName:
jppfs_cor:WorkInProcess

Prior ContextRef:
Prior1YearInstant

Prior UnitRef:
JPY

Prior Decimals:
-6

Prior Value:
55,156,000,000
```

```text
Current ContextRef:
CurrentYearInstant

Current UnitRef:
JPY

Current Decimals:
-6

Current Value:
59,797,000,000
```

Result：

```text
MATCH
```

---

## Raw Materials and Supplies

```text
QName:
jppfs_cor:RawMaterialsAndSupplies

Prior ContextRef:
Prior1YearInstant

Prior UnitRef:
JPY

Prior Decimals:
-6

Prior Value:
99,021,000,000
```

```text
Current ContextRef:
CurrentYearInstant

Current UnitRef:
JPY

Current Decimals:
-6

Current Value:
98,994,000,000
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
Raw XBRL Confirmed
```

Result：

```text
CSV Primary Candidate:
PASS
```

---

# 10. Context Ambiguity Finding

Raw XBRLには同一Inventory ConceptについてConsolidated及びNon-consolidated Contextが存在した。

Example：

```text
jppfs_cor:WorkInProcess
```

Consolidated：

```text
ContextRef:
CurrentYearInstant

Value:
59,797,000,000
```

Non-consolidated：

```text
ContextRef:
CurrentYearInstant_NonConsolidatedMember

Value:
38,448,000,000
```

したがって、

```text
Concept Match Only
```

ではExtraction Targetを一意に決定できない。

Required Validation Dimension Candidate：

```text
Concept
Context
Consolidation Semantics
Period Semantics
Unit
```

Research Finding：

> Context validation is mandatory even when a standard taxonomy concept is used.

---

# 11. False Positive Candidate Finding

Inventory Candidate Searchでは以下も検出された。

```text
jppfs_cor:DecreaseIncreaseInInventoriesOpeCF
```

Characteristics：

```text
Duration
Cash Flow
Inventory Change
```

これはBalance Sheet Inventory Factではない。

Classification：

```text
REJECT
```

---

以下も検出された。

```text
jpcrp_cor:WriteDownsOfInventories
```

Characteristics：

```text
Duration
Inventory Write-down
```

これはInventory Balanceではない。

Classification：

```text
REJECT
```

---

以下も検出された。

```text
jpcrp_cor:NotesRegardingWriteDownsOfInventoriesTextBlock
```

Characteristics：

```text
TextBlock
Inventory Note
```

これはNumeric Inventory Balance Factではない。

Classification：

```text
REJECT AS DIRECT INVENTORY BALANCE FACT
```

Research Finding：

```text
Inventory Keyword Match
≠
Inventory Balance Fact
```

---

# 12. Japanese Label False Positive Finding

Japanese Keyword Searchでは、

```text
商品
製品
```

によりInventoryとは異なるFact及びTextBlockも検出された。

Examples：

```text
Financial Service Providers
Product Warranty Provision
Audit TextBlock
Business Description TextBlock
```

したがってJapanese Label Searchは、

```text
Candidate Discovery
```

には使用可能である。

しかし、

```text
Production Extraction Rule
```

としては使用できない。

Result：

```text
Japanese Keyword Search:
Research Discovery Only
```

---

# 13. Derived Inventory Observation

Three Component Source Facts：

Prior：

```text
84,472,000,000
+
55,156,000,000
+
99,021,000,000
=
238,649,000,000 JPY
```

Current：

```text
98,282,000,000
+
59,797,000,000
+
98,994,000,000
=
257,073,000,000 JPY
```

Derived Total Candidate：

```text
Prior:
238,649,000,000 JPY

Current:
257,073,000,000 JPY
```

Derived Inventory YoY Candidate：

```text
+7.72%
```

Classification：

```text
Component Values:
Source Facts

Inventory Total:
Derived Observation

Inventory YoY:
Derived Observation
```

Important：

```text
Derived Observation
≠
Source Fact
```

---

# 14. Investment Interpretation Boundary

富士電機は複数Segmentを持つ。

```text
Energy
Industry
Semiconductor
Food Distribution
Other
```

したがって、

```text
Consolidated Inventory YoY +7.72%
```

を、

```text
Power Semiconductor Inventory YoY +7.72%
```

と解釈してはならない。

Rejected Interpretation：

```text
Power semiconductor inventory increased 7.72%.
```

Permitted Observation：

```text
Fuji Electric consolidated inventory
derived from the validated three component facts
increased approximately 7.72% year over year.
```

Semiconductor Demand Interpretationには追加Evidenceが必要である。

Candidate Additional Evidence：

```text
Segment Information
Semiconductor Segment Disclosure
Inventory Notes
Production Information
Shipment Information
Management Discussion
Integrated Report
Earnings Presentation
```

---

# 15. ROHM Comparison

ROHM Prototype：

```text
Accounting Standard:
Japanese GAAP

Inventory Structure:
Type B

Concepts:
MerchandiseAndFinishedGoods
WorkInProcess
RawMaterialsAndSupplies

CSV / XBRL:
MATCH
```

Fuji Electric：

```text
Accounting Standard:
Japanese GAAP

Inventory Structure:
Type B

Concepts:
MerchandiseAndFinishedGoods
WorkInProcess
RawMaterialsAndSupplies

CSV / XBRL:
6 / 6 MATCH
```

Cross-company Finding：

```text
2 Japanese GAAP Companies
show the same standard
three-component inventory pattern.
```

Evidence Strength：

```text
SUPPORTED BY TWO COMPANY VALIDATIONS
```

Architecture Status：

```text
PROMISING
NOT PROVEN GENERIC
```

---

# 16. Architecture Implication

Current Evidence supports the following Architecture Candidate.

```text
EDINET Document Discovery
↓
CSV ZIP Acquisition
↓
Annual Securities Report CSV Identification
↓
Standard Inventory Concept Candidate Search
↓
Context Validation
↓
Unit Validation
↓
Component Fact Collection
↓
Derived Total Calculation
↓
Derived YoY Calculation
```

Raw XBRL Candidate Role：

```text
Validation
Fallback
Exception Investigation
```

Current Architecture Candidate：

```text
CSV Primary
+
XBRL Validation / Fallback
```

Status：

```text
SUPPORTED
NOT APPROVED FOR PRODUCTION
```

---

# 17. Research Reviewer Evaluation

## Filing Identity

```text
PASS
```

EDINET API実Responseから確認した。

## Accounting Standard

```text
PASS
Japanese GAAP
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

## Structure Classification

```text
PASS
Type B
```

## Evidence Separation

```text
PASS
```

Source Fact及びDerived Observationを分離した。

## Investment Interpretation Boundary

```text
PASS
```

Consolidated InventoryをSemiconductor Segment Inventoryとして解釈していない。

---

# 18. Final Research Reviewer Decision

```text
FUJI ELECTRIC VALIDATION
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

Production Architecture：

```text
NOT APPROVED
```

---

# 19. Current Cross-company Validation State

```text
Reference Company:
ROHM
COMPLETED

Slot 1:
Fuji Electric
COMPLETED
PASS
TYPE B

Slot 2:
Sanken Electric
NEXT

Slot 3:
Torex Semiconductor
NOT STARTED

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

Current Evidence：

```text
ROHM:
Type B

Fuji Electric:
Type B
```

Structure Saturation：

```text
NOT REACHED
```

---

# 20. Exact Next Task

次のTaskは以下とする。

```text
Sanken Electric EDINET Inventory Validation
```

Mandatory First Gate：

```text
Latest Annual Filing Discovery
Company Identity
EDINET Code
Security Code
Document ID
Document Type
Period
CSV Flag
XBRL Flag
Accounting Standard
```

Important：

```text
Sanken Electric Slot 2
=
Conditional Accept
```

したがってInventory Structure Classificationより先に、

```text
Current Accounting Standard
+
Latest EDINET Annual Filing Availability
```

を確認する。

ROHM及びFuji Electricと同じType B Structureを仮定しない。
