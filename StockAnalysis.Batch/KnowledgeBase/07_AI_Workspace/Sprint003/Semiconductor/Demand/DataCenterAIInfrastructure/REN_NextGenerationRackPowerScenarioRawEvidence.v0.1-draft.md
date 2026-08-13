# Renesas — Next-Generation Rack Power Scenario Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `RenesasRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | Renesas Electronics Corporation |
| Inspection Source | `RenesasSourceFactInspection.v0.1-draft.md` — `REN-SFI-009` |
| Cross-sprint Recheck | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-037` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-037`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-037`; Review Accepted |

> **利用境界：** Next-generation AI rackに関するforward-looking scenarioだけを記録する。Actual又は半導体需要量へ変換しない。`AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *AI Infra and Compute — 2026 Capital Market Day* |
| Publication Event | Document / event date 2026-06-25; publication time / timezone `Unknown` |
| Applicable Period | Next-generation / forward-looking scenario |
| URL | [Official document page](https://www.renesas.com/en/document/ppt/ai-infra-and-compute-2026-capital-market-day) |
| Source position | PDF slide 7, `Order-of-Magnitude Increase in AI Rack Power Content` |
| Retrieval Date | 2026-08-02 |

## 2. Source Fact

Renesas資料は、next-generation AI rackが1MW超へ向かい、power content per rackが10倍超になるとのforward-looking contextを示す。

| Field | Value |
| --- | --- |
| Fact type | Management scenario with third-party market context |
| Actual / Forecast | Forward-looking scenario; Actualではない |
| Unit | MW threshold / relative multiplier |
| Cross-sprint reference | No identical candidate in accepted recheck sets |
| AvailableAt | `TBD — no use` |

## 3. 制約

- `>1MW`又は`>10x`を現在のrack population、installed base、market average又は実測需要とみなさない。
- Power content倍率からcontroller、MOSFET、module又はrevenue数量を算出しない。
- 同じslideのanonymous customer-board relationは`REN-SFI-017`の別Rawへ分離する。
