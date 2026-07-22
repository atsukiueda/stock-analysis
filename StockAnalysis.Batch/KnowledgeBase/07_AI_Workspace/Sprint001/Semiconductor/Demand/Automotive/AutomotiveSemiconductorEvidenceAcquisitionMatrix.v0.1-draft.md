# Sprint001 — Automotive Semiconductor Evidence Acquisition Matrix

## Document Information

| Item | Value |
| --- | --- |
| Research Domain | Semiconductor / Demand / Automotive |
| Sprint | Sprint001 |
| Document Type | Evidence-Acquisition Research Draft |
| Version | 0.1-draft |
| Status | Evidence Collection |
| Reviewer Status | Pending Independent Review |
| Evidence Window | 2021–present |
| Author | Documentation & Knowledge Base Team |
| Last Updated | 2026-07-19 |

> **Draft boundary:** This matrix records acquisition feasibility and source constraints. It does not certify that a metric is comparable, complete, predictive, catalog-ready, or approved for implementation.

---

## 1. Purpose

Provide a controlled acquisition plan for recurring Automotive Semiconductor Demand evidence. For every source family, the matrix records authority, expected cadence, candidate observations, point-in-time requirement, and known comparability limitations.

This is the bridge between the Industry Report / Value Chain / Indicator Catalog drafts and later independent review. It does not replace company research sheets or the existing inventory-semantic mapping assets.

---

## 2. Acquisition Rules

1. Prefer primary issuer disclosures and official statistics.
2. Preserve the source’s own business, product, geography, fiscal-period, and currency definitions.
3. Capture the published date/time separately from the economic period.
4. Maintain both original source wording/value and normalized research fields; never overwrite the former.
5. Record unavailable disclosures as unavailable—never estimated or peer-filled.
6. Treat changed segment definitions as a comparability event, not a silent continuation.

---

## 3. Source-Authority Tiers

| Tier | Source type | Permitted use |
| --- | --- | --- |
| 1 | Statutory filing, annual/integrated report, official earnings report, official investor presentation, official statistics | Factual evidence, subject to definition and review checks. |
| 2 | Official investor-relations archive, official company news release, official product or technical disclosure | Context and factual evidence where scope is explicit. |
| 3 | Third-party industry source | Discovery or context only; not sole evidence for knowledge adoption. |

---

## 4. Company Acquisition Matrix

| Company | Role | Primary official source family | Historical availability observed | Candidate observations | Main limitation | Initial readiness |
| --- | --- | --- | --- | --- | --- | --- |
| Renesas Electronics | Tier 1 semiconductor supplier | Annual Securities Report; quarterly earnings reports; presentation/Q&A archive; Capital Market Day materials | 2021–2025 archives observed; quarterly reporting materials available | Automotive-business description; total revenue; guidance/commentary; product strategy; inventory where disclosed | Automotive product revenue may not be consistently separated from other product/business data | High for recurring issuer evidence; product-level review required |
| ROHM | Tier 1 semiconductor supplier | Integrated Report; financial report; fact book; financial-results briefing material | FY2025 material and IR library observed | Power/SiC and automotive strategy; total/segment results; guidance; inventory where disclosed | Automotive-specific quantitative segmentation must be verified per period | High for source continuity; Medium for automotive-specific metric continuity |
| Sanken Electric | Tier 1 semiconductor supplier | Official financial results, statutory filing, and IR archive | Not yet verified in this draft | Power-semiconductor exposure; financial and inventory observations | Recurrence, English/Japanese availability, and automotive splits remain unverified | Pending source audit |
| Fuji Electric | Tier 1 semiconductor supplier | Official financial-results archive; annual/integrated materials; management plan | FY2021–FY2025 financial-results archive observed | Semiconductor segment results; automotive semiconductor commentary; power/SiC context; inventory and capacity context where disclosed | Segment changes and product-level splits can affect comparability | High for financial-result continuity; Medium for automotive-specific continuity |
| Toshiba Device & Storage | Reference supplier | Official public corporate/product disclosures | Not assessed | Product/value-chain context | Standalone financial disclosure accessibility and continuity unknown | Pending source audit |
| Infineon | Comparative supplier | Annual report; quarterly results; investor presentation | FY2025 annual disclosure observed | Automotive segment revenue; product/capacity commentary; inventory context where disclosed | IFRS definitions and fiscal calendar differ from Japanese issuers | High for comparative context; normalization required |
| NXP | Comparative supplier | Annual filing; quarterly earnings release | FY2025 annual and quarterly disclosure observed | Automotive end-market revenue; product commentary; channel inventory | US filing definition, fiscal/calendar and channel structure differ | High for comparative context; normalization required |
| STMicroelectronics | Comparative supplier | Annual report; quarterly results | Not yet verified in this draft | Automotive/industrial end-market and power/MCU context | Source audit pending | Pending source audit |
| Texas Instruments | Comparative supplier | Annual report; quarterly results | Not yet verified in this draft | Industrial/automotive exposure and analog context | Automotive quantitative split may be limited | Pending source audit |
| onsemi | Comparative supplier | Annual report; quarterly results | Not yet verified in this draft | Automotive and power/SiC context | Source audit pending | Pending source audit |

