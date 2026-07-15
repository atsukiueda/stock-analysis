# Inventory Semantic Mapping Research Consolidation Review

## 1. Document Purpose

本書は、これまで実施したEDINET Inventory Semantic Mapping Researchを統合し、Production Mapping Architecture設計へ進むために十分なResearch Coverage、Evidence Governance及びReviewer Governanceが成立しているかを判定するConsolidation Review Artifactである。

本書は個別Source ConceptのMappingを新たに承認するものではない。

目的は以下である。

> Standard Concept、Cross-standard Concept、Combined Concept及びCompany Extension Conceptに対するMapping Research結果を統合し、Canonical Semantic Role Set、Mapping Evidence Pattern、Conflict Governance、Taxonomy Version Governance及びProduction Mapping Master Readinessを評価する。

### Status

* Research Consolidation Review
* Semantic Mapping Research Phase Gate
* Pre-Catalog
* Pre-DDL
* Pre-Entity
* Pre-Production Mapping

---

## 2. Review Scope

本Reviewでは以下を対象とする。

### Research Design

`InventorySemanticMappingResearchDesign.md`

### Raw Observation Boundary

`InventoryRawObservationSemanticMappingBoundary.md`

### Cross-standard Pre-review Pattern

* WorkInProcess
* MerchandiseAndFinishedGoods
* RawMaterialsAndSupplies

### Direct Standard Mapping Cases

* `InventoriesCAIFRS`
* `WorkInProcess`
* `WorkInProcessCAIFRS`
* `FinishedGoodsCAIFRS`
* `RawMaterialsCAIFRS`
* `OtherInventoriesCAIFRS`

### Combined Standard Mapping Cases

* `MerchandiseAndFinishedGoods`
* `MerchandiseAndFinishedGoodsCAIFRS`
* `RawMaterialsAndSupplies`
* `RawMaterialsAndSuppliesCAIFRS`

### Company Extension Mapping Case

* `SemiFinishedProductsAndWorkInProgressCAIFRS`

### Initial Cross-company Validation

* ROHM
* Fuji Electric
* Sanken Electric
* Torex Semiconductor
* Kioxia Holdings
* Tokyo Electron
* Renesas Electronics

---

# 3. Initial Research Objective Review

The original Semantic Mapping Research Objective was not:

`Map all inventory concepts`

The objective was:

* Define Source Concept Identity
* Define Canonical Semantic Mapping procedure
* Validate Standard Concept Mapping
* Validate Cross-standard Mapping
* Validate Combined Concept handling
* Validate Company Extension handling
* Define Information Loss governance
* Define Double-count governance
* Define Taxonomy Version governance
* Preserve Raw Source Lineage
* Determine whether Production Mapping Architecture can be designed safely

### Objective Status

`SUBSTANTIALLY ACHIEVED`

---

# 4. Initial Cross-company Validation Status

Validated Companies:

1. ROHM
2. Fuji Electric
3. Sanken Electric
4. Torex Semiconductor
5. Kioxia Holdings
6. Tokyo Electron
7. Renesas Electronics

### Accounting Standards Covered

* Japanese GAAP
* IFRS

### Company Types Covered

* Semiconductor Device Manufacturer
* Power Semiconductor-related Manufacturer
* Semiconductor Equipment Manufacturer
* Memory Semiconductor Manufacturer

### Filing Structure Variation Covered

* Component-only inventory disclosure
* Explicit Inventory Total
* Standard Taxonomy Concepts
* IFRS Standard Concepts
* Company Extension Concept
* Consolidated and NonConsolidated context coexistence
* Different Decimals precision
* Different Taxonomy Versions

### Validation Status

`CLOSED / PASS`

---

# 5. Raw Observation Boundary Status

The following boundary has been established.

`Raw Source Fact`

must preserve:

* Source QName
* Namespace URI
* Local Name
* Taxonomy Version
* Accounting Standard
* Filing Identity
* EDINET Code
* ContextRef
* UnitRef
* Decimals
* Raw Value
* Source Label where available

### Boundary Principle

`Raw Source Identity must not be destroyed by Semantic Mapping.`

### Status

