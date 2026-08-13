# Sprint003 NVIDIA Core Company Research — Data Center / AI Infrastructure

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft core company research asset |
| Sprint | Sprint003 |
| 対象企業 | NVIDIA Corporation |
| Research Domain | Semiconductor — Demand — Data Center / AI Infrastructure |
| Version | 0.1-draft |
| 作成日 | 2026-08-11 |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Author | Documentation Team — Research Author persona |
| Reviewer | Evidence Validation / Chief Knowledge / Traceability reviewers — Accepted |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md` |
| Evidence範囲 | `S3-EVR-021`–`032` / `S3-PIT-021`–`032` |
| Review Record | `NVIDIACoreCompanyResearchIndependentReview.v0.1-draft.md` |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | No |

> **利用境界：** 本文書は独立レビュー済みEvidenceを企業単位で整理するDraft Research Assetである。Canonical Knowledge、Catalog、DDL、Entity、Database、ML、バックテスト、Decision Engine、Advisor又は投資判断への利用を許可しない。

## 1. 研究目的と責務

NVIDIAがData Center platform、revenue、reporting framework、supply / capacity obligation、component risk、regulatory event、market access及びenergy dependencyをどの粒度で開示しているかを、Evidence IDへ追跡可能な形で整理する。

本文書は新しいSource Factを作らない。FactはEvidence Registerを参照し、Cross-source InferenceはFactと分離する。未確認関係はGapとして保持する。

対象Research Questionは`S3-DCAI-RQ-001`、`003`、`005`及び`006`である。

## 2. Evidence Baseline

| 区分 | 件数 | 状態 |
| --- | ---: | --- |
| Source Fact候補 | 13 | Inspection Accepted |
| Raw-eligible | 12 | Proceed 9 + Proceed with caution 3 |
| Hold | 1 | `NVDA-SFI-012`; Raw / EVR / PIT未作成 |
| NVIDIA Raw Evidence | 12 | Package Review Accepted |
| NVIDIA EVR / PIT | 12 / 12 | Independent Review Accepted |

全12件は`AvailableAt = TBD — no use`、Catalog Eligibility `No`である。Evidence ID又はPIT IDの存在を、Canonical性、利用可能性又は投資上の有効性とみなさない。

## 3. Fact — Data Center Platform and Reporting Definition

### 3.1 Platform architecture

NVIDIAはData Center platformをcompute-intensive workloadsを加速するplatformと説明する。Compute / networking infrastructureはrack-scale systems、subsystems又はmodulesにsoftware / servicesを伴い、systemsはGPU、CPU、interconnect及びAI / HPC software等、networkingはNVLink、InfiniBand / Ethernet、adapters、cables、DPU並びにswitch chips / systems等を含む。根拠：`S3-EVR-021`。

列挙要素を売上内訳、数量、BOM又はsupplier relationへ変換せず、Data Center revenueをGPU又は半導体単体売上とみなさない。

### 3.2 Reporting transition

Q1 FY2027に、Market PlatformsをData Center / Edge Computingへ、Data CenterをHyperscale / ACIEへ分ける新分類が示された。Hyperscaleはpublic clouds及び最大規模のconsumer internet companies、ACIEはAI Clouds、Industrial、Enterpriseを含むpurpose-built Data Centers / AI factoriesを対象とする。根拠：`S3-EVR-025`。

旧Compute / Networkingと新Hyperscale / ACIEのidentity、継続性、restatement又は数値mappingは未確認である。区分変更だけから需要構造変化を推定しない。

### 3.3 Compute-supply role

NVIDIAは本Research Design上のCompute supply企業である。本役割は調査上の分類であり、NVIDIAの公式segment、製品別売上構成、業界代表性又は投資判断を新たに決定しない。

## 4. Fact — Data Center Revenue and Drivers

### 4.1 Revenue Actual

| Period | Data Center | Issuer sub-market detail | Evidence |
| --- | ---: | --- | --- |
| FY2024 | USD47.525bn | FY2024 Compute / Networking値はAccepted Raw scope外 | `S3-EVR-022` |
| FY2025 | USD115.186bn | Compute USD102.196bn / Networking USD12.990bn | `S3-EVR-022` |
| Q4 FY2025 | USD35.580bn | Compute USD32.556bn / Networking USD3.024bn | `S3-EVR-022` |
| Q4 FY2026 | USD62.3bn | QoQ +22% / YoY +75% | `S3-EVR-023` |
| FY2026 | USD193.7bn | YoY +68% | `S3-EVR-023` |
| Q1 FY2027 | USD75.2bn | QoQ +21% / YoY +92%; old view Compute USD60.4bn / Networking USD14.8bn | `S3-EVR-024` |

`S3-EVR-022`のPublication EventはUnknownを維持する。Data Center revenueはNVIDIA固有のMarket Platform revenueであり、GPU単体、semiconductor industry demand、shipment又はpower-semiconductor demandへ変換しない。

### 4.2 FY2026 driver explanation

FY2026 revenue growthはData Center compute / networking platforms for accelerated computing and AI solutionsが牽引し、Blackwell architecturesはData Center revenueのmajorityを占めた。Data Center computeは前年比59%増、networkingは142%増である。根拠：`S3-EVR-026`。

`majority`の比率・金額を推定せず、BlackwellをGPU単体又は特定製品だけの売上とみなさない。`S3-EVR-023`のActualへ別売上として加算しない。

## 5. Fact — Supply, Capacity and Component Context

### 5.1 Inventory purchase and capacity obligations

2026-01-25時点のoutstanding inventory purchase and long-term supply / capacity obligationsはUSD95.2bnで、substantially allがFY2027までに支払われる。発行者はData Center-scale production、long ordering horizons、customer-demand forecast及びmanufacturing lead times / constraintsを説明する。根拠：`S3-EVR-027`。

USD95.2bnをData Center専用額、CapEx、半導体発注額、Actual purchase、shipment又はrevenueへ変換しない。異なる10-K sectionのclassが完全に同一であると確定せず、component / supplierへ配賦しない。

### 5.2 Component constraint risk

一つのcomponentのsupply constraint又はavailability issueがより広いrevenue impactを持ったことがあり、完成品に必要なthird-party componentsの不足が販売を妨げ得るとNVIDIAは記載する。根拠：`S3-EVR-028`。

これはrealized and prospective risk narrativeであり、現在のshortage、失注額、component数量、発生確率、特定component又はsupplierを確定しない。

### 5.3 Data Center energy and capital dependency

顧客・partnerによるAI infrastructure buildoutにはData Center、energy及びcapitalのavailabilityが重要であり、energy capacity拡大は規制・技術・建設課題を伴う複雑なmulti-year processと説明される。根拠：`S3-EVR-032`。

固定Lead / Lag、開始点・終了点・期間、capacity量、半導体需要量又は単独因果を設定しない。

## 6. Fact — Regulatory and Geographic Context

### 6.1 H20 inventory charge

2025年4月の輸出license要件後のH20需要減少に伴い、Q1 FY2026にH20 excess inventory and purchase obligationsについてUSD4.5bn chargeを計上した。根拠：`S3-EVR-029`。

H20固有のregulatory demand shock及びinventory provision Actualであり、Data Center全体又はGlobal AI需要の通常循環へ一般化せず、inventory数量、将来回復又は他製品への代替を推定しない。

### 6.2 China market access

NVIDIAはFY2026末時点でChinaのData Center compute marketで実質的に競争できない状態と説明し、H200 license programでは提出時点までrevenueを計上していないと記載する。根拠：`S3-EVR-030`。

China総需要、市場規模、競合売上、lost revenue又は将来license / revenueを推定せず、H20 charge又はForecastと同一Factにしない。

### 6.3 Q2 FY2027 total-company outlook

Q2 FY2027全社revenue outlookはUSD91.0bn±2%で、Data Center compute revenue from Chinaを想定していない。根拠：`S3-EVR-031`。

これは全社Forecast / Planであり、Data Center Forecast、China需要減少額、Global demand又はActualへ変換しない。

## 7. Issuer-defined Relationships

確認できる関係はNVIDIA自身の開示内で次のように限定される。

```text
Accelerated computing / AI demand
  → NVIDIA Data Center compute and networking platform revenue
  → inventory purchase / supply / capacity management context

