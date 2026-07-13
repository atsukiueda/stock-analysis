# EDINET Inventory Cross-company Validation Company Selection

## 1. Document Purpose

本書は、

```text
EdinetInventoryCrossCompanyValidationSampleDesign.md
```

で定義したInitial 6 Company Sampleについて、Primary Source Pre-screening、Slot Fit Evaluation及びResearch Reviewer Evaluationを実施し、Cross-company Validation Candidateを選定するResearch Artifactである。

本書の目的は、投資対象として優良な6社を選定することではない。

目的は以下である。

> ROHM Prototypeで確認したInventory Extraction Structure及びCSV First Architecture Candidateを、異なるBusiness Model、Accounting Standard及びInventory Presentation Structureを持つ企業群で検証可能なSampleを構成する。

本書のStatusは以下とする。

```text
Research Artifact
Company Selection
Pre-validation Selection Completed
EDINET Filing Validation Not Yet Completed
Production Architecture Not Approved
```

---

# 2. Selection Principle

Company Selectionでは以下を優先した。

```text
Architecture Variation
Business Model Diversity
Accounting Standard Diversity
Inventory Structure Variation Potential
Semiconductor Value Chain Coverage
Automotive / Power Semiconductor Relevance
EDINET Validation Feasibility
```

以下はSelection Criterionとして使用していない。

```text
Stock Price Performance
Investment Recommendation
Market Capitalization Ranking
Extraction Ease
Known CSV First Success
Expected Positive Validation Result
```

## Important

本SampleはArchitecture Research Sampleである。

したがって、

```text
Good Investment Company
≠
Good Architecture Validation Sample
```

である。

---

# 3. Selected Sample Overview

Initial 6 Company Sample Candidateは以下とする。

| Slot | Company            | Security Code | Primary Role                            | Accounting Standard Candidate |
| ---- | ------------------ | ------------: | --------------------------------------- | ----------------------------- |
| 1    | 富士電機株式会社           |          6504 | Power Semiconductor Reference           | Japanese GAAP                 |
| 2    | サンケン電気株式会社         |          6707 | Power Semiconductor Contrast            | Japanese GAAP Candidate       |
| 3    | トレックス・セミコンダクター株式会社 |          6616 | Analog / Power Management Semiconductor | Japanese GAAP                 |
| 4    | キオクシアホールディングス株式会社  |          285A | Memory Semiconductor                    | IFRS                          |
| 5    | 東京エレクトロン株式会社       |          8035 | Semiconductor Production Equipment      | Japanese GAAP                 |
| 6    | ルネサス エレクトロニクス株式会社  |          6723 | IFRS Semiconductor Company              | IFRS                          |

Reference Company：

```text
ROHM
Security Code:
6963

Prototype Reference:
Completed
```

Total Research Scope：

```text
ROHM Reference
+
6 Validation Companies
=
7 Companies
```

---

# 4. Accounting Standard Coverage

Initial Sample CandidateのAccounting Standard Coverageは以下である。

## Japanese GAAP

```text
Fuji Electric
Sanken Electric Candidate
Torex Semiconductor
Tokyo Electron
```

Target：

```text
4 Companies
```

## IFRS

```text
Kioxia Holdings
Renesas Electronics
```

Target：

```text
2 Companies
```

## Reviewer Note

サンケン電気について、過去のPrimary SourceではJapanese GAAPベースの連結財務諸表を確認した。

ただし、本Researchは最新Annual Securities ReportをValidation Targetとする。

したがって以下をMandatory Pre-validation Gateとする。

```text
Confirm accounting standard
from latest EDINET annual filing
before inventory structure classification.
```

最新FilingでJapanese GAAPではないことが判明した場合、

```text
Sample Dimension Coverage Review
```

を実施する。

過去の会計基準を現在へ無条件に継承しない。

---

# 5. Slot 1 Selection

## Selected Company

```text
富士電機株式会社
Fuji Electric Co., Ltd.

Security Code:
6504
```

## Slot Role

```text
Power Semiconductor Reference
```

## Required Characteristic

