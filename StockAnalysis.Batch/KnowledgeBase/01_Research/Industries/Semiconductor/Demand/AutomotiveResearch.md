# Automotive Research Sheet

**Research Domain**: Semiconductor Industry
**Research Category**: Demand Driver
**Version**: 0.2
**Status**: Evidence Collection
**Reviewer Status**: Pending

# 1. Research Objective（研究目的）

Automotive Demand（自動車需要）が、半導体IndustryにおいてOperational Knowledgeとして採用可能なDemand DriverであるかをEvidenceに基づいて検証する。

本Researchの目的は、Automotive Demandを重要と決め打ちすることではない。

Evidenceにより、

* Knowledge Objectへ昇格できるか
* Context専用に留めるべきか
* 重要度を下げるべきか

を判断する。

---

# 2. Business Value（投資価値）

Automotive Demandは、以下への利用可能性を検証する。

| Destination      | Expected Usage                |
| ---------------- | ----------------------------- |
| Industry Score   | 半導体需要の一部として反映                 |
| Company Score    | 車載比率が高い企業の評価補正                |
| Advisor          | 車載需要・EV・ADAS・Power半導体の説明      |
| ML Context       | Automotive exposure feature候補 |
| Portfolio Engine | Semiconductor内のSubSector配分補助  |

---

# 3. Research Questions（調査課題）

## RQ-001

Automotive市場は半導体Industry全体に対してどの程度重要なDemand Driverなのか。

## RQ-002

Automotive需要は、Power、Analog、MCU、Sensor、Logic、Memory、Equipmentのどこへ強く影響するか。

## RQ-003

EV・HEV・PHEV・ICEでは、半導体需要構造はどう異なるか。

## RQ-004

Automotive DemandはIndustry Cycleに対してLeading Indicator、Coincident Indicator、Lagging Indicatorのどれに近いか。

## RQ-005

継続運用可能なObservationは何か。

---

# 4. Candidate Observations（候補Observation）

| Observation                       | Description    | Type         | Availability | Initial Importance | Evidence Status |
| --------------------------------- | -------------- | ------------ | ------------ | ------------------ | --------------- |
| Global Vehicle Production         | 世界自動車生産台数      | Quantitative | High         | 5                  | Medium          |
| Global Vehicle Sales              | 世界自動車販売台数      | Quantitative | High         | 5                  | Medium          |
| EV Sales                          | EV販売台数         | Quantitative | High         | 5                  | Medium          |
| HEV / PHEV Sales                  | HEV・PHEV販売台数   | Quantitative | Medium       | 4                  | Low             |
| Automotive Semiconductor Revenue  | 車載半導体売上        | Quantitative | Medium       | 5                  | Medium          |
| Semiconductor Revenue Mix         | 車載売上比率         | Quantitative | Medium       | 4                  | Medium          |
| Semiconductor Content per Vehicle | 車両1台当たり半導体搭載額  | Quantitative | Low          | 5                  | Low             |
| ADAS Adoption Rate                | ADAS搭載率        | Quantitative | Low          | 4                  | Low             |
| Automotive Guidance               | 車載半導体メーカーガイダンス | Qualitative  | Medium       | 4                  | Medium          |

---

# 5. Current Evidence Summary（現在のEvidence要約）

## Fact

