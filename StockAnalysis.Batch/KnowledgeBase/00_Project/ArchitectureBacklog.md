# Architecture Backlog

Version: 1.0

---

# Purpose

本ドキュメントは、日本株AIシステム Knowledge Base における
将来の設計改善案を管理する。

Architecture Backlog は
未採用の設計案を記録する場所である。

Researchを止めず、
改善案を蓄積することを目的とする。

---

# Philosophy

BacklogはTODOリストではない。

将来のKnowledge Baseをより良くするための
設計資産である。

Backlogへ登録しただけでは採用とはならない。

採用された場合のみDecisionLogへ記録する。

---

# Workflow

Idea

↓

Architecture Backlog

↓

Discussion

↓

Decision

↓

Implementation

---

# Status

## Backlog

登録のみ

---

## Under Review

検討中

---

## Accepted

採用決定

DecisionLogへ移行予定

---

## Rejected

不採用

履歴は残す

---

## Implemented

実装済み

---

# Priority

High

Medium

Low

---

# Effort

S

M

L

---

# Backlog Template

## Backlog ID

KB-BL-XXX

---

## Title

改善案

---

## Category

例

Research

Industry

SubSector

Metric

Advisor

ML

Database

Architecture

Governance

---

## Background

背景

---

## Expected Benefit

期待効果

---

## Potential Drawbacks

懸念点

---

## Priority

High

Medium

Low

---

## Estimated Effort

S

M

L

---

## Dependencies

前提条件

---

## Status

Backlog

---

## Decision Link

DecisionLog ID

---

## Notes

補足

---

# Initial Backlog

## KB-BL-001

Title

Industry Characteristics のDB化

Status

Backlog

Priority

Medium

---

## KB-BL-002

Title

Research SheetからCatalog自動生成

Status

Backlog

Priority

Medium

---

## KB-BL-003

Title

Evidence信頼度スコア導入

Status

Backlog

Priority

Low

---

## KB-BL-004

Title

Advisor説明テンプレート自動生成

Status

Backlog

Priority

Medium

---

## KB-BL-005

Title

Industry Supply Chain Knowledge追加

Status

Backlog

Priority

Low

---

## KB-BL-006

Title

LLMによるResearch Draft更新

Status

Backlog

Priority

Low

---

# Final Principle

BacklogはResearchを止めないために存在する。

思いついた改善案はBacklogへ記録する。

Researchは継続する。

設計変更はDecisionLogを経て正式採用する。

---
## Backlog ID

KB-BL-008

---

## Title

Industry State（業界サイクル状態）のKnowledge化

---

## Category

Advisor

Market Rule

Knowledge Base

---

## Background

現在のIndustry Researchでは、業界固有のサイクル（例：半導体設備投資サイクル）は定義しているが、「現在そのサイクルのどの局面にあるか」はKnowledgeとして保持していない。

Advisorでは業界の現在地を説明できると、投資判断の説明力が大きく向上する。

---

## Expected Benefit

- Advisorの説明品質向上
- Market Ruleとの連携
- Industryごとの投資タイミング判定
- ML特徴量への応用
- Explainable AIの強化

---

## Potential Drawbacks

- 判定ロジック設計が必要
- IndustryごとにState定義が異なる
- 更新頻度が高い

---

## Priority

Medium

---

## Estimated Effort

M

---

## Dependencies

- MarketRule
- AdvisorRule
- Industry Research
- Candidate Metrics

---

## Proposed Design

Industryごとに現在状態を保持する。

例

- Expansion
- Peak
- Correction
- Bottoming
- Recovery

Advisorでは

「現在はRecovery局面」

など自然言語で説明する。

---

## Status

Backlog

---

## Decision Link

-

---

## Notes

Knowledge Base v2候補。

## Backlog ID

KB-BL-009

## Title

Representative CompanyおよびBoundary CaseのKnowledge化

## Category

Knowledge Base

Architecture

## Background

Representative CompaniesおよびBoundary CasesはIndustry Research Sheet内で管理しているが、将来的には複数Industry間で再利用・横断検索・レビュー履歴管理を行いたい。

## Expected Benefit

- 横断検索
- レビュー履歴管理
- Company Researchとの連携
- Industry比較の効率化

## Potential Drawbacks

- 初期実装コスト増加
- 現段階では運用実績不足

## Priority

Low

## Estimated Effort

M

## Status

Backlog

## Notes

少なくとも20〜30Industry完成後に再評価する。

## Backlog ID

KB-BL-010

## Title

Industry × Market Regime Knowledge Matrix

## Category

Advisor

Knowledge Base

Market Rule

## Background

Industry単体ではなく、市場局面（Market Regime）との組み合わせでAdvisorの説明を行えるようにする。

## Expected Benefit

- Advisor説明品質向上
- Portfolio判断の高度化
- Industry Rotation分析
- ML特徴量候補

