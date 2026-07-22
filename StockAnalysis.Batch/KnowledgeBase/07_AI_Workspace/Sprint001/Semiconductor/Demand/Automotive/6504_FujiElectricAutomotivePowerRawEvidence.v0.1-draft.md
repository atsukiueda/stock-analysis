# Fuji Electric Automotive Semiconductor — Raw Evidence

## Document Information

| Item | Value |
| --- | --- |
| Document type | Draft raw-evidence record |
| Scope | Fuji Electric source-defined automotive-semiconductor sales, order commentary, and separate Semiconductor-segment context. `Power` is product context only unless the cited source explicitly defines it. |
| Version | 0.1-draft |
| Status | Evidence Collection; not independently reviewed |
| Covered observation periods | FY2021–FY2025, subject to the evidence-level limits below |
| Last updated | 2026-07-21 |

> **Authority boundary:** This is a noncanonical research working paper. It records issuer disclosures and comparability limits; it makes no investment conclusion, Catalog entry, DDL specification, or common industry taxonomy decision.

## Evidence Classification

| Label | Meaning in this paper |
| --- | --- |
| Fact | Exact value or statement attributable to an identified Fuji Electric source. |
| Inference | A constrained interpretation that does not extend the issuer’s disclosure beyond its stated scope. |
| Unresolved | A required identity, definition, or comparability attribute is not yet confirmed. It is not usable as a governed fact. |

## Period-by-Period Raw Evidence

| Observation ID | Fiscal period | Observation | Source-defined value or wording | Evidence ID / locator | Comparability disposition |
| --- | --- | --- | --- | --- | --- |
| FJ-AUTO-001 | FY2021 | Semiconductor-segment sales by application: Automotive | **JPY73.1bn**. | EVR-017; FY2022 results, printed p. 8 / PDF p. 7, `Business Results by Segment FY2022 (YoY)②` | **Pending classification.** Direct source-defined sales observation, but FY2021 comparative figures reflect FY2022 organizational restructuring. |
| FJ-AUTO-002 | FY2022 | Semiconductor-segment sales by application: Automotive | **JPY100.2bn**; automotive-semiconductor orders **+33% YoY** and sales **+37% YoY**. | EVR-017; FY2022 results, printed pp. 8 and 11 / PDF pp. 7 and 10 | **Pending classification.** The issuer’s restructuring note prevents a silent pre-/post-reorganization comparison. |
| FJ-AUTO-003 | FY2023 | Semiconductor-segment sales by application: Automotive | **JPY125.6bn**. | EVR-018; FY2023 results, printed p. 9 / PDF p. 8 | **Pending classification.** Consecutive source-defined sales observation; definition continuity with FY2021–FY2022 must be reviewed. |
| FJ-AUTO-004 | FY2023 | Automotive-semiconductor order change | Automotive-semiconductor orders were **+24%** year on year. The source also reports an order-fulfilment delay in Q4 due to component procurement. | EVR-018; FY2023 results, printed p. 11 / PDF p. 10 | **Context only.** It is an order-flow statement, not a sales or production-volume observation. |
| FJ-AUTO-005 | FY2024 | Semiconductor-segment sales by application: Automotive | **JPY132.6bn**. The FY2024 results commentary says automotive-semiconductor net sales increased on domestic demand, while overseas xEV power demand was weak. | EVR-015; FY2024 results, printed p. 10 / PDF p. 9 | **Pending classification.** Consecutive source-defined sales observation; not group-wide automotive revenue or a volume metric. |
| FJ-AUTO-006 | FY2025 | Semiconductor-segment sales by application: Automotive | **JPY117.7bn**. The source attributes the decline to reduced demand for power semiconductors for electrified vehicles and the prior-year selling-price revision effect. | EVR-016; FY2025 results, printed p. 10 / PDF p. 9 | **Pending classification.** Do not interpret as volume-only demand because the issuer identifies a price effect. |
| FJ-SEG-001 | FY2023 | Semiconductors segment net sales / operating profit | Net sales **JPY228.0bn**; operating profit **JPY36.2bn**. | EVR-015; FY2024 results, p. 10 | **Segment only.** It includes industrial as well as automotive applications. |
| FJ-SEG-002 | FY2024 | Semiconductors segment net sales / operating profit | Net sales **JPY236.8bn**; operating profit **JPY37.1bn**. | EVR-015; FY2024 results, p. 10 | **Segment only.** Not automotive profit or revenue. |
| FJ-SEG-003 | FY2025 | Semiconductors segment net sales / operating profit | Net sales **JPY237.4bn**; operating profit **JPY23.5bn**. | EVR-016; FY2025 results, p. 10 | **Segment only.** Not automotive profit or revenue. |

