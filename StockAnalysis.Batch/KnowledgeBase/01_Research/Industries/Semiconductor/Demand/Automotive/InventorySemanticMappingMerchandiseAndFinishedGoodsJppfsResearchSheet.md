# Inventory Semantic Mapping Research Sheet

# jppfs_cor:MerchandiseAndFinishedGoods

## 1. Document Purpose

本書は、EDINET Inventory Semantic Mapping Research Designに基づき、

`jppfs_cor:MerchandiseAndFinishedGoods`

をCanonical Inventory Semantic RoleへMapping可能か検証するResearch Sheetである。

### Initial Mapping Candidate

`jppfs_cor:MerchandiseAndFinishedGoods → FinishedGoods`

### Alternative Canonical Role Candidate

`MerchandiseAndFinishedGoods`

本書の目的はProduction Mapping Masterを作成することではない。

目的は以下である。

> Japanese GAAP Standard TaxonomyのCombined Inventory Conceptである`MerchandiseAndFinishedGoods`について、`FinishedGoods`へCanonical SimplificationすることによるInformation Lossを評価し、既存Canonical RoleへのMapping、Conditional Mapping、独立Canonical Role CandidateまたはUnmappedのいずれがEvidence上妥当かを判断する。

### Status

* Research Sheet
* Semantic Mapping Research
* Japanese GAAP Combined Component Case
* Information Loss Primary Review
* Canonical Role Boundary Review Candidate
* Research Reviewer Pending
* Production Mapping Not Approved

---

## 2. Research Target

### Source Concept QName

`jppfs_cor:MerchandiseAndFinishedGoods`

### Local Name

`MerchandiseAndFinishedGoods`

### Prefix

`jppfs_cor`

### Accounting Standard

`Japanese GAAP`

### Initial Canonical Semantic Role Candidate

`FinishedGoods`

### Alternative Canonical Semantic Role Candidate

`MerchandiseAndFinishedGoods`

### Initial Mapping Confidence Candidate

`M2`

`Strongly Supported Semantic Mapping`

Important:

Initial Mapping Class is a Research Candidate.

The Mapping is not assumed to be valid.

---

## 3. Primary Research Question

The Primary Question is:

> Can a Source Concept explicitly representing merchandise and finished goods be normalized to `FinishedGoods` without removing material financial meaning?

Sub Questions:

1. Does the Source Concept explicitly combine two inventory meanings?
2. Is merchandise merely a presentation wording difference?
3. Can merchandise and finished goods be treated as one economic inventory stage?
4. Does semiconductor industry usage reduce the distinction?
5. Could the distinction affect Inventory Composition analysis?
6. Does five-company reproduction support Canonical simplification?
7. Is an independent Canonical Role preferable?
8. Would Mapping to `FinishedGoods` distort cross-standard comparison with `FinishedGoodsCAIFRS`?
9. Is M2 approval justified?
10. Is Architecture Reviewer review required?

---

## 4. Evidence Hierarchy

This Research uses the following Evidence Priority.

### Priority 1

Official EDINET Taxonomy Evidence

Includes:

* Source Concept identity
* Official labels
* Taxonomy account list position
* Element attributes
* Adjacent concepts
* EDINET concept selection principles

### Priority 2

Validated Filing Evidence

Observed Companies:

* ROHM
* Fuji Electric
* Sanken Electric
* Torex Semiconductor
* Tokyo Electron

### Priority 3

Financial Statement and Inventory Note Context

Purpose:

* Actual disclosed component label
* Inventory component position
* Component composition
* Reported total relationship

### Priority 4

Cross-company Reproduction

Purpose:

Determine whether the same Source Concept is repeatedly used with the same disclosed meaning.

### Priority 5

Canonical Convenience

Classification:

`NOT EVIDENCE`

A simpler Canonical Schema is not sufficient reason to remove Source Meaning.

---

## 5. Source Concept Identity

