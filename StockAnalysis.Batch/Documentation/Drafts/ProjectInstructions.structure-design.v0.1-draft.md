# Structure Design — ProjectInstructions.md

> **Draft — not released.** This is a structure proposal, not an operational instruction.

| Field | Value |
|---|---|
| Proposed artifact | `ProjectInstructions.md` |
| Status | Draft — structure design |
| Owner | Documentation Director |
| Governing document | `000_ProjectDocumentationConstitution.md` |
| Dependency baseline | Existing `KnowledgeBase/00_Project` governance documents |

## 1. Artifact disposition

`ProjectConstitution.md` is not created: the released `000_ProjectDocumentationConstitution.md` is the effective Project Constitution. Creating a second constitution would duplicate authority. The next substantive artifact is `ProjectInstructions.md`.

## 2. Responsibility

`ProjectInstructions.md` will be the practical entry instruction for project participants. It will route work to canonical Policies, Standards, Procedures, Guides, Templates, and Records; it will not restate or override them.

## 3. Proposed chapters

| Chapter | Responsibility | Primary dependency |
|---|---|---|
| Purpose and boundary | Define the instruction document as an operational router | Project Constitution §1, §3 |
| Authority and precedence | Direct readers to the applicable canonical source | Project Constitution §3 |
| Work classification | Route work to an available canonical target or mark the target as planned | Project Constitution §3 |
| Knowledge Base First | State the required entry direction and handoff references | Project Constitution §4; KnowledgeBaseRules |
| Evidence and claim handling | Link to evidence and research controls | ResearchPolicy; ResearchWritingGuide |
| Documentation handling | Link to lifecycle, review, and publication controls when released | Project Constitution; future Documentation Governance |
| Collaboration and review | Route roles and independent review to the Constitution | Project Constitution §5–§7 |
| Change and escalation | Route conflicts and material changes to the responsible authority | Project Constitution §1 (P-005); §6 |
| Maintenance | Limit maintenance to this artifact's ownership and replacement reference | Project Constitution §8–§9 |

## 4. Explicit exclusions

The artifact will not define architecture, coding rules, database schemas, model methods, evidence thresholds, lifecycle mechanics, review checklists, naming syntax, or migration procedures. Those belong to the applicable lower-level canonical artifact.

## 5. Dependencies and future extensibility

The document will link to existing Knowledge Base governance without relocating or superseding it. Future Documentation, Development, Research, Knowledge Base, and Model Governance documents can be added as canonical routing targets without changing the instruction document's role.

Until a domain-specific target is released, the instruction will identify it as planned rather than inventing a substitute control.

| Work area | Current routing target | Target status |
|---|---|---|
| Knowledge Base and research | `KnowledgeBase/00_Project/KnowledgeBaseRules.md`, `ResearchPolicy.md`, and `ResearchWritingGuide.md` | Existing authority |
| Documentation lifecycle | Project Constitution boundary only | Planned Documentation Governance |
| Development | Project Constitution boundary only | Planned Development Governance |
| Data and model governance | Project Constitution boundary only | Planned Data / Model Governance |

## 6. Review criteria

Independent review must confirm that the proposed document: preserves a single authority source; contains no new governing rule; distinguishes instruction from policy; has no broken or circular routing; and remains usable by AI agents, human developers, and external reviewers.
