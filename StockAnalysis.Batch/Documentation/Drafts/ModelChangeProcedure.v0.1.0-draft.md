# Model Change Procedure

> **Draft — not released.** Proposed Procedure; not effective until independently reviewed, approved, and released.

| Field | Value |
|---|---|
| Revision | ModelChangeProcedure@0.1.0-draft |
| Governing Policy | `ModelGovernance.md` |
| Dependencies | Lifecycle, Validation, Explainability & Traceability Standards |

## 1. Purpose and scope

This Procedure defines the controlled method for a material change to a governed model or decision system. It covers request, assessment, authorization, validation, lifecycle routing, monitoring handoff, and closure; it does not define implementation, algorithm, threshold, investment, Backtest, Walk Forward, or deployment methods.

## 2. Principles

Changes are controlled, never implicit, proportionally governed, decision-traceable, and reversible only through governed withdrawal or rollback controls.

## 3. Procedure

1. Register the change request with purpose, scope, affected lifecycle object, upstream references, and applicable change object category.
2. Classify its impact and change object, including configuration, knowledge, model, decision logic, rule, explanation, or documentation reference as applicable.
3. Assess effects on knowledge, evidence relationships, data references, behavior, validation, explanation, Advisor output, monitoring, and downstream consumers.
4. Prepare the controlled change plan, including success criteria, completion criteria, residual-risk consideration, and withdrawal or rollback consideration.
5. Route authorization through constitutional authority with author, reviewer, approver, and implementer separation.
6. Hand off controlled implementation to applicable Development Governance controls.
7. Obtain applicable validation disposition and update affected explanation, provenance, traceability, and gap-disclosure relationships.
8. Route release, withdrawal, rollback, or state change through Lifecycle controls; hand off change context to Monitoring controls.
9. Preserve closure evidence and applicable decision record, including governed feedback for upstream knowledge or evidence improvement.

## 4. Exceptions and delegation

Exceptions follow constitutional authority and do not weaken governing controls. Templates, schemas, thresholds, implementation methods, communications, and operational commands remain delegated.
