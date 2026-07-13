# Inventory Semantic Mapping Research Sheet

# jpigp_cor:WorkInProcessCAIFRS

## 1. Document Purpose

本書は、EDINET Inventory Semantic Mapping Research Design及びWork In Process Cross-standard Official Taxonomy Evidence Reviewに基づき、

`jpigp_cor:WorkInProcessCAIFRS`

をCanonical Inventory Semantic RoleへMapping可能か検証するResearch Sheetである。

### Mapping Candidate

`jpigp_cor:WorkInProcessCAIFRS → WorkInProcess`

本書の目的はProduction Mapping Masterを作成することではない。

目的は以下である。

> IFRS Standard TaxonomyのWork In Process Conceptについて、公式Taxonomy Evidence、Renesas Filing Evidence、Japanese GAAP Reference Mapping及びCross-standard Semantic Equivalence Pre-reviewを用いて、Canonical Semantic Role `WorkInProcess` へのMapping Approval可否をEvidenceに基づいて評価する。

### Status

* Research Sheet
* Semantic Mapping Research
* IFRS Standard Component Mapping
* Cross-standard Mapping Case
* Research Reviewer Pending
* Production Mapping Not Approved

---

## 2. Research Target

### Source Concept QName

`jpigp_cor:WorkInProcessCAIFRS`

### Local Name

`WorkInProcessCAIFRS`

### Prefix

`jpigp_cor`

### Accounting Standard

`IFRS`

### Canonical Semantic Role Candidate

`WorkInProcess`

### Initial Mapping Confidence Candidate

`M1`

`Direct Standard Mapping`

Initial ConfidenceはResearch開始時点のCandidateであり、Reviewer Approvalではない。

---

## 3. Research Questions

本Researchでは以下を確認する。

1. `WorkInProcessCAIFRS` はIFRS Inventory Componentとして仕掛品を表すか。
2. Source LabelはCanonical Role `WorkInProcess` と直接整合するか。
3. Official Taxonomy AttributeはInventory Stock Componentとして整合するか。
4. Renesas Filing EvidenceはTaxonomy上の意味と整合するか。
5. Japanese GAAP `WorkInProcess` とShared Semantic Coreを持つか。
6. IFRS Current Asset qualifierはCanonical Role Boundaryを変更するか。
7. Cross-standard MappingにMaterial Information Lossが存在するか。
8. Combined ConceptまたはCompany ExtensionとのOverlap Riskはあるか。
9. Semantic MappingとMetric Comparabilityを分離できているか。
10. M1 Direct Standard Mapping Approvalは妥当か。

---

## 4. Evidence Hierarchy

本Researchでは以下のEvidence Priorityを採用する。

### Priority 1

Official EDINET Taxonomy Evidence

Includes:

* Official IFRS Element List
* Official Labels
* Data Type
* Period Type
* Balance Attribute
* Abstract Status
* Taxonomy Version

### Priority 2

Official EDINET Concept Handling Guidance

Purpose:

* Concept Meaning Review
* Dimension / Scope Boundary
* Element Concept Evaluation Principle

### Priority 3

Validated Filing Evidence

Primary Company:

`Renesas Electronics Corporation`

Document ID:

`S100XR06`

### Priority 4

Cross-standard Official Taxonomy Evidence Review

Reference Artifact:

`InventorySemanticMappingWorkInProcessCrossStandardOfficialTaxonomyEvidence.md`

### Priority 5

Japanese GAAP Approved Research Mapping

Reference Mapping:

`jppfs_cor:WorkInProcess → WorkInProcess`

### Priority 6

Concept Name Inference

Classification:

`Supporting Inference Only`

Concept Name alone cannot approve the Mapping.

---

## 5. Source Concept Identity

### QName

`jpigp_cor:WorkInProcessCAIFRS`

### Namespace Family

`jpigp`

### Local Name

`WorkInProcessCAIFRS`

### Official Japanese Standard Label

`仕掛品`

### Official Japanese Verbose Label

`仕掛品、流動資産（IFRS）`

### Official English Standard Label

`Work in process`

### Official English Verbose Label

`Work in process - CA (IFRS)`

### Data Type

`xbrli:monetaryItemType`

### Substitution Group

`xbrli:item`

### Period Type

`instant`

### Balance Attribute

`debit`

### Abstract

`false`

