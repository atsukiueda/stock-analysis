# Inventory Semantic Mapping Catalog

## 1. Catalog Purpose

本書は、`InventorySemanticMappingProductionArchitecture.md` で承認されたProduction Mapping Architectureを、DDL及びEntity設計前の論理Catalogとして定義する。

本Catalogの目的は以下である。

> Inventory Semantic Mappingに必要なCanonical Semantic Role、Mapping Class、Mapping Status、Source Type、Scope Type、Conflict Type、初期Approved Mapping、Rejected Mapping Decision及びEvidence Referenceを、実装技術から独立した論理定義として固定する。

本書は以下を定義しない。

* SQL Data Type
* Primary Key
* Foreign Key
* Index
* EF Core Entity
* Runtime Service
* API
* UI
* Physical Table Nameの最終確定

### Status

* Logical Catalog
* Architecture Approved Input
* Pre-DDL
* Pre-Entity
* Pre-Implementation
* Catalog Reviewer Pending

---

# 2. Catalog Design Principles

本Catalogは以下の原則に従う。

## 2.1 Research First

Catalog EntryはResearch Evidenceなしに追加しない。

Required Flow:

`Research`

↓

`Reviewer Decision`

↓

`Architecture Review if required`

↓

`Catalog Registration`

---

## 2.2 Logical Before Physical

Catalogは、

`What must exist`

を定義する。

DDLは、

`How it is physically stored`

を定義する。

Therefore:

Catalogでは以下を決めない。

* `nvarchar(100)`
* `bigint`
* `uniqueidentifier`
* clustered index
* EF navigation property

---

## 2.3 Source Identity Preservation

Mapping CatalogはSource Concept IdentityをCanonical Roleへ置換しない。

Source IdentityとCanonical Meaningは別々に保持する。

---

## 2.4 Explicit Governance

以下を暗黙化しない。

* Mapping Class
* Mapping Status
* Mapping Scope
* Mapping Version
* Reviewer Status
* Evidence
* Rejected Decision
* Conflict Type

---

## 2.5 Unmapped Is Valid

Catalogに存在しないSource Conceptは、Runtime上で強制Mappingしない。

Expected Result:

`Unmapped`

---

# 3. Catalog Structure Overview

本Catalogは以下の論理Catalog群から構成する。

1. Canonical Semantic Role Catalog
2. Mapping Class Catalog
3. Mapping Status Catalog
4. Source Type Catalog
5. Scope Type Catalog
6. Conflict Type Catalog
7. Reviewer Decision Catalog
8. Initial Approved Mapping Catalog
9. Rejected Mapping Decision Catalog
10. Evidence Reference Catalog
11. Mapping Version Governance Catalog
12. Runtime Result State Catalog

---

# 4. Canonical Semantic Role Catalog

Canonical Semantic Roleは、Source Taxonomy Conceptとは独立した正規化Financial Meaningを表す。

## 4.1 Catalog Fields Candidate

論理上、各Roleは最低限以下を持つ。

* Role Code
* Role Name
* Domain
* Description
* Role Type
* Combined Concept Flag
* Residual Concept Flag
* Limited Scope Flag
* Status
* Role Version
* Research Evidence Reference

---

# 5. Canonical Semantic Role

## InventoryTotal

### Role Code

`InventoryTotal`

### Role Name

`Inventory Total`

### Domain

`Inventory`

### Role Type

`Total`

### Description

`Total inventory balance reported for the applicable financial statement scope.`

### Combined Concept Flag

`false`

### Residual Concept Flag

`false`

### Limited Scope Flag

`false`

### Research Status

`APPROVED`

### Production Status

`NOT YET ACTIVE`

---

# 6. Canonical Semantic Role

## FinishedGoods

### Role Code

`FinishedGoods`

### Role Name

`Finished Goods`

### Domain

`Inventory`

### Role Type

`Component`

### Description

`Inventory consisting of completed goods or products represented by a direct Finished Goods source concept.`

### Combined Concept Flag

`false`

### Residual Concept Flag

`false`

### Limited Scope Flag

`false`

### Research Status

`APPROVED`

### Production Status

`NOT YET ACTIVE`

---

# 7. Canonical Semantic Role

