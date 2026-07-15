# Inventory Semantic Mapping Phase A Entity Design

## 1. Document Purpose

本書は、Azure SQLへ適用済みのInventory Semantic Mapping Phase A
Governance Tablesについて、EF Core Entity及びDbContext
Mappingを実装する前に、Entity責務、Property型、Nullability、Navigation
Property、Delete Behavior及びFluent API方針を確定するEntity Design
Artifactである。

対象Tableは以下の5つである。

1.  `SemanticCanonicalRoles`
2.  `SemanticMappingRules`
3.  `SemanticMappingScopes`
4.  `SemanticMappingEvidenceReferences`
5.  `SemanticRejectedMappingDecisions`

本書では以下をまだ実装しない。

-   Runtime Semantic Mapping Service
-   Raw EDINET Fact Entity
-   Conflict Entity
-   Unmapped Queue Entity
-   Canonical Observation Entity
-   Mapping Activation Service

### Status

-   Entity Design
-   Database Applied
-   Pre-Entity Implementation
-   Pre-DbContext Integration
-   Entity Reviewer Pending

------------------------------------------------------------------------

## 2. Design Inputs

本Entity Designは以下を前提とする。

-   `InventorySemanticMappingProductionArchitecture.md`
-   `InventorySemanticMappingCatalog.md`
-   `InventorySemanticMappingDDLDesign.md`
-   `InventorySemanticMappingExistingDatabaseDependencyReview.md`
-   `InventorySemanticMappingPhaseAFinalDDLSpecification.md`
-   Applied `InventorySemanticMappingPhaseADDL.sql`

Database Validation Result:

-   Canonical Roles: `8`
-   Mapping Rules: `11`
-   Mapping Scopes: `2`
-   Evidence References: `11`
-   Rejected Decisions: `4`
-   Active Mappings: `0`

### Database Apply Status

`PASS`

------------------------------------------------------------------------

## 3. Entity Design Principles

### 3.1 Database Is the Current Physical Source of Truth

The SQL DDL has already been applied successfully.

Therefore:

`Entity must reflect the approved physical schema.`

Do not redesign the database through Entity convenience.

### 3.2 Entity Names Are Singular

  --------------------------------------------------------------------------
  Table                                 Entity
  ------------------------------------- ------------------------------------
  `SemanticCanonicalRoles`              `SemanticCanonicalRole`

  `SemanticMappingRules`                `SemanticMappingRule`

  `SemanticMappingScopes`               `SemanticMappingScope`

  `SemanticMappingEvidenceReferences`   `SemanticMappingEvidenceReference`

  `SemanticRejectedMappingDecisions`    `SemanticRejectedMappingDecision`
  --------------------------------------------------------------------------

### 3.3 Nullable Reference Types Must Match Database Nullability

Examples:

Database:

`SourceQName NULL`

C#:

`string? SourceQName`

Database:

`RoleCode NOT NULL`

C#:

`string RoleCode = string.Empty;`

Entity Nullability must not be changed merely for implementation
convenience.

### 3.4 Database-generated Identity Keys

All five Entities use `int Id`.

The database generates `IDENTITY(1,1)`.

EF Core must treat `Id` as generated on add.

### 3.5 No Business Logic in Entity Classes

Entity classes should represent persistence state.

Do not put the following logic inside Entity methods at this phase.

-   Mapping resolution logic
-   Status transition logic
-   Scope evaluation logic
-   Reviewer approval logic
-   Production activation logic
-   Canonicalization logic
-   Conflict resolution logic

These responsibilities belong to future application or domain services.

### 3.6 Entity Design Must Preserve Governance Boundaries

Phase A Entities represent Governance Data.

They do not represent:

-   Raw EDINET Facts
-   Runtime Mapping Results
-   Canonical Financial Observations
-   Mapping Conflicts
-   Unmapped Concepts

The Entity model must not prematurely merge Governance Data and Runtime
Data.

------------------------------------------------------------------------

## 4. Entity: SemanticCanonicalRole

### 4.1 Purpose

