# Sprint001 Automotive Semiconductor Demand — Handoff Record

## 1. Purpose and Authority Boundary

This record enables a new contributor, AI agent, or work session to resume the **Sprint001 Automotive Semiconductor Demand** Draft package without recreating prior work or extending its claims.

It is a **Draft workspace record**. It is not canonical research, a Knowledge Catalog entry, a DDL specification, an implementation instruction, or a governance authority. Canonical controls remain the repository onboarding and Knowledge Base documents listed below.

**Handoff status:** Research paused at a controlled evidence-acquisition boundary. Resume only the stated next action; do not infer missing periods, definitions, or availability conventions.

| Control | Value |
| --- | --- |
| Handoff version | 0.2-draft |
| Last updated / as of | 2026-07-24 (Asia/Tokyo) |
| Evidence Register baseline | `Sprint001AutomotiveEvidenceRegister.v0.1-draft.md`, last updated 2026-07-23, `Reviewer Status: Pending independent re-review` |
| PIT baseline | `Sprint001AutomotiveSourceInventoryAndPIT.v0.1-draft.md`, last updated 2026-07-23, `Reviewer Status: Pending independent re-review` |
| Restart control | Before acting, re-read both baseline files and reconcile this handoff against their current versions. The registers control if they differ. |

## 2. Read Before Acting

Read in this order before any change:

1. `README.md`
2. `000_ProjectDocumentationConstitution.md`
3. `ProjectInstructions.md`
4. `AGENTS.md`
5. `KnowledgeBase/00_Project/KnowledgeBaseRules.md`
6. `KnowledgeBase/00_Project/ResearchPolicy.md`
7. `KnowledgeBase/00_Project/NamingConvention.md`
8. `KnowledgeBase/00_Project/ReviewPolicy.md`
9. This handoff record
10. `Sprint001AutomotiveEvidenceRegister.v0.1-draft.md`
11. `Sprint001AutomotiveSourceInventoryAndPIT.v0.1-draft.md`
12. `6707_SankenElectric_CompanyResearch.v0.1-draft.md`
13. `6707_SankenElectricSourceArchiveAudit.v0.1-draft.md`
14. `6707_SankenElectricAutomotiveMarketSalesRawEvidence.v0.1-draft.md`
15. `6707_SankenElectricAutomotiveDeviceSalesFY2021Q2RawEvidence.v0.1-draft.md`

## 3. Project and Governance State

| Item | Current state |
| --- | --- |
| Governance | Governance v1.0 is Approved and Effective. Constitution, Policy, Standard, and Procedure changes are frozen except through Material Governance Change. |
| Sprint | Sprint001 — Semiconductor / Demand / Automotive |
| Current phase | Research — Evidence Collection |
| Draft workspace | `KnowledgeBase/07_AI_Workspace/Sprint001/Semiconductor/Demand/Automotive/` |
| Canonical research promotion | Not started. No Sprint001 Draft has been promoted to `KnowledgeBase/01_Research/`. |
| Catalog, DDL, and implementation | Not permitted from this Draft package. |
| Research status | Paused after Sanken FY2021 1Q / 2Q evidence acquisition and independent review. |

## 4. Fixed Scope

```text
Semiconductor
  -> Demand
    -> Automotive
```

Do not expand Sprint001 to semiconductor equipment, materials, packaging, or other subsectors. The authorized sequence is:

```text
Research
  -> Independent Review
  -> Knowledge Catalog
  -> DDL
  -> Codex implementation
```

## 5. Non-Negotiable Working Boundaries

- Prefer primary issuer disclosures and retain a durable source URL, date, period, locator, definition, unit, and scope.
- Keep **Fact**, **Inference**, **Hypothesis**, **Opinion**, **Proposal**, and **Decision** distinct.
- Drafts remain in `KnowledgeBase/07_AI_Workspace/`; only independently reviewed and approved material may be promoted to `KnowledgeBase/01_Research/`.
- An author cannot independently approve the author's own work.
- Do not join issuer disclosures into a common industry series without an explicit definition and comparability disposition.
- `AvailableAt = TBD — no use` blocks Catalog, DDL, ML, backtest, and investment use. Do not invent an operating convention to bypass it.
- Do not create governance changes, DDL, Entity, Database, ML, Decision Engine, or Advisor artifacts to resolve a research gap.

## 6. Core Draft Package