## WorkInProcess

### Role Code

`WorkInProcess`

### Role Name

`Work In Process`

### Domain

`Inventory`

### Role Type

`Component`

### Description

`Inventory representing goods or production output currently in the production process.`

### Combined Concept Flag

`false`

### Residual Concept Flag

`false`

### Limited Scope Flag

`false`

### Research Status

`APPROVED`

### Production Status

`NOT YET ACTIVE`

---

# 8. Canonical Semantic Role

## RawMaterials

### Role Code

`RawMaterials`

### Role Name

`Raw Materials`

### Domain

`Inventory`

### Role Type

`Component`

### Description

`Inventory represented by a direct Raw Materials source concept.`

### Combined Concept Flag

`false`

### Residual Concept Flag

`false`

### Limited Scope Flag

`false`

### Research Status

`APPROVED`

### Production Status

`NOT YET ACTIVE`

---

# 9. Canonical Semantic Role

## OtherInventories

### Role Code

`OtherInventories`

### Role Name

`Other Inventories`

### Domain

`Inventory`

### Role Type

`ResidualComponent`

### Description

`Residual or other inventory balance that is explicitly represented as Other Inventories within the inventory domain.`

### Combined Concept Flag

`false`

### Residual Concept Flag

`true`

### Limited Scope Flag

`false`

### Research Status

`APPROVED`

### Production Status

`NOT YET ACTIVE`

### Important

The generic Role:

`Other`

is not approved.

Reason:

`Semantic Under-specification`

---

# 10. Canonical Semantic Role

## MerchandiseAndFinishedGoods

### Role Code

`MerchandiseAndFinishedGoods`

### Role Name

`Merchandise And Finished Goods`

### Domain

`Inventory`

### Role Type

`CombinedComponent`

### Description

`Combined inventory component containing merchandise and finished goods where the source does not provide a supported decomposition.`

### Combined Concept Flag

`true`

### Residual Concept Flag

`false`

### Limited Scope Flag

`false`

### Research Status

`APPROVED`

### Production Status

`NOT YET ACTIVE`

### Atomic Treatment

`REQUIRED`

---

# 11. Canonical Semantic Role

## RawMaterialsAndSupplies

### Role Code

`RawMaterialsAndSupplies`

### Role Name

`Raw Materials And Supplies`

### Domain

`Inventory`

### Role Type

`CombinedComponent`

### Description

`Combined inventory component containing raw materials and supplies where the source does not provide a supported decomposition.`

### Combined Concept Flag

`true`

### Residual Concept Flag

`false`

### Limited Scope Flag

`false`

### Research Status

`APPROVED`

### Production Status

`NOT YET ACTIVE`

### Atomic Treatment

`REQUIRED`

---

# 12. Canonical Semantic Role

## SemiFinishedProductsAndWorkInProgress

### Role Code

`SemiFinishedProductsAndWorkInProgress`

### Role Name

`Semi-finished Products And Work In Progress`

### Domain

`Inventory`

### Role Type

`CombinedComponent`

### Description

`Combined inventory component containing semi-finished products and work in progress.`

### Combined Concept Flag

`true`

### Residual Concept Flag

`false`

### Limited Scope Flag

`true`

### Current Research Scope

`Kioxia Holdings`

### Research Status

`APPROVED WITH LIMITED SCOPE`

### Production Status

`NOT YET ACTIVE`

### Atomic Treatment

`REQUIRED`

---

# 13. Canonical Role Type Catalog

## Total

### Code

`Total`

### Meaning

Represents the complete balance for the Domain.

Example:

`InventoryTotal`

---

## Component

### Code

`Component`

### Meaning

Represents a direct non-combined component within the Domain.

Examples:

* `FinishedGoods`
* `WorkInProcess`
* `RawMaterials`

---

## CombinedComponent

### Code

`CombinedComponent`

### Meaning

Represents a Source-supported combination of multiple semantic inventory components that must remain atomic unless Source-supported decomposition exists.

Examples:

* `MerchandiseAndFinishedGoods`
* `RawMaterialsAndSupplies`
* `SemiFinishedProductsAndWorkInProgress`

---

## ResidualComponent

### Code

`ResidualComponent`

### Meaning

