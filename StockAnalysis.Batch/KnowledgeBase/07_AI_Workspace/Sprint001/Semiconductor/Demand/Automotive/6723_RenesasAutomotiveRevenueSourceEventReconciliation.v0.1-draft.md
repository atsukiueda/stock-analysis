# Renesas Automotive Revenue — Source-Event Reconciliation

## Document Information

| Item | Value |
| --- | --- |
| Document type | Draft evidence-event reconciliation |
| Scope | Original versus revised FY2023 Automotive Business revenue disclosures |
| Version | 0.1-draft |
| Status | Evidence Collection; not independently approved |
| Accessed | 2026-07-21 |

> **Boundary:** A fiscal period, a source publication event, and a permitted operating `AvailableAt` time are different attributes. This record resolves source-event identity only; it does not derive `AvailableAt`.

## Event Register

| Event ID | Related raw record / audit fact | Document and publication event | Evidence purpose | Observation / method statement | Availability status |
| --- | --- | --- | --- | --- | --- |
| REN-EVT-001 | REN-AUTO-2023-A / REN-DEF-002 | [Financial Report 2023](https://www.renesas.com/en/document/rep/financial-report-2023), published 2024-03-28 | Original FY2023 source event | Automotive Business Non-GAAP revenue: JPY695.0bn for FY2023. | `AvailableAt`: TBD — no use |
| REN-EVT-002 | REN-AUTO-2023-B / REN-DEF-003 | [1Q 2024 Presentation](https://www.renesas.com/en/document/ppt/2024-1q-presentation-material), published 2024-04-25; method statement: presentation p. 4 / PDF p. 2; revised-segment footnote: presentation p. 7 / PDF p. 5 | Earliest identified revised-basis method event | Due to organizational changes in 1Q FY2024, revenue aggregation changed from product axis to customer axis; FY2023 segment information was revised for comparability with FY2024. | `AvailableAt`: TBD — no use |
| REN-EVT-003 | REN-AUTO-2023-B, REN-AUTO-2024 / REN-DEF-003–004 | [Financial Report 2024](https://www.renesas.com/en/document/rep/financial-report-2024), published 2025-03-26; p. 4 / PDF p. 3; Note 6 / PDF p. 35 | Audited annual revised-basis value and detailed methodology | FY2023 Automotive JPY660.4bn and FY2024 JPY702.8bn; the method changed from product groupings to customer names and FY2023 was revised. | `AvailableAt`: TBD — no use |
| REN-EVT-004 | REN-AUTO-2025 / REN-DEF-005 | [Financial Report 2025](https://www.renesas.com/en/document/rep/financial-report-2025), published 2026-03-19; p. 4 / PDF p. 3 | Later consecutive annual comparison | FY2024 Automotive JPY702.8bn and FY2025 JPY639.7bn. The reviewed report does not identify a further reportable-segment aggregation-method change. | `AvailableAt`: TBD — no use |

## Fact-Level Reconciliation

| Question | Fact-based answer |
| --- | --- |
| Is 2025-02-06 the publication event for the cited Financial Report 2024? | No. That date corresponds to a full-year earnings-release event, not the Financial Report 2024 cited by the raw-evidence record. The Financial Report publication event is recorded separately as 2025-03-26. |
| What is the earliest identified source event explaining the revised FY2023 basis? | The 1Q 2024 Presentation, published 2024-04-25. |
| Can the original FY2023 and revised FY2023 values be merged? | No. They are source-specific representations under different stated aggregation methodologies. |
| Does this establish PIT usability? | No. `AvailableAt` remains undefined under the project’s current operating convention. |

## Required Follow-up

1. Update any raw-evidence row that cites a Financial Report to use the corresponding Financial Report publication event, not an earnings-release date.
2. Retain the 2024-04-25 presentation as the earliest identified revised-method explanation event.
3. Keep source-event time and `AvailableAt` separate in all future Catalog candidates.