NXPは2025年Annual Reportで、Automotive end market revenueが7,116百万ドルで、前年比35百万ドル減、0.5%減だったと開示している。減少要因はprocessors、相殺要因はmixed-signal productsの成長とされている。([NXP](https://www.nxp.com/docs/en/supporting-information/NXPFRS2025.pdf?utm_source=chatgpt.com))

## Fact

Texas Instrumentsは2025年Annual Reportで、2025年売上の約75%がIndustrial、Automotive、Data Center市場から来ていると説明している。TIは、多数の用途に分散した売上基盤を持つことを意図的な戦略としている。([Texas Instruments](https://investor.ti.com/static-files/fc9d9346-cf77-40db-902a-e9961e9c5736?utm_source=chatgpt.com))

## Fact

RenesasのIRページでは、2026年2Q決算発表予定、2026 Capital Market Day、2025年通期決算関連資料などが確認できる。Renesasは車載MCU、アナログ、パワー、SoCを扱う主要候補企業として継続調査対象とする。([ルネサス](https://www.renesas.com/en/about/investor-relations?srsltid=AfmBOoqeXVYdSDGlqiZDCFJzojr97YJnVetApB-xvb8tETn3mizlFQnT&utm_source=chatgpt.com))

## Fact

IDCはAutomotive Semiconductor Marketについて2025年成長を予測している一方、Industrial Semiconductor Marketは2025年前半に回復したと述べている。([AlphaSense](https://www.alpha-sense.com/earnings/nxpi/?utm_source=chatgpt.com))

---

# 6. Inference（Evidenceに基づく推論）

## Inference-001

Automotive Demandは、半導体Industryにおいて独立したDemand Driver候補として扱う価値がある。

**Reason**

NXPのようにAutomotive end marketを明示的に開示する半導体企業があり、TIもIndustrial・Automotive・Data Centerを主要市場群として説明しているため。

**Constraint**

現時点では、半導体市場全体におけるAutomotiveの相対重要度をAI / Data Centerと比較できるだけのEvidenceは不足している。

---

## Inference-002

Automotive Demandは、MemoryよりもPower、Analog、MCU、Mixed-signal、Sensorへの影響が大きい可能性がある。

**Reason**

NXPのAutomotive減収要因と相殺要因の説明で、processorsとmixed-signal productsが明示されている。また、TIもIndustrial・Automotive・Data Centerを主要市場として扱うが、用途分散型のAnalog / Embedded中心企業である。

**Status**

Inference。Knowledge登録前に追加Evidenceが必要。

---

# 7. Hypothesis（仮説）

## Hypothesis-001

EV・ADASの普及により、車両1台当たり半導体搭載額は長期的に増加する可能性がある。

**Status**

Hypothesis。

**Reason**

一般的には妥当な可能性があるが、現時点では本Research Sheet内で十分な一次Evidenceを確認していない。

**Action**

主要車載半導体企業IR、完成車メーカーIR、業界統計で検証する。

---

## Hypothesis-002

Automotive Demandは、短期的には在庫調整・完成車生産・EV販売動向の影響を受けるため、AI InfrastructureよりもCycle変動が大きい可能性がある。

**Status**

Hypothesis。

**Action**

複数年の売上推移、在庫コメント、ガイダンスの確認が必要。

---

# 8. Candidate Evidence Sources（候補Evidence）

## Tier1

* Renesas IR
* Infineon Annual Report / Quarterly Results
* NXP Annual Report / Quarterly Results
* Texas Instruments Annual Report / Quarterly Results
* STMicroelectronics Annual Report / Quarterly Results
* Toyota / Volkswagen / BYD / Tesla等の完成車メーカーIR

## Tier2

* WSTS
* SEMI
* SIA
* JEITA
* OICA
* ACEA

## Tier3

* IDC
* Gartner
* McKinsey
* Deloitte
* PwC
* MarkLines

---

# 9. Observation Acquisition Method（取得方法）

| Observation                       | Acquisition Method      | Automation Candidate |
| --------------------------------- | ----------------------- | -------------------- |
| Automotive Semiconductor Revenue  | 半導体メーカーIR・Annual Report | Semi-auto            |
| Automotive Revenue Mix            | セグメント開示・IR              | Semi-auto            |
| Vehicle Sales                     | 業界統計                    | Semi-auto            |
| EV Sales                          | 業界統計                    | Semi-auto            |
| OEM Guidance                      | 完成車メーカーIR               | Manual / Semi-auto   |
| Semiconductor Content per Vehicle | 業界資料・IR                 | Low                  |
| ADAS Adoption                     | 業界資料・IR                 | Low                  |

---

# 10. Update Trigger（更新契機）

* 半導体メーカー四半期決算
* 半導体メーカーAnnual Report公開
* 完成車メーカー四半期決算
* 業界統計更新
* 中期経営計画更新
* 重要なガイダンス変更

---

# 11. Candidate Proxies（代替指標候補）

* Automotive Semiconductor Revenue Growth
* Automotive Revenue Mix
* EV Sales Growth
* Vehicle Production Growth
* 車載向けガイダンスコメント
* Mixed-signal / Power / MCU関連売上成長

---

# 12. Open Questions（未解決事項）

* 車両1台当たり半導体搭載額を継続取得できる公開Sourceはあるか。
* Automotiveを単一Demand Driverとして扱うべきか、EV / ADAS / ICE / HEVに分解すべきか。
* Automotive DemandはEquipment需要へどの程度・どの遅行期間で伝播するか。
* 車載需要は半導体Industry全体よりも、Power・Analog・MCU企業のCompany Scoreで使う方が有効か。
* 自動車生産台数と車載半導体売上のどちらが投資判断に有効か。

---

# 13. Expected Knowledge Object（想定Knowledge Object）

現時点では以下を候補とする。

* Automotive Demand
* EV Semiconductor Demand
* Automotive Power Semiconductor Demand
* Automotive MCU / Mixed-signal Demand

ただし、Knowledge Object化は追加EvidenceとReviewer承認後に判断する。

---

# 14. Expected Knowledge Destination（想定利用先）

| Destination      | Expected Usage                                    |
| ---------------- | ------------------------------------------------- |
| Industry Score   | Automotive需要を半導体需要Contextとして反映                    |
| Company Score    | Renesas、Infineon、NXP、TIなどの車載Exposure評価            |
| Advisor          | 車載需要の追い風・逆風説明                                     |
| ML Context       | AutomotiveExposure、EVExposureなどのContext Feature候補 |
| Portfolio Engine | Semiconductor内のSubSector配分補助                      |

---

# 15. Validation Plan（検証計画）

Knowledge化後、以下で有効性を検証する。

* Automotive Exposure別リターン比較
* Walk Forward検証
* Feature Importance確認
* 市況別・Regime別検証
* 半導体SubSector別成績比較
* Advisor説明品質評価

---

# 16. Research Success Criteria（Research成功条件）

このResearchは、以下のいずれかで成功とする。

## Success Pattern A

Automotive DemandがOperational Knowledgeとして採用可能であることをEvidenceで確認できる。

## Success Pattern B

Automotive Demandは重要だが、Company ScoreやSubSector Context限定で使うべきと判断できる。

## Success Pattern C

Automotive Demandは継続取得・Validation上の制約が大きく、Knowledge Object化を見送るべきと判断できる。

Knowledgeが増えない場合でも、Evidenceに基づいて不採用判断ができればResearch成功とする。

---

# 17. Research Completion Checklist

* [ ] Tier1 Evidence収集
* [ ] Tier2 Evidence補完
* [ ] Observation確定
* [ ] Proxy定義
* [ ] Update Trigger確定
* [ ] Transformation Rule設計可能
* [ ] Research Reviewer承認
* [ ] Knowledge Object昇格可否判断

---

# 18. Reviewer Comments

## Current Review

Pending

## Current Assessment

Automotive DemandはDemand Driver候補として有望だが、現時点ではAI InfrastructureほどEvidenceが強くない。

特に、車載半導体搭載額、EV・ADASの半導体需要への寄与、Equipment需要への伝播について追加Evidenceが必要。

---

# 19. Next Actions（次の作業）

1. Renesasの2025年通期決算資料・Capital Market Day資料を確認する。
2. Infineon Automotive segmentの最新Annual Reportを確認する。
3. STMicroelectronicsのAutomotive関連開示を確認する。
4. 車両生産・EV販売に関するTier2 Sourceを確認する。
5. Automotive Demandを単一Knowledge Objectにするか、EV / ADAS / Power / MCUに分割するか判断する。

# 追記：Tier1 Evidence追加

## Renesas Evidence

### Fact

Renesasは2025年通期Financial Reportで、Automotive BusinessのNon-GAAP revenueが639.7 billion yen、前年比63.1 billion yen減、9.0%減だったと開示している。減少理由はmarket softeningとされている。

### Fact

RenesasはAutomotive領域で、MCU、SoC、Analog semiconductor devices、Power semiconductor devicesを供給している。

### Inference

Renesasの開示から、Automotive DemandはMCU、SoC、Analog、Powerへの影響が大きいDemand Driver候補と判断できる。

ただし、2025年は減収であり、Automotive Demandを単純に成長ドライバーとは扱えない。

---

## NXP Evidence

### Fact

NXPは2025年Annual Reportで、Automotive end market revenueが7,116 million USD、前年比35 million USD減、0.5%減だったと開示している。減少要因はprocessors、相殺要因はmixed-signal productsの成長とされている。

### Inference

NXPの開示は、Automotive DemandがProcessorおよびMixed-signal領域に直接影響することを示すEvidenceとして利用できる。

---

## STMicroelectronics Evidence

### Fact

STMicroelectronicsは2025年にRevenue 11.8 billion USDを記録した。

### Fact

報道ベースでは、STMicroelectronicsは2025年にAutomotive、Industrial、Consumer chip marketsの弱需要と高在庫の影響を受けたとされる。

### Reviewer Note

STMicroelectronicsについては、現時点では一次資料からAutomotive segmentの詳細数値を十分確認できていない。

したがって、現段階ではFactとしては限定的に扱い、Automotive Demandの強いEvidenceとしてはまだ採用しない。

---

## Texas Instruments Evidence

### Fact

Texas Instrumentsは2025年Annual Reportで、2025年売上の約75%がIndustrial、Automotive、Data Center市場から来ていると説明している。

### Inference

TIの開示は、AutomotiveがAnalog / Embedded系半導体企業にとって主要End Marketの一部であることを示すEvidenceとして利用できる。

ただし、Industrial・Automotive・Data Centerがまとめて記載されているため、Automotive単独の寄与度を分離するには追加Evidenceが必要。

---

# Updated Assessment

## Fact-based Assessment

Automotive Demandは、少なくとも以下の領域に影響するDemand Driver候補である。

* MCU
* SoC
* Analog
* Power
* Mixed-signal
* Processor

## Inference

Automotive Demandは、MemoryやLogic全体よりも、MCU・Analog・Power・Mixed-signal系企業のCompany ScoreやSubSector Contextで有効に使える可能性が高い。

## Constraint

2025年のRenesas・NXPの開示を見る限り、Automotive Demandは一方向の成長ドライバーではなく、在庫調整・市場軟化・製品ミックスの影響を受けるCyclical Demand Driverとして扱う必要がある。

---

# Updated Research Status

| Item                           | Status         |
| ------------------------------ | -------------- |
| Demand Driver候補                | Yes            |
| Tier1 Evidence                 | Partial        |
| AI Infrastructure並みのEvidence強度 | No             |
| Company Score利用可能性             | High           |
| Industry Score利用可能性            | Medium         |
| Knowledge Object化              | 追加Evidence後に判断 |
| Current Evidence Quality       | Medium         |

---

# Updated Next Actions

1. Infineon Automotive segmentのAnnual Report・決算資料を確認する。
2. STMicroelectronicsのAutomotive関連売上・在庫コメントを一次資料で確認する。
3. Automotiveを単一Knowledge Objectにするか、Automotive MCU / Power / Mixed-signalへ分解するか判断する。
4. Vehicle Sales、EV Sales、ADAS AdoptionのTier2 Evidenceを確認する。

# 追記：Automotive Tier1 / Tier2 Evidence追加 v0.3

## Infineon Evidence

### Fact

Infineonは2025年度Annual Reportで、Automotive segment revenueが7,402百万ユーロ、前年比4%減だったと開示している。Automotive segmentはInfineon全体売上の50%を占める。
Source: Infineon Annual Report 2025.

### Inference

InfineonにおいてAutomotiveは極めて重要なEnd Marketである。

ただし、2025年度は減収であり、Automotiveを単純な成長Driverとして扱うのではなく、Cyclical Demand Driverとして扱う必要がある。

---

## Renesas Evidence

### Fact

Renesasは2025年通期Financial Reportで、Automotive BusinessのNon-GAAP revenueが639.7 billion yen、前年比63.1 billion yen減、9.0%減だったと開示している。減少理由はmarket softeningとされている。
Source: Renesas Financial Report 2025.

### Fact

RenesasはAutomotive Businessで、MCU、SoC、Analog semiconductor devices、Power semiconductor devicesを主に供給している。
Source: Renesas Financial Report 2025.

### Inference

Renesasの開示から、Automotive DemandはMCU、SoC、Analog、Powerに強く関係するDemand Driver候補と判断できる。

一方で、2025年は減収であり、Automotive Demandは短期的には市場軟化や在庫調整の影響を受ける。

---

## NXP Evidence

### Fact

NXPは2025年Annual Reportで、Automotive end market revenueが7,116百万ドル、前年比35百万ドル減、0.5%減だったと開示している。減少要因はprocessorsで、mixed-signal productsの成長が一部相殺した。
Source: NXP Annual Report 2025.

### Inference

NXPの開示は、Automotive Demandがprocessorsおよびmixed-signal productsに直接影響するEvidenceとして利用できる。

ただし、2025年はほぼ横ばいであり、強い成長Driverとは断定しない。

---

## STMicroelectronics Evidence

### Fact

STMicroelectronicsは2025年Q1決算資料で、Automotive end market revenueが前年同期比39%減だったと開示している。Industrialは32%減、Personal Electronicsは11%減だった。
Source: STMicroelectronics Q1 2025 Financial Results.

### Fact

2025年Q3決算発表では、STMicroelectronicsはQ3 net revenues 3.19 billion USD、gross margin 33.2%を報告している。
Source: STMicroelectronics Q3 2025 Financial Results.

### Inference

STMicroelectronicsの開示から、Automotive需要は2025年に強い調整局面にあった可能性が高い。

Automotive Demandは長期的には重要でも、短期では在庫調整・顧客需要鈍化・製品ミックスに大きく左右される。

---

## Vehicle Production / Sales Evidence

### Fact

OICAは2025年の世界自動車生産について、2024年の92.7百万台から2025年は96.4百万台へ増加、世界販売は95.3百万台から99.8百万台へ増加したと説明している。
Source: OICA 2025.

### Fact

ACEAは2025年の世界乗用車登録が3.5%増の77.6百万台、世界自動車生産が4.2%増の78.7百万台だったと説明している。
Source: ACEA Global and EU Auto Industry Report 2025.

### Inference

Vehicle Production / SalesはAutomotive DemandのObservationとして採用可能である。

ただし、車両台数そのものは半導体需要を完全には表さない。EV比率、ADAS普及率、1台当たり半導体搭載額を併せて観測する必要がある。

---

## EV Sales Evidence

### Fact

IEA Global EV Outlook 2026は、欧州の電気自動車販売が2025年に前年比30%以上増加し、4.2百万台、全新車販売の28%に達したと説明している。
Source: IEA Global EV Outlook 2026.

### Fact

ACEAは2025年のEU battery-electric car registrationsが1,880,370台、EU market share 17.4%だったと説明している。
Source: ACEA New Car Registrations 2025.

### Inference

EV SalesはAutomotive Semiconductor Demandの重要Observation候補である。

ただし、EV Sales単独ではPower semiconductor、MCU、Analog、Sensor、Battery Management Systemへの寄与を分離できないため、Company ResearchまたはSubSector Knowledgeで補完する必要がある。

---

# Updated Assessment v0.3

## Fact-based Assessment

Automotive Demandは、少なくとも以下の半導体領域に強く関係するDemand Driver候補である。

* MCU
* SoC
* Analog
* Power
* Mixed-signal
* Processor
* Sensor

## Inference

Automotive Demandは、Semiconductor Industry全体の単独Tier1 Driverとして扱うよりも、以下で使う方が現時点では妥当である。

* Company Score
* SubSector Context
* Automotive Exposure Feature
* Power / Analog / MCU関連企業のAdvisor説明

## Constraint

2025年のInfineon、Renesas、NXP、STMicroelectronicsの開示を見る限り、Automotive需要は成長一辺倒ではなく、market softening、在庫調整、顧客需要鈍化、製品ミックス変化の影響を受ける。

したがって、Automotive Demandは **Structural Growth Driver** ではなく、現時点では **Cyclical / Structural Hybrid Driver** として扱う。

---

# Updated Observation Assessment

| Observation                       | Status | Comment                       |
| --------------------------------- | ------ | ----------------------------- |
| Global Vehicle Production         | 採用候補   | OICA・ACEAで継続観測可能              |
| Global Vehicle Sales              | 採用候補   | OICA・ACEAで継続観測可能              |
| EV Sales                          | 採用候補   | IEA・ACEAで観測可能                 |
| Automotive Semiconductor Revenue  | 採用候補   | NXP・Renesas・Infineon等のIRで観測可能 |
| Automotive Revenue Mix            | 採用候補   | 企業によって開示差あり                   |
| Semiconductor Content per Vehicle | 要追加調査  | 継続取得可能な公開Sourceが未確定           |
| ADAS Adoption Rate                | 要追加調査  | 継続取得可能な公開Sourceが未確定           |
| Automotive Guidance               | 採用候補   | IRレビューが必要                     |

---

# Updated Research Status

| Item                           | Status             |
| ------------------------------ | ------------------ |
| Demand Driver候補                | Yes                |
| Tier1 Evidence                 | Partial → Improved |
| AI Infrastructure並みのEvidence強度 | No                 |
| Company Score利用可能性             | High               |
| SubSector Context利用可能性         | High               |
| Industry-wide Score利用可能性       | Medium             |
| Knowledge Object化              | 可能。ただし分解推奨         |
| Current Evidence Quality       | Medium to High     |

---

# Reviewer Interim Judgment

Automotive DemandはKnowledge Object化可能である。

ただし、単一の「Automotive Demand」として扱うより、以下へ分解することを推奨する。

1. Automotive Semiconductor Demand
2. EV Semiconductor Demand
3. Automotive Power Semiconductor Demand
4. Automotive MCU / Mixed-signal Demand

特にCompany ScoreとAdvisorでは、Renesas、Infineon、NXP、Texas Instruments、STMicroelectronicsなどのAutomotive Exposure評価に有効と考えられる。

一方で、Industry-wide Driverとしての重要度はAI Infrastructureより低く設定するべきである。