```text
Japanese GAAP
Automotive / xEV Exposure
Power Semiconductor Business
```

## Primary Source Pre-screening Fact

富士電機はSemiconductor Businessを保有する。

Power Semiconductor分野では、

```text
IGBT
SiC
Power Semiconductor Module
```

等を扱う。

Official IR ResearchではxEV向けDesign Win獲得及びIGBT / SiC売上拡大をPriority Measureとして説明している。

また、Automotive Power Semiconductor需要を明示的に区分している。

## Accounting Standard

```text
Japanese GAAP
```

Official Financial Resultsで日本基準表記を確認した。

## Slot Fit Evaluation

```text
Power Semiconductor:
PASS

Automotive / xEV Exposure:
PASS

Japanese GAAP:
PASS

Consolidated Financial Information:
PASS

ROHM Business Proximity:
HIGH
```

## Why Selected

ROHMとの近接Business Structure比較に適する。

特に、

```text
ROHM:
SiC / Power Devices

Fuji Electric:
IGBT / SiC / Power Semiconductor Modules
```

という近接性がある。

一方、企業全体のSegment StructureはROHMと同一ではない。

したがって、

> Similar Investment Theme / Different Corporate Structure

のValidation Sampleとして利用価値がある。

## Pre-screening Inference

Inventory PresentationがROHMと同様のComponent Factsになるかは不明である。

これを事前に仮定しない。

## Reviewer Decision

```text
ACCEPT SLOT 1
```

---

# 6. Slot 2 Selection

## Selected Company

```text
サンケン電気株式会社
Sanken Electric Co., Ltd.

Security Code:
6707
```

## Slot Role

```text
Power Semiconductor Contrast
```

## Required Characteristic

```text
Power Semiconductor
Automotive Exposure
Different Inventory Structure Candidate
```

## Primary Source Pre-screening Fact

サンケン電気はPower Electronicsを中核技術領域とする。

Official Technical Researchでは、

```text
Power Devices
Power Modules
IPM
GaN
Power Management IC
```

等を扱っている。

2025 Technical ReportではAutomotive Application向け1200V Power Device及びIPM開発を確認した。

Automotive向けPower Semiconductor Exposureは明確である。

## Accounting Standard Status

過去のPrimary SourceではJapanese GAAPベースのConsolidated Financial Statementsを確認した。

Current Classification：

```text
Japanese GAAP Candidate
```

Mandatory Gate：

```text
Latest EDINET Filing Accounting Standard Confirmation Required
```

## Slot Fit Evaluation

```text
Power Semiconductor:
PASS

Automotive Exposure:
PASS

Power Electronics Focus:
PASS

Accounting Standard:
CONDITIONAL PASS

ROHM Business Proximity:
HIGH

Corporate / Product Structure Difference:
SUFFICIENT
```

## Why Selected

Slot 1の富士電機だけでは、

```text
ROHM
vs
Large Diversified Power / Industrial Company
```

のComparisonになる。

サンケンを追加することで、

```text
ROHM
vs
Power Semiconductor-focused Company
```

を比較できる。

また、Extraction DifficultyやInventory StructureがROHMと同一になる保証はない。

Architecture Variation Sampleとして妥当である。

## Reviewer Decision

```text
CONDITIONAL ACCEPT SLOT 2
```

Condition：

```text
Latest EDINET annual filing must confirm
accounting standard and consolidated filing availability.
```

Fail時はReplacement Candidateを選定する。

---

# 7. Slot 3 Selection

## Selected Company

```text
トレックス・セミコンダクター株式会社
TOREX SEMICONDUCTOR LTD.

Security Code:
6616
```

## Slot Role

```text
Analog / Power Management Semiconductor
```

## Original Slot Definition

```text
Analog / Mixed Signal Semiconductor
Accounting Standard:
Japanese GAAP
```

## Primary Source Pre-screening Fact

トレックス・セミコンダクターはAnalog Power Supply ICを専門領域とする。

Official Company Informationでは、

```text
Analog Power IC
Power Management IC
```

を中核領域としている。

Official Product / Company MaterialsではAutomotive、Industrial及びConsumer Application向けPower Management ICを扱う。

