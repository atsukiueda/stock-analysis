# Automotive Power Lead-Lag Validation Specification

**Research Domain**: Semiconductor Industry
**Research Package**: Automotive Demand
**Research Category**: Validation Specification
**Knowledge Scope**: Automotive / Power Semiconductor
**Version**: 0.1
**Status**: Candidate Validation Specification
**Reviewer Status**: Pending Validation
**Last Updated**: 2026-07-11

---

# 1. Purpose（目的）

本Specification（仕様）は、Automotive Power Semiconductor Demand
（車載パワー半導体需要）に関するObservation（観測項目）が、

* Future Revenue（将来売上）
* Future Margin（将来利益率）
* Future Company Score
* Future Stock Return（将来株価リターン）
* Advisor Decision Quality（Advisor判断品質）

に対して、どの程度のLead-Lag Relationship
（先行・遅行関係）を持つかを検証するための標準を定義する。

本Validationの目的は、

```text
相関が存在する
```

ことを確認するだけではない。

以下を確認する。

```text
Observation
↓
いつ利用可能になったか
↓
何四半期後へ影響するか
↓
複数期間で再現するか
↓
市況が変わっても有効か
↓
投資判断へContributionがあるか
```

Validationを通過していないObservationを、
Production Knowledge Weightへ使用してはならない。

---

# 2. Validation Philosophy（検証思想）

## Principle 1

Applicable Period（対象期間）ではなく、
As Of Date（利用可能時点）を基準とする。

例えばFY2025 Q4の決算数値であっても、
2026年5月に公開された場合、

2026年4月時点のPredictionへ使用してはならない。

---

## Principle 2

Observation Lag（観測Lag）とEconomic Lag（経済Lag）を分離する。

### Observation Lag

実際の事象発生から情報公開までの遅延。

例：

```text
Quarter End
↓
Financial Results Publication
```

### Economic Lag

Observationの変化から、
企業業績や株価へ影響が現れるまでの遅延。

例：

```text
CapEx Increase
↓
Capacity Start-up
↓
Production Increase
↓
Revenue Impact
```

両者を混同しない。

---

## Principle 3

最適LagをFull Datasetで決定しない。

全期間を確認して、

```text
最も成績が良かったLag = 採用Lag
```

とする方法は禁止する。

これはBacktest Optimization
（バックテスト最適化）による過学習リスクを持つ。

Lag CandidateはResearch Phaseで定義し、
Training Period内のみで選択する。

Test Periodの結果を見てLagを変更してはならない。

---

## Principle 4

Correlation（相関）をCausality（因果）として扱わない。

Lead-Lag Relationshipが確認されても、

```text
X causes Y
```

とは断定しない。

KnowledgeへのTransformationでは、

```text
Predictive Relationship
```

または

```text
Context Relationship
```

として管理する。

因果関係を記載する場合は、
別途Evidence Reviewを必要とする。

---

## Principle 5

Stock ReturnだけでKnowledge価値を評価しない。

Observationは以下へ異なるLagで影響する可能性がある。

* Revenue
* Margin
* Guidance
* Company Score
* Stock Return

例えば株価が業績より先に反応する可能性がある。

したがってTargetごとにLead-Lagを分離する。

---

# 3. Point-in-Time Eligibility Rule（時点利用可能性規則）

Observationは以下の条件を満たす場合のみ、
Prediction Date時点で利用可能とする。

```text
EffectiveAsOfDate <= PredictionDate
```

## 3.1 Structured Data（構造化データ）

J-Quants等から取得する財務情報では、
原則としてDisclosure Date / Disclosure Timeを利用する。

Candidate Rule：

```text
EffectiveAsOfDate
=
Disclosure DateTime
+
Operational Availability Buffer
```

Operational Availability Bufferは、
API反映遅延・Batch実行時刻を考慮する。

初期実装では同日利用を前提とせず、

```text
Next Trading Day
```

利用候補を優先する。

これは安全側の設計であり、
Validation後に見直す。

