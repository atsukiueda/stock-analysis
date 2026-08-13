# Sprint003 Alphabet Core Company Research — Data Center / AI Infrastructure

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft core company research asset |
| Sprint | Sprint003 |
| 対象企業 | Alphabet Inc. |
| Research Domain | Semiconductor — Demand — Data Center / AI Infrastructure |
| Version | 0.1-draft |
| 作成日 | 2026-08-11 |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Author | Documentation Team — Research Author persona |
| Reviewer | Evidence Validation / Chief Knowledge / Traceability reviewers — Accepted |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md` |
| Evidence範囲 | `S3-EVR-010`–`020` / `S3-PIT-010`–`020` |
| Review Record | `AlphabetCoreCompanyResearchIndependentReview.v0.1-draft.md` |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | No |

> **利用境界：** 本文書は独立レビュー済みEvidenceを企業単位で整理するDraft Research Assetである。Canonical Knowledge、Catalog、DDL、Entity、Database、ML、バックテスト、Decision Engine、Advisor又は投資判断への利用を許可しない。

## 1. 研究目的と責務

AlphabetがData Center、technical infrastructure、AI-optimized infrastructure、Cloud需要及びAI acceleratorについて、投資、資産、commitment、capacity、供給risk及び需要文脈をどの粒度で開示しているかを、Evidence IDへ追跡可能な形で整理する。

本文書は新しいSource Factを作らない。FactはEvidence Registerを参照し、Cross-source InferenceはFactと分離する。未確認関係はGapとして保持する。

対象Research Questionは`S3-DCAI-RQ-001`、`002`、`005`及び`006`である。

## 2. Evidence Baseline

| 区分 | 件数 | 状態 |
| --- | ---: | --- |
| Source Fact候補 | 11 | Inspection Accepted |
| Raw-eligible | 11 | Proceed 9 + Proceed with caution 2 |
| Hold | 0 | なし |
| Alphabet Raw Evidence | 11 | Package Review Accepted |
| Alphabet EVR / PIT | 11 / 11 | Independent Review Accepted |

全11件は`AvailableAt = TBD — no use`、Catalog Eligibility `No`である。Evidence ID又はPIT IDの存在を、Canonical性、利用可能性又は投資上の有効性とみなさない。

## 3. Fact — 発行者用語、Architecture及びSupply Risk

### 3.1 AI-optimized and technical infrastructure

- AlphabetはGoogle Cloud顧客へspecialized GPUs及び自社custom-built TPUsを含むAI accelerator optionsを提供すると記載する。これはoperating architectureの説明であり、数量、購入額、稼働量、market share、外部調達比率又はsupplier別売上を示さない。根拠：`S3-EVR-010`。
- Technical infrastructureはservers and network equipment、Data Center land、building construction and improvementsへの投資から構成される。一般的なData Center construction projectは複数年・複数phaseで、land / buildings取得、建設、servers / network equipmentの確保・設置を含む。根拠：`S3-EVR-012`。
- `AI-optimized infrastructure`、`technical infrastructure`、`Data Center`、`servers and network equipment`、`GPU`及び`TPU`を同義化しない。

### 3.2 Specialized AI chip supply risk

Technical infrastructure向けservers / network equipment、特にspecialized AI chipsの製造・供給は少数のqualified suppliersに限られ、長期又は予期しないdisruptionはcustomer demandへの対応能力へ影響し得るとAlphabetは記載する。これはrisk disclosureであり、Actual shortage、supplier identity、purchase share、発生確率又は売上影響額ではない。根拠：`S3-EVR-015`。

### 3.3 Demand-side role

Alphabetは本Research Design上のDemand-side企業である。本役割は調査上の分類であり、Alphabetの公式segment、Industry分類、supplier分類又は投資判断を新たに決定しない。

## 4. Fact — CapEx、Asset及びCommitment

### 4.1 Capital expenditures Actual

- Alphabet全社Capital expendituresはFY2024 USD52.5bn、FY2025 USD91.4bnである。FY2025 CapExは主としてtechnical infrastructureへの投資を反映すると発行者は説明する。全額をData Center、servers、AI又は半導体へ配賦しない。根拠：`S3-EVR-011`。
- FY2025 Q4説明では、FY2025 CapEx USD91.4bnのvast majorityをtechnical infrastructureへ投資し、その金額未開示部分の約60%がservers、40%がData Centers and networking equipmentとCFOは説明する。60 / 40を総CapEx USD91.4bnへ直接乗じず、component金額又はGPU / TPU・半導体購入額を導出しない。根拠：`S3-EVR-017`。
- `S3-EVR-011`と`017`のUSD91.4bnは同じFY2025 Actualであり、二重計上しない。

### 4.2 Technical infrastructure gross in-service assets

Property and equipment in serviceを構成するtechnical infrastructure gross balanceは、2024-12-31時点USD141,852m、2025-12-31時点USD203,679mである。両時点で約60%はservers and network equipment、残余はData Center land and buildings and related assetsと注記される。根拠：`S3-EVR-013`。

これはperiod-end gross in-service asset balanceであり、net carrying amount、当年度CapEx composition又はassets not yet in serviceを含む値ではない。`S3-EVR-017`のCapEx 60 / 40と同一指標として扱わず、GPU / TPUへ配賦しない。

### 4.3 Purchase commitments and obligations

2025-12-31時点のpurchase commitments and other contractual obligationsはTotal USD149.1bn、short-term USD113.0bnである。全体は主としてenergy take-or-pay contracts、licenses、technical infrastructure and inventory ordersに関連し、short-termの大部分はtechnical infrastructure and inventory orders関連と説明される。根拠：`S3-EVR-014`。

`primarily`及び`mostly`を100%と解釈せず、支出済みCapEx、受領済み設備・inventory、server order又は半導体購入額へ変換しない。

## 5. Fact — FY2026 Investment Plan and Forecast

- Alphabetは、users / enterprise customersの需要及び内部researchを支えるため、FY2026にFY2025比でservers / network equipment及びData Centersを含むtechnical infrastructure投資を大幅に増加させる見込みと記載する。これは定性的Planであり、金額、実行時期又はcapacity量を確定しない。根拠：`S3-EVR-016`。
- FY2026 CapEx ForecastはUSD175bn–185bnである。AI compute capacity投資がGoogle DeepMind、Google Services、Cloud customer demand及びその他の投資対象を支えると説明する。Actual又は確定予算ではなく、全額をData Center、Cloud、servers、GPU / TPU又は半導体へ配賦しない。根拠：`S3-EVR-018`。

`S3-EVR-011`のFY2025 Actual、`016`の定性的Plan及び`018`の定量Forecastを一つのActual seriesへ統合しない。

## 6. Fact — Commercial Demand and Capacity Context

### 6.1 Google Cloud backlog

Q4 FY2025末のGoogle Cloud backlogはUSD240bn、前四半期比55%増加、前年比で2倍超である。複数顧客のenterprise AI offerings需要が増加要因と説明される。根拠：`S3-EVR-019`。

Backlogはrevenue、CapEx、capacity、semiconductor order又は半導体需要ではない。`more than doubled`から前年値を逆算しない。

### 6.2 Capacity constraint and timing

Alphabetはcapacityを増強中でもsupply-constrainedであり、当年CapExは将来を見据え、投資がcapacityとして利用可能になるまで時間差があると説明する。Cloud、社内需要その他の需要が強いとの文脈を示す。根拠：`S3-EVR-020`。

これはcapacity constraintとtiming boundaryのnarrativeであり、specialized AI chipsだけの制約、固定Lead / Lag、数量、開始点・終了点又は解消時期を定義しない。

## 7. Issuer-named Relationships

確認できる関係はAlphabet自身の開示内で次のように限定される。

```text
Users / enterprise and Cloud customer demand
  → AI-oriented technical infrastructure investment
  → future compute capacity