Represents a residual or other component within a defined Domain.

Example:

`OtherInventories`

---

# 14. Mapping Class Catalog

## M1

### Code

`M1`

### Name

`Direct Meaning-preserving Mapping`

### Definition

A Mapping where:

* Source Concept meaning is clear
* Canonical Role directly preserves the Source meaning
* No material semantic simplification is required
* Evidence is sufficient for direct Mapping

### Typical Sources

* Standard Taxonomy Concept
* Cross-standard directly equivalent Concept

### Production Eligibility Candidate

`Eligible after full approval lifecycle`

---

## M2

### Code

`M2`

### Name

`Strongly Supported Semantic Mapping With Simplification`

### Definition

A Mapping where Source and Canonical meanings are not identical, but strong evidence supports a controlled simplification.

### Current Approved Cases

`NONE`

### Governance

Requires explicit:

* Information Loss Review
* Analytical Impact Review
* Independent Reviewer Approval

### Production Eligibility Candidate

`Exception only`

---

## M3

### Code

`M3`

### Name

`Company Extension Reviewed`

### Definition

A Mapping for a Company Extension Concept that has been individually reviewed against exact Filing Evidence.

### Typical Scope

* Company
* EDINET Code
* Extension Namespace
* Filing Family

### Production Eligibility Candidate

`Scope-limited only`

---

## M4

### Code

`M4`

### Name

`Inference Mapping Candidate`

### Definition

A non-approved Mapping hypothesis based on inference.

### Production Eligibility

`NOT ALLOWED`

---

## M5

### Code

`M5`

### Name

`Unmapped`

### Definition

No approved Canonical Semantic Mapping exists.

### Runtime Meaning

The Source Fact remains available as a Raw Fact but does not produce an approved Canonical Observation.

---

# 15. Mapping Status Catalog

## Draft

Mapping exists as an initial proposal.

Runtime Eligible:

`NO`

---

## ResearchApproved

Research Reviewer approved the Mapping.

Runtime Eligible:

`NO`

---

## ArchitectureApproved

Architecture impact review has passed where required.

Runtime Eligible:

`NO`

---

## CatalogApproved

Mapping has been registered and reviewed in the logical Catalog.

Runtime Eligible:

`NO`

---

## ProductionApproved

Production activation has been approved.

Runtime Eligible:

`NO`

Reason:

Activation remains a separate state.

---

## Active

Mapping may be used by Production Runtime.

Runtime Eligible:

`YES`

---

## Rejected

Mapping Candidate was explicitly rejected.

Runtime Eligible:

`NO`

---

## Suspended

Previously approved Mapping temporarily disabled.

Runtime Eligible:

`NO`

---

## Deprecated

Mapping should not be used for new processing.

Runtime Eligible:

`NO`

---

## Superseded

A newer Mapping Version replaces the Mapping.

Runtime Eligible:

`NO`

---

## Expired

Mapping fell outside its effective boundary.

Runtime Eligible:

`NO`

---

# 16. Source Type Catalog

## StandardTaxonomy

### Definition

Concept defined in an official standard taxonomy family.

Examples:

* `jppfs_cor`
* `jpigp_cor`

---

## CompanyExtension

### Definition

Concept defined in a filer-specific extension namespace.

Example:

Kioxia:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

---

## OtherExtension

### Definition

Non-standard extension Concept not yet classified as a Company Extension.

---

## Unknown

### Definition

Source Concept type has not yet been determined.

### Runtime Handling

`Review Required`

---

# 17. Scope Type Catalog

Mapping Scope may use one or more scope dimensions.

## Global

### Meaning

Mapping applies globally to the exact approved Source Concept Identity subject to version and status controls.

---

## TaxonomyFamily

### Meaning

Mapping is limited to a Taxonomy Family.

Examples:

* `jppfs`
* `jpigp`

---

## TaxonomyVersion

### Meaning

Mapping is limited to an exact or approved Taxonomy Version boundary.

---

## AccountingStandard

### Meaning

Mapping is limited to a defined Accounting Standard.

Examples:

* Japanese GAAP
* IFRS

---

## Company

### Meaning

Mapping is limited to a specific company.

---

## EdinetCode

### Meaning

