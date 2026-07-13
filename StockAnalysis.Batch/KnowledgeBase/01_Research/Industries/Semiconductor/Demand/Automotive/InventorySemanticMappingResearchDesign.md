# Inventory Semantic Mapping Research Design

## 1. Document Purpose

本書は、EDINET Inventory Financial Factについて、

```text
Source Concept
↓
Canonical Semantic Role
```

へのMappingをResearch・Review・Approvalするための標準Procedureを定義するResearch Design Artifactである。

本書の目的はSemantic Mapping Master、Database Table、EntityまたはProduction Mapping Logicを設計することではない。

目的は以下である。

> Raw Financial FactのSource Identityを維持したまま、異なるTaxonomy ConceptおよびCompany Extension ConceptをCanonical Inventory Semantic RoleへMappingするためのEvidence Requirement、Research Procedure、Conflict HandlingおよびReviewer Gateを定義する。

Status：

```text
Research Design Artifact
Semantic Mapping Research Procedure
Pre-Catalog
Pre-DDL
Production Mapping Not Approved
```

---

# 2. Background

Initial 7-company EDINET Inventory Cross-company Validationでは以下を確認した。

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

Observed Inventory Concept Variation：

```text
jppfs_cor:MerchandiseAndFinishedGoods

jppfs_cor:WorkInProcess

jppfs_cor:RawMaterialsAndSupplies

jpigp_cor:InventoriesCAIFRS

jpigp_cor:FinishedGoodsCAIFRS

jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS

jpigp_cor:WorkInProcessCAIFRS

jpigp_cor:RawMaterialsCAIFRS

jpigp_cor:RawMaterialsAndSuppliesCAIFRS

jpigp_cor:OtherInventoriesCAIFRS
```

Company Extension Example：

```text
SemiFinishedProductsAndWorkInProgressCAIFRS
```

したがって、

```text
Inventory Component
=
Fixed QName Schema
```

は支持されない。

一方、

```text
Raw QName
directly becomes
ML Feature
```

も禁止する。

Semantic Mapping Layerが必要である。

---

# 3. Research Objective

Semantic Mapping ResearchのObjectiveは、

Source ConceptをCanonical Semantic Roleへ機械的に分類することではない。

以下をEvidenceに基づいて判断することである。

```text
What financial meaning does this source fact represent?

Is the meaning sufficiently stable for normalization?

Does the mapping preserve economically relevant distinctions?

Can the mapping cause double counting?

Is the mapping supported across taxonomy versions?

Does a company extension require company-specific treatment?

Should the concept remain unmapped?
```

Research Successは、

```text
All Concepts Mapped
```

ではない。

以下もResearch Successとする。

```text
Mapping Rejected

Mapping Deferred

Company-specific Mapping

Unmapped Retained

Canonical Role Expansion Required
```

---

# 4. Core Principle

最重要原則は以下である。

```text
Semantic Convenience
must not override
Source Meaning.
```

CanonicalizationのためにFinancial Meaningを過度に単純化してはならない。

Example：

```text
MerchandiseAndFinishedGoods
```

を、

```text
FinishedGoods
```

へMappingするCandidateは存在する。

しかし、

```text
Merchandise
=
Finished Goods
```

というAccounting Factを意味しない。

これは、

```text
Canonical Simplification Candidate
```

である。

したがってMapping Reviewでは、

```text
Source Meaning
Canonical Meaning
Information Loss
Downstream Use
```

を評価する。

---

# 5. Research Scope

Initial Scope：

```text
Inventory Total

Finished Goods

Work In Process

Raw Materials

Other Inventories
```

Current Canonical Semantic Role Candidate：

```text
InventoryTotal

FinishedGoods

WorkInProcess

RawMaterials

Other
```

Important：

これらはProduction Masterではない。

Mapping Researchによって、

```text
Merchandise

SemiFinishedGoods

Supplies

Consumables

SpareParts
```

等を独立Roleとして追加する可能性がある。

Canonical Role数を最初から固定しない。

---

# 6. Mapping Research Unit

