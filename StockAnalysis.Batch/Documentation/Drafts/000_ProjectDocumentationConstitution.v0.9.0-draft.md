# 000 Project Documentation Constitution

> **DRAFT — NOT APPROVED, NOT EFFECTIVE, NOT RELEASED.** This file is a working draft in the Draft Workspace. It is not a Project File, does not supersede any existing document, and MUST NOT be cited as a binding project rule. Only a separately recorded ratification and a Release under this Constitution can make a later revision effective.

| Control field | Value |
|---|---|
| Document ID | DOC-CON-000 |
| Revision ID | DOC-CON-000@0.9.0-draft |
| Title | Project Documentation Constitution |
| Artifact Type ID | AT-CONSTITUTION |
| Lifecycle state | Draft |
| Conformance status | Draft / not assessed |
| Owner | Documentation Director (proposed) |
| Author | Documentation Team (proposed) |
| Independent reviewer | Unassigned |
| Intended Applicability Profile | IAP-DOC-CON-000-0.9.0-DRAFT (frozen snapshot in Appendix D) |
| Canonical draft location | `Documentation/Drafts/000_ProjectDocumentationConstitution.v0.9.0-draft.md` |
| Effective date | None |
| Supersedes | None |

## Requirements inventory

This inventory is informative navigation; the atomic requirements are the `REQ-*` statements in the body and appendices.

| Area | Requirement IDs |
|---|---|
| Scope, priority, and authority | REQ-001–REQ-014 |
| Identifiers, claims, and profiles | REQ-015–REQ-030 |
| Artifact architecture and lifecycle | REQ-031–REQ-051 |
| Review, approval, release, and conformance | REQ-052–REQ-073 |
| Evidence, records, and references | REQ-074–REQ-090 |
| Publication, exceptions, and legacy transition | REQ-091–REQ-111 |
| Amendment, bootstrap, and operations | REQ-112–REQ-130 |

---

## 1. Purpose and bounded scope

This Constitution establishes the **documentation-governance process** for the Japanese equity AI system. It governs how documentation is identified, reviewed, approved, released, preserved, changed, and audited. Documentation is treated as a maintainable system of artifacts, relationships, and records.

It does **not** decide investment policy, market interpretation, software architecture, data semantics, model behavior, or domain rules. Those matters remain subject-matter decisions owned by the Project Director and the applicable domain authorities.

**REQ-001.** This Constitution MUST govern the lifecycle and documentation-control process for artifacts within its approved applicability profile.

**REQ-002.** This Constitution MUST NOT create, alter, or imply a subject-matter design decision.

**REQ-003.** An artifact governed by this Constitution MUST retain a stable Document ID, Revision ID, Artifact Type ID, lifecycle state, and source-of-record location.

**REQ-004.** A draft artifact MUST NOT be represented as approved, effective, released, canonical, or a Project File.

**REQ-005.** A Draft Workspace MAY contain proposals and review material, but MUST NOT be used as the source of an asserted production rule.

## 2. Normative language, priority, and two-axis authority

The terms **MUST**, **MUST NOT**, **SHOULD**, and **MAY** are normative. A sentence containing a requirement identifier and MUST/MUST NOT is one atomic obligation unless it expressly declares a numbered subrequirement.

Authority has two independent axes:

| Axis | Decides | Does not decide |
|---|---|---|
| Subject-matter authority | project intent, architecture, domain policy, research conclusions, implementation meaning | documentation process mechanics |
| Documentation-governance authority | IDs, lifecycle, review independence, release, traceability, records, retention | substantive project or domain choices |

The Project Director's ratified decisions are the highest internal subject-matter authority. `KnowledgeBase/00_Project/KnowledgeBaseRules.md` remains the existing Knowledge Base subject-matter authority unless and until a Project Director-approved migration explicitly changes that status. This Constitution does not silently replace it.

External obligations include applicable law, regulation, contractual commitments, licensing obligations, and binding security or privacy obligations. They have priority over internal documents. When an external obligation conflicts with this Constitution, the conflict MUST be recorded and escalated; no internal artifact may claim to waive the external obligation.

**REQ-006.** A documentation-governance rule MUST NOT be interpreted as authorization to change a subject-matter rule.

**REQ-007.** A subject-matter authority MAY impose stricter documentation controls, but MUST NOT weaken a nonwaivable control in this Constitution.

