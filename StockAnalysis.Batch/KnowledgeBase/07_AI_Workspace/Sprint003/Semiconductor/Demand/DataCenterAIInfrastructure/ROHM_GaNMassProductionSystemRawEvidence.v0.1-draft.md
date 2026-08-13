# ROHM — GaN Mass-Production System Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `ROHMRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | ROHM Co., Ltd. |
| Inspection Source | `ROHMSourceFactInspection.v0.1-draft.md` — `ROHM-SFI-052` |
| Cross-sprint Recheck | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-082` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-082`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-082`; PIT Review Accepted |

> **利用境界：** Production-system establishmentであり、production volume、Data Center allocation、shipment、customer adoption又はrevenueを示さない。Application positioningは`060`へ分離する。 `AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *ROHM and Delta Electronics Form a Strategic Partnership on Developing Power Devices for Power Supply Systems* |
| Publication Event | 2022-04-28; publication time / timezone `Unknown` |
| Applicable Period | Partnership Actual / development and mass-production Plan |
| URL | [ROHM official source](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2022-04-28_news_ecogan) |
| Source position | 2022-04-28 official news、150V GaN production-system passage |
| Retrieval Date | 2026-08-09 |

## 2. Source Fact

ROHMは150V GaN HEMTのmass-production systemを2022-03に確立したと説明する。

| Field | Value |
| --- | --- |
| Fact type | Production-system Actual |
| Actual / Forecast | Production-system Actual — 上流Inspectionの分類を変更しない |
| Unit | Production-system establishment month |
| Cross-sprint reference | No identical candidate in Accepted recheck sets |
| Related candidate boundary | `061`と同じ2022-03 production transitionに関係する後続のsystem-level statement。`060` application Planとは分離 |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |

## 3. 制約

- Production-system establishmentであり、production volume、Data Center allocation、shipment、customer adoption又はrevenueを示さない。Application positioningは`060`へ分離する。
- 上流Inspection及びAccepted RecheckのFact grain、Source Event、発言主体及び時点分類を変更しない。
- `ROHM-SFI-061`と同じ2022-03 production transitionに関係する後続のsystem-level statementである。二度のproduction進展、独立した需要signal又はcorroborationによる確度加算として二重計上しない。
- 同一Source Eventの別候補、既存Sprint Evidence又は関連candidateと結合して、新しい数値、因果、需要signal、commercial relation又は確度を作らない。
- Evidence / PIT ID、公開可能時刻、Catalog適格性又は下流利用権限を推測しない。
