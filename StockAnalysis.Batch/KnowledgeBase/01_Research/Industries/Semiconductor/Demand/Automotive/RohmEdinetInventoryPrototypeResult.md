# ROHM EDINET Inventory Acquisition Prototype Result

## 1. Document Purpose

本書は、ROHMを対象として実施したEDINET Inventory Acquisition Prototypeの実行結果、取得Evidence、Reviewer判断及びArchitecture上の示唆を記録するResearch Artifactである。

本Prototypeの目的は、Production用EDINET取得基盤を実装することではない。

目的は以下である。

```text
ROHM 1 Company
+
1 Annual Securities Report Filing
+
Inventory Financial Observation
```

について、EDINET APIを利用し、Point-in-time Financial Observationの取得に必要なRaw Source Traceを保持した状態で財務数値を取得可能か検証することである。

本書は以下のPrototype Planに対応するResult Artifactである。

```text
RohmEdinetInventoryPrototypePlan.md
```

本書のStatusは以下とする。

```text
Research Artifact
Prototype Result
Reviewer Evaluated
Production Adoption Not Yet Approved
```

---

# 2. Research Phase

Current Phase：

```text
Research
↓
Data Acquisition Feasibility
↓
EDINET Prototype
↓
Prototype Evidence Closure
```

本書作成時点では以下のPhaseへ進んでいない。

```text
Catalog
DDL
Entity
Database
ML
Advisor
```

したがって、本Prototype結果のみを理由としてProduction Database Schema、Generic Parser、ML Feature等を確定してはならない。

---

# 3. Prototype Research Question

本PrototypeのPrimary Research Questionは以下である。

> EDINET APIを利用して、ROHMの有価証券報告書からInventoryに関連するFinancial Observationを、Period、Consolidation Status、Context及びRaw Source Traceを識別可能な状態で取得できるか。

Secondary Research Questionsは以下である。

1. EDINET Document List APIから対象Filingを識別できるか。
2. docID及びsubmitDateTimeを取得できるか。
3. CSV変換データを取得できるか。
4. Raw XBRL関連データを取得できるか。
5. Inventory関連Conceptを識別できるか。
6. Current / Prior Periodを識別できるか。
7. Consolidated / Non-consolidatedを識別できるか。
8. Instant / Duration Contextを区別できるか。
9. Unitを確認できるか。
10. CSV ValueとRaw XBRL ValueをCross-checkできるか。
11. Total InventoryをSource Factとして取得できるか。
12. Source FactとDerived Observationを分離できるか。

---

# 4. Target Filing Identity

## Fact

Prototype Targetとして以下のEDINET Filingを使用した。

```text
Company          : ローム株式会社
Security Code    : 69630
EDINET Code      : E01953
Document ID      : S100YF41
Document Type    : 120
Document          : 有価証券報告書
Fiscal Period     : 2025-04-01 ～ 2026-03-31
Period End        : 2026-03-31
Submitted At      : 2026-06-19 15:15
Withdrawal Status : 0
Disclosure Status : 0
CSV Flag          : 1
XBRL Flag         : 1
```

Document Description：

```text
有価証券報告書－第68期(2025/04/01－2026/03/31)
```

## Reviewer Decision

```text
Accept
```

理由：

```text
EDINET Code
Security Code
Document Type
Fiscal Period
Document Description
Withdrawal Status
Disclosure Status
CSV Flag
XBRL Flag
```

をEDINET Document List API Responseから確認した。

Prototype TargetとしてFiling Identityは十分に特定されている。

---

# 5. Point-in-time Availability Evidence

## Fact

対象Filingの提出日時は以下である。

```text
Submitted At:
2026-06-19 15:15
```

対象財務期間末は以下である。

```text
Period End:
2026-03-31
```

したがって、

```text
Period End
≠
Information Availability Date
```

である。

## Architecture Implication

Production Point-in-time Datasetでは、Inventory Observationを以下の日付だけで管理してはならない。

```text
2026-03-31
```

