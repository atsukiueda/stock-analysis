# Model Lifecycle Standard

> **APPROVED AND RELEASED.** This Standard is effective for its stated scope.

| Field | Value |
|---|---|
| Revision | ModelLifecycleStandard@0.1.0-draft |
| Document class | Standard |
| Governing Policy | `ModelGovernance.md` |
| Status | Released |

## 1. Purpose and scope

This Standard defines the common lifecycle control model for governed ML models, rule-based decision systems, and hybrid decision systems. It defines state identity, transition direction, role separation, and evidence relationships; it does not define training, validation, release, monitoring, or retirement methods.

## 2. Principles

Every governed object has one authoritative current lifecycle state. State change is controlled, traceable, and never implicit. Reversal, withdrawal, suspension, or retirement occurs only through applicable governed controls.

## 3. Lifecycle State Dictionary

| State | Definition |
|---|---|
| Training | Under development or learning before governed evaluation. |
| Validation | Undergoing defined evaluation for a lifecycle decision. |
| Approval | Awaiting or having received authorized lifecycle approval. |
| Released | Effective for its governed operational purpose. |
| Monitoring | Subject to governed observation of health and consistency. |
| Retirement | Withdrawn from use while applicable history and evidence remain preserved. |

Rejected, Withdrawn, and Suspended may be introduced by an approved extension; no extension weakens the common controls.

## 4. Transition and authority direction

Lifecycle transitions require the authority and independent-review separation defined by the Project Constitution and applicable Validation control. This Standard does not assign new roles, transition thresholds, or transition mechanics.

Validation dispositions may be presented to Approval or routed to an earlier lifecycle state or controlled exception. The Lifecycle State Dictionary remains the common terminology for all Control Family artifacts.

## 5. Evidence relationships

For each lifecycle object and material transition, applicable controls must preserve linked references to provenance, validation disposition, explainability/traceability context, approval, release, change, and monitoring context. Evidence, metadata, references, and Records are distinct; schemas and record formats are delegated.

## 6. Interfaces and delegations

This Standard provides lifecycle terms to Validation, Explainability & Traceability, Model Change, and Monitoring controls. It consumes their applicable outcomes and does not replace their methods.

Test methods, metrics, thresholds, lifecycle forms, commands, record schemas, alerting, incident response, investment validation, and implementation methods remain delegated.

## 7. Maintenance

The Project Director owns this Standard until a model-domain steward is appointed under the Constitution. Revisions preserve the state dictionary, scope, and delegated-mechanics boundary unless an approved successor control changes them.

