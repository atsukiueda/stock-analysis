# Inventory Semantic Mapping DDL Design

## 1. Document Purpose

本書は、`InventorySemanticMappingCatalog.md`で承認された論理Catalogを、Azure SQL / SQL Server上で実装可能なPhysical Data Modelへ変換するためのDDL Design Artifactである。

本書の目的は、単純なMapping Tableを1つ作成することではない。

目的は以下である。

> Inventory Semantic Mapping Production Architecture及びCatalogで承認されたCanonical Semantic Role、Mapping Rule、Mapping Scope、Mapping Version、Evidence Lineage、Rejected Decision、Conflict、Unmapped Queue及びCanonical Observation Lineageを、監査可能・Version管理可能・Scope管理可能なRelational Data Modelとして設計する。

本書はPhysical Database Designである。

ただし、本書では以下をまだ行わない。

* `CREATE TABLE` SQLの最終確定
* Migration作成
* EF Core Entity作成
* DbContext登録
* Service実装
* Runtime Mapping実装
* Historical Reprocessing実装

### Status

* DDL Design
* Architecture Approved Input
* Catalog Approved Input
* Pre-SQL
* Pre-Entity
* Pre-Implementation
* DDL Reviewer Pending

---

# 2. Design Inputs

本DDL Designは以下を前提とする。

## Research

* `InventoryRawObservationSemanticMappingBoundary.md`
* `InventorySemanticMappingResearchDesign.md`
* Individual Mapping Research Sheets
* `InventorySemanticMappingResearchConsolidationReview.md`

## Architecture

* `InventorySemanticMappingProductionArchitecture.md`

## Catalog

* `InventorySemanticMappingCatalog.md`

### Required Sequence

`Research`

↓

`Architecture`

↓

`Catalog`

↓

`DDL`

---

# 3. Database Design Principles

## 3.1 Semantic Data and Governance Data Must Be Separated

以下を1テーブルへ詰め込まない。

* Canonical Role Definition
* Mapping Rule
* Mapping Scope
* Evidence
* Conflict
* Unmapped Queue
* Runtime Observation Lineage

それぞれ責務が異なる。

---

## 3.2 Current State Must Not Destroy History

Mappingは変更される可能性がある。

Therefore:

* UPDATEだけで旧Decisionを消さない
* Versionを保持する
* Supersessionを追跡する
* Historical Observationが使用したMapping Versionを保持する

---

## 3.3 Source Identity Must Be Explicit

Source Concept Identityは最低限以下で識別する。

`NamespaceUri + LocalName`

QNameは表示・監査用途として保持する。

### Important

QName PrefixはNamespace Aliasであり、Primary Identityには使用しない。

---

## 3.4 Surrogate Key and Natural Key Have Different Roles

Recommendation:

* Internal relationships use Surrogate Key
* Semantic uniqueness is enforced by Natural Key constraints

### Reason

Long Namespace URIやVersion / Scope条件を全FKへ伝播させない。

---

## 3.5 No Hard Delete for Governance Records

以下は原則Hard Deleteしない。

* Canonical Role
* Mapping Rule
* Mapping Version
* Rejected Decision
* Conflict Resolution
* Evidence Reference

State transition should use:

* Status
* Effective boundary
* Supersession

---

# 4. Proposed Physical Table Set

Initial Physical Table Candidates:

1. `SemanticCanonicalRoles`
2. `SemanticMappingRules`
3. `SemanticMappingScopes`
4. `SemanticMappingEvidenceReferences`
5. `SemanticRejectedMappingDecisions`
6. `SemanticMappingConflicts`
7. `SemanticMappingConflictFacts`
8. `SemanticUnmappedConcepts`
9. `SemanticCanonicalObservationLineages`

Optional future table:

10. `SemanticMappingReviewHistories`

Initial recommendation:

`Do not add ReviewHistories in first DDL unless existing project governance requires actor-level workflow persistence.`

Reviewer approvals can initially remain on Mapping Rule / Evidence records.

---

# 5. Table

# SemanticCanonicalRoles

## Purpose

Canonical Semantic Role Masterを保持する。

This table answers:

`What normalized semantic meanings exist?`

It does not contain Source Concept Mapping logic.

---

## 5.1 Candidate Columns

* `Id`
* `RoleCode`
* `RoleName`
* `DomainCode`
* `Description`
* `RoleTypeCode`
* `IsCombinedConcept`
* `IsResidualConcept`
* `IsLimitedScope`
* `StatusCode`
* `RoleVersion`
* `EffectiveFrom`
* `EffectiveTo`
* `CreatedAt`
* `UpdatedAt`

---

## 5.2 Primary Key

`Id`

Candidate Type:

`bigint`

Reason:

