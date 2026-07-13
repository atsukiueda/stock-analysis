# Inventory Raw Observation / Semantic Component Mapping Boundary

## 1. Document Purpose

本書は、EDINET Inventory Acquisition Researchで取得するFinancial Factについて、

```text
Raw Observation
Semantic Mapping
Derived Observation
Knowledge Interpretation
```

の責務境界を定義するResearch Architecture Artifactである。

本書の目的はDatabase TableまたはEntityを設計することではない。

目的は以下である。

> EDINET Source FactをどのLayerまでEvidenceとして忠実に保持し、どの時点からMeaning Transformationを行うかを明確化する。

Status：

```text
Research Architecture Artifact
Boundary Definition
Pre-Catalog
Pre-DDL
Production Architecture Not Approved
```

---

# 2. Background

Initial 7-company Cross-company Validationでは以下を確認した。

```text
ROHM
Fuji Electric
Sanken Electric
Torex Semiconductor
Kioxia Holdings
Tokyo Electron
Renesas Electronics
```

Validation Result：

```text
Initial 7-company Cross-company Inventory Validation
=
CLOSED / PASS
```

Japanese GAAP企業では以下のStandard Taxonomy Patternが複数企業で確認された。

```text
jppfs_cor:MerchandiseAndFinishedGoods
jppfs_cor:WorkInProcess
jppfs_cor:RawMaterialsAndSupplies
```

一方、IFRS企業では以下を確認した。

```text
jpigp_cor:InventoriesCAIFRS
```

Component StructureにはVariationが存在した。

Examples：

```text
MerchandiseAndFinishedGoodsCAIFRS
FinishedGoodsCAIFRS
WorkInProcessCAIFRS
SemiFinishedProductsAndWorkInProgressCAIFRS
RawMaterialsCAIFRS
RawMaterialsAndSuppliesCAIFRS
OtherInventoriesCAIFRS
```

さらにKioxia HoldingsではCompany Extension Conceptを確認した。

したがって、

```text
Raw QName
=
Canonical Financial Meaning
```

とは限らない。

---

# 3. Core Boundary Principle

最重要原則は以下である。

```text
Source Fact
must remain
Source Fact.
```

Source Fact取得時にMeaningを上書きしない。

例えば、

```text
jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS
```

を取得した時点で、

```text
FinishedGoods
```

へ置換してSource QNameを失ってはならない。

Correct：

```text
Source QName:
jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS

Semantic Role Candidate:
FinishedGoods
```

Incorrect：

```text
Source QName:
FinishedGoods
```

Raw Source Identity及びSemantic Interpretationを分離する。

---

# 4. Layer Model

Inventory Financial Observationは以下のLayerに分離する。

```text
Layer 0
Source Document Identity

Layer 1
Raw Financial Fact

Layer 2
Fact Eligibility Classification

Layer 3
Semantic Component Mapping

Layer 4
Canonical Financial Observation

Layer 5
Derived Observation

Layer 6
Knowledge Interpretation
```

各Layerは異なる責務を持つ。

---

# 5. Layer 0: Source Document Identity

## Purpose

FactがどのSource Documentから取得されたかを保持する。

Minimum Candidate Information：

```text
Source System
Document ID
Document Type
EDINET Code
Security Code
Filer Name

Period Start
Period End
Submitted At

CSV Flag
XBRL Flag

Acquired At
```

EDINET Example：

```text
Source System:
EDINET

Document ID:
S100XR06

Document Type:
120

EDINET Code:
E02081

Security Code:
67230

Period End:
2025-12-31

Submitted At:
2026-03-19 14:22
```

## Important

以下をSource Document Identityとして使用しない。

```text
Company Name only
File Name only
Web Page Title only
```

Primary Filing Identity Candidate：

```text
Source System
+
Document ID
```

---

# 6. Layer 1: Raw Financial Fact

## Purpose

Sourceに存在するNumeric Factを可能な限り忠実に保持する。

Raw Financial Fact Candidate Fields：

