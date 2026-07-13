# Inventory Semantic Mapping Research Sheet

# jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS

## 1. Document Purpose

本書は、EDINET Inventory Semantic Mapping Research Design及びMerchandise And Finished Goods Cross-standard Official Taxonomy Evidence Reviewに基づき、

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

をCanonical Inventory Semantic RoleへMapping可能か検証するResearch Sheetである。

### Mapping Candidate

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS → MerchandiseAndFinishedGoods`

本書の目的はProduction Mapping Masterを作成することではない。

目的は以下である。

> IFRS Standard TaxonomyのCombined Merchandise and Finished Goods Conceptについて、Official Taxonomy Evidence、Cross-standard Semantic Equivalence Evidence及びValidated Filing Evidenceを用い、Canonical Semantic Role `MerchandiseAndFinishedGoods` へのDirect Meaning-preserving Mapping Approval可否を評価する。

### Status

* Research Sheet
* Semantic Mapping Research
* IFRS Standard Combined Component Mapping
* Cross-standard Mapping Case
* Research Reviewer Pending
* Production Mapping Not Approved

---

## 2. Research Target

### Source Concept QName

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

### Local Name

`MerchandiseAndFinishedGoodsCAIFRS`

### Prefix

`jpigp_cor`

### Accounting Standard

`IFRS`

### Canonical Semantic Role Candidate

`MerchandiseAndFinishedGoods`

### Initial Mapping Confidence Candidate

`M1`

`Direct Meaning-preserving Mapping`

Initial ConfidenceはResearch開始時点のCandidateであり、Reviewer Approvalではない。

---

## 3. Research Questions

本Researchでは以下を確認する。

1. `MerchandiseAndFinishedGoodsCAIFRS`はCombined Inventory Componentを表すか。
2. Official Standard LabelはCanonical Roleと直接整合するか。
3. Official Element AttributesはInventory Stock Componentとして整合するか。
4. Japanese GAAP Reference ConceptとShared Semantic Coreを持つか。
5. Actual Filing Evidenceはこのexact IFRS Conceptの使用を支持するか。
6. Current Asset qualifierはCanonical Role Boundaryを変更するか。
7. Combined ConceptをAtomic Observationとして扱うべきか。
8. `FinishedGoodsCAIFRS`とのOverlap Conflict Riskはどう扱うべきか。
9. Semantic MappingとAnalytical Groupingを分離できているか。
10. M1 Mapping Approvalは妥当か。

---

## 4. Evidence Hierarchy

本Researchでは以下のEvidence Priorityを採用する。

### Priority 1

Official EDINET IFRS Taxonomy Evidence

Includes:

* Official Japanese Label
* Official English Label
* Data Type
* Period Type
* Balance Attribute
* Abstract Status
* Taxonomy Version

### Priority 2

Official EDINET Concept Handling Guidance

Purpose:

* Concept Meaning Review
* Element Concept Boundary
* Presentation / Dimension Boundary

### Priority 3

Cross-standard Official Taxonomy Evidence Review

Reference Artifact:

`InventorySemanticMappingMerchandiseAndFinishedGoodsCrossStandardOfficialTaxonomyEvidence.md`

### Priority 4

Japanese GAAP Approved Research Mapping

Reference Mapping:

`jppfs_cor:MerchandiseAndFinishedGoods → MerchandiseAndFinishedGoods`

### Priority 5

Validated Filing Evidence

Primary Filing Evidence Candidate:

`Renesas Electronics Corporation`

where the exact IFRS Source Concept was observed in the Initial Cross-company Validation.

### Priority 6

Concept Name Inference

Classification:

`Supporting Inference Only`

Concept Name alone cannot approve the Mapping.

---

## 5. Source Concept Identity

### QName

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

### Namespace Family

`jpigp`

### Local Name

`MerchandiseAndFinishedGoodsCAIFRS`

### Official Japanese Standard Label

`商品及び製品`

### Official Japanese Verbose Label

`商品及び製品、流動資産（IFRS）`

### Official English Standard Label

`Merchandise and finished goods`

### Official English Verbose Label

`Merchandise and finished goods - CA (IFRS)`

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
* Combined Inventory Component Candidate

### Source Concept Identity

`CONFIRMED`

---

## 6. Taxonomy Version Evidence

The Concept was confirmed in the reviewed Official IFRS Element Lists.

### Reviewed Versions

`jpigp/2024-11-01`

`jpigp/2025-11-01`

Reviewed attributes were aligned for:

* Japanese Standard Label
* Japanese Verbose Label
* English Standard Label
* English Verbose Label
* Data Type
* Period Type
* Balance Attribute
* Abstract Status

### Current Finding

`No Material Reviewed Attribute Difference Observed`

between the reviewed 2024 and 2025 Official IFRS Element Lists.

### Classification

`Cross-version Stability Supported within Reviewed Official Attributes`

### Not Declared

`Universal Taxonomy Definition Identity`

Future Taxonomy Versions remain subject to Version Change Review.

---

## 7. Official Label Evaluation

### Japanese Standard Label

`商品及び製品`

### English Standard Label

`Merchandise and finished goods`

### Canonical Semantic Role Candidate

`MerchandiseAndFinishedGoods`

Meaning Compatibility:

`DIRECT`

The Source Label explicitly preserves both:

`Merchandise`

and:

`Finished Goods`

The Canonical Role preserves the same Combined Semantic Structure.

### Label Evaluation Result

`PASS`

---

## 8. Structured Element Attribute Evaluation

### Data Type

`monetaryItemType`

Compatible with a monetary inventory component observation.

Result:

`PASS`

### Period Type

`instant`

Compatible with an inventory stock balance.

Result:

`PASS`

### Balance Attribute

`debit`

Consistent with an asset inventory component.

Result:

`PASS`

### Abstract Status

`false`

Usable Numeric Fact Concept Candidate.

Result:

`PASS`

### Structured Attribute Result

`CONSISTENT WITH COMBINED INVENTORY COMPONENT`

Structured attributes are Supporting Evidence.

Semantic Meaning is primarily evaluated from Official Labels, Taxonomy Boundary and Filing Context.

---

## 9. Cross-standard Reference Concept

Approved Japanese GAAP Research Mapping:

`jppfs_cor:MerchandiseAndFinishedGoods → MerchandiseAndFinishedGoods`

Mapping Class:

`M1`

Research Reviewer:

`APPROVE`

Architecture Reviewer:

`APPROVE CANONICAL ROLE ADDITION`

Japanese GAAP Source Meaning:

* 商品及び製品
* Merchandise and finished goods
* Combined Inventory Component
* Instant Monetary Fact

Current IFRS Source Meaning Candidate:

* 商品及び製品
* Merchandise and finished goods
* Combined Inventory Component
* Instant Monetary Fact
* Current Asset Presentation Candidate

### Shared Semantic Core

`Combined merchandise and finished goods inventory component`

Cross-standard Official Taxonomy Pre-review Result:

`PASS`

---

## 10. Official Cross-standard Attribute Comparison

| Attribute               | J-GAAP                         | IFRS                           |
| ----------------------- | ------------------------------ | ------------------------------ |
| Japanese Standard Label | 商品及び製品                         | 商品及び製品                         |
| English Standard Label  | Merchandise and finished goods | Merchandise and finished goods |
| Data Type               | monetaryItemType               | monetaryItemType               |
| Period Type             | instant                        | instant                        |
| Balance                 | debit                          | debit                          |
| Abstract                | false                          | false                          |

### Result

`Strong Official Taxonomy Attribute Alignment`

Observed Difference:

* Accounting Standard
* Taxonomy Family
* IFRS Current Asset presentation qualifier

No Official Attribute Conflict was identified within the reviewed scope.

---

## 11. Filing Evidence Scope

### Company

ルネサスエレクトロニクス株式会社

`Renesas Electronics Corporation`

### Security Code

`67230`

### EDINET Code

`E02081`

### Document ID

`S100XR06`

### Accounting Standard

`IFRS`

### Consolidation Scope

`Consolidated`

The exact Source Concept was observed in the validated Renesas filing.

Filing Identity:

`CONFIRMED`

---

## 12. Renesas Raw Financial Facts

### Prior

QName:

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

ContextRef:

`Prior1YearInstant`

UnitRef:

`JPY`

Decimals:

`-6`

Raw Value:

`47619000000`

### Current

QName:

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

ContextRef:

`CurrentYearInstant`

UnitRef:

`JPY`

Decimals:

`-6`

Raw Value:

`44538000000`

### Classification

* Numeric Fact
* Instant Fact
* Consolidated IFRS Fact
* Monetary Fact
* JPY

Eligibility Candidate:

`Eligible Inventory Component Fact`

---

## 13. Renesas Inventory Note Context

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

### Current

商品及び製品:

`44,538 million JPY`

仕掛品:

`121,437 million JPY`

原材料及び貯蔵品:

`19,928 million JPY`

Total:

`185,903 million JPY`

The structured Fact:

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

matched the Inventory Note row:

`商品及び製品`

Prior:

`47,619 million JPY`

Current:

`44,538 million JPY`

### Same-filing Result

`EXACT VALUE MATCH`

### Research Finding

The exact IFRS Source Concept is directly associated with the disclosed Combined Inventory Component:

`商品及び製品`

Classification:

`Strong Same-filing Semantic Evidence`

---

## 14. Component Sum Reconciliation

### Prior

`47,619 + 106,737 + 22,188 = 176,544`

Reported Inventory Total:

`176,544 million JPY`

Result:

`EXACT MATCH`

### Current

`44,538 + 121,437 + 19,928 = 185,903`

Reported Inventory Total:

`185,903 million JPY`

Result:

`EXACT MATCH`

### Research Use

Component Sum supports the Source Concept being an Inventory Component.

It does not independently prove the combined semantic meaning.

Primary Semantic Evidence remains:

* Official Standard Label
* Source Concept Identity
* Inventory Note Row
* Cross-standard Official Taxonomy Evidence

---

## 15. Inventory Component Eligibility

Candidate Fact must satisfy:

* Numeric Fact
* Instant Fact
* Validated Financial Statement Scope
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

## 16. Current Asset Qualifier Review

IFRS Verbose Label:

`商品及び製品、流動資産（IFRS）`

English:

`Merchandise and finished goods - CA (IFRS)`

Canonical Candidate:

`MerchandiseAndFinishedGoods`

### Potential Concern

The Canonical Role does not include the Current Asset qualifier.

### Supporting Evidence

Official Standard Label:

`商品及び製品`

Official English Standard Label:

`Merchandise and finished goods`

Observed Filing Role:

`Inventory Component`

Cross-standard Official Taxonomy Pre-review:

`PASS`

### Reviewer Interpretation Candidate

The Current Asset qualifier does not currently change the Combined Inventory Component semantic core.

### Information Loss Candidate

`Minor`

### Mandatory Lineage Condition

Preserve:

* Accounting Standard
* Source QName
* Namespace URI
* Taxonomy Version
* Source Label

### Future Boundary Trigger

Detection of a non-current Merchandise and Finished Goods Concept requires:

`Canonical Role Boundary Review`

---

## 17. Combined Semantic Identity

### Source Meaning

`Merchandise and Finished Goods`

### Canonical Meaning

`MerchandiseAndFinishedGoods`

The Canonical Role preserves:

* Merchandise
* Finished Goods
* Combined nature

### Semantic Compression

`NONE`

### Semantic Decomposition

`NONE`

### Semantic Identity Result

`DIRECT MEANING PRESERVATION`

This differs materially from the rejected Candidate:

`MerchandiseAndFinishedGoods → FinishedGoods`

which removed the Merchandise meaning.

---

## 18. Atomic Combined Concept Treatment

Existing Research Principle:

`Combined Source Concept → Atomic Canonical Observation`

unless:

`Source-supported decomposition exists`

The current Source Concept is explicitly Combined.

The validated Filing does not provide a structured split between:

`Merchandise`

and:

`Finished Goods`

within this Fact.

Therefore:

`MerchandiseAndFinishedGoodsCAIFRS`

must remain atomic under:

`MerchandiseAndFinishedGoods`

### Synthetic Decomposition

`NOT APPROVED`

Example prohibited transformation:

`47,619 million JPY`

↓

`Merchandise = assumed amount`

*

`FinishedGoods = assumed amount`

without Source Evidence.

### Atomic Treatment Result

`PASS`

---

## 19. Adjacent FinishedGoodsCAIFRS Boundary

Approved Research Mapping:

`jpigp_cor:FinishedGoodsCAIFRS → FinishedGoods`

Current Candidate:

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS → MerchandiseAndFinishedGoods`

### Shared Meaning

Finished Goods is represented in both semantic descriptions.

### Material Difference

The current Source Concept also includes:

`Merchandise`

Therefore:

`FinishedGoods`

and:

`MerchandiseAndFinishedGoods`

remain separate Canonical Semantic Roles.

### Boundary Result

`DISTINCT CANONICAL ROLES`

This Sheet does not approve semantic equivalence between them.

---

## 20. Accounting Standard Boundary

Source Concept:

`IFRS`

Canonical Role:

`MerchandiseAndFinishedGoods`

The Canonical Role does not encode Accounting Standard.

This is intentional.

### Preserved Lineage

* Accounting Standard
* Source QName
* Namespace URI
* Taxonomy Version

### Research Boundary

`Semantic Component Identity`

is separated from:

`Accounting Standard`

### Not Proven

J-GAAP and IFRS measurement rules for the Combined Component are identical.

### Result

`Semantic Equivalence Supported`

`Accounting Measurement Equivalence Not Evaluated`

---

## 21. Semantic Mapping vs Analytical Grouping

Current Canonical Roles:

* `FinishedGoods`
* `MerchandiseAndFinishedGoods`

A future analytical grouping may be considered.

Example:

`FinishedInventoryGroup`

Possible Members:

* `FinishedGoods`
* `MerchandiseAndFinishedGoods`

