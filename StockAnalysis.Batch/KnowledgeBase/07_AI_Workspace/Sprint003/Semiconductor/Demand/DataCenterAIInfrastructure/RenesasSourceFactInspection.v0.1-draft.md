# Renesas Electronics — Data Center / AI Infrastructure Source Fact Inspection

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft Source Fact inspection |
| Sprint | Sprint003 |
| 対象企業 | Renesas Electronics Corporation |
| Version | 0.1-draft |
| 作成日 | 2026-08-02 |
| Retrieval Date | 2026-08-02 |
| 調査cut-off | 2026-07-30 23:59 JST |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Reviewer Status | Evidence / Knowledge / Traceability final disposition `Accepted` |
| Related Review Record | `RenesasSourceFactInspectionIndependentReview.v0.1-draft.md` |
| Evidence ID | None — 本文書の`REN-SFI-xxx`はLocal inspection IDであり、Evidence IDではない |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md` |
| Stage 0 | `Sprint003DataCenterAIInfrastructureStage0IndependentReview.v0.1-draft.md` — Accepted |
| Cross-sprint参照 | `Sprint003DataCenterAIInfrastructureCrossSprintBridge.v0.1-draft.md` |

> **利用境界：** 本文書はSource Fact候補をRaw Evidence化する前の検査記録である。候補のEvidence採用、`S3-EVR-xxx`又は`S3-PIT-xxx`の発行、`AvailableAt`の確定、Catalog / DDL / ML利用を許可しない。Sprint001・Sprint002の既存Evidenceと同じSource Factは参照のみとし、Sprint003で再発行しない。

## 1. Research Questions

| Research Question | Renesasでの確認対象 |
| --- | --- |
| `S3-DCAI-RQ-001` | AI Infrastructure、Data Center、Digital Power、Memory Interface及びControl Planeの発行者用語 |
| `S3-DCAI-RQ-004` | Data Center / AI用途とPower Semiconductor、Power Management及び関連製品の明示関係 |
| `S3-DCAI-RQ-005` | AI server、800V architecture、rack / core power、memory及びcontrolとの発行者明示関係 |
| `S3-DCAI-RQ-006` | Actual、Plan、Target、Forecast、management scenario、third-party forecast及び発行者分類の差 |
| `S3-DCAI-RQ-007` | 将来の観測候補となり得るRenesas開示と、用途別売上・投資配賦等の利用不能なGap |

## 2. Inspected Official Sources

| Source | Publication Event | Applicable Period | Official location | Inspection status |
| --- | --- | --- | --- | --- |
| Renesas Electronics Corporation, *FY2025 Earnings Report* | 2026-02-05。publication time / timezone `Unknown` | FY2024 / FY2025 Actual | [Official document page](https://www.renesas.com/en/document/rep/earnings-report-year-ended-december-31-2025)、PDF pp.8–9 | Sprint002 `S2-EVR-012`として既存確認済み。本文書では参照のみ |
| Renesas Electronics Corporation, *1Q 2026 Earnings Report* | 2026-04-24。publication time / timezone `Unknown` | 1Q 2026 Actual | [Official document page](https://www.renesas.com/en/document/rep/earnings-report-1st-quarter-ended-march-31-2026)、PDF pp.7–8 | Sprint002 `S2-EVR-013`として既存確認済み。本文書では参照のみ |
| Renesas Electronics Corporation, *1Q 2026 Presentation Material* | 2026-04-24。publication time / timezone `Unknown` | 1Q 2026 Actual / 2Q 2026 Forecast | [Official document page](https://www.renesas.com/en/document/ppt/2026-1q-presentation-material) | Sprint002 `S2-EVR-023`として既存確認済み。本文書では参照のみ |
| Renesas Electronics Corporation, *2026 1Q Presentation Minutes and Q&A* | Event 2026-04-24。document publication time / timezone `Unknown` | 1Q 2026 results and Q2 context | [Official document page](https://www.renesas.com/en/document/ppt/2026-1q-presentation-minutes-and-qa) | Capacity / investment passages inspected; inventory passage is supporting overlap only |
| Renesas Electronics Corporation, *AI Infra and Compute — 2026 Capital Market Day* | Document / event date 2026-06-25。publication time / timezone `Unknown` | 2025 revenue-mix context; mid-to-long-term strategy and market scenarios | [Official document page](https://www.renesas.com/en/document/ppt/ai-infra-and-compute-2026-capital-market-day) | Slides 2–11 and summary inspected |
| Renesas Electronics Corporation, *2026 Capital Market Day Presentation, Minutes and Q&A — 2nd Half* | Event 2026-06-25。document publication time / timezone `Unknown` | Current strategy and future reporting discussion | [Official document page](https://www.renesas.com/en/document/ppt/2026-capital-market-day-presentation-minutes-and-qa-2nd-half) | AI Infra & Compute presentation / Q&A passages inspected |
| Renesas Electronics Corporation, *Renesas Powers 800-Volt Direct Current AI Data Center Architecture with Next-Generation Power Semiconductors* | 2025-10-13。publication time / timezone `Unknown` | Product / architecture announcement | [Official newsroom release](https://www.renesas.com/en/about/newsroom/renesas-powers-800-volt-direct-current-ai-data-center-architecture-next-generation-power) | Product and shipment-scope statements inspected |
| Renesas Electronics Corporation, official AI data-center blogs | 2026-04-02 and 2026-07-25。publication time / timezone `Unknown` | Product / architecture explanation | [GaN blog](https://www.renesas.com/en/blogs/when-it-comes-powering-ai-data-centers-gan-taking-center-stage)、[Infrastructure blog](https://www.renesas.com/en/blogs/why-ais-next-growth-phase-redefining-data-center-infrastructure) | Supporting corroboration only。CMD又はNewsroomと重複するため独立候補を作成しない |

## 3. Source Fact Candidate Assessment

| Local ID | Source position | Classification | Source Fact candidate | Use boundary | Cross-sprint check | Raw Evidence recommendation |
| --- | --- | --- | --- | --- | --- | --- |
| `REN-SFI-001` | FY2025 Earnings Report、Industrial / Infrastructure / IoT results | Direct quantitative observation / Actual with issuer demand explanation | Industrial / Infrastructure / IoT売上はFY2024 JPY636.8bn、FY2025 JPY671.8bnで、JPY35.0bn、5.5%増加。発行者はinfrastructure需要を説明する。 | 複合区分Actualであり、Data Center、AI Infrastructure又は製品別売上へ配賦しない。 | Sprint002 `S2-EVR-012`と同じFact | **Reference existing evidence only** — Sprint003で再発行しない |
| `REN-SFI-002` | 1Q 2026 Earnings Report、Industrial / Infrastructure / IoT results | Direct quantitative observation / Actual with issuer demand explanation | 1Q 2026 Industrial / Infrastructure / IoT売上はJPY199.0bn、前年同期比JPY48.2bn、32%増加し、発行者は主としてinfrastructure需要によると説明する。 | 複合区分Actualであり、Data Center単独の売上又は成長率へ配賦しない。 | Sprint002 `S2-EVR-013`と同じFact | **Reference existing evidence only** — Sprint003で再発行しない |
| `REN-SFI-003` | 1Q 2026 Presentation Material p.7、channel inventory commentary | Actual-period explanation + Forecast / Plan | 1Q Actualではdata center向けchannel inventory増加を含むと説明し、2Q Forecastでは新製品certification前のadvance shipmentを計画すると説明する。 | ActualとForecastを分離する。Inventory金額、日数、製品、顧客、販売又は最終需要を確定しない。 | Sprint002 `S2-EVR-023`と同じFact | **Reference existing evidence only** — Sprint003で再発行しない |
| `REN-SFI-004` | 2026 1Q Presentation Minutes and Q&A、prepared remarks `utilization rate and CAPEX status`、PDF p.7（viewer P6） | Management-reported operating observation / Actual-period context | Front-end wafer input基準の1Q稼働率は約55%で前四半期比約6pt上昇し、Nakaの12-inch MCU / 40nm MCU及びSaijoのdigital power製品の需要増加に対応してwafer inputを増加したと発行者は説明する。 | 全工場又は全設備の稼働率ではない。対象製品のうちData Center分、wafer数量、capacity量、shipment又はrevenueを確定しない。 | 同一event familyの既存`S2-EVR-013` / `023`とはSource position及びFactが異なる | **Proceed with caution** — mixed-product front-end utilization context only |
| `REN-SFI-005` | 2026 Capital Market Day Presentation and Q&A Summary、prepared remarks、PDF pp.31–32（viewer P30–P31） | Issuer definition / reporting transition | RenesasはAI Infra & Compute市場にDigital Power、Memory Interface、Control Plane及びその他analog componentsを含め、AI serversとgeneral serversへ提供すると説明する。またAI / non-AIの区別が曖昧になるため、将来は当該businessを`data center revenue`として説明する方針を示す。 | 将来の報告定義であり、過去のIndustrial / Infrastructure / IoT区分又は2025 revenueを遡及的に再分類しない。AI-onlyとData Center全体を同一視しない。 | 既存Sprint001 / 002に同じdefinition transitionなし | **Proceed** — issuer definition and future comparability boundary |
| `REN-SFI-006` | 2026 Capital Market Day slides 2, 5–6、grid-to-core portfolio | Issuer product / architecture definition | RenesasはAI infrastructure向けportfolioをgrid、ESS / UPS、PSU、rack、xPU board及びcore powerまでのpower-delivery pathに沿って示し、Digital Power、Memory Interface及びControl Plane関連製品を配置する。 | Product / architecture mapであり、sales、shipment、adoption、market share、customer purchase又はuniversal BOMを示さない。 | 既存matchなし | **Proceed** — issuer-defined grid-to-core portfolio boundary |
| `REN-SFI-007` | 2026 Capital Market Day slide 3 `Growth Drivers — AI Infra & Compute`; Presentation and Q&A Summary prepared remarks、PDF pp.31–32 | Management strategy / forward-looking relationship | 発行者は、800V及びvertical power architectureがxPU当たりpower contentを増加させmodulesを有利にし、AI xPU / serverの増加がmemory solutionsを拡大し、grid-to-rackの複雑化がMCU / control機会を生むとの成長driverを示す。 | Management thesisであり、測定済み因果、Actual需要、revenue、unit、share又はLead / Lagを示さない。各edgeを独立に保持し、一本の数値chainへ結合しない。 | 既存matchなし | **Proceed with caution** — issuer-named strategy relationships only |
| `REN-SFI-008` | 2026 Capital Market Day slide 4、server / accelerator market charts | Issuer-presented third-party forecast | Renesas資料はGartner / Omdia由来の2030年までのgeneral server、AI server、CPU、GPU及びASIC数量成長forecastを提示する。 | Renesas Actual又は独自forecastではなく、第三者由来の将来推計。元資料のdefinition、base year、method及び利用許諾を本検査で独立確認していない。 | 既存matchなし | **Hold** — contextual forecast; no Raw Evidence in this gate |
| `REN-SFI-009` | 2026 Capital Market Day slide 7、next-generation rack context | Management scenario + third-party market context | 資料はnext-generation AI rackが1MW超へ向かい、power content per rackが10倍超になるとのforward-looking contextを示す。 | Future scenarioであり、Actual rack population、installed base、power demand、semiconductor demand、shipment又は特定顧客構成ではない。第三者TAM footnoteをRenesas Actualへ変換しない。 | 既存matchなし | **Proceed with caution** — forward-looking rack-power scenario only |
| `REN-SFI-010` | 2026 Capital Market Day slide 8、GaN / MOSFET for 800V | Issuer product / strategy and design-in assertion | Renesasは800V architecture向けGaN / MOSFETへ投資し、D-mode GaN及びefficiency / power-density characteristicsを示す。発行者はlatest MOSFETがnext-generation boardsへ`designed into`されたと説明する。 | Issuer-reported design-in assertionであり、customer / board identity、量産、shipment、revenue、market share又はNVIDIA採用を確定しない。第三者確認済みdesign winとして扱わない。 | 既存matchなし | **Proceed with caution** — product / design-in assertion with commercial boundary |
| `REN-SFI-011` | 2026 Capital Market Day slide 9、2025-to-Mid-Term Digital Power illustration | Issuer management relative-value illustration | Slideは2025からMid-Termへの比較として`>2x More units`及び`>5x More value`を示す。 | 図のunits / value定義、currency、absolute base、実現時期及びActual achievementを本候補から補完しない。Transcriptの2030 xPU volume又はpower content per xPUと同義化しない。 | 既存matchなし | **Proceed with caution** — slide-defined relative illustration only |
| `REN-SFI-012` | 2026 Capital Market Day slide 10、memory / control content | Management strategy / illustrative product-content relationship | 発行者はAI inferenceがCPU及びDRAM需要を促しmemory-interface contentを増加させるとの見方と、MCU-based control採用が拡大するとの見方を示し、memory module / board上の製品構成例を提示する。 | Management thesis及び構成例であり、Actual unit demand、universal BOM、attach rate、shipment、revenue又は特定顧客採用を示さない。 | 既存matchなし | **Proceed with caution** — memory / control opportunity context only |
| `REN-SFI-013` | 2026 Capital Market Day slide 11; Presentation and Q&A Summary prepared remarks、PDF pp.38–39（viewer P37–P38） | Issuer operating strategy / capacity response narrative | RenesasはAI需要のvolatilityに対応するため、in-house fabsとfoundry partnersを組み合わせ、需要に応じてcapacityを増強するhybrid manufacturing modelを説明する。 | Capacity量、supplier identity、製品別allocation、committed wafer、utilization、発注又は実現時期を示さない。Risk / operating strategyでありActual supplyを示さない。 | 既存matchなし | **Proceed with caution** — supply-model context only |
| `REN-SFI-014` | 2025-10-13 official newsroom release、800V DC architecture | Official product / architecture announcement | RenesasはNVIDIAが発表した800V DC AI data-center architectureへの対応として、48V–400VのGaN solutions、800Vへ構成可能なstack、MOSFET、drivers及びcontrollersを含むpower portfolioを説明する。 | 対応表明及びproduct mapであり、NVIDIAによる調達、design win、production deployment、shipment、sales又はcustomer-specific BOMを示さない。効率値は所定製品 / 条件のspecificationとしてのみ扱う。 | CMD候補と関連するが、先行する個別公式announcementとしてSource Eventが異なる | **Proceed** — architecture-to-product relationship with procurement boundary |
| `REN-SFI-015` | 2025-10-13 official newsroom release、power-management shipment statement | Mixed-scope issuer quantitative statement; applicable reporting period `Unknown` | Renesasはpower-management productsを`per year`で15億個超出荷し、computing industry向けshipmentsが増加したと説明する一方、残余用途にはindustrial、IoT、data center及びcommunicationsを含める。 | Product-family全体かつ用途混在。対象FY、集計期間及び比較期間は不明で、FY Actual又はrun-rateへ変換しない。Data Center向け数量、成長率、製品、顧客又は売上を分離できず、`computing`と`data center`のscopeも同一ではない。 | 既存matchなし | **Hold** — application and reporting-period allocation cannot be established |
| `REN-SFI-016` | 2026 1Q Presentation Minutes and Q&A、prepared remarks `utilization rate and CAPEX status`、PDF p.7（viewer P6） | Decision-based investment Plan | 1Qのdecision-based investmentはJPY94bnで、その80%をcapacity expansionが占める。発行者はAI、data center及びdigital power用途を内製化するためのfront-end中心の投資と、back-end packages / modulesの増強計画を説明する。 | Decision-based investmentでありActual cash CapExではない。80%からJPY75.2bnを機械的に算出せず、金額又は比率をAI、Data Center、digital power、製品、front / back-end又はfactoryへ配賦しない。 | 同一event familyの既存`S2-EVR-013` / `023`とはSource position及びFactが異なる | **Proceed with caution** — mixed-scope capacity decision and Plan only |
| `REN-SFI-017` | 2026 Capital Market Day slide 7（AI Infra & Compute PDF p.7 / viewer P6）及びprepared remarks（2nd-half Summary PDF pp.34–35 / viewer P33–P34）、`leading next-generation AI board` example | Issuer assertion / anonymous customer-board direct product relationship | Renesasはleading next-generation AI boardの例でdigital multiphase core power、IBC及びMOSFETを含むtotal power solutionを提供し、そのperformanceを`our customer`が測定したと説明する。Slideは48V IBC及びGPU power solutionのcontroller、MOSFET及びpower-stage個数例も示す。 | 匿名顧客とのissuer-asserted関係である。Customer / board identity、試験条件、採用stage、order、shipment、revenue、production deployment又はuniversal BOMを確定しない。第三者検証済みbenchmarkとみなさない。 | 既存matchなし | **Proceed with caution** — anonymous customer-board relation with strict commercial boundary |
| `REN-SFI-018` | 2026 Capital Market Day slides 4 and 9（AI Infra & Compute PDF pp.4, 9 / viewer P3, P8）及びprepared remarks（2nd-half Summary PDF pp.32, 36 / viewer P31, P35）、xPU volume / power-content comparison | Issuer-presented market-volume synthesis + issuer management content scenario | Transcriptは2030年までのxPU deployment volumeが2倍超となるとの市場contextと、Renesas power content per xPUが約5倍となるとのmanagement scenarioを説明する。Slides / preceding remarksはGartner / Omdia由来のmarket contextを含む。 | `>2x`と`roughly 5x`はentity、denominator及びprovenanceが異なるため一つの倍率Factへ結合しない。Slide 4のthird-party context、slide 9の2025-to-Mid-Term `>2x More units` / `>5x More value`及びtranscript説明も相互に同義化しない。 | 既存matchなし | **Hold** — provenance / horizon reconciliation required before Raw Evidence |
| `REN-SFI-019` | 2026 Capital Market Day slide 9（AI Infra & Compute PDF p.9 / viewer P8）、product-level relative ASP examples | Issuer management relative-ASP illustration | Slideは`Standard smart power stage (2009-present) = 1x ASP`を基準に、`Dual smart power stage >1.5x`、`Integrated vertical power stage >3x`、`Quad-Phase power tower >8x`のrelative ASP例を示す。 | Currency ASP、realized transaction price、customer mix、shipment volume、revenue又はmarket shareではない。各製品例の基準構成と比較演算子を原文どおり保持し、`REN-SFI-018`のpower content per xPUと同義化しない。 | 既存matchなし | **Proceed with caution** — product-level relative illustration only |

## 4. Excluded or Non-convertible Statements

| Statement family | Disposition | Reason |
| --- | --- | --- |
| Industrial / Infrastructure / IoT売上又は増加額をData Center単独売上とみなす | Excluded | 複合区分であり用途別配賦がない。 |
| Decision-based investment JPY94bn又はcapacity expansion 80%をData Center固有又はActual CapExとみなす | Excluded | 投資の測定分類が異なり、AI / Data Center / Digital Power、factory、product又は実行額の配賦がない。 |
| 2025 revenue-mix graphicから不鮮明又は未確認のnumeric shareを転記する | Excluded | ラベル、分母、対象期間及び分類をSource positionから再現できない。 |
| Gartner / Omdia由来のserver / xPU forecastをRenesas Actual又は独自予測とみなす | Excluded | 第三者由来の将来推計である。 |
| Rack / board / module上の例示contentをuniversal BOM、shipment又は半導体需要量へ変換する | Excluded | Architecture exampleであり、顧客・世代・構成によって異なる。 |
| `>2x units`、`>5x value`又はrelative ASP倍率を実現済みrevenue、market share又はcompany forecastとみなす | Excluded | Management illustrationでありActual monetary measureではない。 |
| `designed into`又は800V対応表明をdesign win、量産採用、NVIDIA調達又は売上とみなす | Excluded | Commercial adoptionを確定する開示ではない。 |
| `gaining share with hyperscalers / AI customers / leading players`をActual market share又はnamed-customer採用とみなす | Excluded | Issuer management assertionであり、share分母、期間、顧客identity及び第三者検証がない。本Gateでは独立Raw候補にしない。 |
| Competition比のthermal-performance主張を一般的benchmark又は第三者検証済み優位性とみなす | Excluded | 対象競合集合、試験条件、測定範囲及び独立検証を確認できない。本Gateでは独立Raw候補にしない。 |
| 年間15億個超のpower-management shipmentsをData Center向けunitsとみなす | Excluded | 用途混在でありData Center allocationがない。 |
| 将来の`data center revenue`定義を過去のIndustrial / Infrastructure / IoT又はAI Infra & Compute売上へ遡及適用する | Excluded | Restatement又は旧新区分mappingが開示されていない。 |
| Renesasのportfolio又はgrowth thesisからMicrosoft、Alphabet、NVIDIA又は日本株供給者の購入額・売上を推定する | Excluded | Cross-issuer direct relation及び金額配賦をSource Setが示していない。 |

## 5. Relationship Assessment

### Confirmed Issuer-named Edges

```text
AI Infra & Compute market
    ↓ issuer-defined product domains
