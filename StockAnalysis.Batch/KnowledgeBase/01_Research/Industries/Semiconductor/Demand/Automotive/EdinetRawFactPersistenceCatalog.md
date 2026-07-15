# EDINET Raw Fact Persistence Catalog

## 1. Catalog Purpose

本書は、`EdinetRawFactPersistenceArchitecture.md`で承認されたRaw EDINET Fact Persistence Architectureを、DDL及びEntity設計前の論理Catalogとして固定する。

本Catalogの目的は以下である。

> EDINET Filing、Source File、Context、Context Dimension及びRaw Factについて、DDL実装前に必要な論理項目、責務、Code Value、Natural Identity、初期Ingestion Scope及びDeferred項目を明示的に定義する。

本Catalogは以下を定義しない。

- SQL Data Type
- Primary Keyの物理型
- Foreign Key Constraint
- Index
- EF Core Entity
- Parser実装
- Ingestion Service
- Runtime Semantic Mapping
- Canonical Observation

### Status

- Logical Catalog
- Architecture Approved Input
- Pre-DDL
- Pre-Entity
- Pre-Ingestion Implementation
- Catalog Reviewer Pending

---

## 2. Catalog Design Principles

### 2.1 Raw Evidence Preservation

Raw EDINET Factは、Semantic Mapping前のEvidence Layerとして扱う。

Therefore:

- Source Concept Identityを保持する
- Filing Identityを保持する
- ContextRefを保持する
- UnitRefを保持する
- Decimalsを保持する
- Raw Valueを保持する
- Source File Identityを保持する
- Company Extension Identityを保持する

### 2.2 Filing and Fact Separation

Filing metadataとFact metadataを1テーブルへ混在させない。

Logical separation:

```text
EdinetFiling
    ↓
EdinetSourceFile
    ↓
EdinetContext
    ↓
EdinetContextDimension
    ↓
EdinetRawFact
```

### 2.3 Raw and Parsed Values Are Separate

Raw lexical valueとparsed valueは別物として扱う。

Required principle:

`RawValue is authoritative source evidence.`

`NumericValue is derived parsing output.`

### 2.4 Context Is First-class

同一ConceptでもContextが異なれば意味が異なる。

Therefore:

`Concept identity alone is insufficient.`

### 2.5 Company Extension Is Not Standard Taxonomy

Company Extension Conceptは、Standard Taxonomy Conceptへ事前変換しない。

### 2.6 Persistence Eligibility and Analytical Eligibility Are Different

保存対象であることと、Semantic Mapping対象であることは同義ではない。

---

## 3. Catalog Structure Overview

本Catalogは以下の論理Catalog群から構成する。

1. `EdinetFiling Catalog`
2. `EdinetSourceFile Catalog`
3. `EdinetContext Catalog`
4. `EdinetContextDimension Catalog`
5. `EdinetRawFact Catalog`
6. `Code Value Catalog`
7. `Natural Identity Catalog`
8. `Initial Ingestion Scope Catalog`
9. `Deferred Field Catalog`
10. `Catalog Reviewer Gate`

---

## 4. EdinetFiling Catalog

### 4.1 Purpose

EDINET Document List APIから取得した1 Filingのidentity及びsubmission metadataを保持する。

This catalog answers:

`Which EDINET filing did this fact come from?`

### 4.2 Logical Fields

#### DocumentId

Purpose:

EDINET Document ID。

Example:

`S100YJ18`

Requirement:

- Required
- Immutable Evidence Identity
- Primary Natural Identity

#### EdinetCode

Purpose:

提出者のEDINET Code。

Example:

`E35948`

Requirement:

- Required when available from EDINET API
- Preserve exact source value

#### SecurityCode

Purpose:

EDINET API上のSecurity Code。

Examples:

- `69630`
- `285A0`

Requirement:

- Preserve exact source value
- Do not normalize destructively

#### FilerName

Purpose:

提出者名称。

Requirement:

- Preserve source filer name
- Historical value may differ from current company name

#### DocumentTypeCode

Purpose:

EDINET document type classification。

Initial target:

`120`

Annual Securities Report。

#### DocumentDescription

Purpose:

人間可読の書類説明。

Example:

`有価証券報告書－第8期(2025/04/01－2026/03/31)`

#### PeriodStart

Purpose:

Filing covered period start。

Nullable:

`YES`

#### PeriodEnd

Purpose:

Filing covered period end。

Nullable:

`YES`

#### SubmitDateTime

Purpose:

EDINET submission timestamp。

Critical use:

Point-in-time availability boundary。

#### WithdrawalStatus

Purpose:

EDINET withdrawal status。

Preserve exact source code。

#### DisclosureStatus

Purpose:

EDINET disclosure status。

Preserve exact source code。

#### XbrlFlag

Purpose:

XBRL availability flag。

#### CsvFlag

Purpose:

CSV availability flag。

#### PdfFlag

Purpose:

PDF availability flag。

Initial implementation may persist for completeness.

#### AttachDocFlag

Purpose:

Attachment availability flag。

#### EnglishDocFlag

Purpose:

English document availability flag。

#### LegalStatus

Purpose:

EDINET legal status code。

#### ParentDocumentId

Purpose:

Parent document reference when provided。

Nullable:

`YES`

#### CurrentReportReason

Purpose:

Current report reason if applicable。

Initial annual report scopeでは通常null。

#### CreatedAt

Purpose:

Internal persistence timestamp。

#### UpdatedAt

Purpose:

Internal metadata update timestamp。

### 4.3 Logical Responsibility Boundary

EdinetFiling stores:

- Filing identity
- Filer identity
- Filing submission metadata
- Availability flags
- Filing status

EdinetFiling does not store:

- XBRL Context
- Source Concept
- Fact value
- Semantic Mapping result

---

## 5. EdinetSourceFile Catalog

### 5.1 Purpose

1 Filing ZIP内の個別Source File identityを保持する。

This catalog answers:

`Which exact source file contained this fact?`

### 5.2 Logical Fields

#### FilingReference

Reference to:

`EdinetFiling`

#### SourceFilePath

Purpose:

ZIP内のrelative path。

Example:

`XBRL/PublicDoc/jpcrp030000-asr-001_E35948-000_2026-03-31_01_2026-06-24.xbrl`

Requirement:

- Preserve exact path
- Required

#### SourceFileName

Purpose:

File name only。

Derived from SourceFilePath if needed。

#### SourceFileTypeCode

Allowed candidate values:

- `PublicDoc`
- `AuditDoc`
- `Other`

#### SourceFormatCode

Allowed candidate values:

- `XBRL`
- `CSV`
- `XML`
- `Other`

Initial implementation target:

`XBRL`

#### ContentChecksum

Purpose:

Source payload checksum。

Recommended algorithm:

`SHA-256`

Nullable in initial implementation:

`YES`

#### ChecksumAlgorithmCode

Candidate:

`SHA256`

Nullable if no checksum stored。

#### ParserVersion

Purpose:

Parser version used to process this source file。

Requirement:

`First-class`

#### SourceSequence

Purpose:

Deterministic file ordering within one Filing archive。

Nullable:

`YES`

#### CreatedAt

Internal persistence timestamp。

### 5.3 Logical Responsibility Boundary

EdinetSourceFile stores:

- File-level identity
- PublicDoc / AuditDoc classification
- format
- parser version
- optional checksum

It does not store:

- Fact semantic meaning
- Canonical mapping
- Context dimensions

---

## 6. EdinetContext Catalog

### 6.1 Purpose

XBRL Context identity及びparsed temporal / consolidation semanticsを保持する。

This catalog answers:

`Under what reporting context was this fact reported?`

### 6.2 Logical Fields

#### FilingReference

