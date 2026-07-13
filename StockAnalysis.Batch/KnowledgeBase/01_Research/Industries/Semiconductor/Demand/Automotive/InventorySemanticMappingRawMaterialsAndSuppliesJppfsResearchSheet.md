# Inventory Semantic Mapping Research Sheet

# jppfs_cor:RawMaterialsAndSupplies

## 1. Document Purpose

本書は、EDINET Inventory Semantic Mapping Research Designに基づき、

`jppfs_cor:RawMaterialsAndSupplies`

をCanonical Inventory Semantic RoleへMapping可能か検証するResearch Sheetである。

### Initial Mapping Candidate

`jppfs_cor:RawMaterialsAndSupplies → RawMaterials`

### Alternative Canonical Semantic Role Candidate

`RawMaterialsAndSupplies`

本書の目的はProduction Mapping Masterを作成することではない。

目的は以下である。

> Japanese GAAP Standard TaxonomyのCombined Inventory Conceptである`RawMaterialsAndSupplies`について、`RawMaterials`へCanonical SimplificationすることによるInformation Lossを評価し、既存Canonical RoleへのMapping、独立Canonical Role追加、Conditional MappingまたはUnmappedのいずれがEvidence上妥当かを判断する。

### Status

* Research Sheet
* Semantic Mapping Research
* Japanese GAAP Combined Component Case
* Information Loss Primary Review
* Canonical Role Boundary Review
* Research Reviewer Evaluated
* Production Mapping Not Approved

---

## 2. Research Target

### Source Concept QName

`jppfs_cor:RawMaterialsAndSupplies`

### Local Name

`RawMaterialsAndSupplies`

### Prefix

`jppfs_cor`

### Accounting Standard

`Japanese GAAP`

### Initial Canonical Semantic Role Candidate

`RawMaterials`

### Alternative Canonical Semantic Role Candidate

`RawMaterialsAndSupplies`

### Initial Mapping Confidence Candidate

`M2`

`Strongly Supported Semantic Mapping`

Important:

Initial Mapping CandidateはResearch開始時点のCandidateである。

`RawMaterials`へのMappingを既定路線としない。

---

## 3. Primary Research Question

Primary Question:

> Can a Source Concept explicitly representing Raw Materials and Supplies be normalized to `RawMaterials` without removing material financial meaning?

Sub Questions:

1. Source Conceptは二つのInventory Meaningを明示的に含むか。
2. Suppliesは単なる表示上の表現差か。
3. Raw MaterialsとSuppliesは同一のInventory Stageとして扱えるか。
4. 半導体関連企業ではSuppliesの区別を無視できるか。
5. Inventory Composition Analysisへ影響する可能性はあるか。
6. Five-company reproductionはCanonical Simplificationを支持するか。
7. 独立Canonical Roleが必要か。
8. `RawMaterialsCAIFRS`とのFalse Semantic Equivalence Riskはあるか。
9. M2 Mapping Approvalは妥当か。
10. Architecture Reviewer Gateが必要か。

---

## 4. Evidence Hierarchy

本Researchでは以下のEvidence Priorityを採用する。

### Priority 1

Official EDINET Taxonomy Evidence

Includes:

* Source Concept Identity
* Official Label
* Taxonomy Account List Position
* Adjacent Inventory Concepts
* EDINET Concept Handling Principles

### Priority 2

Validated Filing Evidence

Observed Companies:

* ROHM
* Fuji Electric
* Sanken Electric
* Torex Semiconductor
* Tokyo Electron

### Priority 3

Financial Statement / Inventory Note Context

Purpose:

* Actual disclosed component label
* Inventory component position
* Component value
* Inventory total relationship

### Priority 4

Cross-company Reproduction

Purpose:

Determine whether the same Source Concept repeatedly represents the same Combined Inventory Meaning.

### Priority 5

Canonical Convenience

Classification:

`NOT EVIDENCE`