## Accounting Standard

```text
Japanese GAAP
```

Official Consolidated Financial Resultsで日本基準表記を確認した。

## Slot Fit Evaluation

```text
Analog Semiconductor:
PASS

Power Management IC:
PASS

Japanese GAAP:
PASS

Listed Company:
PASS

Business Model Difference from ROHM:
HIGH
```

## Why Selected

ROHM、富士電機、サンケンだけではPower Semiconductor偏重となる。

トレックスを追加することで、

```text
Power Device
vs
Analog Power Management IC
```

のBusiness Model差を導入する。

Inventory Composition及びInventory Fact PresentationにVariationが存在する可能性がある。

## Inference

Inventory Structure Variationが大きい可能性がある。

ただしこれはPre-screening Inferenceである。

Formal ClassificationはEDINET Fact確認後に行う。

## Reviewer Decision

```text
ACCEPT SLOT 3
```

---

# 8. Slot 4 Selection

## Selected Company

```text
キオクシアホールディングス株式会社
Kioxia Holdings Corporation

Security Code:
285A
```

## Slot Role

```text
Memory Semiconductor
```

## Primary Source Pre-screening Fact

キオクシアグループはFlash Memory及びSSDを主要Businessとする。

Official Annual Securities ReportではSemiconductor / Memory Industryの短期間でのBusiness Environment Volatilityを説明している。

Memory及びStorage Productを主要Businessとしている。

## Accounting Standard

```text
IFRS
```

Official Annual Securities Report及びFinancial ResultsでIFRS Consolidated Financial Informationを確認した。

## Slot Fit Evaluation

```text
Memory Semiconductor:
PASS

IFRS:
PASS

Consolidated Filing:
PASS

Inventory Cycle Relevance:
HIGH

Business Difference from ROHM:
VERY HIGH
```

## Why Selected

Inventory Adjustment ResearchではMemory Semiconductorを除外すべきではない。

Memory Industryは、

```text
Supply
Demand
Inventory
Pricing
Production
```

のCycle InteractionがInvestment Research上重要なBusiness Model Candidateである。

Architecture面でも、

```text
Japanese GAAP jppfs
vs
IFRS taxonomy structure
```

を比較可能である。

## Important

Memory Cycleの重要性を理由に、Inventory Factを有効なInvestment Signalと事前判定してはならない。

本PhaseのPrimary PurposeはExtraction Structure Validationである。

## Reviewer Decision

```text
ACCEPT SLOT 4
```

---

# 9. Slot 5 Selection

## Selected Company

```text
東京エレクトロン株式会社
Tokyo Electron Limited

Security Code:
8035
```

## Slot Role

```text
Semiconductor Production Equipment
```

## Primary Source Pre-screening Fact

東京エレクトロングループはSemiconductor Production Equipment Businessを中核とする。

Official Financial ResultsではReportable Segmentを、

```text
Semiconductor Production Equipment
```

のSingle Segmentとして扱っている。

## Accounting Standard

```text
Japanese GAAP
```

Official FY2026 Consolidated Financial Resultsで日本基準を確認した。

## Slot Fit Evaluation

```text
Semiconductor Equipment:
PASS

Japanese GAAP:
PASS

Consolidated Financial Statements:
PASS

Device Manufacturer Contrast:
VERY HIGH
```

## Why Selected

Device ManufacturerだけでSampleを構成すると、

```text
Inventory Architecture
=
Semiconductor Device Manufacturer Architecture
```

というSelection Biasが発生する。

東京エレクトロンを含めることで、

```text
Device Manufacturer
vs
Production Equipment Manufacturer
```

を比較できる。

Inventory Presentation Structure及びFinancial MeaningのDifferenceを確認するために重要である。

## Reviewer Decision

```text
ACCEPT SLOT 5
```

---

# 10. Slot 6 Selection

## Selected Company

```text
ルネサス エレクトロニクス株式会社
Renesas Electronics Corporation

Security Code:
6723
```

## Slot Role

```text
IFRS Semiconductor Company
```

## Required Characteristic

