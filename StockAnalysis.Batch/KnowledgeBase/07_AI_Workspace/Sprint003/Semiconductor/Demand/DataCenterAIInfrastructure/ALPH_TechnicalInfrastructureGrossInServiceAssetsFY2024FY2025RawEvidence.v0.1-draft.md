# Alphabet — Technical Infrastructure Gross In-service Assets FY2024–FY2025 Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `AlphabetRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | Alphabet Inc. |
| Inspection Source | `AlphabetSourceFactInspection.v0.1-draft.md` — `ALPH-SFI-004` |
| Cross-sprint Recheck | `AlphabetCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-013` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-013`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-013`; Review Accepted |

> **利用境界：** `Property and equipment, in service`を構成するTechnical infrastructureのgross balanceを記録する。Technical infrastructure全体又はnet carrying amountではない。`AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *Alphabet 2025 Form 10-K* |
| Publication Event | SEC filed 2026-02-05; accepted 2026-02-04 21:56:03（SEC index表示。timezoneはページ上で別途明示されない） |
| Applicable Period | As of 2024-12-31 and 2025-12-31 |
| URL | [SEC filing](https://www.sec.gov/Archives/edgar/data/1652044/000165204426000018/goog-20251231.htm) |
| Source position | Note 7, `Property and Equipment, Net` |
| Retrieval Date | 2026-08-02 |

## 2. Source Fact

| As of | Technical infrastructure — gross in-service balance (USD million) |
| --- | ---: |
| 2024-12-31 | 141,852 |
| 2025-12-31 | 203,679 |

Alphabetは両時点で約60%がservers and network equipment、残余がdata center land and buildings and related assetsから構成されると注記する。

| Field | Value |
| --- | --- |
| Fact type | Direct quantitative observation / period-end gross in-service asset balance |
| Actual / Forecast | Actual balance; not net carrying amount |
| Unit | USD million、approximate composition % |
| Cross-sprint reference | No identical candidate in accepted recheck sets |
| AvailableAt | `TBD — no use` |

## 3. 制約

- `assets not yet in service`を含めない。
- 全社accumulated depreciationをTechnical infrastructureへ配賦してnet carrying amountを推定しない。
- 約60%をFY2025 CapEx構成60%と同一視せず、GPU / TPU又は半導体へ配賦しない。
