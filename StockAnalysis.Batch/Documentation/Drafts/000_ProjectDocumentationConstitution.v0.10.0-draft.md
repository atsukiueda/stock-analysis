# 000 Project Documentation Constitution

> **DRAFT — NOT APPROVED, NOT EFFECTIVE, NOT RELEASED.** This is a proposed revision in the Draft Workspace. It is neither a Project File nor an authoritative source. It MUST NOT supersede, reinterpret, move, rename, or mutate an existing document. A one-time bootstrap decision described in Section 16 is required before any later effective revision exists.

| Control | Value |
|---|---|
| Document ID | DOC-CON-000 |
| Revision ID | DOC-CON-000@0.10.0-draft |
| Provenance ID | PROV-DOC-CONST-000-0010 |
| Artifact Type ID | AT-CONSTITUTION |
| Revision state | Draft |
| Release state | None |
| Conformance | Not assessed |
| Source-of-record (draft) | `Documentation/Drafts/000_ProjectDocumentationConstitution.v0.10.0-draft.md` |
| Frozen IAP | IAP-DOC-CON-000-0.10.0-DRAFT, Appendix E |
| Owner / Author / Reviewer | Proposed / Documentation Team / unassigned |

## Requirement inventory and review mapping

The `REQ-*` statements are normative and atomic. This table is navigation only.

| Independent-review finding | Resolution requirement IDs |
|---|---|
| M-01 Revision and Release ownership | REQ-036–REQ-047, Appendix C |
| M-02 atomic requirements and lint | REQ-010–REQ-014, REQ-114 |
| M-03 identifier registry governance | REQ-015–REQ-027, Appendix B |
| M-04 frozen IAP scope | REQ-028–REQ-035, Appendix E |
| M-05 risk acceptance | REQ-066–REQ-071, Appendix H |
| M-06 external bootstrap | REQ-090–REQ-100, Appendix J |
| M-07 release integrity/reproducibility | REQ-072–REQ-080, Appendix G |
| M-08 nonwaivable Project Files/legacy controls | REQ-081–REQ-089, Appendix I |
| M-09 emergency restoration | REQ-101–REQ-107 |
| M-10 information governance release gate | REQ-108–REQ-113, Appendix K |

---

## 1. Purpose, scope, and priority

This Constitution governs the **process** by which Project documentation is identified, controlled, reviewed, approved, released, retained, and changed. It is not a constitution for investment policy, research conclusions, architecture, data semantics, code, models, or operations.

Authority has two axes. Subject-matter authority decides what the project or a domain means. Documentation-governance authority decides how an artifact is controlled. The Project Director retains ultimate internal subject-matter decision authority. `KnowledgeBase/00_Project/KnowledgeBaseRules.md` retains its existing Knowledge Base subject-matter authority unless a Project Director-approved Migration Plan expressly changes it. External legal, regulatory, contractual, license, security, and privacy obligations override all internal documents.

**REQ-001.** This Constitution MUST govern documentation-control process only within its approved IAP.

**REQ-002.** This Constitution MUST NOT decide a subject-matter design outcome.

**REQ-003.** A subject-matter decision MUST be made by its authorized subject-matter authority.

**REQ-004.** Documentation governance MUST NOT be interpreted as delegated subject-matter authority.

**REQ-005.** An applicable external obligation MUST override an inconsistent internal requirement.

**REQ-006.** An external-obligation conflict MUST be recorded and escalated.

**REQ-007.** `KnowledgeBaseRules.md` MUST retain its existing authority until an approved migration changes it.

**REQ-008.** A lower-level artifact MUST NOT weaken a nonwaivable control.

**REQ-009.** A lower-level artifact MUST NOT create a circular normative dependency.

## 2. Normative grammar and requirements lint

MUST, MUST NOT, SHOULD, and MAY are normative terms. A `REQ-*` statement is one independently testable obligation. Compound prose may explain a requirement but may not introduce an unstated obligation.

**REQ-010.** Each normative obligation MUST have one unique Requirement ID.