`DEFINED / PASS`

---

# 6. Canonical Semantic Mapping Boundary Status

Semantic Mapping is defined as:

`Source Concept Identity`

↓

`Canonical Semantic Role`

Semantic Mapping does not perform:

* Metric Calculation
* Investment Interpretation
* ML Feature Approval
* Cross-company Comparability Approval
* Accounting Measurement Equivalence Approval

### Boundary Principle

`Semantic Mapping ≠ Analytical Comparability`

### Status

`DEFINED / PASS`

---

# 7. Approved Research Canonical Semantic Role Set

Current Approved Research Canonical Roles:

1. `InventoryTotal`
2. `FinishedGoods`
3. `WorkInProcess`
4. `RawMaterials`
5. `OtherInventories`
6. `MerchandiseAndFinishedGoods`
7. `RawMaterialsAndSupplies`
8. `SemiFinishedProductsAndWorkInProgress`

### Scope Note

`SemiFinishedProductsAndWorkInProgress`

currently has:

`Kioxia-specific support`

It is not yet a globally reproduced Canonical Role.

### Production Status

`NOT YET APPROVED`

---

# 8. Approved Research Mapping Set

## 8.1 Inventory Total

`jpigp_cor:InventoriesCAIFRS`

↓

`InventoryTotal`

### Mapping Class

`M1`

### Status

`APPROVED`

---

## 8.2 Japanese GAAP Work In Process

`jppfs_cor:WorkInProcess`

↓

`WorkInProcess`

### Mapping Class

`M1`

### Status

`APPROVED`

---

## 8.3 IFRS Work In Process

`jpigp_cor:WorkInProcessCAIFRS`

↓

`WorkInProcess`

### Mapping Class

`M1`

### Status

`APPROVED`

---

## 8.4 IFRS Finished Goods

`jpigp_cor:FinishedGoodsCAIFRS`

↓

`FinishedGoods`

### Mapping Class

`M1`

### Status

`APPROVED`

---

## 8.5 Japanese GAAP Merchandise and Finished Goods

`jppfs_cor:MerchandiseAndFinishedGoods`

↓

`MerchandiseAndFinishedGoods`

### Mapping Class

`M1`

### Status

`APPROVED`

---

## 8.6 IFRS Merchandise and Finished Goods

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

↓

`MerchandiseAndFinishedGoods`

### Mapping Class

`M1`

### Status

`APPROVED`

---

## 8.7 IFRS Raw Materials

`jpigp_cor:RawMaterialsCAIFRS`

↓

`RawMaterials`

### Mapping Class

`M1`

### Status

`APPROVED`

---

## 8.8 Japanese GAAP Raw Materials and Supplies

`jppfs_cor:RawMaterialsAndSupplies`

↓

`RawMaterialsAndSupplies`

### Mapping Class

`M1`

### Status

`APPROVED`

---

## 8.9 IFRS Raw Materials and Supplies

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

↓

`RawMaterialsAndSupplies`

### Mapping Class

`M1`

### Status

`APPROVED`

---

## 8.10 IFRS Other Inventories

`jpigp_cor:OtherInventoriesCAIFRS`

↓

`OtherInventories`

### Mapping Class

`M1`

### Status

`APPROVED`

---

## 8.11 Kioxia Company Extension

`SemiFinishedProductsAndWorkInProgressCAIFRS`

↓

`SemiFinishedProductsAndWorkInProgress`

### Mapping Class

`M3`

`Company Extension Reviewed`

### Scope

`Kioxia-specific`

### Status

`APPROVED`

---

# 9. Rejected Mapping Set

## 9.1 Merchandise and Finished Goods to FinishedGoods

`jppfs_cor:MerchandiseAndFinishedGoods`

↓

`FinishedGoods`

### Decision

`REJECT`

### Reason

`Material Information Loss Candidate`

Removed Meaning:

`Merchandise`

---

## 9.2 Raw Materials and Supplies to RawMaterials

`jppfs_cor:RawMaterialsAndSupplies`

↓

`RawMaterials`

### Decision

`REJECT`

### Reason

`Material Information Loss Candidate`

Removed Meaning:

`Supplies`

---

## 9.3 Other Inventories to Other

`jpigp_cor:OtherInventoriesCAIFRS`

↓

`Other`

### Decision

`REJECT`

### Reason

`Semantic Under-specification`

Removed Domain:

`Inventories`

---

## 9.4 Semi-finished Products and Work In Progress to WorkInProcess

`SemiFinishedProductsAndWorkInProgressCAIFRS`

↓

`WorkInProcess`

### Decision

`REJECT`

### Reason

`Material Information Loss`

Removed Meaning:

`SemiFinishedProducts`

---

# 10. Mapping Class Validation

## M1

Definition:

`Direct Standard or Direct Meaning-preserving Mapping`

Validated Cases:

* InventoryTotal
* WorkInProcess
* FinishedGoods
* RawMaterials
* MerchandiseAndFinishedGoods
* RawMaterialsAndSupplies
* OtherInventories

### M1 Status

`VALIDATED`

---

## M2

Definition:

`Strongly Supported Semantic Mapping with Simplification`

Research Result:

The initially expected M2 cases were not automatically approved.

Examples:

* MerchandiseAndFinishedGoods → FinishedGoods
* RawMaterialsAndSupplies → RawMaterials

Both were rejected.

### M2 Finding

`M2 requires a substantially higher Information Loss burden of proof than initially assumed.`

### Status

`DEFINED BUT NO CURRENT APPROVED CASE`

This is acceptable.

A Classification does not require an approved example.

---

## M3

Definition:

`Company Extension Reviewed`

Validated Case:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

### M3 Status

`VALIDATED IN FIRST COMPANY EXTENSION CASE`

---

## M4

Definition:

`Inference Mapping Candidate`

### Current Approved Usage

`NONE`

### Production Usage

`NOT ALLOWED`

---

## M5

Definition:

`Unmapped`

### Current Major Inventory Mapping Cases

No required validated Concept remains Unmapped within the initial target set.

### Governance Status

`DEFINED`

---

# 11. Direct Standard Mapping Procedure Review

The following procedure was repeatedly successful.

1. Source Concept Identity
2. Official Label
3. Official Element Attributes
4. Filing Evidence
5. Context Eligibility
6. Information Loss
7. Adjacent Concept Boundary
8. Double-count Risk
9. Reviewer Decision

### Validated Families

* InventoryTotal
* WorkInProcess
* FinishedGoods
* RawMaterials
* OtherInventories

### Procedure Status

`REPEATEDLY VALIDATED`

---

# 12. Cross-standard Mapping Procedure Review

The following sequence was validated.

`Existing Canonical Role`

↓

`New Accounting Standard Concept`

↓

`Cross-standard Semantic Equivalence Pre-review`

↓

`Official Taxonomy Evidence Review`

↓

`Final Mapping Research Sheet`

### Validated Cases

* WorkInProcess
* MerchandiseAndFinishedGoods
* RawMaterialsAndSupplies

### Procedure Status

`REPEATEDLY VALIDATED`

### Current Decision

`RETAIN`

---

# 13. Combined Concept Procedure Review

Combined Concepts created the most important Semantic Mapping Architecture finding.

Validated Families:

1. `MerchandiseAndFinishedGoods`
2. `RawMaterialsAndSupplies`

### Observed Pattern

`Combined Source Concept`

↓

`Narrow Existing Canonical Role Candidate`

↓

`Material Information Loss`

↓

`Narrow Mapping Rejected`

↓

`Meaning-preserving Combined Canonical Role`

### Procedure Status

`REPEATEDLY VALIDATED`

---

# 14. Combined Source Concept Principle

Research Principle:

`Combined Source Concept → Atomic Canonical Observation`

unless:

`Source-supported decomposition exists`

### Validated Cases

* MerchandiseAndFinishedGoods
* RawMaterialsAndSupplies
* SemiFinishedProductsAndWorkInProgress

### Unsupported Action

Synthetic decomposition based on:

* Assumed ratio
* Industry intuition
* Naming convenience
* ML feature simplicity

is prohibited.

### Principle Status

`STRONGLY SUPPORTED`

---

