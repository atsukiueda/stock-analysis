# Automotive Power Demand Composite Score Research

**Research Domain**: Semiconductor Industry
**Research Package**: Automotive Demand
**Research Category**: Knowledge Transformation / Composite Observation
**Knowledge Scope**: Automotive / Power Semiconductor
**Version**: 0.1
**Status**: Candidate Design
**Reviewer Status**: Pending Validation
**Last Updated**: 2026-07-11

---

# 1. Research Objective（研究目的）

Automotive Power Semiconductor Demand
（車載パワー半導体需要）を評価するためのComposite Score
（複合スコア）候補を設計する。

本Researchでは、

「EV販売増加 = 車載Power Semiconductor需要改善」

という単純なTransformation Rule（知識変換ルール）を採用しない。

以下の異なる状態を分離して観測する。

* End Demand（最終需要）
* Semiconductor Demand（半導体需要）
* Inventory Adjustment（在庫調整）
* Supply / Capacity（供給・生産能力）
* Commercialization（商用化）
* Company Exposure（企業Exposure）

本ScoreはResearch Candidateであり、
Validation完了前にProduction Scoreとして利用してはならない。

---

# 2. Business Purpose（投資上の目的）

Automotive Power Demand Composite Score
（車載パワー需要複合スコア）は、

以下を区別することを目的とする。

## Pattern A

```text
EV需要改善
+
半導体需要改善
+
在庫正常化

↓

True Demand Recovery
（実需回復）
```

## Pattern B

```text
EV需要改善
+
半導体売上低下
+
在庫調整継続

↓

End Demand Positive
Semiconductor Adjustment Ongoing
（最終需要改善・半導体調整継続）
```

## Pattern C

```text
EV需要鈍化
+
大規模CapEx
+
在庫増加

↓

Capacity Risk
（供給能力過剰リスク）
```

## Pattern D

```text
Design Win
+
量産開始
+
売上改善

↓

Commercialization Confirmed
（商用化確認）
```

この状態分類をAdvisor、Company Score、ML Contextで利用する。

---

# 3. Score Design Philosophy（スコア設計思想）

## Principle 1

Final Demand（最終需要）とSemiconductor Demand（半導体需要）を分離する。

EV Sales GrowthだけでPower Semiconductor Demandを判定しない。

---

## Principle 2

Inventory（在庫）は独立したAdjustment Layer
（調整レイヤー）として扱う。

最終需要が強くても在庫調整中であれば、
半導体企業売上は悪化する可能性がある。

---

## Principle 3

CapEx（設備投資）はPositive Factor
（プラス要因）として固定しない。

CapExは以下の両方を示す可能性がある。

* Future Demand Preparation（将来需要への準備）
* Capacity Oversupply Risk（供給過剰リスク）

---

## Principle 4

Design Win（設計採用）は売上と同義ではない。

量産開始およびRevenue Evidence（売上Evidence）で確認する。

---

## Principle 5

Missing Data（欠損データ）をZeroとして扱わない。

DisclosureNormalizationRule.mdに従う。

---

## Principle 6

Initial Weight（初期Weight）はResearch Hypothesisである。

Walk Forward、Ablation Test（除去テスト）、
Feature Importance、Advisor Contributionにより変更する。

---

# 4. Score Architecture（スコア構造）

初期候補として、以下の5 Component
（構成要素）へ分離する。

```text
Automotive Power Demand Composite Score

├── A. End Demand Component
│      （最終需要）
│
├── B. Semiconductor Demand Component
│      （半導体需要）
│
├── C. Inventory Adjustment Component
│      （在庫調整）
│
├── D. Capacity Risk Component
│      （供給能力リスク）
│
└── E. Commercialization Component
       （商用化）
```

Company Contextへ利用する場合は、
別途Company Exposure Multiplier
（企業Exposure調整）を適用候補とする。

---

# 5. Component A: End Demand Component（最終需要）

## Purpose

Automotive electrification
（自動車電動化）の最終需要環境を観測する。

## Candidate Observations

| Observation               | 日本語        | Initial Importance |
| ------------------------- | ---------- | -----------------: |
| BEV Sales Growth          | BEV販売成長率   |                  4 |
| PHEV Sales Growth         | PHEV販売成長率  |                  3 |
| HEV Sales Growth          | HEV販売成長率   |                  3 |
| EV Penetration Change     | EV普及率変化    |                  4 |
| Regional EV Sales Growth  | 地域別EV販売成長率 |                  5 |
| Vehicle Production Growth | 自動車生産成長率   |                  2 |