```text
Source Document Identity

QName
Namespace URI
Prefix
Local Name

Label

ContextRef

Period Classification
Current / Prior Classification

Consolidation Classification

UnitRef
Unit Meaning

Decimals

Raw Value

Source Format
CSV / XBRL
```

Example：

```text
QName:
jpigp_cor:WorkInProcessCAIFRS

Namespace:
http://disclosure.edinet-fsa.go.jp/taxonomy/jpigp/2024-11-01/jpigp_cor

ContextRef:
CurrentYearInstant

UnitRef:
JPY

Decimals:
-6

Raw Value:
121437000000
```

Classification：

```text
Source Fact
```

---

# 7. Raw Value Principle

Raw Fact ValueはSource表現とFinancial Numeric Valueを区別する可能性がある。

Candidate：

```text
Raw Text Value
Parsed Numeric Value
```

Example：

```text
Raw Text Value:
121437000000

Parsed Numeric Value:
121437000000
```

現時点のEDINET Numeric Factでは同一になるケースが多い。

ただしProduction Architectureでは、

```text
nil
sign
scale
decimals
unit
```

等のSource Semanticsを確認する必要がある可能性がある。

したがって、

```text
Read string
↓
Immediately decimal
↓
Discard raw representation
```

をProduction Ruleとして確定しない。

---

# 8. QName Preservation Rule

QNameは必ずSource Identityとして保持する。

Example：

```text
jppfs_cor:WorkInProcess
```

```text
jpigp_cor:WorkInProcessCAIFRS
```

```text
jpcrp030000-asr_E35948-000:
SemiFinishedProductsAndWorkInProgressCAIFRS
```

これらを取得直後に、

```text
WorkInProcess
```

へ統合してはならない。

Reason：

```text
Taxonomy Lineage Loss

Company Extension Detection Loss

Taxonomy Version Comparison Loss

Mapping Review Impossibility
```

Semantic Mappingは別Layerで行う。

---

# 9. Namespace Preservation Rule

PrefixのみをTaxonomy Identityとして使用しない。

Example：

```text
jpigp_cor
```

はPrefixである。

Taxonomy Identity Candidateは、

```text
Namespace URI
```

を含める。

Observed Example：

```text
http://disclosure.edinet-fsa.go.jp/taxonomy/jpigp/2024-11-01/jpigp_cor
```

and

```text
http://disclosure.edinet-fsa.go.jp/taxonomy/jpigp/2025-11-01/jpigp_cor
```

Taxonomy Versionが異なる。

したがって、

```text
Prefix + Local Name
```

だけで永続的なConcept Identityとみなしてはならない。

Candidate Identity：

```text
Namespace URI
+
Local Name
```

QNameはSource Display Identityとして併存保持する。

---

# 10. Context Preservation Rule

ContextRefはRaw Evidenceとして保持する。

Examples：

```text
CurrentYearInstant

Prior1YearInstant

CurrentYearInstant_NonConsolidatedMember

Prior1YearInstant_NonConsolidatedMember

CurrentYearDuration

Prior1YearDuration
```

Raw Fact取得時点で、

```text
Current
Prior
Consolidated
NonConsolidated
Instant
Duration
```

へ分類する場合でも、Original ContextRefを失ってはならない。

Correct：

```text
ContextRef:
CurrentYearInstant

Period Role:
Current

Consolidation Role:
Consolidated Candidate

Period Type:
Instant
```

Incorrect：

```text
Context:
Current
```

Original Context Evidenceを保持する。

---

# 11. Layer 2: Fact Eligibility Classification

## Purpose

Raw Financial FactがInventory Observation Candidateとして利用可能か判定する。

Eligibility Classification Candidate：

```text
Eligible Inventory Balance Fact

Eligible Inventory Component Fact

Inventory-related Non-balance Fact

TextBlock Context

Wrong Consolidation Scope

Wrong Period Type

Wrong Unit

Ambiguous

Rejected
```

---

# 12. Balance Fact Eligibility

Inventory Balance Candidateには最低限以下を要求する。

```text
Numeric Fact

Instant Fact

Validated Accounting Scope

Validated Consolidation Scope

Validated Unit

Inventory Financial Meaning
```

