# Microsoft — Data Center AI Demand and Server Dependency Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `MicrosoftRawEvidenceIndependentReview.v0.1-draft.md` |
| Authority Source | `Sprint003EvidenceNamespaceDecisionRecord.v0.1-draft.md` |
| Inspection Source | `MicrosoftSourceFactInspection.v0.1-draft.md` — `MSFT-SFI-001` |
| Evidence ID | `S3-EVR-001` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-001` |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-001`; Independent Review Accepted |

> **利用境界：** Microsoft固有のData Center運用依存関係を記録する。半導体需要量、購入額、供給者、Power Semiconductor又は業界全体の因果を確定しない。`AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *Microsoft 2025 Form 10-K* |
| 発行者 | Microsoft Corporation |
| Publication Event | SEC filed 2025-07-30; accepted 2025-07-30 16:11:40 ET |
| Applicable Period | FY ended 2025-06-30 / filing-date operating description |
| URL | [SEC filing](https://www.sec.gov/Archives/edgar/data/789019/000095017025100235/msft-20250630.htm) |
| Source position | Part I, Item 1, `Business → Operations` |
| Retrieval Date | 2026-07-30 |

## 2. Source Fact

Microsoftは、顧客ニーズ、特にAI services需要の増加を踏まえてData Center所在地及びserver capacityを調整していると記載する。またData Centerは、permitted and buildable land、predictable energy、networking supplies及びserversの供給に依存し、serversにはGPU及びother componentsが含まれると記載する。

| Field | Value |
| --- | --- |
| Fact type | Issuer narrative / operating dependency |
| Actual / Forecast | Filing-date operating description; Forecastではない |
| Unit | N/A |
| Cross-sprint reference | Stage 0 fixed examined set: no existing Microsoft match |
| AvailableAt | `TBD — no use` |

## 3. 制約

- GPU以外の`other components`を特定半導体製品へ展開しない。
- Server supply dependencyを購入量、売上又はshortageへ変換しない。
- Microsoftの関係を他社又は業界全体へ一般化しない。