**REQ-008.** A conflict between two internal authorities MUST identify both authorities, the affected requirement IDs, and the escalation decision record.

**REQ-009.** An applicable external obligation MUST take precedence over an inconsistent internal rule.

**REQ-010.** The Project Director MUST decide unresolved subject-matter conflicts.

**REQ-011.** The Documentation Director MUST administer documentation process controls only within delegated authority.

**REQ-012.** `KnowledgeBaseRules.md` MUST remain unchanged in authority by this draft.

**REQ-013.** A lower-level artifact MUST NOT create a normative dependency cycle with its governing artifact.

**REQ-014.** An interpretation that changes an approved requirement's effect MUST be processed as an amendment, not as editorial clarification.

## 3. Terms, identifiers, and claim classes

| Term | Definition |
|---|---|
| Document | A managed information artifact with a stable Document ID and one or more revisions. |
| Revision | An immutable, identified expression of one Document. |
| Release | A controlled publication event that designates a specified approved Revision for a named target. |
| Record | Evidence of an event, decision, review, approval, release, exception, or audit. |
| Source of record | The authoritative stored Revision or Record from which a release is made. |
| Published projection | A released representation derived from the source of record for a designated target. |
| IAP | Intended Applicability Profile: a frozen, revision-specific declaration of governed artifact types and scope. |
| Conformance | Assessed satisfaction of applicable requirements; not a synonym for approval or release. |

Identifier namespaces are distinct. IDs are never reused.

| Identifier | Pattern | Meaning |
|---|---|---|
| Document ID | `DOC-<CLASS>-<NNN>` | Stable document identity |
| Revision ID | `<Document ID>@<version>` | Immutable revision identity |
| Release ID | `REL-<YYYY>-<NNN>` | Release event identity |
| Record ID | `REC-<TYPE>-<NNN>` | Controlled record identity |
| Requirement ID | `REQ-<NNN>` | Atomic normative obligation |
| Finding ID | `FND-<review>-<NNN>` | Review finding identity |
| Evidence ID | `EVD-<NNN>` | Evidence item identity |
| Waiver ID | `WVR-<NNN>` | Time-bounded exception identity |

Claim classes are mutually distinguishable: **Fact**, **Inference**, **Hypothesis**, **Opinion**, **Proposal**, **Decision**, and **Normative Requirement**. A Normative Requirement is an obligation established by an effective governing artifact; it is not empirical evidence and MUST NOT be assigned an Evidence ID merely to simulate support.

**REQ-015.** Every identifier namespace MUST be unique within its registry.

**REQ-016.** A Revision ID MUST identify exactly one immutable content state.

**REQ-017.** A Release ID MUST identify exactly one release event.

**REQ-018.** A Record ID MUST identify exactly one controlled record.

**REQ-019.** Each normative obligation MUST have exactly one Requirement ID.

**REQ-020.** A Requirement ID MUST NOT contain multiple independently testable obligations.

**REQ-021.** A factual claim requiring support MUST cite one or more Evidence IDs or a precise source locator.

**REQ-022.** An inference, hypothesis, opinion, proposal, and decision MUST be labeled with its claim class.

**REQ-023.** A normative requirement MUST NOT be classified as empirical evidence.

## 4. Frozen Intended Applicability Profile

The IAP makes applicability reviewable rather than implicit. Each revision has a frozen IAP snapshot. The snapshot is immutable after entry to Independent Review; any change creates a new Draft Revision and new IAP ID.

Artifact Type IDs are defined in Appendix A. An IAP contains: IAP ID, parent Revision ID, governed Artifact Type IDs, exclusions, repositories/locations, applicable Requirement IDs, profile version, frozen timestamp, and approver/reviewer references when available.

**REQ-024.** Every governed Revision MUST reference one frozen IAP.

**REQ-025.** An IAP MUST name governed Artifact Type IDs rather than only natural-language categories.

**REQ-026.** An IAP MUST explicitly identify exclusions.

**REQ-027.** The IAP data and profile version MUST be immutable after Independent Review begins.

**REQ-028.** A change to a frozen IAP MUST create a new Revision before review continues.

**REQ-029.** Conformance assessment MUST use the Revision's frozen IAP, not a later profile.

**REQ-030.** An artifact outside an IAP MAY adopt this Constitution voluntarily only through a recorded applicability decision.

## 5. Artifact architecture and separation of concerns

The following types are a controlled taxonomy, not merely folder names.

