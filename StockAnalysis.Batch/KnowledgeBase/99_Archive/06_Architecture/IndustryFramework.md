# Industry Research Framework
Version: 1.0

---

## 1. Purpose

本ドキュメントは、Industry Researchを実施する際の標準思考プロセスを定義する。

Industry Researchの目的は、業界を文章で説明することではない。

目的は、業界構造・収益構造・競争環境・投資判断上の特徴を整理し、AIが説明可能なKnowledgeとして再利用できる形に構造化することである。

---

## 2. Positioning

Industry Researchは、Company Researchより先に実施する。

理由は、Company分類・SubSector設計・Metric設計・Advisor説明・ML特徴量設計の基礎がIndustryにあるためである。

```text
Industry Research
↓
Industry Map
↓
Company Research
↓
SubSector Design
↓
Catalog
↓
DDL / Entity / DB
↓
ML / Advisor
```

---

## 3. Standard Thinking Flow

Industry Researchは、原則として以下の順番で考える。

```text
1. Industry Definition
2. Industry Structure
3. Value Chain
4. Business Model
5. Major Players
6. Competitive Landscape
7. Revenue Drivers
8. Cost Drivers
9. Lifecycle
10. Growth Drivers
11. Risks
12. SubSector Design
13. Representative Companies
14. Boundary Cases
15. Candidate Metrics
16. Advisor Perspective
17. ML Perspective
18. Final Review
```

---

## 4. Step 1: Industry Definition

Industryの定義を明確にする。

確認すること：

- 何を提供する業界か
- 誰に価値を提供するか
- どの市場を対象とするか
- どのような企業を含むか
- どのような企業を含まないか

目的：

Industryの範囲を明確にし、Company分類の基準を作る。

---

## 5. Step 2: Industry Structure

業界の内部構造を整理する。

確認すること：

- 上流・中流・下流
- 製品・サービスの流れ
- 主要な事業領域
- B2B / B2C / B2G
- 国内中心かグローバル中心か

目的：

Industry全体の構造を理解し、SubSector設計の前提を作る。

---

## 6. Step 3: Value Chain

業界のValue Chainを整理する。

確認すること：

- 原材料・技術・知的財産
- 製造・開発
- 流通・販売
- 最終顧客
- 収益が発生するポイント
- 競争優位が生まれるポイント

目的：

企業がValue Chain上のどこに位置するかを判断できるようにする。

---

## 7. Step 4: Business Model

業界内の主要なBusiness Modelを整理する。

確認すること：

- 製品販売型
- サービス提供型
- サブスクリプション型
- 受託開発型
- ライセンス型
- ストック型
- フロー型
- 価格決定力の有無

目的：

MetricやAdvisor説明に使える収益構造を整理する。

---

## 8. Step 5: Major Players

主要プレイヤーを整理する。

確認すること：

- 国内代表企業
- 海外代表企業
- 上場企業
- 非上場だが重要な企業
- 顧客企業
- 競合企業
- サプライヤー

目的：

Company Research時の比較対象を明確にする。

---

## 9. Step 6: Competitive Landscape

競争環境を整理する。

確認すること：

- 寡占か分散か
- 参入障壁
- 技術優位
- 規模の経済
- 顧客スイッチングコスト
- 規制
- ブランド力
- 価格競争の強さ

目的：

業界の収益性と企業ごとの差別化要因を説明できるようにする。

---

## 10. Step 7: Revenue Drivers

売上を伸ばす要因を整理する。

確認すること：

- 市場成長
- 価格上昇
- 数量増加
- シェア拡大
- 新製品
- 海外展開
- 顧客数増加
- 単価上昇
- 設備投資需要

目的：

Advisorが「なぜ成長するのか」を説明できるようにする。

---

## 11. Step 8: Cost Drivers

コスト・利益率に影響する要因を整理する。

確認すること：

- 原材料価格
- 人件費
- 研究開発費
- 設備投資
- 減価償却
- 為替
- 物流費
- 外注費
- エネルギー価格

目的：

利益率変動の理由を説明できるようにする。

---

## 12. Step 9: Lifecycle

IndustryのLifecycleを整理する。

分類候補：

- Early Growth
- Growth
- Mature
- Cyclical
- Declining

確認すること：

- 成長産業か
- 成熟産業か
- 景気循環型か
- 構造変化が起きているか
- 技術革新が速いか

目的：

