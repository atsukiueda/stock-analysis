# Structure Design — 07_coding_standards.md

> **Draft — not released.** This is a structure proposal for a Development Standard.

| Field | Value |
|---|---|
| Proposed class | Standard |
| Governing Policy | `DevelopmentGovernance.md` |
| Purpose | Reusable implementation-quality controls for governed development work |

## Proposed chapters

| Chapter | Responsibility |
|---|---|
| Scope and applicability | Application, batch, API, automation, infrastructure, and database-integration code within Development Governance scope |
| Principles | Maintainability, readability, modularity, testability, observability, reproducibility, security-aware boundaries, traceability |
| Architecture and dependency | Preserve governed upstream knowledge and architecture; prohibit silent business-rule redefinition |
| Structure and boundaries | Define separation of concerns, explicit interfaces, dependency direction, and configuration boundaries without language syntax |
| Error and operational behavior | Define explicit failure, diagnostic, and recoverability direction without logging or tooling prescription |
| Data and decision boundaries | Preserve data, model, decision-engine, and Advisor authority boundaries |
| Documentation and traceability | Require relevant implementation-to-authority relationships without metadata schema |
| Review and validation interfaces | Connect to Development Workflow, Testing/Validation Standard, and Review Checklists |
| Delegated language-specific controls | Reserve C#, .NET, EF Core, SQL, formatter, linter, naming syntax, commands, and patterns for supplemental standards or guides |

## Explicit exclusions

No code style syntax, formatter configuration, branch strategy, build command, coverage threshold, test case, API contract, schema definition, or deployment method is defined here.
