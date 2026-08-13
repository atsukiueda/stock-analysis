# Renesas — 800V AI Data Center Architecture Response Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `RenesasRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | Renesas Electronics Corporation |
| Inspection Source | `RenesasSourceFactInspection.v0.1-draft.md` — `REN-SFI-014` |
| Cross-sprint Recheck | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-042` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-042`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-042`; Review Accepted |

> **利用境界：** NVIDIAが発表した800V DC architectureへのRenesasの対応表明とproduct mapだけを記録する。Procurement又はadoptionへ変換しない。`AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *Renesas Powers 800-Volt Direct Current AI Data Center Architecture with Next-Generation Power Semiconductors* |
| Publication Event | 2025-10-13; publication time / timezone `Unknown` |
| Applicable Period | Product / architecture announcement at publication |
| URL | [Official newsroom release](https://www.renesas.com/en/about/newsroom/renesas-powers-800-volt-direct-current-ai-data-center-architecture-next-generation-power) |
| Source position | Announcement body; 800V DC architecture and Renesas product portfolio sections |
| Retrieval Date | 2026-08-02 |

## 2. Source Fact

Renesasは、NVIDIAが発表した800V DC AI data-center architectureへの対応として、48V–400VのGaN solutions、800Vへ構成可能なstack、MOSFET、drivers及びcontrollersを含むpower portfolioを説明する。

| Field | Value |
| --- | --- |
| Fact type | Official product / architecture response announcement |
| Actual / Forecast | Product / architecture statement; procurement Actualではない |
| Unit | Voltage range / architecture context |
| Cross-sprint reference | No identical candidate in accepted recheck sets |
| AvailableAt | `TBD — no use` |

## 3. 制約

- NVIDIAによるprocurement、design win、production deployment、shipment、sales又はcustomer-specific BOMを確定しない。
- 48V–400V productsのstack可能性を単一productの800V rating又は量産systemとみなさない。
- Product specificationを異なるcondition又はportfolio全体へ一般化しない。