### Classification

* IFRS Standard Taxonomy Concept
* Numeric Fact Concept
* Monetary Fact
* Instant Fact
* Asset-side Balance Candidate

Source Concept Identity:

`CONFIRMED`

---

## 6. Taxonomy Version Evidence

Official EDINET IFRS Element Lists confirmed the Concept in the reviewed Taxonomy Versions.

### Version A

`jpigp/2024-11-01`

### Version B

`jpigp/2025-11-01`

Observed attributes in both reviewed official lists:

* Japanese Standard Label: `仕掛品`
* Japanese Verbose Label: `仕掛品、流動資産（IFRS）`
* English Standard Label: `Work in process`
* English Verbose Label: `Work in process - CA (IFRS)`
* Data Type: `xbrli:monetaryItemType`
* Period Type: `instant`
* Balance: `debit`
* Abstract: `false`

### Current Taxonomy Version Finding

`No Material Attribute Difference Observed`

for `WorkInProcessCAIFRS` between the reviewed 2024 and 2025 official element lists.

### Classification

`Cross-version Stability Supported within Reviewed Official Attributes`

### Not Declared

`Universal Taxonomy Definition Identity`

New Taxonomy Version remains subject to Version Change Review.

---

## 7. Official Label Evaluation

### Japanese Standard Label

`仕掛品`

### English Standard Label

`Work in process`

### Canonical Semantic Role Candidate

`WorkInProcess`

Meaning Compatibility:

`DIRECT`

No combined inventory component is present in the Standard Label.

Comparison:

`WorkInProcessCAIFRS`

differs from concepts such as:

`WorkInProcessAndRawMaterialsCAIFRS`

and Company Extension:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

Therefore the current Source Concept has a more direct semantic boundary.

### Label Evaluation Result

`PASS`

---

## 8. Official Element Attribute Evaluation

### Data Type

`monetaryItemType`

Compatible with a monetary inventory component observation.

Result:

`PASS`

### Period Type

`instant`

Compatible with a balance-sheet inventory stock observation.

Result:

`PASS`

### Balance Attribute

`debit`

Consistent with an inventory asset component.

Result:

`PASS`

### Abstract Status

`false`

The Concept can represent an actual Fact.

Result:

`PASS`

### Structured Attribute Finding

Official element attributes are consistent with the proposed `WorkInProcess` Semantic Role.

However:

`Element Attributes alone ≠ Semantic Proof`

They are evaluated together with labels and Filing Evidence.

---

## 9. Filing Evidence Scope

### Company

ルネサスエレクトロニクス株式会社

`Renesas Electronics Corporation`

### Security Code

`67230`

### EDINET Code

`E02081`

### Document ID

`S100XR06`

### Document Type

`120`

### Period

`2025-01-01 - 2025-12-31`

### Submitted At

`2026-03-19 14:22`

### Accounting Standard

`IFRS`

### Consolidation Scope

`Consolidated`

Filing Identity:

`CONFIRMED`

---

## 10. Renesas Raw Financial Facts

### Prior

QName:

`jpigp_cor:WorkInProcessCAIFRS`

ContextRef:

`Prior1YearInstant`

UnitRef:

`JPY`

Decimals:

`-6`

Raw Value:

`106737000000`

### Current

QName:

`jpigp_cor:WorkInProcessCAIFRS`

ContextRef:

`CurrentYearInstant`

UnitRef:

`JPY`

Decimals:

`-6`

Raw Value:

`121437000000`

### Classification

* Numeric Fact
* Instant Fact
* Consolidated IFRS Fact Candidate
* Monetary Fact
* JPY

Eligibility Candidate:

`Eligible Inventory Component Fact`

---

## 11. Renesas Inventory Note Context

Renesas Inventory Note disclosed the following components.

* 商品及び製品
* 仕掛品
* 原材料及び貯蔵品
* 合計

### Prior

商品及び製品:

`47,619 million JPY`

仕掛品:

`106,737 million JPY`

原材料及び貯蔵品:

`22,188 million JPY`

Total:

`176,544 million JPY`

Component Sum:

`47,619 + 106,737 + 22,188 = 176,544`

Result:

`EXACT MATCH`

### Current

商品及び製品:

`44,538 million JPY`

仕掛品:

`121,437 million JPY`

原材料及び貯蔵品:

