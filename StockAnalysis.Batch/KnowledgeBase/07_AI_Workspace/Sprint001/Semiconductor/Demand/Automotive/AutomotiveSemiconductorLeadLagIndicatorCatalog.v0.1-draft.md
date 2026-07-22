# Sprint001 — Automotive Semiconductor Lead/Lag Indicator Catalog

## Document Information

| Item | Value |
| --- | --- |
| Research Domain | Semiconductor / Demand / Automotive |
| Sprint | Sprint001 |
| Document Type | Indicator Catalog Research Draft |
| Version | 0.1-draft |
| Status | Candidate Definition |
| Reviewer Status | Pending Independent Review |
| Author | Documentation & Knowledge Base Team |
| Last Updated | 2026-07-19 |

> **Draft boundary:** “Leading,” “Coincident,” and “Lagging” in this document are candidate classifications only. They are not validated predictive relationships and must not be used as model features, decision rules, or cataloged knowledge before independent review and point-in-time validation.

> **Evidence reference:** Source-supported facts are registered in `Sprint001AutomotiveEvidenceRegister.v0.1-draft.md`; all timing labels here remain candidate classifications.

---

## 1. Purpose

Define an auditable candidate catalog for observations relevant to Automotive Semiconductor Demand. The catalog separates:

- end-demand context,
- semiconductor demand realization,
- inventory adjustment,
- capacity risk, and
- commercialization context.

Its purpose is to make later lead/lag validation falsifiable and reproducible, rather than to assert that any indicator predicts revenue or stock returns.

---

## 2. Classification Rules

| Term | Meaning in this draft |
| --- | --- |
| Candidate leading | May become available before a target observation; predictive value is unvalidated. |
| Candidate coincident | Measures a condition near the same economic period as the target; timing remains to be tested. |
| Candidate lagging | May be disclosed after or reflect a previously realized condition; timing remains to be tested. |
| Contextual | Useful for explanation, segmentation, or scenario analysis but not proposed as a direct predictor. |
| Unknown | Timing, definition, or recurrence is insufficient to classify. |

### Non-negotiable constraints

1. Disclosure availability—not the economic reporting period—determines eligibility for a point-in-time test.
2. Correlation does not establish causality.
3. Indicators from different product categories, geographies, and accounting definitions are not interchangeable.
4. Missing data remains missing; it is not neutral, zero, or a peer estimate.
5. A candidate classification may be rejected after validation.

---

## 3. Targets for Validation

| Target ID | Validation target | Boundary |
| --- | --- | --- |
| T-01 | Future automotive segment/end-market revenue | Only when the issuer discloses an automotive definition. |
| T-02 | Future automotive product-category revenue or guidance | Only source-defined product categories. |
| T-03 | Future inventory-adjustment state | Requires revenue, inventory, and commentary context. |
| T-04 | Future company operating performance | Separate revenue, margin, and guidance tests. |

---

## 4. Candidate Indicator Register

