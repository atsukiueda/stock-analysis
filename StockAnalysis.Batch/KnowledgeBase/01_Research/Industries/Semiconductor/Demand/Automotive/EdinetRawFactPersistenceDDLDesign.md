# EDINET Raw Fact Persistence DDL Design

## 1. Document Purpose

本書は、`EdinetRawFactPersistenceCatalog.md`で承認されたEDINET Raw Fact Persistence Catalogを、Azure SQL / SQL Server上で実装可能なPhysical Data Modelへ変換するためのDDL Design Artifactである。

本書の目的は以下である。

> EDINET Filing、Source File、Context、Context Dimension及びRaw Factを、Point-in-time再現性、監査可能性、Idempotent Ingestion、Parser Version管理及び将来のSemantic Mapping Lineageに耐えられるRelational Data Modelとして設計する。

本書はPhysical Database Designである。

ただし、本書では以下をまだ行わない。

- Final `CREATE TABLE` SQL生成
- Azure SQLへの適用
- EF Core Entity作成
- DbContext登録
- Parser実装
- Ingestion Service実装
- Runtime Semantic Mapping実装
- Canonical Observation実装

### Status

- DDL Design
- Architecture Approved Input
- Catalog Approved Input
- Pre-Final SQL
- Pre-Entity
- Pre-Ingestion Implementation
- DDL Reviewer Pending

---

## 2. Design Inputs

本DDL Designは以下を前提とする。

### Architecture

`EdinetRawFactPersistenceArchitecture.md`

### Catalog

`EdinetRawFactPersistenceCatalog.md`

### Existing Semantic Mapping Foundation

- `SemanticCanonicalRoles`
- `SemanticMappingRules`
- `SemanticMappingScopes`
- `SemanticMappingEvidenceReferences`
- `SemanticRejectedMappingDecisions`

### Existing Database Convention

Current project evidence indicates:

- Azure SQL / SQL Server
- EF Core
- PascalCase table names
- `CreatedAt` / `UpdatedAt`
- `int IDENTITY` usage for new surrogate-key tables
- manual reviewed SQL deployment is currently acceptable
- existing `Companies` table must not be duplicated

---

## 3. Core Physical Design Principles

### 3.1 Filing Is the Root Aggregate

All persisted EDINET raw data belongs to one Filing.

Root:

`EdinetFilings`

Children:

- `EdinetSourceFiles`
- `EdinetContexts`
- `EdinetRawFacts`

### 3.2 Context Is Reused Across Facts

Context metadata must not be duplicated on every Raw Fact.

Therefore:

`EdinetContexts`

is a separate table.

### 3.3 Dimensions Are Child Records

Context dimensions must not be flattened into only one string field.

Therefore:

`EdinetContextDimensions`

is a child table.

### 3.4 Source File Identity Is First-class

Facts must preserve exact source file origin.

Therefore:

`EdinetSourceFiles`

is a separate table.

### 3.5 Raw Fact Is Immutable Evidence

Raw Fact records should not be semantically rewritten after ingestion.

Parser bugs or reprocessing should produce controlled updates or re-ingestion logic without destroying source identity.

### 3.6 Source Identity Before Normalization

Preserve:

- DocumentId
- EdinetCode
- SecurityCode
- Namespace URI
- Local Name
- QName
- ContextRef
- UnitRef
- Decimals
- RawValue

before any canonical interpretation.

---

## 4. Proposed Physical Table Set

Initial tables:

1. `EdinetFilings`
2. `EdinetSourceFiles`
3. `EdinetContexts`
4. `EdinetContextDimensions`
5. `EdinetRawFacts`

Deferred tables:

6. `EdinetIngestionBatches`
7. `EdinetUnits`
8. `EdinetParsingErrors`
9. `EdinetFilingSupersessions`

### Decision

Initial DDL should contain only the five required persistence tables.

---

## 5. Table: EdinetFilings

### 5.1 Purpose

Stores one EDINET filing identity and its submission metadata.

This table answers:

`Which exact EDINET filing did the persisted source data come from?`

### 5.2 Candidate Columns

