# Renesas Automotive Business Revenue — Raw Evidence Register

## Document Information

| Item | Value |
| --- | --- |
| Company | Renesas Electronics (6723) |
| Observation | Non-GAAP Automotive Business revenue |
| Version | 0.2-draft |
| Supersedes | v0.1-draft for current Draft-package interpretation; v0.1 is retained as historical working evidence. |
| Status | Evidence Collection; no Catalog or downstream eligibility |
| Reviewer Status | Pending independent re-review of v0.2 |
| Last Updated | 2026-07-21 |

> **Series boundary:** Financial Report publication events, earnings-release events, and `AvailableAt` are distinct. This v0.2 record uses Financial Report dates only where the Financial Report is cited. It preserves original and revised FY2023 representations separately.

## Raw Evidence and Source Events

| Record ID | Fiscal period | Value | Cited source / event identity | Basis and scope | Comparability | `AvailableAt` | Catalog eligibility |
| --- | --- | ---: | --- | --- | --- | --- | --- |
| REN-AUTO-2021 | FY2021 | JPY462.3bn | Financial Report 2021, Automotive table; Financial Report publication event not yet captured in this Sprint package | Non-GAAP Automotive Business; pre-FY2024 aggregation basis | Single source observation only; no candidate transition pending source-event completion | TBD — no use | No |
| REN-AUTO-2022 | FY2022 | JPY645.0bn | Financial Report 2022, Automotive table; Financial Report publication event not yet captured in this Sprint package | Non-GAAP Automotive Business; pre-FY2024 aggregation basis | Single source observation only; no candidate transition pending source-event completion | TBD — no use | No |
| REN-AUTO-2023-A | FY2023 | JPY695.0bn | [Financial Report 2023](https://www.renesas.com/en/document/rep/financial-report-2023), published 2024-03-28, p. 4 / PDF p. 3; REN-EVT-001 | Non-GAAP Automotive Business; pre-FY2024 aggregation basis | Mutually exclusive with REN-AUTO-2023-B | TBD — no use | No |
| REN-AUTO-2023-B | FY2023 revised | JPY660.4bn | [1Q 2024 Presentation](https://www.renesas.com/en/document/ppt/2024-1q-presentation-material), published 2024-04-25: method statement presentation p. 4 / PDF p. 2; revised-segment footnote presentation p. 7 / PDF p. 5; REN-EVT-002. [Financial Report 2024](https://www.renesas.com/en/document/rep/financial-report-2024), published 2025-03-26, p. 4 / PDF p. 3 and Note 6 / PDF p. 35; REN-EVT-003. | Non-GAAP Automotive Business; revised customer-name aggregation | Candidate revised-basis observation; mutually exclusive with REN-AUTO-2023-A | TBD — no use | No |
| REN-AUTO-2024 | FY2024 | JPY702.8bn | Financial Report 2024, published 2025-03-26, p. 4 / PDF p. 3; REN-EVT-003 | Non-GAAP Automotive Business; customer-name aggregation as described in Note 6 | Candidate direct within revised basis; independent confirmation pending | TBD — no use | No |
| REN-AUTO-2025 | FY2025 | JPY639.7bn | [Financial Report 2025](https://www.renesas.com/en/document/rep/financial-report-2025), published 2026-03-19, p. 4 / PDF p. 3; REN-EVT-004 | Non-GAAP Automotive Business; no further aggregation-method change located in the reviewed report | Candidate direct within revised basis; independent confirmation pending | TBD — no use | No |

## Current Interpretation

### Facts

- Financial Report 2024 states that FY2024 organizational changes changed reportable-segment revenue aggregation from product groupings to customer names and revised FY2023 segment information.
- FY2023 has two reported Automotive Business values: JPY695.0bn on the original basis and JPY660.4bn on the revised basis.
- FY2024 and FY2025 reports each reproduce the immediately preceding revised-basis Automotive Business comparison.

### Inferences

- FY2023 revised → FY2024 → FY2025 is a candidate issuer-internal revised-basis observation window, pending independent review.
- No FY2021–FY2022 customer-name-aggregation restatement is captured; no full five-year single-basis series is asserted.

### Prohibited Uses

- Do not join FY2023 original with FY2023 revised or calculate growth across that boundary.
- Do not use any row for PIT, Catalog, DDL, ML, backtest, or investment use.
- Do not treat a Financial Report’s publication event as its earnings-release date.

## Required Remaining Work

1. Capture Financial Report publication events for FY2021 and FY2022 before considering an original-basis transition.
2. Independently review the revised-basis FY2023 → FY2024 → FY2025 window.
3. Maintain `AvailableAt = TBD — no use` until an approved operating convention exists.

