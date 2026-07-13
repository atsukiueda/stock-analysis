# EDINET Inventory Cross-company Validation Kioxia Holdings Result

## 1. Document Purpose

本書は、EDINET Inventory Cross-company Validation Initial SampleにおけるSlot 4 Company、

```text
キオクシアホールディングス株式会社
Kioxia Holdings Corporation
```

について、最新Annual Securities ReportのEDINET CSV及びRaw XBRLを確認し、IFRS Inventory Extraction Structureを分類したResearch Result Artifactである。

本書の目的はキオクシアホールディングスのInvestment Evaluationを行うことではない。

目的は以下である。

> Japanese GAAP 4社で確認したInventory Extraction Structure及びCSV First Architecture Candidateが、IFRS Filing及び異なるInventory Presentation Structureでも成立するかを検証する。

Status：

```text
Research Artifact
Cross-company Validation Result
IFRS Validation Case
Company Validation Completed
Research Reviewer Evaluated
Production Architecture Not Approved
```

---

# 2. Validation Company

```text
Company:
キオクシアホールディングス株式会社

English Name:
Kioxia Holdings Corporation

Security Code:
285A0

EDINET Code:
E35948
```

Validation Slot：

```text
Slot 4
Memory Semiconductor
IFRS Validation
```

Business Model Candidate：

```text
Flash Memory
SSD
Memory Semiconductor
```

Important：

本ValidationのPrimary PurposeはInventory Extraction Architecture Validationである。

Memory Cycle Investment Interpretationは本ArtifactのScope外とする。

---

# 3. Target Filing

EDINET Document List API実Responseから以下を確認した。

```text
Document ID:
S100YJ18

Document Description:
有価証券報告書－第8期
(2025/04/01－2026/03/31)

Document Type:
120

Period Start:
2025-04-01

Period End:
2026-03-31

Submitted At:
2026-06-24 11:15

Withdrawal Status:
0

Disclosure Status:
0

CSV Flag:
1

XBRL Flag:
1
```

Filing Discovery Result：

```text
PASS
```

Filing IdentityはEDINET Document List API実ResponseをEvidenceとする。

---

# 4. Accounting Standard Validation

Consolidated Audit Opinionでは、連結財務諸表が、

```text
「連結財務諸表の用語、様式及び作成方法に関する規則」
第312条により規定された国際会計基準
```

に準拠すると確認した。

また、連結経営指標等TextBlockでは、IFRSにより作成された連結財務諸表に基づくことが明示されている。

Classification：

```text
IFRS
```

Result：

```text
PASS
```

Important：

提出会社単体財務諸表は日本基準である。

本Inventory Validation TargetはIFRS Consolidated Financial Statementsとする。

---

# 5. CSV ZIP Structure

EDINET CSV ZIPでは以下3 Entryを確認した。

```text
XBRL_TO_CSV/
jpaud-aai-cc-001_E35948-000_2026-03-31_01_2026-06-24.csv

XBRL_TO_CSV/
jpaud-aar-cn-001_E35948-000_2026-03-31_01_2026-06-24.csv

XBRL_TO_CSV/
jpcrp030000-asr-001_E35948-000_2026-03-31_01_2026-06-24.csv
```

Inventory Financial FactsはAnnual Securities Report CSVで確認した。

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

# 6. Total Inventory Source Fact

IFRS Consolidated Financial Statementsでは以下のTotal Inventory Factを確認した。

```text
QName:
jpigp_cor:InventoriesCAIFRS

Label:
棚卸資産、流動資産（IFRS）

Namespace:
http://disclosure.edinet-fsa.go.jp/taxonomy/jpigp/2025-11-01/jpigp_cor
```

Prior：

```text
ContextRef:
Prior1YearInstant

UnitRef:
JPY

Decimals:
-6

Value:
352,863,000,000
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
412,612,000,000
```

Evidence Classification：

```text
Source Fact
```

Important：

キオクシアではTotal InventoryをComponent Sumによってのみ構成する必要はない。

Validated Total Inventory Source Factが存在する。

---

# 7. Inventory Component Source Facts

## 7.1 Finished Goods

```text
QName:
jpigp_cor:FinishedGoodsCAIFRS

Namespace:
jpigp standard taxonomy
```