**REQ-011.** Each Requirement ID MUST identify one independently testable obligation.

**REQ-012.** A Requirement ID MUST NOT be reused for a different obligation.

**REQ-013.** A requirement change MUST preserve its ID when its obligation is unchanged.

**REQ-014.** A changed obligation MUST receive a new Requirement ID.

**REQ-015.** A requirements lint gate MUST detect duplicate Requirement IDs.

**REQ-016.** A requirements lint gate MUST detect missing Requirement IDs in the declared sequence.

**REQ-017.** A requirements lint gate MUST detect multiple normative modal clauses in one requirement.

**REQ-018.** A requirements lint failure MUST block Approval.

## 3. Terms and claim classes

| Term | Meaning |
|---|---|
| Document | Stable managed information identity. |
| Revision | Immutable controlled expression of a Document. |
| Release | Controlled publication event for one approved Revision and one target. |
| Record | Append-only evidence of a governed event. |
| Source of record | Authoritative stored Revision or Record. |
| Published projection | Target-specific representation derived from a source of record. |
| IAP | Frozen Intended Applicability Profile for a Revision. |
| Risk Acceptance | Authorized, time-bounded acceptance of a named residual risk. |

Claim classes are Fact, Inference, Hypothesis, Opinion, Proposal, Decision, and Normative Requirement. Evidence supports a Fact; it does not create a normative requirement or approval.

**REQ-019.** A material factual claim MUST cite evidence or a precise source locator.

**REQ-020.** An inference MUST be labeled as an inference.

**REQ-021.** A hypothesis MUST be labeled as a hypothesis.

**REQ-022.** A proposal MUST be labeled as a proposal.

**REQ-023.** A decision MUST identify its authority record.

**REQ-024.** A normative requirement MUST NOT be represented as empirical evidence.

## 4. Identifier Registry and lifecycle identity

The Identifier Registry is a controlled source of record administered by an appointed Registry Issuer. It is globally unique across the Project documentation scope, including legacy aliases. The registry records issuer, issue time, class, subject, status, predecessor/successor, reservation, alias, and retirement disposition.

| Class | Pattern | Required use |
|---|---|---|
| Document | `DOC-<CLASS>-<NNN>` | stable document identity |
| Revision | `<Document ID>@<version>` | immutable expression |
| Release | `REL-<YYYY>-<NNN>` | one publication event |
| Record | `REC-<TYPE>-<NNN>` | one controlled record |
| Requirement | `REQ-<NNN>` | one obligation |
| Finding | `FND-<review>-<NNN>` | one defect |
| Evidence | `EVD-<NNN>` | one evidence item |
| IAP | `IAP-<Document>-<revision>` | frozen scope snapshot |
| Risk acceptance | `RAC-<NNN>` | residual-risk decision |
| Migration | `MIG-<NNN>` | approved migration plan |

**REQ-025.** The Identifier Registry MUST be the source of record for governed identifier issuance.

**REQ-026.** The Registry Issuer MUST be identified in each registry entry.

**REQ-027.** A governed identifier MUST be globally unique within the Project documentation scope.

**REQ-028.** A retired identifier MUST NOT be reissued.

**REQ-029.** A reserved identifier MUST record its reservation purpose and expiry.

**REQ-030.** An alias MUST record its canonical identifier and reason.

**REQ-031.** A legacy identifier reconciliation MUST preserve the legacy identifier as an alias or predecessor.

**REQ-032.** Bootstrap identity issuance MUST be recorded in the Identifier Registry.

**REQ-033.** A Revision ID MUST identify exactly one immutable content state.

**REQ-034.** A Release ID MUST identify exactly one release event.

**REQ-035.** A Record ID MUST identify exactly one controlled record.

## 5. Frozen Intended Applicability Profile

Every governed Revision uses a frozen IAP. The IAP is a scope snapshot, not a mutable label. It defines type IDs, targets, channels, audiences, repositories, exclusions, applicable requirements, profile version, as-of timestamp, and cryptographic content hash. A Release may cover only a subset of that revision's IAP, and its subset must be explicit.

