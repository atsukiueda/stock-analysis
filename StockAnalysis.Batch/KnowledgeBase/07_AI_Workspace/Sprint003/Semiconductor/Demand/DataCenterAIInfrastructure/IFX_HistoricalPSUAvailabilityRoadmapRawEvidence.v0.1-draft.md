# Infineon Technologies — Historical PSU Availability Roadmap Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `InfineonRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | Infineon Technologies AG |
| Inspection Source | `InfineonSourceFactInspection.v0.1-draft.md` — `IFX-SFI-044` |
| Cross-sprint Recheck | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-132` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-132`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-132`; PIT Review Accepted |

> **利用境界：** Source-exactな製品別timingを保持する。2024 Source Event時点のPlanであり、後続availability Actualへ遡及変換しない。`027`の3 / 3.3 kW current productsと分離する。 `AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | Infineon Technologies AG, *Fourth Quarter FY 2024 Investor Presentation* and *AI data-center PSU roadmap* |
| Publication Event | 2024-11-12 / 2024-05-24; publication time / timezone `Unknown` |
| Applicable Period | Q1 / Q2 2025 and 2026 Plan as of 2024 |
| URL | [Infineon official Q4 presentation](https://www.infineon.com/content/dam/infineon/row/public/documents/corporate/investors/presentations/2024/2024-11-12-q4-fy24-investor-presentation-v01-00-en.pdf); [official roadmap release](https://www.infineon.com/press-release/2024/infpss202405-105) |
| Source position | Q4 FY2024 presentation p.50 and 2024-05-24 release |
| Retrieval Date | 2026-08-09 |

## 2. Source Fact

8 kWは`Available in Q1/25`、12 kWは`Available in Q2/25`、12 kW超は`Available in 26`と表示される。2024-05-24 releaseは8 kWのQ1 2025 availability Planをcorroborateする。

| Field | Value |
| --- | --- |
| Fact type | Product availability Plan / roadmap |
| Actual / Forecast | Product availability Plan / roadmap — 上流Inspectionの分類を変更しない |
| Unit | kW / quarter / year |
| Cross-sprint reference | No identical candidate in Accepted recheck sets |
| Related candidate boundary | Q1 FY2026 / 2026 releaseとcross-event stage reconciliation required |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |

## 3. 制約

- Source-exactな製品別timingを保持する。2024 Source Event時点のPlanであり、後続availability Actualへ遡及変換しない。`027`の3 / 3.3 kW current productsと分離する。
- 上流Inspection及びAccepted RecheckのFact grain、Source Event、発言主体、期間、製品・board type対応及び時点分類を変更しない。
- 同一Source Eventの別候補、corroborating Source Event、既存Sprint Evidence又は関連candidateと結合して、新しい数値、因果、需要signal、commercial relation又は確度を作らない。
- Actual、Plan、Forecast、Target、indication、estimate、scenario、relationship及びapplication definitionを相互に置換しない。
- Evidence / PIT ID、公開可能時刻、Catalog適格性又は下流利用権限を推測しない。
