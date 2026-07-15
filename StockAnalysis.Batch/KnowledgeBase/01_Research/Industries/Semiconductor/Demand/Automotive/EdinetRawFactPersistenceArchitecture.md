# EDINET Raw Fact Persistence Architecture

## 1. Document Purpose

本書は、EDINETから取得したXBRL / CSV Financial Factを、Source Identity、Filing Identity、Context、Unit、Decimals、Raw Value及びPoint-in-time Evidenceを保持したまま永続化するためのArchitectureを定義する。

本Architectureの目的は以下である。

> Semantic Mapping、Derived Metric、ML Dataset及びInvestment Decisionへ進む前に、EDINET Source Factそのものを再現可能・監査可能・再処理可能なRaw Observationとして保存する。

本書はRaw Fact Persistence Architectureである。

以下は本書のScope外とする。

- Semantic Mapping Runtime実装
- Canonical Observation生成
- Derived Metric計算
- Investment Interpretation
- ML Feature生成
- Backtestへの投入
- Production Mapping Activation

### Status

- Raw EDINET Fact Persistence Architecture
- Post Semantic Mapping Governance Foundation
- Pre-Catalog
- Pre-DDL
- Pre-Entity
- Pre-Ingestion Implementation

---

## 2. Architecture Background

Inventory Semantic Mapping Phase Aでは以下が完了した。

- Canonical Semantic Role Master
- Semantic Mapping Rule Master
- Mapping Scope
- Evidence Reference
- Rejected Mapping Decision
- EF Core Entity Integration
- Read-only Validation

Validation Result:

- Canonical Roles: `8`
- Mapping Rules: `11`
- Mapping Scopes: `2`
- Evidence References: `11`
- Rejected Decisions: `4`
- Active Mappings: `0`

しかし、Runtime Semantic Mappingを実行するためには、Source Factを永続的に識別できるRaw Fact Persistenceが必要である。

Current Gap:

`Persistent Raw EDINET Fact Identity`

Therefore:

`Raw Fact Persistence Architecture`

must be defined before Runtime Mapping implementation.

---

## 3. Architecture Objective

Raw EDINET Fact Persistence must support the following.

1. Filing Identity Preservation
2. Source Concept Identity Preservation
3. Context Identity Preservation
4. Unit Identity Preservation
5. Decimals Preservation
6. Raw Value Preservation
7. Numeric / Text Fact distinction
8. Consolidated / NonConsolidated distinction
9. Instant / Duration distinction
10. Taxonomy Version traceability
11. Company Extension preservation
12. Duplicate detection
13. Filing correction / amendment handling
14. Reprocessing
15. Semantic Mapping lineage
16. Point-in-time reproducibility

---

## 4. Core Principle

The most important rule is:

`Raw Fact must remain raw.`

Raw Fact persistence must not:

- rename Source Concept into Canonical Role
- merge Combined Concepts
- decompose Combined Concepts
- convert semantic meaning
- remove Source QName
- remove Namespace URI
- discard ContextRef
- discard UnitRef
- discard Decimals
- silently overwrite previous Filing facts

Raw Fact persistence is an Evidence layer.

---

## 5. Layer Model

The future financial semantic pipeline is defined as:

```text
EDINET Filing
    ↓
Raw Source Document
    ↓
Raw XBRL / CSV Fact
    ↓
Fact Eligibility Validation
    ↓
Semantic Mapping
    ↓
Canonical Observation
    ↓
Derived Metrics
    ↓
Comparability Validation
    ↓
ML / Investment Decision
```

Each layer must remain independently auditable.

---

## 6. EDINET Filing Identity

A Raw Fact must belong to one EDINET Filing.

Minimum Filing Identity candidate:

- Document ID
- EDINET Code
- Security Code
- Filer Name
- Document Type Code
- Period Start
- Period End
- Submit DateTime
- Withdrawal Status
- Disclosure Status
- XBRL Flag
- CSV Flag

### Primary Filing Identity

`Document ID`