A smaller Canonical Role set is not sufficient reason to remove Source Meaning.

---

## 5. Source Concept Identity

### QName

`jppfs_cor:RawMaterialsAndSupplies`

### Namespace Family

`jppfs`

### Local Name

`RawMaterialsAndSupplies`

### Observed Japanese Meaning

`原材料及び貯蔵品`

### English Semantic Expression

`Raw materials and supplies`

### Semantic Structure

`Raw Materials + Supplies`

### Classification

* Japanese GAAP Standard Taxonomy Concept
* Inventory Component Concept
* Combined Semantic Concept
* Monetary Fact Candidate
* Instant Balance Fact Candidate

### Source Concept Identity

`CONFIRMED`

---

## 6. Combined Semantic Structure

The Source Concept explicitly contains:

`Raw Materials`

and:

`Supplies`

Therefore:

`RawMaterialsAndSupplies`

is not semantically identical to:

`RawMaterials`

### Source Semantic Structure

`Raw Materials + Supplies`

### Initial Finding

`Combined Semantic Concept`

The Supplies meaning must be evaluated before Canonical Simplification.

---

## 7. Adjacent Concept Boundary

Validated IFRS Taxonomy Research has already identified distinct Concept Candidates including:

* `RawMaterialsCAIFRS`
* `RawMaterialsAndSuppliesCAIFRS`
* `ProductionSuppliesCAIFRS`
* `WorkInProcessAndRawMaterialsCAIFRS`

Existing Approved Research Mapping:

`jpigp_cor:RawMaterialsCAIFRS → RawMaterials`

The direct IFRS Concept represents:

`Raw Materials`

The current Japanese GAAP Source Concept represents:

`Raw Materials + Supplies`

### Boundary Finding

`RawMaterials`

and:

`RawMaterialsAndSupplies`

are distinct Source Semantic Concepts.

### Important

The existence of distinct Raw Materials and Supplies-related taxonomy concepts weakens the assumption:

`Supplies is merely another label for Raw Materials.`

Current Classification:

`NOT SUPPORTED`

---

## 8. Evidence Scope

The Source Concept was observed in the following validated Japanese GAAP companies.

* ROHM
* Fuji Electric
* Sanken Electric
* Torex Semiconductor
* Tokyo Electron

### Observed Company Count

`5`

### Observed Filing Count

`5`

### Accounting Standard

`Japanese GAAP`

### Cross-company Reproduction

`STRONG`

However:

`Strong Source Concept Reproduction ≠ Canonical Simplification Approval`

Cross-company reproduction confirms stability of the Combined Source Meaning.

It does not prove that `Supplies` can be discarded.

---

## 9. Evidence Case A

## ROHM

### Source Concept

`jppfs_cor:RawMaterialsAndSupplies`

### Observed Role

`Inventory Component`

### Observed Context Candidate

* `Prior1YearInstant`
* `CurrentYearInstant`

### Scope

`Consolidated`

### Unit

`JPY`

### Inventory Structure

`Type B`

The Concept was used as one of the validated Inventory Component Facts.

### Research Finding

ROHM Filing Evidence supports:

`RawMaterialsAndSupplies = Inventory Component`

The structured Source Fact does not provide a Raw Materials / Supplies split.

---

## 10. Evidence Case B

## Fuji Electric

### Source Concept

`jppfs_cor:RawMaterialsAndSupplies`

### Prior

`99,021,000,000 JPY`

### Current

`98,994,000,000 JPY`

### Context

* `Prior1YearInstant`
* `CurrentYearInstant`

### Scope

`Consolidated`

### Decimals

`-6`

The same QName also existed under NonConsolidated Member contexts.

### Research Finding

Semantic Concept Identity is stable.

Fact Eligibility remains Context-dependent.

No Evidence separates:

`Raw Materials`

from:

`Supplies`

within the consolidated Source Fact.

---

## 11. Evidence Case C

## Sanken Electric