Customer / partner AI infrastructure buildout
  → Data Center / energy / capital availability dependency
```

これらは単一の定量因果chainではない。Revenue、obligation、component risk、energy dependency及びregulatory shockを統合して、注文、shipment、capacity、Lead / Lag又はsupplier revenueを生成しない。

## 8. Cross-source Inference — Research Only

### NVDA-INF-001 — Data Center revenue is a platform-scale observation

`S3-EVR-021`–`026`を併せると、NVIDIA Data Center revenueはcompute、networking、systems / modules及びsoftware / servicesを含むissuer-defined platform-scale observationとして整理する必要がある。

**制約：** GPU、semiconductor、power content又はunit demandへ分解せず、新旧reporting frameworkをmappingなしに接続しない。

### NVDA-INF-002 — Scale and constraints are disclosed in different measurement grains

`S3-EVR-023`,`027`,`028`,`032`は、Data Center revenue Actual、mixed obligations、component risk及びenergy / capital dependencyが別の測定・説明grainで開示されることを示す。

**制約：** obligationをrevenue driver又はdemand Forecastへ変換せず、component riskやenergy dependencyからshortage quantity、fixed lag又はForecast achievementを推定しない。

### NVDA-INF-003 — Regulatory shock must remain separate from ordinary demand context

`S3-EVR-029`–`031`は、H20 charge、China market-access status及びChina Data Center computeを除外した全社outlookをSource Fact別に保持する必要性を示す。

**制約：** 三Factを一つのChina demand amount、lost revenue、normal inventory cycle又はfuture recovery scenarioへ統合しない。

これらはCompany Research上のInferenceであり、EVR、PIT、Catalog Fact又はObservationとして登録しない。

## 9. Research Question Disposition

| Research Question | NVIDIAでの回答 | Disposition |
| --- | --- | --- |
| `S3-DCAI-RQ-001` | Data CenterはGPU単体ではなくcompute / networking infrastructure及びsoftware / servicesを含むplatformで、新しいHyperscale / ACIE分類とのmappingは未確認。 | Evidence supported; issuer scope / transition boundary |
| `S3-DCAI-RQ-003` | Data Center revenue Actualとdriver narrativeはplatform-scale demand realizationを示すが、半導体業界全体又はpower-semiconductor需要ではない。 | Evidence supported; platform-scale observation only |
| `S3-DCAI-RQ-005` | Data Center platform、component risk及びinfrastructure dependencyは確認できるが、hyperscaler investment又はNVIDIA demandから特定power supplierのorder、shipment若しくはrevenueへ至る単一Source Factは確認できない。 | Partial support + bounded Negative Evidence |
| `S3-DCAI-RQ-006` | Actual revenue、driver narrative、obligation、risk、regulatory Actual、market-access status、Forecast及びdependency narrativeを分離する必要がある。 | Evidence supported; classification control required |

## 10. Benchmark Follow-up Topics — 未採用

| Topic | Evidence basis | 必要な追加確認 | 現在の境界 |
| --- | --- | --- | --- |
| Data Center revenue series | `S3-EVR-022`–`024`,`026` | definition continuity、restatement、driver denominator | GPU / industry-demand Observationではない |
| Reporting transition | `S3-EVR-025` | old / new mapping、comparative periods、restatement | Trend breakを推定しない |
| Supply / capacity obligations | `S3-EVR-027` | class identity、item / supplier、delivery and payment | Data Center orderではない |
| Component constraints | `S3-EVR-028` | component、period、quantity、revenue impact | continuous shortage indicatorではない |
| China regulatory context | `S3-EVR-029`–`031` | product / license / revenue / period-specific updates | normal demand cycleではない |
| Energy / capital dependency | `S3-EVR-032` | measured project stages、duration、capacity and scope | Lead / Lag Indicatorではない |

これらは比較・更新検討用の未採用Topicであり、Feature、Lead / Lag Indicator、Catalog候補、投資signal又は`AvailableAt`決定ではない。

## 11. Gaps and Negative Evidence

1. Data Center revenueのGPU、CPU、networking、systems、software / services又はpower component別内訳は未確認。
2. 旧Compute / Networkingと新Hyperscale / ACIEのrestatement、数値mapping及び継続seriesは未確認。
3. USD95.2bn obligationsのData Center、product、component、supplier又はcustomer別内訳は未確認。
4. Component constraintのidentity、数量、期間、現行status及びrevenue impactは未確認。
5. H20 charge、China market access及びQ2 FY2027 outlookからChina demand又はlost revenueを算出できない。
6. Energy / capital dependencyについて固定Lead / Lag、capacity量又はsemiconductor demand量は未確認。
7. `NVDA-SFI-012`のFY2026 customer concentrationはCompute & Networking segmentのmixed scopeでData Center固有性を確認できないためHoldであり、本ResearchのFact baselineへ含めない。
8. 2026-07-30までに確認した記録済み公式Source Setでは、NVIDIA demand又はhyperscaler investmentからRenesas、ROHM若しくはInfineonのorder、shipment又はrevenueへ直接至る開示を確認できなかった。これは関係又は資料が存在しないことの証明ではない。

## 12. Update Triggers

- Hyperscale / ACIEの数値、comparative period又は旧区分restatementの開示。
- Data Center revenue / driver、Compute / Networking又はplatform scopeの更新。
- Supply / capacity obligation、component constraint及びenergy availabilityの定量更新。
- H20 / H200 license、China market access、inventory charge又はrevenue inclusionの更新。
- Named customer、supplier、product、order、shipment、capacity又はpower-content relationの公式開示。
- `NVDA-SFI-012`のData Center-specific scope解消。

Update Triggerは自動採用を意味しない。新しいSource Eventは再Inspection、Raw Review、EVR Review及びPIT Reviewを経る。

## 13. Downstream Boundary and Next Handoff

本文書から次へ接続できるのは、Reviewed Draft Baseline及びPhase 1 Closureの再照合だけである。

- 新しいEvidence ID又はPIT IDを発行しない。
- `NVDA-INF-001`–`003`をEvidence又はCatalog Factへ登録しない。
- Benchmark Follow-up TopicをObservation、Feature又はLead / Lag Indicatorとして採用しない。
- `AvailableAt`を決定しない。
- Catalog、DDL、Entity、Database、ML、Backtest、Decision Engine、Advisor及び投資判断に利用しない。
- Phase 2を開始しない。
