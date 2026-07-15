# Inventory Semantic Mapping Existing Database Dependency Review

## 1. Document Purpose

本書は、`InventorySemanticMappingDDLDesign.md`で定義されたInventory Semantic Mapping DDL候補について、既存のStock Analysis SystemのDatabase / EF Core構造との依存関係を確認し、

* Reuse Existing
* Extend Existing
* Create New
* Defer

を判定するDependency Review Artifactである。

本Reviewの目的は以下である。

> Semantic Mapping Production DDLを既存Database Architectureと重複・競合させず、既存Master、Financial Data、Company Identity、Audit Convention、ID Convention及びMigration運用を尊重した形で設計可能か確認する。

### Status

* Existing Database Dependency Review
* DDL Dependency Gate
* Pre-Final SQL
* Pre-Entity
* Pre-Implementation

---

# 2. Evidence Scope

本Reviewでは、現在確認可能な以下の既存System Evidenceを使用する。

### Existing DbContext Evidence

`StockAnalysisDbContext`

確認済みDbSet例:

* `Companies`
* `PricesDaily`
* `FinancialStatements`
* `MarketIndicesDaily`
* `MarketScoresDaily`
* `StockScoresDaily`

確認済みEntity Mapping例:

* `Companies` primary key = `Code`
* `PricesDaily` composite key = `Code + TradeDate`
* `FinancialStatements` primary key = `DisclosureNumber`
* `MarketIndicesDaily` composite key = `IndexCode + TradeDate`
* `MarketScoresDaily` primary key = `ScoreDate`
* `StockScoresDaily` composite key = `Code + ScoreDate`

### Additional Existing Database Evidence

`MlTrainingData`

はSSMSで作成され、

* `Id int IDENTITY`
* `Code`
* `TradeDate`
* `CreatedAt`

を持ち、

`Code + TradeDate`

にUnique Indexが設定されている。

その後、Entity及びDbContextへ追加された運用実績がある。

### Current Financial Storage Evidence

既存`FinancialStatements`はJ-Quants Summary Financial Dataを保存する既存Tableであり、保存処理では、

* DisclosureNumber
* Code
* DisclosedDate
* TypeOfDocument
* NetSales
* OperatingProfit
* Profit
* EPS
* EquityToAssetRatio
* BPS
* Dividend fields
* CreatedAt
* UpdatedAt

等を扱っている。

### Existing Inventory Research Decision

既存`FinancialStatements`は、

* Disclosure Time
* Raw Value Version
* Revision History
* Detailed Financial Statement Items
* Source Provenance
* Effective As Of Date

を保持しないため、Detailed Financial Observationを既存`FinancialStatements`へ追加しない方針がResearch上既に記録されている。

---

# 3. Review Limitation

本Reviewで確認できたDbContext Sourceは、過去時点のSnapshotを含む。

そのため、現在のRepositoryには追加の:

* DbSet
* Entity
* Table
* ML関連Table

が存在する可能性がある。

実際、後続開発では`MlTrainingData`等が追加されたEvidenceがある。

Therefore:

`This Review does not claim that the retrieved DbContext snapshot is the complete current schema.`

ただし、以下のArchitecture Decisionに必要な既存設計傾向は確認できる。

* EF Coreを使用
* Table名はPascalCase複数形中心
* Composite Keyを必要に応じて使用
* Master的Entityと時系列Entityが同一DbContextに存在
* `CreatedAt / UpdatedAt`パターンが広く使用
* 一部TableはSSMSで先に作成後、Entity / DbContextを追従させた実績がある

---

# 4. Dependency Review Summary

| Dependency                          | Decision                                     |
| ----------------------------------- | -------------------------------------------- |
| Existing Companies Table            | REUSE WITH CARE                              |
| Existing FinancialStatements        | DO NOT EXTEND                                |
| Existing Raw EDINET Fact Table      | NOT CONFIRMED / CREATE NEW CANDIDATE         |
| Existing EDINET Filing Master       | NOT CONFIRMED                                |
| Existing Accounting Standard Master | NOT CONFIRMED                                |
| Existing Batch / Job History        | NOT CONFIRMED                                |
| Existing Audit Convention           | REUSE CURRENT CONVENTION                     |
| Existing ID Convention              | MIXED / TABLE-RESPONSIBILITY BASED           |
| Existing Migration Strategy         | MANUAL-FIRST EVIDENCE / NEED STANDARDIZATION |
| Semantic Mapping Governance Tables  | CREATE NEW                                   |
| Canonical Observation Lineage       | DEFER                                        |
| Raw Fact Persistence                | REQUIRED BEFORE RUNTIME MAPPING              |