Mapping is limited to a specific EDINET Code.

---

## FilingFamily

### Meaning

Mapping is limited to a specific recurring filing structure or filing family.

---

## Namespace

### Meaning

Mapping is limited to an exact Namespace URI or Namespace family.

---

# 18. Scope Combination Principle

One Mapping may require multiple Scope conditions.

Example:

`M3 Kioxia Company Extension Mapping`

may require:

* Company = Kioxia
* EDINET Code = E35948
* Extension Namespace match
* Accounting Standard = IFRS

### Principle

`Mapping Scope is compositional.`

Do not reduce a multi-condition Mapping to one broad flag.

---

# 19. Scope Specificity Catalog

Candidate precedence order:

1. Exact Company + Exact Namespace + Exact Version
2. Exact EDINET Code + Exact Namespace
3. Exact Source Concept + Exact Version
4. Exact Source Concept + Approved Version Range
5. Approved Global Standard Mapping

### Important

Scope specificity determines candidate ranking.

It does not automatically resolve semantic conflict.

---

# 20. Conflict Type Catalog

## MultipleMappingConflict

Multiple active Mapping Records apply to one Source Concept Fact.

---

## SameRoleDuplicateConflict

Multiple Source Facts produce the same Canonical Role for the same:

* Filing
* Period
* Scope

---

## NarrowCombinedOverlapConflict

A narrow Concept and a Combined Concept may overlap.

Examples:

* `RawMaterials`
* `RawMaterialsAndSupplies`

---

## TotalComponentConflict

Total and Component Facts are incorrectly used together in a way that creates double counting.

---

## StandardExtensionOverlapConflict

Standard Taxonomy and Company Extension Concepts may overlap semantically.

---

## VersionConflict

Multiple incompatible Mapping Versions are eligible.

---

## ScopeConflict

Multiple mappings with incompatible scope rules match the same Source Fact.

---

## EligibilityConflict

Source Mapping exists but Fact eligibility evidence is inconsistent.

---

# 21. Conflict Severity Candidate

Conflict Severity may later be represented as:

* Warning
* Blocking
* Critical

### Initial Recommendation

All unresolved semantic Mapping conflicts should be:

`Blocking for Canonical Observation creation`

while:

`Raw Fact ingestion continues`

---

# 22. Runtime Result State Catalog

## Mapped

One valid active Mapping and one eligible Fact produce a Canonical Observation.

---

## Unmapped

No active Mapping applies.

---

## Conflict

Mapping or overlap conflict prevents Canonical Observation creation.

---

## Ineligible

Source Concept may be mapped, but the specific Fact fails eligibility.

---

## Error

Technical processing failure.

---

# 23. Reviewer Decision Catalog

## Approve

Mapping or Catalog entry is approved.

---

## ConditionalApprove

Approval is subject to explicit conditions.

---

## Reject

Candidate is rejected.

---

## Defer

Insufficient Evidence or unresolved dependency.

---

# 24. Evidence Reference Type Catalog

## ResearchSheet

Detailed Mapping Research Artifact.

---

## CrossStandardEvidence

Official cross-standard Taxonomy comparison Artifact.

---

## ConsolidationReview

Research phase consolidation decision.

---

## ArchitectureArtifact

Approved Architecture evidence.

---

## PrimarySourceReference

Direct external or filing Primary Source reference.

---

# 25. Evidence Relationship Principle

One Mapping may reference multiple Evidence Artifacts.

Logical relationship:

`Mapping`

`1`

to:

`many Evidence References`

Example:

`WorkInProcessCAIFRS → WorkInProcess`

may reference:

* IFRS Mapping Research Sheet
* Cross-standard Official Taxonomy Evidence
* J-GAAP WorkInProcess Mapping Research

---

# 26. Initial Approved Mapping Catalog

The following Mapping entries are approved at Research / Architecture level for future Production Catalog registration.

They are not yet Runtime Active.

---

## MAP-INV-001

### Source Concept

`jpigp_cor:InventoriesCAIFRS`

### Canonical Role

`InventoryTotal`

### Mapping Class

`M1`

### Source Type

`StandardTaxonomy`

### Accounting Standard

`IFRS`

### Current Catalog Status

`ArchitectureApproved`

