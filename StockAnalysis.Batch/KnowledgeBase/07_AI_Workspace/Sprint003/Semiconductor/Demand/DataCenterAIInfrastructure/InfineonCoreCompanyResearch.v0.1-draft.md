# Sprint003 Infineon Core Company Research — Data Center / AI Infrastructure

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft core company research asset |
| Sprint | Sprint003 |
| 対象企業 | Infineon Technologies AG |
| Research Domain | Semiconductor — Demand — Data Center / AI Infrastructure |
| Version | 0.1-draft |
| 作成日 | 2026-08-09 |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Author | Documentation Team — Research Author persona |
| Reviewer | Evidence Validation / Chief Knowledge / Traceability reviewers — Accepted |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md` |
| Evidence Gate | `InfineonEvidencePackageGateReconciliation.v0.1-draft.md` — Independent Review Accepted |
| Evidence範囲 | `S3-EVR-093`–`132` / `S3-PIT-093`–`132` |
| Review Record | `InfineonCoreCompanyResearchIndependentReview.v0.1-draft.md` |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | No |

> **利用境界：** 本文書は、独立レビュー済みEvidenceを企業単位で整理するDraft Research Assetである。Canonical Knowledge、Catalog、DDL、Entity、Database、ML、バックテスト、Decision Engine、Advisor又は投資判断への利用を許可しない。

## 1. 研究目的と責務

InfineonがData Center（データセンター）又はAI Infrastructure（AIインフラ）に関係するPower Semiconductor（パワー半導体）、Power Supply（電源）、Power Management（電源管理）及び関連Architectureを、どの事業・製品・技術・関係性・将来計画として開示しているかを、Evidence IDへ追跡可能な形で統合する。

本文書は新しいSource Factを作らない。FactはEvidence Registerを参照し、Cross-source Inference（複数資料に基づく推論）はFactと分離する。未確認関係はGapとして保持する。

対象Research Questionは`S3-DCAI-RQ-001`、`004`、`005`及び`006`である。`S3-DCAI-RQ-007`は上流Research Designで日本株対象のRenesas及びROHMに限定されており、Infineonには適用しない。

## 2. Evidence Baseline

| 区分 | 件数 | 状態 |
| --- | ---: | --- |
| Source Fact候補 | 44 | Inspection Accepted |
| Reference-only | 1 | Sprint001 `EVR-004`を参照。Sprint003で再発行しない |
| Duplicate / corroborating Source Event | 1 | `IFX-SFI-029`。`005`を唯一のFact ownerとする |
| Raw-eligible | 40 | Proceed 9 + Proceed with caution 31 |
| Hold | 2 | Raw / EVR / PIT未作成 |
| Infineon Raw Evidence | 40 | Package Review Accepted |
| Infineon EVR / PIT | 40 / 40 | Independent Review Accepted |

全40件は`AvailableAt = TBD — no use`、Catalog Eligibility `No`である。Evidence ID又はPIT IDの存在を、Canonical性、利用可能性又は投資上の有効性とみなさない。

## 3. Fact — 発行者が示す事業・需要文脈

### 3.1 AI Data Center power revenue

- AI-server power-supply components / AI data-center power-supply solutions revenueはFY2024約EUR250mからFY2025 EUR700m超へ増加し、発行者は`nearly tripled`と説明する。二期間のSource-presented Actualだが、PSS segment全体又はAI server市場全体へ拡張しない。根拠：`S3-EVR-093`。
- FY2026 revenue Forecastは約EUR1bnから約EUR1.5bnへ引き上げられ、Q2 FY2026にもEUR1.5bnが再確認された。再確認を別Fact、独立signal又は確度加算とせず、Actualとみなさない。根拠：`S3-EVR-094`。
- Dedicated AI power revenueについてFY2027 EUR2.5bnの`indication`が示される。FY2026 Forecast、guidance、Target又はActualとは別の時点分類として保持する。根拠：`S3-EVR-103`。
- FY2025 AI revenue in server business EUR500m超はhistorical Forecast、next two years内のEUR1bnはhistorical Target、FY2024 low triple-digit EUR millionはhistorical Forecast、FY2024–FY2029 CAGR 50%超はhistorical growth Forecastである。定義、期間及びSource Eventを確認せず単一seriesへ連結しない。根拠：`S3-EVR-114`–`115`、`126`–`127`。

### 3.2 PSS segment及びmixed scope

- FY2026 PSS revenueはAI data-center power-supply productsのstrong demand momentumによりGroup平均より大幅に速く成長するとのSegment Forecastである。AI contribution amount又はActual growthは確定しない。根拠：`S3-EVR-097`。
- Q2 FY2026 PSS revenueはEUR1.260bn、Segment Result EUR257m、margin 20.4%である。PSSはAI単独ではなく、AI revenue又はproduct / customer contributionへ配賦しない。根拠：`S3-EVR-099`。
- PSSのsequential growthは主にAI power及びradar sensor businessにより牽引されたとのActual-period explanationである。二つの寄与を分離せず、amount又はcausal shareを算出しない。根拠：`S3-EVR-100`。
- FY2026 Free Cash Flow ForecastにはDresden frontend manufacturing及びAI data-center power-supply capacity expansionへのsignificant investment cash outflowsが含まれる。Mixed investment contextであり、AI向け金額、wafer volume、product又はcustomerへ配賦しない。根拠：`S3-EVR-098`。
- AI-related demandがFY2026 overall SiC businessのlow-double-digit growthを牽引するとの説明はmixed-scope assertionであり、AI contribution又はbase amountを算出しない。根拠：`S3-EVR-106`。

### 3.3 Demand / supply及びcommercial-stage assertion

- AI businessはallocation状態にあり、AI data-center businessではdemandがsupplyをstrongly exceedしていると発行者は説明する。Product、customer、quantity、duration、shortfall、backlog又はrevenue impactは未開示であり、二つを同一Fact又は定量signalに統合しない。根拠：`S3-EVR-101`、`129`。
- Automotive high-voltage drivetrain向けfrontend manufacturing capacityをAI data-center businessへredeployしているとの説明がある。Capacity amount、technology、site、completion又はAutomotiveからAIへのrevenue移転を補完しない。根拠：`S3-EVR-102`。
- Selected power-supply socketsでAI data-center向けGaN shipmentが増加し、GaN design-in pipelineが複数power-conversion stagesへ拡大しているとの発行者説明がある。Shipment、pipeline、design win、order及びrevenueは相互に置換しない。根拠：`S3-EVR-104`、`105`。

## 4. Fact — Architecture、market framing及びcontent

### 4.1 ArchitectureとPortfolio

- InfineonはAI-related power conversionをgrid-to-coreで扱い、AC/DC、48V / 12V DC/DC及びcore voltage conversionを示す。Issuer architecture / portfolio definitionであり、Actual adoption又はindustry standardではない。根拠：`S3-EVR-108`。
- Current / future AI-server rack向けHV / MV IBC portfolioを示すが、availability、design win、shipment又はuniversal architectureを確定しない。根拠：`S3-EVR-110`。
- AI data-center power supplyをGrid、Rack、Core、Physical AIへ広げ、SST、SSCB、UPS / ESS及びcooling等を配置する。Issuer value-chain taxonomyであり、単一segment又は各productのcommercial statusではない。根拠：`S3-EVR-112`。
- Central 800 V HVDC generationからserver board上のAI chip近傍でpower conversionするfuture architectureを説明する。Deployment、standard adoption又はproduct purchaseを確定しない。根拠：`S3-EVR-119`。
- Vertical power deliveryによりsubstrate PDN lossesを追加10–15%削減するとのinternal engineering illustrationがある。Customer system測定又はuniversal savingではない。根拠：`S3-EVR-111`。

### 4.2 Market sizing、content及びdenominator

- End of decadeにEUR8bn–12bnとしたInfineon addressable-market Forecastはhistoricalであり、2026-05-06にper-kW content assessmentへ置き換えられた。Current Forecast又はInfineon revenueとして利用しない。根拠：`S3-EVR-095`、`130`。
- Rack configurationによりInfineon contentはUSD100–250/kW、current average約USD175/kWとのissuer estimateがある。Transaction price、universal BOM、revenue又はinstalled capacityへ変換しない。根拠：`S3-EVR-107`。
- Today約125kW / rack・Infineon content約USD15k、2027+約600kW+、2029+ 1MW超 / rack・content USD100k超というissuer scenarioがある。Fleet average、installed base又はrevenue Forecastではない。根拠：`S3-EVR-113`。
- 2024 Source EventではInfineon BOM per AI-server rack USD12k–15k、2023 Source Eventではaverage Infineon BOM per AI server USD850–1,800とのissuer estimateがある。Per-kW、rack及びserverという分母・configurationを相互変換しない。根拠：`S3-EVR-116`、`125`。

## 5. Fact — Product Stage及びPerformance

| Evidence group | Stage | 確認できる範囲 | 確認できない範囲 |
| --- | --- | --- | --- |
| `S3-EVR-109` | Availability Actual at publication | 3.3 / 8 / 12 kW single-phase PSUを2026-02-04時点で`available now` | Production volume、adoption、shipment、revenue。Future roadmapは`131`と分離 |
| `S3-EVR-117` | Availability Actual at publication | 3 / 3.3 kW PSUを2024 Source Event時点でavailable | 後続availabilityへの遡及更新。Future roadmapは`132`と分離 |
| `S3-EVR-118` | Performance assertion / Plan | New-generation PSU 97.5%、8kW PSUによる300kW以上rack support、100 W/in³ | Third-party benchmark、deployment、all-load efficiency又はcommercial result |
| `S3-EVR-120` | Reference-design introduction | 18 kW three-phase PSU reference designと30 kW PFC evaluation boardの発表 | Customer deployment、shipment又はrevenue |
| `S3-EVR-121` | Performance assertion | 18 kW design 97.5% peak efficiency、30 kW board 99%超peak efficiency | System-wide efficiency、第三者benchmark又はuniversal performance |
| `S3-EVR-122` | Evaluation availability Plan | 18 kW / 30 kW artifactsをevaluation向けにsoon availableとする計画 | Availability Actual、mass production、shipment又はadoption |
| `S3-EVR-131` | Future reference-board Plan | 16+ kW=`Ref. Board Q2 26`、27 kW=`Ref. Board Q3 26`、30 kW=`Topology Eval. Board Q2 26` | Availability Actual、mass production又はcommercial adoption |
| `S3-EVR-132` | Historical availability Plan | 8 kW=`Q1/25`、12 kW=`Q2/25`、12 kW超=`in 26` | 後続Actualへの遡及変換 |

Product availability、roadmap、reference design、evaluation board、performance assertion、evaluation Plan及びcommercial deploymentは相互に置換しない。

## 6. Fact — 確認できたRelationship

### 6.1 Named-party relationship / offering

| Party | Relationship Fact | Evidence | 境界 |
| --- | --- | --- | --- |
| NVIDIA | InfineonとNVIDIAはAI data center向け800 V HVDC power architectureを共同開発している | `S3-EVR-096` | Development relationであり、procurement、exclusive supply、order、shipment又はrevenueではない。`IFX-SFI-029`から別Fact又は確度加算を作らない |
| Intel Sapphire Rapids | XDP controllers、OptiMOS integrated power stages及びIPOL regulatorからなるofferingをlaunchし、available nowと発表 | `S3-EVR-123` | Intel procurement、customer adoption、shipment、revenue又はexclusive relationではない |
| NVIDIA / HGX | NVIDIA speakerはXDP710がHGX Platform product requirementに適合し、design-inしやすいと説明 | `S3-EVR-124` | External-speaker attributionを保持し、purchase、production adoption、order、shipment、revenue又はexclusive design winを確定しない |

### 6.2 Anonymous relationship

- 複数のNorth American CPU / GPU manufacturers及びcloud providersについてAI server businessのcustomer design winsをgraphicで示す。Customer identity、product、stage、order、shipment、revenue、win date又はexclusive relationは未確認である。根拠：`S3-EVR-128`。

### 6.3 確認できないDirect relation

確認済みEvidenceは、Microsoft又はAlphabetのinvestment、NVIDIAのcompute demand若しくはindustry-wide AI investmentから、Infineonのorder、shipment、revenue又はmarket shareへ至る定量的なDirect relationを示さない。

これは当該関係の不存在を証明しない。確認済みSource Setと調査cut-offに限定したNegative Evidenceである。

## 7. Cross-source Inference — Factではない

| Inference ID | Inference | 根拠Evidence | 制約 |
| --- | --- | --- | --- |
| IFX-INF-001 | InfineonはGridからCoreまでのarchitecture、複数voltage stage、PSU / IBC / power delivery及びdevice portfolioを一つのAI power機会としてpositioningしている。 | `S3-EVR-108`、`110`、`112`、`119`–`123` | Portfolio breadthの推論であり、採用率、競争優位、売上規模又はmarket shareではない |
| IFX-INF-002 | Revenue Actual / Forecastとallocation、demand-supply、capacity redeployment及びGaN commercial-stage assertionの組合せは、InfineonがAI powerを現在の事業拡大領域として扱っていることを示唆する。 | `S3-EVR-093`–`094`、`097`–`105`、`129` | 需要量、供給不足量、Forecast達成、customer concentration又は売上因果を証明しない |
| IFX-INF-003 | NVIDIA / Intel / anonymous counterpartiesに関する開示は、AI infrastructureで複数種類のcommercialization-related relationが存在することを示唆する。 | `S3-EVR-096`、`123`、`124`、`128` | 各relationを同一stageとせず、order、shipment、revenue、exclusive supply又はnamed customer identityを補完しない |
| IFX-INF-004 | 2024–2026のPSU availability、roadmap、reference-design及びevaluation開示は、power levelとarchitectureの変化に対応するproduct-stage progressionを追跡できる可能性を示す。 | `S3-EVR-109`、`117`–`122`、`131`–`132` | Publication Event別Factを自動接続せず、同一product identity、stage transition又はcommercial resultを推測しない |

これらはResearch-level Inferenceであり、Evidence Register又はKnowledge CatalogへFactとして登録しない。

## 8. Research Question Disposition

| Research Question | Research-level answer | Evidence status |
| --- | --- | --- |
| `S3-DCAI-RQ-001` | InfineonはAI-server power-supply components、AI data-center power-supply solutions、dedicated AI power revenue、AI revenue in server business、PSS及びoverall SiC businessという複数Scopeを用いる。これらは同義ではない。 | Evidence supported; definition / mixed-scope constraintあり |
| `S3-DCAI-RQ-004` | Grid-to-core、800 V HVDC、PSU、IBC、GaN、SiC、controller及びintegrated power stageまで明示がある。Architecture、portfolio、availability、performance及びcommercial stageを個別に評価する必要がある。 | Evidence supported |
| `S3-DCAI-RQ-005` | NVIDIA、Intel及び匿名counterpartyとのrelationship / offering Factはあるが、hyperscaler investmentからInfineon salesへの定量的Direct relationは確認できない。 | Partial support + bounded Negative Evidence |
| `S3-DCAI-RQ-006` | Actual、Forecast、Target、indication、estimate、scenario、Plan、relationship、product stage及びmanagement assertionが混在する。Historical SAMはper-kW assessmentに置き換えられ、単純な時系列又は横断比較は不可。 | Evidence supported; comparability controls required |

## 9. Benchmark Follow-up Topics — 未採用

本節はInfineonをpower benchmark candidateとして比較可能性を検討するためのResearch follow-up topicである。`S3-DCAI-RQ-007`への回答、Observation採用、特徴量候補又は下流利用候補ではない。

| Candidate Observation | Evidence basis | 現在の状態 | 採用前に必要な確認 |
| --- | --- | --- | --- |
| AI power revenue | `S3-EVR-093`–`094`、`103`、`114`–`115`、`126`–`127` | Actual / Forecast / indication / Targetの複数時点分類 | Definition continuity、対象製品、期間、Forecast accuracy、AvailableAt authority |
| PSS segment / AI driver | `S3-EVR-097`、`099`–`100` | Segment Forecast / Actual / mixed driver | AI-only bridge、radarとの分離、分母、更新頻度 |
| Allocation / demand-supply / redeployment | `S3-EVR-101`–`102`、`129` | Qualitative operating conditions / action | Product、quantity、duration、site、capacity及び反復可能な観測定義 |
| GaN commercial stage | `S3-EVR-104`–`105` | Shipment increase / design-in pipeline assertion | Product identity、customer、quantity、stage vocabulary、後続Actual |
| Product-stage transition | `S3-EVR-109`、`117`–`122`、`131`–`132` | Availability Actual / roadmap / introduction / performance / evaluation Plan | 同一product identity、board type、stage vocabulary、Source Event間reconciliation。Architecture又はrelationshipを混入しない |
| Per-kW / rack / server content | `S3-EVR-107`、`113`、`116`、`125`、`130` | Estimate / scenario / method change | Denominator、configuration、measurement continuity及び相互変換禁止 |
| Named / anonymous relationship | `S3-EVR-096`、`123`–`124`、`128` | Development / offering / speaker / design-win assertions | Counterparty、product、stage、order・shipment・revenue非開示の保持 |

この表はInfineonのObservation採用、`S3-DCAI-RQ-007`への回答、特徴量設計又は利用可能性を決定しない。

## 10. Open Questions and Gaps

- `IFX-SFI-023`：biggest-customer revenue graphicのnumeric、identity及びscope inspection。
- `IFX-SFI-040`：Kulim fabのAutomotive、renewables、AI data center等mixed scopeからAI-specific allocationを作れない。
- AI power revenueのPublication Event間definition continuity、product scope及びsegment bridge。
- Historical EUR8bn–12bn SAMとper-kW content assessmentのmethod / denominator差。Growth rate又は連続seriesへ変換できない。
- Allocation、demand > supply、capacity redeployment、shipment increase及びdesign-in pipelineのproduct、customer、quantity、duration及びrevenue impact。
- Per-kW、rack及びserver BOM / content estimate間のconfiguration bridge。
- Product roadmap、reference design及びevaluation Planからcommercial shipmentへのstage transition。
- NVIDIA / Intel / anonymous relationshipのprocurement、order、shipment、revenue又はexclusive supply。
- Hyperscaler investment又はNVIDIA compute demandからInfineon businessへ至る定量的なDirect relation。
- Publication time / timezoneと`AvailableAt` authority。

## 11. Update Triggers

- Infineonの通期・四半期決算、Annual Report及びAI power revenue guidance / indication更新。
- AI-server power、AI data-center power、dedicated AI power又はPSSの定義変更。
- FY2026 Forecast、FY2027 indication及びhistorical Targetに対するActual又はrevision。
- Allocation、demand-supply又はcapacity redeploymentの解消・継続・定量化。
- GaN shipment / design-in pipelineのproduct、customer又は数量開示。
- PSU roadmap、reference design又はevaluation Planからavailability / shipment Actualへの遷移。
- NVIDIA、Intel又はanonymous design-winのcommercial stage追加開示。
- Hold候補のgraphic definition又はAI-specific allocation解消。

## 12. Completion and Downstream Boundary

InfineonのCompany-level Evidence acquisitionは独立レビュー済みGateにより完了している。本文書は、そのEvidenceを企業単位で統合した最初のResearch Draftである。

本文書は、著者から独立したEvidence、Knowledge及びTraceability ReviewでAcceptedとなった。Review Accepted後もDraft / noncanonical、`AvailableAt = TBD — no use`及びCatalog Eligibility `No`を維持する。

Definition and Comparability Matrix、Industry Report及びSprint003 Phase 1 Closureは別成果物であり、本文書の完成だけでは開始済み又は完了とみなさない。
