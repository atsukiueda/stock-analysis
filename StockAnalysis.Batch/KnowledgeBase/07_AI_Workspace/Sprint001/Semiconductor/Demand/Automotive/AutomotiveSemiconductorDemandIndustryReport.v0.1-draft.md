# Sprint001 — Automotive Semiconductor Demand Industry Report

## Document Information

| Item | Value |
| --- | --- |
| Research Domain | Semiconductor / Demand / Automotive |
| Sprint | Sprint001 |
| Document Type | Industry Research Draft |
| Version | 0.1-draft |
| Status | Evidence Collection |
| Reviewer Status | Pending Independent Review |
| Evidence Period | 2021–present; latest disclosure is preferred |
| Author | Documentation & Knowledge Base Team |
| Last Updated | 2026-07-19 |

> **Draft boundary:** This is a Research Asset, not canonical research or a Knowledge Catalog entry. No statement in this document may be used for DDL, entity design, model weighting, or investment decisioning before independent review and approved promotion.

> **Evidence reference:** Material facts are governed within this Draft package by `Sprint001AutomotiveEvidenceRegister.v0.1-draft.md`. This report does not establish a separate factual authority.

---

## 1. Purpose and Scope

### Purpose

Establish an evidence-based industry baseline for **Automotive Semiconductor Demand**. The goal is to determine which observations can explain or anticipate changes in demand for automotive semiconductors, and which observations remain only contextual or hypothetical.

### Included scope

```text
Semiconductor
└── Demand
    └── Automotive
```

The study covers the transmission path from OEM production and powertrain mix through Tier 1 suppliers to semiconductor suppliers. It prioritizes demand structure, lead/lag, inventory cycles, and observable evidence suitable for later cataloging.

### Excluded scope

- Semiconductor manufacturing equipment, materials, and packaging as separate Sprint001 sub-sectors.
- Algorithm selection, factor weights, thresholds, backtests, and investment-strategy rules.
- A claim that a reported correlation proves causality.
- Allocation of unsegmented company revenue to automotive business by estimation.

---

## 2. Research Questions

| ID | Question | Required outcome |
| --- | --- | --- |
| RQ-01 | What is the automotive semiconductor demand chain? | Evidence-backed value-chain map and boundaries. |
| RQ-02 | Which product groups are materially exposed? | Separate Power, MCU, Analog, Sensor, SiC, and GaN without unsupported aggregation. |
| RQ-03 | How do OEM production, EV/HEV/PHEV mix, Tier 1 activity, and semiconductor revenue relate over time? | Candidate lead/coincident/lag indicator classification, explicitly subject to validation. |
| RQ-04 | Which inventory observations distinguish end-demand change from channel or producer inventory adjustment? | Observation definitions, source authority, availability, and interpretation constraints. |
| RQ-05 | Which observations can progress to the Knowledge Catalog? | Traceable candidate set with an independent-review disposition. |

---

## 3. Existing-Asset Baseline

### Facts about the repository

The following historical research assets already exist in `KnowledgeBase/01_Research/Industries/Semiconductor/Demand/Automotive/` and are **not** moved or treated as Sprint001-approved outputs:

- `AutomotiveResearch.md` — demand-driver research sheet; status: Evidence Collection; reviewer status: Pending.
- `VehicleProductionResearch.md` — EV-transition research sheet; reviewer status: Pending.
- `AutomotivePowerComponentObservationMappingResearch.md` — candidate mapping of demand, inventory, capacity, and commercialization observations.
- `AutomotivePowerLeadLagValidationSpecification.md` — candidate validation specification.
- EDINET/XBRL inventory research, semantic mapping, catalog, and DDL-design assets.

### Inference from the repository baseline

The project has substantial prior work on **data semantics and candidate observation architecture**. It does not yet have a single independently reviewed Automotive Semiconductor Demand industry report that resolves source authority, value-chain boundaries, and the evidence status of its investment-relevant claims.

---

## 4. Evidence Ledger

The table records source-supported facts only. Each fact is limited to what the cited source states.

