# Sprint001 — Automotive Semiconductor Demand Handoff

## Purpose

This handoff enables a contributor on another PC to resume Sprint001 safely after cloning or pulling this repository. It is a **Draft workspace record**, not a canonical Knowledge Base document, Catalog entry, DDL specification, or governance artifact.

## Local Restart

Open Command Prompt in the repository directory and synchronize the checked-out branch:

```bat
git status
git pull origin feature/mlnet-lightgbm
git status
```

Then create or open a local project in the Codex desktop application by selecting this repository folder. Before changing any file, ask the new task to read, in this order:

1. `README.md`
2. `000_ProjectDocumentationConstitution.md`
3. `ProjectInstructions.md`
4. `AGENTS.md`
5. `KnowledgeBase/00_Project/KnowledgeBaseRules.md`
6. `KnowledgeBase/00_Project/ResearchPolicy.md`
7. This handoff document

Suggested first message to the new task:

```text
Read the repository onboarding and governance documents named in
Sprint001_Automotive_Handoff.md. Continue only Sprint001 Automotive
Semiconductor Demand research from the Draft workspace. Preserve
Knowledge Base First, distinguish Fact / Inference / Hypothesis, and
do not promote any Draft to Catalog, DDL, or implementation.
```

## Project State

| Item | Current state |
| --- | --- |
| Governance | Governance v1.0 is Approved and Effective; Constitution / Policy / Standard / Procedure are frozen except through Material Governance Change. |
| Sprint | Sprint001 — Semiconductor → Demand → Automotive |
| Current phase | Research / Evidence Collection |
| Draft workspace | `KnowledgeBase/07_AI_Workspace/Sprint001/Semiconductor/Demand/Automotive/` |
| Canonical research promotion | Not started. No Sprint001 Draft has been promoted to `KnowledgeBase/01_Research/`. |
| Catalog / DDL | Not permitted yet. |

## Fixed Scope

```text
Semiconductor
└── Demand
    └── Automotive
```

Do not expand Sprint001 to semiconductor equipment, materials, or back-end manufacturing. The research sequence remains:

```text
Research
→ Independent Review
→ Knowledge Catalog
→ DDL
→ Codex implementation
```

## Research Rules

- Use primary issuer disclosures first.
- Keep **Fact**, **Inference**, **Hypothesis**, **Opinion**, **Proposal**, and **Decision** visibly separate.
- Drafts remain under `07_AI_Workspace`; only independently reviewed and approved research may move to `01_Research`.
- An author cannot independently approve the author’s own work.
- Do not silently create a common industry series from issuer-specific disclosures.
- `AvailableAt = TBD — no use` prevents Catalog, DDL, ML, backtest, and investment use. Do not invent an operating convention to remove this boundary.

## Completed Draft Assets

### Sprint package

- `AutomotiveSemiconductorDemandIndustryReport.v0.1-draft.md`
- `AutomotiveSemiconductorValueChain.v0.1-draft.md`
- `AutomotiveSemiconductorLeadLagIndicatorCatalog.v0.1-draft.md`
- `AutomotiveSemiconductorEvidenceAcquisitionMatrix.v0.1-draft.md`
- `Sprint001AutomotiveEvidenceRegister.v0.1-draft.md`
- `Sprint001AutomotiveSourceInventoryAndPIT.v0.1-draft.md`
- `Sprint001AutomotiveSharedTerms.v0.1-draft.md`
- `Sprint001AutomotiveReviewPackageCover.v0.1-draft.md`

### Fuji Electric (6504)

- `6504_FujiElectric_CompanyResearch.v0.1-draft.md`
- `6504_FujiElectricAutomotivePowerRawEvidence.v0.1-draft.md`
- `6504_FujiElectricApplicationSalesDefinitionAudit.v0.1-draft.md`
- `6504_FujiElectricIndependentReview.v0.1-draft.md`