## Potential Drawbacks

- IndustryごとのMatrix整備が必要
- Research工数増加

## Priority

Medium

## Estimated Effort

M

## Dependencies

- MarketRule
- AdvisorRule
- Industry Research

## Status

Backlog

## Notes

Knowledge Base v2候補。

## Backlog ID

KB-BL-011

## Title

Industry Report Layerの追加

## Category

Knowledge Base

Research

Architecture

## Background

現在のIndustry ResearchはKnowledge Base登録を目的としているが、業界全体を包括的に分析・蓄積するレイヤーが存在しない。

投資銀行・証券会社レベルのIndustry Reportを先に作成し、その内容をKnowledge Baseへ構造化して取り込むことで、Research品質・再利用性・Explainabilityを向上させる。

## Expected Benefit

- Industry理解の深化
- Company Researchの効率化
- Research品質の標準化
- Advisor説明の充実
- Knowledge Baseへの転用容易化

## Potential Drawbacks

- 初回Research工数が増える
- ドキュメント管理対象が増える

## Priority

High

## Estimated Effort

L

## Dependencies

- ResearchPolicy
- IndustryResearch_Template
- CompanyResearch_Template

## Status

Backlog

## Notes

Knowledge Base v2候補。
Industry Reportを「一次成果物」、Industry Researchを「Knowledge Base成果物」と位置付ける。

## KB-001 : Create Knowledge Base Development Guide

### Priority
High (After Sprint001)

### Background
As the Knowledge Base grows, architectural consistency should not rely only on individual templates and research policies. A higher-level development guide is required to define the governance of the entire Knowledge Base.

### Goal
Create `Knowledge Base Development Guide.md` as the constitutional document for the Knowledge Base.

### Expected Contents

- Knowledge Base philosophy
- Explainable AI principles
- Research → Catalog → DDL → Entity → Advisor → ML workflow
- Responsibility of each document
- Naming conventions
- Folder governance
- Review process
- Versioning policy
- Change management
- Quality gates
- Definition of completion for each artifact

### Deliverables

- Knowledge Base Development Guide.md

### Dependencies

- ResearchPolicy.md
- ResearchWritingGuide.md
- IndustryFramework.md
- IndustryResearch_Template.md
- CompanyResearch_Template.md

### Status

Backlog

## KB-002 : Define Raw Data / Knowledge / Derived Features Architecture

### Priority
High

### Background
As the Knowledge Base expands, the system must clearly separate raw observable data, investment knowledge, engineered features, and final advisor/ML usage.

### Goal
Define a four-layer architecture:

1. Raw Data
2. Knowledge
3. Derived Features
4. Advisor / ML

### Design Principle

Raw Data represents observed facts from APIs, financial statements, IR materials, or industry statistics.

Knowledge defines what should be evaluated and how it should be interpreted.

Derived Features transform raw data and knowledge into reusable quantitative or qualitative features.

Advisor and ML consume Derived Features and Knowledge to generate predictions, scores, and explainable recommendations.

### Example

For CapEx:

- Raw Data: Annual or quarterly capital expenditure amount
- Knowledge: CapEx is important for semiconductor equipment and manufacturing-related companies
- Derived Feature: CapExGrowth, CapExToSales, CapExCycleScore
- Advisor: Explains whether investment expansion is positive or risky
- ML: Uses engineered CapEx features as model inputs

### Status
Backlog

## KB-003 : Introduce Knowledge Graph Architecture

### Priority
Medium-High

### Background
Industry Research revealed that investment knowledge is not only a list of facts, but also a network of causal relationships among demand drivers, technologies, subsectors, KPIs, companies, and financial outcomes.

### Goal
Introduce a Knowledge Graph architecture to represent causal investment logic.

### Concept
Knowledge Graph should represent nodes such as:

- Demand drivers
- Technologies
- SubSectors
- Industry KPIs
- Companies
- Financial metrics
- Risks
- Opportunities

And relations such as:

- increases
- decreases
- supports
- depends_on
- exposed_to
- benefits_from
- risks_from

### Example
AI Demand
→ increases
HBM Demand
→ increases
Memory CapEx
→ increases
Equipment Demand
→ improves
Book-to-Bill
→ supports
Tokyo Electron Revenue

### Initial Usage
- Advisor explanation
- Industry Knowledge Score
- SubSector tailwind/headwind detection
- Risk warning
- Future ML feature engineering

### Scope Control
Do not design Graph DB, graph embeddings, or DDL in Sprint001.

In Sprint001:

- Describe causal chains in Industry Research
- Record links between Industry Knowledge and Company Research
- Keep this as an architecture backlog item

### Future Usage
Knowledge Graph signals may be combined with ML prediction scores, financial quality scores, valuation scores, technical scores, and market regime scores to produce a final explainable advisor score.

### Status
Backlog