Example:

`S100YJ18`

### Principle

Do not identify a Filing only by:

- Company
- Fiscal Year
- Submission Date

Document ID is the primary EDINET Filing identity.

---

## 7. Filing Persistence Boundary

Raw Fact rows should not duplicate all Filing metadata.

Recommended separation:

```text
EdinetFilings
    1
    |
    N
EdinetRawFacts
```

### EdinetFilings

Responsible for:

- Filing identity
- filer identity
- submission metadata
- filing status
- document availability flags

### EdinetRawFacts

Responsible for:

- individual Source Fact identity
- Context
- Unit
- Decimals
- Value

### Decision

`Separate Filing and Fact persistence`

---

## 8. Filing Version and Amendment Handling

EDINET may contain:

- Original filing
- Amended filing
- Correction filing
- Withdrawal status changes

Therefore:

A newer filing must not overwrite an older filing record.

### Principle

`Document ID is immutable evidence identity.`

If a correction produces a separate Document ID:

Store both.

Do not update the original filing into the corrected filing.

---

## 9. Source Concept Identity

The Source Concept technical identity is:

```text
Namespace URI
+
Local Name
```

Supporting information:

- QName
- Taxonomy Family
- Taxonomy Version
- Source Type

### QName

Useful for:

- diagnostics
- research
- evidence display

But:

`QName Prefix is not authoritative identity.`

### Required Fields

- Namespace URI
- Local Name
- QName

---

## 10. Taxonomy Identity

Raw Fact persistence should preserve:

- Taxonomy Family
- Taxonomy Version

Examples:

- `jppfs`
- `jpigp`
- `2025-11-01`

### Company Extension

For Company Extension Concepts:

- Namespace URI must be preserved exactly
- Taxonomy Family may be classified as `CompanyExtension`
- Filer-specific identity must remain traceable

### Important

Do not normalize Extension Namespace into Standard Taxonomy identity.

---

## 11. Context Identity

XBRL Context determines the meaning of the same Concept Fact.

Examples:

- `CurrentYearInstant`
- `Prior1YearInstant`
- `CurrentYearDuration`
- `CurrentYearInstant_NonConsolidatedMember`

Therefore:

`Concept identity alone is insufficient.`

Raw Fact persistence must preserve:

- ContextRef
- Period Type
- Instant Date
- Period Start
- Period End
- Consolidation Scope
- Dimension information where available

---

## 12. ContextRef Preservation

`ContextRef`

must always be preserved as Source Evidence.

However:

Runtime analytical logic should not rely solely on hardcoded ContextRef string names.

Reason:

ContextRef naming may vary across filings.

### Architecture Principle

Store both:

1. Raw ContextRef
2. Parsed Context semantics

---

## 13. Parsed Context Semantics

Candidate normalized Context fields:

- PeriodTypeCode
- InstantDate
- PeriodStart
- PeriodEnd
- ConsolidationScopeCode
- HasDimensions
- DimensionSignature

### PeriodTypeCode

Candidate:

- Instant
- Duration
- Forever
- Unknown

### ConsolidationScopeCode

Candidate:

- Consolidated
- NonConsolidated
- Unknown

---

## 14. Dimension Preservation

A Context may contain XBRL dimensions.

Examples:

- NonConsolidatedMember
- Business Segment
- Geographic Segment
- Product category

### Risk

Flattening all Dimension facts into one undifferentiated Fact table without preserving dimensions can create false duplicates.

### Requirement

Raw Fact Architecture must preserve dimension identity.

---

## 15. Dimension Storage Options

### Option A

Store complete normalized Dimension Signature on Raw Fact.

Example:

```text
DimensionA=MemberA|DimensionB=MemberB
```

### Option B

Create child tables:

- EdinetRawFactDimensions

### Option C

Store Context separately and link Facts to Context.

### Preferred Architecture

`Context Master + Context Dimension child`

Reason:

Many Facts share the same Context.

This avoids duplicating Context metadata on every Fact.

---