- `Id`
- `DocumentId`
- `EdinetCode`
- `SecurityCode`
- `FilerName`
- `DocumentTypeCode`
- `DocumentDescription`
- `PeriodStart`
- `PeriodEnd`
- `SubmitDateTime`
- `WithdrawalStatus`
- `DisclosureStatus`
- `XbrlFlag`
- `CsvFlag`
- `PdfFlag`
- `AttachDocFlag`
- `EnglishDocFlag`
- `LegalStatus`
- `ParentDocumentId`
- `CurrentReportReason`
- `CreatedAt`
- `UpdatedAt`

### 5.3 Primary Key

`Id`

Candidate physical type:

`int IDENTITY(1,1)`

### 5.4 Natural Key

`DocumentId`

### Decision

Unique constraint:

`UNIQUE(DocumentId)`

### Reason

EDINET Document ID is the immutable source filing identity.

---

## 6. EdinetFilings Column Design

### Id

Candidate:

`int IDENTITY(1,1) NOT NULL`

### DocumentId

Candidate:

`nvarchar(20) NOT NULL`

Examples:

- `S100YJ18`
- `S100XR06`

### EdinetCode

Candidate:

`nvarchar(20) NULL`

Example:

`E35948`

### SecurityCode

Candidate:

`nvarchar(20) NULL`

Examples:

- `69630`
- `285A0`

### FilerName

Candidate:

`nvarchar(500) NULL`

### DocumentTypeCode

Candidate:

`nvarchar(20) NULL`

Initial target:

`120`

### DocumentDescription

Candidate:

`nvarchar(1000) NULL`

### PeriodStart

Candidate:

`date NULL`

### PeriodEnd

Candidate:

`date NULL`

### SubmitDateTime

Candidate:

`datetime2 NULL`

### WithdrawalStatus

Candidate:

`nvarchar(20) NULL`

### DisclosureStatus

Candidate:

`nvarchar(20) NULL`

### XbrlFlag

Candidate:

`nvarchar(10) NULL`

### CsvFlag

Candidate:

`nvarchar(10) NULL`

### PdfFlag

Candidate:

`nvarchar(10) NULL`

### AttachDocFlag

Candidate:

`nvarchar(10) NULL`

### EnglishDocFlag

Candidate:

`nvarchar(10) NULL`

### LegalStatus

Candidate:

`nvarchar(20) NULL`

### ParentDocumentId

Candidate:

`nvarchar(20) NULL`

### CurrentReportReason

Candidate:

`nvarchar(1000) NULL`

### CreatedAt

Candidate:

`datetime2 NOT NULL DEFAULT SYSDATETIME()`

### UpdatedAt

Candidate:

`datetime2 NULL`

---

## 7. EdinetFilings Index Strategy

### Unique

`DocumentId`

### Search Index

Candidate:

`EdinetCode + SubmitDateTime`

### Search Index

Candidate:

`SecurityCode + SubmitDateTime`

### Search Index

Candidate:

`DocumentTypeCode + SubmitDateTime`

### Reason

Supports:

- company filing history
- point-in-time lookup
- annual securities report filtering

---

## 8. Table: EdinetSourceFiles

### 8.1 Purpose

Stores individual source files inside one EDINET filing package.

### 8.2 Candidate Columns

- `Id`
- `FilingId`
- `SourceFilePath`
- `SourceFileName`
- `SourceFileTypeCode`
- `SourceFormatCode`
- `ContentChecksum`
- `ChecksumAlgorithmCode`
- `ParserVersion`
- `SourceSequence`
- `CreatedAt`

### 8.3 Primary Key

`Id`

Candidate:

`int IDENTITY(1,1)`

### 8.4 Natural Key

Candidate:

`FilingId + SourceFilePath`

### Decision

Unique constraint:

`UNIQUE(FilingId, SourceFilePath)`

---

## 9. EdinetSourceFiles Column Design

### FilingId

FK to:

`EdinetFilings.Id`

Required:

`YES`

### SourceFilePath

Candidate:

`nvarchar(1000) NOT NULL`

### SourceFileName

Candidate:

`nvarchar(500) NOT NULL`

### SourceFileTypeCode

Candidate:

`nvarchar(50) NOT NULL`

Allowed:

- PublicDoc
- AuditDoc
- Other