# 15. Company Extension Procedure Review

The Company Extension Research Procedure was applied to:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

### Required Steps Successfully Applied

* Extension Namespace Confirmation
* Exact Filing Identity
* Raw Fact Review
* Filing Note Cross-reference
* Exact Value Match
* Component Sum Reconciliation
* Standard Concept Boundary Review
* Information Loss Review
* Company-specific Scope Review
* Architecture Reviewer Gate

### Result

`PASS`

### Procedure Status

`VALIDATED IN FIRST COMPANY EXTENSION CASE`

### Current Decision

`RETAIN FULL PROCEDURE`

No shortened Company Extension procedure is approved.

---

# 16. Information Loss Governance Review

The Information Loss Gate materially changed Mapping decisions.

Examples:

### Case A

`MerchandiseAndFinishedGoods → FinishedGoods`

Rejected.

### Case B

`RawMaterialsAndSupplies → RawMaterials`

Rejected.

### Case C

`SemiFinishedProductsAndWorkInProgress → WorkInProcess`

Rejected.

### Case D

`OtherInventories → Other`

Rejected.

### Research Finding

Without explicit Information Loss Review, all four cases could plausibly have been incorrectly normalized into narrower or under-specified roles.

### Status

`CRITICAL CONTROL / VALIDATED`

---

# 17. Canonical Role Precision Governance

The `Other` case established:

`Canonical Semantic Role names must remain sufficiently self-describing.`

### Rejected

`Other`

### Approved

`OtherInventories`

### Reason

Generic Canonical Role names create:

* Domain ambiguity
* Catalog ambiguity
* Metric naming ambiguity
* Feature collision risk
* Advisor explanation ambiguity

### Principle Status

`SUPPORTED`

---

# 18. Semantic Mapping vs Analytical Grouping

Research repeatedly established:

`Canonical Semantic Mapping`

is not:

`Analytical Grouping`

Examples:

`FinishedGoods`

and:

`MerchandiseAndFinishedGoods`

may later belong to a broader analytical group.

Likewise:

`RawMaterials`

and:

`RawMaterialsAndSupplies`

may later belong to a broader analytical group.

However:

They remain distinct Semantic Roles.

### Status

`BOUNDARY DEFINED`

---

# 19. Semantic Equivalence vs Metric Comparability

A Source Concept may be semantically normalized across Accounting Standards while Metric Comparability remains unproven.

Examples:

* J-GAAP WorkInProcess
* IFRS WorkInProcess

Shared Canonical Role:

`WorkInProcess`

But:

`WorkInProcessGrowthYoY`

may still require controls for:

* Accounting Standard
* Company
* SubSector
* Business Model
* Accounting Policy

### Principle

`Semantic Equivalence ≠ Metric Comparability`

### Status

`CRITICAL BOUNDARY / DEFINED`

---

# 20. Semantic Equivalence vs Composition Equivalence

Combined roles may have the same Semantic Role while internal composition differs.

Examples:

`RawMaterialsAndSupplies`

Company A may be mostly Raw Materials.

Company B may contain a larger Supplies share.

Likewise:

`MerchandiseAndFinishedGoods`

may contain different Merchandise / Finished Goods proportions.

### Principle

`Semantic Equivalence ≠ Composition Equivalence`

### Status

`DEFINED`

---

# 21. Accounting Standard Boundary

Accounting Standard is not embedded into Canonical Role names.

Rejected Candidate Examples:

* `IFRSWorkInProcess`
* `IFRSRawMaterials`
* `IFRSMerchandiseAndFinishedGoods`

### Architecture Principle

Accounting Standard belongs in:

* Source Lineage
* Observation Context
* Dataset Comparability Control

not necessarily in:

* Canonical Semantic Role Name

### Status

`SUPPORTED`

---

# 22. Taxonomy Version Governance Review

Observed Taxonomy Versions include:

* `2024-11-01`
* `2025-11-01`

### Established Rule

Same Local Name across versions does not automatically guarantee identical meaning.

Review should consider:

* Label
* Element Attributes
* Financial Statement Position
* Filing Usage
* Official Difference Information

### Current Research Finding