---

## 3.2 IR Document Data（IR資料データ）

以下を管理する。

* PublishedDateTime
* AcquiredAt
* ExtractedAt
* ReviewedAt
* ApprovedAt

Knowledgeとして使用する場合のCandidate Rule：

```text
EffectiveAsOfDate
=
ApprovedAt
```

ただし将来、
Validation済みAutomated Extractionを導入した場合は再検討する。

---

## 3.3 External Statistics（外部統計）

以下を分離する。

* Observation Period
* Publication Date
* Revision Date

改定値が存在する場合、
Backtestでは当時利用可能だったVintage
（当時版データ）を使用する。

Vintageを復元できない場合、
Point-in-time Validation不可として扱う。

---

# 4. Validation Targets（検証Target）

各Observationについて、以下を個別に検証する。

## Target A：Future Revenue Growth（将来売上成長）

Candidate Horizons：

* t+1 Quarter
* t+2 Quarters
* t+4 Quarters

---

## Target B：Future Margin Change（将来利益率変化）

Candidate Horizons：

* t+1 Quarter
* t+2 Quarters
* t+4 Quarters

Candidate Metrics：

* Operating Margin Change
* Segment Margin Change where available
* Gross Margin Change

---

## Target C：Future Guidance Direction（将来ガイダンス方向）

Candidate Horizons：

* Next Earnings
* Next Two Earnings

Direction：

```text
Improving
Stable
Weakening
```

---

## Target D：Future Stock Return（将来株価リターン）

Candidate Horizons：

* 5 Trading Days
* 10 Trading Days
* 20 Trading Days
* 60 Trading Days
* 120 Trading Days

ただし、Knowledgeの目的によってTargetを限定する。

Automotive Power Contextでは、

```text
20D
60D
120D
```

をPrimary Candidateとする。

5D・10DはSwing MLとの比較用とし、
Knowledge本体の価値判定を短期Returnだけで行わない。

---

## Target E：Future Ranking Quality（将来ランキング品質）

Knowledge追加前後で、

* Top N Return
* Top N Hit Rate
* Rank IC Candidate
* Company Ranking Stability

を比較する。

---

# 5. Observation-specific Lag Candidates（Observation別Lag候補）

固定Lagではなく、
Observationの経済的性質からCandidateを定義する。

| Observation              | Initial Lag Candidates | Research Rationale |
| ------------------------ | ---------------------- | ------------------ |
| EV Sales Growth          | 0Q / 1Q / 2Q           | 最終需要と半導体売上の伝播確認    |
| EV Penetration           | 1Q / 2Q / 4Q           | 構造変化として比較的長期候補     |
| Automotive Power Revenue | 0Q / 1Q                | 企業業績に近い            |
| Automotive Book-to-Bill  | 1Q / 2Q                | 将来売上への先行候補         |
| Guidance Direction       | Next Earnings / 2Q     | 経営見通しの持続性確認        |
| Inventory Growth         | 1Q / 2Q / 4Q           | 在庫調整の解消期間確認        |
| Inventory / Revenue      | 1Q / 2Q / 4Q           | 需給圧力の持続性確認         |
| Inventory Days           | 1Q / 2Q / 4Q           | 在庫正常化速度確認          |
| CapEx Growth             | 2Q / 4Q / 8Q           | 能力増強の長期伝播候補        |
| Capacity Start-up        | 1Q / 2Q / 4Q           | 稼働開始後の供給影響         |
| Underutilization Cost    | 1Q / 2Q                | 稼働状況改善の確認          |
| Design Win               | 4Q / 8Q / 12Q          | 商用化まで長期間候補         |
| Mass Production Start    | 1Q / 2Q / 4Q           | 売上寄与開始候補           |
| Revenue Contribution     | 0Q / 1Q                | 商用化確認済みObservation |

## Important Note

上記LagはResearch Hypothesisである。

Operational Lagではない。

Training Period内のValidationで選択または棄却する。

---

# 6. Validation Unit（検証単位）