Example：

```text
jpigp_cor:InventoriesCAIFRS
CurrentYearInstant
JPY
```

Candidate：

```text
Eligible Inventory Balance Fact
```

---

# 13. Duration Fact Exclusion

以下はInventory関連FactであってもInventory Stock Valueではない。

Example：

```text
jppfs_cor:DecreaseIncreaseInInventoriesOpeCF
```

```text
jpigp_cor:DecreaseIncreaseInInventoriesOpeCFIFRS
```

Characteristics：

```text
Duration
Cash Flow
Inventory Change
```

Classification：

```text
Inventory-related Non-balance Fact
```

Inventory Balance Datasetへ混在させない。

---

# 14. Write-down Fact Separation

Example：

```text
jpcrp_cor:WriteDownsOfInventories
```

これはInventory Balance Factではない。

Classification：

```text
Inventory Write-down Fact Candidate
```

Future Observation Candidate：

```text
InventoryWriteDown
```

しかし、

```text
Inventory
```

とは別Semantic Roleである。

Inventory Keyword Matchを理由にInventory Balanceとして取得してはならない。

---

# 15. TextBlock Separation

Example：

```text
jpigp_cor:NotesInventoriesConsolidatedFinancialStatementsIFRSTextBlock
```

Classification：

```text
Inventory Context TextBlock
```

TextBlockは、

```text
Component Discovery
Financial Meaning Cross-reference
Reported Total Cross-check
Accounting Policy Context
```

に使用可能である。

ただし、

```text
Direct Numeric Inventory Observation
```

として保存しない。

Numeric Fact及びTextBlock Evidenceを混在させない。

---

# 16. Consolidation Scope Rule

Primary Inventory Observation Candidateは、

```text
Consolidated
```

とする。

Example：

```text
CurrentYearInstant
```

と、

```text
CurrentYearInstant_NonConsolidatedMember
```

が同一QNameで存在する可能性がある。

Therefore：

```text
QName Match Only
=
Invalid Extraction Rule
```

Primary Common Observation：

```text
Consolidated Inventory
```

Non-consolidated Factは、

```text
Separate Raw Fact
```

として保持可能。

ただしPrimary Inventory Featureへ自動混入させない。

---

# 17. Unit Validation Rule

Initial Inventory Observation Candidateでは、

```text
JPY
```

をPrimary Unitとする。

Raw FactにはUnitRefを保持する。

Example：

```text
UnitRef:
JPY
```

以下は禁止する。

```text
JPY Fact
+
USD Fact
Component Sum

Monetary Fact
+
pure Fact
```

Unit ValidationはDerived Calculation前に必須とする。

---

# 18. Decimals Preservation Rule

DecimalsはRaw Fact Evidenceとして保持する。

Observed Examples：

```text
-3
-6
```

Meaning：

Source Fact Precision / Reporting Precisionに関係するMetadata Candidate。

Decimalsを無視して、

```text
Component Sum
must exactly equal
Reported Total
```

というValidation Ruleを作成してはならない。

Sanken Electric及びTokyo Electron Validationでは、
Component SumとReported Total Candidateに1百万円差を確認した。

Classification：

```text
Precision / Rounding Difference Candidate
```

Tolerance Rule：

```text
NOT YET DEFINED
```

---

# 19. Layer 3: Semantic Component Mapping

## Purpose

異なるSource ConceptをCanonical Financial MeaningへMappingする。

Example：

```text
Source Concept
↓
Semantic Role
```

Mapping Candidate：

```text
jppfs_cor:MerchandiseAndFinishedGoods
→
FinishedGoods
```

```text
jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS
→
FinishedGoods
```

```text
jpigp_cor:FinishedGoodsCAIFRS
→
FinishedGoods
```

```text
jppfs_cor:WorkInProcess
→
WorkInProcess
```

```text
jpigp_cor:WorkInProcessCAIFRS
→
WorkInProcess
```

```text
SemiFinishedProductsAndWorkInProgressCAIFRS
→
WorkInProcess
```