最低限、

```text
PeriodEnd
PublishedAt / SubmittedAt
AcquiredAt
ExtractedAt
EffectiveAsOfDate
```

を区別する必要がある。

## Important

本PrototypeではProduction `EffectiveAsOfDate` Ruleを確定していない。

したがって、

```text
EffectiveAsOfDate = SubmittedAt
```

とはまだ決定しない。

これはProduction Data Governance Researchで別途Reviewer判断する。

---

# 6. EDINET API Acquisition Result

## Document List API

Result：

```text
PASS
```

Target Date：

```text
2026-06-19
```

Result Set Count：

```text
1116
```

ROHM Documents Found：

```text
3
```

対象有価証券報告書：

```text
S100YF41
```

## CSV Acquisition

EDINET Document Acquisition APIからCSV変換ZIPを取得した。

Result：

```text
PASS
```

ZIP Size：

```text
165,644 bytes
```

CSV Entry Count：

```text
3
```

Entries：

```text
XBRL_TO_CSV/jpaud-aai-cc-001_E01953-000_2026-03-31_01_2026-06-19.csv

XBRL_TO_CSV/jpaud-aar-cn-001_E01953-000_2026-03-31_01_2026-06-19.csv

XBRL_TO_CSV/jpcrp030000-asr-001_E01953-000_2026-03-31_01_2026-06-19.csv
```

有価証券報告書本文CSV Candidate：

```text
jpcrp030000-asr-001_E01953-000_2026-03-31_01_2026-06-19.csv
```

File Size：

```text
954,288 bytes
```

## XBRL Acquisition

EDINET Document Acquisition APIからXBRL関連ZIPを取得した。

Result：

```text
PASS
```

ZIP Size：

```text
1,322,750 bytes
```

ZIP Entry Count：

```text
39
```

Raw XBRL Instance：

```text
XBRL/PublicDoc/
jpcrp030000-asr-001_E01953-000_2026-03-31_01_2026-06-19.xbrl
```

Instance Size：

```text
4,809,036 bytes
```

## Reviewer Decision

```text
EDINET API Acquisition Feasibility
=
PASS
```

ROHM 1 Filingについて、

```text
Filing Discovery
CSV Acquisition
XBRL Acquisition
```

の技術的実行可能性を確認した。

---

# 7. CSV Structure Evidence

ROHM有価証券報告書本文CSVでは、Inventory Componentに関連するNumeric Factが以下の構造で確認された。

```text
Concept QName
Japanese Label
Context
Context Label
Consolidation Classification
Period Type
Unit Ref
Unit Label
Value
```

確認例：

```text
"jppfs_cor:MerchandiseAndFinishedGoods"
"商品及び製品"
"CurrentYearInstant"
"当期末"
"連結"
"時点"
"JPY"
"円"
"40897000000"
```

## Fact

少なくとも本Prototype Target Filingでは、CSV変換データから以下を取得可能である。

```text
Concept QName
Label
Current / Prior Context
Consolidated Status
Instant / Duration
Unit
Value
```

## Reviewer Decision

```text
CSV Detailed Financial Observation Extraction
=
Technically Feasible for Prototype Target
```

ただし、これはROHM 1 Filingでの確認結果である。

全企業、全Taxonomy、全会計基準、全Filing TypeへのGeneric Applicabilityは未検証である。

---

# 8. Confirmed Inventory Component Concepts

Raw CSV及びRaw XBRL Cross-checkによって、以下の3 Conceptを確認した。

## 8.1 Merchandise and Finished Goods

```text
QName:
jppfs_cor:MerchandiseAndFinishedGoods

Japanese Label:
商品及び製品

Namespace:
http://disclosure.edinet-fsa.go.jp/taxonomy/jppfs/2025-11-01/jppfs_cor
```

Prior：

```text
ContextRef : Prior1YearInstant
UnitRef    : JPY
Decimals   : -6
Value      : 43,083,000,000
```

Current：

