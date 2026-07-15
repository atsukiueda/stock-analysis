# Inventory Semantic Mapping Research Sheet

# Kioxia Company Extension

# SemiFinishedProductsAndWorkInProgressCAIFRS

## 1. Document Purpose

本書は、EDINET Inventory Semantic Mapping Research Designに基づき、Kioxia Holdingsの有価証券報告書で確認されたCompany Extension Concept、

`SemiFinishedProductsAndWorkInProgressCAIFRS`

をCanonical Inventory Semantic RoleへMapping可能か検証するResearch Sheetである。

### Initial Mapping Candidate

`SemiFinishedProductsAndWorkInProgressCAIFRS → WorkInProcess`

### Alternative Canonical Semantic Role Candidate

`SemiFinishedProductsAndWorkInProgress`

本書の目的はProduction Mapping Masterを作成することではない。

目的は以下である。

> Company Extension Conceptである`SemiFinishedProductsAndWorkInProgressCAIFRS`について、Source Concept Identity、Kioxia Filing Evidence、Inventory Note、Component Sum Reconciliation、Standard Taxonomy Concept Boundary及びInformation Lossを評価し、`WorkInProcess`へのMapping、独立Canonical Role追加、Conditional MappingまたはUnmappedのいずれがEvidence上妥当かを判断する。

### Status

* Research Sheet
* Semantic Mapping Research
* Company Extension Case
* Kioxia-specific Evidence
* Information Loss Review
* Architecture Reviewer Gate Candidate
* Production Mapping Not Approved

---

## 2. Research Target

### Source Concept QName

`jpcrp030000-asr_E35948-000:SemiFinishedProductsAndWorkInProgressCAIFRS`

### Local Name

`SemiFinishedProductsAndWorkInProgressCAIFRS`

### Source Type

`Company Extension Concept`

### Observed Company

`Kioxia Holdings Corporation`

### Accounting Standard

`IFRS`

### Initial Canonical Semantic Role Candidate

`WorkInProcess`

### Alternative Canonical Semantic Role Candidate

`SemiFinishedProductsAndWorkInProgress`

### Initial Mapping Confidence Candidate

`M3`

`Company Extension Reviewed`

Important:

Company Extension ConceptはStandard Taxonomy Conceptではない。

Concept NameのみからMappingを確定しない。

---

## 3. Primary Research Question

Primary Question:

> Can a Company Extension Concept explicitly representing Semi-finished Products and Work in Progress be normalized to `WorkInProcess` without removing material financial meaning?

Sub Questions:

1. Source Conceptは二つのInventory Meaningを明示的に含むか。
2. 半製品は仕掛品と同一Semantic Roleとして扱えるか。
3. Kioxia Filing Noteは両者をCombined Componentとして開示しているか。
4. `WorkInProcessCAIFRS`とのSemantic Boundaryは何か。
5. Component Sum ReconciliationはInventory Component Eligibilityを支持するか。
6. `WorkInProcess`へのMappingでMaterial Information Lossが生じるか。
7. 独立Canonical Role追加が必要か。
8. Company-specific Mappingとして限定すべきか。
9. M3 Mapping Approvalは妥当か。
10. Architecture Reviewer Gateが必要か。

---

## 4. Evidence Hierarchy

本Researchでは以下のEvidence Priorityを採用する。

### Priority 1

Exact Filing Evidence

Includes:

* Filing Identity
* Raw QName
* Namespace URI
* ContextRef
* UnitRef
* Decimals
* Raw Value
* Inventory Note Row
* Exact Value Match
* Component Sum Reconciliation

### Priority 2

Company Extension Source Meaning

Includes:

* Local Name
* Filing Label
* Financial Statement Position
* Note Context

### Priority 3

Official Standard Taxonomy Comparison

Relevant Standard Concept:

`jpigp_cor:WorkInProcessCAIFRS`

Purpose:

* Shared Meaning Review
* Information Loss Review
* Boundary Review

### Priority 4

Cross-company / Cross-standard Reference Mapping

Reference Canonical Role:

`WorkInProcess`

Approved Research Mappings:

* `jppfs_cor:WorkInProcess → WorkInProcess`
* `jpigp_cor:WorkInProcessCAIFRS → WorkInProcess`

### Priority 5

Concept Name Inference

Classification:

`Supporting Inference Only`

Company Extension Mapping cannot be approved by Local Name alone.

---

## 5. Filing Identity

### Company

キオクシアホールディングス株式会社

`Kioxia Holdings Corporation`

### Security Code

`285A0`

### EDINET Code

`E35948`

### Document ID

`S100YJ18`

### Document Type

`120`

### Period

`2025-04-01 - 2026-03-31`

### Submitted At

`2026-06-24 11:15`

### Accounting Standard

`IFRS`

### Consolidation Scope

`Consolidated`

### Filing Identity

`CONFIRMED`

---

## 6. Extension Namespace Confirmation

### QName

`jpcrp030000-asr_E35948-000:SemiFinishedProductsAndWorkInProgressCAIFRS`

### Namespace

`http://disclosure.edinet-fsa.go.jp/jpcrp030000/asr/001/E35948-000/2026-03-31/01/2026-06-24`

### Namespace Classification

`Company Filing Extension Namespace`

### Standard Taxonomy Namespace

`NOT jpigp_cor`

### Source Type Result

`COMPANY EXTENSION CONFIRMED`

This Concept must not be treated as a Standard Taxonomy Concept.

---

## 7. Source Concept Semantic Structure

### Local Name

`SemiFinishedProductsAndWorkInProgressCAIFRS`

### Explicit Semantic Components

* `SemiFinishedProducts`
* `WorkInProgress`

### Combined Semantic Structure

`Semi-finished Products + Work in Progress`

Therefore:

`SemiFinishedProductsAndWorkInProgress`

is not textually or semantically identical to:

`WorkInProcess`

### Initial Finding

`Combined Company Extension Concept`

---

## 8. Kioxia Raw Financial Facts

### Prior

QName:

`jpcrp030000-asr_E35948-000:SemiFinishedProductsAndWorkInProgressCAIFRS`

ContextRef:

`Prior1YearInstant`

UnitRef:

`JPY`

Decimals:

`-6`

Raw Value:

`283746000000`

### Current

QName:

`jpcrp030000-asr_E35948-000:SemiFinishedProductsAndWorkInProgressCAIFRS`

ContextRef:

`CurrentYearInstant`

UnitRef:

`JPY`

Decimals:

`-6`

Raw Value:

`280183000000`

### Classification

* Numeric Fact
* Instant Fact
* Consolidated IFRS Fact
* Monetary Fact
* JPY
* Company Extension Fact

### Eligibility Candidate

`Eligible Inventory Component Fact`

---

## 9. Kioxia Inventory Note Context

Kioxia Inventory Note disclosed the following components.

* 製品
* 半製品及び仕掛品
* 原材料
* その他
* 合計

### Prior

製品:

`50,549 million JPY`

半製品及び仕掛品:

`283,746 million JPY`

原材料:

`18,486 million JPY`

その他:

`82 million JPY`

Total:

`352,863 million JPY`

### Current

製品:

`53,232 million JPY`

半製品及び仕掛品:

`280,183 million JPY`

原材料:

`79,093 million JPY`

その他:

`104 million JPY`

Total:

`412,612 million JPY`

The Company Extension Fact matched the Inventory Note row:

`半製品及び仕掛品`

### Prior Value Match

`283,746 million JPY`

Result:

`EXACT MATCH`

### Current Value Match

`280,183 million JPY`

Result:

`EXACT MATCH`

### Research Finding

The Company Extension Concept directly represents the disclosed Combined Inventory Component:

`半製品及び仕掛品`

### Classification

`Strong Same-filing Semantic Evidence`

---

## 10. Component Sum Reconciliation

### Prior

`50,549 + 283,746 + 18,486 + 82 = 352,863`

Reported Inventory Total:

`352,863 million JPY`

Result:

`EXACT MATCH`

### Current