| Type ID | Class | Primary responsibility |
|---|---|---|
| AT-CONSTITUTION | Constitutional | authority, durable principles, process boundaries |
| AT-POLICY | Normative | mandatory domain or organizational policy |
| AT-STANDARD | Normative | testable common rule or quality baseline |
| AT-PROCEDURE | Procedural | repeatable method for performing work |
| AT-GUIDE | Guidance | nonbinding explanation or recommendation |
| AT-TEMPLATE | Structural | reusable artifact structure |
| AT-DECISION | Record | decision and rationale |
| AT-REVIEW | Record | independent review and finding disposition |
| AT-APPROVAL | Record | authorization to approve a Revision |
| AT-RELEASE | Record | publication and target verification |
| AT-REGISTER | Navigational | controlled index or registry |
| AT-HANDOFF | Operational state | time-sensitive work continuity |
| AT-BACKLOG | Operational state | unadopted work or decision candidates |
| AT-EVIDENCE | Record | provenance for a factual claim |

Policies and standards contain durable normative rules. Procedures contain execution instructions. Records report events; they do not create new normative rules. Handoffs and backlogs describe operational state and are not authorities. A Decision Record can establish subject-matter meaning only when approved by its authorized subject-matter authority.

**REQ-031.** Each artifact MUST declare one primary Artifact Type ID.

**REQ-032.** A Record MUST NOT introduce a new normative requirement without an approved governing artifact that contains it.

**REQ-033.** A Handoff or Backlog artifact MUST NOT be treated as a design decision or binding policy.

**REQ-034.** A Template MUST identify its governing procedure or standard when one exists.

**REQ-035.** A Policy, Standard, or Constitution MUST identify its subject-matter authority and documentation-governance authority.

**REQ-036.** A Register MUST link to the source-of-record item rather than duplicate its controlled content.

## 6. Roles and separation of duties

Proposed documentation roles are Documentation Director, Lead Documentation Architect, Lead Governance Architect, Lead Workflow Architect, Lead Knowledge Architect, Chief Editor, and Chief Reviewer. These are workflow roles, not a transfer of Project Director authority.

| Role | Accountability |
|---|---|
| Author | prepares a Draft and responds to findings |
| Independent Reviewer | seeks defects and verifies dispositions |
| Approver | authorizes the approved Revision within delegated subject-matter authority |
| Release Authority | authorizes and verifies publication |
| Record Custodian | preserves controlled records and registries |

**REQ-037.** The Author MUST NOT serve as Independent Reviewer of the same Revision.

**REQ-038.** The Independent Reviewer MUST record any actual or perceived conflict of interest before review begins.

**REQ-039.** An unresolved reviewer conflict of interest MUST block Approval.

**REQ-040.** An Approver MUST be authorized for the artifact's subject matter.

**REQ-041.** Release Authority MUST verify the released projection against the approved Revision.

**REQ-042.** No AI role label MAY be treated as a legal, organizational, or human approval identity without an authorized accountable party.

## 7. Canonical lifecycle and derived artifact state

The canonical lifecycle applies to a **Revision**. `Revision` is a deliberate rework state, not a separate document maturity or publishing state.

```text
Proposed → Draft → Independent Review → Revision → Approval Pending → Approved → Released
                                      ↑                  │                 │
                                      └──────────────────┘                 ├→ Superseded
                                                                             ├→ Deprecated
                                                                             ├→ Withdrawn
                                                                             └→ Archived
```

| Revision state | Meaning | Permitted transition basis |
|---|---|---|
| Proposed | candidate exists; no controlled content yet | author initiation |
| Draft | editable working revision | author work |
| Independent Review | frozen for review except controlled correction | review entry record |
| Revision | review findings are being addressed | finding disposition work |
| Approval Pending | review completed; authorization awaited | review completion record |
| Approved | content authorized; not necessarily published | approval record |
| Released | approved Revision has a verified release event | release record |

Publication/validity is a property of a **Release**, not a free-standing Revision state: a Release may be effective, scheduled, withdrawn, superseded, or archived. A Document-level state is derived from its latest valid Release; it MUST NOT be manually asserted when inconsistent with the Release Registry.

**REQ-043.** A Revision MUST enter Independent Review only with its content and IAP frozen.

**REQ-044.** A material change during Independent Review MUST transition the Revision to Revision.

**REQ-045.** A Revision state MUST NOT be used to assert publication validity.