* Stable internal FK
* Simple indexing
* Avoid string FK propagation

---

## 5.3 Natural Key

Candidate:

`RoleCode + RoleVersion`

### Unique Constraint Candidate

`UNIQUE(RoleCode, RoleVersion)`

### Current Active Uniqueness

At most one active Role Version should exist per `RoleCode`.

This may require:

* Filtered Unique Index

Candidate condition:

`StatusCode = 'Active'`

Detailed SQL deferred to final DDL.

---

## 5.4 RoleCode

Examples:

* `InventoryTotal`
* `FinishedGoods`
* `WorkInProcess`
* `RawMaterials`
* `OtherInventories`
* `MerchandiseAndFinishedGoods`
* `RawMaterialsAndSupplies`
* `SemiFinishedProductsAndWorkInProgress`

RoleCode should be:

* Stable
* Machine-readable
* English
* PascalCase

---

## 5.5 RoleTypeCode

Allowed Catalog Values:

* `Total`
* `Component`
* `CombinedComponent`
* `ResidualComponent`

Initial Recommendation:

Use controlled string code or FK Master.

### DDL Candidate Decision

For the initial implementation:

`Use string code with CHECK constraint`

Reason:

Small stable enumeration.

Do not create a separate master table solely for four stable Role Types unless broader project standards require master-table normalization.

---

# 6. Table

# SemanticMappingRules

## Purpose

Source Concept IdentityからCanonical Semantic RoleへのApproved Mapping Versionを保持する。

This table answers:

`Which Canonical Role may this Source Concept map to under approved conditions?`

---

## 6.1 Candidate Columns

* `Id`
* `MappingCode`
* `MappingVersion`
* `SourceNamespaceUri`
* `SourceLocalName`
* `SourceQName`
* `TaxonomyFamilyCode`
* `SourceTypeCode`
* `AccountingStandardCode`
* `CanonicalRoleId`
* `MappingClassCode`
* `StatusCode`
* `ResearchReviewerStatusCode`
* `ArchitectureReviewerStatusCode`
* `ProductionReviewerStatusCode`
* `EffectiveFrom`
* `EffectiveTo`
* `SupersededByMappingRuleId`
* `CreatedAt`
* `UpdatedAt`
* `ReviewedAt`

---

## 6.2 Primary Key

`Id`

Candidate Type:

`bigint`

---

## 6.3 MappingCode

Examples:

* `MAP-INV-001`
* `MAP-INV-002`

MappingCode identifies the logical Mapping family.

### Mapping Version

Example:

`MappingCode = MAP-INV-003`

Versions:

* Version 1
* Version 2

### Natural Key

`MappingCode + MappingVersion`

Unique Constraint:

`UNIQUE(MappingCode, MappingVersion)`

---

# 7. Source Concept Natural Identity

Within a Mapping Rule, Source Concept is identified by:

* `SourceNamespaceUri`
* `SourceLocalName`

Additional classification:

* Taxonomy Family
* Source Type
* Accounting Standard

### Important

Do not require `SourceQName` uniqueness.

Prefix may differ.

---

# 8. Namespace URI Storage

Namespace URI can be long.

Candidate Physical Type:

`nvarchar(1000)`

Final length to be verified against observed EDINET Extension Namespace maximums before SQL finalization.

### Important

Do not hash Namespace URI as the only stored identity.

Optional future optimization:

* Namespace hash
* Separate Namespace Master

Initial Recommendation:

`Store full Namespace URI directly`

Reason:

Initial mapping volume is small.

Auditability is more important than premature normalization.

---

# 9. Source Local Name Storage

Candidate Type:

`nvarchar(300)`

Reason:

Company Extension Local Names may be long.

Final length should be validated against observed EDINET data before SQL finalization.

---

# 10. Source QName Storage

Candidate Type:

`nvarchar(500)`

Purpose:

* Auditability
* Debugging
* Human-readable diagnostics

QName is not the authoritative natural identity.

---

# 11. Taxonomy Family Storage

Candidate Values:

* `jppfs`
* `jpigp`
* `jpcrp`
* `CompanyExtension`
* `Unknown`

Initial Recommendation:

Store as controlled string code.

No separate table initially.

---

# 12. Source Type Storage

Allowed Values:

* `StandardTaxonomy`
* `CompanyExtension`
* `OtherExtension`
* `Unknown`

Initial Recommendation:

Controlled string + CHECK constraint.

---

# 13. Accounting Standard Storage

Candidate Values:

* `JapaneseGAAP`
* `IFRS`
* Future standards if required

Initial Recommendation:

Use existing project Accounting Standard Master if already present.

If no such Master exists:

Use controlled string code initially.

### Important

Do not create duplicate standard master structures without checking the existing schema.

---

