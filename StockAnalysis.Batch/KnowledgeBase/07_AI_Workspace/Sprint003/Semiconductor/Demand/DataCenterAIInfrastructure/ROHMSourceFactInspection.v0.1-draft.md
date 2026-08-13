# ROHM — Data Center / AI Infrastructure Source Fact Inspection

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft Source Fact inspection |
| Sprint | Sprint003 |
| 対象企業 | ROHM Co., Ltd. |
| Version | 0.1-draft |
| 作成日 | 2026-08-09 |
| Retrieval Date | 2026-08-09 |
| 調査cut-off | 2026-07-30 23:59 JST |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Reviewer Status | Evidence / Knowledge / Traceability — Accepted |
| Related Review Record | `ROHMSourceFactInspectionIndependentReview.v0.1-draft.md` |
| Evidence ID | None — `ROHM-SFI-xxx`はLocal inspection IDであり、Evidence IDではない |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md` |
| Stage 0 | `Sprint003DataCenterAIInfrastructureStage0IndependentReview.v0.1-draft.md` — Accepted |
| Cross-sprint参照 | `Sprint003DataCenterAIInfrastructureCrossSprintBridge.v0.1-draft.md` |

> **利用境界：** 本文書はSource Fact候補をRaw Evidence化する前の検査記録である。Evidence採用、`S3-EVR-xxx`又は`S3-PIT-xxx`の発行、`AvailableAt`の確定、Catalog / DDL / ML利用を許可しない。既存Sprintと同一のSource Factは参照のみとし、Sprint003で再発行しない。

## 1. Research Questions

| Research Question | ROHMでの確認対象 |
| --- | --- |
| `S3-DCAI-RQ-001` | ROHMが用いるServer、AI Server、Data Center、Computer & Storage及びC&Sの範囲 |
| `S3-DCAI-RQ-004` | AI server / Data CenterとSiC、GaN、Si MOSFET、analog IC及びpower solutionの明示関係 |
| `S3-DCAI-RQ-005` | 800VDC、±400VDC、PSU、rack、server board及びgrid-to-chipの発行者明示関係 |
| `S3-DCAI-RQ-006` | Actual、Plan、Target、Forecast、simulation、management scenario及びcustomer planの差 |
| `S3-DCAI-RQ-007` | 将来の観測候補となり得るROHM開示と、用途別売上・顧客別売上等の利用不能なGap |

## 2. Inspected Official Sources

| Source | Publication Event | Applicable Period | Official location | Inspection status |
| --- | --- | --- | --- | --- |
| ROHM Co., Ltd., *Financial Results for FY2025* | Document date 2026-05-13。publication time / timezone `Unknown` | FY2025 Actual / FY2026 Plan / mid-term targets | [Official PDF](https://fscdn.rohm.com/en/financial/account/2603_presentation_en.pdf)、PDF pp.5, 19, 23–25, 27, 35, 38 | AI server / server business、C&S及びPower-device passages inspected |
| ROHM Co., Ltd., *Financial Results for FY2024* | Document date 2025-05-14。publication time / timezone `Unknown` | FY2024 Actual / FY2025 Plan | [Official PDF](https://micro.rohm.com/en/financial/account/2503_41811104_presentation_en.pdf)、PDF pp.22–24 and relevant strategy pages | AI data-server effective-demand / solution / product-stage passages inspected; prior targets retained separately |
| ROHM Co., Ltd., *Financial Results for the First Half of FY2025* | Document date 2025-11-07。publication time / timezone `Unknown` | FY2025 H1 / then-current targets | [Official PDF](https://fscdn.rohm.com/en/financial/account/2509_10200916_presentation_en.pdf)、PDF pp.17–19, 29 | AI data-server adoption commentary and prior server-sales target graphic inspected |
| ROHM Co., Ltd., *ROHM Group Integrated Report 2025* | 2025-11（月のみ）。publication day / time / timezone `Unknown` | FY2024 Actual context / medium-term strategy | [Official PDF](https://fscdn.rohm.com/en/financial/integrated-report/rohm_group_integrated_report_2025_en_view.pdf)、physical PDF pp.26–29（printed pp.48–55） | IC、Discrete、Si Power Device及びModule strategy passages inspected |
| ROHM Co., Ltd., *Special Dialogue: HVDC for AI servers* | publication date / time / timezone `Unknown`。2026-07-30作成のOfficial Source Inventoryでpage存在とAI server / HVDC / Delta collaborationのtopic scopeを確認済み。version identity `Unknown` | Current technical discussion and future plans | [Official page](https://www.rohm.com/ir/dialogue/ai-server) | Delta Electronicsとの対談全文をinspection。発言主体をROHM / Deltaで分離 |
| ROHM Co., Ltd., *Server/Data Center* | publication date / time / timezone `Unknown`。2026-07-30作成のOfficial Source Inventoryでpage存在とServer / Data Center application scopeを確認済み。version identity `Unknown` | Current issuer solution taxonomy | [Official page](https://www.rohm.com/solution/industry/server) | PSU、BBU、Server Board及び関連solution taxonomyをinspection |
| ROHM Co., Ltd., *ROHM’s 800VDC Architecture Solutions for AI Servers* | Official release news page display 2025-10-13。publication time / timezone `Unknown`; information current as of 2025-10; Catalog No. 68WP001E Rev.001 | Technical architecture, internal simulations and product positioning | [Official PDF](https://fscdn.rohm.com/en/products/databook/white_paper/common/800vdc_architecture_solution_for_ai_server_wp-e.pdf)、PDF pp.3–25 | Architecture、device positioning、simulation及びcase-study sections inspected; release eventは公式Newsで確認 |
| ROHM Co., Ltd., *ROHM’s EcoGaN has been Adopted for AI Server Power Supplies by Murata Power Solutions* | 2025-03-05。publication time / timezone `Unknown` | Named-customer adoption announcement | [Official news](https://www.rohm.com/news-detail?news-title=2025-03-05_news_murata&defaultGroupId=false) | EcoGaN adoption relation inspected; customer product, order, volume and revenue remain bounded |
| ROHM Co., Ltd., *ROHM’s High 8V Gate Withstand Voltage Marking Technology Breakthrough for 150V GaN HEMT* | 2021-05-27。publication time / timezone `Unknown` | Product-development Actual / sample Plan | [Official news](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=150v-gan-hemt) | Data-center power-supply application、development及びsample Planを分離 |
| ROHM Co., Ltd., *ROHM starts Production of 150V GaN HEMTs: Featuring Breakthrough 8V Withstand Gate Voltage* | 2022-03-22。publication time / timezone `Unknown` | Product-production commencement Actual / application positioning | [Official news](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=150v-gan-hemts) | GNE10xxTB production commencementとData Center / base-station applicationを分離 |
| ROHM Co., Ltd. / Delta Electronics, *ROHM and Delta Electronics Form a Strategic Partnership on Developing Power Devices for Power Supply Systems* | 2022-04-28。publication time / timezone `Unknown` | Strategic partnership Actual / development and mass-production Plan | [Official news](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2022-04-28_news_ecogan) | Partnership、150V production-system Actual、600V development / mass-production Planを分離 |
| ROHM Co., Ltd., *SiC SBDs from ROHM chosen by Murata Power Solutions for Data Center PSUs* | 2023-03-07。publication time / timezone `Unknown` | Named-customer product-adoption and customer production-stage assertions | [Official news](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2023-03-07_news_murata) | SCS308AH / Data Center PSU relationとMurata speakerのproduction-stage statementを分離 |
| ROHM Co., Ltd., *ROHM Begins Mass Production of 650V GaN HEMTs That Deliver Class-Leading Performance* | 2023-05-08。publication time / timezone `Unknown` | Mass-production Actual / application positioning / named-development relation | [Official news](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2023-05-08_news_gan) | GNP1070TC-Z / GNP1150TCA-Z production、server application、Ancora joint developmentを分離 |
| ROHM Co., Ltd., *ROHM Develops Class-Leading Low ON-Resistance, High-Power MOSFETs for High-Performance Enterprise and AI Servers* | 2025-04-10。publication time / timezone `Unknown` | Product development Actual / 2025 mass-production Plan | [Official news](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2025-04-10_news_mosfet) | Product development、availability、AI-server application及びmass-production Planを分離 |
| ROHM Co., Ltd., *ROHM Delivers High-Performance Power Solutions Aligned with NVIDIA 800V HVDC Architecture* | Official page display 2025-06-12。URL slugは`2025-06-13_nvidia`で一日異なる。publication time / timezone `Unknown` | Product / architecture response and anonymous endorsement assertion | [Official news](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2025-06-13_nvidia) | NVIDIA architecture responseとcloud-provider assertionを分離。Publication Eventはpage displayを採用し、slugとの差を保持 |
| ROHM Co., Ltd., *ROHM Introduces a New MOSFET for AI Servers with Industry-Leading SOA Performance and Low ON-Resistance* | 2025-07-01。publication time / timezone `Unknown` | Product market release and anonymous recommendation assertion | [Official news](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2025-07-01_news_mosfet) | RY7P250BM release / sales launchとrecommended-component assertionを分離 |
| ROHM Co., Ltd., *ROHM Launches an Isolated Gate Driver IC Optimized for High-Voltage GaN Devices* | 2025-06-25。publication time / timezone `Unknown` | Product-development / availability Actual and application positioning | [Official news](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2025-06-25_topics_gate-driver) | BM6GD11BFJ-LB availabilityとserver power-supply applicationを分離 |
| ROHM Co., Ltd., *ROHM launches wide SOA MOSFET for AI servers in compact 5×6mm package* | 2025-11-25。publication time / timezone `Unknown` | Product mass-production Actual / application positioning | [Official news](https://www.rohm.com/news-detail?news-title=2025-11-25_news_mosfet) | RS7P200BM mass-production commencementとAI-server applicationを分離 |
| ROHM Co., Ltd., *ROHM Strengthens Supply Capability for GaN Power Devices* | 2026-02-26。publication time / timezone `Unknown` | Supply-system decision / 2027 Plan | [Official news](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2026-02-26_news_gan) | TSMC technology-transfer decision、2027 production-system aim及びapplication scopeを分離 |
| ROHM Co., Ltd., *ROHM Develops 5th Generation SiC MOSFETs with Approx. 30% Lower On-Resistance at High Temperatures* | 2026-04-21。publication time / timezone `Unknown` | Development Actual / sample Plan / application positioning | [Official news](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2026-04-21_news_sic-mosfet) | Development completion、sample timing及びAI-server / Data Center applicationを分離 |
| ROHM Co., Ltd., *ROHM Publishes White Paper on Power Solutions for Next-Generation 800 VDC Architecture* | Official page display 2025-10-13。URL slugは`2025-10-14_news_white-paper`。publication time / timezone `Unknown` | White-paper release event | [Official news](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2025-10-14_news_white-paper) | White paperのrelease eventとCatalog No. 68WP001E Rev.001を接続。日付はpage displayを採用 |
| ROHM Co., Ltd., *ROHM’s SiC MOSFET Adopted in BBU for AI Servers as HVDC Architectures Advance* | 2026-06-03。publication time / timezone `Unknown` | Anonymous-customer product-adoption assertion | [Official news](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2026-06-03_news_sic-mosfet) | SCT4013DLL / BBU / ±400V relation inspected |
| ROHM Co., Ltd., *ROHM Launches 600V Super Junction MOSFETs in Surface-Mount Package with High Thermal Performance* | 2026-07-09。publication time / timezone `Unknown` | Mass-production Actual / application positioning | [Official news](https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2026-07-09_news_super-junction-mosfet) | Sequential mass-production commencementとAI-server / Data Center applicationを分離 |

Official newsroomは、調査cut-off以前の2021-05-27から2026-07-09までに確認できたAI server / Data Center / 800V / HVDC / SiC / GaN / MOSFET関連の発表を再検索した。本文書は、単なる一般server用途ではなく、Sprint003のRQへ直接接続し、かつdevelopment、release、Plan、adoption、recommendation又はmass-productionのstageを識別できるSource Eventを候補化する。完全なweb不存在を証明するものではなく、後続recheckでも限定Source Setに対する重複検索を行う。

### 2.1 Period Coverage and Search Boundary

| Period | Coverage confirmation | Treatment |
| --- | --- | --- |
| FY2021–FY2023 | Official Financial Report archive、既存Sprint001 FY2021–FY2023 ROHM records及び公式Newsroomを、`server`、`data center`、`AI server`、`power supply`、`SiC`、`GaN`で確認 | 既存Automotive Factsはreference-only。2021 GaN development / sample Plan及び2023 Murata adoptionを新規候補化 |
| FY2024 | FY2024 Results、Integrated Report 2025及び既存Sprint001 / 002 Evidenceを確認 | Same Factはreference-only。AI data-server strategy / Planの新規Source positionだけを候補化 |
| FY2025 / latest pre-cut-off results | FY2025 H1、FY2025 full-year results及び2026-07-30以前の公式Newsroomを確認 | Prior targetとlater Actual / targetをPublication Event別に保持。Latest full-year resultを上書き根拠にしない |

このcoverage記録は限定された公式Archive / Newsroom検索結果であり、web上の完全な不存在を証明しない。候補recheckでは同じ期間・語彙を再使用する。

## 3. Source Fact Candidate Inspection

| Local ID | Source position | Classification | Candidate Source Fact | Use boundary | Existing evidence / overlap | Preliminary disposition |
| --- | --- | --- | --- | --- | --- | --- |
| `ROHM-SFI-001` | FY2025 Results p.4 / p.8、Industrial results / forecast | Existing Actual and Plan | FY2025 Industrial Actual及びFY2026 Industrial forecast。 | IndustrialをData Center又はAI serverへ配賦しない。 | Sprint002 `S2-EVR-007` / `008`と同じFact | **Reference existing evidence only** |
| `ROHM-SFI-002` | Integrated Report 2025、Power / SiC industrial-application context | Existing issuer product / application definition | Power / SiCとindustrial applicationの発行者定義。 | Industrial、automotive及びAI serverを同一用途としない。 | Sprint002 `S2-EVR-009`と同じFact | **Reference existing evidence only** |
| `ROHM-SFI-003` | FY2024 Results / Fact Book 2026 3Q、Industrial and classification context | Existing Actual / classification note | FY2024 Industrial Actual及び発行者分類注記。 | C&S又はData Centerへ遡及再分類しない。 | Sprint002 `S2-EVR-010` / `011`と同じFact | **Reference existing evidence only** |
| `ROHM-SFI-004` | Integrated Report 2025 printed pp.50–51及びFY2021–FY2025 automotive disclosures | Existing product / application and Automotive facts | Discrete-device application mix及びautomotive market sales。 | Automotive factsをAI server需要へ再利用しない。 | Sprint001 `EVR-008` / `019`–`023`参照 | **Reference existing evidence only** |
| `ROHM-SFI-005` | FY2025 Results p.5、operating-profit change explanation | Management-reported Actual-period explanation | ROHMは新製品の立上げ等を背景にAI server businessが拡大したと説明する。 | 売上額、数量、顧客、製品別寄与、利益額又はData Center単独成長率を確定しない。 | 既存matchなし | **Proceed with caution** — qualitative Actual-period explanation |
| `ROHM-SFI-006` | FY2025 Results p.19、SiC Business Sales Trend | Issuer Forecast | FY2026にcomputer / storage向け（AI server power supply向け）salesが前年比2.5倍になるとROHMは予測する。 | ForecastでありActualではない。Base amount、AI-only比率、customer、units又はmarket shareを補完しない。 | 既存matchなし | **Proceed with caution** — issuer forecast only |
| `ROHM-SFI-007` | FY2025 Results p.23、`ROHM's Addressable Demand Forecast` | Issuer research / Forecast | AI server向けpower devices（DrMOSを含む）のROHM addressable demandはFY2025–FY2030 CAGR +48%との発行者調査を示す。 | ROHM sales、TAM Actual又はthird-party validated forecastではない。Absolute values、share及びrevenueへ変換しない。 | 既存matchなし | **Proceed with caution** — issuer addressable-demand forecast |
| `ROHM-SFI-008` | FY2025 Results p.23、Data Center CAPEX chart | Issuer-compiled third-party context | Amazon、Google、Microsoft及びMetaのData Center CAPEXについて2021–2026 CAGR +41%を示す。 | 各社IRをROHMが編集したcontextであり、定義、FX、対象CapEx及び原資料照合が本Gateで未完了。ROHM需要又は売上としない。 | Cross-issuer contextのみ | **Hold** — source-by-source provenance reconciliation required |
| `ROHM-SFI-009` | FY2025 Results p.24、current server / next-generation AI server illustration | Issuer management architecture scenario | Illustrationはmain boards 18→72、power consumption 13kW→1,000kW、power components 600→22,000、analog components 300→17,000を示す。 | Next generationは2027年頃以降のscenario。Current average、universal BOM、shipment、installed base又は実現済み需要とみなさない。 | 既存matchなし | **Proceed with caution** — architecture / content illustration |
| `ROHM-SFI-010` | FY2025 Results p.27、Server Business sales target | Source-presented Actual | FY2025 Server Business salesはJPY17.0bnと表示される。 | `Server Business`はAI server単独又はData Center単独と定義されていない。C&S segment又はAI server revenueと同一視しない。 | 既存matchなし | **Proceed with caution** — mixed server-scope Actual |
| `ROHM-SFI-011` | FY2025 Results p.27、Server Business sales target | Issuer Plan / Target | Server Business salesはFY2026 JPY25.0bn、FY2028 JPY30.0bn、FY2030 JPY100bn超を目指すと表示される。 | Actualではない。FY2028値は2025-11時点planとされ、各targetのassumption、AI-only比率及び達成確率を補完しない。FY2025 Actualと分離する。 | 既存matchなし | **Proceed with caution** — issuer targets only |
| `ROHM-SFI-012` | Official Server/Data Center page、PSU / BBU / Server Board sections | Issuer solution / application definition; cut-off content identity unresolved | ROHMは8月9日inspection時点のpageでServer / Data Center向けsolution areaをPSU、BBU及びAI server motherboardに分け、SiC power devices、analog ICs及びdiscrete componentsを配置する。 | Page存在とtopic scopeは7月30日のInventoryで確認済みだが、exact passageのversion identityは未確認。Product mapをavailability、adoption、shipment、revenue、market share又はuniversal BOMとしない。 | 既存matchなし | **Hold** — cut-off exact-content identity unresolved |
| `ROHM-SFI-013` | 800VDC white paper p.3、abstract / proposed architecture | Issuer technical architecture definition / internal analysis | 800VDC architectureではAC-DC converterをside power rackへ移し、DC-DC converterをIT rackに残す構成を説明し、ROHM internal analysisとしてpower-source側にSiC、IT-rack側にGaNを位置付ける。 | Proposed architecture / internal analysisであり、industry standard、deployed system、採用、売上又は優位性の第三者検証ではない。 | 既存matchなし | **Proceed** — architecture and device-positioning definition |
| `ROHM-SFI-014` | 800VDC white paper pp.9–17、simulation / board estimates | Internal simulation / engineering estimate | Vienna PFC、three-phase LLC、SiC / GaN DC-DCについて約99%級のsimulation及び20kW board-size / power-density estimatesを提示する。 | 複数topology、条件及び除外範囲を一つのefficiency Factへ統合できない。Measured system performance、commercial product又はdemand evidenceではない。 | 既存matchなし | **Hold** — method / topology-specific validation required |
| `ROHM-SFI-015` | Integrated Report 2025 physical p.26（printed pp.48–49）、IC segment | Issuer strategy / portfolio relationship | ROHMはAI server向けにICとpower devicesをhigh-voltageからlow-voltageまで組み合わせたtotal solutionへ注力すると説明する。 | Strategy / portfolio positioningであり、Actual adoption、revenue、unit、customer又はmarket shareではない。 | 既存matchなし | **Proceed** — issuer portfolio strategy |
| `ROHM-SFI-016` | Integrated Report 2025 physical p.27（printed pp.50–51）、FY2024 application mix | Source-presented Actual mix | FY2024のDiscrete Semiconductor net sales JPY187bnに対しComputer & Storage application shareは9.1%と表示される。 | Shareのみを保持し、金額を機械算出しない。Computer & StorageをAI server又はData Center単独へ配賦しない。既存`EVR-008`のapplication narrativeと同一Factではない。 | 同一Source pageの既存`EVR-008`とはSource position / Fact grainが異なる | **Proceed with caution** — mixed-scope application share |
| `ROHM-SFI-017` | Integrated Report 2025 physical p.27（printed pp.50–51）、SiC market outlook | Management Forecast | Data Centerへのhigh-voltage inverter導入により、SiC device marketが今後数年間でJPY100bn超拡大するとの見通しを示す。 | Forecast provenance、base market、地域、期間起点及び定義が十分でない。ROHM addressable demand又はsalesとしない。 | 既存matchなし | **Hold** — forecast definition / provenance insufficient |
| `ROHM-SFI-018` | Integrated Report 2025 physical p.28（printed pp.52–53）、Si Power Devices | Issuer strategy / product positioning | ROHMはAI server市場でSi MOSFET salesを増加させ、高付加価値MOSFETを投入する方針を示す。 | Strategyであり、Actual sales growth、customer adoption、product availability又はcompetitive performanceを確定しない。 | 既存matchなし | **Proceed with caution** — product strategy only |
| `ROHM-SFI-019` | Integrated Report 2025 physical p.29（printed pp.54–55）、Modules | Issuer strategy / R&D direction | ROHMはAI server market拡大を見据え、optical moduleのdevelopment / salesを進める方針を示す。 | Power semiconductor demand、commercial adoption、revenue、volume又はnamed customer relationを示さない。 | 既存matchなし | **Proceed with caution** — adjacent-product strategy only |
| `ROHM-SFI-020` | Special Dialogue、Delta speaker、rack power discussion | Named external participant scenario; cut-off content identity unresolved | Delta speakerは8月9日inspection時点のpageでconventional CPU rack約10kW、latest GPU AI rack 120–130kW、future 300kW / 600kW / 1MWとの見方を示す。 | Exact passageの7月30日時点version identityは未確認。Deltaのmanagement expectationでありROHM Actual、third-party forecast又はuniversal rack trajectoryではない。 | 既存matchなし | **Hold** — cut-off exact-content identity unresolved |
| `ROHM-SFI-021` | Special Dialogue、Delta adoption plan passage | Named-customer Plan / direct product relationship; cut-off content identity unresolved | Deltaは8月9日inspection時点のpageで、Q2–Q3 2026に量産予定のAC-DC PSUへROHMのSi power MOSFET及びSiC MOSFETを採用する計画を説明する。 | Exact passageの7月30日時点version identityは未確認。Customer Planであり、量産開始、order、shipment、revenue、volume又はexclusive supplyを確定しない。 | 既存matchなし | **Hold** — cut-off exact-content identity unresolved |
| `ROHM-SFI-022` | Special Dialogue、Delta speaker、grid-to-chip passage | Named external participant product-incorporation Plan; cut-off content identity unresolved | Delta speakerは8月9日inspection時点のpageで、ROHMのpower semiconductors、power-control ICs及びDrMOSを組み込むgrid-to-chip total-power solutionを計画すると説明する。 | Exact passageの7月30日時点version identityは未確認。Delta-stated Planであり、製品別採用、BOM、order、shipment、revenue又は量産完了を示さない。`021`及び`025`と同一化しない。 | 既存matchなし | **Hold** — cut-off exact-content identity unresolved |
| `ROHM-SFI-023` | Special Dialogue、ROHM speaker、market-size outlook | Issuer management Forecast | ROHM speakerはSiC market約JPY500bn、2030年頃約JPY1tn、Data Center追加市場を5年でJPY200bn、将来JPY500bnとする見方を示す。 | Forecast source、base year、geography、product scope、currency basis及び`additional market`定義が不十分。Actual又はROHM salesへ変換しない。 | 既存matchなし | **Hold** — forecast definition / provenance insufficient |
| `ROHM-SFI-024` | Special Dialogue、Delta Electronics / Ares Chen speaker、`800V and ±400V architectures` response | Named external participant technical interpretation; cut-off content identity unresolved | Chenは8月9日inspection時点のpageで、±400VDCがSi MOSFET活用余地を持ち、800VDCでは一般に高耐圧SiC MOSFETが必要とのtechnical trade-offを説明する。 | Exact passageの7月30日時点version identityは未確認。Delta speakerによる条件付きinterpretationとして保持し、industry standard又は唯一のarchitectureへ一般化しない。 | 既存matchなし | **Hold** — cut-off exact-content identity unresolved |
| `ROHM-SFI-025` | Special Dialogue、named-party collaboration statements | Named-party collaboration relationship; cut-off content identity unresolved | Delta ElectronicsとROHMは8月9日inspection時点のpageで、AI-server power solution及びHVDC対応の協業関係を説明する。 | Exact passageの7月30日時点version identityは未確認。個別製品採用、BOM、order、shipment、revenue又はexclusive relationshipを確定せず、`021` / `022`と別grainで保持する。 | 既存matchなし | **Hold** — cut-off exact-content identity unresolved |
| `ROHM-SFI-026` | 2025-03-05 official news、Murata Power Solutions adoption announcement | Issuer-reported named-customer product adoption | ROHMはEcoGaNがMurata Power Solutionsの5.5kW AI-server power supplyへ採用されたと発表する。 | Issuer announcementであり、order、shipment quantity、revenue、market share、exclusive supply又は全Murata PSUへの採用を確定しない。 | 既存matchなし | **Proceed with caution** — named-customer adoption assertion |
| `ROHM-SFI-027` | 2025-04-10 official news、product development / availability | Product development Actual / market availability | ROHMはRS7E200BGを12V enterprise-server power supplyのsecondary AC-DC / HSC向け、RS7N200BH及びRS7N160BHを48V AI-server power supplyのsecondary AC-DC向けとして開発し、sourceはonline availabilityを`now`と示す。 | 製品別application mappingを保持する。Development / sample availabilityであり、mass-production volume、customer adoption、shipment又はrevenueを示さない。2025 mass-production Planと分離する。 | 既存matchなし | **Proceed with caution** — product-stage Actual with commercial boundary |
| `ROHM-SFI-028` | 2025-04-10 official news、future production statement | Issuer Plan | ROHMはAI-server hot-swap circuit向けpower MOSFETのmass productionを2025年中に順次開始する計画を示す。 | Planであり実現済みmass productionではない。後続Source Eventによる製品別Actualと自動的に同一化しない。 | 既存matchなし | **Proceed with caution** — production Plan only |
| `ROHM-SFI-029` | Official page display 2025-06-12（URL slug `2025-06-13_nvidia`）、NVIDIA 800V HVDC architecture response | Issuer architecture / portfolio response assertion | ROHMはNVIDIA 800V HVDC architectureをsupportするkey silicon providerの一社であると自社発表し、Si、SiC、GaN及びanalog / module portfolioとの対応関係を示す。 | ROHM issuer assertionであり、NVIDIA procurement、design win、shipment、revenue又はexclusive partnershipを確定しない。 | NVIDIA architectureとROHM対応の新規Source Event | **Proceed with caution** — issuer architecture-response assertion |
| `ROHM-SFI-030` | Official page display 2025-06-12（URL slug `2025-06-13_nvidia`）、RY7P250BM passage | Issuer-reported anonymous third-party endorsement assertion | ROHMはRY7P250BMが`major global cloud providers`からendorsedされたと発表する。 | Provider数、identity、対象design、評価条件、adoption stage、order、shipment、revenue及びproduction deploymentを確定しない。`ROHM-SFI-041`の単数provider / recommended-component assertionと同一party又はcorroborationとみなさない。 | 既存matchなし | **Proceed with caution** — anonymous-party endorsement assertion |
| `ROHM-SFI-031` | 2025-07-01 official news、RY7P250BM launch / sales information | Product market-release Actual / application positioning | ROHMは100V MOSFET RY7P250BMをAI-server 48V hot-swap circuit向けにmarket releaseし、Sales Launch Dateを2025-05と表示する。 | Product release / issuer application positioningであり、customer adoption、shipment quantity、revenue又はmarket shareを示さない。`030`のrecommendation relationと分離する。 | 既存matchなし | **Proceed** — product launch and issuer-defined application |
| `ROHM-SFI-032` | 2025-11-25 official news、RS7P200BM mass-production passage | Product mass-production Actual | ROHMはRS7P200BMのmass productionを2025-09に開始したと発表する。 | Company-wide production volume、shipment、revenue、customer adoption又はAI-server allocationを示さない。Application positioningは`033`へ分離する。 | 既存matchなし | **Proceed with caution** — product-level production commencement |
| `ROHM-SFI-033` | 2025-11-25 official news、RS7P200BM application passage | Issuer product / application definition | ROHMはRS7P200BMを48V AI-server hot-swap circuit及びindustrial power supply向けproductとして位置付ける。 | Product suitabilityであり、AI-server adoption、shipment、revenue又はActual demandを示さない。 | 既存matchなし | **Proceed** — issuer-defined application only |
| `ROHM-SFI-034` | 2026-02-26 official news、GaN supply capability decision | Issuer supply-system decision / Plan | ROHMはTSMC GaN technologyをROHM Hamamatsuへ移管してin-group production systemを構築することを決定し、AI-server等の需要に対応するため2027年のsystem establishmentを目指す。 | Decision / Planであり、technology transfer完了、capacity、wafer volume、AI-server allocation、shipment又はrevenueを示さない。 | 既存matchなし | **Proceed with caution** — supply-system Plan |
| `ROHM-SFI-035` | 2026-04-21 official news、5th Generation SiC development passage | Product-development Actual | ROHMは5th Generation SiC MOSFETのdevelopmentを2026-03に完了したと発表する。 | Development completionであり、packaged-product mass production、AI-server adoption、shipment又はrevenueではない。 | 既存matchなし | **Proceed with caution** — development-stage Actual |
| `ROHM-SFI-036` | 2026-04-21 official news、sample provision passage | Issuer Plan | ROHMは5th Generation SiC MOSFETを搭載するdiscrete devices / modulesのsamplesを2026-07から提供する計画を示す。 | Planでありsample delivery Actualを確定しない。Mass production、customer adoption、shipment又はrevenueへ変換しない。 | 既存matchなし | **Proceed with caution** — sample Plan only |
| `ROHM-SFI-037` | 2026-04-21 official news、Application Examples | Issuer product / application definition | ROHMは5th Generation SiC MOSFETのapplication exampleにAI-server / Data Center power suppliesを含める。 | Application positioningであり、採用、volume、shipment、revenue又はData Center専用productを示さない。 | 既存matchなし | **Proceed** — issuer-defined application only |
| `ROHM-SFI-038` | 2026-06-03 official news、BBU adoption announcement | Issuer-reported anonymous-customer product adoption | ROHMは750V SiC MOSFET SCT4013DLLがAI-server power supply向けBBUの±400V power sectionに採用されたと発表する。 | Customer / BBU maker identity、order、volume、shipment、revenue、production deployment及びexclusive supplyを確定しない。 | 既存matchなし | **Proceed with caution** — anonymous-customer product-adoption assertion |
| `ROHM-SFI-039` | 2026-07-09 official news、600V Super Junction MOSFET production passage | Product mass-production Actual | ROHMはR60xxXNx / R60xxWNx seriesのmass productionを2026-06から順次開始したと発表する。 | Product-family production commencementであり、AI-server allocation、shipment quantity、revenue、customer adoption又はcapacityを示さない。 | 既存matchなし | **Proceed with caution** — production commencement Actual |
| `ROHM-SFI-040` | 2026-07-09 official news、Application Examples | Issuer product / application definition | ROHMは600V Super Junction MOSFET seriesのapplication exampleにAI-server / Data Center power suppliesを含める。 | Application positioningであり、採用、shipment、revenue、Data Center専用production又はActual demandを示さない。`039`のproduction Factと分離する。 | 既存matchなし | **Proceed** — issuer-defined application only |
| `ROHM-SFI-041` | 2025-07-01 official news、RY7P250BM recommended-component passage | Issuer-reported anonymous third-party recommendation assertion | ROHMはRY7P250BMが`leading global cloud platform provider`によりrecommended componentとしてcertifiedされたと発表する。 | Provider identity、対象design、評価条件、adoption stage、order、shipment、revenue及びproduction deploymentを確定しない。`ROHM-SFI-030`の複数provider endorsement assertionと同一party又はcorroborationとみなさない。 | 既存matchなし | **Proceed with caution** — anonymous-party recommendation assertion |
| `ROHM-SFI-042` | FY2024 Results p.24、`Solutions for Servers` | Issuer product-development Plan | ROHMはAI data-server market向けcoverageを拡大するため、新製品planning / developmentを加速する方針を示す。 | Planであり、development completion、Actual sales、customer adoption又はproduct availabilityを示さない。SAM illustrationは`057`へ分離する。 | 既存matchなし | **Proceed with caution** — prior-event product-development Plan |
| `ROHM-SFI-043` | FY2025 H1 Results p.29、`Solutions for Servers` | Management-reported current-period qualitative assertion | ROHMはAI data serversを中心にROHM productsのadoptionが急速に進んでいると説明する。 | Adoptionの製品、customer、stage、order、shipment、revenue及び数量は未開示。Actual sales growth又はmarket shareとみなさない。 | 既存matchなし | **Proceed with caution** — qualitative adoption assertion |
| `ROHM-SFI-044` | FY2025 H1 Results p.29、Server sales target graphic | Prior issuer Target set | 当該Publication EventはFY2025、FY2030及びFY2035を軸とするserver sales target graphicを示す。 | 後続FY2025 Results p.27のFY2025 Actual / FY2026 / FY2028 / FY2030 targetと自動的に同一definition又は継続seriesとしない。Graphicの数値・scope reconciliationが完了するまでRaw化しない。 | `ROHM-SFI-010` / `011`のprior Source Event | **Hold** — target definition / numeric reconciliation required |
| `ROHM-SFI-045` | 2023-03-07 official news、Murata Power Solutions adoption announcement | Issuer-reported named-customer product adoption | ROHMはSiC SBD SCS308AHがMurata Power SolutionsのData Center PSUへ採用されたと発表する。 | Customer product family、order、shipment quantity、revenue、market share、exclusive supply又は全Murata PSUへの採用を確定しない。 | 既存matchなし | **Proceed with caution** — named-customer adoption assertion |
| `ROHM-SFI-046` | 2025-06-25 official news、BM6GD11BFJ-LB product status | Product-development / availability Actual | ROHMはhigh-voltage GaN向けisolated gate-driver IC BM6GD11BFJ-LBを開発し、sourceは`now available`と示す。 | Availabilityであり、mass-production volume、server adoption、shipment、revenue又はGaN-device shareを示さない。Application positioningは`047`へ分離する。 | 既存matchなし | **Proceed** — product availability Actual |
| `ROHM-SFI-047` | 2025-06-25 official news、Application Examples | Issuer product / application definition | ROHMはBM6GD11BFJ-LBとGaN deviceの組合せをserver power supplyを含むhigh-current application向けに位置付ける。 | Product suitabilityであり、AI-server専用、adoption、shipment、revenue又はActual demandを示さない。 | 既存matchなし | **Proceed** — issuer-defined application only |
| `ROHM-SFI-048` | 2025-03-05 official news、Murata 5.5kW PSU production passage | Named-customer production Plan | Murata Power Solutionsの5.5kW AI-server PSUは2025年にmass production開始予定とsourceは説明する。 | Planであり、production commencement、order、shipment、volume又はrevenueのActualを示さない。`026`のproduct adoption Factと分離する。 | Same Source Event as `ROHM-SFI-026` | **Proceed with caution** — named-customer production Plan |
| `ROHM-SFI-049` | 2021-05-27 official news、150V GaN HEMT technology passage | Product-development Actual | ROHMは150V GaN HEMT向け8V gate withstand-voltage technologyを開発したと発表する。 | Technology developmentであり、commercial product、adoption、shipment、revenue又はData Center demandを示さない。Sample Planは`050`、application positioningは`058`へ分離する。 | 既存matchなし | **Proceed with caution** — development-stage technology Actual |
| `ROHM-SFI-050` | 2021-05-27 official news、sample timing passage | Issuer Plan | ROHMは当該150V GaN deviceのsample shipmentを2021-09に予定すると説明する。 | Planであり、sample shipment Actual、mass production、customer adoption、revenue又はData Center allocationを示さない。 | Same Source Event as `ROHM-SFI-049` | **Proceed with caution** — sample Plan only |
| `ROHM-SFI-051` | 2022-04-28 official news、strategic-partnership announcement | Named-party development / mass-production partnership Actual | ROHMとDelta Electronicsはnext-generation GaN power devicesの共同development / mass productionに関するstrategic partnershipを締結した。 | Partnership Actualであり、個別customer order、製品採用、shipment、revenue、exclusive supply又はData Center専用relationを示さない。 | 2026 dynamic dialogueより前のversioned Source Event | **Proceed with caution** — named-party partnership relation |
| `ROHM-SFI-052` | 2022-04-28 official news、150V GaN production-system passage | Production-system Actual | ROHMは150V GaN HEMTのmass-production systemを2022-03に確立したと説明する。 | Production-system establishmentであり、production volume、Data Center allocation、shipment、customer adoption又はrevenueを示さない。Application positioningは`060`へ分離する。 | `ROHM-SFI-049` / `050`のlater Source Event | **Proceed with caution** — production-system Actual |
| `ROHM-SFI-053` | 2022-04-28 official news、600V GaN partnership plan | Named-party development / mass-production Plan | ROHMとDeltaはpower-supply system向け600V GaN power devicesを共同development / mass productionする方針を示す。 | Planであり、development completion、mass-production commencement、Data Center adoption、shipment又はrevenueを示さない。 | Same Source Event as `ROHM-SFI-051` / `052` | **Proceed with caution** — named-party product-development Plan |
| `ROHM-SFI-054` | 2023-05-08 official news、650V GaN HEMT production passage | Product mass-production Actual | ROHMは650V GaN HEMT GNP1070TC-Z及びGNP1150TCA-Zのmass productionを開始したと発表する。 | Product-level commencementであり、production volume、server allocation、shipment quantity、revenue又はcustomer adoptionを示さない。 | 既存matchなし | **Proceed with caution** — product mass-production commencement |
| `ROHM-SFI-055` | 2023-05-08 official news、Application Examples | Issuer product / application definition | ROHMは当該650V GaN HEMTsをserver及びAC adapter等のpower-supply system向けに位置付ける。 | ServerはAI server又はData Center単独ではない。Product suitabilityであり、adoption、shipment、revenue又はActual demandを示さない。 | 既存matchなし | **Proceed** — issuer-defined server application only |
| `ROHM-SFI-056` | 2023-05-08 official news、joint-development statement | Named-party product-development relationship | ROHMはGNP1070TC-Z / GNP1150TCA-ZをDelta Electronics affiliateのAncora Semiconductorsと共同開発したと発表する。 | Direct development relationであり、Deltaによるpurchase、adoption、order、shipment、revenue又はexclusive relationshipを示さない。 | `ROHM-SFI-051` / `053`のpartnershipと別Source Event / product grain | **Proceed with caution** — named-party joint-development relation |
| `ROHM-SFI-057` | FY2024 Results p.24、FY2024–FY2028 SAM illustration | Issuer management relative-market illustration | ROHMはproduct lineup強化によりAI data-server向けserviceable available marketをFY2024からFY2028に4倍へ拡大するillustrationを示す。 | SAM definition、absolute value、Actual achievement、sales、share又はcustomer adoptionを示さない。`042`のdevelopment Plan及び後続server-sales targetと同義化しない。 | Same Source position as `ROHM-SFI-042` | **Proceed with caution** — relative SAM illustration only |
| `ROHM-SFI-058` | 2021-05-27 official news、application statement | Issuer technology / application definition | ROHMは150V GaN HEMT technologyをbase-station / Data Center power-supply circuit向けに位置付ける。 | Application positioningであり、commercial product、adoption、shipment、revenue又はActual demandを示さない。 | Same Source Event as `ROHM-SFI-049` / `050` | **Proceed** — issuer-defined application only |
| `ROHM-SFI-059` | 2023-03-07 official news、Dr. Longcheng Tan（Murata Power Solutions Senior Electrical Engineer / project leader）statement | Named-customer production-stage assertion | TanはSCS308AHを採用したD1U front-end AC-DC PSUが`now in mass production`であると説明する。 | Named customer statementである。Production volume、ROHM shipment、order、revenue、start date、exclusive supply又は全D1U productへの採用を確定しない。 | Same Source Event as adoption `ROHM-SFI-045` | **Proceed with caution** — named-customer production-stage assertion |
| `ROHM-SFI-060` | 2022-04-28 official news、EcoGaN application passage | Issuer product-family expansion Plan / intended application scope | ROHMは150V EcoGaN lineupをbase-station / Data Center等のpower circuitへ拡大する見通しを説明する。 | Future expansion Planであり、Current availability、Data Center専用production、adoption、shipment、revenue又はActual demandを示さない。 | Same Source Event as `ROHM-SFI-051`–`053` | **Proceed with caution** — intended mixed-application expansion Plan |
| `ROHM-SFI-061` | 2022-03-22 official news、GNE10xxTB production passage | Product-production commencement Actual | ROHMは150V GaN HEMT GNE10xxTB seriesのproduction開始を発表する。 | Product-series commencementであり、production volume、Data Center allocation、shipment quantity、revenue又はcustomer adoptionを示さない。`052`の後続production-system statementとは別Source Eventで保持する。 | Prior direct Source Event for `ROHM-SFI-052` | **Proceed with caution** — product-production commencement |
| `ROHM-SFI-062` | 2022-03-22 official news、Application Examples | Issuer product / application definition | ROHMはGNE10xxTB seriesをData Center / base-station向け48V input buck-converter circuit等に位置付ける。 | Product suitabilityであり、Data Center専用production、adoption、shipment、revenue又はActual demandを示さない。 | Same Source Event as `ROHM-SFI-061` | **Proceed** — issuer-defined application only |

