# ROHM — 800VDC Architecture and Device Positioning Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `ROHMRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | ROHM Co., Ltd. |
| Inspection Source | `ROHMSourceFactInspection.v0.1-draft.md` — `ROHM-SFI-013` |
| Cross-sprint Recheck | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-052` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-052`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-052`; PIT Review Accepted |

> **利用境界：** Proposed architecture / internal analysisであり、industry standard、deployed system、採用、売上又は優位性の第三者検証ではない。 `AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *ROHM’s 800VDC Architecture Solutions for AI Servers* |
| Publication Event | Official release page display 2025-10-13; publication time / timezone `Unknown` |
| Applicable Period | Technical architecture / internal analysis at publication |
| URL | [ROHM official source](https://fscdn.rohm.com/en/products/databook/white_paper/common/800vdc_architecture_solution_for_ai_server_wp-e.pdf) |
| Source position | 800VDC white paper p.3、abstract / proposed architecture |
| Retrieval Date | 2026-08-09 |

## 2. Source Fact

800VDC architectureではAC-DC converterをside power rackへ移し、DC-DC converterをIT rackに残す構成を説明し、ROHM internal analysisとしてpower-source側にSiC、IT-rack側にGaNを位置付ける。

| Field | Value |
| --- | --- |
| Fact type | Issuer technical architecture definition / internal analysis |
| Actual / Forecast | Issuer technical architecture definition / internal analysis — 上流Inspectionの分類を変更しない |
| Unit | VDC architecture / qualitative device positioning |
| Cross-sprint reference | No identical candidate in Accepted recheck sets |
| Related candidate boundary | `029`のNVIDIA architecture responseとSource Event / claimが異なる |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |

## 3. 制約

- Proposed architecture / internal analysisであり、industry standard、deployed system、採用、売上又は優位性の第三者検証ではない。
- 上流Inspection及びAccepted RecheckのFact grain、Source Event、発言主体及び時点分類を変更しない。
- 同一Source Eventの別候補、既存Sprint Evidence又は関連candidateと結合して、新しい数値、因果、需要signal、commercial relation又は確度を作らない。
- Evidence / PIT ID、公開可能時刻、Catalog適格性又は下流利用権限を推測しない。