### QName

`jppfs_cor:MerchandiseAndFinishedGoods`

### Namespace Family

`jppfs`

### Local Name

`MerchandiseAndFinishedGoods`

### Observed Japanese Meaning

`商品及び製品`

### English Semantic Expression

`Merchandise and finished goods`

### Classification

* Japanese GAAP Standard Taxonomy Concept
* Inventory Component Concept
* Combined Semantic Concept Candidate
* Monetary Fact Candidate
* Instant Balance Fact Candidate

### Source Concept Identity

`CONFIRMED`

---

## 6. Combined Semantic Structure

The Source Concept explicitly contains:

`Merchandise`

and:

`Finished Goods`

Therefore:

`MerchandiseAndFinishedGoods`

is not textually identical to:

`FinishedGoods`

Semantic Structure:

`Merchandise + Finished Goods`

Initial Finding:

`Combined Semantic Concept`

This distinction must be reviewed before Canonical Simplification.

---

## 7. Adjacent Concept Evidence

Japanese GAAP Inventory Taxonomy includes Concept Candidates such as:

* `Merchandise`
* `FinishedGoods`
* `MerchandiseAndFinishedGoods`
* `WorkInProcess`
* `RawMaterialsAndSupplies`
* `Supplies`

Research Finding:

`MerchandiseAndFinishedGoods`

exists alongside more specific inventory concept candidates.

Therefore:

`Merchandise`

and:

`Finished Goods`

are not necessarily treated as universally identical concepts.

### Important

The existence of separate adjacent concepts weakens the following assumption:

`Merchandise is only a label variation of Finished Goods.`

Current Classification:

`NOT SUPPORTED`

---

## 8. EDINET Concept Selection Boundary

EDINET taxonomy concept handling requires Source Concept meaning to be understood from taxonomy information and financial statement presentation.

For financial statement primary table concepts, concept selection is not intended to be driven only by approximate keyword similarity.

Research Implication:

`商品及び製品`

must not automatically be transformed into:

`製品`

for Canonical convenience.

Therefore:

`MerchandiseAndFinishedGoods → FinishedGoods`

requires explicit Information Loss approval.

---

## 9. Evidence Scope

The Concept was observed in the following validated Japanese GAAP companies:

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

`Strong Reproduction of Source Concept ≠ Approval of Canonical Simplification`

Cross-company reproduction confirms Source Concept stability.

It does not prove that part of the Source Meaning can be discarded.

---

## 10. Evidence Case A

## ROHM

### Source Concept

`jppfs_cor:MerchandiseAndFinishedGoods`

### Observed Role

Inventory Component

### Observed Context Candidate

* `Prior1YearInstant`
* `CurrentYearInstant`

### Scope

Consolidated

### Unit

JPY

### Inventory Structure

`Type B`

The Concept was used as one of the Inventory Component Facts.

Research Finding:

The Filing Evidence supports:

`MerchandiseAndFinishedGoods = Inventory Component`

It does not separately identify the merchandise share and finished goods share within the structured Fact.

---

## 11. Evidence Case B

## Fuji Electric

### Source Concept

`jppfs_cor:MerchandiseAndFinishedGoods`

### Prior

`84,472,000,000 JPY`

### Current

`98,282,000,000 JPY`

### Context

* `Prior1YearInstant`
* `CurrentYearInstant`

### Scope

Consolidated

### Decimals

`-6`

The same QName also existed in NonConsolidated Member context with different values.

Research Finding:

Semantic Concept Identity is stable.

Fact Eligibility remains Context-dependent.

No Evidence separates:

`Merchandise`

from:

`Finished Goods`

within the consolidated Source Fact.

---

## 12. Evidence Case C

## Sanken Electric

### Source Concept

`jppfs_cor:MerchandiseAndFinishedGoods`

### Prior

`11,911,000,000 JPY`

### Current