No material reviewed meaning difference was identified in the mapped concepts across the reviewed versions.

### Governance Status

`DEFINED`

---

# 23. Context and Consolidation Governance

The same QName may appear under:

* Consolidated Context
* NonConsolidated Member Context

Examples were observed in Japanese GAAP filings.

### Principle

`Semantic Mapping`

does not determine:

`Fact Eligibility`

### Fact Eligibility must separately evaluate:

* ContextRef
* Dimension
* Consolidation Scope
* Period
* Unit

### Status

`VALIDATED`

---

# 24. Unit and Decimals Governance

Observed Decimals included:

* `-3`
* `-6`

### Finding

Decimals variation does not determine Semantic Role.

However:

Decimals must remain preserved for:

* Source Precision
* Reconciliation
* Auditability

### Unit Rule

Semantic Mapping does not replace Unit Validation.

### Status

`DEFINED`

---

# 25. InventoryTotal and Component Boundary

InventoryTotal is a separate Semantic Role from Inventory Components.

Incorrect:

`InventoryTotal + Components`

used to calculate a total.

### Correct Boundary

`InventoryTotal`

may be:

`Primary Total Source Fact`

while components support:

* Composition
* Reconciliation
* Derived Metrics

### Status

`DEFINED`

---

# 26. Overlap and Double-count Governance

The following patterns require Conflict Review.

### Pattern A

Narrow Concept + Combined Concept

Example:

* `RawMaterialsCAIFRS`
* `RawMaterialsAndSuppliesCAIFRS`

### Pattern B

Finished Goods + Combined Merchandise and Finished Goods

### Pattern C

WorkInProcess + SemiFinishedProductsAndWorkInProgress

### Pattern D

Multiple Facts mapped to the same Canonical Role within:

* Same Filing
* Same Period
* Same Scope

### Core Rule

`Same Canonical Role ≠ Automatic Sum`

### Status

`DEFINED`

---

# 27. Unmapped Governance Review

Unmapped remains a valid outcome.

### Unmapped is appropriate when:

* Meaning is ambiguous
* Evidence is insufficient
* Conflicting Evidence remains unresolved
* No Canonical Role is appropriate
* New Role addition is not justified

### Current Initial Inventory Set

No critical validated Source Concept remains forced into Unmapped status.

### Status

`DEFINED / NOT CURRENTLY BLOCKING`

---

# 28. Evidence Coverage Review

The Research now includes:

### Multiple Companies

`7`

### Multiple Accounting Standards

`2`

### Multiple Taxonomy Families

* `jppfs`
* `jpigp`
* Company Extension Namespace

### Multiple Concept Types

* Total
* Direct Component
* Combined Component
* Residual Component
* Company Extension

### Multiple Review Patterns

* M1
* M3
* Rejected M2
* Architecture Role Addition
* Architecture Role Replacement
* Limited-scope Role

### Coverage Result

`BROAD ENOUGH FOR INITIAL PRODUCTION MAPPING ARCHITECTURE DESIGN`

---

# 29. Remaining Coverage Gaps

The Research is not exhaustive.

Known Gaps include:

* More Company Extension patterns
* Additional IFRS filers
* Additional non-semiconductor industries
* Non-current inventory concepts
* Alternative inventory note structures
* Additional taxonomy versions
* Correction / amended filings
* Duplicate candidate resolution in Production
* Missing total / partial component cases
* Unit conversion cases
* Filing restatement handling

### Important

These gaps do not block initial Production Mapping Architecture design.

They must remain:

`Known Extension Risks`

---

# 30. Research Sufficiency Test

## Question 1

Has Source Identity been defined?

`YES`

## Question 2

Has Direct Standard Mapping been validated?

`YES`

## Question 3

Has Cross-standard Mapping been validated?

`YES`

## Question 4

Has Combined Concept handling been validated?

`YES`

## Question 5

Has Company Extension handling been validated?

`YES`

## Question 6

Has Information Loss governance changed actual decisions?

`YES`

## Question 7

Has Conflict / Double-count governance been defined?

`YES`

## Question 8

Has Taxonomy Version governance been defined?

`YES`

## Question 9

