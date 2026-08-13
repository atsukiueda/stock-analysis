# Renesas Electronics — Cross-sprint Candidate Recheck

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft candidate-level cross-sprint traceability record |
| Sprint | Sprint003 |
| 対象企業 | Renesas Electronics Corporation |
| Version | 0.1-draft |
| 確認日 | 2026-08-02 |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Reviewer Status | Evidence / Knowledge / Traceability final disposition `Accepted` |
| Related Review Record | `RenesasCrossSprintCandidateRecheckIndependentReview.v0.1-draft.md` |
| 上流Inspection | `RenesasSourceFactInspection.v0.1-draft.md` — Accepted |
| 上流Bridge | `Sprint003DataCenterAIInfrastructureCrossSprintBridge.v0.1-draft.md` — Stage 0 Accepted |
| Evidence / PIT ID | None — Local candidate recheck only |

> **利用境界：** 本記録はRaw Evidence作成前の重複・参照確認である。検索対象内でmatchがないことはRepository全体又は外部に同一資料・同一Factが存在しないことの証明ではない。Evidence採用、ID発行、`AvailableAt`確定、Catalog又は下流利用を許可しない。

## 1. Examined Sets

2026-08-02に、Stage 0の固定集合と、本Recheckで安全側に追加したread-only検索集合を区別して確認した。

### 1.1 Stage 0 Fixed Examined Set

`Sprint003DataCenterAIInfrastructureCrossSprintBridge.v0.1-draft.md` §1.1で明示され、Stage 0独立レビューAcceptedとなった11 artifactを指す。Sprint001のEvidence Register、PIT、Industry Report、Evidence Acquisition Matrix、Renesas / ROHM Company Research、及びSprint002のEvidence Register、PIT、Industry Report、Renesas / ROHM Company Researchである。

Stage 0 Bridgeは、Renesasについて次を既存matchとして固定している。

- `CSB-REN-001` / Sprint002 `S2-EVR-012`：FY2025 Industrial / Infrastructure / IoT Actual。
- `CSB-REN-002` / Sprint002 `S2-EVR-013`：1Q 2026 Industrial / Infrastructure / IoT Actual。
- `CSB-REN-003` / Sprint002 `S2-EVR-023`：1Q Actual inventory context及び2Q Forecast advance shipment。
- `CSB-REN-004` / Sprint001 `EVR-003`、`010`–`014`：Automotive用途のboundary reference。

上流Inspectionの`REN-SFI-001`–`003`は上記Sprint002 Factと同一であるためReference-onlyとし、本RecheckのRaw eligibility対象13件へ含めない。Sprint001 Automotive Factは同一発行者でも用途・Source Factが異なり、Data Centerへ再利用しない。

### 1.2 Additional Candidate Recheck Set

| Scope | Additional read-only search content |
| --- | --- |
| Sprint001 | `KnowledgeBase/07_AI_Workspace/Sprint001/Semiconductor/Demand/Automotive`配下のDraft `.md` |
| Sprint002 | `KnowledgeBase/07_AI_Workspace/Sprint002/Semiconductor/Demand/IndustrialPower`配下のDraft `.md` |
| Legacy Research | `KnowledgeBase/01_Research`配下の既存`.md` |

追加集合は本Recheckで安全側に確認した範囲であり、Stage 0 Accepted scopeを変更・拡張又は再承認するものではない。

検索語は`Renesas`、`ルネサス`、`2026 Capital Market Day`、`AI Infra`、`data center revenue`、`front-end wafer`、`decision-based investment`、`JPY94 billion`、`800V`、`800-Volt`、`next-generation AI board`、`power content per xPU`、`hybrid manufacturing`、`Dual smart power stage`、`Quad-Phase`、`designed into next-generation boards`及び`1.5 billion`である。各語を上記集合についてliteral case-insensitive検索した。

