# Infineon Technologies — Data Center / AI Infrastructure Source Fact Inspection

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft Source Fact inspection |
| Sprint | Sprint003 |
| 対象企業 | Infineon Technologies AG |
| Version | 0.1-draft |
| 作成日 | 2026-08-09 |
| Retrieval Date | 2026-08-09 |
| 調査cut-off | 2026-07-30 23:59 JST |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Reviewer Status | Evidence / Knowledge / Traceability — Accepted |
| Related Review Record | `InfineonSourceFactInspectionIndependentReview.v0.1-draft.md` |
| Evidence ID | None — `IFX-SFI-xxx`はLocal inspection IDであり、Evidence IDではない |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md` |
| Stage 0 | `Sprint003DataCenterAIInfrastructureStage0IndependentReview.v0.1-draft.md` — Accepted |
| Cross-sprint参照 | `Sprint003DataCenterAIInfrastructureCrossSprintBridge.v0.1-draft.md` |

> **利用境界：** 本文書はSource Fact候補をRaw Evidence化する前の検査記録である。Evidence採用、`S3-EVR-xxx`又は`S3-PIT-xxx`の発行、`AvailableAt`の確定、Catalog / DDL / ML利用を許可しない。既存Sprintと同一のSource Factは参照のみとし、Sprint003で再発行しない。

## 1. Research Questions

| Research Question | Infineonでの確認対象 |
| --- | --- |
| `S3-DCAI-RQ-001` | Infineonが用いるAI server、AI data center、server business、AI power、grid-to-core及びsegmentの範囲 |
| `S3-DCAI-RQ-004` | Data Center / AI用途とSi、SiC、GaN、PSU、IBC、VRM及びpower managementの明示関係 |
| `S3-DCAI-RQ-005` | NVIDIA、Intel又は匿名顧客とのissuer-named relationship及び需要側投資とのDirect relation |
| `S3-DCAI-RQ-006` | Actual、Forecast、Target、Plan、issuer estimate、design-win assertion、product availability及びsegment narrativeの差 |

## 2. Inspected Official Sources

| Source | Publication Event | Applicable Period | Official location | Inspection status |
| --- | --- | --- | --- | --- |
| Infineon Technologies AG, Annual Reports archive | Archive page。exact page publication event `Unknown` | FY2021–FY2025 | [Official archive](https://www.infineon.com/about/investor/reports-presentations/annual-reports) | FY2021以降のannual source locationを確認。FY2021に新規Data Center Fact候補を確認できなかったことは不存在証明ではない |
| Infineon Technologies AG, *Annual Report 2025* | PDF copy deadline 2025-11-27。publication time / timezone `Unknown` | FY2024 / FY2025 Actual、FY2026 Forecast / end-of-decade outlook | [Official PDF](https://www.infineon.com/row/public/documents/corporate/investors/annual-reports/2025/2025-annual-report-v01-00-en.pdf)、physical PDF pp.8, 50, 68 / viewer P7, P49, P67 | AI data-center revenue、Forecast、addressable market、NVIDIA relation、segment outlook及びinvestment contextをinspection |
| Infineon Technologies AG, *FY 2025 concluded in line with expectations* | 2025-11-12。publication time / timezone `Unknown` | FY2025 results / FY2026 outlook | [Official results release](https://www.infineon.com/press-release/2025/infxx202511-021) | Annual ReportのFY2025 result eventをcorroborate。別Factの重複候補にはしない |
| Infineon Technologies AG, *First Quarter FY 2026 Quarterly Update* | 2026-02-04。time / timezone `Unknown` | FY2025 revenue mix / Q1 FY2026 / architecture roadmap | [Official PDF](https://www.infineon.com/assets/row/public/documents/corporate/investors/presentations/2026/2026-02-04-q1-fy26-investor-presentation-v01-00-en.pdf)、physical PDF pp.59–63 / viewer P58–P62 | Grid-to-core、PSU、IBC及びvertical power delivery passagesをinspection |
| Infineon Technologies AG, *Q2 FY2026 Investor Presentation* and *Analyst Call Intro Statement* | 2026-05-06。time / timezone `Unknown` | Q2 FY2026 Actual / FY2026–FY2027 indication | [Official presentation](https://www.infineon.com/row/public/documents/corporate/investors/presentations/2026/2026-05-06-q2-fy26-investor-presentation-v01-00-en.pdf)、[official statement](https://www.infineon.com/row/public/documents/corporate/investors/presentations/2026/2026-05-06-q2-fy26-intro-statement-analyst-call-v01-00-en.pdf)、statement physical PDF pp.4–5 / viewer P3–P4 | PSS result、AI allocation、capacity、revenue indication、GaN shipment、design-in、SiC growth及びcontent estimateをinspection |
| Infineon Technologies AG, *Powering AI — from the panel to the token* | 2025-11-26 | FY2025 Actual / FY2026 Forecast / architecture scenarios | [Official PDF](https://www.infineon.com/content/dam/infineon/row/public/documents/corporate/investors/presentations/2025/2025-11-26-power-roadshow-v01-00-en.pdf)、physical PDF pp.4–5, 11–12, 20–23 / viewer P3–P4, P10–P11, P19–P22 | Grid-to-core taxonomy、rack-power / content scenarios、revenue context及びcustomer graphicをinspection |
| Infineon Technologies AG, *Fourth Quarter FY 2024 Investor Presentation* | 2024-11-12 | FY2024 Actual context / FY2025 and later Forecast / Target | [Official PDF](https://www.infineon.com/content/dam/infineon/row/public/documents/corporate/investors/presentations/2024/2024-11-12-q4-fy24-investor-presentation-v01-00-en.pdf)、physical PDF pp.47–54 / viewer P46–P53 | Historical AI server revenue outlook、rack BOM estimate、PSU roadmap及びpower-delivery illustrationsをinspection |
| Infineon Technologies AG, *Expanding our leadership in Power Systems* | 2023-11-27 | FY2023 context / FY2024–FY2029 Forecast | [Official PDF](https://www.infineon.com/content/dam/infineon/row/public/documents/corporate/investors/presentations/2023/20231127-presentation-power-roadshow-v01-00-en.pdf)、physical PDF pp.7–11 / viewer P6–P10 | AI-server BOM、power-delivery calculation、revenue Forecast及びanonymous design-win graphicをinspection |
| Infineon Technologies AG, *Complete power management solutions for next-generation Intel Xeon processors* | 2022-03-31 | Product launch / availability at publication | [Official technology news](https://www.infineon.com/technology-news/2022/infpss202203-066) | Intel Sapphire Rapids compute-server offering及びproduct setをinspection |
| Infineon Technologies AG, *XDP710 Digital hot-swap controller* | 2022-11-14 | Product introduction / external speaker assertion | [Official technology news](https://www.infineon.com/technology-news/2022/infpss202211-023) | NVIDIA speaker statement及びInfineon product definitionをinspection |
| Infineon Technologies AG, *AI data-center PSU roadmap* | 2024-05-24 | Current product / future roadmap at publication | [Official press release](https://www.infineon.com/press-release/2024/infpss202405-105) | 3 / 3.3 / 8 / 12 kW PSU stage、performance claims及びavailability Planをinspection |
| Infineon Technologies AG / NVIDIA, *800 V power delivery architecture for future AI server racks* | 2025-05-20 | Named-party development relation / future architecture | [Official press release](https://www.infineon.com/press-release/2025/INFXX202505-107) | NVIDIA collaborationと800 V HVDC architectureを分離してinspection |
| Infineon Technologies AG, *AI data center PSU solutions to 30 kW* | 2026-06-02 | Product / reference-design introduction and evaluation Plan | [Official technology news](https://www.infineon.com/technology-news/2026/infpss202606-094) | 18 kW reference design、30 kW evaluation board、performance及びavailabilityを分離してinspection |
| Infineon Technologies AG, *Kulim SiC power fab first phase opening* | 2024-08-08 | Fab opening Actual / future expansion | [Official press release](https://www.infineon.com/press-release/2024/infxx202408-133) | Production-stage、mixed applications、investment及びcustomer-commitment contextをinspection |

### 2.1 Period Coverage and Search Boundary

| Period | Coverage confirmation | Treatment |
| --- | --- | --- |
| FY2021 | Official Annual Report archiveとofficial siteを`data center`、`server`、`AI`、`power supply`で確認 | 新規Source Fact候補なし。不存在証明ではない |
| FY2022–FY2023 | Annual archive、2022 Intel / NVIDIA product news、2023 Power Roadshowを確認 | Product relation、availability、Forecast、estimate及びdesign-win assertionを分離 |
| FY2024–FY2025 | Q4 FY2024、Annual Report 2025、2024–2025 official releases、Power Roadshowを確認 | Historical Forecast、later Actual、architecture及びnamed relationshipをPublication Event別に保持 |
| Latest pre-cut-off FY2026 | Q1 / Q2 FY2026及び2026-06-02 product newsを確認 | Latest Actual、Forecast / indication、capacity action、shipment assertion及びproduct stageを分離 |

このcoverage記録は、調査cut-offまでに確認したInfineon公式Archive / Newsroom / Investor資料の限定集合であり、web上の完全な不存在を証明しない。

## 3. Source Fact Candidate Inspection

| Local ID | Source position | Classification | Candidate Source Fact | Use boundary | Existing evidence / overlap | Preliminary disposition |
| --- | --- | --- | --- | --- | --- | --- |
| `IFX-SFI-001` | Annual Report 2025、Automotive segment revenue position | Existing Actual | FY2025 Automotive segment revenue。 | AutomotiveをAI data center又はPSSへ配賦しない。 | Sprint001 `EVR-004`と同じFact | **Reference existing evidence only** |
| `IFX-SFI-002` | Annual Report 2025, physical PDF p.50 / viewer P49及びp.8 / P7 | Source-presented Actual | AI-server power-supply components / AI data-center power-supply solutions revenueはFY2024約EUR250mからFY2025 EUR700m超へ増加し、nearly tripledと発行者は説明する。 | Source wording差を保持し、PSS segment全体、AI server全体又はindustry revenueへ拡張しない。二期間のSource-presented Actualだが、Forecast / Targetと連結しない。 | FY2025 results releaseがcorroborating Source Event | **Proceed with caution** — issuer-defined application Actual |
| `IFX-SFI-003` | Annual Report 2025, physical PDF p.8 / viewer P7 | Issuer Forecast | FY2026 revenue Forecastを約EUR1bnから約EUR1.5bnへ引き上げたと発行者は説明する。 | Actualではない。為替、customer mix、product mix又は達成確率を補完しない。 | `002`のfuture period | **Proceed with caution** — Forecast only |
| `IFX-SFI-004` | Annual Report 2025, physical PDF p.8 / viewer P7 | Historical issuer addressable-market Forecast | Infineon addressable marketはend of decadeにEUR8bn–12bnと発行者は予測した。 | Infineon revenue、TAM Actual、market share又はthird-party validated Forecastとみなさない。2026-05-06に`IFX-SFI-042`のper-kW assessmentがこのSAM sizingをreplacedしたため、Current Forecastとして使用しない。 | Power Roadshowにも同じfigure | **Proceed with caution** — superseded issuer market Forecast |
| `IFX-SFI-005` | 2025-05-20 release and Annual Report 2025 p.8 | Named-party architecture-development relation | InfineonとNVIDIAはAI data center向け800 V HVDC power architectureを共同開発している。 | Development relationであり、NVIDIA procurement、exclusive supply、order、shipment又はrevenueを確定しない。 | Two official Infineon Source Events; same relationship Fact | **Proceed** — named-party direct development relation |
| `IFX-SFI-006` | Annual Report 2025, physical PDF p.68 / viewer P67 | Issuer segment Forecast / driver narrative | FY2026 PSS revenueはAI data-center power-supply productsのstrong demand momentumによりGroup平均より大幅に速く成長すると発行者はForecastする。 | Segment Forecastであり、AI contribution amount、Actual growth又はproduct-level revenueを確定しない。 | Existing S3 matchなし | **Proceed with caution** — mixed segment outlook |
| `IFX-SFI-007` | Annual Report 2025, physical PDF p.68 / viewer P67 | Issuer investment Plan / mixed cash-flow context | FY2026 Free Cash Flow Forecastは、Dresden frontend manufacturing及びAI data-center power-supply capacity expansionへのsignificant investment cash outflowsを含む。 | Total investmentをAIへ配賦せず、capacity amount、wafer volume、product又はcustomerを補完しない。 | Existing S3 matchなし | **Proceed with caution** — mixed investment context |
| `IFX-SFI-008` | Q2 FY2026 statement, physical PDF p.4 / viewer P3 | Segment Actual | Q2 FY2026 PSS revenueはEUR1.260bn、Segment Result EUR257m、margin 20.4%と表示される。 | PSSはAI単独ではない。AI revenue、product mix又はcustomer contributionへ配賦しない。 | Existing S3 matchなし | **Proceed with caution** — mixed-segment Actual |
| `IFX-SFI-009` | Q2 FY2026 statement, physical PDF p.4 / viewer P3 | Management-reported Actual-period explanation | PSS sequential growthは主にAI power及びradar sensor businessにより牽引されたと発行者は説明する。 | AIとradarの寄与を分離せず、amount、growth rate又はcausal shareを算出しない。 | Same event as `008` | **Proceed with caution** — mixed driver narrative |
| `IFX-SFI-010` | Q2 FY2026 statement, physical PDF p.4 / viewer P3 | Management-reported current operating condition | InfineonはAI businessがallocation状態にあると説明する。 | Allocationのproduct、customer、quantity、duration、backlog又はunmet demandを補完しない。 | Existing S3 matchなし | **Proceed with caution** — issuer operating assertion |
| `IFX-SFI-011` | Q2 FY2026 statement, physical PDF p.3 / viewer P2 | Management capacity redeployment action | Infineonはautomotive high-voltage drivetrain向けfrontend manufacturing capacityをAI data-center businessへredeployしていると説明する。 | Source businessとdestinationを保持する。Capacity amount、technology、site、product、AI allocation又はcompletionを補完せず、Automotive revenue減少額をAI revenueへ移し替えない。 | `010` / `041`と同じevent、別Fact | **Proceed with caution** — source-specific capacity redeployment |
| `IFX-SFI-012` | Q2 FY2026 statement, physical PDF p.4 / viewer P3 | Issuer indication | Dedicated AI power revenueについてFY2027 EUR2.5bn indicationを示す。 | Actual又はFY2026 guidanceではない。`indication`をguidance又はTargetへ同義化しない。同時に再確認されたFY2026 EUR1.5bnは`003`のcross-event corroborationに限定し、別Raw又は独立signalとしない。 | `003`のFY2026 Forecast再確認と同じpassage | **Proceed with caution** — FY2027 indication only |
| `IFX-SFI-013` | Q2 FY2026 statement, physical PDF pp.4–5 / viewer P3–P4 | Management-reported shipment assertion | AI data-center applications向けGaNはselected power-supply socketsへshipmentsが増えていると発行者は説明する。 | Product、customer、quantity、revenue、production site又はmarket shareを確定しない。 | Existing S3 matchなし | **Proceed with caution** — unquantified shipment assertion |
| `IFX-SFI-014` | Q2 FY2026 statement, physical PDF pp.4–5 / viewer P3–P4 | Management-reported design-in pipeline assertion | GaN design-in pipelineは複数power-conversion stagesへ拡大していると発行者は説明する。 | Design-in pipelineをdesign win、order、shipment、revenue又はnamed customer adoptionとみなさない。 | Same event as `013` | **Proceed with caution** — pipeline assertion |
| `IFX-SFI-015` | Q2 FY2026 statement, physical PDF p.5 / viewer P4 | Mixed-scope growth assertion | AI-related demandがFY2026 overall SiC businessのlow-double-digit growthを牽引すると発行者は説明する。 | Overall SiC businessはAI単独ではない。AI contribution、base amount又はapplication mixを算出しない。 | Existing S3 matchなし | **Proceed with caution** — mixed-scope growth statement |
| `IFX-SFI-016` | Q2 FY2026 statement, physical PDF p.5 / viewer P4 | Issuer content estimate | Rack configurationによりInfineon contentはUSD100–250/kW、current averageは約USD175/kWとのissuer estimateを示す。 | Transaction price、universal BOM、revenue、installed capacity又はmarket shareへ変換しない。 | Prior BOM estimates exist with different denominator | **Proceed with caution** — issuer content estimate |
| `IFX-SFI-017` | Q1 FY2026 presentation, physical PDF p.59 / viewer P58 | Issuer architecture / portfolio definition | InfineonはAI-related power conversionをgrid-to-coreで扱い、AC/DC、48V / 12V DC/DC及びcore voltage conversionを示す。 | Portfolio / architecture definitionであり、Actual adoption、revenue又はindustry-standard architectureではない。 | Q4 FY2024 / Power Roadshow同family | **Proceed** — issuer architecture definition |
| `IFX-SFI-018` | Q1 FY2026 presentation, physical PDF p.60 / viewer P59 | Product availability Actual at publication | 3.3 / 8 / 12 kW single-phase PSUを2026-02-04時点でavailable nowと表示する。 | Publication Event時点のavailabilityであり、production volume、adoption、shipment又はrevenueを示さない。Future reference-board roadmapは`043`へ分離する。 | 2024 roadmap及び2026 releaseとcross-event reconciliation required | **Proceed with caution** — product availability Actual |
| `IFX-SFI-019` | Q1 FY2026 presentation, physical PDF p.61 / viewer P60 | Issuer product / application definition | Infineonはcurrent / future AI-server rack向けHV / MV IBC portfolioを示す。 | Portfolio positioningであり、availability、design win、shipment、revenue又はuniversal architectureを示さない。 | Existing S3 matchなし | **Proceed** — issuer product-scope definition |
| `IFX-SFI-020` | Q1 FY2026 presentation, physical PDF p.63 / viewer P62 | Internal engineering illustration | Vertical power deliveryによりsubstrate PDN lossesを追加10–15%削減するとのissuer illustrationを示す。 | Internal architecture estimateであり、customer system測定、universal saving、revenue又はadoptionではない。 | Existing S3 matchなし | **Proceed with caution** — engineering estimate |
| `IFX-SFI-021` | 2025 Power Roadshow, physical PDF p.4 / viewer P3 | Issuer value-chain / portfolio taxonomy | InfineonはAI data-center power supplyをGrid、Rack、Core、Physical AIへ広げ、SST、SSCB、UPS / ESS、cooling等を配置する。 | Issuer taxonomyであり、各productのavailability、adoption、revenue又はsingle segment mappingではない。 | `017`より広い value-chain scope | **Proceed** — issuer taxonomy |
| `IFX-SFI-022` | 2025 Power Roadshow, physical PDF p.11 / viewer P10 | Issuer architecture / content scenario | Today約125kW / rack・Infineon content約USD15k、2027+約600kW+、2029+ 1MW超 / rack・content USD100k超というscenarioを示す。 | Scenarioであり、fleet average、installed base、shipment、revenue Forecast又はuniversal BOMではない。 | `016`とdenominator / eventが異なる | **Proceed with caution** — architecture / content scenario |
| `IFX-SFI-023` | 2025 Power Roadshow, physical PDF p.20 / viewer P19 | Unresolved customer-revenue graphic | FY2024 / FY2026の`biggest customers` revenue graphicを示すが、抽出可能本文だけでは個別値、customer identity及びscopeを確定できない。 | 数値、顧客、growth又はconcentrationを推定しない。 | Existing S3 matchなし | **Hold** — graphic definition / numeric inspection required |
| `IFX-SFI-024` | Q4 FY2024 presentation, physical PDF p.47 / viewer P46 | Historical issuer Forecast | FY2025 AI revenue in server businessはEUR500m超とのForecastを示す。 | Historical Forecastであり、later FY2025 Actualと同義化せず、forecast accuracyの評価前にseries化しない。 | Later `002` Actual exists | **Proceed with caution** — prior Forecast |
| `IFX-SFI-025` | Q4 FY2024 presentation, physical PDF p.47 / viewer P46 | Historical issuer Target | AI server revenue EUR1bnをnext two years内に達成するTargetを示す。 | Targetであり、FY2026 Forecast又はFY2027 indicationと自動的に同一定義・期限へ接続しない。 | Later `003` / `012` require reconciliation | **Proceed with caution** — prior Target |
| `IFX-SFI-026` | Q4 FY2024 presentation, physical PDF p.49 / viewer P48 | Issuer BOM estimate / rack illustration | Infineon BOM per AI-server rackはUSD12k–15kまでとのissuer estimateを示す。 | Simplified rack configuration依存。Transaction price、universal BOM、shipment、revenue又はmarket shareではない。 | `016` / `022`とdenominator / configurationが異なる | **Proceed with caution** — issuer rack-BOM estimate |
| `IFX-SFI-027` | Q4 FY2024 presentation p.50 and 2024-05-24 release | Product availability Actual at publication | 3 / 3.3 kW PSUは2024 Source Event時点でavailableと示される。 | Publication Event時点のstageを保持し、後続availabilityへ遡及更新しない。Future 8 / 12 / >12 kW roadmapは`044`へ分離する。 | Q1 FY2026 / 2026 releaseとcross-event reconciliation required | **Proceed** — product availability Actual |
| `IFX-SFI-028` | 2024-05-24 release, PSU performance passages | Issuer product-performance assertion / Plan | New-generation PSUは97.5% efficiency、8kW PSUは300kW以上のAI rackをsupport可能、power densityは100 W/in³との発行者説明を示す。 | Product / demonstrator condition依存。Third-party benchmark、deployment、shipment、revenue又はall-load efficiencyへ一般化しない。 | Existing S3 matchなし | **Proceed with caution** — product-performance assertion |
| `IFX-SFI-029` | 2025-05-20 release | Corroborating Source Event for named-party architecture-development relation | InfineonとNVIDIAの800 V HVDC共同開発relationを直接発表するSource Event。 | Source Factは`005`が所有する。別Raw、別EVR / PIT、独立signal、二度の進展又はcorroborationによる確度加算を禁止する。 | Exact duplicate relationship Fact of `005` | **Duplicate / corroborating source event — no separate Raw** |
| `IFX-SFI-030` | 2025-05-20 release, architecture passage | Issuer / named-party technical architecture definition | Central 800 V HVDC generationからserver board上のAI chip近傍でpower conversionするarchitectureを説明する。 | Future architectureであり、deployment、standard adoption、product purchase又はrevenueではない。 | `029`とsame event、別Fact grain | **Proceed** — architecture definition |
| `IFX-SFI-031` | 2026-06-02 news, solution introduction | Product / reference-design introduction | 50 V rack向け18 kW three-phase PSU reference designと800 VDC / ±400 VDC sidecar向け30 kW PFC evaluation boardを発表する。 | Reference design / evaluation boardであり、customer deployment、shipment又はrevenueではない。 | Q1 roadmapのlater Source Event | **Proceed** — product introduction |
| `IFX-SFI-032` | 2026-06-02 news, performance passages | Issuer engineering / product-performance assertion | 18 kW designは97.5% peak efficiency、30 kW boardは99%超peak efficiency等を発行者は示す。 | Topology、load及びtest conditions依存。System-wide efficiency、third-party benchmark、commercial result又はuniversal performanceへ変換しない。 | Same event as `031` | **Proceed with caution** — performance assertion |
| `IFX-SFI-033` | 2026-06-02 news, availability section | Evaluation availability Plan | 18 kW reference designと30 kW evaluation boardはevaluation向けにsoon availableとされる。 | Planであり、availability Actual、mass production、shipment又はcustomer adoptionではない。 | Same event as `031` / `032` | **Proceed with caution** — availability Plan |
| `IFX-SFI-034` | 2022-03-31 news | Named-platform product-offering launch / availability | Intel Sapphire Rapids compute servers向けにXDP controllers、OptiMOS integrated power stages及びIPOL regulatorからなるofferingをlaunchし、available nowと発表する。 | Platform-oriented offeringであり、Intel procurement、customer adoption、shipment、revenue又はexclusive relationを確定しない。 | Existing S3 matchなし | **Proceed** — product offering / availability |
| `IFX-SFI-035` | 2022-11-14 news, Abhijit Datta / NVIDIA statement | Named external-speaker product-requirement assertion | NVIDIA speakerはXDP710がHGX Platform product requirementに適合し、design-inしやすいと説明する。 | Speaker attributionを保持する。Purchase、production adoption、order、shipment、revenue又はexclusive design winを確定しない。 | Existing S3 matchなし | **Proceed with caution** — external speaker assertion |
| `IFX-SFI-036` | 2023 Power Roadshow, physical PDF p.7 / viewer P6 | Issuer BOM estimate | Average Infineon BOM per AI serverはUSD850–1,800とのissuer estimateを示す。 | Server configuration依存。`026` rack BOM又は`016` per-kW contentと同義化せず、transaction price、revenue又はmarket shareへ変換しない。 | Different denominator from later estimates | **Proceed with caution** — issuer server-BOM estimate |
| `IFX-SFI-037` | 2023 Power Roadshow, physical PDF p.11 / viewer P10 | Historical issuer Forecast | FY2024 AI revenue in server businessはlow triple-digit EUR million amountとのForecastを示す。 | Historical ForecastでありActualではない。Later revenue disclosuresとdefinition / period確認なしにseries化しない。 | Earlier event for `024` / `002` | **Proceed with caution** — prior Forecast |
| `IFX-SFI-038` | 2023 Power Roadshow, physical PDF p.11 / viewer P10 | Historical issuer growth Forecast | FY2024–FY2029 AI server revenue CAGRは50%超とのForecastを示す。 | Actual CAGR、industry growth又はmarket shareではない。Base / endpoint amountを補完しない。 | Existing S3 matchなし | **Proceed with caution** — prior CAGR Forecast |
| `IFX-SFI-039` | 2023 Power Roadshow, physical PDF p.11 / viewer P10 | Issuer-reported anonymous design-win assertion | 複数のNorth American CPU / GPU manufacturers及びcloud providersについてAI server businessのcustomer design winsをgraphicで示す。 | Customer identity、product、stage、order、shipment、revenue、win date又はexclusive relationを確定しない。 | Existing S3 matchなし | **Proceed with caution** — anonymous design-win assertion |
| `IFX-SFI-040` | 2024-08-08 Kulim release | Mixed-scope fab / customer-commitment context | Kulim first phase opening、EUR2bn investment、SiC production及びGaN epitaxyを説明し、AI data centerを複数applicationの一つとして挙げる。 | Automotive、renewables等とのmixed scope。Customer commitments / prepaymentsをAI-specificとせず、AI capacity、wafer volume、shipment又はrevenueへ配賦しない。 | Existing S3 matchなし | **Hold** — AI-specific allocation unavailable |
| `IFX-SFI-041` | Q2 FY2026 statement, physical PDF p.3 / viewer P2 | Management-reported demand / supply condition | AI data-center businessではdemandがsupplyをstrongly exceedしていると発行者は説明する。 | Product、customer、quantity、period、shortfall、backlog又はrevenue impactを補完しない。`allocation`又はcapacity redeploymentと別Factを維持する。 | `010` / `011`と同じevent、別Fact | **Proceed with caution** — unquantified demand-supply assertion |
| `IFX-SFI-042` | Q2 FY2026 statement, physical PDF p.5 / viewer P4 | Issuer measurement / market-sizing method change | USD100–250/kW・current average約USD175/kWのcontent assessmentが、従来のend-of-decade EUR8bn–12bn SAM sizingをreplacesすると発行者は説明する。 | 新しいabsolute market-size Forecastを作らず、旧SAMと新assessmentを同一series又はgrowth rateへ変換しない。`016`のcontent estimateを測定単位として参照する。 | `004` historical sizing / `016` current content estimate | **Proceed** — issuer measurement-basis replacement |
| `IFX-SFI-043` | Q1 FY2026 presentation, physical PDF p.60 / viewer P59 | Product roadmap / future reference-board Plan | 16+ kWは`Ref. Board Q2 26`、27 kWは`Ref. Board Q3 26`、30 kWは`Topology Eval. Board Q2 26`として、three-phase solutionsのfuture roadmapに表示される。 | Source記載のboard typeとtimingを製品別に保持する。Availability Actual、mass production、customer adoption、shipment又はrevenueを示さない。`018`のavailable-now productsと分離する。 | 2026-06-02 later introduction requires stage reconciliation | **Proceed with caution** — future product roadmap |
| `IFX-SFI-044` | Q4 FY2024 presentation p.50 and 2024-05-24 release | Product availability Plan / roadmap | 8 kWは`Available in Q1/25`、12 kWは`Available in Q2/25`、12 kW超は`Available in 26`と表示される。2024-05-24 releaseは8 kWのQ1 2025 availability Planをcorroborateする。 | Source-exactな製品別timingを保持する。2024 Source Event時点のPlanであり、後続availability Actualへ遡及変換しない。`027`の3 / 3.3 kW current productsと分離する。 | Q1 FY2026 / 2026 releaseとcross-event stage reconciliation required | **Proceed with caution** — historical product roadmap |

## 4. Excluded or Non-convertible Statements

| Statement family | Disposition | Reason |
| --- | --- | --- |
| PSS segment Actual又はForecastをAI power revenueへ配賦する | Excluded | PSSはAI単独ではなく、product / application allocationがない。 |
| FY2025 Actual、FY2026 Forecast、FY2027 indication及びend-of-decade market Forecastを一つのActual seriesにする | Excluded | Measurement classification、period及びdefinitionが異なる。 |
| EUR8bn–12bn addressable marketからInfineon market share又はrevenueを算出する | Excluded | Issuer ForecastでありActual market / shareではない。 |
| Rack、server又はper-kW content estimateを相互変換する | Excluded | Denominator、configuration及びPublication Eventが異なる。 |
| Allocation又はdesign-in pipelineをBacklog、order、shipment又はrevenueとみなす | Excluded | Quantity、stage及びcommercial outcomeが未開示である。 |
| Selected-socket GaN shipmentをGaN全体又はAI revenueへ拡張する | Excluded | Product、customer、quantity及びrevenueが未開示である。 |
| SiC overall growthをAI-only growthへ配賦する | Excluded | Mixed application / product scopeである。 |
| NVIDIA collaboration又はHGX requirement statementをprocurement / exclusive design winとみなす | Excluded | Development relation又はspeaker assertionであり、purchaseを示さない。 |
| Intel platform向けofferingをIntel procurement又はcustomer adoptionとみなす | Excluded | Product offering / availabilityである。 |
| Architecture、BOM、efficiency又はrack-power scenarioをinstalled base / universal designへ一般化する | Excluded | Issuer estimate / illustration / future architectureである。 |
| Product introduction、reference design、evaluation board及びavailability Planを量産・shipment・revenueへ変換する | Excluded | Product stageが異なる。 |
| Kulim investment又はcustomer commitmentsをAI data-center capacityへ配賦する | Excluded | Multiple application / customer scopeである。 |
| Superseded EUR8bn–12bn SAM sizingとper-kW assessmentを連続market-size seriesへ変換する | Excluded | 発行者がmeasurement basisのreplacementを明示している。 |
| Hyperscaler Capex又はNVIDIA demandからInfineon salesへの定量因果を作る | Excluded | 同一Sourceによるattributable quantitative relationがない。 |

## 5. Relationship Assessment

### Confirmed named development / product-context edges

```text
NVIDIA
    ↓ named-party joint development