# 14. CanonicalRoleId

FK Candidate:

`SemanticCanonicalRoles.Id`

### Rule

Mapping Rule must reference one Canonical Role Version or Role Identity.

Design Question:

Should Mapping reference:

* exact Role row/version
* stable RoleCode identity

### DDL Decision

Reference exact `SemanticCanonicalRoles.Id`.

Reason:

A Mapping decision must remain reproducible against the Role Version used at approval time.

---

# 15. Mapping Class Storage

Allowed:

* `M1`
* `M2`
* `M3`
* `M4`
* `M5`

### Runtime Rule

Only approved executable classes should become Active.

Initial Production Candidate:

* M1
* M3

M2 only when a future explicit approved case exists.

M4:

`Never Active by default`

M5:

Represents Unmapped governance, not an executable Mapping Rule.

### DDL Decision

`M5 should not be stored as an active Mapping Rule to a Canonical Role.`

Unmapped belongs to runtime result / unmapped queue.

---

# 16. Mapping Status Storage

Allowed Lifecycle Values:

* Draft
* ResearchApproved
* ArchitectureApproved
* CatalogApproved
* ProductionApproved
* Active
* Rejected
* Suspended
* Deprecated
* Superseded
* Expired

### Runtime Query Rule

Only:

`StatusCode = 'Active'`

may participate in Runtime Mapping.

---

# 17. SupersededByMappingRuleId

Self FK:

`SemanticMappingRules.Id`

Purpose:

Version lineage.

### Rule

A Mapping Rule may point to its direct successor.

Do not delete superseded versions.

---

# 18. Table

# SemanticMappingScopes

## Purpose

Mapping Ruleの適用範囲を保持する。

Mapping Scope is first-class and compositional.

One Mapping Rule may have multiple required Scope Conditions.

---

## 18.1 Candidate Columns

* `Id`
* `MappingRuleId`
* `ScopeTypeCode`
* `ScopeOperatorCode`
* `ScopeValue`
* `ScopeValueFrom`
* `ScopeValueTo`
* `IsRequired`
* `CreatedAt`

---

# 19. Scope Type Values

Allowed initial values:

* `Global`
* `TaxonomyFamily`
* `TaxonomyVersion`
* `AccountingStandard`
* `Company`
* `EdinetCode`
* `FilingFamily`
* `Namespace`

---

# 20. Scope Operator

Candidate Values:

* `Equals`
* `FromInclusive`
* `ToInclusive`
* `BetweenInclusive`

Potential future:

* `Prefix`
* `Regex`

### Initial Decision

Do not support Regex in initial Production.

Reason:

Complex and difficult to audit.

---

# 21. Scope Value Representation

All Scope Values may initially be represented as normalized strings.

Examples:

`EdinetCode = E35948`

`AccountingStandard = IFRS`

`TaxonomyVersion = 2025-11-01`

### Trade-off

String representation is flexible.

But it weakens DB-level referential integrity for Company / EDINET Code.

### Initial Decision

Use typed dedicated columns only where an existing stable master exists.

Otherwise keep logical generic scope structure.

This decision must be reviewed against the actual current DB schema before final SQL.

---

# 22. Global Scope Representation

Two options:

## Option A

No scope rows means Global.

## Option B

Explicit `Global` scope row.

### Decision

Use:

`No scope rows = Global`

Reason:

Avoid redundant Global row.

### Exception

If operational readability later benefits from explicit scope, reconsider.

---

# 23. Company Extension Scope Example

Mapping:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

Required Scope Rows candidate:

* `EdinetCode = E35948`
* `AccountingStandard = IFRS`
* `Namespace = exact extension namespace family or approved pattern`

### Important

A Local Name match alone must not activate M3 Mapping.

---

# 24. Table

# SemanticMappingEvidenceReferences

## Purpose

Mapping RuleとResearch / Architecture Evidenceのmany-to-many relationshipを保持する。

---

## 24.1 Candidate Columns

* `Id`
* `MappingRuleId`
* `EvidenceCode`
* `EvidenceTypeCode`
* `ArtifactPath`
* `EvidenceDescription`
* `EvidenceVersion`
* `ReviewerDecisionCode`
* `ReviewedAt`
* `CreatedAt`

---

# 25. Evidence Relationship

One Mapping Rule:

`1`

to:

`many Evidence References`

Example:

`WorkInProcessCAIFRS → WorkInProcess`

may reference:

* Mapping Research Sheet
* Cross-standard Taxonomy Evidence
* J-GAAP Reference Mapping Sheet

---

# 26. Artifact Path

Candidate Type:

`nvarchar(1000)`

Store repository-relative path.

Example:

`KnowledgeBase/01_Research/.../InventorySemanticMappingWorkInProcessCAIFRSResearchSheet.md`