以下の3単位で検証する。

## Level 1：Observation Level（観測単位）

例：

```text
Inventory / Revenue
→ Future Revenue Growth
```

個別Observationの有効性を確認する。

---

## Level 2：Component Level（構成要素単位）

例：

```text
Inventory Adjustment Component
→ Future Revenue Growth
```

Component統合の追加価値を確認する。

---

## Level 3：Knowledge Context Level（Knowledge Context単位）

例：

```text
Automotive Power Context
→ Company Ranking
→ Future Return
```

投資判断へのContributionを確認する。

Observation Levelで有効でも、
Context Levelで追加価値がなければWeightを下げる。

---

# 7. Dataset Split Rule（データ分割規則）

Random Split（ランダム分割）は禁止する。

Chronological Split（時系列分割）を使用する。

## Candidate Walk Forward Structure

```text
Train Period
↓
Validation Period
↓
Test Period
↓
Window Forward
```

例：

```text
Train:
2016-2020

Validation:
2021

Test:
2022

↓

Train:
2016-2021

Validation:
2022

Test:
2023
```

具体期間はData Availability確認後に決定する。

---

# 8. Lag Selection Rule（Lag選択規則）

Lag選択は以下で行う。

```text
Training Data
↓
Candidate Lag Comparison
↓
Validation Period Evaluation
↓
Lag Selection
↓
Test Period Fixed Evaluation
```

Test結果確認後のLag変更は禁止する。

Testで失敗した場合、

```text
Lag Failure
```

として記録する。

次Walk Forward Windowで再学習・再選択する場合は許可する。

---

# 9. Multiple Testing Control（多重検証管理）

多数のObservation × Lag × Targetを試すと、
偶然良い結果が発生する。

例：

```text
20 Observations
×
5 Lags
×
5 Targets

=
500 Tests
```

この問題を無視してはならない。

## Candidate Controls

* Candidate Lag事前制限
* Research Hypothesis記録
* Out-of-sample Test
* Walk Forward Stability
* Ablation Test
* Minimum Window Success Count
* Effect Direction Consistency

必要に応じて統計的Multiple Testing Correction
（多重検定補正）を検討する。

具体手法はML / Statistical Validation Phaseで決定する。

---

# 10. Overlapping Horizon Rule（重複期間規則）

Future Return 60Dや120D等では、
隣接ObservationのTarget Periodが重複する。

例：

```text
Observation A: 2025-01-01
Target: 60D

Observation B: 2025-01-02
Target: 60D
```

Target Returnの大部分が重複する。

この状態でSample Countをそのまま独立Observation数として解釈してはならない。

## Candidate Handling

* Non-overlapping Evaluation
* Spaced Observation Sampling
* Cluster-aware Statistical Review
* Quarter-level Evaluation

少なくとも、
Trade CountまたはSample Countだけで信頼性を判断しない。

---

# 11. Publication Lag Rule（公開遅延規則）

Observation Period終了日とPublication Dateを分離する。

例：

```text
Inventory:
2025 Q4

Period End:
2025-12-31

Published:
2026-02-05
```

Prediction Dateが2026-01-15の場合、

2025 Q4 Inventoryを使用してはならない。

Feature Dateは、

```text
Published Date
```

または

```text
Approved AsOfDate
```

へ割り当てる。

---

# 12. Revision Rule（改定値規則）

後日修正された財務値・統計値について、

Backtest Datasetへ最新値を過去時点から適用してはならない。

以下を区別する。

```text
Original Publication
Revision 1
Revision 2
Latest
```

Prediction Date時点で利用可能だったVersionのみを使用する。

Version履歴を取得できないObservationは、

```text
Revision Risk
```

を付与する。

Revision Riskが高い場合、
Production Validationから除外候補とする。

---

# 13. Qualitative Observation Lag Rule（定性ObservationのLag規則）

対象：

* Guidance
* Customer Inventory Commentary
* Regional Demand Commentary
* SiC Commentary

