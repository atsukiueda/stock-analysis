# Documentation Governance

> **APPROVED AND RELEASED.** This Policy is effective for its stated scope.

| Field | Value |
|---|---|
| Document | Documentation Governance |
| Revision | DocumentationGovernance@0.2.0-draft |
| Document class | Policy |
| Owner | Documentation Director |
| Status | Released |
| Governing document | `000_ProjectDocumentationConstitution.md` |

## 1. Purpose and applicability

This Policy establishes durable governance for project-level documentation beneath the Project Constitution. It governs new Documentation Governance artifacts and project-level documentation within its stated scope.

Existing `KnowledgeBase/00_Project` authorities remain outside this Policy’s scope unless an approved migration explicitly changes that relationship. This Policy does not relocate, supersede, broaden, or retire any existing Knowledge Base document.

## 2. Documentation Governance vision

Documentation is part of the product, not merely a by-product of development. Documentation Governance exists to preserve knowledge, decisions, provenance, and traceability so that the project remains understandable and maintainable over time.

Its purpose is not to accumulate documents; it is to keep each governed document trustworthy, discoverable, and appropriately authoritative.

## 3. Documentation principles

- **Single Source of Truth.** Each governed subject has one identified effective canonical publication.
- **Canonical First.** Operational reliance belongs on the effective publication, not on a draft or informal copy.
- **Independent Review.** Review is independent defect discovery before approval, not author self-endorsement.
- **Traceability by design.** Governing authority, status, source, and material decisions remain traceable.
- **No Silent Authority.** A document cannot become authoritative through use, implication, duplication, or unrecorded replacement.

These domain principles apply the Project Constitution to documentation; they do not add a higher authority or replace constitutional principles.

## 4. Relationship and scope

```text
Project Constitution
  ↓
Documentation Governance (this Policy)
  ↓
Documentation Standards
  ↓
Procedures
  ↓
Templates and Records
```

```text
Documentation Governance scope
├── Project-level documentation in stated scope
│   ├── README and Project Instructions
│   ├── Policies, Standards, Procedures, and Guides
│   └── Templates and Records
└── Outside scope unless approved migration changes it
    ├── Existing KnowledgeBase/00_Project authorities
    ├── Research-evidence fitness and claim handling
    ├── Development implementation governance
    └── Model governance
```

## 5. Authority and boundary

The Project Constitution is the controlling authority. This Policy applies its documentation-domain direction and cannot weaken it. A conflict that cannot be resolved within assigned authority is routed under the Constitution.

This Policy defines direction, not detailed mechanics. It does not prescribe tools, lint configuration, hash serialization, metadata schemas, record forms, review checklists, release commands, folder layouts, retention periods, or migration steps.

## 6. Documentation authority

Each governed documentation artifact MUST declare its document class and status. The constitutional hierarchy applies: Constitution, Policy, Standard, Procedure, Guide, Template, and Record.

Only a released artifact is an effective project-level canonical publication. A Draft, review finding, proposed decision, or working copy is not a canonical publication. A Record preserves evidence and does not create a normative rule.

## 7. Ownership and decision authority

The Project Director retains final substantive authority for project-wide direction, conflicts, and approval or rejection within the authority defined by the Constitution. The Documentation Director stewards this Policy and the documentation program: maintaining the governance direction, coordinating the documentation domain, stewarding canonical publication, and ensuring that approved publication is routed through the assigned authority. The Chief Reviewer coordinates review assignment and synthesis but does not replace independent review.

All role authority, delegation, and final decision boundaries are defined by the [Role Organization](000_ProjectDocumentationConstitution.md#5-role-organization) and [Decision Authority Matrix](000_ProjectDocumentationConstitution.md#6-decision-authority-matrix). This Policy creates no additional role or decision authority.

## 8. Canonicality and publication

A project-level document MUST have one identified effective canonical publication for its governed subject. A publication MUST preserve traceability to its approved source and applicable approval and release evidence. Publication controls MUST distinguish working material from effective canonical material. Canonical publication provides a single effective source, prevents competing authority, and preserves traceability across change.

Project documentation MUST avoid competing sources of authority. If duplicate, overlapping, or unclear authority is found, the responsible role MUST route the issue for decision rather than silently selecting or replacing a source.

## 9. Lifecycle, review, and approval

Material documentation follows the constitutional direction that review precedes approval and approval precedes release. Independent review exists to find defects, not merely to endorse a result. An author MUST NOT independently approve their own work.

This Policy does not define lifecycle states, reviewer counts, templates, gate criteria, evidence schemas, or release mechanics. Those controls are delegated to approved lower-level artifacts because reusable mechanics must be precise, testable, and able to evolve without changing the Policy’s durable direction.

## 10. Change, migration, and preservation

Governed documentation changes MUST preserve relevant history and decision context. A change that affects an existing Knowledge Base authority, including a move, rename, consolidation, retirement, or supersession, requires an approved migration before implementation.

Until such a migration is approved, existing Knowledge Base documents retain their stated authority. This Policy does not determine a migration method or record format.

## 11. Quality, provenance, and traceability

Project-level documentation MUST be understandable, maintainable, traceable to its governing authority, and explicit about its status and scope. Documentation provenance and decision traceability MUST be preserved at the level required by applicable canonical controls.

Research-evidence fitness, source evaluation, and research claim handling remain governed by existing research authorities, including [ResearchPolicy.md](KnowledgeBase/00_Project/ResearchPolicy.md) and [ResearchWritingGuide.md](KnowledgeBase/00_Project/ResearchWritingGuide.md). This Policy does not extend their scope.

## 12. Delegated controls

The following lower-level controlled artifacts are required before their respective detailed controls may be treated as established:

| Control need | Intended artifact class |
|---|---|
| Documentation lifecycle state model and gates | Standard |
| Independent review and approval mechanics | Standard or Procedure |
| Canonical publication and projection mechanics | Standard |
| Documentation change and migration method | Procedure |
| Documentation quality assessment | Standard or Procedure, with an optional checklist Template |
| Review, approval, release, and migration evidence | Template and Record |
| Controlled document register | Standard for the control; Records for register entries |

## 13. Governance family, exceptions, and maintenance

The current constitutional governance family comprises Documentation Governance, Research Governance, Knowledge Base Governance, Development Governance, and Model Governance.

```text
Project Constitution
├── Documentation Governance (this proposed Policy)
├── Research Governance
├── Knowledge Base Governance
├── Development Governance
└── Model Governance

Potential future extension: Data Governance
  Status: not established as a separate governance domain; requires Project Director decision.
```

No exception may weaken the Project Constitution. Conflicts and unassigned decisions are routed to the authority identified by the Constitution, with the Project Director resolving unresolved constitutional conflicts.

The Documentation Director owns this Policy. Its revisions MUST preserve the scope boundary in section 1 and the delegated-control boundary in section 5. Detailed lifecycle and maintenance mechanics remain delegated until a relevant lower-level artifact is approved.