Research Unitは以下とする。

```text
Source Concept Identity
+
Taxonomy Version
+
Accounting Context
+
Observed Filing Evidence
```

Example：

```text
Namespace URI:
http://disclosure.edinet-fsa.go.jp/taxonomy/jpigp/2024-11-01/jpigp_cor

Local Name:
WorkInProcessCAIFRS

Accounting Standard:
IFRS

Observed Company:
Renesas Electronics

Observed Filing:
S100XR06
```

QName文字列だけをResearch Unitとしない。

---

# 7. Source Concept Identity

Primary Concept Identity Candidate：

```text
Namespace URI
+
Local Name
```

Additional Source Identity：

```text
QName

Prefix

Taxonomy Version Candidate

Source Label
```

Example：

```text
QName:
jpigp_cor:WorkInProcessCAIFRS

Namespace URI:
http://disclosure.edinet-fsa.go.jp/taxonomy/jpigp/2024-11-01/jpigp_cor

Local Name:
WorkInProcessCAIFRS

Label:
仕掛品、流動資産（IFRS）
```

PrefixのみでConceptを識別しない。

---

# 8. Taxonomy Version Rule

Initial Validationでは以下のTaxonomy Version差を確認した。

```text
jpigp/2024-11-01

jpigp/2025-11-01
```

したがって、

```text
Same Local Name
=
Automatically Same Approved Mapping
```

とはしない。

Mapping Researchでは以下を確認する。

```text
Local Name

Standard Label

Definition if available

Accounting Presentation

Observed Financial Statement Position

Taxonomy Version Change
```

## Candidate Rule

同一Local Nameが複数Taxonomy Versionに存在し、

Financial MeaningにMaterial Changeが確認されない場合、

```text
Cross-version Mapping Candidate
```

とする。

ただしReviewer Approvalが必要。

Taxonomy Version差をSilent Ignoreしない。

---

# 9. Mapping Evidence Hierarchy

Semantic Mapping Evidence Priorityは以下とする。

## Priority 1：Structured Source Meaning

Examples：

```text
Standard Taxonomy Concept

Official Concept Label

Taxonomy Definition

Presentation Relationship

Calculation Relationship
```

最優先Evidence。

---

## Priority 2：Same Filing Financial Statement Context

Examples：

```text
Inventory Note

Balance Sheet Position

Component Table

Reported Total

Component Sum Reconciliation
```

Source Conceptが実際にどのFinancial Meaningで使用されているか確認する。

---

## Priority 3：Official Company Filing Narrative

Examples：

```text
Accounting Policy

Inventory Note Explanation

Audit KAM

Company Financial Statement Description
```

Semantic Cross-referenceに使用する。

---

## Priority 4：Cross-company Reproduction

同一Conceptまたは同一Meaningが複数企業で確認されるか。

Example：

```text
jppfs_cor:WorkInProcess
```

Observed：

```text
ROHM
Fuji Electric
Sanken Electric
Torex Semiconductor
Tokyo Electron
```

Cross-company ReproductionはMapping Confidenceを強化する。

---

## Priority 5：Concept Name Inference

Example：

```text
SemiFinishedProductsAndWorkInProgressCAIFRS
```

Name Semantics。

これは単独ではApproval Evidenceとして不十分。

Classification：

```text
Inference Evidence
```

必ず他Evidenceと組み合わせる。

---

# 10. Minimum Evidence Requirement

Semantic Mapping Approvalには最低限以下を要求する。

```text
Source Concept Identity Confirmed

Numeric Fact Confirmed

Eligible Inventory Component Fact

Source Label or Equivalent Meaning Evidence

Financial Statement Context Confirmed

No Known Double-count Conflict

Reviewer Evaluation
```

Company Extensionでは追加で以下を要求する。

```text
Same Filing Note Cross-reference
or
Component Reconciliation Evidence
or
Equivalent Strong Primary Source Evidence
```

QName文字列だけでCompany Extension MappingをApproveしない。

---

# 11. Mapping Candidate Record