`15,132,000,000 JPY`

### Context

* `Prior1YearInstant`
* `CurrentYearInstant`

### Scope

Consolidated

### Decimals

`-6`

Inventory Structure:

`Type B`

The disclosed inventory component structure used the combined concept.

Research Finding:

The Source Fact supports a combined inventory component observation.

It does not provide separate structured facts for:

`Merchandise`

and:

`Finished Goods`

within the selected consolidated component set.

---

## 13. Evidence Case D

## Torex Semiconductor

### Source Concept

`jppfs_cor:MerchandiseAndFinishedGoods`

### Prior

`3,259,408,000 JPY`

### Current

`2,122,350,000 JPY`

### Context

* `Prior1YearInstant`
* `CurrentYearInstant`

### Scope

Consolidated

### Decimals

`-3`

KAM Evidence cross-referenced the current amount with:

`商品及び製品`

The structured Fact value and disclosed financial meaning were aligned.

### Research Finding

Same-filing Evidence strongly supports:

`MerchandiseAndFinishedGoods`

as the disclosed combined inventory component meaning.

It does not support reducing the meaning to `FinishedGoods` alone.

---

## 14. Evidence Case E

## Tokyo Electron

### Source Concept

`jppfs_cor:MerchandiseAndFinishedGoods`

### Prior

`291,523,000,000 JPY`

### Current

`286,052,000,000 JPY`

### Context

* `Prior1YearInstant`
* `CurrentYearInstant`

### Scope

Consolidated

### Decimals

`-6`

KAM Context identified:

`商品及び製品`

as a major inventory component.

### Research Finding

The disclosed meaning is explicitly combined.

No Primary Evidence currently supports removing:

`商品`

from the Semantic Observation.

---

## 15. Cross-company Reproduction Review

Observed Companies:

* ROHM
* Fuji Electric
* Sanken Electric
* Torex Semiconductor
* Tokyo Electron

Observed Source Concept:

`jppfs_cor:MerchandiseAndFinishedGoods`

Observed Financial Role:

`Inventory Component`

Observed Japanese Meaning:

`商品及び製品`

Observed Period Type:

`Instant`

Observed Common Consolidated Context Candidate:

* `Prior1YearInstant`
* `CurrentYearInstant`

### Cross-company Result

`REPRODUCED`

### Evidence Strength

`Strong Cross-company Support`

### Important Boundary

The Evidence strongly supports:

`MerchandiseAndFinishedGoods`

as a stable Source Semantic Concept.

The Evidence does not directly support:

`MerchandiseAndFinishedGoods → FinishedGoods`

---

## 16. Merchandise Semantic Review

`Merchandise`

generally represents goods held for sale that are not necessarily internally manufactured finished products.

`Finished Goods`

represents goods that have completed a production process.

Within a manufacturing company, both may appear in the same combined disclosed account.

However:

`Merchandise`

and:

`Finished Goods`

can represent different inventory origins and operational processes.

### Research Finding Candidate

`Merchandise and Finished Goods may have different economic provenance.`

### Evidence Classification

`Semantic / Accounting Distinction Candidate`

### Important

This Research does not assert that the distinction is investment-relevant.

It asserts only that the Source Meaning distinction exists and has not been proven immaterial.

---

## 17. Semiconductor Business Context Review

The five validated companies are semiconductor or semiconductor-equipment related companies.

Potential Hypothesis:

`Merchandise may be immaterial relative to Finished Goods in semiconductor manufacturers.`

Status:

`HYPOTHESIS`

Current Evidence:

`INSUFFICIENT`

The structured Source Fact does not provide a merchandise / finished goods split.

Therefore the following statement is not supported:

`Merchandise is negligible in the validated companies.`

### Reviewer Boundary

Industry intuition cannot be used to erase the Merchandise meaning.

---

## 18. Initial Canonical Mapping Candidate

### Candidate A