| IAP dimension | Definition |
|---|---|
| Artifact types | Controlled Artifact Type IDs in Appendix A |
| Scope targets | named systems, repository areas, or documentation domains |
| Channels | canonical repository, Project Files, archive, controlled external channel |
| Audiences | internal contributors, reviewers, Project Director, authorized consumers |
| Exclusions | named out-of-scope targets, channels, or audiences |

**REQ-036.** Every governed Revision MUST reference one frozen IAP ID.

**REQ-037.** An IAP MUST list Artifact Type IDs.

**REQ-038.** An IAP MUST list Scope Targets.

**REQ-039.** An IAP MUST list Channels.

**REQ-040.** An IAP MUST list Audiences.

**REQ-041.** An IAP MUST list explicit exclusions.

**REQ-042.** An IAP MUST record an as-of timestamp.

**REQ-043.** An IAP MUST record a content hash.

**REQ-044.** An IAP MUST become immutable at Independent Review entry.

**REQ-045.** An IAP change after review entry MUST create a new Revision.

**REQ-046.** A Release IAP subset MUST be recorded in its Release Record.

**REQ-047.** A Release IAP subset MUST NOT exceed the approved Revision IAP.

## 6. Artifact taxonomy and responsibilities

| Type ID | Class | Responsibility |
|---|---|---|
| AT-CONSTITUTION | Constitutional | authority and durable process principles |
| AT-POLICY | Normative | mandatory domain/organization rule |
| AT-STANDARD | Normative | testable common baseline |
| AT-PROCEDURE | Procedural | repeatable method |
| AT-GUIDE | Guidance | nonbinding advice |
| AT-TEMPLATE | Structural | reusable artifact form |
| AT-DECISION | Record | decision/rationale evidence |
| AT-REVIEW | Record | independent findings/dispositions |
| AT-APPROVAL | Record | authorization evidence |
| AT-RELEASE | Record | publication evidence |
| AT-EVIDENCE | Record | factual provenance |
| AT-REGISTER | Navigational | controlled index |
| AT-HANDOFF | Operational | current continuity state |
| AT-BACKLOG | Operational | unadopted candidate work |

**REQ-048.** A governed artifact MUST declare one primary Artifact Type ID.

**REQ-049.** A Record MUST NOT create a normative rule.

**REQ-050.** A Handoff MUST NOT be treated as a decision.

**REQ-051.** A Backlog item MUST NOT be treated as approval.

**REQ-052.** A Register MUST link to its source of record.

## 7. Roles and independence

Roles are Author, Independent Reviewer, Approver, Release Authority, Record Custodian, Registry Issuer, and Project Director. AI labels describe assistance and never constitute human or organizational approval authority.

**REQ-053.** An Author MUST NOT independently review the same Revision.

**REQ-054.** An Independent Reviewer MUST declare conflicts before review.

**REQ-055.** An unresolved reviewer conflict MUST block Approval.

**REQ-056.** An Approver MUST hold delegated subject-matter authority.

**REQ-057.** A Release Authority MUST verify the release target.

**REQ-058.** A Record Custodian MUST preserve controlled records.

**REQ-059.** An AI role label MUST NOT be used as an approval identity.

## 8. Separate Revision and Release state models

Revision state describes content workflow only. Release state describes publication/validity only. A Document status is a deterministic derived value, calculated from Release Registry records; no author may set it manually.

### Revision state matrix

| State | Meaning | Record for entry |
|---|---|---|
| Proposed | candidate has no controlled revision | initiation note |
| Draft | editable controlled revision | Draft record |
| Independent Review | content and IAP frozen for examination | Review Record |
| Revision | findings are being addressed | finding disposition update |
| Approval Pending | review complete; authorization awaited | completed Review Record |
| Approved | content authorized | Approval Record |

### Release state matrix

