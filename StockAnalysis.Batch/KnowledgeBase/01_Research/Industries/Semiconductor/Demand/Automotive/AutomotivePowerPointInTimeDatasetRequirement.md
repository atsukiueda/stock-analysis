# Automotive Power Point-in-time Dataset Requirement

**Research Domain**: Semiconductor Industry
**Research Package**: Automotive Demand
**Research Category**: Dataset Governance / Point-in-time Validation
**Knowledge Scope**: Automotive / Power Semiconductor
**Version**: 0.1
**Status**: Candidate Dataset Requirement
**Reviewer Status**: Pending Validation
**Last Updated**: 2026-07-11

---

# 1. Purpose（目的）

本Requirement（要件）は、Automotive Power Semiconductor Knowledge
（車載パワー半導体Knowledge）のValidation、Machine Learning、
Backtest、Walk Forwardに使用するDatasetについて、

**Prediction Date（予測時点）で実際に利用可能だった情報だけを使用する**

ためのPoint-in-time Dataset
（時点整合Dataset）要件を定義する。

本プロジェクトでは、

```text
現在取得できる最新情報
```

と

```text
過去のPrediction Date時点で利用可能だった情報
```

を明確に区別する。

最新値を過去へ遡及適用してはならない。

---

# 2. Core Principle（中核原則）

## Point-in-time Principle（時点整合原則）

すべてのObservation、Knowledge、Featureについて、

```text
Prediction Date
```

以前に利用可能だったことを証明できなければ、
BacktestまたはWalk Forwardへ使用してはならない。

基本条件は以下とする。

```text
EffectiveAsOfDate <= PredictionDate
```

Prediction Dateより後に利用可能となった情報はFuture Information
（未来情報）として扱う。

---

# 3. Time Concepts（時点概念）

Point-in-time Datasetでは、
一つの日付だけを持たない。

最低限、以下を区別する。

| Field             | 日本語    | Definition         |
| ----------------- | ------ | ------------------ |
| ObservationDate   | 観測日    | 実際の事象または数値の基準日     |
| PeriodStart       | 対象期間開始 | 数値が対象とする期間の開始      |
| PeriodEnd         | 対象期間終了 | 数値が対象とする期間の終了      |
| PublishedAt       | 公開日時   | 情報源が公式に公開した日時      |
| AcquiredAt        | 取得日時   | システムが資料・データを取得した日時 |
| ExtractedAt       | 抽出日時   | 数値・記述を資料から抽出した日時   |
| ReviewedAt        | レビュー日時 | Reviewerが確認した日時    |
| ApprovedAt        | 承認日時   | Knowledge利用を承認した日時 |
| EffectiveAsOfDate | 利用可能時点 | Dataset上で利用可能とする時点 |
| SupersededAt      | 失効日時   | 後続Versionに置換された日時  |

これらを一つの`Date`へ統合してはならない。

---

# 4. Effective As Of Rule（利用可能時点規則）

Observation Typeごとに、
EffectiveAsOfDateのCandidate Ruleを定義する。

---

## 4.1 Structured Financial Data（構造化財務データ）

対象例：

* Revenue
* Inventory
* CapEx
* Operating Income
* Financial Statement Values

Candidate Rule：

```text
EffectiveAsOfDate
=
Official Disclosure DateTime
+
Operational Availability Buffer
```

初期Validationでは、安全側の設計として、

```text
Next Trading Day
```

から利用可能とする候補を優先する。

### Example

```text
Period End:
2025-12-31

Official Disclosure:
2026-02-05 15:30

Initial Effective As Of:
2026-02-06
```

2026-02-05以前のPredictionへ使用してはならない。

同日利用については、
将来のBatch Execution TimeおよびAPI Availability確認後に再評価する。

---

## 4.2 Official Statistics（公式統計）

対象例：

* EV Registrations
* Vehicle Production
* EV Penetration
* Regional Vehicle Sales

Candidate Rule：

```text
EffectiveAsOfDate
=
Official Publication Date
```

ただし、Publication Timeが不明な場合は、

```text
Next Calendar Day
```

または

```text
Next Trading Day
```

を安全側Candidateとする。

最終ルールはSourceごとに定義する。

---

## 4.3 IR Documents（IR資料）