`MerchandiseAndFinishedGoods → FinishedGoods`

Mapping Class Candidate:

`M2`

Potential Benefit:

* Simpler Canonical Component Schema
* Easier comparison with `FinishedGoodsCAIFRS`
* Easier component growth calculation

Potential Cost:

* Merchandise meaning removed
* Potential cross-standard semantic distortion
* Potential company business model distinction removed
* Potential composition analysis distortion

### Initial Evaluation

`HIGH INFORMATION LOSS CONCERN`

---

## 19. Alternative Canonical Role Candidate

### Candidate B

`MerchandiseAndFinishedGoods`

Canonical Role Meaning:

`Combined merchandise and finished goods inventory component`

Potential Benefit:

* Preserves Source Meaning
* Avoids unsupported decomposition
* Avoids false equivalence with `FinishedGoodsCAIFRS`
* Preserves future analytical flexibility

Potential Cost:

* Canonical Role count increases
* Cross-company component comparison becomes less uniform
* Additional downstream Mapping / Grouping Research required

### Initial Evaluation

`SEMANTICALLY SAFER`

---

## 20. Conditional Analytical Grouping Candidate

A separate future analytical grouping may be considered.

Example:

`FinishedInventoryGroup`

Potential Members:

* `FinishedGoods`
* `MerchandiseAndFinishedGoods`

Purpose Candidate:

`Broader inventory-stage analysis`

Important:

This would be:

`Analytical Grouping`

not:

`Source Semantic Mapping`

Candidate Architecture:

`Raw Source Fact`

↓

`Canonical Semantic Role`

↓

`Optional Analytical Group`

Therefore:

`MerchandiseAndFinishedGoods`

could remain a distinct Canonical Role while later participating in a broader analytical grouping.

Status:

`Architecture Candidate`

Not Approved.

---

## 21. Semantic Mapping vs Analytical Grouping

This Research identifies an important distinction.

### Semantic Mapping Question

`What does the Source Fact mean?`

### Analytical Grouping Question

`Which observations may be analyzed together?`

These are not identical.

Incorrect:

`We want to compare finished inventories, therefore map everything to FinishedGoods.`

Correct Candidate:

`Preserve Source Meaning`

↓

`Validate Analytical Group Compatibility`

↓

`Group only if supported`

Research Finding:

`Canonical Semantic Mapping ≠ Analytical Feature Grouping`

This distinction is mandatory.

---

## 22. Information Loss Evaluation

## Candidate A: FinishedGoods

### Source Meaning

`Merchandise and Finished Goods`

### Canonical Meaning

`Finished Goods`

### Removed Meaning

`Merchandise`

### Information Loss

`MATERIAL CANDIDATE`

Reason:

An explicit component of the Source Concept is removed.

The removed component may represent different inventory provenance and operational meaning.

### Mitigation by Lineage

Source QName and Label can be preserved.

However:

Lineage preservation does not fully solve Semantic Normalization loss if the Canonical Observation itself is used as `FinishedGoods`.

### Current Decision

`Information Loss remains material candidate.`

---

## 23. Information Loss Evaluation

## Candidate B: MerchandiseAndFinishedGoods

### Source Meaning

`Merchandise and Finished Goods`

### Canonical Meaning

`MerchandiseAndFinishedGoods`

### Removed Meaning

`None Material Identified`

### Information Loss

`NONE`

### Current Decision

`Meaning-preserving candidate`

---

## 24. Cross-standard Comparison Risk

IFRS Mapping already approved:

`jpigp_cor:FinishedGoodsCAIFRS → FinishedGoods`

If Japanese GAAP:

`MerchandiseAndFinishedGoods → FinishedGoods`

is approved, then the Canonical Role would combine:

`Finished Goods only`

and:

`Merchandise + Finished Goods`

under the same semantic identity.

Potential Result:

`False Cross-standard Semantic Equivalence`

### Research Finding

