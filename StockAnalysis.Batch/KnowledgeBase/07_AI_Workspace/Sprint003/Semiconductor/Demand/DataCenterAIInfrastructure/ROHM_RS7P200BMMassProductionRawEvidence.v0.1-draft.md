# ROHM — RS7P200BM Mass-Production Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `ROHMRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | ROHM Co., Ltd. |
| Inspection Source | `ROHMSourceFactInspection.v0.1-draft.md` — `ROHM-SFI-032` |
| Cross-sprint Recheck | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-063` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-063`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-063`; PIT Review Accepted |

> **利用境界：** Company-wide production volume、shipment、revenue、customer adoption又はAI-server allocationを示さない。Application positioningは`033`へ分離する。 `AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *ROHM launches wide SOA MOSFET for AI servers in compact 5×6mm package* |
| Publication Event | 2025-11-25; publication time / timezone `Unknown` |
| Applicable Period | Product production / application at publication |
| URL | [ROHM official source](https://www.rohm.com/news-detail?news-title=2025-11-25_news_mosfet) |
| Source position | 2025-11-25 official news、RS7P200BM mass-production passage |
| Retrieval Date | 2026-08-09 |

## 2. Source Fact

ROHMはRS7P200BMのmass productionを2025-09に開始したと発表する。

| Field | Value |
| --- | --- |
| Fact type | Product mass-production Actual |
| Actual / Forecast | Product mass-production Actual — 上流Inspectionの分類を変更しない |
| Unit | Production commencement month |
| Cross-sprint reference | No identical candidate in Accepted recheck sets |
| Related candidate boundary | `033`のapplication definitionと分離 |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |

## 3. 制約

- Company-wide production volume、shipment、revenue、customer adoption又はAI-server allocationを示さない。Application positioningは`033`へ分離する。
- 上流Inspection及びAccepted RecheckのFact grain、Source Event、発言主体及び時点分類を変更しない。
- 同一Source Eventの別候補、既存Sprint Evidence又は関連candidateと結合して、新しい数値、因果、需要signal、commercial relation又は確度を作らない。
- Evidence / PIT ID、公開可能時刻、Catalog適格性又は下流利用権限を推測しない。