対象例：

* Earnings Presentation
* Annual Report
* Integrated Report
* Capital Market Day Material
* Official News Release

以下を記録する。

```text
PublishedAt
AcquiredAt
ExtractedAt
ReviewedAt
ApprovedAt
```

初期Knowledge Validationでは、

```text
EffectiveAsOfDate
=
ApprovedAt
```

とする。

### Reason

AIまたは人間が資料を取得しただけでは、
Knowledgeとして利用可能とはみなさない。

Evidence Classification、Transformation Rule、Reviewer確認が必要だからである。

---

## 4.4 Qualitative Observation（定性Observation）

対象例：

* Guidance Direction
* Customer Inventory Commentary
* Demand Commentary
* Regional Demand Commentary
* SiC Demand Commentary

Candidate Lifecycle：

```text
Official Publication
↓
Document Acquisition
↓
Extraction
↓
Fact / Inference / Hypothesis Classification
↓
Reviewer Check
↓
Approval
↓
Effective As Of
```

Reviewer承認前の定性情報は、

```text
Research Data
```

として保持できる。

ただし、

```text
Approved Knowledge Feature
```

としてML、Backtest、Decision Engineへ使用してはならない。

---

## 4.5 Event Observation（イベントObservation）

対象例：

* Design Win
* Customer Nomination
* Mass Production Start
* Fab Expansion
* Capacity Start-up
* Official Guidance Revision

公式発表日をPublishedAtとする。

ただしKnowledge Stateへの変換にはReviewer承認を要求する。

例：

```text
Mass Production Announcement
PublishedAt:
2025-09-04

ReviewedAt:
2025-09-05

ApprovedAt:
2025-09-05

EffectiveAsOfDate:
2025-09-05
```

---

# 5. Raw Observation and Knowledge Separation

（原観測とKnowledgeの分離）

Raw Observation（原観測）とApproved Knowledge
（承認済みKnowledge）を同一時点として扱わない。

例：

```text
Company Guidance Published
2026-02-05
```

Raw Observationとしては2026-02-05に存在する。

しかし、

```text
Automotive Demand Improving
```

というKnowledgeへ変換されたのが2026-02-07の場合、

Knowledge EffectiveAsOfDateは2026-02-07とする。

```text
Raw Observation Effective Date
≠
Knowledge Effective Date
```

---

# 6. Dataset Layer（Datasetレイヤー）

Point-in-time Datasetは最低限、
以下のLayerへ分離する。

```text
Layer 0
Raw Source

Layer 1
Raw Observation

Layer 2
Normalized Observation

Layer 3
Reviewed Observation

Layer 4
Approved Knowledge

Layer 5
Model Feature Snapshot
```

---

## Layer 0：Raw Source（原資料）

保存対象：

* API Response
* PDF
* CSV
* Official Statistics File
* News Release HTML Metadata

原資料を上書きしない。

---

## Layer 1：Raw Observation（原観測）

原資料から取得した値・記述。

例：

```text
Original Label:
Inventories

Original Value:
2,016

Original Unit:
EUR million
```

解釈を加えない。

---

## Layer 2：Normalized Observation（正規化Observation）

DisclosureNormalizationRuleに従い正規化する。

例：

```text
Normalized Concept:
Inventory

Normalized Unit:
EUR million

Inventory Growth:
-0.98%
```

原値を保持する。

---

## Layer 3：Reviewed Observation（レビュー済みObservation）

以下を確認済み。

* Source
* Definition
* Period
* Publication Date
* Disclosure Status
* Normalization
* Fact Classification

---

## Layer 4：Approved Knowledge（承認済みKnowledge）

Transformation RuleおよびValidation Statusを持つ。

例：

```text
Inventory Adjustment State:
Normalization Candidate
```

ApprovedAt以降に利用可能。

---

## Layer 5：Model Feature Snapshot（モデル特徴量Snapshot）

Prediction Dateごとに、
その時点で利用可能なFeatureを固定する。

例：

```text
Code:
6963

PredictionDate:
2026-05-15

AutomotivePowerInventoryScore:
72

AutomotivePowerInventoryConfidence:
High

FeatureEffectiveAsOf:
2026-05-08
```