**REQ-046.** Only an Approved Revision MAY be released.

**REQ-047.** Only a verified Release MAY designate a Published Project File.

**REQ-048.** A Document-level status MUST be derived from the Release Registry.

**REQ-049.** A Superseded, Deprecated, Withdrawn, or Archived indication MUST identify the related Release or Record ID.

**REQ-050.** A withdrawn release MUST preserve its release record and withdrawal rationale.

**REQ-051.** A lifecycle transition MUST have the record required by Appendix B.

## 8. Independent review, approval, and conformance

Independent Review exists to find problems, not to manufacture approval. The reviewer records atomic findings and verifies that each disposition has evidence. Review outcome is separate from approval authority.

Finding severities are **Critical**, **Major**, **Minor**, and **Editorial**. A finding is atomic: one finding describes one defect, one impact, and one required disposition. Multiple defects require multiple findings.

Conformance status is one of `Not Assessed`, `Conformant`, `Conformant with Approved Waiver`, `Nonconformant`, or `Not Applicable`. It is assessed against the frozen IAP and does not by itself confer approval or release.

**REQ-052.** Independent Review MUST use a reviewer different from the Author.

**REQ-053.** Each finding MUST have a Finding ID, severity, requirement or criterion, evidence, impact, owner, disposition, and verification result.

**REQ-054.** A finding MUST address exactly one defect.

**REQ-055.** An unresolved Critical finding MUST block Approval.

**REQ-056.** An unresolved Major finding MUST block Approval unless a time-bounded approved waiver explicitly covers it.

**REQ-057.** The reviewer MUST verify the disposition of every finding before recommending approval.

**REQ-058.** Approval MUST be evidenced by an Approval Record separate from the reviewed artifact.

**REQ-059.** Approval MUST identify the exact Revision ID and frozen IAP ID.

**REQ-060.** Conformance assessment MUST state the applicable requirements, result, assessor, date, and supporting record IDs.

**REQ-061.** `Conformant with Approved Waiver` MUST identify every active Waiver ID.

**REQ-062.** Approval MUST NOT be inferred from silence, publication, a merge, or a reviewer recommendation.

## 9. Evidence, provenance, and traceability

Evidence supports factual claims. It is not a substitute for authority, review, or approval. Each evidence item includes source, source type, authoritative body where applicable, publication date, applicable period, as-of date, retrieval date, locator, claim relationship, and integrity note.

Traceability must be navigable in both directions where a dependency exists: governing rule to downstream artifact, and downstream artifact to governing rule. A source locator may be internal or external, but it must be sufficiently precise for a reviewer to locate the cited material.

**REQ-063.** Each factual claim with material impact MUST be traceable to an Evidence ID or precise source locator.

**REQ-064.** An Evidence Record MUST state its claim relationship and retrieval date.

**REQ-065.** A source that is unavailable, ambiguous, or stale MUST be labeled with that limitation.

**REQ-066.** A Decision Record MUST distinguish facts, inferences, hypotheses, options, and decision rationale.

**REQ-067.** A normative requirement MUST be traceable to its governing Revision and approval/release records, not to an Evidence ID.

**REQ-068.** A dependency link MUST identify the target Document ID and, where material, its Revision or Release ID.

## 10. Records, retention, and reference integrity

Records are append-only evidence of governance activity. A correction is a new linked record, not an untraceable alteration. Retention class, custodian, access constraints, and disposition basis are mandatory metadata for controlled records.

**REQ-069.** A controlled Record MUST be preserved as an identifiable source of record.

**REQ-070.** A Record correction MUST preserve the original Record ID and link to a corrective Record ID.

**REQ-071.** An Approval, Review, Release, Decision, Waiver, and Audit Record MUST declare a Record Custodian and retention class.

**REQ-072.** A broken normative reference MUST be assessed as a finding before release.

**REQ-073.** A circular normative dependency MUST block approval until resolved.

## 11. Publication and release boundaries

The canonical repository holds sources of record. Published Project Files are projections for trusted consumption. A release is either **Exact** (byte/content equivalent apart from allowed transport metadata) or **Controlled Transform** (a documented, verified derivation such as a rendered or filtered projection). A controlled transform must identify its transformation specification and validation result.

**REQ-074.** A Draft MUST NOT be registered in Project Files.

**REQ-075.** A Project File MUST identify its Release ID and source Revision ID.

**REQ-076.** An Exact Release MUST verify equivalence to the approved Revision.

