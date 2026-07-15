# Inventory Semantic Mapping Phase A Final DDL Specification

## 1. Document Purpose

本書は、`InventorySemanticMappingExistingDatabaseDependencyReview.md`で確定したPhase A Semantic Mapping Governance Tablesについて、Azure SQL / SQL Server上へ実装するための最終Physical DDL Specificationを定義する。

本書の目的は以下である。

> Research、Architecture、Catalog及びExisting Database Dependency Reviewで承認されたInventory Semantic Mapping Governance Modelを、既存Stock Analysis SystemのDatabase Conventionと整合する具体的なColumn、SQL Data Type、NULL、Default、Primary Key、Foreign Key、CHECK Constraint、UNIQUE Constraint及びIndexへ変換する。

本書の対象は以下の5テーブルである。

1. `SemanticCanonicalRoles`
2. `SemanticMappingRules`
3. `SemanticMappingScopes`
4. `SemanticMappingEvidenceReferences`
5. `SemanticRejectedMappingDecisions`

本書では以下を行わない。

* Raw EDINET Fact Table設計
* EDINET Filing Table設計
* Runtime Conflict Table設計
* Unmapped Queue設計
* Canonical Observation Lineage設計
* EF Core Entity実装
* Service実装
* Runtime Mapping実装

### Status

* Phase A Final DDL Specification
* Pre-SQL
* Pre-Entity
* DDL Reviewer Pending

---

# 2. Phase A Scope

Phase Aの目的は、

`Runtime Semantic Mapping`

を完成させることではない。

目的は、

`Governed Mapping Master Foundation`

を構築することである。

Phase Aでは以下を永続化する。

* Canonical Semantic Role
* Mapping Rule Version
* Mapping Scope
* Evidence Reference
* Rejected Mapping Decision

### Phase A Does Not Persist

* Raw Fact
* Runtime Mapping Result
* Conflict
* Unmapped Observation
* Canonical Observation
* Reprocessing Lineage

---

# 3. Existing Database Compatibility

本Specificationは以下の既存設計傾向を採用する。

### Table Naming

`PascalCase`

### Primary Key

新規Governance Table:

`int IDENTITY(1,1)`

### Audit Columns

* `CreatedAt`
* `UpdatedAt`
* `ReviewedAt`

### EF Core Integration

Future:

`Explicit Fluent API Configuration`

### Deployment Baseline

`Reviewed SQL DDL executed manually`

followed by:

`Entity / DbContext synchronization`

---

# 4. Common SQL Type Principles

## 4.1 Primary Key

```text
int IDENTITY(1,1)
```

Reason:

* Existing project precedent
* Governance table volume is small
* Sufficient capacity

---

## 4.2 DateTime

Use:

```text
datetime2
```

Do not use:

```text
datetime
```

### Default

For DB-created timestamps:

```text
SYSDATETIME()
```

Important:

Current application uses `DateTime.Now`.

Therefore this specification does not label timestamps as UTC.

---

## 4.3 Boolean

Use:

```text
bit
```

---

## 4.4 Code Fields

Use:

```text
nvarchar
```

with explicit maximum lengths.

Do not use:

```text
varchar
```

because Japanese and multilingual values may appear in descriptions and evidence.

---

# 5. Table

# SemanticCanonicalRoles

## 5.1 Purpose

Canonical Semantic Role Master.

This table defines:

`What normalized semantic meanings exist?`

It does not define Source Concept Mapping.

---

## 5.2 Final Columns

### Id

```text
int
IDENTITY(1,1)
NOT NULL
```

Primary Key.

---

### RoleCode

```text
nvarchar(100)
NOT NULL
```

Examples:

* InventoryTotal
* FinishedGoods
* WorkInProcess
* RawMaterials
* OtherInventories
* MerchandiseAndFinishedGoods
* RawMaterialsAndSupplies
* SemiFinishedProductsAndWorkInProgress

RoleCode is a stable machine-readable business code.

---

### RoleName

```text
nvarchar(200)
NOT NULL
```

Human-readable role name.

---

### DomainCode

```text
nvarchar(100)
NOT NULL
```