投資タイミングやPortfolio Ruleに活用する。

---

## 13. Step 10: Growth Drivers

中長期の成長要因を整理する。

確認すること：

- 技術革新
- 人口動態
- 規制変更
- インフラ投資
- DX
- 脱炭素
- AI
- 自動化
- グローバル需要

目的：

Advisorが中長期の投資テーマを説明できるようにする。

---

## 14. Step 11: Risks

業界固有リスクを整理する。

確認すること：

- 景気後退
- 需要減少
- 在庫調整
- 価格下落
- 規制
- 地政学
- 技術陳腐化
- 顧客集中
- 為替
- 金利

目的：

Advisorがリスク説明をできるようにする。

---

## 15. Step 12: SubSector Design

SubSector候補を設計する。

SubSectorは投資判断の最小単位である。

確認すること：

- 評価指標が異なるか
- 比較対象企業が異なるか
- Advisor説明が変わるか
- ML上も意味があるか
- 企業数が少なすぎないか

目的：

Company分類・Peer比較・Metric設計の基準を作る。

---

## 16. Step 13: Representative Companies

代表企業を選定する。

基準：

- Industryを代表している
- SubSectorを説明しやすい
- 一次情報が確認しやすい
- 比較対象として自然
- Advisor説明に使いやすい

最低5社を目安とする。

---

## 17. Step 14: Boundary Cases

分類が迷う企業を記録する。

確認すること：

- 複数Industryにまたがる企業
- 売上構成と利益構成が異なる企業
- 親会社・子会社で事業が異なる企業
- 化学・電子部品・素材など隣接業界の企業
- 将来分類見直しが必要な企業

目的：

分類判断の再現性を高める。

---

## 18. Step 15: Candidate Metrics

IndustryまたはSubSectorで有効なMetric候補を整理する。

確認すること：

- 収益性指標
- 成長性指標
- 安全性指標
- 効率性指標
- 業界固有指標
- Market Ruleに使える指標
- Advisor説明に使える指標

Metricは必ずEvidenceと説明可能性を持つこと。

---

## 19. Step 16: Advisor Perspective

Advisorが説明に使う観点を整理する。

確認すること：

- どのような局面で買われやすいか
- どのような局面で避けるべきか
- 業界全体の魅力
- 個別企業を見る時の注意点
- SubSectorごとの評価差
- Portfolio内での役割

目的：

ユーザーへ自然言語で説明できる知識にする。

---

## 20. Step 17: ML Perspective

MLで利用できる観点を整理する。

確認すること：

- 有効そうな特徴量
- 効きやすい市況条件
- サイクル性
- Momentumとの相性
- Fundamentalとの相性
- 過学習リスク
- サンプル数

目的：

Knowledge BaseとML Engineを接続する。

---

## 21. Step 18: Final Review

Industry Research全体を確認する。

確認すること：

- Industry定義は明確か
- Included / Excludedが明確か
- Value Chainが説明できるか
- SubSector候補が妥当か
- Representative Companiesが妥当か
- Boundary Casesを記録したか
- Advisorで説明できるか
- MLで使えるか
- Research Sheetへ反映できるか

---

## 22. Industry Map Rule

Industryごとに、可能な限りIndustry Mapを作成する。

Industry Mapでは以下を整理する。

- Value Chain
- Major Players
- SubSector候補
- 日本企業の位置
- Boundary領域
- Advisor上の説明ポイント

保存場所：

```text
06_Architecture/IndustryMaps
```

例：

```text
06_Architecture/IndustryMaps/SEMICONDUCTOR.md
```

図は最初はMarkdownでよい。

必要になれば後からdraw.io等へ移行する。

---

## 23. Anti Patterns

以下を避ける。

- CompanyからIndustryを逆算する
- ニュースだけでIndustryを定義する
- SubSectorを細かくしすぎる
- Company SheetにIndustry知識を重複して書く
- Boundary Caseを記録しない
- Advisorで説明できない分類を作る
- MLで使えないほど細かい分類を作る

---

## 24. Final Principle

Industry Researchは、業界を説明するための文章作成ではない。

業界構造をAIが利用可能なKnowledgeへ変換する作業である。

Industry Researchの品質が、Company分類・SubSector設計・Metric設計・Advisor説明・ML活用の品質を決定する。

そのため、Industry ResearchはKnowledge Baseにおける最重要工程の一つとして扱う。