### Important

Do not store only an external URL.

Repository Artifact Path is the internal Evidence anchor.

---

# 27. Table

# SemanticRejectedMappingDecisions

## Purpose

Explicitly Rejected Mapping Candidatesを保持する。

This prevents previously rejected normalization from being silently reintroduced.

---

## 27.1 Candidate Columns

* `Id`
* `DecisionCode`
* `SourceNamespaceUri`
* `SourceLocalName`
* `SourceQName`
* `RejectedCanonicalRoleCode`
* `ReplacementCanonicalRoleCode`
* `ReasonCode`
* `ReasonDescription`
* `EvidenceReference`
* `DecisionStatusCode`
* `ReviewedAt`
* `CreatedAt`

---

# 28. Rejected Decision Natural Key

Candidate:

`SourceNamespaceUri + SourceLocalName + RejectedCanonicalRoleCode + Decision Version`

A Decision Version field may be required.

### DDL Decision

Add:

`DecisionVersion`

Natural Key:

`DecisionCode + DecisionVersion`

Reason:

Rejected decisions may be reopened or superseded.

---

# 29. Rejected Mapping Runtime Use

Rejected Mapping Decisions are not used to create Canonical Observations.

However Runtime Mapping Candidate generation may use them to:

* prevent prohibited fallback logic
* improve diagnostics
* surface known rejection reason

### Initial Runtime Requirement

Optional.

DDL should preserve the data regardless.

---

# 30. Table

# SemanticMappingConflicts

## Purpose

RuntimeまたはValidation時に検出されたSemantic Mapping Conflictを保持する。

---

## 30.1 Candidate Columns

* `Id`
* `ConflictCode`
* `ConflictTypeCode`
* `SeverityCode`
* `StatusCode`
* `CompanyCode`
* `EdinetCode`
* `DocumentId`
* `PeriodKey`
* `ScopeKey`
* `Description`
* `DetectedAt`
* `ResolvedAt`
* `ResolutionCode`
* `ResolutionDescription`
* `ResolvedBy`
* `CreatedAt`
* `UpdatedAt`

---

# 31. Conflict Status Values

Candidate:

* Open
* Investigating
* Resolved
* Dismissed
* Superseded

---

# 32. Conflict Severity Values

Candidate:

* Warning
* Blocking
* Critical

### Initial Semantic Conflict Default

`Blocking`

for affected Canonical Observation creation.

---

# 33. Conflict Scope Identity

Potential conflict identity includes:

* Company
* Document
* Period
* Consolidation Scope
* Canonical Role

### Design Challenge

A simple `ScopeKey` string may be convenient but weakly typed.

### Initial DDL Decision

Store individual known fields where available, plus optional normalized `ScopeKey`.

Final SQL must align with existing Raw Fact model.

---

# 34. Table

# SemanticMappingConflictFacts

## Purpose

One Conflictに関係する複数Raw FactまたはMapping Candidateを関連付ける。

---

## 34.1 Candidate Columns

* `Id`
* `ConflictId`
* `RawFactId`
* `MappingRuleId`
* `CanonicalRoleId`
* `ParticipationTypeCode`
* `CreatedAt`

### Participation Type Candidate

* SourceFact
* MappingCandidate
* Selected
* Rejected
* Overlapping

---

# 35. RawFactId Dependency

This table requires an existing Raw EDINET Fact persistent identity.

### DDL Blocker Check

Before final SQL:

Confirm whether the current project already has a persistent Raw XBRL Fact table.

If not:

`Semantic Mapping DDL implementation cannot fully complete until Raw Fact persistence design exists.`

### Important

Do not invent `RawFactId` target table without reviewing the existing schema.

---

# 36. Table

# SemanticUnmappedConcepts

## Purpose

RuntimeでMappingされなかったSource ConceptをResearch Queueとして蓄積する。

---

## 36.1 Candidate Columns

* `Id`
* `SourceNamespaceUri`
* `SourceLocalName`
* `SampleQName`
* `TaxonomyFamilyCode`
* `TaxonomyVersion`
* `SourceTypeCode`
* `AccountingStandardCode`
* `CompanyCode`
* `EdinetCode`
* `FirstSeenAt`
* `LastSeenAt`
* `OccurrenceCount`
* `SampleDocumentId`
* `SampleContextRef`
* `SampleUnitRef`
* `SampleValue`
* `ReviewStatusCode`
* `CreatedAt`
* `UpdatedAt`

---

# 37. Unmapped Natural Identity

Potential grouping key:

* Source Namespace URI
* Source Local Name
* Company Scope if Company Extension
* Taxonomy Version

### Natural Key Candidate

Standard Concept:

`NamespaceUri + LocalName + TaxonomyVersion`