**REQ-077.** A Controlled-Transform Release MUST identify the transformation specification and verification evidence.

**REQ-078.** A release failure MUST create or update a Release Record without changing the approved Revision's identity.

**REQ-079.** A published projection MUST NOT become the source of record merely because it is more convenient to access.

## 12. Exceptions, nonconformance, and corrective action

A waiver is a narrowly scoped, time-bounded authorization to operate with a named nonconformance. It is not a permanent rule change. A waiver must state scope, affected requirement IDs, rationale, risk, compensating controls, owner, approver, issue date, expiry, review date, and renewal rule.

The following controls are nonwaivable: reviewer independence; prohibition on a Draft in Project Files; preservation of records; prohibition on unrecorded legacy mutation; Project Director subject-matter authority; integrity of approval and release records; and priority of external obligations.

**REQ-080.** A waiver MUST have a Waiver ID and an expiry date.

**REQ-081.** A waiver MUST NOT waive a nonwaivable control.

**REQ-082.** A nonconformance MUST have an owner, corrective action, due date, and verification result.

**REQ-083.** An expired waiver MUST cause the related status to be reassessed.

**REQ-084.** A recurring nonconformance MUST trigger management review.

## 13. Legacy coexistence and controlled migration

Existing documentation remains in place until a specifically approved migration plan changes it. No deletion, rename, move, merge, authority reassignment, ID reassignment, or status conversion is authorized by this draft.

A Migration Plan includes source and target identities, authority mapping, content mapping, status mapping, reference inventory, compatibility, freeze point, cutover, rollback, acceptance criteria, independent review, and Project Director approval where subject-matter authority is affected.

**REQ-085.** A legacy artifact MUST NOT be mutated solely to claim conformance with this Constitution.

**REQ-086.** A migration MUST preserve legacy identity and historical references or provide an approved redirect/tombstone record.

**REQ-087.** A migration MUST NOT automatically upgrade Draft, incomplete, or legacy-approved status.

**REQ-088.** A migration affecting subject-matter authority MUST have Project Director approval.

**REQ-089.** A migration MUST have an independently reviewed rollback plan before cutover.

## 14. Amendment, bootstrap ratification, and emergency restoration

This draft cannot ratify itself. Initial effectiveness requires a Project Director approval decision that identifies the exact Revision ID, IAP ID, effective date, and transition provisions. Its first effective release must then be verified like any other release.

Amendments require a proposal, impact analysis, independent constitutional review, resolution or waiver of findings, authorized approval, release, and transition provisions. Editorial corrections may use normal change control only if they do not alter requirement meaning, applicability, authority, lifecycle, or retention.

Emergency amendment is restricted to a documented urgent risk. It must identify the baseline effective Release being changed, the narrow temporary change, scope, reason, approver, expiry, and restoration release. At expiry, a verified restoration release to the identified baseline or a normally approved successor release is mandatory; the emergency release cannot silently persist.

**REQ-090.** Initial ratification MUST be recorded outside the Revision being ratified.

**REQ-091.** An amendment MUST identify affected Requirement IDs and downstream impact.

**REQ-092.** A constitutional amendment MUST undergo Independent Review.

**REQ-093.** An emergency amendment MUST identify its baseline Release ID.

**REQ-094.** An emergency amendment MUST have an expiry date.

**REQ-095.** An emergency amendment expiry MUST trigger a verified restoration release or an approved successor release.

**REQ-096.** An emergency amendment MUST NOT be used to bypass Project Director subject-matter authority.

## 15. Operations, audit, and management review

Audit assesses conformance against defined criteria. Management review evaluates systemic effectiveness, risks, trends, and corrective actions. Neither substitutes for approval. Scheduled review checks continuing applicability; event-driven review is triggered by material authority, architecture, external obligation, or incident changes.

**REQ-097.** Audit findings MUST be recorded and traceable to criteria.

**REQ-098.** Management review MUST review unresolved Critical or recurring Major nonconformances.

**REQ-099.** A material change to an upstream authority MUST trigger impact assessment for dependent released artifacts.

**REQ-100.** Metrics used for management review MUST have definitions, owners, and a stated purpose.

---

# Appendix A — Artifact Type Registry (normative)

The Artifact Type IDs in Section 5 are the initial controlled registry. A new type requires an approved amendment or an approved controlled extension that names its ID, class, purpose, required metadata, lifecycle applicability, retention class, and governing authority.