```text
ContextRef : CurrentYearInstant
UnitRef    : JPY
Decimals   : -6
Value      : 40,897,000,000
```

---

## 8.2 Work in Process

```text
QName:
jppfs_cor:WorkInProcess

Japanese Label:
仕掛品

Namespace:
http://disclosure.edinet-fsa.go.jp/taxonomy/jppfs/2025-11-01/jppfs_cor
```

Prior：

```text
ContextRef : Prior1YearInstant
UnitRef    : JPY
Decimals   : -6
Value      : 88,500,000,000
```

Current：

```text
ContextRef : CurrentYearInstant
UnitRef    : JPY
Decimals   : -6
Value      : 92,331,000,000
```

---

## 8.3 Raw Materials and Supplies

```text
QName:
jppfs_cor:RawMaterialsAndSupplies

Japanese Label:
原材料及び貯蔵品

Namespace:
http://disclosure.edinet-fsa.go.jp/taxonomy/jppfs/2025-11-01/jppfs_cor
```

Prior：

```text
ContextRef : Prior1YearInstant
UnitRef    : JPY
Decimals   : -6
Value      : 71,874,000,000
```

Current：

```text
ContextRef : CurrentYearInstant
UnitRef    : JPY
Decimals   : -6
Value      : 69,079,000,000
```

---

# 9. Context Validation

## Fact

対象3 Conceptについて以下のContextを確認した。

```text
Prior1YearInstant
CurrentYearInstant
```

## Fact

対象CSVでは以下のClassificationを確認した。

```text
Consolidation:
連結

Period Type:
時点
```

## Reviewer Decision

本PrototypeでInventory Component Observationとして採用可能なCandidateは以下を満たす。

```text
Consolidated
+
Instant
+
JPY
+
Inventory Component Concept
```

以下は同一Keywordを含んでもInventory Balance Sheet Stock Valueとして採用しない。

例：

```text
jppfs_cor:DecreaseIncreaseInInventoriesOpeCF
```

理由：

```text
Duration
Cash Flow
Inventory Change
```

である。

したがって、

```text
Inventory Keyword Match
≠
Inventory Balance Sheet Fact
```

である。

Concept NameだけによるKeyword ExtractionをProduction Ruleとして採用してはならない。

---

# 10. Excluded Inventory-related Concepts

Prototype Searchでは以下のConceptも検出された。

```text
jppfs_cor:DecreaseIncreaseInInventoriesOpeCF
```

Label：

```text
棚卸資産の増減額（△は増加）、営業活動によるキャッシュ・フロー
```

Context：

```text
Prior1YearDuration
CurrentYearDuration
```

これはCash Flow Observationである。

Inventory Balance Sheet Stock Valueではない。

Reviewer Decision：

```text
Reject as Inventory Stock Value
```

---

また以下のCompany Extension Conceptを確認した。

```text
jpcrp030000-asr_E01953-000:
WriteDownOfInventoriesCostOfSales
```

これは棚卸資産評価損に関連するObservationである。

Inventory Total Balanceではない。

Reviewer Decision：

```text
Reject as Inventory Stock Value
```

## Architecture Implication

Production Extractionでは、

```text
Keyword
```

のみでFinancial Meaningを決定してはならない。

最低限、

```text
Concept Identity
Context
Period Type
Consolidation Status
Unit
Financial Statement Meaning
```

を評価する必要がある。

---

# 11. CSV and Raw XBRL Cross-check

対象3 Inventory Componentについて、CSV ValueとRaw XBRL Valueを比較した。

## Merchandise and Finished Goods

```text
Prior CSV:
43,083,000,000

Prior XBRL:
43,083,000,000

Result:
MATCH
```

```text
Current CSV:
40,897,000,000

Current XBRL:
40,897,000,000

Result:
MATCH
```

## Work in Process

```text
Prior CSV:
88,500,000,000

Prior XBRL:
88,500,000,000

Result:
MATCH
```

```text
Current CSV:
92,331,000,000

Current XBRL:
92,331,000,000

Result:
MATCH
```

