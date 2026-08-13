# Renesas — Anonymous Customer AI Board Power Solution Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `RenesasRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | Renesas Electronics Corporation |
| Inspection Source | `RenesasSourceFactInspection.v0.1-draft.md` — `REN-SFI-017` |
| Cross-sprint Recheck | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-044` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-044`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-044`; Review Accepted |

> **利用境界：** 匿名顧客boardとのissuer-asserted direct product relationshipだけを記録する。Named-customer adoption又はcommercial Actualへ変換しない。`AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *AI Infra and Compute — 2026 Capital Market Day*; *2026 Capital Market Day Presentation, Minutes and Q&A — 2nd Half* |
| Publication Event | Event / document date 2026-06-25; publication time / timezone `Unknown` |
| Applicable Period | Current issuer assertion at event date |
| URL | [Official deck](https://www.renesas.com/en/document/ppt/ai-infra-and-compute-2026-capital-market-day); [Official prepared remarks](https://www.renesas.com/en/document/ppt/2026-capital-market-day-presentation-minutes-and-qa-2nd-half) |
| Source position | Deck slide 7 / PDF p.7（viewer P6）; prepared remarks PDF pp.34–35（viewer P33–P34） |
| Retrieval Date | 2026-08-02 |

## 2. Source Fact

Renesasは、leading next-generation AI boardの例でdigital multiphase core power、IBC及びMOSFETを含むtotal power solutionを提供し、そのperformanceを`our customer`が当該boardで測定したと説明する。Slide上の構成例は次のとおりである。

| Example solution | Source-presented illustrative content |
| --- | --- |
| 48V IBC solution | `>5 Digital controllers`、`>30 MOSFETs` |
| GPU Power solution | `>10 Digital controllers`、`>100 Smart power stages` |

| Field | Value |
| --- | --- |
| Fact type | Issuer assertion / anonymous customer-board direct product relationship |
| Actual / Forecast | Current issuer assertion; commercial Actualは未確認 |
| Unit | Illustrative component counts; universal measureではない |
| Cross-sprint reference | No identical candidate in accepted recheck sets |
| AvailableAt | `TBD — no use` |

## 3. 制約

- Customer / board identity、test condition、adoption stage、order、shipment、revenue又はproduction deploymentを確定しない。
- `our customer`の測定を第三者独立検証済みbenchmarkとみなさない。
- 比較演算子`>`、製品名及び各solutionとの対応を維持し、component countsをuniversal BOM、market average又は需要量へ一般化しない。
- 同じslideのgeneral rack-power scenarioは`REN-SFI-009`の別Rawへ分離する。