---

# 5. Dependency

# Existing Companies Table

## Existing Evidence

`Companies` already exists.

Primary Key:

`Code`

The application uses company Code as the Entity key.

Company creation code also indicates fields such as:

* Code
* CompanyName
* CompanyNameEnglish
* MarketCode
* MarketName
* Sector17Code
* Sector17Name
* Sector33Code
* Sector33Name
* IsActive
* CreatedAt
* UpdatedAt

### Dependency Decision

`REUSE EXISTING`

### Important Boundary

Semantic Mapping Company Scope should not create a duplicate Company Master.

However:

EDINET Source identifies companies primarily through:

`EDINET Code`

while the existing Company key is:

`Security Code / J-Quants Code`

Therefore:

`Companies.Code`

alone is not sufficient for all EDINET Mapping Scope requirements.

---

# 6. EDINET Code Dependency

Current Companies evidence does not confirm an:

`EdinetCode`

column.

### Requirement

Company-specific Semantic Mapping such as Kioxia M3 requires stable scope:

`E35948`

Therefore Production Architecture requires a relationship between:

* Existing Companies.Code
* EDINET Code

### Possible Designs

## Option A

Extend `Companies` with:

`EdinetCode`

## Option B

Create a separate Company Identifier table.

Example logical model:

`CompanyIdentifiers`

* Company Code
* Identifier Type
* Identifier Value
* Effective From
* Effective To

## Option C

Store EDINET Code directly only on Mapping Scope.

### Evaluation

Option C is sufficient for initial Mapping execution.

However, long-term EDINET ingestion will also need:

* filer identity resolution
* historical identifier management
* security code / EDINET code relationship

### Current Decision

`DEFER FINAL IDENTIFIER MODEL`

For Phase A Mapping Governance:

`Mapping Scope may store EdinetCode directly.`

Do not extend `Companies` solely for Semantic Mapping until broader EDINET Company Identity Architecture is reviewed.

### Dependency Decision

`REUSE Companies`

*

`DEFER EDINET IDENTIFIER MASTER DESIGN`

---

# 7. Dependency

# Existing FinancialStatements Table

## Existing Role

`FinancialStatements`

currently stores J-Quants Summary Financial Data.

Its primary key is:

`DisclosureNumber`

Current saving logic updates summarized financial fields by DisclosureNumber.

### Known Limitation

Existing Research already concluded that this Table does not preserve sufficient:

* Point-in-time detail
* Source provenance
* Revision history
* Detailed XBRL fact identity

for Inventory Raw Observation persistence.

### Dependency Decision

`DO NOT EXTEND FOR RAW EDINET FACTS`

### Reason

Adding detailed EDINET/XBRL Fact rows into `FinancialStatements` would mix:

* Summary financial statement records
* Individual taxonomy facts
* Different revision semantics
* Different source lineage

This would violate the established Raw Observation Boundary.

---

# 8. Dependency

# Existing Raw EDINET Fact Persistence

## Current Evidence

EDINET Prototype currently:

* discovers filings
* downloads CSV / XBRL
* inspects Raw Fact candidates
* prints QName
* Namespace
* ContextRef
* UnitRef
* Decimals
* Value

However, no confirmed persistent Raw EDINET Fact table was identified in the reviewed existing schema evidence.

Research artifacts also previously treated EDINET work as Prototype and explicitly prohibited premature Database Entity / Migration creation during the initial phase.

### Dependency Decision

`NOT CONFIRMED`

### Architecture Consequence

Production Semantic Mapping Runtime cannot safely exist without durable Raw Fact persistence.

### Required Raw Fact Identity

At minimum:

* Raw Fact ID
* Document ID
* EDINET Code
* Security Code where available
* Namespace URI
* Local Name
* QName
* ContextRef
* UnitRef
* Decimals
* Raw Value
* Period Start
* Period End
* Instant Date where applicable
* Consolidation / Dimension evidence
* Source file / filing reference
* CreatedAt