Initial value:

`Inventory`

---

### Description

```text
nvarchar(1000)
NOT NULL
```

Canonical Semantic Role meaning.

---

### RoleTypeCode

```text
nvarchar(50)
NOT NULL
```

Allowed:

* Total
* Component
* CombinedComponent
* ResidualComponent

---

### IsCombinedConcept

```text
bit
NOT NULL
DEFAULT 0
```

---

### IsResidualConcept

```text
bit
NOT NULL
DEFAULT 0
```

---

### IsLimitedScope

```text
bit
NOT NULL
DEFAULT 0
```

This is descriptive governance metadata.

Actual enforceable scope belongs to Mapping Scope.

---

### StatusCode

```text
nvarchar(50)
NOT NULL
```

Initial supported Role status:

* Draft
* Approved
* Deprecated
* Superseded

---

### RoleVersion

```text
int
NOT NULL
DEFAULT 1
```

---

### EffectiveFrom

```text
datetime2
NULL
```

---

### EffectiveTo

```text
datetime2
NULL
```

---

### CreatedAt

```text
datetime2
NOT NULL
DEFAULT SYSDATETIME()
```

---

### UpdatedAt

```text
datetime2
NULL
```

---

# 6. SemanticCanonicalRoles Constraints

## Primary Key

```text
PK_SemanticCanonicalRoles
(Id)
```

---

## Unique Constraint

```text
UQ_SemanticCanonicalRoles_RoleCode_RoleVersion
(RoleCode, RoleVersion)
```

---

## CHECK

## RoleTypeCode

Allowed:

```text
Total
Component
CombinedComponent
ResidualComponent
```

---

## CHECK

## StatusCode

Allowed:

```text
Draft
Approved
Deprecated
Superseded
```

---

## CHECK

## RoleVersion

```text
RoleVersion > 0
```

---

## CHECK

## Effective Boundary

If both values exist:

```text
EffectiveTo >= EffectiveFrom
```

---

## CHECK

## Combined Role Consistency

If:

```text
RoleTypeCode = CombinedComponent
```

then:

```text
IsCombinedConcept = 1
```

### Decision

This may be enforced by CHECK Constraint.

---

## CHECK

## Residual Role Consistency

If:

```text
RoleTypeCode = ResidualComponent
```

then:

```text
IsResidualConcept = 1
```

---

# 7. SemanticCanonicalRoles Indexes

## Index 1

Unique:

```text
RoleCode
RoleVersion
```

implemented by Unique Constraint.

---

## Index 2

```text
IX_SemanticCanonicalRoles_DomainCode_StatusCode
(DomainCode, StatusCode)
```

Purpose:

Role Catalog lookup.

---

# 8. Table

# SemanticMappingRules

## 8.1 Purpose

Approved Mapping Rule Versionを保持する。

This table defines:

`Which Source Concept may map to which Canonical Semantic Role?`

---

# 9. SemanticMappingRules Final Columns

### Id

```text
int
IDENTITY(1,1)
NOT NULL
```

Primary Key.

---

### MappingCode

```text
nvarchar(50)
NOT NULL
```

Examples:

* MAP-INV-001
* MAP-INV-011

---

### MappingVersion

```text
int
NOT NULL
DEFAULT 1
```

---

### SourceNamespaceUri

```text
nvarchar(1000)
NOT NULL
```

Authoritative Namespace identity.

---

### SourceLocalName

```text
nvarchar(300)
NOT NULL
```

Authoritative Local Name.

---

### SourceQName

```text
nvarchar(500)
NULL
```

Audit / display field.

QName is not authoritative identity.

---

### TaxonomyFamilyCode

```text
nvarchar(100)
NULL
```

Examples:

* jppfs
* jpigp
* CompanyExtension

---

### SourceTypeCode

```text
nvarchar(50)
NOT NULL
```

Allowed:

* StandardTaxonomy
* CompanyExtension
* OtherExtension
* Unknown

---

### AccountingStandardCode

```text
nvarchar(50)
NULL
```

Examples:

* JapaneseGAAP
* IFRS