```text
IFRS
Consolidated Filing
Semiconductor Business
```

## Primary Source Pre-screening Fact

Renesas GroupはAutomotive Business及びIndustrial / Infrastructure / IoT Businessを展開する。

主要Product Categoryには以下を含む。

```text
MCU
SoC
Analog Semiconductor Device
Power Semiconductor Device
```

Automotive BusinessではADAS及びxEV Application Exposureが確認される。

## Accounting Standard

```text
IFRS
```

Official Financial Materialでは、

```text
Annual Securities Report for FY2018/12 onward
```

にIFRS Consolidated Financial Statementsを使用していることを確認した。

## Slot Fit Evaluation

```text
IFRS:
PASS

Consolidated Filing:
PASS

Semiconductor Company:
PASS

Automotive Exposure:
PASS

Analog Exposure:
PASS

Power Semiconductor Exposure:
PASS
```

## Why Selected

IFRS Sampleをキオクシアだけにすると、

```text
IFRS
=
Memory Company
```

というConfoundingが発生する。

Renesasを追加することで、

```text
IFRS Memory Semiconductor
vs
IFRS Automotive / MCU / Analog Semiconductor
```

を比較できる。

したがって、

```text
Accounting Standard Effect
vs
Business Model Effect
```

を完全ではないものの、一定程度分離するSample構成となる。

## Reviewer Decision

```text
ACCEPT SLOT 6
```

---

# 11. Sample Diversity Evaluation

Selected Sample：

```text
Fuji Electric
Sanken Electric
Torex Semiconductor
Kioxia Holdings
Tokyo Electron
Renesas Electronics
```

## Business Model Coverage

```text
Power Semiconductor
Power Electronics
Analog / Power Management IC
Memory Semiconductor
Semiconductor Production Equipment
MCU / SoC / Analog / Power Semiconductor
```

Result：

```text
PASS
```

---

## Accounting Standard Coverage

```text
Japanese GAAP:
4 Candidate Companies

IFRS:
2 Companies
```

Result：

```text
PASS WITH SANKEN PRE-VALIDATION CONDITION
```

---

## Automotive Exposure Coverage

Strong Automotive / xEV Candidate：

```text
Fuji Electric
Sanken Electric
Renesas Electronics
```

Additional Automotive Application Exposure Candidate：

```text
Torex Semiconductor
Kioxia
```

Result：

```text
SUFFICIENT
```

---

## Value Chain Coverage

```text
Device / Power:
Fuji Electric
Sanken Electric

Analog / Power Management:
Torex Semiconductor

Memory:
Kioxia

Equipment:
Tokyo Electron

Integrated Semiconductor Portfolio:
Renesas
```

Result：

```text
PASS
```

---

# 12. Selection Bias Review

## Easy Extraction Bias

```text
Not intentionally selected
```

Inventory Concept Structureは未確認である。

---

## CSV First Confirmation Bias

```text
Controlled
```

CSV Firstを支持する企業のみ選定していない。

IFRS、Memory、Equipmentを含めている。

---

## Automotive-only Bias

```text
Controlled
```

Tokyo Electron及びKioxiaを含む。

---

## Japanese GAAP-only Bias

```text
Controlled
```

Kioxia及びRenesasを含む。

---

## Device Manufacturer-only Bias

```text
Controlled
```

Tokyo Electronを含む。

---

## Large-cap-only Bias

```text
Controlled
```

Torex及びSankenを含む。

---

# 13. Research Reviewer Evaluation

## Evidence Quality

```text
PASS FOR PRE-SCREENING
```

Company Role及びAccounting Standard CandidateはOfficial Company / IR SourcesをPrimary SourceとしてPre-screeningした。

## Sample Diversity

```text
PASS
```

Initial 6 Company Sampleとして必要なBusiness Model Variationを持つ。

## Selection Bias

```text
ACCEPTABLE
```

Known Extraction Resultを基準に企業選定していない。

## Boundary Case Coverage

```text
IFRS
Memory
Equipment
Focused Analog
Power Semiconductor
Diversified Semiconductor
```

を含む。

## Reviewer Concern

