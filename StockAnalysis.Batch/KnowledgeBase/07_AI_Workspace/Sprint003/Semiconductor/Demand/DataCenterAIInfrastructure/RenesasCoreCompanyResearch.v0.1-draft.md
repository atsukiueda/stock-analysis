# Sprint003 Renesas Core Company Research — Data Center / AI Infrastructure

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft core company research asset |
| Sprint | Sprint003 |
| 対象企業 | Renesas Electronics Corporation |
| Research Domain | Semiconductor — Demand — Data Center / AI Infrastructure |
| Version | 0.1-draft |
| 作成日 | 2026-08-11 |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Author | Documentation Team — Research Author persona |
| Reviewer | Evidence Validation / Chief Knowledge / Traceability reviewers — Accepted |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md` |
| Evidence Gate | `RenesasEvidencePackageGateReconciliation.v0.1-draft.md` — Independent Review Accepted |
| Evidence範囲 | `S3-EVR-033`–`045` / `S3-PIT-033`–`045` |
| Review Record | `RenesasCoreCompanyResearchIndependentReview.v0.1-draft.md` |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | No |

> **利用境界：** 本文書は独立レビュー済みEvidenceを企業単位で整理するDraft Research Assetである。Canonical Knowledge、Catalog、DDL、Entity、Database、ML、バックテスト、Decision Engine、Advisor又は投資判断への利用を許可しない。

## 1. 研究目的と責務

RenesasがData Center / AI Infrastructureに関係するAI Infra & Compute、grid-to-core portfolio、digital power、memory / control、800 V、product relation、utilization及びcapacity strategyをどの粒度で開示しているかを、Evidence IDへ追跡可能な形で整理する。

本文書は新しいSource Factを作らない。FactはEvidence Registerを参照し、Cross-source InferenceはFactと分離する。未確認関係はGapとして保持する。

対象Research Questionは`S3-DCAI-RQ-001`、`004`、`005`、`006`及び`007`である。

## 2. Evidence Baseline

| 区分 | 件数 | 状態 |
| --- | ---: | --- |
| Source Fact候補 | 19 | Inspection Accepted |
| Reference-only | 3 | Sprint002 Evidence参照; Sprint003で再発行しない |
| Raw-eligible | 13 | Proceed 3 + Proceed with caution 10 |
| Hold | 3 | Raw / EVR / PIT未作成 |
| Renesas Raw Evidence | 13 | Package Review Accepted |
| Renesas EVR / PIT | 13 / 13 | Independent Review Accepted |

全13件は`AvailableAt = TBD — no use`、Catalog Eligibility `No`である。Evidence ID又はPIT IDの存在を、Canonical性、利用可能性又は投資上の有効性とみなさない。

`REN-SFI-001`–`003`はSprint002 Evidence参照専用で、Sprint003 Raw / EVR / PITを再発行していない。Holdは`REN-SFI-008`,`015`,`018`である。

## 3. Fact — Business Scope and Reporting Definition

RenesasはAI Infra & ComputeをDigital Power、Memory Interface、Control Plane及びその他analog componentsを含み、AI / general serversへ提供するbusinessとして説明する。AI / non-AIの区別が曖昧になるため、今後は当該businessを`data center revenue`としてreporting and discussingすると説明する。根拠：`S3-EVR-034`。

これはprospective reporting definitionである。過去のIIoT、AI Infra & Compute又は2025 revenueを遡及再分類せず、AI-only、general server及びData Center全体を同一視しない。Sprint003で比較可能なData Center revenue Actual seriesは存在しない。

Renesasは本Research Design上のPower / embedded supply candidateである。本役割は調査上の分類であり、公式segment、Data Center revenue Actual、supplier share又は投資判断を新たに決定しない。

## 4. Fact — Architecture, Portfolio and Growth Relationships

### 4.1 Grid-to-core portfolio

RenesasはGrid、ESS / UPS、PSU、rack、xPU board及びcore powerに沿うAI infrastructure portfolioを示す。Slide 5は`PORTFOLIO (TODAY)`、slide 6は`PORTFOLIO (MID-TO-LONG TERM)`として、Digital Power、Memory Interface、Control Plane及び関連analog productsを配置する。根拠：`S3-EVR-035`。

TodayとMid-to-Long-Termを統合しない。Mid-to-Long-Termをcurrent availability / adoptionへ変換せず、Today表示もavailability、shipment、design win又はmarket shareのActual証拠とみなさない。

### 4.2 Growth-driver relationships

発行者は、800 V / vertical architectureからpower content / module opportunity、AI xPU / server増加からmemory solutions、grid-to-rack complexityからMCU / control opportunityへの三つの関係を示す。根拠：`S3-EVR-036`。

三edgeを結合せず、Actual、測定済み因果、revenue、unit、market share又はLead / Lagへ変換しない。

### 4.3 Memory Interface / Control opportunity

AI inferenceがCPU / DRAM需要を促しmemory-interface contentを増加させるとの見方と、MCU-based controlの採用が拡大するとの見方を示す。製品構成例の存在contextも提示する。根拠：`S3-EVR-040`。

Renesas shipment、attach rate、revenue、universal BOM、customer configuration又はActual unit demandを推定せず、component countsを数量Factとして採用しない。

### 4.4 800 V architecture response

RenesasはNVIDIA発表の800 V DC architectureへのproduct responseとして、48 V–400 VのGaN solutions、800 Vへ構成可能なstack、MOSFET、drivers及びcontrollersを含むpower portfolioを説明する。根拠：`S3-EVR-042`。

NVIDIA procurement、design win、production deployment、shipment、sales又はcustomer-specific BOMを確定せず、stack可能性を単一productの800 V ratingとみなさない。

## 5. Fact — Scenario and Relative-value Illustrations

### 5.1 Rack power scenario

Next-generation AI rackが1 MW超へ向かい、power content per rackが10倍超になるとのforward-looking contextを示す。根拠：`S3-EVR-037`。

Current rack population、installed base、market average又は実測需要ではなく、component又はrevenue数量を算出しない。

### 5.2 Digital Power units / value

2025からMid-Termへのmanagement illustrationとして`>2x More units`及び`>5x More value`を示す。Entity、currency、absolute base及び実現時期は未確定である。根拠：`S3-EVR-039`。

2030 xPU volume、power content、product ASP、revenue Forecast又はActual growthと同義化しない。

### 5.3 Product relative ASP

`Standard smart power stage (2009-present) = 1x ASP`を基準に、`Dual smart power stage >1.5x`、`Integrated vertical power stage >3x`、`Quad-Phase power tower >8x`を示す。根拠：`S3-EVR-045`。

Currency ASP、realized transaction price、customer mix、shipment、revenue又はmarket shareを算出せず、units / value又はpower content per xPUと同義化しない。

## 6. Fact — Product and Customer Relationship Assertions

### 6.1 800 V GaN / MOSFET design-in assertion

Renesasは800 V向けGaN / MOSFETへ投資し、D-mode GaN及びefficiency / power-density characteristicsを示す。Latest MOSFETがnext-generation boardsへ`designed into`されたと説明する。根拠：`S3-EVR-038`。

Customer / board identity、量産、shipment、revenue、market share又はNVIDIA採用を確定せず、第三者確認済みdesign winとみなさない。

### 6.2 Anonymous customer-board relation

Leading next-generation AI boardにDigital multiphase core power、IBC及びMOSFETを含むtotal power solutionを提供し、そのperformanceを`our customer`が測定したと説明する。48 V IBC例は`>5 Digital controllers` / `>30 MOSFETs`、GPU Power例は`>10 Digital controllers` / `>100 Smart power stages`である。根拠：`S3-EVR-044`。

Customer / board identity、test condition、adoption stage、order、shipment、revenue又はproduction deploymentを確定しない。Customer測定を第三者独立benchmark、数量例をuniversal BOMとみなさない。

`S3-EVR-037`のgeneral rack scenario、`038`のdesign-in assertion及び`044`のanonymous direct relationを相互に統合しない。

## 7. Fact — Utilization, Investment and Capacity Strategy

### 7.1 Front-end utilization — Actual-period context

Front-end wafer input基準の1Q 2026 utilizationは約55%、前四半期比約6pt上昇した。Nakaの12-inch MCU / 40nm MCU及びSaijoのdigital power製品の需要増加に対応してwafer inputを増加したと説明する。根拠：`S3-EVR-033`。

全工場又は全設備の稼働率とみなさず、Data Center向けwafer、製品、shipment、revenue又はcapacityを推定しない。

### 7.2 Decision-based investment Plan

1Q decision-based investmentはJPY94bn、その80%はcapacity expansionである。AI、Data Center、digital power applicationsをin-houseで製造するためfront-endを中心に投資し、back-end packages / modules capacityも増加させるPlanを説明する。根拠：`S3-EVR-043`。

JPY75.2bnを算出せず、金額又は比率を用途、製品、工程又はfactoryへ配賦しない。Actual cash expenditure、completed capacity又はcommitted productionとみなさない。

### 7.3 Hybrid manufacturing strategy

AI需要がvolatileであり得るとの文脈で、in-house manufacturingとexternal foundriesを組み合わせ、需要に応じてcapacityを追加するmodelを説明する。根拠：`S3-EVR-041`。

Capacity量、foundry identity、wafer commitment、utilization、product allocation又は実現時期を推定せず、供給確保又はcapacity Actualとみなさない。

`S3-EVR-033`のActual-period observation、`041`のoperating strategy及び`043`のPlanを一つのcapacity series又は需要因果chainへ統合しない。

## 8. Cross-source Inference — Research Only

### REN-INF-001 — Renesas defines a grid-to-core opportunity system

`S3-EVR-035`,`036`,`040`,`042`を併せると、RenesasはAI Infrastructureの機会をgrid-to-core architecture、power、memory interface及びcontrolの複数領域としてpositioningしていると整理できる。

**制約：** Industry-standard architecture、available portfolio、adoption、supplier share、unit demand又はrevenue規模を証明しない。

### REN-INF-002 — Commercial assertion grains require separate tracking

`S3-EVR-038`,`042`,`044`は、design-in assertion、architecture response及びanonymous customer-board direct relationという異なるcommercial / relationship grainを示す。

**制約：** 三Factを単一customer、NVIDIA adoption、order、shipment、production又はrevenueへ統合せず、assertionの数をcommercial progress scoreへ変換しない。

### REN-INF-003 — Supply response is not a Data Center demand series

`S3-EVR-033`,`041`,`043`は、front-end wafer-input utilization、hybrid manufacturing strategy及びmixed-scope investment Planを別Factとして追跡できることを示す。

**制約：** Data Center-specific utilization、capacity、wafer、shipment、revenue、fixed Lead / Lag又はForecast achievementへ変換しない。

これらはCompany Research上のInferenceであり、EVR、PIT、Catalog Fact又はObservationとして登録しない。

## 9. Research Question Disposition

| Research Question | Renesasでの回答 | Disposition |
| --- | --- | --- |
| `S3-DCAI-RQ-001` | AI Infra & Compute、AI / general server、prospective data center revenue、grid-to-core及びproduct scopeは異なる。 | Evidence supported; prospective definition boundary |
| `S3-DCAI-RQ-004` | Grid-to-core、Digital Power、Memory Interface、Control Plane、GaN / MOSFET及び800 V responseをissuer positioningとして確認できる。 | Evidence supported; architecture / product boundaries required |
| `S3-DCAI-RQ-005` | Design-in、architecture response及びanonymous customer-board relationはあるが、需要側投資からRenesas order、shipment又はrevenueへ至る単一Source Factは確認できない。 | Partial support + bounded Negative Evidence |
| `S3-DCAI-RQ-006` | Actual-period utilization、definition、strategy、scenario、relative illustration、design-in / customer assertion及びPlanを分離する必要がある。 | Evidence supported; classification / denominator control required |
| `S3-DCAI-RQ-007` | 将来追跡候補はprospective data center revenue、utilization、investment、product relation及びrelative illustrationであるが、現在はObservation未採用である。 | Japan-equity follow-up topics only; no downstream use |

## 10. Japan-equity Follow-up Topics — 未採用

| Topic | Evidence basis | 必要な追加確認 | 現在の境界 |
| --- | --- | --- | --- |
| Prospective `data center revenue` | `S3-EVR-034` | First Actual、scope、period、restatement、AvailableAt authority | 過去売上へ遡及しない |
| Front-end utilization | `S3-EVR-033` | Repeatability、product / application allocation、Data Center-specificity | Demand / revenue Observationではない |
| Capacity investment | `S3-EVR-043` | Actual expenditure、completion、capacity量、allocation | Planであり用途配賦しない |
| Product / relationship stage | `S3-EVR-038`,`042`,`044` | Customer、product、stage、order / shipment / revenue | Assertionsをadoptionへ統合しない |
| Relative content / ASP | `S3-EVR-037`,`039`,`045` | Denominator、absolute base、Actual transition | Absolute demand / valueを導出しない |
| Supply strategy | `S3-EVR-041` | Foundry、capacity、timing、product allocation | Capacity Actualではない |

これらは`S3-DCAI-RQ-007`に対応する未採用Research Topicであり、Observation、Feature、Lead / Lag Indicator、Knowledge Catalog Candidate、投資signal又は`AvailableAt`決定ではない。

## 11. Gaps and Negative Evidence

1. Prospective `data center revenue`の最初のActual、scope、period、過去restatement及びdefinition continuityは未確認。
2. Front-end utilization、JPY94bn / 80% investment及びhybrid strategyのData Center、product、wafer、factory、capacity又はrevenueへの配賦は未確認。
3. Relative units / value / ASP、rack power及びcomponent countsのabsolute base、currency、market population及びActual transitionは未確認。
4. Design-in、architecture response及びanonymous customer-board assertionについて、customer identity、adoption stage、order、shipment、production及びrevenueは未確認。
5. `REN-SFI-008`,`015`,`018`は第三者forecast、mixed-scope shipment又はprovenance / horizon reconciliation未解決のHoldであり、本ResearchのFact baselineへ含めない。
6. `REN-SFI-001`–`003`はSprint002 Evidence参照専用であり、Sprint003 Factとして再発行しない。
7. 2026-07-30までに確認した記録済み公式Source Setでは、hyperscaler investment又はNVIDIA demandからRenesasのorder、shipment又はrevenueへ定量的に直接至る開示を確認できなかった。これは関係又は資料が存在しないことの証明ではない。

## 12. Update Triggers

- Prospective `data center revenue`の最初のActual、definition、period及びrestatement開示。
- Front-end utilization、JPY94bn investment及びhybrid manufacturingのActual progress / allocation更新。
- 800 V、GaN / MOSFET、anonymous customer board又はnamed customerのstage更新。
- Units / value / ASP、rack power又はcomponent countのdenominator / Actual bridge開示。
- Hold候補のforecast provenance、shipment scope又はhorizon reconciliation解消。

Update Triggerは自動採用を意味しない。新しいSource Eventは再Inspection、Raw Review、EVR Review及びPIT Reviewを経る。

## 13. Downstream Boundary and Next Handoff

本文書から次へ接続できるのは、Reviewed Draft Baseline及びPhase 1 Closureの再照合だけである。

- 新しいEvidence ID又はPIT IDを発行しない。
- `REN-INF-001`–`003`をEvidence又はCatalog Factへ登録しない。
- Japan-equity Follow-up TopicをObservation、Feature又はLead / Lag Indicatorとして採用しない。
- `AvailableAt`を決定しない。
- Catalog、DDL、Entity、Database、ML、Backtest、Decision Engine、Advisor及び投資判断に利用しない。
- Phase 2を開始しない。
