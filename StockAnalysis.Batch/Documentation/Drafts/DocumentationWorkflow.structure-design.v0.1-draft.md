# Structure Design — Documentation Workflow

> **Draft — not released.** This is a structure proposal for a Documentation Procedure.

| Field | Value |
|---|---|
| Proposed artifact | `DocumentationWorkflow.md` |
| Document class | Procedure |
| Governing Policy | `04_governance.md` |
| Purpose | Controlled creation, review, approval, publication, and maintenance of project-level documentation |

## Proposed chapters

| Chapter | Responsibility |
|---|---|
| Scope and authority | Apply only to project-level documents within Documentation Governance scope; preserve existing Knowledge Base authority |
| Workflow principles | Draft is noncanonical; review finds defects; author cannot approve; approval precedes release |
| Intake and classification | Identify document class, owner, scope, dependencies, and required authority |
| Drafting and source control | Define controlled draft identity and source-of-truth relationship without tool commands |
| Independent review | Define reviewer independence, finding disposition, and revision loop |
| Approval and release | Define authority routing and publication projection; delegate record schemas and release mechanics |
| Change, migration, and retirement | Route controlled change and protect existing authority pending approved migration |
| Evidence and publication records | Identify approval, release, and identifier evidence relationships without schemas |
| Maintenance and feedback | Define review triggers and corrective routing |
| Interfaces | Consume Constitution, Documentation Governance, Project Instructions, and existing Knowledge Base boundaries |

## Relationship orientation

```text
Intake → Draft → Independent Review → Revision → Approval → Release → Maintenance
                         ↑                    ↓
                         └──── findings ──────┘
```

## Explicit delegations

The Procedure will not define metadata schemas, hashes, record forms, checklists, storage layout, release commands, lint rules, review thresholds, or migration implementation steps. These require applicable Standards, Templates, or Records.
