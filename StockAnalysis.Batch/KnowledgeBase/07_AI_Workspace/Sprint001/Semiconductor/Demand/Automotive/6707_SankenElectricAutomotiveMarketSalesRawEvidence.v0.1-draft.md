# Sanken Electric Automotive Market Sales — Raw Evidence

## Document Information

| Item | Value |
| --- | --- |
| Document type | Draft raw-evidence record |
| Company | Sanken Electric Co., Ltd. (6707) |
| Observation | Consolidated market-sales trend; source label: <span lang="ja">&#33258;&#21205;&#36554;(&#35336;)</span> |
| Version | 0.1-draft |
| Status | Evidence Collection; revised after independent review |
| Accessed | 2026-07-23 |

> **Authority boundary:** The source labels this observation as consolidated market sales. It is not semiconductor-device-only revenue, automotive product revenue, a current Sprint001-period series, a Catalog entry, or a DDL specification.

## Primary Evidence

| Record ID | Evidence / PIT ID | Applicable period | Source-defined observation | Source / pinpoint locator | Source event and PIT | Scope / use boundary |
| --- | --- | --- | --- | --- | --- | --- |
| SANKEN-AUTO-2018 | `EVR-025` / `PIT-016` | FY2018, as labeled by the source | Source row <span lang="ja">&#33258;&#21205;&#36554;(&#35336;)</span> (English working translation: Automotive total): **JPY76,442m** | [FY2021 Business Performance Data](https://www.sanken-ele.co.jp/corp/tousika/pdf/frb_2103c_j-04.pdf), source table <span lang="ja">3．&#24066;&#22580;&#21029; &#22770;&#19978;&#25512;&#31227;(&#36899;&#32080;)</span>, printed p. 4 / PDF index p. 3 | Dated 2021-05-11 (date-only; release time not captured). `AvailableAt = TBD — no use`. | Consolidated market-sales classification. Outside Sprint001 FY2021–present target period. |
| SANKEN-AUTO-2019 | `EVR-025` / `PIT-016` | FY2019, as labeled by the source | Source row <span lang="ja">&#33258;&#21205;&#36554;(&#35336;)</span> (English working translation: Automotive total): **JPY70,233m** | Same source and table, printed p. 4 / PDF index p. 3 | Dated 2021-05-11 (date-only; release time not captured). `AvailableAt = TBD — no use`. | Consolidated market-sales classification. Outside Sprint001 FY2021–present target period. |
| SANKEN-AUTO-2020 | `EVR-025` / `PIT-016` | FY2020, as labeled by the source | Source row <span lang="ja">&#33258;&#21205;&#36554;(&#35336;)</span> (English working translation: Automotive total): **JPY64,045m** | Same source and table, printed p. 4 / PDF index p. 3 | Dated 2021-05-11 (date-only; release time not captured). `AvailableAt = TBD — no use`. | Consolidated market-sales classification. Outside Sprint001 FY2021–present target period. |

## Scope and Definition Controls

| Topic | Controlled treatment |
| --- | --- |
| Source label | <span lang="ja">&#33258;&#21205;&#36554;(&#35336;)</span> is the source label; `Automotive total` is an English working translation only. |
| Table title | <span lang="ja">&#24066;&#22580;&#21029; &#22770;&#19978;&#25512;&#31227;(&#36899;&#32080;)</span> is the source table title. |
| Measure | Consolidated market-sales trend, as stated in the source title. |
| Product boundary | The source does not state that this line is semiconductor-device-only, power-device-only, SiC-only, or automotive-product-only revenue. |
| Time boundary | The source's FY2018–FY2020 labels precede Sprint001's FY2021–present target period. They provide historical context only. |
| Comparability | No class is assigned. This one source does not establish continuity into FY2021 or later. |
| Point in time | `AvailableAt = TBD — no use`; no downstream use is permitted. |

## Facts

- The official data book is dated 2021-05-11 and contains the consolidated market-sales table identified above.
- The source row <span lang="ja">&#33258;&#21205;&#36554;(&#35336;)</span> reports JPY76,442m, JPY70,233m, and JPY64,045m for its source-labeled FY2018, FY2019, and FY2020 columns.

## Explicit Non-Claims

- No FY2021–present Sanken Automotive series is asserted.
- No automotive semiconductor-device, power-device, SiC, order, shipment, OEM-production, or industry-demand series is inferred.
- No Catalog, DDL, ML, backtest, or investment use is authorized.

## Required Independent Review

1. Confirm the source row, unit, and FY2018–FY2020 mapping.
2. Confirm the interpretation remains consolidated market sales rather than a semiconductor-only measure.
3. Confirm the pre-FY2021 time boundary and `AvailableAt = TBD — no use` restriction are retained.
