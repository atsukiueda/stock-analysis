# ROHM — Server Business Sales Targets Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `ROHMRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | ROHM Co., Ltd. |
| Inspection Source | `ROHMSourceFactInspection.v0.1-draft.md` — `ROHM-SFI-011` |
| Cross-sprint Recheck | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-051` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-051`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-051`; PIT Review Accepted |

> **利用境界：** Actualではない。FY2028値は2025-11時点planとされ、各targetのassumption、AI-only比率及び達成確率を補完しない。FY2025 Actualと分離する。 `AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *Financial Results for FY2025* |
| Publication Event | Document date 2026-05-13; publication time / timezone `Unknown` |
| Applicable Period | FY2025 Actual / FY2026 Plan / mid-term target context |
| URL | [ROHM official source](https://fscdn.rohm.com/en/financial/account/2603_presentation_en.pdf) |
| Source position | FY2025 Results p.27、Server Business sales target |
| Retrieval Date | 2026-08-09 |

## 2. Source Fact

Server Business salesはFY2026 JPY25.0bn、FY2028 JPY30.0bn、FY2030 JPY100bn超を目指すと表示される。

| Field | Value |
| --- | --- |
| Fact type | Issuer Plan / Target |
| Actual / Forecast | Issuer Plan / Target — 上流Inspectionの分類を変更しない |
| Unit | JPY billion |
| Cross-sprint reference | No identical candidate in Accepted recheck sets |
| Related candidate boundary | `010`のActual及びHold `044`のprior target setと非同義 |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |

## 3. 制約

- Actualではない。FY2028値は2025-11時点planとされ、各targetのassumption、AI-only比率及び達成確率を補完しない。FY2025 Actualと分離する。
- 上流Inspection及びAccepted RecheckのFact grain、Source Event、発言主体及び時点分類を変更しない。
- 同一Source Eventの別候補、既存Sprint Evidence又は関連candidateと結合して、新しい数値、因果、需要signal、commercial relation又は確度を作らない。
- Evidence / PIT ID、公開可能時刻、Catalog適格性又は下流利用権限を推測しない。