### Source Concept

`jppfs_cor:RawMaterialsAndSupplies`

### Prior

`6,949,000,000 JPY`

### Current

`5,928,000,000 JPY`

### Context

* `Prior1YearInstant`
* `CurrentYearInstant`

### Scope

`Consolidated`

### Decimals

`-6`

### Inventory Structure

`Type B`

### Research Finding

The Source Fact supports a Combined Inventory Component Observation.

The selected consolidated Fact set does not provide Source-supported decomposition into:

`RawMaterials`

and:

`Supplies`

---

## 12. Evidence Case D

## Torex Semiconductor

### Source Concept

`jppfs_cor:RawMaterialsAndSupplies`

### Prior

`1,483,746,000 JPY`

### Current

`2,257,956,000 JPY`

### Context

* `Prior1YearInstant`
* `CurrentYearInstant`

### Scope

`Consolidated`

### Decimals

`-3`

The Source Fact was observed as a consolidated inventory component.

### Research Finding

The Source Fact provides a Combined Raw Materials and Supplies value.

No Source-supported split was confirmed.

---

## 13. Evidence Case E

## Tokyo Electron

### Source Concept

`jppfs_cor:RawMaterialsAndSupplies`

### Prior

`267,580,000,000 JPY`

### Current

`216,494,000,000 JPY`

### Context

* `Prior1YearInstant`
* `CurrentYearInstant`

### Scope

`Consolidated`

### Decimals

`-6`

KAM Context identified:

`原材料及び貯蔵品`

as a major Inventory Component.

### Research Finding

The disclosed financial meaning is explicitly Combined.

No Primary Evidence supports removing:

`貯蔵品`

from the Canonical Observation.

---

## 14. Cross-company Reproduction Review

Observed Companies:

* ROHM
* Fuji Electric
* Sanken Electric
* Torex Semiconductor
* Tokyo Electron

Observed Source Concept:

`jppfs_cor:RawMaterialsAndSupplies`

Observed Financial Role:

`Inventory Component`

Observed Japanese Meaning:

`原材料及び貯蔵品`

Observed Period Type:

`Instant`

Observed Consolidated Context Candidate:

* `Prior1YearInstant`
* `CurrentYearInstant`

### Cross-company Result

`REPRODUCED`

### Evidence Strength

`Strong Cross-company Support`

### Important Boundary

Current Evidence strongly supports:

`RawMaterialsAndSupplies`

as a stable Source Semantic Concept.

Current Evidence does not support:

`RawMaterialsAndSupplies → RawMaterials`

---

## 15. Supplies Semantic Review

The Source Concept distinguishes:

`Raw Materials`

and:

`Supplies`

The existing IFRS Taxonomy Research has separately identified:

`ProductionSuppliesCAIFRS`

as a Supplies-related Concept Candidate.

Therefore the following assumption is not supported:

`Supplies = Raw Materials`

### Semantic Boundary Candidate

Raw Materials may primarily represent materials entering production or manufacturing processes.

Supplies may represent stored or production-related consumable inventory with a different operational provenance.

### Evidence Classification

`Semantic Distinction Candidate`

### Important

This Research does not establish that the distinction has predictive investment value.

It establishes that the Source Meaning distinction exists and has not been proven immaterial.

---

## 16. Semiconductor Business Context Review

Potential Hypothesis:

`Supplies may be immaterial relative to Raw Materials in semiconductor-related manufacturers.`

Status:

`HYPOTHESIS`

Current Evidence:

`INSUFFICIENT`

The Combined Source Facts do not provide:

`Raw Materials / Supplies split`

Therefore the following statement is unsupported:

`Supplies is negligible in the validated companies.`

### Reviewer Boundary

Industry intuition cannot be used to remove Supplies meaning.

---

## 17. Initial Canonical Mapping Candidate

## Candidate A: RawMaterials

Mapping:

`RawMaterialsAndSupplies → RawMaterials`