## 4. Excluded or Non-convertible Statements

| Statement family | Disposition | Reason |
| --- | --- | --- |
| Industrial、C&S又はServer BusinessをAI server / Data Center単独売上へ配賦する | Excluded | 各source-defined scopeは異なり、issuer mappingがない。 |
| FY2025 Server Business JPY17bnとFY2026以降のtargetを一本のActual time seriesとする | Excluded | ActualとPlan / Targetの測定分類が異なる。 |
| Computer & Storage 9.1%から金額を算出する | Excluded | Source-presented observationはshareであり、rounding及び分母条件の検証がない。 |
| AI server business拡大説明を売上又は利益の定量寄与へ変換する | Excluded | 定量allocationがない。 |
| 2.5x、+48% CAGR又は+41% CAGRを実現済みROHM成長率とみなす | Excluded | Plan / Forecast又はissuer-compiled contextである。 |
| 13kW→1,000kW及びcomponent countsをuniversal BOM又は半導体需要数量へ変換する | Excluded | Future architecture illustrationである。 |
| White paperのsimulationをmeasured product / system efficiencyとみなす | Excluded | Simulation条件、topology及びperipheral exclusionsに依存する。 |
| Deltaの採用・量産計画を実現済みorder、shipment、revenue又はproductionとみなす | Excluded | Customer Planであり、実行確認がない。 |
| Solution pageのproduct placementをavailability、design win又はcommercial adoptionとみなす | Excluded | Issuer taxonomy / portfolio mapである。 |
| ROHM又はDeltaのmarket outlookを第三者検証済みforecastとみなす | Excluded | Forecast provenance / methodが未確認である。 |
| 800VDC / ±400VDC discussionを唯一のindustry architecture又は必然的SiC需要とみなす | Excluded | Technical interpretationであり、architecture選択・条件に依存する。 |
| ROHM factsからMicrosoft、Alphabet、NVIDIA又は他社のpurchase、shipment若しくはrevenueを推定する | Excluded | 同一一次資料による定量的direct relationがない。 |
| `key silicon provider`又はNVIDIA architectureとのalignmentをNVIDIA procurement / design winとみなす | Excluded | ROHMのissuer assertionであり、NVIDIA側の購入又は採用確認ではない。 |
| `endorsed` / `recommended component`を量産採用、order、shipment又はrevenueとみなす | Excluded | 匿名第三者との評価・推薦関係でありcommercial stageが未開示である。 |
| 製品のmass-production commencementをAI-server向けproduction volume又は需要量とみなす | Excluded | Product-family全体のproduction eventであり、用途別allocationがない。 |
| Product development / sample Plan / application exampleをcommercial adoptionとみなす | Excluded | Development stage、Plan及びproduct positioningはActual adoptionと異なる。 |