However:

`Analytical Grouping`

is not:

`Semantic Mapping`

### Current Status

`Analytical Grouping Not Approved`

This Mapping preserves Source Meaning only.

---

## 22. Semantic Mapping vs Metric Comparability

Mapping both J-GAAP and IFRS Combined Concepts to:

`MerchandiseAndFinishedGoods`

does not prove that:

`MerchandiseAndFinishedGoodsGrowthYoY`

has identical economic or predictive interpretation across companies.

Potential Comparability Dimensions:

* Accounting Standard
* Company
* Business Model
* SubSector
* Merchandise Share
* Finished Goods Share
* Inventory Accounting Policy

### Research Finding

`Semantic Equivalence ≠ Composition Equivalence`

and:

`Semantic Equivalence ≠ Metric Comparability Approval`

### ML Boundary

Automatic cross-standard or cross-company feature pooling is:

`NOT APPROVED`

---

## 23. Information Loss Evaluation

### Source Meaning

`Merchandise and finished goods - CA (IFRS)`

### Canonical Meaning

`MerchandiseAndFinishedGoods`

### Removed from Canonical Role Name

* IFRS Identity
* Current Asset qualifier
* Taxonomy family

These remain in Lineage.

### Combined Inventory Meaning Loss

`NONE IDENTIFIED`