Research Sheet Candidate Fields：

```text
Source Namespace URI

Source QName

Source Local Name

Source Prefix

Taxonomy Version

Source Label

Accounting Standard

Observed Company

Observed Document ID

Observed ContextRef

Observed UnitRef

Observed Decimals

Source Value Example

Eligibility Classification

Canonical Semantic Role Candidate

Mapping Evidence

Contradicting Evidence

Information Loss Risk

Double-count Risk

Mapping Confidence Candidate

Research Reviewer Decision

Reviewer Note

Mapping Version Candidate
```

これはResearch Sheet Candidateである。

Database DDLではない。

---

# 12. Mapping Confidence Classification

Initial Classification Candidate：

```text
M1
Direct Standard Mapping

M2
Strongly Supported Semantic Mapping

M3
Company Extension Reviewed

M4
Inference Mapping Candidate

M5
Unmapped
```

---

# 13. M1: Direct Standard Mapping

Definition：

```text
Standard Taxonomy Concept
+
Source Label directly matches
Canonical Semantic Role
+
Financial Statement Context consistent
```

Example Candidate：

```text
jpigp_cor:WorkInProcessCAIFRS
→
WorkInProcess
```

Evidence：

```text
Standard Concept

Label:
仕掛品

Inventory Note Position:
Inventory Component

Component Reconciliation:
Consistent
```

Candidate Classification：

```text
M1
Direct Standard Mapping
```

---

# 14. M2: Strongly Supported Semantic Mapping

Definition：

Source Concept Meaningは明確だが、
Canonical RoleがSource Labelより広いまたはSimplifiedである。

Example Candidate：

```text
jppfs_cor:MerchandiseAndFinishedGoods
→
FinishedGoods
```

Concern：

```text
Merchandise
+
Finished Goods
```

を、

```text
FinishedGoods
```

へCanonicalizeするためInformation Lossがある。

Candidate Classification：

```text
M2
Strongly Supported Semantic Mapping
```

Mapping Note Candidate：

```text
Canonical role includes merchandise and finished goods.
```

Information Loss Riskを明示する。

---

# 15. M3: Company Extension Reviewed

Definition：

```text
Company Extension Concept
+
Primary Filing Evidence
+
Semantic Review
```

Example：

```text
SemiFinishedProductsAndWorkInProgressCAIFRS
→
WorkInProcess
```

Observed Company：

```text
Kioxia Holdings
```

Evidence：

```text
Inventory Note Position

Japanese Label:
半製品及び仕掛品

Component Sum Reconciliation

Total Inventory Cross-check

Raw XBRL Fact
```

Candidate Classification：

```text
M3
Company Extension Reviewed
```

## Important

M3 Mappingは、

```text
Global Standard Concept Mapping
```

として扱わない。

Initial Scope Candidate：

```text
Company / Filing Family Reviewed Mapping
```

追加企業で同一Extension Conceptが確認された場合は再評価する。

---

# 16. M4: Inference Mapping Candidate

Definition：

Concept Name等からMappingが推測できるが、
Primary Evidenceが不足する。

Example：

```text
UnknownCompanyExtension:
InventoryRelatedAssetXYZ
```

LabelまたはFinancial Statement Positionが不明。

Classification：

```text
M4
Inference Mapping Candidate
```

Production Normalization：

```text
NOT ALLOWED
```

Research only。

Evidence追加を待つ。

---

# 17. M5: Unmapped

Definition：

```text
Meaning Ambiguous

Conflicting Evidence

Insufficient Evidence

Canonical Role Missing
```

Classification：

```text
M5
Unmapped
```

## Important

UnmappedはFailureではない。

Source FactはRaw Evidenceとして保持する。

禁止：

```text
Unknown Concept
↓
Closest Role Guess
```

Unmapped Concept CountはResearch Quality Indicator Candidateとする。

---

# 18. Standard Taxonomy Mapping Procedure

Standard Taxonomy ConceptのResearch Procedure：