## 16. Recommended Context Model

```text
EdinetFilings
    |
    | 1
    |
    N
EdinetContexts
    |
    | 1
    |
    N
EdinetRawFacts

EdinetContexts
    |
    | 1
    |
    N
EdinetContextDimensions
```

### Benefits

- avoids repeated Context metadata
- preserves dimension structure
- supports eligibility analysis
- supports Consolidated / NonConsolidated distinction
- improves Raw Fact uniqueness

---

## 17. Unit Identity

Raw Fact must preserve:

- UnitRef
- normalized Unit Code where determinable

Examples:

- JPY
- shares
- pure
- percentage-like ratios

### Principle

`UnitRef must not be discarded even when Unit seems obvious.`

---

## 18. Unit Persistence Options

### Option A

Store UnitRef directly on every Raw Fact.

### Option B

Create EdinetUnits table.

### Preferred Initial Architecture

`Store UnitRef directly on Raw Fact`

Reason:

- lower complexity
- initial scope is financial facts
- Unit reuse volume does not justify separate Master yet

### Future

If compound XBRL Units become important:

Create structured Unit persistence.

---

## 19. Decimals Preservation

Observed values include:

- `-3`
- `-6`

Decimals affects reported precision.

Therefore:

Raw Fact must preserve:

`Decimals`

as Source metadata.

### Important

Do not interpret:

`Raw Value`

without preserving:

`Decimals`

for reconciliation and audit.

---

## 20. Precision and Raw Value

Raw XBRL numeric values may be represented as exact serialized values.

Example:

```text
Value = 412612000000
Decimals = -6
```

Raw Fact persistence should preserve:

- original lexical value
- parsed numeric value where possible

### Recommended Model

Store both:

- `RawValue`
- `NumericValue`

### Reason

Some XBRL facts are:

- numeric
- text
- HTML TextBlock
- nil

A single decimal column is insufficient.

---

## 21. Fact Value Model

Candidate fields:

- RawValue
- NumericValue
- TextValue
- IsNil
- ValueTypeCode

### ValueTypeCode

Candidate:

- Numeric
- Text
- Html
- Boolean
- Date
- Unknown

### Initial Inventory Scope

Most target facts are Numeric.

However Architecture should not make the Raw Fact table inventory-only.

---

## 22. Generic Raw Fact Principle

Raw EDINET Fact persistence should be:

`Generic financial disclosure fact storage`

not:

`Inventory-specific table`

### Reason

Future Knowledge Base expansion will cover:

- Revenue
- CAPEX
- R&D
- Segment data
- Receivables
- Debt
- Cash Flow
- Other industry-specific facts

### Decision

`Generic Raw EDINET Fact Architecture`

---

## 23. Raw Value Storage

### RawValue

Candidate:

`nvarchar(max)` or sufficiently large text

Purpose:

Preserve original lexical source value.

### NumericValue

Candidate:

`decimal(38, 10)` or comparable high precision

### Problem

XBRL values may exceed normal precision or represent very different scales.

### Decision

Exact physical type deferred to DDL Design.

Architecture requirement:

`Raw lexical value must always be preserved.`

Numeric parsing is additive, not destructive.

---

## 24. TextBlock Handling

Some EDINET Facts contain:

- HTML
- XHTML fragments
- narrative disclosures
- tables

Example:

`NotesRegardingWriteDownsOfInventoriesTextBlock`

### Architecture Decision

Raw Fact persistence must support large TextBlock values.

However:

Phase 1 ingestion may choose to persist only selected Fact classes.

### Important

If filtering is used:

Filtering rules must be explicit and reproducible.

---

## 25. Fact Selection Strategy

Three possible ingestion strategies exist.

### Strategy A

Persist all XBRL Facts.

### Strategy B

Persist only financial numeric Facts.

### Strategy C

Persist Research-approved target concepts only.

### Recommended Architecture

`Strategy A-compatible architecture`

but initial implementation may start with:

`Strategy B`

### Reason