### Overall Information Loss

`Minor`

Reason:

The full Combined Semantic Core is preserved.

### Mapping Condition

Source and Accounting Standard Lineage must remain available.

---

## 24. Double-count Risk Evaluation

### Risk A

`FinishedGoodsCAIFRS`

and:

`MerchandiseAndFinishedGoodsCAIFRS`

appear in the same Filing / Period / Scope.

Potential Overlap:

`HIGH`

Required Governance:

`Conflict Review`

Do not sum automatically.

---

### Risk B

A separate Merchandise Fact and Combined Fact coexist.

Potential Overlap:

`HIGH`

Required Governance:

`Conflict Review`

---

### Risk C

InventoryTotal and Combined Component are added into the same Total calculation.

Result:

`Double Count`

Required Governance:

`Total and Component Roles remain separate`

### Double-count Risk Classification

`HIGH if source selection is not governed`

### Mapping Decision Impact

The Mapping remains supportable.

The risk belongs to Fact Selection and Overlap Governance.

---

## 25. Same Canonical Role Duplicate Risk

Japanese GAAP Source Concept:

`jppfs_cor:MerchandiseAndFinishedGoods`

IFRS Source Concept:

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

Both may map to:

`MerchandiseAndFinishedGoods`

Across different Accounting Standards and Filings this is expected.

Within the same Filing:

both Source Concepts would normally belong to different reporting taxonomy contexts.

However, if multiple Facts map to the same Canonical Role within the same:

* Filing
* Period
* Scope

then:

`Duplicate / Semantic Overlap Review`

is mandatory.

### Rule Candidate

`Same Canonical Role + Same Filing + Same Period + Same Scope ≠ Automatic Sum`

---

## 26. Contradicting Evidence Search

Within the current reviewed scope:

### Same Source Concept Used as Finished Goods only

`NOT OBSERVED`

### Same Source Concept Used as Inventory Total

`NOT OBSERVED`

### Same Source Concept Used for Work In Process

`NOT OBSERVED`

