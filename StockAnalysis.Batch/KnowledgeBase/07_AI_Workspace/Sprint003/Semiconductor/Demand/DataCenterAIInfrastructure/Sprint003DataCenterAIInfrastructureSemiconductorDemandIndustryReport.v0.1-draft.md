# Sprint003 Data Center / AI Infrastructure Semiconductor Demand — Industry Report

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft industry research report |
| Sprint | Sprint003 |
| 対象 | Semiconductor → Demand → Data Center / AI Infrastructure |
| Version | 0.1-draft |
| 作成日 | 2026-08-11 |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Author | Documentation Team — Research Author persona |
| Reviewer | Evidence Validation / Chief Knowledge / Traceability reviewers — Accepted |
| 上流Scope | `Sprint003DataCenterAIInfrastructureSemiconductorDemandScopeDesign.v0.1-draft.md` |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md` |
| Definition Matrix | `Sprint003DataCenterAIInfrastructureDefinitionAndComparabilityMatrix.v0.1-draft.md` — Independent Review Accepted |
| Evidence Register | `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` — `S3-EVR-001`–`132` Independent Review Accepted |
| PIT Inventory | `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` — `S3-PIT-001`–`132` Independent Review Accepted |
| Review Record | `Sprint003DataCenterAIInfrastructureSemiconductorDemandIndustryReportIndependentReview.v0.1-draft.md` |
| AvailableAt | 全132件 `TBD — no use` |
| Catalog Eligibility | 全132件 No |

> **利用境界：** 本ReportはAccepted Draft Evidenceを業界単位で横断整理するDraft Research Assetである。Canonicalな業界定義、市場規模、需要予測、因果関係、Knowledge Catalog、DDL、Entity、Database、ML、バックテスト、Decision Engine、Advisor又は投資判断の根拠を作らない。

## 1. Purpose and Scope

Data Center / AI Infrastructureに関係する半導体需要について、需要・システム側の投資 / capacity文脈、Compute platform側のrevenue / reporting文脈、Power Semiconductor / Power Management側のarchitecture / product / commercial-stage文脈を、一次開示と比較制約に基づき統合する。

目的は、市場規模又は需要伝播を推定することではない。次を明確にすることを目的とする。

1. 発行者が何をData Center、AI Infrastructure、Server又はPower opportunityとして開示しているか。
2. 需要側、Compute側及びPower supply側で、何がActual、Forecast、Target、Plan、Scenario又はRelationshipなのか。
3. 日本株対象のRenesas及びROHMについて、投資判断に先立つResearch上の観測候補とGapが何か。
4. Industry Reportから後続Researchへ引き渡せる比較境界と、引き渡してはならない未立証関係が何か。

### 1.1 Included Core Companies

| Role | Company | Report function |
| --- | --- | --- |
| Demand-side | Microsoft | Data Center / Cloud / AI Infrastructure investment、commitment、server / energy dependency |
| Demand-side | Alphabet | Technical infrastructure、Data Center construction、CapEx、capacity timing、Cloud backlog |
| Compute supply | NVIDIA | Data Center platform、revenue、reporting transition、supply / energy / market-access context |
| Power / embedded supply candidate | Renesas Electronics | AI Infra & Compute、grid-to-core、digital power、800 V、capacity strategy |
| Power supply candidate | ROHM | Server Business、Si / SiC / GaN、AI server / Data Center product stage、named relationship |
| Power benchmark candidate | Infineon | AI power revenue、PSS、grid-to-core、PSU / IBC、NVIDIA / Intel / anonymous relationship |

### 1.2 Explicitly Out of Scope

- Semiconductor manufacturing equipment、materials又はpackagingを別SubSectorとして拡張すること。
- Market size、supplier share、industry CAGR、unit demand又はsemiconductor purchase amountを算出すること。
- Currency換算、会計period変換又はissuer definitionの正規化による企業ranking。
- Lead / Lag、相関、因果、特徴量、weight、threshold又は投資signalの採用。
- Phase 2 Value Chain / Indicator work、Catalog、DDL又は実装を先取りすること。

## 2. Evidence Base and Status

| Issuer | EVR / PIT | Count | Review state | Use state |
| --- | --- | ---: | --- | --- |
| Microsoft | `001`–`009` | 9 | Independent Review Accepted | `TBD — no use`; Catalog `No` |
| Alphabet | `010`–`020` | 11 | Independent Review Accepted | `TBD — no use`; Catalog `No` |
| NVIDIA | `021`–`032` | 12 | Independent Review Accepted | `TBD — no use`; Catalog `No` |
| Renesas | `033`–`045` | 13 | Independent Review Accepted | `TBD — no use`; Catalog `No` |
| ROHM | `046`–`092` | 47 | Independent Review Accepted | `TBD — no use`; Catalog `No` |
| Infineon | `093`–`132` | 40 | Independent Review Accepted | `TBD — no use`; Catalog `No` |
| **Total** | `001`–`132` | **132** | Draft Evidence baseline | Draft / noncanonical |

Evidence IDの存在は、FactのCanonical化、`AvailableAt`決定、企業間比較の許可又は投資上の有効性を意味しない。Hold、Reference-only及びDuplicate / corroborating候補は、各Accepted GateのDispositionを維持し、本Reportで新しいEvidenceへ昇格させない。

## 3. Issuer-defined Terminology and Reporting Boundary

### Fact

- MicrosoftはData Center、server capacity、Cloud / AI Infrastructure、Microsoft Cloud及びAzure and other cloud servicesを異なる文脈で使用する。`S3-EVR-001`,`005`,`007`–`009`
- AlphabetはAI-optimized infrastructure、technical infrastructure、Data Center construction、Google Cloud及びspecialized GPU / TPUを異なる測定対象として開示する。`S3-EVR-010`,`012`,`015`–`020`
- NVIDIAのData CenterはGPU単体ではなく、Compute / Networking systems、modules、software / servicesを含むplatform scopeである。Q1 FY2027にはHyperscale / ACIEという新reporting frameworkを示すが、旧区分との数値mappingは未確認である。`S3-EVR-021`,`025`
- RenesasはAI / non-AI境界が曖昧になるとして、今後当該businessを`data center revenue`としてreporting / discussingすると説明するが、過去IIoT又はAI Infra & Computeを遡及再分類しない。`S3-EVR-034`
- ROHMはServer Business、AI server / AI data server、Computer & Storage、Data Center及びDiscrete Semiconductorという複数Scopeを使う。`S3-EVR-046`–`054`,`074`
- InfineonはAI-server power-supply components、AI data-center power-supply solutions、dedicated AI power revenue、AI revenue in server business、PSS及びoverall SiC businessという複数Scopeを使う。`S3-EVR-093`–`106`

### Research-level Inference

`Data Center / AI Infrastructure Semiconductor Demand`は、単一の発行者区分又は会計segmentではなく、施設・capacity、Compute platform、power-conversion architecture、product application及びcommercial-stage開示を接続して調査する作業上のResearch Scopeである。

### Boundary

このInferenceはCanonical SubSector definitionを作らない。Data Center、AI Infrastructure、Cloud、Server、AI power及びPSSを同義化せず、各Factは発行者のScopeを保持する。

## 4. Demand-side Investment and Capacity Context

### 4.1 Microsoft

#### Fact

- Property and Equipment additionsはFY2023 USD28.107bn、FY2024 USD44.477bn、FY2025 USD64.551bn。FY2026 9か月はUSD80.146bn、3か月はUSD30.876bnである。全社cash-flow observationである。`S3-EVR-002`,`006`
- 2025-06-30時点のconstruction commitmentsはUSD32.1bnで、`primarily` Data Center関連と説明される。Purchase commitmentsはFY2026 USD103.940bn、Thereafter USD6.013bn、Total USD109.953bnである。CommitmentでありActual expenditure又はsemiconductor orderではない。`S3-EVR-003`,`004`
- Cloud offerings、AI Infrastructure及びtrainingを支えるcapital investment Planと、Data Center / server capacityがland、energy、networking supplies及びGPUを含むserversへ依存するとの説明がある。`S3-EVR-001`,`005`
- Microsoft Cloud revenue、Azure growth及びCloud / AI demand contextは開示されるが、Data Center investment又はsemiconductor demandの直接Observationではない。`S3-EVR-007`–`009`

#### Boundary

全社Property and Equipment additions、construction commitments及びpurchase commitmentsを合算せず、Data Center、AI、server、GPU又はsemiconductorへ配賦しない。

### 4.2 Alphabet

#### Fact

- CapExはFY2024 USD52.5bn、FY2025 USD91.4bn。FY2026 CapEx ForecastはUSD175bn–185bnである。FY2025 ActualとFY2026 Forecastを分離する。`S3-EVR-011`,`017`,`018`
- Technical infrastructureはservers / network equipment、Data Center land、building construction / improvementsを含み、constructionは複数年・複数phaseで進むと説明される。`S3-EVR-012`
- Gross in-service technical-infrastructure assetsは2024年末USD141.852bn、2025年末USD203.679bnで、両時点の約60%がservers and network equipmentとされる。CapEx又はnet carrying amountとは別測定対象である。`S3-EVR-013`
- Commitments / contractual obligationsは2025年末Total USD149.1bn、short-term USD113.0bnで、energy、licenses、technical infrastructure、inventory等のmixed scopeである。`S3-EVR-014`
- Google Cloud backlog USD240bnとenterprise AI offerings需要、capacity constraint及びinvestment-to-availabilityの時間差が説明される。Backlogをrevenue、CapEx又はsemiconductor demandへ変換しない。`S3-EVR-019`,`020`
- Google Cloudはspecialized GPUs及びcustom-built TPUsを含むaccelerator optionsを提供し、specialized AI chip供給を少数のqualified suppliersへ依存するriskを開示する。Quantity、supplier identity又はpurchase shareは未開示である。`S3-EVR-010`,`015`

#### Boundary

CapEx、gross assets、commitments及びbacklogは別測定対象である。60 / 40 compositionを総CapExへ機械配賦せず、GPU / TPU又はsemiconductor amountを導出しない。

### 4.3 Demand-side Synthesis — Inference

**DCAI-INF-001（Research-level Inference）：** Microsoft及びAlphabetの開示は、AI / Cloud capacity expansionがland、building、energy、networking、servers及びmulti-year constructionを含む複合的なinfrastructure processとして管理されていることを示唆する。根拠：`S3-EVR-001`,`003`–`005`,`012`–`014`,`016`,`018`,`020`。

**制約：** CapExから半導体購入額又はsupplier revenueを算出せず、construction開始からsemiconductor demandまでの固定Lead / Lagを設定しない。

## 5. Compute Platform Disclosure Structure

### Fact

- NVIDIA Data Center revenueはFY2024 USD47.525bn、FY2025 USD115.186bn、FY2026 USD193.7bn。Q4 FY2026はUSD62.3bn、Q1 FY2027はUSD75.2bnである。Data Center platform scopeでありGPU単体売上ではない。`S3-EVR-022`–`024`
- FY2026 growthはData Center compute / networking platforms for accelerated computing and AI solutionsにより牽引され、Blackwell architecturesはData Center revenueの`majority`と説明される。比率又は金額を推定しない。`S3-EVR-026`
- Data Center platformはGPU、CPU、interconnect、software及びnetworking components / systemsを含む。Q1 FY2027のHyperscale / ACIE transitionについて旧Compute / Networkingとのrestatementは未確認である。`S3-EVR-021`,`025`
- Consolidated obligations USD95.2bn、component constraint risk、energy / capital dependency、China market-access restriction、H20 inventory charge USD4.5bn及びQ2 FY2027全社revenue outlook USD91.0bn±2%が開示される。各Factのscopeと時点を分離する。`S3-EVR-027`–`032`

### Research-level Inference

**DCAI-INF-002：** NVIDIAの開示は、AI Compute demand realizationがCompute / Networking platform revenueだけでなく、component availability、datacenter-scale production、energy、capital及びmarket accessの複数制約に依存することを示唆する。根拠：`S3-EVR-021`,`026`–`028`,`030`–`032`。

### Boundary

NVIDIAのData Center revenue又はgrowth rateを、半導体業界全体の需要、GPU unit demand、power semiconductor需要又はRenesas / ROHM / Infineon revenueへ一般化しない。China / H20 Factを通常のGlobal AI demand cycleへ一般化しない。

## 6. Power Semiconductor / Power Management Disclosure Structure

### 6.1 Renesas Electronics

#### Fact

- `PORTFOLIO (TODAY)`と`PORTFOLIO (MID-TO-LONG TERM)`を分け、Digital Power、Memory Interface、Control Plane及びanalog productsをgrid-to-coreへ配置する。`S3-EVR-035`
- 800 V / vertical architectureからpower content / module opportunity、AI xPU / server増加からmemory solutions、grid-to-rack complexityからMCU / control opportunityという三つのmanagement relationshipsを示す。Actual又は測定済み因果ではない。`S3-EVR-036`
- Next-generation AI rackが1MW超、power content per rackが10倍超となるscenario、2025からMid-Termの`>2x More units` / `>5x More value`、product relative ASP illustrationを示す。三つの分母・Factを統合しない。`S3-EVR-037`,`039`,`045`
- 800 V向けGaN / MOSFET design-in assertion、48V–400V GaN solutions等のarchitecture response、anonymous customer-board solution assertionがある。Customer identity、order、shipment、revenue又はNVIDIA procurementは未確認である。`S3-EVR-038`,`042`,`044`
- Q1 2026 front-end wafer-input utilizationは約55%、前四半期比約6pt上昇。Decision-based investment JPY94bnの80%をcapacity expansionとするPlanがある。稼働率とinvestment Planを別Factとして保持する。`S3-EVR-033`,`043`
- Hybrid manufacturing strategyとMemory Interface / Control opportunityはmanagement strategyであり、capacity Actual又はunit demandではない。`S3-EVR-040`,`041`

#### Boundary

Renesasについて、Sprint003で比較可能なData Center revenue Actual seriesは存在しない。Relative multiplier、component count、utilization及びinvestment Planからrevenue又はdemand quantityを導出しない。

### 6.2 ROHM

#### Fact — Business / demand context

- FY2025 Server Business salesはJPY17.0bn。FY2026 JPY25.0bn、FY2028 JPY30.0bn、FY2030 JPY100bn超はTargetsである。Server BusinessはAI server又はData Center単独とは定義されない。`S3-EVR-050`,`051`
- Computer / Storage向けSiC salesのFY2026前年比2.5倍はForecast、AI server向けpower devicesのFY2025–FY2030 CAGR +48%はissuer research / Forecastである。`S3-EVR-047`,`048`
- FY2024 Discrete Semiconductor net sales JPY187bnに対するComputer & Storage application share 9.1%はmixed-scope Actualである。金額を機械算出しない。`S3-EVR-054`
- AI server business expansion及びAI data servers中心のadoption assertionはあるが、product / customer / quantity / revenue contributionは未開示である。`S3-EVR-046`,`074`

#### Fact — Architecture / products / stage

- Next-generation AI server scenarioはmain boards 18→72、power consumption 13kW→1,000kW、power components 600→22,000、analog components 300→17,000を示す。Current average又はuniversal BOMではない。`S3-EVR-049`
- Internal analysisは800VDC architectureでpower-source側にSiC、IT-rack側にGaNをpositioningし、ICとpower devicesを組み合わせるtotal-solution strategyを示す。`S3-EVR-052`,`053`
- NVIDIA 800 V HVDC architectureへのROHM product responseがあるが、NVIDIA procurement、design win又はcommercial deploymentを確定しない。`S3-EVR-060`
- Si MOSFET、Super Junction MOSFET、5th Generation SiC、150V / 650V GaN、gate driver及びoptical moduleについて、Strategy、Development、Sample Plan、Availability、Mass-production Plan / commencement及びapplication positioningがSource Event別に存在する。`S3-EVR-055`,`056`,`058`,`059`,`062`–`068`,`070`,`071`,`073`,`076`,`077`,`079`,`080`,`082`,`084`,`085`,`088`,`090`–`092`
- FY2024からFY2028へのSAM 4倍はproduct lineup強化に関するissuer illustrationであり、product stage、Actual achievement、sales又はshareではない。`S3-EVR-087`
- Murata Power Solutions、Delta Electronics、Ancora Semiconductors及びanonymous counterpartiesとのadoption、production Plan / assertion、joint development、endorsement / recommendationがある。各関係のstageとspeakerを保持する。`S3-EVR-057`,`061`,`069`,`072`,`075`,`078`,`081`,`083`,`086`,`089`

#### Boundary

Product development、sample、availability、application、mass-production Plan、production commencement、adoption、endorsement、recommendation、shipment及びrevenueを相互に置換しない。同じ2022-03 GaN production transitionを説明する`S3-EVR-082` / `091`を二度の進展又は独立需要signalとして数えない。

### 6.3 Infineon

#### Fact — Revenue / operating context

- AI power関連revenueはFY2024約EUR250mからFY2025 EUR700m超へ増加したSource-presented Actualである。FY2026約EUR1.5bnはForecast、FY2027 EUR2.5bnは`indication`である。Definition continuity確認前に単一seriesへ統合しない。`S3-EVR-093`,`094`,`103`
- Historical FY2024 / FY2025 Forecast、two-year Target及びFY2024–FY2029 CAGR Forecastは、後続Actual / Forecast / indicationとSource Event別に保持する。`S3-EVR-114`,`115`,`126`,`127`
- FY2026 PSS revenueはAI data-center power-supply productsのstrong demand momentumによりGroup平均より大幅に速く成長するとのSegment Forecastである。AI contribution amount又はActual growthではない。`S3-EVR-097`
- FY2026 Free Cash Flow ForecastにはDresden frontend manufacturing及びAI data-center power-supply capacity expansionへのsignificant investment cash outflowsが含まれる。Mixed investment Planであり、AI-specific amount、capacity、wafer、product又はcustomerへ配賦しない。`S3-EVR-098`
- PSS Q2 FY2026 revenue EUR1.260bn、Segment Result EUR257m、margin 20.4%はPSS segment ActualでありAI単独ではない。AI / radar growth driverとoverall SiC growth assertionもmixed scopeである。`S3-EVR-099`,`100`,`106`
- AI businessのallocation、demandがsupplyをstrongly exceedするcondition、Automotive capacityのAI data-center businessへのredeployment、GaN shipment increase及びdesign-in pipeline expansionが説明される。Product、quantity、backlog又はrevenue impactは未開示である。`S3-EVR-101`,`102`,`104`,`105`,`129`

#### Fact — Architecture / content / products

- Grid-to-core、HV / MV IBC、AI data-center value-chain taxonomy及びfuture 800 V architectureを示す。`S3-EVR-108`,`110`,`112`,`119`
- Historical end-of-decade EUR8bn–12bn addressable-market Forecastは、2026-05-06にUSD100–250/kW・current average約USD175/kWというcontent assessmentへ置き換えられた。新しいabsolute market Forecastを作らない。`S3-EVR-095`,`107`,`130`
- Rack scenario、USD/rack及びUSD/server BOM estimateはdenominatorが異なるため相互変換しない。`S3-EVR-113`,`116`,`125`
- 3 / 3.3 / 8 / 12 kW availability、16+ / 27 / 30 kW roadmap、18 kW reference design、30 kW evaluation board、performance assertion及びevaluation availability PlanをSource Event / stage別に保持する。`S3-EVR-109`,`111`,`117`,`118`,`120`–`122`,`131`,`132`
- NVIDIAとの800 V共同開発、Intel Sapphire Rapids offering、NVIDIA speaker assertion及びanonymous design-win assertionがある。Procurement、order、shipment、revenue又はexclusive relationを確定しない。`S3-EVR-096`,`123`,`124`,`128`

#### Boundary

AI power revenue、PSS及びoverall SiC businessを相互に配賦しない。Availability、roadmap、reference design、evaluation Plan、design win及びcommercial shipmentを同一stageとしない。

## 7. Cross-company Industry Synthesis — Inference, Not Fact

| Inference ID | Research-level Inference | Evidence basis | Constraint |
| --- | --- | --- | --- |
| DCAI-INF-003 | AI Infrastructureの電力供給は、Grid / facility側からRack / board / Core側まで複数conversion stageを持つ機会として、Renesas、ROHM及びInfineonの各発行者にpositioningされている。 | Renesas `035`,`036`,`042`; ROHM `052`,`053`,`060`; Infineon `108`,`110`,`112`,`119` | 共通architecture、industry standard、adoption率、supplier share又は売上規模を証明しない |
| DCAI-INF-004 | Rack power又はpower densityの上昇は、各発行者がpower content、device count、BOM又はhigher-power product opportunityを説明する共通文脈である。 | Renesas `037`,`039`,`044`,`045`; ROHM `049`; Infineon `107`,`111`,`113`,`116`,`118`,`121`,`125` | 分母・scenario・test conditionが異なる。共通数量、平均BOM、TAM又はrevenue Forecastを作らない |
| DCAI-INF-005 | Power supplierのproduct / commercialization開示は、Strategy、Development、Sample、Availability、Application positioning、Reference-design / Evaluation-board introduction、Internal engineering illustration / product-performance assertion、Evaluation availability Plan、Roadmap、Mass-production Plan、Production commencement、Design-in、Adoption、Endorsement、Recommendation、Customer-board assertion、external-speaker assertion、Shipment assertion及びrelationshipという別stage又は別assertion grainへ分散している。 | Renesas `038`,`044`; ROHM `055`,`056`,`057`,`058`,`059`,`061`,`062`,`063`,`064`,`066`,`067`,`068`,`069`,`070`,`071`,`072`,`075`,`076`,`077`,`078`,`079`,`080`,`081`,`082`,`083`,`084`,`085`,`086`,`088`,`089`,`090`,`091`,`092`; Infineon `096`,`104`,`105`,`109`,`111`,`117`,`118`,`120`,`121`,`122`,`123`,`124`,`128`,`131`,`132` | `ROHM 087`のSAM illustration等をstage根拠へ混入せず、Engineering / performance assertionをcommercial resultへ変換せず、Endorsement / Recommendation / solution assertionをAdoptionへ昇格しない。Stage / assertion grainを順位、需要量、commercial success又は投資評価へ変換しない |
| DCAI-INF-006 | Demand-side investment、Compute platform revenue及びPower supplier開示を同じ業界Research内で追跡する価値はあるが、現在のEvidenceは三層間の定量的なDirect relationを確立しない。 | Demand-side `001`–`020`; Compute `021`–`032`; supplier relationship facts: Renesas `038`,`044`、ROHM `057`,`061`,`069`,`072`,`075`,`078`,`081`,`083`,`086`,`089`、Infineon `096`,`123`,`124`,`128` | 異なる発行者のFactを組み合わせて注文、売上、倍率、Lead / Lag又は因果を生成しない |

これらのInferenceをEVR、Knowledge Catalog又は特徴量として登録しない。

## 8. Research Question Disposition

| Research Question | Research-level answer | Current status |
| --- | --- | --- |
| `S3-DCAI-RQ-001` | Data Center / AI Infrastructureは、施設・capacity、technical infrastructure、Compute platform、Power architecture及びissuer-specific revenue / application scopeに分かれる。単一の発行者定義ではない。 | Evidence supported; noncanonical working scope |
| `S3-DCAI-RQ-002` | Microsoft / AlphabetのCapEx、commitment、assets、backlog及びcapacity timingは需要側contextを示すが、半導体購入額又はsupplier revenueへ配賦できない。 | Evidence supported; no semiconductor-demand conversion |
| `S3-DCAI-RQ-003` | NVIDIA Data Center revenueはplatform-scale demand realizationのissuer observationだが、GPU単体又はpower semiconductor需要を表さず、reporting transition及びsupply / energy / market-access制約がある。 | Evidence supported; platform-scope boundary |
| `S3-DCAI-RQ-004` | Renesas、ROHM及びInfineonはgrid-to-core / 800 V / PSU / IBC / Si / SiC / GaN等を明示するが、architecture、application、product stage及びrevenue scopeは企業別に異なる。 | Evidence supported; comparability controls required |
| `S3-DCAI-RQ-005` | Issuer別のinfrastructure dependency、product positioning及びnamed / anonymous relationship Factはあるが、需要側投資から特定半導体product、demand、order、shipment又はsupplier revenueへ直接接続する単一Source Factは確認できない。異なる発行者のFactを組み合わせてDirect relationを作らない。 | Partial support + bounded Negative Evidence |
| `S3-DCAI-RQ-006` | Actual、Forecast、Target、indication、Plan、scenario、estimate、definition及びrelationshipが混在し、currency・period・denominator・stageを越えた単純比較は不可。 | Evidence supported; Matrix controls apply |
| `S3-DCAI-RQ-007` | Renesasは利用可能なData Center revenue seriesを持たず、portfolio / utilization / investment / scenario中心。ROHMはServer Business Actual / Targetsとproduct-stage / relationship開示を持つが、AI server / Data Center単独seriesではない。両社とも将来追跡候補はあるが、現在はObservation未採用である。 | Japan-equity follow-up topics only; no downstream use |

## 9. Japan-equity Relevance and Follow-up Topics

### 9.1 Renesas

| Follow-up topic | Evidence | Current state | Required before adoption |
| --- | --- | --- | --- |
| Prospective `data center revenue` reporting | `034` | Definition / reporting transition | First reported Actual、scope、period、restatement及びAvailableAt authority |
| Front-end utilization | `033` | Actual-period wafer-input observation | Product / application allocation、repeatability、Data Center-specificity |
| Capacity investment | `043` | Decision-based Plan | Actual expenditure、completion、capacity量、用途別配賦禁止 |
| Product stage / relationship | `038`,`042`,`044` | Design-in / architecture response / anonymous customer assertion | Customer、product、stage、shipment / revenue境界 |
| Relative content illustrations | `037`,`039`,`045` | Scenario / relative multipliers | Denominator、Actual transition、absolute value非導出 |

### 9.2 ROHM

| Follow-up topic | Evidence | Current state | Required before adoption |
| --- | --- | --- | --- |
| Server Business sales | `050`,`051` | FY2025 Actual / future Targets | Definition continuity、対象product、Actual / Target分離、AvailableAt authority |
| Computer / Storage / AI server outlook | `047`,`048`,`054` | Forecast / mixed-scope Actual share | AI-only bridge、base amount、用途定義 |
| Product-stage transition | `058`,`059`,`062`,`063`,`064`,`066`,`067`,`068`,`070`,`071`,`073`,`076`,`077`,`079`,`080`,`082`,`084`,`085`,`088`,`090`,`091`,`092` | Development / Plan / availability / production / application positioning | Product identity、stage vocabulary、duplicate-event handling、下流利用禁止。Relationship、architecture、SAM illustrationを混入しない |
| Named / anonymous relationship | `057`,`061`,`069`,`072`,`075`,`078`,`081`,`083`,`086`,`089` | Multiple assertion types | Counterparty、speaker、stage、order / shipment / revenue非開示の保持 |
| Supply-system progress | `065`,`082`,`091` | Decision / Plan / system / product statements | 2027 progress、capacity、同じ2022-03 transitionの非二重計上 |
| SAM illustration | `087` | FY2024→FY2028 relative-market illustration | Product stage、Actual achievement、sales、share又はindustry Forecastへ変換しない |

これらは`S3-DCAI-RQ-007`に対応するResearch follow-up topicであり、Knowledge Catalog Candidate、ML feature又は投資signalではない。

## 10. Definition and Comparability Controls

1. Microsoft / AlphabetのCapEx、commitment、assets及びbacklogを同一測定値として合算しない。
2. NVIDIA Data Center revenueをGPU又はsemiconductor単体売上とみなさない。
3. NVIDIAの旧Compute / Networkingと新Hyperscale / ACIEをmappingなしに接続しない。
4. ROHM Server Business、Computer & Storage、AI server及びData Centerを同義化しない。
5. Infineon AI power revenue、PSS及びoverall SiC businessを同義化しない。
6. Renesas relative value / ASP、ROHM component scenario、Infineon per-kW / rack / server estimateを相互換算しない。
7. Actual、Forecast、Target、indication、Plan、scenario、estimate及びrelationshipを相互に置換しない。
8. Development、Sample、Availability、Application positioning、Reference-design / Evaluation-board introduction、Internal engineering illustration / product-performance assertion、Evaluation availability Plan、Roadmap、Mass-production Plan、Production commencement、Design-in、Adoption、Endorsement、Recommendation、Customer-board assertion、external-speaker assertion、Shipment assertion及びRevenueを別stage又は別assertion grainとして保持する。Engineering / performance assertionをcommercial resultへ変換せず、Endorsement、Recommendation又はsolution assertionをAdoptionへ昇格しない。
9. Anonymous partyをnamed customerへ変換せず、異なるanonymous assertionを同一party又はcorroborationとみなさない。
10. Currency換算、growth ranking、合算、共通proxy又はindustry averageを作らない。

## 11. Gaps, Risks and Explicit Non-claims

### 11.1 Major Gaps

1. Demand-side CapEx / commitmentからserver、GPU、power semiconductor又は特定supplierへの配賦比率。
2. NVIDIA reporting transition前後のrestatement / mapping及びData Center revenueからpower contentへのbridge。
3. Renesas prospective `data center revenue`の最初のActual seriesと過去scope continuity。
4. ROHM Server Business、Computer & Storage、AI server及びData Centerのdefinition bridge。
5. Infineon AI power revenueのPublication Event間definition continuity及びPSS / SiC bridge。
6. Rack、server、per-kW、relative value及びcomponent count間のconfiguration / denominator bridge。
7. Roadmap、availability、design-in、adoption、shipment及びrevenue間のproduct-stage transition。
8. Hyperscaler investment又はNVIDIA demandからRenesas / ROHM / Infineonのorder、shipment又はrevenueへ至る定量的Direct relation。
9. Publication time / timezone及び承認済み`AvailableAt` Operating Convention。

### 11.2 Risks

- 共通する`AI`、`Data Center`、`Server`又は`Power`という語だけで異なるScopeを同一化するリスク。
- CapEx、commitment、backlog、revenue及びcapacity conditionを一つの需要指標へ統合するリスク。
- Product application又はarchitecture responseをActual adoptionへ昇格するリスク。
- Forecast、Target及びscenarioをActual demandとして扱うリスク。
- Relationship assertionをsupplier selection、exclusive supply又はcommercial magnitudeへ拡張するリスク。
- Current disclosureだけから固定Lead / Lag、cycle又はpredictive featureを設定するリスク。

### 11.3 Explicit Non-claims

- Data Center / AI Infrastructure semiconductor market size、CAGR、unit demand、supplier share又は企業rankingを主張しない。
- Power semiconductor demandがhyperscaler CapExと一定倍率又は時差で連動すると主張しない。
- 800 V architectureが唯一のindustry standard又は全Data Centerへ採用済みと主張しない。
- Renesas、ROHM又はInfineonの投資魅力度、競争優位又は将来業績を評価しない。
- Candidate follow-up topicをCatalog、DDL、ML又はAdvisorへ渡さない。

Negative Evidenceは、調査cut-offまでに記録した公式Source Setで確認できなかったことだけを意味し、関係又は資料の不存在を証明しない。

## 12. Update Triggers

- Microsoft / Alphabetの通期・四半期CapEx、commitment、Data Center capacity及びAI infrastructure定義更新。
- NVIDIA Data Center reporting frameworkのrestatement、Compute / Networking又はHyperscale / ACIE数値開示。
- Renesasのprospective `data center revenue` Actual、capacity investment進捗及びproduct-stage更新。
- ROHM Server Business Target revision / Actual、2027 GaN supply-system及びnamed relationshipのstage更新。
- Infineon FY2026 Forecast / FY2027 indicationに対するActual、allocation / capacity redeployment、PSU roadmapのstage更新。
- Named customer、order、shipment、revenue、product数量又は用途別salesの追加開示。
- Hold候補のsource identity、definition、method、version又はallocation Gapの解消。

## 13. Completion and Downstream Boundary

本Reportは、132件のAccepted EvidenceとAccepted Definition and Comparability Matrixに基づくSprint003 Phase 1 Industry Research Draftである。

本文書は、著者から独立したEvidence、Knowledge及びTraceability ReviewでAcceptedとなった。Review Accepted後もDraft / noncanonical、全132件`AvailableAt = TBD — no use`及びCatalog Eligibility `No`を維持する。

本Reportの完成は、Reviewed Draft Baseline、Sprint003 Phase 1 Closure、Project Director Disposition、Phase 2、Knowledge Catalog、DDL又は実装の開始・承認を意味しない。
