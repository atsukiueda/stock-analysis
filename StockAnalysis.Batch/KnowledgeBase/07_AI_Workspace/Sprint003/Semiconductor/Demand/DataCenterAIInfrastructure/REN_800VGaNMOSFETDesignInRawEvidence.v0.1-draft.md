# Renesas — 800V GaN / MOSFET Design-in Assertion Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `RenesasRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | Renesas Electronics Corporation |
| Inspection Source | `RenesasSourceFactInspection.v0.1-draft.md` — `REN-SFI-010` |
| Cross-sprint Recheck | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-038` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-038`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-038`; Review Accepted |

> **利用境界：** 800V向けproduct strategyとissuer-reported design-in assertionだけを記録する。商用採用実績へ変換しない。`AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *AI Infra and Compute — 2026 Capital Market Day* |
| Publication Event | Document / event date 2026-06-25; publication time / timezone `Unknown` |
| Applicable Period | Current product / strategy assertion at event date |
| URL | [Official document page](https://www.renesas.com/en/document/ppt/ai-infra-and-compute-2026-capital-market-day) |
| Source position | PDF slide 8, GaN / MOSFET for 800V architecture |
| Retrieval Date | 2026-08-02 |

## 2. Source Fact

Renesasは800V architecture向けGaN / MOSFETへ投資し、D-mode GaN及びefficiency / power-density characteristicsを示す。発行者はlatest MOSFETがnext-generation boardsへ`designed into`されたと説明する。

| Field | Value |
| --- | --- |
| Fact type | Issuer product / strategy and design-in assertion |
| Actual / Forecast | Current issuer assertion; revenue / shipment Actualではない |
| Unit | N/A; product specificationsは本Factで集約しない |
| Cross-sprint reference | No identical candidate in accepted recheck sets |
| AvailableAt | `TBD — no use` |

## 3. 制約

- `designed into`を第三者確認済みdesign win、量産採用又はshipmentとみなさない。
- Customer / board identity、数量、revenue、market share又はNVIDIA採用を確定しない。
- Specificationを異なるproduct / conditionへ一般化しない。