### Official Standard Label Conflict

`NOT IDENTIFIED`

### English Label Conflict

`NOT IDENTIFIED`

### Combined Meaning Conflict

`NOT IDENTIFIED`

### Period Type Conflict

`NOT IDENTIFIED`

### Filing Note Conflict

`NOT IDENTIFIED`

### Contradicting Semantic Evidence

`NONE IDENTIFIED within current reviewed scope`

---

## 27. Canonical Role Candidate Evaluation

### Candidate A

`MerchandiseAndFinishedGoods`

Meaning:

`Combined merchandise and finished goods inventory component`

Evaluation:

* Official Label Match: PASS
* English Label Match: PASS
* Combined Meaning Preservation: PASS
* Cross-standard Reference Role: PASS
* Information Loss: NONE MATERIAL

Result:

`STRONGLY SUPPORTED`

---

### Candidate B

`FinishedGoods`

Evaluation:

Merchandise meaning removed.

Result:

`REJECT`

---

### Candidate C

`IFRSMerchandiseAndFinishedGoods`

Concern:

Accounting Standard should remain a Lineage / Context dimension.

Result:

`REJECT`

---

### Preferred Candidate

`MerchandiseAndFinishedGoods`

Canonical Role Suitability:

`PASS`

---

## 28. Mapping Confidence Evaluation

### M1 Requirement

* Standard Taxonomy Concept
* Source Label directly matches Canonical Role
* Financial Statement Context consistent

### Evaluation

Standard Taxonomy Concept:

`PASS`

Japanese Standard Label:

`PASS`

English Standard Label:

`PASS`

Structured Element Attributes:

`PASS`

Combined Semantic Structure:

`PASS`

Inventory Component Role:

`PASS`

Same-filing Note Cross-reference:

`PASS`

Exact Value Match:

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

`Direct Meaning-preserving Mapping`

---

## 29. Researcher Proposal

### Proposed Mapping

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS → MerchandiseAndFinishedGoods`

### Proposed Mapping Class

`M1`

`Direct Meaning-preserving Mapping`

### Proposed Scope

`Validated IFRS eligible combined Merchandise and Finished Goods inventory component facts`

### Proposed Usage

`Canonical MerchandiseAndFinishedGoods Observation`

### Eligible Usage Requires

* Numeric Fact
* Instant Period Type
* Validated Financial Statement Scope
* Validated Consolidation Scope for common observation
* Validated Monetary Unit
* Source Lineage Preservation

### Atomic Treatment Condition

The Source Fact remains a single Combined Canonical Observation unless Source-supported decomposition exists.

---

## 30. Researcher Evidence Summary

### Supporting Evidence

* Official IFRS Standard Taxonomy Concept
* Exact Japanese Standard Label alignment
* Exact English Standard Label alignment
* Monetary Item Type
* Instant Period Type
* Debit Balance
* Non-abstract Fact Element
* 2024 Official Taxonomy Evidence
* 2025 Official Taxonomy Evidence
* Renesas Raw XBRL Fact
* Renesas Inventory Note cross-reference
* Prior Exact Value Match
* Current Exact Value Match
* Exact Component Sum Reconciliation
* Approved Japanese GAAP Combined Role Mapping
* Cross-standard Official Taxonomy Evidence Review
* No contradictory semantic evidence identified

### Known Limitations

* Exact IFRS Source Concept Filing Evidence is currently Renesas-centered.
* Accounting Measurement Equivalence is not evaluated.
* Composition equivalence is not evaluated.
* Metric Comparability is not evaluated.
* Analytical grouping with FinishedGoods is not approved.
* Overlapping Combined and narrow component facts require Conflict Review.

### Researcher Decision Candidate

`APPROVE MAPPING`

---

## 31. Independent Research Reviewer Review

### Review Question 1

Was the Mapping approved because a matching Canonical Role already existed?

Decision:

`NO`

The Canonical Role was previously added only after rejecting a lossy FinishedGoods Mapping.

The current IFRS Concept independently shows the same Official Combined Meaning.

---

### Review Question 2

Was Cross-standard equivalence inferred only from Local Name similarity?

Decision:

`NO`

Evidence includes:

* Exact Japanese Standard Label
* Exact English Standard Label
* Structured Element Attributes
* Official Taxonomy Review
* Combined Semantic Structure

---

### Review Question 3

Does the Current Asset qualifier require a separate Role?

Current Decision:

`NO`

No evidence currently indicates that it changes the Combined Inventory Component semantic core.

Condition:

Future non-current Combined Concept evidence triggers Boundary Review.

---

### Review Question 4

Should the Combined Concept be decomposed for easier analysis?

Decision:

`NO`

No Source-supported decomposition exists.

Synthetic decomposition is prohibited.

---

### Review Question 5

Does Approval allow grouping with FinishedGoods?

Decision:

`NO`

Analytical Grouping remains a separate Research Question.

---

### Review Question 6

Does Approval prove metric comparability?

Decision:

`NO`

The Research explicitly separates:

`Semantic Mapping`

from:

`Metric Comparability`

---

### Review Question 7

Is M1 too strong with one exact IFRS filing case?

Reviewer Concern:

`LIMITED FILING REPRODUCTION`

However:

The Mapping is a Direct Standard Taxonomy meaning-preserving case.

Evidence includes Official Taxonomy alignment and strong same-filing evidence.

Reviewer Decision:

`M1 remains justified as Research Mapping Confidence.`

Condition:

New contradictory usage reopens the Mapping Review.

---

## 32. Research Reviewer Decision

`APPROVE`

### Approved Research Mapping Candidate

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS → MerchandiseAndFinishedGoods`

### Mapping Confidence

`M1`

`Direct Meaning-preserving Mapping`

### Scope

`Validated IFRS eligible combined Merchandise and Finished Goods inventory component facts`

### Usage Candidate

`Canonical MerchandiseAndFinishedGoods Observation`

### Atomic Combined Concept Treatment

`REQUIRED`

### Analytical Grouping

`NOT APPROVED`

### Metric Comparability

`NOT EVALUATED`

---

## 33. Reviewer Conditions

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
11. Combined Source Concept must remain atomic.
12. Unsupported synthetic decomposition is prohibited.
13. `FinishedGoodsCAIFRS` remains mapped to `FinishedGoods`.
14. `MerchandiseAndFinishedGoods` and `FinishedGoods` remain distinct Canonical Roles.
15. Multiple overlapping source concepts require Conflict Review.
16. Same Canonical Role facts in the same Filing / Period / Scope must not be summed automatically.
17. Future non-current Combined Concept evidence triggers Boundary Review.
18. New Taxonomy Versions require Version Change Review.
19. Mapping Approval does not prove Accounting Measurement Equivalence.
20. Mapping Approval does not prove Composition Equivalence.
21. Mapping Approval does not prove Metric Comparability.
22. Mapping Approval does not authorize Analytical Grouping.
23. Mapping Approval does not authorize Production implementation.

---

## 34. Mapping Approval Gate Result

| Gate Item                       | Result     |
| ------------------------------- | ---------- |
| Source Concept Identity         | CONFIRMED  |
| Eligibility                     | PASS       |
| Financial Meaning Evidence      | SUFFICIENT |
| Official Taxonomy Evidence      | PASS       |
| Cross-standard Pre-review       | PASS       |
| Canonical Role Candidate        | DEFINED    |
| Combined Semantic Preservation  | PASS       |
| Atomic Treatment                | DEFINED    |
| Information Loss                | MINOR      |
| Adjacent FinishedGoods Boundary | REVIEWED   |
| Double-count Risk               | EVALUATED  |
| Contradicting Evidence          | REVIEWED   |
| Taxonomy Version                | RECORDED   |
| Accounting Standard Boundary    | RECORDED   |
| Metric Comparability Boundary   | RECORDED   |
| Reviewer Decision               | APPROVE    |

### Gate Result

`PASS`

---

## 35. Architecture Reviewer Requirement

### Canonical Role Addition

`NO`

The Role already exists as an Approved Research Canonical Role.

### Canonical Role Split

`NO`

### Mapping Model Change

`NO`

### Atomic Combined Concept Principle

Already supported by prior Architecture Review.

### Lineage Requirement Change

`NO`

Therefore:

`Architecture Reviewer Additional Gate: NOT REQUIRED`

Existing Research Architecture Boundary内でApproval可能。

---

## 36. Final Mapping Research Result

### Source Concept

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

### Canonical Semantic Role

`MerchandiseAndFinishedGoods`

### Mapping Class

`M1`

`DIRECT MEANING-PRESERVING MAPPING`

### Cross-standard Semantic Role

`SUPPORTED`