### Production Runtime Status

`NOT ACTIVE`

---

## MAP-INV-002

### Source Concept

`jppfs_cor:WorkInProcess`

### Canonical Role

`WorkInProcess`

### Mapping Class

`M1`

### Source Type

`StandardTaxonomy`

### Accounting Standard

`Japanese GAAP`

### Current Catalog Status

`ArchitectureApproved`

### Production Runtime Status

`NOT ACTIVE`

---

## MAP-INV-003

### Source Concept

`jpigp_cor:WorkInProcessCAIFRS`

### Canonical Role

`WorkInProcess`

### Mapping Class

`M1`

### Source Type

`StandardTaxonomy`

### Accounting Standard

`IFRS`

### Current Catalog Status

`ArchitectureApproved`

### Production Runtime Status

`NOT ACTIVE`

---

## MAP-INV-004

### Source Concept

`jpigp_cor:FinishedGoodsCAIFRS`

### Canonical Role

`FinishedGoods`

### Mapping Class

`M1`

### Source Type

`StandardTaxonomy`

### Accounting Standard

`IFRS`

### Current Catalog Status

`ArchitectureApproved`

### Production Runtime Status

`NOT ACTIVE`

---

## MAP-INV-005

### Source Concept

`jppfs_cor:MerchandiseAndFinishedGoods`

### Canonical Role

`MerchandiseAndFinishedGoods`

### Mapping Class

`M1`

### Source Type

`StandardTaxonomy`

### Accounting Standard

`Japanese GAAP`

### Combined Concept

`YES`

### Atomic Treatment

`REQUIRED`

### Current Catalog Status

`ArchitectureApproved`

### Production Runtime Status

`NOT ACTIVE`

---

## MAP-INV-006

### Source Concept

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

### Canonical Role

`MerchandiseAndFinishedGoods`

### Mapping Class

`M1`

### Source Type

`StandardTaxonomy`

### Accounting Standard

`IFRS`

### Combined Concept

`YES`

### Atomic Treatment

`REQUIRED`

### Current Catalog Status

`ArchitectureApproved`

### Production Runtime Status

`NOT ACTIVE`

---

## MAP-INV-007

### Source Concept

`jpigp_cor:RawMaterialsCAIFRS`

### Canonical Role

`RawMaterials`

### Mapping Class

`M1`

### Source Type

`StandardTaxonomy`

### Accounting Standard

`IFRS`

### Current Catalog Status

`ArchitectureApproved`

### Production Runtime Status

`NOT ACTIVE`

---

## MAP-INV-008

### Source Concept

`jppfs_cor:RawMaterialsAndSupplies`

### Canonical Role

`RawMaterialsAndSupplies`

### Mapping Class

`M1`

### Source Type

`StandardTaxonomy`

### Accounting Standard

`Japanese GAAP`

### Combined Concept

`YES`

### Atomic Treatment

`REQUIRED`

### Current Catalog Status

`ArchitectureApproved`

### Production Runtime Status

`NOT ACTIVE`

---

## MAP-INV-009

### Source Concept

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

### Canonical Role

`RawMaterialsAndSupplies`

### Mapping Class

`M1`

### Source Type

`StandardTaxonomy`

### Accounting Standard

`IFRS`

### Combined Concept

`YES`

### Atomic Treatment

`REQUIRED`

### Current Catalog Status

`ArchitectureApproved`

### Production Runtime Status

`NOT ACTIVE`

---

## MAP-INV-010

### Source Concept

`jpigp_cor:OtherInventoriesCAIFRS`

### Canonical Role

`OtherInventories`

### Mapping Class

`M1`

### Source Type

`StandardTaxonomy`

### Accounting Standard

`IFRS`

### Residual Concept

`YES`

### Current Catalog Status

`ArchitectureApproved`

### Production Runtime Status

`NOT ACTIVE`

---

## MAP-INV-011

### Source Concept

`SemiFinishedProductsAndWorkInProgressCAIFRS`

### Source Identity Type

`Company Extension`

### Canonical Role

`SemiFinishedProductsAndWorkInProgress`

### Mapping Class

`M3`

### Source Type

`CompanyExtension`

### Accounting Standard

`IFRS`

### Company Scope

