# Automotive Power Data Availability Matrix Research

**Research Domain**: Semiconductor Industry
**Research Package**: Automotive Demand
**Research Category**: Data Availability / Operational Feasibility
**Knowledge Scope**: Automotive / Power Semiconductor
**Version**: 0.1
**Status**: Candidate Design
**Reviewer Status**: Pending Validation
**Last Updated**: 2026-07-11

---

# 1. Research Objective（研究目的）

Automotive Power Demand
（車載パワー半導体需要）の5 Componentについて、

* どのObservation（観測項目）を取得できるか
* どの頻度で更新できるか
* どの程度のHistorical Coverage（過去期間）を確保できるか
* Point-in-time Validation（時点整合検証）へ利用できるか
* 自動取得・半自動取得・手動Researchのどれに分類するか

を整理する。

本Researchの目的は、

「理論上重要なObservation」

を列挙することではない。

継続取得・Validation・運用が可能なObservationを特定することである。

---

# 2. Research Success Criteria（調査成功条件）

以下を判断できた場合、本Researchを完了候補とする。

* Production Candidate Observation
* Experimental Observation
* Advisor-only Observation
* Research-only Observation
* Initial Exclusion Observation

さらに、各Observationについて以下を定義する。

* Source
* Frequency
* Historical Coverage
* Point-in-time Availability
* Acquisition Method
* Disclosure Stability
* Operational Cost
* Initial Usage

---

# 3. Availability Classification（利用可能性分類）

| Classification        | 日本語        | Definition              |
| --------------------- | ---------- | ----------------------- |
| Production Candidate  | 本番候補       | 継続取得・履歴構築・Validationが可能 |
| Conditional Candidate | 条件付き候補     | 一部企業・地域のみ取得可能           |
| Experimental          | 実験候補       | 有用性候補だが取得・定義に制約あり       |
| Advisor-only          | Advisor専用  | 定性説明には有用だが定量利用困難        |
| Research-only         | Research専用 | 仮説形成・補足調査でのみ利用          |
| Initial Exclusion     | 初期除外       | 初期運用では採用しない             |

Availability ClassificationはKnowledge Importanceではない。

取得可能性が高いことを理由に重要度を上げてはならない。

---

# 4. Operational Cost Classification（運用コスト分類）

| Cost      | Definition                   |
| --------- | ---------------------------- |
| Low       | APIまたは定型ファイルから自動・準自動取得可能     |
| Medium    | PDF / IRから定型抽出とReviewer確認が必要 |
| High      | 複数資料の個別Research・定義確認が必要      |
| Very High | 継続取得が困難または商用データ依存            |

Operational CostはKnowledgeの投資価値と分離する。

---

# 5. Component A: End Demand Data Availability（最終需要）

| Observation               | Primary Source Candidate            | Frequency                  | History        | Point-in-time | Cost          | Initial Decision      |
| ------------------------- | ----------------------------------- | -------------------------- | -------------- | ------------- | ------------- | --------------------- |
| Global EV Sales Growth    | IEA                                 | Annual / periodic          | Medium         | Yes           | Low to Medium | Production Candidate  |
| Regional EV Sales Growth  | ACEA / regional official statistics | Monthly / periodic         | Medium         | Yes           | Low to Medium | Production Candidate  |
| BEV Registrations         | ACEA / regional statistics          | Monthly                    | Medium         | Yes           | Low           | Production Candidate  |
| PHEV Registrations        | ACEA / regional statistics          | Monthly                    | Medium         | Yes           | Low           | Production Candidate  |
| HEV Registrations         | ACEA / regional statistics          | Monthly                    | Medium         | Yes           | Low           | Production Candidate  |
| EV Penetration            | Derived from registrations          | Monthly                    | Medium         | Yes           | Low           | Production Candidate  |
| Vehicle Production Growth | OICA / regional associations        | Annual / monthly by region | Long to Medium | Yes           | Low to Medium | Conditional Candidate |
| OEM Production Guidance   | OEM IR                              | Quarterly / event          | Medium         | Yes           | High          | Experimental          |
| Vehicle Inventory         | Regional / OEM dependent            | Irregular                  | Limited        | Conditional   | High          | Research-only         |