Digital Power + Memory Interface + Control Plane + Other analog components
```

根拠：`REN-SFI-005`。発行者のmarket / portfolio定義であり、各domainの売上又はmarket shareを示さない。

```text
AI data-center grid-to-core power delivery path
    ↓ issuer portfolio positioning
GaN / MOSFET + Digital Power + Modules + MCU / Control products
```

根拠：`REN-SFI-006`、`010`及び`014`。製品・architecture上の関係であり、顧客採用又は売上関係ではない。

```text
800V / vertical power architectures
    ↓ management expectation
Higher power content per xPU and greater module opportunity
```

```text
Growth in AI xPU / server deployment
    ↓ management expectation
Greater memory-interface opportunity
```

```text
Greater grid-to-rack complexity
    ↓ management expectation
Greater MCU / control opportunity
```

根拠：`REN-SFI-007`及び`012`。三つのedgeは個別のmanagement thesisとして保持し、測定済み因果又は一本の数量chainとして結合しない。

```text
Anonymous leading next-generation AI board
    ↓ issuer-reported direct product relationship
Renesas total power solution including multiphase core power + IBC + MOSFET
```

根拠：`REN-SFI-017`。発行者が匿名顧客boardへの提供とcustomer-measured performanceを主張する直接関係である。ただし、顧客identity、採用stage、試験条件、order、shipment、revenue及び量産は未確認である。

```text
AI / Data Center / Digital Power capacity needs — mixed application scope
    ↓ issuer investment decision / Plan