Persisting only currently known concepts would destroy future research potential.

---

## 26. Initial Implementation Recommendation

Initial production candidate:

Persist:

- all numeric facts
- source identity
- context
- unit
- decimals
- filing identity

Defer:

- large narrative TextBlocks
- full HTML disclosure storage

### Reason

This supports Semantic Mapping and financial metric research without immediately creating very large storage volume.

### Important

The architecture must still allow future TextBlock ingestion.

---

## 27. Raw Fact Uniqueness

Potential Fact uniqueness cannot be:

```text
DocumentId + QName
```

because the same Concept may occur in multiple Contexts.

Minimum candidate:

```text
Filing
+
Namespace URI
+
Local Name
+
Context
+
Unit
```

Potential duplicates may still exist.

### Additional Factors

- decimals
- language
- fact occurrence
- dimensions

---

## 28. Recommended Fact Natural Identity

Candidate:

```text
FilingId
+
SourceNamespaceUri
+
SourceLocalName
+
ContextId
+
UnitRef
+
OccurrenceIndex
```

### OccurrenceIndex

Needed only when the same exact Concept / Context / Unit combination appears multiple times.

### Alternative

Source XML node sequence.

### Decision

Preserve deterministic source occurrence ordering.

---

## 29. Duplicate Detection

Duplicate Facts may arise from:

- repeated presentation
- source duplication
- parsing behavior
- multiple XBRL files
- audit document inclusion

### Requirement

Fact ingestion must distinguish:

- true duplicate
- separate valid fact
- repeated source occurrence

### Recommendation

Persist:

- Source File Path
- Source Fact Sequence

---

## 30. Source File Identity

EDINET ZIP may contain:

- PublicDoc XBRL
- AuditDoc XBRL
- multiple related files

Raw Fact must preserve:

- Source File Path
- Source File Type

### Example

```text
XBRL/PublicDoc/jpcrp030000-asr-001_....xbrl
```

### Purpose

Prevents mixing PublicDoc and AuditDoc facts.

---

## 31. PublicDoc vs AuditDoc Boundary

Initial financial fact ingestion should prioritize:

`PublicDoc`

AuditDoc should not be mixed automatically into the same analytical Fact set.

### Architecture Requirement

Source File Classification must be preserved.

Candidate:

- PublicDoc
- AuditDoc
- Other

---

## 32. Filing Eligibility

A persisted Filing is not automatically eligible for Semantic Mapping.

Eligibility may depend on:

- Document Type
- Withdrawal Status
- Disclosure Status
- XBRL availability
- filing supersession

### Principle

`Persistence Eligibility ≠ Analytical Eligibility`

Raw Evidence may be stored even when not analytically active.

---

## 33. Raw Fact Eligibility Status

Raw Fact persistence may eventually include:

- Ingested
- Parsed
- Eligible
- Ineligible
- Superseded

### Current Decision

Do not embed full Semantic Mapping eligibility into Raw Fact Entity.

Eligibility should be evaluated by downstream validation.

---

## 34. Point-in-time Requirement

The Stock AI system requires point-in-time correctness.

Therefore each Raw Fact must be traceable to:

- Filing Submit DateTime
- Document ID
- Filing period
- source fact context

### Principle

A Fact must not become available to historical backtests before its actual filing submission time.

### Future Use

`AvailableFrom = Filing Submit DateTime`

may become a key temporal field in dataset construction.

---

## 35. Correction and Restatement Handling

If a company files:

- original report
- amended report
- corrected report

do not silently overwrite.

### Required Behavior

Persist all filings.

Later:

Eligibility / supersession logic decides which filing is active for a given as-of date.

### Historical Backtest

For a historical date:

Use only filings available by that date.

---

## 36. Idempotent Ingestion

Re-running ingestion for the same Filing must not create uncontrolled duplicates.

### Requirement

Ingestion should be idempotent.

Candidate pattern:

1. Check Filing by Document ID
2. Check Source File identity
3. Check Context identity
4. Check Raw Fact natural identity
5. Insert missing records only
6. Detect semantic mismatch