`53,232 + 280,183 + 79,093 + 104 = 412,612`

Reported Inventory Total:

`412,612 million JPY`

Result:

`EXACT MATCH`

### Research Use

Component Sum strongly supports:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

being one of the Inventory Components.

However:

`Component Sum Match ≠ WorkInProcess Mapping Approval`

The Semantic Mapping decision must still evaluate the `SemiFinishedProducts` meaning.

---

## 11. Inventory Component Eligibility

Candidate Fact must satisfy:

* Numeric Fact
* Instant Fact
* Validated Filing Identity
* Validated Consolidation Scope
* Validated Monetary Unit
* Inventory Component Meaning

### Numeric Fact

`PASS`

### Instant Fact

`PASS`

### Filing Identity

`PASS`

### Consolidation Scope

`PASS`

### Monetary Unit

`JPY`

`PASS`

### Inventory Component Meaning

`PASS`

### Eligibility Result

`Eligible Inventory Component Fact`

---

## 12. Reference Standard Concept

## WorkInProcessCAIFRS

Approved Research Mapping:

`jpigp_cor:WorkInProcessCAIFRS → WorkInProcess`

### Standard Concept Meaning

* 仕掛品
* Work in process

### Current Company Extension Meaning

* 半製品
* 仕掛品

### Shared Meaning

`Work in Progress`

### Additional Meaning in Extension

`Semi-finished Products`

### Boundary Finding

The Company Extension Concept is broader than:

`WorkInProcessCAIFRS`

---

## 13. Semi-finished Products Semantic Review

The Source Concept explicitly distinguishes:

`Semi-finished Products`

from:

`Work in Progress`

within one Combined Component.

The Filing Note likewise discloses:

`半製品及び仕掛品`

Therefore the following assumption is not supported:

`Semi-finished Products = merely another label for Work in Progress`

### Potential Economic Distinction

Semi-finished products may represent goods that have completed certain production stages but are not yet final finished goods.

Work in progress may represent production still in process.

### Evidence Classification

`Semantic Distinction Candidate`

### Important

This Research does not yet establish that the distinction has predictive investment value.

It establishes that the Source Meaning includes both concepts.

---

## 14. Semiconductor Manufacturing Context

In semiconductor manufacturing, production stages can be long and multi-step.

Potential categories may include:

* Wafer-stage inventory
* Processed but incomplete inventory
* Semi-finished devices
* Work in progress
* Finished goods

However:

The current Source Fact aggregates:

`Semi-finished Products`

and:

`Work in Progress`

Therefore:

No Source-supported split exists between the two.

### Research Boundary

Industry knowledge cannot be used to synthetically allocate:

`283,746 million JPY`

into separate:

* SemiFinishedProducts
* WorkInProcess

amounts.

### Synthetic Decomposition

`PROHIBITED`

---

## 15. Candidate A Review

## WorkInProcess

### Proposed Mapping

`SemiFinishedProductsAndWorkInProgressCAIFRS → WorkInProcess`

### Potential Benefit

* Reuses existing Canonical Role
* Easier comparison with Standard WIP concepts
* Simpler Feature Schema

### Primary Cost

`SemiFinishedProducts` meaning is removed.

### Potential False Equivalence

The following would be treated as the same Canonical Role:

`WorkInProcessCAIFRS`

and:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

despite one being broader.

### Initial Evaluation

`HIGH INFORMATION LOSS CONCERN`

---

## 16. Candidate B Review

## SemiFinishedProductsAndWorkInProgress

### Proposed Mapping

`SemiFinishedProductsAndWorkInProgressCAIFRS → SemiFinishedProductsAndWorkInProgress`

### Source Meaning Preservation

`PASS`

### Combined Semantic Structure Preservation

`PASS`

### Information Loss

`NONE MATERIAL`

### Potential Cost

* New Canonical Role
* Current Evidence is one-company-specific
* Future cross-company comparability uncertain

### Initial Evaluation

`SEMANTICALLY PRECISE`

---

## 17. Candidate C Review

## Conditional Company-specific Mapping to WorkInProcess