---

# 6. End Demand Assessment（最終需要評価）

## Production Candidate

初期Dataset候補は以下とする。

* Regional EV Sales Growth
* BEV Registration Growth
* PHEV Registration Growth
* HEV Registration Growth
* EV Penetration Change

## Conditional Candidate

* Global EV Sales Growth
* Vehicle Production Growth

Global EV dataは市場全体Contextとして有用だが、
Company ScoreではRegional Exposureとの整合が必要である。

## Initial Exclusion

* Vehicle Inventory

継続的かつ比較可能な公開Sourceを初期段階では確定できていない。

重要性が低いと判断したわけではない。

**Operational Feasibility不足による初期除外**である。

---

# 7. Component B: Semiconductor Demand Data Availability（半導体需要）

| Observation                | Infineon                 | ROHM                 | ST                     | onsemi       | Frequency          | Initial Decision        |
| -------------------------- | ------------------------ | -------------------- | ---------------------- | ------------ | ------------------ | ----------------------- |
| Total Revenue Growth       | Stable                   | Stable               | Stable                 | Stable       | Quarterly          | Production Candidate    |
| Automotive Revenue Growth  | High                     | Partial              | Partial                | Candidate    | Quarterly / Annual | Conditional Candidate   |
| Automotive Power Revenue   | High                     | Indirect             | Limited                | Indirect     | Annual / periodic  | Company-specific        |
| SiC Revenue Growth         | Limited                  | Commentary / partial | Periodic               | Limited      | Irregular          | Experimental            |
| SiC Device Revenue         | Not separated            | Partial commentary   | Limited                | Limited      | Irregular          | Experimental            |
| SiC Module Revenue         | Not separated            | Limited              | Limited                | Limited      | Irregular          | Initial Exclusion       |
| SiC Substrate Revenue      | Not applicable / unclear | Partial commentary   | Limited                | Limited      | Irregular          | Company-specific        |
| Automotive Book-to-Bill    | Not standard             | Not standard         | Periodically disclosed | Not standard | Irregular          | High-value Experimental |
| Power Guidance             | Stable commentary        | Periodic             | Periodic               | Periodic     | Quarterly          | Conditional Candidate   |
| SiC Guidance               | Periodic                 | Periodic             | Periodic               | Periodic     | Quarterly / event  | Conditional Candidate   |
| Customer Demand Commentary | Available                | Available            | Available              | Available    | Quarterly          | Advisor / Experimental  |
| Regional Demand Commentary | Available                | Available            | Available              | Available    | Quarterly          | Advisor / Experimental  |

---

# 8. Semiconductor Demand Assessment（半導体需要評価）

## Strong Production Candidate

以下を企業ごとに取得する。

* Total Revenue Growth
* Guidance Direction
* Inventory Trend
* Company-specific Automotive Revenue Growth where reported

## Company-specific Candidate

以下は共通Featureへ強制変換しない。

* Infineon Automotive Power Revenue
* ROHM SiC Device Commentary
* ROHM SiC Substrate Commentary
* ST SiC Revenue
* ST Automotive Book-to-Bill
* onsemi Power / Automotive-specific disclosures

これらはCompany-specific Observationとして保存する。

## Experimental

* SiC Revenue Growth
* Automotive Book-to-Bill

理論的価値は高い。

しかし、企業横断での継続取得性が低い。

初期ML Featureへ直接使用せず、
Company ContextおよびResearch Validationから開始する。

## Initial Exclusion

* SiC Module Revenue

現時点では継続取得可能な共通Sourceを確認できない。

---

# 9. Component C: Inventory Adjustment Data Availability（在庫調整）