## Raw Materials and Supplies

```text
Prior CSV:
71,874,000,000

Prior XBRL:
71,874,000,000

Result:
MATCH
```

```text
Current CSV:
69,079,000,000

Current XBRL:
69,079,000,000

Result:
MATCH
```

## Cross-check Result

```text
6 / 6 Values Matched
```

## Reviewer Decision

```text
CSV ↔ Raw XBRL Cross-check
=
PASS
```

少なくとも本Prototype Target Filing及び対象3 Conceptでは、EDINET CSV変換値とRaw XBRL Fact Valueの一致を確認した。

---

# 12. Source Fact Classification

以下の値はRaw XBRL上に独立したFact Elementとして存在する。

```text
MerchandiseAndFinishedGoods
WorkInProcess
RawMaterialsAndSupplies
```

したがって、本Prototypeでは以下として分類する。

```text
Evidence Classification:
Source Fact
```

Source Fact Candidates：

```text
43,083,000,000 JPY
40,897,000,000 JPY

88,500,000,000 JPY
92,331,000,000 JPY

71,874,000,000 JPY
69,079,000,000 JPY
```

Raw Source Trace Candidate：

```text
Document ID
EDINET Code
Security Code
Submitted At
Period End
CSV Entry
XBRL Instance Entry
Concept QName
Namespace
ContextRef
UnitRef
Decimals
Raw Value
```

## Architecture Requirement

将来Raw Financial Observationを保存する場合、Derived Observationだけを保存してSource Component Lineageを失ってはならない。

---

# 13. Total Inventory Fact Search Result

## Fact

今回確認したInventory Candidate Search及びRaw XBRL Cross-checkでは、

```text
Total Inventories
```

に相当する単一のInventory Total Numeric Factは確認していない。

## Important

これは以下を意味しない。

```text
EDINETにはInventory Totalが存在しない
```

または、

```text
すべての企業はInventory Componentを合算する必要がある
```

本Prototypeで確認できるFactは以下のみである。

> ROHM第68期有価証券報告書の今回確認した対象Fact Structureでは、Inventory Totalとして採用可能な単一Numeric Factを確認できず、3つのInventory Component Numeric Factを確認した。

## Reviewer Classification

```text
Fact:
Three Inventory Component Facts were confirmed.

Not Verified:
Generic absence of Total Inventories Concept across EDINET filings.
```

---

# 14. Derived Total Inventory Observation

ROHMのInventory Total Candidateを以下の3 Source Factsから構成する。

```text
MerchandiseAndFinishedGoods
+
WorkInProcess
+
RawMaterialsAndSupplies
```

## Prior Period

```text
43,083,000,000
+
88,500,000,000
+
71,874,000,000
=
203,457,000,000 JPY
```

## Current Period

```text
40,897,000,000
+
92,331,000,000
+
69,079,000,000
=
202,307,000,000 JPY
```

## Evidence Classification

```text
Total Inventory:
Derived Observation
```

これはRaw XBRL上の単一Source Factとして確認した値ではない。

したがって、

```text
Source Fact
```

として保存または説明してはならない。

## Required Lineage

Derived Total Inventoryを将来利用する場合、最低限以下のLineageが必要である。

```text
Derived Observation Name
Formula
Transformation Rule Version

Source Concept 1
Source Fact 1

Source Concept 2
Source Fact 2

Source Concept 3
Source Fact 3

Source Document ID
Period
Consolidation Status
Calculated At
```

---

# 15. Inventory YoY Derived Observation

Formula：

```text
Inventory YoY
=
(Current Total Inventory / Prior Total Inventory) - 1
```

Calculation：

```text
202,307,000,000
/
203,457,000,000
-
1
=
-0.005652...
```

Result：

```text
Inventory YoY
≈ -0.57%
```

## Evidence Classification

```text
Inventory YoY:
Derived Observation
```

これはEDINET Source Factではない。

## Interpretation Status