定性情報はDocument Published Date以降のみ利用する。

AI Extraction結果を即時Factとして利用しない。

Candidate Lifecycle：

```text
Published
↓
Extracted
↓
Fact / Inference Classification
↓
Reviewer Approval
↓
Effective As Of
```

Reviewer Approval前の内容はResearch Datasetとしてのみ扱う。

---

# 14. Direction Validation（方向性検証）

ObservationのInitial Interpretationが正しいか確認する。

例：

```text
Inventory / Revenue High
→ Negative
```

を最初から固定しない。

以下を検証する。

```text
High Inventory / Revenue
→ Future Revenue
→ Future Margin
→ Future Return
```

結果が、

```text
Future Revenue Recovery
```

と関係する場合、

Contrarian Recovery Signal
（逆張り回復シグナル）の可能性がある。

Researchの初期解釈と異なる場合、
Evidenceを優先してInterpretation Ruleを変更する。

---

# 15. Regime Validation（局面別検証）

Observationの効果を以下で分解する候補とする。

## Market Regime

* Strong Risk On
* Risk On
* Neutral
* Risk Off
* Strong Risk Off

## Industry Cycle

* Contraction
* Bottoming
* Recovery
* Expansion
* Peak
* Correction

## Automotive Demand State

* Strong Expansion
* Expansion
* End-demand-led Recovery
* Inventory Normalization
* Mixed
* Demand Weakness
* Capacity Risk

## Important Rule

Regime分割後のSample Countが不足する場合、
強い結論を出さない。

```text
Insufficient Evidence
```

として管理する。

---

# 16. Cross-company Validation（企業横断検証）

以下を分離する。

## Within-company Validation

同一企業内の時系列関係。

例：

```text
ROHM Inventory
→ ROHM Future Revenue
```

## Cross-company Validation

同一Observation Conceptの企業横断関係。

例：

```text
Inventory / Revenue
→ Future Revenue
across Power Semiconductor Companies
```

Company Disclosure差を考慮する。

企業横断で効果がなく、
一社だけで有効なObservationは、

```text
Company-specific Knowledge
```

へ降格候補とする。

---

# 17. Target Leakage Check（Target Leakage確認）

以下を必ず確認する。

* Target期間中に公開されたGuidanceをFeatureへ入れていないか
* Future Revenueを含むDerived Featureがないか
* 最新Annual Report情報を過去年へ遡及適用していないか
* 後日修正値を当初値として使用していないか
* Full DatasetでNormalizationしていないか
* Full DatasetでLag選択していないか
* Test期間を見てTransformation Ruleを変更していないか

一つでも該当する場合、
Validation Resultを無効とする。

---

# 18. Missing Data and Imputation Validation（欠損・補完検証）

Imputation（欠損補完）はTraining Window内の情報のみで実施する。

Full Datasetを利用した補完は禁止する。

以下を比較する。

```text
Feature Exclusion
vs
Missing Flag
vs
Training-only Imputation
```

最も成績が良い方法だけではなく、

* Stability
* Explainability
* Selection Bias

を確認する。

---

# 19. Evaluation Metrics（評価指標）

## Relationship Metrics

* Correlation
* Rank Correlation
* Direction Consistency
* Effect Size
* Window Success Rate

## Financial Metrics

* Future Revenue Growth
* Future Margin Change
* Guidance Direction Accuracy

## ML Metrics

* AUC
* RMSE
* MAE
* Feature Importance
* Permutation Importance
* Stability by Window

## Investment Metrics

* Capital Return
* Profit Factor
* Max Drawdown
* Win Rate
* Trade Count
* Top N Return
* False Positive Rate

単一Metricで採用判断しない。

---

# 20. Minimum Evidence Candidate（最低Evidence候補）

Production Knowledge昇格には、
少なくとも以下を要求する候補とする。

* 複数Walk Forward Windowで方向性が一致
* Out-of-sample改善
* Ablation時にContribution確認
* 単一企業依存ではない、またはCompany-specificと明記
* Point-in-time整合
* Observation取得率が運用可能水準
* Explanation可能
* 更新Trigger定義済み