Nullable to preserve future flexibility for Source Concepts where Accounting Standard is not applicable or unresolved.

---

### CanonicalRoleId

```text
int
NOT NULL
```

FK to:

`SemanticCanonicalRoles.Id`

---

### MappingClassCode

```text
nvarchar(10)
NOT NULL
```

Allowed:

* M1
* M2
* M3
* M4

M5 is not an executable Mapping Rule.

---

### StatusCode

```text
nvarchar(50)
NOT NULL
```

Allowed:

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

---

### ResearchReviewerStatusCode

```text
nvarchar(50)
NOT NULL
DEFAULT 'Pending'
```

Allowed:

* Pending
* Approve
* ConditionalApprove
* Reject
* Defer

---

### ArchitectureReviewerStatusCode

```text
nvarchar(50)
NOT NULL
DEFAULT 'Pending'
```

Allowed:

* Pending
* Approve
* ConditionalApprove
* Reject
* Defer
* NotRequired

---

### ProductionReviewerStatusCode

```text
nvarchar(50)
NOT NULL
DEFAULT 'Pending'
```

Allowed:

* Pending
* Approve
* ConditionalApprove
* Reject
* Defer

---

### EffectiveFrom

```text
datetime2
NULL
```

---

### EffectiveTo

```text
datetime2
NULL
```

---

### SupersededByMappingRuleId

```text
int
NULL
```

Self FK.

---

### ReviewedAt

```text
datetime2
NULL
```

---

### CreatedAt

```text
datetime2
NOT NULL
DEFAULT SYSDATETIME()
```

---

### UpdatedAt

```text
datetime2
NULL
```

---

# 10. SemanticMappingRules Constraints

## Primary Key

```text
PK_SemanticMappingRules
(Id)
```

---

## Unique Constraint

```text
UQ_SemanticMappingRules_MappingCode_MappingVersion
(MappingCode, MappingVersion)
```

---

## FK

```text
CanonicalRoleId
→ SemanticCanonicalRoles.Id
```

Delete behavior:

`NO ACTION`

---

## Self FK

```text
SupersededByMappingRuleId
→ SemanticMappingRules.Id
```

Delete behavior:

`NO ACTION`

---

## CHECK

## MappingVersion

```text
MappingVersion > 0
```

---

## CHECK

## SourceTypeCode

Allowed:

```text
StandardTaxonomy
CompanyExtension
OtherExtension
Unknown
```

---

## CHECK

## MappingClassCode

Allowed:

```text
M1
M2
M3
M4
```

---

## CHECK

## StatusCode

Allowed lifecycle values.

---

## CHECK

## Reviewer Status Codes

Each Reviewer Status must use its approved enum set.

---

## CHECK

## Effective Boundary

If both exist:

```text
EffectiveTo >= EffectiveFrom
```

---

## CHECK

## Supersession Self-reference

```text
SupersededByMappingRuleId <> Id
```

when not null.

---

## CHECK

## M4 Active Prohibition

A Mapping Class:

`M4`

must not have:

`StatusCode = Active`

### Decision

Enforce by CHECK Constraint.

---

## CHECK

## Active Mapping Reviewer Requirement

An Active Mapping must satisfy:

```text
ResearchReviewerStatusCode IN ('Approve', 'ConditionalApprove')
```

and:

```text
ArchitectureReviewerStatusCode IN
(
    'Approve',
    'ConditionalApprove',
    'NotRequired'
)
```

and:

```text
ProductionReviewerStatusCode IN
(
    'Approve',
    'ConditionalApprove'
)
```

### Decision

Enforce by CHECK Constraint.

This prevents accidental activation without reviewer approval.

---

# 11. SemanticMappingRules Indexes

## Index 1

Unique:

```text
MappingCode
MappingVersion
```

---

## Index 2

## Source Lookup

```text
IX_SemanticMappingRules_SourceIdentity_Status
(
    SourceLocalName,
    StatusCode
)
```

Include candidate:

* SourceNamespaceUri
* CanonicalRoleId
* MappingClassCode
* MappingVersion

### Important

Full Namespace URI is not placed directly in the key at this stage due to index width concerns.

