# ROHM Automotive Market Sales Definition Audit

## Document Information

| Item | Value |
| --- | --- |
| Document type | Draft definition and continuity audit |
| Company | ROHM Co., Ltd. (6963) |
| Measure under audit | Issuer-defined market-segment sales: `Automotive` |
| Version | 0.1-draft |
| Status | Evidence Collection; pending independent review |
| Scope | FY2021–FY2025 source observations only |
| Accessed | 2026-07-23 |

> **Authority boundary:** This audit determines neither a Catalog measure nor a DDL field. It records whether currently captured issuer disclosures support a comparability disposition.

## Question

Do the captured ROHM disclosures establish a definition-continuous FY2021–FY2025 issuer-internal Automotive market-sales series?

## Evidence Basis

| Evidence | Disclosed market label | Covered periods | Definition-relevant source wording | Audit use |
| --- | --- | --- | --- | --- |
| `EVR-022` | `Automotive` in `FY2022 Sales Trend by Market Segments (YoY)` | FY2021 / FY2022 | `Market Segment: Calculated by most recent segment.` | Establishes the FY2021 / FY2022 values and identifies a classification-control note. |
| `EVR-021` | `Automotive` in `FY2023 Sales Trend by Market Segments (YoY)` | FY2022 / FY2023 | The captured table identifies market segments; no explicit continuity statement is captured in the evidence record. | Establishes FY2022 / FY2023 values and an overlap with `EVR-022`. |
| `EVR-023` | `Automotive` in `FY2024 Sales Trend by Market Segments (YoY)` | FY2023 / FY2024 | The captured table identifies market segments; no explicit continuity statement is captured in the evidence record. | Establishes FY2023 / FY2024 values and overlaps with adjacent source events. |
| `EVR-019` | `Automotive` in `FY2025 Results — Sales by Market Segment (YoY)` | FY2024 / FY2025 | The captured table identifies market segments; no explicit continuity statement is captured in the evidence record. | Establishes FY2024 / FY2025 values and an overlap with `EVR-023`. |

## Source-Event Reconciliation

| Overlapping fiscal year | Source-event values | Result |
| --- | --- | --- |
| FY2022 | `EVR-022`: JPY213.0bn; `EVR-021`: JPY213.0bn | Numeric values agree. |
| FY2023 | `EVR-021`: JPY229.4bn; `EVR-023`: JPY229.4bn | Numeric values agree. |
| FY2024 | `EVR-023`: JPY223.8bn; `EVR-019`: JPY223.8bn | Numeric values agree. |

## Findings

### Facts

- Each captured presentation uses the market label `Automotive` and reports adjacent fiscal-year values in JPY billions.
- The three overlapping values agree across adjacent source events.
- `EVR-022` explicitly states that its market segment is calculated by the most recent segment.
- No captured evidence record contains an issuer statement that the market-definition methodology remained unchanged across FY2021–FY2025.

### Inference

The reconciled overlaps reduce the risk of a numerical transcription or adjacent-source mismatch. They do not establish definition continuity, because the FY2022 source expressly references calculation by the most recent segment and the captured sources do not state an unchanged methodology across the full period.

## Disposition

| Field | Draft disposition |
| --- | --- |
| Comparability class | Not assigned |
| Review status | Pending classification |
| Validated continuous series | No |
| Catalog eligibility | No |
| DDL / ML / backtest / investment use | Prohibited while `AvailableAt = TBD — no use` and comparability remains undisposed |

## Evidence Gaps and Required Action

| Gap | Why it matters | Required action |
| --- | --- | --- |
| Definition-continuity statement or methodology history | Numeric agreement does not prove that the market classification had unchanged scope. | Locate an issuer disclosure that explicitly describes classification stability, a restatement, or a methodology change; otherwise retain the no-class disposition. |
| Approved `AvailableAt` operating convention | Public document dates do not by themselves establish permitted point-in-time use. | Do not infer it; retain the governed `TBD — no use` boundary. |

## Explicit Non-Claims

- This audit does not classify ROHM Automotive market sales as Direct, Proxy, or Non-comparable.
- This audit does not equate the market-sales measure to product, SiC, discrete-device, power-device, OEM, or industry-demand revenue.
- This audit does not authorize Catalog, DDL, ML, backtest, or investment use.

## Required Independent Review

1. Verify that each source event, locator, and overlap value resolves to the Evidence Register.
2. Test whether the `most recent segment` note has a more specific issuer-defined effect than is stated here.
3. Confirm that the Draft disposition does not convert numeric reconciliation into definition continuity.