Represents one version of a Canonical Semantic Role.

A Canonical Semantic Role defines the normalized semantic destination
used by Semantic Mapping Rules.

Examples:

-   `InventoryTotal`
-   `FinishedGoods`
-   `WorkInProcess`
-   `RawMaterials`
-   `OtherInventories`
-   `MerchandiseAndFinishedGoods`
-   `RawMaterialsAndSupplies`
-   `SemiFinishedProductsAndWorkInProgress`

### Class Name

`SemanticCanonicalRole`

### Table

`SemanticCanonicalRoles`

### 4.2 Properties

``` csharp
public int Id { get; set; }

public string RoleCode { get; set; } = string.Empty;

public string RoleName { get; set; } = string.Empty;

public string DomainCode { get; set; } = string.Empty;

public string Description { get; set; } = string.Empty;

public string RoleTypeCode { get; set; } = string.Empty;

public bool IsCombinedConcept { get; set; }

public bool IsResidualConcept { get; set; }

public bool IsLimitedScope { get; set; }

public string StatusCode { get; set; } = string.Empty;

public int RoleVersion { get; set; }

public DateTime? EffectiveFrom { get; set; }

public DateTime? EffectiveTo { get; set; }

public DateTime CreatedAt { get; set; }

public DateTime? UpdatedAt { get; set; }
```

### 4.3 Navigation Properties

A Canonical Role may have many Mapping Rules.

``` csharp
public ICollection<SemanticMappingRule> MappingRules { get; set; }
    = new List<SemanticMappingRule>();
```

Relationship:

``` text
SemanticCanonicalRole
    1
    |
    |
    N
SemanticMappingRule
```

### Decision

`APPROVE`

------------------------------------------------------------------------

## 5. SemanticCanonicalRole Fluent API

Required configuration:

-   `ToTable("SemanticCanonicalRoles")`
-   `HasKey(x => x.Id)`
-   `ValueGeneratedOnAdd()`
-   Max lengths
-   Required fields
-   Unique index on `RoleCode + RoleVersion`
-   Index on `DomainCode + StatusCode`

### Unique Constraint

``` text
RoleCode
+
RoleVersion
```

This preserves Canonical Role version identity.

### Important

Database CHECK Constraints already exist.

EF Core does not need to duplicate every semantic enum-like validation
rule in application code at this stage.

The physical database remains responsible for enforcing the applied
CHECK Constraints.

Application-level validation may later use:

-   Constants
-   Domain enums
-   Validation services
-   Governance services

------------------------------------------------------------------------

## 6. Entity: SemanticMappingRule

### 6.1 Purpose

Represents one Mapping Rule Version from a Source Concept Identity to a
Canonical Semantic Role.

The Source Concept Identity is primarily represented by:

-   `SourceNamespaceUri`
-   `SourceLocalName`

`SourceQName` is retained as supporting identity and diagnostic
information.

A Mapping Rule also contains:

-   Mapping Class
-   Governance Status
-   Reviewer Status
-   Effective Period
-   Version Lineage

### Class Name

`SemanticMappingRule`

### Table

`SemanticMappingRules`

### 6.2 Properties

``` csharp
public int Id { get; set; }

public string MappingCode { get; set; } = string.Empty;

public int MappingVersion { get; set; }

public string SourceNamespaceUri { get; set; } = string.Empty;

public string SourceLocalName { get; set; } = string.Empty;

public string? SourceQName { get; set; }

public string? TaxonomyFamilyCode { get; set; }

public string SourceTypeCode { get; set; } = string.Empty;

public string? AccountingStandardCode { get; set; }

public int CanonicalRoleId { get; set; }

public string MappingClassCode { get; set; } = string.Empty;

public string StatusCode { get; set; } = string.Empty;

public string ResearchReviewerStatusCode { get; set; } = string.Empty;

public string ArchitectureReviewerStatusCode { get; set; } = string.Empty;

public string ProductionReviewerStatusCode { get; set; } = string.Empty;

public DateTime? EffectiveFrom { get; set; }

public DateTime? EffectiveTo { get; set; }

public int? SupersededByMappingRuleId { get; set; }

public DateTime? ReviewedAt { get; set; }

public DateTime CreatedAt { get; set; }

public DateTime? UpdatedAt { get; set; }
```