`Kioxia Holdings Corporation`

### EDINET Code Scope

`E35948`

### Combined Concept

`YES`

### Atomic Treatment

`REQUIRED`

### Limited Scope

`YES`

### Current Catalog Status

`ArchitectureApproved`

### Production Runtime Status

`NOT ACTIVE`

---

# 27. Mapping Catalog Completeness Note

The initial Mapping Catalog does not claim exhaustive Inventory Concept coverage.

It represents:

`Research-approved initial Mapping coverage`

Unknown Concepts remain:

`Unmapped`

until reviewed.

---

# 28. Rejected Mapping Decision Catalog

Rejected Mapping Decisions must remain discoverable.

Purpose:

* Prevent accidental reintroduction
* Preserve reviewer rationale
* Support future re-evaluation
* Maintain decision history

---

## REJ-INV-001

### Source Concept

`jppfs_cor:MerchandiseAndFinishedGoods`

### Rejected Canonical Role

`FinishedGoods`

### Decision

`REJECT`

### Reason

`Merchandise meaning would be removed.`

### Replacement Mapping

`MerchandiseAndFinishedGoods`

---

## REJ-INV-002

### Source Concept

`jppfs_cor:RawMaterialsAndSupplies`

### Rejected Canonical Role

`RawMaterials`

### Decision

`REJECT`

### Reason

`Supplies meaning would be removed.`

### Replacement Mapping

`RawMaterialsAndSupplies`

---

## REJ-INV-003

### Source Concept

`jpigp_cor:OtherInventoriesCAIFRS`

### Rejected Canonical Role

`Other`

### Decision

`REJECT`

### Reason

`Inventory domain would be removed and the Role would become semantically ambiguous.`

### Replacement Mapping

`OtherInventories`

---

## REJ-INV-004

### Source Concept

`SemiFinishedProductsAndWorkInProgressCAIFRS`

### Rejected Canonical Role

`WorkInProcess`

### Decision

`REJECT`

### Reason

`Semi-finished Products meaning would be removed.`

### Replacement Mapping

`SemiFinishedProductsAndWorkInProgress`

---

# 29. Rejected Decision Governance

Rejected Mapping Decisions are not Runtime Mapping Records.

They belong to governance history.

Possible future action:

`Reopen`

only when:

* New Primary Evidence
* New Taxonomy Evidence
* New Analytical Requirement
* New Architecture decision

exists.

A rejected Mapping must not be silently recreated as a new Active Mapping.

---

# 30. Mapping Version Governance Catalog

Each Mapping requires a logical Mapping Version.

Initial Candidate:

`1`

or equivalent version identifier.

### Version Change Triggers

* Scope change
* Canonical Role change
* Taxonomy Version support change
* Evidence change
* Reviewer decision change
* Conflict resolution change

### Principle

Mapping updates should create:

`New Version`

rather than silently rewriting historical Mapping meaning.

---

# 31. Mapping Version Status Relationship

One logical Mapping family may contain:

* Version 1: Superseded
* Version 2: Active

Historical Canonical Observations must retain:

`Mapping Version Used`

---

# 32. Effective Boundary Catalog

Mapping may define:

* Effective From
* Effective To
* Taxonomy Version From
* Taxonomy Version To

### Important

These are different from:

* Fact Period Start
* Fact Period End
* Filing Submission Date

Catalog must preserve this conceptual distinction.

---

# 33. Taxonomy Version Governance Catalog

Possible Version Scope Types:

## Exact

Mapping approved for one exact Taxonomy Version.

## Range

Mapping approved for a reviewed Version Range.

## OpenEndedReviewed

Mapping approved from a reviewed version forward subject to monitoring.

### Initial Recommendation

Use:

`Exact`

or:

`Explicit Reviewed Range`

for initial Production.

Avoid unbounded global activation.

---

# 34. Company Extension Scope Catalog

Company Extension mappings require stronger scope controls.

Minimum Scope Candidate:

* Company
* EDINET Code
* Namespace
* Accounting Standard
* Source Local Name

### Current M3 Case

Kioxia:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

Scope:

* Company: Kioxia Holdings
* EDINET Code: E35948
* Source Type: CompanyExtension

### Default Rule