`19,928 million JPY`

Total:

`185,903 million JPY`

Component Sum:

`44,538 + 121,437 + 19,928 = 185,903`

Result:

`EXACT MATCH`

### Research Finding

The structured `WorkInProcessCAIFRS` Fact corresponds to the `仕掛品` component disclosed in the Inventory Note.

Classification:

`Strong Same-filing Semantic Evidence`

Component Sum is Supporting Evidence.

The Primary Semantic Evidence remains:

* Official Label
* Official Taxonomy Attributes
* Financial Statement Context

---

## 12. Inventory Component Eligibility

Candidate Fact must satisfy:

* Numeric Fact
* Instant Fact
* Validated Consolidation Scope
* Validated Monetary Unit
* Inventory Component Meaning

### Numeric Fact

`PASS`

### Instant Fact

`PASS`

### Consolidation Scope

`PASS within validated filing`

### Monetary Unit

`JPY`

`PASS`

### Inventory Component Meaning

`PASS`

### Eligibility Result

`Eligible Inventory Component Fact`

---

## 13. Duration Fact Separation

The following Concept also exists in IFRS financial reporting.

`jpigp_cor:DecreaseIncreaseInInventoriesOpeCFIFRS`

Observed Period Type:

`Duration`

Financial Meaning:

`Inventory Change in Operating Cash Flow`

Therefore:

`WorkInProcessCAIFRS ≠ DecreaseIncreaseInInventoriesOpeCFIFRS`

The Candidate Source Concept is an Instant Inventory Component Fact.

Eligibility Separation:

`PASS`

---

## 14. Cross-standard Reference Mapping

Existing Approved Research Mapping:

`jppfs_cor:WorkInProcess → WorkInProcess`

Mapping Class:

`M1`

Research Reviewer:

`APPROVE`

Japanese GAAP Source Meaning:

* 仕掛品
* Work in process
* Inventory Component
* Instant Monetary Fact

Current IFRS Source Meaning:

* 仕掛品
* Work in process
* Inventory Component
* Instant Monetary Fact
* Current Asset Presentation Candidate

Shared Semantic Core:

`Work in process inventory component`

Cross-standard Official Taxonomy Pre-review Result:

`PASS`

---

## 15. Cross-standard Official Attribute Comparison

| Attribute      | J-GAAP `WorkInProcess` | IFRS `WorkInProcessCAIFRS` |
| -------------- | ---------------------- | -------------------------- |
| Japanese Label | 仕掛品                    | 仕掛品                        |
| English Label  | Work in process        | Work in process            |
| Data Type      | monetaryItemType       | monetaryItemType           |
| Period Type    | instant                | instant                    |
| Balance        | debit                  | debit                      |
| Abstract       | false                  | false                      |

### Result

`Strong Official Taxonomy Attribute Alignment`

Observed Difference:

* Accounting Standard
* Taxonomy Family
* IFRS `CA` presentation qualifier

No official attribute conflict was identified within the reviewed scope.

---

## 16. Current Asset Qualifier Review

IFRS Verbose Label:

`仕掛品、流動資産（IFRS）`

English:

`Work in process - CA (IFRS)`

Canonical Candidate:

`WorkInProcess`

### Potential Concern

The Canonical Role does not preserve the Current Asset qualifier in its name.

### Supporting Evidence

The official IFRS Standard Label remains:

`仕掛品`

The official English Standard Label remains:

`Work in process`

Observed Filing Role:

`Inventory Component`

### Reviewer Interpretation Candidate

The Current Asset qualifier represents a financial statement presentation or classification dimension in the reviewed Concept.

No evidence currently shows that it changes the inventory-stage semantic identity from `WorkInProcess`.

### Information Loss Candidate

`Minor`

### Mandatory Lineage Condition

The following must remain preserved:

* Accounting Standard
* Source QName
* Namespace URI
* Source Label
* Taxonomy Version

### Future Boundary Trigger

Detection of:

`Non-current Work In Process`

or another materially different Work In Process Concept triggers:

`Canonical Role Boundary Review`

---

## 17. Semantic Identity vs Measurement Equivalence

Current Evidence supports:

`WorkInProcessCAIFRS represents Work In Process inventory.`

Current Evidence does not prove:

`IFRS and Japanese GAAP measure Work In Process identically.`

Therefore:

### Semantic Identity

