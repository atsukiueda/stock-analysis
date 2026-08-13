# Alphabet — AI-optimized Infrastructure and Accelerators Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `AlphabetRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | Alphabet Inc. |
| Inspection Source | `AlphabetSourceFactInspection.v0.1-draft.md` — `ALPH-SFI-001` |
| Cross-sprint Recheck | `AlphabetCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-010` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-010`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-010`; Review Accepted |

> **利用境界：** AlphabetのAI infrastructure architecture及びaccelerator optionsを記録する。GPU / TPU数量、購入額、外部調達比率、半導体需要又は供給者別売上を確定しない。`AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *Alphabet 2025 Form 10-K* |
| Publication Event | SEC filed 2026-02-05; accepted 2026-02-04 21:56:03（SEC index表示。timezoneはページ上で別途明示されない） |
| Applicable Period | FY ended 2025-12-31 / filing-date operating architecture description |
| URL | [SEC filing](https://www.sec.gov/Archives/edgar/data/1652044/000165204426000018/goog-20251231.htm) |
| Source position | Part I, Item 1, AI / technical infrastructure description |
| Retrieval Date | 2026-08-02 |

## 2. Source Fact

Alphabetはfull-stack AI approachの基盤をAI-optimized infrastructureと説明し、Google Cloud顧客へspecialized Graphics Processing Units（GPUs）及び自社custom-built Tensor Processing Units（TPUs）を含むAI accelerator optionsを提供すると記載する。

| Field | Value |
| --- | --- |
| Fact type | Issuer narrative / operating architecture |
| Actual / Forecast | Filing-date description; quantitative Actual / Forecastではない |
| Unit | N/A |
| Cross-sprint reference | No identical candidate in accepted recheck sets |
| AvailableAt | `TBD — no use` |

## 3. 制約

- AI-optimized infrastructure、technical infrastructure、Data Center、GPU及びTPUを同義化しない。
- Accelerator optionの列挙を購入量、稼働量、市場share又は半導体需要へ変換しない。
- 本Factを`ALPH-SFI-006`の供給risk Factとして重複登録しない。