## Initial Interpretation

世界合計より、
Company Regional Exposure（企業地域Exposure）と整合する
地域別需要を優先する。

## Constraint

PowertrainごとのPower Semiconductor Content
（パワー半導体搭載量）が未確定であるため、

BEV、PHEV、HEVへ固定Weightを付けない。

---

# 6. Component B: Semiconductor Demand Component（半導体需要）

## Purpose

実際のPower Semiconductor企業側で需要改善が発生しているかを観測する。

## Candidate Observations

| Observation                     | 日本語              | Initial Importance |
| ------------------------------- | ---------------- | -----------------: |
| Automotive Power Revenue Growth | 車載Power売上成長率     |                  5 |
| SiC Revenue Growth              | SiC売上成長率         |                  5 |
| Automotive Revenue Growth       | 車載売上成長率          |                  4 |
| Power / SiC Guidance Direction  | Power・SiCガイダンス方向 |                  5 |
| Automotive Book-to-Bill         | 車載B/Bレシオ         |  5 where disclosed |
| Regional Demand Commentary      | 地域需要コメント         |                  3 |

## Initial Interpretation

本ComponentをComposite Scoreの中核候補とする。

理由は、End Demandより企業売上に近いObservationであるため。

ただし、企業間の開示差が大きいため、
Company-specific Observationを優先する。

---

# 7. Component C: Inventory Adjustment Component（在庫調整）

## Purpose

End DemandとSemiconductor Revenueの乖離を説明する。

## Candidate Observations

| Observation                   | 日本語       | Initial Importance |
| ----------------------------- | --------- | -----------------: |
| Inventory Growth              | 在庫増減率     |                  5 |
| Inventory / Revenue           | 在庫売上比率    |                  5 |
| Inventory Days                | 在庫日数      |                  4 |
| Segment Inventory             | Segment在庫 |  5 where disclosed |
| Inventory Commentary          | 在庫コメント    |                  4 |
| Customer Inventory Commentary | 顧客在庫コメント  |                  5 |

## Initial Interpretation

### Positive Adjustment

```text
Inventory Decline
+
Revenue Stabilization
+
Guidance Improvement

↓

Inventory Normalization
```

### Negative Adjustment

```text
Inventory Growth
+
Revenue Decline
+
Weak Guidance

↓

Inventory Pressure
```

## Important Rule

在庫減少のみをPositiveと判定しない。

売上急減による在庫圧縮の可能性を確認する。

---

# 8. Component D: Capacity Risk Component（供給能力リスク）

## Purpose

CapExおよびCapacity Expansion
（生産能力増強）が将来需要への準備か、
供給過剰リスクかを評価する。

## Candidate Observations

| Observation        | 日本語     | Initial Importance |
| ------------------ | ------- | -----------------: |
| CapEx Growth       | 設備投資成長率 |                  4 |
| SiC-specific CapEx | SiC設備投資 |                  5 |
| Capacity Expansion | 能力増強    |                  5 |
| Utilization        | 稼働率     |                  5 |
| Inventory Growth   | 在庫増加    |                  4 |
| Revenue Growth     | 売上成長    |                  4 |
| Guidance Direction | ガイダンス方向 |                  4 |

## Initial Interpretation

### Growth Investment Candidate

```text
CapEx Increase
+
Revenue Growth
+
Inventory Stable
+
Guidance Positive

↓

Demand-backed Capacity Expansion
```

### Oversupply Risk Candidate

```text
CapEx Increase
+
Revenue Weakness
+
Inventory Increase
+
Guidance Weakness

↓

Capacity Oversupply Risk
```

## Constraint

Utilizationが取得困難な企業では、
Inventory、Revenue、GuidanceをProxy候補とする。

---

# 9. Component E: Commercialization Component（商用化）

## Purpose

技術・製品開発が実際の商用需要へ移行しているかを観測する。

## Candidate Observations

| Observation                | 日本語  | Initial Importance |
| -------------------------- | ---- | -----------------: |
| Design Win                 | 設計採用 |                  2 |
| Mass Production Start      | 量産開始 |                  4 |
| Customer Nomination        | 顧客指名 |                  3 |
| Revenue Contribution       | 売上寄与 |                  5 |
| Repeat / Expanded Adoption | 採用拡大 |                  4 |

