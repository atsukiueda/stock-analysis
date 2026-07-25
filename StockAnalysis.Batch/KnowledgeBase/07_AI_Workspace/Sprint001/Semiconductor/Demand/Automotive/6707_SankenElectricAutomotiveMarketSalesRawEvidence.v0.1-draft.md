# Sanken Electric Automotive Market Sales — Raw Evidence

## Document Information

| Item | Value |
| --- | --- |
| Document type | Draft raw-evidence record |
| Company | Sanken Electric Co., Ltd. (6707) |
| Observation | Consolidated market-sales trend; source label: <span lang="ja">&#33258;&#21205;&#36554;(&#35336;)</span> |
| Version | 0.1-draft |
| Status | Evidence Collection; FY2021-FY2024 update pending independent re-review |
| Accessed | 2026-07-25 |

> **Authority boundary:** The source labels these observations as consolidated market sales. `SANKEN-AUTO-2021-CONSOLIDATED` through `SANKEN-AUTO-2024-CONSOLIDATED` are target-period observations only; they do not establish a continuous or comparable Sprint001 series. The FY2024 source states that Allegro MicroSystems, Inc. and Polar Semiconductor, LLC were excluded from consolidation. These observations are not semiconductor-device-only revenue, automotive product revenue, a Catalog entry, or a DDL specification.

## Primary Evidence

| Record ID | Evidence / PIT ID | Applicable period | Source-defined observation | Source / pinpoint locator | Source event and PIT | Scope / use boundary |
| --- | --- | --- | --- | --- | --- | --- |
| SANKEN-AUTO-2018 | `EVR-025` / `PIT-016` | FY2018, as labeled by the source | Source row <span lang="ja">&#33258;&#21205;&#36554;(&#35336;)</span> (English working translation: Automotive total): **JPY76,442m** | [FY2021 Business Performance Data](https://www.sanken-ele.co.jp/corp/tousika/pdf/frb_2103c_j-04.pdf), source table <span lang="ja">3．&#24066;&#22580;&#21029; &#22770;&#19978;&#25512;&#31227;(&#36899;&#32080;)</span>, printed p. 4 / PDF index p. 3 | Dated 2021-05-11 (date-only; release time not captured). `AvailableAt = TBD — no use`. | Consolidated market-sales classification. Outside Sprint001 FY2021–present target period. |
| SANKEN-AUTO-2019 | `EVR-025` / `PIT-016` | FY2019, as labeled by the source | Source row <span lang="ja">&#33258;&#21205;&#36554;(&#35336;)</span> (English working translation: Automotive total): **JPY70,233m** | Same source and table, printed p. 4 / PDF index p. 3 | Dated 2021-05-11 (date-only; release time not captured). `AvailableAt = TBD — no use`. | Consolidated market-sales classification. Outside Sprint001 FY2021–present target period. |
| SANKEN-AUTO-2020 | `EVR-025` / `PIT-016` | FY2020, as labeled by the source | Source row <span lang="ja">&#33258;&#21205;&#36554;(&#35336;)</span> (English working translation: Automotive total): **JPY64,045m** | Same source and table, printed p. 4 / PDF index p. 3 | Dated 2021-05-11 (date-only; release time not captured). `AvailableAt = TBD — no use`. | Consolidated market-sales classification. Outside Sprint001 FY2021–present target period. |

