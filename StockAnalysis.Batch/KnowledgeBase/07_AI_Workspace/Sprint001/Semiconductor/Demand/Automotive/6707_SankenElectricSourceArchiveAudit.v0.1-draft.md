# Sanken Electric Source Archive Audit

## Document Information

| Item | Value |
| --- | --- |
| Document type | Draft source-archive audit |
| Company | Sanken Electric Co., Ltd. (6707) |
| Version | 0.1-draft |
| Status | Evidence Collection; revised after independent review |
| Accessed | 2026-07-23 |

> **Authority boundary:** This audit records source accessibility and observed disclosure scope. It does not create a target-period market-sales series, a Catalog entry, or a DDL specification.

## Official Sources Confirmed

| Source | Official location | Confirmed scope | Use boundary |
| --- | --- | --- | --- |
| IR Materials | [IR Materials](https://www.sanken-ele.co.jp/corp/en/fina/library.htm) | Official entry point linking Financial Reports, Financial Results Presentations, and Sanken Reports. | Archive accessibility only; a listing is not a registered observation. |
| Presentation Slides | [Presentation Slides](https://www.sanken-ele.co.jp/corp/en/tousika/briefing.htm) | Official presentation archive endpoint. | The captured page does not expose a period-indexed document list. Do not infer missing or complete coverage. |
| Management Vision | [Management Vision](https://www.sanken-ele.co.jp/corp/en/about_sanken/vision/index.html) | Audit-only strategy context. | Target/strategy only; publication date is not captured; do not use as registered evidence. |
| Automotive Solutions | [Solutions for Automotives](https://www.semicon.sanken-ele.co.jp/en/sp/automotive.html) | Audit-only product context. | Product context only; publication date is not captured; do not use as registered evidence. |
| FY2021 data book | [FY2021 Business Performance Data](https://www.sanken-ele.co.jp/corp/tousika/pdf/frb_2103c_j-04.pdf) | Official historical source dated 2021-05-11; its FY2018-FY2020 consolidated market-sales observation is registered as `EVR-025`. | Historical context only; not a FY2021-present series, Catalog input, or downstream input. |
| FY2022 Q2 presentation | [FY2022 Q2 Financial Results Presentation](https://www.sanken-ele.co.jp/corp/tousika/pdf/frb_2203c_2q_j.pdf) | Official source dated 2021-11-08; source-defined FY2021 1Q / 2Q Device consolidated sales classified by market are registered as `EVR-026` / `PIT-017`. | Partial target-period evidence only; no full-year or continuous series, Catalog input, or downstream input. |

## FY2021 Q1/Q2 Evidence Update

> **Current Draft correction:** The official FY2022 Q2 Financial Results Presentation, dated 2021-11-08, is now source-audited as `EVR-026` / `PIT-017`. It reports the source-defined Automotive series within quarterly Device consolidated sales classified by market: FY2021 1Q JPY21.4bn and FY2021 2Q JPY20.9bn. This is partial target-period evidence only. It does not establish FY2021 full-year or FY2022-present continuity, comparability, Catalog eligibility, DDL eligibility, or downstream use. Statements below saying no FY2021-present observation was acquired are superseded only to the extent of these two observations.

## Findings

### Facts

- Sanken provides official IR Material and Financial Results Presentation entry points.
- A FY2018-FY2020 historical consolidated market-sales observation from the FY2021 data book is registered as `EVR-025` and routed through `PIT-016`.
- Two FY2021 quarterly source-defined Device consolidated-sales observations (1Q / 2Q) are registered as `EVR-026` / `PIT-017`. No FY2021 full-year or FY2022-present continuous Sanken series is acquired in this Draft package.

### Inference

Sanken is an evidence-relevant issuer for automotive power-semiconductor research. The captured official materials support partial FY2021 quantitative observation, but not a FY2021 full-year or FY2022-present continuous automotive measure.

## Source Acquisition State

| Requirement | State | Reason / next action |
| --- | --- | --- |
| Official archive access | Confirmed | Identify official FY2021 full-year and FY2022-onward result presentations. |
| Audit-only product / strategy context | Captured, unregistered | Do not convert product or management context into realised sales, volume, or demand. |
| Historical FY2018-FY2020 market-sales observation | Registered as `EVR-025` / `PIT-016` | Historical context only; no comparability class assigned. |
| FY2021-present Automotive series | Partial: FY2021 1Q / 2Q registered as `EVR-026` / `PIT-017` | Identify FY2021 full-year and later source documents, then audit table labels, units, definitions, and publication events. |
| Catalog / DDL eligibility | No | Two quarterly observations do not establish a complete series, and `AvailableAt = TBD — no use` remains in effect. |

## Explicit Non-Claims

- This audit does not claim that the official archive is complete or incomplete.
- This audit does not treat the FY2018-FY2020 historical source fact as a FY2021-present series, Catalog input, or downstream input.
- This audit does not treat Sanken's automotive strategy target as an actual ratio.
- This audit does not classify audit-only product context as automotive revenue or industry demand.

## Required Independent Review

1. Confirm that each listed source is official and that its stated boundary is accurate.
2. Confirm that the historical observation remains outside the Sprint001 target period and uses the corrected EVR-025 / PIT-016 route.
3. Confirm that strategy, product, and realised-sales concepts remain separated.
