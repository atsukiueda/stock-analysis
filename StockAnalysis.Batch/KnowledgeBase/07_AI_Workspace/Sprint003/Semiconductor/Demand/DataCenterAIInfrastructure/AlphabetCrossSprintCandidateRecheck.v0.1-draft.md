# Alphabet — Cross-sprint Candidate Recheck

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft candidate-level cross-sprint traceability record |
| Sprint | Sprint003 |
| 対象企業 | Alphabet Inc. |
| Version | 0.1-draft |
| 確認日 | 2026-08-02 |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Reviewer Status | Evidence / Knowledge / Traceability final disposition `Accepted` |
| Related Review Record | `AlphabetCrossSprintCandidateRecheckIndependentReview.v0.1-draft.md` |
| 上流Inspection | `AlphabetSourceFactInspection.v0.1-draft.md` — Accepted |
| 上流Bridge | `Sprint003DataCenterAIInfrastructureCrossSprintBridge.v0.1-draft.md` — Stage 0 Accepted |
| Evidence / PIT ID | None — Local candidate recheck only |

> **利用境界：** 本記録はRaw Evidence作成前の重複・参照確認である。検索対象内でmatchがないことはRepository全体又は外部に同一資料・同一Factが存在しないことの証明ではない。Evidence採用、ID発行、`AvailableAt`確定、Catalog又は下流利用を許可しない。

## 1. Examined Sets

2026-08-02に、Stage 0の固定集合と、本Recheckで安全側に追加したread-only検索集合を区別して確認した。

### 1.1 Stage 0 Fixed Examined Set

`Sprint003DataCenterAIInfrastructureCrossSprintBridge.v0.1-draft.md` §1.1で明示され、Stage 0独立レビューAcceptedとなった11 artifactを指す。Sprint001のEvidence Register、PIT、Industry Report、Evidence Acquisition Matrix、Renesas / ROHM Company Research、及びSprint002のEvidence Register、PIT、Industry Report、Renesas / ROHM Company Researchである。

Stage 0 Bridgeは、この固定集合においてAlphabetの既存Research Assetを確認できなかったと記録している。

### 1.2 Additional Candidate Recheck Set

| Scope | Additional read-only search content |
| --- | --- |
| Sprint001 | `KnowledgeBase/07_AI_Workspace/Sprint001/Semiconductor/Demand/Automotive`配下のDraft `.md` |
| Sprint002 | `KnowledgeBase/07_AI_Workspace/Sprint002/Semiconductor/Demand/IndustrialPower`配下のDraft `.md` |
| Legacy Research | `KnowledgeBase/01_Research`配下の既存`.md` |

追加集合は本Recheckで安全側に確認した範囲であり、Stage 0 Accepted scopeを変更・拡張又は再承認するものではない。

検索語は`Alphabet`、`Google Cloud`、`AI-optimized infrastructure`、`technical infrastructure`、`specialized AI chips`及び`Tensor Processing Unit`である。各語を上記二集合についてliteral case-insensitive検索し、該当するAlphabet Source Factを確認できなかった。

no-matchは、上記二集合を2026-08-02に指定語彙で確認した結果に限定される。Stage 0固定集合の結果と整合し、追加集合は補助的なread-only corroborationである。

### 1.3 Candidate-level Search Matrix

各候補について、発行者名だけでなく、資料識別子、Source position family及び主要Fact語をliteral case-insensitiveで再検索した。

