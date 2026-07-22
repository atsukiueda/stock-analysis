# Structure Design — Monitoring & Incident Procedure

> **Draft — not released.** This is a structure proposal, not an effective Procedure.

| Field | Value |
|---|---|
| Proposed artifact | `MonitoringIncidentProcedure.md` |
| Document class | Procedure |
| Governing Policy | `ModelGovernance.md` |
| Primary dependencies | Model Lifecycle, Validation, Explainability & Traceability Standards; Model Change Procedure (Draft) |

## Procedure purpose

The Procedure will define one controlled method for observing governed model and decision-system health, handling detected concerns, preserving decision context, and closing incidents with traceable evidence.

## Procedure principles

Continuous accountability; no silent incident; proportional response; evidence-preserving investigation; controlled communication; reversible containment; and traceable closure.

## Scope boundary

**In scope:** model drift, data drift references, performance observations, decision consistency, explanation or traceability gaps, lifecycle status, incident classification, escalation, containment, recovery, and closure. **Outside scope:** monitoring metrics, thresholds, alert configuration, model algorithms, data-quality methods, remediation implementation, deployment commands, investment risk limits, and investment decisions.

## Proposed chapters

| Chapter | Responsibility |
|---|---|
| Authority and applicability | Define covered ML models, rule-based decisions, hybrid systems, and Advisor-facing paths; route roles through the Constitution |
| Monitoring context | Identify governed object, effective lifecycle state, validation disposition, explanation/traceability references, and applicable change context |
| Monitoring scope | Identify model drift, data drift, performance, decision consistency, explanation gaps, trace gaps, and lifecycle anomalies without metrics or thresholds |
| Detection and intake | Define controlled receipt of automated, human, audit, or downstream signals without alert configuration |
| Incident classification | Define impact-oriented, proportional classification and routing without severity thresholds |
| Triage and evidence preservation | Define initial assessment, evidence/metadata/reference/Record distinction, and preservation of context |
| Escalation and communication | Define authority routing, independent-review consideration, and controlled stakeholder communication |
| Containment and recovery direction | Route suspension, withdrawal, rollback, or Model Change Procedure handoff to applicable controls without methods |
| Investigation and root-cause relationship | Define traceable investigation relationships without analysis method |
| Closure and learning | Define completion criteria, residual-risk consideration, closure evidence, decision record, and governed feedback to upstream knowledge/evidence improvement |
| Interfaces | Consume Lifecycle, Validation, Explainability, Change, Development, Documentation, and Investment references; provide incident context to applicable controls |
| Delegated mechanics | Reserve metrics, thresholds, alerting, runbooks, incident forms, communications templates, and remediation procedures |

## Relationship orientation

```text
Monitoring context
  ↓
Detection / intake
  ↓
Classification and triage
  ↓
Evidence preservation and escalation
  ↓
Containment / recovery / controlled change handoff
  ↓
Investigation and closure
  ↓
Closure evidence, decision record, and governed feedback
```

## Review criteria

Verify: Procedure-class suitability; no hidden metric, alert, or remediation method; lifecycle and validation compatibility; explicit evidence relationships; proportional and authority-routed incident handling; clear model-versus-investment boundary; controlled change interface; closure and feedback traceability; and compatibility with human, AI, Codex, and external-review participation.