### Decision

`CREATE NEW RAW FACT MODEL CANDIDATE`

but:

`DO NOT DESIGN IT INSIDE THE SEMANTIC MAPPING TABLES`

Raw EDINET Fact persistence requires its own Architecture / Catalog / DDL review.

---

# 9. Critical Dependency Finding

The current DDL sequence has uncovered a dependency inversion risk.

Originally:

`Semantic Mapping Governance DDL`

was planned before finalizing Raw Fact persistence.

However Runtime Mapping fundamentally requires:

`Persistent Raw Fact Identity`

Therefore the architecture should distinguish:

## Phase A

Mapping Governance Master

Can proceed independently.

Includes:

* SemanticCanonicalRoles
* SemanticMappingRules
* SemanticMappingScopes
* SemanticMappingEvidenceReferences
* SemanticRejectedMappingDecisions

## Phase B

Operational Mapping Runtime

Requires:

* Raw EDINET Fact persistence
* Filing persistence
* Canonical Observation persistence

### Decision

`Phase A may proceed.`

`Runtime Mapping DDL must not proceed before Raw Fact Architecture.`

---

# 10. Dependency

# Existing EDINET Filing Persistence

## Current Evidence

Prototype retrieves metadata including:

* docID
* edinetCode
* secCode
* filerName
* document type
* period
* submitDateTime
* withdrawalStatus
* disclosureStatus
* xbrlFlag
* csvFlag

EDINET research explicitly identifies these metadata as important for point-in-time and filing lineage.

No existing persistent EDINET Filing table was confirmed.

### Dependency Decision

`NOT CONFIRMED`

### Requirement

Raw Fact persistence should not repeat all Filing metadata on every Fact row if a stable Filing record exists.

### Likely Architecture Candidate

`EdinetFilings`

or a broader:

`SourceDocuments`

model.

### Decision

`DEFER TO RAW EDINET OBSERVATION ARCHITECTURE`

Do not create Filing Master opportunistically inside Semantic Mapping DDL.

---

# 11. Dependency

# Accounting Standard Master

## Current Evidence

No existing Accounting Standard Master was confirmed.

Current Application entities shown in available evidence do not establish such a Master.

### Options

## Option A

Create master table.

## Option B

Controlled string code.

### Current Requirement Scale

Current standards:

* `JapaneseGAAP`
* `IFRS`

Potential future:

* US GAAP
* Other accounting bases

### Decision

For Semantic Mapping Phase A:

`USE CONTROLLED STRING CODE`

Do not create a dedicated Accounting Standard Master yet.

### Reason

A dedicated master should be created only when broader Financial Observation Architecture requires it.

### Dependency Decision

`CREATE NO NEW MASTER NOW`

---

# 12. Dependency

# Batch / Job History

## Current Evidence

The project is a Batch application, but no stable persistent Batch Execution History table was confirmed in reviewed schema evidence.

Program execution currently uses flags to select processing paths.

The current codebase runs scheduled-style or manual batch workflows directly through Program / services rather than an identified persistent job orchestration model.

### Dependency Decision

`NOT CONFIRMED`

### Impact

The proposed:

`ReprocessingBatchId`

must remain deferred.

Do not create a Semantic Mapping-specific Batch History table.

### Future Decision

Reuse a generic Batch / Job Execution model if one is later introduced.

---

# 13. Dependency

# Audit Column Convention

## Existing Evidence

Existing save processes repeatedly use:

* `CreatedAt`
* `UpdatedAt`

and assign:

`DateTime.Now`

for record creation and updates.

`MlTrainingData` also uses:

`CreatedAt datetime2`.

### Current Convention

`CreatedAt`

`UpdatedAt`

### Time Basis

Current implementation evidence:

`Local DateTime / DateTime.Now`

not:

`UTC`

### Previous DDL Candidate

The proposed Semantic Mapping DDL leaned toward UTC.

### Conflict

Introducing UTC only for new Mapping Tables without a project-wide convention would create inconsistent timestamp semantics.

### Dependency Decision

`REUSE CURRENT COLUMN NAMING`

but:

`DO NOT SILENTLY MIX LOCAL TIME AND UTC`