Reference to:

`EdinetFiling`

#### ContextRef

Purpose:

Raw XBRL context ID。

Examples:

- `CurrentYearInstant`
- `Prior1YearInstant`
- `CurrentYearDuration`
- `CurrentYearInstant_NonConsolidatedMember`

Requirement:

- Required
- Preserve exact source value

#### PeriodTypeCode

Allowed:

- `Instant`
- `Duration`
- `Forever`
- `Unknown`

#### InstantDate

Used when:

`PeriodTypeCode = Instant`

Nullable otherwise。

#### PeriodStart

Used when:

`PeriodTypeCode = Duration`

Nullable otherwise。

#### PeriodEnd

Used when:

`PeriodTypeCode = Duration`

Nullable otherwise。

#### ConsolidationScopeCode

Allowed:

- `Consolidated`
- `NonConsolidated`
- `Unknown`

#### HasDimensions

Purpose:

Whether Context contains explicit or typed dimensions。

#### DimensionSignature

Purpose:

Normalized deterministic representation of Context dimensions。

Example:

`DimensionA=MemberA|DimensionB=MemberB`

Requirement:

- Optional
- Derived
- Must not replace child dimension records

#### EntityIdentifierScheme

Purpose:

Raw XBRL entity identifier scheme。

Nullable in initial implementation。

#### EntityIdentifierValue

Purpose:

Raw XBRL entity identifier value。

Nullable in initial implementation。

#### CreatedAt

Internal persistence timestamp。

### 6.3 Logical Responsibility Boundary

EdinetContext stores:

- Raw ContextRef
- parsed period semantics
- consolidation scope
- dimension presence
- optional normalized signature

It does not store:

- Source Concept
- Unit
- Raw Fact value

---

## 7. EdinetContextDimension Catalog

### 7.1 Purpose

1 Contextに含まれるDimension / Member pairを保持する。

This catalog answers:

`Which dimensional members refine this context?`

### 7.2 Logical Fields

#### ContextReference

Reference to:

`EdinetContext`

#### DimensionNamespaceUri

Purpose:

Dimension concept namespace。

#### DimensionLocalName

Purpose:

Dimension concept local name。

#### DimensionQName

Purpose:

Human-readable diagnostic QName。

Nullable:

`YES`

#### MemberNamespaceUri

Purpose:

Explicit member namespace。

Nullable for typed dimension。

#### MemberLocalName

Purpose:

Explicit member local name。

Nullable for typed dimension。

#### MemberQName

Purpose:

Human-readable member QName。

Nullable。

#### TypedMemberValue

Purpose:

Typed dimension lexical value。

Nullable for explicit dimension。

#### DimensionTypeCode

Allowed:

- `Explicit`
- `Typed`
- `Unknown`

#### DimensionOrder

Purpose:

Deterministic source order。

### 7.3 Logical Responsibility Boundary

EdinetContextDimension stores:

- exact dimension identity
- exact member identity
- typed member value
- source order

It does not perform:

- segment semantic normalization
- industry interpretation
- member hierarchy resolution

---

## 8. EdinetRawFact Catalog

### 8.1 Purpose

EDINET XBRLから取得した個別FactをSource Evidenceとして保持する。

This catalog answers:

`What exact fact was reported in the source filing?`

### 8.2 Logical Fields

#### FilingReference

Reference to:

`EdinetFiling`

Required:

`YES`

#### SourceFileReference

Reference to:

`EdinetSourceFile`

Required:

`YES`

#### ContextReference

Reference to:

`EdinetContext`

Nullable:

Potentially `YES` for facts without context, but initial numeric financial facts are expected to have a context。

Initial recommendation:

`Required for initial numeric ingestion scope`

#### SourceNamespaceUri

Purpose:

Source Concept namespace URI。

Requirement:

- Required
- Authoritative Source Concept identity component

#### SourceLocalName

Purpose:

Source Concept local name。

