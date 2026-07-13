# EDINET Inventory Cross-company Validation Sample Design

## 1. Document Purpose

本書は、ROHM EDINET Inventory Acquisition Prototypeで得られたData Acquisition及びExtraction Architecture Candidateについて、Cross-company Validationを実施するためのSample Designを定義するResearch Artifactである。

本書の目的は、検証対象企業を恣意的に選択することではない。

以下のResearch Questionに回答可能なSample Structureを先に定義し、その後に具体的な企業を選定することである。

> ROHMで確認したCSV First Extraction Candidate、Inventory Component Structure及びSource Fact / Derived Observation分離方針は、異なる企業、会計基準、Inventory Presentation及びTaxonomy Structureに対してどの程度成立するか。

本書のStatusは以下とする。

```text
Research Artifact
Sample Design
Company Selection Not Yet Completed
Production Architecture Not Yet Approved
```

---

# 2. Research Background

ROHM第68期有価証券報告書を対象としたPrototypeでは、以下を確認した。

```text
EDINET Document List API
PASS

CSV Acquisition
PASS

Raw XBRL Acquisition
PASS

Inventory Component Fact Extraction
PASS

CSV ↔ Raw XBRL Cross-check
PASS
```

ROHMでは以下のInventory Component Source Factsを確認した。

```text
jppfs_cor:MerchandiseAndFinishedGoods
jppfs_cor:WorkInProcess
jppfs_cor:RawMaterialsAndSupplies
```

ROHM Prototypeでは、Inventory Totalとして採用可能な単一Numeric Factを確認しなかった。

そのためROHMのTotal Inventory Candidateは以下のDerived Observationとして構成した。

```text
MerchandiseAndFinishedGoods
+
WorkInProcess
+
RawMaterialsAndSupplies
```

また、対象6 ValueについてEDINET CSV変換データとRaw XBRL Valueが一致した。

この結果から以下をResearch Candidateとした。

```text
CSV Primary Extraction Candidate
+
Raw XBRL Cross-check Candidate
```

ただし、これは以下の限定条件下の結果である。

```text
1 Company
1 Filing
Japanese GAAP
3 Inventory Components
```

したがってProduction Architecture DecisionにはEvidenceが不足している。

---

# 3. Primary Research Questions

Cross-company Validationでは以下を検証する。

## RQ-1

Inventory Totalは企業間でどのようなFact Structureを持つか。

Candidate Structure：

```text
A:
Single Total Inventories Fact

B:
Multiple Inventory Component Facts

C:
Total Fact
+
Component Facts

D:
Company Extension Fact

E:
TextBlock Only

F:
Other / Unknown
```

---

## RQ-2

EDINET CSV変換データは、Detailed Financial Observation Extractionに必要なMetadataを企業間で安定して保持するか。

確認対象：

```text
Concept QName
Label
Context
Current / Prior Classification
Consolidation Classification
Period Type
Unit
Value
```

---

## RQ-3

CSV ValueとRaw XBRL Valueは企業間で一致するか。

Comparison Unit：

```text
Company
Filing
Concept
ContextRef
UnitRef
Value
```

---

## RQ-4

Inventory Observation ExtractionにCompany Extension Mappingが必要となる割合はどの程度か。

Classification：

```text
Standard Taxonomy Only
Company Extension Required
Mixed
Unknown
```

---

## RQ-5

ROHMで確認したInventory Component Formulaを他企業へGeneric適用できるか。

ROHM Formula：

```text
MerchandiseAndFinishedGoods
+
WorkInProcess
+
RawMaterialsAndSupplies
```

Expected Decision：

```text
Do not assume generic applicability.
```

Cross-company ValidationによってFormula Patternを分類する。

---

## RQ-6

Japanese GAAPとIFRSではInventory Fact Structureにどの程度差があるか。

確認対象：

```text
Concept Namespace
Total / Component Presentation
Context Structure
Consolidation Identification
Unit
Company Extension Usage
```

---

# 4. Validation Unit

Primary Validation Unitは以下とする。

```text
Company
+
Annual Securities Report Filing
+
Inventory Observation Structure
```

同一企業の複数年度を最初から大量に取得しない。

初期Cross-company Validationでは、

```text
1 Company
=
1 Recent Annual Securities Report
```

を基本とする。

理由：

本Phaseの目的はHistorical Backfillではない。

目的はExtraction StructureのVariation確認である。

---

# 5. Sample Size Design

## Initial Sample

Initial Validation Sampleは以下とする。

```text
6 Companies
```

### Reviewer Rationale

