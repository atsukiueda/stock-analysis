# Research Policy

Version: 1.1

---

## 1. Purpose

本ドキュメントは、日本株AIシステムにおける **Knowledge Base Research** の標準作業手順を定義する。

Researchの目的は、企業や業界を詳しく調べること自体ではない。

目的は、AIが投資判断を説明できるだけの根拠を、効率良く、再利用可能な形で構造化し、Knowledge Baseへ蓄積することである。

Knowledge Base Researchは、Explainable AIを実現するための中核工程である。

---

## 2. Positioning

Knowledge Base構築は以下の順番で進める。

```text
Research
↓
Review
↓
Catalog
↓
DDL
↓
Entity
↓
Database
↓
ML
↓
Advisor
```

Researchはすべての上流工程である。

DDL、Entity、DB、ML、Advisorは、ResearchとCatalogの結果から導かれる。

Researchが不十分な状態で実装へ進んではならない。

---

## 3. Core Philosophy

Researchでは以下を最優先とする。

* Evidence Driven
* Explainable AI
* Reproducibility
* Maintainability
* Consistency
* Human Review
* AI Draft First

Researchは100点を目指さない。

80点でReviewへ進み、Knowledge Baseを継続的に改善する。

---

## 4. Research Principle

Researchの目的は、企業を深く知ることではない。

AIが投資判断を説明できる知識を、効率良く構造化することである。

そのため、以下を徹底する。

* 全ページを読む必要はない
* 分類に必要な情報を優先する
* 一次情報を優先する
* 根拠をResearch Sheetに残す
* 不明点はConfidenceで管理する
* 迷う企業はBoundary Caseとして残す

---

## 5. Standard Workflow

Researchは以下の標準フローで進める。

```text
AI Draft
↓
Human Review
↓
Approved
↓
Evidence Verified
↓
Production Ready
↓
Catalog
```

AIはドラフトを作成する。

人は一次情報を確認し、最終判断を行う。

人がゼロからすべて調査する運用は原則採用しない。

---

## 6. Research Inputs

Researchで利用する情報は、信頼度によって分類する。

### 6.1 Primary Sources

分類根拠として使用できる情報。

優先順位は以下とする。

1. 最新統合報告書
2. 最新有価証券報告書
3. 最新決算説明資料
4. 最新IRサイト
5. JPX / J-Quants

### 6.2 Secondary Sources

補助的に使用できる情報。

* 業界団体資料
* 官公庁資料
* 取引所資料
* 企業公式の補足資料

### 6.3 Reference Sources

参考にはできるが、分類根拠にはしない情報。

* ニュース記事
* ブログ
* Wikipedia
* SNS
* まとめサイト
* アナリストコメント

Reference Sourcesだけを根拠にIndustryやSubSectorを確定してはならない。

---

## 7. Research Outputs

Researchの成果物は以下とする。

### 7.1 Industry Research

成果物：

```text
02_Research/Industries/<IndustryCode>.md
```

例：

```text
02_Research/Industries/SEMICONDUCTOR.md
```

### 7.2 Company Research

成果物：

```text
02_Research/Companies/<Code>_<CompanyName>.md
```

例：

```text
02_Research/Companies/8035_東京エレクトロン.md
```

### 7.3 Draft Research

AIが作成した未レビューのドラフトは以下へ置く。

```text
07_AI_Workspace
```

ReviewedまたはApprovedになるまでは、正式Researchとして扱わない。

---

## 8. Research Status

Research成果物は以下の状態を持つ。

```text
Draft
↓
Reviewed
↓
Approved
↓
Evidence Verified
↓
Production Ready
```

### Draft

AIまたは人が作成した初期案。

正式Knowledgeではない。

### Reviewed

基本項目が埋まり、レビュー可能な状態。

### Approved

人が内容を確認し、分類として採用可能と判断した状態。

### Evidence Verified

一次情報との整合性を確認済みの状態。

### Production Ready

Catalogへ反映可能な正式状態。

---

## 9. Industry Research Procedure

Industry Researchは以下の順番で進める。

### Step 1: Industry Definition

Industryの定義を記載する。

* 何を含む業界か
* どの市場を対象とするか
* どのような企業群か
* Advisorでどう説明できるか

### Step 2: Included Business

このIndustryに含める事業を記載する。

### Step 3: Excluded Business

類似しているが、このIndustryには含めない事業を記載する。