------------------------------------------------------------------------

## 7. SemanticMappingRule Navigation Properties

### 7.1 Canonical Role

``` csharp
public SemanticCanonicalRole CanonicalRole { get; set; } = null!;
```

Relationship:

``` text
Many SemanticMappingRules
→
One SemanticCanonicalRole
```

Foreign Key:

``` text
SemanticMappingRule.CanonicalRoleId
→
SemanticCanonicalRole.Id
```

### 7.2 Superseded Mapping Rule

Mapping Rule version lineage is represented through a self-reference.

``` csharp
public SemanticMappingRule? SupersededByMappingRule { get; set; }
```

Inverse navigation:

``` csharp
public ICollection<SemanticMappingRule> SupersededMappingRules { get; set; }
    = new List<SemanticMappingRule>();
```

### Decision

Use both navigations.

### Reason

This supports future inspection of Mapping Rule lineage.

Example:

``` text
Mapping Rule Version 1
    ↓ superseded by
Mapping Rule Version 2
```

The relationship is informational and governance-oriented.

It must not introduce cascade deletion.

### 7.3 Mapping Scopes

``` csharp
public ICollection<SemanticMappingScope> Scopes { get; set; }
    = new List<SemanticMappingScope>();
```

One Mapping Rule may require multiple Scope Conditions.

Example:

``` text
Mapping Rule
    ├── EdinetCode = E35948
    └── AccountingStandard = IFRS
```

### 7.4 Evidence References

``` csharp
public ICollection<SemanticMappingEvidenceReference> EvidenceReferences { get; set; }
    = new List<SemanticMappingEvidenceReference>();
```

One Mapping Rule may be supported by multiple Evidence Artifacts.

------------------------------------------------------------------------

## 8. SemanticMappingRule Fluent API

Required:

-   `ToTable("SemanticMappingRules")`
-   `HasKey`
-   Property max lengths
-   Required / nullable configuration
-   Unique index on `MappingCode + MappingVersion`
-   Index on `SourceLocalName + StatusCode`
-   Index on `CanonicalRoleId + StatusCode`
-   Index on `TaxonomyFamilyCode + SourceLocalName + StatusCode`

### 8.1 Canonical Role Relationship

``` text
SemanticMappingRule.CanonicalRoleId
→
SemanticCanonicalRole.Id
```

Delete Behavior:

`Restrict / NoAction`

### Decision

Preferred:

`DeleteBehavior.NoAction`

### Reason

A Canonical Role referenced by Governance Mapping Rules must not be
cascade-deleted.

### 8.2 Self-reference Relationship

``` text
SemanticMappingRule.SupersededByMappingRuleId
→
SemanticMappingRule.Id
```

Delete Behavior:

`Restrict / NoAction`

### Important

Avoid cascade cycles.

Preferred:

`DeleteBehavior.NoAction`

------------------------------------------------------------------------

## 9. Entity: SemanticMappingScope

### 9.1 Purpose

Represents one Scope Condition for a Mapping Rule.

Scope Conditions constrain the applicability of Mapping Rules.

Examples:

-   Taxonomy Family
-   Taxonomy Version
-   Accounting Standard
-   Company Code
-   EDINET Code
-   Filing Family
-   Namespace

### Class Name

`SemanticMappingScope`

### Table

`SemanticMappingScopes`

### 9.2 Properties

``` csharp
public int Id { get; set; }

public int MappingRuleId { get; set; }

public string ScopeTypeCode { get; set; } = string.Empty;

public string ScopeOperatorCode { get; set; } = string.Empty;

public string? ScopeValue { get; set; }

public string? ScopeValueFrom { get; set; }

public string? ScopeValueTo { get; set; }

public bool IsRequired { get; set; }

public DateTime CreatedAt { get; set; }
```

### 9.3 Navigation Property