本書では、

```text
Inventory YoY -0.57%
```

をInvestment Signalとして解釈しない。

例えば、

```text
Inventory adjustment completed
Demand recovery
Inventory normalization
Positive semiconductor cycle signal
```

とは判断しない。

これらは別Research及びValidationが必要である。

したがって現在のClassificationは以下。

```text
Fact:
Confirmed Inventory Component Source Facts

Derived Observation:
Total Inventory
Inventory YoY

Investment Interpretation:
Not Evaluated in this Prototype
```

---

# 16. CSV First Architecture Candidate

## Prototype Evidence

本Prototype Targetでは、EDINET CSV変換データから以下を取得できた。

```text
Concept QName
Japanese Label
Context
Consolidation Classification
Period Type
Unit
Value
```

さらに対象6 ValueについてRaw XBRLと一致した。

## Inference

ROHM第68期有価証券報告書の対象Inventory Observation取得では、

```text
CSV Primary Extraction
+
Raw XBRL Cross-check
```

がRaw XBRL直接解析のみより実装複雑度を抑えられる可能性がある。

## Important

これはInferenceである。

Production Architecture Decisionではない。

## Architecture Candidate

```text
Candidate:
CSV First Extraction

Audit / Research Cross-check:
Raw XBRL
```

## Reviewer Decision

```text
Accept as Research Candidate
```

ただし、

```text
Production Adoption:
NOT APPROVED
```

理由：

```text
ROHM 1 Company
1 Filing
3 Inventory Components
```

のみのValidationだからである。

---

# 17. Prototype Success Criteria Review

| Success Criterion                              | Result |
| ---------------------------------------------- | ------ |
| EDINET API Authentication                      | PASS   |
| ROHM Filing Acquisition                        | PASS   |
| Annual Securities Report Identification        | PASS   |
| docID Acquisition                              | PASS   |
| submitDateTime Acquisition                     | PASS   |
| xbrlFlag Confirmation                          | PASS   |
| csvFlag Confirmation                           | PASS   |
| CSV ZIP Acquisition                            | PASS   |
| XBRL ZIP Acquisition                           | PASS   |
| Inventory Candidate Concept Discovery          | PASS   |
| Period End Identification                      | PASS   |
| Consolidated / Non-consolidated Identification | PASS   |
| Instant / Duration Identification              | PASS   |
| Unit Identification                            | PASS   |
| Inventory Component Value Acquisition          | PASS   |
| CSV / XBRL Cross-check                         | PASS   |
| Raw Source Trace Candidate Identification      | PASS   |

## Overall Prototype Result

```text
PASS
```

## Reviewer Decision

```text
ROHM EDINET Inventory Acquisition Feasibility Prototype
=
SUCCESS
```

---

# 18. Prototype Limitations

本Prototypeには以下のLimitationsがある。

## 18.1 Single Company

対象企業はROHMのみである。

```text
Cross-company Validation:
Not Performed
```

---

## 18.2 Single Filing

対象Filingは以下の1件のみである。

```text
S100YF41
```

```text
Cross-period Validation:
Not Performed
```

---

## 18.3 Japanese GAAP Scope

確認した対象Conceptは以下のNamespaceである。

```text
jppfs
```

IFRS Filing等のConcept Structureは検証していない。

```text
IFRS Applicability:
Not Verified
```

---

## 18.4 Company Extension Mapping

Company Extension ConceptについてGeneric Mappingを検証していない。

```text
Company Extension Automatic Mapping:
Not Verified
```

---

## 18.5 Total Inventory Formula Generalization

ROHMで確認した以下のFormulaを、

```text
MerchandiseAndFinishedGoods
+
WorkInProcess
+
RawMaterialsAndSupplies
```

他企業へGeneric Ruleとして適用可能か検証していない。

```text
Generic Formula Applicability:
Not Verified
```

したがって、ROHM Formulaを全企業へHardcodeしてはならない。

---

## 18.6 Restatement / Amendment

