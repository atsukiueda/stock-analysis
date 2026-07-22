# Structure Design — DevelopmentGovernance.md

> **Draft — not released.** This is a structure proposal for Development Governance, not development policy.

| Field | Value |
|---|---|
| Proposed artifact | `DevelopmentGovernance.md` |
| Proposed title | Development Governance |
| Proposed document class | Policy |
| Status | Draft — structure design |
| Owner | Project Director; a development-domain steward may be appointed under the constitutional role-profile and delegation process |
| Governing document | `000_ProjectDocumentationConstitution.md` |

## 1. Responsibility

The proposed Policy will govern new project-level development-governance artifacts and governed development work within its stated scope beneath the Project Constitution. It will apply Knowledge Base First, Architecture Before Implementation, evidence, traceability, independent review, and long-term maintainability to development work without prescribing a technology-specific implementation method.

It will not supersede existing Knowledge Base authority, research evidence practice, documentation governance, model governance, or future domain-specific database controls. Existing Knowledge Base and research authorities remain unchanged unless an approved migration explicitly changes their relationship. The Project Director remains accountable until a development-domain steward is appointed through the Constitution’s role-profile and delegation process.

## 2. Proposed chapters

| Chapter | Responsibility | Boundary / primary dependency |
|---|---|---|
| Purpose, scope, and exclusions | Define development-domain applicability | Project Constitution §§1, 3, 9 |
| Development vision and principles | State durable development-direction goals | Project Constitution §2 |
| Governance relationship and scope | Show Constitution → Development Governance → future controls | Project Constitution §3 |
| Authority, roles, and decisions | Route ownership, Codex, and review authority without duplicating roles | Project Constitution §§5–6 |
| Knowledge and architecture dependency | Apply Knowledge Base First and Architecture Before Implementation | Project Constitution §§2, 4 |
| Change and design decision policy | Require governed decisions for material changes; delegate methods | Project Constitution P-015–P-016 |
| Quality, validation, and review policy | Establish durable quality direction; delegate testing and review mechanics | Project Constitution §§2, 7 |
| Interfaces, data, and model boundaries | Preserve upstream authority and avoid cross-domain takeover | Governance hierarchy; future domain controls |
| Delivery evidence and traceability | Establish traceability direction; delegate evidence schemas | Project Constitution §2 |
| Delegated-control register | Identify Coding, Testing, Review, Delivery, and change-control artifacts | Project Constitution P-025 |
| Exceptions and maintenance | Route conflicts and preserve Policy boundary | Project Constitution P-005; §§6, 8–9 |

## 3. Explicit delegations

The Policy will not define language syntax, framework selection, API contracts, database schema, ORM configuration, security controls, build commands, branch strategy, code-review checklists, test cases, coverage thresholds, deployment commands, CI configuration, release cadence, or data/model methods. These belong to approved Standards, Procedures, Guides, Templates, or Records in the applicable domain.

## 4. Existing-document relationship

| Existing artifact | Treatment in this Policy |
|---|---|
| Project Constitution | Controlling authority and source of roles, decisions, and project principles |
| Documentation Governance | Sibling domain Policy; governs project-level documentation, not software implementation |
| Existing `KnowledgeBase/00_Project` authorities | Upstream or adjacent authority; unchanged unless an approved migration says otherwise |
| ArchitectureBacklog.md and DecisionLog.md | Existing context and history; neither silently authorizes an implementation change |
| ReviewPolicy.md | Existing Knowledge Base review practice only; development review mechanics remain delegated |

## 5. Future-control map

The Policy will establish, but not itself implement, the need for: Coding Standards; Testing and Validation Standard; Software Review Standard or Procedure; Architecture Change Procedure; Build and Delivery Procedure; development evidence and decision Record templates; and future database/interface controls where separately governed.

## 6. Review criteria

Independent review must verify: constitutional consistency; correct application of Knowledge Base First; no design or technology decision disguised as policy; separation from Documentation, Knowledge Base, Research, Database, and Model Governance; independent-review integrity; complete delegation of mechanics; and scalability to human developers, Codex, other AI agents, and external reviewers.
