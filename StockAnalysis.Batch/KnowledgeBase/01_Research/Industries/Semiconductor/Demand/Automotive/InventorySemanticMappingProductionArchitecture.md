# Inventory Semantic Mapping Production Architecture

## 1. Architecture Purpose

本書は、Research Phaseで承認されたInventory Semantic Mapping Decisionを、Production Systemへ安全かつ監査可能な形で持ち込むためのArchitectureを定義する。

本Architectureの目的は、単純なQName変換表を作成することではない。

目的は以下である。

> EDINET Raw Financial FactのSource Identityを保持したまま、Research-approved Mappingを使用してCanonical Semantic Observationを生成し、Taxonomy Version、Accounting Standard、Company Scope、Company Extension、Conflict、Unmapped、Mapping Version及びEvidence LineageをProduction上で統制する。

本書はArchitecture Designである。

以下は本書のScope外とする。

* DDL作成
* Entity実装
* Runtime Mapping実装
* Historical Reprocessing実行
* Derived Metric実装
* ML Feature実装
* Advisor実装

### Status

* Production Mapping Architecture Design
* Pre-Catalog
* Pre-DDL
* Pre-Entity
* Pre-Implementation
* Architecture Reviewer Pending

---

# 2. Research Inputs

本Architectureは以下のResearch結果を前提とする。

## 2.1 Raw Observation Boundary

`InventoryRawObservationSemanticMappingBoundary.md`

Core Principle:

`Raw Source Identity must not be destroyed by Semantic Mapping.`

---

## 2.2 Semantic Mapping Research Design

`InventorySemanticMappingResearchDesign.md`

Core Principles:

* Research-first
* Evidence-based Mapping
* Independent Reviewer Gate
* Information Loss Review
* Conflict Review
* Unmapped as valid outcome

---

## 2.3 Research Consolidation Review

`InventorySemanticMappingResearchConsolidationReview.md`

Final Decision:

`RESEARCH SUFFICIENT`

Approved Transition:

`PROCEED TO PRODUCTION MAPPING ARCHITECTURE DESIGN`

---

# 3. Production Boundary

Production Semantic Mapping Architecture is responsible for:

1. Source Concept Identity resolution
2. Mapping Candidate search
3. Scope matching
4. Mapping Version selection
5. Mapping Status validation
6. Canonical Semantic Role resolution
7. Conflict detection
8. Unmapped classification
9. Evidence lineage preservation
10. Canonical Observation creation eligibility
11. Audit trail generation

Production Semantic Mapping Architecture is not responsible for:

* Investment interpretation
* Metric comparability approval
* Accounting measurement equivalence
* Feature engineering
* ML importance weighting
* Trading decision generation

### Boundary

`Raw Fact`

↓

`Semantic Mapping`

↓

`Canonical Observation`

↓

`Derived Metric`

↓

`Comparability Validation`

↓

`ML / Decision Use`

Each layer must remain independently governed.

---

# 4. Core Architecture Principles

## 4.1 Raw Source Preservation

Semantic Mapping must never overwrite the original Source Fact.

Required preservation includes:

* QName
* Namespace URI
* Local Name
* Taxonomy Family
* Taxonomy Version
* Accounting Standard
* Filing Identity
* EDINET Code
* ContextRef
* UnitRef
* Decimals
* Raw Value
* Source Label
* Source Document ID

### Principle

`Canonicalization adds interpretation.`

It does not replace source evidence.

---

## 4.2 Research-approved Mapping Only

Production Mapping may use only:

`Approved Production Mapping Records`

Research approval alone does not automatically activate a Mapping in Production.

Required transition:

`Research Approval`

↓

`Architecture Approval`

↓

`Catalog Registration`

↓

`Production Mapping Approval`

↓

`Runtime Active`

---

## 4.3 No Name-based Guessing

The following are prohibited:

* Substring Mapping
* Prefix Guessing
* Local Name similarity alone
* Label keyword-only Mapping
* First-match wins
* Hardcoded fallback by naming pattern

Example prohibited rule:

`Concept contains RawMaterials → RawMaterials`

Mapping must be based on an explicit approved Mapping Record.

---

## 4.4 Unmapped Is Valid

If no approved Mapping applies:

`Unmapped`

is the correct result.