| SANKEN-AUTO-2021-CONSOLIDATED | `EVR-031` / `PIT-022` | FY2021 | Source table `Market sales`, row `Automotive`: **JPY87,899m** | [FY2022 Consolidated Financial Results](https://www2.jpx.co.jp/disc/67070/140120220511539463.pdf), printed p. 2 / PDF index p. 3 | Dated 2022-05-12 (date-only; release time not captured). `AvailableAt = TBD — no use`. | Consolidated market-sales classification. Distinct from the FY2021 Device consolidated-sales table; no mapping or continuity is asserted. |
| SANKEN-AUTO-2022-CONSOLIDATED | `EVR-032` / `PIT-023` | FY2022 | Source table `Market sales`, row `Automotive`: **JPY116,986m** | [FY2023 Consolidated Financial Results](https://www2.jpx.co.jp/disc/67070/140120230510563843.pdf), printed p. 2 / PDF index p. 3 | Dated 2023-05-11 (date-only; release time not captured). `AvailableAt = TBD — no use`. | Consolidated market-sales classification. Distinct from the FY2022 Device consolidated-sales table; no mapping or continuity is asserted. |
| SANKEN-AUTO-2023-CONSOLIDATED | `EVR-033` / `PIT-024` | FY2023 | Source table `Market sales`, row `Automotive`: **JPY141,536m** | [FY2024 Consolidated Financial Results](https://www2.jpx.co.jp/disc/67070/140120240510588073.pdf), printed p. 2 / PDF index p. 3 | Dated 2024-05-10 (date-only; release time not captured). `AvailableAt = TBD — no use`. | Consolidated market-sales classification. Distinct from the FY2023 Device consolidated-sales table; no mapping or continuity is asserted. |
| SANKEN-AUTO-2024-CONSOLIDATED | `EVR-034` / `PIT-025` | FY2024 | Source table `Market sales`, row `Automotive`: **JPY55,562m** | [FY2025 Consolidated Financial Results](https://www2.jpx.co.jp/disc/67070/140120250512543006.pdf), printed p. 2 / PDF index p. 3 | Dated 2025-05-14 (date-only; release time not captured). `AvailableAt = TBD — no use`. | Consolidated market-sales classification. The source states Allegro MicroSystems, Inc. and Polar Semiconductor, LLC were excluded from consolidation; no continuity or comparability is asserted. |

| SANKEN-AUTO-2024-CONSOLIDATED-RECLASSIFIED | `EVR-035` / `PIT-026` | FY2024 comparative, reclassified in a later disclosure | Source table `Market sales`, row `Automotive`: **JPY31,668m**. Accompanying note: original FY2024 Automotive JPY55,562m included Allegro products JPY20,821m and switching-power-products (former unit-products business) JPY3,072m; the FY2026 source reclassified those amounts to `Others`. | [FY2026 Consolidated Financial Results](https://www2.jpx.co.jp/disc/67070/140120260513527660.pdf), printed p. 3 / PDF index p. 4 | Dated 2026-05-13 (date-only; release time not captured). `AvailableAt = TBD — no use`. | **Fact:** source-presented reclassified comparative consolidated market-sales observation; `RestatementFlag: Yes`. **Non-claim:** it neither replaces `SANKEN-AUTO-2024-CONSOLIDATED` nor establishes an identity, continuity, or comparability with Device consolidated sales or Sanken Core sales. |

## Scope and Definition Controls

| Topic | Controlled treatment |
| --- | --- |
| Source-specific labels and tables | FY2018-FY2020 only: source label <span lang="ja">&#33258;&#21205;&#36554;(&#35336;)</span> and data-book table <span lang="ja">&#24066;&#22580;&#21029; &#22770;&#19978;&#25512;&#31227;(&#36899;&#32080;)</span>; `Automotive total` is an English working translation only. FY2021-FY2024, including the reclassified comparative: `Market sales`, row `Automotive`. The latter is not asserted identical to the FY2018-FY2020 label/table. |
| Measure | Consolidated market-sales observations, each limited to its named source table and row. |
| Product boundary | The source does not state that this line is semiconductor-device-only, power-device-only, SiC-only, or automotive-product-only revenue. |
| Time boundary | The source's FY2018–FY2020 labels precede Sprint001's FY2021–present target period. They provide historical context only. |
| Comparability | No class is assigned. `EVR-031` through `EVR-035` / `PIT-022` through `PIT-026`, including the later FY2024 reclassified comparative observation, do not establish a joined, continuous, or comparable series with the Device consolidated-sales or Sanken Core market-sales records. `EVR-035` / `PIT-026` does not replace `EVR-034` / `PIT-025`. |
| Point in time | `AvailableAt = TBD — no use`; no downstream use is permitted. |

> **Reclassified comparative boundary:** `EVR-035` / `PIT-026` is a later source-presented reclassified FY2024 comparative observation. It does not replace `EVR-034` / `PIT-025` and does not establish comparability with Device consolidated-sales or Sanken Core market-sales records.

## Facts

- The official data book is dated 2021-05-11 and contains the consolidated market-sales table identified above.
- The source row <span lang="ja">&#33258;&#21205;&#36554;(&#35336;)</span> reports JPY76,442m, JPY70,233m, and JPY64,045m for its source-labeled FY2018, FY2019, and FY2020 columns.

- The FY2026 disclosure presents FY2024 Automotive JPY31,668m as a reclassified comparative value and states that Allegro products JPY20,821m and switching-power-products (former unit-products business) JPY3,072m were reclassified to `Others`.

## Derived Check / Reviewer Observation

> This section is a reviewer-derived arithmetic check, not an issuer source fact. It makes no reconciliation, rounding assumption, or residual allocation.
- **Reviewer-raised arithmetic boundary:** the displayed component figures do not arithmetically reproduce the displayed Automotive comparative value exactly (`55,562 − 20,821 − 3,072 = 31,669`, versus source-presented JPY31,668m). The source-presented JPY31,668m remains the recorded fact; no independent reconciliation, rounding assumption, or residual allocation is made.

## Explicit Non-Claims

- No joined FY2021–present Sanken Automotive series is asserted.
- No automotive semiconductor-device, power-device, SiC, order, shipment, OEM-production, or industry-demand series is inferred.
- No Catalog, DDL, ML, backtest, or investment use is authorized.

## FY2021-FY2024 and Reclassified-Comparative Review Scope

1. Confirm the FY2021-FY2024 `Market sales` / `Automotive` observations are controlled separately from the FY2018-FY2020 data-book table.
2. Confirm the reclassified FY2024 comparative is retained as a separate source observation and does not replace the original FY2024 observation.
3. Confirm the FY2026 displayed JPY31,668m is treated as a source fact and the component arithmetic is retained only as a reviewer check without reconciliation.

## Required Independent Review

1. Confirm the source row, unit, and FY2018–FY2020 mapping.
2. Confirm the interpretation remains consolidated market sales rather than a semiconductor-only measure.
3. Confirm the FY2018–FY2020 historical boundary, the separate FY2021 consolidated-market-sales record, and `AvailableAt = TBD — no use` restriction are retained.