## 5. Relationship Assessment

### Issuer-defined architecture / portfolio edges

```text
Server / Data Center
    ↓ issuer solution taxonomy
PSU + BBU + AI Server Motherboard
    ↓ issuer product positioning
SiC + GaN + Si MOSFET + Analog IC + Discrete components
```

根拠：cut-off内のversioned sourcesである`ROHM-SFI-013`及び`015`。`ROHM-SFI-012`のdynamic solution page taxonomyはexact-content identity未解決のためHoldであり、このconfirmed edgeの根拠に含めない。Architecture / portfolio上の関係であり、Actual sales又は採用を示さない。

```text
NVIDIA 800V HVDC architecture
    ↓ ROHM issuer-reported alignment / product response
ROHM Si + SiC + GaN + Analog / Module portfolio
```

根拠：`ROHM-SFI-029`。ROHM側のarchitecture response assertionであり、NVIDIA procurement、design win又はshipmentを示さない。

### Post-cut-off-inspected dynamic-page relationships — Hold

```text
Delta AC-DC PSU planned for mass production in Q2–Q3 2026
    ↓ named-customer stated adoption Plan
ROHM Si power MOSFET + SiC MOSFET
```

根拠：`ROHM-SFI-021`。Direct relationはPlanとして確認できるが、実行、order、shipment、volume及びrevenueは未確認である。