後日Knowledgeが更新されても、
過去Snapshotを上書きしない。

---

# 7. Feature Snapshot Principle（特徴量Snapshot原則）

ML Training Dataを毎回最新Knowledgeから再計算し、

```text
過去時点のFeature
```

を現在のKnowledgeで上書きしてはならない。

例：

2026年にAutomotive Knowledge Rule Version 2.0を作成した場合、

2024年当時存在しなかったRuleを使って
2024年Prediction Featureを生成すると、

Historical Simulation
（過去シミュレーション）

であり、

True Point-in-time Backtest
（真の時点整合Backtest）

ではない。

---

# 8. Historical Simulation and True Point-in-time Validation

（履歴シミュレーションと真の時点整合検証）

以下を区別する。

## Historical Simulation

現在のRuleを過去データへ適用する。

Purpose：

* Rule Research
* Hypothesis Validation
* Feature Exploration

利用可能。

ただし、

```text
Point-in-time Validated
```

と表現してはならない。

---

## True Point-in-time Validation

当時利用可能だった、

* Observation
* Evidence
* Rule Version
* Knowledge Version

のみを利用する。

Purpose：

* Production Validation
* Final Walk Forward
* Advisor Reliability Assessment

---

## Important Rule

Historical Simulationで良好な結果が出ても、
Production Knowledgeへ直接昇格させない。

True Point-in-time Validationまたは、
それに準ずる厳格なValidationを必要とする。

---

# 9. Knowledge Version Rule（Knowledge Version規則）

Knowledge更新時には、
過去Versionを上書きしない。

例：

```text
AutomotivePowerInventoryKnowledge

Version 1.0
EffectiveFrom:
2025-01-01

EffectiveTo:
2026-03-31
```

```text
Version 2.0
EffectiveFrom:
2026-04-01
```

Prediction Dateが2025-10-01の場合、

```text
Version 1.0
```

を使用する。

---

# 10. Transformation Rule Version（変換ルールVersion）

Transformation RuleもVersion管理する。

例：

```text
TR-AUTO-INV-001

Version 1.0

Inventory / Revenue
+
Revenue Trend
```

将来、

```text
Customer Inventory Commentary
```

を追加した場合、

```text
Version 2.0
```

とする。

Version 2.0を過去Backtestへ使用する場合、

```text
Historical Simulation
```

として明示する。

---

# 11. Revision and Restatement Rule（改定・再表示規則）

財務データまたは統計値が後日改定された場合、
最新値で過去Datasetを上書きしない。

最低限、以下を管理する。

| Field         | Description |
| ------------- | ----------- |
| ValueVersion  | 値Version    |
| PublishedAt   | 公開日時        |
| SupersededAt  | 後続値公開日時     |
| IsRestatement | 再表示か        |
| OriginalValue | 当初値         |
| RevisedValue  | 改定値         |

Prediction Date時点で利用可能だったVersionを使用する。

---

# 12. Latest Value Query Rule（最新値取得規則）

Prediction Date時点で利用可能な最新Observationは、

Concept上、以下の条件で取得する。

```text
EffectiveAsOfDate <= PredictionDate
```

かつ

```text
SupersededAt IS NULL
OR
SupersededAt > PredictionDate
```

その中から、

```text
EffectiveAsOfDate DESC
```

の最新値を取得する。

正式SQLはDDL Phaseで設計する。

---

# 13. Null and Missing State Rule（NULL・欠損状態規則）

NULLのみで状態を管理してはならない。

以下を区別する。

```text
Reported
Derived
Estimated Proxy
Not Disclosed
Not Applicable
Not Yet Reviewed
Definition Changed
Discontinued
Conflicting Evidence
Missing Historical Source
```

ML Dataset生成時には、

```text
Raw Missing State
```

を保持した上で、

Feature-specific Missing Handling
（特徴量固有の欠損処理）を実施する。

---

# 14. Imputation Point-in-time Rule（欠損補完時点規則）

欠損補完はTraining Window内のデータのみで実施する。

禁止例：

```text
2018-2026 全期間平均
↓
2020 Feature補完
```

これは2021年以降の情報を利用する可能性がある。

許可候補：

```text
Training Period Median
```

```text
Past-only Rolling Median
```

