# Micron Technology — MU-SFI-063 Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted — Package review C/H/M/L = 0 |
| Review Record | `MicronRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | Micron Technology, Inc. |
| Inspection Source | `MicronSourceFactInspection.v0.1-draft.md` — `MU-SFI-063` |
| Cross-sprint Recheck | `MicronCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical Fact |
| Evidence / PIT ID | `S3-P2-EVR-054` issued — EVR Review Accepted / PIT not issued |

> **利用境界：** Module構成と測定値を保持し、system / rack power又はTCOへ変換しない。 `AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | Micron Technology, Inc., *Micron Redefines AI Performance With Sampling of 256GB DDR5 Server Module* |
| Publication Event | 2026-05-12 09:01 EDT |
| Applicable Period | Publication Event 2026-05-12 09:01 EDT時点で開示された比較 / test basis（Fact本文の条件に限定） |
| URL | [Official source](https://investors.micron.com/node/50471) |
| Source position | 2026-05-12 release, performance paragraphs |
| Retrieval Date | 2026-08-13 |
| Corroborating provenance | Micron Powers AI Everywhere at COMPUTEX 2026 (2026-06-01 18:00 EDT), https://investors.micron.com/news-releases/news-release-details/micron-powers-ai-everywhere-computex-2026 — corroboration-only |

## 2. Source Fact

256GB DDR5 RDIMMはtwo 128GB modules比40%超lower operating power（11.1W対19.4W）と説明される。

| Field | Value |
| --- | --- |
| Fact type / classification | Comparative-power assertion — 上流Inspectionの分類を変更しない |
| Upstream disposition | Proceed with caution |
| Cross-sprint reference | No identical Source identity / event / position / Fact in Accepted recheck |
| Related candidate boundary | Sample Fact owner `090` |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |

## 3. 制約

- Module構成と測定値を保持し、system / rack power又はTCOへ変換しない。
- 上流Inspection及びAccepted RecheckのFact grain、Source Event、期間、数値、製品・party対応及びclassificationを変更しない。
- Related candidate、same-event atomic Fact又はcorroborating Source Eventと結合し、新しい数値、因果、需要signal、commercial progression又は確度を作らない。
- Actual、Plan、Forecast、issuer expectation、Target、relationship、speaker assertion、simulation、run rate、illustration及びoperating policyを相互に置換しない。
- Evidence / PIT ID、AvailableAt、Canonicality、Catalog又は下流利用権限を推測しない。