Current Evidence does not prove:

`MerchandiseAndFinishedGoods`

and:

`FinishedGoodsCAIFRS`

are semantically equivalent.

Therefore:

`Cross-standard unification into FinishedGoods is not currently justified.`

---

## 25. Metric Distortion Risk

Potential Derived Metric:

`FinishedGoodsGrowthYoY`

If `MerchandiseAndFinishedGoods` is mapped to `FinishedGoods`, the Metric may compare:

### Company A

`Finished Goods Growth`

with:

### Company B

`Merchandise + Finished Goods Growth`

under one Feature Name.

Potential Distortion:

* Different inventory composition
* Merchandise acquisition changes
* Finished production changes
* Business model differences

### Risk Classification

`MATERIAL CANDIDATE`

### Decision

Do not create a common `FinishedGoodsGrowthYoY` from both Source Concepts without separate Analytical Comparability Validation.

---

## 26. Double-count Risk Evaluation

### Risk A

Separate `Merchandise` Fact and combined `MerchandiseAndFinishedGoods` Fact exist in the same Filing / Period / Scope.

Potential Overlap:

`HIGH`

### Risk B

Separate `FinishedGoods` Fact and combined `MerchandiseAndFinishedGoods` Fact coexist.

Potential Overlap:

`HIGH`

### Risk C

Combined Concept is decomposed into:

* Merchandise
* FinishedGoods

without Source Evidence.

Result:

`Unsupported Synthetic Split`

### Required Governance

`Combined Concepts must remain atomic unless a supported decomposition source exists.`

---

## 27. Atomic Combined Concept Principle

Initial Candidate Rule:

`Combined Source Concept → Atomic Canonical Observation`

unless:

`Source-supported decomposition exists`

Example:

`MerchandiseAndFinishedGoods`

remains atomic.

Do not create:

`Merchandise`

and:

`FinishedGoods`

from one Source Fact using assumed proportions.

### Classification

`Research Architecture Candidate`

This Principle is supported by the current Information Loss Review.

Architecture Reviewer evaluation is required because it affects Canonical Role Design.

---

## 28. Contradicting Evidence Search

### Evidence that Source Concept Means Finished Goods Only

`NOT IDENTIFIED`

### Evidence that Merchandise is always immaterial

`NOT IDENTIFIED`

### Evidence that Merchandise can be safely ignored for investment analysis

`NOT IDENTIFIED`

### Evidence that the five validated companies separately disclose the merchandise share in the selected structured consolidated Fact set

`NOT IDENTIFIED`

### Evidence that the combined Concept is semantically identical to IFRS `FinishedGoodsCAIFRS`

`NOT IDENTIFIED`

### Contradicting Evidence to Independent Combined Meaning

`NONE IDENTIFIED`

Current Evidence favors preservation of the combined Source Meaning.

---

## 29. Mapping Confidence Evaluation

## Candidate A

Mapping:

`jppfs_cor:MerchandiseAndFinishedGoods → FinishedGoods`

Initial Class Candidate:

`M2`

### M2 Evaluation

Source Meaning is clear:

`PASS`

Canonical Meaning is broader or simplified:

`YES`

Information Loss evaluated:

`MATERIAL CANDIDATE`

Cross-standard distortion risk:

`YES`

Metric distortion risk:

`YES`

Supporting Evidence that removed Merchandise meaning is immaterial:

`INSUFFICIENT`

### M2 Result

`FAIL`

Current Evidence does not justify M2 Mapping Approval.

---

## 30. Mapping Confidence Evaluation

## Candidate B

Mapping:

`jppfs_cor:MerchandiseAndFinishedGoods → MerchandiseAndFinishedGoods`

Candidate Class:

`M1 or Direct Meaning-preserving Mapping Candidate`

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

`MerchandiseAndFinishedGoods`

is not yet an approved Canonical Semantic Role in the current Research Design.

Therefore:

`Architecture Reviewer Gate Required`

---

## 31. Researcher Proposal

### Reject Initial Mapping Candidate

`jppfs_cor:MerchandiseAndFinishedGoods → FinishedGoods`

Proposed Decision:

`REJECT`

Reason:

`Material Information Loss Candidate`

and:

`Insufficient Evidence that Merchandise distinction is immaterial`

---

### Proposed New Canonical Role Candidate

`MerchandiseAndFinishedGoods`

Proposed Mapping:

`jppfs_cor:MerchandiseAndFinishedGoods → MerchandiseAndFinishedGoods`

Proposed Mapping Class Candidate:

`M1`

`Direct Meaning-preserving Mapping`

Proposed Usage:

`Canonical Combined Inventory Component Observation`

### Architecture Impact

`Canonical Role Addition Required`

Therefore:

`Architecture Reviewer Gate = REQUIRED`

---

## 32. Researcher Evidence Summary

### Supporting Evidence for New Role

* Standard Taxonomy Concept
* Explicit Combined Local Name
* Explicit Combined Japanese Meaning
* Five-company reproduction
* Stable Inventory Component role
* Same-filing financial statement evidence
* No supported merchandise / finished goods decomposition
* Material Information Loss risk from FinishedGoods simplification
* Cross-standard false equivalence risk
* Derived Metric distortion risk

### Known Limitations

* Investment relevance of Merchandise distinction is not yet validated.
* Analytical grouping with FinishedGoods may still prove useful.
* Broader Japanese GAAP company evidence outside the current industry cluster is limited.
* Production Canonical Role model is not approved.

### Researcher Decision

`REJECT INITIAL M2 MAPPING`

and:

`PROPOSE NEW CANONICAL ROLE`

---

## 33. Independent Research Reviewer Review

### Review Question 1

Is the Research over-preserving taxonomy wording?

Reviewer Concern:

`POSSIBLE`

A Canonical Layer should normalize Source variation.

However:

Normalization requires demonstrated semantic equivalence.

Current Evidence does not show Merchandise is immaterial or equivalent to Finished Goods.

### Decision

`Preservation is justified at current Evidence level.`

---

### Review Question 2

Does five-company reproduction support simplification?

Decision:

`NO`

Five-company reproduction supports the Source Concept's stability.

It does not support removing part of its meaning.

---

### Review Question 3

Would a separate Canonical Role create unnecessary complexity?

Decision:

`POSSIBLY`

However complexity alone is not sufficient reason to create false semantic equivalence.

The Role may later be grouped analytically.

### Reviewer Principle

`Semantic correctness before schema compactness.`

---

### Review Question 4

Could `MerchandiseAndFinishedGoods` be mapped to `FinishedGoods` only for semiconductor companies?

Decision:

`INSUFFICIENT EVIDENCE`

No validated Source split proves Merchandise immaterial within the five companies.

A Company or Industry-specific conditional mapping is not approved.

---

### Review Question 5

Does Lineage preservation make FinishedGoods Mapping safe?

Decision:

`NO`

Lineage allows later audit.

It does not prevent a Canonical Feature named `FinishedGoods` from carrying broader source meaning.

Therefore Material Semantic Loss remains.

---

### Review Question 6

Should the Concept remain Unmapped rather than add a Role?

Reviewer Judgment:

`NO`

The Source Meaning is clear and reproduced across five companies.

The problem is not ambiguity.

The problem is absence of a matching current Canonical Role.

Therefore:

`Canonical Role Expansion Review`

is more appropriate than `M5 Unmapped`.

---

## 34. Research Reviewer Decision

### Initial Mapping Candidate

`jppfs_cor:MerchandiseAndFinishedGoods → FinishedGoods`

Decision:

`REJECT`

Mapping Class:

`M2 NOT APPROVED`

Reason:

`Material Information Loss Candidate`

---

### Alternative Mapping Candidate

