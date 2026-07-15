# EDINET Raw Fact Persistence Existing Database Dependency Review

## 1. Document Purpose

本書は、`EdinetRawFactPersistenceDDLDesign.md`で定義されたEDINET Raw Fact Persistence DDL候補について、現在確認可能なStock Analysis Systemの既存Database、DbContext運用、EDINET Prototype Service、DTO、Program実行方式及び既存Research Decisionとの依存関係をレビューし、

- Reuse Existing
- Extend Existing
- Create New
- Defer

を判定するDependency Review Artifactである。

本Reviewの目的は以下である。

> Raw EDINET Fact Persistenceを既存Architectureへ重複・競合なく追加し、Prototype資産を無理にProduction化せず、再利用可能な部分のみを明確に再利用する。

### Status

- Existing Database Dependency Review
- DDL Dependency Gate
- Pre-Final DDL Specification
- Conditional Approval
- Current Repository Full-file Verification Still Required

---

## 2. Review Evidence Scope

本Reviewでは、現在確認可能な以下のEvidenceを使用する。

### Existing Program Execution Evidence

現在のBatch Applicationは、

- `StockAnalysisDbContext`
- Azure SQL
- EF Core
- `HttpClient`
- Boolean実行Flag
- `Program.cs`による直接Service起動

を使用している。

Database接続は`DbContextOptionsBuilder<StockAnalysisDbContext>`から生成され、`await using var db = new StockAnalysisDbContext(options);`でContextを保持している。

### Existing Persistence Pattern Evidence

既存の財務データ保存処理では、

- `FindAsync`
- Entity追加
- 既存行更新
- `SaveChangesAsync`

という直接的なEF Core Persistence Patternを採用している。

既存処理は`DateTime.Now`を使用する。

### Existing EDINET Prototype Evidence

`EdinetInventoryPrototypeService`は以下を既に実装している。

- EDINET API Key取得
- Document List API呼び出し
- `EdinetDocumentListResponse`へのDeserialize
- `EdinetDocumentDto`利用
- EDINET Codeによる書類抽出
- CSV ZIP取得
- XBRL ZIP取得
- ZIP Entry確認
- Inventory Candidate検索
- Raw XBRL Fact候補確認

同ServiceのClass Commentでは明確に、

- Production Serviceではない
- DB保存を行わない
- 全企業取得を行わない
- 履歴Backfillを行わない

と定義されている。

### Existing EDINET Research Boundary Evidence

過去ResearchではPrototype段階で以下を禁止していた。

- 全企業取得
- 日次EDINET監視Batch
- Database Entity
- Migration
- Generic XBRL Parser
- Historical Backfill

これは当時のPrototype Boundaryであり、現在はResearch・Semantic Mapping Governanceを経て次のArchitecture Phaseへ進んでいる。

### Existing Source Structure Evidence

Raw XBRL ZIPには、

- `XBRL/PublicDoc/...`
- `XBRL/AuditDoc/...`
- XSD
- definition linkbase
- presentation linkbase
- label linkbase
- inline XBRL HTML
- manifest

等が含まれることを実取得で確認済みである。

Inventory Fact候補はPublicDoc XBRLから確認され、AuditDocでは対象Fact候補が見つからないケースが複数確認されている。

---

## 3. Review Limitation

本Reviewは、現在このReview時点で直接確認できたConversation内の既存Source Evidenceを基にしている。

以下のCurrent Repository Full Fileを完全には直接確認できていない。

- 最新`StockAnalysisDbContext.cs`全文
- 最新`EdinetDocumentDto.cs`全文
- 最新`EdinetDocumentListResponse.cs`全文
- EDINET関連全ファイル一覧
- 最新Repository上の全Table / Entity一覧

したがって、本Reviewは以下を主張しない。

`The complete current repository has been exhaustively inspected.`

### Required Local Verification Before Final SQL

Final DDL Specification作成前、または少なくともSQL適用前に、Repository上で以下を確認する。

```text
git grep -n "class Edinet"
git grep -n "DbSet<Edinet"
git grep -n "EdinetFilings"
git grep -n "EdinetRawFacts"
git grep -n "EdinetContexts"
git grep -n "EdinetSourceFiles"
```

またはIDE全文検索で同等の確認を行う。

### Review Decision Impact

