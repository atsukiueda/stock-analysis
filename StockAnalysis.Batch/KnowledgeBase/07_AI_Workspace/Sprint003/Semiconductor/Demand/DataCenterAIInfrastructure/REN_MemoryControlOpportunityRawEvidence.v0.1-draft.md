# Renesas — Memory Interface / Control Opportunity Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `RenesasRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | Renesas Electronics Corporation |
| Inspection Source | `RenesasSourceFactInspection.v0.1-draft.md` — `REN-SFI-012` |
| Cross-sprint Recheck | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-040` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-040`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-040`; Review Accepted |

> **利用境界：** Memory Interface及びMCU-based controlに関するmanagement thesisと構成例だけを記録する。Actual需要又はBOMへ変換しない。`AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *AI Infra and Compute — 2026 Capital Market Day* |
| Publication Event | Document / event date 2026-06-25; publication time / timezone `Unknown` |
| Applicable Period | Forward-looking product opportunity context |
| URL | [Official document page](https://www.renesas.com/en/document/ppt/ai-infra-and-compute-2026-capital-market-day) |
| Source position | PDF slide 10, Memory Interface and Control Plane |
| Retrieval Date | 2026-08-02 |

## 2. Source Fact

RenesasはAI inferenceがCPU及びDRAM需要を促し、memory-interface contentを増加させるとの見方と、MCU-based controlの採用が拡大するとの見方を示す。資料はmemory module / board上の製品構成例も提示する。

| Field | Value |
| --- | --- |
| Fact type | Management strategy / illustrative product-content relationship |
| Actual / Forecast | Management thesis / example; Actualではない |
| Unit | N/A — 本Rawはslide上のexample component countsを数量Observationとして採用しない |
| Cross-sprint reference | No identical candidate in accepted recheck sets |
| AvailableAt | `TBD — no use` |

## 3. 制約

- CPU / DRAM需要からRenesas shipment、attach rate又はrevenueを推定しない。
- 製品構成例は存在contextだけを保持し、個数を本Rawの数量Factとして採用しない。Universal BOM、customer configuration又はActual unit demandへ変換しない。
- `REN-SFI-007`のgrowth-driver relationshipと独立Factとして保持し、二重計上又は因果chain化しない。
