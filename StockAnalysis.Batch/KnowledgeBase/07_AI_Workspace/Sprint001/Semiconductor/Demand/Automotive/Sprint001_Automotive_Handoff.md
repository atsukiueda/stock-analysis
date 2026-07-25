# Sprint001 Automotive Semiconductor Demand — Handoff Record

## 1. Current State

| Item | Current state |
| --- | --- |
| Version / as of | 0.3-draft / 2026-07-25 (Asia/Tokyo) |
| Scope | Sprint001 → Semiconductor → Demand → Automotive only |
| Phase | Research / Evidence Collection |
| Workspace | `KnowledgeBase/07_AI_Workspace/Sprint001/Semiconductor/Demand/Automotive/` only |
| Governance | Governance v1.0 is Approved and Effective. Constitution / Policy / Standard / Procedure are frozen absent Material Governance Change. |
| Formal evidence state | Evidence Register and PIT remain **Draft / Pending independent re-review**. Limited reviews do not approve, promote, or transition lifecycle state. |
| Use restriction | `AvailableAt = TBD — no use`. No Catalog, DDL, Entity, Database, ML, backtest, Decision Engine, Advisor, or investment use. |

This is a Draft workspace handoff, not canonical research or governance authority. If it conflicts with the Evidence Register or PIT, those current records control.

## 2. Read Before Acting

1. `README.md`
2. `000_ProjectDocumentationConstitution.md`
3. `ProjectInstructions.md`
4. `AGENTS.md`
5. `KnowledgeBase/00_Project/KnowledgeBaseRules.md`
6. `KnowledgeBase/00_Project/ResearchPolicy.md`
7. `KnowledgeBase/00_Project/ReviewPolicy.md`
8. This handoff
9. `Sprint001AutomotiveEvidenceRegister.v0.1-draft.md`
10. `Sprint001AutomotiveSourceInventoryAndPIT.v0.1-draft.md`
11. `6707_SankenElectricAutomotiveSalesFY2021ToFY2024RawEvidence.v0.1-draft.md`
12. `6707_SankenElectricAutomotiveMarketSalesRawEvidence.v0.1-draft.md`
13. `6707_SankenElectricIndependentReview.v0.1-draft.md`

## 3. Non-Negotiable Boundaries

- Keep Fact, Inference, Hypothesis, Opinion, Proposal, and Decision distinct.
- Prefer issuer-authored primary disclosures; record issuer, title, publication date, URL, page, table, row, period, unit, actual/forecast status, definition, and use boundary.
- An author cannot approve the author's own work. Reviews must separately test Evidence, Knowledge, and Traceability, with problem discovery first.
- Do not join observations merely because names or values are similar. Do not infer availability, definitions, mappings, continuity, comparability, or approval.
- Drafts stay in this workspace. No promotion or downstream artifact creation.

## 4. Other Issuer Draft State

| Issuer | Facts retained in Draft | Boundary |
| --- | --- | --- |
| Fuji Electric (6504) | Semiconductor-segment Automotive application sales: FY2021–FY2025 JPY73.1bn / 100.2bn / 125.6bn / 132.6bn / 117.7bn. | Issuer-internal evidence only; not a common industry series; `AvailableAt = TBD — no use`. |
| Renesas Electronics (6723) | FY2023 Automotive Business revenue: original JPY695.0bn and revised JPY660.4bn; revised-basis candidate FY2023–FY2025: JPY660.4bn / 702.8bn / 639.7bn. | Original and revised FY2023 observations are mutually exclusive. FY2021–FY2022 customer-name-basis restatements are not acquired; do not create a five-year single-basis series. |
| ROHM (6963) | Issuer-defined Automotive market sales FY2021–FY2025: JPY172.5bn / 213.0bn / 229.4bn / 223.8bn / 236.8bn. | Market classification, not product/SiC/power-device/industry-demand revenue; methodology continuity and comparability are unestablished. |

## 5. Sanken Electric (6707) — Current Evidence State

### Facts recorded