```text
1. Source Concept Identity確認

2. Numeric Fact / Context確認

3. Inventory Eligibility確認

4. Source Label確認

5. Same Filing Note確認

6. Canonical Role Candidate選定

7. Information Loss評価

8. Double-count Risk評価

9. Cross-company Evidence確認

10. Taxonomy Version差確認

11. Research Reviewer判定
```

全Step完了前にApproved Mappingとしない。

---

# 19. Company Extension Mapping Procedure

Company Extensionは別Procedureとする。

```text
1. Extension Namespace確認

2. Filing Identity確認

3. Raw QName / Local Name確認

4. Label確認

5. Context / Unit / Decimals確認

6. Financial Statement Position確認

7. Inventory Note Cross-reference

8. Reported Total確認

9. Component Sum Reconciliation

10. Canonical Role Candidate評価

11. Information Loss評価

12. Double-count Risk評価

13. Company-specific Scope評価

14. Research Reviewer判定
```

## Mandatory Gate

Company Extensionについて、

```text
Concept Name Looks Obvious
```

だけではApproveしない。

---

# 20. Component Sum as Mapping Evidence

Component Sum ReconciliationはMapping Evidenceとして利用可能。

Example：

Kioxia：

```text
Finished Goods
+
Semi-finished Products / WIP
+
Raw Materials
+
Other

=
Reported Inventory Total
```

Prior：

```text
Exact Match
```

Current：

```text
Exact Match
```

これは、

```text
SemiFinishedProductsAndWorkInProgressCAIFRS
```

がInventory Componentであることを支持する。

However：

```text
Component Sum Match
≠
Semantic Role Proven Alone
```

である。

例えば未知ConceptがComponent Sumに含まれても、

```text
FinishedGoods
WorkInProcess
RawMaterials
Other
```

のどれかはSumだけでは判断できない。

Component SumはSupporting Evidenceとする。

---

# 21. Information Loss Evaluation

Canonical Mapping時に失われるMeaningを評価する。

Candidate Classification：

```text
None

Minor

Material

Unknown
```

Example：

```text
WorkInProcessCAIFRS
→
WorkInProcess
```

Candidate：

```text
Information Loss:
None / Minor
```

Example：

```text
MerchandiseAndFinishedGoods
→
FinishedGoods
```

Candidate：

```text
Information Loss:
Material Candidate
```

Reason：

```text
Merchandise distinction is removed.
```

MappingをRejectするか、
Canonical Roleを変更するか、
Downstream Usageを限定するかをReviewerが判断する。

---

# 22. Canonical Role Expansion Rule

既存Canonical Roleへ無理にMappingしてはならない。

以下の場合、

```text
Canonical Role Expansion Review
```

を実施する。

```text
Material Information Loss

Repeated Unmapped Concepts

Repeated Combined Concepts

Economically Different Component

Downstream Metric Distortion Risk
```

Example：

複数企業で、

```text
MerchandiseAndFinishedGoods
```

が継続的に確認され、

FinishedGoods単独との差がInvestment Interpretation上重要であるEvidenceが得られた場合、

```text
MerchandiseAndFinishedGoods
```

を独立Canonical Roleとする可能性がある。

Canonical Schemaの単純さを優先しない。

---

# 23. Double-count Risk Evaluation

Mapping ResearchではDouble-count Riskを必須確認する。

Example：

```text
InventoryTotal
```

と、

```text
FinishedGoods
WorkInProcess
RawMaterials
```

を同一Total Calculationへ全て加算してはならない。

Incorrect：

```text
InventoryTotal
+
FinishedGoods
+
WorkInProcess
+
RawMaterials
```

Correct Candidate：

```text
InventoryTotal
=
Primary Total

Components
=
Composition / Reconciliation
```

また、

```text
MerchandiseAndFinishedGoods
```

を、

```text
Merchandise
+
FinishedGoods
```

へ重複展開してはならない。

---

# 24. Mapping Conflict Types

Conflict Classification Candidate：

