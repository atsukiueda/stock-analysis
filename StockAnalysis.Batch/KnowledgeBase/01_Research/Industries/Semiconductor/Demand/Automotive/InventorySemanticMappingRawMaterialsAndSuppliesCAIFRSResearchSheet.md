# Inventory Semantic Mapping Research Sheet

# jpigp_cor:RawMaterialsAndSuppliesCAIFRS

## 1. Document Purpose

本書は、EDINET Inventory Semantic Mapping Research Design及びRaw Materials And Supplies Cross-standard Official Taxonomy Evidence Reviewに基づき、

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

をCanonical Inventory Semantic RoleへMapping可能か検証するResearch Sheetである。

### Mapping Candidate

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS → RawMaterialsAndSupplies`

本書の目的はProduction Mapping Masterを作成することではない。

目的は以下である。

> IFRS Standard TaxonomyのCombined Raw Materials and Supplies Conceptについて、Official Taxonomy Evidence、Renesas Filing Evidence、Japanese GAAP Reference Mapping及びCross-standard Semantic Equivalence Pre-reviewを用いて、Canonical Semantic Role `RawMaterialsAndSupplies` へのDirect Meaning-preserving Mapping Approval可否をEvidenceに基づいて評価する。

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

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

### Local Name

`RawMaterialsAndSuppliesCAIFRS`

### Prefix

`jpigp_cor`

### Accounting Standard

`IFRS`

### Canonical Semantic Role Candidate

`RawMaterialsAndSupplies`

### Initial Mapping Confidence Candidate

`M1`

`Direct Meaning-preserving Mapping`

Initial ConfidenceはResearch開始時点のCandidateであり、Reviewer Approvalではない。

---

## 3. Research Questions

本Researchでは以下を確認する。

1. `RawMaterialsAndSuppliesCAIFRS`はCombined Raw Materials and Supplies Inventory Componentを表すか。
2. Official Standard LabelはCanonical Roleと直接整合するか。
3. Official Element AttributesはInventory Stock Componentとして整合するか。
4. Renesas Filing Evidenceはexact Source Concept Meaningと整合するか。
5. Japanese GAAP `RawMaterialsAndSupplies`とShared Semantic Coreを持つか。
6. Current Asset qualifierはCanonical Role Boundaryを変更するか。
7. Combined ConceptをAtomic Observationとして扱うべきか。
8. `RawMaterialsCAIFRS`とのOverlap Conflict Riskはどう扱うべきか。
9. `ProductionSuppliesCAIFRS`とのOverlap Conflict Riskはどう扱うべきか。
10. Semantic Mapping、Composition Equivalence及びMetric Comparabilityを分離できているか。
11. M1 Direct Meaning-preserving Mapping Approvalは妥当か。

---

## 4. Evidence Hierarchy

本Researchでは以下のEvidence Priorityを採用する。

### Priority 1

Official EDINET IFRS Taxonomy Evidence

Includes:

* Official Japanese Label
* Official English Label
* Data Type
* Substitution Group
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

`InventorySemanticMappingRawMaterialsAndSuppliesCrossStandardOfficialTaxonomyEvidence.md`

### Priority 4

Japanese GAAP Approved Research Mapping

Reference Mapping:

`jppfs_cor:RawMaterialsAndSupplies → RawMaterialsAndSupplies`

### Priority 5

Validated Filing Evidence

Primary Filing:

`Renesas Electronics Corporation`

Document ID:

`S100XR06`

### Priority 6

Concept Name Inference

Classification:

`Supporting Inference Only`

Concept Name alone cannot approve the Mapping.

---

## 5. Source Concept Identity

### QName

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

### Namespace Family

`jpigp`

### Local Name

`RawMaterialsAndSuppliesCAIFRS`

### Official Japanese Standard Label

`原材料及び貯蔵品`

### Official Japanese Verbose Label

`原材料及び貯蔵品、流動資産（IFRS）`

### Official English Standard Label

`Raw materials and supplies`

### Official English Verbose Label

`Raw materials and supplies - CA (IFRS)`

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

### Reviewed Version A

`jpigp/2024-11-01`

### Reviewed Version B

`jpigp/2025-11-01`

The following reviewed attributes were aligned.

* Japanese Standard Label
* Japanese Verbose Label
* English Standard Label
* English Verbose Label
* Data Type
* Substitution Group
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

`原材料及び貯蔵品`

### English Standard Label

`Raw materials and supplies`

### Canonical Semantic Role Candidate

`RawMaterialsAndSupplies`

### Meaning Compatibility

`DIRECT`

The Source Label explicitly preserves both:

`Raw Materials`

and:

`Supplies`

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

Consistent with an inventory asset component.

Result:

`PASS`

### Abstract Status

`false`

Usable Numeric Fact Concept Candidate.

Result:

`PASS`

### Structured Attribute Result

`CONSISTENT WITH COMBINED RAW MATERIALS AND SUPPLIES INVENTORY COMPONENT`

Structured attributes are Supporting Evidence.

Semantic Meaning is primarily evaluated from:

* Official Labels
* Taxonomy Boundary
* Filing Context

---

## 9. Cross-standard Reference Concept

Approved Japanese GAAP Research Mapping:

`jppfs_cor:RawMaterialsAndSupplies → RawMaterialsAndSupplies`

### Mapping Class

`M1`

### Research Reviewer

`APPROVE`

### Architecture Reviewer

`APPROVE CANONICAL ROLE ADDITION`

### Japanese GAAP Source Meaning

* 原材料及び貯蔵品
* Raw materials and supplies
* Combined Inventory Component
* Instant Monetary Fact

### Current IFRS Source Meaning Candidate

* 原材料及び貯蔵品
* Raw materials and supplies
* Combined Inventory Component
* Instant Monetary Fact
* Current Asset Presentation Candidate

### Shared Semantic Core

`Combined raw materials and supplies inventory component`

### Cross-standard Official Taxonomy Pre-review Result

`PASS`

---

## 10. Official Cross-standard Attribute Comparison

| Attribute               | J-GAAP                     | IFRS                       |
| ----------------------- | -------------------------- | -------------------------- |
| Japanese Standard Label | 原材料及び貯蔵品                   | 原材料及び貯蔵品                   |
| English Standard Label  | Raw materials and supplies | Raw materials and supplies |
| Data Type               | monetaryItemType           | monetaryItemType           |
| Substitution Group      | item                       | item                       |
| Period Type             | instant                    | instant                    |
| Balance                 | debit                      | debit                      |
| Abstract                | false                      | false                      |

### Result

`Strong Official Taxonomy Attribute Alignment`

### Observed Difference

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

### Filing Identity

`CONFIRMED`

---

## 12. Renesas Raw Financial Facts

### Prior

QName:

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

ContextRef:

`Prior1YearInstant`

UnitRef:

`JPY`

Decimals:

`-6`

Raw Value:

`22188000000`

### Current

QName:

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

ContextRef:

`CurrentYearInstant`

UnitRef:

`JPY`

Decimals:

`-6`

Raw Value:

`19928000000`

### Classification

* Numeric Fact
* Instant Fact
* Consolidated IFRS Fact
* Monetary Fact
* JPY

### Eligibility Candidate

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

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

matched the Inventory Note row:

`原材料及び貯蔵品`

### Prior Value Match

`22,188 million JPY`

Result:

`EXACT MATCH`

### Current Value Match

`19,928 million JPY`

Result:

`EXACT MATCH`

### Research Finding

The exact IFRS Source Concept is directly associated with the disclosed Combined Inventory Component:

`原材料及び貯蔵品`

### Classification

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

It does not independently prove the detailed Combined Semantic Meaning.

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

`原材料及び貯蔵品、流動資産（IFRS）`

English:

`Raw materials and supplies - CA (IFRS)`

Canonical Candidate:

`RawMaterialsAndSupplies`

### Potential Concern

The Canonical Role does not include the Current Asset qualifier.

### Supporting Evidence

Official Standard Label:

`原材料及び貯蔵品`

Official English Standard Label:

`Raw materials and supplies`

Observed Filing Role:

`Inventory Component`

Cross-standard Official Taxonomy Pre-review:

`PASS`

### Reviewer Interpretation Candidate

The Current Asset qualifier does not currently change the Combined Raw Materials and Supplies semantic core.

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

Detection of a non-current Raw Materials and Supplies Concept requires:

`Canonical Role Boundary Review`

---

## 17. Combined Semantic Identity

### Source Meaning

`Raw Materials and Supplies`

### Canonical Meaning

`RawMaterialsAndSupplies`

The Canonical Role preserves:

* Raw Materials
* Supplies
* Combined nature

### Semantic Compression

`NONE`

### Semantic Decomposition

`NONE`

### Semantic Identity Result

`DIRECT MEANING PRESERVATION`

This differs materially from the rejected Candidate:

`RawMaterialsAndSupplies → RawMaterials`

which removed the Supplies meaning.

---

## 18. Atomic Combined Concept Treatment

Existing Research Principle:

`Combined Source Concept → Atomic Canonical Observation`

unless:

`Source-supported decomposition exists`

The current Source Concept is explicitly Combined.

The validated Filing does not provide a structured split between:

`Raw Materials`

and:

`Supplies`

within this Fact.

Therefore:

`RawMaterialsAndSuppliesCAIFRS`

must remain atomic under:

`RawMaterialsAndSupplies`

### Synthetic Decomposition

`NOT APPROVED`

Prohibited Example:

`19,928 million JPY`

↓

`RawMaterials = assumed amount`

*

`Supplies = assumed amount`

without Source Evidence.

### Atomic Treatment Result

`PASS`

---

## 19. RawMaterialsCAIFRS Boundary

Approved Research Mapping:

`jpigp_cor:RawMaterialsCAIFRS → RawMaterials`

Current Candidate:

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS → RawMaterialsAndSupplies`