| IDs | Source-defined measure | Period / source-presented value | Controlled boundary |
| --- | --- | --- | --- |
| `EVR-025` / `PIT-016` | Historical consolidated market sales, Automotive total | FY2018 JPY76,442m; FY2019 JPY70,233m; FY2020 JPY64,045m | Historical context only; outside target period. |
| `EVR-026` / `PIT-017` | Device consolidated sales by market, Automotive | FY2021 1Q JPY21.4bn; 2Q JPY20.9bn | Two actual quarterly observations only. |
| `EVR-027` / `PIT-018` | Device consolidated sales by market, Automotive | FY2021 quarterly actuals; JPY85.8bn is arithmetic-derived only | No source-presented FY2021 annual observation in this record. |
| `EVR-028` / `PIT-019` | Device consolidated sales by market, Automotive | FY2022 full year JPY114.5bn | Source-defined measure; continuity remains unestablished. |
| `EVR-029` / `PIT-020` | Device consolidated sales by market, Automotive | FY2023 full year JPY138.7bn | Source-defined measure; continuity remains unestablished. |
| `EVR-030` / `PIT-021` | Sanken Core sales by market, Automotive | FY2024 quarterly actuals JPY7.9bn / 7.8bn / 7.2bn / 8.7bn; JPY31.6bn is arithmetic-derived only | Source title differs from FY2021–FY2023. Underlying effect is Unknown. |
| `EVR-031` / `PIT-022` | Consolidated market sales, Automotive | FY2021 JPY87,899m | Separate issuer table; no mapping or comparability claim. |
| `EVR-032` / `PIT-023` | Consolidated market sales, Automotive | FY2022 JPY116,986m | Separate issuer table; no mapping or comparability claim. |
| `EVR-033` / `PIT-024` | Consolidated market sales, Automotive | FY2023 JPY141,536m | Separate issuer table; no mapping or comparability claim. |
| `EVR-034` / `PIT-025` | Consolidated market sales, Automotive | FY2024 JPY55,562m | The source states Allegro MicroSystems, Inc. and Polar Semiconductor, LLC were excluded from consolidation. |
| `EVR-035` / `PIT-026` | Reclassified comparative consolidated market sales, Automotive | FY2024 JPY31,668m | Later source-presented comparative; separate from EVR-034. Its note components do not arithmetically reproduce the displayed value; no reconciliation is inferred. |
| `EVR-036` / `PIT-027` | `Sales by Market`, Automotive / Sanken Core | FY2024 JPY31,668m | Distinct `Sales by Market` table. |
| `EVR-037` / `PIT-028` | `Net Sales by Market`, Automotive / Sanken Core | FY2024 comparative JPY31,668m; FY2025 JPY31,390m | Source states Allegro and the Switching Power Supply Product (Former Unit Products) business were reclassified into `Others`. `RestatementFlag: Yes` applies to its FY2024 comparative. |

### Required non-claims

- Numeric equality of FY2024 JPY31,668m among `EVR-035`, `EVR-036`, and `EVR-037` does **not** establish identity, mapping, continuity, or comparability.
- `EVR-036` is `Sales by Market`; `EVR-037` is `Net Sales by Market`. These are distinct source tables.
- No listed observation is automotive product revenue, SiC-only revenue, power-device-only revenue, OEM demand, or automotive-semiconductor industry demand unless the specific source says so.
- No joined Sanken FY2021–FY2025 series exists.

## 6. Review Record

`6707_SankenElectricIndependentReview.v0.1-draft.md` records limited independent reviews for `EVR-031` through `EVR-037`.

Facts about the review state:

- Evidence, Knowledge, and Traceability reviewers reported no new finding after targeted remediation for `EVR-035`, `EVR-036`, and `EVR-037`.
- `K-037-001` required explicit principal-record non-claims between the distinct `Sales by Market` and `Net Sales by Market` tables; it was remediated and re-reviewed with no new Knowledge finding.

**Status boundary:** None of these reviews is approval, an independent lifecycle disposition for the package, a promotion, or authorization for downstream use. Formal status remains **Draft / Evidence Collection / Pending independent re-review**.

## 7. Exact Next Action

Continue only targeted primary-source research for an issuer statement that explicitly explains the relationship, if any, among:

1. FY2021–FY2023 `Device consolidated sales by market`;
2. FY2024–FY2025 `Sanken Core` market-sales tables; and
3. the FY2024 reclassification to `Others`.

Do not treat matching values, labels, or adjacent presentations as that statement. If a qualifying fact is found, first re-read the Evidence Register and PIT, confirm unused IDs, then update the relevant Raw Evidence, Evidence Register, and PIT in one coherent Draft change. Request independent Evidence, Knowledge, and Traceability review before recording any conclusion beyond the source fact.

If no qualifying material is found, update only `6707_SankenElectricSourceArchiveAudit.v0.1-draft.md` with the research date, official sources checked, scope searched, and limited non-finding. Do not state that no official source exists.

## 8. Do Not Do

- Do not change governance documents.
- Do not promote, release, move, or rename Draft research.
- Do not create Catalog, DDL, Entity, Database, ML, Decision Engine, Advisor, backtest, or investment artifacts.
- Do not use forecast values as actual observations.
- Do not alter `AvailableAt = TBD — no use`.