```text
Delta-stated grid-to-chip total-power-solution Plan
    ↓ planned product incorporation
ROHM power semiconductors + power-control ICs + DrMOS
```

根拠：`ROHM-SFI-022`。`ROHM-SFI-021`の特定PSU adoption Plan及び`025`のbroader collaboration relationとは別grainである。

```text
Delta Electronics
    ↕ named-party collaboration relationship
ROHM — AI-server power / HVDC domain
```

根拠：`ROHM-SFI-025`。個別製品組込み又は量産Planを示すedgeではない。

上記三つのDelta関連edgeは、page存在とtopic scopeのみcut-off時点で確認され、exact passageのversion identityは未解決である。このためすべてHoldであり、Raw Evidence対象ではない。

### Cut-off eligible named / anonymous relationship assertions

```text
ROHM ↔ Delta Electronics
    ↓ strategic partnership Actual / product-development and mass-production Plan
Next-generation GaN power devices, including planned 600V devices
```

根拠：Partnership relationは`ROHM-SFI-051`、600V development / mass-production Planは`053`。Partnership、Plan及び後続product Actualを同一化しない。

```text
ROHM ↔ Ancora Semiconductors, a Delta Electronics affiliate
    ↓ issuer-reported joint-development relation
GNP1070TC-Z / GNP1150TCA-Z 650V GaN HEMTs
```