訂正有価証券報告書、修正Fact、Restatement等のHandlingは検証していない。

```text
Restatement Handling:
Not Verified
```

---

## 18.7 Point-in-time Effective Date

SubmittedAtからProduction EffectiveAsOfDateを決定するRuleは未確定である。

```text
EffectiveAsOfDate Rule:
Not Approved
```

---

# 19. Rejected Premature Implementations

本Prototype結果のみを理由として以下へ進むことをRejectする。

```text
Generic XBRL Parser
All-company EDINET Import
Daily EDINET Monitoring Batch
Production Database Entity
Migration
Generic Taxonomy Mapping Master
Company Extension Automatic Mapping
Knowledge Transformation
ML Feature Generation
Historical Backfill
Advisor Integration
```

理由：

```text
Prototype Success
≠
Production Architecture Validation
```

である。

---

# 20. Reviewer Final Decision

## Decision

```text
ACCEPT PROTOTYPE RESULT
```

## Technical Feasibility

```text
PASS
```

## Evidence Quality

```text
Sufficient for ROHM Prototype Closure
```

## Production Adoption

```text
NOT YET APPROVED
```

## CSV First Architecture

```text
Research Candidate
```

## Raw XBRL

```text
Cross-check / Lineage Research Source Candidate
```

## Inventory Components

```text
Source Facts
```

## Total Inventory

```text
Derived Observation
```

## Inventory YoY

```text
Derived Observation
```

## Investment Signal Interpretation

```text
Not Evaluated
```

---

# 21. Architecture Lessons Learned

本Prototypeから以下を得た。

## Lesson 1

```text
Inventory Keyword Match
≠
Inventory Balance Sheet Fact
```

Cash Flow Inventory Change及びInventory Write-down等を誤採用する危険がある。

---

## Lesson 2

Financial Observation ExtractionではConcept Nameだけでは不十分である。

最低限、

```text
Concept
Context
Period Type
Consolidation Status
Unit
Financial Meaning
```

を確認する必要がある。

---

## Lesson 3

Total Financial Metricが必ず単一Source Factとして存在するとは限らない。

Component Source FactsからDerived Observationを構成する可能性がある。

---

## Lesson 4

Source FactとDerived Observationは分離しなければならない。

```text
Source Fact
≠
Derived Observation
```

Formula及びSource Lineageを保持する必要がある。

---

## Lesson 5

EDINET CSV変換データは、少なくともROHM Prototype TargetではDetailed Financial Observation Extractionに必要なMetadataを保持していた。

---

## Lesson 6

CSV First Architectureは検討価値がある。

ただしROHM 1 Filingの結果のみでProduction Standardへ昇格させてはならない。

---

# 22. Exact Next Research Task

Prototype Closure後の次Research Taskは以下とする。

```text
EDINET Inventory Cross-company Validation
```

目的：

> ROHMで確認したCSV First Extraction Candidate及びInventory Component Structureが、他企業・他Concept Structureでも成立するか検証する。

次Researchでは最低限、ROHMとは異なるInventory Presentationを持つ可能性がある企業を選定する。

Validation Perspective：

```text
Total Inventories Single Fact
vs
Component Facts

Standard Taxonomy
vs
Company Extension

Japanese GAAP
vs
IFRS Candidate

CSV Metadata Sufficiency

Consolidated Context Identification

Current / Prior Period Identification

CSV ↔ XBRL Equality

Derived Observation Requirement
```

企業選定は恣意的に行わない。

まず、

```text
Cross-company Validation Sample Design
```

をResearchとして定義する。

その後に対象企業を選定する。

---

# 23. Final Status

```text
RohmEdinetInventoryPrototypePlan
=
COMPLETED

RohmEdinetInventoryPrototypeExecution
=
COMPLETED

RohmEdinetInventoryPrototypeResult
=
ACCEPTED

ROHM Prototype
=
CLOSED

EDINET Production Adoption
=
PENDING

Exact Next
=
Cross-company Validation Sample Design
```