Current evidence is sufficient to make Architecture-level dependency decisions.

However:

`Table name collision absence is conditionally approved, not absolutely proven.`

---

## 4. Dependency Review Summary

| Dependency | Decision |
|---|---|
| Existing Companies | REUSE WITHOUT MANDATORY FK |
| Existing FinancialStatements | DO NOT EXTEND |
| Existing StockAnalysisDbContext | EXTEND |
| Existing EDINET Document DTO | REUSE / EXTEND |
| Existing EDINET Document List Response DTO | REUSE |
| Existing EdinetInventoryPrototypeService | DO NOT PROMOTE DIRECTLY |
| Existing HTTP / API Key Pattern | REUSE |
| Existing ZIP Download Logic | EXTRACT / REUSE |
| Existing XBRL Candidate Print Logic | RESEARCH-ONLY / DO NOT REUSE AS PARSER |
| Existing Generic XBRL Parser | NOT CONFIRMED |
| Existing EDINET Persistence Tables | NOT CONFIRMED |
| Existing Transaction Infrastructure | NOT CONFIRMED |
| Existing Ingestion Batch Model | NOT CONFIRMED |
| Existing Timestamp Convention | REUSE CURRENT CONVENTION |
| Existing DB Deployment Pattern | MANUAL REVIEWED SQL COMPATIBLE |
| EdinetFilings | CREATE NEW |
| EdinetSourceFiles | CREATE NEW |
| EdinetContexts | CREATE NEW |
| EdinetContextDimensions | CREATE NEW |
| EdinetRawFacts | CREATE NEW |
| EdinetIngestionBatch | DEFER |
| EdinetUnit | DEFER |

---

## 5. Dependency: Existing Companies

### Existing Role

The existing `Companies` table is the application company master.

It must not be duplicated by EDINET persistence.

### EDINET Identifier Difference

EDINET source identifiers include:

- EDINET Code
- Security Code

Examples:

```text
E01953
69630
```

Internal application Company Code may use a different representation.

### Risk

Making `EdinetFilings` immediately depend on `Companies.Code` through a mandatory Foreign Key could create:

- code normalization dependency
- alphanumeric code mismatch
- historical identifier issues
- failed ingestion for unresolved issuers

### Decision

`REUSE EXISTING WITHOUT MANDATORY FK`

### Phase 1

Persist exact source identifiers:

- EdinetCode
- SecurityCode

### Future

Create or review a broader Company Identifier resolution model separately.

---

## 6. Dependency: Existing FinancialStatements

### Existing Role

Existing `FinancialStatements` stores J-Quants summary financial data.

Current persistence logic updates summarized values such as:

- NetSales
- OperatingProfit
- Profit
- EPS
- EquityToAssetRatio
- BPS
- Dividend values

### Raw EDINET Requirement

Raw EDINET Facts require:

- Document identity
- exact Namespace URI
- Local Name
- QName
- Context
- Dimensions
- Unit
- Decimals
- Raw lexical value
- Source file lineage
- Parser version

### Decision

`DO NOT EXTEND`

### Reason

Extending `FinancialStatements` would mix:

- summary disclosure records
- individual source facts
- different key semantics
- different update semantics
- different lineage requirements

This would violate the approved Raw Observation boundary.

---

## 7. Dependency: Existing StockAnalysisDbContext

### Existing Pattern

The application already uses one central:

`StockAnalysisDbContext`

for the current Batch application.

Semantic Mapping Phase A has also already been integrated into the same DbContext and validated successfully.

### Decision

`EXTEND EXISTING`

Add future DbSet entries for:

- EdinetFilings
- EdinetSourceFiles
- EdinetContexts
- EdinetContextDimensions
- EdinetRawFacts

### Important

Do not create a second DbContext solely for EDINET Raw Persistence at this phase.

### Reason

A second context would add:

- transaction boundary complexity
- configuration duplication
- migration/deployment complexity
- cross-context lineage complexity

without demonstrated need.

---

## 8. Dependency: Existing EdinetDocumentDto

### Existing Evidence

The Prototype already uses:

`EdinetDocumentDto`

as the DTO returned from Document List API parsing.

Observed metadata includes at least:

- DocumentId
- EdinetCode
- SecurityCode
- FilerName
- DocumentTypeCode
- PeriodStart
- PeriodEnd
- SubmitDateTime
- ParentDocumentId
- WithdrawalStatus
- DisclosureStatus
- XbrlFlag
- CsvFlag

