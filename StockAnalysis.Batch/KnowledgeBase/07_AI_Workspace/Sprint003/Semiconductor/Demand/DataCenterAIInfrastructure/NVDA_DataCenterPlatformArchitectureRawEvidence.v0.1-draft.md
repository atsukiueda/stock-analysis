# NVIDIA — Data Center Platform Architecture Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `NVIDIARawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | NVIDIA Corporation |
| Inspection Source | `NVIDIASourceFactInspection.v0.1-draft.md` — `NVDA-SFI-001` |
| Cross-sprint Recheck | `NVIDIACrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-021` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-021`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-021`; Review Accepted |

> **利用境界：** NVIDIAによるData Center platformの構成定義だけを記録する。売上内訳、BOM又は半導体需要量へ変換しない。`AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *NVIDIA Fiscal 2026 Form 10-K* |
| Publication Event | SEC filed 2026-02-25; accepted 2026-02-25 16:42:19（SEC index表示。timezoneはページ上で別途明示されない） |
| Applicable Period | FY ended 2026-01-25 / issuer definition as filed |
| URL | [SEC filing](https://www.sec.gov/Archives/edgar/data/1045810/000104581026000021/nvda-20260125.htm) |
| Source position | Part I, Item 1, `Data Center` |
| Retrieval Date | 2026-08-02 |

## 2. Source Fact

NVIDIAはData Center platformをcompute-intensive workloadsを加速するplatformと説明する。Compute / networking infrastructureはrack-scale systems、subsystems又はmodulesにsoftware / servicesを伴い、systemsはGPU、CPU、interconnect及びAI / HPC software等、networkingはNVLink、InfiniBand / Ethernet、adapters、cables、DPU並びにswitch chips / systems等を含む。

| Field | Value |
| --- | --- |
| Fact type | Issuer definition / platform architecture |
| Actual / Forecast | Definition; neither Actual nor Forecast |
| Unit | N/A |
| Cross-sprint reference | No identical candidate in accepted recheck sets |
| AvailableAt | `TBD — no use` |

## 3. 制約

- Data Center revenueをGPU単体又は半導体だけの売上とみなさない。
- 列挙要素を相互排他的な売上内訳、数量又はBOMへ変換しない。
- 個別componentと特定supplierの関係を推定しない。
