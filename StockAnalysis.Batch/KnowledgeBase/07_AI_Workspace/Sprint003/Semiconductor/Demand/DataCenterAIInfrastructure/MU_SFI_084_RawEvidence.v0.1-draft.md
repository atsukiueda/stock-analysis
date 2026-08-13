# Micron Technology — MU-SFI-084 Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted — Package review C/H/M/L = 0 |
| Review Record | `MicronRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | Micron Technology, Inc. |
| Inspection Source | `MicronSourceFactInspection.v0.1-draft.md` — `MU-SFI-084` |
| Cross-sprint Recheck | `MicronCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical Fact |
| Evidence / PIT ID | `S3-P2-EVR-075` issued — EVR Review Accepted / PIT not issued |

> **利用境界：** Tableのtest / configuration basisを保持し、random readを含むall-workload benchmark、customer result又はcommercial successへ一般化しない。 `AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | Micron Technology, Inc., *Micron 9650 SSD, the world's first PCIe Gen6 SSD, reaches a new shipping milestone!* |
| Publication Event | 2026-02-11; time / timezone Unknown |
| Applicable Period | Publication Event 2026-02-11時点で開示された比較 / test basis（Fact本文の条件に限定） |
| URL | [Official source](https://www.micron.com/about/blog/storage/ssd/micron-9650-ssd-the-worlds-first-pcie-gen6-ssd-reaches-a-new-shipping-milestone) |
| Source position | 2026-02-11 official product blog, performance table |
| Retrieval Date | 2026-08-13 |
| Corroborating provenance | None recorded as a separate Fact owner; related candidates remain separate. |

## 2. Source Fact

Micron 9650はsource-defined Gen5 comparisonに対して最大2倍のsequential read performanceを示す。

| Field | Value |
| --- | --- |
| Fact type / classification | Comparative-sequential-read-performance assertion — 上流Inspectionの分類を変更しない |
| Upstream disposition | Proceed with caution |
| Cross-sprint reference | No identical Source identity / event / position / Fact in Accepted recheck |
| Related candidate boundary | 2026-03-16 release corroborates |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |

## 3. 制約

- Tableのtest / configuration basisを保持し、random readを含むall-workload benchmark、customer result又はcommercial successへ一般化しない。
- 上流Inspection及びAccepted RecheckのFact grain、Source Event、期間、数値、製品・party対応及びclassificationを変更しない。
- Related candidate、same-event atomic Fact又はcorroborating Source Eventと結合し、新しい数値、因果、需要signal、commercial progression又は確度を作らない。
- Actual、Plan、Forecast、issuer expectation、Target、relationship、speaker assertion、simulation、run rate、illustration及びoperating policyを相互に置換しない。
- Evidence / PIT ID、AvailableAt、Canonicality、Catalog又は下流利用権限を推測しない。