根拠：`ROHM-SFI-056`。Delta purchase又はcommercial adoptionを示さない。

```text
Murata Power Solutions 5.5kW AI-server power supply
    ↓ ROHM issuer-reported named-customer adoption
ROHM EcoGaN
```

根拠：`ROHM-SFI-026`。Adoption assertionは確認できるが、order、shipment quantity、revenue及びexclusive supplyは未確認である。

```text
Anonymous global cloud platform provider
    ↓ ROHM issuer-reported endorsement assertion
RY7P250BM
```

根拠：`ROHM-SFI-030`。Sourceは複数形`providers`を用いる。Provider identity、design、adoption stage及びcommercial resultは未確認である。

```text
Anonymous leading global cloud platform provider
    ↓ ROHM issuer-reported recommended-component certification assertion
RY7P250BM
```

根拠：`ROHM-SFI-041`。`030`と同一party又はcorroborating relationとはみなさない。

```text
Anonymous AI-server BBU
    ↓ ROHM issuer-reported product adoption
SCT4013DLL 750V SiC MOSFET in ±400V power section
```

根拠：`ROHM-SFI-038`。Issuer-reported adoptionであるが、customer identity、volume、shipment及びrevenueは未確認である。

```text
Murata Power Solutions Data Center PSU
    ↓ ROHM issuer-reported named-customer adoption
SCS308AH SiC SBD
```