| State | Meaning | Record for entry |
|---|---|---|
| Scheduled | release authorized for future effective time | Release Record |
| Effective | published projection is valid | verified Release Record |
| Superseded | successor Effective release replaces it | successor Release Record |
| Withdrawn | publication no longer valid | withdrawal Record |
| Archived | retained but no longer operational | archival Record |
| Failed | attempted release did not complete safely | failed Release Record |

Document status algorithm: select all Release Records for Document ID; if any verified Effective release exists, select the one with the latest effective timestamp; otherwise select the latest valid Scheduled release; otherwise `No Effective Release`. Its status is the selected release state. Ties are invalid and block release until a correction record chooses a deterministic ordering key.

**REQ-060.** A Revision state MUST NOT assert publication validity.

**REQ-061.** A Release state MUST NOT assert content-review progress.

**REQ-062.** Only an Approved Revision MAY have a Release Record created.

**REQ-063.** Only a verified Effective Release MAY designate a Project File.

**REQ-064.** Document status MUST be derived by the stated algorithm.

**REQ-065.** An invalid status tie MUST block a new Effective Release.

**REQ-066.** A material change during Independent Review MUST transition to Revision.

**REQ-067.** A return to Independent Review MUST use a new Review Record.

## 9. Review, Approval, conformance, and Risk Acceptance

Independent Review aims to discover defects. Findings are atomic and have Critical, Major, Minor, or Editorial severity. Conformance is an assessment against the frozen IAP and remains separate from approval.

Risk Acceptance is distinct from Approval and waiver: it accepts a defined residual risk, with authority, scope, rationale, monitoring, expiry, and revocation trigger. It cannot waive a nonwaivable control. Approval may proceed with an accepted risk only when the Acceptance Record explicitly authorizes that exact Revision/IAP and all other gates pass.

**REQ-068.** A finding MUST describe exactly one defect.

**REQ-069.** A finding MUST state severity.

**REQ-070.** A finding MUST state its requirement or criterion.

**REQ-071.** A finding MUST state verification evidence.

**REQ-072.** An unresolved Critical finding MUST block Approval.

**REQ-073.** An unresolved Major finding MUST block Approval without approved Risk Acceptance.

**REQ-074.** A reviewer MUST verify every finding disposition.

**REQ-075.** Approval MUST reference the exact Revision ID.

**REQ-076.** Approval MUST reference the frozen IAP ID.

**REQ-077.** Conformance MUST identify the assessed requirements.

**REQ-078.** A Risk Acceptance MUST have an RAC ID.

**REQ-079.** A Risk Acceptance MUST identify an authorized risk authority.

**REQ-080.** A Risk Acceptance MUST identify residual-risk monitoring.

**REQ-081.** A Risk Acceptance MUST have an expiry date.

**REQ-082.** An expired Risk Acceptance MUST block Approval.

**REQ-083.** Approval MUST record any active RAC ID.

## 10. Source of record and release integrity

The canonical repository stores sources of record. Project Files are published projections. An **Exact Copy** release preserves approved content exactly, except declared transport metadata. A **Controlled Transform** release derives a projection through an approved reproducible transformation.

Every Release Record has mode, source Revision hash, projection hash, target, IAP subset, verification result, verifier, timestamp, and failure disposition. Controlled Transform additionally records specification hash, tool name/version, configuration hash, inputs, execution environment, and reproducibility result. A mode manifest enumerates all released projections for the Release ID.

**REQ-084.** A Release Record MUST identify its release mode.

**REQ-085.** A Release Record MUST record the source Revision hash.

**REQ-086.** A Release Record MUST record the projection hash.

**REQ-087.** An Exact Copy release MUST verify content equivalence.

**REQ-088.** A Controlled Transform release MUST record its transform specification hash.

**REQ-089.** A Controlled Transform release MUST record tool version.

**REQ-090.** A Controlled Transform release MUST record configuration hash.

**REQ-091.** A Controlled Transform release MUST record reproducibility result.

**REQ-092.** A mode manifest MUST list every projection for its Release ID.

**REQ-093.** A failed release MUST preserve failure evidence.

**REQ-094.** A failed release MUST NOT alter the approved Revision.