### Shared Meaning

Raw Materials is represented in both semantic descriptions.

### Material Difference

The current Source Concept also includes:

`Supplies`

Therefore:

`RawMaterials`

and:

`RawMaterialsAndSupplies`

remain separate Canonical Semantic Roles.

### Boundary Result

`DISTINCT CANONICAL ROLES`

This Sheet does not approve semantic equivalence between them.

---

## 20. ProductionSuppliesCAIFRS Boundary

Adjacent IFRS Concept:

`jpigp_cor:ProductionSuppliesCAIFRS`

### Semantic Candidate

`Production Supplies`

The current Source Concept includes Supplies as part of a Combined Component.

### Potential Overlap

If:

`ProductionSuppliesCAIFRS`

and:

`RawMaterialsAndSuppliesCAIFRS`

appear in the same Filing / Period / Scope:

`Potential Supplies Overlap`

### Required Governance

`Conflict Review`

Do not sum automatically.

### Boundary Result

`Distinct Source Concepts with Potential Semantic Overlap`

Approval of the current Mapping does not approve:

`ProductionSuppliesCAIFRS → RawMaterialsAndSupplies`

---

## 21. Accounting Standard Boundary

Source Concept:

`IFRS`

Canonical Role:

`RawMaterialsAndSupplies`

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

