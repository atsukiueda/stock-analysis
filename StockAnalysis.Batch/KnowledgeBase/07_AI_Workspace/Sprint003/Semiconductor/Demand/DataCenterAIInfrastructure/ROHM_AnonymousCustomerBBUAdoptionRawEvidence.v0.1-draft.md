# ROHM — Anonymous-Customer BBU Adoption Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `ROHMRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | ROHM Co., Ltd. |
| Inspection Source | `ROHMSourceFactInspection.v0.1-draft.md` — `ROHM-SFI-038` |
| Cross-sprint Recheck | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-069` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-069`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-069`; PIT Review Accepted |

> **利用境界：** Customer / BBU maker identity、order、volume、shipment、revenue、production deployment及びexclusive supplyを確定しない。 `AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *ROHM’s SiC MOSFET Adopted in BBU for AI Servers as HVDC Architectures Advance* |
| Publication Event | 2026-06-03; publication time / timezone `Unknown` |
| Applicable Period | Anonymous-customer adoption announcement at publication |
| URL | [ROHM official source](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2026-06-03_news_sic-mosfet) |
| Source position | 2026-06-03 official news、BBU adoption announcement |
| Retrieval Date | 2026-08-09 |

## 2. Source Fact

ROHMは750V SiC MOSFET SCT4013DLLがAI-server power supply向けBBUの±400V power sectionに採用されたと発表する。

| Field | Value |
| --- | --- |
| Fact type | Issuer-reported anonymous-customer product adoption |
| Actual / Forecast | Issuer-reported anonymous-customer product adoption — 上流Inspectionの分類を変更しない |
| Unit | Product / voltage / application relation |
| Cross-sprint reference | No identical candidate in Accepted recheck sets |
| Related candidate boundary | Other adoption assertionsとcustomer / product / Source Eventが異なる |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |

## 3. 制約

- Customer / BBU maker identity、order、volume、shipment、revenue、production deployment及びexclusive supplyを確定しない。
- 上流Inspection及びAccepted RecheckのFact grain、Source Event、発言主体及び時点分類を変更しない。
- 同一Source Eventの別候補、既存Sprint Evidence又は関連candidateと結合して、新しい数値、因果、需要signal、commercial relation又は確度を作らない。
- Evidence / PIT ID、公開可能時刻、Catalog適格性又は下流利用権限を推測しない。
