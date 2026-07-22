# Documentation Governance

> **Draft — not released.** Proposed Policy. It is not effective until independently reviewed, approved, and released.

| Field | Value |
|---|---|
| Document | Documentation Governance |
| Revision | DocumentationGovernance@0.1.0-draft |
| Document class | Policy |
| Owner | Documentation Director |
| Status | Draft |
| Governing document | `000_ProjectDocumentationConstitution.md` |

## 1. Purpose and applicability

This Policy establishes durable governance for project-level documentation beneath the Project Constitution. It governs new Documentation Governance artifacts and project-level documentation within its stated scope.

Existing `KnowledgeBase/00_Project` authorities remain outside this Policy’s scope unless an approved migration explicitly changes that relationship. This Policy does not relocate, supersede, broaden, or retire any existing Knowledge Base document.

## 2. Authority and boundary

The Project Constitution is the controlling authority. This Policy applies its documentation-domain direction and cannot weaken it. A conflict that cannot be resolved within assigned authority is routed under the Constitution.

This Policy defines direction, not detailed mechanics. It does not prescribe tools, lint configuration, hash serialization, metadata schemas, record forms, review checklists, release commands, folder layouts, retention periods, or migration steps.

## 3. Documentation authority

Each governed documentation artifact MUST declare its document class and status. The constitutional hierarchy applies: Constitution, Policy, Standard, Procedure, Guide, Template, and Record.

Only a released artifact is an effective project-level canonical publication. A Draft, review finding, proposed decision, or working copy is not a canonical publication. A Record preserves evidence and does not create a normative rule.

## 4. Ownership and decision authority

The Project Director retains final substantive authority for project-wide direction, conflicts, and approval or rejection within the authority defined by the Constitution. The Documentation Director stewards this Policy and the documentation program. The Chief Reviewer coordinates review assignment and synthesis but does not replace independent review.

All role authority, delegation, and final decision boundaries are defined by the [Role Organization](000_ProjectDocumentationConstitution.md#5-role-organization) and [Decision Authority Matrix](000_ProjectDocumentationConstitution.md#6-decision-authority-matrix). This Policy creates no additional role or decision authority.

## 5. Canonicality and publication

A project-level document MUST have one identified effective canonical publication for its governed subject. A publication MUST preserve traceability to its approved source and applicable approval and release evidence. Publication controls MUST distinguish working material from effective canonical material.

Project documentation MUST avoid competing sources of authority. If duplicate, overlapping, or unclear authority is found, the responsible role MUST route the issue for decision rather than silently selecting or replacing a source.

## 6. Lifecycle, review, and approval

Material documentation follows the constitutional direction that review precedes approval and approval precedes release. Independent review exists to find defects, not merely to endorse a result. An author MUST NOT independently approve their own work.

This Policy does not define lifecycle states, reviewer counts, templates, gate criteria, evidence schemas, or release mechanics. Those controls are delegated to approved lower-level artifacts.

## 7. Change, migration, and preservation

Governed documentation changes MUST preserve relevant history and decision context. A change that affects an existing Knowledge Base authority, including a move, rename, consolidation, retirement, or supersession, requires an approved migration before implementation.

Until such a migration is approved, existing Knowledge Base documents retain their stated authority. This Policy does not determine a migration method or record format.

## 8. Quality, provenance, and traceability

Project-level documentation MUST be understandable, maintainable, traceable to its governing authority, and explicit about its status and scope. Documentation provenance and decision traceability MUST be preserved at the level required by applicable canonical controls.

Research-evidence fitness, source evaluation, and research claim handling remain governed by existing research authorities, including [ResearchPolicy.md](KnowledgeBase/00_Project/ResearchPolicy.md) and [ResearchWritingGuide.md](KnowledgeBase/00_Project/ResearchWritingGuide.md). This Policy does not extend their scope.

## 9. Delegated controls

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

## 10. Exceptions, conflicts, and maintenance

No exception may weaken the Project Constitution. Conflicts and unassigned decisions are routed to the authority identified by the Constitution, with the Project Director resolving unresolved constitutional conflicts.

The Documentation Director owns this Policy. Its revisions MUST preserve the scope boundary in section 1 and the delegated-control boundary in section 2. Detailed lifecycle and maintenance mechanics remain delegated until a relevant lower-level artifact is approved.
