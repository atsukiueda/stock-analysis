# Micron Technology — MU-SFI-036 Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted — Package review C/H/M/L = 0 |
| Review Record | `MicronRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | Micron Technology, Inc. |
| Inspection Source | `MicronSourceFactInspection.v0.1-draft.md` — `MU-SFI-036` |
| Cross-sprint Recheck | `MicronCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical Fact |
| Evidence / PIT ID | `S3-P2-EVR-033` issued — EVR Review Accepted / PIT not issued |

> **利用境界：** Bandwidth単独因果又は反復一般則にしない。HBM容量、GPU FLOPs、tokens/sec及びsimulation projectionを保持し、Actual deployed performance、third-party benchmark、universal ratio又はrevenueへ変換しない。 `AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | Micron Technology, Inc., *Micron Powers AI Everywhere at COMPUTEX 2026* |
| Publication Event | 2026-06-01 18:00 EDT |
| Applicable Period | Publication Event 2026-06-01 18:00 EDT時点で開示された比較 / test basis（Fact本文の条件に限定） |
| URL | [Official source](https://investors.micron.com/news-releases/news-release-details/micron-powers-ai-everywhere-computex-2026) |
| Source position | 2026-06-01 release, HBM bullet / footnote 3 |
| Retrieval Date | 2026-08-13 |
| Corroborating provenance | None recorded as a separate Fact owner; related candidates remain separate. |

## 2. Source Fact

Micron internal simulationは、HBM4 288GB systemをHBM3E 288GB systemと比較し、GPU FLOPs 1.5倍かつbandwidth 2倍の一つの構成でLLM inference throughput（tokens/sec）が2.6倍になるとのprojectionを示す。

| Field | Value |
| --- | --- |
| Fact type / classification | Internal multi-factor system-simulation assertion — 上流Inspectionの分類を変更しない |
| Upstream disposition | Proceed with caution |
| Cross-sprint reference | No identical Source identity / event / position / Fact in Accepted recheck |
| Related candidate boundary | Performance, not product stage |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |

## 3. 制約

- Bandwidth単独因果又は反復一般則にしない。HBM容量、GPU FLOPs、tokens/sec及びsimulation projectionを保持し、Actual deployed performance、third-party benchmark、universal ratio又はrevenueへ変換しない。
- 上流Inspection及びAccepted RecheckのFact grain、Source Event、期間、数値、製品・party対応及びclassificationを変更しない。
- Related candidate、same-event atomic Fact又はcorroborating Source Eventと結合し、新しい数値、因果、需要signal、commercial progression又は確度を作らない。
- Actual、Plan、Forecast、issuer expectation、Target、relationship、speaker assertion、simulation、run rate、illustration及びoperating policyを相互に置換しない。
- Evidence / PIT ID、AvailableAt、Canonicality、Catalog又は下流利用権限を推測しない。