Prior：

```text
50,549,000,000 JPY
```

Current：

```text
53,232,000,000 JPY
```

Decimals：

```text
-6
```

Classification：

```text
Standard Taxonomy Source Fact
```

---

## 7.2 Semi-finished Products and Work in Progress

```text
QName:
jpcrp030000-asr_E35948-000:
SemiFinishedProductsAndWorkInProgressCAIFRS
```

Namespace：

```text
http://disclosure.edinet-fsa.go.jp/
jpcrp030000/asr/001/E35948-000/
2026-03-31/01/2026-06-24
```

Prior：

```text
283,746,000,000 JPY
```

Current：

```text
280,183,000,000 JPY
```

Decimals：

```text
-6
```

Classification：

```text
Company Extension Source Fact
```

Research Finding：

> Complete Inventory Component Composition Extraction requires recognition of a filer-specific extension concept in this Filing.

---

## 7.3 Raw Materials

```text
QName:
jpigp_cor:RawMaterialsCAIFRS
```

Prior：

```text
18,486,000,000 JPY
```

Current：

```text
79,093,000,000 JPY
```

Decimals：

```text
-6
```

Classification：

```text
Standard Taxonomy Source Fact
```

---

## 7.4 Other Inventories

```text
QName:
jpigp_cor:OtherInventoriesCAIFRS
```

Prior：

```text
82,000,000 JPY
```

Current：

```text
104,000,000 JPY
```

Decimals：

```text
-6
```

Classification：

```text
Standard Taxonomy Source Fact
```

---

# 8. Inventory Structure Classification

Validated Structure：

```text
Total Inventory Fact
+
Inventory Component Facts
```

Classification：

```text
Type C
Total Fact + Component Facts
```

Result：

```text
PASS
```

However、Component StructureにはStandard Taxonomy及びCompany Extensionが混在する。

Detailed Classification：

```text
Total Inventory:
Standard IFRS Taxonomy

Finished Goods:
Standard IFRS Taxonomy

Semi-finished Products and Work in Progress:
Company Extension

Raw Materials:
Standard IFRS Taxonomy

Other Inventories:
Standard IFRS Taxonomy
```

Therefore：

```text
Company Extension Required for Total Inventory Extraction:
NO

Company Extension Required for Complete Component Composition Extraction:
YES
```

---

# 9. Component Sum Cross-check

## Prior

```text
50,549
+
283,746
+
18,486
+
82
=
352,863 million JPY
```

Total Source Fact：

```text
352,863 million JPY
```

Result：

```text
EXACT MATCH
```

---

## Current

```text
53,232
+
280,183
+
79,093
+
104
=
412,612 million JPY
```

Total Source Fact：

```text
412,612 million JPY
```

Result：

```text
EXACT MATCH
```

Cross-check：

```text
Prior:
MATCH

Current:
MATCH

Total:
2 / 2 MATCH
```

Evidence Classification：

```text
Total Inventory:
Source Fact

Component Facts:
Source Facts

Component Sum:
Derived Observation

Component Sum Cross-check:
Validation Result
```

---

# 10. CSV / Raw XBRL Cross-check

Known Inventory Values were searched in the Raw XBRL Instance.

Target Instance：

```text
XBRL/PublicDoc/
jpcrp030000-asr-001_E35948-000_2026-03-31_01_2026-06-24.xbrl
```

Confirmed Facts：

```text
InventoriesCAIFRS
Prior / Current

FinishedGoodsCAIFRS
Prior / Current

SemiFinishedProductsAndWorkInProgressCAIFRS
Prior / Current

RawMaterialsCAIFRS
Prior / Current

OtherInventoriesCAIFRS
Prior / Current
```

Target Fact Count：

```text
10
```

CSV / Raw XBRL Value Result：

```text
10 / 10 MATCH
```

Context Result：

```text
MATCH
```

Unit Result：

```text
JPY
MATCH
```

Decimals：

```text
-6
```

Reviewer Decision：

```text
Raw XBRL Cross-check:
PASS
```

---

# 11. Company Extension Discovery Finding

Initial Inventory Keyword Discovery did not completely identify the following Concept.

