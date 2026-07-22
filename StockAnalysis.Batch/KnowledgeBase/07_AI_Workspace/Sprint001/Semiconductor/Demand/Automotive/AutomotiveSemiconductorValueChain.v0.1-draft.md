# Sprint001 — Automotive Semiconductor Value Chain

## Document Information

| Item | Value |
| --- | --- |
| Research Domain | Semiconductor / Demand / Automotive |
| Sprint | Sprint001 |
| Document Type | Value-Chain Research Draft |
| Version | 0.1-draft |
| Status | Evidence Collection |
| Reviewer Status | Pending Independent Review |
| Author | Documentation & Knowledge Base Team |
| Last Updated | 2026-07-19 |

> **Draft boundary:** This document is a Research Asset. It defines neither a causal model nor an investment rule, and cannot be used as canonical research, a Catalog entry, DDL input, or implementation specification before independent review.

> **Evidence reference:** Use `Sprint001AutomotiveEvidenceRegister.v0.1-draft.md` as the factual source for this package. The transmission model remains Fact / Inference / Hypothesis-separated.

---

## 1. Purpose

Define a traceable Automotive Semiconductor Demand value chain that distinguishes:

1. the origin of end demand,
2. the conversion of vehicle requirements into systems and components,
3. supplier-side semiconductor demand realization, and
4. observations that may be used to test—not assume—transmission between those stages.

The model supports later Lead/Lag Indicator Catalog work. It does not assign weights, lags, or causal effect sizes.

---

## 2. Scope and Boundaries

### In scope

```text
OEM vehicle production and powertrain mix
        ↓
Tier 1 vehicle systems and component demand
        ↓
Automotive semiconductor suppliers
        ↓
Revenue, inventory, capacity, and guidance observations
```

### Out of scope

- Detailed semiconductor fabrication, materials, or equipment value chains.
- Attribution of a supplier’s total revenue to a named OEM without source disclosure.
- A fixed ordering lead/lag between any two stages.
- Treating EV volume as a direct measure of semiconductor revenue.

---

## 3. Evidence-Backed Participant Roles

| Stage | Evidence-backed role | Representative evidence | Boundary |
| --- | --- | --- | --- |
| OEM / end market | Vehicle production and powertrain demand are observable at market and company level. | OICA publishes production statistics; IEA reports electric-car sales and share. | Production, sales, registrations, and orders are distinct measures and must not be substituted without disclosure. |
| Tier 1 systems | Tier 1 firms translate vehicle requirements into electrification, powertrain, electronics, and advanced-device systems. | DENSO’s 2025 Integrated Report identifies Electrification Systems, Powertrain Systems, Mobility Electronics, and Advanced Devices. | A Tier 1’s product portfolio does not establish direct supplier allocation. |
| Semiconductor supplier | Automotive suppliers provide product categories such as MCU, SoC, analog, power, mixed-signal, and sensor-related products. | Renesas identifies automotive MCUs, SoCs, analog, and power; NXP and Infineon disclose automotive revenue. | Product-category exposure is supplier-defined; no cross-company normalization is assumed. |
| Supplier operating state | Revenue, inventory, utilization/capacity commentary, and guidance may show demand realization or adjustment. | NXP discloses automotive end-market revenue and channel inventory; company disclosures vary. | These observations can reflect more than end demand and require contextual interpretation. |

---

## 4. Evidence Ledger

| Evidence ID | Fact | Source authority | Permitted interpretation |
| --- | --- | --- | --- |
| VC-E-001 | OICA publishes country-level 2024 vehicle-production statistics. | OICA | Production is an upstream demand-context observation. |
| VC-E-002 | The IEA reports global electric-car sales above 17 million in 2024 and a global market share above 20%. | IEA, *Global EV Outlook 2025* | Powertrain mix is an observable structural-demand context. |
| VC-E-003 | DENSO reports core product areas including Electrification Systems, Powertrain Systems, Mobility Electronics, and Advanced Devices. | DENSO Integrated Report 2025 | A representative Tier 1 operates at the vehicle-system layer. |
| VC-E-004 | DENSO describes a power-semiconductor domain covering SiC wafers, devices, modules, and inverters for BEV/PHEV/HEV applications. | DENSO Integrated Report 2025 | Product-chain stages must not be collapsed into a single “SiC revenue” measure unless the source does so. |
| VC-E-005 | Renesas states that its Automotive Business provides MCUs, SoCs, analog semiconductors, and power semiconductors. | Renesas Annual Securities Report FY2025 | The automotive supplier layer contains multiple product categories. |
| VC-E-006 | NXP reported 2025 automotive end-market revenue of USD7,116 million; mixed-signal product growth partly offset processor declines. | NXP 2025 annual filing | Automotive demand can diverge by product category even within one supplier. |
| VC-E-007 | Infineon reported Automotive-segment revenue of EUR7,402 million in FY2025. | Infineon Annual Report 2025 | Segment revenue is a supplier-side realized-demand observation. |

