# ROHM — Enterprise / AI Server MOSFET Availability Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `ROHMRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | ROHM Co., Ltd. |
| Inspection Source | `ROHMSourceFactInspection.v0.1-draft.md` — `ROHM-SFI-027` |
| Cross-sprint Recheck | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-058` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-058`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-058`; PIT Review Accepted |

> **利用境界：** 製品別application mappingを保持する。Development / sample availabilityであり、mass-production volume、customer adoption、shipment又はrevenueを示さない。2025 mass-production Planと分離する。 `AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *ROHM Develops Class-Leading Low ON-Resistance, High-Power MOSFETs for High-Performance Enterprise and AI Servers* |
| Publication Event | 2025-04-10; publication time / timezone `Unknown` |
| Applicable Period | Product development / availability / Plan at publication |
| URL | [ROHM official source](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2025-04-10_news_mosfet) |
| Source position | 2025-04-10 official news、product development / availability |
| Retrieval Date | 2026-08-09 |

## 2. Source Fact

ROHMはRS7E200BGを12V enterprise-server power supplyのsecondary AC-DC / HSC向け、RS7N200BH及びRS7N160BHを48V AI-server power supplyのsecondary AC-DC向けとして開発し、sourceはonline availabilityを`now`と示す。

| Field | Value |
| --- | --- |
| Fact type | Product development Actual / market availability |
| Actual / Forecast | Product development Actual / market availability — 上流Inspectionの分類を変更しない |
| Unit | Product / voltage / application mapping |
| Cross-sprint reference | No identical candidate in Accepted recheck sets |
| Related candidate boundary | `028`のproduction Planと分離 |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |

## 3. 制約

- 製品別application mappingを保持する。Development / sample availabilityであり、mass-production volume、customer adoption、shipment又はrevenueを示さない。2025 mass-production Planと分離する。
- 上流Inspection及びAccepted RecheckのFact grain、Source Event、発言主体及び時点分類を変更しない。
- 同一Source Eventの別候補、既存Sprint Evidence又は関連candidateと結合して、新しい数値、因果、需要signal、commercial relation又は確度を作らない。
- Evidence / PIT ID、公開可能時刻、Catalog適格性又は下流利用権限を推測しない。