| Candidate | Source identity / event terms | Position / key Fact terms | Result in §1.1 and §1.2 sets |
| --- | --- | --- | --- |
| `ALPH-SFI-001` | `Alphabet 2025 Form 10-K`; `goog-20251231` | `AI-optimized infrastructure`; `Tensor Processing Units` | No identical candidate |
| `ALPH-SFI-002` | `Alphabet 2025 Form 10-K`; `goog-20251231` | `52.5 billion`; `91.4 billion`; `capital expenditures` | No identical candidate |
| `ALPH-SFI-003` | `Alphabet 2025 Form 10-K`; `goog-20251231` | `data center construction projects`; `servers and network equipment` | No identical candidate |
| `ALPH-SFI-004` | `Alphabet 2025 Form 10-K`; `goog-20251231` | `203,679`; `141,852`; `Property and equipment, in service` | No identical candidate |
| `ALPH-SFI-005` | `Alphabet 2025 Form 10-K`; `goog-20251231` | `149.1 billion`; `113.0 billion`; `Purchase Commitments` | No identical candidate |
| `ALPH-SFI-006` | `Alphabet 2025 Form 10-K`; `goog-20251231` | `specialized AI chips`; `qualified suppliers` | No identical candidate |
| `ALPH-SFI-007` | `Alphabet 2025 Form 10-K`; `goog-20251231` | `significantly increase`; `technical infrastructure`; `2026` | No identical candidate |
| `ALPH-SFI-008` | `2025 Q4 Earnings Call`; `2026-02-04` | `91.4 billion`; `60%`; `data centers and networking equipment` | No identical candidate |
| `ALPH-SFI-009` | `2025 Q4 Earnings Call`; `2026-02-04` | `175 billion`; `185 billion`; `AI compute capacity` | No identical candidate |
| `ALPH-SFI-010` | `2025 Q4 Earnings Call`; `2026-02-04` | `240 billion`; `backlog`; `enterprise AI` | No identical candidate |
| `ALPH-SFI-011` | `2025 Q4 Earnings Call`; `2026-02-04` | `supply-constrained`; `time delay`; `capacity` | No identical candidate |

`No identical candidate`は、Source identity / eventとposition / key Fact termsを組み合わせて候補単位で確認した結果、同一発行者・同一資料・同一位置・同一Factへ解決する既存Research Assetを確認できなかったことを示す。`2026-02-04`、`60%`、`backlog`、`capacity`等の一般語には他社・他用途の偶発的matchが存在するため、それらをAlphabetの同一Factとは判定していない。no-matchを不存在証明としても扱わない。

## 2. Candidate-level Recheck

| Local ID | Source Event / Position family | Existing cross-sprint match | Same-package relationship | Raw Evidence eligibility and required treatment |
| --- | --- | --- | --- | --- |
| `ALPH-SFI-001` | 2025 Form 10-K、Item 1、AI / technical infrastructure architecture | None in fixed examined set | `ALPH-SFI-006`がGPU / TPU定義contextを参照し得る | Eligible。AI-optimized infrastructureとGPU / TPU optionsの発行者説明に限定する。 |
| `ALPH-SFI-002` | 2025 Form 10-K、Item 7、FY2024 / FY2025 CapEx Actual | None | `ALPH-SFI-008`がFY2025 USD91.4bnを再掲 | Eligible。10-K Actualをprimary source factとして保持し、Q4 callの60 / 40構成説明と独立の二重観測として数えない。 |
| `ALPH-SFI-003` | 2025 Form 10-K、Item 7、technical infrastructure definition / construction lifecycle | None | `ALPH-SFI-004` / `007` / `008`の定義境界に使用 | Eligible。構成定義とmulti-year processを保持し、固定Lead / Lag又は構成別金額を作らない。 |
| `ALPH-SFI-004` | 2025 Form 10-K、Note 7、in-service gross asset balance | None | `ALPH-SFI-008`のCapEx 60 / 40とは測定対象が異なる | Eligible。gross in-service balance、not-yet-in-service非包含、net推定禁止を保持する。 |
| `ALPH-SFI-005` | 2025 Form 10-K、Item 7、purchase commitments | None | 他候補に同一commitment Factなし | Eligible。mixed scope及びshort-termの`mostly`限定を保持し、technical infrastructureへ全額配賦しない。 |
| `ALPH-SFI-006` | 2025 Form 10-K、Item 1A、specialized AI chip supply risk | None | GPU / TPU optionsの定義は`ALPH-SFI-001`と重なる | Eligible。Raw Source FactはItem 1Aのlimited qualified suppliers→capacity / customer demand riskへ限定する。GPU / TPU optionsは`ALPH-SFI-001`へのcontext referenceとし、同一Factを再登録しない。 |
| `ALPH-SFI-007` | 2025 Form 10-K、Item 1 risk / Item 7 Plan | None | `ALPH-SFI-002` Actual及び`009`定量Forecastと関係するが分類が異なる | Eligible。定性的Planとして保持し、Actual又はUSD175–185bn Forecastと同一化しない。 |
| `ALPH-SFI-008` | 2025 Q4 Earnings Call、FY2025 technical-infrastructure investment部分の60 / 40 management classification | None | USD91.4bnは`ALPH-SFI-002`と同一FY2025総CapEx | Eligible。新規性はcallでの金額未開示technical-infrastructure investment部分に対するservers 60% / data centers and networking 40%のmanagement classification。USD91.4bnを独立の追加観測として二重計上せず、60 / 40を総CapExへ直接乗じない。 |
| `ALPH-SFI-009` | 2025 Q4 Earnings Call、FY2026 CapEx Forecast / demand context | None | `ALPH-SFI-007`定性的Planと関係するが定量Forecast | Eligible。Forecast / PlanをActualから分離し、投資先への未開示配賦をしない。 |
| `ALPH-SFI-010` | 2025 Q4 Earnings Call、Google Cloud backlog / AI demand context | None | 他候補に同一backlog Factなし | Eligible with caution。Cloud commercial metricでありsemiconductor demand proxyではない。 |
| `ALPH-SFI-011` | 2025 Q4 Earnings Call、capacity constraint / timing boundary | None | `ALPH-SFI-007` / `009`のinvestment contextと関係するが別narrative | Eligible with caution。Phase 1のcapacity / timing boundaryに限定し、Lead / Lag分析又は固定期間を作らない。 |