---

## 37. Ingestion Version

Parser logic may evolve.

Therefore:

Raw Fact persistence should support:

- Parser Version
- Ingestion Version

### Purpose

A parser bug fix may require reprocessing the same Filing.

### Candidate fields

- ParserVersion
- IngestionBatchId

### Current Decision

Parser Version should be first-class.

Batch infrastructure dependency remains open.

---

## 38. Reprocessing Principle

Raw Source Filing should not need to be re-downloaded if source files are retained.

Possible storage models:

### Option A

Persist original ZIP bytes.

### Option B

Persist extracted source files.

### Option C

Re-download from EDINET when needed.

### Architecture Lean

For auditability:

`retain Source Document reference and optionally source payload checksum`

Full binary retention decision requires storage-cost review.

---

## 39. Source Checksum

Recommended:

Persist checksum for downloaded source artifact.

Candidate:

`SHA-256`

### Purpose

- detect source corruption
- verify reprocessing consistency
- prove source payload identity

### Important

Checksum supplements Document ID.

It does not replace it.

---

## 40. Proposed Logical Persistence Model

Initial logical entities:

1. `EdinetFiling`
2. `EdinetSourceFile`
3. `EdinetContext`
4. `EdinetContextDimension`
5. `EdinetRawFact`

Potential future:

6. `EdinetIngestionBatch`
7. `EdinetUnit`

---

## 41. EdinetFiling Responsibility

Stores:

- Document ID
- EDINET Code
- Security Code
- Filer Name
- Document Type
- Period
- Submit DateTime
- Filing status
- availability flags

Primary identity:

`DocumentId`

---

## 42. EdinetSourceFile Responsibility

Stores:

- Filing ID
- Source file path
- Source file type
- checksum
- parser version
- ingestion metadata

Relationship:

```text
EdinetFiling
    1
    |
    N
EdinetSourceFile
```

---

## 43. EdinetContext Responsibility

Stores:

- Filing ID
- ContextRef
- Period type
- instant date
- duration start
- duration end
- consolidation scope
- dimension presence
- normalized signature

Relationship:

```text
EdinetFiling
    1
    |
    N
EdinetContext
```

---

## 44. EdinetContextDimension Responsibility

Stores:

- Context ID
- Dimension Namespace
- Dimension Local Name
- Member Namespace
- Member Local Name
- Typed dimension value if applicable

Relationship:

```text
EdinetContext
    1
    |
    N
EdinetContextDimension
```

---

## 45. EdinetRawFact Responsibility

Stores:

- Filing ID
- Source File ID
- Context ID
- Source Concept identity
- UnitRef
- Decimals
- Raw Value
- parsed Numeric Value
- Value Type
- nil flag
- source sequence
- parser version

Relationship:

```text
EdinetFiling
    1
    |
    N
EdinetRawFact

EdinetContext
    1
    |
    N
EdinetRawFact

EdinetSourceFile
    1
    |
    N
EdinetRawFact
```

---

## 46. Existing Companies Relationship

Existing `Companies` table should not be duplicated.

However:

`EdinetFiling`

may store both:

- SecurityCode
- EdinetCode

### Relationship Candidate

Optional link to existing `Companies.Code`.

### Problem

EDINET Security Code format may include five-character values such as:

- `69630`
- `285A0`

Existing J-Quants Company Code normalization must be reviewed.

### Decision

Do not make `CompanyCode` FK mandatory in first Raw Fact DDL.

Preserve source identifiers first.

---

## 47. Security Code Normalization Boundary

Do not remove the EDINET source security code.

Example:

`69630`

Even if internal Company Code is:

`6963`

Both should remain distinguishable.

### Principle

`Source identifier preservation before normalization.`

---

## 48. Semantic Mapping Integration Boundary

Future Semantic Mapping Runtime will read:

`EdinetRawFact`

and resolve against:

`SemanticMappingRules`

using:

- Namespace URI
- Local Name
- Source Type
- Accounting Standard
- EDINET Code
- Context eligibility

### Important

Raw Fact table must not directly store:

`CanonicalRoleId`

as the only semantic result.

Mapping output belongs to a separate downstream layer.

---

## 49. Mapping Version Lineage

When Raw Fact becomes a Canonical Observation:

Future lineage should preserve:

- RawFactId
- MappingRuleId
- MappingVersion
- CanonicalRoleId

This confirms the previously deferred:

`SemanticCanonicalObservationLineages`

dependency.

---

## 50. Raw Fact Architecture vs Semantic Mapping Governance

### Raw Fact Architecture answers

`What did EDINET actually report?`

### Semantic Mapping Governance answers

`How may that Source Concept be normalized?`

### Canonical Observation answers

`What normalized semantic observation was produced?`

These must remain separate.

---

## 51. Storage Volume Consideration

Persisting all XBRL facts across all listed companies may become large.

Potential drivers:

- 4,000+ companies
- annual reports
- quarterly reports
- many contexts
- narrative facts

### Initial Cost Control

Start with:

- selected document types
- numeric facts
- PublicDoc
- annual securities reports

Then expand.

### Important

Architecture remains generic.

---

## 52. Initial Document Type Scope

Recommended initial target:

`Annual Securities Report`

EDINET Document Type Code:

`120`

### Reason

Current Inventory Research and Semantic Mapping evidence are based on annual securities reports.

### Future

Add:

- quarterly / semiannual reports
- amended reports
- other filing types

after ingestion architecture validation.

---

## 53. Initial Source File Scope

Recommended:

`PublicDoc XBRL`

### Exclude initially

- AuditDoc facts
- unrelated attachments

### Reason

Current research confirmed required inventory facts in PublicDoc XBRL.

---

## 54. Initial Fact Scope

Recommended initial implementation:

- Numeric Facts
- PublicDoc
- Annual Securities Reports
- Consolidated and NonConsolidated contexts both persisted
- All numeric concepts, not only inventory

### Reason

Preserves future reuse without excessive TextBlock storage.

---

## 55. Initial Ingestion Workflow

```text
Discover EDINET Filing
    ↓
Persist / resolve EdinetFiling
    ↓
Download XBRL ZIP
    ↓
Resolve PublicDoc XBRL files
    ↓
Persist Source File metadata
    ↓
Parse Contexts
    ↓
Persist Contexts
    ↓
Persist Context Dimensions
    ↓
Parse Numeric Facts
    ↓
Persist Raw Facts
    ↓
Validate counts
```

---

## 56. Transaction Boundary

Recommended:

One Filing ingestion per transaction.

### Reason

A Filing should not remain partially persisted as:

- Filing exists
- contexts missing
- facts partially inserted

### Alternative for large filings

Staged ingestion may later be required.

Initial recommendation:

`One Filing = One controlled transaction`

---

## 57. Failure Handling

Possible states:

- FilingDiscovered
- Downloaded
- Parsed
- Persisted
- Failed

### Current Decision

Operational ingestion status model should be considered in Catalog / DDL.

Do not silently swallow parsing failures.

---

## 58. Error Isolation

One Filing failure must not block ingestion of all other Filings.

### Principle

`Fail per Filing, not globally.`

---

## 59. Parser Validation

Before broad ingestion, validate against known research companies:

- ROHM
- Fuji Electric
- Sanken Electric
- Torex Semiconductor
- Kioxia Holdings
- Tokyo Electron
- Renesas Electronics

### Validation Goal

Persisted Raw Facts must reproduce previously observed:

- QName
- Namespace
- ContextRef
- UnitRef
- Decimals
- Value

---

## 60. Known-value Regression Validation

The initial Raw Fact parser should include regression checks against known values.

Examples:

### Kioxia

`InventoriesCAIFRS`

Current:

`412612000000`

### Kioxia

`SemiFinishedProductsAndWorkInProgressCAIFRS`

