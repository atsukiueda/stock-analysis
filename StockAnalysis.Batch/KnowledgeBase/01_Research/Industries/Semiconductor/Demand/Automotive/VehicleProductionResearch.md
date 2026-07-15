# EV Transition Research Sheet

**Research Domain**: Semiconductor Industry
**Research Package**: Automotive Demand
**Research Category**: Demand Observation
**Version**: 0.1
**Status**: Evidence Collection
**Reviewer Status**: Pending
**Last Updated**: 2026-07-10

---

# 1. Research Objective（研究目的）

EV Transition（電動車移行）が、Automotive Semiconductor Demand（車載半導体需要）を評価するためのOperational Knowledge（運用可能なKnowledge）として採用可能かを、Evidenceに基づいて検証する。

本Researchでは、単に「EVが増えれば半導体需要が増える」とは判断しない。

以下を個別に確認する。

* EV販売・生産の増加を継続的に観測できるか
* EV移行がどの半導体SubSectorへ伝播するか
* BEV・PHEV・HEVを同一指標として扱ってよいか
* EV販売数と車載半導体企業の売上が整合するか
* EV販売数だけでなく、地域構成・車種構成・在庫調整を考慮すべきか
* Advisor・Company Score・ML Contextで有効に利用できるか

---

# 2. Research Success Criteria（調査成功条件）

本Researchは、以下のいずれかをEvidenceで判断できた場合に成功とする。

## Success Pattern A

EV Transitionが、車載半導体需要の独立したKnowledge Objectとして利用可能である。

## Success Pattern B

EV販売数単独では不十分だが、Powertrain Mix（パワートレイン構成）、半導体企業売上、在庫、企業ガイダンスと組み合わせれば利用可能である。

## Success Pattern C

EV Transitionは投資テーマとしては重要でも、継続観測性または投資判断への寄与が不足し、Knowledge Object化を見送る。

Knowledge Objectを作成しない結論でも、Evidenceに基づく判断ができればResearch成功とする。

---

# 3. Business Value（投資価値）

| Destination       | Expected Usage                     |
| ----------------- | ---------------------------------- |
| Industry Score    | Automotive需要の構成変化を補足               |
| SubSector Context | Power、Analog、MCU、BMS関連需要の評価        |
| Company Score     | 車載電動化Exposureが高い企業の評価              |
| Advisor           | EV移行による追い風・逆風の説明                   |
| ML Context        | EVSalesGrowth、EVPenetration等の特徴量候補 |
| Portfolio Engine  | 車載Power・Analog・MCU関連企業の配分補助        |

---

# 4. Research Questions（調査課題）

## RQ-001

EV販売台数およびEV比率は、車載半導体需要を説明する有効なObservationとなるか。

## RQ-002

BEV、PHEV、HEVでは半導体需要構造が異なるため、個別に観測すべきか。

## RQ-003

EV Transitionは、Power Semiconductor、MCU、Analog、Mixed-signal、BMS、Sensor、Processorのどこへ最も強く影響するか。

## RQ-004

EV販売数の増加と、車載半導体メーカーのAutomotive revenueに乖離が生じる原因は何か。

## RQ-005

EV TransitionはLeading Indicator（先行指標）か、Demand Context（需要文脈）か。

## RQ-006

地域別EV販売・生産を分けて管理する必要があるか。

---

# 5. Current Evidence Summary（現在のEvidence要約）

## Fact-001：世界のEV市場

IEAは、2025年の世界電気自動車販売が2,000万台を超え、世界の新車販売の4分の1超を占める見込みとしていた。また、2025年第1四半期の世界EV販売は前年同期比35%増だった。

## Fact-002：2025年のEV生産

IEAによると、2025年の世界電気自動車生産は約2,200万台で、前年比25%以上増加した。中国は世界生産の約75%を占めた。

## Fact-003：欧州市場

IEAは、欧州の2025年電気自動車販売が前年比30%以上増加し、420万台、全新車販売の28%に達したとしている。

## Fact-004：EUのパワートレイン構成

ACEAによると、2025年のEU新車市場ではBattery Electric Vehicle（バッテリー電気自動車、BEV）の構成比が17.4%、Hybrid Electric Vehicle（ハイブリッド車、HEV）が34.5%だった。ガソリン車とディーゼル車の合計構成比は35.5%で、2024年の45.2%から低下した。