### SourceFormatCode

Candidate:

`nvarchar(50) NOT NULL`

Allowed:

- XBRL
- CSV
- XML
- Other

### ContentChecksum

Candidate:

`nvarchar(128) NULL`

### ChecksumAlgorithmCode

Candidate:

`nvarchar(50) NULL`

### ParserVersion

Candidate:

`nvarchar(100) NOT NULL`

### SourceSequence

Candidate:

`int NULL`

### CreatedAt

Candidate:

`datetime2 NOT NULL DEFAULT SYSDATETIME()`

---

## 10. EdinetSourceFiles Constraints

### CHECK: SourceFileTypeCode

Allowed:

- PublicDoc
- AuditDoc
- Other

### CHECK: SourceFormatCode

Allowed:

- XBRL
- CSV
- XML
- Other

### CHECK: SourceSequence

If not null:

`SourceSequence >= 0`

---

## 11. EdinetSourceFiles Index Strategy

### Unique

`FilingId + SourceFilePath`

### Search Index

`FilingId + SourceFileTypeCode`

### Search Index

`FilingId + SourceFormatCode`

---

## 12. Table: EdinetContexts

### 12.1 Purpose

Stores one XBRL Context identity and parsed reporting semantics.

### 12.2 Candidate Columns

- `Id`
- `FilingId`
- `ContextRef`
- `PeriodTypeCode`
- `InstantDate`
- `PeriodStart`
- `PeriodEnd`
- `ConsolidationScopeCode`
- `HasDimensions`
- `DimensionSignature`
- `EntityIdentifierScheme`
- `EntityIdentifierValue`
- `CreatedAt`

### 12.3 Primary Key

`Id`

Candidate:

`int IDENTITY(1,1)`

### 12.4 Natural Key

`FilingId + ContextRef`

### Decision

Unique constraint:

`UNIQUE(FilingId, ContextRef)`

---

## 13. EdinetContexts Column Design

### FilingId

FK to:

`EdinetFilings.Id`

### ContextRef

Candidate:

`nvarchar(500) NOT NULL`

### PeriodTypeCode

Candidate:

`nvarchar(50) NOT NULL`

Allowed:

- Instant
- Duration
- Forever
- Unknown

### InstantDate

Candidate:

`date NULL`

### PeriodStart

Candidate:

`date NULL`

### PeriodEnd

Candidate:

`date NULL`

### ConsolidationScopeCode

Candidate:

`nvarchar(50) NOT NULL`

Allowed:

- Consolidated
- NonConsolidated
- Unknown

### HasDimensions

Candidate:

`bit NOT NULL DEFAULT 0`

### DimensionSignature

Candidate:

`nvarchar(2000) NULL`

### EntityIdentifierScheme

Candidate:

`nvarchar(1000) NULL`

### EntityIdentifierValue

Candidate:

`nvarchar(500) NULL`

### CreatedAt

Candidate:

`datetime2 NOT NULL DEFAULT SYSDATETIME()`

---

## 14. EdinetContexts Period Consistency Constraints

### Instant

If:

`PeriodTypeCode = Instant`

Then:

- `InstantDate IS NOT NULL`
- `PeriodStart IS NULL`
- `PeriodEnd IS NULL`

### Duration

If:

`PeriodTypeCode = Duration`

Then:

- `InstantDate IS NULL`
- `PeriodStart IS NOT NULL`
- `PeriodEnd IS NOT NULL`
- `PeriodEnd >= PeriodStart`

### Forever

All period date fields may be null.

### Unknown

No strict period field requirement.

### Decision

Enforce structural consistency with CHECK constraints where practical.

---

## 15. Consolidation Scope Detection

### Physical Field

`ConsolidationScopeCode`

### Allowed

- Consolidated
- NonConsolidated
- Unknown

### Important

This is parsed context metadata.

It must not be inferred solely from `ContextRef` string naming when richer dimension evidence exists.

---

## 16. EdinetContexts Index Strategy

### Unique

`FilingId + ContextRef`

### Search Index

`FilingId + PeriodTypeCode`

### Search Index

`FilingId + ConsolidationScopeCode`

### Search Index

Candidate:

`PeriodEnd + ConsolidationScopeCode`