Do not force a Source Concept into the nearest Canonical Role.

---

## 4.5 Conflict Is a First-class State

If multiple eligible mappings or overlapping source facts exist:

Do not silently select one.

Result:

`Conflict`

must be recorded and reviewed.

---

# 5. Source Concept Identity Model

Production Mapping requires stable Source Concept Identity.

Minimum logical identity candidate:

`Namespace URI + Local Name`

QName alone is insufficient because prefixes may vary.

### Source Concept Identity Candidate

* Namespace URI
* Local Name
* QName for traceability
* Taxonomy Family
* Taxonomy Version
* Accounting Standard
* Source Type

### Source Type Candidate

* StandardTaxonomy
* CompanyExtension
* OtherExtension
* Unknown

### Identity Rule

Primary technical identity:

`Namespace URI + Local Name`

Human-readable identity:

`QName`

---

# 6. Taxonomy Family Model

Taxonomy Family should be represented explicitly.

Examples:

* `jppfs`
* `jpigp`
* `jpcrp`
* Company Extension Namespace

Purpose:

* Scope matching
* Version governance
* Standard / Extension distinction
* Research traceability

### Important

Taxonomy Family must not replace full Namespace URI.

It is a classification field.

---

# 7. Taxonomy Version Model

Taxonomy Version is a first-class Production concern.

Mapping Records may be:

* Version-specific
* Version-range scoped
* Version-independent only when explicitly approved

### Required Capability

The Architecture must support:

* Exact Version
* Minimum Version
* Maximum Version
* Open-ended Version Scope

### Example

`jpigp/2024-11-01 through jpigp/2025-11-01`

### Default Rule

A Mapping approved for one Taxonomy Version must not automatically apply to a new version without governance.

---

# 8. Canonical Semantic Role Model

Canonical Semantic Role represents normalized financial meaning.

Current Approved Research Roles:

* `InventoryTotal`
* `FinishedGoods`
* `WorkInProcess`
* `RawMaterials`
* `OtherInventories`
* `MerchandiseAndFinishedGoods`
* `RawMaterialsAndSupplies`
* `SemiFinishedProductsAndWorkInProgress`

### Role Properties Candidate

* Role Code
* Role Name
* Domain
* Description
* Role Type
* Combined Concept Flag
* Residual Concept Flag
* Limited Scope Flag
* Status
* Version

---

# 9. Canonical Role Type

Initial Role Type Candidate:

* `Total`
* `Component`
* `CombinedComponent`
* `ResidualComponent`

### Examples

`InventoryTotal`

→ `Total`

`WorkInProcess`

→ `Component`

`RawMaterialsAndSupplies`

→ `CombinedComponent`

`OtherInventories`

→ `ResidualComponent`

### Purpose

Role Type supports:

* Validation
* Conflict detection
* Total / Component separation
* Downstream governance

---

# 10. Domain Model

Canonical Semantic Role must belong to a Domain.

Current Domain:

`Inventory`

### Example

`OtherInventories`

Domain:

`Inventory`

This prevents ambiguous generic roles such as:

`Other`

### Architecture Principle

`Canonical Role should remain self-describing within and across domains.`

---

# 11. Mapping Rule Model

A Mapping Rule connects:

`Source Concept Identity`

to:

`Canonical Semantic Role`

### Minimum Logical Fields Candidate

* Mapping ID
* Source Namespace URI
* Source Local Name
* Source QName
* Taxonomy Family
* Accounting Standard
* Canonical Semantic Role
* Mapping Class
* Mapping Status
* Mapping Version
* Scope
* Evidence Reference
* Reviewer Status
* Effective Boundary

Important:

This is a logical model.

It is not DDL.

---

# 12. Mapping Class Model

Current Mapping Classes:

## M1

`Direct Standard or Direct Meaning-preserving Mapping`

Examples:

* `WorkInProcessCAIFRS → WorkInProcess`
* `RawMaterialsAndSuppliesCAIFRS → RawMaterialsAndSupplies`

---

## M2

`Strongly Supported Semantic Mapping with Simplification`

Current Approved Cases:

`NONE`

M2 requires explicit Information Loss justification.

---

## M3

`Company Extension Reviewed`

Example:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

↓

`SemiFinishedProductsAndWorkInProgress`

Scope:

`Kioxia-specific`