| Evidence ID | Fact | Source authority | Usage boundary |
| --- | --- | --- | --- |
| E-001 | OICA publishes country-level 2024 passenger-car and commercial-vehicle production statistics; its 2024 world table reports China, Japan, India, Germany, and South Korea among the largest producing countries. | OICA production statistics | Candidate end-demand scale and regional exposure context; not a semiconductor-demand measure by itself. |
| E-002 | The IEA reports that global electric-car sales exceeded 17 million in 2024 and represented more than 20% of global car sales. | IEA, *Global EV Outlook 2025* | Candidate powertrain-mix / structural-demand context; not a direct revenue proxy. |
| E-003 | Renesas describes its Automotive Business as including in-vehicle control and information, and states that it mainly provides MCUs, SoCs, analog semiconductors, and power semiconductors in that business. | Renesas Annual Securities Report FY2025 | Direct evidence of product-category exposure for a representative Japanese supplier. |
| E-004 | Infineon reported Automotive-segment revenue of EUR7,402 million in FY2025. | Infineon Annual Report 2025 | Direct supplier-side automotive-demand observation at segment level. |
| E-005 | NXP reported 2025 automotive end-market revenue of USD7,116 million, down USD35 million (0.5%) from 2024; it attributed the decline to processors, partly offset by mixed-signal growth. | NXP 2025 annual filing | Direct supplier-side observation and evidence that product categories can diverge within automotive demand. |

### Primary-source links