`SUPPORTED`

### Accounting Measurement Equivalence

`NOT EVALUATED`

### Research Boundary

Semantic Mapping normalizes the financial observation meaning.

It does not erase the Accounting Standard dimension.

---

## 18. Semantic Identity vs Metric Comparability

Candidate Mapping:

`WorkInProcessCAIFRS → WorkInProcess`

may allow Canonical Observation creation.

However, it does not establish:

`IFRS WorkInProcess Growth`

and:

`J-GAAP WorkInProcess Growth`

having identical predictive or decision meaning.

Possible Comparability Dimensions:

* Accounting Standard
* Company
* SubSector
* Business Model
* Inventory Accounting Policy
* Revenue Recognition Structure

### Research Finding

`Semantic Mapping Approval ≠ Metric Comparability Approval`

### ML Boundary

Automatic cross-standard pooling is:

`NOT APPROVED`

Metric Comparability requires later Dataset / Validation Research.

---

## 19. Information Loss Evaluation

### Source Meaning

`Work in process - CA (IFRS)`

### Canonical Meaning

`WorkInProcess`

### Removed from Canonical Role Name

* IFRS identity
* Current Asset qualifier
* Taxonomy family

These are preserved in Source Lineage.

### Inventory-stage Meaning Loss

`None Material Identified`

### Overall Information Loss

`Minor`

Reason:

The Canonical Role preserves the core inventory-stage meaning.

### Mapping Condition

Source and Accounting Standard Lineage must remain available.

---

## 20. Double-count Risk Evaluation

Potential Risk A:

`InventoryTotal + WorkInProcess`

used in the same total calculation.

Result:

`Double Count Risk`

InventoryTotal and component roles must remain separate.

---

Potential Risk B:

`WorkInProcessCAIFRS`

and:

`WorkInProcessAndRawMaterialsCAIFRS`

appear in the same Filing / Period / Scope.

Result:

`Potential Semantic Overlap`

Automatic summation is prohibited.

---

Potential Risk C:

`WorkInProcessCAIFRS`

and Company Extension:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

map to the same Canonical Role.

If both exist in the same Filing / Period / Scope:

`Conflict Review Required`

### Double-count Risk Classification

`Medium to High depending on source structure`

### Mapping Decision Impact

The risk does not reject the Mapping.

It requires downstream Fact Selection and Conflict Governance.

---

## 21. Combined Concept Boundary

The IFRS Taxonomy includes Concept Candidates such as:

`WorkInProcessAndRawMaterialsCAIFRS`

This Concept is not semantically identical to:

`WorkInProcessCAIFRS`

Therefore:

`WorkInProcessAndRawMaterialsCAIFRS → WorkInProcess`

is not approved by this Research.

Likewise:

`Concept contains "WorkInProcess" → WorkInProcess`

is prohibited.

### Mapping Identity Rule

Mapping must use:

`Namespace URI + Local Name`

and approved Research Mapping evidence.

Substring mapping is rejected.

---

## 22. Company Extension Boundary

Kioxia Filing contained:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

Classification:

`Company Extension Source Fact`

The Concept has a Work In Process-related semantic candidate.

However, this Research does not approve:

`SemiFinishedProductsAndWorkInProgressCAIFRS → WorkInProcess`

That Mapping remains:

`M3 Candidate`

and requires Company Extension Research Procedure.

### Important

Approval of:

`WorkInProcessCAIFRS → WorkInProcess`

does not approve semantically similar Company Extensions.

---

## 23. Contradicting Evidence Search

Within current Official Taxonomy and Filing Evidence Scope:

### Same Source Concept Used as Inventory Total

`NOT OBSERVED`

### Same Source Concept Used as Cash Flow Change

`NOT OBSERVED`

### Same Source Concept Used for Non-inventory Meaning

`NOT OBSERVED`

### Standard Label Conflict

`NOT IDENTIFIED`

### English Label Conflict

`NOT IDENTIFIED`

### Period Type Conflict

`NOT IDENTIFIED`

### Balance Attribute Conflict

`NOT IDENTIFIED`

### Financial Statement Role Conflict

`NOT IDENTIFIED`

Known Difference:

`IFRS Current Asset presentation qualifier`

Current Evaluation:

`Not a contradiction to WorkInProcess semantic identity.`

### Contradicting Semantic Evidence