Company Extension:

`NamespaceUri + LocalName`

Since Extension Namespace already embeds filer / filing identity in many cases.

### Decision

Use Surrogate PK plus controlled unique key after actual EDINET namespace patterns are reviewed.

Do not over-constrain before validating historical extension behavior.

---

# 38. Unmapped Occurrence Aggregation

Repeated unknown facts should update:

* OccurrenceCount
* LastSeenAt

rather than insert unlimited duplicate queue records.

### Purpose

Prioritize frequently occurring unknown Concepts.

---

# 39. Table

# SemanticCanonicalObservationLineages

## Purpose

Canonical ObservationとSource Raw Fact / Mapping Versionのlineageを保持する。

This table answers:

`Why does this Canonical Observation exist?`

---

## 39.1 Candidate Columns

* `Id`
* `CanonicalObservationId`
* `RawFactId`
* `MappingRuleId`
* `CanonicalRoleId`
* `MappingVersion`
* `ReprocessingBatchId`
* `MappedAt`
* `CreatedAt`

---

# 40. CanonicalObservationId Dependency

A Production Canonical Observation table does not yet exist.

Possible future candidates:

* Generic Financial Semantic Observation Table
* Inventory-specific Canonical Observation Table

### Current Decision

Do not finalize FK target yet.

This is a known dependency for later Observation DDL Design.

### Important

The Mapping DDL should not prematurely force Inventory-specific observation storage if the broader Knowledge Base Architecture may use generic semantic observations.

---

# 41. ReprocessingBatchId

Purpose:

Identify Canonical Observations produced by controlled historical reprocessing.

### Dependency

A generic Batch / Reprocessing execution model may already exist.

Before final SQL:

Review existing Batch execution / job history tables.

Do not duplicate infrastructure unnecessarily.

---

# 42. Temporal Table Evaluation

Question:

Should Mapping Tables use SQL Server System-versioned Temporal Tables?

### Candidate Benefits

* Automatic row history
* Easy change audit

### Candidate Risks

* Additional complexity
* Application-level Mapping Version still required
* Temporal history does not explain semantic supersession

### Decision

`Do not rely on Temporal Tables as the primary Mapping Version mechanism.`

Optional Temporal usage may be considered later for operational audit.

Logical Mapping Version remains mandatory.

---

# 43. Soft Delete Evaluation

Recommendation:

`Do not use IsDeleted as primary lifecycle control.`

Use:

* StatusCode
* EffectiveFrom
* EffectiveTo
* SupersededBy

### Reason

Deleted / non-deleted is too weak for governance.

---

# 44. Canonical Role Referential Integrity

`SemanticMappingRules.CanonicalRoleId`

must reference:

`SemanticCanonicalRoles.Id`

### Delete Rule

`RESTRICT / NO ACTION`

Do not cascade delete Roles through Mapping history.

---

# 45. Mapping Scope Referential Integrity

`SemanticMappingScopes.MappingRuleId`

FK to:

`SemanticMappingRules.Id`

### Delete Rule

No hard delete expected.

If physical delete is ever allowed for Draft-only records:

Cascade may be acceptable.

### Initial Recommendation

Use `NO ACTION`.

Lifecycle status rather than deletion.

---

# 46. Evidence Referential Integrity

`SemanticMappingEvidenceReferences.MappingRuleId`

FK to Mapping Rule.

### Delete Rule

`NO ACTION`

Evidence must not disappear when Mapping is superseded.

---

# 47. Conflict Fact Referential Integrity

Conflict related rows should not be deleted if Mapping or Raw Fact is later superseded.

### Recommendation

Use stable retained source records and `NO ACTION`.

---

# 48. Index Strategy

# SemanticCanonicalRoles

Candidate Indexes:

1. Unique:
   `RoleCode + RoleVersion`

2. Filtered Candidate:
   active Role by `RoleCode`

3. Search:
   `DomainCode + StatusCode`

---

# 49. Index Strategy

# SemanticMappingRules

Candidate Indexes:

1. Unique:
   `MappingCode + MappingVersion`

2. Runtime Source Lookup:
   `SourceNamespaceUri + SourceLocalName + StatusCode`

3. Version lookup:
   `TaxonomyFamilyCode + SourceLocalName + StatusCode`

4. Canonical Role:
   `CanonicalRoleId + StatusCode`

5. Supersession:
   `SupersededByMappingRuleId`

### Important

Namespace URI is wide.

Final SQL index design must consider SQL Server key width limits.

Potential solution:

* Persisted Namespace Hash
* Separate Namespace Master
* Include Namespace URI instead of keying directly

### Current Decision

`Index width review required before final CREATE INDEX.`

---

# 50. Namespace Hash Candidate

Potential additional column:

`SourceNamespaceHash`

Purpose:

* Narrow runtime lookup index

Hash candidate:

`SHA-256`

### Important

Hash is not authoritative identity.

Runtime match must verify:

`Hash + Full Namespace URI + Local Name`

### Decision

`OPTIONAL OPTIMIZATION`

Do not add until query volume or index width requires it.

---

# 51. Index Strategy

# SemanticMappingScopes

Candidate:

`MappingRuleId + ScopeTypeCode`

Potential unique rule:

One Mapping Rule should not contain duplicate identical Scope Conditions.

Natural uniqueness candidate:

`MappingRuleId + ScopeTypeCode + ScopeOperatorCode + ScopeValue`

---

# 52. Index Strategy

# SemanticUnmappedConcepts

Candidate:

* ReviewStatusCode
* LastSeenAt
* OccurrenceCount
* TaxonomyVersion
* EdinetCode

Purpose:

Research queue prioritization.

---

# 53. Index Strategy

# SemanticMappingConflicts

Candidate:

* StatusCode + SeverityCode
* ConflictTypeCode + StatusCode
* DocumentId
* EdinetCode
* DetectedAt

---

# 54. Active Mapping Uniqueness

A critical question:

Can multiple Active Mapping Rules exist for the exact same Source Concept?

Answer:

`YES, if scopes are non-overlapping.`

Therefore a simple unique constraint on:

`Namespace + LocalName + Active`

would be incorrect.

### Required Enforcement

Overlap cannot be fully enforced by simple relational unique constraints.

Need:

* Application validation
* DDL constraints where possible
* Activation-time conflict validation

### Principle

`Active mapping scope overlap must be validated before activation.`

---

# 55. Mapping Activation Transaction

Future Production activation should be transactional.

Candidate Flow:

1. Load proposed Mapping Version
2. Validate Reviewer Status
3. Validate Evidence
4. Validate Scope
5. Detect overlap with Active mappings
6. Supersede previous version if required
7. Activate new Mapping
8. Commit

### Runtime implementation deferred.

---

# 56. Mapping Reviewer Fields

Question:

Should reviewer names be stored directly in `SemanticMappingRules`?

### Candidate

* ResearchReviewedBy
* ArchitectureReviewedBy
* ProductionReviewedBy

### Concern

This duplicates reviewer history and creates many nullable fields.

### Initial Decision

Store status / latest reviewed timestamp on Mapping Rule.

Detailed reviewer identity may belong in a future Review History table if required.

### DDL Candidate

Initial Mapping Rule fields:

* ResearchReviewerStatusCode
* ArchitectureReviewerStatusCode
* ProductionReviewerStatusCode
* ReviewedAt

### Future

`SemanticMappingReviewHistories`

when actor-level governance becomes operational.

---

# 57. Mapping Evidence Approval Boundary

Evidence Reference existence alone does not approve a Mapping.

Required:

* Mapping status lifecycle
* Reviewer status
* Active status

### Rule

`Evidence != Activation`

---

# 58. Rejected Decision Table vs Mapping Status Rejected

Question:

Why have both:

* Mapping Rule Status = Rejected
* SemanticRejectedMappingDecisions

### Decision

Use both for different purposes.

### Mapping Rule Rejected

A fully formed Mapping Rule proposal existed and was rejected.

### Rejected Decision Catalog

A semantic candidate decision should remain discoverable even if it never became a formal executable Mapping Rule.

### Initial Cases

Current Research rejected candidates may be stored directly in:

`SemanticRejectedMappingDecisions`

No need to create rejected executable Mapping Rules solely for history.

---

# 59. Canonical Role Versioning

Role Meaning may change.

Examples:

* Description refinement
* Role split
* Role merge
* Scope promotion

### Decision

Use:

`RoleVersion`

### Low-impact change

Description wording correction may not require semantic Role Version increment.

### High-impact change

Semantic boundary change requires new Role Version.

Governance rules to be defined in future Change Management Artifact if needed.

---

# 60. Limited-scope Canonical Role

`SemiFinishedProductsAndWorkInProgress`

has current Kioxia-specific support.

Question:

Should Role scope be stored on Role Master or only Mapping Scope?

### Decision

Primary enforcement belongs to:

`Mapping Scope`

`IsLimitedScope` on Role Master is descriptive governance metadata.

### Reason

The same Role could later receive broader mappings.

Do not hard-code company scope into Role identity.

---

# 61. Mapping Scope and Role Scope Separation

Canonical Role:

`What meaning exists?`

Mapping Scope:

`Where can this Source Concept map to that meaning?`

Therefore:

Company restrictions should normally be encoded on Mapping Rule Scope.

---

# 62. Raw Fact Persistence Dependency