3社以下ではStructure Variationを確認するには不足する。

一方、10社以上を最初から対象にすると、Extraction Architecture未確定の状態でResearch Scopeが拡大しすぎる。

したがって初期Sampleは6社とする。

## Expansion Rule

以下のいずれかが発生した場合、Sampleを追加する。

```text
New Inventory Fact Structure found

New Accounting Standard Pattern found

Company Extension pattern not covered

CSV metadata insufficient

CSV ↔ XBRL mismatch found

Context interpretation ambiguity found
```

追加Sampleは固定件数ではなく、Structure Saturationを基準とする。

## Structure Saturation Candidate

以下の状態をStructure Saturation Candidateとする。

> 連続3社の追加検証で、新しいInventory Extraction Structure Classificationが発見されない。

これはProduction Adoption Ruleではない。

Research Sampling Stop Candidateである。

---

# 6. Mandatory Sample Dimensions

6社のInitial Sampleは、最低限以下のDimensionをCoverageする。

## Dimension 1: Accounting Standard

```text
Japanese GAAP
IFRS
```

Initial Target：

```text
Japanese GAAP:
At least 4 Companies

IFRS:
At least 2 Companies
```

理由：

日本株UniverseではJapanese GAAPをPrimary Scopeとして重視する。

一方、IFRSを除外するとGeneric EDINET Financial Observation Architectureを評価できない。

---

## Dimension 2: Semiconductor Business Type

最低限以下をCoverageする。

```text
Power Semiconductor

Analog / Mixed Signal

Memory

Semiconductor Manufacturing Equipment
or
Semiconductor Materials
```

## Important

本ResearchのInvestment ThemeはAutomotive Power Inventory Adjustmentである。

したがってPower Semiconductor CompanyをSampleから外してはならない。

ただしPower Semiconductor CompanyだけでSampleを構成してはならない。

理由：

Extraction Architecture ValidationとIndustry Hypothesis Validationを混同しないためである。

---

## Dimension 3: Inventory Presentation Structure

企業選定時に事前に完全なStructureを知る必要はない。

ただし、Primary Sourceの財務諸表表示を事前Screeningし、可能な限り以下のVariation Candidateを含める。

```text
Total Inventory displayed

Multiple Components displayed

Large Work in Process balance

Raw Materials-heavy structure

Finished Goods-heavy structure
```

このClassificationは企業選定時点ではPre-screening Inferenceである。

正式ClassificationはEDINET Fact確認後に行う。

---

## Dimension 4: Taxonomy Pattern

可能な限り以下をCoverageする。

```text
Standard Taxonomy dominant

Company Extension present
```

Company Extensionの有無はEDINET Raw Fact確認後に正式判定する。

---

## Dimension 5: Consolidated Financial Statements

Primary Sampleでは以下を必須とする。

```text
Consolidated Financial Statements Available
```

理由：

現在のInventory ResearchではCompany-level Investment Decisionに利用するInventory Observationを対象としており、Primary CandidateはConsolidated Inventoryである。

Non-consolidatedのみの企業はInitial Sample対象外とする。

---

# 7. Proposed Sample Slot Design

Initial 6 Company Sampleは企業名を先に固定せず、以下のSlotとして設計する。

## Slot 1

```text
Role:
Power Semiconductor Reference

Accounting Standard:
Japanese GAAP

Required Characteristic:
Automotive / xEV Exposure
```

目的：

ROHMとの近接Business Structure比較。

---

## Slot 2

```text
Role:
Power Semiconductor Contrast

Accounting Standard:
Japanese GAAP

Required Characteristic:
Different Inventory Presentation Candidate
```

目的：

同IndustryでもInventory Fact Structureが異なるか確認する。

---

## Slot 3

```text
Role:
Analog / Mixed Signal Semiconductor

Accounting Standard:
Japanese GAAP
```

目的：

Power Semiconductor固有StructureとSemiconductor General Structureを分離する。

---

## Slot 4

```text
Role:
Memory Semiconductor

Accounting Standard:
Japanese GAAP
or
IFRS
```

目的：

Work in Process及びInventory Cycleの重要性が高いBusiness ModelでFact Structureを確認する。

---

## Slot 5

```text
Role:
Semiconductor Equipment or Materials

Accounting Standard:
Japanese GAAP
```

目的：

Device Manufacturer以外のInventory Presentationを確認する。

---

## Slot 6

```text
Role:
IFRS Semiconductor Company

Accounting Standard:
IFRS

Required Characteristic:
Consolidated Filing
```

目的：