Usefulness to be confirmed during query profiling.

---

## 17. Table: EdinetContextDimensions

### 17.1 Purpose

Stores one dimension/member pair for one context.

### 17.2 Candidate Columns

- `Id`
- `ContextId`
- `DimensionNamespaceUri`
- `DimensionLocalName`
- `DimensionQName`
- `MemberNamespaceUri`
- `MemberLocalName`
- `MemberQName`
- `TypedMemberValue`
- `DimensionTypeCode`
- `DimensionOrder`
- `CreatedAt`

### 17.3 Primary Key

`Id`

Candidate:

`int IDENTITY(1,1)`

---

## 18. EdinetContextDimensions Natural Identity

The initial candidate natural key is:

`ContextId + DimensionOrder`

### Reason

Dimension order is deterministic from source parsing and avoids nullable-composite uniqueness complexity.

### Additional Semantic Validation

Parser should ensure that the same Context does not contain accidental duplicate dimension positions.

### Decision

Unique constraint:

`UNIQUE(ContextId, DimensionOrder)`

### Important

This does not claim semantic uniqueness by Dimension QName alone.

---

## 19. EdinetContextDimensions Column Design

### ContextId

FK to:

`EdinetContexts.Id`

### DimensionNamespaceUri

Candidate:

`nvarchar(1000) NOT NULL`

### DimensionLocalName

Candidate:

`nvarchar(300) NOT NULL`

### DimensionQName

Candidate:

`nvarchar(500) NULL`

### MemberNamespaceUri

Candidate:

`nvarchar(1000) NULL`

### MemberLocalName

Candidate:

`nvarchar(300) NULL`

### MemberQName

Candidate:

`nvarchar(500) NULL`

### TypedMemberValue

Candidate:

`nvarchar(max) NULL`

### DimensionTypeCode

Candidate:

`nvarchar(50) NOT NULL`

Allowed:

- Explicit
- Typed
- Unknown

### DimensionOrder

Candidate:

`int NOT NULL`

### CreatedAt

Candidate:

`datetime2 NOT NULL DEFAULT SYSDATETIME()`

---

## 20. EdinetContextDimensions Constraints

### DimensionTypeCode

Allowed:

- Explicit
- Typed
- Unknown

### DimensionOrder

`DimensionOrder >= 0`

### Explicit Dimension

Candidate rule:

If `DimensionTypeCode = Explicit`

then:

- MemberLocalName should normally be non-null

### Typed Dimension

Candidate rule:

If `DimensionTypeCode = Typed`

then:

- TypedMemberValue should normally be non-null

### Decision

Do not over-constrain initial DDL if EDINET variation is not fully validated.

Structural minimum constraints only.

---

## 21. EdinetContextDimensions Index Strategy

### Unique

`ContextId + DimensionOrder`

### Search Index

`ContextId`

### Search Index Candidate

`DimensionLocalName + MemberLocalName`

Useful for segment analysis later.

Deferred until query demand is confirmed.

---

## 22. Table: EdinetRawFacts

### 22.1 Purpose

Stores one raw EDINET/XBRL fact as source evidence.

### 22.2 Candidate Columns

- `Id`
- `FilingId`
- `SourceFileId`
- `ContextId`
- `SourceNamespaceUri`
- `SourceLocalName`
- `SourceQName`
- `TaxonomyFamilyCode`
- `TaxonomyVersion`
- `SourceTypeCode`
- `UnitRef`
- `Decimals`
- `Precision`
- `RawValue`
- `NumericValue`
- `TextValue`
- `ValueTypeCode`
- `IsNil`
- `LanguageCode`
- `SourceFactSequence`
- `OccurrenceIndex`
- `ParserVersion`
- `CreatedAt`

### 22.3 Primary Key

`Id`

Candidate:

`bigint IDENTITY(1,1)`

### Important Difference

Unlike governance tables, Raw Fact volume may become very large.

Potential scale:

- 4,000+ companies
- many filings
- thousands of numeric facts per filing

### Decision

Use:

`bigint`

for `EdinetRawFacts.Id`

### Other Tables

Use:

`int`

for:

- EdinetFilings
- EdinetSourceFiles
- EdinetContexts
- EdinetContextDimensions