`NONE IDENTIFIED within current reviewed scope`

---

## 24. Canonical Role Candidate Evaluation

### Candidate

`WorkInProcess`

### Alternative Candidate A

`CurrentWorkInProcess`

Concern:

The role unnecessarily embeds a presentation qualifier into the common inventory-stage semantic identity.

Current Evidence does not justify requiring a separate role.

Decision:

`REJECT AS CURRENT PRIMARY CANDIDATE`

---

### Alternative Candidate B

`IFRSWorkInProcess`

Concern:

Accounting Standard should remain a Lineage / Context dimension rather than being embedded into the Canonical Semantic Role.

Decision:

`REJECT`

---

### Preferred Candidate

`WorkInProcess`

Reason:

* Direct Standard Label correspondence
* Exact English label correspondence
* Shared semantic core with Japanese GAAP reference concept
* Inventory-stage meaning retained
* Accounting Standard remains in lineage

Canonical Role Suitability:

`PASS`

---

## 25. Mapping Confidence Evaluation

### M1 Requirement

* Standard Taxonomy Concept
* Source Label directly matches Canonical Role
* Financial Statement Context consistent

### Evaluation

Standard Taxonomy Concept:

`PASS`

Official Japanese Label:

`PASS`

Official English Label:

`PASS`

Structured Element Attributes:

`PASS`

Inventory Component Role:

`PASS`

Same-filing Note Cross-reference:

`PASS`

Component Reconciliation:

`PASS`

Cross-standard Official Taxonomy Pre-review:

`PASS`

Information Loss:

`MINOR`

Contradicting Semantic Evidence:

`NONE IDENTIFIED`

### Mapping Confidence Candidate

`M1`

`Direct Standard Mapping`

---

## 26. Researcher Proposal

### Proposed Mapping

`jpigp_cor:WorkInProcessCAIFRS → WorkInProcess`

### Proposed Mapping Class

`M1`

`Direct Standard Mapping`

### Proposed Accounting Scope

`Validated IFRS eligible inventory component facts`

### Proposed Usage

`Canonical WorkInProcess Observation`

### Eligible Usage Requires

* Numeric Fact
* Instant Period Type
* Validated Financial Statement Scope
* Validated Consolidation Scope for common observation
* Validated Monetary Unit
* Source Lineage Preservation

### Cross-standard Usage Condition

Accounting Standard must remain available as an observation dimension or lineage attribute.

---

## 27. Researcher Evidence Summary

### Supporting Evidence

* Official EDINET IFRS Standard Concept
* Official Japanese Standard Label `仕掛品`
* Official English Label `Work in process`
* Monetary Item Type
* Instant Period Type
* Debit Balance
* Non-abstract Fact Element
* 2024 official Taxonomy Evidence
* 2025 official Taxonomy Evidence
* Renesas Raw XBRL Fact
* Renesas Inventory Note Cross-reference
* Exact Component Sum Reconciliation
* Japanese GAAP WorkInProcess Reference Mapping
* Cross-standard Official Taxonomy Evidence Review
* No contradictory semantic evidence identified

### Known Limitations

* Consolidated IFRS Filing Evidence currently comes primarily from Renesas for this exact Standard Concept.
* Accounting Measurement Equivalence is not evaluated.
* Cross-standard Metric Comparability is not evaluated.
* Non-current Work In Process boundaries are not broadly researched.
* Combined Work In Process Concepts require separate review.

### Researcher Decision Candidate

`APPROVE MAPPING`

---

## 28. Independent Research Reviewer Review

### Review Question 1

Was the Mapping accepted only because both Concepts are named Work In Process?

Decision:

`NO`

Evidence includes:

* Official Japanese Labels
* Official English Labels
* Structured Element Attributes
* Financial Statement Role
* Same-filing Inventory Note
* Component Reconciliation
* Official Cross-standard Taxonomy Review

---

### Review Question 2

Was Japanese GAAP Mapping automatically inherited?

Decision:

`NO`

A separate Cross-standard Official Taxonomy Evidence Review was completed.

IFRS Source Concept Identity and Filing Evidence were independently evaluated.

---

### Review Question 3

Does the Current Asset qualifier require a separate Canonical Role?

Current Decision:

`NO`

Reason:

The Standard Label and financial statement role preserve the Work In Process inventory-stage identity.