Has Unmapped governance been defined?

`YES`

## Question 10

Are remaining gaps known and non-blocking?

`YES`

### Result

`RESEARCH SUFFICIENCY TEST = PASS`

---

# 31. Research Reviewer Decision

### Decision

`RESEARCH SUFFICIENT`

### Approved Next Phase

`PROCEED TO PRODUCTION MAPPING ARCHITECTURE DESIGN`

### Not Yet Approved

* Production DDL
* Production Entity
* Production Runtime Mapping
* Production ML Features
* Production Derived Metrics

### Required Sequence

`Research Consolidation Review`

↓

`Production Mapping Architecture Design`

↓

`Architecture Review`

↓

`Catalog Design`

↓

`DDL`

↓

`Entity`

↓

`Mapping Implementation`

↓

`Validation`

---

# 32. Architecture Reviewer Decision

### Research Coverage

`SUFFICIENT`

### Architecture Boundary

`STABLE ENOUGH FOR INITIAL DESIGN`

### Canonical Role Set

`SUFFICIENT FOR INITIAL ARCHITECTURE`

### Mapping Procedure

`VALIDATED`

### Conflict Governance

`DEFINED`

### Lineage Requirement

`DEFINED`

### Decision

`APPROVE TRANSITION TO PRODUCTION MAPPING ARCHITECTURE DESIGN`

---

# 33. Current Project Phase Transition

Previous Phase:

`Semantic Mapping Research`

Current Status:

`COMPLETED FOR INITIAL PRODUCTION ARCHITECTURE ENTRY`

Next Phase:

`Production Mapping Architecture Design`

Important:

This does not mean Research is permanently closed.

New Source Concepts may reopen:

* Concept Research
* Mapping Review
* Architecture Review

### Phase Model

`Research-first`

remains active.

---

# 34. Production Mapping Architecture Design Objectives

The next phase must design how approved Research Mapping becomes a governed Production capability.

Required Architecture Topics:

1. Source Concept Identity Model
2. Canonical Semantic Role Model
3. Mapping Rule Model
4. Mapping Scope Model
5. Taxonomy Version Scope
6. Company-specific Scope
7. Mapping Confidence
8. Reviewer Status
9. Mapping Version
10. Effective Date / Version Boundary
11. Source Lineage
12. Conflict Detection
13. Duplicate / Overlap Handling
14. Unmapped Queue
15. Mapping Change Impact
16. Historical Reprocessing
17. Auditability
18. Production Validation

---

# 35. Production Mapping Master Requirements

The future Mapping Master must be able to represent at minimum:

### Standard Mapping

Example:

`jpigp_cor:RawMaterialsCAIFRS → RawMaterials`

### Cross-standard Mapping

Different Source Concepts mapping to the same Canonical Role.

### Combined Concept Mapping

Example:

`RawMaterialsAndSupplies`

### Company Extension Mapping

Example:

`SemiFinishedProductsAndWorkInProgress`

### Limited-scope Mapping

Example:

`Kioxia-specific`

### Rejected Mapping

A rejected Candidate should remain traceable where useful for governance.

### Unmapped Concept

Must remain discoverable.

---

# 36. Minimum Mapping Record Candidate

The next Architecture phase should evaluate a Mapping Record capable of representing:

* Mapping ID
* Source Namespace URI
* Source Local Name
* Source QName
* Taxonomy Family
* Taxonomy Version Scope
* Accounting Standard
* Company Scope
* EDINET Code Scope
* Filing Family Scope
* Canonical Semantic Role
* Mapping Class
* Mapping Confidence
* Mapping Status
* Reviewer Decision
* Evidence Reference
* Effective From
* Effective To
* Mapping Version
* Created At
* Reviewed At

Important:

This is an Architecture Candidate.

It is not DDL.

---

# 37. Canonical Semantic Role Master Candidate

The next Architecture phase should evaluate a Canonical Semantic Role definition capable of representing:

* Role Code
* Role Name
* Domain
* Description
* Role Type
* Total / Component Classification
* Combined Concept Flag
* Limited-scope Flag
* Status
* Version

Potential Role Type Candidates:

* `Total`
* `Component`
* `CombinedComponent`
* `ResidualComponent`

Important:

This is an Architecture Candidate.

Not DDL.

---

# 38. Mapping Scope Requirement

Production Mapping must not assume all mappings are global.

Required Scope Types may include:

* Global Standard Concept
* Taxonomy-family Scope
* Taxonomy-version Scope
* Accounting-standard Scope
* Company Scope
* EDINET-code Scope
* Filing-family Scope

### Example

`SemiFinishedProductsAndWorkInProgress`

requires limited scope.

Therefore:

`Mapping Scope`

is a first-class Architecture concern.

---

# 39. Conflict Resolution Requirement

Production Architecture must define deterministic handling for:

* Multiple eligible Source Facts
* Multiple mappings to same Canonical Role
* Narrow + Combined Concept overlap
* Total + Component coexistence
* Standard + Extension Concept coexistence
* Conflicting Mapping Versions

### Important

Conflict resolution must not be hidden inside arbitrary code ordering.

It requires explicit:

* Detection
* Classification
* Resolution status
* Audit trail

---

# 40. Mapping Version Requirement

Mapping decisions may change.

Examples:

* New Taxonomy Version
* New Filing Evidence
* New Cross-company Evidence
* Canonical Role split
* Canonical Role merge
* Scope change

Therefore:

`Mapping Version`

must be first-class.

Historical observations must remain traceable to:

`Mapping Version Used`

---

# 41. Reprocessing Requirement

A Mapping change may affect:

* Historical Canonical Observations
* Derived Metrics
* ML Datasets
* Backtests
* Advisor explanations

Therefore future Architecture must support:

`Impact Identification`

and potentially:

`Controlled Reprocessing`

Mapping changes must not silently rewrite historical interpretation without lineage.

---

# 42. Research Artifact Governance

Research Artifacts remain the Evidence source for Production Mapping decisions.

Production Mapping Master must not become the sole source of truth for why a Mapping exists.

Required Relationship:

`Production Mapping Record`

↓

`Evidence Reference`

↓

`Research Artifact`

### Principle

`Production Configuration must remain auditable back to Research Evidence.`

---

# 43. Final Consolidation Decision

### Initial 7-company Inventory Validation

`PASS`

### Raw Observation Boundary

`PASS`

### Semantic Mapping Research Design

`PASS`

### Standard Mapping Procedure

`PASS`

### Cross-standard Mapping Procedure

`PASS`

### Combined Concept Procedure

`PASS`

### Company Extension Procedure

`PASS`

### Information Loss Governance

`PASS`

### Conflict Governance

`PASS`

### Taxonomy Version Governance

`PASS`

### Research Coverage

`SUFFICIENT`

### Final Decision

`PROCEED TO PRODUCTION MAPPING ARCHITECTURE DESIGN`

---

# 44. Exact Next Task

Next Artifact:

`InventorySemanticMappingProductionArchitecture.md`

### Purpose

> Research-approved Semantic Mapping decisionsをProduction Systemへ安全に持ち込むため、Mapping Master、Canonical Role Master、Scope、Version、Evidence Lineage、Conflict Handling及びReprocessing Boundaryを設計する。

### Required Sections

1. Architecture Purpose
2. Research Inputs
3. Production Boundary
4. Source Concept Identity
5. Canonical Semantic Role Model
6. Mapping Rule Model
7. Mapping Scope Model
8. Mapping Status Lifecycle
9. Mapping Confidence
10. Mapping Versioning
11. Evidence Lineage
12. Conflict Detection
13. Conflict Resolution
14. Unmapped Queue
15. Historical Reprocessing
16. Auditability
17. Runtime Mapping Flow
18. Failure Handling
19. Catalog Boundary
20. DDL Boundary
21. Reviewer Gate
22. Definition of Done

### Current Phase

`Production Mapping Architecture Design`

### Important

Do not create DDL yet.

Do not create Entity yet.

Do not implement Runtime Mapping yet.

First:

`Architecture Design`

↓

`Architecture Review`

only after Approval:

`Catalog`

↓

`DDL`

↓

`Entity`

↓

`Implementation`