```text
Missing Flag
```

```text
Feature Exclusion
```

補完方法自体もModel Versionへ記録する。

---

# 15. Scaling and Normalization Rule（標準化・正規化規則）

Feature Scaling、Standardization、Winsorization等は、

Training WindowのみでParameterを計算する。

禁止：

```text
Full Dataset Mean
Full Dataset Standard Deviation
Full Dataset Quantile
```

Walk Forward Windowごとに再計算する。

---

# 16. Company Universe Point-in-time Rule

（企業Universe時点規則）

現在のCompany Universeを過去全期間へ適用しない。

以下の問題を考慮する。

* 新規上場
* 上場廃止
* 合併
* Company Code変更
* Business Model変更
* SubSector変更
* Automotive Exposure変更

Prediction Date時点のUniverseを使用する。

将来Company Classification Versionを保持する。

---

# 17. Exposure Point-in-time Rule（Exposure時点規則）

Company Exposureも固定値として過去へ適用しない。

例：

```text
ROHM Automotive Exposure
```

が2026年時点で高くても、

2018年に同じExposureだったとは限らない。

以下をVersion管理候補とする。

* Automotive Revenue Mix
* Power Exposure
* SiC Exposure
* Regional Exposure
* Customer Exposure
* SubSector Classification

Exposure EffectiveAsOfDateを持たせる。

---

# 18. Event Duplication Rule（イベント重複規則）

同一Eventが複数資料で発表される場合、
重複Eventとして複数加点しない。

例：

```text
Design Win
↓
News Release

同一Design Win
↓
Quarterly Presentation

同一Design Win
↓
Integrated Report
```

Event Identityを管理し、

```text
One Economic Event
=
One Primary Event
```

とする。

後続資料はEvidence追加として紐付ける。

---

# 19. Document Revision Rule（資料更新規則）

同一URLまたは同一Document Titleでも、
企業がPDFを差し替える可能性を考慮する。

Raw Source候補では以下を保持する。

* Source URL
* AcquiredAt
* File Hash
* Document Title
* Published Date
* Document Version where available

File Hashが変化した場合、
Document Revision Candidateとして検出する。

正式実装はDocument Acquisition Phaseで設計する。

---

# 20. Dataset Generation Rule（Dataset生成規則）

Dataset生成時は、

```text
Prediction Date
↓
Eligible Observations取得
↓
Eligible Knowledge Version取得
↓
Exposure Version取得
↓
Transformation Rule Version取得
↓
Feature Calculation
↓
Feature Snapshot保存
```

の順序を守る。

Dataset Generatorが現在最新のKnowledgeを直接参照し、
過去全期間を一括生成してはならない。

---

# 21. Reproducibility Requirement（再現性要件）

任意のPrediction Recordについて、
以下を再現可能にする。

```text
Why was this feature value 72?
```

最低限、以下へ遡れること。

```text
Feature Snapshot
↓
Knowledge Version
↓
Transformation Rule Version
↓
Reviewed Observations
↓
Normalized Observations
↓
Raw Observations
↓
Source Documents
```

値だけ保存し、
由来を追跡できないFeatureはProduction Knowledge Featureとして認めない。

---

# 22. Dataset Audit Fields（Dataset監査項目）

将来Dataset Recordには、
最低限以下のMetadata候補を持つ。

| Field                 | Purpose             |
| --------------------- | ------------------- |
| PredictionDate        | 予測日                 |
| DatasetVersion        | Dataset Version     |
| FeatureSetVersion     | Feature Set Version |
| KnowledgeVersionSet   | Knowledge Version集合 |
| TransformationRuleSet | Rule Version集合      |
| GeneratedAt           | Dataset生成日時         |
| GeneratorVersion      | Generator Version   |
| SourceCutoffDate      | Source利用締切          |
| IsPointInTime         | 時点整合Datasetか        |
| ValidationStatus      | 検証状況                |

正式な物理設計はDDL Phaseで決定する。

---

# 23. Dataset Classification（Dataset分類）

