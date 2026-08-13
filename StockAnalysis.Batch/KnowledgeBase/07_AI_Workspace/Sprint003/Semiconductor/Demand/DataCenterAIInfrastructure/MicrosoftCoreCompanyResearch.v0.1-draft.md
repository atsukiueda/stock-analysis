# Sprint003 Microsoft Core Company Research — Data Center / AI Infrastructure

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft core company research asset |
| Sprint | Sprint003 |
| 対象企業 | Microsoft Corporation |
| Research Domain | Semiconductor — Demand — Data Center / AI Infrastructure |
| Version | 0.1-draft |
| 作成日 | 2026-08-11 |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Author | Documentation Team — Research Author persona |
| Reviewer | Evidence Validation / Chief Knowledge / Traceability reviewers — Accepted |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md` |
| Evidence範囲 | `S3-EVR-001`–`009` / `S3-PIT-001`–`009` |
| Review Record | `MicrosoftCoreCompanyResearchIndependentReview.v0.1-draft.md` |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | No |

> **利用境界：** 本文書は独立レビュー済みEvidenceを企業単位で整理するDraft Research Assetである。Canonical Knowledge、Catalog、DDL、Entity、Database、ML、バックテスト、Decision Engine、Advisor又は投資判断への利用を許可しない。

## 1. 研究目的と責務

MicrosoftがData Center、Cloud及びAI Infrastructureについて、需要、設備投資、commitment、capacity依存及び業績文脈をどの粒度で開示しているかを、Evidence IDへ追跡可能な形で整理する。

本文書は新しいSource Factを作らない。FactはEvidence Registerを参照し、Cross-source InferenceはFactと分離する。未確認関係はGapとして保持する。

対象Research Questionは`S3-DCAI-RQ-001`、`002`、`005`及び`006`である。

## 2. Evidence Baseline

| 区分 | 件数 | 状態 |
| --- | ---: | --- |
| Source Fact候補 | 10 | Inspection Accepted |
| Raw-eligible | 9 | Proceed 8 + Proceed with caution 1 |
| Hold | 1 | `MSFT-SFI-010`; Raw / EVR / PIT未作成 |
| Microsoft Raw Evidence | 9 | Package Review Accepted |
| Microsoft EVR / PIT | 9 / 9 | Independent Review Accepted |

全9件は`AvailableAt = TBD — no use`、Catalog Eligibility `No`である。Evidence ID又はPIT IDの存在を、Canonical性、利用可能性又は投資上の有効性とみなさない。

## 3. Fact — 発行者用語とInfrastructure依存

### 3.1 Data Center、Cloud及びAI Infrastructure

- Microsoftは、顧客ニーズ、特にAI services需要の増加を踏まえてData Center所在地及びserver capacityを調整すると記載する。Data Centerはpermitted and buildable land、predictable energy、networking supplies及びserversの供給に依存し、serversにはGPU及びother componentsが含まれる。根拠：`S3-EVR-001`。
- Microsoftは、Cloud offeringsの成長並びにAI Infrastructure及びtrainingへの投資を支えるため、capital expendituresへの投資を継続するPlanを記載する。Property and Equipment additionsにはnew facilities、Data Centers及びcomputer systems等が含まれるが、相互排他的な内訳ではない。根拠：`S3-EVR-005`。
- Q3 FY2026の業績説明では、AI Infrastructureへの継続投資及びAI product usage増加がgross margin percentage低下の複数要因に含まれ、R&D compute capacity、AI talent及びdataへの投資がoperating expenses増加要因に含まれる。根拠：`S3-EVR-007`。

`Data Center`、`Cloud offerings`、`AI Infrastructure`、`AI services`、`Microsoft Cloud`及び`Azure and other cloud services`を同義化しない。

### 3.2 Demand-side role

Microsoftは本Research Design上のDemand-side企業である。本役割は上流Designの調査上の分類であり、Microsoftの公式segment、Industry分類、supplier分類又は投資判断を新たに決定しない。

## 4. Fact — Investment、Commitment及びPlan

### 4.1 Property and Equipment additions — Actual

| Applicable Period | Source-presented amount | Evidence | Boundary |
| --- | ---: | --- | --- |
| FY2023 | USD28,107m | `S3-EVR-002` | Consolidated P&E additions |
| FY2024 | USD44,477m | `S3-EVR-002` | Consolidated P&E additions |
| FY2025 | USD64,551m | `S3-EVR-002` | Consolidated P&E additions |
| Q3 FY2025 comparison / 3 months | USD16,745m | `S3-EVR-006` | Unaudited comparative period |
| Q3 FY2026 / 3 months | USD30,876m | `S3-EVR-006` | Unaudited Actual-period result |
| 9 months FY2025 comparison | USD47,472m | `S3-EVR-006` | Unaudited comparative period |
| 9 months FY2026 | USD80,146m | `S3-EVR-006` | Unaudited Actual-period result |

原典cash-flow statementはcash outflowを括弧付き負数で表示する。表はadditions amountの絶対額であり、Data Center、Cloud、AI、server、GPU又は半導体への配賦値ではない。増減率を半導体需要率に変換しない。

### 4.2 Construction and purchase commitments

- 2025-06-30時点の新規建物、建物改良及びleasehold improvementsに関するconstruction commitmentsはUSD32.1bnで、Microsoftは主としてData Center関連と記載する。支出済みCapex、稼働capacity又はserver / GPU / 半導体購入額ではない。根拠：`S3-EVR-003`。
- 同日時点のpurchase commitmentsはFY2026 USD103,940m、Thereafter USD6,013m、Total USD109,953mである。主としてData Center関連で、construction commitmentsに含まれないopen purchase orders及びtake-or-pay contractsを含む。Actual purchase、支出又は半導体orderではない。根拠：`S3-EVR-004`。

Construction commitmentsとpurchase commitmentsは定義が異なるため、無条件に合算しない。`primarily`を100% Data Centerと解釈しない。

### 4.3 Capital investment relationship — issuer narrative

2024-12-10の説明で、Microsoft CFOはCloud / AI services需要との整合のためcapital expenditureを増加させたと述べ、AI platformをglobalに構築して顧客及びpartner需要へ対応するにはinfrastructureへのmeaningful capital investmentが必要と説明する。過去説明と将来必要性を一つのActualへ統合せず、金額、Data Center比率又は半導体購入額を推定しない。根拠：`S3-EVR-009`。

## 5. Fact — Cloud Demand and Performance Context

- Q3 FY2026のMicrosoft Cloud revenueはUSD54.5bn、前年比29%増、Azure and other cloud services revenueは前年比40%増である。Microsoft CFOはMicrosoft Cloudへの需要増を反映した結果と説明する。根拠：`S3-EVR-008`。
- `S3-EVR-008`はCloud revenue / growthのActual-period contextであり、Data Center investment、AI demand、server shipment又は半導体需要の直接Observationではない。
- `S3-EVR-007`のmargin及びoperating-expense説明は複数要因を含むため、AI Infrastructure投資額、GPU数量、server台数又は半導体需要量を逆算しない。

## 6. Issuer-named Relationships

確認できる関係は、Microsoft自身の開示内で次のように限定される。

```text
AI services / customer needs
  → Data Center location and server-capacity adjustment
  → land / energy / networking supplies / servers dependency