### Required Final DDL Decision

Either:

1. Continue current `DateTime.Now` convention consistently, or
2. Introduce a project-wide UTC migration policy separately.

### Current Decision

For first Semantic Mapping DDL:

`CreatedAt / UpdatedAt / ReviewedAt`

use the existing project timestamp convention.

Do not introduce UTC-only behavior inside this isolated feature.

---

# 14. Dependency

# ID Type Convention

## Existing Evidence

Existing schema uses multiple key styles.

Examples:

### Natural / String Key

`Companies.Code`

### Composite Key

`PricesDaily(Code, TradeDate)`

`StockScoresDaily(Code, ScoreDate)`

### String Business Key

`FinancialStatements.DisclosureNumber`

### Surrogate Identity

`MlTrainingData.Id int IDENTITY`

### Finding

There is no universal rule:

`All tables use bigint surrogate keys`

### Previous DDL Candidate

`bigint`

was proposed for Semantic Mapping governance tables.

### Review

Expected Mapping volume is very small relative to ML data.

Using `bigint` provides little practical benefit.

Existing project has confirmed successful usage of:

`int IDENTITY`

for new surrogate-key tables.

### Dependency Decision

`USE int IDENTITY FOR PHASE A GOVERNANCE TABLE PRIMARY KEYS`

unless an existing current project-wide rule has changed.

### Reason

* Consistent with `MlTrainingData`
* More than sufficient capacity
* Simpler EF Core mapping
* Avoid arbitrary divergence

### Revised DDL Decision

Replace prior default candidate:

`bigint`

with:

`int`

for Phase A Semantic Mapping governance tables.

This is a material Dependency Review outcome.

---

# 15. Dependency

# Table Naming Convention

## Existing Evidence

Existing Table names include:

* `Companies`
* `PricesDaily`
* `FinancialStatements`
* `MarketIndicesDaily`
* `MarketScoresDaily`
* `StockScoresDaily`
* `MlTrainingData`

### Pattern

* PascalCase
* Mostly plural for entity collections
* Some functional suffixes such as `Daily`
* No schema prefix observed in available evidence

### Proposed Mapping Table Names

* `SemanticCanonicalRoles`
* `SemanticMappingRules`
* `SemanticMappingScopes`
* `SemanticMappingEvidenceReferences`
* `SemanticRejectedMappingDecisions`
* `SemanticMappingConflicts`
* `SemanticUnmappedConcepts`

### Dependency Decision

`COMPATIBLE`

No rename required at this stage.

---

# 16. Dependency

# EF Core Configuration Convention

## Existing Evidence

Existing project explicitly configures:

* `ToTable`
* `HasKey`
* selected unique indexes

inside:

`StockAnalysisDbContext.OnModelCreating`

### Decision

New Semantic Mapping Entities should follow:

`Explicit Fluent API Configuration`

Do not rely only on conventions.

### Required Future Entity Design

Each Entity should define:

* `ToTable`
* `HasKey`
* String max lengths
* Required / optional fields
* Unique indexes
* FKs
* Delete behavior

---

# 17. Dependency

# Migration Strategy

## Existing Evidence

`MlTrainingData` was created through explicit SQL in SSMS and then represented in Entity / DbContext afterward.

### Finding

Current project has at least one:

`Database-first manual SQL change → Entity synchronization`

workflow.

No consistent EF Core Migration-first strategy was confirmed.

### Risk

Introducing EF Migration now without checking existing database migration ownership may create:

* Schema drift
* Duplicate object creation
* Migration history inconsistency

### Dependency Decision

`CURRENT OPERATIONAL BASELINE = MANUAL SQL / SSMS COMPATIBLE`

### Recommended Next Step

For this phase:

1. Create reviewed SQL DDL script
2. Execute manually against development Azure SQL
3. Add Entity classes
4. Add DbSet / Fluent configuration
5. Build
6. Validate schema

### Important

This is not a permanent rejection of EF Core Migrations.

It reflects current repository evidence.

A project-wide Migration Strategy may be standardized later.

---

# 18. Dependency

# Existing Raw Financial Data

## Existing Table

`FinancialStatements`

### Decision

`REUSE FOR SUMMARY FINANCIAL DATA ONLY`

