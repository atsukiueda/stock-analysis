# Renesas — AI Infrastructure Grid-to-Core Portfolio Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `RenesasRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | Renesas Electronics Corporation |
| Inspection Source | `RenesasSourceFactInspection.v0.1-draft.md` — `REN-SFI-006` |
| Cross-sprint Recheck | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-035` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-035`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-035`; Review Accepted |

> **利用境界：** Renesasが示すgrid-to-core product / architecture mapだけを記録する。Sales、shipment、adoption又はBOMへ変換しない。`AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *AI Infra and Compute — 2026 Capital Market Day* |
| Publication Event | Document / event date 2026-06-25; publication time / timezone `Unknown` |
| Applicable Period | Current and mid-to-long-term portfolio strategy |
| URL | [Official document page](https://www.renesas.com/en/document/ppt/ai-infra-and-compute-2026-capital-market-day) |
| Source position | PDF slides 2, 5–6; portfolio at-a-glance and grid-to-core power-delivery maps |
| Retrieval Date | 2026-08-02 |

## 2. Source Fact

RenesasはAI infrastructure向けportfolioを、grid、ESS / UPS、PSU、rack、xPU board及びcore powerまでのpower-delivery pathに沿って示す。Sourceはphaseを次の二つに分ける。

| Source-labeled phase | Subfact |
| --- | --- |
| Slide 5 `PORTFOLIO (TODAY)` | 発行者がTodayと表示するgrid-to-core portfolio map。Digital Power、Memory Interface、Control Plane及び関連analog productsを各stageへ配置する。 |
| Slide 6 `PORTFOLIO (MID-TO-LONG TERM)` | 発行者がMid-to-Long-Termと表示する将来portfolio map。同じpower-delivery path上の将来product positioningを示す。 |

二つのmapは同じissuer-defined architecture groupとして保持するが、phase間の製品配置を統合しない。

| Field | Value |
| --- | --- |
| Fact type | Issuer product / architecture definition |
| Actual / Forecast | Issuer-labeled Today definition + Mid-to-Long-Term portfolio strategy; sales Actual又はquantified Forecastではない |
| Unit | N/A |
| Cross-sprint reference | No identical candidate in accepted recheck sets |
| AvailableAt | `TBD — no use` |

## 3. 制約

- 列挙製品を相互排他的な売上内訳、数量又はuniversal BOMへ変換しない。
- Mid-to-Long-Term掲載をcurrent availability、shipment、design-in又はcommercial adoptionとみなさない。
- Today掲載もproduct availability、customer adoption、design win、shipment又はmarket shareのActual証拠とみなさない。
- Grid-to-core各段階を同時採用される一つのcommercial solutionと推定しない。