Cloud / AI services demand
  → global infrastructure investment requirement
```

ServersにGPUが含まれることは確認できるが、GPU以外の`other components`、数量、supplier、購入額又はrevenueを特定しない。MicrosoftのCapexからNVIDIA、Renesas、ROHM、Infineon又はその他supplierの売上・受注を推定しない。

## 7. Cross-source Inference — Research Only

### MSFT-INF-001 — Infrastructure is a composite dependency system

`S3-EVR-001`,`003`–`005`,`009`を併せると、MicrosoftのData Center / AI Infrastructure拡張は、land、energy、networking、servers、building-related commitment、purchase commitment及びcapital Planを含む複合的なinfrastructure managementとして開示されていると整理できる。

**制約：** 構成要素を一つの金額又は共通需要量へ統合せず、commitmentからActual、capacity、semiconductor demand又はsupplier revenueへの変換を行わない。

### MSFT-INF-002 — Investment observations are trackable but not allocable

`S3-EVR-002`,`006`によりconsolidated Property and Equipment additionsの時系列更新は追跡可能である。一方、`S3-EVR-003`–`005`,`009`のData Center / Cloud / AI文脈を用いて全社値を用途配賦することはできない。

**制約：** 本Inferenceはinvestment trend、semiconductor demand trend、Capex efficiency、supplier benefit又は投資signalを決定しない。

これらはCompany Research上のInferenceであり、EVR、PIT、Catalog Fact又はObservationとして登録しない。

## 8. Research Question Disposition

| Research Question | Microsoftでの回答 | Disposition |
| --- | --- | --- |
| `S3-DCAI-RQ-001` | Data Center、Cloud、AI Infrastructure、AI services、Microsoft Cloud及びAzureは文脈・測定対象が異なる。 | Evidence supported; terms remain issuer-specific |
| `S3-DCAI-RQ-002` | Consolidated P&E additions、construction commitments、purchase commitments、capital Plan及びperformance narrativeを別Factとして追跡できる。 | Evidence supported; no semiconductor allocation |
| `S3-DCAI-RQ-005` | AI / Cloud需要とinfrastructure investment / dependencyのissuer-named relationはあるが、需要側投資から特定半導体product、order、shipment又はsupplier revenueへの単一Source Factは確認できない。 | Partial support + bounded Negative Evidence |
| `S3-DCAI-RQ-006` | Actual、Commitment、Plan、Actual-period narrative及び需要contextを分離する必要がある。 | Evidence supported; classification control required |

## 9. Benchmark Follow-up Topics — 未採用

| Topic | Evidence basis | 必要な追加確認 | 現在の境界 |
| --- | --- | --- | --- |
| Consolidated P&E additions update | `S3-EVR-002`,`006` | 同一定義、period、restatement及びsign convention | Data Center / AI / semiconductor Observationではない |
| Construction commitment | `S3-EVR-003` | definition、remaining balance、completion及びscope update | Actual spend / capacityではない |
| Purchase commitment | `S3-EVR-004` | item mix、counterparty、take-or-pay及びsettlement | Semiconductor orderではない |
| Cloud demand context | `S3-EVR-008` | Microsoft Cloud / Azure definition continuity | Semiconductor-demand proxyではない |

これらは比較・更新検討用の未採用Topicであり、Feature、Lead / Lag Indicator、Catalog候補、投資signal又は`AvailableAt`決定ではない。

## 10. Gaps and Negative Evidence

1. Consolidated P&E additionsのData Center、Cloud、AI、server又はsemiconductorへの配賦比率は未確認。
2. Construction / purchase commitmentsの品目、supplier、server / GPU / semiconductor比率及び実行時期は未確認。
3. `Cloud`、`AI Infrastructure`、`Data Center`及び`AI services`の相互包含を一意にするissuer definition bridgeは未確認。
4. Microsoft Cloud / Azure growthとData Center投資、capacity、server shipment又はsemiconductor demandを接続する測定関係は未確認。
5. Data Center / AI Infrastructure投資と、特定Power Semiconductor、Power Management IC、MCU又は日本株対象企業の売上・受注を直接結ぶ開示は、2026-07-30までに確認した記録済み公式Source Setでは確認できなかった。これは関係又は資料が存在しないことの証明ではない。
6. `MSFT-SFI-010`の400超Data Center、70 regions及び2GW超new capacityは、期間・measurement boundary未解決のためHoldであり、本ResearchのFact baselineへ含めない。

## 11. Update Triggers

- Annual Report又は四半期資料におけるP&E additions、construction commitment及びpurchase commitment更新。
- Data Center / AI Infrastructure向け投資額、capacity、server、accelerator又はsupplier内訳の新規開示。
- Cloud、AI Infrastructure、Data Center及びMicrosoft Cloudのdefinition / reporting change。
- `MSFT-SFI-010`のapplicable period、測定範囲又はsource versionの解消。
- Named supplier、product、order、shipment、capacity又はrevenue relationの公式開示。

Update Triggerは自動採用を意味しない。新しいSource Eventは再Inspection、Raw Review、EVR Review及びPIT Reviewを経る。

## 12. Downstream Boundary and Next Handoff

本文書から次へ接続できるのは、Reviewed Draft Baseline及びPhase 1 Closureの再照合だけである。

- 新しいEvidence ID又はPIT IDを発行しない。
- `MSFT-INF-001`–`002`をEvidence又はCatalog Factへ登録しない。
- Benchmark Follow-up TopicをObservation、Feature又はLead / Lag Indicatorとして採用しない。
- `AvailableAt`を決定しない。
- Catalog、DDL、Entity、Database、ML、Backtest、Decision Engine、Advisor及び投資判断に利用しない。
- Phase 2を開始しない。