### Step 4: Classification Criteria

Industryへ分類する条件を定義する。

優先順位は以下とする。

1. 売上構成
2. 利益構成
3. IR上の事業区分
4. 同業比較
5. Advisorでの説明性
6. ML利用価値

### Step 5: Representative Companies

代表企業を記載する。

最低5社を目安とする。

### Step 6: Boundary Cases

分類が迷いやすい企業を記録する。

Boundary Caseは将来のKnowledge Base改善において重要な資産である。

### Step 7: Candidate SubSectors

SubSector候補を定義する。

SubSectorは投資判断の最小単位である。

### Step 8: Candidate Metrics

IndustryまたはSubSectorで重要なMetric候補を記録する。

### Step 9: Industry Characteristics

Lifecycle、景気感応度、資本集約度、技術革新度などを記載する。

DB化は急がない。

まずResearch Sheetで管理する。

### Step 10: ML Perspective

MLで利用できる可能性がある観点を記録する。

### Step 11: Advisor Perspective

Advisorが説明に使える観点を記録する。

### Step 12: Final Review

Research Sheet全体を確認し、Reviewへ引き渡す。

---

## 10. Company Research Procedure

Company Researchは以下の順番で進める。

### Step 1: Primary Sources確認

最低限、以下のうち確認可能なものを記録する。

* 統合報告書
* 有価証券報告書
* 決算説明資料
* IRサイト
* JPX / J-Quants

### Step 2: Business Summary

企業の主要事業を簡潔に記載する。

### Step 3: Revenue Composition

売上構成を確認する。

セグメント別売上がある場合は優先して記録する。

### Step 4: Profit Composition

利益構成を確認する。

営業利益またはセグメント利益がある場合は記録する。

### Step 5: Industry Judgment

Industryを判定する。

### Step 6: SubSector Judgment

SubSectorを判定する。

### Step 7: Comparable Companies

比較対象企業を記録する。

### Step 8: Boundary Case確認

分類が迷う場合はBoundary Caseとして記録する。

### Step 9: Confidence設定

分類の確信度を設定する。

```text
High
Medium
Low
```

### Step 10: Final Comment

判断理由と残課題を記録する。

---

## 11. Research Scope

### 11.1 必ず調査する項目

Company Researchでは以下を必須とする。

* Primary Sources
* Business Summary
* 売上構成
* 利益構成
* Industry判定
* SubSector判定
* 判定理由
* 比較対象
* Confidence
* Review Status

### 11.2 必要に応じて調査する項目

以下は必要に応じて調査する。

* 主要顧客
* 海外売上比率
* 設備投資
* 研究開発
* 市場シェア
* 受注残
* 業界サイクル
* 規制リスク

### 11.3 Research対象外

Research段階では原則として以下を扱わない。

* 株価チャート
* PER
* PBR
* 配当利回り
* テクニカル指標
* 短期売買判断
* ニュースベースの投資判断
* アナリスト評価

これらはScreening、ML、Advisor、Backtestで扱う。

---

## 12. Research Stop Rule

以下が揃った時点でResearchを終了してよい。

* Primary Sourcesを確認した
* Business Summaryを作成した
* 売上構成を確認した
* Industryを判定した
* SubSectorを判定した
* 比較対象を確認した
* 判定理由を記録した
* Confidenceを設定した

完璧主義は禁止する。

不明点は残課題として記録し、Reviewまたは将来更新で改善する。

---

## 13. Research Time Guideline

### Company Research

1社あたり30〜60分を目安とする。

60分を超える場合は、以下を判断する。

* Boundary Caseとして扱う
* ConfidenceをMediumまたはLowにする
* 残課題を記録して次へ進む

### Industry Research

IndustryはKnowledge Baseの基礎となるため、Companyより時間をかけてよい。

ただし、過剰な調査でResearch開始を止めてはならない。

---

## 14. Daily Workflow

毎回の作業は以下の形式で開始する。

```text
Today's Goal
Current Phase
Deliverables
Current Progress
Definition of Done
Next
Backlog
Blockers
```

### Today's Goal

その日に必ず完成させる成果物を1つ以上定義する。

### Deliverables

完成物を明確にする。

### Definition of Done

完了条件を明確にする。

### Backlog

作業中に出た改善案を記録する。

Researchを止めてその場で設計変更しない。

---

## 15. Sprint Workflow

Knowledge ProductionはSprint単位で進める。

