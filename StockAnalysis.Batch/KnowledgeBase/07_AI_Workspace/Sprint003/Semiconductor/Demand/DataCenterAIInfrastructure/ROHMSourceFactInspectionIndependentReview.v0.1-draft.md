# ROHM Source Fact Inspection — Independent Review

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft independent review record |
| Sprint | Sprint003 |
| Version | 0.1-draft |
| Review Date | 2026-08-09 |
| 対象 | `ROHMSourceFactInspection.v0.1-draft.md` — `ROHM-SFI-001`–`ROHM-SFI-062` |
| 状態 | Independent review completed — Accepted; Draft / noncanonical |

> **利用境界：** 本記録はSource Fact Inspectionの独立レビュー証跡である。Raw Evidence採用、Evidence / PIT ID発行、`AvailableAt`確定、Canonical化、Catalog / DDL / ML利用を承認しない。

## 1. Reviewer Organization

| Reviewer persona | Review scope | Independence |
| --- | --- | --- |
| Evidence Validation Reviewer | 公式一次資料、数値、期間、Source position、Publication Event、Actual / Plan / Forecast / Scenario / Simulation分類 | 著者・承認者ではなく、対象ファイルを編集していない |
| Chief Knowledge Reviewer | Knowledge Base First、Source completeness、Fact grain、非同義化、用途配賦禁止、Relationship、Gap | 著者・承認者ではなく、対象ファイルを編集していない |
| Traceability Reviewer | Local ID、件数、Source locator、既存Evidence参照、Gate順序、Evidence / PIT未発行、利用境界 | 著者・承認者ではなく、対象ファイルを編集していない |

## 2. Reviewed Package

| Candidate range | Count | Final preliminary disposition |
| --- | ---: | --- |
| `ROHM-SFI-001`–`ROHM-SFI-062` | 62 | Reference existing evidence only 4 / Proceed 11 / Proceed with caution 36 / Hold 11 |

Raw-eligibleはProceed及びProceed with cautionの47件である。Excluded transformationは16件である。`ROHM-SFI-xxx`はLocal inspection IDであり、Evidence ID又はPIT IDではない。

## 3. Review Findings and Resolution

独立レビューは、問題を発見する目的で複数回実施した。初回及び中間レビューで検出した主要論点と最終的な解消内容を以下に記録する。

| Review area | Finding | Resolution |
| --- | --- | --- |
| Official Source completeness | Cut-off以前のAI server、Data Center、GaN、SiC、MOSFET、named-party関係の公式資料が不足していた | FY2021–FY2025及び最新開示を再探索し、2021–2026年の関連公式Source Eventを追加した |
| Cut-off identity | Dynamic web pageの存在はcut-off以前に確認できたが、2026-08-09取得本文との版同一性を証明できなかった | `ROHM-SFI-012`及び`020`–`025`をHoldとし、Raw対象から除外した |
| Publication Event | FY2024 Results、white paper及びNVIDIA関連newsの日付・slug差に確認事項があった | 公式PDF表紙又は公式page表示日へ同期し、slug差は明示した。時刻・timezoneは推測していない |
| Fact grain | Actual、Plan、Forecast、Target、Scenario、Simulation、application definition、relationshipが複合した候補があった | Production、application、partnership、development、mass-production Plan、market illustration等をatomic candidateへ分割した |
| Anonymous-party identity | 複数Source Eventの匿名cloud provider assertionを同一party又は相互corroborationと読める構造があった | Source Event別の独立issuer assertionとし、party同一性及びcommercial adoptionを未確認とした |
| Attribution | Delta及びMurata発言のspeaker精度が不足していた | 組織、氏名及びroleを公式Sourceに従って固定した。`ROHM-SFI-059`はDr. Longcheng Tanのcustomer-stage assertionとして保持した |
| Relationship | Broader collaborationと個別product-incorporation Planが再結合される箇所があった | Issuer-defined edge、named external participant edge、product-stage edgeを分離した |
| Temporal classification | Future lineup expansionをcurrent application / availabilityと読める候補があった | `ROHM-SFI-060`をFuture expansion Plan / intended application scopeとしてcautionへ再分類した |
| Direct production evidence | 2022-03-22の150V GaN HEMT production commencementが後続Sourceだけで表現されていた | `ROHM-SFI-061`をproduction Actual、`ROHM-SFI-062`をapplication definitionとして追加し、後続のproduction-system Factと分離した |
| Gate control | 候補件数、Disposition、Raw eligibility及びID発行境界を修正後に再照合する必要があった | 001–062の一意・連続性、4 + 11 + 36 + 11 = 62、Raw-eligible 47、Excluded 16を三者が再確認した |

## 4. Final Re-review

| Review scope | Critical | High | Medium | Low | Final disposition |
| --- | ---: | ---: | ---: | ---: | --- |
| Evidence | 0 | 0 | 0 | 0 | Accepted |
| Knowledge | 0 | 0 | 0 | 0 | Accepted |
| Traceability | 0 | 0 | 0 | 0 | Accepted |

最終再レビューでは、公式Sourceへの忠実性、Source completeness、cut-off eligibility、Fact grain、classification、Relationship、Gap、候補件数、Disposition、Source locator及びGate順序に残存Findingはなかった。

## 5. Final Disposition

**Disposition: Accepted**

`ROHMSourceFactInspection.v0.1-draft.md`をROHMのDraft Source Fact Inspectionとして受け入れる。

- Reference-only 4件は既存Evidenceを参照し、Sprint003で再発行しない。
- Proceed 11件及びProceed with caution 36件の合計47件だけをcandidate-level Cross-sprint recheckへ進める。
- Hold 11件はRaw Evidence化しない。
- Excluded transformation 16件は禁止変換として維持する。
- Cross-sprint recheck Accepted後にのみ、一候補一FactのRaw Evidence Draftを作成できる。
- Evidence / PIT IDは各レビューGate前に発行しない。
- 全件 `AvailableAt = TBD — no use`、Catalog Eligibility `No`を維持する。

本DispositionはSource Fact Inspection gateの受入れであり、Canonical化、Catalog登録、DDL又はML利用の承認ではない。
