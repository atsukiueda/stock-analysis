# Development Governance

> **Draft — not released.** Proposed Policy. It is not effective until independently reviewed, approved, and released.

| Field | Value |
|---|---|
| Document | Development Governance |
| Revision | DevelopmentGovernance@0.1.0-draft |
| Document class | Policy |
| Owner | Project Director |
| Status | Draft |
| Governing document | `000_ProjectDocumentationConstitution.md` |

## 1. Purpose and applicability

This Policy establishes durable direction for new project-level development-governance artifacts and governed development work within its stated scope. It applies the Project Constitution’s Knowledge Base First, Architecture Before Implementation, evidence, traceability, independent-review, and long-term-maintainability principles to development work.

Existing Knowledge Base and research authorities remain outside this Policy’s scope unless an approved migration explicitly changes their relationship. This Policy does not supersede Documentation Governance, Model Governance, existing Knowledge Base authority, research evidence practice, or a future separately governed data or database control.

## 2. Development vision and principles

Development exists to operationalize governed knowledge and architecture into maintainable system behavior, not to become an unreviewed source of project truth.

- **Knowledge before code.** Development uses or validates applicable governed upstream knowledge.
- **Architecture before implementation.** Material design direction precedes implementation work.
- **Traceable change.** Material development decisions and their effects remain traceable through applicable controls.
- **Independent review.** Review seeks defects independently of authorship.
- **Maintainable operation.** Long-term clarity and evolvability take priority over short-term convenience.

These principles apply the Project Constitution to the development domain; they do not add a higher authority or prescribe an implementation method.

## 3. Governance relationship and scope

```text
Project Constitution
  ↓
Development Governance (this proposed Policy)
  ↓
Development Standards
  ↓
Development Procedures
  ↓
Templates and Records
```

```text
Development Governance scope
├── Project-level development direction in stated scope
│   ├── Knowledge and architecture dependency
│   ├── Development quality and review direction
│   └── Change, delivery-evidence, and traceability direction
└── Outside scope unless approved governance changes it
    ├── Existing KnowledgeBase/00_Project authority
    ├── Research evidence fitness and claim handling
    ├── Documentation publication governance
    ├── Model governance
    └── Database, data, and interface control mechanics
```

## 4. Authority, roles, and decisions

The Project Director remains accountable for development-domain direction until a steward is appointed through the Constitution’s role-profile and delegation process. An appointment does not transfer accountability unless an approved authority matrix expressly does so.

The Constitution defines the role, decision, and independent-review boundaries. Codex executes only assigned work within its authority; it does not set development policy or approve its own work. Use the [Role Organization](000_ProjectDocumentationConstitution.md#5-role-organization) and [Decision Authority Matrix](000_ProjectDocumentationConstitution.md#6-decision-authority-matrix) for authoritative routing.

## 5. Knowledge and architecture dependency

Governed development work MUST use or validate applicable upstream knowledge before operationalizing it. The governing dependency direction is Research → Independent Review → Catalog → DDL → Entity → Database → ML → Decision Engine → Advisor.

Development MUST NOT silently replace reviewed knowledge, architecture direction, or governed upstream decisions. This Policy does not determine how a dependency is represented, validated, or implemented.

## 6. Change and design decision direction

Material development changes MUST remain within the authority and architecture direction established by applicable canonical artifacts. Where a material change requires a decision, use the authority identified by the Constitution and preserve its context through the applicable canonical controls.

Existing [ArchitectureBacklog.md](KnowledgeBase/00_Project/ArchitectureBacklog.md) and [DecisionLog.md](KnowledgeBase/00_Project/DecisionLog.md) provide existing context and history; neither independently authorizes implementation or a new architecture decision.

## 7. Quality, validation, and review direction

Development work MUST be designed for maintainability, traceability, explainability where applicable, and independent review. Quality and validation controls must be sufficient for the governed risk and responsibility of the work.

This Policy does not define test methods, acceptance criteria, code-review mechanics, thresholds, or tooling. Existing [ReviewPolicy.md](KnowledgeBase/00_Project/ReviewPolicy.md) remains Knowledge Base review practice only and does not establish development-review mechanics.

## 8. Interface and domain boundaries

Development consumes and operationalizes applicable knowledge, data, model, and documentation outputs without taking authority over their source domains. Documentation publication is governed by Documentation Governance; research evidence by existing research authorities; model direction by Model Governance; and future data, database, and interface controls by their applicable governance artifacts.

Where no specific lower-level control exists, this Policy supplies direction but no substitute implementation procedure.

## 9. Delivery evidence and traceability

Development work MUST preserve the level of traceability required by applicable canonical controls between its upstream authority, material decisions, and resulting work product. Evidence schemas, retention, record formats, and delivery mechanics are delegated to lower-level controlled artifacts.

## 10. Delegated controls

The following controls require approved lower-level artifacts before their detailed mechanisms may be treated as established:

| Control need | Intended artifact class |
|---|---|
| Coding conventions and implementation quality | Standard |
| Testing and validation mechanics | Standard or Procedure |
| Software review mechanics | Standard or Procedure |
| Architecture-change method | Procedure |
| Build and delivery method | Procedure |
| Development decision and evidence structure | Standard or Procedure for structure; Template and Record for execution and evidence |
| Database and interface controls | Applicable future governance artifact and Standard |

## 11. Exceptions and maintenance

No exception may weaken the Project Constitution. Conflicts and unassigned development decisions are routed to the authority identified by the Constitution, with the Project Director resolving unresolved constitutional conflicts.

The Project Director owns this Policy until a steward is appointed through the Constitution’s role-profile and delegation process. Revisions MUST preserve sections 1 and 3 scope boundaries and the delegated-control boundary in section 10. Detailed lifecycle and maintenance mechanics remain delegated.