原則として、1Sprint = 1Industry とする。

例：

```text
Sprint001
Industry: SEMICONDUCTOR
```

Sprintで完成させるもの：

* Industry Research Sheet
* 代表Company Research Sheets
* Boundary Cases
* Candidate SubSectors
* Candidate Metrics
* ReviewTracker更新
* Catalog反映候補

---

## 16. Minimum Daily Goal

最低目標は **1日1成果物** とする。

成果物の例：

* Governance文書1件
* Industry Research Sheet 1件
* Company Research Sheet 1件
* Excel Catalog更新
* ReviewTracker更新

調子が良い日は複数成果物を進めてよい。

ただし、品質を落として数を増やしてはならない。

---

## 17. Backlog Policy

Research中に出た改善案は、まずBacklogへ記録する。

記録先：

```text
00_Governance/ArchitectureBacklog.md
```

Backlogに入れる例：

* 新しいMetric候補
* 新しいテーブル案
* Industry分割案
* Template改善案
* Advisor改善案
* ML特徴量候補

Researchを止める設計変更は原則行わない。

---

## 18. DecisionLog Policy

正式に採用した設計判断はDecisionLogへ記録する。

記録先：

```text
00_Governance/DecisionLog.md
```

DecisionLogへ記録する例：

* Industry分類数の方針
* SubSector設計方針
* Metric採用ルール
* Governance変更
* Catalog構造変更

Backlogは「候補」。

DecisionLogは「採用済み判断」。

---

## 19. Version Policy

### Governance Documents

Governance文書はVersionを持つ。

例：

```text
Version: 1.0
Version: 1.1
Version: 2.0
```

### Research Sheets

Research Sheetは原則Versionを持たない。

Git履歴、DecisionLog、Classification Decision Historyで管理する。

### Catalog

Catalogは最新版を正とする。

必要に応じて更新日・更新者・Review Statusを管理する。

---

## 20. Role and Responsibility

### AI

AIは以下を担当する。

* Research Draft作成
* Primary Source候補整理
* Business Summary作成
* Industry候補提示
* SubSector候補提示
* Boundary Case抽出
* Candidate Metrics提案
* Advisor観点整理
* ML観点整理
* 不足項目の指摘

### Human

人は以下を担当する。

* 一次情報の最終確認
* 分類の最終判断
* Approved判定
* Evidence Verified判定
* Catalog反映
* Production Ready判定

最終判断は必ず人が行う。

---

## 21. Quality Gate

ResearchからReviewへ進むには、以下を満たす必要がある。

* Primary Sourcesが記録されている
* Industry判定理由がある
* SubSector判定理由がある
* Confidenceが設定されている
* Boundary Caseを確認している
* Advisorで説明可能である
* ML利用価値を大きく損なわない

---

## 22. Definition of Done

Research成果物は以下を満たした時点で完了とする。

* 必須項目が埋まっている
* 一次情報が記録されている
* 判定理由が明確である
* 比較対象が妥当である
* Explainable AIとして説明可能である
* Reviewへ引き渡し可能である

---

## 23. Anti Patterns

以下は禁止する。

### 23.1 DDL First

Research前にDDLを作成すること。

### 23.2 Catalog First

Research SheetなしでCatalogへ登録すること。

### 23.3 News Based Classification

ニュース記事のみでIndustryやSubSectorを決めること。

### 23.4 Over Research

分類に不要な情報まで調べ続けること。

### 23.5 Template Drift

Research中に毎回テンプレートを変更すること。

### 23.6 Untraceable Judgment

根拠を追跡できない分類判断。

---

## 24. Best Practices

推奨する進め方は以下である。

* 最初にIndustry Sheetを作る
* 次に代表Companyを調べる
* 境界企業を必ず記録する
* 迷う場合はConfidenceを下げて進む
* 改善案はBacklogへ逃がす
* Researchと設計変更を混ぜない
* 1日1成果物を守る
* AI Draftを活用する
* 人は最終判断に集中する

---

## 25. FAQ

### Q1. 完璧に調べてから次へ進むべきか？

いいえ。

80点でReviewへ進む。

完璧主義はResearch速度を大きく落とす。

### Q2. ニュース記事は使ってよいか？

参考としては使ってよい。

分類根拠には使わない。

### Q3. 会社が複数事業を持つ場合はどうするか？

売上構成、利益構成、IR上の説明、比較対象を総合して判断する。