## Fact-005：観測更新性

ACEAはEUの新車登録をパワートレイン別に月次更新しており、BEV・HEV・PHEV等の販売構成を比較的高頻度で観測できる。

## Fact-006：Power Semiconductorとの関係

Infineonは2025年Annual Reportで、Power Semiconductor（パワー半導体）が電動化を支えること、および同社が支援運転や自動車の脱炭素化・デジタル化を主要テーマとしていることを説明している。

## Fact-007：車載半導体市場内の構成

Infineonの2025年度投資家資料では、同社はPower Semiconductor、Automotive Semiconductor、Automotive MCU市場で主要ポジションを持つと説明している。同資料では2024年のAutomotive Semiconductor市場規模を684億ドルとしている。

## Fact-008：EV向けMCU・BMS

NXPは、EVの電動化用途に特化したMCUおよび高電圧Battery Management System（バッテリーマネジメントシステム、BMS）向けICを提供している。

## Fact-009：ルネサスの製品構成

RenesasはAutomotive向けにMCU・SoCを中心とし、Analog・Power製品を組み合わせたシステムソリューションを提供している。

---

# 6. Evidence Interpretation（Evidenceの解釈）

## Inference-001

EV Transitionは、Automotive Demand Package内で独立して管理する価値がある。

**Reason**

EV販売・生産はIEAおよびACEAから継続観測でき、Power Semiconductor、MCU、Analog、BMS等への製品伝播も主要半導体企業の公式資料で確認できるため。

**Constraint**

EV販売の増加が、そのまま半導体企業の売上増加を意味するわけではない。

---

## Inference-002

EV Transitionは、Automotive Semiconductor Industry全体よりも、Power Semiconductor、MCU、Analog、Mixed-signal、BMSに対して強いContextを与える可能性が高い。

**Reason**

Infineon、NXP、Renesasが電動化用途としてPower、MCU、Analog、BMS等を明示しているため。

**Status**

Inference。

各SubSectorへの寄与率は未検証である。

---

## Inference-003

EV Sales（EV販売台数）はLeading Indicatorではなく、Demand ContextまたはCoincident Observationとして扱う方が妥当である可能性が高い。

**Reason**

EV販売は既に実現した需要を表すため、半導体受注・設備投資を十分に先行するとは限らない。

**Validation Required**

EV販売、半導体企業売上、受注、在庫、ガイダンスのLead-Lag Analysis（先行・遅行分析）が必要。

---

## Inference-004

EV Transitionは地域別に管理する必要がある。

**Reason**

2025年のEV生産では中国の構成比が非常に高く、欧州でもEV普及率が大きく上昇しているため、世界合計だけでは企業ごとの地域Exposureを適切に説明できない。

---

# 7. Hypotheses（仮説）

## Hypothesis-001

BEV比率の上昇は、ICE中心の車種構成よりも、Power SemiconductorおよびBMS需要を増加させる可能性がある。

**Status**

Hypothesis。

**Reason**

企業の製品用途から方向性は支持されるが、1台当たり半導体搭載額や搭載個数の継続的な一次Evidenceが不足している。

---

## Hypothesis-002

HEVはBEV移行の過渡期需要として、Power Semiconductor、MCU、Analog需要へ大きく寄与する可能性がある。

**Status**

Hypothesis。

**Reason**

EUでは2025年にHEVが新車市場の34.5%を占めたが、HEVとBEVの半導体搭載構造を直接比較できる一次Evidenceが不足している。

---

## Hypothesis-003

EV販売が増加しても、車載半導体在庫調整、価格下落、製品ミックス、地域Exposureによって、半導体企業売上が減少する場合がある。

**Status**

HypothesisからInferenceへ昇格候補。

主要車載半導体企業の2025年売上動向との整合確認を継続する。

---

# 8. Candidate Observations（候補観測項目）

