# Micron Technology — MU-SFI-075 Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted — Package review C/H/M/L = 0 |
| Review Record | `MicronRawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | Micron Technology, Inc. |
| Inspection Source | `MicronSourceFactInspection.v0.1-draft.md` — `MU-SFI-075` |
| Cross-sprint Recheck | `MicronCrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical Fact |
| Evidence / PIT ID | `S3-P2-EVR-066` issued — EVR Review Accepted / PIT not issued |

> **利用境界：** Test basisを保持し、GPU system、customer deployment又はuniversal benchmarkへ一般化しない。 `AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | Micron Technology, Inc., *Micron Sets New Benchmark With the World's First High-Capacity 256GB LPDRAM SOCAMM2 for Data Center Infrastructure* |
| Publication Event | 2026-03-03 09:00 EST |
| Applicable Period | Publication Event 2026-03-03 09:00 EST時点で開示された比較 / test basis（Fact本文の条件に限定） |
| URL | [Official source](https://investors.micron.com/news-releases/news-release-details/micron-sets-new-benchmark-worlds-first-high-capacity-256gb) |
| Source position | 2026-03-03 release, test paragraph |
| Retrieval Date | 2026-08-13 |
| Corroborating provenance | None recorded as a separate Fact owner; related candidates remain separate. |

## 2. Source Fact

Source-defined stand-alone CPU testで256GB SOCAMM2はcomparison configuration比2.3倍超のtime-to-first-token performanceを示す。

| Field | Value |
| --- | --- |
| Fact type / classification | Internal test / time-to-first-token assertion — 上流Inspectionの分類を変更しない |
| Upstream disposition | Proceed with caution |
| Cross-sprint reference | No identical Source identity / event / position / Fact in Accepted recheck |
| Related candidate boundary | Performance, not stage |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |

## 3. 制約

- Test basisを保持し、GPU system、customer deployment又はuniversal benchmarkへ一般化しない。
- 上流Inspection及びAccepted RecheckのFact grain、Source Event、期間、数値、製品・party対応及びclassificationを変更しない。
- Related candidate、same-event atomic Fact又はcorroborating Source Eventと結合し、新しい数値、因果、需要signal、commercial progression又は確度を作らない。
- Actual、Plan、Forecast、issuer expectation、Target、relationship、speaker assertion、simulation、run rate、illustration及びoperating policyを相互に置換しない。
- Evidence / PIT ID、AvailableAt、Canonicality、Catalog又は下流利用権限を推測しない。