```text
jppfs_cor:RawMaterialsAndSupplies
→
RawMaterials
```

```text
jpigp_cor:RawMaterialsCAIFRS
→
RawMaterials
```

```text
jpigp_cor:RawMaterialsAndSuppliesCAIFRS
→
RawMaterials
```

```text
jpigp_cor:OtherInventoriesCAIFRS
→
Other
```

---

# 20. Canonical Inventory Semantic Role Candidate

Initial Candidate：

```text
InventoryTotal

FinishedGoods

WorkInProcess

RawMaterials

Other
```

Important：

これはInitial Research Candidateである。

Production Master定義ではない。

追加企業Validationにより、

```text
Merchandise

SemiFinishedGoods

Supplies

Consumables

SpareParts
```

等を独立Roleとして扱う必要が生じる可能性がある。

無理に4 Componentへ圧縮してはならない。

Unknown Conceptは、

```text
Unknown / Unmapped
```

として保持する。

---

# 21. Mapping Confidence

Semantic MappingにはConfidenceまたはReviewer Statusが必要となる可能性がある。

Candidate：

```text
Direct Standard Mapping

Supported Semantic Mapping

Company Extension Reviewed

Inference

Unmapped
```

Example：

```text
jpigp_cor:WorkInProcessCAIFRS
→
WorkInProcess

Mapping Class:
Direct Standard Mapping
```

Kioxia：

```text
SemiFinishedProductsAndWorkInProgressCAIFRS
→
WorkInProcess

Mapping Class:
Company Extension Reviewed
```

## Important

Company Extension MappingをQName文字列だけから自動確定してはならない。

Evidence Candidate：

```text
Japanese Label

English Concept Name

Inventory Note Position

Component Sum Reconciliation

Company Financial Statement Meaning

Reviewer Decision
```

---

# 22. Mapping Versioning

Semantic Mapping RuleはVersion管理候補とする。

Example：

```text
InventorySemanticMappingVersion:
1
```

Reason：

Taxonomy ChangeまたはResearch CorrectionによりMappingが変更される可能性がある。

Derived Observationは、

```text
Mapping Version
```

をLineage Candidateとして保持する必要がある。

Mapping変更後に過去ObservationをSilent Overwriteしてはならない。

---

# 23. Layer 4: Canonical Financial Observation

Semantic Mapping後にCanonical Observation Candidateを構成する。

Example：

```text
Company:
Renesas Electronics

Period End:
2025-12-31

Observation:
InventoryTotal

Value:
185903000000

Unit:
JPY

Scope:
Consolidated
```

Component：

```text
Observation:
FinishedGoods

Value:
44538000000
```

```text
Observation:
WorkInProcess

Value:
121437000000
```

```text
Observation:
RawMaterials

Value:
19928000000
```

Canonical ObservationはSource Factそのものではない。

Classification：

```text
Normalized Observation
```

Source Fact Lineageを必須とする。

---

# 24. One Source Fact to One Semantic Role Principle

Initial Candidate Rule：

```text
1 Raw Fact
→
0 or 1 Primary Semantic Role
```

理由：

一つのFactを複数Componentへ重複MappingするとComponent SumでDouble Countが発生する可能性がある。

Example：

```text
MerchandiseAndFinishedGoods
```

を、

```text
Merchandise
+
FinishedGoods
```

へ2重展開してはならない。

Initial Mapping Candidate：

```text
MerchandiseAndFinishedGoods
→
FinishedGoods
```

ただしこれはSemantic Simplificationである。

後のResearchで、

```text
MerchandiseAndFinishedGoods
```

を独立Canonical RoleとすべきEvidenceが得られた場合はMappingを再評価する。

---

# 25. Layer 5: Derived Observation

Derived ObservationはCanonical Financial Observationから計算する。

Examples：

```text
InventoryTotalDerived

InventoryGrowthYoY

InventoryGrowthQoQ

FinishedGoodsGrowthYoY

WorkInProcessGrowthYoY

RawMaterialsGrowthYoY

InventoryToRevenue

InventoryRevenueGrowthGap

InventoryCompositionRatio
```