### Do Not Use For

* EDINET individual XBRL Facts
* Semantic Mapping Raw Fact identity
* Taxonomy Version lineage
* Company Extension facts
* Context-specific facts

### Final Decision

`NO EXTENSION FOR SEMANTIC MAPPING RAW FACTS`

---

# 19. Dependency

# Company Foreign Key Design

A possible Mapping Scope may reference Company.

Existing Company PK:

`Code`

### Problem

M3 scope is more naturally identified by:

`EDINET Code`

Example:

`E35948`

### Decision

Do not create:

`CompanyCode FK`

as mandatory on every Mapping Rule.

Instead:

`Mapping Scope remains generic and optional.`

For company-specific mappings:

* `EdinetCode = E35948`
* optional `Company Code = 285A0`

may both be stored as scope conditions.

### Future

When a formal Company Identifier model exists, Scope may reference it.

---

# 20. Dependency

# Raw Fact Foreign Key

Proposed:

`SemanticMappingConflictFacts.RawFactId`

### Current State

No confirmed target Raw Fact table.

### Decision

`DEFER TABLE`

Do not create:

`SemanticMappingConflictFacts`

in Phase A.

---

# 21. Dependency

# Canonical Observation Foreign Key

Proposed:

`SemanticCanonicalObservationLineages.CanonicalObservationId`

### Current State

No approved Canonical Observation persistence model.

### Decision

`DEFER TABLE`

Do not create:

`SemanticCanonicalObservationLineages`

in Phase A.

---

# 22. Dependency

# Conflict Persistence

`SemanticMappingConflicts`

was proposed for Phase A.

### Review

A conflict record without stable Raw Fact IDs may still retain:

* Document ID
* EDINET Code
* Source Concept details
* textual description

However, production Runtime conflict persistence is not needed before Runtime Mapping exists.

### Revised Decision

`DEFER SemanticMappingConflicts UNTIL RAW FACT MODEL EXISTS`

### Reason

Otherwise the table would be designed around temporary textual identifiers and likely require redesign.

---

# 23. Dependency

# Unmapped Concept Queue

`SemanticUnmappedConcepts`

was proposed for Phase A.

### Review

This table can theoretically exist without RawFactId.

However, the actual uniqueness and aggregation rule depends on:

* stable Source Concept identity
* taxonomy version
* company extension namespace behavior
* ingestion pipeline

### Decision

`DEFER UNTIL RAW EDINET INGESTION ARCHITECTURE`

### Reason

It is operational Runtime infrastructure, not Mapping Master foundation.

---

# 24. Revised Phase A Scope

After existing dependency review, Phase A should be reduced.

### Approved Initial Governance Tables

1. `SemanticCanonicalRoles`
2. `SemanticMappingRules`
3. `SemanticMappingScopes`
4. `SemanticMappingEvidenceReferences`
5. `SemanticRejectedMappingDecisions`

### Deferred Operational Tables

* `SemanticMappingConflicts`
* `SemanticMappingConflictFacts`
* `SemanticUnmappedConcepts`
* `SemanticCanonicalObservationLineages`

### Reason

Operational tables depend on the still-unapproved:

* Raw EDINET Fact model
* Filing model
* Canonical Observation model
* Runtime ingestion model

---

# 25. Why Phase A Reduction Is Important

Creating operational tables now would require assumptions about:

* RawFactId
* Document identity
* Company identity
* Observation identity
* Runtime batch identity

Those assumptions have not passed Research → Architecture → Catalog → DDL governance.

### Decision Principle

`Do not implement downstream runtime persistence before upstream observation identity is stable.`

---

# 26. Proposed Dependency Classification

## Reuse Existing

### Companies

Reuse existing Company data where relevant.

Do not duplicate Company Master.

### Existing audit naming

Reuse:

* CreatedAt
* UpdatedAt

### Existing EF Core DbContext

Extend existing:

`StockAnalysisDbContext`

after Entity design.

---

## Extend Existing

### StockAnalysisDbContext

Future addition of Semantic Mapping DbSets.

### Existing Database

Add new Semantic Mapping governance tables.

---

## Create New

### SemanticCanonicalRoles

### SemanticMappingRules

### SemanticMappingScopes

### SemanticMappingEvidenceReferences