Japanese GAAP `jppfs` Structureへの過度な依存を検出する。

---

# 8. ROHM Treatment in Sample

ROHMはInitial 6 Company Sampleへ含めない。

理由：

ROHMはPrototype Referenceであり、既にValidation済みだからである。

Sample Structure：

```text
Reference:
ROHM

Cross-company Validation:
6 Additional Companies
```

したがってTotal Observation Scopeは以下。

```text
1 Reference Company
+
6 Validation Companies
=
7 Companies
```

---

# 9. Company Selection Criteria

Candidate Companyは以下を満たす必要がある。

## Mandatory

```text
Japanese Listed Company

Recent Annual Securities Report available in EDINET

Consolidated Financial Statements available

Inventory-related balance exists
or
Inventory absence itself is analytically relevant

Semiconductor Value Chain relevance
```

---

## Preferred

```text
Clear Business Model

Primary Source disclosure quality

Automotive Exposure identifiable

Different Inventory Structure Candidate

Recent Filing with CSV Flag = 1

Recent Filing with XBRL Flag = 1
```

---

# 10. Exclusion Criteria

以下はInitial Sampleから除外する。

```text
Financial Institutions

Pure Holding Company with little operating inventory

ETF

REIT

Investment Fund

Company without consolidated financial statements

Filing without usable EDINET XBRL / CSV

Company whose primary business is unrelated to semiconductor value chain
```

また、ROHMに極めて近いBusiness Structureの企業だけを複数選び、Sample Diversityを失う選定は禁止する。

---

# 11. Selection Bias Controls

企業選定時に以下は禁止する。

## Prohibited

```text
Choose companies only because extraction is easy.

Choose companies only because known inventory data exists.

Choose companies only because results support CSV First.

Exclude companies because Company Extension looks difficult.

Exclude IFRS because taxonomy differs.

Choose only high-quality disclosure companies.

Choose only automotive semiconductor companies.
```

理由：

Architecture ValidationではFailure Case及びDifficult CaseもEvidenceである。

---

# 12. Pre-screening Information

企業選定時には以下のみをPre-screeningする。

```text
Company Name
Security Code
EDINET Code where available
Primary Semiconductor Business Type
Accounting Standard
Recent Annual Filing availability
Consolidated Filing availability
Automotive Exposure Candidate
Inventory Presentation Candidate
```

## Important

Pre-screening時点で以下を確定しない。

```text
Inventory Extraction Method
Total Inventory Formula
Concept Mapping
CSV Primary Decision
XBRL Primary Decision
```

これらは実データ確認後に判断する。

---

# 13. Validation Procedure per Company

各企業について以下の順序を固定する。

```text
1.
Identify latest target annual filing

2.
Confirm:
docID
submitDateTime
periodEnd
csvFlag
xbrlFlag

3.
Acquire CSV ZIP

4.
Identify main annual report CSV

5.
Search Inventory Candidate Facts

6.
Classify:
Total Fact
Component Facts
Extension Fact
TextBlock
Other

7.
Validate:
Consolidated
Instant
Current / Prior
Unit

8.
Acquire Raw XBRL ZIP

9.
Identify Raw XBRL Instance

10.
Cross-check CSV vs XBRL

11.
Determine:
Source Fact
Derived Observation Candidate

12.
Record architecture variation

13.
Reviewer evaluation
```

---

# 14. Required Result Fields

各企業のValidation Resultには最低限以下を記録する。

```text
Company
Security Code
EDINET Code
Accounting Standard

Document ID
Document Type
Period Start
Period End
Submitted At
CSV Flag
XBRL Flag

Inventory Structure Classification

Concept QName
Namespace
Japanese Label

ContextRef
Current / Prior
Consolidated / Non-consolidated
Instant / Duration

UnitRef
Decimals
Raw Value

CSV Value
XBRL Value
Match Result

Source Fact Classification

Derived Observation Required

Formula Candidate

Company Extension Required

Extraction Difficulty

Reviewer Decision
```

---

# 15. Inventory Structure Classification

Initial Classification Candidateは以下とする。

## Type A

```text
Single Total Inventory Fact
```

例：

```text
Inventories
```

Total InventoryをSource Factとして取得可能。

---

## Type B

```text
Component Facts Only
```

ROHM Prototype Candidate。

Total InventoryはDerived Observationとなる可能性がある。

---

## Type C

```text
Total Fact
+
Component Facts
```

Total FactとComponent SumをCross-check可能。

---

## Type D

```text
Company Extension Fact Required
```

Standard TaxonomyだけではInventory Observationを構成できない。