Derived ObservationはSource Factとして扱わない。

---

# 26. Inventory Total Strategy

Inventory Totalの取得戦略はStructure Typeにより異なる。

## Type A

```text
Single Total Inventory Fact
```

Strategy：

```text
Use Validated Total Source Fact
```

## Type B

```text
Component Facts Only
```

Strategy：

```text
Validated Components
↓
Derived Inventory Total
```

## Type C

```text
Total Fact
+
Component Facts
```

Strategy：

```text
Use Total Source Fact

Component Sum
=
Validation / Composition Observation
```

## Type D

```text
Company Extension Required
```

Strategy：

```text
Semantic Mapping Review
```

## Type E

```text
TextBlock Only
```

Strategy：

```text
Separate Table / TextBlock Research
```

## Type U

```text
Unknown
```

Strategy：

```text
Do Not Force Extraction
```

---

# 27. Source Fact Priority Rule

Inventory TotalがSource Factとして存在し、
Eligibility Validationを通過する場合、

```text
Source Total Fact
```

をPrimary Total Observation Candidateとする。

Component SumでSource Totalを置換しない。

Example：

Kioxia：

```text
jpigp_cor:InventoriesCAIFRS
```

Primary：

```text
Source Total Fact
```

Component Sum：

```text
Cross-check
```

Reason：

```text
Source Fact
>
Equivalent Derived Observation
```

ただしSource FactのScopeまたはMeaningが不明な場合は自動採用しない。

---

# 28. Component Sum Reconciliation

Type Cでは以下を評価する。

```text
Reported Total
vs
Component Sum
```

Candidate Result：

```text
Exact Match

Precision-consistent Difference

Unexplained Difference

Component Coverage Incomplete

Unit Mismatch

Scope Mismatch
```

Exact MatchのみをPASS条件としない。

Decimals-aware Reconciliation Ruleは別Researchで定義する。

Current Status：

```text
Research Backlog
```

---

# 29. Layer 6: Knowledge Interpretation

Canonical / Derived ObservationをInvestment Meaningへ変換するLayer。

Examples：

```text
Inventory Pressure

Inventory Normalization

Demand Collapse / Forced Destocking

Demand-backed Inventory Build
```

これはFinancial Data Acquisition Layerではない。

Example：

```text
Raw Materials YoY +327%
```

Fact / Derived Observation。

```text
Production Ramp
```

Interpretation Candidate。

両者を同一Recordまたは同一Evidence Classとして扱ってはならない。

---

# 30. Fact / Observation / Interpretation Separation

Example：

## Source Fact

```text
RawMaterialsCAIFRS
Current:
79,093,000,000 JPY
```

## Derived Observation

```text
Raw Materials YoY:
+327.83%
```

## Interpretation Candidate

```text
Strategic raw material buildup
```

## Knowledge Conclusion

```text
Demand-backed Inventory Build
```

Current EvidenceではInterpretation Candidate及びKnowledge Conclusionは未確定。

Therefore：

```text
Fact
≠
Derived Observation
≠
Interpretation
≠
Knowledge Conclusion
```

---

# 31. Point-in-Time Boundary

Layer TransformationはPoint-in-Time Ruleを破ってはならない。

Example：

```text
Period End:
2025-12-31

Submitted At:
2026-03-19
```

Observation Available From Candidate：

```text
2026-03-19
```

Prediction：

```text
2026-02-01
```

Result：

```text
Observation Not Available
```

Semantic Mappingが後日承認された場合でも、
Source FactのHistorical Availability Dateを変更してはならない。

Mapping approval dateとSource availability dateは別概念である。

---

# 32. Research Asset Boundary

Research Assetとして以下を分離する。

## A. Acquisition Evidence

Purpose：

```text
What fact existed in the source?
```

Includes：

```text
Document Identity
Raw QName
Namespace
ContextRef
UnitRef
Decimals
Raw Value
CSV / XBRL Match Result
```

---

## B. Eligibility Research

Purpose：

```text
Is this fact usable for inventory observation?
```