**REQ-101.** An Artifact Type ID MUST NOT be reused for a different primary responsibility.

**REQ-102.** An extension MUST NOT redefine an existing Artifact Type ID.

**REQ-103.** Every released governed artifact MUST have the minimum metadata in Appendix C.

# Appendix B — Lifecycle transition matrix (normative)

| From | To | Minimum transition record | Gate |
|---|---|---|---|
| Proposed | Draft | author initiation note | metadata complete |
| Draft | Independent Review | Review Record | content and IAP frozen |
| Independent Review | Revision | Review Record / Finding | material issue or requested change |
| Revision | Independent Review | Review Record | revised content and IAP frozen |
| Independent Review | Approval Pending | Review Record | findings verified/disposed |
| Approval Pending | Approved | Approval Record | authorized approver; conformance assessed |
| Approved | Released | Release Record | exact or controlled-transform verification |
| Released | Superseded/Deprecated/Withdrawn/Archived | linked Release or disposition Record | historical integrity preserved |

**REQ-104.** A transition not listed in this matrix MUST be rejected unless an approved amendment defines it.

**REQ-105.** A return from Approval Pending to Revision MUST preserve the prior approval-pending record and create a new review cycle.

# Appendix C — Minimum metadata matrix (normative)

| Artifact class | Minimum metadata |
|---|---|
| All governed documents | Document ID, Revision ID, title, type ID, lifecycle state, IAP ID, owner, source location, version, created/updated dates |
| Constitutional/Policy/Standard | plus authority axes, effective date when released, supersession relationship, applicable requirements |
| Procedure/Guide/Template | plus governing artifact, intended users, compatibility notes |
| Review Record | Record ID, target Revision, reviewer, independence declaration, findings, outcome, verification |
| Approval Record | Record ID, target Revision and IAP, approver, authority basis, decision, date |
| Release Record | Record ID, Release ID, target Revision, target location, release kind, verification, effective status |
| Evidence Record | Record ID, Evidence ID, claim relation, source metadata, locator, retrieved date, limitation |
| Waiver | Record ID, Waiver ID, requirement IDs, scope, risk, controls, approver, expiry |

**REQ-106.** Missing required metadata MUST be assessed as a conformance finding before release.

# Appendix D — Frozen IAP snapshot for this Draft (normative data)

| Field | Frozen value |
|---|---|
| IAP ID | IAP-DOC-CON-000-0.9.0-DRAFT |
| Parent Revision ID | DOC-CON-000@0.9.0-draft |
| Profile version | 1.0.0-draft |
| Freeze status | Frozen for this Draft revision; changes require new revision |
| In-scope types | AT-CONSTITUTION, AT-POLICY, AT-STANDARD, AT-PROCEDURE, AT-GUIDE, AT-TEMPLATE, AT-DECISION, AT-REVIEW, AT-APPROVAL, AT-RELEASE, AT-REGISTER, AT-HANDOFF, AT-BACKLOG, AT-EVIDENCE |
| In-scope locations | Draft Workspace, canonical documentation repository, released Project Files, controlled archive/records locations |
| Exclusions | implementation source code, database schemas as executable artifacts, model outputs, investment decisions, external source systems, unapproved legacy migration |
| Applicable requirements | REQ-001–REQ-130, except where an artifact type is expressly excluded by its own approved IAP |

**REQ-107.** This IAP snapshot MUST NOT be edited in place after Independent Review starts.

# Appendix E — Review finding and record schemas (normative)

Review Record fields: Record ID; target Revision ID; IAP ID; reviewer; independence/conflict declaration; criteria; finding list; recommendation; date; verification evidence.

Finding fields: Finding ID; target Revision ID; one defect statement; severity; violated requirement/criterion; evidence/locator; impact; owner; disposition; resolution evidence; reviewer verification; status.

**REQ-108.** A finding lacking any required schema field MUST be treated as incomplete.

**REQ-109.** A reviewer recommendation MUST distinguish `approve`, `approve with waiver`, `revision required`, and `reject`.

# Appendix F — Release equivalence and retention controls (normative)

An Exact Release compares approved source and projection for content equivalence, excluding only documented transport metadata. A Controlled Transform compares the projection with an approved transform specification and validation criteria. Release Records, Approval Records, Review Records, Decision Records, and Waivers have retention class `Permanent unless external retention obligation requires longer`; other classes require an approved retention schedule.

