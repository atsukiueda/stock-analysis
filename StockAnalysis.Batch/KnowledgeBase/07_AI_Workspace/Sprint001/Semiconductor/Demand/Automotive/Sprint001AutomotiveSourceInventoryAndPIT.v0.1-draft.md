# Sprint001 — Automotive Source Inventory and Point-in-Time Readiness

## Document Information

| Item | Value |
| --- | --- |
| Document Type | Draft acquisition inventory / point-in-time readiness record |
| Version | 0.1-draft |
| Status | Evidence Collection |
| Reviewer Status | Pending independent re-review |
| Period policy | 2021–present target; no complete comparable series asserted |
| Last Updated | 2026-07-23 |

> **Boundary:** Archive availability is not evidence acquisition, and evidence acquisition is not cross-company comparability. This document records those states separately.

---

## 1. Status Vocabulary

| Status | Meaning |
| --- | --- |
| Archive observed | Official source page lists a relevant historical document or series. No raw observation has been accepted. |
| Source identified | A specific official document is identified with period and publication date. Locator/value may still be pending. |
| Evidence registered | A specific Fact is registered in `Sprint001AutomotiveEvidenceRegister`. |
| Series acquired | Period-by-period observations and identifiers have been captured. |
| Comparable series | Definition, scope, fiscal period, unit/currency, restatement, and availability checks have passed for the stated use. |

No row below has `Series acquired` or `Comparable series` status unless explicitly stated.

---

## 2. Official Archive Inventory