| Observation                   | Source               | Frequency         | History | Point-in-time | Cost   | Initial Decision      |
| ----------------------------- | -------------------- | ----------------- | ------- | ------------- | ------ | --------------------- |
| Total Inventory               | Financial statements | Quarterly         | Long    | Yes           | Low    | Production Candidate  |
| Inventory Growth              | Derived              | Quarterly         | Long    | Yes           | Low    | Production Candidate  |
| Inventory / Revenue           | Derived              | Quarterly         | Long    | Yes           | Low    | Production Candidate  |
| Inventory Days                | Derived              | Quarterly         | Long    | Yes           | Low    | Production Candidate  |
| Segment Inventory             | Company disclosure   | Annual / periodic | Limited | Yes           | Medium | Company-specific      |
| Customer Inventory Commentary | Earnings materials   | Quarterly         | Medium  | Yes           | High   | Experimental          |
| Destocking Commentary         | Earnings materials   | Quarterly         | Medium  | Yes           | High   | Experimental          |
| Inventory Write-down          | Financial / notes    | Event / quarterly | Medium  | Yes           | Medium | Conditional Candidate |

---

# 10. Inventory Assessment（在庫評価）

Inventory Componentは5 Componentの中で、
最もOperational Feasibilityが高い候補の一つである。

## Production Candidate

* Inventory Growth
* Inventory / Revenue
* Inventory Days

理由：

財務諸表から比較的長い時系列を構築できる。

## Company-specific High-value Observation

* Segment Inventory

Infineon等、開示企業では高い利用価値候補がある。

ただし、非開示企業へProxy値を機械的に補完しない。

## Experimental Qualitative Observation

* Customer Inventory Commentary
* Destocking Commentary

AI-assisted Extraction
（AI補助抽出）候補とする。

人間Reviewer承認前にKnowledgeへ変換しない。

---

# 11. Component D: Capacity Risk Data Availability（供給能力リスク）

| Observation              | Source                | Frequency          | History | Point-in-time | Cost           | Initial Decision      |
| ------------------------ | --------------------- | ------------------ | ------- | ------------- | -------------- | --------------------- |
| Total CapEx              | Cash flow / IR        | Quarterly / annual | Long    | Yes           | Low            | Production Candidate  |
| CapEx Growth             | Derived               | Quarterly / annual | Long    | Yes           | Low            | Production Candidate  |
| SiC-specific CapEx       | IR / presentation     | Periodic           | Limited | Yes           | Medium to High | Experimental          |
| Fab Expansion            | Official release / IR | Event              | Medium  | Yes           | Medium         | Conditional Candidate |
| Wafer Capacity Expansion | IR                    | Event / periodic   | Limited | Yes           | High           | Experimental          |
| Utilization              | Company disclosure    | Irregular          | Limited | Yes           | High           | Experimental          |
| Underutilization Cost    | Company disclosure    | Periodic           | Limited | Yes           | Medium         | Company-specific      |
| Capacity Start-up Date   | Official release      | Event              | Medium  | Yes           | Medium         | Conditional Candidate |

---

# 12. Capacity Risk Assessment（供給能力リスク評価）

## Production Candidate

* Total CapEx
* CapEx Growth

ただし、CapEx単独ではDirectionを付与しない。

## Conditional Candidate

* Fab Expansion
* Capacity Start-up Date

公式発表からEvent Observationとして管理可能。

## Experimental

* SiC-specific CapEx
* Wafer Capacity Expansion
* Utilization

重要性候補は高いが、定義・更新頻度・企業差の制約がある。

## Company-specific High-value Observation

* Underutilization Cost

Infineon等で取得できる場合は、
Capacity Risk Contextへ利用候補とする。

---

# 13. Component E: Commercialization Data Availability（商用化）