## 22. Semantic Mapping vs Composition Equivalence

The Canonical Role identifies:

`Raw Materials + Supplies`

However, it does not identify the internal ratio between:

`Raw Materials`

and:

`Supplies`

### Example

Company A:

`95% Raw Materials / 5% Supplies`

Company B:

`60% Raw Materials / 40% Supplies`

Both could potentially use the same Combined Semantic Role.

### Research Finding

`Semantic Equivalence ≠ Composition Equivalence`

### Current Status

`Composition Equivalence Not Evaluated`

This distinction must be retained before Derived Metric pooling.

---

## 23. Semantic Mapping vs Analytical Grouping

Current Canonical Roles:

* `RawMaterials`
* `RawMaterialsAndSupplies`

A future Analytical Group may be considered.

Examples:

`RawMaterialRelatedInventoryGroup`

or:

`InputInventoryGroup`

Possible Members:

* `RawMaterials`
* `RawMaterialsAndSupplies`

However:

`Analytical Grouping`

is not:

`Semantic Mapping`

### Current Status

`Analytical Grouping Not Approved`

This Mapping preserves Source Meaning only.

---

## 24. Semantic Mapping vs Metric Comparability

Mapping both J-GAAP and IFRS Combined Concepts to:

`RawMaterialsAndSupplies`

does not prove that:

`RawMaterialsAndSuppliesGrowthYoY`

has identical economic or predictive interpretation across companies.

Potential Comparability Dimensions:

* Accounting Standard
* Company
* SubSector
* Business Model
* Production Process
* Procurement Cycle
* Supplies Materiality
* Internal Raw Materials / Supplies Mix
* Inventory Accounting Policy