### Primary-source links

- [OICA 2024 world motor-vehicle production statistics](https://oica.net/fr/production-statistics/)
- [IEA — Global EV Outlook 2025](https://www.iea.org/reports/global-ev-outlook-2025)
- [DENSO Integrated Report 2025](https://www.denso.com/global/en/about-us/investors/annual-report/integrated-report-2025/)
- [Renesas Annual Securities Report FY2025](https://www.renesas.com/en/document/rep/annual-securities-report-2025)
- [NXP 2025 annual filing](https://investors.nxp.com/static-files/2299cbbd-40e4-42dd-a9e7-231185a54386)
- [Infineon Annual Report 2025](https://www.infineon.com/row/public/documents/corporate/investors/annual-reports/2025/2025-annual-report-v01-00-en.pdf)

---

## 5. Candidate Transmission Model

```text
[OEM / market]
Vehicle production, registrations, powertrain mix, OEM guidance
                    │
                    │ candidate demand transmission; unvalidated
                    ▼
[Tier 1 systems]
Electrification, powertrain, mobility electronics, sensing, advanced devices
                    │
                    │ product-, geography-, and customer-specific; unvalidated
                    ▼
[Semiconductor supplier]
Automotive revenue, product revenue/guidance, order commentary
                    │
                    ├──────────────► [Inventory adjustment]
                    │                finished goods / WIP / raw materials / channel inventory
                    │
                    └──────────────► [Capacity state]
                                     utilization / capex / expansion / underutilization
```

### Fact

The sources establish the existence of these business layers and the categories reported by representative companies.

### Inference

Supplier revenue is economically nearer to semiconductor demand realization than OEM production or EV penetration. It can nonetheless diverge because of inventory changes, product mix, geographic exposure, pricing, or supplier-specific events.

### Hypothesis

Tier 1 system observations can improve interpretation of the transition from OEM demand to semiconductor supplier revenue. This is untested and depends on recurrent, time-aligned disclosures.

---

## 6. Observation Boundaries

| Observation family | Primary chain stage | May indicate | Must not by itself indicate |
| --- | --- | --- | --- |
| Vehicle production / registration | OEM / market | End-market scale or direction | Semiconductor revenue or inventory normalization. |
| BEV / PHEV / HEV mix | OEM / market | Product-category demand context | A universal uplift to all automotive semiconductor categories. |
| Tier 1 product/system disclosure | Tier 1 | System-level demand and technology context | Direct demand for a named semiconductor supplier. |
| Automotive segment revenue | Semiconductor supplier | Realized supplier-side automotive revenue | Source of volume, price, mix, or inventory change without commentary. |
| Product-specific revenue/guidance | Semiconductor supplier | Category-specific supplier demand | A peer’s comparable product category. |
| Inventory, channel inventory, inventory/revenue | Supplier operating state | Potential adjustment or working-capital state | Demand recovery/decline without revenue and guidance context. |
| Capex, expansion, utilization | Supplier operating state | Capacity-risk context | Fixed positive or negative demand signal. |

---

## 7. Cross-Company Comparability Rules

1. Preserve each issuer’s stated segment, end-market, product, geography, fiscal-period, and currency definition.
2. Do not aggregate power devices, modules, substrates, wafers, and inverters as a single category unless the source reports that aggregate.
3. Do not infer a supplier’s automotive exposure from technology announcements alone.
4. Do not treat an OEM, Tier 1, and supplier observation as contemporaneous until their applicable period and publication date are aligned.
5. Record unavailable product splits as unavailable; do not fill them by peer average or analyst estimation.

---

## 8. Review Questions

| ID | Question for the independent reviewer |
| --- | --- |
| RV-01 | Does each stated participant role remain within what the cited source supports? |
| RV-02 | Does the model clearly separate end demand, system demand, semiconductor realization, inventory, and capacity? |
| RV-03 | Are all causal or lead/lag claims retained as Inference or Hypothesis until validation? |
| RV-04 | Do the comparability rules prevent unsupported cross-company aggregation? |
| RV-05 | Is the model sufficiently specific to guide the indicator catalog without becoming an implementation design? |

---

## 9. Next Actions

1. Build the Lead/Lag Indicator Catalog from the observation boundaries above.
2. Collect recurring 2021–present disclosure points for the representative company set.
3. Reconcile historical Automotive Power mapping candidates against the reviewed value-chain boundaries.
4. Submit this draft for independent review together with the Industry Report Draft.
