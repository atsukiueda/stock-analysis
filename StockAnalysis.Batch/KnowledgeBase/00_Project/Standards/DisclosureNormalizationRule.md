# Disclosure Normalization Rule

**Document Type**: Knowledge Standard
**Version**: 0.1
**Status**: Draft for Review
**Applies To**: Industry Research / Company Research / Knowledge Object / Catalog / Advisor / ML
**Last Updated**: 2026-07-11

---

# 1. Purpose（目的）

本ドキュメントは、企業ごとに異なるDisclosure（情報開示）の粒度・定義・頻度を正規化し、開示差によって企業評価や投資判断が歪むことを防止するための標準ルールを定義する。

本プロジェクトでは、以下を明確に区別する。

```text
Disclosure Quality（開示品質）
≠
Business Quality（事業品質）
≠
Investment Quality（投資品質）
```

開示情報が詳細な企業を、開示が少ない企業より自動的に高く評価してはならない。

開示状況は、Knowledge Confidence（Knowledgeの信頼度）やData Availability（データ利用可能性）には反映できるが、企業の投資魅力度へ直接加点してはならない。

---

# 2. Scope（適用範囲）

本ルールは、以下の情報へ適用する。

* Automotive Revenue
* SubSector Revenue
* Product Category Revenue
* SiC Revenue
* Power Semiconductor Revenue
* Segment Inventory
* CapEx
* Design Win
* Mass Production Start
* Company Guidance
* Market Share
* Customer Concentration
* Capacity / Utilization
* その他、企業間で開示定義が異なるObservation

対象レイヤーは以下とする。

| Layer            | Application                |
| ---------------- | -------------------------- |
| Research Sheet   | Evidence収集・比較              |
| Knowledge Object | Observation・Transformation |
| Catalog          | データ状態・利用可能性管理              |
| Company Score    | 企業評価への利用                   |
| Advisor          | 説明文生成                      |
| ML               | 特徴量・欠損値処理                  |
| Portfolio Engine | 投資判断補助                     |

---

# 3. Core Principles（中核原則）

## 3.1 Non-disclosure Is Not Zero（非開示はゼロではない）

非開示項目を数値ゼロとして扱ってはならない。

```text
Not Disclosed ≠ Zero
```

例えば、企業がSiC Revenueを開示していない場合、

```text
SiC Revenue = 0
```

とは解釈しない。

正しくは、

```text
SiC Revenue Status = Not Disclosed
```

として扱う。

---

## 3.2 Absence of Evidence Is Not Evidence of Absence

（Evidenceがないことは、不存在のEvidenceではない）

開示がないことを理由に、

* 事業が存在しない
* 売上が小さい
* 競争力が低い
* 投資価値が低い

と判断してはならない。

開示がない場合に判断できるのは、

> 現在利用可能なEvidenceでは確認できない

という点のみである。

---

## 3.3 Disclosure Quality Must Not Directly Increase Investment Score

（開示品質を投資スコアへ直接加点しない）

開示粒度が高い企業はResearch・Advisor・MLで扱いやすい。

しかし、それはBusiness QualityまたはInvestment Qualityとは別である。

開示品質は以下へ利用する。

* Knowledge Confidence
* Evidence Confidence
* Observation Availability
* Review Priority
* Manual Review Requirement

以下へ直接利用しない。

* Company Score加点
* Buy / Hold判定
* Expected Return
* Portfolio Weight
* ML Target

---

## 3.4 Compare Direction and Change Before Absolute Values

（絶対値より方向性・変化を優先する）

企業間で会計基準・事業区分・通貨・開示定義が異なる場合、絶対金額を直接比較しない。

優先順位は以下とする。

1. 同一企業内での時系列変化
2. 成長率
3. 構成比の変化
4. ガイダンス方向
5. 在庫・CapEx・利益率との整合性
6. 企業間の絶対額比較

---

## 3.5 Do Not Force False Comparability

（誤った比較可能性を作らない）

定義が異なるデータを、見かけ上同じ項目として統合してはならない。

例：

* Infineon Automotive Power Revenue
* ROHM Discrete Semiconductor Automotive Mix
* ST SiC Revenue
* onsemi Automotive Revenue

これらは関連するが、同一指標ではない。

共通化する場合は、上位概念へ変換する。

例：

```text
Company-specific Automotive Power Observation
```

ただし、変換前の原データと定義を追跡可能にする。

---

# 4. Disclosure Status（開示状態）

Observationごとに、以下の状態を必ず保持する。