The raw response also contains additional fields such as:

- pdfFlag
- attachDocFlag
- englishDocFlag
- legalStatus
- ordinanceCode
- formCode
- JCN
- docInfoEditStatus

### Decision

`REUSE / EXTEND`

### Rule

Do not create a duplicate Production DTO if the existing DTO can be safely expanded.

### Required Review Before Entity Implementation

Compare current `EdinetDocumentDto` against the final `EdinetFiling` fields.

If fields are missing:

`extend DTO`

rather than introducing another near-identical Document List DTO.

### Important Boundary

DTO and Entity remain separate responsibilities.

Do not use EF Entity directly as API response DTO.

---

## 9. Dependency: Existing EdinetDocumentListResponse

### Existing Evidence

Prototype successfully deserializes Document List API response using:

`EdinetDocumentListResponse`

and accesses:

- Metadata
- Parameter
- ResultSet
- Results

### Decision

`REUSE`

### Reason

This API response model is already validated against real EDINET responses.

No architectural reason exists to replace it.

### Future Refactoring

It may later move into a generic EDINET API client layer, but behavior should be preserved.

---

## 10. Dependency: Existing EdinetInventoryPrototypeService

### Current Responsibility

The Class itself explicitly states:

- ROHM inventory acquisition prototype
- Production Serviceではない
- DB保存なし
- 全企業取得なし
- Backfillなし

### Current Capabilities

It combines multiple responsibilities:

- API communication
- Document List retrieval
- Company filtering
- ZIP download
- ZIP inspection
- CSV candidate search
- XBRL candidate search
- console research output

### Risk

Promoting this Class directly into Production would preserve Prototype coupling:

- ROHM-specific constants
- Inventory-specific naming
- Console-heavy diagnostics
- Research-only candidate search
- no persistence boundary
- no parser abstraction

### Decision

`DO NOT PROMOTE DIRECTLY`

### Reuse Strategy

Extract or reuse only validated low-level behavior:

- API Key retrieval convention
- EDINET request construction
- response content-type validation
- CSV ZIP download behavior where needed
- XBRL ZIP download behavior
- Document List deserialization

### New Production Responsibility Candidate

Future services may be separated conceptually into:

```text
EdinetApiClient
EdinetXbrlArchiveReader
EdinetXbrlParser
EdinetRawFactIngestionService
```

### Important

Do not create all four automatically without implementation review.

The exact class split should occur during Parser / Ingestion Design.

---

## 11. Dependency: Existing HTTP and API Key Pattern

### Existing Pattern

The application uses:

- shared `HttpClient` created in Program
- `IConfiguration`
- `Edinet:ApiKey`
- no source-code hardcoding

### Decision

`REUSE`

### Production Improvement Candidate

The future application may eventually use:

- `IHttpClientFactory`
- typed client
- retry policy

However, this is not required to implement Raw Fact persistence.

### Decision

`DO NOT BLOCK RAW PERSISTENCE ON HTTP CLIENT REFACTOR`

---

## 12. Dependency: Existing ZIP Download Logic

### Existing Evidence

Prototype successfully retrieves:

- type=5 CSV ZIP
- XBRL ZIP

and validates Content-Type.

### Decision

`REUSE BEHAVIOR`

### Implementation Form

Prefer extracting reusable download behavior rather than copy-pasting the entire Prototype Service.

### Important

The production ingestion path should not depend on:

- ROHM-specific method names
- console candidate search
- inventory keywords

---

## 13. Dependency: Existing XBRL Candidate Search Logic

### Existing Purpose

Current XBRL logic prints candidate facts and was built for Research validation.

It successfully proved access to:

- QName
- Namespace
- ContextRef
- UnitRef
- Decimals
- Value

### Limitation

Candidate search is not equivalent to a production parser.

It may:

- filter by keywords
- print selected facts
- not persist contexts
- not persist dimensions
- not guarantee deterministic fact sequence
- not implement idempotency

### Decision

`RESEARCH-ONLY`

### Reuse

Useful for:

- regression comparison
- known-value validation
- parser acceptance tests

### Do Not Reuse As

`Production Raw Fact Parser`

---

## 14. Dependency: Generic XBRL Parser