```text
SemiFinishedProductsAndWorkInProgressCAIFRS
```

The Concept was identified by Raw XBRL Known Value Discovery using Inventory Note values as Research Evidence.

Important：

Known Value Discovery is a Research Helper.

It is not an approved Production Extraction Method.

Research Finding：

```text
Known Keyword Set
≠
Complete Financial Concept Discovery
```

The following conclusion is supported。

> Keyword Search is useful for Candidate Discovery but is not sufficient as a Production Concept Mapping Rule.

---

# 12. Total Extraction and Composition Extraction Separation

Kioxia provides a Total Inventory Source Fact.

```text
jpigp_cor:InventoriesCAIFRS
```

Therefore Total Inventory Extraction does not require Company Extension Mapping.

However、Complete Component Composition Extraction requires the filer extension Concept：

```text
SemiFinishedProductsAndWorkInProgressCAIFRS
```

Architecture Candidate：

```text
Inventory Total Extraction
```

and

```text
Inventory Component Composition Extraction
```

should be evaluated as separate capabilities.

## Inference

A staged Production Adoption may be possible.

Candidate Stage 1：

```text
Validated Total Inventory Extraction
```

Candidate Stage 2：

```text
Component Composition Extraction
+
Extension Mapping
```

Status：

```text
Inference
Architecture Candidate
Not Production Approved
```

---

# 13. Inventory YoY

Total Source Facts：

```text
Prior:
352,863,000,000 JPY

Current:
412,612,000,000 JPY
```

Formula：

```text
Current / Prior - 1
```

Result：

```text
Inventory YoY:
approximately +16.93%
```

Evidence Classification：

```text
Inventory Total:
Source Fact

Inventory YoY:
Derived Observation
```

---

# 14. Component Composition Change

Approximate Component YoY：

```text
Finished Goods:
+5.31%

Semi-finished Products and Work in Progress:
-1.26%

Raw Materials:
+327.83%

Other Inventories:
+26.83%
```

Research Fact：

```text
Inventory composition changed materially.
```

Investment Interpretation：

```text
NOT EVALUATED
```

The following explanations are not established by this Validation：

```text
Memory cycle recovery

Production ramp

Strategic raw material buildup

Supply constraint hedge

Demand acceleration
```

These require Industry and Company Research Evidence.

---

# 15. Japanese GAAP Comparison

Validated Japanese GAAP Cases：

```text
ROHM
Fuji Electric
Sanken Electric
Torex Semiconductor
```

Observed Structure：

```text
Type B
Component Facts Only
```

Common Concepts：

```text
jppfs_cor:MerchandiseAndFinishedGoods

jppfs_cor:WorkInProcess

jppfs_cor:RawMaterialsAndSupplies
```

Kioxia IFRS：

```text
Type C
Total Fact + Component Facts
```

Total Concept：

```text
jpigp_cor:InventoriesCAIFRS
```

Component Structure：

```text
Standard IFRS Taxonomy
+
Company Extension
```

Cross-company Finding：

```text
Accounting Standard and filing taxonomy
can materially change inventory extraction structure.
```

---

# 16. Architecture Implication

The following universal extraction rule is rejected。

```text
Inventory
=
always sum three components
```

The following universal extraction rule is also not supported。

```text
Inventory
=
always use one total fact
```

Current Architecture Candidate：

```text
Discover Filing Structure
↓
Classify Inventory Structure
↓
Select Extraction Strategy
↓
Validate Context
↓
Validate Unit
↓
Preserve Source Fact Lineage
↓
Calculate Derived Observation if required
```

Possible Strategy Candidate：

```text
Type A:
Validated Total Fact

Type B:
Validated Component Facts
+
Derived Total

Type C:
Validated Total Fact
+
Component Cross-check

Type D:
Extension Mapping Research Required

Type E:
TextBlock / Table Research Required
```

Status：

```text
Research Candidate
Not Production Approved
```

---

# 17. CSV First Architecture Evaluation

Kioxia CSV contained：

```text
Concept QName
Label
Context
Period Classification
Unit
Value
```

Total Inventory Source Fact was directly discoverable in CSV.

Standard Component Facts were also discoverable.

