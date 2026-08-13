# Renesas Electronics Source Fact Inspection — Independent Review

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft independent review record |
| Sprint | Sprint003 |
| Version | 0.1-draft |
| Review Date | 2026-08-02 |
| 対象 | `RenesasSourceFactInspection.v0.1-draft.md` — `REN-SFI-001`–`REN-SFI-019` |
| 状態 | Independent review completed — Accepted; Draft / noncanonical |

> **利用境界：** 本記録はSource Fact Inspectionの独立レビュー証跡である。Raw Evidence採用、Evidence / PIT ID発行、`AvailableAt`確定、Canonical化、Catalog又は下流利用を承認しない。

## 1. Reviewer Organization

| Reviewer persona | Review scope | Independence |
| --- | --- | --- |
| Evidence Validation Reviewer | 公式一次資料、数値、期間、Source position、Publication Event、Actual / Plan / Forecast / Scenario分類及びmixed scope | 著者・承認者ではなく、対象ファイルを編集していない |
| Chief Knowledge Reviewer | Knowledge Base First、Cross-sprint非重複、非同義化、用途配賦禁止、Relationship、Gap及びRaw grain | 著者・承認者ではなく、対象ファイルを編集していない |
| Traceability Reviewer | Local ID、件数、公式locator、Cross-sprint参照、Gate順序、Evidence / PIT未発行及び利用境界 | 著者・承認者ではなく、対象ファイルを編集していない |

## 2. Reviewed Package

| Candidate range | Count | Final preliminary disposition |
| --- | ---: | --- |
| `REN-SFI-001`–`REN-SFI-019` | 19 | Reference existing evidence only 3 / Proceed 3 / Proceed with caution 10 / Hold 3 |

Excluded transformationは12件である。`REN-SFI-xxx`はLocal inspection IDであり、Evidence ID又はPIT IDではない。Cross-sprint recheck対象はProceed / Proceed with cautionの13件に限る。

## 3. Initial Review Findings

| Review | Critical | High | Medium | Low | Initial recommendation |
| --- | ---: | ---: | ---: | ---: | --- |
| Evidence | 0 | 0 | 3 | 2 | Revise |
| Knowledge | 0 | 2 | 2 | 0 | Revise |
| Traceability | 0 | 0 | 2 | 0 | Revise |

### Evidence Findings

- `REN-SFI-004`の約55%は全般的な工場稼働率ではなく、front-end wafer input基準であった。またActual-period observationとdecision-based investment Planが一候補に混在していた。
- `REN-SFI-010`は原文の`designed into next-generation boards`を弱く言い換えず、issuer-reported design-in assertionとして保持する必要があった。
- 旧`REN-SFI-011`は、第三者由来のxPU volume、Renesas content scenario、slide上のunits / value及び製品別relative ASPを混在させていた。
- `REN-SFI-005`の定義・将来reporting記述はQ&A回答ではなくprepared remarksに所在した。
- 年間15億個超のshipmentsは`per year`以外の対象FY / 集計期間が不明であった。

### Knowledge Findings

- 旧`REN-SFI-009`は、一般的rack-power scenario、board上の製品個数例及び匿名顧客boardへの直接的製品関係を一つにまとめていた。
- 旧`REN-SFI-011`は、entity、denominator、基準年、horizon及びprovenanceが異なる倍率を非同義のまま一候補へ正規化していた。
- `gaining share`及び競合比performance等のcommercial / competitive assertionsが、候補・Excluded・Gapのいずれにも明示処理されていなかった。
- Utilization Actualとinvestment Planは、将来のRaw Evidenceも別artifactとする必要があった。

### Traceability Findings

- EVR ID発行とPIT ID発行のGateが一行にまとめられ、既存の段階的統制を正確に表していなかった。
- Earnings Reportの直接URL及びprepared remarksのPDF / viewer page locatorが不足していた。

## 4. Revisions Applied

1. `REN-SFI-004`をfront-end wafer-input utilizationのActual-period observationへ限定し、investment Planを`REN-SFI-016`へ分離した。
2. `REN-SFI-009`をrack-power scenarioへ限定し、匿名顧客boardとの直接的製品関係を`REN-SFI-017`へ分離した。
3. 旧倍率候補を、slide-defined units / valueの`REN-SFI-011`、xPU volume / power contentの`REN-SFI-018`、製品別relative ASPの`REN-SFI-019`へ分離した。Provenance / horizon reconciliation未了の`REN-SFI-018`はHoldとした。
4. `REN-SFI-010`をissuer-reported design-in assertionとして保持し、顧客、量産、shipment、revenue及びNVIDIA採用を未確認とした。
5. `REN-SFI-015`へApplicable Period `Unknown`及びFY Actual / run-rate変換禁止を追加した。
6. `gaining share`及びcompetition比performanceを明示的なExcluded transformationへ追加した。
7. Anonymous customer-board direct relationをmanagement thesisとは別のRelationship edgeとして記録した。
8. Earnings Reportの直接URL、各候補のphysical PDF / zero-based viewer locator及びprepared-remarks anchorを追加した。
9. EVR IDとPIT IDの発行・登録Gateを分離し、Raw review、EVR review及び一対一PITの順序を明示した。
10. 候補を19件へ再計数し、Reference 3 / Proceed 3 / Proceed with caution 10 / Hold 3、Excluded 12、次Gate対象13件へ整合させた。

## 5. Final Re-review

| Review scope | Critical | High | Medium | Low | Final disposition |
| --- | ---: | ---: | ---: | ---: | --- |
| Evidence | 0 | 0 | 0 | 0 | Accepted |
| Knowledge | 0 | 0 | 0 | 0 | Accepted |
| Traceability | 0 | 0 | 0 | 0 | Accepted |

最終再レビューでは、公式一次資料への忠実性、Fact grain、非同義化、Direct relationとmanagement thesisの分離、Cross-sprint参照専用境界、candidate / disposition件数、Source locator及びGate順序に残存指摘はなかった。

## 6. Final Disposition

**Disposition: Accepted**

本文書はRenesas ElectronicsのDraft Source Fact候補検査として受け入れる。Proceed 3件及びProceed with caution 10件は、現在のSource Factと利用境界を維持してcandidate-level Cross-sprint recheckへ進める。Reference-only 3件はSprint002 Evidenceを参照し、Hold 3件はRaw Evidence化しない。

受入れ後も両文書はDraft / noncanonicalである。次Gateでは候補ごとの同一Source Event・同一Source Fact・同一Claimを再照合し、Accepted後にのみRaw Evidenceを作成する。Evidence / PIT IDは各レビューGate前に発行せず、全件`AvailableAt = TBD — no use`、Catalog Eligibility `No`を維持する。