| Observation              | Description   |  Availability | Initial Importance | Evidence Status |
| ------------------------ | ------------- | ------------: | -----------------: | --------------- |
| Global EV Sales          | 世界EV販売台数      |          High |                  5 | High            |
| Global EV Sales Growth   | 世界EV販売成長率     |          High |                  5 | High            |
| EV Penetration           | 新車販売に占めるEV比率  |          High |                  5 | High            |
| Regional EV Sales        | 地域別EV販売台数     |          High |                  5 | High            |
| BEV Registrations        | BEV登録台数       |          High |                  5 | High            |
| PHEV Registrations       | PHEV登録台数      |        Medium |                  4 | Medium          |
| HEV Registrations        | HEV登録台数       |    High in EU |                  4 | High            |
| EV Production            | EV生産台数        |        Medium |                  4 | High            |
| Automotive Power Revenue | 車載Power半導体売上  |        Medium |                  5 | Medium          |
| Automotive MCU Revenue   | 車載MCU売上       | Low to Medium |                  4 | Medium          |
| BMS-related Revenue      | BMS関連売上       |           Low |                  4 | Low             |
| EV Semiconductor Content | EV1台当たり半導体搭載額 |           Low |                  5 | Low             |
| Company EV Guidance      | EV関連企業ガイダンス   |        Medium |                  4 | Medium          |

---

# 9. Observation Scope（観測範囲）

EV Transitionを一つの集計値だけで管理しない。

最低限、以下へ分解する。

```text
EV Transition
├── Global EV Sales
├── Regional EV Sales
│   ├── China
│   ├── Europe
│   ├── North America
│   └── Japan / Other Asia
├── Powertrain Mix
│   ├── BEV
│   ├── PHEV
│   ├── HEV
│   └── ICE
└── Semiconductor Impact
    ├── Power
    ├── MCU
    ├── Analog / Mixed-signal
    ├── BMS
    ├── Sensor
    └── Processor
```

---

# 10. Data Sources（データソース）

## Tier1

* 車載半導体メーカーAnnual Report
* 車載半導体メーカー決算説明資料
* 完成車メーカーIR
* 公式製品・Application資料

## Tier2

* IEA Global EV Outlook
* ACEA Registration Statistics
* 各国自動車工業会
* 官公庁自動車登録統計

## Tier3

* MarkLines
* IDC
* Gartner
* Deloitte
* McKinsey
* PwC

Tier3のみでKnowledgeを確定しない。

---

# 11. Acquisition Method（取得方法）

| Observation               | Acquisition Method | Automation Candidate |
| ------------------------- | ------------------ | -------------------- |
| Global EV Sales           | IEA年次資料            | Semi-auto            |
| EU EV Registrations       | ACEA月次統計           | Semi-auto            |
| Regional EV Sales         | 地域別業界統計            | Semi-auto            |
| Powertrain Mix            | ACEA・各国統計          | Semi-auto            |
| EV Production             | IEA年次資料            | Semi-auto            |
| Power / MCU / BMS Revenue | 企業IR抽出             | Manual / Semi-auto   |
| Company EV Guidance       | 決算資料レビュー           | Manual / AI-assisted |
| EV Semiconductor Content  | IR・業界資料            | Low                  |

---

# 12. Update Trigger（更新契機）

* ACEA月次登録統計更新
* IEA年次Global EV Outlook更新
* 各国自動車登録統計更新
* 車載半導体メーカー四半期決算
* 完成車メーカー四半期決算
* EV販売見通しの公式改定
* 補助金・規制・関税制度の重要変更
* 車載半導体在庫ガイダンス変更

---

# 13. Candidate Transformation Rules（変換ルール候補）

## Rule Candidate A：EV数量成長

```text
Regional EV Sales Growth
+
EV Penetration Increase
+
Stable Automotive Semiconductor Guidance

↓

EV Semiconductor Demand Positive Context
```

## Rule Candidate B：Power Semiconductor伝播

```text
BEV / PHEV Share Increase
+
Automotive Power Revenue Growth
+
Inventory Normalization

↓

Automotive Power Semiconductor Positive Context
```

## Rule Candidate C：需要と売上の乖離

```text
EV Sales Growth
+
Automotive Semiconductor Revenue Decline
+
Inventory Reduction Commentary

↓

End Demand Positive
but
Semiconductor Inventory Adjustment Ongoing
```

## Rule Candidate D：地域Exposure

```text
Regional EV Sales Growth
×
Company Regional Exposure
×
Company Automotive Product Exposure

↓

Company-specific EV Demand Context
```

すべてValidation前のRule Candidateであり、Knowledgeとしては未承認である。

---

# 14. Candidate Proxies（代替指標候補）