**REQ-095.** A published projection MUST NOT replace the source of record.

## 11. Records, evidence, and retention

Records are append-only. Correcting a record creates a linked corrective record. Evidence items include source, locator, claim relation, publication date where available, applicable period, as-of date, retrieval date, and limitations. Approval, Review, Release, Decision, Risk Acceptance, Migration, and Audit records are retained permanently unless an external obligation requires longer.

**REQ-096.** A controlled Record MUST be identifiable by Record ID.

**REQ-097.** A corrective Record MUST link to its corrected Record.

**REQ-098.** A material Evidence Record MUST record retrieval date.

**REQ-099.** A material Evidence Record MUST record limitations.

**REQ-100.** A permanent Record MUST NOT be overwritten.

## 12. Nonwaivable controls and legacy migration

Nonwaivable controls are: reviewer independence; prohibition on Draft in Project Files; prohibition on Approved-but-unreleased content in Project Files; integrity of records; Project Director subject-matter authority; external-obligation priority; and prohibition on pre-migration legacy mutation. A legacy artifact may change only via a Project Director-approved Migration Plan after Independent Review. A Migration Plan must state source, target, authority mapping, content mapping, status mapping, reference inventory, compatibility, freeze point, cutover, rollback, acceptance criteria, and post-cutover verification.

**REQ-101.** A Draft MUST NOT be placed in Project Files.

**REQ-102.** An Approved-but-unreleased Revision MUST NOT be placed in Project Files.

**REQ-103.** A nonwaivable control MUST NOT receive Risk Acceptance.

**REQ-104.** A legacy artifact MUST NOT be mutated before an approved Migration Plan.

**REQ-105.** A legacy migration MUST use a Project Director-approved Migration Plan.

**REQ-106.** A Migration Plan MUST have Independent Review.

**REQ-107.** A Migration Plan MUST contain rollback criteria.

## 13. Emergency amendment and deterministic restoration

An emergency amendment is a time-limited response to an urgent documented risk. It names the baseline Effective Release ID, the exact restoration Revision ID, restoration IAP ID, restoration target, emergency scope, expiry, authority, and failure-safe behavior. Restoration is a new, verified Release Record; it must never depend on an ambiguous “return to baseline.” If restoration fails, the emergency release becomes Withdrawn at expiry unless a normally approved successor Effective release is verified before expiry; no expired emergency release remains Effective.

**REQ-108.** An emergency amendment MUST identify its baseline Effective Release ID.

**REQ-109.** An emergency amendment MUST identify an exact restoration Revision ID.

**REQ-110.** An emergency amendment MUST identify a restoration IAP ID.

**REQ-111.** An emergency amendment MUST identify a restoration target.

**REQ-112.** An emergency amendment MUST have an expiry timestamp.

**REQ-113.** A failed restoration MUST create a failure Release Record.

**REQ-114.** An expired emergency release MUST NOT remain Effective.

**REQ-115.** Emergency amendment MUST NOT bypass subject-matter authority.

## 14. Information governance release gate

Before a constitutional release, the Release Authority verifies minimum information-governance controls: classification, authorized audience, access/handling restrictions, personal/confidential information assessment, external-sharing assessment, retention class, and legal/regulatory/contractual obligation check. Delegation is permitted only through a written delegation record naming scope, delegate, effective interval, and oversight authority.

**REQ-116.** A constitutional Release Record MUST record information classification.

**REQ-117.** A constitutional Release Record MUST record authorized audience.

**REQ-118.** A constitutional Release Record MUST record handling restrictions.

**REQ-119.** A constitutional release MUST assess personal or confidential information.

**REQ-120.** A constitutional release MUST assess external-sharing restrictions.

**REQ-121.** A constitutional release MUST assess applicable external obligations.

**REQ-122.** An information-governance delegation MUST be recorded.

**REQ-123.** An unresolved information-governance issue MUST block release.

## 15. Amendment and controlled extensions