### SemanticRejectedMappingDecisions

---

## Defer

### Raw EDINET Fact Table

Requires separate Architecture.

### EDINET Filing Table

Requires separate Source Observation Architecture.

### Accounting Standard Master

Not required yet.

### Company Identifier Master

Requires broader identity review.

### Mapping Conflicts

Requires Runtime Raw Fact identity.

### Unmapped Queue

Requires ingestion architecture.

### Canonical Observation Lineage

Requires Canonical Observation Architecture.

### Reprocessing Batch linkage

Requires Batch History model.

---

# 27. Revised Phase A Table Responsibilities

## SemanticCanonicalRoles

Stable Canonical Semantic Role Master.

Independent of Raw Fact persistence.

### Decision

`CREATE NEW`

---

## SemanticMappingRules

Approved Mapping version definitions.

Independent of Raw Fact persistence.

### Decision

`CREATE NEW`

---

## SemanticMappingScopes

Mapping applicability conditions.

### Decision

`CREATE NEW`

---

## SemanticMappingEvidenceReferences

Repository Research Artifact lineage.

### Decision

`CREATE NEW`

---

## SemanticRejectedMappingDecisions

Governance history for rejected candidate mappings.

### Decision

`CREATE NEW`

---

# 28. Revised Primary Key Decision

Phase A Tables should use:

`int IDENTITY(1,1)`

### Tables

* SemanticCanonicalRoles
* SemanticMappingRules
* SemanticMappingScopes
* SemanticMappingEvidenceReferences
* SemanticRejectedMappingDecisions

### Reason

Current project evidence already uses:

`int IDENTITY`

for surrogate-key operational tables.

No volume requirement justifies `bigint`.

---

# 29. Revised Timestamp Decision

Use existing project column names:

* `CreatedAt`
* `UpdatedAt`
* `ReviewedAt`

### Time Semantic

Follow existing application convention initially.

### Important

Do not claim stored timestamps are UTC unless application code explicitly uses UTC.

A future project-wide UTC policy may change this.

---

# 30. Revised Mapping Rule Scope Strategy

The generic child table:

`SemanticMappingScopes`

remains approved.

### Reason

M3 Company Extension requires compositional scope.

### Initial Scope Types

* TaxonomyFamily
* TaxonomyVersion
* AccountingStandard
* CompanyCode
* EdinetCode
* FilingFamily
* Namespace

### Global

No Scope rows.

---

# 31. Existing Companies Reuse Decision

Do not add a mandatory FK from:

`SemanticMappingRules`

to:

`Companies`

### Reason

Global Standard Mappings are not company-specific.

Company Extension scope belongs in:

`SemanticMappingScopes`

### Optional Future Referential Integrity

A typed Company Scope table may later reference `Companies.Code`.

Not required for first Phase A.

---

# 32. Evidence Artifact Storage Decision

The Knowledge Base is repository-backed.

Therefore:

`ArtifactPath`

should be stored as repository-relative path.

### Example

`KnowledgeBase/01_Research/Industries/Semiconductor/Demand/Automotive/InventorySemanticMappingWorkInProcessCAIFRSResearchSheet.md`

### Dependency Decision

`NO EXTERNAL DOCUMENT STORE REQUIRED`

---

# 33. Current DDL Blockers

## Blocker A

Current live DbContext should be checked before editing to ensure:

* no naming conflict
* no existing Semantic tables
* current audit conventions unchanged

### Severity

`LOW`

---

## Blocker B

Raw EDINET Fact Architecture is not yet defined.

### Severity

`BLOCKS RUNTIME MAPPING TABLES`

Does not block Phase A Governance Tables.

---

## Blocker C

Canonical Observation Architecture is not defined.

### Severity

`BLOCKS LINEAGE TABLE`

Does not block Phase A Governance Tables.

---

## Blocker D

Project-wide Migration Strategy is not formalized.

### Severity

`MEDIUM`

### Current Mitigation

Use reviewed manual SQL deployment consistent with existing evidence.

---

# 34. Existing Database Dependency Review Result