Possible Rule:

`Kioxia only`

`SemiFinishedProductsAndWorkInProgressCAIFRS → WorkInProcess`

### Potential Benefit

Simplifies Kioxia comparison with other companies.

### Problem

The semantic loss remains.

Company-specific scope does not make:

`Semi-finished Products`

disappear.

### Candidate C Evaluation

`NOT SUPPORTED`

Company-specific restriction does not solve semantic under-specification.

---

## 18. Candidate D Review

## Unmapped

### Potential Benefit

Avoids premature Canonical Role expansion.

### Problem

The Source Meaning is clear.

The exact Filing Evidence is strong.

The Concept is not ambiguous.

### Candidate D Evaluation

`UNNECESSARILY CONSERVATIVE`

The issue is not lack of meaning.

The issue is absence of a current matching Canonical Role.

---

## 19. Information Loss Evaluation

## Candidate A: WorkInProcess

### Source Meaning

`Semi-finished Products and Work in Progress`

### Canonical Meaning

`WorkInProcess`

### Removed Meaning

`SemiFinishedProducts`

### Information Loss

`MATERIAL CANDIDATE`

### Lineage Mitigation

Original QName and Source Label can remain.

However:

A Canonical Observation named:

`WorkInProcess`

would still contain a broader Source Value.

### Metric Risk

A derived metric:

`WorkInProcessGrowthYoY`

would compare:

`Pure Work In Process`

against:

`Semi-finished Products + Work In Progress`

across companies.

### Decision

`Material Information Loss remains`

---

## 20. Information Loss Evaluation

## Candidate B: SemiFinishedProductsAndWorkInProgress

### Source Meaning

`Semi-finished Products and Work in Progress`

### Canonical Meaning

`SemiFinishedProductsAndWorkInProgress`

### Removed Meaning

`None Material Identified`

### Information Loss

`NONE`

### Decision

`Meaning-preserving Candidate`

---

## 21. Atomic Combined Concept Principle

Existing Research Principle:

`Combined Source Concept → Atomic Canonical Observation`

unless:

`Source-supported decomposition exists`

The current Company Extension Concept is explicitly Combined.

No Source-supported split exists.

Therefore:

`SemiFinishedProductsAndWorkInProgress`

must remain atomic.

### Decomposition Status

`NOT APPROVED`

---

## 22. Cross-company Comparability Boundary

Current Evidence for this exact Company Extension Concept is:

`Kioxia Holdings`

only.

Therefore:

`Cross-company Reproduction = NOT ESTABLISHED`

### Important

Lack of reproduction does not invalidate the Source Meaning.

It does limit:

* Global Mapping confidence
* Cross-company analytical use
* Canonical Role generalization

### Proposed Scope Candidate

`Kioxia-specific reviewed Source Mapping`

until broader reproduction occurs.

---

## 23. Company-specific Scope Review

Because the Concept is a Company Extension:

`Global Standard Mapping`

is not appropriate.

### Proposed Mapping Scope

* Company: Kioxia Holdings
* Extension Namespace Family: E35948-000 filing extensions
* Reviewed Filing Family: Kioxia IFRS Annual Securities Report
* Semantic Role: `SemiFinishedProductsAndWorkInProgress`

### Mapping Class

`M3`

`Company Extension Reviewed`

### Future Promotion Candidate

If equivalent Concepts are observed across multiple companies:

`Cross-company Canonical Role Review`

may be performed.

---

## 24. Metric Comparability Boundary

Even if a Canonical Role is created:

`SemiFinishedProductsAndWorkInProgress`

the following remains unproven:

* comparability with `WorkInProcess`
* comparability with `FinishedGoods`
* cross-company predictive value
* cross-standard metric equivalence

### Research Finding

`Semantic Mapping Approval ≠ Analytical Comparability Approval`

### ML Use

`NOT APPROVED`

---

## 25. Double-count Risk Evaluation

### Risk A

`WorkInProcessCAIFRS`

and:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

appear in the same Filing / Period / Scope.

Potential Overlap:

`HIGH`

### Required Governance

`Conflict Review`

Do not sum automatically.

---

### Risk B

A future `SemiFinishedProductsCAIFRS` or equivalent Concept appears separately.

Potential Overlap:

`HIGH`

---

### Risk C

The Combined Concept is mapped to `WorkInProcess` while another pure WorkInProcess Fact also exists.

Potential Result:

`Semantic Double Count`

### Double-count Risk Classification

`HIGH`

### Decision

Preserving a distinct Combined Role reduces false equivalence risk.

---

## 26. Contradicting Evidence Search

### Evidence that the Concept means Work In Process only

`NOT IDENTIFIED`

### Evidence that Semi-finished Products are immaterial

`NOT IDENTIFIED`

### Evidence that the Company Extension is erroneous or redundant

`NOT IDENTIFIED`

### Evidence that WorkInProcessCAIFRS and the Extension are exact semantic equivalents

`NOT IDENTIFIED`

### Evidence that the Combined Concept should remain Unmapped

`NOT IDENTIFIED`

### Contradicting Evidence to Combined Meaning

`NONE IDENTIFIED`

---

## 27. Mapping Confidence Evaluation

## Candidate A

Mapping:

`SemiFinishedProductsAndWorkInProgressCAIFRS → WorkInProcess`

### Evaluation

Source Meaning Clear:

`PASS`

Canonical Simplification:

`YES`

Information Loss:

`MATERIAL CANDIDATE`

False Equivalence Risk:

`HIGH`

Metric Distortion Risk:

`HIGH`

Evidence that SemiFinishedProducts distinction is immaterial:

`INSUFFICIENT`

### Candidate A Result

`FAIL`

---

## 28. Mapping Confidence Evaluation

## Candidate B

Mapping:

`SemiFinishedProductsAndWorkInProgressCAIFRS → SemiFinishedProductsAndWorkInProgress`

### Evaluation

Company Extension Identity:

`PASS`

Exact Filing Evidence:

`PASS`

Inventory Note Cross-reference:

`PASS`

Exact Value Match:

`PASS`

Component Reconciliation:

`PASS`

Canonical Meaning Directly Matches Source Meaning:

`PASS`

Information Loss:

`NONE MATERIAL`

Cross-company Reproduction:

`NOT ESTABLISHED`

### Candidate Result

`STRONGLY SUPPORTED WITH COMPANY-SPECIFIC SCOPE`

### Mapping Class

`M3`

`Company Extension Reviewed`

---

## 29. Researcher Proposal

### Reject Initial Mapping Candidate

`SemiFinishedProductsAndWorkInProgressCAIFRS → WorkInProcess`

### Proposed Decision

`REJECT`

### Reason

`Material Information Loss Candidate`

and:

`False Equivalence Risk with pure WorkInProcess concepts`

---

### Proposed New Canonical Role Candidate

`SemiFinishedProductsAndWorkInProgress`

### Proposed Mapping

`SemiFinishedProductsAndWorkInProgressCAIFRS → SemiFinishedProductsAndWorkInProgress`

### Proposed Mapping Class

`M3`

`Company Extension Reviewed`

### Proposed Scope

`Kioxia-specific reviewed mapping`

### Architecture Impact

`Canonical Role Addition Required`

Therefore:

`Architecture Reviewer Gate = REQUIRED`

---

## 30. Independent Research Reviewer Review

### Review Question 1

Is a new Canonical Role excessive for one company?

Reviewer Concern:

`YES`

A Canonical Role should not proliferate for arbitrary filer-specific labels.

However:

The current Concept represents:

* a material inventory balance
* a clear combined semantic meaning
* exact Filing Note correspondence
* more than half of Kioxia inventory in the observed periods

The Source Meaning cannot be safely represented by an existing Role.

### Decision

`New Role is justified with limited Company-specific scope.`

---

### Review Question 2

Could WorkInProcess be used as a broader umbrella role?

Decision:

`NOT AT SEMANTIC MAPPING LAYER`

A broader analytical grouping could later include:

* `WorkInProcess`
* `SemiFinishedProductsAndWorkInProgress`

But that is:

`Analytical Grouping`

not:

`Canonical Semantic Mapping`

---

### Review Question 3

Does lack of cross-company reproduction require Unmapped status?

Decision:

`NO`

M3 exists specifically for reviewed Company Extension Concepts.

The Mapping must remain scope-limited.

---

### Review Question 4

Could `SemiFinishedProductsAndWorkInProgress` become a global Canonical Role?

Decision:

`NOT YET`

Current Evidence is Kioxia-specific.

Global promotion requires additional reproduction or architecture review.

---

### Review Question 5

Does this create excessive ML feature fragmentation?

Potentially:

`YES`

However:

Feature grouping belongs to later Analytical / ML Validation.

Semantic truth should not be changed to simplify feature engineering.

### Reviewer Principle

`Semantic correctness before feature compactness`

---

## 31. Research Reviewer Decision

### Initial Mapping Candidate

`SemiFinishedProductsAndWorkInProgressCAIFRS → WorkInProcess`

Decision:

`REJECT`

Reason:

`Material Information Loss`

---

### Alternative Mapping Candidate

`SemiFinishedProductsAndWorkInProgressCAIFRS → SemiFinishedProductsAndWorkInProgress`

Decision:

`CONDITIONAL APPROVE PENDING ARCHITECTURE REVIEW`

### Mapping Confidence

`M3`

`Company Extension Reviewed`

### Scope

`Kioxia-specific reviewed mapping`

---

## 32. Architecture Reviewer Gate

### Canonical Role Addition

`YES`

### Proposed New Role

`SemiFinishedProductsAndWorkInProgress`

### Role Meaning

`Combined semi-finished products and work in progress inventory component`

### Scope

`Research Canonical Role with current Kioxia-specific support`

### Semantic Role Set Change

`YES`

### Downstream Potential Impact

* Canonical Observation Schema
* Inventory Component Metrics
* Analytical Grouping
* Cross-company Comparison
* Future Catalog
* Future DDL
* Future ML Feature Definition

Therefore:

`Architecture Reviewer Gate = REQUIRED`

---

## 33. Architecture Reviewer Evaluation

### Question 1

Does the proposed Role preserve a clear Source Meaning?

Decision:

`YES`

---

### Question 2

Can an existing Role preserve the same meaning?

Decision:

`NO`

`WorkInProcess` removes Semi-finished Products meaning.

---

### Question 3

Is this merely a filer-specific wording variation?

Decision:

`NOT SUPPORTED`

The Concept corresponds exactly to a distinct disclosed Inventory Note row.

---

### Question 4

Is the role sufficiently material to justify preservation?

Decision:

`YES`

Observed values:

* Prior: `283,746 million JPY`
* Current: `280,183 million JPY`

The component is material within Kioxia Inventory.

---

### Question 5

Should the Role be globally generalized?

Decision:

`NO`

Current support is Company-specific.

### Required Scope

`Kioxia-specific reviewed Canonical Mapping`

---

## 34. Architecture Reviewer Decision

`APPROVE CANONICAL ROLE ADDITION WITH LIMITED SCOPE`

### New Canonical Semantic Role

`SemiFinishedProductsAndWorkInProgress`

### Role Meaning

`Combined semi-finished products and work in progress inventory component`

### Current Evidence Scope

`Kioxia Holdings`

### Mapping Status

`APPROVED RESEARCH CANONICAL ROLE`

### Global Cross-company Status

`NOT ESTABLISHED`

### Production Master Status

`NOT APPROVED`

---

## 35. Final Mapping Research Result

### Rejected Mapping

`SemiFinishedProductsAndWorkInProgressCAIFRS → WorkInProcess`

### Decision

`REJECT`

---

### Approved Research Mapping

`SemiFinishedProductsAndWorkInProgressCAIFRS → SemiFinishedProductsAndWorkInProgress`

### Mapping Class

`M3`

`COMPANY EXTENSION REVIEWED`

### Research Reviewer

`APPROVE`