| Dataset Type                     | Definition              |
| -------------------------------- | ----------------------- |
| Research Dataset                 | 仮説検証用。最新Ruleの過去適用を許容    |
| Historical Simulation Dataset    | 現在Ruleによる過去シミュレーション     |
| Point-in-time Validation Dataset | 当時利用可能情報を使用             |
| Production Training Dataset      | Production承認済みFeatureのみ |
| Production Inference Dataset     | 現在のAdvisor / ML推論用      |

Dataset Typeを混在させない。

---

# 24. Invalid Dataset Conditions（Dataset無効条件）

以下のいずれかが確認された場合、
Validation Datasetを無効とする。

* Future Publication使用
* Future Knowledge Version使用
* Future Exposure使用
* Latest Revised Valueの遡及適用
* Full Dataset Imputation
* Full Dataset Scaling
* Full Dataset Lag Selection
* Test Periodを利用したRule変更
* Current Company Universeの遡及利用
* Event重複
* Feature Lineage欠損
* As Of Date不明

判定：

```text
INVALID POINT-IN-TIME DATASET
```

結果を投資判断根拠として使用してはならない。

---

# 25. Initial Implementation Priority（初期実装優先順位）

## Priority 1

Structured Financial Observation

* Revenue
* Inventory
* CapEx

理由：

公開時点管理と長期履歴構築が比較的現実的。

---

## Priority 2

Derived Financial Observation

* Revenue Growth
* Inventory Growth
* Inventory / Revenue
* Inventory Days
* CapEx Growth

Training WindowおよびAs Of Date整合を維持する。

---

## Priority 3

External End Demand Statistics

* EV Registrations
* EV Penetration
* Regional EV Growth

SourceごとのPublication Ruleを定義する。

---

## Priority 4

Qualitative IR Observation

* Guidance
* Inventory Commentary
* Demand Commentary

AI-assisted Extraction + Reviewer方式を採用候補とする。

---

## Priority 5

Event Observation

* Design Win
* Mass Production
* Capacity Expansion

Event Identity管理が必要。

---

# 26. Independent Reviewer Judgment（独立レビュー判定）

## Research Reviewer

**判定：強く承認**

Raw ObservationとApproved KnowledgeのEffective Dateを分離した点を評価する。

企業が資料を公開した日時と、
Knowledgeとして承認された日時は異なる。

この差を無視してはならない。

---

## Engineering / ML Reviewer

**判定：強く承認**

以下をProduction Datasetの必須条件候補とする。

* Point-in-time Eligibility
* Versioned Knowledge
* Versioned Transformation Rules
* Training-only Imputation
* Training-only Scaling
* Point-in-time Company Universe
* Feature Snapshot
* Feature Lineage
* Dataset Version

特に、

```text
現在のKnowledgeで過去Featureを再計算
```

する処理はResearch Simulationとしては許可するが、
Production Walk Forwardとは明確に分離する。

---

## ADR Reviewer

**判定：強く承認**

本Requirementは、
ML・Backtest・Knowledge・Document Acquisition・DB設計へ横断的に影響する。

正式ADR対象とする。

### ADR Candidate Title

**Require Point-in-time Lineage for Investment Knowledge Features**

### Decision Candidate

Production ValidationおよびProduction MLで使用するKnowledge Featureは、
Prediction Date時点で利用可能だったObservation、Knowledge Version、
Transformation Rule Versionから生成され、
Feature Lineageを追跡可能でなければならない。

---

# 27. Final Decision（現時点の決定）

Automotive Power Knowledge Validationでは、
Point-in-time DatasetをProduction Validationの必須要件とする。

Historical SimulationとTrue Point-in-time Validationを分離する。

最新Knowledge・最新Rule・最新改定値を過去期間へ適用したDatasetは、
Researchには利用できるが、

```text
Production Validated
```

とは認定しない。

---

# 28. Next Actions（次の作業）

1. Inventory Adjustment Component Validation Specificationを作成する。
2. Inventory / Revenue算出定義を確定する。
3. Inventory Days算出定義を検討する。
4. J-Quants / 財務諸表から取得可能なInventory項目をCatalog候補化する。
5. Power Semiconductor Company Universeを定義する。
6. Historical Coverage要件を確認する。
7. Point-in-time Dataset Requirementを将来のKnowledgeBaseDevelopmentGuideへ反映候補として登録する。
8. ADR CandidateをArchitecture Backlogへ登録する。
