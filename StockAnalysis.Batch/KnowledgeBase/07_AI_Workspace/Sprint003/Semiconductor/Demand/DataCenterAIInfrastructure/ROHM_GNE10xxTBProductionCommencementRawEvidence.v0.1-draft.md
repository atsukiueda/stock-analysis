# ROHM — GNE10xxTB Production Commencement Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `ROHMRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | ROHM Co., Ltd. |
| Inspection Source | `ROHMSourceFactInspection.v0.1-draft.md` — `ROHM-SFI-061` |
| Cross-sprint Recheck | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-091` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-091`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-091`; PIT Review Accepted |

> **利用境界：** Product-series commencementであり、production volume、Data Center allocation、shipment quantity、revenue又はcustomer adoptionを示さない。`052`の後続production-system statementとは別Source Eventで保持する。 `AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *ROHM starts Production of 150V GaN HEMTs: Featuring Breakthrough 8V Withstand Gate Voltage* |
| Publication Event | 2022-03-22; publication time / timezone `Unknown` |
| Applicable Period | Product-production commencement / application at publication |
| URL | [ROHM official source](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=150v-gan-hemts) |
| Source position | 2022-03-22 official news、GNE10xxTB production passage |
| Retrieval Date | 2026-08-09 |

## 2. Source Fact

ROHMは150V GaN HEMT GNE10xxTB seriesのproduction開始を発表する。

| Field | Value |
| --- | --- |
| Fact type | Product-production commencement Actual |
| Actual / Forecast | Product-production commencement Actual — 上流Inspectionの分類を変更しない |
| Unit | Product-series production commencement |
| Cross-sprint reference | No identical candidate in Accepted recheck sets |
| Related candidate boundary | `052`は同じ2022-03 production transitionに関係する後続Source Eventのsystem-level statement |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |

## 3. 制約

- Product-series commencementであり、production volume、Data Center allocation、shipment quantity、revenue又はcustomer adoptionを示さない。`052`の後続production-system statementとは別Source Eventで保持する。
- 上流Inspection及びAccepted RecheckのFact grain、Source Event、発言主体及び時点分類を変更しない。
- `ROHM-SFI-052`と同じ2022-03 production transitionに関係する直接Source Eventである。二度のproduction進展、独立した需要signal又はcorroborationによる確度加算として二重計上しない。
- 同一Source Eventの別候補、既存Sprint Evidence又は関連candidateと結合して、新しい数値、因果、需要signal、commercial relation又は確度を作らない。
- Evidence / PIT ID、公開可能時刻、Catalog適格性又は下流利用権限を推測しない。