### Current Evidence

No confirmed generic production XBRL parser exists.

### Decision

`CREATE NEW PARSER RESPONSIBILITY REQUIRED`

### Important

This does not yet mean creating a new Class immediately.

First create:

`XBRL Parser Design / Parsing Contract`

after Final DDL and Entity integration.

### Required Parser Outputs

At minimum:

- Source files
- Contexts
- Context dimensions
- Numeric facts
- deterministic SourceFactSequence
- parser version

---

## 15. Dependency: Existing EDINET Persistence Tables

### Current Evidence

No confirmed existing tables named:

- EdinetFilings
- EdinetSourceFiles
- EdinetContexts
- EdinetContextDimensions
- EdinetRawFacts

have been identified in the reviewed evidence.

### Decision

`CREATE NEW, SUBJECT TO LOCAL NAME COLLISION CHECK`

### Required Local Check

Before SQL application:

```text
Search repository
+
Check Azure SQL object names
```

### Review Status

`CONDITIONAL CREATE NEW`

---

## 16. Dependency: Existing Transaction Pattern

### Existing Evidence

Current persistence helpers generally call:

`SaveChangesAsync`

after a logical batch of operations.

No confirmed generic transaction abstraction for EDINET filing ingestion has been identified.

### Raw Filing Requirement

The approved architecture requires:

`One Filing = One controlled transaction`

for initial ingestion.

### Decision

`CREATE TRANSACTION BOUNDARY IN INGESTION SERVICE`

### Do Not Create

A generic repository/unit-of-work framework solely for this feature.

### Preferred Future Pattern

Use EF Core database transaction directly:

```text
BeginTransactionAsync
↓
Persist Filing
↓
Persist Source Files
↓
Persist Contexts
↓
Persist Dimensions
↓
Persist Facts
↓
SaveChanges
↓
Commit
```

Exact implementation occurs later.

---

## 17. Dependency: Existing Batch / Ingestion History

### Current Evidence

No persistent generic ingestion batch model is confirmed.

Current Batch selection is controlled by Program execution flags.

### Decision

`DEFER GENERIC INGESTION BATCH TABLE`

### Phase 1

Use:

- ParserVersion
- CreatedAt
- Filing identity
- Source file identity

for reproducibility.

### Future Trigger

Create `EdinetIngestionBatch` only if needed for:

- scheduled production ingestion
- retry history
- multi-parser reprocessing
- operational monitoring
- backfill control

---

## 18. Dependency: Current Program Execution Flags

### Existing Pattern

Development and validation workflows are selected using Boolean constants in `Program.cs`.

### Decision

`REUSE FOR INITIAL VALIDATION ONLY`

### Do Not Treat As

Long-term production orchestration.

### Initial Parser Validation

A temporary flag such as:

`RUN_EDINET_RAW_FACT_INGESTION_VALIDATION`

may be acceptable.

### Future Production

Scheduled ingestion architecture should be reviewed separately.

---

## 19. Dependency: Existing Timestamp Convention

### Existing Evidence

Current code frequently uses:

`DateTime.Now`

Existing Semantic Mapping tables were designed to follow the current project timestamp convention.

### Decision

`REUSE CURRENT CONVENTION`

### Important

Do not introduce isolated UTC semantics without project-wide migration.

### DDL

Use:

- CreatedAt
- UpdatedAt
- `SYSDATETIME()` default where database-generated

### Point-in-time Source Time

`SubmitDateTime`

must preserve EDINET source time semantics independently from internal CreatedAt.

---

## 20. Dependency: Existing ID Strategy

### Existing Project

Multiple key strategies exist.

Raw Fact volume differs substantially from Governance table volume.

### Decision

- EdinetFilings: `int`
- EdinetSourceFiles: `int`
- EdinetContexts: `int`
- EdinetContextDimensions: `int`
- EdinetRawFacts: `bigint`

### Review

`APPROVE`

### Reason

Raw Fact is the only table with plausible very large long-term row count.

---

## 21. Dependency: SourceFactSequence

### Previous DDL Design

Primary idempotency candidate:

`SourceFileId + SourceFactSequence`

### Existing Prototype Compatibility

Current candidate-print logic does not establish a formal deterministic sequence contract.

### Risk

If parser traversal order changes across versions, sequence-based identity could become unstable.