---

## 23. EdinetRawFacts Foreign Keys

### FilingId

FK to:

`EdinetFilings.Id`

### SourceFileId

FK to:

`EdinetSourceFiles.Id`

### ContextId

FK to:

`EdinetContexts.Id`

Initial numeric fact scope:

`ContextId NOT NULL`

### Future Generic Compatibility

Some non-financial facts may lack context.

If future broader ingestion requires it, nullable ContextId may be reconsidered.

### Initial Decision

`ContextId NOT NULL`

---

## 24. Source Concept Storage

### SourceNamespaceUri

Candidate:

`nvarchar(1000) NOT NULL`

### SourceLocalName

Candidate:

`nvarchar(300) NOT NULL`

### SourceQName

Candidate:

`nvarchar(500) NULL`

### TaxonomyFamilyCode

Candidate:

`nvarchar(100) NULL`

### TaxonomyVersion

Candidate:

`nvarchar(100) NULL`

### SourceTypeCode

Candidate:

`nvarchar(50) NOT NULL`

Allowed:

- StandardTaxonomy
- CompanyExtension
- OtherExtension
- Unknown

---

## 25. UnitRef Storage

Candidate:

`nvarchar(500) NULL`

### Reason

Compound or non-trivial XBRL unitRef values may exceed simple short codes.

### Important

Store raw UnitRef exactly.

Do not map directly to currency code only.

---

## 26. Decimals Storage

Observed examples:

- `-3`
- `-6`

Possible XBRL value:

- `INF`

### Decision

Store raw lexical form:

`nvarchar(50) NULL`

Do not use only integer storage.

### Future Parsed Field

A separate parsed integer precision field could be added later if analytically useful.

Not required now.

---

## 27. Precision Storage

Candidate:

`nvarchar(50) NULL`

### Reason

Preserve exact lexical attribute.

---

## 28. RawValue Storage

### Candidate

`nvarchar(max) NULL`

### Reason

Raw lexical value is authoritative evidence and may vary greatly in size.

### Initial Numeric Scope

Most values will be small.

But architecture should remain future-compatible.

---

## 29. NumericValue Storage

### Candidate Options

#### Option A

`decimal(38,10)`

#### Option B

`decimal(38,18)`

#### Option C

No numeric column initially

### Decision

Use:

`decimal(38,10) NULL`

### Rationale

Supports:

- large financial values
- decimal ratios
- parsed numeric queryability

### Important Limitation

Some XBRL numeric values may exceed precision or scale.

Parser behavior:

- always preserve RawValue
- set NumericValue only when safe parsing succeeds
- never reject a fact solely because NumericValue cannot be represented

---

## 30. TextValue Storage

Candidate:

`nvarchar(max) NULL`

### Initial Use

Mostly unused in numeric-only initial ingestion.

### Decision

Include now for generic schema compatibility.

### Reason

Avoid future table redesign when selected text facts are added.

---

## 31. ValueTypeCode

Candidate:

`nvarchar(50) NOT NULL`

Allowed:

- Numeric
- Text
- Html
- Boolean
- Date
- Unknown

Initial ingestion:

`Numeric`

---

## 32. IsNil

Candidate:

`bit NOT NULL DEFAULT 0`

### Important

If `IsNil = 1`:

- RawValue may be null
- NumericValue may be null
- TextValue may be null

---

## 33. LanguageCode

Candidate:

`nvarchar(50) NULL`

Example:

`ja`

---

## 34. SourceFactSequence

Candidate:

`int NOT NULL`

### Purpose

Deterministic occurrence ordering in source file.

### Constraint

`SourceFactSequence >= 0`

---

## 35. OccurrenceIndex

Candidate:

`int NOT NULL DEFAULT 0`

### Purpose

Disambiguates repeated identical concept/context/unit combinations.

### Constraint

`OccurrenceIndex >= 0`

---

## 36. ParserVersion

Candidate:

`nvarchar(100) NOT NULL`

### Important

ParserVersion on Raw Fact may appear redundant with Source File ParserVersion.

### Decision

Keep both.

### Reason

A source file may be reprocessed and facts may be produced under a different parser version.

Fact-level parser version improves reproducibility.

