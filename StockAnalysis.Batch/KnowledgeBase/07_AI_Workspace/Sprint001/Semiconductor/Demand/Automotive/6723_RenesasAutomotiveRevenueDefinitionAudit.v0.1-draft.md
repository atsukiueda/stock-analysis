# Renesas Automotive Business Revenue — Definition and Series Audit

## Document Information

| Item | Value |
| --- | --- |
| Document type | Draft definition / series audit |
| Observation | Renesas Non-GAAP Automotive Business revenue |
| Version | 0.1-draft |
| Status | Evidence Collection; current raw-evidence authority within this Draft package is `6723_RenesasAutomotiveRevenueRawEvidence.v0.2-draft.md`; pending independent review |
| Date | 2026-07-21 |

> **Authority boundary:** This Draft identifies disclosed aggregation bases and potential issuer-internal series. It does not authorize a Catalog observation, DDL field, point-in-time use, feature, backtest, or investment conclusion.

## Primary-Source Facts

| Fact ID | Source and locator | Fact |
| --- | --- | --- |
| REN-DEF-001 | v0.2 REN-AUTO-2021 / REN-AUTO-2022; Financial Report 2022, p. 4 / PDF p. 3; source-event identity requires separate completion | The report presents Automotive Non-GAAP revenue of JPY462.3bn for FY2021 and JPY645.0bn for FY2022 in a consecutive comparison. |
| REN-DEF-002 | v0.2 REN-AUTO-2023-A / REN-EVT-001; [Financial Report 2023](https://www.renesas.com/en/document/rep/financial-report-2023), published 2024-03-28, p. 4 / PDF p. 3 | The original FY2023 report presents Automotive Non-GAAP revenue of JPY695.0bn for FY2023. |
| REN-DEF-003 | v0.2 REN-AUTO-2023-B / REN-EVT-002 and REN-EVT-003; 1Q 2024 Presentation, published 2024-04-25, presentation p. 4 / PDF p. 2 and presentation p. 7 / PDF p. 5; Financial Report 2024 Note 6 / PDF p. 35 | Due to organizational changes in FY2024, the methodology for aggregating reportable-segment revenue changed from product groupings to customer names; previously reported FY2023 segment information was revised using the new methodology. |
| REN-DEF-004 | v0.2 REN-AUTO-2023-B / REN-AUTO-2024 / REN-EVT-003; Financial Report 2024, published 2025-03-26, p. 4 / PDF p. 3 and Note 6 / PDF p. 35 | The FY2024 / revised-FY2023 comparison presents Automotive revenue JPY702.8bn / JPY660.4bn. Note 6 presents FY2023 Automotive revenue from external customers of JPY660,409m. |
| REN-DEF-005 | v0.2 REN-AUTO-2025 / REN-EVT-004; [Financial Report 2025](https://www.renesas.com/en/document/rep/financial-report-2025), published 2026-03-19, p. 4 / PDF p. 3 | The FY2025 / FY2024 comparison presents Automotive revenue JPY639.7bn / JPY702.8bn. |

## Series Separation

| Series ID | Included periods | Values (JPYbn) | Basis | Status |
| --- | --- | --- | --- | --- |
| REN-S-ORIGINAL | FY2021–FY2023 original disclosures | 462.3, 645.0, 695.0 | Pre-FY2024 aggregation-basis source observations. The later report states the methodology was changed from product groupings to customer names in FY2024. | Candidate source-observation chain; not comparable to the revised series without reconciliation. |
| REN-S-REVISED | FY2023 revised → FY2025 | 660.4, 702.8, 639.7 | FY2023 revised under the FY2024 customer-name aggregation methodology, followed by consecutive FY2024 and FY2025 comparisons. | Candidate issuer-internal series; independent review and PIT control required. |

## Controlled Inferences

1. **Inference:** FY2023 original JPY695.0bn and revised JPY660.4bn are mutually exclusive representations of the same period under different stated aggregation methods. They must not be combined.
2. **Inference:** The FY2023 revised → FY2024 → FY2025 values are a candidate internal continuity window because each later report presents the immediately prior comparison and the FY2024 report expressly explains the FY2023 revision basis.
3. **Boundary:** The sources reviewed do not provide FY2021–FY2022 restated under the customer-name aggregation methodology. A five-year single-basis series is therefore not established.

## Proposed Transition Dispositions — Not Approved

| Transition | Proposed disposition | Constraint |
| --- | --- | --- |
| FY2021 → FY2022 | Source observations only; transition assessment deferred | Financial Report publication events require completion. Must retain original-report basis and acquisition/PPA context. |
| FY2022 → FY2023 original | Source observations only; transition assessment deferred | Financial Report publication events require completion. Do not calculate across to FY2024 revised-basis value. |
| FY2023 original → FY2023 revised | Non-comparable / mutually exclusive | Issuer changed aggregation methodology; this is a reconciliation boundary, not a growth transition. |
| FY2023 revised → FY2024 | Candidate direct within revised basis | Requires independent confirmation that FY2024 uses the stated new methodology and retains the same Automotive Business scope. |
| FY2024 → FY2025 | Candidate direct within revised basis | Consecutive comparison is disclosed; confirm no later aggregation-method change before approval. |

## Point-in-Time and Downstream Boundary

All rows remain `AvailableAt = TBD — no use`. The audit does not permit any Catalog, DDL, ML, backtest, or investment use. The candidate revised-basis window is an evidence-collection result only.

## Required Independent Review

1. Verify the exact interpretation of the FY2024 aggregation-method change and FY2023 revision.
2. Confirm that FY2025 does not disclose a further aggregation-method change affecting Automotive Business revenue.
3. Accept, amend, or reject each proposed transition disposition.
4. Confirm that all Research Sheet references preserve the original/revised series separation.