| Status               | 日本語        | Definition          |
| -------------------- | ---------- | ------------------- |
| Reported             | 開示済み       | 企業公式資料で明示された値または記述  |
| Derived              | 算出値        | 複数の開示値から算出した値       |
| Estimated Proxy      | 推定Proxy    | 直接開示がなく、代替指標から推定した値 |
| Not Disclosed        | 非開示        | 対象項目が資料内で開示されていない   |
| Not Applicable       | 非該当        | 企業の事業構造上、対象項目が該当しない |
| Not Yet Reviewed     | 未レビュー      | 資料は存在するが未確認         |
| Definition Changed   | 定義変更       | 過去期間と定義が変更された       |
| Discontinued         | 開示終了       | 過去には開示されたが現在は開示されない |
| Conflicting Evidence | Evidence競合 | 複数資料間で定義・値が一致しない    |

---

# 5. Data Lineage（データ系譜）

すべての正規化データについて、以下を追跡可能にする。

| Item                | Description                                               |
| ------------------- | --------------------------------------------------------- |
| Source Company      | 情報開示企業                                                    |
| Source Document     | 資料名                                                       |
| Source Type         | Annual Report / Quarterly Results / IR / Official Release |
| Publication Date    | 公開日                                                       |
| Applicable Period   | 対象期間                                                      |
| Original Label      | 原文の項目名                                                    |
| Original Definition | 原文定義                                                      |
| Original Value      | 原値                                                        |
| Original Unit       | 原単位                                                       |
| Currency            | 通貨                                                        |
| Normalized Concept  | 正規化後の概念                                                   |
| Transformation Rule | 適用した変換ルール                                                 |
| Disclosure Status   | 開示状態                                                      |
| Reviewer Status     | レビュー状況                                                    |
| As Of Date          | 利用可能時点                                                    |

原値を上書きせず、Original ValueとNormalized Valueを分離する。

---

# 6. Normalization Levels（正規化レベル）

## Level 0：Raw Disclosure（原開示）

企業資料から取得した原情報。

例：

```text
Automotive Power Revenue: EUR 1,773 million
```

変換を行わず保存する。

---

## Level 1：Within-company Normalization（企業内正規化）

同一企業内で時系列比較できる形式へ統一する。

例：

* 通貨単位統一
* 百万単位への変換
* 会計年度統一
* 前年同期比
* 売上構成比
* 在庫増減率
* CapEx増減率

企業内比較を主目的とする。

---

## Level 2：Concept Normalization（概念正規化）

異なる企業開示を、上位の共通概念へマッピングする。

例：

| Company Disclosure                | Normalized Concept              |
| --------------------------------- | ------------------------------- |
| Infineon Automotive Power Revenue | Automotive Power Exposure       |
| ROHM Discrete Automotive Mix      | Automotive Power Exposure       |
| ST SiC Revenue                    | Automotive Power / SiC Exposure |
| onsemi Automotive Revenue         | Automotive Exposure             |

ただし、元の定義差は保持する。

---

## Level 3：Comparable Context（比較可能Context）

共通Observationと企業固有Observationを統合し、比較可能なContextへ変換する。

例：

```text
Revenue Trend
+
Inventory Trend
+
Guidance Direction
+
CapEx Direction
+
Commercialization Evidence
+
Disclosure Confidence

↓

Company-specific Automotive Power Context
```

Level 3はInvestment Scoreではなく、まずContextとして利用する。

---

# 7. Common Observation Set（共通観測セット）

企業横断で可能な限り取得する最低共通Observationは以下とする。

| Observation                   | Initial Adoption      |
| ----------------------------- | --------------------- |
| Total Revenue Growth          | Adopt                 |
| Automotive Revenue Growth     | Adopt where available |
| Automotive Revenue Mix        | Conditional           |
| Inventory Growth              | Adopt                 |
| CapEx Growth                  | Adopt                 |
| Automotive Guidance Direction | Adopt                 |
| Power / SiC Commentary        | Adopt                 |
| Design Win                    | Low Weight            |
| Mass Production Start         | Medium Weight         |
| Regional Demand Commentary    | Adopt                 |
| Profitability Trend           | Adopt                 |

開示されない項目はNot Disclosedとして管理する。

---

# 8. Company-specific Observation（企業固有観測）

企業固有の開示は、共通スコアへ無理に統合しない。

例：

## Infineon

* Automotive Power Revenue
* Automotive Segment Inventory
* Automotive Product Category Revenue

## ROHM

* Discrete Semiconductor Automotive Mix
* SiC Device Commentary
* SiC Substrate Commentary

## STMicroelectronics