### Revised Decision

`KEEP AS CANDIDATE, NOT YET FINAL`

### Required Before Final DDL

Parser contract must define SourceFactSequence deterministically.

### Recommended Definition

`0-based document order of persisted fact elements within one exact source file`

### Additional Protection

Natural semantic fields must also be compared on re-ingestion.

### DDL Reviewer Status

`CONDITIONAL APPROVE`

---

## 22. Dependency: ParserVersion Duplication

### Previous DDL Design

ParserVersion exists on:

- EdinetSourceFiles
- EdinetRawFacts

### Review

This may be redundant.

### Interpretation

Source file parser version describes:

`Which parser process handled this file`

Fact parser version describes:

`Which parser logic produced this fact`

In a simple one-pass parser these are identical.

### Revised Decision

For Phase 1:

`STORE ParserVersion ON EdinetSourceFiles ONLY`

### Reason

- avoids per-fact string duplication
- reduces Raw Fact storage cost
- SourceFileId already provides lineage
- initial ingestion is one parser execution per source file

### Future

If multiple fact derivation versions from one persisted source file are required:

Add ingestion/version model later.

### Material DDL Change

Remove:

`EdinetRawFacts.ParserVersion`

from initial DDL candidate.

---

## 23. Dependency: FilingId on EdinetRawFacts

### Previous DDL Design

Raw Fact stores both:

- FilingId
- SourceFileId
- ContextId

### Redundancy

SourceFile already belongs to Filing.

Context also belongs to Filing.

### Options

#### Option A

Keep FilingId for query performance and integrity checks.

#### Option B

Remove FilingId and derive through SourceFile / Context.

### Review Decision

`KEEP FilingId`

### Reason

- common filing-level fact queries
- simpler semantic mapping ingestion queries
- easier partitioning/indexing candidate
- explicit evidence root

### Required Integrity

Application validation must ensure:

```text
RawFact.FilingId
=
SourceFile.FilingId
=
Context.FilingId
```

### Future DB Enforcement

SQL cannot easily enforce this with simple FKs.

Do not add complex triggers initially.

---

## 24. Dependency: NumericValue Type

### Previous Candidate

`decimal(38,10)`

### Review

For common financial facts this is likely sufficient.

However:

- XBRL numeric values vary
- some ratios may use high scale
- large monetary values may consume precision
- RawValue remains authoritative

### Decision

`APPROVE decimal(38,10) AS OPTIONAL PARSED VALUE`

### Safety Rule

Parser must:

- preserve RawValue always
- use safe `TryParse`
- set NumericValue null if representation is unsafe
- never discard a fact due to NumericValue parse failure

### Status

`APPROVE`

---

## 25. Dependency: RawValue and TextValue

### Initial Scope

Numeric facts only.

### Previous DDL Candidate

Both:

- RawValue
- TextValue

### Review

For numeric-only initial ingestion, TextValue duplicates RawValue and is not used.

### Revised Decision

`DEFER TextValue COLUMN`

### Initial Raw Fact

Keep:

- RawValue
- NumericValue
- ValueTypeCode

### Future Text Fact Expansion

RawValue can already preserve lexical text.

A dedicated TextValue should be added only if normalized text processing requires it.

### Material DDL Change

Remove:

`TextValue`

from initial DDL candidate.

---

## 26. Dependency: ValueTypeCode

### Initial Scope

Numeric facts only.

### Question

Is ValueTypeCode necessary if all initial persisted facts are Numeric?

### Decision

`KEEP`

### Reason

- generic table compatibility
- explicit ingestion semantics
- future expansion without table redesign

### Initial Allowed Values

Keep existing controlled set.

---

## 27. Dependency: SourceFileName

### Previous Candidate

Store both:

- SourceFilePath
- SourceFileName

### Review

`SourceFileName` is fully derivable from `SourceFilePath`.

### Decision

`REMOVE SourceFileName FROM INITIAL TABLE`

### Reason

Avoid redundant persistence.

Application may derive:

`Path.GetFileName(SourceFilePath)`

### Material DDL Change

EdinetSourceFiles initial fields should not require SourceFileName.

---

## 28. Dependency: SourceSequence on EdinetSourceFiles

### Previous Candidate

Optional archive file ordering.

### Review

No current downstream requirement depends on ZIP entry order.