Current:

`280183000000`

### Tokyo Electron

`WorkInProcess`

Current:

`210570000000`

### Sanken Electric

`WriteDownsOfInventories`

Current:

`2412000000`

### Purpose

Detect parser regression.

---

## 61. Architecture Risks

Known risks:

1. XBRL Context complexity
2. Dimension complexity
3. Duplicate facts
4. Extension namespace proliferation
5. filing corrections
6. parser evolution
7. storage volume
8. text block size
9. source identifier mismatch
10. point-in-time errors

---

## 62. Risk Mitigation

- preserve exact source identity
- separate Filing / Context / Fact
- preserve dimensions
- preserve raw lexical values
- version parser
- idempotent ingestion
- known-value regression tests
- conservative initial scope
- no premature semantic normalization

---

## 63. Architecture Reviewer Review

### Question 1

Should Raw Facts be stored directly in `FinancialStatements`?

`NO`

Reason:

Existing `FinancialStatements` is summary-oriented and lacks required source lineage.

### Question 2

Should Inventory facts use an inventory-specific Raw table?

`NO`

Reason:

Raw EDINET architecture should be reusable across financial concepts.

### Question 3

Should Context be stored separately?

`YES`

Reason:

Context semantics and dimensions are reusable across many facts.

### Question 4

Should Company Extension Concepts be normalized before persistence?

`NO`

Preserve exact extension identity.

### Question 5

Should only known Semantic Mapping concepts be persisted?

`NO`

Initial implementation may restrict to numeric facts, but not only known concepts.

### Question 6

Should corrected filings overwrite original filings?

`NO`

Preserve all Document IDs.

### Question 7

Should Runtime Semantic Mapping begin now?

`NO`

Raw Fact persistence must be implemented and validated first.

---

## 64. Architecture Reviewer Decision

### Decision

`APPROVE`

### Approved Logical Model

- EdinetFiling
- EdinetSourceFile
- EdinetContext
- EdinetContextDimension
- EdinetRawFact

### Initial Implementation Scope

- Annual Securities Reports
- PublicDoc XBRL
- Numeric Facts
- all numeric concepts
- exact source identity preservation

### Deferred

- narrative TextBlocks
- full source binary retention decision
- generic ingestion batch model
- Runtime Semantic Mapping
- Canonical Observation persistence

---

## 65. Definition of Done

Architecture is complete when:

- Filing identity is defined
- Source file identity is defined
- Source concept identity is defined
- Context persistence is defined
- Dimension persistence is defined
- Unit preservation is defined
- Decimals preservation is defined
- raw and parsed values are separated
- duplicate handling is defined
- amendment handling is defined
- point-in-time boundary is defined
- initial ingestion scope is defined
- Semantic Mapping boundary is preserved
- reviewer decision is recorded

### Result

`DEFINITION OF DONE = PASS`

---

## 66. Final Architecture Decision

### Raw EDINET Fact Persistence Architecture

`APPROVED`

### Next Phase

`CATALOG DESIGN`

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
Final DDL
    ↓
Entity
    ↓
Parser / Ingestion
    ↓
Regression Validation
    ↓
Runtime Semantic Mapping
```

---

## 67. Exact Next Task

Next Artifact:

`EdinetRawFactPersistenceCatalog.md`

### Purpose

> Raw EDINET Fact Persistence Architectureで承認されたFiling、Source File、Context、Dimension及びRaw Factの論理項目をCatalogとして固定する。

### Required Sections

1. Catalog Purpose
2. EdinetFiling Catalog
3. EdinetSourceFile Catalog
4. EdinetContext Catalog
5. EdinetContextDimension Catalog
6. EdinetRawFact Catalog
7. Code Value Catalog
8. Natural Identity Catalog
9. Initial Ingestion Scope
10. Deferred Fields
11. Catalog Reviewer Gate
12. Definition of Done

### Important

まだDDLは作成しない。

次は:

`EdinetRawFactPersistenceCatalog.md`

を作成する。