Legacy ResearchにはRenesas IR及び2026 Capital Market Dayを将来確認対象とする一般的記述が存在したが、Sprint003候補と同一のSource position及びFactは記録されていなかった。Sprint001 / 002にはRenesasのAutomotive、Industrial / Infrastructure / IoT、inventory及びsource-archive記述が多数存在するが、上流Bridgeで固定した既存Fact以外に、対象13候補と同一のSource identity / position / Factへ解決する記録は確認できなかった。

このno-matchは、上記集合を2026-08-02に指定語彙で確認した結果に限定される。数値、`data center`、`capacity`、`800V`等の一般語が他社又は他用途で一致しても、Renesasの同一Factとは判定しない。

### 1.3 Candidate-level Search Matrix

| Candidate | Source identity / event or period terms | Position / key Fact terms | Result in §1.1 and §1.2 sets |
| --- | --- | --- | --- |
| `REN-SFI-004` | *2026 1Q Presentation Minutes and Q&A*; event 2026-04-24 | PDF p.7; front-end wafer input; utilization around 55%; about 6 points | Same event family as existing `S2-EVR-013` / `023`; no identical Source Fact |
| `REN-SFI-005` | *2026 Capital Market Day Presentation and Q&A Summary*; event 2026-06-25 | PDF pp.31–32; Digital Power; Memory Interface; Control Plane; `data center revenue` | Generic legacy CMD mention only; no identical candidate |
| `REN-SFI-006` | *AI Infra and Compute — 2026 Capital Market Day* | slides 2, 5–6; grid-to-core; ESS / UPS; PSU; xPU board | No identical candidate |
| `REN-SFI-007` | Same CMD package | slide 3; 800V; vertical power; memory solutions; MCU / control | No identical candidate |
| `REN-SFI-009` | Same CMD package | slide 7; next-generation rack; `>1MW`; `>10x` power content | No identical candidate |
| `REN-SFI-010` | Same CMD package | slide 8; GaN; MOSFET; `designed into next-generation boards` | No identical candidate |
| `REN-SFI-011` | Same CMD package | slide 9; 2025-to-Mid-Term; `>2x More units`; `>5x More value` | No identical candidate |
| `REN-SFI-012` | Same CMD package | slide 10; AI inference; CPU / DRAM; memory interface; MCU-based control | No identical candidate |
| `REN-SFI-013` | Same CMD package | slide 11 / Summary pp.38–39; hybrid manufacturing; external foundries | No identical candidate |
| `REN-SFI-014` | Official newsroom release; publication 2025-10-13 | NVIDIA 800V DC architecture; 48V–400V GaN; MOSFET; drivers; controllers | No identical candidate |
| `REN-SFI-016` | *2026 1Q Presentation Minutes and Q&A*; event 2026-04-24 | PDF p.7; JPY94bn; 80%; AI / data center / digital power; front-end / back-end | Same document as `REN-SFI-004` and event family as existing S2 facts; no identical Source Fact |
| `REN-SFI-017` | 2026 CMD slide 7 / Summary pp.34–35 | leading next-generation AI board; total power solution; `our customer` | No identical candidate |
| `REN-SFI-019` | 2026 CMD slide 9 | Standard smart power stage 1x; >1.5x; >3x; >8x ASP | No identical candidate |

`No identical candidate`は、Source identity / event、Source position及びkey Fact termsを組み合わせて、同一発行者・同一資料・同一位置・同一Factへ解決する既存Research Assetを確認できなかったことを示す。no-matchを不存在証明として扱わない。

## 2. Candidate-level Recheck

