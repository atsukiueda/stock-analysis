# Project Instructions

> **APPROVED AND RELEASED.** This is an operational entry and routing guide. It creates no policy, standard, procedure, technical design, or decision.

| Field | Value |
|---|---|
| Document | Project Instructions |
| Revision | ProjectInstructions@0.2.0-draft |
| Document class | Guide |
| Owner | Documentation Director |
| Status | Released |
| Governing document | `000_ProjectDocumentationConstitution.md` |

## 1. Purpose and boundary

This guide is the operational entry point for human developers, AI agents, Codex, researchers, authors, and reviewers. It helps a participant find an available canonical document; it does not replace, interpret beyond its stated text, establish precedence, or override any linked authority.

`000_ProjectDocumentationConstitution.md` is the single effective Project Constitution. A separate `ProjectConstitution.md` is intentionally not created, because it would duplicate constitutional authority.

## 2. First steps

For a new participant, read in this order:

1. [README](README.md) — project entry and documentation map.
2. [Project Constitution](000_ProjectDocumentationConstitution.md) — principles, authority, organization, and governing-document hierarchy.
3. This Project Instructions guide — practical routing to available canonical documents.
4. [Knowledge Base Rules](KnowledgeBase/00_Project/KnowledgeBaseRules.md) — Knowledge Base scope and stewardship.
5. [Research Policy](KnowledgeBase/00_Project/ResearchPolicy.md) — research work and evidence practice.

## 3. If unsure where to start, start upstream

> **If you are unsure where to start, start upstream.**

This is a navigation aid for the project’s Knowledge Base First philosophy, not a new decision rule. Existing knowledge and research are the upstream context for downstream operational work; beginning there helps participants avoid detached implementation.

```text
Knowledge
  ↓
Research
  ↓
Review
  ↓
Catalog
  ↓
Implementation
```

For the governing dependency direction, use the Project Constitution: Research → Independent Review → Catalog → DDL → Entity → Database → ML → Decision Engine → Advisor.

## 4. Find the right starting point

| If you want to… | Start with | Notes |
|---|---|---|
| Understand project direction or authority | [Project Constitution](000_ProjectDocumentationConstitution.md) | Includes the Role Organization and Decision Authority Matrix. |
| Start industry research | [ResearchPolicy.md](KnowledgeBase/00_Project/ResearchPolicy.md) | Use the Research Writing Guide for research outputs. |
| Update or curate the Knowledge Base | [KnowledgeBaseRules.md](KnowledgeBase/00_Project/KnowledgeBaseRules.md) | Start with existing Knowledge Base scope and stewardship. |
| Locate existing DDL-related knowledge | [KnowledgeBaseRules.md](KnowledgeBase/00_Project/KnowledgeBaseRules.md) | Domain-specific development governance is planned. |
| Request or conduct a Knowledge Base review | [ReviewPolicy.md](KnowledgeBase/00_Project/ReviewPolicy.md) | Existing Knowledge Base review practice only. |
| Check a naming convention | [NamingConvention.md](KnowledgeBase/00_Project/NamingConvention.md) | Existing naming authority. |
| Understand an existing decision | [DecisionLog.md](KnowledgeBase/00_Project/DecisionLog.md) | Existing decision history. |
| Inspect unresolved architecture work | [ArchitectureBacklog.md](KnowledgeBase/00_Project/ArchitectureBacklog.md) | Not an authority to implement a change. |
| Find who can decide a matter | [Project Constitution — Decision Authority Matrix](000_ProjectDocumentationConstitution.md#6-decision-authority-matrix) | The Constitution is authoritative. |

## 5. Knowledge Base First

Knowledge Base First keeps research, review, and cataloged knowledge upstream of database, machine-learning, decision-engine, and advisor work. This direction preserves traceability from downstream behavior back to reviewed knowledge and prevents implementation from silently becoming the source of truth.

This guide does not add to the governed flow. Use the Project Constitution for its authority and the applicable Knowledge Base or research document for the work itself.

## 6. Planned domain navigation

The following entries make known gaps visible. They are not temporary policies or substitute procedures.

| Planned domain | Current starting point | Status |
|---|---|---|
| Documentation Governance | Project Constitution boundary | Canonical domain document not yet released |
| Development Governance | Project Constitution boundary | Canonical domain document not yet released |
| Model Governance | Project Constitution boundary | Canonical domain document not yet released |
| Documentation workflow | This guide and the Project Constitution | Canonical workflow document not yet released |
| Development workflow | This guide and the Project Constitution | Canonical workflow document not yet released |

Research Governance and Knowledge Base Governance currently route through the existing `KnowledgeBase/00_Project` authorities. The Constitution defines the final governance hierarchy.

## 7. Typical scenarios

| Scenario | Go to |
|---|---|
| I want to begin industry research | [Research Policy](KnowledgeBase/00_Project/ResearchPolicy.md) → [Research Writing Guide](KnowledgeBase/00_Project/ResearchWritingGuide.md) |
| I want to update the Knowledge Base | [Knowledge Base Rules](KnowledgeBase/00_Project/KnowledgeBaseRules.md) |
| I want Codex to implement something | [Project Constitution](000_ProjectDocumentationConstitution.md) → planned Development Governance |
| I want to change architecture | [Decision Authority Matrix](000_ProjectDocumentationConstitution.md#6-decision-authority-matrix) → [Architecture Backlog](KnowledgeBase/00_Project/ArchitectureBacklog.md) for context |
| I want to write a project document | [README](README.md) → planned Documentation Governance |
| I want to review an existing Knowledge Base artifact | [Review Policy](KnowledgeBase/00_Project/ReviewPolicy.md) |

## 8. Collaboration and review routing

The Project Constitution defines roles, decision authority, collaboration, and independent-review boundaries. Use its [Role Organization](000_ProjectDocumentationConstitution.md#5-role-organization) and [Decision Authority Matrix](000_ProjectDocumentationConstitution.md#6-decision-authority-matrix) to locate the responsible role.

For existing Knowledge Base review practice, use the [Review Policy](KnowledgeBase/00_Project/ReviewPolicy.md). This guide supplies no substitute workflow for an unreleased domain.

## 9. Change, conflict, and escalation

This guide does not authorize an architecture change, migration, deletion, rename, model decision, data control, or investment conclusion.

The Project Constitution identifies the authority for unresolved constitutional conflicts and ordinary domain decisions. Use the applicable canonical record or future record standard for decision evidence and record content.

## 10. Maintenance

The Documentation Director owns this guide. Its maintenance is limited to keeping listed routes and the routing-only boundary current. Documentation lifecycle mechanics are governed by the applicable Documentation Governance artifact when released.

## 11. Boundaries

This guide deliberately does not define implementation practices, coding standards, test methods, schema rules, model methods, evidence thresholds, review checklists, naming syntax, lifecycle mechanics, or migration procedures. Follow the relevant current or future canonical artifact for those subjects.