### Architecture Reviewer

`APPROVE CANONICAL ROLE ADDITION WITH LIMITED SCOPE`

### Mapping Gate

`PASS`

### Current Scope

`Kioxia-specific`

### Cross-company Generalization

`NOT APPROVED`

### Analytical Grouping

`NOT APPROVED`

### Metric Comparability

`NOT EVALUATED`

### Production Mapping

`NOT YET APPROVED`

---

## 36. Reviewer Conditions

Approval is subject to the following conditions.

1. Full QName must be preserved.
2. Extension Namespace URI must be preserved.
3. Filing identity must be preserved.
4. EDINET Code must be preserved.
5. Accounting Standard must be preserved.
6. Source Label must remain traceable.
7. Original ContextRef must be preserved.
8. Instant balance semantics must be validated.
9. Consolidated and NonConsolidated observations must remain separate.
10. Monetary Unit must be validated.
11. Decimals must be preserved.
12. Combined Source Concept must remain atomic.
13. Unsupported Semi-finished Products / Work In Progress decomposition is prohibited.
14. `WorkInProcess` and `SemiFinishedProductsAndWorkInProgress` remain distinct Canonical Roles.
15. Mapping scope is currently Kioxia-specific.
16. The Mapping must not be automatically applied to other filer extensions with similar names.
17. Equivalent future Company Extensions require separate Research Review.
18. Global Canonical Role promotion requires additional Evidence.
19. Multiple overlapping WIP-related source concepts require Conflict Review.
20. Mapping Approval does not prove Analytical Comparability.
21. Mapping Approval does not prove Metric Comparability.
22. Mapping Approval does not establish Investment Interpretation.
23. Mapping Approval does not authorize Production implementation.

---

## 37. Mapping Approval Gate Result

### Initial Candidate

| Gate Item                  | Result    |
| -------------------------- | --------- |
| Source Concept Identity    | CONFIRMED |
| Company Extension Identity | CONFIRMED |
| Filing Evidence            | PASS      |
| Eligibility                | PASS      |
| Canonical Role Fit         | FAIL      |
| Information Loss           | MATERIAL  |
| Reviewer Decision          | REJECT    |

### Initial Candidate Gate Result

`FAIL`

---

### Alternative Candidate

| Gate Item                      | Result                     |
| ------------------------------ | -------------------------- |
| Source Concept Identity        | CONFIRMED                  |
| Company Extension Identity     | CONFIRMED                  |
| Filing Evidence                | PASS                       |
| Inventory Note Cross-reference | PASS                       |
| Exact Value Match              | PASS                       |
| Component Reconciliation       | PASS                       |
| Canonical Role Precision       | PASS                       |
| Information Loss               | NONE MATERIAL              |
| Cross-company Reproduction     | NOT ESTABLISHED            |
| Scope Limitation               | DEFINED                    |
| Research Reviewer              | APPROVE                    |
| Architecture Reviewer          | APPROVE WITH LIMITED SCOPE |

### Alternative Candidate Gate Result

`PASS`

---

## 38. Company Extension Procedure Evaluation

This Sheet is the first completed Company Extension Semantic Mapping Case.

### Procedure Evaluation

Extension Namespace Confirmation:

`WORKED`

Exact Filing Identity Review:

`WORKED`

Raw Fact Review:

`WORKED`

Inventory Note Cross-reference:

`WORKED`

Component Reconciliation:

`WORKED`

Standard Concept Boundary Review:

`WORKED`

Information Loss Review:

`WORKED`

Company-specific Scope Review:

`WORKED`

Architecture Reviewer Gate:

`WORKED`

### Result

`PASS`

### Process Finding

The Company Extension Research Procedure successfully prevented:

`Name-based forced mapping`

to an existing narrower Canonical Role.

### Procedure Status

`VALIDATED IN FIRST COMPANY EXTENSION CASE`

No shortened procedure is approved yet.

---

## 39. Research Architecture Finding

This Research adds a new Architecture Principle.

### Principle

