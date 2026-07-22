# Structure Design — Model Change Procedure

> **Draft — not released.** This is a structure proposal, not an effective Procedure.

| Field | Value |
|---|---|
| Proposed artifact | `ModelChangeProcedure.md` |
| Document class | Procedure |
| Governing Policy | `ModelGovernance.md` |
| Primary dependencies | Model Lifecycle, Validation, and Explainability & Traceability Standards (Draft) |

## Procedure purpose

The Procedure will define one controlled method for proposing, assessing, authorizing, implementing, validating, releasing, withdrawing, or retiring a material change to a governed model or decision system.

## Procedure principles

Controlled change; no implicit change; proportional governance; traceable decision; and reversible change through governed withdrawal or rollback controls.

## Scope boundary

**In scope:** controlled change to ML models, rule-based decisions, hybrid decision systems, related decision logic, and their governed explanation/traceability relationships. **Outside scope:** algorithm choice, feature engineering, thresholds, validation method, investment strategy, Backtest/Walk Forward mechanics, implementation detail, and deployment commands.

## Proposed chapters

| Chapter | Responsibility |
|---|---|
| Authority and applicability | Identify change types and constitutional authority routes |
| Change request | Define request identity, stated purpose, scope, affected lifecycle object, and upstream references |
| Change classification | Define impact-oriented classification and proportional control routing; consider configuration, knowledge, model, decision logic, rule, explanation, and documentation-reference change objects without thresholds |
| Impact assessment | Identify affected knowledge, evidence relationships, data references, model/decision behavior, validation, explanation, advisor, monitoring, and downstream consumers |
| Change plan | Define required plan relationships, including success criteria, completion criteria, residual-risk consideration, and rollback or withdrawal consideration, without a template schema |
| Authorization and separation | Define author, reviewer, approver, and implementer separation through existing authority |
| Controlled implementation | Define the procedure handoff to Development Governance without prescribing implementation mechanics |
| Validation and disposition | Require applicable Validation Standard outcome and lifecycle-state routing |
| Explainability and traceability update | Require affected links, explanations, provenance references, and gap disclosures to be assessed |
| Release, withdrawal, and rollback | Route lifecycle transitions and controlled reversal to Lifecycle Standard; do not define commands |
| Monitoring handoff | Provide change context to Monitoring & Incident Procedure |
| Evidence and records | Identify evidence relationships and record categories without schemas |
| Exceptions and closure | Define controlled exception route, closure conditions, and preserved decision context |

## Relationship orientation

```text
Change request
  ↓
Impact assessment / change plan
  ↓
Authorization
  ↓
Controlled implementation
  ↓
Validation disposition ↔ Explainability / traceability update
  ↓
Lifecycle release, withdrawal, or rollback
  ↓
Monitoring handoff and closure
  ↓
Closure evidence and decision record
```

## Review criteria

Verify: Procedure-class fit; use of rather than duplication of Lifecycle/Validation/Traceability controls; clear role separation; proportional routing without hidden thresholds; explicit model-versus-investment boundary; rollback/withdrawal direction; evidence without schema invention; and no implementation or deployment method.