迷う場合はBoundary Caseに記録する。

### Q4. IndustryとSubSectorのどちらを優先するか？

Industryを先に決める。

SubSectorは投資判断の最小単位として後から精緻化する。

### Q5. Research中に良い設計案を思いついたら？

ArchitectureBacklogへ記録する。

Researchは止めない。

### Q6. Catalogへいつ反映するか？

Approved、Evidence Verified、Production Readyになってから反映する。

---

## 26. Final Principle

Researchは、Knowledge Baseを育てる活動である。

一社のResearchは一社分の情報だけで終わらない。

Industry、SubSector、Metric、Advisor、MLの知識も同時に改善する。

この積み重ねにより、Knowledge Baseは知識の複利として成長する。

本プロジェクトでは、Researchを最重要工程として扱う。

AIが投資判断を説明できる未来のために、Researchは常にEvidence Drivenであり、Explainableであり、再利用可能でなければならない。

# Research Source Hierarchy

Researchでは、目的に応じて情報源を使い分ける。

## Tier1 : Primary Company Sources（最優先）

目的

Company Classification

SubSector Classification

Evidence

対象

- Integrated Report
- Securities Report
- Earnings Presentation
- Official IR

---

## Tier2 : Industry Sources

目的

Industry理解

Industry Cycle

Industry Structure

Market Size

対象

- WSTS
- SEMI
- SIA
- JEITA
- 官公庁統計

---

## Tier3 : Institutional Research

目的

Industry Outlook

Technology Trend

Macro Trend

Competitive Landscape

対象

- Deloitte
- PwC
- McKinsey
- BCG
- Bain
- Gartner
- IDC

---

## Tier4 : Reference

目的

補足説明

対象

- ニュース
- 学会
- 技術記事
- 書籍

Tier4のみで分類判断を行ってはならない。

## Operational Research Principle

Knowledge Baseでは、投資判断への重要性だけでなく、
継続的なデータ取得・更新・保守可能性を考慮してKnowledgeを採用する。

評価項目

- Investment Importance
- Data Availability
- Update Frequency
- Operational Cost
- Explainability
- ML Utility

取得困難なKPIについては

- Proxy Metric
- Derived Feature

を優先的に検討する。

Proxyが十分な説明力を持たない場合は
初期システムでは採用しない。

## Evidence Integrity Principle

Knowledge Baseでは

推測

一般論

市場で広く語られている説明

だけではKnowledgeとして登録しない。

Knowledgeへ登録する情報は

Tier1を中心としたEvidenceにより
検証可能でなければならない。

Evidenceが不十分なものは

Hypothesis

としてResearch Sheetへ保持する。

Knowledge Baseへは登録しない。

Knowledge Baseは『もっともらしい説明』を蓄積する場所ではない。Evidenceによって検証され、将来も再検証可能なKnowledgeのみを資産として蓄積する。

# Research Integrity Principle

本Knowledge Baseでは、Researchの完成度よりもResearchの信頼性を優先する。

以下を厳守する。

- 分からないことを推測で補わない。
- 一般論や市場で広く語られている説明だけではKnowledgeとして採用しない。
- Tier1を中心としたEvidenceにより検証可能であること。
- Evidenceが不足する内容はHypothesisとしてResearch Sheetへ管理する。
- HypothesisはKnowledge Baseへ登録しない。

# Operational Responsibility Principle

本Knowledge Baseは、

将来、実際の資産運用に利用される可能性があることを前提とする。

そのため

Research

Design

Implementation

Machine Learning

Advisor

のすべてにおいて

- 安全性
- 再現性
- Explainability
- 保守性

を優先する。

開発速度や見栄えを理由に品質を妥協しない。

# Operational Observation Principle

Knowledge Baseへ登録する重要概念は、

「何であるか（Definition）」

だけでなく、

「どのように観測するか（Observation）」

まで定義しなければならない。

重要概念には以下を定義する。

- Definition（定義）
- Observation Method（観測方法）
- Data Source（データソース）
- Update Frequency（更新頻度）
- Operational Feasibility（運用可能性）
- Proxy Candidate（代替指標候補）
- Initial Adoption（初期採用可否）

Observationが定義されていない概念は、

Knowledge Baseへ登録してはならない。

観測できない概念は、

Research TopicまたはHypothesisとして管理する。

Knowledge Baseへは登録しない。