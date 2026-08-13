# ROHM — Next-Generation AI Server Architecture Scenario Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `ROHMRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | ROHM Co., Ltd. |
| Inspection Source | `ROHMSourceFactInspection.v0.1-draft.md` — `ROHM-SFI-009` |
| Cross-sprint Recheck | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-049` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-049`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-049`; PIT Review Accepted |

> **利用境界：** Next generationは2027年頃以降のscenario。Current average、universal BOM、shipment、installed base又は実現済み需要とみなさない。 `AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *Financial Results for FY2025* |
| Publication Event | Document date 2026-05-13; publication time / timezone `Unknown` |
| Applicable Period | FY2025 Actual / FY2026 Plan / mid-term target context |
| URL | [ROHM official source](https://fscdn.rohm.com/en/financial/account/2603_presentation_en.pdf) |
| Source position | FY2025 Results p.24、current server / next-generation AI server illustration |
| Retrieval Date | 2026-08-09 |

## 2. Source Fact

Illustrationはmain boards 18→72、power consumption 13kW→1,000kW、power components 600→22,000、analog components 300→17,000を示す。

| Field | Value |
| --- | --- |
| Fact type | Issuer management architecture scenario |
| Actual / Forecast | Issuer management architecture scenario — 上流Inspectionの分類を変更しない |
| Unit | Illustrative board count / kW / component count |
| Cross-sprint reference | No identical candidate in Accepted recheck sets |
| Related candidate boundary | `010` / `011`のsales Factとは別grain |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |

## 3. 制約

- Next generationは2027年頃以降のscenario。Current average、universal BOM、shipment、installed base又は実現済み需要とみなさない。
- 上流Inspection及びAccepted RecheckのFact grain、Source Event、発言主体及び時点分類を変更しない。
- 同一Source Eventの別候補、既存Sprint Evidence又は関連candidateと結合して、新しい数値、因果、需要signal、commercial relation又は確度を作らない。
- Evidence / PIT ID、公開可能時刻、Catalog適格性又は下流利用権限を推測しない。