``` csharp
public SemanticMappingRule MappingRule { get; set; } = null!;
```

Relationship:

``` text
Many SemanticMappingScopes
→
One SemanticMappingRule
```

------------------------------------------------------------------------

## 10. SemanticMappingScope Fluent API

Required:

-   `ToTable("SemanticMappingScopes")`
-   `HasKey`
-   `MappingRuleId` required
-   Max lengths
-   Index on `MappingRuleId`
-   Index on `MappingRuleId + ScopeTypeCode`

Relationship:

``` text
SemanticMappingScope.MappingRuleId
→
SemanticMappingRule.Id
```

Delete Behavior:

`Restrict / NoAction`

### Preferred

`DeleteBehavior.NoAction`

------------------------------------------------------------------------

## 11. Entity: SemanticMappingEvidenceReference

### 11.1 Purpose

Represents one Evidence Artifact reference supporting a Mapping Rule.

The Entity stores a reference to the Evidence Artifact.

It does not store the complete Evidence Artifact body.

Examples:

-   Research Sheet
-   Cross-standard Evidence
-   Consolidation Review
-   Architecture Artifact
-   Primary Source Reference

### Class Name

`SemanticMappingEvidenceReference`

### Table

`SemanticMappingEvidenceReferences`

### 11.2 Properties

``` csharp
public int Id { get; set; }

public int MappingRuleId { get; set; }

public string EvidenceCode { get; set; } = string.Empty;

public string EvidenceTypeCode { get; set; } = string.Empty;

public string ArtifactPath { get; set; } = string.Empty;

public string? EvidenceDescription { get; set; }

public string? EvidenceVersion { get; set; }

public string? ReviewerDecisionCode { get; set; }

public DateTime? ReviewedAt { get; set; }

public DateTime CreatedAt { get; set; }
```

### 11.3 Navigation Property

``` csharp
public SemanticMappingRule MappingRule { get; set; } = null!;
```

Relationship:

``` text
Many SemanticMappingEvidenceReferences
→
One SemanticMappingRule
```

------------------------------------------------------------------------

## 12. SemanticMappingEvidenceReference Fluent API

Required:

-   `ToTable("SemanticMappingEvidenceReferences")`
-   `HasKey`
-   Unique index on `EvidenceCode`
-   Index on `MappingRuleId`
-   Required / nullable fields
-   Max lengths

Relationship:

``` text
SemanticMappingEvidenceReference.MappingRuleId
→
SemanticMappingRule.Id
```

Delete Behavior:

`Restrict / NoAction`

### Preferred

`DeleteBehavior.NoAction`

### Reason

Evidence lineage must not disappear automatically because a Mapping Rule
is deleted or modified.

Governance records require explicit lifecycle management.

------------------------------------------------------------------------

## 13. Entity: SemanticRejectedMappingDecision

### 13.1 Purpose

Represents one explicitly rejected Semantic Mapping candidate decision.

This Entity preserves negative knowledge.

Examples:

-   Combined concept must not be collapsed into a narrower role
-   Generic `Other` role must not replace `OtherInventories`
-   Company extension must not be mapped to a narrower standard role
    when material meaning would be lost

This Entity is independent of executable Mapping Rules.

### Class Name

`SemanticRejectedMappingDecision`

### Table

`SemanticRejectedMappingDecisions`

### 13.2 Properties

``` csharp
public int Id { get; set; }

public string DecisionCode { get; set; } = string.Empty;

public int DecisionVersion { get; set; }

public string SourceNamespaceUri { get; set; } = string.Empty;

public string SourceLocalName { get; set; } = string.Empty;

public string? SourceQName { get; set; }

public string RejectedCanonicalRoleCode { get; set; } = string.Empty;

public string? ReplacementCanonicalRoleCode { get; set; }

public string ReasonCode { get; set; } = string.Empty;

public string ReasonDescription { get; set; } = string.Empty;

public string EvidenceArtifactPath { get; set; } = string.Empty;

public string DecisionStatusCode { get; set; } = string.Empty;

public DateTime? ReviewedAt { get; set; }

public DateTime CreatedAt { get; set; }

public DateTime? UpdatedAt { get; set; }
```