Initial Mapping Class:

`M2`

### Potential Benefit

* Smaller Canonical Role set
* Easier comparison with `RawMaterialsCAIFRS`
* Easier RawMaterials growth calculation
* Simpler downstream Feature Schema

### Potential Cost

* Supplies meaning removed
* Potential false Cross-standard equivalence
* Potential procurement / inventory composition distinction removed
* Potential Derived Metric distortion

### Initial Evaluation

`HIGH INFORMATION LOSS CONCERN`

---

## 18. Alternative Canonical Role Candidate

## Candidate B: RawMaterialsAndSupplies

Canonical Role:

`RawMaterialsAndSupplies`

Role Meaning:

`Combined raw materials and supplies inventory component`

### Potential Benefit

* Preserves Source Meaning
* Avoids unsupported decomposition
* Avoids false equivalence with `RawMaterialsCAIFRS`
* Preserves future analytical flexibility
* Aligns with repeated Source Concept Evidence

### Potential Cost

* Canonical Role count increases
* Cross-company component comparison becomes less uniform
* Future Analytical Grouping may be required

### Initial Evaluation

`SEMANTICALLY SAFER`

---

## 19. Semantic Mapping vs Analytical Grouping

### Semantic Mapping Question

`What does the Source Fact mean?`

### Analytical Grouping Question

`Which observations may be analyzed together?`

These are separate Research Questions.

Incorrect:

`We want a Raw Materials metric, therefore map RawMaterialsAndSupplies to RawMaterials.`

Correct Candidate:

`Preserve Source Meaning`

↓

`Validate Analytical Comparability`

↓

`Create Analytical Group if supported`

### Research Finding

`Canonical Semantic Mapping ≠ Analytical Feature Grouping`

This distinction is mandatory.

---

## 20. Analytical Grouping Candidate

Future Analytical Group Candidate:

`InputInventoryGroup`

or:

`RawMaterialRelatedInventoryGroup`

Potential Members Candidate:

* `RawMaterials`
* `RawMaterialsAndSupplies`

However:

This is an Analytical Grouping Candidate.

It is not a Canonical Semantic Mapping Decision.

### Status

`NOT APPROVED`

Required Future Validation:

* Composition differences
* Supplies materiality
* Business model differences
* Predictive contribution
* Metric stability

---

## 21. Information Loss Evaluation

## Candidate A: RawMaterials

### Source Meaning

`Raw Materials and Supplies`

### Canonical Meaning

`Raw Materials`

### Removed Meaning

`Supplies`

### Information Loss

`MATERIAL CANDIDATE`

Reason:

An explicit component of the Source Concept is removed.

Current Evidence does not establish that Supplies is immaterial.

### Lineage Mitigation

Original QName and Label may remain available.

However:

Lineage preservation does not prevent a Canonical Observation named `RawMaterials` from containing broader source meaning.

### Current Decision

`Material Information Loss Concern Remains`

---

## 22. Information Loss Evaluation

## Candidate B: RawMaterialsAndSupplies

### Source Meaning

`Raw Materials and Supplies`

### Canonical Meaning

`RawMaterialsAndSupplies`

### Removed Meaning

`None Material Identified`

### Information Loss

`NONE`

### Current Decision

`Meaning-preserving Candidate`

---

## 23. Cross-standard Comparison Risk

Existing Approved IFRS Mapping:

`jpigp_cor:RawMaterialsCAIFRS → RawMaterials`

If Japanese GAAP:

`jppfs_cor:RawMaterialsAndSupplies → RawMaterials`

is approved, the Canonical Role would combine:

`Raw Materials only`

and:

`Raw Materials + Supplies`

under the same semantic identity.

### Potential Result

`False Cross-standard Semantic Equivalence`

### Research Finding

Current Evidence does not prove:

`RawMaterialsAndSupplies`

and:

`RawMaterialsCAIFRS`

are semantically equivalent.

