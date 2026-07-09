# Decision Log

Version: 1.0

---

# Purpose

本ドキュメントは、Knowledge Baseに関する重要な設計判断を記録する。

Decision Logの目的は、

「なぜその設計を採用したのか」

を将来も追跡できるようにすることである。

Gitのコミット履歴では設計意図までは十分に残らない。

そのため、本ドキュメントをKnowledge Baseにおける正式な設計判断記録とする。

---

# Scope

以下を記録対象とする。

* Governance変更
* Industry設計
* SubSector設計
* Metric設計
* Knowledge Base設計
* Reviewルール変更
* Naming変更
* Advisor設計
* ML設計に影響するKnowledge設計

対象外

* 軽微な誤字修正
* Markdownの体裁修正
* コードリファクタリング
* バグ修正

---

# Decision Record Template

---

## Decision ID

KB-YYYY-XXX

例

KB-2026-001

---

## Decision Date

YYYY-MM-DD

---

## Category

例

* Governance
* Industry
* SubSector
* Metric
* Research
* Review
* Advisor
* ML
* Architecture

---

## Title

設計判断を一文で表現する。

例

Industry数を40〜70分類とする

---

## Background

なぜこの検討が必要になったか。

---

## Options Considered

検討した案を記録する。

例

* 案A
* 案B
* 案C

---

## Decision

最終的に採用した内容。

---

## Reason

採用理由を記録する。

Explainable AI

Research効率

保守性

ML利用

Advisor利用

などの観点から説明する。

---

## Advantages

採用によるメリット。

---

## Disadvantages

採用によるデメリット。

---

## Impact

影響範囲

例

* Industry Research
* Company Research
* Catalog
* DDL
* ML
* Advisor

---

## Related Documents

関連資料

例

* KnowledgeBaseRules.md
* ResearchPolicy.md
* IndustryResearch_Template.md

---

## Status

* Proposed
* Approved
* Deprecated
* Replaced

---

## Reviewer

最終承認者

---

## Notes

補足事項

---

# Decision Numbering

採番規則

KB-YYYY-001

KB-YYYY-002

...

Knowledge Base全体で一意とする。

欠番は許容する。

再利用しない。

---

# Update Policy

Decisionは削除しない。

変更が必要な場合は、

新しいDecisionを追加する。

古いDecisionは

Statusを

Replaced

または

Deprecated

へ変更する。

履歴は必ず残す。

---

# Quality Criteria

Decisionには必ず

* 背景
* 比較した案
* 採用理由
* メリット
* デメリット
* 影響範囲

を記録する。

「なんとなく決めた」は認めない。

---

# Initial Decisions

以下はKnowledge Base v1.0 Freeze以前に正式採用済みの主要Decisionである。

| Decision ID | Title                      | Status   |
| ----------- | -------------------------- | -------- |
| KB-2026-001 | Research Firstを採用          | Approved |
| KB-2026-002 | Primary Source Firstを採用    | Approved |
| KB-2026-003 | Industryは40〜70分類           | Approved |
| KB-2026-004 | SubSectorは120〜200分類        | Approved |
| KB-2026-005 | AI Draft → Human Review方式  | Approved |
| KB-2026-006 | Research Sheetを唯一の一次情報源とする | Approved |
| KB-2026-007 | Knowledge Base v1.0 Freeze | Approved |

---

# Final Principle

設計判断はプロジェクトの知識資産である。

Decision Logは

「何を決めたか」

だけでなく、

「なぜそう決めたか」

を将来へ残すことを目的とする。

Knowledge Baseの進化は、

Decision Logによって継続的に記録・管理される。
