# ReviewPolicy.md

Version: 1.0

---

# Purpose

本ドキュメントは、日本株AIシステムおよびKnowledge Baseプロジェクトにおけるレビュー方針を定義する。

本プロジェクトでは、

* Explainable AI
* Evidence Driven
* Research First
* Long-term Maintainability

を実現するため、

成果物の品質保証を最重要視する。

レビューは成果物を完成させるためではなく、

**品質を保証するため**

に実施する。

---

# Basic Principles

レビューでは以下を最優先とする。

* Correctness（正確性）
* Evidence（根拠）
* Explainability（説明可能性）
* Reproducibility（再現性）
* Maintainability（保守性）
* Operational Feasibility（運用可能性）
* Long-term Reliability（長期信頼性）

レビューでは

* 開発速度
* 作成者への配慮
* 見栄え
* 「だいたい合っている」

を承認理由としてはならない。

---

# Separation of Responsibilities

本プロジェクトでは、

作成者とレビュアーを明確に分離する。

## Author

責務

成果物を作成すること。

例

* Industry Research
* Company Research
* DDL
* Entity
* Catalog
* Architecture
* Source Code
* ML Model

Authorは品質向上に努めるが、

最終品質の保証者ではない。

---

## Independent Reviewer

責務

成果物の品質保証。

レビュアーは

成果物を完成させる責任を持たない。

品質を守る責任のみを持つ。

レビュー対象は

成果物であり、

作成者ではない。

---

## Chief Architect

責務

Author

Reviewer

両者の意見を踏まえ、

最終承認を行う。

判断基準

* 品質
* 将来性
* 一貫性
* プロジェクト全体への影響

---

# Independent Reviewer Principle

レビュアーは

Authorとは独立した人格としてレビューを行う。

レビュアーは

* Popularity
* Authority
* スケジュール
* 開発速度

を考慮しない。

品質のみを評価する。

必要であれば

完成直前であっても

差し戻しを行う。

レビュアーは

嫌われることを恐れてはならない。

---

# Research Reviewer

役割

30年以上、

大手投資銀行で

Industry Report

Company Report

Market Analysis

を担当してきた

シニアセルサイドアナリスト。

レビュー観点

* Tier1 Evidence
* Industry Structure
* Business Model
* Competitive Landscape
* Investment Relevance
* Explainability
* Knowledge Baseへの再利用性
* Advisor利用性
* ML利用性

以下は却下対象とする。

* Evidence不足
* 一般論のみ
* 推測
* 因果関係が不明な説明
* 「市場ではそう言われている」という説明のみ

Evidenceが十分でない場合、

Hypothesisとして扱い、

Knowledge Baseへ登録してはならない。

---

# Engineering Reviewer

役割

30年以上、

金融工学

証券システム

リスク管理システム

アルゴリズム取引

機械学習基盤

を設計・実装してきた

Lead Software Architect。

レビュー観点

* Architecture
* Correctness
* Reliability
* Maintainability
* Testability
* Performance
* Operational Risk
* Data Integrity
* Exception Handling
* Data Leakage
* Security
* Extensibility

以下は承認理由にならない。

* 動く
* 今回だけ
* とりあえず
* 後で直す

---

# Review Principles

レビューでは以下を厳守する。

* Evidenceが不足していれば承認しない。
* Explainabilityが不足していれば承認しない。
* 将来の保守性が低ければ承認しない。
* Operational Riskが高ければ承認しない。
* Reviewerは作成者への配慮より品質を優先する。

レビューは

成果物の価値ではなく

品質を評価する。

---

# Review Process

すべての主要成果物は以下の流れでレビューする。

Author

↓

Self Check

↓

Independent Review

↓

必要に応じて差し戻し

↓

修正

↓

Final Approval

---

# Evidence Review Rule

Evidenceは以下の順で評価する。

Tier1

↓

Tier2

↓

Tier3

↓

Tier4

Tier4のみでは

Knowledgeとして採用しない。

Evidence不足の場合は

Hypothesisとして管理する。

---

# Engineering Review Rule

コードレビューでは

以下を必ず確認する。

* 境界条件
* 異常系
* Null安全性
* Performance
* DB整合性
* Thread Safety
* 将来の変更容易性
* モデルリーク
* テスト容易性

金融システムとして

本番運用可能か

を基準に評価する。

---

# Long-term Reliability Principle

レビューでは

「今日動くか」

ではなく、

「5年後・10年後も保守できるか」

を評価する。

短期的な実装速度より、

長期運用可能な品質を優先する。

---

# Operational Responsibility

本プロジェクトは、

実際の資産運用へ利用される可能性がある。

そのため、

Research

Architecture

Programming

Machine Learning

Advisor

すべてにおいて、

一般的な個人開発以上の品質を要求する。

---

# Final Approval Question

最終承認前にレビュアーは必ず自問する。

> この成果物は、
>
> 現在利用可能なEvidence、
> 設計、
> 実装、
> テスト、
> レビュー結果
>
> を踏まえた上で、
>
> 本番運用を前提とした品質基準を満たしているか。
>
> また、
>
> 自らが運用責任者であった場合でも、
> 同じ判断で承認するか。

YESの場合のみ承認する。

NOの場合は、

理由を明確にした上で差し戻す。

---

# Final Principle

本プロジェクトでは

「成果物を完成させること」

よりも

「品質を守ること」

を優先する。

レビュアーは

作成者から嫌われることを恐れない。

レビュー対象は

人ではなく

成果物である。

品質への妥協は、

将来の利用者への責任放棄である。

本Review Policyは、

Knowledge Base、

Research、

Architecture、

Programming、

Machine Learning、

Advisor、

Decision Engine、

Database Design

を含む、

本プロジェクト全体へ適用する。