具体的な数値Thresholdは、
実データ分布確認前に固定しない。

---

# 21. Validation Result Classification（検証結果分類）

| Status                  | Definition                    |
| ----------------------- | ----------------------------- |
| Validated               | 複数Windowで安定したContribution確認   |
| Conditionally Validated | 特定Regime・SubSector・Companyで有効 |
| Context Only            | 予測力は弱いが説明価値あり                 |
| Experimental            | Evidence不足または結果不安定            |
| Rejected                | Contributionなしまたは悪化           |
| Invalid Test            | Leakage・時点不整合等で検証無効           |

---

# 22. Knowledge Importance Update Rule（Knowledge重要度更新規則）

Validation結果に応じて重要度を変更する。

```text
Validated
→ Importance維持または上昇

Conditionally Validated
→ 適用Scope限定

Context Only
→ Advisor Contextへ限定

Experimental
→ Research継続

Rejected
→ ML / Decision Engineから除外

Invalid Test
→ 再検証
```

Research上のInitial Importanceを理由に、
Rejected Knowledgeを残してはならない。

---

# 23. Initial Validation Priority（初期検証優先順位）

## Priority 1

Inventory Adjustment Component

理由：

* 長期財務履歴候補
* Point-in-time管理可能
* 定量化可能
* 更新頻度が比較的一貫

## Priority 2

End Demand Component

理由：

* EV登録統計取得候補
* 地域別Observation可能

## Priority 3

Semiconductor Demand Component

理由：

* 投資価値候補は高い
* 企業開示差への対応が必要

## Priority 4

Capacity Risk Component

理由：

* CapEx履歴は取得可能
* Economic Lagが長い可能性
* 過剰供給と成長投資の分離が必要

## Priority 5

Commercialization Component

理由：

* 投資価値候補は存在
* Historical Dataset構築コストが高い

この順序はValidation Priorityであり、
Knowledge Importance順位ではない。

---

# 24. Independent Reviewer Judgment（独立レビュー判定）

## Research Reviewer

**判定：承認**

Applicable PeriodではなくAs Of Dateを基準にする点、
Observation LagとEconomic Lagを分離する点を評価する。

特に、Initial Interpretationと逆方向の結果が出た場合に、
Evidenceを優先してInterpretation Ruleを変更する方針を支持する。

## Engineering / ML Reviewer

**判定：強く承認**

以下を必須条件とする。

* Chronological Split
* Training-only Transformation
* Training-only Lag Selection
* Fixed Test Evaluation
* Point-in-time Dataset
* Ablation Test
* Window Stability Review

Random Splitは本Knowledge Validationでは使用しない。

## ADR Reviewer

**判定：承認**

Lead-Lag Validationは、
Knowledge WeightおよびTransformation Ruleを変更し得る。

したがってValidation結果による重要設計変更は、
Knowledge Weight Update Recordへ記録する。

Project-wide Validation Standardへの昇格は、
Automotive Reference Implementation完了後に判断する。

---

# 25. Final Decision（現時点の決定）

Automotive Power Knowledgeについて、

ObservationごとのLead-LagをResearch Hypothesisとして事前定義する。

LagはTraining / Validation期間で選択し、
Test期間では固定する。

Applicable Periodではなく、
実際のPublication / Approval As Of Dateを使用する。

Validation結果がResearch仮説を否定した場合、
仮説ではなくEvidenceを優先する。

---

# 26. Next Actions（次の作業）

1. Point-in-time Dataset Requirementを詳細設計する。
2. Inventory Adjustment Component Validation Specificationを作成する。
3. J-Quantsから取得可能なInventory関連項目を確認する。
4. Inventory / RevenueおよびInventory Daysの算出定義を確定する。
5. 対象Power Semiconductor Company Universeを定義する。
6. Historical Data Availabilityを確認する。
7. Validation実装はCatalog / DDL後に行う。