## Point-in-Time and Definition Controls

| Attribute | Current treatment |
| --- | --- |
| Fiscal-year end | Fuji Electric fiscal years in these results are treated as years ended 31 March; each use must retain the specific issuer document and applicable period. |
| Disclosed-at / available-at | Official document dates are recorded in the Evidence Register and PIT inventory. `AvailableAt` remains `TBD — no use` because no approved operating convention has yet defined the permitted timestamp derivation. |
| Currency / unit | JPY billions where the referenced business-results tables state that unit; preserve the source unit at ingestion. |
| Observation scope | `Automotive` rows are source-defined observations within the Semiconductor business-results table. They are not automatically equivalent to group-wide automotive revenue, units, or semiconductor demand volume. |
| Segment boundary | Semiconductor-segment sales/profit include industrial applications and must remain segregated from automotive observations. |
| Price / volume | FY2025 automotive commentary identifies both demand and a prior-year selling-price revision effect. No volume inference is permitted from the revenue change alone. |
| Organization changes | FY2022 results state that FY2021 figures reflect organizational restructuring conducted in FY2022. The effect on the automotive observation definition is unresolved pending direct table audit. |

## Candidate Comparable Windows

| Window | Status | Reason |
| --- | --- | --- |
| FY2021–FY2025 automotive sales observations | Acquired; not yet comparable | A source-defined sales chain is captured (JPY73.1bn, 100.2bn, 125.6bn, 132.6bn, 117.7bn). FY2021 figures are stated to reflect FY2022 organizational restructuring; definition/version continuity needs independent disposition. |
| FY2023–FY2025 automotive sales observations | Pending classification | Consecutive source-defined application-sales rows are captured. They remain noncanonical until the independent review records a definition and comparability disposition. |
| FY2023–FY2025 Semiconductor segment results | Candidate only | Consecutive values are available, but they are not automotive-only and cannot answer automotive-demand questions without a separately governed use case. |
| FY2022–FY2023 automotive orders | Not established | Both are YoY percentage statements; the baseline values, definitions, and continuous historical series have not been acquired. |

## Explicit Non-Claims

- **Fact boundary:** The issuer statements do not establish an industry-wide automotive semiconductor demand series.
- **Fact boundary:** They do not establish vehicle-production-to-Fuji revenue lead or lag.
- **Fact boundary:** They do not establish inventory, capacity utilization, or channel inventory for automotive power semiconductors.
- **Inference boundary:** The FY2025 revenue decline must not be attributed solely to lower xEV demand because the issuer also cites a price-revision effect.

## Required Independent Review Tests

1. Confirm whether the FY2022 restructuring note changes the application-sales definition or only restates the FY2021 comparative presentation.
2. Record the comparability disposition for every adjacent pair in the FY2021–FY2025 source-defined sales chain.
3. Establish `available_at` under an approved operating convention before any point-in-time use.
4. Confirm that the captured values remain source-defined Semiconductor-segment sales by application, not group-wide automotive revenue, orders, or a volume metric.
5. Confirm that no future Catalog candidate duplicates the broader Fuji Semiconductor-segment observation.

## Official Sources

- [Fuji Electric FY2022 financial results](https://www.fujielectric.com/ir/box/doc/pdf/gh2023_04/230427_01.pdf)
- [Fuji Electric FY2023 consolidated financial results](https://www.fujielectric.com/common-resource-gl/ir/data/20240425_1.pdf)
- [Fuji Electric FY2024 consolidated financial results](https://www.fujielectric.com/common-resource-gl/ir/data/20250425_1.pdf)
- [Fuji Electric FY2025 consolidated financial results](https://www.fujielectric.com/common-resource-gl/ir/data/20260428_1a.pdf)