---

## 37. EdinetRawFacts Natural Identity

A critical requirement is idempotent ingestion.

Candidate uniqueness:

```text
SourceFileId
+
SourceFactSequence
```

### Why This Is Strong

Within one exact source file:

- deterministic parser sequence
- stable source occurrence
- no nullable composite complexity

### Additional Semantic Identity

For audit:

- SourceNamespaceUri
- SourceLocalName
- ContextId
- UnitRef
- OccurrenceIndex

### Decision

Primary idempotency unique constraint:

`UNIQUE(SourceFileId, SourceFactSequence)`

### Important

Parser must guarantee deterministic sequence ordering.

---

## 38. Alternative Raw Fact Uniqueness Rejected

Rejected candidate:

```text
FilingId
+
NamespaceUri
+
LocalName
+
ContextId
+
UnitRef
```

### Reason

The same exact combination may legitimately appear more than once.

### Rejected candidate:

`DocumentId + QName`

### Reason

Context is ignored.

---

## 39. SourceFactSequence Governance

Parser sequence must be defined as:

`Document order among persisted fact elements`

### Initial rule

Zero-based or one-based must be fixed before implementation.

### Recommendation

Use:

`0-based`

### Reason

Natural with C# enumeration.

### Final decision

`0-based`

---

## 40. OccurrenceIndex Governance

OccurrenceIndex is counted among facts sharing:

- SourceFileId
- SourceNamespaceUri
- SourceLocalName
- ContextId
- UnitRef

### Recommendation

Use:

`0-based`

### Purpose

Diagnostic disambiguation.

Not primary persistence identity.

---

## 41. EdinetRawFacts Index Strategy

### Unique

`SourceFileId + SourceFactSequence`

### Semantic Mapping Lookup Index

Candidate:

`SourceLocalName + SourceTypeCode`

Include:

- SourceNamespaceUri
- FilingId
- ContextId
- NumericValue
- UnitRef

### Important

Full Namespace URI is wide.

Do not make it a wide leading index key initially.

### Filing Query Index

`FilingId + ContextId`

### Source File Query Index

`SourceFileId`

### Concept Query Index

`TaxonomyFamilyCode + SourceLocalName`

### Numeric Fact Query Index

Candidate filtered index:

`ValueTypeCode = Numeric`

Deferred until volume profiling.

---

## 42. Namespace URI Index Width Strategy

### Problem

`nvarchar(1000)` is too wide for ideal index key use.

### Initial Decision

Do not create Namespace URI as primary index key.

Runtime Semantic Mapping candidate lookup:

1. Search by Local Name / Source Type
2. Verify exact Namespace URI in predicate or application layer

### Future Optimization

Possible:

- Namespace Master table
- persisted SHA-256 hash
- normalized Source Concept Master

### Current Decision

`DEFER`

---

## 43. Filing to Company Integration

### Existing Companies

Existing primary key:

`Companies.Code`

### EDINET Security Code

Examples:

- `69630`
- `285A0`

### Problem

Internal code normalization may differ.

### Decision

Do not create mandatory FK from `EdinetFilings` to `Companies`.

### Preserve

- SecurityCode
- EdinetCode

### Future

Add company identifier resolution architecture separately.

---

## 44. Foreign Key Delete Behavior

All child relationships should use:

`NO ACTION`

### Relationships

- EdinetSourceFiles → EdinetFilings
- EdinetContexts → EdinetFilings
- EdinetContextDimensions → EdinetContexts
- EdinetRawFacts → EdinetFilings
- EdinetRawFacts → EdinetSourceFiles
- EdinetRawFacts → EdinetContexts

### Reason

Raw evidence must not disappear through cascade deletion.

---

## 45. Hard Delete Policy

Production raw evidence should not be hard-deleted casually.

### Initial recommendation

No generic delete service.

If ingestion must be rebuilt:

Use explicit controlled cleanup by Filing in development.

### Production

Retention policy should be long-term.

---

## 46. Filing Ingestion Transaction Boundary

Recommended:

`One Filing = One transaction`

### Transaction includes

- Filing insert/resolve
- Source file insert
- Context insert
- Context dimension insert
- Raw fact insert