---

## M4

`Inference Mapping Candidate`

Production activation:

`NOT ALLOWED BY DEFAULT`

---

## M5

`Unmapped`

Used when no approved Mapping exists.

---

# 13. Mapping Status Lifecycle

Mapping Status should be explicitly governed.

Candidate Lifecycle:

`Draft`

↓

`ResearchApproved`

↓

`ArchitectureApproved`

↓

`CatalogApproved`

↓

`ProductionApproved`

↓

`Active`

Possible terminal / exceptional states:

* Rejected
* Deprecated
* Superseded
* Suspended
* Expired

### Runtime Rule

Only:

`Active`

Mapping Records may be used by Production Runtime Mapping.

---

# 14. Reviewer Status Model

Mapping activation requires independent Reviewer evidence.

Candidate Reviewer fields:

* Research Reviewer Status
* Architecture Reviewer Status
* Production Reviewer Status
* Reviewed By
* Reviewed At
* Review Evidence Reference

### Principle

A developer adding a Mapping Record must not automatically make it Active.

---

# 15. Mapping Scope Model

Not all mappings are global.

Production Architecture must support multiple Scope dimensions.

### Scope Dimensions Candidate

* Global
* Taxonomy Family
* Taxonomy Version
* Accounting Standard
* Company
* EDINET Code
* Filing Family
* Source Namespace
* Effective Date

### Example A

Standard Mapping:

`jpigp_cor:RawMaterialsCAIFRS → RawMaterials`

Scope:

`IFRS / jpigp / approved taxonomy versions`

### Example B

Company Extension Mapping:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

Scope:

`Kioxia / E35948`

---

# 16. Scope Specificity

When multiple Mapping Records could match one Source Fact, the system must apply deterministic specificity rules.

Candidate precedence:

1. Exact Company + Exact Namespace + Exact Version
2. Exact Company + Namespace Family
3. Exact Source Concept + Exact Version
4. Exact Source Concept + Taxonomy Version Range
5. Global approved Standard Mapping

### Important

Specificity determines Candidate priority.

It does not automatically resolve semantic conflicts.

---

# 17. Scope Matching Result

Possible Mapping Scope Match results:

* NoMatch
* SingleMatch
* MultipleCompatibleMatches
* MultipleConflictingMatches

### Runtime Rule

`SingleMatch`

may proceed.

`NoMatch`

→ Unmapped Queue

`MultipleCompatibleMatches`

→ Explicit deterministic review rule required

`MultipleConflictingMatches`

→ Conflict

---

# 18. Mapping Version Model

Mapping decisions may evolve.

Each Mapping Record requires:

`Mapping Version`

### Version Change Triggers

* Taxonomy update
* New Filing Evidence
* New Company Evidence
* Canonical Role change
* Scope change
* Reviewer decision change
* Conflict discovery

### Principle

Historical Mapping decisions must remain reproducible.

---

# 19. Mapping Effective Boundary

Mapping Version should support:

* Effective From
* Effective To

These may represent:

* Taxonomy Version boundary
* Filing period boundary
* Submission date boundary
* Governance activation date

### Important

Effective dates must not be confused with:

`Source Fact Period`

Both must remain separately represented.

---

# 20. Mapping Supersession

A Mapping may be replaced.

Example:

`Mapping Version 1`

↓

`Mapping Version 2`

The previous Mapping must not be deleted.

Required relationship:

`Superseded By`

or equivalent version lineage.

### Principle

`Mapping history is append-oriented.`

---

# 21. Evidence Lineage Model

Every Production Mapping Record must reference supporting Research Evidence.

Minimum Evidence Reference Candidate:

* Research Artifact Path
* Evidence Type
* Reviewer Decision
* Approval Date
* Evidence Version

### Example

Mapping:

`RawMaterialsAndSuppliesCAIFRS → RawMaterialsAndSupplies`

Evidence:

`InventorySemanticMappingRawMaterialsAndSuppliesCAIFRSResearchSheet.md`

### Principle

`Production Mapping must be auditable back to Research.`

---

# 22. Multiple Evidence References

One Mapping may depend on multiple Research Artifacts.

Example Cross-standard Mapping:

* Cross-standard Official Taxonomy Evidence
* Final Mapping Research Sheet
* Reference J-GAAP Mapping Sheet