### Research Reviewer

`APPROVE`

### Mapping Gate

`PASS`

### Atomic Combined Concept Treatment

`REQUIRED`

### Analytical Grouping

`NOT APPROVED`

### Metric Comparability

`NOT EVALUATED`

### Production Mapping

`NOT YET APPROVED`

---

## 37. Cross-standard Combined Concept Procedure Evaluation

This Sheet is the first completed Cross-standard Combined Semantic Concept Mapping Case.

### Procedure Evaluation

Official Taxonomy Evidence Review:

`WORKED`

Source Identity Review:

`WORKED`

Combined Semantic Structure Review:

`WORKED`

Filing Evidence Review:

`WORKED`

Cross-standard Semantic Comparison:

`WORKED`

Current Asset Qualifier Review:

`WORKED`

Atomic Concept Review:

`WORKED`

Adjacent Narrow Concept Boundary Review:

`WORKED`

Information Loss Review:

`WORKED`

Metric Comparability Separation:

`WORKED`

Double-count Conflict Review:

`WORKED`

Reviewer Independence Review:

`WORKED`

### Result

`PASS`

### Process Finding

The following Research sequence was effective:

`Meaning-preserving Canonical Role Review`

↓

`Cross-standard Official Taxonomy Pre-review`

↓

`Final Mapping Research Sheet`

This sequence should be retained for future Combined Concept Mapping Cases.

---

## 38. Current Canonical Semantic Role Set

Approved Research Canonical Roles:

* `InventoryTotal`
* `FinishedGoods`
* `WorkInProcess`
* `RawMaterials`
* `Other`
* `MerchandiseAndFinishedGoods`

### `MerchandiseAndFinishedGoods`

Cross-standard support now exists from:

* Japanese GAAP Standard Concept
* IFRS Standard Concept

### Research Status

`CROSS-STANDARD CANONICAL ROLE SUPPORTED`

### Production Status

`NOT APPROVED`

---

## 39. Current Mapping Research State

### 1

`jpigp_cor:InventoriesCAIFRS → InventoryTotal`

Class:

`M1`

Status:

`APPROVED`

### 2

`jppfs_cor:WorkInProcess → WorkInProcess`

Class:

`M1`

Status:

`APPROVED`

### 3

`jpigp_cor:WorkInProcessCAIFRS → WorkInProcess`

Class:

`M1`

Status:

`APPROVED`

### 4

`jpigp_cor:FinishedGoodsCAIFRS → FinishedGoods`

Class:

`M1`

Status:

`APPROVED`

### 5

`jppfs_cor:MerchandiseAndFinishedGoods → MerchandiseAndFinishedGoods`

Class:

`M1`

Status:

`APPROVED`

### 6

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS → MerchandiseAndFinishedGoods`

Class:

`M1`

Status:

`APPROVED`

### Rejected Candidate

`jppfs_cor:MerchandiseAndFinishedGoods → FinishedGoods`

Status:

`REJECTED`

Important:

`Approved Research Mapping ≠ Production Mapping Master Entry`

Catalog / DDL / Entityへの登録はまだ行わない。

---

## 40. Exact Next Task

次のMapping Research Targetは以下とする。

`jpigp_cor:RawMaterialsCAIFRS`

### Canonical Semantic Role Candidate

`RawMaterials`

### Observed Company

`Kioxia Holdings`

### Research Purpose

> IFRS Standard TaxonomyのRaw Materials ConceptについてDirect Standard Mapping可否を検証し、隣接する`RawMaterialsAndSuppliesCAIFRS`及びJapanese GAAP `RawMaterialsAndSupplies`との境界を整理する。

### Research Focus

* Official Standard Label
* Official Element Attributes
* Kioxia Filing Evidence
* Inventory Component Eligibility
* `RawMaterialsCAIFRS` semantic boundary
* `RawMaterialsAndSuppliesCAIFRS` adjacent combined concept
* Japanese GAAP combined concept boundary
* Information Loss
* Cross-standard Metric Comparability boundary
* M1 Mapping Approval

### Important

The next Sheet approves or rejects only:

`RawMaterialsCAIFRS → RawMaterials`

It must not automatically approve:

`RawMaterialsAndSuppliesCAIFRS → RawMaterials`

or:

`jppfs_cor:RawMaterialsAndSupplies → RawMaterials`

Those Combined Concepts require separate Information Loss Review.
