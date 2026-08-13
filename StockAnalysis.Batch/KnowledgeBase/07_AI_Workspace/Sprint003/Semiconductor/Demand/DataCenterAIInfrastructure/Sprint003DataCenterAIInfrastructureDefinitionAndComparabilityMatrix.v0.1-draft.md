# Sprint003 Data Center / AI Infrastructure — Definition and Comparability Matrix

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft definition and comparability research asset |
| Sprint | Sprint003 |
| Research Domain | Semiconductor — Demand — Data Center / AI Infrastructure |
| Version | 0.1-draft |
| 作成日 | 2026-08-11 |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Author | Documentation Team — Research Author persona |
| Reviewer | Evidence Validation / Chief Knowledge / Traceability reviewers — Accepted |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md` |
| Evidence Register | `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` — `S3-EVR-001`–`132` Independent Review Accepted |
| PIT Inventory | `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` — `S3-PIT-001`–`132` Independent Review Accepted |
| Company Research | `ROHMCoreCompanyResearch.v0.1-draft.md`; `InfineonCoreCompanyResearch.v0.1-draft.md` — Independent Review Accepted |
| Review Record | `Sprint003DataCenterAIInfrastructureDefinitionAndComparabilityMatrixIndependentReview.v0.1-draft.md` |
| AvailableAt | 全132件 `TBD — no use` |
| Catalog Eligibility | 全132件 No |

> **利用境界：** 本MatrixはAccepted Evidenceの定義差と比較制約を整理するDraft Research Assetである。比較可能性の記載はCanonical Knowledge、Catalog、DDL、特徴量、企業評価、投資判断又は下流利用を承認しない。

## 1. 目的と責務

Microsoft、Alphabet、NVIDIA、Renesas Electronics、ROHM及びInfineonについて、Data Center / AI Infrastructureに関係する発行者定義、測定対象、期間、単位、Fact type、product stage及びrelationship grainを横断整理する。

本Matrixの責務は次の三点に限定する。

1. 同じ又は類似する用語を無条件に同義化しない。
2. Industry Reportで並置できるFactと、定量比較できないFactを区別する。
3. 比較不能又は条件付き比較となる理由をEvidence IDへ追跡可能にする。

本Matrixは新しいSource Fact、比較統制、正規化値、換算値、業界平均又は投資signalを作らない。以下の「比較可能」「条件付き」「比較不可」は本Artifact内のResearch assessmentであり、Governance rule又は下流利用許可ではない。

## 2. Evidence Population

| Issuer | Role in Research Design | EVR / PIT | Count | Current use state |
| --- | --- | --- | ---: | --- |
| Microsoft | Demand-side | `001`–`009` | 9 | `TBD — no use`; Catalog `No` |
| Alphabet | Demand-side | `010`–`020` | 11 | `TBD — no use`; Catalog `No` |
| NVIDIA | Compute supply | `021`–`032` | 12 | `TBD — no use`; Catalog `No` |
| Renesas Electronics | Power / embedded supply candidate | `033`–`045` | 13 | `TBD — no use`; Catalog `No` |
| ROHM | Power supply candidate | `046`–`092` | 47 | `TBD — no use`; Catalog `No` |
| Infineon | Power benchmark candidate | `093`–`132` | 40 | `TBD — no use`; Catalog `No` |
| **Total** |  | `001`–`132` | **132** | Draft / noncanonical |

Reference-only、Duplicate及びHold候補は、各企業のAccepted Evidence Package Gate又はCross-sprint Bridgeに従う。本Matrixは未発行Evidence IDを作らず、Hold Factを比較対象へ復帰させない。

## 3. Issuer-defined Scope and Terminology

| Issuer | Issuer-defined / disclosed scope | Evidence | 同義化してはならない対象 | Comparability assessment |
| --- | --- | --- | --- | --- |
| Microsoft | Data Center、server capacity、Cloud / AI Infrastructure、Microsoft Cloud、Azure and other cloud services | `001`、`005`、`007`–`009` | Data Center、Cloud、Azure、AI Infrastructure、server、GPU | 用語の関係を記述可能。相互の金額・数量mappingは不可 |
| Alphabet | AI-optimized infrastructure、technical infrastructure、Google Cloud、specialized GPU / TPU、Data Center construction | `010`、`012`、`015`–`020` | Technical infrastructure、Data Center、servers、network equipment、GPU / TPU、Cloud backlog | Issuer process / scopeの記述は可能。AI又は半導体への配賦は不可 |
| NVIDIA | Data Center platform、Compute、Networking、Hyperscale、ACIE | `021`–`026` | Data Center revenue、GPU単体、semiconductor単体、旧Compute / Networking、新Hyperscale / ACIE | 同一issuer内でもreporting transition前後の数値mappingは不可 |
| Renesas | AI Infra & Compute、prospective `data center revenue`、Digital Power、Memory Interface、Control Plane、grid-to-core | `034`–`036`、`040` | 旧IIoT、AI-only、general server、Data Center全体、Today / Mid-to-Long-Term portfolio | Issuer strategy taxonomyの記述は可能。遡及再分類とsegment revenue化は不可 |
| ROHM | Server Business、AI server / AI data server、Computer & Storage、Data Center、Discrete Semiconductor | `046`–`054`、`074` | Server Business、AI server単独、Data Center単独、Computer & Storage、Discrete全体 | Definitionが異なるため単一売上series不可。各Scopeの個別記述のみ |
| Infineon | AI-server power-supply components、AI data-center power-supply solutions、dedicated AI power revenue、AI revenue in server business、PSS、overall SiC | `093`–`106` | AI power revenue、PSS segment、SiC全体、Data Center全体、server business | AI power関連開示間もdefinition continuity未確認。PSS / SiCとのbridge不可 |

### 3.1 Cross-issuer term boundary

次の用語は発行者横断で無条件に同義化しない。

- `Data Center`：Microsoft / Alphabetでは施設・capacity・infrastructure文脈、NVIDIAではplatform / reporting scope、供給側3社では用途・strategy・revenue候補を含む。
- `AI Infrastructure`：需要側のcapital / compute infrastructure、NVIDIAのaccelerated computing platform、供給側のpower architecture / portfolioでgrainが異なる。
- `Server`：server capacity、AI server、general server、server business、server BOM及びserver用途productを含み、測定対象が異なる。
- `Revenue`：Cloud、Data Center platform、Server Business、AI power、PSS segment等のissuer-defined scopeが異なる。
- `Demand`：customer demand narrative、backlog、allocation、shipment increase、design-in pipeline、revenue driver及びForecastを含み、同一Observationではない。

## 4. Fact-type and Time Classification Matrix

| Fact type | Representative Evidence | 比較できる範囲 | 禁止する変換 |
| --- | --- | --- | --- |
| Actual — cash / CapEx / assets | Microsoft `002`,`006`; Alphabet `011`,`013`,`017` | 同一issuer・同一定義・同一会計basis内のperiod comparison候補 | Data Center、AI、server又はsemiconductor amountへの配賦 |
| Commitment / obligation | Microsoft `003`–`004`; Alphabet `014`; NVIDIA `027` | 契約上の将来負担が開示されるという構造的比較 | Actual expenditure、orders、shipment、supplier revenue又はsemiconductor demandへの変換 |
| Actual — revenue / segment | Microsoft `008`; NVIDIA `022`–`024`; ROHM `050`,`054`; Infineon `093`,`099` | 同一issuer・同一定義・同一period内の比較候補 | 異なるissuer scopeを共通市場売上としてranking又は合算 |
| Backlog / commercial demand context | Alphabet `019` | Backlogとissuer explanationを固有のcommercial contextとして記述 | Revenue、CapEx、capacity又はsemiconductor order / demand proxyへの変換 |
| Forecast / outlook | Alphabet `018`; NVIDIA `031`; ROHM `047`,`048`; Infineon `094`,`095`,`097`,`114`,`126`,`127` | 発行者が将来値又は方向を示した事実の並置 | Actual、Target、indication、industry Forecast又は達成確率への変換 |
| Target / indication | ROHM `051`; Infineon `103`,`115` | Fact typeと期限を保持した個別記述 | Forecast、guidance、Actual又は互いに同義化 |
| Plan / roadmap | Microsoft `005`; Alphabet `016`; Renesas `043`; ROHM `059`,`065`,`073`,`078`,`080`,`083`,`090`; Infineon `098`,`122`,`131`–`132` | 発行者が将来行動・stage・timingを示した事実 | 実行済み投資、availability、capacity、shipment、revenue又はForecastへの変換 |
| Scenario / illustration / estimate | Renesas `037`,`039`,`045`; ROHM `049`,`087`; Infineon `107`,`113`,`116`,`125` | 原文の分母、相対値、period及びissuer originを保持した説明 | Actual、universal BOM、transaction price、industry average、revenue又はmarket shareへの変換 |
| Product / engineering performance assertion | Infineon `111`,`118`,`121` | Product、topology、condition及びissuer assertionを保持した説明 | System-wide performance、第三者benchmark、deployment又はcommercial resultへの一般化 |
| Measurement-basis / method change | Infineon `130` | Historical SAMからper-kW assessmentへのissuer-reported変更として記述 | 新しいabsolute market Forecast、連続series又はgrowth rateの生成 |
| Operating narrative / condition | Microsoft `001`,`007`,`009`; Alphabet `015`,`020`; NVIDIA `028`,`030`,`032`; Renesas `033`,`041`; ROHM `046`,`074`; Infineon `100`–`102`,`104`–`106`,`129` | 発行者別のoperating context / risk / conditionの類型比較 | 数量、固定Lead / Lag、backlog、shortfall、売上影響又は因果係数の補完 |
| Definition / taxonomy / reporting transition | Alphabet `010`,`012`; NVIDIA `021`,`025`; Renesas `034`–`035`; ROHM `052`–`053`; Infineon `108`,`110`,`112`,`119` | 用語・scope・architecture差の比較 | 定義からActual availability、adoption、revenue又は標準architectureを推定 |
| Relationship / assertion | Renesas `038`,`044`; ROHM `057`,`061`,`069`,`072`,`075`,`078`,`081`,`083`,`086`,`089`; Infineon `096`,`123`–`124`,`128` | Counterparty、speaker、stage及び匿名性を保持した関係類型の比較 | Procurement、order、shipment、revenue、exclusive supply、market share又は同一匿名partyの推定 |

Publication Event、Applicable Period及びFact typeは別Fieldとして保持する。同じ日付の資料に複数Factがあっても統合せず、同じFactが複数Source Eventに現れても独立signal又は確度加算として二重計上しない。

## 5. Measurement Unit and Denominator Matrix

| Measurement family | Issuer / Evidence | Unit / denominator | Comparability assessment | Required boundary |
| --- | --- | --- | --- | --- |
| Property / CapEx cash flow | Microsoft `002`,`006` | USDm、cash-flow additions | Microsoft内のperiod comparison候補 | Alphabet CapEx又はasset balanceとの会計basis同一性を仮定しない |
| CapEx | Alphabet `011`,`017`,`018` | USDbn、Actual / Forecast | Alphabet内でFact typeを分離したperiod comparison候補 | `vast majority`及び60/40を総額へ機械配賦しない |
| Gross in-service assets | Alphabet `013` | USDm、period-end gross balance | CapExと別測定対象として単独利用 | CapEx、net assets、GPU / TPU valueへ変換しない |
| Commitments / obligations | Microsoft `003`–`004`; Alphabet `014`; NVIDIA `027` | USDbn又はUSDm、scope / maturityが異なる | 構造的並置のみ | 金額ranking又は合算は不可。Actual purchase / CapExへ変換しない |
| Cloud / backlog | Microsoft `008`; Alphabet `019` | Revenue / growth、backlog / growth | Demand-side commercial contextの記述のみ | Data Center CapEx又はsemiconductor demand proxyとして採用しない |
| NVIDIA Data Center revenue | `022`–`024` | USDbn、platform reporting scope | NVIDIA内でperiod / reporting definition確認付き比較候補 | GPU単体、industry demand又は供給側売上へ変換しない |
| NVIDIA Data Center driver explanation | `026` | YoY %及びqualitative `majority` | Data Center Actualと二重加算せず、driver contextとして記述 | `majority`の比率・金額、GPU単体売上又はindustry growthへの変換 |
| ROHM Server Business / application | `047`,`050`–`051`,`054` | JPYbn、YoY multiplier、application share | 各definition内の個別記述。相互bridge未確認 | AI server / Data Center単独額又はJPY換算値を作らない |
| Infineon AI power revenue | `093`–`094`,`103`,`114`–`115`,`126`–`127` | EURm / EURbn、qualitative growth ratio及びCAGR、Actual / Forecast / indication / Target | Definition continuity確認前はSource Event別 | 単一時系列、Forecast accuracy又はROHMとのcurrency conversion比較を作らない |
| PSS / SiC | Infineon `097`,`099`–`100`,`106` | PSS revenue EURbn、Segment Result EURm、margin %及びqualitative segment / mixed-scope growth | Mixed-scope contextのみ | AI-only amount又はcontributionを算出しない |
| Utilization / investment | Renesas `033`,`043` | wafer-input utilization % / JPYbn / % Plan | 別Factとして個別記述 | 稼働率とcapacity Planを因果接続せず、JPY75.2bn又は用途配賦を作らない |
| Relative units / value / ASP | Renesas `039`,`045` | Relative multipliers | 同一slide / issuer illustration内だけ | Absolute units、currency、revenue、transaction priceへ変換しない |
| Architecture quantities | Renesas `037`,`044`; ROHM `049`; Infineon `113` | Rack MW、relative content、illustrative counts | Issuer scenarioの個別説明のみ | Cross-issuer average、universal BOM又はdemand quantityへ統合しない |
| Content estimate | Infineon `107`,`116`,`125`,`130` | USD/kW、USD/rack、USD/server | Denominator別に保持 | 分母間換算、TAM、revenue、market share又はtransaction priceへ変換しない |
| Efficiency / loss | Infineon `111`,`118`,`121` | %、W/in³、条件付きengineering assertion | Product / architecture別の記述のみ | System-wide又はthird-party benchmarkへ一般化しない |

## 6. Product-stage Comparability Matrix

| Stage / assertion | Representative Evidence | Comparable treatment | Non-comparable treatment |
| --- | --- | --- | --- |
| Architecture / portfolio definition | Renesas `035`,`042`; ROHM `052`–`053`,`060`; Infineon `108`,`110`,`112`,`119` | Technology / voltage / stage positioningを記述 | Product availability、industry adoption又はrevenueとみなさない |
| Development / joint development | ROHM `066`,`079`,`081`,`083`,`086`; Infineon `096` | Named party、product family、Actual / Planを保持 | Procurement、order、design win、production又はrevenueへ変換しない |
| Sample Plan | ROHM `067`,`080` | Source Event時点のsample Planとして記述 | Availability Actual、mass production、shipment又はadoptionへ昇格しない |
| Availability / market release | ROHM `058`,`062`,`076`; Infineon `109`,`117`,`123` | Product、event及びissuer wordingを保持 | Production volume、customer adoption、shipment又はrevenueとみなさない |
| Application positioning / product suitability | ROHM `064`,`068`,`071`,`077`,`085`,`088`,`092` | Product、application scope及びSource Eventを保持 | Availability、adoption、用途別production、shipment、revenue又はActual demandへ昇格しない |
| Reference-design / evaluation-board introduction | Infineon `120` | 18 kW reference design / 30 kW evaluation boardのintroductionとして保持 | Availability Actual、mass production、customer deployment、shipment又はrevenueへ昇格しない |
| Evaluation availability Plan | Infineon `122` | Future evaluation availability Planとして保持 | Availability Actual、mass production、shipment又はadoptionへ昇格しない |
| Product roadmap / future reference-board Plan | Infineon `131`,`132` | Board type、product power、Source Event及びtimingを保持 | Sample Planと同義化せず、後続Actualを過去Planへ遡及しない |
| Mass-production Plan | ROHM `059`,`078`,`083` | Plan / counterparty statementを保持 | Commencement Actual又はROHM shipmentへ変換しない |
| Production commencement / system | ROHM `063`,`070`,`082`,`084`,`091`; related `089` | Source Event、product / system grain及びspeakerを保持 | 用途別production、二度の進展、独立需要signal又はrevenueへ変換しない |
| Design-in / adoption / endorsement / recommendation / customer-board assertion | Renesas `038`,`044`; ROHM `057`,`061`,`069`,`072`,`075`; Infineon `128` | Issuer、匿名性、product、speaker / assertion type及び未確定stageを保持 | Endorsement、recommendation又はsolution assertionをadoptionへ昇格せず、order、shipment、revenue、exclusive supply又はmarket shareへ拡張しない |
| External-speaker product-requirement assertion | Infineon `124` | NVIDIA speaker attributionとproduct-requirement assertionを保持 | Purchase、production adoption、order、shipment、revenue又はexclusive design winへ昇格しない |

同一product familyであっても、Development、Sample、Availability、Application positioning、Reference-design introduction、Roadmap、Mass-production Plan、Production commencement、Design-in、Adoption、Endorsement、Recommendation、Customer-board assertion、Shipment及びRevenueは別stage又は別assertion grainである。

## 7. Relationship Comparability Matrix

| Relationship grain | Examples | Cross-issuer comparison allowed | Prohibited conclusion |
| --- | --- | --- | --- |
| Named joint development | NVIDIA–Infineon `096`; Delta–ROHM `081`,`083`; Ancora–ROHM `086` | 関係主体、対象技術、Actual / Planの類型比較 | Procurement、exclusive supply、order、shipment、revenue |
| Named platform / offering | Intel–Infineon `123`; NVIDIA speaker–Infineon `124` | Offering / external-speaker assertionとして並置 | Intel / NVIDIA purchase又はproduction adoption |
| Named adoption / production statement | Murata–ROHM `057`,`075`,`078`,`089` | Product、counterparty、stage及びspeakerを保持した事例比較 | 全社需要、継続受注、数量、ROHM shipment / revenue |
| Anonymous relationship | Renesas `044`; ROHM `061`,`069`,`072`; Infineon `128` | Anonymous issuer assertionの存在と境界を比較 | Party identity、同一party、corroboration、order、revenue、universal BOM |
| Architecture response without procurement | Renesas `042`; ROHM `060`; Infineon `119` | 800 V architectureへの発行者positioningを記述 | NVIDIA adoption、design win、procurement又はmarket share |

Microsoft / Alphabetの投資、NVIDIAのcompute需要又はplatform revenueと、Renesas / ROHM / Infineonの売上・受注を異なる発行者の開示から接続してDirect relationを作らない。

## 8. Within-issuer Comparability Assessment

| Issuer | 比較候補 | 条件 | 現在比較できないもの |
| --- | --- | --- | --- |
| Microsoft | FY2023–FY2025及びFY2026 Q3のProperty and Equipment additions | Cash-flow表示、期間長及びFY/QTD/YTDを保持 | Data Center / AI比率、construction / purchase commitmentsとの同一化 |
| Alphabet | FY2024 / FY2025 CapEx Actual、FY2026 Forecast | Actual / Forecast、technical infrastructure限定語及びperiodを保持 | Gross assets、backlog、commitmentsとの同一series化、GPU / TPU配賦 |
| NVIDIA | FY2024–FY2026及びQ1 FY2027 Data Center revenue | Data Center platform scope、quarter / year及びreporting transitionを保持 | 旧Compute / Networkingから新Hyperscale / ACIEへのmapping |
| Renesas | Q1 utilization、portfolio、scenario、investment Plan等をSource Event別に追跡 | Fact type、Today / Mid-to-Long-Term、denominatorを保持 | Data Center revenue series、utilizationからrevenue / demandへの変換 |
| ROHM | FY2025 Server Business ActualとFY2026 / FY2028 / FY2030 Targets | `Server Business`定義とActual / Targetを保持 | Computer & Storage、AI server、Data Center又はDiscrete shareとの自動bridge |
| Infineon | AI power revenueのFY2024 / FY2025 Actual、FY2026 Forecast、FY2027 indication | Definition continuity、Actual / Forecast / indication及びSource Eventを保持 | Historical AI server Forecast / Target / CAGR、PSS / SiC segmentとの単一series化 |

## 9. Cross-issuer Comparability Assessment

### 9.1 記述的に並置できる項目

| Comparison topic | Issuers | Permitted statement | Limitation |
| --- | --- | --- | --- |
| Infrastructure expansion disclosure | Microsoft、Alphabet、NVIDIA | CapEx / commitments / obligations / capacity dependencyを各issuer定義のまま並置 | 金額の同一basis比較、合算又はsemiconductor demand換算は不可 |
| Platform / architecture breadth | NVIDIA、Renesas、ROHM、Infineon | Compute / networking、grid-to-core、800 V、power-conversion stageのissuer positioningを比較 | Industry-standard architecture、採用率又はsupplier shareを決めない |
| Power-supply commercialization stages | Renesas、ROHM、Infineon | Development、availability、roadmap、design-in、adoption等の開示stageを比較 | Stageを順位、売上規模又はcommercial successへ変換しない |
| Supply / capacity condition | Alphabet、NVIDIA、Renesas、Infineon | Constraint、risk、hybrid capacity、allocation / redeploymentの開示類型を比較 | 共通shortage index、Lead / Lag又は数量signalを作らない |
| Issuer-named relationship | Renesas、ROHM、Infineon | Counterpartyとrelationship grainを保持して事例を比較 | 需要側投資からsupplier売上へのDirect relationを作らない |

### 9.2 現在、定量比較できない項目

- Microsoft / Alphabet CapExとNVIDIA Data Center revenue。
- NVIDIA Data Center revenueとROHM Server Business又はInfineon AI power revenue。
- ROHM JPY TargetとInfineon EUR Forecast / indication。
- Renesas relative units / value / ASPとInfineon USD/kW / rack / server content。
- 各社のrack power、component count、BOM又はarchitecture scenario。
- Allocation、backlog、design-in、shipment increase、availability及びrevenueの相互比較。
- Actual、Forecast、Target、indication、Plan及びscenarioを混在させたgrowth ranking。

Currency換算、inflation adjustment、会計period変換又はissuer definitionの正規化は、本Matrixの範囲外である。

## 10. Industry Report Use Matrix

| Industry Report section candidate | Evidence basis | Permitted use | Explicit non-claim |
| --- | --- | --- | --- |
| Demand-side investment and construction context | Microsoft `002`–`006`,`009`; Alphabet `011`–`014`,`016`–`018`,`020` | CapEx、commitment、construction lifecycle、composition及びcapacity timingをissuer別Factとして説明 | Semiconductor購入額、supplier revenue、項目別配賦又は固定Lead / Lag |
| Demand-side architecture / dependency / commercial context | Microsoft `001`,`007`–`008`; Alphabet `010`,`015`,`019` | Server / accelerator options、operating dependency、Cloud revenue / backlogをFact type別に説明 | Data Center investment又はsemiconductor demandの共通proxy化 |
| Compute platform, revenue and reporting context | NVIDIA `021`–`026` | Data Center platform、revenue、driver及びreporting transitionを別Factとして説明 | GPU単体売上、industry demand又はpower supplier売上への一般化 |
| Compute supply, market-access and capacity context | NVIDIA `027`–`032` | Obligation、component risk、regulatory shock、market access、outlook及びenergy dependencyを別Factとして説明 | 共通需要cycle、China需要額、supplier allocation又は固定Lead / Lag |
| Power architecture and portfolio | Renesas `034`–`036`,`040`,`042`; ROHM `052`–`053`,`060`,`068`,`071`,`077`,`085`,`088`,`092`; Infineon `108`,`110`,`112`,`119` | Architecture、portfolio、application positioning及びissuer responseをFact別に説明 | 共通BOM、market share、commercial ranking又は採用済みindustry standard |
| Power product stage, performance and relationship | Renesas `038`,`044`; ROHM `055`,`056`,`057`,`058`,`059`,`061`,`062`,`063`,`064`,`066`,`067`,`069`,`070`,`072`,`075`,`076`,`078`,`079`,`080`,`081`,`082`,`083`,`084`,`086`,`089`,`091`; Infineon `096`,`104`,`105`,`109`,`111`,`117`,`118`,`120`,`121`,`122`,`123`,`124`,`128`,`131`,`132` | Product、stage、performance及びrelationshipを限定ID単位で説明 | Stage ranking、universal performance、order、shipment又はrevenueへの変換 |
| Power operating / capacity context | Renesas `033`,`041`,`043`; ROHM `065`,`073`–`074`,`078`,`082`–`083`,`089`–`090`; Infineon `098`,`101`–`102`,`106`,`129` | Utilization、investment / supply Plan、adoption narrative、allocation、redeployment及びdemand-supply conditionをFact別に説明 | Capacity量、用途別配賦、短缺量又は売上因果の補完 |
| Revenue / Forecast / Target disclosure structure | ROHM `046`,`047`,`048`,`050`,`051`,`054`; Infineon `093`,`094`,`097`,`099`,`100`,`103`,`106`,`114`,`115`,`126`,`127` | Issuer-defined Actual、Forecast、Target、indication及びdriver差を説明 | Currency換算ranking、単一定義series又はForecast達成認定 |
| Measurement and denominator controls | Renesas `037`,`039`,`045`; ROHM `049`,`087`; Infineon `095`,`107`,`113`,`116`,`125`,`130` | Historical market sizing、relative multiplier、scenario、per-kW、rack / server BOM及びmethod changeを分母別に説明 | Cross-issuer換算、TAM、transaction price、revenue又はmarket shareへの変換 |
| Definition and comparability controls | 本Matrix全体 | Scope、period、unit、Fact type、denominator、stageの差を明示 | Catalog schema、ML feature又は投資signalの決定 |
| Gaps and negative evidence | 各Gate / Hold / §11 | 未確認関係と調査範囲を限定して記録 | 不存在証明又は調査外資料の否定 |

## 11. Gaps Affecting Comparability

1. Microsoft / Alphabetの全社CapEx・commitmentからData Center / AI / semiconductorへの配賦比率。
2. NVIDIAの旧Compute / Networkingと新Hyperscale / ACIEのrestatement / mapping。
3. Renesas prospective `data center revenue`の過去期間definition及びActual series。
4. ROHMのServer Business、Computer & Storage、AI server及びData Center間のdefinition bridge。
5. InfineonのAI power revenueについてPublication Event間のdefinition continuityとPSS / SiC bridge。
6. Per-kW、rack、server及びcomponent-count estimate間のconfiguration / denominator bridge。
7. Product roadmap、availability、design-in、adoption、shipment及びrevenue間のstage transition。
8. Demand-side investment又はNVIDIA compute demandから、日本株power semiconductor supplierのorder / shipment / revenueへ至る単一Source内のDirect relation。
9. Publication time / timezoneと承認済み`AvailableAt` Operating Convention。

これらのGapは推測で補完しない。Negative Evidenceは、調査cut-offまでに記録した公式Source Setで確認できなかったことに限定し、関係又は資料の不存在を証明しない。

## 12. Matrix Disposition and Downstream Boundary

本Matrixは、Sprint003の132 Accepted Evidenceについて、Industry Report作成前に必要なDefinition、period、unit、Fact type、denominator、product stage及びrelationshipの比較境界を整理したDraftである。

本Matrixは、著者から独立したEvidence、Knowledge及びTraceability ReviewでAcceptedとなった。Review Accepted後もDraft / noncanonical、全132件`AvailableAt = TBD — no use`、Catalog Eligibility `No`を維持する。

本MatrixはIndustry Report作成へ接続できるが、Catalog、DDL、Entity、Database、ML、バックテスト、Decision Engine、Advisor又は投資判断へは接続しない。
