# 日本株AI投資システム

> **Draft — not released.** This is a navigational document only; it introduces no new policy, decision, or system design.

| Field | Value |
|---|---|
| Document | README |
| Revision | README@0.2.0-draft |
| Artifact type | Navigational index |
| Owner | Documentation Director |
| Status | Draft |
| Governing document | `000_ProjectDocumentationConstitution.md` |

## Purpose

This repository develops a long-lived Japanese equity AI investment system. Its major domains include Knowledge Base, industry research, EDINET, J-Quants, Azure SQL, C#/.NET, Entity Framework Core, ML.NET, Decision Engine, and Advisor.

This README is the entry point for approved project documentation. It does not replace the documents it links to.

## Project vision

Japanese equity AI investment support, built Knowledge Base First.

Evidence-based decision making and explainable AI guide the system from research to advisor output.

The project favors long-term maintainability over short-term implementation speed.

## Project principles

- Knowledge Base First
- Research before implementation
- Evidence before opinion
- Independent review before approval
- Architecture before implementation

For the governing principles and authority boundaries, read the [Project Constitution](000_ProjectDocumentationConstitution.md) and [Knowledge Base Rules](KnowledgeBase/00_Project/KnowledgeBaseRules.md).

## Repository structure

| Location | Purpose |
|---|---|
| `Documentation/` | Drafts, released-document evidence, and documentation records |
| `KnowledgeBase/` | Knowledge Base governance, research, standards, and templates |
| `StockAnalysis.Batch/` | Application source project |

## Project roadmap

```text
Research
  ↓
Independent Review
  ↓
Catalog
  ↓
DDL
  ↓
Entity
  ↓
Database
  ↓
Machine Learning
  ↓
Decision Engine
  ↓
Advisor
```

## Project organization

The Project Director sets direction and final substantive decisions. Documentation Team, Research Team, Codex, and the Review Board collaborate under the Role Organization defined in the [Project Constitution](000_ProjectDocumentationConstitution.md).

## Workflow entry points

Workflow documents will be added here as they are released:

| Workflow | Canonical document |
|---|---|
| Documentation workflow | Planned — this entry will link to its canonical workflow document when released |
| Research workflow | [ResearchPolicy.md](KnowledgeBase/00_Project/ResearchPolicy.md) |
| Development workflow | Planned — this entry will link to its canonical workflow document when released |

## Start here

1. [Project Constitution](000_ProjectDocumentationConstitution.md) — project principles, authority, organization, and governing-document hierarchy.
2. [Knowledge Base Governance Overview](KnowledgeBase/00_Project/GovernanceOverview.md) — existing Knowledge Base documentation map and reading order.
3. [Knowledge Base Rules](KnowledgeBase/00_Project/KnowledgeBaseRules.md) — existing Knowledge Base subject-matter constitution.

## Documentation status overview

The Project Constitution is released. The remaining documentation set is being introduced through controlled drafts and independent review. Existing Knowledge Base documents remain authoritative within their stated scope until an approved migration changes them.

## Existing Knowledge Base governance

| Purpose | Canonical existing document |
|---|---|
| Knowledge Base rules | [KnowledgeBaseRules.md](KnowledgeBase/00_Project/KnowledgeBaseRules.md) |
| Research procedure | [ResearchPolicy.md](KnowledgeBase/00_Project/ResearchPolicy.md) |
| Review policy | [ReviewPolicy.md](KnowledgeBase/00_Project/ReviewPolicy.md) |
| Naming convention | [NamingConvention.md](KnowledgeBase/00_Project/NamingConvention.md) |
| Decision history | [DecisionLog.md](KnowledgeBase/00_Project/DecisionLog.md) |
| Architecture backlog | [ArchitectureBacklog.md](KnowledgeBase/00_Project/ArchitectureBacklog.md) |

## Current publication snapshot

| Publication status | Current entry |
|---|---|
| Draft | `README@0.2.0-draft` — this document; not canonical |
| Released | [Project Constitution](000_ProjectDocumentationConstitution.md) |
| Existing authoritative documents | `KnowledgeBase/00_Project/` within each document's stated scope |
| Planned navigation | Documentation and development workflow links will be added when their canonical documents are released |

## Records

The approval, release, and identifier evidence for the Project Constitution are retained in `Documentation/Records/`.

## Boundaries

This README is an index. For a rule, decision, workflow, or technical design, follow the linked canonical document rather than treating this summary as an authority.