A similar Local Name from another Company Extension does not inherit this Mapping.

---

# 35. Canonical Role Scope Catalog

Canonical Role itself may be:

* Global
* Limited-scope

### Current Limited-scope Role

`SemiFinishedProductsAndWorkInProgress`

Current Evidence Scope:

`Kioxia Holdings`

### Important

A limited-scope Canonical Role may later be promoted after broader Evidence.

---

# 36. Conflict Handling Catalog

For each Conflict Type, Catalog must define:

* Conflict Code
* Conflict Name
* Description
* Blocking Flag
* Default Action
* Review Required Flag

### Initial Default

All unresolved semantic conflicts:

`Blocking for Canonical Observation creation`

Raw Fact ingestion:

`Continues`

---

# 37. Conflict Default Action Catalog

## MultipleMappingConflict

Default:

`RequireManualReview`

---

## SameRoleDuplicateConflict

Default:

`RequireManualReview`

---

## NarrowCombinedOverlapConflict

Default:

`KeepRawFacts / DoNotCreateAffectedCanonicalObservation`

---

## StandardExtensionOverlapConflict

Default:

`RequireManualReview`

---

## VersionConflict

Default:

`BlockCanonicalMapping`

---

## ScopeConflict

Default:

`BlockCanonicalMapping`

---

# 38. Unmapped Governance Catalog

An Unmapped Source Concept should enter a Review Queue.

Minimum logical information:

* Source QName
* Namespace URI
* Local Name
* Taxonomy Family
* Taxonomy Version
* Company
* EDINET Code
* Filing ID
* Occurrence Count
* First Seen
* Last Seen
* Review Status

### Review Status Candidate

* New
* Researching
* Reviewed
* MappingApproved
* Rejected
* Deferred

---

# 39. Unmapped Priority Candidate

Future Research Queue priority may consider:

* Occurrence Count
* Number of Companies
* Financial Materiality
* Inventory Relevance
* Model / Metric Dependency
* Company Extension Frequency

### Important

Priority ranking does not approve a Mapping.

---

# 40. Evidence Reference Catalog

Each Mapping Catalog Entry should reference one or more Evidence Artifacts.

Minimum logical fields:

* Evidence Reference Code
* Mapping Code
* Evidence Type
* Artifact Path
* Evidence Description
* Reviewer Decision
* Evidence Version

---

# 41. Initial Evidence Reference Examples

## EV-INV-001

Mapping:

`MAP-INV-003`

Evidence:

`InventorySemanticMappingWorkInProcessCAIFRSResearchSheet.md`

Type:

`ResearchSheet`

---

## EV-INV-002

Mapping:

`MAP-INV-003`

Evidence:

`InventorySemanticMappingWorkInProcessCrossStandardOfficialTaxonomyEvidence.md`

Type:

`CrossStandardEvidence`

---

## EV-INV-003

Mapping:

`MAP-INV-011`

Evidence:

`InventorySemanticMappingSemiFinishedProductsAndWorkInProgressKioxiaResearchSheet.md`

Type:

`ResearchSheet`

---

# 42. Catalog Status Governance

Catalog entries themselves may have status.

Candidate:

* Draft
* Reviewed
* Approved
* Deprecated

### Important

Catalog Approval does not mean Runtime Activation.

---

# 43. Catalog Change Governance

Changes to Catalog require different review levels.

## Low-impact

* Description correction
* Non-semantic wording fix

## Medium-impact

* Scope metadata correction
* Evidence reference update

## High-impact

* Canonical Role change
* Mapping target change
* Mapping Class change
* Conflict rule change

### High-impact Change

Requires:

`Architecture Reviewer Gate`

---

# 44. Catalog and Research Relationship

Research Artifact answers:

`Why is this Mapping justified?`

Catalog answers:

`What logical configuration has been approved for implementation design?`

Production Mapping Master later answers:

`What may Runtime execute?`

These layers must remain separate.

---

# 45. Catalog and DDL Relationship

DDL must implement approved Catalog concepts.

DDL must not introduce a new semantic concept that is absent from Catalog merely for implementation convenience.

### Required Flow

`Catalog`

↓

`DDL`

↓

`Entity`

---

# 46. DDL Readiness Review

