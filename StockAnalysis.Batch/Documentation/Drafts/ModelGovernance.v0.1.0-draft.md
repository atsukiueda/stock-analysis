# Model Governance

> **Draft — not released.** Proposed Policy. It is not effective until independently reviewed, approved, and released.

| Field | Value |
|---|---|
| Document | Model Governance |
| Revision | ModelGovernance@0.1.0-draft |
| Document class | Policy |
| Owner | Project Director |
| Status | Draft |
| Governing document | `000_ProjectDocumentationConstitution.md` |

## 1. Purpose and applicability

This Policy governs new project-level model-governance artifacts and governed model or decision-system work within its stated scope. It applies Knowledge Base First, evidence, traceability, explainability, independent review, and long-term maintainability to the downstream path from Database through ML, Decision Engine, and Advisor.

Existing Knowledge Base, research, documentation, development, and any existing data or database authority remain unchanged unless an approved migration explicitly changes their relationship. Future data or database controls require separately approved governance artifacts.

## 2. Vision and principles

The purpose of governed models is to support explainable, evidence-based investment decision systems. Models exist to support explainable, evidence-based decisions rather than to maximize predictive accuracy alone.

- **Governed upstream knowledge.** Model and decision-system work uses or validates applicable upstream authority.
- **Explainable behavior.** Features, predictions, Decision Engine behavior, and Advisor output remain understandable in their applicable relationships.
- **Separate validation.** Model validation and investment validation are distinct concerns.
- **Human judgment.** Human judgment or override remains an available governance consideration; its authority and mechanism are delegated.
- **Traceable evolution.** Material changes, validation evidence, and resulting behavior remain traceable through applicable controls.

## 3. Governance relationship and scope

```text
Research → Independent Review → Catalog → DDL → Entity → Database → ML → Decision Engine → Advisor
                                           └──── governed downstream segment ────┘
```

```text
Project Constitution
  ↓
Model Governance (this proposed Policy)
  ↓
Model and Decision-System Standards / Procedures
  ↓
Templates and Records
```

This Policy governs model and decision-system direction, not investment conclusions, advisor wording, algorithms, feature selection, thresholds, or implementation methods.

## 4. Authority, roles, and decisions

The Project Director remains accountable until a model-domain steward is appointed through the Constitution’s role-profile and delegation process. Participation by human specialists, Codex, other AI agents, or external reviewers does not grant authority beyond an assigned role.

Use the [Role Organization](000_ProjectDocumentationConstitution.md#5-role-organization) and [Decision Authority Matrix](000_ProjectDocumentationConstitution.md#6-decision-authority-matrix) for authoritative role and decision routing. This Policy creates no new role or decision authority.

## 5. Model lifecycle direction

Model lifecycle is a governed concern. The following is a non-normative orientation only; it establishes no stages, gates, sequence, or procedure:

```text
Training → Validation → Approval → Release → Monitoring → Retirement
```

A future Model Lifecycle Standard defines any lifecycle mechanics.

## 6. Explainability, validation, and monitoring

Explainability must preserve understandable relationships from applicable governed knowledge through features and predictions to Decision Engine and Advisor behavior. The applicable lower-level controls determine representation and evidence.

Model validation evaluates model or decision-system fitness within its governed purpose. Investment validation evaluates investment or strategy behavior and is not established by model fitness alone. Their methods, criteria, and authority remain separately governed.

Monitoring direction includes model drift, data drift, performance, and decision consistency where applicable. Metrics, thresholds, response methods, and incident procedures are delegated.

## 7. Change, interfaces, and domain boundaries

Material model or decision-system changes MUST remain within applicable constitutional authority and preserve decision context through canonical controls. Development Governance governs software development direction; Documentation Governance governs publication; research authorities govern research evidence; and future data or database controls govern their assigned mechanics.

This Policy supplies no substitute method where a lower-level or adjacent-domain control is not yet released.

## 8. Delegated controls

| Control need | Intended artifact class |
|---|---|
| Model lifecycle mechanics | Standard |
| Model and decision-system validation | Standard or Procedure |
| Investment validation | Applicable future investment governance artifact |
| Explainability and traceability | Standard |
| Monitoring and incident response | Procedure |
| Model change method | Procedure |
| Evidence and approval structure | Standard or Procedure, with Templates and Records supporting execution and evidence |

## 9. Exceptions and maintenance

No exception may weaken the Project Constitution. Conflicts and unassigned decisions are routed to the authority identified by the Constitution, with the Project Director resolving unresolved constitutional conflicts.

The Project Director owns this Policy until a model-domain steward is appointed through the Constitution’s role-profile and delegation process. Revisions MUST preserve the scope and delegated-control boundaries of this Policy.