An amendment identifies affected requirements, downstream impact, review result, approval, release, and transition provisions. An extension may add a profile, checklist, or registry entry but cannot weaken this Constitution. Editorial work may not alter requirement meaning, authority, scope, lifecycle, retention, or information-governance behavior.

**REQ-124.** A constitutional amendment MUST identify affected Requirement IDs.

**REQ-125.** A constitutional amendment MUST undergo Independent Review.

**REQ-126.** An extension MUST identify its governing authority.

**REQ-127.** An extension MUST NOT weaken this Constitution.

**REQ-128.** An editorial change MUST NOT change a normative obligation.

## 16. One-time external bootstrap ratification

This Constitution cannot approve or release itself. Its first effectiveness is established outside the normal release workflow by one Project Director Decision Record. That external bootstrap sequence: (1) creates the Identifier Registry entry and assigns Document, Revision, IAP, and provenance identifiers; (2) appoints the initial Record Custodian, Registry Issuer, Independent Reviewer, Approver, and Release Authority; (3) records independent-review outcome and disposition; (4) records the exact Revision and IAP ratified; (5) declares canonical store and retention; (6) declares effective timestamp and first permitted target; and (7) records failure or refusal without creating an effective release.

The Project Director Decision Record is the sole bootstrap authority; ordinary Approval and Release are unavailable until it succeeds. After successful bootstrap, any first Project Files projection must use the normal release integrity and information-governance gates.

**REQ-129.** Bootstrap MUST be established by a Project Director Decision Record.

**REQ-130.** Bootstrap MUST identify the exact Revision ID.

**REQ-131.** Bootstrap MUST identify the exact IAP ID.

**REQ-132.** Bootstrap MUST appoint initial accountable roles.

**REQ-133.** Bootstrap MUST identify the canonical store.

**REQ-134.** Bootstrap MUST identify retention requirements.

**REQ-135.** Bootstrap MUST identify an effective timestamp.

**REQ-136.** Bootstrap failure MUST be recorded externally.

**REQ-137.** Bootstrap failure MUST NOT create an effective release.

**REQ-138.** Post-bootstrap Project Files publication MUST use the normal release gates.

---

# Appendix A — Artifact Type Registry (normative)

The type table in Section 6 is the initial registry. A new Artifact Type requires a controlled extension naming its Type ID, class, responsibility, metadata, lifecycle applicability, retention class, and authority.

**REQ-139.** An Artifact Type ID MUST NOT be repurposed.

**REQ-140.** A released artifact MUST contain its required metadata.

# Appendix B — Identifier Registry schema (normative)

Required entry fields: identifier; class; canonical subject; issuer; issued timestamp; registry status (`active`, `reserved`, `aliased`, `retired`); predecessor/successor; alias target if applicable; reservation purpose/expiry if applicable; and reconciliation reference for legacy identity.

**REQ-141.** An Identifier Registry entry MUST contain all applicable schema fields.

**REQ-142.** Registry reconciliation MUST be reviewed before migration approval.

# Appendix C — Lifecycle transition constraints (normative)

| Transition | Required record | Blocking condition |
|---|---|---|
| Draft → Independent Review | Review Record | IAP/hash not frozen |
| Independent Review → Revision | Finding update | no material change identified |
| Revision → Independent Review | new Review Record | IAP/content not frozen |
| Approval Pending → Approved | Approval Record | open blocking finding/risk acceptance expired |
| Approved → Scheduled/Effective | Release Record | integrity or information gate fails |
| Effective → Superseded/Withdrawn/Archived | Release/disposition Record | history not preserved |

**REQ-143.** A transition MUST retain its predecessor record.

**REQ-144.** A Release Record MUST state its release state.

# Appendix D — Review and Risk Acceptance schemas (normative)

Review Record: Record ID; target Revision/IAP; reviewer; conflict declaration; criteria; findings; recommendation; date; verification. Finding: Finding ID; one defect; severity; criterion; evidence; impact; owner; disposition; verification.

Risk Acceptance Record: RAC ID; target Revision/IAP; accepted risk; rationale; authority; scope; compensating controls; monitoring; revocation trigger; issue timestamp; expiry; approval-gate effect.

