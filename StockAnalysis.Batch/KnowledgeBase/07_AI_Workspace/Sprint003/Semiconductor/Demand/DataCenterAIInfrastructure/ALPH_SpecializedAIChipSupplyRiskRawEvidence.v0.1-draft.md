# Alphabet — Specialized AI Chip Supply Risk Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `AlphabetRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | Alphabet Inc. |
| Inspection Source | `AlphabetSourceFactInspection.v0.1-draft.md` — `ALPH-SFI-006` |
| Cross-sprint Recheck | `AlphabetCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-015` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-015`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-015`; Review Accepted |

> **利用境界：** 発行者のspecialized AI chip supply riskを記録する。Actual shortage、発注量、supplier identity、発生確率又は売上影響額を確定しない。`AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *Alphabet 2025 Form 10-K* |
| Publication Event | SEC filed 2026-02-05; accepted 2026-02-04 21:56:03（SEC index表示。timezoneはページ上で別途明示されない） |
| Applicable Period | FY ended 2025-12-31 / filing-date risk disclosure |
| URL | [SEC filing](https://www.sec.gov/Archives/edgar/data/1652044/000165204426000018/goog-20251231.htm) |
| Source position | Part I, Item 1A, manufacturing and supply-chain risk discussion |
| Retrieval Date | 2026-08-02 |

## 2. Source Fact

Alphabetはtechnical infrastructure向けservers and network equipment、特にspecialized AI chipsの製造・供給が少数のqualified suppliersに限られると記載する。これらsupplierの長期又は予期しないdisruptionはcustomer demandへの対応能力へ影響し得ると説明する。

| Field | Value |
| --- | --- |
| Fact type | Issuer narrative / operating dependency and risk |
| Actual / Forecast | Risk disclosure; realized shortage又はForecastではない |
| Unit | N/A |
| Cross-sprint reference | No identical candidate in accepted recheck sets |
| AvailableAt | `TBD — no use` |

## 3. 制約

- Risk disclosureを実際のshortage、将来発生又は数量制約として扱わない。
- Supplier数、identity、purchase share又は特定企業売上を推定しない。
- GPU / TPU optionsの定義は`ALPH_AIOptimizedInfrastructureAcceleratorsRawEvidence.v0.1-draft.md`へ委ね、本Factで重複登録しない。