Production Semantic Mapping requires stable Raw Fact persistence.

Required Raw Fact fields include at minimum:

* Fact ID
* Document ID
* Namespace URI
* Local Name
* QName
* ContextRef
* UnitRef
* Decimals
* Raw Value

### Current Dependency Status

`TO BE CONFIRMED AGAINST EXISTING DATABASE`

### Blocker Classification

`DDL IMPLEMENTATION BLOCKER IF NO RAW FACT TABLE EXISTS`

The current DDL Design itself may proceed.

Final SQL and Entity relationship cannot be completed without confirming the Raw Fact persistence model.

---

# 63. Canonical Observation Persistence Dependency

Production Mapping Lineage requires a Canonical Observation target.

Current open question:

Should Inventory Canonical Observations use:

## Option A

Inventory-specific table

## Option B

Generic Semantic Financial Observation table

### Current Architecture Lean

`Option B may provide better long-term extensibility`

However:

This decision affects broader Knowledge Base Architecture and must not be made inside Inventory Mapping DDL alone.

### Decision

`DEFER TO CANONICAL OBSERVATION ARCHITECTURE`

---

# 64. Mapping DDL Implementation Boundary

The following tables can potentially be implemented before Canonical Observation design:

* SemanticCanonicalRoles
* SemanticMappingRules
* SemanticMappingScopes
* SemanticMappingEvidenceReferences
* SemanticRejectedMappingDecisions
* SemanticMappingConflicts
* SemanticUnmappedConcepts

The following depend on broader Raw / Canonical Observation persistence:

* SemanticMappingConflictFacts
* SemanticCanonicalObservationLineages

### Recommendation

DDL implementation may be split into:

`Phase A: Mapping Governance Tables`

and:

`Phase B: Runtime Observation Lineage Tables`

---

# 65. Phase A Candidate

Phase A Tables:

1. SemanticCanonicalRoles
2. SemanticMappingRules
3. SemanticMappingScopes
4. SemanticMappingEvidenceReferences
5. SemanticRejectedMappingDecisions
6. SemanticMappingConflicts
7. SemanticUnmappedConcepts

### Purpose

Enable governed Mapping Master foundation.

---

# 66. Phase B Candidate

Phase B Tables:

1. SemanticMappingConflictFacts
2. SemanticCanonicalObservationLineages

### Dependency

* Raw Fact persistence
* Canonical Observation persistence

---

# 67. Migration Strategy

Initial DDL Migration should not activate mappings automatically.

Candidate sequence:

1. Create Master / Governance tables
2. Seed Canonical Roles
3. Seed Mapping Rules as non-Active
4. Seed Scope
5. Seed Evidence References
6. Seed Rejected Decisions
7. Validate data
8. Separate Production Activation decision

### Principle

`Schema deployment != Mapping activation`

---

# 68. Initial Seed Data Scope

Candidate Seed Data:

## Canonical Roles

8 approved Research Roles.

## Mapping Rules

11 approved Research Mappings.

## Rejected Decisions

4 rejected Mapping Candidates.

### Initial Mapping Status Candidate

`CatalogApproved`

or:

`ProductionApproved`

Question:

Should seed records start Active?

### Decision

`NO`

Recommended initial status:

`CatalogApproved`

until Production validation is completed.

---

# 69. Production Activation Gate

Before Mapping Rule becomes Active:

* DDL deployed
* Seed validated
* Scope validated
* Evidence links validated
* Runtime lookup tested
* Conflict detection tested
* Reviewer approval recorded

### Status progression candidate

`CatalogApproved`

↓

`ProductionApproved`

↓

`Active`

---

# 70. Audit Column Standard

All major governance tables should have:

* CreatedAt
* UpdatedAt where mutable
* ReviewedAt where applicable

### Time Standard

Recommendation:

`UTC`

### Important

Existing project audit conventions must be checked before final SQL.

Do not create inconsistent timestamp conventions.

---

# 71. String Code Case Sensitivity

Codes such as:

* `InventoryTotal`
* `M1`
* `Active`

must be treated consistently.

### Recommendation

Application layer uses canonical casing.

Database uniqueness should account for current collation behavior.

### Final DDL Review

Confirm Azure SQL database collation.

---

# 72. Foreign Key Delete Behavior

General recommendation:

`NO ACTION / RESTRICT`

for governance records.

Avoid cascade deletion of:

* Mapping history
* Evidence
* Conflict history
* Lineage

---

# 73. Data Retention

Semantic Mapping governance records should be retained long-term.

Reason:

* Backtest reproducibility
* Historical dataset lineage
* Auditability
* Taxonomy evolution research

### Retention Candidate

`Indefinite`

subject to future data governance policy.

---

# 74. Security Boundary

Write access to Mapping governance tables should be restricted.