## 3. Reconciliation Rules for Raw Evidence

- 同じ発行者・同じ資料でも、Source position、Fact、分類又は測定対象が異なる場合だけ別Raw Evidenceとする。
- `ALPH-SFI-002`と`008`のFY2025 CapEx USD91.4bnは同一経済事実の再掲であり、独立した二つのActual observationとして数えない。`008`の60 / 40は金額未開示のtechnical-infrastructure investment部分を分母とし、総CapExへ直接乗じない。
- `ALPH-SFI-004`の約60%は期末in-service gross asset構成、`008`の約60%はFY2025 CapExのmanagement classificationであり、相互代替しない。
- `ALPH-SFI-001`のGPU / TPU optionsを`006`で再登録しない。`006`は供給risk passageへ限定する。
- `ALPH-SFI-007`の定性的Planと`009`の定量Forecastを分離し、Actual化しない。
- `ALPH-SFI-010` / `011`はcontext限定であり、半導体需要Observation又はLead / Lag measurementとして扱わない。

## 4. Preliminary Disposition

| Result | Count | Treatment |
| --- | ---: | --- |
| No cross-sprint match / Raw eligible | 9 | Inspection境界を維持してRaw Evidence化可能 |
| No cross-sprint match / Raw eligible with caution | 2 | Context限定Raw Evidence化可能 |
| Existing Evidence reference only | 0 | 該当なし |
| Duplicate — do not create Raw Evidence | 0 | 候補全体の重複はなし。ただし重複Fact部分は§3で非二重計上化 |

## 5. Gate Status and Next Gate

| Gate | Status | Record / Next action |
| --- | --- | --- |
| Candidate-level Cross-sprint recheck | Completed — Accepted | `AlphabetCrossSprintCandidateRecheckIndependentReview.v0.1-draft.md` |
| Raw Evidence | Draft completed — 11 artifacts | 11候補を一対一でDraft化済み |
| Raw Evidence independent review | Completed — Accepted | `AlphabetRawEvidenceIndependentReview.v0.1-draft.md` |
| EVR ID / registration | Not issued / not registered | Raw review受理後、EVR行作成時にのみ発行 |
| PIT ID / registration | Not issued / not registered | EVR review受理後、PIT行作成時にのみ発行 |
| AvailableAt / Catalog | Not permitted | `TBD — no use` / `No` |