## Initial Interpretation

```text
Design Win Only

↓

Commercialization Unconfirmed
```

```text
Design Win
+
Mass Production Start

↓

Commercialization Progress
```

```text
Mass Production
+
Revenue Growth

↓

Commercialization Confirmed
```

## Important Rule

製品発表件数をCommercialization Scoreへ使用しない。

---

# 10. Company Exposure Adjustment（企業Exposure調整）

Composite Demand ScoreをCompany Scoreへ利用する場合、
企業Exposureを考慮する。

## Candidate Factors

* Automotive Revenue Mix
* Power Product Exposure
* SiC Exposure
* Regional Exposure
* Customer Exposure
* Device / Module / Substrate Exposure

## Candidate Concept

```text
Automotive Power Demand Context

×

Validated Company Exposure

↓

Company-specific Automotive Power Context
```

## Prohibited Transformation

```text
Automotive Power Demand Score High

↓

All Power Semiconductor Companies Positive
```

企業Exposureが確認できない場合、
Company Scoreへ直接反映しない。

---

# 11. Candidate State Classification（状態分類候補）

単純な0〜100 Scoreだけでなく、
Context State（文脈状態）を保持する。

| State                   | 日本語      | Definition         |
| ----------------------- | -------- | ------------------ |
| Strong Expansion        | 強い拡大     | 最終需要・半導体需要・在庫が同時改善 |
| Expansion               | 拡大       | 半導体需要改善が確認される      |
| End-demand-led Recovery | 最終需要主導回復 | EV等は改善、半導体調整継続     |
| Inventory Normalization | 在庫正常化    | 在庫調整改善が主要変化        |
| Mixed                   | 混在       | Evidence方向が一致しない   |
| Demand Weakness         | 需要悪化     | 半導体需要が弱い           |
| Capacity Risk           | 供給能力リスク  | CapEx・能力増強と需要が不整合  |
| Uncertain               | 判定困難     | Evidence不足または競合    |

AdvisorではScore単独ではなく、
Stateを優先して説明する。

---

# 12. Initial Score Formula Candidate（初期計算候補）

現段階ではProduction Formulaではない。

Research Candidateとして以下を置く。

```text
Demand Context
=
End Demand Component
+
Semiconductor Demand Component
+
Inventory Adjustment Component
-
Capacity Risk Component
+
Commercialization Component
```

ただし、固定Weightはまだ定義しない。

## Reason

現時点では、

* 各Componentの予測力
* Lead-Lag
* 相関
* 情報更新頻度
* Company間比較可能性

がValidationされていないため。

---

# 13. Why Fixed Weights Are Not Defined Yet（固定Weightを設定しない理由）

以下のようなWeight設定は禁止する。

```text
EV Sales              30%
SiC Revenue           30%
Inventory             20%
CapEx                  10%
Design Win             10%
```

Evidenceがないため。

Initial ImportanceはResearch Priorityであり、
Operational Weightではない。

Weightは以下から決定する。

```text
Research Hypothesis
        ↓
Historical Dataset
        ↓
Lead-Lag Analysis
        ↓
Walk Forward
        ↓
Ablation Test
        ↓
Stability Analysis
        ↓
Operational Weight
```

---

# 14. Validation Design（検証設計）

## Phase 1: Data Availability Validation

確認事項：

* 各Observationの取得率
* 更新頻度
* 歴史データ期間
* Definition Stability
* Point-in-time Availability

取得率が低いObservationはML Featureから除外候補とする。

---

## Phase 2: Relationship Validation

確認対象：

* EV Sales → Automotive Power Revenue
* EV Penetration → SiC Revenue
* Inventory → Future Revenue
* CapEx → Future Revenue
* CapEx → Future Margin
* Mass Production → Future Revenue

Correlationだけで因果関係を断定しない。

---

## Phase 3: Lead-Lag Validation

各Observationについて、

* t
* t+1 Quarter
* t+2 Quarters
* t+4 Quarters

との関係を確認する。

Observationごとに有効なLagを推定する。

---

## Phase 4: Walk Forward Validation

未来情報を使用しない。

KnowledgePublishedDate
および
AsOfDate

を基準に、その時点で利用可能なObservationのみ使用する。

---

## Phase 5: Knowledge Ablation Test（Knowledge除去テスト）

以下を比較する。

```text
Base Model

vs

Base Model
+
Automotive Power Context
```

さらにComponent単位で除去する。