| ID | Indicator | Chain stage | Candidate class | Primary use | Evidence availability | Status |
| --- | --- | --- | --- | --- | --- | --- |
| ASL-001 | Global vehicle production | OEM / market | Candidate coincident | End-demand scale context | OICA; EVR-001 | Unvalidated |
| ASL-002 | Regional vehicle production | OEM / market | Candidate coincident | Exposure-adjusted end-demand context | OICA subset; overlaps ASL-001 | Unvalidated |
| ASL-003 | OEM production guidance | OEM / market | Candidate leading | Near-term end-demand context | Medium; issuer dependent | Unvalidated |
| ASL-004 | Global electric-car sales | OEM / market | Contextual | Electrification context | IEA; EVR-002 | Unvalidated |
| ASL-005 | BEV penetration | OEM / market | Contextual | Product-mix context | Region/source-specific | Unvalidated |
| ASL-006 | PHEV penetration | OEM / market | Contextual | Product-mix context | Region/source-specific | Unvalidated |
| ASL-007 | HEV penetration | OEM / market | Contextual | Product-mix context | Region/source-specific | Unvalidated |
| ASL-008 | Tier 1 electrification or mobility-electronics disclosure | Tier 1 systems | Unknown | System-level transmission context | Medium; issuer dependent | Unvalidated |
| ASL-009 | Automotive segment/end-market revenue | Semiconductor supplier | Candidate coincident | Realized supplier demand | EVR-004 / EVR-005 where issuer-defined | Unvalidated |
| ASL-010 | Automotive product-category revenue or guidance | Semiconductor supplier | Candidate coincident | Product-specific demand | Low to Medium | Unvalidated |
| ASL-011 | Order / book-to-bill / customer demand commentary | Semiconductor supplier | Candidate leading | Near-term supplier demand | Low to Medium | Unvalidated |
| ASL-012 | Finished goods | Supplier operating state | Candidate lagging / contextual | Inventory-adjustment explanation | Semantic mapping required | Unvalidated |
| ASL-013 | Work in process | Supplier operating state | Candidate lagging / contextual | Inventory-adjustment explanation | Semantic mapping required | Unvalidated |
| ASL-014 | Raw materials | Supplier operating state | Candidate lagging / contextual | Inventory-adjustment explanation | Semantic mapping required | Unvalidated |
| ASL-015 | Inventory-to-revenue | Supplier operating state | Candidate lagging / contextual | Derived inventory normalization | Formula/version required | Unvalidated |
| ASL-016 | Inventory days | Supplier operating state | Candidate lagging / contextual | Derived inventory normalization | Formula/version required | Unvalidated |
| ASL-017 | Channel inventory | Supplier operating state | Candidate lagging / contextual | Channel adjustment explanation | Low to Medium | Unvalidated |
| ASL-018 | Utilization | Supplier operating state | Unknown | Capacity-state interpretation | Low to Medium | Unvalidated |
| ASL-019 | Underutilization cost | Supplier operating state | Unknown | Capacity-state interpretation | Low to Medium | Unvalidated |
| ASL-020 | Capex | Supplier operating state | Contextual | Capacity-risk interpretation | Medium | Unvalidated |
| ASL-021 | Capacity expansion | Supplier operating state | Contextual | Capacity-risk interpretation | Medium | Unvalidated |
| ASL-022 | Design win | Commercialization | Unknown | Commercialization context | Medium; issuer dependent | Unvalidated |
| ASL-023 | Customer nomination | Commercialization | Unknown | Commercialization context | Medium; issuer dependent | Unvalidated |
| ASL-024 | Mass production start | Commercialization | Unknown | Commercialization context | Medium; issuer dependent | Unvalidated |

### Relationship and anti-double-counting rules

| Observation | Relationship | Rule |
| --- | --- | --- |
| ASL-002 ↔ ASL-001 | `aggregation-of` / `overlaps-with` | A regional observation may contribute to a regional exposure view; it must not be added with the same global total for one scoring purpose. |
| ASL-004 ↔ ASL-005–007 | `overlaps-with` | Penetration uses vehicle-sales denominators and may share numerator data; use one primary metric per stated transformation. |
| ASL-012–014 | `mutually-distinct` | Finished goods, WIP, and raw materials are separate raw observations and require separate semantic evidence. |
| ASL-015 | `derived-from` | Must identify reviewed inventory numerator and revenue denominator, period alignment, and formula version. |
| ASL-016 | `derived-from` | Must identify reviewed cost/revenue basis, period alignment, and formula version. |
| ASL-017 | `non-comparable-by-default` | Channel inventory is not producer inventory. |
| ASL-018–021 | `context-only` | Capacity observations cannot receive fixed demand direction. |

---

## 5. Initial Source Anchors