The Catalog now defines:

* Canonical Role
* Role Type
* Mapping Class
* Mapping Status
* Source Type
* Scope Type
* Conflict Type
* Runtime Result State
* Approved Mapping Set
* Rejected Decision Set
* Evidence Reference concept
* Version governance

### Initial DDL Readiness Candidate

`HIGH`

However:

Catalog Reviewer approval is required first.

---

# 47. Catalog Reviewer Review

## Question 1

Does the Catalog preserve Research decisions?

Decision:

`YES`

---

## Question 2

Does it improperly collapse Architecture into DDL?

Decision:

`NO`

Physical implementation details remain deferred.

---

## Question 3

Are Approved and Rejected Mapping decisions both represented?

Decision:

`YES`

---

## Question 4

Are Company Extension mappings scope-aware?

Decision:

`YES`

---

## Question 5

Are Combined Concepts represented explicitly?

Decision:

`YES`

---

## Question 6

Is Unmapped a first-class outcome?

Decision:

`YES`

---

## Question 7

Is Conflict a first-class concept?

Decision:

`YES`

---

## Question 8

Can Evidence Lineage be represented?

Decision:

`YES`

---

## Question 9

Is the Catalog sufficient to begin DDL design?

Decision:

`YES`

---

# 48. Catalog Reviewer Decision

### Decision

`APPROVE`

### Catalog Status

`APPROVED FOR DDL DESIGN`

### Approved Logical Catalog Areas

* Canonical Semantic Role Catalog
* Mapping Class Catalog
* Mapping Status Catalog
* Source Type Catalog
* Scope Type Catalog
* Conflict Type Catalog
* Runtime Result State Catalog
* Initial Approved Mapping Catalog
* Rejected Mapping Decision Catalog
* Evidence Reference Catalog
* Mapping Version Governance

### Not Yet Approved

* Physical Table Design
* SQL Data Types
* Indexes
* Entity Design
* Runtime Implementation

---

# 49. Catalog Definition of Done

Catalog is complete when:

* Canonical Roles are listed
* Role Types are defined
* Mapping Classes are defined
* Mapping Status lifecycle is cataloged
* Source Types are defined
* Scope Types are defined
* Conflict Types are defined
* Runtime Result States are defined
* Initial Approved Mappings are registered
* Rejected Mapping Decisions are registered
* Evidence Reference model is defined
* Version governance is defined
* Company Extension scope is represented
* Catalog Reviewer approval is recorded

### Result

`DEFINITION OF DONE = PASS`

---

# 50. Final Catalog Decision

### Inventory Semantic Mapping Catalog

`APPROVED`

### Next Phase

`DDL DESIGN`

### Required Sequence

`Research`

↓

`Architecture`

↓

`Catalog`

↓

`DDL`

↓

`Entity`

↓

`Implementation`

### Current Position

`Catalog Complete`

`DDL Next`

---

# 51. Exact Next Task

Next Artifact:

`InventorySemanticMappingDDLDesign.md`

### Purpose

> Approved Inventory Semantic Mapping Catalogを、Azure SQL / SQL Server上で監査可能・Version管理可能・Scope管理可能なPhysical Data Modelへ変換する。

### DDL Design Scope

The DDL Design must evaluate physical tables for at least:

1. Canonical Semantic Role Master
2. Semantic Mapping Rule
3. Mapping Scope
4. Mapping Evidence Reference
5. Mapping Version / Supersession
6. Rejected Mapping Decision
7. Mapping Conflict
8. Unmapped Concept Queue
9. Canonical Observation Mapping Lineage

### Mandatory Design Questions

* Natural Key vs Surrogate Key
* Namespace URI storage
* Source Concept uniqueness
* Version representation
* Scope representation
* Multiple Evidence References
* Mapping Status enforcement
* Active Mapping uniqueness
* Company Extension scope enforcement
* Conflict auditability
* Reprocessing lineage
* Soft delete vs status lifecycle
* Temporal history requirement
* Index strategy
* Referential integrity

### Important

Do not create EF Core Entity yet.

Do not implement Services yet.

First:

`DDL Design`

↓

`DDL Review`

only after Approval:

`Entity Design`

↓

`Implementation`
