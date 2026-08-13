# NVIDIA — Supply and Capacity Obligations FY2026 Raw Evidence

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft raw evidence |
| Version | 0.1-draft |
| 状態 | Draft only — Independent Review Accepted; noncanonical |
| Reviewer Status | Accepted |
| Review Record | `NVIDIARawEvidenceIndependentReview.v0.1-draft.md` |
| Issuer | NVIDIA Corporation |
| Inspection Source | `NVIDIASourceFactInspection.v0.1-draft.md` — `NVDA-SFI-007` |
| Cross-sprint Recheck | `NVIDIACrossSprintCandidateRecheck.v0.1-draft.md` — Accepted; no identical candidate |
| Evidence ID | `S3-EVR-027` |
| Evidence Registration Status | Registered — `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` / `S3-EVR-027`; EVR Review Accepted |
| PIT Mapping Status | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-027`; Review Accepted |

> **利用境界：** 連結ベースのobligationと発行者のordering-horizon説明を記録する。Data Center専用額、CapEx又はActual購入へ変換しない。`AvailableAt = TBD — no use`、Catalog Eligibility `No`。

## 1. 一次資料

| 項目 | 内容 |
| --- | --- |
| 資料名 | *NVIDIA Fiscal 2026 Form 10-K* |
| Publication Event | SEC filed 2026-02-25; accepted 2026-02-25 16:42:19（timezoneはページ上で別途明示されない） |
| Applicable Period | Balance as of 2026-01-25 / FY2026 discussion |
| URL | [SEC filing](https://www.sec.gov/Archives/edgar/data/1045810/000104581026000021/nvda-20260125.htm) |
| Source position | Note 12, `Commitments`; Part II, Item 7, inventory and capacity purchase commitments discussion |
| Retrieval Date | 2026-08-02 |

## 2. Source Fact

2026-01-25時点のoutstanding inventory purchase and long-term supply and capacity obligationsは連結ベースでUSD95.2bnで、substantially allがFY2027までに支払われると記載される。Note 12ではdatacenter-scale productionとcurrent / future product architecturesにわたる長いordering horizonsを反映すると説明する。Item 7ではinventory and capacity purchase commitmentsは将来のcustomer demand予測に基づき、manufacturing lead timesその他のconstraintsを考慮すると説明する。

| Field | Value |
| --- | --- |
| Fact type | Direct quantitative observation / Consolidated obligation with issuer narrative |
| Actual / Forecast | Commitment / obligation; not Actual purchase or Forecast revenue |
| Amount | USD95.2bn |
| Cross-sprint reference | No identical candidate in accepted recheck sets |
| AvailableAt | `TBD — no use` |

## 3. 制約

- USD95.2bn全額をData Center専用commitment、Data Center CapEx又は半導体発注額とみなさない。
- `datacenter-scale production`は100% Data Center帰属を意味しない。
- Note 12のobligation classとItem 7のcommitment classの同一性・完全対応を確定しない。
- Commitment / obligationをActual purchase、shipment又はrevenueへ変換しない。
- Item 7のcustomer-demand forecast / lead-time relationを、Note 12のUSD95.2bn全体への因果又は金額配賦として扱わない。
- GPU、wafer、memory、networking又は個別supplierへ配賦しない。