サンケン電気のCurrent Accounting Standard及び最新EDINET Filing Structureは、最新Annual Filing取得時に再確認が必要である。

したがってSlot 2はConditional Acceptとする。

## Final Research Reviewer Decision

```text
ACCEPT SAMPLE
WITH ONE PRE-VALIDATION CONDITION
```

---

# 14. Final Selected Validation Sample

正式なInitial Validation Candidateは以下とする。

```text
Slot 1
Fuji Electric
6504

Slot 2
Sanken Electric
6707
Conditional

Slot 3
Torex Semiconductor
6616

Slot 4
Kioxia Holdings
285A

Slot 5
Tokyo Electron
8035

Slot 6
Renesas Electronics
6723
```

Reference：

```text
ROHM
6963
```

---

# 15. Mandatory Pre-validation Gate

各Company Validation開始時に以下をEDINET実Responseから確認する。

```text
Company Identity
EDINET Code
Security Code

Latest Target Annual Filing
Document ID
Document Type
Period Start
Period End
Submitted At

CSV Flag
XBRL Flag

Consolidated Financial Statements Availability
Accounting Standard
```

## Important

Pre-screening Researchの値をProduction Factとして使用しない。

EDINET Validation Resultを優先する。

特に、

```text
EDINET Code
Document ID
Accounting Standard
Inventory Structure
```

を推測または過去資料から固定しない。

---

# 16. Validation Execution Order

Validation Orderは以下とする。

```text
1. Fuji Electric
2. Sanken Electric
3. Torex Semiconductor
4. Kioxia Holdings
5. Tokyo Electron
6. Renesas Electronics
```

## Rationale

最初にJapanese GAAP Power Semiconductor企業を検証する。

```text
ROHM
↓
Fuji Electric
↓
Sanken Electric
```

によって近接Business Structure内のVariationを確認する。

次に、

```text
Torex
```

でAnalog / Power Management Structureへ移る。

その後、

```text
Kioxia
```

でIFRS / Memory Structureを確認する。

次に、

```text
Tokyo Electron
```

でEquipment Structureを確認する。

最後に、

```text
Renesas
```

でIFRSかつAutomotive / Analog / Power Semiconductor Structureを確認する。

この順序により、Structure Variationの発生地点を比較しやすくする。

---

# 17. Stop / Expansion Rule

Initial 6 Companiesは原則すべて検証する。

途中でCSV FirstがFAILしてもResearchを停止しない。

途中でROHMと同一Structureが複数確認されてもResearchを停止しない。

以下のNew Structureが発見された場合、Architecture Variationとして記録する。

```text
Single Total Fact

Total + Components

Company Extension Required

TextBlock Only

IFRS-specific Structure

Context Ambiguity

CSV Metadata Insufficient

CSV / XBRL Mismatch

Inventory Not Material

Unresolved Structure
```

6社完了後、Structure Saturation Candidateを評価する。

必要なら追加Company Sampleを選定する。

---

# 18. Current Decision

```text
ROHM Prototype:
CLOSED

Cross-company Sample Design:
COMPLETED

Cross-company Company Selection:
ACCEPTED

Initial Validation Companies:
6

Reference Company:
ROHM

Production EDINET Architecture:
NOT APPROVED

Current Phase:
Research
```

---

# 19. Exact Next Task

次のTaskは以下とする。

```text
Fuji Electric EDINET Inventory Validation
```

Execution Scope：

```text
1 Company
+
1 Latest Annual Securities Report
+
Inventory Observation Structure
```

確認順序：

```text
EDINET Filing Discovery
↓
Filing Identity Confirmation
↓
Accounting Standard Confirmation
↓
CSV ZIP Acquisition
↓
Inventory Fact Search
↓
Inventory Structure Classification
↓
Context Validation
↓
Raw XBRL Cross-check
↓
Source Fact / Derived Observation Classification
↓
Company Result Artifact
↓
Reviewer Evaluation
```

ROHM Prototype Serviceを即Generic Production Serviceへ変更しない。

Fuji Electric Validationに必要な最小Research Prototype変更のみを行う。