```text
Full Context

- End Demand

- Semiconductor Demand

- Inventory

- Capacity Risk

- Commercialization
```

削除しても結果が変わらないComponentは重要度を下げる。

---

# 15. Evaluation Metrics（評価指標）

ML性能だけで判断しない。

## ML

* AUC
* RMSE / MAE
* Feature Importance
* Stability

## Backtest

* Capital Return
* Profit Factor
* Max Drawdown
* Win Rate
* Trade Count

## Decision

* Company Ranking improvement
* False Positive reduction
* Regime-specific performance

## Advisor

* Explanation consistency
* Evidence traceability
* Contradiction rate

## Operation

* Data acquisition cost
* Review cost
* Missing rate
* Update latency

---

# 16. Rejection and Downgrade Rules（不採用・降格ルール）

以下の場合、ComponentまたはKnowledge全体の重要度を下げる。

* Walk Forward改善なし
* Ablation Testで差がない
* 特定企業のみで有効
* 特定期間のみで有効
* 過学習疑い
* 情報取得率が低い
* 更新コスト過大
* Company Guidanceの方が明確に有効
* Proxy誤差が大きい
* Explainabilityが悪化する

Research上重要でも、
投資判断へのContributionが低ければML・Decision Engineで使用しない。

---

# 17. Initial Knowledge Destination（初期利用先）

| Destination                  | Initial Decision     |
| ---------------------------- | -------------------- |
| Automotive Package Context   | Adopt Candidate      |
| Power Semiconductor Context  | Adopt Candidate      |
| Company Score                | Validation Required  |
| Advisor                      | Strong Candidate     |
| ML Context                   | Experimental         |
| Portfolio Engine             | Validation Required  |
| Semiconductor Industry Score | Low Weight Candidate |

---

# 18. Current Research Judgment（現在のResearch判断）

## Fact

Automotive Power Semiconductor関連企業では、
車載Power売上、在庫、CapEx、ガイダンス、SiC関連商用化Evidence等を
企業ごとに異なる粒度で取得できる。

## Inference

単一Observationより、

* End Demand
* Semiconductor Demand
* Inventory
* Capacity Risk
* Commercialization

を分離したComposite Contextの方が、
車載Power Semiconductor需要の状態を説明できる可能性が高い。

## Hypothesis

Composite ContextはVehicle ProductionまたはEV Sales単独より、
Company Score、Advisor、ML Contextの品質を改善する可能性がある。

Validation前のためKnowledgeとしては未承認である。

---

# 19. Independent Reviewer Judgment（独立レビュー判定）

## Research Reviewer

**判定：承認 — Validation Designへ進行可能**

5 Component構造は、
EV販売だけで車載Power需要を説明する問題を回避している。

特にInventory AdjustmentとCapacity Riskを独立させた点を評価する。

## Engineering / ML Reviewer

**判定：条件付き承認**

固定Weightを現時点で定義しない判断は正しい。

最初にComponent Scoreを個別Featureとして保存し、
MLおよびWalk ForwardでContributionを測定すべきである。

初期実装では、

```text
AutomotivePowerEndDemandScore
AutomotivePowerSemiconductorDemandScore
AutomotivePowerInventoryScore
AutomotivePowerCapacityRiskScore
AutomotivePowerCommercializationScore
```

を分離候補とする。

最初からComposite Score一つだけに圧縮してはならない。

## ADR Reviewer

**判定：承認**

「Composite Scoreを設計するが、固定WeightをEvidenceなしで決めない」

という判断はProject Constitutionと整合する。

Production WeightはValidation完了後に決定する。

---

# 20. Final Decision（現時点の決定）

Automotive Power Demand Composite Scoreは、
現時点では単一Production Scoreとして実装しない。

まず5 Componentを独立Knowledge Candidateとして保持する。

```text
End Demand
Semiconductor Demand
Inventory Adjustment
Capacity Risk
Commercialization
```

各ComponentをValidationし、

投資判断へのContributionが確認されたものだけを
最終Composite Scoreへ採用する。

---

# 21. Next Actions（次の作業）

1. 5 ComponentのObservation Mappingを確定する。
2. Data Availability Matrixを作成する。
3. Point-in-time Data要件を定義する。
4. Lead-Lag Validation仕様を作成する。
5. Knowledge Object Candidateへ変換する。
6. Automotive Power Demand Composite ScoreはValidation後に再設計する。