Therefore Architecture should support:

`1 Mapping → many Evidence References`

Do not force all evidence into one free-text field.

---

# 23. Source Fact Eligibility Boundary

A valid Mapping Record does not mean every Fact with that Source Concept is eligible.

Runtime Fact Eligibility still requires:

* Context validation
* Period type validation
* Consolidation scope validation
* Unit validation
* Filing status validation
* Withdrawal / disclosure status validation where applicable

### Principle

`Mapping Eligibility ≠ Fact Eligibility`

Both gates must pass.

---

# 24. Runtime Mapping Flow

Candidate Runtime Flow:

`Raw EDINET Fact`

↓

`Validate Raw Fact Identity`

↓

`Validate Filing Eligibility`

↓

`Validate Context / Period / Scope`

↓

`Resolve Source Concept Identity`

↓

`Find Active Mapping Candidates`

↓

`Apply Mapping Scope Filter`

↓

`Evaluate Mapping Version`

↓

`Detect Mapping Conflict`

↓

`Resolve Canonical Semantic Role`

↓

`Detect Source Fact Overlap`

↓

`Create Canonical Observation Candidate`

↓

`Validate Observation`

↓

`Persist Canonical Observation`

↓

`Persist Mapping Lineage`

---

# 25. Canonical Observation Requirement

A Canonical Observation should retain a link to:

* Raw Source Fact
* Mapping Record
* Mapping Version
* Canonical Semantic Role
* Mapping Timestamp

### Principle

A Canonical Observation must answer:

`Which source fact produced this observation?`

and:

`Which mapping decision was used?`

---

# 26. Mapping Result State

Runtime Mapping Result Candidate:

* Mapped
* Unmapped
* Conflict
* Ineligible
* Error

### Mapped

One valid Mapping and eligible Fact.

### Unmapped

No Active Mapping.

### Conflict

Multiple incompatible candidates or semantic overlap.

### Ineligible

Fact exists but fails eligibility.

### Error

Technical processing failure.

These states must remain distinguishable.

---

# 27. Unmapped Queue

Unknown Source Concepts must be visible.

Required Unmapped information candidate:

* Source QName
* Namespace URI
* Local Name
* Taxonomy Version
* Company
* EDINET Code
* Filing ID
* Occurrence Count
* First Seen
* Last Seen
* Sample Value
* Sample Context
* Review Status

### Purpose

Unmapped Queue becomes:

`Research Discovery Input`

### Principle

Production must surface unknowns.

It must not hide them.

---

# 28. Conflict Model

Conflict is not one generic error.

Candidate Conflict Types:

* MultipleMappingConflict
* SameRoleDuplicateConflict
* NarrowCombinedOverlapConflict
* TotalComponentConflict
* StandardExtensionOverlapConflict
* VersionConflict
* ScopeConflict
* EligibilityConflict

### Purpose

Conflict classification enables:

* Review routing
* Metrics
* Audit
* Resolution

---

# 29. Narrow and Combined Concept Conflict

Example:

`RawMaterialsCAIFRS`

and:

`RawMaterialsAndSuppliesCAIFRS`

Potential Issue:

Semantic overlap.

### Runtime Rule

Do not automatically sum.

Do not automatically prefer narrower or broader.

Result:

`NarrowCombinedOverlapConflict`

unless an explicit approved Selection Rule exists.

---

# 30. Total and Component Conflict

InventoryTotal and Inventory Components may coexist legitimately.

This coexistence is not inherently a Conflict.

However:

Using both in the same total calculation would create Double Count.

### Architecture Boundary

Semantic Mapping may produce:

* InventoryTotal Observation
* Component Observations

Downstream calculation logic must distinguish Role Type.

---

# 31. Same Canonical Role Duplicate Conflict

If multiple Source Facts map to the same Canonical Role for the same:

* Company
* Filing
* Period
* Scope

do not automatically:

* sum
* take first
* take maximum
* take latest

Result:

`SameRoleDuplicateConflict`

unless an approved Resolution Rule exists.

---

# 32. Standard and Extension Overlap Conflict

A Filing may contain:

* Standard Taxonomy Concept
* Company Extension Concept

with overlapping meaning.

Example candidate:

* `WorkInProcessCAIFRS`
* `SemiFinishedProductsAndWorkInProgressCAIFRS`

### Rule

Do not assume Extension should override Standard.

Do not assume Standard should override Extension.

Detect and review semantic overlap.

---

# 33. Conflict Resolution Model

Conflict resolution should be explicit and evidence-based.

Possible Resolution Outcomes:

* SelectSourceA
* SelectSourceB
* KeepBothDistinct
* MarkUnmapped
* RequireManualReview
* AddNewMappingVersion
* AddScopeRestriction

### Required Audit

* Conflict ID
* Resolution
* Evidence
* Reviewer
* Resolution Date
* Mapping Version Impact

---

# 34. Manual Review Boundary

Production Runtime must not block the entire ingestion pipeline because one Concept is Unmapped or Conflicted.

Candidate behavior:

* Persist Raw Fact
* Record Mapping Result
* Queue Review
* Continue processing unrelated Facts

### Principle

`Fail isolated, not globally.`

---

# 35. Failure Handling

Technical Failure and Semantic Failure must remain separate.

### Technical Failure

Examples:

* Database unavailable
* Invalid JSON
* ZIP corruption
* XBRL parse failure

### Semantic Failure

Examples:

* Unmapped Concept
* Multiple mapping candidates
* Overlap conflict

These require different operational responses.

---

# 36. Historical Reprocessing Boundary

Mapping changes may require historical reprocessing.

Examples:

* New Mapping added
* Mapping scope corrected
* Canonical Role changed
* Mapping Version superseded
* Conflict resolved

### Architecture Requirement

System must be able to identify:

`Which Canonical Observations were created using Mapping Version X?`

---

# 37. Reprocessing Impact Analysis

Before historical reprocessing, identify impacted:

* Raw Facts
* Canonical Observations
* Derived Metrics
* ML Training Data
* Backtests
* Advisor Outputs

### Principle

`Mapping change impact must be traceable before reprocessing.`

---

# 38. Historical Interpretation

Two possible approaches exist.

## Option A

Always recompute historical data using latest Mapping.

Risk:

Historical interpretation silently changes.

## Option B

Preserve original Mapping Version and selectively reprocess.

Preferred Candidate:

`Option B`

### Reason

Supports:

* Reproducibility
* Backtest audit
* Model dataset lineage

---

# 39. Canonical Observation Versioning

Canonical Observation may require:

* Mapping Version Used
* Observation Version
* Reprocessing Batch ID

This enables distinction between:

`Original Observation`

and:

`Reprocessed Observation`

### Status

`Architecture Candidate`

Detailed implementation deferred to Catalog / DDL phase.

---

# 40. Auditability Requirement

The system must be able to answer:

1. Why was this Source Fact mapped?
2. Which Mapping Record was used?
3. Which Mapping Version was used?
4. Which Research Evidence supports it?
5. Who approved it?
6. Was the Mapping later superseded?
7. Was the Observation reprocessed?

### Definition

If these questions cannot be answered:

`Production Mapping is not auditable.`

---

# 41. Mapping Change Governance

A Mapping change must not be treated as ordinary configuration editing.

Required Change Flow:

`New Evidence`

↓

`Research Review`

↓

`Reviewer Decision`

↓

`Architecture Impact Review`

↓

`New Mapping Version`

↓

`Production Approval`

↓

`Optional Reprocessing`

---

# 42. Canonical Role Change Governance

Canonical Role changes are higher impact than simple Mapping additions.

Examples:

* Role rename
* Role split
* Role merge
* Role deprecation

Potential Impact:

* Catalog
* Metrics
* ML Features
* Backtests
* Advisor Outputs

Therefore:

`Canonical Role Change`

requires:

`Architecture Reviewer Gate`

---

# 43. Production Mapping Master Boundary

The Production Mapping Master should store:

`Approved executable mapping configuration`

It should not replace:

`Research Evidence`

### Relationship

`Research Artifact`

↓

`Approved Mapping Decision`

↓

`Production Mapping Master`

### Principle

Mapping Master answers:

`What should runtime do?`

Research Artifact answers:

`Why is this justified?`

Both are required.

---

# 44. Canonical Role Master Boundary

Canonical Role Master should define:

* Approved Role Identity
* Domain
* Meaning
* Role Type
* Status
* Version