### Benefit

Prevents partial filing persistence.

### Risk

Very large filings may create long transactions.

### Initial decision

Use one transaction for prototype and initial production validation.

Revisit after performance measurement.

---

## 47. Idempotent Re-ingestion Strategy

### Filing

Resolve by:

`DocumentId`

### Source File

Resolve by:

`FilingId + SourceFilePath`

### Context

Resolve by:

`FilingId + ContextRef`

### Context Dimension

Resolve by:

`ContextId + DimensionOrder`

### Raw Fact

Resolve by:

`SourceFileId + SourceFactSequence`

### Semantic mismatch handling

If natural identity exists but material fields differ:

`FAIL`

Do not silently overwrite.

### Reason

Possible causes:

- parser change
- source payload change
- sequence instability
- bug

These require review.

---

## 48. Parser Version Change Handling

If parser version changes:

### Option A

Overwrite same Raw Fact row

### Option B

Create duplicate fact row

### Option C

Controlled reprocessing with explicit cleanup/version strategy

### Decision

For initial implementation:

`Do not auto-overwrite existing facts.`

If the same natural identity exists with a different parser output:

`Fail validation and review.`

### Future

A formal ingestion batch/version model may support multi-version raw parsing.

---

## 49. Source File Checksum Strategy

### Initial

Optional.

### Recommended before broad ingestion

Calculate SHA-256 over source file bytes.

### Use

- verify source identity
- detect unexpected payload changes
- support reprocessing audit

### Constraint

If checksum algorithm exists, checksum value should exist.

Potential CHECK to be considered in final DDL.

---

## 50. Storage Volume Estimate Consideration

Potential future scale:

- thousands of companies
- multiple filings per year
- thousands of facts per filing

### Design implication

`EdinetRawFacts.Id = bigint`

### Other tables

`int` remains sufficient initially.

### Text columns

Avoid adding unnecessary duplicated large fields to Raw Fact.

### Context normalization

Reduces repeated data.

---

## 51. Table Naming Decision

Approved physical names:

- `EdinetFilings`
- `EdinetSourceFiles`
- `EdinetContexts`
- `EdinetContextDimensions`
- `EdinetRawFacts`

### Decision

`APPROVE`

---

## 52. Audit Column Decision

Use:

- `CreatedAt`
- `UpdatedAt` where mutable

### Time basis

Follow current project convention.

Do not claim UTC unless project-wide policy changes.

---

## 53. Mutable vs Immutable Tables

### EdinetFilings

Potentially mutable metadata:

- status flags
- UpdatedAt

### EdinetSourceFiles

Mostly immutable.

### EdinetContexts

Immutable after successful ingestion.

### EdinetContextDimensions

Immutable after successful ingestion.

### EdinetRawFacts

Immutable source evidence.

### Principle

Do not use generic update operations for immutable child records.

---

## 54. CHECK Constraint Philosophy

Database should enforce:

- enum-like controlled codes
- non-negative sequence values
- period structural consistency
- version/string presence where required

Database should not enforce:

- semantic interpretation
- company normalization
- taxonomy equivalence
- mapping eligibility

---

## 55. Initial DDL Phase Scope

### Phase A: Core Raw Persistence

Create all five tables.

### Why all five together

Unlike Semantic Mapping Governance, Context and Source File are required for valid Raw Fact identity.

Therefore partial implementation would weaken source lineage.

### Decision

Implement all five in one DDL phase.

---

## 56. Seed Data Requirement

No business seed data is required.

### Reason

These are ingestion tables, not governance masters.

Only schema deployment is required.

### Validation

Use known filings through parser ingestion tests.

---

## 57. Known-value Regression Integration

After schema and parser implementation:

Persist known filing facts and verify values.

### Required regression cases

- Kioxia `InventoriesCAIFRS = 412612000000`
- Kioxia `SemiFinishedProductsAndWorkInProgressCAIFRS = 280183000000`
- Tokyo Electron `WorkInProcess = 210570000000`
- Sanken Electric `WriteDownsOfInventories = 2412000000`

---

## 58. Existing Database Dependency Review Requirements

Before final DDL specification, confirm:

1. Current `StockAnalysisDbContext`
2. Existing EDINET-related entities/tables
3. Existing naming conflicts
4. Current ID type conventions
5. Current timestamp conventions
6. Existing parser DTOs
7. Existing filing discovery model
8. Existing source file abstraction
9. Existing transaction pattern
10. Existing Azure SQL size/cost constraints

---

## 59. Open Design Questions

### Question 1

Should `SubmitDateTime` be NOT NULL?

Likely yes for Document List API filing records.

Needs current DTO confirmation.

### Question 2

Should `EdinetCode` be NOT NULL?

Likely yes for target annual filings.

Needs actual API variation review.

### Question 3

Should `NumericValue` use `decimal(38,10)`?

Candidate approved for design.

Needs parser range validation.

### Question 4

Should `RawValue` remain `nvarchar(max)`?

Likely yes.

### Question 5

Should ContextId be NOT NULL?

Approved for initial numeric ingestion.

### Question 6

Should parser version exist on both SourceFile and RawFact?

Current decision:

`YES`

### Question 7

Should SourceFactSequence be the primary idempotency key?

Current decision:

`YES`

Requires deterministic parser implementation.

---

## 60. DDL Reviewer Review

### Question 1

Are Filing and Fact separated?

`YES`

### Question 2

Is Context normalized?

`YES`

### Question 3

Are Dimensions preserved?

`YES`

### Question 4

Is exact source file origin preserved?

`YES`

### Question 5

Is RawValue preserved independently from NumericValue?

`YES`

### Question 6

Does the design support idempotent ingestion?

`YES`

### Question 7

Does the design preserve point-in-time filing identity?

`YES`

### Question 8

Does the design avoid premature Semantic Mapping?

`YES`

### Question 9

Is storage scale considered?

`YES`

### Question 10

Is Raw Fact primary key sized for large volume?

`YES`

---

## 61. DDL Reviewer Decision

### Decision

`APPROVE WITH EXISTING DATABASE DEPENDENCY REVIEW`

### Approved Physical Table Model

- `EdinetFilings`
- `EdinetSourceFiles`
- `EdinetContexts`
- `EdinetContextDimensions`
- `EdinetRawFacts`

### Key Decisions

- `EdinetRawFacts.Id = bigint`
- other surrogate keys = `int`
- `DocumentId` unique
- `FilingId + SourceFilePath` unique
- `FilingId + ContextRef` unique
- `ContextId + DimensionOrder` unique
- `SourceFileId + SourceFactSequence` unique
- Context normalized
- dimensions normalized
- no cascade delete
- no seed data

### Remaining Gate

`Existing Database Dependency Review`

---

## 62. Definition of Done

DDL Design is complete when:

- five table responsibilities are defined
- physical table names are defined
- PK strategy is defined
- natural identities are defined
- raw fact idempotency key is defined
- context normalization is defined
- dimension persistence is defined
- raw and parsed value storage is defined
- numeric precision candidate is defined
- index strategy is defined
- delete behavior is defined
- transaction boundary is defined
- re-ingestion behavior is defined
- reviewer decision is recorded

### Result

`DEFINITION OF DONE = PASS`

---

## 63. Final DDL Design Decision

### EDINET Raw Fact Persistence DDL Design

`APPROVED WITH DEPENDENCY REVIEW REQUIRED`

### Next Phase

`EXISTING DATABASE DEPENDENCY REVIEW`

### Next Artifact

`EdinetRawFactPersistenceExistingDatabaseDependencyReview.md`

### Purpose

> Current Repository、DbContext、EDINET Prototype DTO / Service、既存Table及び既存Transaction Conventionを確認し、Raw Fact DDLが既存実装と重複・競合しないことを確定する。

### Required Review Targets

- Current `StockAnalysisDbContext`
- EDINET DTOs
- `EdinetInventoryPrototypeService`
- current Document List response model
- current XBRL parsing utilities
- current namespace conventions
- existing table names
- current transaction pattern
- current Azure SQL storage constraints

### Decision Categories

For each dependency:

- Reuse Existing
- Extend Existing
- Create New
- Defer

### Important

Do not generate final SQL before this review.

Next:

`EdinetRawFactPersistenceExistingDatabaseDependencyReview.md`