Therefore:

`Cross-standard unification into RawMaterials is not justified.`

---

## 24. Metric Distortion Risk

Potential Derived Metric:

`RawMaterialsGrowthYoY`

If `RawMaterialsAndSupplies` is mapped to `RawMaterials`, the Metric may compare:

### Company A

`Raw Materials Growth`

with:

### Company B

`Raw Materials + Supplies Growth`

under one Feature Name.

Potential Distortion:

* Raw material procurement changes
* Supplies inventory changes
* Production consumable buildup
* Production process differences
* Company business model differences

### Risk Classification

`MATERIAL CANDIDATE`

### Decision

Do not create a common `RawMaterialsGrowthYoY` from both Source Concepts without Analytical Comparability Validation.

---

## 25. Atomic Combined Concept Principle

Existing Research Principle:

`Combined Source Concept → Atomic Canonical Observation`

unless:

`Source-supported decomposition exists`

The current Source Concept is explicitly Combined.

No validated Source-supported Raw Materials / Supplies decomposition exists in the selected five-company Fact set.

Therefore:

`RawMaterialsAndSupplies`

must remain atomic.

### Unsupported Synthetic Decomposition

Prohibited Example:

`RawMaterialsAndSupplies Value`

↓

`RawMaterials = assumed amount`

*

`Supplies = assumed amount`

without Primary Source Evidence.

### Atomic Treatment Result

`PASS`

---

## 26. Double-count Risk Evaluation

### Risk A

Separate `RawMaterials` and combined `RawMaterialsAndSupplies` Facts coexist.

Potential Overlap:

`HIGH`

### Risk B

Separate `Supplies` and combined `RawMaterialsAndSupplies` Facts coexist.

Potential Overlap:

`HIGH`

### Risk C

Combined Concept is synthetically decomposed and original Combined Fact is also retained.

Potential Result:

`DOUBLE COUNT`

### Required Governance

`Combined Concepts remain atomic unless Source-supported decomposition exists.`

---

## 27. Contradicting Evidence Search

### Evidence that Source Concept means Raw Materials only

`NOT IDENTIFIED`

### Evidence that Supplies is always immaterial

`NOT IDENTIFIED`

### Evidence that Supplies may be ignored for Investment Analysis

`NOT IDENTIFIED`

### Evidence that the selected consolidated Fact sets separately disclose Supplies share

`NOT IDENTIFIED`

### Evidence that RawMaterialsAndSupplies is semantically identical to RawMaterialsCAIFRS

`NOT IDENTIFIED`

### Contradicting Evidence to Independent Combined Meaning

`NONE IDENTIFIED`

Current Evidence favors preservation of the Combined Source Meaning.

---

## 28. Mapping Confidence Evaluation

## Candidate A

Mapping:

`jppfs_cor:RawMaterialsAndSupplies → RawMaterials`

Initial Class Candidate:

`M2`

### Evaluation

Source Meaning Clear:

`PASS`

Canonical Simplification:

`YES`

Information Loss:

`MATERIAL CANDIDATE`

Cross-standard Distortion Risk:

`YES`

Metric Distortion Risk:

`YES`

Evidence that removed Supplies meaning is immaterial:

`INSUFFICIENT`

### M2 Result

`FAIL`

Current Evidence does not justify M2 Mapping Approval.

---

## 29. Mapping Confidence Evaluation

## Candidate B

Mapping:

`jppfs_cor:RawMaterialsAndSupplies → RawMaterialsAndSupplies`

Candidate Class:

`M1`

`Direct Meaning-preserving Mapping`

### Evaluation

Standard Taxonomy Concept:

`PASS`

Canonical Meaning Directly Matches Source Meaning:

`PASS`

Inventory Component Role:

`PASS`

Five-company Reproduction:

`PASS`

Information Loss:

`NONE MATERIAL`

Cross-standard False Equivalence Risk:

`REDUCED`

### Candidate Result