```text
C1
Same Source Concept
Multiple Canonical Role Candidates

C2
Different Concepts
Potential Duplicate Meaning

C3
Taxonomy Version Meaning Change

C4
Company Extension Meaning Conflict

C5
Source Label / Note Conflict

C6
Component Sum Conflict

C7
Accounting Standard Semantic Conflict

C8
Canonical Role Insufficient
```

ConflictはSilent Resolutionしない。

---

# 25. Conflict Escalation Procedure

Conflict発生時：

```text
Mapping Candidate
↓
CONFLICT
↓
Research Reviewer
↓
Additional Primary Evidence
↓
Architecture Reviewer if schema impact exists
```

Decision Candidate：

```text
Approve Mapping

Reject Mapping

Company-specific Mapping

Split Canonical Role

Create New Canonical Role Candidate

Defer

Unmapped
```

Conflict中のConceptをProduction Mappingへ使用しない。

---

# 26. Taxonomy Version Change Procedure

新Taxonomy Version検出時：

```text
1. Namespace URI Version確認

2. Existing Local Name Mapping検索

3. Label比較

4. Definition比較

5. Financial Statement Position比較

6. Filing Usage比較

7. Material Meaning Change評価
```

Result Candidate：

```text
No Material Change

Mapping Review Required

Mapping Deprecated

New Concept

Unknown
```

## Important

```text
Same Local Name
```

だけでMapping Versionを自動継承しない。

ただし、
毎年全ConceptをゼロからResearchする運用も避ける。

Candidate：

```text
Prior Approved Mapping
+
Version Change Review
```

---

# 27. Cross-version Mapping Approval

以下を満たす場合、

```text
Cross-version Mapping Approval Candidate
```

とする。

```text
Same Local Name

Equivalent Label

Equivalent Financial Statement Position

No Contradicting Definition Evidence

Observed Filing Meaning Consistent

Reviewer Approval
```

Approved Candidate Example：

```text
jpigp/2024-11-01:
WorkInProcessCAIFRS

jpigp/2025-11-01:
WorkInProcessCAIFRS
```

ただし実際のApprovalはTaxonomy Research後に行う。

本書ではMappingを確定しない。

---

# 28. Unmapped Concept Governance

Unmapped Conceptは削除しない。

Research Asset Candidate：

```text
Source Concept Identity

Observed Company

Observed Document ID

Observed Value

Context

Label

Discovery Date

Unmapped Reason

Required Evidence

Reviewer Status
```

Unmapped Queue Candidate：

```text
High Materiality

Repeated Across Companies

Component Reconciliation Impact

Potential Inventory Total Impact

Low Priority Context-only
```

PriorityはMaterialityおよびDownstream Impactで決定する。

---

# 29. Mapping Review Materiality

Mapping Review Priority Candidate：

## Critical

```text
Inventory Total

Large Component

Component required for Total Derivation

Potential Double Count
```

## High

```text
Repeated Concept

Material Composition Component

Cross-company Feature Candidate
```

## Medium

```text
Company-specific Component

Advisor Context Candidate
```

## Low

```text
Immaterial Value

Text Context only

No Current Downstream Use
```

Materiality Threshold数値は本書で固定しない。

---

# 30. Reviewer Roles

## Researcher

責務：

```text
Source Fact Collection

Primary Evidence Collection

Mapping Candidate Proposal

Contradicting Evidence Recording
```

Researcherは自分のMapping ProposalをFinal Approveしない。

---

## Research Reviewer

責務：

```text
Evidence Sufficiency Review

Semantic Meaning Review

Information Loss Review

Double-count Review

Mapping Confidence Decision
```

Decision：

```text
APPROVE

CONDITIONAL APPROVE

REJECT

DEFER

UNMAPPED
```

---

## Architecture Reviewer

以下の場合のみ必須。

```text
Canonical Role Addition

Canonical Role Split

Mapping Model Change

Version Governance Change

Lineage Requirement Change

Production Architecture Impact
```

単一Concept MappingごとにArchitecture Reviewerを要求しない。

---

# 31. Reviewer Independence Rule

Research ProposalとFinal Reviewを論理的に分離する。

