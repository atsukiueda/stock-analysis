# NVIDIA Source Fact Inspection — Independent Review

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft independent review record |
| Sprint | Sprint003 |
| Version | 0.1-draft |
| Review Date | 2026-08-02 |
| 対象 | `NVIDIASourceFactInspection.v0.1-draft.md` — `NVDA-SFI-001`–`NVDA-SFI-013` |
| 状態 | Independent review completed — Accepted; Draft / noncanonical |

> **利用境界：** 本記録はSource Fact Inspectionの独立レビュー証跡である。Raw Evidence採用、Evidence / PIT ID発行、`AvailableAt`確定、Canonical化、Catalog又は下流利用を承認しない。

## 1. Reviewer Organization

| Reviewer persona | Review scope | Independence |
| --- | --- | --- |
| Evidence Validation Reviewer | 公式Source、数値、期間、Publication Event、Source position、分類、測定境界 | 著者・承認者ではなく、対象ファイルを編集していない |
| Chief Knowledge Reviewer | Knowledge Base First、非同義化、推論境界、Relationship分類、commitment scope | 著者・承認者ではなく、対象ファイルを編集していない |
| Traceability Reviewer | Local ID、件数、Cross-sprint、参照、ID未発行、次ゲート | 著者・承認者ではなく、対象ファイルを編集していない |

## 2. Reviewed Package

| Candidate range | Count | Preliminary disposition |
| --- | ---: | --- |
| `NVDA-SFI-001`–`NVDA-SFI-013` | 13 | Proceed 9 / Proceed with caution 3 / Hold 1 |

Excluded transformationは10件である。`NVDA-SFI-xxx`はLocal inspection IDであり、Evidence ID又はPIT IDではない。

## 3. Findings and Revisions

### Evidence Review

- 公式一次資料4件に対して数値、対象期間、Source position、Actual / Definition / Transition / Commitment / Risk / Forecast分類を照合した。
- Publication time又はtimezoneを確認できないeventは`Unknown`のまま保持され、推測による補完はない。
- 新規findingなし。

### Knowledge Findings

- **High:** `NVDA-SFI-007`のUSD95.2bnがData Center専用commitmentと読まれる余地があった。
- **Revision:** 連結ベースのoutstanding inventory purchase and long-term supply / capacity obligationsであることを明示し、Data Center専用commitment、Data Center CapEx、半導体発注額又は個別構成への配賦を禁止した。
- **Medium:** Item 7の`inventory and capacity purchase commitments`とNote 12のUSD95.2bn obligation classをRelationship edgeで暗黙に同一化する余地があった。
- **Revision:** edgeをItem 7の発行者説明へ限定し、両classの同一性・完全対応、金額への因果配賦及びData Center専用帰属を未確定とした。

### Traceability Review

- Local ID 13件は一意で欠番・重複なし。
- Proceed 9、Proceed with caution 3、Hold 1、Excluded 10の集計は本文と一致。
- 公式URL、上流設計及びStage 0参照に不整合はない。
- Evidence / PIT IDは未発行であり、Raw Evidence、`AvailableAt`、Catalog及び下流利用は許可されていない。

## 4. Final Re-review

| Review scope | Critical | High | Medium | Low | Final disposition |
| --- | ---: | ---: | ---: | ---: | --- |
| Evidence | 0 | 0 | 0 | 0 | Accepted |
| Knowledge | 0 | 0 | 0 | 0 | Accepted |
| Traceability | 0 | 0 | 0 | 0 | Accepted |

## 5. Final Disposition

**Disposition: Accepted**

本InspectionはNVIDIAのDraft Source Fact候補検査として受理する。Proceed 9件及びProceed with caution 3件は、各Source Factと利用境界を維持して候補別Cross-sprint recheckへ進める。Hold 1件はRaw Evidence化しない。

受理後も本文書はDraft・noncanonicalである。Candidate-level Cross-sprint recheck、Raw Evidence化、Raw独立レビュー、Evidence Register、PITの順序を維持し、全件`AvailableAt = TBD — no use`、Catalog Eligibility `No`とする。
