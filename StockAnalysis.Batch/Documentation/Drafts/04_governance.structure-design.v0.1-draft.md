# Structure Design — 04_governance.md

> **Draft — not released.** This is a design proposal for Documentation Governance, not governance itself.

| Field | Value |
|---|---|
| Proposed artifact | `04_governance.md` |
| Proposed title | Documentation Governance |
| Proposed document class | Policy |
| Status | Draft — structure design |
| Owner | Documentation Director |
| Governing document | `000_ProjectDocumentationConstitution.md` |

## 1. Responsibility

The proposed Policy will govern the documentation domain beneath the Project Constitution. It will define durable documentation authority, publication, review, change, and stewardship policy; reusable mechanics will be delegated to Standards, Procedures, Templates, and Records.

It will not alter the stated authority of existing `KnowledgeBase/00_Project` documents. Any supersession, relocation, consolidation, or retirement requires a separately approved migration.

Its applicability will be limited to new Documentation Governance artifacts and project-level documentation within its stated scope. Existing `KnowledgeBase/00_Project` authorities remain outside that scope unless an approved migration explicitly changes the relationship.

## 2. Proposed chapters

| Chapter | Responsibility | Boundary / primary dependency |
|---|---|---|
| Purpose, scope, and exclusions | Establish Documentation Governance as a domain Policy | Project Constitution §§1, 3, 9 |
| Authority and document hierarchy | Apply the constitutional document classes to documentation | Project Constitution §3 |
| Documentation ownership and roles | Assign documentation-domain responsibility without duplicating the Role Organization | Project Constitution §§5–6 |
| Canonical publication and source-of-truth policy | Define authoritative publication principles and projection boundary | Project Constitution P-018, P-023–P-025 |
| Lifecycle and release policy | Define lifecycle intent and decision gates; delegate state mechanics | Project Constitution §9 |
| Independent review and approval policy | Define separation, review purpose, and approval boundary | Project Constitution §7 |
| Change, migration, and retention policy | Govern controlled evolution and preservation of authority | Existing Knowledge Base governance; Project Constitution P-016 |
| Quality, provenance, and traceability policy | Define documentation-quality objectives and documentation provenance; exclude research-evidence fitness | Project Constitution §2; ResearchPolicy boundary |
| Delegated-control register | Identify required future Standards, Procedures, Templates, and Records | Project Constitution P-025 |
| Exceptions, conflicts, and maintenance | Route exceptions and define policy stewardship | Project Constitution P-005; §§6, 8–9 |

## 3. Explicit delegations

The Policy will not prescribe lint configuration, hash algorithms or serialization, metadata schemas, review checklists, approval forms, release commands, folder layouts, record formats, retention periods, migration steps, or tool-specific controls. These are candidates for lower-level controlled artifacts.

## 4. Existing-document relationship

| Existing artifact | Treatment in this Policy |
|---|---|
| `GovernanceOverview.md` | Preserve as existing Knowledge Base governance map; link without supersession |
| `KnowledgeBaseRules.md` | Preserve within its stated Knowledge Base scope |
| `ReviewPolicy.md` | Preserve as existing Knowledge Base review practice; do not silently broaden scope |
| `ResearchPolicy.md` and `ResearchWritingGuide.md` | Preserve as research-domain authority |
| `NamingConvention.md` | Preserve as existing naming authority |
| `DecisionLog.md` and ADR directory | Preserve as decision-history assets; record mechanics remain delegated |

## 5. Future-control map

The Policy will establish, but not itself implement, the need for: Documentation Lifecycle Standard; Review and Approval Standard; Publication and Canonicality Standard; Change and Migration Procedure; Documentation Quality Checklist; approval, release, review, and migration record templates; and a controlled document register.

## 6. Review criteria

Independent review must verify: constitutional consistency; no silent takeover of existing Knowledge Base authority; clear policy-versus-procedure separation; independent-review integrity; no unsupported implementation detail; viable extension to future human participants, AI agents, and external reviewers; and complete routing of delegated controls.