Runtime must verify full Namespace URI.

---

## Index 3

## Canonical Role Lookup

```text
IX_SemanticMappingRules_CanonicalRoleId_StatusCode
(
    CanonicalRoleId,
    StatusCode
)
```

---

## Index 4

## Source Family Lookup

```text
IX_SemanticMappingRules_TaxonomyFamily_LocalName_Status
(
    TaxonomyFamilyCode,
    SourceLocalName,
    StatusCode
)
```

---

# 12. Namespace Lookup Decision

Initial DDL will not introduce:

`SourceNamespaceHash`

### Reason

Phase A mapping volume is very small.

### Future Trigger

Add hash or Namespace Master only if:

* Runtime lookup volume
* Index width
* Cross-domain reuse

justify it.

### Runtime Correctness Rule

Any candidate lookup by Local Name must verify:

`SourceNamespaceUri`

before accepting a Mapping.

---

# 13. Table

# SemanticMappingScopes

## 13.1 Purpose

Mapping Ruleに対するcompositional applicability conditionsを保持する。

One Mapping Rule may have:

`0..many Scope Conditions`

No scope rows:

`Global within the Source Concept and Mapping effective boundary`

---

# 14. SemanticMappingScopes Final Columns

### Id

```text
int
IDENTITY(1,1)
NOT NULL
```

---

### MappingRuleId

```text
int
NOT NULL
```

FK.

---

### ScopeTypeCode

```text
nvarchar(50)
NOT NULL
```

Allowed:

* TaxonomyFamily
* TaxonomyVersion
* AccountingStandard
* CompanyCode
* EdinetCode
* FilingFamily
* Namespace

---

### ScopeOperatorCode

```text
nvarchar(50)
NOT NULL
DEFAULT 'Equals'
```

Initial allowed:

* Equals
* FromInclusive
* ToInclusive
* BetweenInclusive

---

### ScopeValue

```text
nvarchar(1000)
NULL
```

Used mainly for:

`Equals`

---

### ScopeValueFrom

```text
nvarchar(1000)
NULL
```

---

### ScopeValueTo

```text
nvarchar(1000)
NULL
```

---

### IsRequired

```text
bit
NOT NULL
DEFAULT 1
```

Initial Phase A:

All scope conditions are expected to be required.

This column remains for future extensibility.

---

### CreatedAt

```text
datetime2
NOT NULL
DEFAULT SYSDATETIME()
```

---

# 15. SemanticMappingScopes Constraints

## Primary Key

```text
PK_SemanticMappingScopes
(Id)
```

---

## FK

```text
MappingRuleId
→ SemanticMappingRules.Id
```

Delete behavior:

`NO ACTION`

---

## CHECK

## ScopeTypeCode

Allowed initial values.

---

## CHECK

## ScopeOperatorCode

Allowed:

* Equals
* FromInclusive
* ToInclusive
* BetweenInclusive

---

## CHECK

## Scope Value Structure

### Equals

Requires:

```text
ScopeValue IS NOT NULL
```

and:

```text
ScopeValueFrom IS NULL
ScopeValueTo IS NULL
```

### FromInclusive

Requires:

```text
ScopeValueFrom IS NOT NULL
```

### ToInclusive

Requires:

```text
ScopeValueTo IS NOT NULL
```

### BetweenInclusive

Requires both:

```text
ScopeValueFrom IS NOT NULL
ScopeValueTo IS NOT NULL
```

---

# 16. SemanticMappingScopes Unique Constraint

Prevent exact duplicate scope condition.

Candidate unique index:

```text
MappingRuleId
ScopeTypeCode
ScopeOperatorCode
ScopeValue
ScopeValueFrom
ScopeValueTo
```

### SQL Server NULL Concern

Unique handling with multiple nullable values is cumbersome.

### Decision

Do not create a broad unique constraint across nullable scope columns.

Instead create:

```text
IX_SemanticMappingScopes_MappingRuleId_ScopeTypeCode
```

and enforce exact duplicate prevention in application / seed validation.

---

# 17. SemanticMappingScopes Indexes

## Index 1