Requirement:

- Required

#### SourceQName

Purpose:

Diagnostic / audit QName。

Nullable:

`YES`

#### TaxonomyFamilyCode

Candidate examples:

- `jppfs`
- `jpigp`
- `jpcrp`
- `CompanyExtension`
- `Unknown`

#### TaxonomyVersion

Example:

`2025-11-01`

Nullable for Company Extension or unknown cases。

#### SourceTypeCode

Allowed:

- `StandardTaxonomy`
- `CompanyExtension`
- `OtherExtension`
- `Unknown`

#### UnitRef

Purpose:

Raw XBRL unitRef。

Examples:

- `JPY`
- `shares`
- `pure`

Nullable:

`YES`

#### Decimals

Purpose:

Raw XBRL decimals attribute。

Examples:

- `-3`
- `-6`
- `INF`

Architecture note:

Decimals may not always be an integer lexical representation.

Therefore logical storage must preserve original lexical form.

#### Precision

Purpose:

Raw XBRL precision attribute if present。

Nullable:

`YES`

#### RawValue

Purpose:

Original lexical fact value。

Requirement:

- Required unless fact is nil
- Authoritative source evidence

#### NumericValue

Purpose:

Parsed numeric representation when parsing succeeds。

Nullable:

`YES`

#### TextValue

Purpose:

Parsed text representation for non-numeric facts。

Initial implementation:

`Deferred for broad ingestion`

#### ValueTypeCode

Allowed:

- `Numeric`
- `Text`
- `Html`
- `Boolean`
- `Date`
- `Unknown`

Initial implementation target:

`Numeric`

#### IsNil

Purpose:

Whether source fact is nil。

#### LanguageCode

Purpose:

xml:lang or equivalent language metadata。

Nullable:

`YES`

#### SourceFactSequence

Purpose:

Deterministic occurrence order in source file。

Required:

`YES`

#### OccurrenceIndex

Purpose:

Disambiguate repeated identical concept / context / unit combinations。

Candidate:

Zero-based or one-based sequence。

Final convention deferred to DDL design。

#### ParserVersion

Purpose:

Parser version used to produce persisted record。

Required:

`YES`

#### CreatedAt

Internal persistence timestamp。

### 8.3 Logical Responsibility Boundary

EdinetRawFact stores:

- exact Source Concept identity
- source lexical value
- parsed numeric value
- context reference
- unit
- decimals
- file origin
- parser version

It does not store:

- CanonicalRoleId as semantic result
- MappingRuleId as final normalized meaning
- Derived metrics
- investment interpretation

---

## 9. Code Value Catalog

### 9.1 SourceFileTypeCode

Allowed initial values:

- `PublicDoc`
- `AuditDoc`
- `Other`

### 9.2 SourceFormatCode

Allowed initial values:

- `XBRL`
- `CSV`
- `XML`
- `Other`

### 9.3 PeriodTypeCode

Allowed:

- `Instant`
- `Duration`
- `Forever`
- `Unknown`

### 9.4 ConsolidationScopeCode

Allowed:

- `Consolidated`
- `NonConsolidated`
- `Unknown`

### 9.5 DimensionTypeCode

Allowed:

- `Explicit`
- `Typed`
- `Unknown`

### 9.6 SourceTypeCode

Allowed:

- `StandardTaxonomy`
- `CompanyExtension`
- `OtherExtension`
- `Unknown`

### 9.7 ValueTypeCode

Allowed:

- `Numeric`
- `Text`
- `Html`
- `Boolean`
- `Date`
- `Unknown`

### 9.8 FilingIngestionStatusCode

Candidate values:

- `Discovered`
- `Downloaded`
- `Parsed`
- `Persisted`
- `Failed`

### Catalog Decision

Status persistence may belong to Filing or a future ingestion execution model。

Current decision:

`DEFER PHYSICAL PLACEMENT TO DDL DESIGN`

---

