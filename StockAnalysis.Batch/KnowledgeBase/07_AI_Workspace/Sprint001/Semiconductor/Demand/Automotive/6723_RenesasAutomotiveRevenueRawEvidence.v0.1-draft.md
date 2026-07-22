# Renesas Automotive Business Revenue — Raw Evidence Register

## Document Information

| Item | Value |
| --- | --- |
| Company | Renesas Electronics (6723) |
| Observation | Non-GAAP Automotive Business revenue |
| Version | 0.1-draft |
| Status | Evidence Collection — definition continuity unresolved |
| Reviewer Status | Pending independent re-review |
| Last Updated | 2026-07-20 |

> **No-series boundary:** The rows below preserve source-reported values. The FY2023 original value and the revised FY2023 comparative value must not be combined. A later Renesas presentation identifies the revised 2023 segment financial statements as based on a new aggregation method; no complete 2021–present restated series has yet been acquired.

---

## Raw Evidence Rows

| Record ID | Applicable period | Value / unit | DisclosedAt | Source and pinpoint locator | Automotive scope | Restatement / comparability | `AvailableAt` | Catalog eligibility |
| --- | --- | ---: | --- | --- | --- | --- | --- | --- |
| REN-AUTO-2021 | 2021-01-01–2021-12-31 | JPY462.3bn | 2022-02-09 | [Financial Report 2021](https://www.renesas.com/en/document/rep/financial-report-2021), `A) Overview of the current financial operation (Non-GAAP basis)`, Automotive revenue table | Source-defined Automotive Business | Original FY2021 report; no cross-year continuity conclusion | TBD — no use | No |
| REN-AUTO-2022 | 2022-01-01–2022-12-31 | JPY645.0bn | 2023-02-09 | [Financial Report 2022](https://www.renesas.com/en/document/rep/financial-report-2022), `A) Overview of the current financial operation (Non-GAAP basis)`, Automotive revenue table | Source-defined Automotive Business | Original FY2022 report; no cross-year continuity conclusion | TBD — no use | No |
| REN-AUTO-2023-A | 2023-01-01–2023-12-31 | JPY695.0bn | 2024-02-08 | [Financial Report 2023](https://www.renesas.com/en/document/rep/financial-report-2023), p.4, Automotive Business / Automotive revenue | Source-defined Automotive Business | Original FY2023 report | TBD — no use | No |
| REN-AUTO-2023-B | 2023-01-01–2023-12-31 | JPY660.4bn | 2025-02-06 | [Financial Report 2024](https://www.renesas.com/en/document/rep/financial-report-2024), p.4, comparative Automotive revenue table; [1Q 2024 Presentation](https://www.renesas.com/en/document/ppt/2024-1q-presentation-material), p.12 footnote 1 | Prior-year comparative in FY2024 report | **Revised based on new aggregation method.** Mutually exclusive with REN-AUTO-2023-A. | TBD — no use | No |
| REN-AUTO-2024 | 2024-01-01–2024-12-31 | JPY702.8bn | 2025-02-06 | [Financial Report 2024](https://www.renesas.com/en/document/rep/financial-report-2024), p.4, Automotive Business / Automotive revenue | Source-defined Automotive Business | Definition continuity with prior reports unresolved | TBD — no use | No |
| REN-AUTO-2025 | 2025-01-01–2025-12-31 | JPY639.7bn | 2026-02-05 | [Financial Report 2025](https://www.renesas.com/en/document/rep/financial-report-2025), p.4, Automotive Business / Automotive revenue | Source-defined Automotive Business | Definition continuity with prior reports unresolved | TBD — no use | No |

---

## Evidence Interpretation

### Facts

- Renesas disclosed the listed values in the identified reports, with the stated dates and fiscal periods.
- The FY2023 original report and FY2024 comparative report contain different Automotive revenue values for the same FY2023 period.

### Inference

The FY2023 discrepancy is a material comparability event. It prevents use of the rows as a single time series until the issuer’s reporting change, restatement, or scope explanation is identified.

### Prohibited uses

- Computing FY2023-to-FY2024 growth from a selected FY2023 value.
- Using any row as a point-in-time feature before `AvailableAt` is defined by an approved operating convention.
- Comparing Renesas values with another issuer’s automotive revenue without a documented comparability assessment.

## Required Remediation

1. Locate the issuer statement explaining the FY2023 comparative difference.
2. Record `ScopeOrSegmentVersion` and `RestatementFlag` for every row.
3. Determine whether an issuer-restated 2021–present series exists.
4. Only then submit a candidate direct-within-issuer series for independent validation.

---

## Difference Investigation — 2026-07-20

### Sources reviewed

- [Financial Report 2023](https://www.renesas.com/en/document/rep/financial-report-2023), p.4 — FY2023 Automotive Business revenue JPY695.0bn.
- [Financial Report 2024](https://www.renesas.com/en/document/rep/financial-report-2024), p.4 — FY2023 comparative Automotive Business revenue JPY660.4bn and FY2024 revenue JPY702.8bn.
- [Annual Securities Report 2024](https://www.renesas.com/en/document/rep/annual-securities-report-2024), `Overview of the financial operation` / `Business Segments` references.
- Official Renesas investor-update and financial-report archive entries for FY2021–FY2025.
- [1Q 2024 Presentation](https://www.renesas.com/en/document/ppt/2024-1q-presentation-material), p.12, `REVENUE AND GROSS PROFIT BY SEGMENT` footnote 1.

### Confirmed facts

1. The FY2023 original Financial Report reports JPY695.0bn for FY2023 Automotive Business Non-GAAP revenue.
2. The FY2024 Financial Report reports JPY660.4bn as the FY2023 comparative figure and JPY702.8bn for FY2024.
3. The 1Q 2024 Presentation p.12 footnote 1 states: `2023 segment financial statements: revised based on the new aggregation method.` This explicitly explains why FY2023 may appear on a revised basis in later 2024 materials.
4. The reviewed sources do not yet provide a complete historical restated series for FY2021–FY2025 or a detailed mapping of the new aggregation method.

### Disposition

**Partially resolved.** The JPY34.6bn FY2023 difference is a disclosed revision based on a new aggregation method. `REN-AUTO-2023-A` remains the original basis and `REN-AUTO-2023-B` the revised basis; they are mutually exclusive. `REN-AUTO-2023-B` may be considered only with later materials using the same revised basis, after Point-in-Time controls are completed. A full FY2021–FY2025 directly comparable series remains unavailable.

### Required external resolution

Obtain a primary-source reconciliation or restated historical series that maps FY2021–FY2022 into the new aggregation method. Until then, the proposed Automotive Business revenue series remains rejected for full-period lead/lag analysis and derived growth calculations spanning unreconciled bases.

---

## Retrospective-Series Search — 2026-07-20

### Sources checked

- [1Q 2024 Presentation](https://www.renesas.com/en/document/ppt/2024-1q-presentation-material), p.6 and p.12.
- [2Q 2024 Presentation](https://www.renesas.com/en/document/ppt/2024-2q-presentation-material), p.6 and p.12.
- [3Q 2024 Presentation](https://www.renesas.com/en/document/ppt/2024-3q-presentation-material), p.6.
- [4Q / Full-Year 2024 Presentation](https://www.renesas.com/en/document/ppt/2024-full-year-presentation-material), p.6.
- [3Q 2025 Presentation](https://www.renesas.com/en/document/ppt/2025-3q-presentation-material), p.8.
- Renesas Financial Reports archive, including correction notices for Financial Report 2021 and 2022 dated 2023-05-11.

### Findings

1. The 2024 and 2025 presentation series consistently label **2023** segment revenue as revised based on the new aggregation method.
2. The reviewed presentation charts show 2022 context but do not label FY2021 or FY2022 segment revenue as revised under the new aggregation method.
3. The archive lists correction documents for Financial Report 2021 and 2022, but the reviewed archive metadata does not establish that they provide a new-aggregation-method restatement of Automotive Business revenue.

### Disposition

**No complete FY2021–FY2022 restated Automotive Business revenue series confirmed.** The permitted candidate window remains only the revised FY2023 basis and later materials, subject to Point-in-Time completion and independent review. No 2021–2025 continuous series is adopted.