### Research Finding

`Semantic Equivalence ≠ Metric Comparability Approval`

### ML Boundary

Automatic cross-standard or cross-company Feature Pooling is:

`NOT APPROVED`

---

## 25. Information Loss Evaluation

### Source Meaning

`Raw materials and supplies - CA (IFRS)`

### Canonical Meaning

`RawMaterialsAndSupplies`

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

## 26. Double-count Risk Evaluation

### Risk A

`RawMaterialsCAIFRS`

and:

`RawMaterialsAndSuppliesCAIFRS`

appear in the same Filing / Period / Scope.

### Potential Overlap

`HIGH`

Reason:

The Combined Concept includes Raw Materials meaning.

### Required Governance

`Conflict Review`

Do not sum automatically.

---

### Risk B

`ProductionSuppliesCAIFRS`

and:

`RawMaterialsAndSuppliesCAIFRS`

coexist.

### Potential Overlap

`HIGH`

Reason:

The Combined Concept includes Supplies meaning.

### Required Governance

`Conflict Review`

---

### Risk C

InventoryTotal and Combined Component are included in the same Total calculation.

Result:

`Double Count`

Required Governance:

`Total and Component Roles remain separate`

---

### Risk D

The Combined Concept is synthetically decomposed while the original Combined Observation remains active.

Potential Result:

`Double Count`

### Double-count Risk Classification

`HIGH if source selection is not governed`

### Mapping Decision Impact

The Mapping remains supportable.

The risk belongs to Fact Selection and Overlap Governance.

---

## 27. Same Canonical Role Duplicate Risk

Japanese GAAP Source Concept:

`jppfs_cor:RawMaterialsAndSupplies`

IFRS Source Concept:

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

Both may map to:

`RawMaterialsAndSupplies`

Across different Accounting Standards and Filings this is expected.

Within the same Filing, if multiple Facts map to the same Canonical Role under the same:

* Filing
* Period
* Scope

then:

`Duplicate / Semantic Overlap Review`

is mandatory.

### Rule Candidate

`Same Canonical Role + Same Filing + Same Period + Same Scope ≠ Automatic Sum`

---

## 28. Contradicting Evidence Search

Within the current reviewed scope:

### Same Source Concept Used as Raw Materials only

`NOT OBSERVED`

### Same Source Concept Used as Inventory Total

`NOT OBSERVED`

### Same Source Concept Used as Work In Process

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

### Evidence that Supplies may be removed

`NOT IDENTIFIED`

### Contradicting Semantic Evidence

`NONE IDENTIFIED within current reviewed scope`

---

## 29. Canonical Role Candidate Evaluation

### Candidate A

`RawMaterialsAndSupplies`

Meaning:

`Combined raw materials and supplies inventory component`

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

`RawMaterials`

Evaluation:

Supplies meaning removed.

Result:

`REJECT`

---

### Candidate C

`IFRSRawMaterialsAndSupplies`

Concern:

Accounting Standard should remain a Lineage / Context dimension.

Result:

`REJECT`

---

### Preferred Candidate

`RawMaterialsAndSupplies`

### Canonical Role Suitability

`PASS`

---

## 30. Mapping Confidence Evaluation

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

Prior Exact Value Match:

`PASS`

Current Exact Value Match:

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

## 31. Researcher Proposal