**Current evidence conclusion:** Fuji’s Semiconductor-segment sales by application: Automotive are captured for FY2021–FY2025: JPY73.1bn, 100.2bn, 125.6bn, 132.6bn, and 117.7bn. Independent reviewers accepted the bounded issuer-internal interpretation and retained reorganization / price-effect constraints. This is still Draft evidence and is not eligible for Catalog or downstream use because `AvailableAt` remains unresolved.

### Renesas Electronics (6723)

- `6723_RenesasElectronics_CompanyResearch.v0.1-draft.md`
- `6723_RenesasAutomotiveRevenueRawEvidence.v0.1-draft.md` — historical working evidence only; do not treat its event dates as current.
- `6723_RenesasAutomotiveRevenueRawEvidence.v0.2-draft.md` — current Draft-package raw-evidence record.
- `6723_RenesasAutomotiveRevenueDefinitionAudit.v0.1-draft.md`
- `6723_RenesasAutomotiveRevenueSourceEventReconciliation.v0.1-draft.md`

**Current evidence conclusion:**

- FY2023 original Automotive Business revenue: JPY695.0bn.
- FY2023 revised Automotive Business revenue: JPY660.4bn.
- The two FY2023 values are mutually exclusive because Renesas changed reportable-segment revenue aggregation in FY2024 from product groupings to customer names and revised FY2023 information.
- Candidate revised-basis window only: FY2023 revised JPY660.4bn → FY2024 JPY702.8bn → FY2025 JPY639.7bn.
- FY2021–FY2022 customer-name-basis restatement and their Financial Report publication events are not captured. Do not construct a five-year single-basis series.

## Independent Review Status

Independent Evidence, Knowledge, and Traceability reviewers were used for the Fuji and Renesas audits.

| Item | Review result | Current limitation |
| --- | --- | --- |
| Fuji source values / scope | Evidence and traceability interpretation accepted | No PIT / Catalog / DDL use. |
| Fuji comparability audit | Bounded Draft interpretation accepted | Remains noncanonical and requires applicable approval for promotion. |
| Renesas original vs revised separation | Accepted as Draft evidence interpretation | v0.2 requires lifecycle re-review before any approval. |
| Renesas revised FY2023–FY2025 candidate window | Factually supported; bounded candidate only | No PIT / Catalog / DDL use. |

## Known Blockers

1. No approved `AvailableAt` convention exists. This is a governance-controlled boundary; do not create a new rule in Sprint research.
2. No Catalog-approved automotive demand observation exists.
3. No DDL design may start from these Drafts.
4. Renesas has no acquired FY2021–FY2022 restatement under the customer-name aggregation method.
5. Cross-company comparability is not established for any issuer series.

## Recommended Continuation Order

1. Apply the same issuer-by-issuer period, definition, event-date, and comparability audit to **ROHM (6963)**.
2. Complete the **Sanken Electric (6707)** official-source audit; it remains low confidence.
3. Reconcile all Company Research Sheets against the Evidence Register at claim level.
4. Conduct an independent Sprint001 package review only after the remaining Tier1 evidence is brought to the same standard.
5. Consider Catalog candidacy only after independent review, approval, and the existing PIT boundary are satisfied.

## Do Not Do

- Do not move or rename existing historical research in `KnowledgeBase/01_Research/`.
- Do not promote, release, or register these Drafts as canonical.
- Do not create DDL, Entity, Database, ML, Decision Engine, or Advisor artifacts from this Sprint evidence.
- Do not revise governance documents to solve research workflow gaps.
- Do not treat issuer narrative as an industry-wide fact without comparative evidence and review.

## Working Definition of Done for Sprint001

Sprint001 can proceed to Knowledge Catalog review only when Automotive Semiconductor Demand knowledge is independently reviewed, traceable to primary evidence, scoped without issuer-series mixing, and sufficiently complete that DDL design does not require further industry-level research.