Includes：

```text
Instant / Duration
Consolidated / NonConsolidated
Balance / Cash Flow / Write-down
Unit Validation
Ambiguity
```

---

## C. Semantic Mapping Research

Purpose：

```text
What canonical financial meaning does this fact represent?
```

Includes：

```text
Source Concept
Canonical Semantic Role Candidate
Mapping Evidence
Mapping Confidence
Reviewer Decision
Mapping Version Candidate
```

---

## D. Derived Observation Research

Purpose：

```text
What calculation should be performed?
```

Includes：

```text
Formula
Input Semantic Roles
Period Alignment
Precision Rule
Formula Version
Derived Result
```

---

## E. Knowledge Interpretation Research

Purpose：

```text
What investment meaning may the observation have?
```

Includes：

```text
Hypothesis
Supporting Evidence
Contradicting Evidence
Regime
Lag
Target
Validation Result
```

---

# 33. Prohibited Coupling

以下を禁止する。

```text
Raw QName
directly becomes
ML Feature Name
```

```text
Keyword Match
directly becomes
Semantic Mapping
```

```text
Component Sum
directly becomes
Source Fact
```

```text
Inventory Increase
directly becomes
Negative Signal
```

```text
Inventory Decline
directly becomes
Positive Signal
```

```text
Company Extension
directly becomes
Unsupported / Rejected
```

```text
Mapping Change
silently overwrites
Historical Observation
```

---

# 34. Production Architecture Candidate

Current Architecture Candidate：

```text
EDINET Filing Discovery
↓
Source Document Identity
↓
Raw Financial Fact Extraction
↓
Fact Eligibility Classification
↓
Semantic Component Mapping
↓
Canonical Financial Observation
↓
Derived Observation
↓
Knowledge Interpretation
↓
ML / Decision / Advisor
```

Status：

```text
Research Architecture Candidate
```

Production Approval：

```text
NOT YET APPROVED
```

---

# 35. Research Reviewer Evaluation

## Evidence Separation

```text
PASS
```

Source Fact、Normalized Observation、Derived Observation、Interpretationを分離する。

## Company Extension Treatment

```text
PASS
```

ExtensionをRejectせず、Semantic Mapping Review対象とする。

## Context Governance

```text
PASS
```

Original ContextRefを保持しつつClassificationする。

## Precision Governance

```text
PASS WITH BACKLOG
```

Decimalsを保持する。

Tolerance Ruleは未定義。

## Point-in-Time

```text
PASS
```

Source AvailabilityとMapping Approvalを分離する。

---

# 36. Architecture Reviewer Decision

```text
APPROVE RESEARCH BOUNDARY
```

Approved Boundary Candidate：

```text
Raw Financial Fact
≠
Semantic Mapping
≠
Canonical Observation
≠
Derived Observation
≠
Knowledge Interpretation
```

This separation is mandatory for the next Research Design phase.

Not Approved：

```text
DDL
Entity
Production Parser
Production Mapping Master
ML Feature Implementation
```

---

# 37. Current Decision

```text
Initial 7-company Validation:
CLOSED / PASS

EDINET Acquisition Feasibility:
PASS

Raw Observation Boundary:
DEFINED

Semantic Mapping Boundary:
DEFINED

Production Architecture:
NOT APPROVED

Current Phase:
Research
```

---

# 38. Exact Next Task

次のTaskは以下とする。

```text
Inventory Semantic Mapping Research Design
```

Purpose：

> Initial 7-company Validationで確認したSource Concept Variationを用いて、Semantic Mapping RuleをResearch・Reviewするための標準Procedureを定義する。

Next Research Questions：

```text
What evidence is required to map a source concept?

How should standard taxonomy concepts be approved?

How should company extension concepts be reviewed?

How should mapping confidence be classified?

How should taxonomy version changes be handled?

How should unmapped concepts be retained?

How should mapping conflicts be escalated?

What is the reviewer approval gate?
```

Important：

Semantic Mapping TableまたはDDLをまだ作成しない。

まずMapping Research Procedure及びReviewer Gateを定義する。