| Asset | Role |
| --- | --- |
| `AutomotiveSemiconductorDemandIndustryReport.v0.1-draft.md` | Industry-level Draft baseline. |
| `AutomotiveSemiconductorValueChain.v0.1-draft.md` | Value-chain Draft baseline. |
| `AutomotiveSemiconductorLeadLagIndicatorCatalog.v0.1-draft.md` | Candidate indicator taxonomy; not a Catalog. |
| `AutomotiveSemiconductorEvidenceAcquisitionMatrix.v0.1-draft.md` | Evidence-acquisition plan. |
| `Sprint001AutomotiveEvidenceRegister.v0.1-draft.md` | Draft evidence identity and factual-register boundary. |
| `Sprint001AutomotiveSourceInventoryAndPIT.v0.1-draft.md` | Archive / acquisition / PIT readiness record. |
| `Sprint001AutomotiveSharedTerms.v0.1-draft.md` | Working vocabulary only. |
| `Sprint001AutomotiveReviewPackageCover.v0.1-draft.md` | Review package navigation. |

## 7. Issuer Evidence State

### 7.1 Fuji Electric (6504)

**Files**

- `6504_FujiElectric_CompanyResearch.v0.1-draft.md`
- `6504_FujiElectricAutomotivePowerRawEvidence.v0.1-draft.md`
- `6504_FujiElectricApplicationSalesDefinitionAudit.v0.1-draft.md`
- `6504_FujiElectricIndependentReview.v0.1-draft.md`

**Facts captured in the Draft package**

- Semiconductor-segment sales by application: Automotive: FY2021 to FY2025 = JPY73.1bn, JPY100.2bn, JPY125.6bn, JPY132.6bn, and JPY117.7bn.
- FY2022 disclosure states that the FY2021 figure reflects an organizational restructuring.
- FY2025 automotive application-sales commentary must retain both reduced xEV power-semiconductor demand and prior-year selling-price-revision impact.

**Boundary**

This is bounded issuer-internal Draft evidence only. It is not a common industry series, and `AvailableAt = TBD — no use` prevents downstream use.

### 7.2 Renesas Electronics (6723)

**Files**

- `6723_RenesasElectronics_CompanyResearch.v0.1-draft.md`
- `6723_RenesasAutomotiveRevenueRawEvidence.v0.1-draft.md` — historical working evidence only; do not treat its event dates as current.
- `6723_RenesasAutomotiveRevenueRawEvidence.v0.2-draft.md` — current raw-evidence record.
- `6723_RenesasAutomotiveRevenueDefinitionAudit.v0.1-draft.md`
- `6723_RenesasAutomotiveRevenueSourceEventReconciliation.v0.1-draft.md`

**Facts captured in the Draft package**

- FY2023 original Automotive Business revenue: JPY695.0bn.
- FY2023 revised Automotive Business revenue: JPY660.4bn.
- These are mutually exclusive: Renesas changed aggregation in FY2024 from product groupings to customer names and revised FY2023 information.
- A revised-basis candidate window only is recorded: FY2023 revised JPY660.4bn, FY2024 JPY702.8bn, FY2025 JPY639.7bn.

**Boundary**

FY2021 and FY2022 customer-name-basis restatements and their publication events are not captured. Do not create a five-year single-basis series.

### 7.3 ROHM (6963)

**Files**

- `6963_ROHM_CompanyResearch.v0.1-draft.md`
- `6963_ROHMAutomotiveMarketSalesRawEvidence.v0.1-draft.md`
- `6963_ROHMAutomotiveMarketSalesDefinitionAudit.v0.1-draft.md`

**Facts captured in the Draft package**

- Issuer-defined Automotive market sales: FY2021 to FY2025 = JPY172.5bn, JPY213.0bn, JPY229.4bn, JPY223.8bn, and JPY236.8bn.
- Overlapping FY2022, FY2023, and FY2024 values are reconciled across adjacent official presentations.

**Boundary**

The measure is an issuer-defined market classification, not automotive-product, SiC, power-device, discrete-device, OEM, or industry-demand revenue. The FY2022 source says `Market Segment: Calculated by most recent segment`; methodology continuity is not established. No validated continuous series, comparability class, Catalog use, or downstream use exists.

### 7.4 Sanken Electric (6707) — Current Stop Point

**Files**

- `6707_SankenElectric_CompanyResearch.v0.1-draft.md`
- `6707_SankenElectricSourceArchiveAudit.v0.1-draft.md`
- `6707_SankenElectricAutomotiveMarketSalesRawEvidence.v0.1-draft.md`
- `6707_SankenElectricAutomotiveDeviceSalesFY2021Q2RawEvidence.v0.1-draft.md`

**Evidence identity**

| ID | Source-defined measure | Period and value | Status / boundary |
| --- | --- | --- | --- |
| `EVR-025` / `PIT-016` | Historical consolidated market sales; source row Automotive total | FY2018 JPY76,442m; FY2019 JPY70,233m; FY2020 JPY64,045m | Historical context only. Outside the Sprint001 target period. No continuity claim. |
| `EVR-026` / `PIT-017` | Device consolidated sales classified by market; source series Automotive | FY2021 1Q JPY21.4bn; FY2021 2Q JPY20.9bn | Two source-presented actual quarterly observations only. No FY2021 full-year or later continuous series. |

**EVR-026 primary source**

