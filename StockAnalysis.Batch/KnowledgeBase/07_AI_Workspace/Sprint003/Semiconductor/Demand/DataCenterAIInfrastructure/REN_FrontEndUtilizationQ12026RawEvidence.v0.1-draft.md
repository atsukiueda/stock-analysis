# Renesas — Front-end Utilization Q1 2026 Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `RenesasRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | Renesas Electronics Corporation |
| Inspection Source | `RenesasSourceFactInspection.v0.1-draft.md` — `REN-SFI-004` |
| Cross-sprint Recheck | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical Source Fact |
| Evidence ID | `S3-EVR-033` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-033`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-033`; Review Accepted |

> **利用境界：** Front-end wafer input基準の稼働率と製品需要contextだけを記録する。全工場稼働率又はData Center単独Observationへ変換しない。`AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *2026 1Q Presentation Minutes and Q&A* |
| Publication Event | Event 2026-04-24; document publication time / timezone `Unknown` |
| Applicable Period | 1Q 2026 Actual-period context |
| URL | [Official document page](https://www.renesas.com/en/document/ppt/2026-1q-presentation-minutes-and-qa) |
| Source position | Prepared remarks `utilization rate and CAPEX status`; PDF p.7（viewer P6） |
| Retrieval Date | 2026-08-02 |

## 2. Source Fact

Renesasは、front-end wafer input基準の1Q稼働率が約55%で、前四半期比約6pt上昇したと説明する。Nakaの12-inch MCU / 40nm MCU及びSaijoのdigital power製品で需要が増加したため、wafer inputを増加したと説明する。

| Field | Value |
| --- | --- |
| Fact type | Management-reported operating observation / Actual-period context |
| Actual / Forecast | Actual-period context; Planではない |
| Unit | Percent / percentage-point change |
| Cross-sprint reference | Same event family as `S2-EVR-013` / `023`; Source Fact is different |
| AvailableAt | `TBD — no use` |

## 3. 制約

- 約55%を全工場、全設備又はassembly / testを含む稼働率とみなさない。
- Naka / Saijoの需要説明からData Center向けwafer、製品、shipment、revenue又はcapacityを推定しない。
- 同じpageのdecision-based investment Planは本Factへ混在させず、`REN-SFI-016`の別Rawへ分離する。