```text
IX_SemanticMappingScopes_MappingRuleId
(MappingRuleId)
```

---

## Index 2

```text
IX_SemanticMappingScopes_MappingRuleId_ScopeTypeCode
(
    MappingRuleId,
    ScopeTypeCode
)
```

---

# 18. Table

# SemanticMappingEvidenceReferences

## 18.1 Purpose

Mapping RuleとEvidence Artifactのrelationshipを保持する。

One Mapping Rule may reference:

`many Evidence Artifacts`

---

# 19. SemanticMappingEvidenceReferences Final Columns

### Id

```text
int
IDENTITY(1,1)
NOT NULL
```

---

### MappingRuleId

```text
int
NOT NULL
```

FK.

---

### EvidenceCode

```text
nvarchar(50)
NOT NULL
```

Examples:

* EV-INV-001
* EV-INV-002

---

### EvidenceTypeCode

```text
nvarchar(50)
NOT NULL
```

Allowed:

* ResearchSheet
* CrossStandardEvidence
* ConsolidationReview
* ArchitectureArtifact
* PrimarySourceReference

---

### ArtifactPath

```text
nvarchar(1000)
NOT NULL
```

Repository-relative path.

---

### EvidenceDescription

```text
nvarchar(1000)
NULL
```

---

### EvidenceVersion

```text
nvarchar(100)
NULL
```

---

### ReviewerDecisionCode

```text
nvarchar(50)
NULL
```

Allowed when populated:

* Approve
* ConditionalApprove
* Reject
* Defer

---

### ReviewedAt

```text
datetime2
NULL
```

---

### CreatedAt

```text
datetime2
NOT NULL
DEFAULT SYSDATETIME()
```

---

# 20. SemanticMappingEvidenceReferences Constraints

## Primary Key

```text
PK_SemanticMappingEvidenceReferences
(Id)
```

---

## FK

```text
MappingRuleId
→ SemanticMappingRules.Id
```

Delete behavior:

`NO ACTION`

---

## Unique Constraint

```text
UQ_SemanticMappingEvidenceReferences_EvidenceCode
(EvidenceCode)
```

---

## CHECK

## EvidenceTypeCode

Allowed values from Catalog.

---

## CHECK

## ReviewerDecisionCode

If not null:

approved decision codes only.

---

# 21. SemanticMappingEvidenceReferences Indexes

## Index

```text
IX_SemanticMappingEvidenceReferences_MappingRuleId
(MappingRuleId)
```

---

# 22. Table

# SemanticRejectedMappingDecisions

## 22.1 Purpose

Rejected Mapping Candidate Decisionを永続化する。

This table is Governance History.

It is not an executable Mapping table.

---

# 23. SemanticRejectedMappingDecisions Final Columns

### Id

```text
int
IDENTITY(1,1)
NOT NULL
```

---

### DecisionCode

```text
nvarchar(50)
NOT NULL
```

Examples:

* REJ-INV-001
* REJ-INV-004

---

### DecisionVersion

```text
int
NOT NULL
DEFAULT 1
```

---

### SourceNamespaceUri

```text
nvarchar(1000)
NOT NULL
```

---

### SourceLocalName

```text
nvarchar(300)
NOT NULL
```

---

### SourceQName

```text
nvarchar(500)
NULL
```

---

### RejectedCanonicalRoleCode

```text
nvarchar(100)
NOT NULL
```

Role Code is stored rather than Role FK.

### Reason

The rejected Role may:

* later be deprecated
* not exist as an approved Role
* represent a historical candidate

Governance history should remain independent.

---

### ReplacementCanonicalRoleCode

```text
nvarchar(100)
NULL
```

---

### ReasonCode

```text
nvarchar(100)
NOT NULL
```

Initial examples:

* MaterialInformationLoss
* SemanticUnderSpecification
* UnsupportedSimplification
* FalseSemanticEquivalenceRisk

---

### ReasonDescription

```text
nvarchar(2000)
NOT NULL
```

---

### EvidenceArtifactPath

```text
nvarchar(1000)
NOT NULL
```

---

### DecisionStatusCode