- [FY2022 Q2 Financial Results Presentation](https://www.sanken-ele.co.jp/corp/tousika/pdf/frb_2203c_2q_j.pdf)
- Dated 2021-11-08.
- Printed page 7 / PDF index page 6.
- Source title: market-by-market quarterly trend in Device consolidated sales.
- Unit: JPY hundred millions; the recorded values are transparently converted to JPY billions.
- The source identifies 2Q as an actual result. Later forecast-context values are deliberately not registered as facts.

**Sanken boundary**

Do not describe `EVR-026` as automotive product-category revenue, SiC-only revenue, power-device-only revenue, OEM demand, or automotive semiconductor industry demand. Do not join it to `EVR-025`; the source titles and periodicities do not establish definition continuity. `AvailableAt = TBD — no use` remains in force.

## 8. Review and Lifecycle Status

The formal lifecycle state of the Sprint package is controlled by the Evidence Register and PIT baseline named in Section 1. Both currently state `Reviewer Status: Pending independent re-review`.

| Scope | Repository-verifiable review record | Current formal status |
| --- | --- | --- |
| Fuji evidence | `6504_FujiElectricIndependentReview.v0.1-draft.md` | Draft package remains pending independent re-review. |
| Renesas, ROHM, and Sanken evidence | No formal independent-review record is currently listed in this Draft workspace. Do not infer approval from prior work-session discussion. | Draft package remains pending independent re-review. |
| Entire Sprint001 package | No package-level review record is identified. | Pending independent re-review. |

No review statement in this handoff creates a lifecycle transition, canonical status, Catalog eligibility, or downstream-use permission.

## 9. Known Blockers

1. No approved `AvailableAt` convention exists.
2. No Sprint001 Draft has been approved as a Knowledge Catalog entry.
3. No DDL design may start from this Draft package.
4. Cross-company comparability is not established for any issuer series.
5. Sanken has no acquired FY2021 full-year or FY2022-present continuous Automotive series.
6. Renesas has no acquired FY2021-FY2022 restatement on the customer-name basis.

## 10. Exact Next Action

Continue **only** Sanken primary-source acquisition.

1. Locate an official Sanken FY2021 full-year result presentation or equivalent official disclosure that might include the Automotive market / Device sales table.
2. If identified, capture the document title, issuer, publication date, durable URL, printed/PDF page locator, source table title, row / series label, period, unit, exact value, scope, and forecast-versus-actual status.
3. Create a new Draft raw-evidence record; do not modify `EVR-026` to add a new observation.
4. Immediately before allocating any new identifier, re-read the current `Sprint001AutomotiveEvidenceRegister.v0.1-draft.md` and `Sprint001AutomotiveSourceInventoryAndPIT.v0.1-draft.md`. Confirm the next unused identifier from the current files; do not reserve or predict an ID in advance.
5. In one coherent Draft update, add the new Evidence Register row and its matching PIT row, with explicit reciprocal references. Then update the applicable Sanken raw-evidence, Company Research, and Source Archive Audit records only where their factual state changed.
6. If no suitable source is located, update `6707_SankenElectricSourceArchiveAudit.v0.1-draft.md` only. Record the research date, official archive path or durable URL searched, precise search / navigation boundary, specifically identified documents checked, and the limited result: no suitable document was identified within that verified scope. Do not claim that no official source exists.
7. Request independent Evidence, Knowledge, and Traceability reviews. Revise and re-review when a material issue is found.
8. Before ending the work session, update this handoff's `Last updated / as of`, exact stop point, and next action if the work state changed.

## 11. Do Not Do

- Do not promote, release, move, or rename Draft research.
- Do not alter the Governance v1.0 Constitution, Policies, Standards, or Procedures.
- Do not create a shared issuer series, a Catalog entry, DDL, Entity, Database, ML, Decision Engine, or Advisor artifact.
- Do not replace source-defined terms with broader economic claims.
- Do not add forecast values as actual observations.
- Do not infer a release time, `AvailableAt`, period mapping, definition continuity, or approval history.

## 12. Definition of Done for Sprint001

Sprint001 may proceed to Knowledge Catalog review only when the Automotive Semiconductor Demand package is independently reviewed, traceable to primary evidence, definition-controlled, free from unsupported issuer-series mixing, and sufficiently complete that DDL design does not require additional industry-level research.

## 13. Suggested Restart Prompt

```text
Read the onboarding and governance documents listed in
Sprint001_Automotive_Handoff.md, then read the Evidence Register and
PIT inventory. Continue only Sprint001 Automotive Semiconductor Demand
in the Draft workspace. The immediate task is to locate official Sanken
FY2021 full-year and FY2022-onward Automotive Device-sales disclosures.
Preserve Fact / Inference separation, AvailableAt = TBD — no use, and
independent Evidence / Knowledge / Traceability review. Do not promote
any Draft to Catalog, DDL, or implementation.
```