However:

`Future non-current Work In Process evidence triggers boundary review.`

Reviewer Classification:

`PASS WITH BOUNDARY CONDITION`

---

### Review Question 4

Is Measurement Equivalence being silently assumed?

Decision:

`NO`

The Research explicitly records:

`Accounting Measurement Equivalence = NOT EVALUATED`

---

### Review Question 5

Is Metric Comparability being silently assumed?

Decision:

`NO`

The Research explicitly records:

`Semantic Mapping Approval ≠ Metric Comparability Approval`

Automatic cross-standard ML pooling is not approved.

---

### Review Question 6

Could overlapping source concepts create double counting?

Decision:

`YES`

Relevant Concepts include:

* `WorkInProcessCAIFRS`
* `WorkInProcessAndRawMaterialsCAIFRS`
* `SemiFinishedProductsAndWorkInProgressCAIFRS`

Required Governance:

`Same Filing + Same Period + Same Scope + Potential Same Canonical Role → Conflict Review`

Mapping approval remains possible because this is a Fact Selection / Overlap Governance issue.

---

### Review Question 7

Is M1 too strong given only one validated consolidated IFRS company for this exact Concept?

Reviewer Concern:

`YES`

Cross-company reproduction for this exact IFRS Concept is weaker than the Japanese GAAP WorkInProcess case.

However:

M1 Classification is defined by direct Standard Taxonomy semantic alignment, not by company count alone.

Supporting Evidence includes official Taxonomy material and direct labels.

Reviewer Decision:

`M1 remains justified as Research Mapping Confidence.`

Condition:

New contradictory filing usage must reopen Mapping Review.

---

## 29. Research Reviewer Decision

`APPROVE`

### Approved Research Mapping Candidate

`jpigp_cor:WorkInProcessCAIFRS → WorkInProcess`

### Mapping Confidence

`M1`

`Direct Standard Mapping`

### Scope

`Validated IFRS eligible Work In Process inventory component facts`

### Usage Candidate

`Canonical WorkInProcess Observation`

### Cross-standard Semantic Role

`SUPPORTED`

### Accounting Measurement Equivalence

`NOT EVALUATED`

### Metric Comparability

`NOT EVALUATED`

---

## 30. Reviewer Conditions

Approval is subject to the following conditions.

1. Original QName must be preserved.
2. Namespace URI must be preserved.
3. Taxonomy Version must be preserved.
4. Accounting Standard must be preserved.
5. Source Label must remain traceable.
6. Original ContextRef must be preserved.
7. Instant balance semantics must be validated.
8. Consolidated and NonConsolidated observations must remain separate.
9. Monetary Unit must be validated.
10. Decimals must be preserved.
11. InventoryTotal and WorkInProcess roles must remain separate.
12. Combined Work In Process Concepts must not inherit this Mapping automatically.
13. Company Extension Concepts must not inherit this Mapping automatically.
14. Multiple facts mapping to WorkInProcess in the same Filing / Period / Scope require Conflict Review.
15. Future non-current Work In Process evidence requires Canonical Role Boundary Review.
16. New Taxonomy Versions require Version Change Review.
17. Mapping Approval does not prove Accounting Measurement Equivalence.
18. Mapping Approval does not prove Metric Comparability.
19. Mapping Approval does not authorize automatic cross-standard ML pooling.
20. Mapping Approval does not authorize Production implementation.

---

## 31. Mapping Approval Gate Result

| Gate Item                     | Result            |
| ----------------------------- | ----------------- |
| Source Concept Identity       | CONFIRMED         |
| Eligibility                   | PASS              |
| Financial Meaning Evidence    | SUFFICIENT        |
| Official Taxonomy Evidence    | PASS              |
| Canonical Role Candidate      | DEFINED           |
| Cross-standard Pre-review     | PASS              |
| Information Loss              | EVALUATED / MINOR |
| Double-count Risk             | EVALUATED         |
| Contradicting Evidence        | REVIEWED          |
| Taxonomy Version              | RECORDED          |
| Accounting Standard Boundary  | RECORDED          |
| Metric Comparability Boundary | RECORDED          |
| Reviewer Decision             | APPROVE           |

### Gate Result

`PASS`

---

## 32. Architecture Reviewer Requirement

### Canonical Role Addition

`NO`

### Canonical Role Split