| Observation           | Source                | Frequency | History | Point-in-time | Cost   | Initial Decision                 |
| --------------------- | --------------------- | --------- | ------- | ------------- | ------ | -------------------------------- |
| Product Announcement  | Official release      | Event     | High    | Yes           | Low    | Evidence Only                    |
| Design Win            | Official release / IR | Event     | Medium  | Yes           | Medium | Conditional Candidate            |
| Customer Nomination   | Official release / IR | Event     | Medium  | Yes           | Medium | Conditional Candidate            |
| Mass Production Start | Official release      | Event     | Medium  | Yes           | Medium | Production Candidate for Context |
| Revenue Contribution  | IR                    | Periodic  | Low     | Yes           | High   | High-value Experimental          |
| Repeat Adoption       | Official release / IR | Event     | Low     | Yes           | High   | Experimental                     |
| Expanded Adoption     | Official release / IR | Event     | Low     | Yes           | High   | Experimental                     |

---

# 14. Commercialization Assessment（商用化評価）

## Do Not Score

* Product Announcement

新製品発表だけでは需要を確認できない。

## Conditional Candidate

* Design Win
* Customer Nomination

初期Weightは低くする。

## Strong Context Candidate

* Mass Production Start

商用化段階が進んだEvidenceとして利用候補。

## High-value Experimental

* Revenue Contribution
* Repeat Adoption
* Expanded Adoption

投資判断への価値は高い可能性があるが、
継続取得率が低い。

AdvisorおよびCompany Researchから利用を開始する。

---

# 15. Historical Coverage Assessment（履歴期間評価）

## Long-history Candidate

長期時系列を構築できる可能性が高い。

* Total Revenue
* Inventory
* CapEx
* Derived Inventory Ratios

## Medium-history Candidate

過去資料のResearchにより構築可能。

* Automotive Revenue
* Regional EV Registrations
* Guidance Direction
* Automotive Commentary

## Limited-history Candidate

継続的Dataset構築が難しい。

* SiC Revenue
* SiC-specific CapEx
* Segment Inventory
* Utilization
* Underutilization Cost
* Revenue Contribution from Design Wins

---

# 16. Point-in-Time Availability Assessment（時点利用可能性評価）

## Strong Point-in-time Candidate

* Financial Statement Values
* Quarterly Revenue
* Inventory
* CapEx
* Official Registration Statistics

Published Dateを取得できるため、
Walk Forwardへ利用しやすい。

## Conditional Point-in-time Candidate

* Guidance
* Commentary
* Design Win
* Mass Production

Document Published Dateに加えて、
Reviewer Approved Dateを管理する必要がある。

## High-risk Candidate

第三者Data Providerによる再構築済みHistorical Dataset。

元データの公開時点が不明な場合、
Walk Forwardへ使用しない。

---

# 17. Acquisition Layer（取得レイヤー）

## Layer A: Automated / Structured

初期自動化候補。

* J-Quants Financial Data where applicable
* Financial Statement Data
* Inventory
* Revenue
* CapEx
* Derived Ratios
* Structured registration statistics where technically available

## Layer B: Semi-automated Document Extraction

* Automotive Revenue
* Power Revenue
* SiC Commentary
* Guidance
* Segment Inventory
* Fab Expansion

処理候補：

```text id="20fumz"
Document Detection
↓
Document Acquisition
↓
AI-assisted Extraction
↓
Research Sheet Draft
↓
Human Review
↓
Approved Observation
```

## Layer C: Manual Research

* Definition Change
* Conflicting Evidence
* Customer-specific demand
* SiC Device / Module / Substrate separation
* Company-specific unusual disclosures

---

# 18. Initial Production Dataset Candidate（初期Production Dataset候補）

初期段階では以下を優先する。

## End Demand

* Regional EV Sales Growth
* BEV Growth
* PHEV Growth
* HEV Growth
* EV Penetration Change

## Semiconductor Demand

* Total Revenue Growth
* Automotive Revenue Growth where reported
* Guidance Direction
* Automotive / Power Commentary Status