## 10. Natural Identity Catalog

### 10.1 EdinetFiling Natural Identity

Primary natural identity:

`DocumentId`

### 10.2 EdinetSourceFile Natural Identity

Candidate:

```text
Filing
+
SourceFilePath
```

### 10.3 EdinetContext Natural Identity

Candidate:

```text
Filing
+
ContextRef
```

### 10.4 EdinetContextDimension Natural Identity

Candidate:

```text
Context
+
DimensionNamespaceUri
+
DimensionLocalName
+
MemberNamespaceUri
+
MemberLocalName
+
TypedMemberValue
+
DimensionOrder
```

Final simplification deferred to DDL。

### 10.5 EdinetRawFact Natural Identity

Candidate:

```text
Filing
+
SourceFile
+
SourceNamespaceUri
+
SourceLocalName
+
Context
+
UnitRef
+
SourceFactSequence
```

### Important

Do not use only:

```text
DocumentId
+
QName
```

because the same concept may appear under multiple contexts。

---

## 11. Filing Amendment and Correction Catalog

### Rule 1

Different `DocumentId` means different Filing Evidence record。

### Rule 2

Corrected filing must not overwrite original filing。

### Rule 3

Historical backtest eligibility is evaluated by actual `SubmitDateTime`。

### Rule 4

Withdrawal / supersession affects downstream analytical eligibility, not raw persistence。

---

## 12. Point-in-time Catalog

### Required Temporal Anchor

`SubmitDateTime`

Future analytical availability candidate:

`AvailableFrom = SubmitDateTime`

### Principle

A Raw Fact cannot be used in a historical dataset before the source filing was actually submitted。

---

## 13. Parser Version Catalog

### Requirement

Parser Version is first-class metadata。

### Purpose

- parser regression investigation
- controlled reprocessing
- comparison across parser versions
- reproducibility

### Example Candidate

`edinet-xbrl-parser-v1`

Final naming convention deferred。

---

## 14. Source Checksum Catalog

### Candidate Algorithm

`SHA-256`

### Logical Fields

- ChecksumAlgorithmCode
- ContentChecksum

### Initial Requirement

Optional。

### Future Importance

Recommended before broad production ingestion。

---

## 15. Initial Ingestion Scope Catalog

### 15.1 Document Scope

Initial:

`Annual Securities Report`

EDINET Document Type Code:

`120`

### 15.2 Source File Scope

Initial:

`PublicDoc XBRL`

### 15.3 Fact Scope

Initial:

`All numeric facts`

Not only:

`Inventory concepts`

### 15.4 Context Scope

Persist both:

- Consolidated
- NonConsolidated

### 15.5 Dimension Scope

Persist all dimensions encountered in included contexts。

### 15.6 TextBlock Scope

Deferred。

### 15.7 AuditDoc Scope

Deferred from initial analytical ingestion。

---

## 16. Initial Validation Company Catalog

Initial parser / persistence validation should use:

- ROHM
- Fuji Electric
- Sanken Electric
- Torex Semiconductor
- Kioxia Holdings
- Tokyo Electron
- Renesas Electronics

### Validation Goal

Persisted data must reproduce previously observed:

- QName
- Namespace
- ContextRef
- UnitRef
- Decimals
- Value

---

## 17. Known-value Regression Catalog

### Kioxia

Concept:

`InventoriesCAIFRS`

Expected Current Value:

`412612000000`

### Kioxia

Concept:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

Expected Current Value:

`280183000000`

### Tokyo Electron

Concept:

`WorkInProcess`

Expected Current Value:

`210570000000`

### Sanken Electric

Concept:

`WriteDownsOfInventories`

Expected Current Value:

`2412000000`

### Purpose

Detect parser and persistence regression。

---

## 18. Deferred Field Catalog

The following remain deferred:

- full TextBlock persistence
- full source ZIP binary storage
- generic ingestion batch master
- generic unit master
- canonical observation linkage
- semantic mapping execution result
- conflict queue
- unmapped queue
- source download retry history
- parser error detail child table
- amendment supersession resolution table
- company identifier master integration

---

## 19. Reuse / Create / Defer Classification

### Reuse

- Existing `Companies` table where appropriate
- Existing EF Core `StockAnalysisDbContext`
- Existing audit naming convention

### Create New

- `EdinetFiling`
- `EdinetSourceFile`
- `EdinetContext`
- `EdinetContextDimension`
- `EdinetRawFact`

### Defer

- `EdinetIngestionBatch`
- `EdinetUnit`
- Canonical Observation storage
- Runtime Semantic Mapping result storage

---

## 20. Catalog Reviewer Review

### Question 1

Does the Catalog preserve Filing identity?

`YES`

### Question 2

Does it preserve exact Source Concept identity?

`YES`

### Question 3

Does it treat Context as first-class?

`YES`

### Question 4

Does it preserve Dimensions?

`YES`

### Question 5

Does it separate raw lexical value from parsed numeric value?

`YES`

### Question 6

Does it avoid premature Semantic Mapping?

`YES`

### Question 7

Does it support point-in-time reconstruction?

`YES`

### Question 8

Does it support parser versioning?

`YES`

### Question 9

Does it remain generic beyond Inventory?

`YES`

### Question 10

Is the Catalog sufficient to begin DDL design?

`YES`

---

## 21. Catalog Reviewer Decision

### Decision

`APPROVE`

### Catalog Status

`APPROVED FOR DDL DESIGN`

### Approved Logical Entities

- `EdinetFiling`
- `EdinetSourceFile`
- `EdinetContext`
- `EdinetContextDimension`
- `EdinetRawFact`

### Not Yet Approved

- Physical Table Names
- SQL Data Types
- Indexes
- Entity Classes
- Parser implementation
- Runtime ingestion implementation

---

## 22. Catalog Definition of Done

Catalog is complete when:

- Filing fields are defined
- Source File fields are defined
- Context fields are defined
- Dimension fields are defined
- Raw Fact fields are defined
- Code values are cataloged
- Natural identities are defined
- initial ingestion scope is fixed
- known-value regression targets are recorded
- deferred fields are identified
- reviewer decision is recorded

### Result

`DEFINITION OF DONE = PASS`

---

## 23. Final Catalog Decision

### EDINET Raw Fact Persistence Catalog

`APPROVED`

### Next Phase

`DDL DESIGN`

### Required Sequence

```text
Raw Fact Architecture
    ↓
Raw Fact Catalog
    ↓
Raw Fact DDL Design
    ↓
Existing DB Dependency Review
    ↓
Final DDL Specification
    ↓
SQL DDL
    ↓
Entity
    ↓
Parser / Ingestion
    ↓
Regression Validation
```

---

## 24. Exact Next Task

Next Artifact:

`EdinetRawFactPersistenceDDLDesign.md`

### Purpose

> Approved EDINET Raw Fact Persistence Catalogを、Azure SQL / SQL Server上でPoint-in-time再現性、監査可能性、Idempotent Ingestion及び将来のSemantic Mapping Lineageを支えられるPhysical Data Modelへ変換する。

### Required DDL Design Questions

1. Table names
2. Primary key strategy
3. Natural key enforcement
4. DocumentId storage and uniqueness
5. Source file identity
6. Context uniqueness
7. Context dimension uniqueness
8. Raw fact duplicate handling
9. Namespace URI storage
10. RawValue and NumericValue types
11. Decimals lexical storage
12. Source fact sequence
13. parser version storage
14. checksum storage
15. FK delete behavior
16. index strategy
17. filing transaction boundary
18. idempotent re-ingestion support
19. existing `Companies` integration
20. storage volume considerations

### Important

Do not create Entity classes yet.

Next:

`EdinetRawFactPersistenceDDLDesign.md`
