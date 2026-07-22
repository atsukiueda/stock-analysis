# Project Instructions

> **Draft — not released.** This document is an operational routing guide. It creates no policy, standard, procedure, technical design, or decision.

| Field | Value |
|---|---|
| Document | Project Instructions |
| Revision | ProjectInstructions@0.1.0-draft |
| Document class | Guide |
| Owner | Documentation Director |
| Status | Draft |
| Governing document | `000_ProjectDocumentationConstitution.md` |

## 1. Purpose and boundary

This guide lists available canonical starting points for governed work. It does not replace, interpret beyond its stated text, establish precedence, or override any linked authority.

`000_ProjectDocumentationConstitution.md` is the single effective Project Constitution. A separate `ProjectConstitution.md` is intentionally not created, because it would duplicate constitutional authority.

## 2. Authority and reading order

Select the listed document whose stated scope matches the subject. The Project Constitution defines governing-document hierarchy and conflict authority; this guide does not add a conflict-resolution method.

| Need | Start with |
|---|---|
| Project principles, authority, organization, or document hierarchy | [Project Constitution](000_ProjectDocumentationConstitution.md) |
| Knowledge Base scope, structure, or stewardship | [KnowledgeBaseRules.md](KnowledgeBase/00_Project/KnowledgeBaseRules.md) |
| Research method, source handling, or research outputs | [ResearchPolicy.md](KnowledgeBase/00_Project/ResearchPolicy.md) and [ResearchWritingGuide.md](KnowledgeBase/00_Project/ResearchWritingGuide.md) |
| Existing Knowledge Base review practice | [ReviewPolicy.md](KnowledgeBase/00_Project/ReviewPolicy.md) |
| Names and identifiers | [NamingConvention.md](KnowledgeBase/00_Project/NamingConvention.md) |
| Existing decisions or unresolved architecture work | [DecisionLog.md](KnowledgeBase/00_Project/DecisionLog.md) and [ArchitectureBacklog.md](KnowledgeBase/00_Project/ArchitectureBacklog.md) |

## 3. Work routing

The following table groups the currently known routing targets. A planned target indicates that no domain-specific canonical control is yet published.

| Work area | Current routing target | Status |
|---|---|---|
| Knowledge Base and research | Existing Knowledge Base rules and research documents listed in section 2 | Existing authority |
| Documentation lifecycle and publication | Project Constitution boundary; future Documentation Governance | Planned domain control |
| Software development | Project Constitution boundary; future Development Governance | Planned domain control |
| Research data concerns | Data Governance Lead role in the [Project Constitution](000_ProjectDocumentationConstitution.md) | Existing role; no separate governance domain established |
| Other data concerns | Project Constitution boundary | Domain ownership not yet determined |
| Model and decision-system governance | Project Constitution boundary; future Model Governance | Planned domain control |

Where no applicable canonical target is listed, this guide supplies no decision authority. Refer to the Project Constitution for the responsible authority and conflict route.

## 4. Knowledge Base First

The project’s governing direction is:

```text
Research → Independent Review → Catalog → DDL → Entity → Database → ML → Decision Engine → Advisor
```

Start upstream where the work is knowledge-dependent. Downstream work must use or validate applicable governed upstream knowledge and must route material feedback to the responsible upstream domain. The Project Constitution is the authority for this direction; this guide only provides the entry point.

## 5. Evidence and claim handling

For research or Knowledge Base evidence and claim handling, use the [Research Policy](KnowledgeBase/00_Project/ResearchPolicy.md) and [Research Writing Guide](KnowledgeBase/00_Project/ResearchWritingGuide.md). This guide adds no evidence or claim-handling rule.

## 6. Collaboration and review routing

Use the Role Organization and Decision Authority Matrix in the Project Constitution to identify the responsible role. Use the existing Review Policy for current Knowledge Base review practice.

The Project Constitution defines the author and independent-review boundaries. For a domain without a released workflow, this guide supplies no substitute workflow; refer to the Constitution for the responsible authority.

## 7. Change, conflict, and escalation

Do not use this guide to authorize a new architecture, migration, deletion, rename, model decision, data control, or investment conclusion.

Escalate to the Project Director when an unresolved constitutional conflict exists. Route ordinary domain decisions to the role with the relevant authority in the Project Constitution. The Constitution states the requirements for preserving material decisions; use the applicable canonical record or future record standard rather than this guide for record content.

## 8. Maintenance

The Documentation Director owns this guide. Its maintenance is limited to keeping listed routes and the routing-only boundary current. Documentation lifecycle mechanics are governed by the applicable Documentation Governance artifact when released.

## 9. Boundaries

This guide deliberately does not define implementation practices, coding standards, test methods, schema rules, model methods, evidence thresholds, review checklists, naming syntax, lifecycle mechanics, or migration procedures. Follow the relevant current or future canonical artifact for those subjects.