It should not contain Source-specific mapping logic.

### Separation

`Canonical Role Master`

defines:

`What semantic meanings exist?`

`Mapping Master`

defines:

`Which Source Concepts map to them?`

---

# 45. Catalog Boundary

Catalog Design follows Architecture Approval.

Catalog should register:

* Canonical Role definitions
* Mapping definitions
* Scope definitions
* Status definitions
* Mapping Class definitions
* Conflict Type definitions

### Important

Do not move to Catalog until this Architecture is reviewed.

---

# 46. DDL Boundary

DDL must follow:

`Research`

↓

`Architecture`

↓

`Catalog`

Only after Catalog approval should tables be designed.

### Prohibited

Creating Mapping tables now.

---

# 47. Entity Boundary

Entity classes must reflect approved DDL.

Do not design Entity first and force the database to follow implementation convenience.

### Required Sequence

`Catalog`

↓

`DDL`

↓

`Entity`

---

# 48. Runtime Implementation Boundary

Runtime Mapping implementation must not begin until:

* Architecture Approved
* Catalog Approved
* DDL Approved
* Entity Approved

### Reason

Runtime behavior depends on:

* Scope
* Version
* Status
* Conflict model
* Lineage

Premature implementation would likely hardcode unresolved design choices.

---

# 49. Initial Production Mapping Record Examples

These examples are conceptual only.

## Example A

Source:

`jpigp_cor:WorkInProcessCAIFRS`

Canonical:

`WorkInProcess`

Class:

`M1`

Scope:

`IFRS Standard Taxonomy`

---

## Example B

Source:

`jppfs_cor:RawMaterialsAndSupplies`

Canonical:

`RawMaterialsAndSupplies`

Class:

`M1`

Scope:

`Japanese GAAP Standard Taxonomy`

---

## Example C

Source:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

Canonical:

`SemiFinishedProductsAndWorkInProgress`

Class:

`M3`

Scope:

`Kioxia / E35948`

---

# 50. Rejected Mapping Governance

Rejected Research Candidates may be useful to retain as governance evidence.

Examples:

* `MerchandiseAndFinishedGoods → FinishedGoods`
* `RawMaterialsAndSupplies → RawMaterials`
* `OtherInventories → Other`
* `SemiFinishedProductsAndWorkInProgress → WorkInProcess`

### Purpose

Prevent future reintroduction of previously rejected mappings without new evidence.

### Candidate Architecture

Rejected mappings may exist in:

`Research Decision Catalog`

rather than Active Production Mapping Master.

Detailed placement deferred to Catalog Design.

---

# 51. Security and Operational Boundary

Semantic Mapping does not require external user-editable runtime configuration in the initial phase.

Initial recommendation:

`Admin / controlled batch process only`

### Reason

Mapping changes affect:

* Historical interpretation
* ML datasets
* Backtests

Therefore unrestricted UI editing is inappropriate initially.

---

# 52. Observability Requirements

Production Mapping should expose metrics such as:

* Total Facts Processed
* Mapped Count
* Unmapped Count
* Conflict Count
* Ineligible Count
* Mapping Usage by Mapping Version
* Unknown Concept Count
* Company Extension Count

### Purpose

Detect:

* Taxonomy changes
* New concepts
* Mapping regressions
* Unexpected coverage loss

---

# 53. Taxonomy Change Detection

A rise in:

`Unmapped Count`

after a new filing season may indicate:

* New Taxonomy Version
* New Company Extension
* Changed Source Concept usage

### Architecture Requirement

Unmapped / Conflict metrics should become a Taxonomy Change signal.

---

# 54. Initial Runtime Strategy

Recommended initial runtime strategy:

`Conservative Mapping`

Characteristics:

* Approved mappings only
* No inference mapping
* No automatic substring matching
* No automatic conflict resolution
* Unmapped surfaced
* Conflicts surfaced
* Full lineage

### Reason

Initial Production goal is:

`Correct and auditable`

before:

`Maximum coverage`

---

# 55. Future Runtime Strategy

Future phases may add:

* Suggested Mapping Candidates
* Automated Taxonomy Diff Detection
* Reviewer Support Tools
* Confidence-assisted Research Queue

However:

AI or heuristic suggestions must not automatically activate Production Mapping.

### Boundary

`Suggestion`