`STRONGLY SUPPORTED`

However:

`RawMaterialsAndSupplies`

is not yet an Approved Research Canonical Role.

Therefore:

`Architecture Reviewer Gate Required`

---

## 30. Researcher Proposal

### Reject Initial Mapping Candidate

`jppfs_cor:RawMaterialsAndSupplies → RawMaterials`

### Proposed Decision

`REJECT`

### Reason

`Material Information Loss Candidate`

and:

`Insufficient Evidence that Supplies distinction is immaterial`

---

### Proposed New Canonical Role Candidate

`RawMaterialsAndSupplies`

### Proposed Mapping

`jppfs_cor:RawMaterialsAndSupplies → RawMaterialsAndSupplies`

### Proposed Mapping Class

`M1`

`Direct Meaning-preserving Mapping`

### Proposed Usage

`Canonical Combined Inventory Component Observation`

### Architecture Impact

`Canonical Role Addition Required`

Therefore:

`Architecture Reviewer Gate = REQUIRED`

---

## 31. Researcher Evidence Summary

### Supporting Evidence for New Role

* Japanese GAAP Standard Taxonomy Concept
* Explicit Combined Source Concept identity
* Explicit `Raw Materials + Supplies` meaning
* Five-company Cross-company Reproduction
* Stable Inventory Component role
* No validated Source-supported decomposition
* Material Information Loss Risk from `RawMaterials` simplification
* False Cross-standard Equivalence Risk with `RawMaterialsCAIFRS`
* Derived Metric distortion risk
* Atomic Combined Concept Principle

### Known Limitations

* Investment relevance of the Supplies distinction is not yet validated.
* Analytical grouping with RawMaterials may later prove useful.
* Broader company Evidence outside the current semiconductor-related cluster is limited.
* Production Canonical Role model is not approved.

### Researcher Decision

`REJECT INITIAL M2 MAPPING`

and:

`PROPOSE NEW CANONICAL ROLE`

---

## 32. Independent Research Reviewer Review

### Review Question 1

Is the Research over-preserving taxonomy wording?

Reviewer Concern:

`POSSIBLE`

A Canonical Layer must normalize Source variation.

However:

Normalization requires demonstrated semantic equivalence.

Current Evidence does not establish that Supplies is immaterial or equivalent to Raw Materials.

### Decision

`Preservation is justified at current Evidence level.`

---

### Review Question 2

Does Five-company Reproduction support simplification?

Decision:

`NO`

Five-company Reproduction supports stability of the Combined Source Concept.

It does not support removal of Supplies meaning.

---

### Review Question 3

Would a separate Canonical Role create unnecessary complexity?

Decision:

`POSSIBLY`

However:

`Schema compactness`

is not sufficient reason to create false semantic equivalence.

Future Analytical Grouping can address broader analysis.

### Reviewer Principle

`Semantic correctness before schema compactness.`

---

### Review Question 4

Could RawMaterialsAndSupplies map to RawMaterials only for semiconductor-related companies?

Decision:

`INSUFFICIENT EVIDENCE`

The selected Source Facts do not provide a Supplies split.

Industry-specific Conditional Mapping is not approved.

---

### Review Question 5

Does Lineage preservation make RawMaterials Mapping safe?

Decision:

`NO`

Lineage preserves auditability.

It does not prevent a Canonical Feature named `RawMaterials` from carrying Combined Source Meaning.

---

### Review Question 6

Should the Concept remain Unmapped instead of adding a Role?

Decision:

`NO`

The Source Meaning is clear.

The Concept is reproduced across five companies.

The issue is absence of a matching current Canonical Role.

Therefore:

`Canonical Role Expansion Review`

is more appropriate than:

`M5 Unmapped`

---

## 33. Research Reviewer Decision

### Initial Mapping Candidate

`jppfs_cor:RawMaterialsAndSupplies → RawMaterials`

Decision:

`REJECT`

Mapping Class:

`M2 NOT APPROVED`

Reason:

`Material Information Loss Candidate`

---

### Alternative Mapping Candidate

`jppfs_cor:RawMaterialsAndSupplies → RawMaterialsAndSupplies`

Research Reviewer Decision:

`CONDITIONAL APPROVE PENDING ARCHITECTURE REVIEW`

Mapping Confidence Candidate:

`M1`

`Direct Meaning-preserving Mapping`

Reason:

* Source Meaning directly preserved
* Five-company reproduction
* Stable Inventory Component role
* No material semantic loss identified

---

## 34. Architecture Reviewer Gate

### Canonical Role Addition

`YES`

### Proposed New Role

`RawMaterialsAndSupplies`

### Role Meaning

`Combined raw materials and supplies inventory component`

### Semantic Role Set Change

`YES`

### Potential Downstream Impact

* Canonical Component Observation Schema
* Derived Inventory Component Metrics
* Cross-standard Comparison
* Analytical Grouping
* Future Catalog
* Future DDL
* Future ML Feature Definition

Therefore:

`Architecture Reviewer Gate = REQUIRED`

---

## 35. Architecture Reviewer Evaluation

### Question 1

Does the proposed Role represent a repeatedly observed financial meaning?

Decision:

`YES`

Observed in five validated Japanese GAAP companies.

---

### Question 2

Can the existing `RawMaterials` Role preserve the Source Meaning?

Decision:

`NO`

Supplies meaning would be removed.

---

### Question 3

Is the new Role created for one filer-specific variation?

Decision:

`NO`

The Source Concept is a Standard Taxonomy Concept reproduced across five companies.

---

### Question 4

Does the new Role duplicate `RawMaterials`?

Decision:

`NO`

`RawMaterials`

means:

`Raw Materials`

The proposed Role means:

`Raw Materials + Supplies`

The semantic boundaries differ.

---

### Question 5

Can Analytical Complexity be addressed later?

Decision:

`YES`

A future Analytical Group may include:

* `RawMaterials`
* `RawMaterialsAndSupplies`

subject to Analytical Comparability Validation.

---

### Question 6

Does adding the Role weaken Evidence Governance?

Decision:

`NO`

The new Role preserves Source Meaning and avoids unsupported normalization.

---

## 36. Architecture Reviewer Decision

`APPROVE CANONICAL ROLE ADDITION`

### New Canonical Semantic Role

`RawMaterialsAndSupplies`

### Role Meaning

`Combined raw materials and supplies inventory component`

### Status

`APPROVED RESEARCH CANONICAL ROLE`

### Production Master Status

`NOT APPROVED`

### Analytical Grouping

`NOT APPROVED`

---

## 37. Final Mapping Research Result

### Rejected Mapping

`jppfs_cor:RawMaterialsAndSupplies → RawMaterials`

### Mapping Class

`M2`

### Decision

`REJECT`

---

### Approved Research Mapping

`jppfs_cor:RawMaterialsAndSupplies → RawMaterialsAndSupplies`

### Mapping Class

`M1`

`DIRECT MEANING-PRESERVING MAPPING`

### Research Reviewer

`APPROVE`

### Architecture Reviewer

`APPROVE CANONICAL ROLE ADDITION`

### Mapping Gate

`PASS`

### Production Mapping

`NOT YET APPROVED`

---

## 38. Reviewer Conditions

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
12. Unsupported Raw Materials / Supplies decomposition is prohibited.
13. `RawMaterialsCAIFRS` remains mapped to `RawMaterials`.
14. `RawMaterials` and `RawMaterialsAndSupplies` remain distinct Canonical Roles.
15. `RawMaterialsAndSuppliesCAIFRS` does not inherit this Mapping automatically.
16. Optional Analytical Grouping requires separate Validation.
17. Common RawMaterials metric pooling is not approved.
18. Multiple overlapping inventory component facts require Conflict Review.
19. New Taxonomy Versions require Version Change Review.
20. Mapping Approval does not prove Accounting Measurement Equivalence.
21. Mapping Approval does not prove Metric Comparability.
22. Mapping Approval does not establish Investment Interpretation.
23. Mapping Approval does not authorize Production implementation.