### 13.3 Navigation Properties

`NONE`

### Reason

Rejected Role Codes may refer to:

-   Historical candidates
-   Non-existent roles
-   Deprecated roles
-   Conceptual alternatives that were intentionally never registered

Therefore:

`RejectedCanonicalRoleCode`

and:

`ReplacementCanonicalRoleCode`

remain string codes.

Do not force Foreign Key relationships.

This preserves the historical meaning of rejection decisions
independently from the current Canonical Role Master state.

------------------------------------------------------------------------

## 14. SemanticRejectedMappingDecision Fluent API

Required:

-   `ToTable("SemanticRejectedMappingDecisions")`
-   `HasKey`
-   Unique index on `DecisionCode + DecisionVersion`
-   Index on `SourceLocalName`
-   Index on `RejectedCanonicalRoleCode`
-   Max lengths
-   Required / nullable configuration

------------------------------------------------------------------------

## 15. DbSet Design

Add the following to `StockAnalysisDbContext`.

``` csharp
public DbSet<SemanticCanonicalRole> SemanticCanonicalRoles { get; set; }

public DbSet<SemanticMappingRule> SemanticMappingRules { get; set; }

public DbSet<SemanticMappingScope> SemanticMappingScopes { get; set; }

public DbSet<SemanticMappingEvidenceReference>
    SemanticMappingEvidenceReferences { get; set; }

public DbSet<SemanticRejectedMappingDecision>
    SemanticRejectedMappingDecisions { get; set; }
```

### Nullability Style

Follow the current project DbSet convention.

If current DbContext uses:

``` csharp
public DbSet<T> X { get; set; }
```

keep the same style.

If current DbContext uses:

``` csharp
public DbSet<T> X => Set<T>();
```

follow the current implementation.

Do not introduce a new DbSet pattern only for these Entities.

------------------------------------------------------------------------

## 16. Entity File Placement

Recommended folder:

``` text
StockAnalysis.Batch/Entities/
```

or the current existing Entity directory.

### Files

``` text
SemanticCanonicalRole.cs
SemanticMappingRule.cs
SemanticMappingScope.cs
SemanticMappingEvidenceReference.cs
SemanticRejectedMappingDecision.cs
```

### Important

Follow the actual Repository namespace and folder convention.

Do not create a separate Semantic namespace unless the current project
already organizes Entities by domain.

The Entity implementation must fit the existing solution structure
rather than introducing an isolated architectural pattern.

------------------------------------------------------------------------

## 17. XML Comment Requirement

Project coding rules require detailed Japanese comments.

Each Entity class should include XML comments.

Example:

``` csharp
/// <summary>
/// Canonical Semantic Roleを表す。
/// </summary>
```

Important properties should also receive comments where meaning is not
obvious.

Example:

``` csharp
/// <summary>
/// Source ConceptのNamespace URI。
/// QName Prefixではなく、Source Concept Identityの主要要素として使用する。
/// </summary>
public string SourceNamespaceUri { get; set; } = string.Empty;
```

Another example:

``` csharp
/// <summary>
/// このMapping Ruleを置き換える後継Mapping Rule ID。
/// 現行Ruleの場合はnullとする。
/// </summary>
public int? SupersededByMappingRuleId { get; set; }
```

### Comment Policy

Comments should explain:

-   Semantic meaning
-   Governance meaning
-   Non-obvious lifecycle behavior
-   Relationship meaning

Comments should not merely repeat the property name.

------------------------------------------------------------------------

## 18. Enum vs String Decision

Current Database stores controlled values as strings.

Examples:

-   `StatusCode`
-   `MappingClassCode`
-   `SourceTypeCode`
-   `ScopeTypeCode`
-   `ScopeOperatorCode`
-   Reviewer Status Codes

Question:

Should C# Entity properties use enums?

### Option A

Entity property itself is enum.

### Option B

Entity property remains string.

### Current Decision