根拠：`ROHM-SFI-045`。Customer product family、order、shipment quantity及びrevenueは未確認である。

`ROHM-SFI-059`は同じMurata Source Event内のcustomer production-stage assertionを別Factとして保持する。Adoption relationとmass-production stageを一つのcommercial quantity Factへ結合しない。

### Product-stage edges

`ROHM-SFI-027`、`028`、`031`–`037`、`039`、`040`、`042`–`062`は、development、release、mass-production system / Plan / commencement、sample Plan、application positioning、prior Target、partnership及びadoption assertionをSource Event / measurement class別に分離する。製品stageが進んでいても、AI-server用途へのallocation又はcustomer adoptionを自動的に意味しない。

### Gap

調査cut-offまでに確認したROHM公式Source Setでは、AI server又はData Center単独のActual revenue、order、shipment unit、inventory、capacity、CapEx又はcustomer concentrationを確認できなかった。FY2025 Server Business sales JPY17.0bnはsource-defined `Server Business`であり、AI server単独又はData Center単独への配賦はできない。

Murata及び匿名BBUとのrelationはissuer-reported adoption、匿名cloud providerとのrelationはendorsement / recommendationとして開示されるが、いずれもorder、shipment quantity又はrevenueの確認は得られない。DeltaとのPlan / collaboration passageはcut-off exact-content identity未解決のためHoldである。Microsoft、Alphabet又はNVIDIAの投資・設備とROHMのActual salesを直接結ぶquantitative relationも確認できない。これは当該関係又は追加資料が存在しないことの証明ではない。