800 V HVDC architecture for AI data centers
    ↓ issuer architecture definition
Central power generation → server board → AI chip-level conversion
```

根拠：`IFX-SFI-005` / `029` / `030`。`005`と`029`は同一relationship Factであり、Raw化時に二重発行しない。Development relationであり、procurement又はcommercial resultではない。

```text
Intel Sapphire Rapids compute-server platform
    ↓ Infineon platform-oriented offering
XDP controllers + OptiMOS power stages + IPOL regulator
```

根拠：`IFX-SFI-034`。Intel procurement又はadoption Actualを確定しない。

```text
NVIDIA HGX Platform product requirement
    ↓ NVIDIA speaker assertion
Infineon XDP710 product fit / design usability
```

根拠：`IFX-SFI-035`。Speaker attributionを保持し、order、shipment又はexclusive design winへ拡張しない。

### Issuer-defined architecture / portfolio edges

```text
Grid → Rack → Core
    ↓ Infineon portfolio taxonomy
SST / SSCB / UPS / PSU / IBC / VRM / power stages
    ↓ material and control portfolio
Si + SiC + GaN + drivers + controllers + sensors
```

根拠：`IFX-SFI-017` / `019` / `021`。Portfolio taxonomyであり、各stageのActual revenue又はadoptionを示さない。

### Anonymous or unresolved edges

- `IFX-SFI-039`は複数の匿名CPU / GPU manufacturers及びcloud providersとのdesign-win assertionである。Identity、product及びcommercial stageは未確認。
- `IFX-SFI-023`のbiggest-customer revenue graphicはnumeric / definition inspection未完了のためHoldであり、Relationship又はcustomer concentrationを確定しない。
- `IFX-SFI-040`のcustomer commitments / prepaymentsはKulim mixed-scope contextであり、AI-specific relationshipとして使用しない。

## 6. Disposition Summary

| Disposition | Count | IDs |
| --- | ---: | --- |
| Reference existing evidence only | 1 | `IFX-SFI-001` |
| Duplicate / corroborating source event | 1 | `IFX-SFI-029` |
| Proceed | 9 | `005`、`017`、`019`、`021`、`027`、`030`、`031`、`034`、`042` |
| Proceed with caution | 31 | `002`–`004`、`006`–`016`、`018`、`020`、`022`、`024`–`026`、`028`、`032`–`033`、`035`–`039`、`041`、`043`–`044` |
| Hold | 2 | `023`、`040` |
| **Total** | **44** | `IFX-SFI-001`–`044` |

Raw-eligible unique FactはProceed 9件 + Proceed with caution 31件 = 40件である。`IFX-SFI-029`は`005`のcorroborating Source Eventであり、別Rawを作成しない。Evidence / PIT IDは発行しない。

## 7. Gap Register

| Gap | Evidence status | Required treatment |
| --- | --- | --- |
| AI power / AI data-center revenue definitionのPublication Event間継続性 | 未確認 | FY2024 Forecast、FY2025 Actual、FY2026 Forecast、FY2027 indicationを自動series化しない |
| End-of-decade market sizing basis | Measurement change confirmed | EUR8bn–12bn historical SAM sizingは2026-05-06のper-kW assessmentにreplaced。両者を連続series化しない |
| PSS segmentからAI revenueへのbridge | 未開示 | Segment revenueを配賦しない |
| Allocation、design-in pipeline及びshipmentの数量・製品・顧客 | 未開示 | Backlog、order、revenue又はmarket shareへ変換しない |
| Biggest-customer graphicの値・identity・scope | Hold | Graphic inspection / definition reconciliationが完了するまで使用しない |
| Rack / server / per-kW content estimateのconfiguration bridge | 未開示 | Denominator間変換を禁止する |
| Product roadmapからcommercial shipmentへのstage transition | 一部未確認 | Publication Event別stageを保持する |
| Kulim capacityのAI-specific allocation | 未開示 | AI data-center capacityへ配賦しない |
| Hyperscaler investment又はNVIDIA compute demandからInfineon salesへの定量relation | 確認できない | Negative Evidenceとして限定し、因果又は倍率を作らない |
| Publication time / timezone | 多くのSourceで`Unknown` | 推測補完せず、`AvailableAt = TBD — no use`を維持する |

Negative Evidenceは、調査cut-offまでに確認した公式Source Setで関係を確認できなかったことだけを意味し、当該関係又は資料の不存在を証明しない。

## 8. Next Gate

1. Evidence、Knowledge及びTraceabilityの独立レビューはAcceptedである。
2. Raw-eligible候補だけをcandidate-level Cross-sprint recheckへ進める。
3. `029`は`005`のcorroborating Source Eventとして別Rawを作成せず、その他のsame-event / cross-event関係をFact grainで照合する。
4. Recheck Accepted前にRaw Evidenceを作成しない。
5. Raw Review Accepted前にEVR IDを発行・登録しない。
6. EVR Review Accepted前にPIT IDを発行・登録しない。
7. 全候補で`AvailableAt = TBD — no use`、Catalog Eligibility `No`を維持する。

## 9. Inspection Disposition

**Disposition: Accepted**

独立レビューでは、44候補をReference 1、Duplicate / corroborating 1、Raw-eligible unique Fact 40、Hold 2として受け入れた。Candidate-level recheck前であり、Raw Evidence、EVR又はPITは未作成・未発行である。本DispositionはInspection gateの受入れであり、Canonical化、Catalog採用又は下流利用の承認ではない。