`Use string properties in persistence Entities.`

### Reason

-   DB schema already stores string codes
-   New code values may be added through governance
-   Avoid ValueConverter complexity at this phase
-   Preserve exact DB values
-   Prevent persistence layer from becoming tightly coupled to a fixed
    application enum set

### Future

Application-level typed constants or domain enums may be introduced
above the persistence layer.

------------------------------------------------------------------------

## 19. Constant Class Candidate

To avoid magic strings later, future application code may define:

-   `SemanticMappingStatusCodes`
-   `SemanticMappingClassCodes`
-   `SemanticScopeTypeCodes`
-   `SemanticScopeOperatorCodes`
-   `SemanticReviewerStatusCodes`
-   `SemanticSourceTypeCodes`
-   `SemanticCanonicalRoleTypeCodes`

However:

`Not part of Entity implementation step`

First implement Entities exactly matching the applied database schema.

------------------------------------------------------------------------

## 20. Required Property Lengths

### 20.1 SemanticCanonicalRole

-   `RoleCode`: 100
-   `RoleName`: 200
-   `DomainCode`: 100
-   `Description`: 1000
-   `RoleTypeCode`: 50
-   `StatusCode`: 50

### 20.2 SemanticMappingRule

-   `MappingCode`: 50
-   `SourceNamespaceUri`: 1000
-   `SourceLocalName`: 300
-   `SourceQName`: 500
-   `TaxonomyFamilyCode`: 100
-   `SourceTypeCode`: 50
-   `AccountingStandardCode`: 50
-   `MappingClassCode`: 10
-   `StatusCode`: 50
-   `ResearchReviewerStatusCode`: 50
-   `ArchitectureReviewerStatusCode`: 50
-   `ProductionReviewerStatusCode`: 50

### 20.3 SemanticMappingScope

-   `ScopeTypeCode`: 50
-   `ScopeOperatorCode`: 50
-   `ScopeValue`: 1000
-   `ScopeValueFrom`: 1000
-   `ScopeValueTo`: 1000

### 20.4 SemanticMappingEvidenceReference

-   `EvidenceCode`: 50
-   `EvidenceTypeCode`: 50
-   `ArtifactPath`: 1000
-   `EvidenceDescription`: 1000
-   `EvidenceVersion`: 100
-   `ReviewerDecisionCode`: 50

### 20.5 SemanticRejectedMappingDecision

-   `DecisionCode`: 50
-   `SourceNamespaceUri`: 1000
-   `SourceLocalName`: 300
-   `SourceQName`: 500
-   `RejectedCanonicalRoleCode`: 100
-   `ReplacementCanonicalRoleCode`: 100
-   `ReasonCode`: 100
-   `ReasonDescription`: 2000
-   `EvidenceArtifactPath`: 1000
-   `DecisionStatusCode`: 50

------------------------------------------------------------------------

## 21. Default Value Handling

Database has defaults for:

-   Identity
-   `CreatedAt`
-   Selected Status values
-   Version values
-   Boolean flags

### EF Core Decision

Do not duplicate database defaults through Entity constructor logic
unnecessarily.

For example, `CreatedAt` should normally be generated by the database if
not explicitly supplied.

### Important

The current project may already use application-side timestamp
assignment.

If so, implementation should first inspect and follow the existing
project convention.

Do not introduce a conflicting timestamp strategy only for Semantic
Mapping Entities.

### Current Phase

No insert Service is being created yet.

Therefore no application-level creation behavior is required in this
Entity implementation step.

------------------------------------------------------------------------

## 22. Database-generated CreatedAt

Fluent API may use:

``` csharp
.ValueGeneratedOnAdd()
```

for database-default `CreatedAt`.

### Decision

`OPTIONAL BASED ON EXISTING PROJECT CONVENTION`

The key requirement is:

EF Core must not create behavior inconsistent with the applied database
schema.

Exact implementation should follow current project behavior.

------------------------------------------------------------------------

## 23. Navigation Loading Strategy

No lazy loading requirement has been established.

### Decision