### Decision

`DEFER`

### Reason

SourceFilePath is the stable file identity.

### Material DDL Change

Remove SourceSequence from initial table.

---

## 29. Dependency: Filing Metadata Completeness

### Current DTO / Raw Response

The existing EDINET response includes more metadata than the initial minimal Filing candidate.

Examples:

- JCN
- ordinanceCode
- formCode
- issuerEdinetCode
- subjectEdinetCode
- subsidiaryEdinetCode
- opeDateTime
- docInfoEditStatus

### Question

Should all fields be persisted now?

### Decision

`PERSIST HIGH-VALUE SOURCE METADATA, NOT EVERY API FIELD`

### Recommended Initial Additions

Add to EdinetFilings:

- `Jcn`
- `OrdinanceCode`
- `FormCode`
- `DocumentInfoEditStatus`
- `OperationDateTime`

### Reason

These may matter for:

- filing classification
- revision metadata
- source traceability

### Defer

- issuerEdinetCode
- subjectEdinetCode
- subsidiaryEdinetCode

until a concrete use case appears.

### Material DDL Change

Initial Filing design should be expanded slightly beyond the first candidate.

---

## 30. Dependency: SubmitDateTime Nullability

### Existing Real Responses

Target annual securities report examples include SubmitDateTime.

### Point-in-time Requirement

SubmitDateTime is essential.

### Decision

For persisted target filings:

`SubmitDateTime NOT NULL`

### Ingestion Rule

If target Filing lacks SubmitDateTime:

`FAIL PERSISTENCE VALIDATION`

### Status

`APPROVE`

---

## 31. Dependency: EdinetCode Nullability

### Existing Target Use

Target listed company filings have EdinetCode.

### Decision

For Phase 1 annual securities report ingestion:

`EdinetCode NOT NULL`

### Reason

Company-specific semantic scope may depend on EDINET Code.

### Future

Broader document types may require reconsideration.

---

## 32. Dependency: DocumentTypeCode Nullability

### Initial Scope

Document Type Code `120`.

### Decision

`NOT NULL`

### Reason

Initial ingestion explicitly filters on document type.

---

## 33. Dependency: XbrlFlag

### Initial Scope

Only filings with XBRL available are ingested.

### Decision

Persist as source code.

Do not convert immediately to bool if EDINET source provides code strings.

### Reason

Source fidelity.

---

## 34. Dependency: PublicDoc / AuditDoc Classification

### Existing ZIP Evidence

Both directories are present in real downloads.

### Current Research

Inventory candidates were found in PublicDoc, while AuditDoc candidate matches were absent in tested cases.

### Decision

`CREATE SourceFileTypeCode`

with:

- PublicDoc
- AuditDoc
- Other

### Initial Ingestion

Persist only:

`PublicDoc XBRL source files selected by parser design`

### Important

Do not assume every PublicDoc file is an XBRL instance.

---

## 35. Dependency: Source File Selection

### Raw ZIP Contains

- XBRL instance
- XSD
- linkbases
- inline XBRL HTML
- images
- manifests

### Risk

Persisting every ZIP entry as an EdinetSourceFile creates unnecessary rows if only parsed instance sources are intended.

### Revised Decision

`EdinetSourceFiles = files actually processed as fact sources`

not:

`all ZIP entries`

### Initial Scope

Persist:

- PublicDoc XBRL instance files parsed for facts

### Future

A separate ArchiveEntry catalog may be added if full archive inventory is required.

---

## 36. Dependency: XBRL vs Inline XBRL

### Existing Evidence

Downloaded archives include both:

- `.xbrl`
- `_ixbrl.htm`

### Current Prototype

Known fact candidate search uses `.xbrl` instance files.

### Decision

Initial production parser should target:

`XBRL instance files`

### Defer

Inline XBRL parsing.

### Reason

Reduce implementation complexity while preserving validated extraction path.

---

## 37. Dependency: Context Consolidation Scope Parsing

### Existing Prototype

Research outputs distinguish context strings such as:

- CurrentYearInstant
- CurrentYearInstant_NonConsolidatedMember

### Risk

Hardcoding ContextRef suffix rules alone is fragile.

### Decision

`CREATE PARSED CONSOLIDATION FIELD, BUT DERIVE FROM CONTEXT STRUCTURE`

