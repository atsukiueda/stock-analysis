# NVIDIA — Data Center / AI Infrastructure Source Fact Inspection

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft Source Fact inspection |
| Sprint | Sprint003 |
| 対象企業 | NVIDIA Corporation |
| Version | 0.1-draft |
| 作成日 | 2026-08-02 |
| Retrieval Date | 2026-08-02 |
| 調査cut-off | 2026-07-30 23:59 JST |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Reviewer Status | Evidence / Knowledge / Traceability review completed — Accepted |
| Related Review Record | `NVIDIASourceFactInspectionIndependentReview.v0.1-draft.md` |
| Evidence ID | None — 本文書の`NVDA-SFI-xxx`はLocal inspection IDであり、Evidence IDではない |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md` |
| Stage 0 | `Sprint003DataCenterAIInfrastructureStage0IndependentReview.v0.1-draft.md` — Accepted |

> **利用境界：** 本文書はSource Fact候補をRaw Evidence化する前の検査記録である。候補のEvidence採用、`S3-EVR-xxx`又は`S3-PIT-xxx`の発行、`AvailableAt`の確定、Catalog / DDL / ML利用を許可しない。

## 1. Research Questions

| Research Question | NVIDIAでの確認対象 |
| --- | --- |
| `S3-DCAI-RQ-001` | Data Center、Compute、Networking、AI infrastructure及びplatformの発行者定義 |
| `S3-DCAI-RQ-003` | NVIDIA固有のData Center Actual、製品・platform構造及び需要コメント |
| `S3-DCAI-RQ-005` | Data Center buildoutとGPU、CPU、DPU、interconnect、switch、networking、supply / capacityとの発行者明示関係 |
| `S3-DCAI-RQ-006` | Actual、Forecast、risk、commitment、reporting-framework transition及びmanagement narrativeの分類差 |

## 2. Inspected Official Sources

| Source | Publication Event | Applicable Period | Official location | Inspection status |
| --- | --- | --- | --- | --- |
| NVIDIA Corporation, *Fiscal 2026 Form 10-K* | SEC filed 2026-02-25; accepted 2026-02-25 16:42:19（SEC index表示。timezoneはページ上で別途明示されない） | FY ended 2026-01-25 | [SEC filing index](https://www.sec.gov/Archives/edgar/data/1045810/000104581026000021/0001045810-26-000021-index.htm)、[SEC filing](https://www.sec.gov/Archives/edgar/data/1045810/000104581026000021/nvda-20260125.htm) | Source Fact inspection completed for listed positions |
| NVIDIA Corporation, *Fourth Quarter and Fiscal 2026 Results* | 2026-02-25; release time/timezone `Unknown`（14:00 PTは別eventであるconference call時刻） | Q4 / FY2026, quarter and year ended 2026-01-25 | [Official earnings release](https://investor.nvidia.com/news/press-release-details/2026/NVIDIA-Announces-Financial-Results-for-Fourth-Quarter-and-Fiscal-2026/) | Source Fact inspection completed for listed positions |
| NVIDIA Corporation, *First Quarter Fiscal 2027 Results* | 2026-05-20; release time/timezone `Unknown`（14:00 PTは別eventであるconference call時刻） | Q1 FY2027, quarter ended 2026-04-26; Q2 FY2027 outlook | [Official earnings release](https://investor.nvidia.com/news/press-release-details/2026/NVIDIA-Announces-Financial-Results-for-First-Quarter-Fiscal-2027/default.aspx) | Source Fact inspection completed for listed positions |
| NVIDIA Corporation, *CFO Commentary on Fourth Quarter and Fiscal 2025 Results* | Publication date/time/timezone `Unknown` | Q4 / FY2025, quarter and year ended 2025-01-26 | [Official CFO Commentary PDF](https://investor.nvidia.com/files/doc_financials/2025/Q425/Q4FY25-CFO-Commentary.pdf) | Prior-year Actual and classification inspection completed; `AvailableAt = TBD — no use` |

## 3. Source Fact Candidate Assessment

| Local ID | Source position | Classification | Source Fact candidate | Use boundary | Cross-sprint check | Raw Evidence recommendation |
| --- | --- | --- | --- | --- | --- | --- |
| `NVDA-SFI-001` | FY2026 Form 10-K, Part I, Item 1, `Data Center` | Issuer definition / platform architecture | NVIDIAはData Center platformをAI、data processing、graphics、robotics及びscientific computing等のcompute-intensive workloadsを加速するplatformと説明する。Compute / networking infrastructureはrack-scale systems、subsystems又はmodulesにsoftware / servicesを伴い、systemsはGPU、CPU、interconnect、AI / HPC software等、networkingはNVLink、InfiniBand / Ethernet、adapters、cables、DPU、switch chips / systems等を含む。 | Data Center revenueをGPU単体又は半導体だけの売上とみなさない。列挙要素を相互排他的な売上内訳、数量又はBOMへ変換しない。 | Stage 0固定集合で既存NVIDIA matchなし | **Proceed** — issuer-defined Data Center platform boundary |
| `NVDA-SFI-002` | Q4 FY2025 CFO Commentary, pp.1–3, Revenue by Market Platform and Revenue commentary | Direct quantitative observation / Actual with issuer demand explanation | FY2025 Data Center revenueはUSD115.186bn（FY2024 USD47.525bn）で、内訳はCompute USD102.196bn、Networking USD12.990bn。Q4 FY2025 Data Center revenueはUSD35.580bn、Compute USD32.556bn、Networking USD3.024bn。発行者はFY2025成長をaccelerated computing platformへの需要と関連付ける。 | NVIDIA固有Market Platform Actual。Publication eventはUnknown。Data Center revenueを半導体業界需要、shipment数量、特定顧客投資又は日本株供給企業売上へ変換しない。 | 既存matchなし | **Proceed** — prior-year Data Center / Compute / Networking Actual baseline |
| `NVDA-SFI-003` | Q4 / FY2026 earnings release, `Data Center` highlights | Direct quantitative observation / Actual with issuer driver explanation | Q4 FY2026 Data Center revenueはUSD62.3bnで前四半期比22%増、前年比75%増。FY2026 Data Center revenueはUSD193.7bnで前年比68%増。発行者はQ4の増加をaccelerated computing及びAIへのmajor platform shiftsと関連付ける。 | Market Platform Actual。Data Center revenueにはplatform、systems、networking、software / servicesが含まれ得るため、GPU又は半導体売上と同一化しない。 | 既存matchなし | **Proceed** — latest full-year and quarter Data Center Actual |
| `NVDA-SFI-004` | Q1 FY2027 earnings release, headline, reporting framework and `Data Center` highlights | Direct quantitative observation / Actual | Q1 FY2027 Data Center revenueはUSD75.2bn、前四半期比21%増、前年比92%増。旧sub-market表示ではData Center Compute USD60.4bn、Networking USD14.8bnである。 | Q1 Actual。Compute / Networkingは旧sub-market表示であり、将来のHyperscale / ACIE区分へ再配賦しない。合計値を半導体業界需要へ一般化しない。 | 既存matchなし | **Proceed** — latest pre-cut-off Data Center Actual with transition boundary |
| `NVDA-SFI-005` | Q1 FY2027 earnings release, new reporting framework | Issuer definition / reporting transition; not an Actual trend | NVIDIAはmarket platformsをData CenterとEdge Computingへ移行し、Data Center内をHyperscaleとACIEに分ける方針を示した。Hyperscaleはpublic cloudsと最大規模のconsumer internet companies、ACIEはAI Clouds、Industrial、Enterpriseを含むpurpose-built data centers / AI factoriesを対象とする。 | 新旧区分のidentity、継続性又はrestatementを推定しない。Q1に併記された旧Compute / Networking値をHyperscale / ACIEへ配賦しない。 | 既存matchなし | **Proceed** — reporting-definition transition required for future comparability |
| `NVDA-SFI-006` | FY2026 Form 10-K, Part II, Item 7, Overview and revenue discussion | Issuer narrative with Actual-period explanation | FY2026 revenue growthはData Center compute / networking platforms for accelerated computing and AI solutionsが牽引し、Blackwell architecturesはData Center revenueのmajorityを占めたと発行者は説明する。Data Center computingは前年比59%増、networkingは142%増と説明される。 | `majority`の割合又は金額を推定しない。BlackwellをGPU単体又は特定製品だけの売上とみなさず、`NVDA-SFI-003`のData Center Actualと独立に二重計上しない。 | 既存matchなし | **Proceed** — issuer driver and product-architecture context |
| `NVDA-SFI-007` | FY2026 Form 10-K, Note 12, `Commitments`; Part II, Item 7, inventory and capacity purchase commitments discussion | Direct quantitative observation / Consolidated commitment with issuer narrative | 2026-01-25時点のoutstanding inventory purchase and long-term supply and capacity obligationsは連結ベースでUSD95.2bnで、substantially allがFY2027までに支払われると記載される。Note 12では、datacenter-scale productionとcurrent / future product architecturesにわたる長いordering horizonsを反映すると発行者は説明する。Item 7では、inventory and capacity purchase commitmentsは将来のcustomer demand予測に基づき、manufacturing lead timesその他のconstraintsを考慮すると説明する。 | USD95.2bn全額がData Center専用commitment、Data Center CapEx又は半導体発注額であるとのsegment配賦は開示されていない。`datacenter-scale production`は発行者説明であり、100% Data Center帰属を意味しない。CommitmentをActual購入、shipment又はrevenueへ変換せず、GPU、wafer、memory、networking又は個別supplierへ配賦しない。Note 12のobligation classとItem 7の`inventory and capacity purchase commitments`の同一性・完全対応も確定しない。 | 既存matchなし | **Proceed** — consolidated supply / capacity obligation and ordering-horizon boundary |
| `NVDA-SFI-008` | FY2026 Form 10-K, Part I, Item 1A, `Risks Related to Demand, Supply, and Manufacturing` | Issuer narrative / realized and prospective operating risk | NVIDIAは一部製品が複雑なData Center buildoutの一部であるため、一つのcomponentのsupply constraint又はavailability issueがより広いrevenue impactを持ったことがあり、完成品に必要なthird-party componentsの不足が販売を妨げ得ると記載する。 | Risk disclosure。現在のshortage対象、失注額、component数量、発生確率又は特定supplierを確定しない。 | 既存matchなし | **Proceed** — issuer-named component-to-system constraint relationship |
| `NVDA-SFI-009` | FY2026 Form 10-K, Part I / Item 7, H20 export-control and inventory discussion | Direct quantitative observation / regulatory demand shock and inventory provision | 2025年4月の米国輸出license要件後、H20需要減少に伴い、Q1 FY2026にH20 excess inventory and purchase obligationsについてUSD4.5bn chargeを計上したとNVIDIAは記載する。 | 特定規制eventに伴うH20固有の会計処理。Data Center全体又はGlobal AI需要の循環指標へ一般化せず、inventory数量、通常需要、将来回復又は他製品への代替を推定しない。 | 既存matchなし | **Proceed** — observed regulatory / inventory event with strict scope |
| `NVDA-SFI-010` | FY2026 Form 10-K, Part I, export-control discussion | Issuer narrative / market-access status and risk | NVIDIAはFY2026末時点でChinaのData Center compute marketで実質的に競争できない状態と説明し、H200 license programでは提出時点までrevenueを計上していないと記載する。 | Issuer-specific regulatory / market-access context。Chinaの総需要、市場規模、競合売上、将来許可又はlost revenue金額を推定しない。 | 既存matchなし | **Proceed with caution** — geographic demand-access boundary |
| `NVDA-SFI-011` | Q1 FY2027 earnings release, `Outlook` | Forecast / Plan with explicit exclusion assumption | Q2 FY2027の全社revenue outlookはUSD91.0bn±2%で、Data Center compute revenue from Chinaを想定していないと発行者は明記する。 | 全社ForecastでありData Center Forecastではない。China除外をData Center revenue額、需要減少額、Global demand又はActualへ変換しない。 | 既存matchなし | **Proceed with caution** — quantitative company outlook with Data Center exclusion boundary |
| `NVDA-SFI-012` | FY2026 Form 10-K, Note 16 and `Concentration of Revenue` | Direct quantitative observation / customer concentration with mixed segment scope | FY2026はdirect customer 1社が全社売上の22%、別の1社が14%を占め、いずれも主としてCompute & Networking segmentに帰属すると記載される。 | Compute & NetworkingにはData Centerに加えAutomotive等が含まれる。顧客identity、Data Center比率、end-customer share又は二社の需要因果を推定しない。 | 既存matchなし | **Hold** — concentration context is not Data Center-specific |
| `NVDA-SFI-013` | FY2026 Form 10-K, Recent Developments / demand risk discussion | Issuer narrative / capacity dependency and timing boundary | NVIDIAは顧客・partnerによるAI infrastructure buildoutにData Center、energy及びcapitalのavailabilityが重要で、energy capacity拡大は規制・技術・建設課題を伴う複雑なmulti-year processと説明する。 | Phase 1のdependency / timing context。固定Lead / Lagの開始点・終了点、期間、capacity量、半導体需要又は単独因果を設定しない。 | 既存matchなし | **Proceed with caution** — capacity and timing boundary only; no Lead / Lag analysis |

## 4. Excluded or Non-convertible Statements

| Statement family | Disposition | Reason |
| --- | --- | --- |
| NVIDIA Data Center revenueをGPU又は半導体単体売上とみなす | Excluded | 発行者定義はGPU、CPU、DPU、interconnect、networking systems、software及びservicesを含むplatformである。 |
| Compute & Networking segmentをData Centerと同義化する | Excluded | 同segmentはData CenterのほかAutomotive platforms等を含む。 |
| NVIDIA Data Center revenue成長率を半導体業界全体の需要成長率とみなす | Excluded | 単一発行者のMarket Platform revenueであり、市場規模又は他社需要を表さない。 |
| 旧Compute / Networking区分を新Hyperscale / ACIEへ配賦する | Excluded | 発行者はQ1 FY2027で新旧区分の数値mapping又はrestatementを開示していない。 |
| USD95.2bn obligationsをData Center専用commitment、Data Center CapEx、半導体発注額、wafer需要又はshipmentへ変換する | Excluded | 連結ベースのinventory purchase and long-term supply / capacity obligationsであり、Data Center又は個別構成への配賦は未開示。 |
| Consolidated inventory USD21.4bnをData Center inventoryとみなす | Excluded | 全社inventoryであり、Data Center又はproduct別配賦がない。 |
| Customer concentration 22% / 14%をData Center customer shareとみなす | Excluded | 全社売上に対するdirect customer比率で、主としてCompute & Networkingという限定にとどまる。 |
| H20 USD4.5bn chargeを通常のAI需要循環又は全製品inventory調整へ一般化する | Excluded | 特定export-control eventとH20 demand減少に結び付く個別会計事象である。 |
| Multi-year energy capacity説明から固定Lead / Lagを設定する | Excluded | 期間、開始点、終了点、地域及びcapacity量を定義していない。 |
| NVIDIAの売上又はcommitmentsからRenesas、ROHM、Infineonその他supplierの売上を推定する | Excluded | Supplier identity、purchase amount又は売上因果を開示していない。 |

## 5. Relationship Assessment

### Confirmed Issuer-named Edges

```text
Accelerated computing and AI demand / platform shifts
    ↓