Do not introduce lazy loading proxies.

Use normal navigation properties.

Queries should explicitly use:

-   `Include`
-   Projection
-   Join

as needed.

### Reason

Semantic Mapping Governance queries should remain explicit and
auditable.

------------------------------------------------------------------------

## 24. Delete Behavior

All Entity relationships use:

`DeleteBehavior.Restrict`

or:

`DeleteBehavior.NoAction`

depending on current SQL Server / EF Core convention.

### Preferred

`DeleteBehavior.NoAction`

to mirror SQL Server `NO ACTION`.

### Relationships

-   CanonicalRole → MappingRules
-   MappingRule → Scopes
-   MappingRule → EvidenceReferences
-   MappingRule → Superseded Mapping Rule

No cascade delete.

### Governance Principle

Governance records should not disappear through implicit relationship
cascades.

Deletion, if ever supported, must be explicit.

------------------------------------------------------------------------

## 25. Self-reference Relationship Risk

`SemanticMappingRule` has `SupersededByMappingRuleId`.

A self-reference may create:

-   Cascade cycle risk
-   Multiple cascade path risk
-   Unexpected historical deletion

### Required

Explicit:

`DeleteBehavior.NoAction`

The self-reference must be configured deliberately.

------------------------------------------------------------------------

## 26. DbContext Configuration Placement

Current project may configure Entities directly inside
`OnModelCreating`.

### Option A

Continue direct:

``` csharp
modelBuilder.Entity<T>()
```

blocks.

### Option B

Create separate:

``` csharp
IEntityTypeConfiguration<T>
```

classes.

### Decision

Follow current project convention.

Do not refactor all existing DbContext configuration solely for these
five Entities.

### Current Lean

If current `OnModelCreating` is still manageable:

`Add explicit blocks there.`

If the project already uses separate Entity Configuration classes:

`Follow that pattern.`

------------------------------------------------------------------------

## 27. Entity Implementation Order

Recommended implementation order:

1.  `SemanticCanonicalRole`
2.  `SemanticMappingRule`
3.  `SemanticMappingScope`
4.  `SemanticMappingEvidenceReference`
5.  `SemanticRejectedMappingDecision`
6.  Add `DbSet`
7.  Add Fluent API
8.  Build
9.  Run read-only validation query

### Reason

`SemanticMappingRule` depends on `SemanticCanonicalRole`.

`SemanticMappingScope` and `SemanticMappingEvidenceReference` depend on
`SemanticMappingRule`.

Implementing in dependency order reduces incomplete-reference errors.

------------------------------------------------------------------------

## 28. Read-only Validation After Build

After Entity and DbContext implementation, run a temporary read-only
validation.

Expected:

``` text
SemanticCanonicalRoles = 8
SemanticMappingRules = 11
SemanticMappingScopes = 2
SemanticMappingEvidenceReferences = 11
SemanticRejectedMappingDecisions = 4
Active Mapping Count = 0
```

### Additional Validation

The first EF validation should also verify that:

-   `MAP-INV-001` through `MAP-INV-011` can be read
-   Canonical Role navigation can be resolved
-   Kioxia Mapping Scopes can be read
-   Evidence References can be read
-   Self-reference mapping does not cause model creation errors

### Important

Do not modify data during first EF validation.

The first Entity integration test is read-only.

------------------------------------------------------------------------

## 29. Runtime Service Boundary

Do not yet create:

-   `SemanticMappingService`
-   `MappingResolver`
-   `ScopeEvaluator`
-   `MappingActivationService`
-   `CanonicalObservationService`
-   `MappingConflictResolver`

### Reason

Raw EDINET Fact Architecture remains pending.

The Entity implementation step is only:

`Database representation integration`

This prevents premature Runtime Architecture coupling.

------------------------------------------------------------------------

## 30. Phase A Entity Relationship Summary

