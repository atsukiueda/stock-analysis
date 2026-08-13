# Microsoft Raw Evidence Package — Independent Review

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft independent review record |
| Sprint | Sprint003 |
| Version | 0.1-draft |
| Review Date | 2026-07-30 |
| 対象 | Microsoft Raw Evidence `S3-EVR-001`–`S3-EVR-009` |
| 状態 | Independent review completed — Accepted; Draft / noncanonical |

> **利用境界：** 本記録はRaw Evidenceの独立レビュー証跡である。EVR登録、PIT ID発行、`AvailableAt`確定、Canonical化、Catalog又は下流利用を承認しない。

## 1. Reviewed Package

| Evidence ID | Inspection source | Raw Evidence | Final disposition |
| --- | --- | --- | --- |
| `S3-EVR-001` | `MSFT-SFI-001` | `MSFT_DataCenterAIDemandServerDependencyRawEvidence.v0.1-draft.md` | Accepted |
| `S3-EVR-002` | `MSFT-SFI-002` | `MSFT_PropertyEquipmentAdditionsFY2023FY2025RawEvidence.v0.1-draft.md` | Accepted |
| `S3-EVR-003` | `MSFT-SFI-003` | `MSFT_DataCenterConstructionCommitmentsFY2025RawEvidence.v0.1-draft.md` | Accepted |
| `S3-EVR-004` | `MSFT-SFI-004` | `MSFT_DataCenterPurchaseCommitmentsFY2025RawEvidence.v0.1-draft.md` | Accepted |
| `S3-EVR-005` | `MSFT-SFI-005` | `MSFT_CloudAIInfrastructureCapitalPlanFY2025RawEvidence.v0.1-draft.md` | Accepted |
| `S3-EVR-006` | `MSFT-SFI-006` | `MSFT_PropertyEquipmentAdditionsFY2026Q3RawEvidence.v0.1-draft.md` | Accepted |
| `S3-EVR-007` | `MSFT-SFI-007` | `MSFT_AIInfrastructureMarginComputeCapacityFY2026Q3RawEvidence.v0.1-draft.md` | Accepted |
| `S3-EVR-008` | `MSFT-SFI-008` | `MSFT_CloudDemandMetricsFY2026Q3RawEvidence.v0.1-draft.md` | Accepted |
| `S3-EVR-009` | `MSFT-SFI-009` | `MSFT_CloudAIInfrastructureDemandCapexFY2024RawEvidence.v0.1-draft.md` | Accepted |

`MSFT-SFI-010`はHoldであり、本Packageへ含めていない。

## 2. Reviewer Organization

| Reviewer persona | Scope | Independence |
| --- | --- | --- |
| Evidence Validation Reviewer | 公式正本、数値、Source position、Publication Event、分類 | 著者・承認者ではなく、ファイル編集を実施していない |
| Chief Knowledge Reviewer | Microsoft固有Fact、非同義化、禁止変換、推論境界 | 著者・承認者ではなく、ファイル編集を実施していない |
| Traceability Reviewer | SFI / EVR対応、PIT未発行、EVR未登録、状態 | 著者・承認者ではなく、ファイル編集を実施していない |

## 3. Findings and Revisions

### Initial Findings

- 未作成PIT行へ`S3-PIT-001`–`009`を先行発行しており、dangling identityとなっていた。
- EVR row未作成であるEvidence Registration Statusが不足していた。
- 6件でIssuer fieldが不足していた。
- `S3-EVR-007`でFY2026 Q3 earnings event dateとPerformance page固有publication eventが混在していた。
- `S3-EVR-003`及び`004`の見出しだけでは`primarily related to datacenters`の限定が落ちる可能性があった。

### Applied Revisions

- PIT IDをすべて未発行へ戻し、EVR独立レビュー受理後に一対一PITを作成するPending状態へ変更。
- 全9件にEvidence Registration Status `Pending — EVR row not yet created`を追加。
- 全9件にIssuer `Microsoft Corporation`を明示。
- Earnings event contextとPerformance page publication event `Unknown`を分離。
- `S3-EVR-003`及び`004`のArtifact titleに`Primarily Data Center-related`を反映。

### Final Re-review

| Review scope | Critical | High | Medium | Low | Final disposition |
| --- | ---: | ---: | ---: | ---: | --- |
| Evidence | 0 | 0 | 0 | 0 | Accepted |
| Knowledge | 0 | 0 | 0 | 0 | Accepted |
| Traceability | 0 | 0 | 0 | 0 | Accepted |

## 4. Final Disposition

**Disposition: Accepted**

9件は、各Source Fact及び利用境界を維持してEVR登録へ進める。EVR独立レビュー受理後、全EVRに一対一対応するPIT行を作成し、その時点でPIT IDを発行する。

全件について、`AvailableAt = TBD — no use`、Catalog Eligibility `No`及びnoncanonicalを維持する。