```text
nvarchar(50)
NOT NULL
DEFAULT 'Active'
```

Allowed:

* Active
* Reopened
* Superseded

---

### ReviewedAt

```text
datetime2
NULL
```

---

### CreatedAt

```text
datetime2
NOT NULL
DEFAULT SYSDATETIME()
```

---

### UpdatedAt

```text
datetime2
NULL
```

---

# 24. SemanticRejectedMappingDecisions Constraints

## Primary Key

```text
PK_SemanticRejectedMappingDecisions
(Id)
```

---

## Unique Constraint

```text
UQ_SemanticRejectedMappingDecisions_DecisionCode_DecisionVersion
(
    DecisionCode,
    DecisionVersion
)
```

---

## CHECK

## DecisionVersion

```text
DecisionVersion > 0
```

---

## CHECK

## DecisionStatusCode

Allowed:

* Active
* Reopened
* Superseded

---

# 25. SemanticRejectedMappingDecisions Indexes

## Index 1

```text
IX_SemanticRejectedMappingDecisions_SourceLocalName
(SourceLocalName)
```

---

## Index 2

```text
IX_SemanticRejectedMappingDecisions_RejectedCanonicalRoleCode
(RejectedCanonicalRoleCode)
```

---

# 26. Foreign Key Delete Policy

For all Phase A foreign keys:

```text
ON DELETE NO ACTION
```

### Reason

Governance history must not disappear through cascading deletion.

---

# 27. Hard Delete Policy

Hard Delete is prohibited for:

* Approved Canonical Roles
* Mapping Rules
* Evidence References
* Rejected Decisions

Draft records may theoretically be deleted before approval.

### Initial Implementation Recommendation

Do not expose generic delete operations.

Use status lifecycle instead.

---

# 28. Seed Strategy

Initial Seed Order:

1. `SemanticCanonicalRoles`
2. `SemanticMappingRules`
3. `SemanticMappingScopes`
4. `SemanticMappingEvidenceReferences`
5. `SemanticRejectedMappingDecisions`

---

# 29. Initial Canonical Role Seed Set

Seed the following 8 Roles.

## ROLE-1

`InventoryTotal`

Status:

`Approved`

Version:

`1`

---

## ROLE-2

`FinishedGoods`

Status:

`Approved`

Version:

`1`

---

## ROLE-3

`WorkInProcess`

Status:

`Approved`

Version:

`1`

---

## ROLE-4

`RawMaterials`

Status:

`Approved`

Version:

`1`

---

## ROLE-5

`OtherInventories`

Status:

`Approved`

Version:

`1`

---

## ROLE-6

`MerchandiseAndFinishedGoods`

Status:

`Approved`

Version:

`1`

---

## ROLE-7

`RawMaterialsAndSupplies`

Status:

`Approved`

Version:

`1`

---

## ROLE-8

`SemiFinishedProductsAndWorkInProgress`

Status:

`Approved`

Version:

`1`

IsLimitedScope:

`true`

### Important

Role itself is not company-scoped.

The limited scope is enforced through Mapping Scope.

---

# 30. Initial Mapping Rule Seed Set

Seed:

`MAP-INV-001` through `MAP-INV-011`

### Initial MappingVersion

`1`

### Initial Status

`CatalogApproved`

### Important

Do not seed as:

`Active`

### Reason

Runtime:

* Scope matching
* Conflict handling
* Fact eligibility

is not yet implemented.

---

# 31. Initial Reviewer Status Seed

For already reviewed Research mappings:

### ResearchReviewerStatusCode

`Approve`

### ArchitectureReviewerStatusCode

Either:

`Approve`

or:

`NotRequired`

based on the individual Mapping Research decision.

### ProductionReviewerStatusCode

`Pending`

### Therefore

Status remains:

`CatalogApproved`

---

# 32. M3 Kioxia Mapping Scope Seed

Mapping:

`MAP-INV-011`

Required Scope rows:

## Scope 1

```text
ScopeTypeCode = EdinetCode
ScopeOperatorCode = Equals
ScopeValue = E35948
```

## Scope 2