≠

`Approved Mapping`

---

# 56. Architecture Risks

Known Risks:

1. Mapping Master complexity
2. Scope precedence complexity
3. Taxonomy Version growth
4. Company Extension proliferation
5. Conflict queue growth
6. Reprocessing cost
7. Canonical Role fragmentation
8. Reviewer workload

### Mitigation

* Explicit scope
* Versioning
* Conservative runtime
* Research evidence reuse
* Observability
* Limited automation

---

# 57. Architecture Trade-off

This Architecture chooses:

`Governance and auditability`

over:

`Simple hardcoded mapping`

### Cost

* More metadata
* More review
* More implementation complexity

### Benefit

* Reproducibility
* Evidence traceability
* Safe taxonomy evolution
* Historical auditability
* ML dataset trustworthiness

### Decision

`ACCEPT TRADE-OFF`

This project targets long-term evidence-based investment analysis.

A simple dictionary is insufficient.

---

# 58. Architecture Reviewer Review

## Question 1

Is this Architecture overengineered for the current 11 mappings?

Reviewer Concern:

`YES, potentially`

However:

The Architecture is driven not by current mapping count alone, but by observed complexity:

* Multiple standards
* Multiple taxonomy versions
* Company extensions
* Scope restrictions
* rejected mappings
* conflicts
* future historical reprocessing

### Decision

`Complexity is justified`

---

## Question 2

Could mappings be hardcoded first?

Decision:

`NOT RECOMMENDED`

Hardcoding would hide:

* Version
* Scope
* Evidence
* Status
* reviewer decisions

and increase redesign risk.

---

## Question 3

Is Mapping Scope first-class?

Decision:

`YES`

Required by M3 Company Extension cases.

---

## Question 4

Is Mapping Version first-class?

Decision:

`YES`

Required for reproducibility and historical reprocessing.

---

## Question 5

Is Conflict first-class?

Decision:

`YES`

Observed source structures make silent conflict resolution unsafe.

---

## Question 6

Is full Evidence Lineage necessary?

Decision:

`YES`

This project explicitly requires evidence-based governance.

---

# 59. Architecture Reviewer Decision

### Decision

`APPROVE`

### Architecture Status

`APPROVED FOR CATALOG DESIGN`

### Approved Boundaries

* Source Concept Identity
* Canonical Role separation
* Mapping Rule
* Mapping Scope
* Mapping Version
* Evidence Lineage
* Conflict
* Unmapped Queue
* Reprocessing boundary
* Auditability

### Not Yet Approved

* DDL
* Entity
* Runtime implementation

---

# 60. Architecture Definition of Done

Architecture is complete when:

* Source Concept Identity is defined
* Canonical Role Model is defined
* Mapping Rule Model is defined
* Scope is first-class
* Version is first-class
* Status lifecycle is defined
* Evidence lineage is defined
* Conflict states are defined
* Unmapped state is defined
* Runtime Mapping Flow is defined
* Reprocessing boundary is defined
* Auditability requirements are defined
* Catalog boundary is defined
* DDL boundary is defined
* Reviewer approval is recorded

### Result

`DEFINITION OF DONE = PASS`

---

# 61. Final Architecture Decision

### Production Mapping Architecture

`APPROVED`

### Next Phase

`Catalog Design`

### Sequence

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

`Architecture Complete`

`Catalog Next`

---

# 62. Exact Next Task

Next Artifact:

`InventorySemanticMappingCatalog.md`

### Purpose

> Production Mapping Architectureで承認されたConcept、Role、Mapping、Scope、Status、Version及びConflict Governanceを、実装前の論理Catalogとして定義する。

### Required Catalog Sections

1. Catalog Purpose
2. Canonical Semantic Role Catalog
3. Mapping Class Catalog
4. Mapping Status Catalog
5. Scope Type Catalog
6. Conflict Type Catalog
7. Source Type Catalog
8. Approved Initial Mapping Catalog
9. Rejected Mapping Decision Catalog
10. Evidence Reference Catalog
11. Version Governance
12. Catalog Reviewer Gate
13. Definition of Done

### Important

Catalog is still not DDL.

Do not define:

* SQL Data Types
* Primary Keys
* Foreign Keys
* Indexes
* EF Core Entities

until Catalog Review passes.
