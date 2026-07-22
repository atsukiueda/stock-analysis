# Structure Design — ModelGovernance.md

> **Draft — not released.** This is a structure proposal for Model Governance, not model policy.

| Field | Value |
|---|---|
| Proposed artifact | `ModelGovernance.md` |
| Proposed title | Model Governance |
| Proposed document class | Policy |
| Revision | ModelGovernanceStructure@0.2-draft |
| Status | Draft — structure design |
| Owner | Project Director; model-domain stewardship may be appointed through the constitutional role-profile and delegation process |
| Governing document | `000_ProjectDocumentationConstitution.md` |

## 1. Responsibility

The proposed Policy will govern new project-level model-governance artifacts and governed model or decision-system work within its stated scope. Its vision is to support explainable, evidence-based investment decision systems rather than to maximize predictive accuracy alone. It will apply Knowledge Base First, evidence, traceability, explainability, independent review, and long-term maintainability without prescribing model algorithms, features, thresholds, investment conclusions, or implementation methods.

Existing Knowledge Base, research, documentation, development, and any existing data or database authorities remain unchanged unless an approved migration explicitly changes their relationship. Future data or database controls require separately approved governance artifacts. The Project Director remains accountable until a model-domain steward is appointed under the Constitution.

## 2. Proposed chapters

| Chapter | Responsibility | Boundary / primary dependency |
|---|---|---|
| Purpose, scope, and exclusions | Define model and decision-system applicability | Project Constitution §§1, 3, 9 |
| Model Governance vision and principles | State durable model-direction goals | Project Constitution §2 |
| Governance relationship and scope | Show Constitution → Model Governance → future controls | Project Constitution §3 |
| Authority, roles, and decisions | Route existing constitutional role profiles and any appointed model-development steward | Project Constitution §§5–7 |
| Governed upstream dependency | Apply the full Knowledge Base First path; identify Database → ML → Decision Engine → Advisor as its relevant downstream segment | Project Constitution §4 |
| Model and decision-system boundary | Distinguish models, decision logic, advisor output, and investment conclusions | Governance hierarchy; Investment review scope |
| Model lifecycle direction | Identify Training → Validation → Approval → Release → Monitoring → Retirement as a Policy-level orientation; delegate mechanics | Project Constitution §§2, 7, 9 |
| Explainability, traceability, and provenance | Establish direction across features, predictions, Decision Engine, and Advisor behavior | Project Constitution §2 |
| Validation, investment-validation, risk, and monitoring direction | Distinguish model validation from investment validation; identify drift, performance, and decision consistency as monitoring scope; delegate methods and thresholds | Project Constitution §§2, 7 |
| Human judgment boundary | Establish that human judgment or override remains an available governance consideration; delegate authority and mechanism | Project Constitution §§5–6 |
| Change and release direction | Govern material model/decision changes; delegate lifecycle mechanics | Project Constitution P-015–P-016, P-025 |
| Data and development interfaces | Preserve adjacent authority and lineage boundaries | Development Governance; future data controls |
| Delegated-control register | Identify lifecycle, validation, monitoring, evidence, and change controls | Project Constitution P-025 |
| Exceptions and maintenance | Route conflicts and preserve Policy boundary | Project Constitution P-005; §§6, 8–9 |

## 3. Explicit delegations

The Policy will not define model algorithms, feature selection, label design, training configuration, ML.NET usage, thresholds, optimization objectives, backtest method, walk-forward method, performance targets, risk limits, monitoring metrics, data transformation logic, production deployment, investment recommendation, or advisor wording. These belong to approved lower-level artifacts in the applicable domain.

## 4. Existing-document relationship

| Existing artifact | Treatment in this Policy |
|---|---|
| Project Constitution | Controlling authority; source of roles, decisions, dependency direction, and project principles |
| Development Governance | Sibling Policy; governs development direction, not model or decision-system authority |
| Documentation Governance | Sibling Policy; governs documentation publication, not model controls |
| Existing `KnowledgeBase/00_Project` authorities | Upstream or adjacent authority; unchanged absent approved migration |
| ResearchPolicy.md and ResearchWritingGuide.md | Research evidence and claims authority; not model-validation method |
| DecisionLog.md and ArchitectureBacklog.md | Existing context and history; no independent model-change authority |

## 5. Future-control map

The Policy will establish, but not itself implement, the need for: Model Lifecycle Standard; Model and Decision-System Validation Standard; Explainability and Traceability Standard; Model Change Procedure; Monitoring and Incident Procedure; a Standard or Procedure for Model/Decision evidence and approval structure, with Templates and Records supporting execution and preserved evidence; and future data-quality and investment-validation controls where separately governed.

## 6. Review criteria

Independent review must verify: constitutional consistency; correct Knowledge Base First dependency; no investment, algorithm, threshold, or validation-method decision disguised as policy; clear boundary between model, decision engine, advisor, development, data, and investment domains; independent-review integrity; complete delegation of mechanics; and scalability to human participants, Codex, other AI agents, and external reviewers.