| Indicator family | Primary source anchor | Source-supported fact | Limitation |
| --- | --- | --- | --- |
| Vehicle production | OICA | Publishes country-level production statistics. | Does not measure semiconductor orders or supplier revenue. |
| EV sales and mix | IEA | Reports global electric-car sales and share. | Does not define supplier- or category-specific semiconductor content. |
| Tier 1 systems | DENSO | Discloses electrification, powertrain, mobility-electronics, and advanced-device businesses. | Does not disclose a generic transmission coefficient to semiconductor suppliers. |
| Product exposure | Renesas | Identifies automotive MCU, SoC, analog, and power products. | Does not make categories directly comparable with every peer. |
| Automotive realized revenue | NXP / Infineon | Disclose automotive end-market or segment revenue. | Fiscal calendars, product mix, and definitions differ. |

### Primary-source links

- [OICA 2024 production statistics](https://oica.net/fr/production-statistics/)
- [IEA — Global EV Outlook 2025](https://www.iea.org/reports/global-ev-outlook-2025)
- [DENSO Integrated Report 2025](https://www.denso.com/global/en/about-us/investors/annual-report/integrated-report-2025/)
- [Renesas Annual Securities Report FY2025](https://www.renesas.com/en/document/rep/annual-securities-report-2025)
- [NXP 2025 annual filing](https://investors.nxp.com/static-files/2299cbbd-40e4-42dd-a9e7-231185a54386)
- [Infineon Annual Report 2025](https://www.infineon.com/row/public/documents/corporate/investors/annual-reports/2025/2025-annual-report-v01-00-en.pdf)

---

## 6. Point-in-Time Record Requirement

Every validated observation must retain the following fields before it can be used beyond research:

| Field | Purpose |
| --- | --- |
| Observation definition and version | Prevent definition drift. |
| Source issuer and source document | Preserve authority and traceability. |
| Applicable period | Identify the economic period described. |
| Published date/time | Identify when the document became public. |
| Effective-as-of date | Identify the first permitted use in a test. |
| Geography, product category, and unit | Preserve comparability boundaries. |
| Raw value / source wording | Preserve original evidence. |
| Review status and confidence | Prevent unreviewed use. |

---

## 7. Validation Design

### Required tests

1. **Availability test:** Verify that the observation was public before the prediction date.
2. **Definition-stability test:** Verify that the issuer’s measure retains a comparable definition across the tested period.
3. **Lag-window test:** Specify candidate lags in the training period only; do not choose lags from full-sample performance.
4. **Regime test:** Test supply shortage, inventory adjustment, and normalization periods separately where data supports it.
5. **Ablation test:** Evaluate each observation’s incremental contribution without treating correlation as causal proof.
6. **Explanation test:** Confirm that an Advisor explanation discloses uncertainty and does not overstate the evidence.

### Candidate disposition

| Disposition | Meaning |
| --- | --- |
| Adopt candidate | Meets evidence, availability, and validation requirements; still requires catalog review. |
| Context only | Useful for explanation but lacks demonstrated predictive contribution. |
| Insufficient evidence | Source, definition, recurrence, or timing is inadequate. |
| Rejected | Fails validation, traceability, or boundary requirements. |

---

## 8. Known Risks

- Automotive demand can vary by region, vehicle type, semiconductor category, and customer program.
- Supplier sales can diverge from vehicle production because of inventory, pricing, content, and channel conditions.
- Annual disclosures may be too infrequent for certain lead/lag applications.
- Company-specific segment taxonomy can change; historical values must not be silently restated or bridged.
- Global EV metrics may obscure hybrid, regional, and price-segment differences.

---

## 9. Independent Review Questions

1. Are all current classifications explicitly marked as candidates rather than approved relationships?
2. Are contextual observations prevented from becoming direct factors by implication?
3. Does the register preserve source-defined product and accounting boundaries?
4. Are the point-in-time fields sufficient to prevent look-ahead bias?
5. Are any observations duplicated across demand, inventory, capacity, and commercialization without a stated primary purpose?

---

## 10. Next Actions

1. Create the Evidence Acquisition Matrix for each representative company and indicator.
2. Reconcile inventory indicators with the historical EDINET/XBRL semantic-mapping assets.
3. Prepare an independent-review package containing this catalog, the Value Chain Draft, and the Industry Report Draft.