---

## 5. Demand-Side Acquisition Matrix

| Organization / source | Role | Candidate observations | Cadence | Point-in-time requirement | Boundary |
| --- | --- | --- | --- | --- | --- |
| OICA | Global end-market statistics | Vehicle production by country/type | Annual | Publication date and revision status | Production is not sales/registration and not semiconductor demand. |
| IEA | Global EV market context | Electric-car sales, share, regional market context | Annual | Publication date; historical-series version | EV sales are contextual unless category-specific transmission is validated. |
| Toyota | OEM | Production, sales, guidance, powertrain strategy | Quarterly / annual where disclosed | Exact issuer publication date | No direct semiconductor supplier allocation assumed. |
| DENSO | Tier 1 systems | Electrification, powertrain, mobility-electronics, semiconductor system context | Quarterly / annual where disclosed | Exact issuer publication date | Do not infer purchases from product/technology discussion. |
| Aisin | Tier 1 systems | Electrification and powertrain system context | Quarterly / annual where disclosed | Exact issuer publication date | Direct semiconductor-demand linkage unverified. |
| Bosch / Continental | Reference Tier 1 systems | System and regional demand context | Annual / quarterly where disclosed | Exact issuer publication date | Used only where definitions and reuse are documented. |

---

## 6. Observation Acquisition Matrix

| Observation | Preferred source | Cadence | Raw evidence to retain | Candidate use | Readiness / restriction |
| --- | --- | --- | --- | --- | --- |
| Global / regional vehicle production | OICA | Annual | Source table, geography, vehicle definition, publication date | End-demand context | High availability; low frequency. |
| EV sales / penetration | IEA and official regional sources | Annual / regional cadence | Series version, geography, vehicle classification, publication date | Product-mix context | High availability; not a direct supplier-revenue proxy. |
| OEM production guidance | OEM earnings release / presentation | Quarterly / annual | Guidance wording, period, publication date, revisions | Candidate leading context | Issuer-specific and qualitative. |
| Tier 1 system disclosure | Integrated / annual report; earnings material | Quarterly / annual | System category, source wording, period, date | Transmission context | No purchase-volume inference. |
| Automotive segment / end-market revenue | Supplier filing / earnings report | Quarterly / annual | Segment definition, value, currency, fiscal period, date | Supplier-demand realization | High value only when the automotive definition is explicit. |
| Product-category revenue / guidance | Supplier presentation / Q&A / filing | Quarterly / annual | Exact category definition and wording | Product-level demand context | Do not bridge categories across issuers without review. |
| Inventory (finished goods / WIP / raw materials) | Statutory filing / XBRL / earnings material | Quarterly / annual | Taxonomy tag, scope, unit, period, publication date | Inventory-adjustment context | Must use semantic mapping; no silent aggregation. |
| Inventory-to-revenue / inventory days | Derived from reviewed raw observations | Quarterly / annual | Formula version and all raw inputs | Normalized inventory context | Not a raw disclosed fact; retain derivation. |
| Channel inventory | Supplier earnings report / release | Quarterly where disclosed | Definition, weeks/days, period, publication date | Channel-adjustment context | Not comparable with producer inventory by default. |
| Capacity / utilization / capex | Issuer filing, presentation, earnings commentary | Quarterly / annual | Wording, capacity basis, capex scope, date | Capacity-risk context | Direction is context-dependent. |
| Order / book-to-bill / demand commentary | Issuer release / Q&A | Quarterly where disclosed | Full wording, speaker/document, date | Candidate leading context | Often qualitative; validate recurrence and consistency. |