```text
ScopeTypeCode = AccountingStandard
ScopeOperatorCode = Equals
ScopeValue = IFRS
```

## Scope 3

Namespace Scope.

### Important

The exact extension Namespace includes filing-specific date information.

Using one exact full Namespace could make the Mapping valid only for one Filing.

Therefore the Phase A seed must not invent a broad namespace wildcard.

### Decision

For initial Catalog seed:

Use only:

* EDINET Code
* Accounting Standard

and preserve exact Source Namespace URI on the Mapping Rule.

### Future Filing Version Issue

A new Kioxia annual report may use a different extension Namespace URI.

This Mapping must then be:

* reviewed
* versioned
* extended

Do not use Regex or Prefix matching yet.

This is deliberately conservative.

---

# 33. Taxonomy Version Scope Seed

Research reviewed certain Taxonomy Versions.

However:

Current SourceNamespaceUri itself often contains Taxonomy Version for standard concepts.

### Decision

Do not duplicate Taxonomy Version Scope rows in the first seed unless:

`TaxonomyVersion`

is separately available and normalized in the source runtime.

### Mapping Rule

Preserve:

* SourceNamespaceUri
* TaxonomyFamilyCode

Future runtime architecture may add explicit Taxonomy Version extraction.

---

# 34. Source Namespace Seed Requirement

Every initial Mapping Rule must store the exact approved Namespace URI.

Examples include:

* J-GAAP Taxonomy Namespace
* IFRS Taxonomy Namespace
* Kioxia Extension Namespace

### Important

Do not seed only QName.

---

# 35. Initial Evidence Seed Strategy

Not every possible Research Artifact must be seeded immediately.

Minimum:

Each Mapping Rule must have at least:

`1 primary Mapping Research Sheet`

Cross-standard mappings should additionally reference:

`Cross-standard Official Taxonomy Evidence`

where available.

### Validation Rule

Before future Production activation:

Every Mapping Rule must have:

`at least one Evidence Reference`

---

# 36. Initial Rejected Decision Seed Set

Seed 4 records.

## REJ-INV-001

`MerchandiseAndFinishedGoods`

→ rejected `FinishedGoods`

---

## REJ-INV-002

`RawMaterialsAndSupplies`

→ rejected `RawMaterials`

---

## REJ-INV-003

`OtherInventoriesCAIFRS`

→ rejected `Other`

---

## REJ-INV-004

`SemiFinishedProductsAndWorkInProgressCAIFRS`

→ rejected `WorkInProcess`

---

# 37. Seed Transaction Requirement

Initial Phase A seed should run inside one transaction.

### Order

1. Insert Canonical Roles
2. Resolve Role IDs
3. Insert Mapping Rules
4. Insert Scope
5. Insert Evidence
6. Insert Rejected Decisions
7. Validate counts
8. Commit

### Failure

Rollback entire seed.

---

# 38. Seed Idempotency Requirement

DDL deployment and seed deployment may be rerun in development.

Therefore seed script should not blindly duplicate records.

Recommended approach:

* Check by Natural Key
* Insert if missing
* Fail on semantic mismatch

### Important

Do not silently overwrite an existing Mapping Version.

---

# 39. Expected Initial Row Counts

After successful initial seed:

### SemanticCanonicalRoles

`8`

### SemanticMappingRules

`11`

### SemanticMappingScopes

At least:

`2`

for initial Kioxia M3 Mapping.

Additional scopes only if explicitly approved.

### SemanticRejectedMappingDecisions

`4`

### SemanticMappingEvidenceReferences

`>= 11`

minimum one per Mapping.

---

# 40. Deployment Validation Queries

After Phase A DDL and seed:

Validate:

### Canonical Role Count

`8`

### Mapping Rule Count

`11`

### Rejected Decision Count

`4`

### Duplicate Mapping Code / Version

`0`

### Mapping Rule Without Canonical Role

`0`

### Mapping Rule Without Evidence

`0`

### Active Mapping Count

`0`

Expected before Runtime implementation.

---

# 41. Active Mapping Safety Check

After initial deployment:

```text
Active Mapping Count = 0
```