## 6. Preliminary Disposition

| Category | Count | Treatment |
| --- | ---: | --- |
| Reference existing evidence only | 4 | Sprint001 / Sprint002 Evidenceを参照し、Sprint003 IDを発行しない |
| Proceed | 11 | 独立レビュー後、個別Cross-sprint recheckを実施 |
| Proceed with caution | 36 | mixed scope / Plan / Forecast / scenario / adoption assertion / product stage境界を維持してrecheckを実施 |
| Hold | 11 | Raw Evidence化せず、provenance、method、scope又はcut-off content identityのreconciliation待ち |
| Excluded transformation | 16 | Evidence化せず、禁止変換として保持 |

Proceed 11件は`ROHM-SFI-013`、`015`、`031`、`033`、`037`、`040`、`046`、`047`、`055`、`058`、`062`である。Proceed with caution 36件は`005`、`006`、`007`、`009`、`010`、`011`、`016`、`018`、`019`、`026`–`030`、`032`、`034`–`036`、`038`、`039`、`041`–`043`、`045`、`048`–`054`、`056`、`057`、`059`–`061`である。Hold 11件は`008`、`012`、`014`、`017`、`020`–`025`、`044`である。

## 7. Gate Status and Next Gate

| Gate | Status | Record / Next action |
| --- | --- | --- |
| Source Fact Inspection Independent Review | Accepted | `ROHMSourceFactInspectionIndependentReview.v0.1-draft.md` — 2026-08-09、三者最終Finding 0件 |
| Candidate-level Cross-sprint recheck | Not started | Inspection Accepted後、Raw-eligible 47候補を一対一で照合 |
| Raw Evidence | Not created | Recheck Accepted後のみ作成 |
| EVR ID / registration | Not issued / not registered | Raw review Accepted後、EVR行作成時に発行 |
| PIT ID / registration | Not issued / not registered | EVR review Accepted後、一対一PIT行作成時に発行 |
| AvailableAt / Catalog | Not permitted | `TBD — no use` / `No` |
