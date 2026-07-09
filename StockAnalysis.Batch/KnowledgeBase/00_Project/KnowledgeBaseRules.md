# Knowledge Base Rules
Version: 1.0

---

> **本ドキュメントはKnowledge Baseの最上位ルールである。**
>
> 他の設計書・Research Sheet・Catalog・DDL・実装方針と矛盾する場合は、本ドキュメントを優先する。

# Purpose

本ドキュメントは、日本株AIシステムにおけるKnowledge Baseの設計思想・運用ルール・品質基準を定義する。

Knowledge Baseは単なるマスターデータではない。

将来的に

- ML Engine
- Decision Engine
- Advisor Engine
- Portfolio Engine

が共通利用する知識基盤（Single Source of Truth）として位置付ける。

Knowledge BaseはExplainable AIを実現するための最重要コンポーネントである。

---

# Mission

Knowledge Baseの目的は

「AIが投資判断の根拠を説明できること」

である。

予測精度だけを追求しない。

以下を最優先とする。

- Explainable
- Evidence Driven
- Reproducible
- Maintainable
- Extensible

---

# Fundamental Principles

## Rule 1
Research First

必ず

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

の順番で進める。

DDLを先に作成してはならない。

---

## Rule 2
Primary Source First

Researchは一次情報を優先する。

優先順位

① 最新統合報告書

② 最新有価証券報告書

③ 最新決算説明資料

④ 最新IRサイト

⑤ JPX・J-Quants

ニュースサイト

ブログ

まとめサイト

Wikipedia

などは補助資料とする。

分類根拠には利用しない。

---

## Rule 3
Evidence Driven

すべての分類にはEvidenceを残す。

Evidenceが残らない分類は禁止。

Research Sheetから必ず根拠を追跡できること。

---

## Rule 4
Research Sheet is the Truth

Company分類

Industry分類

SubSector分類

Metric選定

Advisor知識

すべてResearch Sheetを唯一の正とする。

CatalogはResearch Sheetから生成される成果物である。

---

## Rule 5
Catalog Traceability

Catalogへ登録する情報は

必ずResearch Sheetから辿れること。

Research Sheetには

- 出典
- 判定理由
- 採用理由
- 採用しなかった理由

を記録する。

---

## Rule 6
Review Required

Research完了後

Reviewed

↓

Approved

↓

Evidence Verified

の順にレビューする。

未レビュー情報はCatalogへ登録しない。

---

## Rule 7
Boundary Cases

分類が迷う企業ほど重要である。

Boundary Caseは必ずResearch Sheetへ残す。

将来の分類変更にも利用する。

---

## Rule 8
Decision History

分類変更は履歴を残す。

いつ

誰が

何を

なぜ変更したか

を必ず記録する。

Gitだけに依存しない。

---

## Rule 9
Version Management

Knowledge BaseはVersion管理する。

例

v1.0

↓

v1.1

↓

v2.0

Industry定義変更など大きな変更はVersionを更新する。

---

## Rule 10
80 Percent Rule

Researchは100点を目指さない。

80点でReviewへ進む。

Research品質は継続的に改善する。

---

## Rule 11
Research Time

Company Research

30〜60分を目安とする。

Industry Research

必要に応じて時間をかける。

完璧主義は禁止。

---

## Rule 12
Single Industry Sheet

Industry Research SheetはIndustryごとに1つ。

例えば

SEMICONDUCTOR.md

は1つのみ。

CompanyごとにIndustry知識を重複して記載しない。

---

## Rule 13
Single Company Sheet

Company Research Sheetは企業ごとに1つ。

Industry知識を書かない。

Industry Sheetを参照する。

---

## Rule 14
Industry First

Industry知識はCompanyより優先する。

Industryが完成してからCompany分類を行う。

---

## Rule 15
SubSector is the Smallest Investment Unit

SubSectorは投資判断を行う最小単位とする。

Advisor

Metric

Peer比較

ML

はSubSectorを基本単位とする。

---

## Rule 16
Explainable AI

Knowledge Baseへ登録する知識は

Advisorが自然言語で説明可能であること。

説明できない知識は登録しない。

---

## Rule 17
ML Compatibility

Knowledge Baseは

MLで利用可能であること。

特徴量

評価指標

分類

Evidence

はMLから利用できる形で整理する。

---

## Rule 18
Advisor Compatibility

Knowledge BaseはAdvisor Engineから利用可能であること。

Advisorは

なぜその銘柄を勧めるのか

を説明できなければならない。

---

## Rule 19
Long-term Maintainability

5年後

10年後でも保守可能な構造を優先する。

短期的な実装速度を優先しない。

---

## Rule 20
Knowledge Base Before Code

Knowledge Baseが完成していない状態で

DDL

Entity

ML

Advisor

を実装してはならない。

Knowledge Baseが最上位設計である。

---

# Quality Standards

Knowledge Baseに登録される情報は

- 正確性
- 再現性
- 一貫性
- 説明可能性
- 保守性

を満たすこと。

---

# Review Status

Researching

Reviewed

Approved

Evidence Verified

---

# Evidence Status

Draft

Official IR Reviewed

Backtest Verified

ML Verified

Production Verified

---

# Industry Design Policy

Industry

40〜70分類

---

SubSector

120〜200分類

---

Metric

Evidenceに基づき追加する。

MetricCodeは変更禁止。

---

# Explainable AI Policy

Knowledge Baseは

AIが

「なぜその判断をしたのか」

を説明するための知識基盤である。

予測精度より

説明可能性を優先する。

---

# Final Principle

Knowledge Baseは

本システム最大の資産である。

コードより長く利用されることを前提に設計する。

すべての設計判断は

Explainable

Evidence

Maintainability

を基準として行う。