---

## 7. Point-in-Time Minimum Dataset

Every acquired record must contain:

```text
ObservationIdentifier
IssuerOrStatisticOwner
SourceDocument
SourceAuthorityTier
SourceURLorRepositoryPath
ApplicablePeriodStart
ApplicablePeriodEnd
PublishedDateTime
EffectiveAsOfDate
DefinitionText
Geography
ProductOrSegmentScope
UnitAndCurrency
RawValueOrQuotedText
ReviewStatus
Confidence
```

`EffectiveAsOfDate` is not inferred from an applicable period. It must be set from the publication event and later approved operational convention.

---

## 8. Material Comparability Events

| Event | Required handling |
| --- | --- |
| Segment reorganization | Record the effective date, issuer restatement treatment, and comparability decision. |
| Product-category rename or aggregation change | Treat as a new definition until independently reviewed. |
| Accounting-standard or taxonomy change | Route through the existing semantic-mapping process. |
| Currency or fiscal-year change | Preserve original values and document normalization method separately. |
| Guidance withdrawal or revision | Retain both original and revised published records; do not overwrite history. |

---

## 9. Evidence Confirmed in This Draft

### Facts

- Renesas provides an archive of 2025 quarterly results, annual reports, presentations, Q&A, and financial data; its public archive also contains earlier years.
- ROHM’s investor-relations site provides FY2025 financial reports, a fact book, integrated report, and financial-results briefing material.
- Fuji Electric’s financial-results archive exposes FY2021 through FY2025 materials; its FY2025 results describe lower automotive-semiconductor sales associated with lower demand for power semiconductors for electrified vehicles and pricing effects.

### Inference

Renesas, ROHM, and Fuji Electric are suitable first-pass Japanese evidence targets because an official recurring disclosure channel is observable. This does **not** establish that every required automotive metric is available or comparable.

### Unknown

Sanken, Toshiba Device & Storage, STMicroelectronics, Texas Instruments, and onsemi require a source-archive audit before their readiness can be elevated beyond `Pending source audit`.

### Primary-source links

- [Renesas IR Materials: 2025](https://www.renesas.com/en/about/investor-relations/event/presentation/2025)
- [Renesas Earnings Reports archive](https://www.renesas.com/en/about/investor-relations/earning)
- [ROHM Investor Relations](https://www.rohm.com/ir)
- [Fuji Electric Financial Results archive](https://www.fujielectric.com/ir/library/detail/financial_results.html)
- [Fuji Electric FY2025 results summary](https://www.fujielectric.com/ir/finance/detail/summary.html)

---

## 10. Independent Review Questions

1. Is the distinction between source availability and metric suitability consistently maintained?
2. Are all product and segment definitions preserved rather than normalized by assumption?
3. Does the matrix prevent use before `PublishedDateTime` / `EffectiveAsOfDate`?
4. Are `Pending source audit` entries clearly excluded from candidate adoption?
5. Does the matrix duplicate any existing semantic-mapping authority rather than reference it?

---

## 11. Next Actions

1. Audit the pending-source companies using official archives only.
2. Build company research sheets for Renesas, ROHM, Sanken Electric, and Fuji Electric using the established template.
3. Reconcile inventory fields with historical EDINET/XBRL semantic mappings before any observation is proposed for cataloging.
4. Assemble the Industry Report, Value Chain, Indicator Catalog, and this matrix as the first Independent Review package.