`NO`

### Mapping Model Change

`NO`

### Lineage Requirement Change

`NO`

The required Accounting Standard and Source Concept lineage are already included in the approved Research Boundary.

### Cross-standard Semantic Architecture Finding

`ALREADY RECORDED`

Therefore:

`Architecture Reviewer Additional Gate: NOT REQUIRED`

Existing Research Architecture Boundary内でApproval可能。

---

## 33. Final Mapping Research Result

### Source Concept

`jpigp_cor:WorkInProcessCAIFRS`

### Canonical Semantic Role

`WorkInProcess`

### Mapping Class

`M1`

`DIRECT STANDARD MAPPING`

### Cross-standard Semantic Role

`SUPPORTED`

### Research Reviewer

`APPROVE`

### Mapping Gate

`PASS`

### Accounting Measurement Equivalence

`NOT EVALUATED`

### Metric Comparability

`NOT EVALUATED`

### Production Mapping

`NOT YET APPROVED`

---

## 34. Cross-standard Mapping Procedure Validation

This Sheet is the first completed Cross-standard Semantic Mapping Case.

### Procedure Evaluation

Official Taxonomy Evidence Review:

`WORKED`

Source Identity Review:

`WORKED`

Filing Evidence Review:

`WORKED`

Cross-standard Semantic Comparison:

`WORKED`

Current Asset Qualifier Review:

`WORKED`

Information Loss Review:

`WORKED`

Measurement Equivalence Separation:

`WORKED`

Metric Comparability Separation:

`WORKED`

Double-count Conflict Review:

`WORKED`

Reviewer Independence Review:

`WORKED`

### Result

`PASS`

### Important

The Cross-standard Pre-review Gate added material value.

Without the Pre-review, the Mapping may have been accepted primarily from label similarity.

Therefore:

`Cross-standard Pre-review Gate = RETAIN`

for future Accounting Standard boundary mappings.

---

## 35. Research Process Decision

For future Mapping Candidates where:

`Existing Canonical Role`

and:

`New Source Concept from a different Accounting Standard`

are involved, the following Gate is required.

`Source Concept Research`

↓

`Cross-standard Equivalence Pre-review`

↓

`Official Taxonomy Evidence Review`

↓

`Final Semantic Mapping Research Sheet`

↓

`Research Reviewer Decision`

### Exception

A shortened process is not yet approved.

Reason:

`Completed Cross-standard Mapping Cases: 1`

Further Cases are required before Research Procedure Compression.

---

## 36. Current Mapping Research State

Approved Research Mapping Candidates:

### 1

`jpigp_cor:InventoriesCAIFRS → InventoryTotal`

Mapping Class:

`M1`

Status:

`APPROVED`

### 2

`jppfs_cor:WorkInProcess → WorkInProcess`

Mapping Class:

`M1`

Status:

`APPROVED`

### 3

`jpigp_cor:WorkInProcessCAIFRS → WorkInProcess`

Mapping Class:

`M1`

Status:

`APPROVED`

Important:

`Approved Research Mapping ≠ Production Mapping Master Entry`

Catalog / DDL / Entityへの登録はまだ行わない。

---

## 37. Exact Next Task

次のMapping Research Targetは以下とする。

`jpigp_cor:FinishedGoodsCAIFRS`

### Canonical Semantic Role Candidate

`FinishedGoods`

### Observed Company

`Kioxia Holdings`

### Research Purpose

> IFRS Standard TaxonomyのFinished Goods Conceptについて、Direct Standard Mapping Caseとして評価し、WorkInProcess Cross-standard Caseで確立したResearch Procedureと比較する。

### Research Focus

* Official Standard Label
* Official Taxonomy Attributes
* Inventory Component Eligibility
* Kioxia Filing Evidence
* Component Sum Reconciliation
* Information Loss
* Adjacent `MerchandiseAndFinishedGoodsCAIFRS` Concept Boundary
* Combined Concept Conflict Risk
* Canonical Role `FinishedGoods` Suitability

### Expected Mapping Confidence Candidate

`M1`

`Direct Standard Mapping`

### Important

`FinishedGoodsCAIFRS`

and:

`MerchandiseAndFinishedGoodsCAIFRS`

must not be treated as automatically equivalent.

The next Research must explicitly evaluate the adjacent combined Concept boundary before Approval.