---

## 39. Mapping Approval Gate Result

### Initial Candidate

| Gate Item                      | Result             |
| ------------------------------ | ------------------ |
| Source Concept Identity        | CONFIRMED          |
| Eligibility                    | PASS               |
| Financial Meaning Evidence     | SUFFICIENT         |
| Information Loss               | MATERIAL CANDIDATE |
| Cross-standard Distortion Risk | IDENTIFIED         |
| Metric Distortion Risk         | IDENTIFIED         |
| Reviewer Decision              | REJECT             |

### Initial Candidate Gate Result

`FAIL`

---

### Alternative Candidate

| Gate Item                  | Result            |
| -------------------------- | ----------------- |
| Source Concept Identity    | CONFIRMED         |
| Eligibility                | PASS              |
| Financial Meaning Evidence | SUFFICIENT        |
| Canonical Role             | NEW ROLE APPROVED |
| Information Loss           | NONE MATERIAL     |
| Cross-company Reproduction | 5 COMPANIES       |
| Atomic Treatment           | REQUIRED          |
| Double-count Risk          | EVALUATED         |
| Research Reviewer          | APPROVE           |
| Architecture Reviewer      | APPROVE           |

### Alternative Candidate Gate Result

`PASS`

---

## 40. Research Architecture Finding

This Research independently reproduces the architectural finding first observed with:

`MerchandiseAndFinishedGoods`

### Reproduced Pattern

`Combined Standard Taxonomy Concept`

↓

`Mapping to narrower existing Role causes Material Information Loss Candidate`

↓

`Meaning-preserving Combined Canonical Role preferred`

### Current Evidence Cases

1. `MerchandiseAndFinishedGoods`
2. `RawMaterialsAndSupplies`

### Stronger Architecture Finding

`Combined Source Concept → Meaning-preserving Canonical Role`

is now supported by two separate Standard Taxonomy Concept families.

However:

This is still a Research Architecture Finding.

It is not yet an automatic Production Mapping Rule.

---

## 41. Canonical Semantic Role Set

Current Approved Research Canonical Roles:

* `InventoryTotal`
* `FinishedGoods`
* `WorkInProcess`
* `RawMaterials`
* `Other`
* `MerchandiseAndFinishedGoods`
* `RawMaterialsAndSupplies`

### New Role

`RawMaterialsAndSupplies`

Status:

`APPROVED RESEARCH CANONICAL ROLE`

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

Next Mapping Research Target:

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

### Primary Canonical Role Candidate

`RawMaterialsAndSupplies`

### Cross-standard Reference Concept

`jppfs_cor:RawMaterialsAndSupplies`

### Research Purpose

> IFRS Standard TaxonomyのCombined Raw Materials and Supplies Conceptについて、新たにApproved Research Canonical Roleとなった`RawMaterialsAndSupplies`へのCross-standard Semantic Mapping可能性を検証する。

### Mandatory Gate

Because this Mapping crosses Accounting Standards:

`Cross-standard Semantic Equivalence Pre-review`

is required.

### Research Focus

* Official J-GAAP / IFRS Standard Labels
* Official Element Attributes
* Combined Semantic Structure
* Current Asset qualifier
* `RawMaterialsCAIFRS` boundary
* `ProductionSuppliesCAIFRS` boundary
* Accounting Measurement Equivalence boundary
* Metric Comparability boundary
* Atomic Combined Concept treatment
* Overlap Conflict Risk

### Mapping Approval Status

`NOT STARTED`

Do not create the Final Mapping Research Sheet directly.

First:

`RawMaterialsAndSupplies Cross-standard Equivalence Pre-review`