``` text
SemanticCanonicalRole
    |
    | 1
    |
    | N
SemanticMappingRule
    |
    |-----------------------------|
    |                             |
    | 1                           | 1
    |                             |
    | N                           | N
SemanticMappingScope    SemanticMappingEvidenceReference

SemanticMappingRule
    |
    | optional self-reference
    |
    +--> SupersededByMappingRule

SemanticRejectedMappingDecision
    |
    +--> No FK Navigation
```

------------------------------------------------------------------------

## 31. Entity Responsibility Boundary

### SemanticCanonicalRole

Responsible for:

-   Canonical semantic identity
-   Canonical role type
-   Canonical role version
-   Canonical role lifecycle metadata

Not responsible for:

-   Source concept matching
-   Runtime mapping

### SemanticMappingRule

Responsible for:

-   Source concept identity
-   Canonical destination relationship
-   Mapping classification
-   Governance status
-   Reviewer status
-   Version lineage

Not responsible for:

-   Runtime mapping execution
-   Scope evaluation implementation

### SemanticMappingScope

Responsible for:

-   Mapping applicability condition persistence

Not responsible for:

-   Scope evaluation algorithm

### SemanticMappingEvidenceReference

Responsible for:

-   Evidence Artifact reference persistence
-   Reviewer decision metadata

Not responsible for:

-   Evidence document body storage
-   Evidence quality scoring

### SemanticRejectedMappingDecision

Responsible for:

-   Preserving explicitly rejected mapping knowledge
-   Preventing repeated rediscovery of rejected semantic collapses

Not responsible for:

-   Executable mapping

------------------------------------------------------------------------

## 32. Entity Reviewer Review

### Question 1

Do Entities match the applied DDL?

`YES`

### Question 2

Are Nullability rules aligned?

`YES`

### Question 3

Are relationships explicit?

`YES`

### Question 4

Are cascade deletes avoided?

`YES`

### Question 5

Are generic string code fields preserved?

`YES`

### Question 6

Is Runtime Mapping logic excluded?

`YES`

### Question 7

Is Raw Fact dependency still deferred?

`YES`

### Question 8

Is negative mapping knowledge preserved independently?

`YES`

### Question 9

Is Mapping Rule version lineage supported?

`YES`

### Question 10

Does the design avoid premature domain-service implementation?

`YES`

------------------------------------------------------------------------

## 33. Entity Reviewer Decision

### Decision

`APPROVE`

### Approved Next Step

`IMPLEMENT PHASE A ENTITIES AND DBCONTEXT MAPPING`

### Not Yet Approved

-   Runtime Mapping Service
-   Production Activation
-   Raw Fact Mapping
-   Canonical Observation creation
-   Conflict Resolution
-   Unmapped Queue implementation

------------------------------------------------------------------------

## 34. Definition of Done

Entity Design is complete when:

-   5 Entity responsibilities are defined
-   C# property types are defined
-   Nullability is defined
-   Navigation properties are defined
-   DbSet additions are defined
-   Fluent API requirements are defined
-   Delete behavior is defined
-   Enum/string decision is defined
-   Implementation order is defined
-   Validation plan is defined
-   Runtime boundary is preserved
-   Entity Reviewer approval is recorded

### Result

`DEFINITION OF DONE = PASS`

------------------------------------------------------------------------

## 35. Final Decision

### Phase A Entity Design

`APPROVED`

### Database State

``` text
Canonical Roles = 8
Mapping Rules = 11
Mapping Scopes = 2
Evidence References = 11
Rejected Mapping Decisions = 4
Active Mapping Rules = 0
```

### Next Step

Implement:

1.  `SemanticCanonicalRole.cs`
2.  `SemanticMappingRule.cs`
3.  `SemanticMappingScope.cs`
4.  `SemanticMappingEvidenceReference.cs`
5.  `SemanticRejectedMappingDecision.cs`

Then:

1.  Add `DbSet`
2.  Add Fluent API configuration
3.  Build
4.  Run read-only count validation
5.  Validate navigation relationships

### Current Phase

`ENTITY IMPLEMENTATION`

### Runtime Mapping Status

`NOT STARTED`

### Production Activation Status

`NOT APPROVED`

### Final Entity Design Decision

`APPROVED`