## Inventory Adjustment

* Inventory Growth
* Inventory / Revenue
* Inventory Days

## Capacity Risk

* CapEx Growth
* Official Capacity Expansion Event

## Commercialization

* Mass Production Start Event

---

# 19. Experimental Dataset Candidate（実験Dataset候補）

以下はProduction Datasetと分離する。

* SiC Revenue Growth
* Automotive Book-to-Bill
* Segment Inventory
* Customer Inventory Commentary
* SiC-specific CapEx
* Utilization
* Underutilization Cost
* Design Win
* Revenue Contribution
* Repeat Adoption

Experimental FeatureをProduction Featureへ昇格するには、
Walk ForwardおよびData Availability Reviewを通過する必要がある。

---

# 20. Initial Exclusion List（初期除外候補）

以下は現時点で初期ML Datasetへ含めない。

* SiC Module Revenue
* Customer-specific Revenue
* SiC ASP
* Vehicle-level Semiconductor Unit Count
* Vehicle-level SiC Unit Count
* Unverified Market Share Estimate
* News-based Demand Score
* Product Announcement Count

理由：

* 継続取得困難
* 定義不安定
* 高コスト
* Proxy Risk
* Investment Contribution未確認

---

# 21. Data Availability Matrix Summary（利用可能性まとめ）

| Component            | Availability   | Initial Operational Priority |
| -------------------- | -------------- | ---------------------------- |
| End Demand           | High           | High                         |
| Semiconductor Demand | Medium         | High                         |
| Inventory Adjustment | High           | Very High                    |
| Capacity Risk        | Medium to High | High                         |
| Commercialization    | Medium         | Medium                       |

## Inference

Inventory Adjustmentは、
取得可能性・履歴期間・Point-in-time整合性の観点から、
最も早くValidation可能なComponentである可能性が高い。

## Hypothesis

Inventory Adjustmentは、
Automotive Power Contextの中で高いInvestment Contributionを持つ可能性がある。

これはValidation前の仮説であり、
Initial Weightへ直接反映しない。

---

# 22. Independent Reviewer Judgment（独立レビュー判定）

## Research Reviewer

**判定：承認**

初期Production DatasetとExperimental Datasetを分離した判断を支持する。

Research Importanceが高くても、
Data Availabilityが低いObservationをProduction利用しない方針は適切である。

## Engineering / ML Reviewer

**判定：承認**

最初のValidationでは取得率の高いObservationだけでBaselineを作成する。

その後、Experimental Observationを一つずつ追加し、
Incremental Contribution（追加寄与）を測定すべきである。

推奨順序：

```text id="crd1ht"
Baseline
↓
+ Inventory
↓
+ End Demand
↓
+ Semiconductor Demand
↓
+ Capacity Risk
↓
+ Commercialization
```

ただし、この順序自体もResearch Hypothesisである。

Validation結果により変更可能とする。

## ADR Reviewer

**判定：承認**

「理論的重要度」と「Production利用可能性」を分離する設計を支持する。

取得できない高重要度指標を無理なProxyで補完するより、
Productionから除外しExperimentalとして管理する方が
Project Constitutionと整合する。

---

# 23. Final Decision（現時点の決定）

Automotive Power DemandのObservationを、

```text id="3z2k2r"
Production Candidate
Experimental
Advisor-only
Research-only
Initial Exclusion
```

へ分類する。

初期ValidationではProduction Candidateのみ利用する。

Experimental Observationは、
個別ContributionをValidation後に昇格・降格する。

取得困難なObservationは、
重要度が高くても無理にProduction利用しない。

---

# 24. Next Actions（次の作業）

1. Lead-Lag Validation Specificationを作成する。
2. Point-in-time Dataset構築要件を確定する。
3. Production Candidate ObservationのCatalog候補を整理する。
4. Inventory Adjustment ComponentからValidation設計を開始する。
5. Experimental Observationの昇格基準を定義する。