同一AI Workflow内で実施する場合でも、

```text
Researcher View
```

と、

```text
Reviewer View
```

を明示的に分離する。

Reviewerは以下を確認する。

```text
Was an obvious mapping accepted too quickly?

Was contradictory evidence searched?

Was canonical simplicity prioritized over meaning?

Was company-extension meaning inferred only from its name?

Was component reconciliation misused as semantic proof?

Was an unmapped concept forced into an existing role?
```

---

# 32. Mapping Approval Gate

Mapping Approvalには以下を要求する。

```text
Source Concept Identity:
CONFIRMED

Eligibility:
PASS

Financial Meaning Evidence:
SUFFICIENT

Canonical Role Candidate:
DEFINED

Information Loss:
EVALUATED

Double-count Risk:
EVALUATED

Contradicting Evidence:
REVIEWED

Taxonomy Version:
RECORDED

Reviewer Decision:
APPROVE or CONDITIONAL APPROVE
```

一つでもCritical Itemが未確認の場合、

```text
APPROVE
```

にしない。

---

# 33. Conditional Approval

以下の場合、

```text
CONDITIONAL APPROVE
```

を使用する。

Examples：

```text
Company-specific only

Specific Taxonomy Version only

Specific Filing Family only

Composition Analysis only

Not valid for Total Derivation
```

Example：

```text
Kioxia Extension Concept
→
WorkInProcess
```

Candidate Scope：

```text
Kioxia Filing Family
Inventory Composition
```

Cross-company Common Mappingへの自動昇格は禁止する。

---

# 34. Mapping Version Candidate

Mapping Research ResultにはVersion Candidateを持たせる。

Example：

```text
Inventory Semantic Mapping Research Version:
1
```

Version変更Candidate：

```text
Mapping Added

Mapping Removed

Canonical Role Changed

Scope Changed

Confidence Changed

Taxonomy Version Extension
```

Historical Derived ObservationはMapping Version Lineageを保持する必要がある。

Production DDLは後Phaseで設計する。

---

# 35. Mapping Change Impact Review

Approved Mapping変更時には以下を確認する。

```text
Affected Companies

Affected Documents

Affected Historical Observations

Affected Derived Metrics

Affected ML Features

Affected Backtests

Affected Knowledge Interpretations
```

Mapping Changeは単なるMaster Data修正ではない可能性がある。

Therefore：

```text
Mapping Change
=
Potential Data Lineage Event
```

として扱う。

---

# 36. Initial Mapping Research Candidates

Initial 7-company Validation Evidenceから以下をResearch Candidateとする。

| Source Concept Candidate                      | Canonical Role Candidate | Initial Class Candidate |
| --------------------------------------------- | ------------------------ | ----------------------- |
| `jppfs_cor:MerchandiseAndFinishedGoods`       | FinishedGoods            | M2                      |
| `jppfs_cor:WorkInProcess`                     | WorkInProcess            | M1                      |
| `jppfs_cor:RawMaterialsAndSupplies`           | RawMaterials             | M2                      |
| `jpigp_cor:InventoriesCAIFRS`                 | InventoryTotal           | M1                      |
| `jpigp_cor:FinishedGoodsCAIFRS`               | FinishedGoods            | M1                      |
| `jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS` | FinishedGoods            | M2                      |
| `jpigp_cor:WorkInProcessCAIFRS`               | WorkInProcess            | M1                      |
| `SemiFinishedProductsAndWorkInProgressCAIFRS` | WorkInProcess            | M3 Candidate            |
| `jpigp_cor:RawMaterialsCAIFRS`                | RawMaterials             | M1                      |
| `jpigp_cor:RawMaterialsAndSuppliesCAIFRS`     | RawMaterials             | M2                      |
| `jpigp_cor:OtherInventoriesCAIFRS`            | Other                    | M1 Candidate            |

Important：

本TableはApproved Mapping Masterではない。

```text
Initial Mapping Research Candidate List
```

である。

各ConceptはMapping Research SheetおよびReviewer Gateを通す。