`jppfs_cor:MerchandiseAndFinishedGoods → MerchandiseAndFinishedGoods`

Research Reviewer Decision:

`CONDITIONAL APPROVE PENDING ARCHITECTURE REVIEW`

Mapping Confidence Candidate:

`M1`

`Direct Meaning-preserving Mapping`

Reason:

* Source Meaning directly preserved
* Five-company reproduction
* Inventory component role stable
* No material semantic loss identified

---

## 35. Reviewer Conditions

The alternative Mapping Candidate is subject to the following conditions.

1. Canonical Role addition requires Architecture Reviewer approval.
2. Original QName must be preserved.
3. Namespace URI must be preserved.
4. Taxonomy Version must be preserved.
5. Accounting Standard must be preserved.
6. Original ContextRef must be preserved.
7. Consolidated and NonConsolidated observations must remain separate.
8. Monetary Unit must be validated.
9. Decimals must be preserved.
10. Combined Source Concept must remain atomic.
11. Unsupported merchandise / finished goods decomposition is prohibited.
12. `FinishedGoodsCAIFRS` must remain mapped to `FinishedGoods`.
13. `MerchandiseAndFinishedGoods` and `FinishedGoods` must not be treated as semantically identical.
14. Optional analytical grouping requires separate Validation.
15. Common FinishedGoods metric pooling is not approved.
16. Multiple overlapping inventory component facts require Conflict Review.
17. Mapping approval does not authorize Production implementation.

---

## 36. Mapping Approval Gate Result

### Initial Candidate

| Gate Item                      | Result             |
| ------------------------------ | ------------------ |
| Source Concept Identity        | CONFIRMED          |
| Eligibility                    | PASS               |
| Financial Meaning Evidence     | SUFFICIENT         |
| Canonical Role Candidate       | DEFINED            |
| Information Loss               | MATERIAL CANDIDATE |
| Cross-standard Distortion Risk | IDENTIFIED         |
| Metric Distortion Risk         | IDENTIFIED         |
| Reviewer Decision              | REJECT             |

### Initial Candidate Gate Result

`FAIL`

---

### Alternative Candidate

| Gate Item                  | Result              |
| -------------------------- | ------------------- |
| Source Concept Identity    | CONFIRMED           |
| Eligibility                | PASS                |
| Financial Meaning Evidence | SUFFICIENT          |
| Canonical Role Candidate   | NEW ROLE REQUIRED   |
| Information Loss           | NONE MATERIAL       |
| Cross-company Reproduction | 5 COMPANIES         |
| Double-count Risk          | EVALUATED           |
| Reviewer Decision          | CONDITIONAL APPROVE |

### Alternative Candidate Gate Result

`PENDING ARCHITECTURE REVIEW`

---

## 37. Architecture Reviewer Gate

### Canonical Role Addition

`YES`

Proposed New Role:

`MerchandiseAndFinishedGoods`

### Canonical Role Split

`NO`

### Mapping Model Change

`NO`

### Semantic Role Set Change

`YES`

### Downstream Potential Impact

* Component Observation Schema
* Derived Component Metrics
* Analytical Grouping
* Cross-standard Comparison
* Future Catalog
* Future DDL
* Future ML Feature Definition

Therefore:

`Architecture Reviewer Gate = REQUIRED`

---

## 38. Architecture Reviewer Evaluation

### Question 1

Does the proposed Role represent a repeatedly observed financial meaning?

Decision:

`YES`

Observed in five validated Japanese GAAP companies.

---

### Question 2

Can the existing `FinishedGoods` Role preserve the Source Meaning?

Decision:

`NO`

Merchandise meaning would be removed.

---

### Question 3

Is the new Role being created for one filer-specific extension?

Decision:

`NO`

It is a Standard Taxonomy Concept reproduced across five companies.

---

### Question 4

Can Analytical Complexity be handled later?

Decision:

`YES`

Potential future grouping:

`FinishedInventoryGroup`

may include:

* `FinishedGoods`
* `MerchandiseAndFinishedGoods`

subject to Analytical Comparability Validation.

---

### Question 5

Does the new Role weaken Evidence Governance?

Decision:

`NO`

It preserves Source Meaning and reduces unsupported normalization.

---

## 39. Architecture Reviewer Decision

`APPROVE CANONICAL ROLE ADDITION`

### New Canonical Semantic Role Candidate

`MerchandiseAndFinishedGoods`

### Role Meaning

`Combined merchandise and finished goods inventory component`

### Status

`APPROVED RESEARCH CANONICAL ROLE`

### Production Master Status

`NOT APPROVED`

### Analytical Grouping

`NOT YET APPROVED`

---

## 40. Final Mapping Research Result

### Rejected Mapping

`jppfs_cor:MerchandiseAndFinishedGoods → FinishedGoods`

Mapping Class:

`M2`

Decision:

`REJECT`

---

### Approved Research Mapping

`jppfs_cor:MerchandiseAndFinishedGoods → MerchandiseAndFinishedGoods`

Mapping Class:

`M1`

`DIRECT MEANING-PRESERVING MAPPING`

Research Reviewer:

`APPROVE`

Architecture Reviewer:

`APPROVE CANONICAL ROLE ADDITION`

Mapping Gate:

`PASS`

Production Mapping:

`NOT YET APPROVED`

---

## 41. Research Architecture Finding

This Research identified a material architectural distinction.

`Semantic Normalization`

must not be optimized only for:

`Small Canonical Role Count`

A Canonical Role should be added when:

* Source Meaning is clear
* Meaning is repeatedly observed
* Existing Role causes Material Information Loss
* Source decomposition is unavailable
* Analytical grouping can be deferred

### New Principle Candidate

`Preserve combined source semantics before analytical grouping.`

This Principle is supported by the current Mapping Case.

---

## 42. Canonical Semantic Role Candidate Set

Current Research Canonical Role Set:

* `InventoryTotal`
* `FinishedGoods`
* `WorkInProcess`
* `RawMaterials`
* `Other`
* `MerchandiseAndFinishedGoods`

### New Role

`MerchandiseAndFinishedGoods`

Status:

`APPROVED RESEARCH CANONICAL ROLE`

Important:

`Research Canonical Role ≠ Production Master Entry`

---

## 43. Current Mapping Research State

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

`APPROVED RESEARCH MAPPING`

Architecture Review:

`PASS`

### Rejected Candidate

`jppfs_cor:MerchandiseAndFinishedGoods → FinishedGoods`

Status:

`REJECTED`

---

## 44. Exact Next Task

Next Mapping Research Target:

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

### Primary Canonical Role Candidate

`MerchandiseAndFinishedGoods`

### Cross-standard Reference Concept

`jppfs_cor:MerchandiseAndFinishedGoods`

### Research Purpose

> IFRS Standard TaxonomyのCombined Merchandise and Finished Goods Conceptについて、新たにApproved Research Canonical Roleとなった`MerchandiseAndFinishedGoods`へCross-standard Semantic Mapping可能か検証する。

### Mandatory Gate

Because this Mapping crosses Accounting Standards:

`Cross-standard Semantic Equivalence Pre-review`

is required.

### Research Focus

* Official J-GAAP / IFRS Standard Labels
* Official Element Attributes
* Combined Semantic Structure
* Current Asset qualifier
* Adjacent `FinishedGoodsCAIFRS`
* Cross-standard Information Loss
* Measurement Equivalence Boundary
* Metric Comparability Boundary
* Overlap Conflict Risk

### Mapping Approval Status

`NOT STARTED`

Do not directly create the final Mapping Research Sheet.

First:

`MerchandiseAndFinishedGoods Cross-standard Equivalence Pre-review`