**REQ-110.** A release verification MUST name its comparison basis and result.

**REQ-111.** Permanent records MUST NOT be deleted or overwritten without a separately authorized legal or regulatory disposition record.

# Appendix G — Controlled extension and acceptance (normative)

An extension may add a Domain Profile, checklist, registry entry, or implementation guidance only when it declares its namespace, scope, owner, version, governing authority, compatibility, additional quality gates, and conformance tests. It may strengthen but may not weaken this Constitution.

**REQ-112.** A controlled extension MUST identify every requirement it supplements.

**REQ-113.** A controlled extension MUST NOT claim to supersede this Constitution without a constitutional amendment.

**REQ-114.** A new profile MUST be independently reviewed before its first release.

# Appendix H — Adoption and acceptance checklist (normative)

Initial adoption is complete only when: (a) bootstrap ratification Record exists; (b) approval identifies this exact Revision and IAP; (c) independent review has resolved or waived applicable findings; (d) release verification exists; (e) the canonical source and published projection are registered; and (f) a legacy transition plan, if any, is separately approved.

**REQ-115.** A release of this Constitution MUST NOT occur before all Appendix H adoption conditions are met.

**REQ-116.** A legacy mapping MUST identify its source, target, disposition, and approval status.

# Appendix I — Nonwaivable controls (normative)

The controls stated as nonwaivable in Section 12 are absolute within internal governance. They apply during normal work, migration, emergency amendment, and restoration.

**REQ-117.** A nonwaivable-control violation MUST be reported as at least a Critical finding.

**REQ-118.** A waiver request MUST explicitly confirm that it does not affect a nonwaivable control.

# Appendix J — Document quality gates (normative)

| Gate | Minimum criteria |
|---|---|
| Draft entry | ID, type, owner, source location, IAP established |
| Review entry | content/IAP frozen; references resolvable; author self-check completed |
| Approval | independent review complete; Critical resolved; Major resolved or waived; conformance assessed |
| Release | approved revision; target identified; release verification passed; records registered |
| Maintenance | periodic/event-driven assessment; dependency changes evaluated |

**REQ-119.** A gate result MUST be recorded with the target Revision ID.

**REQ-120.** A failed gate MUST identify the blocking criterion and responsible owner.

# Appendix K — Integrity and self-application (normative)

This Constitution applies to its own lifecycle after bootstrap ratification. Before ratification, it is a proposal only. This draft establishes no authority to approve itself, alter existing documentation, or publish itself to Project Files.

**REQ-121.** Self-application after ratification MUST use separate Author, Independent Reviewer, Approver, and Release Authority assignments unless a documented delegated authority permits a compatible role combination that preserves reviewer independence.

**REQ-122.** The first effective release MUST retain this draft Revision as a historical predecessor, not overwrite it.

**REQ-123.** An IAP freeze violation MUST invalidate the current review entry and require a new review cycle.

**REQ-124.** An approval referencing an incorrect Revision ID or IAP ID MUST be invalid.

**REQ-125.** A release referencing an incorrect approved Revision ID MUST be invalid.

**REQ-126.** A derived document state that disagrees with the Release Registry MUST be corrected through a Record, not silently edited.

**REQ-127.** A reviewer conflict declaration MUST be retained with the Review Record.

**REQ-128.** Project Files MUST contain only Released projections designated by a valid Release Record.

**REQ-129.** A release rollback MUST create a new Release Record and preserve the prior release history.

**REQ-130.** This Draft MUST remain outside Project Files until bootstrap ratification, approval, and release requirements are fulfilled.

---

## Draft author self-check (informative)

- Process-only scope is explicitly bounded; subject-matter authority is not reassigned.
- Two-axis authority preserves the existing Knowledge Base authority and prioritizes external obligations.
- Document, Revision, Release, Record, Requirement, Finding, Evidence, and Waiver identities are separate.
- The IAP is frozen, revision-specific, type-ID based, and included as immutable snapshot data.
- Revision lifecycle, release validity, and document-derived state are separated.
- Independent review uses atomic findings; approval, conformance, and release are separate controls.
- Normative requirements are not represented as empirical evidence.
- Publication distinguishes source of record from exact/controlled-transform projections.
- Reviewer independence, Draft-in-Project-Files prohibition, legacy mutation prohibition, and record integrity are nonwaivable.
- Bootstrap, legacy transition, and emergency restoration require explicit records and controls.
