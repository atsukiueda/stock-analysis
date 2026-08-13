# NVIDIA Raw Evidence Package — Independent Review

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft independent review record |
| Sprint | Sprint003 |
| Version | 0.1-draft |
| Review Date | 2026-08-02 |
| 対象 | NVIDIA Raw Evidence 12件 / `NVDA-SFI-001`–`011`、`013` |
| 状態 | Independent review completed — Accepted; Draft / noncanonical |

> **利用境界：** 本記録はRaw Evidence Packageの独立レビュー証跡である。Evidence / PIT ID発行、EVR / PIT登録、`AvailableAt`確定、Canonical化、Catalog又は下流利用を承認しない。

## 1. Reviewed Package

| Inspection ID | Raw Evidence | Final disposition |
| --- | --- | --- |
| `NVDA-SFI-001` | `NVDA_DataCenterPlatformArchitectureRawEvidence.v0.1-draft.md` | Accepted |
| `NVDA-SFI-002` | `NVDA_DataCenterRevenueFY2025RawEvidence.v0.1-draft.md` | Accepted |
| `NVDA-SFI-003` | `NVDA_DataCenterRevenueFY2026RawEvidence.v0.1-draft.md` | Accepted |
| `NVDA-SFI-004` | `NVDA_DataCenterRevenueQ1FY2027RawEvidence.v0.1-draft.md` | Accepted |
| `NVDA-SFI-005` | `NVDA_DataCenterReportingFrameworkFY2027RawEvidence.v0.1-draft.md` | Accepted |
| `NVDA-SFI-006` | `NVDA_DataCenterRevenueDriversFY2026RawEvidence.v0.1-draft.md` | Accepted |
| `NVDA-SFI-007` | `NVDA_SupplyCapacityObligationsFY2026RawEvidence.v0.1-draft.md` | Accepted |
| `NVDA-SFI-008` | `NVDA_DataCenterComponentConstraintRiskRawEvidence.v0.1-draft.md` | Accepted |
| `NVDA-SFI-009` | `NVDA_H20InventoryChargeFY2026RawEvidence.v0.1-draft.md` | Accepted |
| `NVDA-SFI-010` | `NVDA_ChinaDataCenterMarketAccessFY2026RawEvidence.v0.1-draft.md` | Accepted with context boundary |
| `NVDA-SFI-011` | `NVDA_RevenueOutlookQ2FY2027RawEvidence.v0.1-draft.md` | Accepted with context boundary |
| `NVDA-SFI-013` | `NVDA_DataCenterEnergyCapitalDependencyRawEvidence.v0.1-draft.md` | Accepted with context boundary |

`NVDA-SFI-012`はHoldのためRaw Evidenceを作成していない。

## 2. Reviewer Organization

| Reviewer persona | Review scope | Independence |
| --- | --- | --- |
| Evidence Validation Reviewer | 公式Source、数値、期間、Publication Event、Source position、分類、Fact忠実性 | 著者・承認者ではなく、対象ファイルを編集していない |
| Chief Knowledge Reviewer | 非同義化、非二重計上、測定scope、commitment、reporting transition、China及びPhase境界 | 著者・承認者ではなく、対象ファイルを編集していない |
| Traceability Reviewer | SFI一対一、Hold非作成、ID未発行、上流参照、状態、利用境界、参照実在性 | 著者・承認者ではなく、対象ファイルを編集していない |

## 3. Findings and Revisions

### FY2024 Sub-market Values

- FY2024 Compute / Networkingに公式値が存在するにもかかわらず`N/A`と表示されていた。
- Accepted `NVDA-SFI-002`が捕捉したFY2024 FactはData Center totalだけであるため、FY2024 totalを別表へ分離した。
- Compute / Networking値はAccepted scope外で本Rawに未収容であり、`Unknown`又は`N/A`ではないことを明記した。

### Commitment Boundary

- USD95.2bn obligationについて、shipment / revenue変換禁止と、Item 7のrelationを金額全体へ因果配賦しない境界が不足していた。
- Actual purchase、shipment及びrevenueへの変換を禁止し、Item 7のcustomer-demand forecast / lead-time relationをNote 12のUSD95.2bn全体へ因果又は金額配賦しないことを明記した。

### PIT Routing with Unknown Publication Event

- Publication Event未確定をPIT登録禁止と読める表現があった。
- PIT行作成自体は禁止せず、`AvailableAt = TBD — no use`、Catalog Eligibility `No`、時系列・Catalog・下流利用禁止を維持する表現へ修正した。

## 4. Final Re-review

| Review scope | Critical | High | Medium | Low | Reviewer conclusion |
| --- | ---: | ---: | ---: | ---: | --- |
| Evidence | 0 | 0 | 0 | 0 | Accepted |
| Knowledge | 0 | 0 | 0 | 0 | Accepted |
| Traceability | 0 | 0 | 0 | 0 | Accepted |

## 5. Final Disposition

**Disposition: Accepted**

12件はNVIDIA Draft Raw Evidence Packageとして受理する。`NVDA-SFI-010`、`011`及び`013`はcontext限定を維持する。Evidence ID `S3-EVR-021`–`032`及びPIT ID `S3-PIT-021`–`032`は一対一登録・独立レビューAcceptedである。

受理後も全件はDraft・noncanonical、`AvailableAt = TBD — no use`、Catalog Eligibility `No`であり、EVR登録後の独立レビュー受理なしにPITへ進めない。