In-house front-end focus + future back-end expansion
```

根拠：`REN-SFI-016`。investment amount又は80%を用途別・factory別に配賦しない。

### Gap

調査cut-offまでに確認したRenesas公式Source Setでは、Data Center単独のActual revenue、orders、shipment units、inventory amount、capacity又はCapExを確認できなかった。将来`data center revenue`として説明する方針は示されたが、過去区分とのrestatement又は数値mappingは未確認である。

Microsoft、Alphabet又はNVIDIAの投資・売上とRenesasの受注・売上を同一一次資料で直接結ぶquantitative relationも確認できなかった。NVIDIA 800V architectureへの対応表明は、NVIDIAによる調達、design win又は量産採用の証拠ではない。これらは当該関係又は資料が存在しないことの証明ではない。

## 6. Preliminary Disposition

| Category | Count | Treatment |
| --- | ---: | --- |
| Reference existing evidence only | 3 | Sprint002 Evidenceを参照し、Sprint003 IDを発行しない |
| Proceed | 3 | 独立レビュー後、個別Cross-sprint recheckを実施 |
| Proceed with caution | 10 | Plan / management scenario / mixed scope / issuer commercial assertionを維持して個別recheckを実施 |
| Hold | 3 | Raw Evidence化せず、第三者forecast、provenance不整合又は用途配賦不能として保持 |
| Excluded transformation | 12 | Evidence化せず、禁止変換として保持 |

Proceed 3件は`REN-SFI-005`、`006`、`014`である。Proceed with caution 10件は`REN-SFI-004`、`007`、`009`、`010`、`011`、`012`、`013`、`016`、`017`、`019`である。Hold 3件は`REN-SFI-008`、`015`、`018`である。

## 7. Gate Status and Next Gate

| Gate | Status | Record / Next action |
| --- | --- | --- |
| Source Fact Inspection Independent Review | Completed — Accepted | `RenesasSourceFactInspectionIndependentReview.v0.1-draft.md` |
| Candidate-level Cross-sprint recheck | Completed — Accepted | `RenesasCrossSprintCandidateRecheckIndependentReview.v0.1-draft.md` |
| Raw Evidence | Draft completed — 13 artifacts; Independent Review Accepted | `RenesasRawEvidenceIndependentReview.v0.1-draft.md` |
| EVR ID / registration | Completed — Accepted | `S3-EVR-033`–`045`; `Sprint003RenesasEvidenceRegisterIndependentReview.v0.1-draft.md` |
| PIT ID / registration | Completed — Accepted | `S3-PIT-033`–`045`; `Sprint003RenesasPITInventoryIndependentReview.v0.1-draft.md` |
| AvailableAt / Catalog | Not permitted | `TBD — no use` / `No` |