| Inventory ID | Owner | Official source | Coverage observed | Publication evidence | Status | Limitation |
| --- | --- | --- | --- | --- | --- |
| PIT-SI-001 | Renesas | [Earnings Reports archive](https://www.renesas.com/en/about/investor-relations/earning) | FY2021, FY2022, FY2023, FY2024, FY2025 annual and quarterly listings observed | FY2021 annual results announced 2022-02-09; FY2022 annual results announced 2023-02-09; subsequent listings shown in archive | Archive observed; selected FY2025 fact registered as EVR-003 | Source archives include corrections/amendments; period-by-period definition/revision capture remains required. |
| PIT-SI-002 | ROHM | [Financial Statements archive](https://www.rohm.com/ir/library/annual-financial-report), [Trend in Results](https://www.rohm.com/ir/financial/trend-in-results), and FY2022–FY2025 results presentations registered in EVR-019 and EVR-021–EVR-023 | FY2021–FY2026 consolidated trend shown; issuer-defined Automotive market-sales observations acquired for FY2021–FY2025 | Results presentations dated 2023-05-10 through 2026-05-13; overlapping values source-reconciled | Evidence registered / source observations acquired; comparability pending | Consolidated trends are not automotive revenue. The captured market-sales observations are not automotive product revenue and are not yet a validated comparable series. |
| PIT-SI-003 | Fuji Electric | [Financial Results archive](https://www.fujielectric.com/ir/library/detail/financial_results.html) | FY2021–FY2025 financial-results pages observed | FY2021 results announced 2022-04-27; FY2022 2023-04-27; FY2023 2024-04-25; FY2024 2025-04-25; FY2025 2026-04-28 | Evidence registered: EVR-007, EVR-009, EVR-015–EVR-018; FY2021–FY2025 source-defined automotive sales observations acquired | FY2022 disclosure says the FY2021 figures reflect a FY2022 organizational restructuring; comparability requires independent disposition. |
| PIT-SI-004 | Sanken Electric | [Official IR Materials](https://www.sanken-ele.co.jp/corp/en/fina/library.htm), [Presentation Slides](https://www.sanken-ele.co.jp/corp/en/tousika/briefing.htm), FY2021 data-book, and FY2022 Q2 presentation | Historical FY2018–FY2020 observation registered as EVR-025 / PIT-016; source-defined FY2021 1Q / 2Q observations registered as EVR-026 / PIT-017 | FY2021 data book dated 2021-05-11; FY2022 Q2 presentation dated 2021-11-08 | Partial target-period evidence registered | No FY2021 full-year or FY2022–present continuous source evidence is registered; definition continuity is not established. |

---

## Sanken FY2021 Acquisition Update

> **Current Draft correction:** `EVR-026` / `PIT-017` records two source-defined target-period observations: FY2021 1Q and FY2021 2Q. The prior archive-inventory statement that no FY2021-present observation was acquired is superseded to this limited extent. It remains true that no FY2021 full-year or FY2022-present continuous Sanken series has been acquired, and definition continuity is not established.

## 3. Point-in-Time Record Contract

Each candidate observation must be recorded as one row before it can be evaluated for Catalog candidacy.

| Field | Required rule |
| --- | --- |
| `ObservationId` | One raw observation or one explicitly defined derived metric only. |
| `EvidenceId` | Must resolve to the Evidence Register. |
| `IssuerOrOwner` | Required. |
| `ApplicablePeriodStart` / `ApplicablePeriodEnd` | Required for reported economic period. |
| `FiscalPeriod` | Required when issuer reporting is used. |
| `DisclosedAt` | Exact public release date/time when available; date-only is explicitly marked. |
| `AvailableAt` | `TBD — no use` until the applicable operating convention defines it. It must not be inferred from period end. |
| `ScopeOrSegmentVersion` | Required; segment/product-definition change is a new version. |
| `UnitCurrency` | Required for quantitative values. |
| `RestatementFlag` | Required: `No`, `Yes`, or `Unknown`. |
| `ComparabilityClass` | `Direct`, `Proxy`, or `Non-comparable`, with reason. |
| `CatalogEligibility` | `No` until all required fields and independent review are complete. |

---

## 4. Initial Point-in-Time Readiness Rows

| Record ID | Observation | Evidence ID | Applicable period | DisclosedAt | AvailableAt | Scope/version | Comparability | Catalog eligibility |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| PIT-001 | Renesas Automotive Business product exposure | EVR-003 | FY2025 | 2026-05-15 | TBD — no use | Annual Securities Report 2025; Automotive Business definition | Proxy — descriptive exposure only | No |
| PIT-002 | Infineon Automotive segment revenue | EVR-004 | FY2025 | Report publication date pending exact capture | TBD — no use | FY2025 Automotive segment; IFRS | Direct within issuer only | No |
| PIT-003 | NXP Automotive end-market revenue | EVR-005 | FY ended 2025-12-31 | 2026-02-19 | TBD — no use | 2025 end-market revenue; USD | Direct within issuer only | No |
| PIT-004 | Fuji automotive-semiconductor commentary | EVR-007 | FY ended 2026-03-31 | 2026-04-28 | TBD — no use | Issuer commentary; automotive semiconductors | Proxy / narrative context | No |
| PIT-005 | Fuji Semiconductors segment net sales and operating profit | EVR-009 | FY ended 2026-03-31 | 2026-04-28 | TBD — no use | Semiconductors segment; JPY | Direct within issuer; non-comparable to automotive revenue | No |
| PIT-006 | Fuji Semiconductor-segment sales by application: Automotive | EVR-017 | FY2021 / FY2022 | 2023-04-27 | TBD — no approved convention; no use | Semiconductor application sales; Automotive; JPYbn; FY2021 comparative reflects FY2022 reorganization | Pending classification; definition-controlled | No |
| PIT-007 | Fuji Semiconductor-segment sales by application: Automotive | EVR-018 | FY2022 / FY2023 | 2024-04-25 | TBD — no approved convention; no use | Semiconductor application sales; Automotive; JPYbn | Pending classification; definition continuity review required | No |
| PIT-008 | Fuji Semiconductor-segment sales by application: Automotive | EVR-015 | FY2023 / FY2024 | 2025-04-25 | TBD — no approved convention; no use | Semiconductor application sales; Automotive; JPYbn | Pending classification; definition continuity review required | No |
| PIT-009 | Fuji Semiconductor-segment sales by application: Automotive | EVR-016 | FY2024 / FY2025 | 2026-04-28 | TBD — no approved convention; no use | Semiconductor application sales; Automotive; JPYbn | Pending classification; price effect prevents volume interpretation | No |

---

## 5. 2021–Present Acquisition Gap

| Requirement | Current state | Required next action |
| --- | --- | --- |
| Renesas series | Archive observed from FY2021 | Capture each document’s period, publication event, definition version, and selected observation values. |
| ROHM series | FY2021–FY2025 issuer-defined Automotive market-sales observations registered and overlap-reconciled | Independently dispose definition continuity; do not use consolidated trend as automotive proxy or treat the observations as a validated series. |
| Fuji series | FY2021–FY2025 source-defined automotive sales observations acquired | Review segment/application definition and FY2022 reorganization effect before assigning comparability class. |
| Sanken series | Historical FY2018–FY2020 observation registered; FY2021 1Q / 2Q source-defined observations registered; no complete target-period series | Acquire and audit official FY2021 full-year and later tables; independently dispose definition continuity before any joined series or comparison is considered. |
| Cross-company series | Not started | Compare only after issuer-level series are complete and scope alignment is evidenced. |

| PIT-010 | ROHM market-segment sales: Automotive | EVR-019 | FY2024 / FY2025 | 2026-05-13 (date-only) | TBD — no approved convention; no use | ROHM market classification; Automotive; JPYbn; `RestatementFlag: Unknown` | No class assigned; review status Pending classification; formal definition continuity not established | No |
| PIT-011 | ROHM sales composition: Automotive | EVR-020 | FY2025 | 2026-05-13 (date-only) | TBD — no approved convention; no use | ROHM sales composition; Automotive; JPYbn / percent; `RestatementFlag: Unknown` | No class assigned; review status Pending classification; composition context only | No |
| PIT-012 | ROHM market-segment sales: Automotive | EVR-021 | FY2022 / FY2023 | 2024-05-09 (date-only) | TBD — no approved convention; no use | ROHM market classification; Automotive; JPYbn; `RestatementFlag: Unknown` | No class assigned; review status Pending classification; formal definition continuity not established | No |
| PIT-013 | ROHM market-segment sales: Automotive | EVR-022 | FY2021 / FY2022 | 2023-05-10 (date-only) | TBD — no approved convention; no use | ROHM market classification; Automotive; JPYbn; `RestatementFlag: Unknown` | No class assigned; review status Pending classification; source says calculated by most recent segment | No |
| PIT-014 | ROHM market-segment sales: Automotive | EVR-023 | FY2023 / FY2024 | 2025-05-14 (date-only) | TBD — no approved convention; no use | ROHM market classification; Automotive; JPYbn; `RestatementFlag: Unknown` | No class assigned; review status Pending classification; formal definition continuity not established | No |
| PIT-015 | Sanken consolidated market sales: `自動車(計)` | EVR-024 | FY2018 / FY2019 / FY2020 | 2021-05-11 (date-only) | TBD — no approved convention; no use | Consolidated market-sales trend; JPYm; `RestatementFlag: Unknown` | No class assigned; outside Sprint001 FY2021–present target period; no continuity evidence | No |
| PIT-016 | Sanken consolidated market sales: source row `&#33258;&#21205;&#36554;(&#35336;)` | EVR-025 | FY2018 / FY2019 / FY2020 | 2021-05-11 (date-only) | TBD — no approved convention; no use | Consolidated market-sales trend; JPYm; `RestatementFlag: Unknown` | No class assigned; outside Sprint001 FY2021–present target period; no continuity evidence | No |

| PIT-017 | Sanken quarterly Device consolidated sales by market: source series <span lang="ja">&#33258;&#21205;&#36554;</span> | EVR-026 | FY2021 1Q / FY2021 2Q | 2021-11-08 (date-only) | TBD — no approved convention; no use | Device consolidated sales classified by market; JPY hundred millions; `RestatementFlag: Unknown` | No class assigned; actual values only; no continuity with PIT-016 or later series established | No |

## Sanken PIT Correction Overlay

| Record ID | Effective status | Current route |
| --- | --- | --- |
| PIT-015 | Superseded correction trace — do not use. It references encoding-corrupt `EVR-024`. | None. |
| PIT-016 | Current Draft PIT route for the historical source fact. | `EVR-025` and `SANKEN-AUTO-2018/2019/2020`. |

## 6. Review Disposition

This source inventory resolves the distinction between archive availability, identified sources, registered evidence, acquired series, and comparable series. It does **not** resolve the 2021–present acquisition gap. No row is eligible for Catalog, DDL, ML, or investment use.