`Company Extension Concepts may justify a limited-scope Canonical Role when Source Meaning is clear, material, and not representable by an existing Role without Material Information Loss.`

### Required Conditions

* Exact Filing Evidence
* Strong Source Meaning
* Materiality or analytical relevance
* No existing meaning-preserving Role
* Reviewer Approval
* Scope Limitation
* Full Lineage Preservation

### Important

This does not mean:

`Every Company Extension gets a new Canonical Role`

Default remains:

`Review First`

Possible Results:

* Existing Role Mapping
* New Limited-scope Role
* Unmapped
* Reject

---

## 40. Updated Canonical Semantic Role Set

Approved Research Canonical Roles:

* `InventoryTotal`
* `FinishedGoods`
* `WorkInProcess`
* `RawMaterials`
* `OtherInventories`
* `MerchandiseAndFinishedGoods`
* `RawMaterialsAndSupplies`
* `SemiFinishedProductsAndWorkInProgress`

### Limited-scope Role

`SemiFinishedProductsAndWorkInProgress`

Current Evidence Scope:

`Kioxia Holdings`

### Production Status

`NOT APPROVED`

---

## 41. Current Mapping Research State

### Standard / Cross-standard Mappings

1. `jpigp_cor:InventoriesCAIFRS → InventoryTotal`
2. `jppfs_cor:WorkInProcess → WorkInProcess`
3. `jpigp_cor:WorkInProcessCAIFRS → WorkInProcess`
4. `jpigp_cor:FinishedGoodsCAIFRS → FinishedGoods`
5. `jppfs_cor:MerchandiseAndFinishedGoods → MerchandiseAndFinishedGoods`
6. `jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS → MerchandiseAndFinishedGoods`
7. `jpigp_cor:RawMaterialsCAIFRS → RawMaterials`
8. `jppfs_cor:RawMaterialsAndSupplies → RawMaterialsAndSupplies`
9. `jpigp_cor:RawMaterialsAndSuppliesCAIFRS → RawMaterialsAndSupplies`
10. `jpigp_cor:OtherInventoriesCAIFRS → OtherInventories`

### Company Extension Mapping

11. `SemiFinishedProductsAndWorkInProgressCAIFRS → SemiFinishedProductsAndWorkInProgress`

Class:

`M3`

Scope:

`Kioxia-specific`

Status:

`APPROVED`

### Rejected Candidates

* `MerchandiseAndFinishedGoods → FinishedGoods`
* `RawMaterialsAndSupplies → RawMaterials`
* `OtherInventoriesCAIFRS → Other`
* `SemiFinishedProductsAndWorkInProgressCAIFRS → WorkInProcess`

Important:

`Approved Research Mapping ≠ Production Mapping Master Entry`

---

## 42. Exact Next Task

次のTaskは、個別Concept Mappingをさらに増やすことではない。

次に進むべきTaskは以下とする。

`Inventory Semantic Mapping Research Consolidation Review`

### Purpose

> これまでのStandard Concept、Cross-standard Concept、Combined Concept及びCompany Extension Mapping Researchを統合し、Production Mapping Architecture設計へ進めるだけのResearch Coverageが得られたかをReviewer判定する。

### Review Scope

* Approved Canonical Role Set
* Approved Mapping Set
* Rejected Mapping Set
* M1 / M3 Evidence Pattern
* Combined Concept Principle
* Company Extension Principle
* Cross-standard Pre-review Gate
* Taxonomy Version Governance
* Conflict / Overlap Governance
* Unmapped Governance
* Remaining Concept Coverage Gaps
* Production Mapping Master Readiness
* Catalog Readiness
* DDL Readiness

### Possible Decisions

* `RESEARCH SUFFICIENT → PROCEED TO MAPPING ARCHITECTURE`
* `ADDITIONAL CONCEPT RESEARCH REQUIRED`
* `ADDITIONAL COMPANY VALIDATION REQUIRED`
* `ARCHITECTURE BLOCKED`

### Current Preliminary Lean

`RESEARCH SUFFICIENT CANDIDATE`

However:

No final decision should be made until Consolidation Review is completed.