| Local ID | Source Event / Position family | Existing cross-sprint match | Related candidate / same-package or cross-event relationship | Raw Evidence eligibility and required treatment |
| --- | --- | --- | --- | --- |
| `REN-SFI-004` | 1Q 2026 Minutes / Q&A prepared remarks、front-end wafer-input utilization | 同一event familyの`S2-EVR-013` / `023`のみ。Factは異なる | `REN-SFI-016`と同じpageだがActual-period observationとPlanは別Fact | **Eligible with caution.** Front-end wafer input基準の約55% / 約6ptだけを保持し、全工場稼働率、Data Center単独、wafer数量又は売上へ変換しない。 |
| `REN-SFI-005` | 2026 CMD prepared remarks、AI Infra & Compute definition / future reporting | None | CMD全候補のmarket / reporting-definition context | **Eligible.** 発行者定義及び将来reporting transitionとして保持し、旧IIoT区分のrestatement又は数値mappingを作らない。 |
| `REN-SFI-006` | 2026 CMD slides 2, 5–6、grid-to-core portfolio | None | `007`、`009`、`010`、`012`、`014`、`017`及び`019`のarchitecture context | **Eligible.** Portfolio definitionに限定し、製品別売上、adoption、universal BOM又はcustomer purchaseを作らない。 |
| `REN-SFI-007` | 2026 CMD slide 3 / prepared remarks、growth-driver relationships | None | `006`のportfolioを前提とするmanagement thesis | **Eligible with caution.** 三つのedgeを独立に保持し、Actual、測定済み因果、Lead / Lag又は一つの数量chainへ変換しない。 |
| `REN-SFI-009` | 2026 CMD slide 7、rack-power scenario | None | `017`と同じslideだが、forward-looking market contextとanonymous customer-board relationは別Fact | **Eligible with caution.** `>1MW`及び`>10x`をfuture scenarioとして保持し、Actual rack population、installed base又はsemiconductor demandへ変換しない。 |
| `REN-SFI-010` | 2026 CMD slide 8、GaN / MOSFET product and design-in assertion | None | `014`と800V product contextを共有するがSource Event及びFactが異なる | **Eligible with caution.** Issuer-reported design-in assertionとして保持し、customer identity、量産、shipment、revenue又はNVIDIA採用を確定しない。 |
| `REN-SFI-011` | 2026 CMD slide 9、2025-to-Mid-Term relative units / value | None | `019`と同じslide、`018` Holdとも倍率contextを共有するが分母・horizonが異なる | **Eligible with caution.** Slideの`>2x More units` / `>5x More value`を原文のまま保持し、definitions又はabsolute valuesを補完しない。`018` / `019`と結合しない。 |
| `REN-SFI-012` | 2026 CMD slide 10、memory / control opportunity | None | `007`のgrowth-driver relationshipを製品content例で補足する別Fact | **Eligible with caution.** Management thesis及び構成例に限定し、Actual demand、attach rate、universal BOM、shipment又はrevenueを確定しない。 |
| `REN-SFI-013` | 2026 CMD slide 11 / prepared remarks、hybrid manufacturing | None | `016`のinvestment PlanとはSource Event、測定分類及びcapacity Factが異なる | **Eligible with caution.** Operating strategyとして保持し、capacity量、foundry identity、allocation、committed wafer又は実現時期を作らない。 |
| `REN-SFI-014` | 2025-10-13 newsroom release、800V DC architecture product mapping | None | `006` / `010`の後続CMD contextと重複する製品群があるが、先行個別Source Eventのarchitecture-to-product relation | **Eligible.** NVIDIA architectureへの対応表明に限定し、NVIDIA procurement、design win、production deployment、shipment又はsalesを確定しない。 |
| `REN-SFI-016` | 1Q 2026 Minutes / Q&A prepared remarks、decision-based investment Plan | 同一event familyの`S2-EVR-013` / `023`のみ。Factは異なる | `004`と同じpageだがPlanは別Fact | **Eligible with caution.** JPY94bn / 80%をdecision-based investment Planとして保持し、JPY75.2bnを算出せず、Data Center・製品・工程・工場へ配賦しない。 |
| `REN-SFI-017` | 2026 CMD slide 7 / prepared remarks、anonymous customer-board relation | None | `009`と同じslideだが、issuer-asserted direct relationはgeneral scenarioと別Fact | **Eligible with caution.** Anonymous customer-board relationを保持し、identity、test condition、adoption stage、order、shipment、revenue、量産又はuniversal BOMを確定しない。 |
| `REN-SFI-019` | 2026 CMD slide 9、product-level relative ASP examples | None | `011`と同じslideだが、製品別relative ASPとunits / valueは別Fact | **Eligible with caution.** Source-exactな製品、基準1x及び比較演算子を保持し、currency ASP、transaction price、shipment、revenue又はmarket shareへ変換しない。 |