**REQ-145.** A Review Record MUST retain the conflict declaration.

**REQ-146.** A Risk Acceptance Record MUST retain its monitoring plan.

# Appendix E — Frozen IAP snapshot for this Draft (normative data)

| Field | Frozen value |
|---|---|
| IAP ID | IAP-DOC-CON-000-0.10.0-DRAFT |
| Parent Revision | DOC-CON-000@0.10.0-draft |
| Profile version | 1.0.0-draft |
| As-of | 2026-07-18T00:00:00+09:00 |
| Content hash | `UNVERIFIED-DRAFT-HASH; calculate before review entry` |
| Artifact types | AT-CONSTITUTION, AT-POLICY, AT-STANDARD, AT-PROCEDURE, AT-GUIDE, AT-TEMPLATE, AT-DECISION, AT-REVIEW, AT-APPROVAL, AT-RELEASE, AT-EVIDENCE, AT-REGISTER, AT-HANDOFF, AT-BACKLOG |
| Scope Targets | Project documentation governance; KnowledgeBase documentation interfaces; documentation repositories |
| Channels | Draft Workspace; canonical repository; Project Files; controlled archive |
| Audiences | Documentation Team; Independent Reviewer; Project Director; authorized project consumers |
| Exclusions | code; runtime databases; model outputs; investment decisions; external systems; unapproved legacy migration |
| Requirements | REQ-001–REQ-150 |

**REQ-147.** This IAP hash MUST be calculated before Independent Review entry.

**REQ-148.** This IAP MUST remain outside Project Files before a valid release.

# Appendix F — Minimum document and record metadata (normative)

All governed documents: Document ID, Revision ID, Type ID, lifecycle state, IAP ID, owner, source location, version, timestamps. Approval: exact Revision/IAP, authority, approver, decision, date. Release: Release ID, target, mode, state, hashes, subset, verification. Evidence: Evidence ID, claim relation, source, locator, retrieval date, limitation. Migration: MIG ID and Section 12 contents.

**REQ-149.** Missing required metadata MUST block Release.

# Appendix G — Release mode manifest (normative)

The mode manifest is a controlled part of a Release Record. For every projection it records projection ID/location, mode, source hash, projection hash, target, IAP subset, verifier, timestamp, result, and controlled-transform reproducibility fields where applicable.

**REQ-150.** A Release Record without a complete mode manifest MUST be invalid.

# Appendix H — Risk Acceptance decision rules (normative)

Risk Acceptance is limited to residual risks from nonblocking conformance gaps or Major findings where the authorized risk authority explicitly accepts the risk. It is never an Approval Record, a Release Record, or a waiver of nonwaivable controls. Expiry, failed monitoring, or revocation immediately requires reassessment.

# Appendix I — Nonwaivable controls (normative)

The following are nonwaivable in normal work, bootstrap, migration, emergency amendment, and restoration: reviewer independence; Draft and Approved-but-unreleased Project Files prohibition; pre-migration legacy mutation prohibition; record integrity; Project Director subject-matter authority; and external-obligation priority.

# Appendix J — Bootstrap record checklist (normative)

The external Project Director Decision Record includes Decision Record ID; exact Revision/IAP/provenance IDs; identity issuance/reconciliation; role appointments; independent-review evidence; source-of-record store; retention; effective timestamp; decision outcome; failure/refusal handling; and first release target restriction.

# Appendix K — Information-governance release checklist (normative)

Before constitutional publication verify classification, audience, handling/access restrictions, personal/confidential information, external sharing, retention, external obligations, required delegation, and unresolved issues. This checklist is a release gate, not a self-certification.

## Author self-check (informative)

v0.10.0 preserves v0.9.0 as-is and introduces the required separate state models, identifier registry, frozen scope snapshot, risk acceptance, external bootstrap, integrity/reproducibility controls, strict Project Files and legacy safeguards, deterministic emergency restoration, and information-governance release checks. It remains a Draft and has not modified existing Project documentation or Project Files.