The Company Extension Component required additional Discovery Research.

Result：

```text
CSV Primary for Total Inventory:
PASS

CSV Primary for Known Standard Components:
PASS

CSV-only Generic Component Discovery:
CONDITIONAL
```

Raw XBRL Role：

```text
Cross-check Source
Taxonomy Audit Source
Extension Discovery Source
```

Architecture Candidate：

```text
CSV Primary
+
Raw XBRL Validation / Exception Investigation
```

remains supported.

However、Company Extension Mapping is now a confirmed architecture concern.

---

# 18. Precision and Rounding Finding

All validated Inventory Facts used：

```text
Decimals:
-6
```

Prior and Current Component Sums exactly matched Total Source Facts.

Result：

```text
Exact Match:
2 / 2
```

This does not invalidate the Sanken Precision / Rounding Finding.

Research Backlog remains：

```text
Derived Financial Observation
Precision and Rounding Governance
```

Reason：

```text
Exact equality in one Filing
does not establish a generic exact-equality rule.
```

---

# 19. Research Reviewer Evaluation

Filing Identity：

```text
PASS
```

Accounting Standard：

```text
PASS
IFRS
```

CSV Acquisition：

```text
PASS
```

Total Inventory Fact：

```text
PASS
```

Component Facts：

```text
PASS
```

Company Extension Detection：

```text
PASS
```

Context Validation：

```text
PASS
```

Raw XBRL Cross-check：

```text
PASS
10 / 10 MATCH
```

Structure Classification：

```text
PASS
Type C
```

Source Fact / Derived Observation Separation：

```text
PASS
```

Architecture Variation Detection：

```text
PASS
```

---

# 20. Final Research Reviewer Decision

```text
KIOXIA HOLDINGS VALIDATION
PASS
```

Inventory Structure：

```text
TYPE C
TOTAL FACT + COMPONENT FACTS
```

Accounting Standard：

```text
IFRS
```

Total Inventory：

```text
STANDARD TAXONOMY SOURCE FACT
```

Component Structure：

```text
STANDARD TAXONOMY
+
COMPANY EXTENSION
```

CSV First Architecture Candidate：

```text
SUPPORTED FOR TOTAL EXTRACTION
CONDITIONAL FOR GENERIC COMPONENT DISCOVERY
```

Raw XBRL：

```text
VALIDATION / TAXONOMY AUDIT /
EXTENSION DISCOVERY VALUE CONFIRMED
```

Production Adoption：

```text
NOT APPROVED
```

---

# 21. Current Cross-company Validation State

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
COMPLETED
PASS
TYPE B

Slot 4:
Kioxia Holdings
COMPLETED
PASS
TYPE C

Slot 5:
Tokyo Electron
NEXT

Slot 6:
Renesas Electronics
NOT STARTED
```

Current Structure Evidence：

```text
Type B:
4 Companies

Type C:
1 Company

Company Extension in Inventory Component Structure:
1 Confirmed Case
```

Structure Saturation：

```text
NOT REACHED
```

Reason：

```text
Equipment Business Model not yet validated.

Second IFRS Company not yet validated.

Company Extension variation has just been discovered.
```

---

# 22. Research Backlog Candidates

Existing：

```text
Derived Financial Observation
Precision and Rounding Governance
```

Existing：

```text
Inventory Component Composition Analysis
```

New：

```text
Inventory Total Extraction
vs
Inventory Component Composition Extraction
Capability Separation
```

New：

```text
Company Extension Semantic Mapping
for Detailed Financial Observation
```

Status：

```text
BACKLOG CANDIDATES
```

Do not interrupt Current Cross-company Validation.

---

# 23. Exact Next Task

Next Task：

```text
Tokyo Electron EDINET Inventory Validation
```

Purpose：

> Validate an equipment manufacturer and determine whether Inventory Structure differs from semiconductor device manufacturers.

Mandatory First Gate：

```text
Latest Annual Filing Discovery

Company Identity

Security Code

EDINET Code

Document ID

Accounting Standard

CSV Flag

XBRL Flag
```

Do not assume Type B or Type C.

Do not assume that semiconductor production equipment inventory has the same financial meaning or component structure as semiconductor device inventory.