### Current Prototype Logic

May be used only as regression comparison.

---

## 38. Dependency: Context DimensionSignature

### Previous Candidate

Persist normalized DimensionSignature plus child dimensions.

### Review

DimensionSignature is derivable from child dimensions.

### Benefits

- fast equality checks
- idempotency diagnostics
- easier logging

### Cost

small compared with fact volume.

### Decision

`KEEP`

### Rule

Signature must be deterministic and documented by parser contract.

---

## 39. Dependency: Context Entity Identifier Fields

### Previous Candidate

- EntityIdentifierScheme
- EntityIdentifierValue

### Review

Useful for exact context preservation and validation.

### Decision

`KEEP`

### Reason

They are raw context identity elements, not merely analytical metadata.

---

## 40. Dependency: Unit Master

### Current Need

Initial facts mainly use:

- JPY
- shares
- pure

### Decision

`DEFER EdinetUnits`

Store raw:

`UnitRef`

on Fact.

### Important

This does not preserve full compound unit XML semantics.

### Future Trigger

Introduce structured unit model when non-trivial compound units become analytically relevant.

---

## 41. Dependency: Full Binary Archive Retention

### Current Prototype

Downloads ZIP bytes in memory.

### Options

- store DB binary
- store Blob Storage
- re-download from EDINET

### Current Decision

`DEFER`

### Phase 1

Persist:

- DocumentId
- SourceFilePath
- optional checksum

### Future

Blob retention should be a separate cost / audit decision.

---

## 42. Dependency: Azure SQL Storage Cost

### Raw Fact Volume

Potentially large.

### Current Mitigations

- numeric facts only
- annual securities reports only
- PublicDoc XBRL instance only
- normalized contexts
- no duplicated ParserVersion per fact
- no TextValue column
- no SourceFileName duplicate

### Decision

`APPROVE INITIAL COST-CONSCIOUS MODEL`

### Future

Measure actual rows and DB size after 7-company validation before broad backfill.

---

## 43. Revised Initial Physical Table Scope

### EdinetFilings

Create New.

### EdinetSourceFiles

Create New.

### EdinetContexts

Create New.

### EdinetContextDimensions

Create New.

### EdinetRawFacts

Create New.

### No Additional Operational Tables

Do not create yet:

- EdinetIngestionBatches
- EdinetParsingErrors
- EdinetUnits
- EdinetFilingSupersessions

---

## 44. Revised DDL Changes from Previous DDL Design

The Dependency Review changes several previous candidates.

### Remove from EdinetSourceFiles

- SourceFileName
- SourceSequence

### Remove from EdinetRawFacts

- ParserVersion
- TextValue

### Add to EdinetFilings

- Jcn
- OrdinanceCode
- FormCode
- DocumentInfoEditStatus
- OperationDateTime

### Tighten Nullability

- EdinetCode = NOT NULL for Phase 1 target filings
- DocumentTypeCode = NOT NULL
- SubmitDateTime = NOT NULL

### Conditional Decision

`SourceFileId + SourceFactSequence` unique remains conditional on deterministic parser contract.

---

## 45. Reuse / Extend / Create / Defer Final Classification

### Reuse Existing

- StockAnalysisDbContext
- EdinetDocumentListResponse
- HttpClient / IConfiguration API key pattern
- validated EDINET API request behavior
- ZIP download behavior
- existing Companies master

### Extend Existing

- EdinetDocumentDto if required fields are missing
- StockAnalysisDbContext with future DbSets
- EDINET API client responsibility extracted from prototype behavior

### Create New

- EdinetFilings
- EdinetSourceFiles
- EdinetContexts
- EdinetContextDimensions
- EdinetRawFacts
- production XBRL parser responsibility
- filing-level ingestion transaction logic

### Defer

- mandatory Companies FK
- EdinetIngestionBatch
- EdinetUnit
- full ZIP binary retention
- Inline XBRL parsing
- Runtime Semantic Mapping
- Canonical Observation
- conflict / unmapped queues

---

## 46. Dependency Review Risks

### Risk 1

Current full Repository may already contain newer EDINET classes not visible in reviewed evidence.

Mitigation:

Local grep before final SQL / Entity creation.

### Risk 2

SourceFactSequence may not remain stable if parser traversal implementation changes.

Mitigation:

Define parser sequence contract before finalizing unique constraint.

### Risk 3

DTO field types may not match desired Entity types.

Mitigation:

DTO-to-Entity mapping layer.

Do not bind Entity directly to JSON serialization.

### Risk 4

`decimal(38,10)` may fail for unusual values.

Mitigation:

RawValue is authoritative; NumericValue is optional.

### Risk 5

One-Filing transaction may be too large.

Mitigation:

Measure on known 7-company filings before broad backfill.

---

## 47. Existing Database Dependency Review Result

| Area | Result |
|---|---|
| Companies | REUSE WITHOUT MANDATORY FK |
| FinancialStatements | DO NOT EXTEND |
| StockAnalysisDbContext | EXTEND |
| EdinetDocumentDto | REUSE / EXTEND |
| EdinetDocumentListResponse | REUSE |
| EdinetInventoryPrototypeService | DO NOT PROMOTE DIRECTLY |
| EDINET API request logic | REUSE BEHAVIOR |
| ZIP download logic | REUSE BEHAVIOR |
| Candidate print/search logic | RESEARCH-ONLY |
| Generic XBRL parser | CREATE NEW RESPONSIBILITY |
| EDINET persistence tables | CREATE NEW, CONDITIONAL ON NAME CHECK |
| Filing transaction boundary | CREATE IN INGESTION |
| Generic ingestion batch | DEFER |
| Timestamp convention | REUSE |
| Company FK | DEFER |
| XBRL instance parsing | INITIAL PRODUCTION TARGET |
| Inline XBRL parsing | DEFER |

---

## 48. Reviewer Gate

### Question 1

Does this design duplicate `FinancialStatements`?

`NO`

### Question 2

Does it duplicate the existing Company master?

`NO`

### Question 3

Does it reuse the validated EDINET response DTO?

`YES`

### Question 4

Does it incorrectly promote the prototype service directly to production?

`NO`

### Question 5

Does it preserve the possibility of extracting reusable API logic?

`YES`

### Question 6

Does it reduce unnecessary raw fact storage duplication?

`YES`

### Question 7

Is the deterministic fact sequence issue explicitly gated?

`YES`

### Question 8

Are current repository inspection limitations disclosed?

`YES`

### Question 9

Can Final DDL Specification proceed?

`YES, CONDITIONALLY`

---

## 49. Reviewer Decision

### Decision

`CONDITIONAL APPROVE`

### Approved

Proceed to:

`EdinetRawFactPersistenceFinalDDLSpecification.md`

### Conditions

Before Final SQL execution:

1. Confirm no existing same-named EDINET tables / entities.
2. Confirm current `EdinetDocumentDto` fields.
3. Define deterministic `SourceFactSequence` parser contract.
4. Confirm selected PublicDoc `.xbrl` instance file identification rule.

### Important

These conditions do not require redesigning the entire architecture.

They are implementation-boundary checks.

---

## 50. Definition of Done

Dependency Review is complete when:

- existing Companies reuse is decided
- FinancialStatements extension is rejected
- DbContext reuse is decided
- EDINET DTO reuse is decided
- Prototype service boundary is decided
- API logic reuse is decided
- parser responsibility is identified
- persistence table creation is classified
- transaction dependency is reviewed
- batch history dependency is reviewed
- storage-reduction revisions are recorded
- remaining implementation gates are explicit
- reviewer decision is recorded

### Result

`DEFINITION OF DONE = PASS`

---

## 51. Final Dependency Review Decision

### Existing Database Compatibility

`PASS WITH CONDITIONS`

### Duplicate Infrastructure Risk

`CONTROLLED`

### Prototype Promotion Risk

`CONTROLLED`

### Immediate New Tables

`5`

### Final SQL Generation

`NOT YET`

### Next Artifact

`EdinetRawFactPersistenceFinalDDLSpecification.md`

### Required Final Specification Inputs

Use the revised decisions from this Review:

- five tables
- RawFacts bigint PK
- SourceFiles without SourceFileName / SourceSequence
- RawFacts without ParserVersion / TextValue
- expanded Filing metadata
- SourceFactSequence deterministic contract gate
- no mandatory Companies FK
- no cascade delete
- no seed data
- one-filing transaction model

### Final Decision

`PROCEED TO FINAL DDL SPECIFICATION`