Technical infrastructure
  → servers / network equipment / land / buildings
  → specialized AI chip supply risk as one dependency
```

これらの関係を用いて、CapEx、assets、commitments又はbacklogからGPU / TPU数量、半導体order、特定supplier売上又は固定Lead / Lagを導出しない。

## 8. Cross-source Inference — Research Only

### ALPH-INF-001 — Technical infrastructure is a multi-stage asset process

`S3-EVR-011`–`014`,`017`,`020`を併せると、Alphabetのtechnical infrastructureは、multi-year construction、period-end in-service assets、current-period CapEx、contractual obligations及びcapacity availability timingを別の測定対象として管理する複合的なasset processと整理できる。

**制約：** CapEx、asset balance、commitment及びcapacityを一つのseriesへ統合せず、固定Lead / Lag、semiconductor demand又はsupplier revenueを推論しない。

### ALPH-INF-002 — Demand, investment and constraint are directionally connected but not quantitatively bridged

`S3-EVR-016`,`018`–`020`は、customer / internal demand、technical infrastructure investment、Cloud backlog及びcapacity constraintが同じ発行者の経営文脈に現れることを示す。

**制約：** Backlog又はdemandからCapEx、capacity、accelerator quantity、semiconductor order若しくはrevenueへの換算式・因果量を作らず、Forecast実現又はsupplier benefitを主張しない。

これらはCompany Research上のInferenceであり、EVR、PIT、Catalog Fact又はObservationとして登録しない。

## 9. Research Question Disposition

| Research Question | Alphabetでの回答 | Disposition |
| --- | --- | --- |
| `S3-DCAI-RQ-001` | AI-optimized infrastructure、technical infrastructure、Data Center、servers / network equipment、GPU及びTPUは異なるscopeを持つ。 | Evidence supported; issuer terms remain separate |
| `S3-DCAI-RQ-002` | CapEx Actual、gross in-service assets、mixed obligations、investment Plan / Forecast、backlog及びcapacity timingを別Factとして追跡できる。 | Evidence supported; no semiconductor allocation |
| `S3-DCAI-RQ-005` | Demandとtechnical infrastructure investmentのissuer-named relation、accelerator options及びspecialized-chip riskはあるが、投資から特定product、order、shipment又はsupplier revenueへ直接接続する単一Source Factは確認できない。 | Partial support + bounded Negative Evidence |
| `S3-DCAI-RQ-006` | Actual、Asset balance、Commitment、Plan、Forecast、commercial-demand context及びcapacity narrativeを分離する必要がある。 | Evidence supported; classification control required |

## 10. Benchmark Follow-up Topics — 未採用

| Topic | Evidence basis | 必要な追加確認 | 現在の境界 |
| --- | --- | --- | --- |
| Capital expenditures | `S3-EVR-011`,`017`,`018` | Actual / Forecast、denominator、composition及びrestatement | Semiconductor-demand Observationではない |
| Technical infrastructure assets | `S3-EVR-013` | gross / net、in-service / under-construction及びdefinition continuity | CapEx又はcapacityと同義ではない |
| Purchase commitments | `S3-EVR-014` | mixed scope、item / supplier、settlement及びdelivery | Semiconductor orderではない |
| Cloud backlog | `S3-EVR-019` | backlog definition、conversion、period及びcustomer scope | Revenue / capacity / semiconductor proxyではない |
| Capacity timing | `S3-EVR-020` | asset class、start / end event、measured duration及びrepeatability | Lead / Lag Indicatorではない |

これらは比較・更新検討用の未採用Topicであり、Feature、Lead / Lag Indicator、Catalog候補、投資signal又は`AvailableAt`決定ではない。

## 11. Gaps and Negative Evidence

1. 全社CapEx、gross asset及びcommitmentのData Center、AI、server、network、GPU / TPU又は半導体への配賦比率は未確認。
2. FY2025 technical-infrastructure investment部分の金額、server 60% / Data Center and networking 40%の絶対額及び内部構成は未確認。
3. Specialized AI chip supplierのidentity、supplier数、purchase share、Actual shortage及び影響額は未確認。
4. Google Cloud backlogとrevenue、CapEx、capacity、server shipment又はsemiconductor demandの定量bridgeは未確認。
5. Capacity investmentからavailabilityまでの開始点、終了点、対象asset及びdurationは未確認。
6. 2026-07-30までに確認した記録済み公式Source Setでは、Alphabet投資とNVIDIA、Renesas、ROHM、Infineon又はその他特定supplierのproduct、order、shipment若しくはrevenueを直接結ぶ開示を確認できなかった。これは関係又は資料が存在しないことの証明ではない。

## 12. Update Triggers

- CapEx Actual / Forecast、technical-infrastructure composition及びgross asset balanceの更新。
- Data Center、servers、network equipment、GPU / TPU又は半導体別の投資・asset・commitment内訳開示。
- Google Cloud backlogのdefinition、conversion又はcapacity relation更新。
- Supply constraint、specialized AI chip supplier及びcapacity availability timingの定量開示。
- Named supplier、product、order、shipment、capacity又はrevenue relationの公式開示。

Update Triggerは自動採用を意味しない。新しいSource Eventは再Inspection、Raw Review、EVR Review及びPIT Reviewを経る。

## 13. Downstream Boundary and Next Handoff

本文書から次へ接続できるのは、Reviewed Draft Baseline及びPhase 1 Closureの再照合だけである。

- 新しいEvidence ID又はPIT IDを発行しない。
- `ALPH-INF-001`–`002`をEvidence又はCatalog Factへ登録しない。
- Benchmark Follow-up TopicをObservation、Feature又はLead / Lag Indicatorとして採用しない。
- `AvailableAt`を決定しない。
- Catalog、DDL、Entity、Database、ML、Backtest、Decision Engine、Advisor及び投資判断に利用しない。
- Phase 2を開始しない。