* SiC Revenue
* 200mm SiC CapEx
* Smart Mobility Commentary

## onsemi

* Automotive Revenue Breakdown
* Intelligent Power Revenue
* SiC-related Guidance

企業固有Observationは、Company Score・Advisor・Company Researchで優先利用する。

---

# 9. Disclosure Confidence（開示信頼度）

Disclosure Confidenceは、Observationがどの程度一貫して取得可能かを示す。

## 9.1 Evaluation Factors（評価要素）

| Factor                     | Description      |
| -------------------------- | ---------------- |
| Source Authority           | Tier1公式資料か       |
| Definition Stability       | 定義が期間を通じて安定しているか |
| Update Consistency         | 定期的に更新されるか       |
| Granularity                | 投資判断に必要な粒度か      |
| Historical Coverage        | 過去データが継続して存在するか  |
| Cross-document Consistency | 資料間で整合しているか      |
| Review Completeness        | Reviewer確認済みか    |

## 9.2 Confidence Levels（信頼度区分）

| Level        | Definition              |
| ------------ | ----------------------- |
| Very High    | Tier1、定義安定、定期更新、長期時系列あり |
| High         | Tier1中心、比較的安定、時系列取得可能   |
| Medium       | Tier1だが不定期、定義差または粒度制約あり |
| Low          | 断片的開示、継続取得困難            |
| Experimental | Proxy・推定中心で未検証          |

Disclosure Confidenceは投資スコアではなく、Knowledge利用上限を決める。

---

# 10. Usage Limits by Confidence（信頼度別利用制限）

| Confidence   | Advisor        | Company Score | ML         | Portfolio |
| ------------ | -------------- | ------------- | ---------- | --------- |
| Very High    | 利用可            | 利用可           | 候補         | 候補        |
| High         | 利用可            | 条件付き利用        | 実験利用       | 条件付き      |
| Medium       | Context利用      | 低Weight       | 原則実験       | 原則不使用     |
| Low          | 注記付き説明のみ       | 不使用           | 不使用        | 不使用       |
| Experimental | Hypothesis表示のみ | 不使用           | Researchのみ | 不使用       |

ML利用には、Disclosure Confidenceとは別にValidationが必要である。

---

# 11. Missing Data Rule（欠損データ規則）

## 11.1 Prohibited Handling（禁止）

以下は禁止する。

```text
Not Disclosed → 0
Not Reviewed → 0
Definition Changed → Previous Value Copy
Missing Value → Peer Average without Label
```

## 11.2 Allowed Handling（許可）

以下は条件付きで許可する。

* Missing Indicator Flag
* Disclosure Status Feature
* Company-specific Model
* Proxy with Explicit Label
* Manual Review
* Feature Exclusion
* Model-specific Imputation after Validation

欠損補完を行う場合は、補完前の状態を保持する。

---

# 12. Proxy Rule（Proxy利用規則）

Proxyは、以下をすべて満たす場合のみ利用する。

1. 直接Observationの取得が困難である。
2. 投資上の因果関係または関連性が説明できる。
3. Evidenceが存在する。
4. Proxyであることを明記する。
5. Validation方法が定義される。
6. 直接値が取得できた場合に再評価する。
7. Proxyの重要度を直接値と同等にしない。

ProxyはFactではなく、DerivedまたはEstimated Proxyとして管理する。

---

# 13. Currency and Fiscal Period Rule（通貨・会計期間規則）

## Currency（通貨）

企業間比較では、原通貨を保持する。

必要に応じて共通通貨へ変換するが、以下を記録する。

* Exchange Rate Source
* Exchange Rate Date
* Average / Closing Rate
* Conversion Method

ただし、方向性・成長率比較では原通貨を優先する。

## Fiscal Period（会計期間）

以下を区別する。

* Calendar Year
* Fiscal Year
* Quarter
* Trailing Twelve Months
* Year-to-date

異なる期間を同一時点の値として比較してはならない。

---

# 14. Definition Change Rule（定義変更規則）

企業がSegment・Product Category・Revenue Breakdownの定義を変更した場合、

以下を実施する。

1. Definition Changedとして記録する。
2. 変更前後を直接連結しない。
3. 企業が過去データを再表示している場合のみ再構築する。
4. 再表示がない場合、時系列を分割する。
5. Advisor説明で比較制約を明記する。
6. ML Featureとして利用する場合は期間分割または除外を検討する。

---

# 15. Disclosure Adjustment（開示差調整）

Disclosureの多い企業が有利にならないよう、以下を分離する。