- [OICA 2024 world motor-vehicle production statistics](https://oica.net/fr/production-statistics/)
- [IEA — Global EV Outlook 2025](https://www.iea.org/reports/global-ev-outlook-2025)
- [Renesas — Annual Securities Report FY2025](https://www.renesas.com/en/document/rep/annual-securities-report-2025)
- [Infineon — Annual Report 2025](https://www.infineon.com/row/public/documents/corporate/investors/annual-reports/2025/2025-annual-report-v01-00-en.pdf)
- [NXP — 2025 annual filing](https://investors.nxp.com/static-files/2299cbbd-40e4-42dd-a9e7-231185a54386)

---

## 5. Preliminary Value-Chain Model

```text
OEM orders / vehicle production / powertrain mix
                    ↓
Tier 1 systems and component demand
                    ↓
Automotive semiconductor orders, shipment, and guidance
                    ↓
Supplier revenue, inventory, utilization, and capacity actions
```

### Fact

The identified suppliers explicitly report automotive operations or end markets. Renesas identifies automotive product categories; Infineon and NXP disclose automotive segment/end-market revenue.

### Inference

OEM production and powertrain mix are upstream demand-context observations; supplier revenue and guidance are nearer to semiconductor demand realization. The size, sign, and timing of any relationship must be tested using point-in-time data before a lead/lag designation is adopted.

### Hypothesis

EV/HEV/PHEV mix will carry more explanatory value for power semiconductors, BMS-related components, and some MCUs than for automotive semiconductor demand as a whole. This remains unapproved pending category-specific company evidence and validation.

---

## 6. Candidate Observation Register

| Observation | Primary location in chain | Initial role | Evidence state | Required next test |
| --- | --- | --- | --- | --- |
| Global / regional vehicle production | OEM | Candidate coincident context | Source available | Align period and geography with supplier exposure. |
| OEM production guidance | OEM | Candidate leading context | Company-specific | Confirm published date and consistency with realized production. |
| EV / HEV / PHEV sales and penetration | OEM / market | Structural-demand context | Source available | Test separately by region and product category. |
| Automotive segment or end-market revenue | Semiconductor supplier | Candidate coincident outcome | Source available for selected suppliers | Normalize fiscal periods and disclosure dates. |
| Automotive product-category revenue or guidance | Semiconductor supplier | Candidate demand observation | Partially available | Preserve source-defined categories; do not infer missing splits. |
| Finished goods, WIP, raw materials, inventory/revenue, and inventory days | Semiconductor supplier | Inventory-adjustment context | Existing semantic work | Apply approved semantic mapping only after review. |
| Utilization, capacity expansion, and capex | Semiconductor supplier | Capacity-risk context | Disclosure-dependent | Do not assign fixed positive/negative direction. |
| Book-to-bill or order commentary | Supplier / Tier 1 | Candidate leading observation | Disclosure-dependent | Define source and point-in-time availability. |

---

## 7. Representative-Company Evidence Plan

### Tier 1 — Semiconductor suppliers

| Company | Research priority | Evidence purpose |
| --- | --- | --- |
| Renesas Electronics | Highest | Japanese automotive MCU, SoC, analog, and power exposure. |
| ROHM | Highest | Automotive and power/SiC exposure; segment and product evidence. |
| Sanken Electric | Highest | Power-semiconductor and inventory evidence. |
| Fuji Electric | Highest | Power-semiconductor and industrial/automotive boundary evidence. |
| Toshiba Device & Storage | Reference | Product and value-chain reference; assess disclosure accessibility. |
| Infineon, NXP, STMicroelectronics, Texas Instruments, onsemi | Comparative | Common vocabulary, category boundaries, and externally disclosed automotive observations. |

### Tier 2 — Demand-side and Tier 1 system suppliers

Toyota, Denso, Aisin, Bosch, and Continental are used to test the upstream-demand interpretation. They are not assumed to be direct proxies for any semiconductor supplier without documented exposure and timing evidence.

---

## 8. Research Work Packages

| Order | Deliverable | Purpose | Exit condition |
| ---: | --- | --- | --- |
| 1 | Automotive Semiconductor Industry Report | Consolidate verified demand structure, boundaries, and claims. | Each claim labelled Fact, Inference, or Hypothesis with source linkage. |
| 2 | Automotive Semiconductor Value Chain | Define OEM → Tier 1 → supplier transmission and boundaries. | No unsupported participant or causality assertion. |
| 3 | Lead/Lag Indicator Catalog | Classify each observation as candidate leading, coincident, lagging, or contextual. | Classification states its validation status and point-in-time rule. |
| 4 | Observation Mapping | Reconcile historical mapping with the reviewed indicator catalog. | One primary ownership; no double counting; source and availability recorded. |
| 5 | Knowledge Catalog Candidate and Review Package | Prepare only reviewed candidates for catalog decision. | Independent reviewer disposition for every proposed knowledge object. |

---

## 9. Quality Gates

1. **Evidence Gate:** factual claims cite primary sources and specify publication date or fiscal period.
2. **Boundary Gate:** product categories and company exposure follow the source’s own definition.
3. **Point-in-Time Gate:** every time-series candidate records applicable period, publication date, and usable-as-of date.
4. **Independent Review Gate:** a reviewer distinct from the author tests evidence sufficiency, category drift, double counting, and unsupported causal language.
5. **Catalog Gate:** only approved, traceable knowledge candidates move to `01_Research`, then to the Knowledge Catalog.

---

## 10. Open Questions

| ID | Open question | Classification | Resolution path |
| --- | --- | --- | --- |
| OQ-01 | Which upstream observation has stable predictive value for supplier revenue after disclosure timing is respected? | Unknown | Point-in-time lead/lag validation. |
| OQ-02 | Can a comparable automotive inventory signal be normalized across Japanese GAAP, IFRS, and US GAAP without semantic loss? | Unknown | Use existing semantic-mapping assets and independent review. |
| OQ-03 | Does powertrain mix add information beyond vehicle production for each product category? | Hypothesis | Category-specific evidence and ablation testing. |
| OQ-04 | Which Tier 1 demand-side disclosures can be used repeatedly and with timely publication? | Unknown | Company source audit for 2021–present. |

---

## 11. Next Actions

1. Build the Value Chain draft from OEM, Tier 1, and supplier primary disclosures.
2. Collect 2021–present disclosure calendars and automotive segment/product observations for the Tier 1 supplier list.
3. Create the Lead/Lag Indicator Catalog with explicit `Candidate` status only.
4. Submit the completed package to an independent reviewer before any promotion to `01_Research`.