---

## Type E

```text
TextBlock Only
```

Numeric Fact Extractionでは取得できない。

Table / Inline XBRL / TextBlock Extraction Researchが必要。

---

## Type F

```text
No Material Inventory
or
Not Applicable
```

Inventory Observation自体のInvestment Relevanceを再評価する。

---

## Type U

```text
Unknown / Unresolved
```

Evidence不足またはContext Ambiguity。

Unknownを無理に既存Typeへ分類してはならない。

---

# 16. CSV First Evaluation Criteria

各Company Resultで以下を評価する。

## CSV Primary Candidate PASS

以下をすべて満たす場合。

```text
Required Fact present in CSV

Concept QName available

Context available

Consolidation classification available

Period type available

Unit available

Value available

CSV Value equals Raw XBRL Value
```

---

## CSV Primary Candidate CONDITIONAL

例：

```text
Value present

But:
Context interpretation requires additional mapping
or
Company Extension mapping required
```

---

## CSV Primary Candidate FAIL

例：

```text
Required Numeric Fact absent

Critical lineage metadata absent

CSV and Raw XBRL mismatch

Only TextBlock available
```

---

# 17. Raw XBRL Role Evaluation

Raw XBRLのRoleを以下から分類する。

```text
Primary Extraction Required

Cross-check Source

Taxonomy / Context Audit Source

Extension Mapping Source

Insufficient
```

ROHMでは現時点で以下がCandidateである。

```text
Cross-check Source
+
Taxonomy / Context Audit Source
```

このClassificationが他企業でも成立するか検証する。

---

# 18. Derived Observation Rule Evaluation

Total InventoryがDerived Observationとなる場合、以下を確認する。

```text
All material inventory components identified

Component overlap absent

Component omission risk evaluated

Same period

Same consolidation scope

Same unit

Same accounting scope
```

以下は禁止する。

```text
Keyword-based component sum

Mixed consolidated and non-consolidated sum

Current and prior context mix

Duration and instant mix

JPY and other currency mix

Standard fact and overlapping total fact double count
```

---

# 19. Reviewer Gate

Cross-company Validation完了後、Research Reviewer及びADR Reviewer相当のArchitecture Reviewを行う。

## Research Reviewer Focus

```text
Evidence Quality
Sample Diversity
Selection Bias
Inventory Financial Meaning
Boundary Cases
Source Fact / Derived Observation Classification
```

## Architecture Reviewer Focus

```text
CSV Primary Reliability
XBRL Dependency
Taxonomy Version Dependency
Company Extension Complexity
Context Semantics
Source Lineage
Versioning
Operational Cost
Failure Modes
Generic Parser Risk
Migration Cost
```

---

# 20. Production Adoption Decision Candidate

Cross-company Validation後に以下を判断する。

## Candidate A

```text
CSV Primary Extraction
+
Raw XBRL Audit
```

## Candidate B

```text
Raw XBRL Primary Extraction
```

## Candidate C

```text
Hybrid Extraction by Structure Type
```

## Candidate D

```text
EDINET not suitable as Production Financial Observation Source
```

Prototype Successを理由にCandidate Aを自動採用してはならない。

---

# 21. Definition of Done

本Sample DesignのDefinition of Doneは以下である。

```text
Primary Research Questions defined

Validation Unit defined

Initial Sample Size defined

Mandatory Sample Dimensions defined

Six Sample Slots defined

Selection Criteria defined

Exclusion Criteria defined

Selection Bias Controls defined

Validation Procedure defined

Required Result Fields defined

Inventory Structure Classification defined

CSV First Evaluation Criteria defined

Raw XBRL Role Evaluation defined

Derived Observation Evaluation defined

Reviewer Gate defined
```

---

# 22. Current Decision

```text
Initial Validation Sample:
6 Additional Companies

Reference:
ROHM

Total Research Scope:
7 Companies

Current Phase:
Research

Company Selection:
Not Yet Completed

Production Architecture:
Not Approved
```

---

# 23. Exact Next Task

次のTaskは以下とする。

```text
Cross-company Validation Company Selection
```

6 Sample SlotそれぞれについてCandidate CompanyをResearchする。

Selection Workflow：

```text
Candidate Research
↓
Primary Source Pre-screening
↓
Slot Fit Evaluation
↓
Research Reviewer Evaluation
↓
Final Sample Selection
```

企業名を知名度だけで選定しない。

ROHM Prototype Resultを支持する企業だけを選定しない。

Architecture Variationを発見できるSample Qualityを優先する。