### Proposed Mapping

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS → RawMaterialsAndSupplies`

### Proposed Mapping Class

`M1`

`Direct Meaning-preserving Mapping`

### Proposed Scope

`Validated IFRS eligible combined Raw Materials and Supplies inventory component facts`

### Proposed Usage

`Canonical RawMaterialsAndSupplies Observation`

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

## 32. Researcher Evidence Summary

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
* Composition Equivalence is not evaluated.
* Metric Comparability is not evaluated.
* Analytical grouping with RawMaterials is not approved.
* Overlapping combined and narrow component facts require Conflict Review.

### Researcher Decision Candidate

`APPROVE MAPPING`

---

## 33. Independent Research Reviewer Review

### Review Question 1

Was the Mapping approved because a matching Canonical Role already existed?

Decision:

`NO`

The Canonical Role was previously added only after rejecting a lossy RawMaterials Mapping.

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
* Same-filing Evidence

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

Does Approval allow grouping with RawMaterials?

Decision:

`NO`

Analytical Grouping remains a separate Research Question.

---

### Review Question 6

Does Approval prove Composition Equivalence?

Decision:

`NO`

The internal Raw Materials / Supplies ratio is not known from the Combined Fact.

---

### Review Question 7

Does Approval prove Metric Comparability?

Decision:

`NO`

The Research explicitly separates:

`Semantic Mapping`

from:

`Metric Comparability`

---

### Review Question 8

Is M1 too strong with one exact IFRS Filing Case?

Reviewer Concern:

`LIMITED FILING REPRODUCTION`

However:

The Mapping is a Direct Standard Taxonomy meaning-preserving case.

Evidence includes Official Taxonomy alignment and strong same-filing evidence.

Reviewer Decision:

`M1 remains justified as Research Mapping Confidence`

Condition:

New contradictory usage reopens Mapping Review.

---

## 34. Research Reviewer Decision

`APPROVE`

### Approved Research Mapping Candidate

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS → RawMaterialsAndSupplies`

### Mapping Confidence

`M1`

`Direct Meaning-preserving Mapping`

### Scope

`Validated IFRS eligible combined Raw Materials and Supplies inventory component facts`

### Usage Candidate

`Canonical RawMaterialsAndSupplies Observation`

### Atomic Combined Concept Treatment

`REQUIRED`

### Analytical Grouping

`NOT APPROVED`

### Composition Equivalence

`NOT EVALUATED`

### Metric Comparability

`NOT EVALUATED`

---

## 35. Reviewer Conditions

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
13. `RawMaterialsCAIFRS` remains mapped to `RawMaterials`.
14. `RawMaterials` and `RawMaterialsAndSupplies` remain distinct Canonical Roles.
15. `ProductionSuppliesCAIFRS` must not inherit this Mapping.
16. Multiple overlapping source concepts require Conflict Review.
17. Same Canonical Role Facts in the same Filing / Period / Scope must not be summed automatically.
18. Future non-current Combined Concept evidence triggers Boundary Review.
19. New Taxonomy Versions require Version Change Review.
20. Mapping Approval does not prove Accounting Measurement Equivalence.
21. Mapping Approval does not prove Composition Equivalence.
22. Mapping Approval does not prove Metric Comparability.
23. Mapping Approval does not authorize Analytical Grouping.
24. Mapping Approval does not establish Investment Interpretation.
25. Mapping Approval does not authorize Production implementation.

---

## 36. Mapping Approval Gate Result

| Gate Item                        | Result     |
| -------------------------------- | ---------- |
| Source Concept Identity          | CONFIRMED  |
| Eligibility                      | PASS       |
| Financial Meaning Evidence       | SUFFICIENT |
| Official Taxonomy Evidence       | PASS       |
| Cross-standard Pre-review        | PASS       |
| Canonical Role Candidate         | DEFINED    |
| Combined Semantic Preservation   | PASS       |
| Atomic Treatment                 | DEFINED    |
| Information Loss                 | MINOR      |
| RawMaterials Boundary            | REVIEWED   |
| ProductionSupplies Boundary      | REVIEWED   |
| Double-count Risk                | EVALUATED  |
| Contradicting Evidence           | REVIEWED   |
| Taxonomy Version                 | RECORDED   |
| Accounting Standard Boundary     | RECORDED   |
| Composition Equivalence Boundary | RECORDED   |
| Metric Comparability Boundary    | RECORDED   |
| Reviewer Decision                | APPROVE    |

### Gate Result

`PASS`

---

## 37. Architecture Reviewer Requirement

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

## 38. Final Mapping Research Result

### Source Concept

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

### Canonical Semantic Role

`RawMaterialsAndSupplies`

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

### Composition Equivalence

`NOT EVALUATED`

### Metric Comparability

`NOT EVALUATED`

### Production Mapping

`NOT YET APPROVED`

---

## 39. Cross-standard Combined Concept Procedure Evaluation

This Sheet is the second completed Cross-standard Combined Semantic Concept Mapping Case.

### Completed Cases

1. `MerchandiseAndFinishedGoods`
2. `RawMaterialsAndSupplies`

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

Composition Equivalence Separation:

`WORKED`

Metric Comparability Separation:

`WORKED`

Double-count Conflict Review:

`WORKED`

Reviewer Independence Review:

`WORKED`

### Result

`PASS`

### Stronger Process Finding

The same Cross-standard Combined Concept Research Procedure succeeded in two independent Concept Families.

Therefore:

`Cross-standard Combined Concept Review Procedure`

is now:

`REPEATEDLY VALIDATED IN RESEARCH`

However:

`Shortened Procedure`

is still not approved.

Reason:

Production Mapping Governance has not yet been designed.

---

## 40. Research Architecture Finding

The following Pattern is now supported by two Cross-standard Combined Concept Families.

### Pattern

`Combined Standard Source Concept`

↓

`Direct Mapping to Narrower Existing Role causes Material Information Loss Candidate`

↓

`Meaning-preserving Combined Canonical Role`

↓

`Cross-standard Official Taxonomy Equivalence Review`

↓

`Meaning-preserving Cross-standard Mapping`

### Supported Families

* `MerchandiseAndFinishedGoods`
* `RawMaterialsAndSupplies`

### Stronger Architecture Finding

`Combined Source Semantics should be preserved at Canonical Semantic Mapping Layer before Analytical Grouping.`

This finding now has:

* Japanese GAAP Evidence
* IFRS Evidence
* Official Taxonomy Evidence
* Cross-company Filing Evidence
* Two independent Combined Concept Families

### Status

`Strong Research Architecture Finding`

### Production Rule Status

`NOT YET APPROVED`

---

## 41. Current Canonical Semantic Role Set

Approved Research Canonical Roles:

* `InventoryTotal`
* `FinishedGoods`
* `WorkInProcess`
* `RawMaterials`
* `Other`
* `MerchandiseAndFinishedGoods`
* `RawMaterialsAndSupplies`

### Cross-standard Supported Roles

* `WorkInProcess`
* `MerchandiseAndFinishedGoods`
* `RawMaterialsAndSupplies`

### IFRS-supported Roles

* `InventoryTotal`
* `FinishedGoods`
* `WorkInProcess`
* `RawMaterials`
* `MerchandiseAndFinishedGoods`
* `RawMaterialsAndSupplies`

### Production Status

`NOT APPROVED`

---

## 42. Current Mapping Research State

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

### 7

`jpigp_cor:RawMaterialsCAIFRS → RawMaterials`

Class:

`M1`

Status:

`APPROVED`

### 8

`jppfs_cor:RawMaterialsAndSupplies → RawMaterialsAndSupplies`

Class:

`M1`

Status:

`APPROVED`

### 9

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS → RawMaterialsAndSupplies`

Class:

`M1`

Status:

`APPROVED`

### Rejected Candidates

`jppfs_cor:MerchandiseAndFinishedGoods → FinishedGoods`

Status:

`REJECTED`

`jppfs_cor:RawMaterialsAndSupplies → RawMaterials`

Status:

`REJECTED`

Important:

`Approved Research Mapping ≠ Production Mapping Master Entry`

Catalog / DDL / Entityへの登録はまだ行わない。

---

## 43. Exact Next Task

次のMapping Research Targetは以下とする。

`jpigp_cor:OtherInventoriesCAIFRS`

### Initial Canonical Semantic Role Candidate

`Other`

### Alternative Canonical Semantic Role Candidate

`OtherInventories`

### Initial Mapping Class Candidate

`M1 Candidate`

### Research Purpose

> IFRS Standard TaxonomyのOther Inventories Conceptについて、Canonical Role `Other` が十分なSemantic Precisionを持つか、または`OtherInventories`へRole Boundaryを修正すべきかを検証する。

### Primary Research Risk

`Other`

is a broad generic role name.

Potential Problem:

`Other`

may lose the domain meaning:

`Other Inventories`

### Research Focus

* Official Standard Label
* Official Element Attributes
* Kioxia Filing Evidence
* Inventory Component Eligibility
* Canonical Role naming precision
* Information Loss from `OtherInventories → Other`
* Future non-inventory `Other` role conflict
* Canonical Role expansion or rename
* M1 Approval feasibility

### Important

Do not assume:

`OtherInventoriesCAIFRS → Other`

is valid merely because `Other` exists in the current Role Candidate Set.

Primary Gate:

`Canonical Role Precision Review`

### Mapping Approval Status

`NOT STARTED`