```text
Investment Assessment
+
Knowledge Confidence
+
Disclosure Completeness
```

## Investment Assessment

* 業績
* 競争力
* 収益性
* 成長性
* バリュエーション
* リスク

## Knowledge Confidence

* Evidence品質
* 定義安定性
* 更新性
* Validation状況

## Disclosure Completeness

* 必要項目の開示率
* 履歴取得率
* Review完了率

Disclosure Completenessは独立表示し、Investment Assessmentへ直接加算しない。

---

# 16. Advisor Usage Rule（Advisor利用規則）

Advisorは、Disclosure Statusに応じて表現を変更する。

## Reported

> 企業は車載Power売上の増加を開示しています。

## Derived

> 開示された数値から算出すると、車載売上構成比は上昇しています。

## Estimated Proxy

> 直接開示はありませんが、関連売上・ガイダンスから需要改善が示唆されます。

## Not Disclosed

> 対象項目は開示されていないため、直接評価できません。

## Conflicting Evidence

> 資料間で定義または数値が一致しないため、現時点では評価を保留します。

Advisorは非開示を否定的評価として表現してはならない。

---

# 17. ML Usage Rule（ML利用規則）

MLでは以下を区別する。

* Observed Value
* Derived Value
* Proxy Value
* Missing Flag
* Disclosure Confidence
* Definition Version

以下を検証する。

* Proxy導入前後の性能
* Missing Flagの重要度
* 開示企業へのSelection Bias（選択バイアス）
* 大企業・海外企業への偏り
* 開示変更によるData Drift（データドリフト）
* Point-in-time整合性
* Walk Forwardでの再現性

Disclosure Confidenceを企業品質のProxyとして学習させないよう注意する。

---

# 18. Initial Normalization Flow（初期正規化フロー）

```text
Official Disclosure
        ↓
Raw Observation保存
        ↓
Disclosure Status判定
        ↓
Definition確認
        ↓
Within-company Normalization
        ↓
Concept Mapping
        ↓
Disclosure Confidence評価
        ↓
Research Review
        ↓
Company-specific Context
        ↓
Advisor / Company Score / ML Candidate
```

---

# 19. Review Checklist（レビューチェックリスト）

* [ ] 原資料がTier1である
* [ ] 原項目名を保持している
* [ ] 原定義を記録している
* [ ] 公開日と対象期間が分離されている
* [ ] 非開示をゼロとしていない
* [ ] 算出値と開示値を分離している
* [ ] Proxyが明記されている
* [ ] 定義変更を確認した
* [ ] 通貨・期間が整合している
* [ ] Disclosure Confidenceを投資評価へ直接加算していない
* [ ] Advisor表現がEvidence区分と一致している
* [ ] MLで欠損・選択バイアスを検証可能である
* [ ] As Of Dateが保持されている
* [ ] Reviewerが承認している

---

# 20. Independent Reviewer Judgment（独立レビュー判定）

## Research Reviewer

**判定：承認**

本ルールは、企業開示の差を企業品質の差と誤認するリスクを抑制できる。

特に以下を必須とする。

* 非開示をゼロとして扱わない
* 企業固有Observationを無理に共通化しない
* 原データと正規化データを分離する
* Disclosure ConfidenceとInvestment Scoreを分離する

## Engineering Reviewer

**判定：条件付き承認**

DB設計時には、少なくとも以下を別カラムまたは別Entityとして保持する必要がある。

* Raw Value
* Normalized Value
* Disclosure Status
* Source Definition
* Applicable Period
* Published Date
* As Of Date
* Transformation Rule
* Confidence
* Version

NULLだけで状態を表現してはならない。

## ADR Reviewer

**判定：承認**

このルールは、Research・Knowledge・DB・Advisor・MLのすべてに影響する横断的な設計判断である。

正式運用前にADRを作成する。

---

# 21. Related ADR Candidate（関連ADR候補）

**ADR Title**

Separate Disclosure Quality from Investment Quality

**Decision**

企業開示の充実度をInvestment Scoreへ直接加点せず、Knowledge ConfidenceおよびDisclosure Completenessとして独立管理する。

---

# 22. Next Actions（次の作業）

1. 本RuleをReview後にVersion 1.0へ昇格する。
2. ResearchSheetTemplateへDisclosure Status項目を追加する。
3. CompanyDisclosureMatrixResearch.mdへ本Ruleを参照追加する。
4. 将来のCatalogでDisclosure Status Masterを設計する。
5. DDL設計時にRaw / Normalized / Status / Provenanceを分離する。
6. Automotive Power Demand Composite Scoreの設計へ進む。