must be explicitly confirmed.

### Reason

Runtime activation is a separate future gate.

---

# 42. DDL Constraint Philosophy

Database constraints should enforce:

* Structural validity
* Controlled enum values
* Reviewer minimum for Active status
* Version positivity
* FK integrity
* Effective boundary validity

Database should not attempt to enforce:

* Semantic equivalence
* Scope overlap
* Mapping evidence sufficiency beyond simple existence
* Cross-concept overlap

Those require application governance and review logic.

---

# 43. Scope Overlap Enforcement

SQL constraint alone cannot reliably detect overlapping compositional Scope Rules.

### Therefore

Before a Mapping becomes:

`Active`

application validation must check:

* Existing Active Mapping candidates
* Scope overlap
* Version overlap
* Source Concept overlap

### Phase A

No Mapping is Active.

Therefore activation validator can be implemented later before Runtime activation.

---

# 44. Current Known Non-goals

Phase A does not solve:

* new EDINET Concept auto-discovery
* raw XBRL persistence
* runtime semantic mapping
* conflict queue
* unmapped queue
* canonical observation persistence
* historical reprocessing

This is intentional.

---

# 45. EF Core Future Mapping Notes

Entity Design should later follow these physical decisions.

Likely Entity classes:

* `SemanticCanonicalRole`
* `SemanticMappingRule`
* `SemanticMappingScope`
* `SemanticMappingEvidenceReference`
* `SemanticRejectedMappingDecision`

### Important

Entity Design occurs only after:

* SQL DDL approval
* Database application

---

# 46. Final DDL Reviewer Review

## Question 1

Are SQL types explicit?

`YES`

## Question 2

Are nullable fields explicit?

`YES`

## Question 3

Are PK and FK decisions explicit?

`YES`

## Question 4

Are controlled code constraints defined?

`YES`

## Question 5

Is Mapping activation guarded?

`YES`

## Question 6

Is M4 prevented from becoming Active?

`YES`

## Question 7

Is Mapping history preserved?

`YES`

## Question 8

Are hard deletes avoided?

`YES`

## Question 9

Is Phase A independent from Raw Fact persistence?

`YES`

## Question 10

Are operational tables still deferred?

`YES`

---

# 47. DDL Reviewer Decision

### Decision

`APPROVE`

### Phase A Final DDL Specification

`APPROVED FOR SQL GENERATION`

### Approved Tables

1. `SemanticCanonicalRoles`
2. `SemanticMappingRules`
3. `SemanticMappingScopes`
4. `SemanticMappingEvidenceReferences`
5. `SemanticRejectedMappingDecisions`

### Initial Seed

`APPROVED FOR SQL GENERATION`

### Runtime Activation

`NOT APPROVED`

---

# 48. Definition of Done

The Final DDL Specification is complete when:

* 5 table definitions are finalized
* exact SQL types are defined
* nullability is defined
* defaults are defined
* primary keys are defined
* foreign keys are defined
* check constraints are defined
* indexes are defined
* seed strategy is defined
* initial row counts are defined
* deployment validation is defined
* active mapping count is required to remain zero
* DDL Reviewer approval is recorded

### Result

`DEFINITION OF DONE = PASS`

---

# 49. Final Decision

### Phase A Governance DDL

`APPROVED`

### Next Step

Generate:

`InventorySemanticMappingPhaseADDL.sql`

### SQL Script Scope

The SQL script should include:

1. `CREATE TABLE`
2. `ALTER TABLE / CONSTRAINT`
3. `CREATE INDEX`
4. Initial Canonical Role Seed
5. Initial Mapping Rule Seed
6. Initial Mapping Scope Seed
7. Initial Evidence Reference Seed
8. Rejected Mapping Decision Seed
9. Validation Queries

### Important

The SQL script must:

* be transaction-safe
* avoid duplicate seed insertion
* not activate mappings
* include Japanese comments
* separate DDL and Seed sections clearly

### After SQL Review

Sequence:

`SQL DDL`

↓

`User Review`

↓

`Execute on Azure SQL`

↓

`Validate Counts`

↓

`Entity Design`