EV向け半導体搭載額を直接取得できない場合、以下をProxyとして検討する。

* BEV / PHEV / HEV販売構成比
* Automotive Power Semiconductor Revenue Growth
* Automotive MCU Revenue Growth
* Automotive Revenue Mix
* EV関連製品ガイダンス
* EV向けDesign Win（設計採用）コメント
* 車載Power・BMS関連製品投入状況
* EV生産台数成長率

---

# 15. Validation Plan（検証計画）

## Quantitative Validation（定量検証）

* EV Sales Growthと車載Power半導体企業売上成長率の比較
* EV PenetrationとAutomotive Revenue Mixの比較
* 地域別EV販売と企業地域Exposureの比較
* BEV / HEV / PHEV別の説明力比較
* Lead-Lag Analysis
* Walk Forward検証
* Regime別検証
* EV指標追加前後のML性能比較

## Decision Validation（判断検証）

* Power・Analog・MCU関連企業のCompany Score改善
* Advisor説明品質
* Portfolio EngineのSubSector配分改善
* Automotive Package全体への追加価値

## Rejection Criterion（不採用基準）

以下の場合、EV Transitionの重要度を下げる。

* EV販売と対象企業売上の関係に再現性がない
* Vehicle ProductionやCompany Guidanceの方が有効
* 地域Exposureを加えても説明力が低い
* 更新・取得コストに対して投資判断への寄与が小さい
* バックテストまたはWalk Forwardで安定した改善が確認できない

---

# 16. Expected Knowledge Destination（想定利用先）

| Destination                  |    Expected Importance |
| ---------------------------- | ---------------------: |
| Automotive Knowledge Package |                   High |
| Power Semiconductor Context  |                   High |
| MCU / Analog Context         |         Medium to High |
| Company Score                |                   High |
| Industry Score               |          Low to Medium |
| Advisor                      |                   High |
| ML Context                   | Experimental to Medium |
| Portfolio Engine             |                 Medium |

---

# 17. Initial Importance（初期重要度）

**Research Importance**: High within Automotive Package
**Industry-wide Importance**: Medium
**Current Evidence Quality**: Medium to High
**Observation Availability**: High for EV sales, Medium for semiconductor transmission

EV販売・普及率の観測可能性は高い。

一方で、EV販売から半導体企業売上へ変換するTransformation Ruleは未検証であるため、Operational Weightはまだ確定しない。

---

# 18. Reviewer Interim Judgment（中間レビュー）

## 判定

**Knowledge Object化候補として継続調査**

## Reviewer Comment

EV Transitionは、Vehicle ProductionよりもAutomotive Semiconductor Demandへの構造変化を説明できる可能性が高い。

特にPower Semiconductor、MCU、Analog、BMSへの投資Contextとして有望である。

ただし、以下を混同してはならない。

* EV市場が成長していること
* 車載半導体企業の売上が増加していること
* 特定企業の株価が上昇すること

これらはそれぞれ別の命題であり、独立して検証する必要がある。

現時点ではEV TransitionをIndustry全体の直接スコアへ強く反映せず、Automotive Package、SubSector Context、Company Scoreを主なDestinationとする。

---

# 19. Research Completion Checklist

* [x] 世界EV販売Source確認
* [x] 欧州Powertrain Mix Source確認
* [x] EV生産Source確認
* [x] Power・MCU・BMSへの製品伝播確認
* [ ] 中国・北米・日本の地域別統計確認
* [ ] BEV・PHEV・HEV別の半導体伝播比較
* [ ] 主要企業Automotive Revenueとの時系列比較
* [ ] Lead-Lag Analysis設計
* [ ] Transformation Rule検証
* [ ] Research Reviewer最終承認
* [ ] Knowledge Object昇格可否判断

---

# 20. Next Actions（次の作業）

1. 中国・北米・日本のEV販売およびPowertrain Mixの公開Sourceを確認する。
2. BEV・PHEV・HEVを同一Scoreに統合すべきか検討する。
3. Infineon・Renesas・NXP・STMicroelectronicsのAutomotive RevenueとEV販売の時系列比較方法を設計する。
4. Automotive Power Semiconductor Demand Researchへ進む。
5. EV Transitionを単独Knowledge Objectにするか、EV AdoptionとPower Semiconductor Transmissionへ分割するか最終判断する。