Initial operational model:

`Batch / Admin controlled`

No end-user direct write access.

### Reason

Mapping changes may affect:

* Historical interpretation
* ML datasets
* Backtests

---

# 75. DDL Reviewer Review

## Question 1

Is one Mapping table sufficient?

Decision:

`NO`

Scope, Evidence, Conflict and Unmapped have distinct cardinality and lifecycle requirements.

---

## Question 2

Should Source Concept be a separate master table now?

Reviewer Concern:

Possible normalization opportunity.

### Decision

`NOT YET REQUIRED`

Reason:

Current mapping count is small.

Source Concept identity may later become a reusable master across domains.

Premature Source Concept Master creation risks overlapping broader EDINET Raw Fact Architecture.

---

## Question 3

Should Namespace URI be normalized into a separate table now?

Decision:

`NO`

Keep full URI in Mapping Rule initially.

Revisit if:

* Index width
* volume
* reuse

justify normalization.

---

## Question 4

Should Mapping Scope use fixed columns instead of a generic child table?

Decision:

`GENERIC CHILD TABLE PREFERRED`

Reason:

Future Scope Types may expand.

However:

Activation-time validation must prevent invalid combinations.

---

## Question 5

Should Mapping history rely on Temporal Tables?

Decision:

`NO`

Explicit Mapping Version remains primary.

---

## Question 6

Should Mapping Rules be hard deleted?

Decision:

`NO`

---

## Question 7

Should Rejected Decisions be persisted?

Decision:

`YES`

They are governance evidence.

---

## Question 8

Can Runtime Observation Lineage be finalized now?

Decision:

`NO`

Raw Fact and Canonical Observation persistence dependencies remain unresolved.

---

# 76. DDL Reviewer Decision

### Decision

`APPROVE WITH PHASED IMPLEMENTATION`

### Phase A

`APPROVED FOR FINAL SQL DESIGN`

Tables:

* SemanticCanonicalRoles
* SemanticMappingRules
* SemanticMappingScopes
* SemanticMappingEvidenceReferences
* SemanticRejectedMappingDecisions
* SemanticMappingConflicts
* SemanticUnmappedConcepts

### Phase B

`DEFER`

Tables:

* SemanticMappingConflictFacts
* SemanticCanonicalObservationLineages

Reason:

Raw Fact / Canonical Observation persistence dependencies must be confirmed first.

---

# 77. DDL Definition of Done

DDL Design is complete when:

* Physical table responsibilities are defined
* Surrogate keys are defined
* Natural uniqueness is identified
* Mapping Version model is defined
* Scope child model is defined
* Evidence relationship is defined
* Rejected Decision persistence is defined
* Conflict persistence is defined
* Unmapped queue persistence is defined
* Lineage dependency is identified
* Index candidates are defined
* Delete behavior is defined
* Activation strategy is defined
* Phase A / Phase B split is defined
* DDL Reviewer decision is recorded

### Result

`DEFINITION OF DONE = PASS`

---

# 78. Final DDL Design Decision

### Inventory Semantic Mapping DDL Design

`APPROVED WITH PHASED IMPLEMENTATION`

### Phase A

`READY FOR FINAL DDL SPECIFICATION`

### Phase B

`DEFERRED PENDING OBSERVATION PERSISTENCE REVIEW`

### Next Task

Before writing final `CREATE TABLE`, perform:

`Existing Database Dependency Review`

Required checks:

1. Existing Raw EDINET Fact persistence table
2. Existing Company / EDINET Code master
3. Existing Accounting Standard master
4. Existing Batch / Job History model
5. Existing audit column conventions
6. Existing ID type conventions
7. Existing naming conventions
8. Existing migration strategy

### Important

Do not invent duplicate infrastructure.

The next step must inspect the existing project schema before final SQL DDL is produced.

---

# 79. Exact Next Task

Next Artifact:

`InventorySemanticMappingExistingDatabaseDependencyReview.md`

### Purpose

> Existing Azure SQL / EF Core schemaを確認し、Semantic Mapping DDL Designが既存Master、Raw Fact、Batch History、Audit Convention及びNaming Conventionと重複しないよう依存関係を確定する。

### Review Targets

* Existing DbContext
* Existing Entity classes
* Existing Companies table
* EDINET-related tables if any
* Financial raw fact tables if any
* Batch history tables
* Master table naming conventions
* ID types
* Audit timestamp conventions
* Soft-delete conventions
* Existing migration approach

### Required Decision

For each proposed dependency:

* Reuse Existing
* Extend Existing
* Create New
* Defer

### Current Phase

`DDL Dependency Review`

### Important

Only after this review:

`Final SQL DDL`

↓

`DDL Review`

↓

`Entity Design`