---

# 37. Research Sheet Execution Order

Initial Mapping Research Order：

```text
1. Inventory Total
   jpigp_cor:InventoriesCAIFRS

2. Work In Process Standard Concepts
   jppfs_cor:WorkInProcess
   jpigp_cor:WorkInProcessCAIFRS

3. Finished Goods Standard Concepts
   jpigp_cor:FinishedGoodsCAIFRS

4. Merchandise + Finished Goods Concepts
   jppfs_cor:MerchandiseAndFinishedGoods
   jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS

5. Raw Materials Standard Concepts
   jpigp_cor:RawMaterialsCAIFRS

6. Raw Materials + Supplies Concepts
   jppfs_cor:RawMaterialsAndSupplies
   jpigp_cor:RawMaterialsAndSuppliesCAIFRS

7. Other Inventories
   jpigp_cor:OtherInventoriesCAIFRS

8. Kioxia Company Extension
   SemiFinishedProductsAndWorkInProgressCAIFRS
```

Rationale：

```text
Direct Standard Mapping
↓
Combined Standard Concept
↓
Other Component
↓
Company Extension
```

の順にResearch Procedureを検証する。

---

# 38. Stop Rule

以下を確認した場合、
Mapping Researchを一時停止してArchitecture Reviewする。

```text
Canonical Role causes repeated Material Information Loss

Same Source Concept has conflicting meaning across filings

Component Double Count cannot be resolved

Taxonomy Version changes material meaning

Company Extension mappings proliferate rapidly

Canonical Role count expands without stable boundary

Raw Fact lineage cannot support mapping revision
```

Production Mapping Master作成へ無理に進まない。

---

# 39. Research Reviewer Evaluation

## Evidence Hierarchy

```text
PASS
```

Primary structured source meaningを優先する。

## Company Extension Governance

```text
PASS
```

Name inferenceのみでApproveしない。

## Information Loss Governance

```text
PASS
```

Canonical simplification riskを明示する。

## Conflict Governance

```text
PASS
```

Silent Resolutionを禁止する。

## Taxonomy Version Governance

```text
PASS
```

Namespace VersionをResearch Dimensionとして保持する。

## Unmapped Governance

```text
PASS
```

UnmappedをFailureとして扱わない。

---

# 40. Architecture Reviewer Decision

```text
APPROVE SEMANTIC MAPPING RESEARCH DESIGN
```

Approved：

```text
Evidence Hierarchy

Mapping Confidence Classification

Standard Concept Research Procedure

Company Extension Research Procedure

Information Loss Review

Double-count Risk Review

Conflict Escalation

Taxonomy Version Review

Unmapped Governance

Reviewer Approval Gate
```

Not Approved：

```text
Production Mapping Master

Database DDL

Entity

Runtime Mapping Logic

Automatic Company Extension Mapping

ML Feature Mapping
```

---

# 41. Current Decision

```text
Initial 7-company Validation:
CLOSED / PASS

Raw Observation Boundary:
DEFINED

Semantic Mapping Boundary:
DEFINED

Semantic Mapping Research Design:
DEFINED

Production Semantic Mapping:
NOT APPROVED

Current Phase:
Research
```

---

# 42. Exact Next Task

次のTaskは以下とする。

```text
Inventory Semantic Mapping Research Sheet
for jpigp_cor:InventoriesCAIFRS
```

Research Target：

```text
Canonical Role Candidate:
InventoryTotal

Observed Accounting Standard:
IFRS

Observed Companies:
Kioxia Holdings
Renesas Electronics
```

Research Questions：

```text
Is the concept meaning directly equivalent to InventoryTotal?

Is the concept consistently used as consolidated current inventory?

Does taxonomy version variation change meaning?

Is context eligibility stable?

Is the concept usable as Primary Total Source Fact?

What mapping confidence should be assigned?

What reviewer decision is justified?
```

これは最初のSemantic Mapping Research Sheetとして、
Research Procedure自体をValidationするReference Mapping Caseとする。
