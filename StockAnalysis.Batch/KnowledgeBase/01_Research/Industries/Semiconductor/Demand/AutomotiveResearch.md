# Automotive Research Sheet

**Research Domain**: Semiconductor Industry

**Research Category**: Demand Driver

**Research Status**: Evidence Collection

**Version**: 0.1

**Reviewer Status**: Pending

---

# 1. Purpose（目的）

本Research Sheetの目的は、自動車市場（Automotive）が半導体Industryに与える影響をEvidenceに基づいて分析し、将来的にOperational Knowledgeへ変換するための基礎情報を整理することである。

本Research SheetはKnowledgeではない。

本資料では

* Evidenceの収集
* Evidenceの比較
* Observation候補の整理
* Open Question（未解決事項）の整理

を行う。

Knowledge ObjectはResearch Reviewer承認後に作成する。

---

# 2. Research Questions（調査課題）

## RQ-001

Automotive市場は半導体Industry全体に対してどの程度重要なDemand Driverなのか。

---

## RQ-002

Automotive需要は

* Logic
* Memory
* Analog
* Power
* MCU
* Sensor
* Foundry
* Equipment

のどのSubSectorへ影響するか。

---

## RQ-003

EV

HEV

PHEV

ICE

では半導体需要構造はどのように異なるか。

---

## RQ-004

Automotive DemandはIndustry Cycleに対して

* Leading Indicator
* Coincident Indicator
* Lagging Indicator

のどれに該当するか。

---

## RQ-005

継続運用可能なObservationは何か。

---

## RQ-006

取得困難なObservationについてProxyを構築できるか。

---

# 3. Candidate Observations（候補Observation）

| Observation                       | Description    | Observation Type | Availability | Initial Importance | Current Evidence |
| --------------------------------- | -------------- | ---------------- | ------------ | -----------------: | ---------------- |
| Global Vehicle Production         | 世界自動車生産台数      | Quantitative     | High         |                  5 | Medium           |
| Global Vehicle Sales              | 世界販売台数         | Quantitative     | High         |                  5 | Medium           |
| EV Sales                          | EV販売台数         | Quantitative     | High         |                  5 | Medium           |
| HEV / PHEV Sales                  | HEV・PHEV販売台数   | Quantitative     | Medium       |                  4 | Low              |
| Semiconductor Revenue Mix         | 車載売上比率         | Quantitative     | Medium       |                  4 | Medium           |
| Semiconductor Content per Vehicle | 車両1台当たり半導体搭載額  | Quantitative     | Low          |                  5 | Low              |
| ADAS Adoption Rate                | ADAS搭載率        | Quantitative     | Low          |                  4 | Low              |
| OEM Guidance                      | 完成車メーカーガイダンス   | Qualitative      | Medium       |                  4 | Medium           |
| Automotive Semiconductor Guidance | 車載半導体メーカーガイダンス | Qualitative      | Medium       |                  4 | Medium           |

---

# 4. Candidate Evidence Sources（候補Evidence）

## Tier1（優先）

* 完成車メーカー統合報告書
* 完成車メーカー決算説明資料
* 完成車メーカー有価証券報告書
* 車載半導体メーカーIR
* 車載半導体メーカー決算説明資料

---

## Tier2

* WSTS
* SEMI
* SIA
* JEITA

---

## Tier2〜Tier3（レビュー後採用判断）

* OICA
* ACEA
* MarkLines
* IDC
* Gartner

---

# 5. Observation Acquisition Method（取得方法）

| Observation  | Acquisition Method   |
| ------------ | -------------------- |
| 生産台数         | 公開統計・業界団体            |
| 販売台数         | 公開統計・業界団体            |
| EV販売         | 業界統計                 |
| OEM Guidance | IRレビュー               |
| 車載売上比率       | 決算資料レビュー             |
| ADAS搭載率      | 業界調査・IR              |
| 半導体搭載額       | IR・調査会社資料（継続取得可否を確認） |

---

# 6. Update Trigger（更新契機）

* 四半期決算
* 決算説明資料公開
* 統合報告書公開
* 年次市場統計更新
* 中期経営計画更新

---

# 7. Initial Hypotheses（初期仮説）

## Hypothesis-001

Automotive需要はMemoryよりもPower・Analog・MCU・Sensorへの影響が大きい可能性がある。

**Status**

Hypothesis

**Evidence**

不足。

Knowledge登録不可。

---

## Hypothesis-002

Automotive DemandはIndustry全体では重要Demand Driverだが、AI Infrastructureほど市場全体を左右するかは未確定。

**Status**

Hypothesis

追加Evidenceが必要。

---

# 8. Open Questions（未解決事項）

* 車載半導体搭載額を継続取得できる情報源は存在するか。
* EV・HEV・ICEを個別Observationとすべきか。
* 地域別（中国・北米・欧州・日本）Observationを持つべきか。
* OEMよりTier1 Supplierの方が先行指標として有効か。
* 車載需要はEquipmentメーカーへどの程度伝播するか。

---

# 9. Candidate Proxies（代替指標候補）

取得困難なObservationについては以下を検討する。

* EV販売比率
* OEM設備投資
* 車載半導体売上比率
* 車載向け受注コメント
* ADAS関連売上

---

# 10. Research Completion Criteria（Definition of Done）

本Research Sheetは以下を満たした時点で完了とする。

* Tier1 Evidence収集完了
* Tier2 Evidence補完完了
* Observation確定
* Proxy定義完了
* Update Trigger確定
* Transformation Ruleを設計可能
* Research Reviewer承認

承認後、Knowledge Objectを作成する。

---

# 11. Reviewer Comments

**Current Review**

Pending

**Current Assessment**

Evidence収集中。

現時点ではAutomotiveをTier1 Demand Driverと断定するEvidenceは十分ではない。

Research継続。

---

# 12. Next Actions（次の作業）

1. OICA・主要完成車メーカーIRから生産・販売データを収集する。
2. Infineon、NXP、Renesas、Texas Instrumentsなど主要車載半導体メーカーのIRを調査する。
3. 車載半導体搭載額（Semiconductor Content per Vehicle）の継続取得可能性を調査する。
4. ObservationごとのTransformation Ruleを設計する。
5. Research Reviewerレビュー後、Knowledge Objectへ昇格可否を判断する。