NVIDIA Data Center Compute and Networking revenue growth
```

根拠：`NVDA-SFI-002`、`003`、`006`。NVIDIA固有のMarket Platform revenueに関する発行者説明であり、industry-wide demand又は半導体数量ではない。

```text
NVIDIA Data Center platform
    ↓ consists of
Compute systems + Networking infrastructure + Software / Services
```

根拠：`NVDA-SFI-001`。構成要素の発行者定義であり、売上配賦又はBOMを示さない。

```text
Forecast customer demand + manufacturing lead times / constraints
    ↓
Inventory and capacity purchase commitments
```

根拠：`NVDA-SFI-007`のItem 7にある発行者説明。このedgeのtargetはItem 7の`inventory and capacity purchase commitments`に限定する。Note 12のUSD95.2bn obligation classとの同一性・完全対応、金額への因果配賦及びData Center専用帰属は確定しない。CommitmentはActual購入又はshipmentではない。

```text
Availability issue in one component of a complex Data Center buildout
    ↓
Potentially broader NVIDIA revenue impact
```

根拠：`NVDA-SFI-008`。Risk disclosure内の発行者説明であり、特定component又は影響額を確定しない。

上記edgeを一本の数量chainへ結合しない。Revenue、commitment、inventory、component constraint及びcustomer buildoutは測定対象と分類が異なり、相互換算できない。

### Gap

調査cut-offまでに確認したNVIDIAの公式Source Setでは、Data Center revenue、manufacturing / capacity commitments又はcomponent constraintを、Renesas、ROHM、Infineonその他特定supplierの売上・受注へ直接接続する開示を確認できなかった。GPU / CPU / DPU / switch chip / memory等の数量別BOM、supplier別購入額及びData Center inventory内訳も未確認である。これは当該関係又は資料が存在しないことの証明ではない。

## 6. Preliminary Disposition

| Category | Count | Treatment |
| --- | ---: | --- |
| Proceed | 9 | 独立レビュー後、候補別Raw Evidence化を検討 |
| Proceed with caution | 3 | Geographic access、Forecast exclusion又はcapacity timing contextとしてのみRaw Evidence化を検討 |
| Hold | 1 | Data Center固有性を確認できないためRaw Evidence化しない |
| Excluded transformation | 10 | Evidence化せず、禁止変換として保持 |

## 7. Gate Status and Next Gate

| Gate | Status | Record / Next action |
| --- | --- | --- |
| Source Fact Inspection Independent Review | Accepted | `NVIDIASourceFactInspectionIndependentReview.v0.1-draft.md` |
| Candidate-level Cross-sprint recheck | Completed — Accepted | `NVIDIACrossSprintCandidateRecheckIndependentReview.v0.1-draft.md` |
| Raw Evidence | Draft completed — Independent Review Accepted | `NVIDIARawEvidenceIndependentReview.v0.1-draft.md`; 12 artifacts |
| Evidence / PIT ID | EVR / PIT registration completed — Accepted | `S3-EVR-021`–`032`; `S3-PIT-021`–`032` |
| AvailableAt / Catalog | Not permitted | `TBD — no use` / `No` |