InspectionでHoldとなった`REN-SFI-008`、`015`及び`018`は、本RecheckのRaw eligibility対象外である。既存matchがないことを理由にHoldを解除しない。Reference-onlyの`REN-SFI-001`–`003`も再発行しない。

## 3. Reconciliation Rules for Raw Evidence

- `REN-SFI-001`–`003`はSprint002 `S2-EVR-012`、`013`及び`023`を参照し、S3 Raw / EVR / PITを作成しない。
- `REN-SFI-004`と`016`は同じdocument / pageでも、front-end utilizationのActual-period observationとdecision-based investment Planとして別Raw artifactにする。
- `REN-SFI-005`の将来`data center revenue`定義を既存IIoT Actual又は2025 revenueへ遡及適用しない。
- 同一CMD packageの各候補は、一つのpresentationを複製するのではなく、Source position、Fact grain及びclassificationが異なる場合だけ一対一Raw artifactにする。
- `REN-SFI-006`のportfolio、`007` / `012`のmanagement thesis、`009`のscenario、`010`のdesign-in assertion、`017`のanonymous customer direct relationを相互に同一化又は一本の因果chainへ結合しない。
- `REN-SFI-009`と`017`は同じslide 7でも、general rack-power scenarioとanonymous customer-board relationとして分離する。
- `REN-SFI-011`と`019`は同じslide 9でも、units / valueとproduct-level relative ASPとして分離し、Holdの`REN-SFI-018`を取り込まない。
- `REN-SFI-010`と`014`は800V product contextを共有するが、design-in assertionとarchitecture response announcementを別Source Event / Factとして保持し、NVIDIA採用へ変換しない。
- `REN-SFI-016`のJPY94bn及び80%はData Center固有CapEx、Actual支出又はJPY75.2bnへ変換しない。
- Competitive / share assertions、第三者market forecast及びmixed-scope shipmentはInspectionのExcluded / Holdを維持し、Raw Evidenceへ混入させない。

## 4. Preliminary Disposition

| Result | Count | Treatment |
| --- | ---: | --- |
| Existing Evidence reference only | 3 | `REN-SFI-001`–`003`; Sprint002 Evidenceを参照しS3再発行なし |
| No identical cross-sprint match / Raw eligible | 3 | `REN-SFI-005`、`006`、`014` |
| No identical cross-sprint match / Raw eligible with caution | 10 | `REN-SFI-004`、`007`、`009`–`013`、`016`、`017`、`019` |
| Duplicate — do not create new Raw Evidence | 0 | Eligible 13件には完全重複なし |
| Hold / outside recheck eligibility | 3 | `REN-SFI-008`、`015`、`018`; Raw Evidence化しない |

## 5. Gate Status and Next Gate

| Gate | Status | Record / Next action |
| --- | --- | --- |
| Candidate-level Cross-sprint recheck | Completed — Accepted | `RenesasCrossSprintCandidateRecheckIndependentReview.v0.1-draft.md` |
| Raw Evidence | Draft completed — 13 artifacts | Eligible 3件及びEligible with caution 10件を一対一Draft化済み |
| Raw Evidence independent review | Completed — Accepted | `RenesasRawEvidenceIndependentReview.v0.1-draft.md` |
| EVR ID / registration | Completed — Accepted | `S3-EVR-033`–`045`; `Sprint003RenesasEvidenceRegisterIndependentReview.v0.1-draft.md` |
| PIT ID / registration | Completed — Accepted | `S3-PIT-033`–`045`; `Sprint003RenesasPITInventoryIndependentReview.v0.1-draft.md` |
| AvailableAt / Catalog | Not permitted | `TBD — no use` / `No` |