| Area                          | Result                            |
| ----------------------------- | --------------------------------- |
| Companies                     | REUSE                             |
| EDINET Code identity          | DEFER BROADER IDENTITY MODEL      |
| FinancialStatements           | DO NOT EXTEND                     |
| Raw EDINET Facts              | CREATE NEW ARCHITECTURE REQUIRED  |
| EDINET Filing Persistence     | CREATE NEW ARCHITECTURE REQUIRED  |
| Accounting Standard Master    | NOT REQUIRED YET                  |
| Batch History                 | DEFER                             |
| Audit Column Names            | REUSE                             |
| Audit Time Basis              | FOLLOW CURRENT PROJECT CONVENTION |
| Surrogate Key Type            | int IDENTITY                      |
| Table Naming                  | COMPATIBLE                        |
| DbContext                     | EXTEND LATER                      |
| EF Configuration              | USE FLUENT API                    |
| Migration Strategy            | MANUAL SQL CURRENT BASELINE       |
| Runtime Conflict Tables       | DEFER                             |
| Unmapped Queue                | DEFER                             |
| Canonical Observation Lineage | DEFER                             |

---

# 35. Architecture Impact Review

This Dependency Review changes one important part of the previous DDL Design.

### Previous Phase A Candidate

7 tables.

### Revised Phase A

5 tables.

### Removed from immediate implementation

* SemanticMappingConflicts
* SemanticUnmappedConcepts

### Reason

Both are operational Runtime concerns and depend on Raw Fact ingestion identity.

### Architecture Decision

`APPROVE PHASE A REDUCTION`

---

# 36. DDL Reviewer Decision

### Phase A Governance Foundation

`APPROVE FOR FINAL SQL DDL`

Tables:

1. `SemanticCanonicalRoles`
2. `SemanticMappingRules`
3. `SemanticMappingScopes`
4. `SemanticMappingEvidenceReferences`
5. `SemanticRejectedMappingDecisions`

### Runtime Mapping Persistence

`DEFER`

Pending:

`Raw EDINET Observation Architecture`

### Reviewer Status

`APPROVE`

---

# 37. Dependency Review Definition of Done

The Review is complete when:

* Existing Companies reuse is decided
* Existing FinancialStatements reuse is decided
* Raw Fact dependency is identified
* EDINET Filing dependency is identified
* Accounting Standard dependency is decided
* Batch History dependency is decided
* Audit convention is decided
* ID convention is decided
* Table naming compatibility is reviewed
* DbContext integration approach is reviewed
* Migration strategy is reviewed
* Phase A / Runtime Phase boundary is revised
* Reviewer decision is recorded

### Result

`DEFINITION OF DONE = PASS`

---

# 38. Final Dependency Review Decision

### Existing Database Compatibility

`PASS`

### Existing Table Reuse

`PARTIAL`

### Duplicate Infrastructure Risk

`CONTROLLED`

### Immediate DDL Scope

`5 GOVERNANCE TABLES`

### Runtime DDL

`DEFERRED`

### Final Decision

`PROCEED TO FINAL PHASE A SQL DDL DESIGN`

---

# 39. Exact Next Task

Next Artifact:

`InventorySemanticMappingPhaseADDL.sql`

or first:

`InventorySemanticMappingPhaseAFinalDDLSpecification.md`

### Recommended Sequence

Because this project follows:

`Design → Review → Implementation`

the next Artifact should be:

`InventorySemanticMappingPhaseAFinalDDLSpecification.md`

### Purpose

> Dependency Reviewで確定した5つのPhase A Governance Tablesについて、最終Column、SQL Data Type、NULL、Default、PK、FK、CHECK、UNIQUE、Index及びSeed Strategyを確定する。

### Target Tables

1. `SemanticCanonicalRoles`
2. `SemanticMappingRules`
3. `SemanticMappingScopes`
4. `SemanticMappingEvidenceReferences`
5. `SemanticRejectedMappingDecisions`

### Required Decisions

* Exact SQL Data Types
* Max Length
* Nullability
* Default Values
* PK
* FK
* Unique Constraints
* CHECK Constraints
* Indexes
* Seed Order
* Initial Status
* Existing DbContext integration boundary

### Important

Do not create Entity classes yet.

Sequence:

`Final DDL Specification`

↓

`DDL Reviewer Approval`

↓

`CREATE TABLE SQL`

↓

`Database Apply`

↓

`Entity Design`
