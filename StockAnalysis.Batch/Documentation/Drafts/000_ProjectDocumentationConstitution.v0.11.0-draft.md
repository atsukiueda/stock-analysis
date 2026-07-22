# 000 Project Documentation Constitution

> **DRAFT — NOT APPROVED, NOT EFFECTIVE, NOT RELEASED.** This proposed Revision is held only in the Draft Workspace. It is not a Project File, does not alter existing authority, and has no binding effect. It may become effective only through the external bootstrap process in Section 16.

| Field | Value |
|---|---|
| Document ID | DOC-CON-000 |
| Revision ID | DOC-CON-000@0.11.0-draft |
| Provenance ID | PROV-DOC-CONST-000-0011 |
| Artifact Type | AT-CONSTITUTION |
| Revision state | Draft |
| Release state | None |
| IAP snapshot | IAP-DOC-CON-000-0.11.0-DRAFT (Appendix E) |
| Draft source | `Documentation/Drafts/000_ProjectDocumentationConstitution.v0.11.0-draft.md` |

## Review-finding mapping

| Finding | Complete remediation requirement IDs |
|---|---|
| M-01 Revision/Release state ownership | REQ-055–REQ-067; Appendix C |
| M-02 atomic requirements and lint | REQ-010–REQ-020; Appendix A |
| M-03 identifier registry | REQ-021–REQ-032; Appendix B |
| M-04 frozen IAP scope | REQ-033–REQ-047; Appendix E |
| M-05 risk acceptance | REQ-071–REQ-083; Appendix D |
| M-06 external bootstrap | REQ-137–REQ-147; Appendix J |
| M-07 release integrity | REQ-084–REQ-100; Appendix F |
| M-08 Project Files and legacy | REQ-103–REQ-109; Appendices G–H |
| M-09 emergency restoration | REQ-110–REQ-123; Appendix I |
| M-10 information governance | REQ-124–REQ-133; Appendix K |

**REQ-001.** The mapping table MUST reference every M-01 through M-10 finding.

**REQ-002.** The mapping table MUST reference only Requirement IDs defined in this Revision.

**REQ-003.** A mapping-consistency lint MUST verify REQ-001.

**REQ-004.** A mapping-consistency lint MUST verify REQ-002.

## 1. Purpose, scope, and authority

This Constitution controls documentation process: identity, review, approval, release, retention, and change. It does not decide investment, research, architecture, data, software, models, or operational subject matter. Subject-matter authority decides content; documentation-governance authority decides document control. The Project Director retains highest internal subject-matter authority. `KnowledgeBase/00_Project/KnowledgeBaseRules.md` remains its current Knowledge Base subject-matter authority until a Project Director-approved migration explicitly changes it. Applicable external legal, regulatory, contractual, license, security, and privacy obligations take priority.

**REQ-005.** This Constitution MUST govern documentation control within its IAP.

**REQ-006.** This Constitution MUST NOT decide subject-matter outcomes.

**REQ-007.** Documentation governance MUST NOT imply subject-matter delegation.

**REQ-008.** An external obligation MUST override an inconsistent internal obligation.

**REQ-009.** An external-obligation conflict MUST be recorded.

## 2. Normative grammar and atomicity lint

MUST, MUST NOT, SHOULD, and MAY are normative. A requirement is atomic only when one independently testable predicate/action is associated with one Requirement ID. Explanatory prose creates no obligation.

**REQ-010.** Each normative obligation MUST have one Requirement ID.

**REQ-011.** Each Requirement ID MUST name one independently testable predicate.

**REQ-012.** Each Requirement ID MUST name one independently testable action.

**REQ-013.** A Requirement ID MUST NOT be reused.

**REQ-014.** A changed obligation MUST receive a new Requirement ID.

**REQ-015.** A requirements lint MUST detect duplicate Requirement IDs.

**REQ-016.** A requirements lint MUST detect missing sequence members.

**REQ-017.** A requirements lint MUST detect more than one independently testable predicate in a requirement.

**REQ-018.** A requirements lint MUST detect more than one independently testable action in a requirement.

**REQ-019.** A requirements-lint failure MUST block Review Entry.

**REQ-020.** A requirements-lint failure MUST block Approval.

## 3. Terms and Identifier Registry

Document: stable identity. Revision: immutable expression of a Document. Release: controlled publication event. Record: append-only evidence of an event. Source of record: authoritative stored Revision or Record. Projection: target-specific representation. IAP: frozen applicability snapshot. Release Applicability Key (RAK): tuple of `(Document ID, Scope Target Snapshot ID, Channel Snapshot ID, Audience Snapshot ID, IAP Subset Hash)`. Risk Acceptance: authorized time-bounded residual-risk decision.

The Identifier Registry is the globally unique source of record. A Registry Issuer creates entries. Every entry has identifier, class, subject, issuer, issued timestamp, status, predecessor/successor, alias target when applicable, reservation purpose/expiry when applicable, and legacy reconciliation when applicable.

| Class | Pattern |
|---|---|
| Document | `DOC-<CLASS>-<NNN>` |
| Revision | `<Document ID>@<version>` |
| Release | `REL-<YYYY>-<NNN>` |
| Record | `REC-<TYPE>-<NNN>` |
| Requirement | `REQ-<NNN>` |
| Finding | `FND-<review>-<NNN>` |
| Evidence | `EVD-<NNN>` |
| IAP | `IAP-<Document>-<revision>` |
| Snapshot | `SNP-<kind>-<NNN>` |
| Risk Acceptance | `RAC-<NNN>` |
| Migration | `MIG-<NNN>` |

**REQ-021.** The Identifier Registry MUST be the identity source of record.

**REQ-022.** A registry entry MUST identify its Registry Issuer.

**REQ-023.** A governed identifier MUST be globally unique.

**REQ-024.** A retired identifier MUST NOT be reissued.

**REQ-025.** A reservation MUST record its purpose.

**REQ-026.** A reservation MUST record its expiry.

**REQ-027.** An alias MUST record its canonical identifier.

**REQ-028.** A legacy identity MUST be preserved as an alias or predecessor.

**REQ-029.** Bootstrap issuance MUST be recorded in the Registry.

**REQ-030.** A Revision ID MUST identify one immutable content state.

**REQ-031.** A Release ID MUST identify one release event.

**REQ-032.** A Record ID MUST identify one controlled record.

## 4. Frozen IAP and controlled scope sets

An IAP freezes the full applicability context for one Revision. It contains Artifact Type IDs, `Scope Target Snapshot ID`, `Channel Snapshot ID`, `Audience Snapshot ID`, exclusions, applicable Requirement IDs, profile version, as-of timestamp, and IAP hash. Each snapshot is a controlled immutable list: snapshot ID, list version, list members using stable IDs, as-of timestamp, and snapshot hash. Natural-language labels may describe a member but cannot be its sole identity. A Release records an IAP subset by snapshot-member IDs and a subset hash.

**REQ-033.** Every governed Revision MUST reference one IAP ID.

**REQ-034.** An IAP MUST reference an Artifact Type ID set.

**REQ-035.** An IAP MUST reference a Scope Target Snapshot ID.

**REQ-036.** An IAP MUST reference a Channel Snapshot ID.

**REQ-037.** An IAP MUST reference an Audience Snapshot ID.

**REQ-038.** A scope snapshot MUST use stable member IDs.

**REQ-039.** A scope snapshot MUST record its version.

**REQ-040.** A scope snapshot MUST record its as-of timestamp.

**REQ-041.** A scope snapshot MUST record its hash.

**REQ-042.** An IAP MUST record its hash.

**REQ-043.** An IAP MUST become immutable at Review Entry.

**REQ-044.** An IAP change after Review Entry MUST create a new Revision.

**REQ-045.** A Release MUST record its IAP subset hash.

**REQ-046.** A Release subset MUST be contained by its Revision IAP.

**REQ-047.** An IAP hash MUST be calculated before Review Entry.

## 5. Artifact types, roles, and evidence

Artifact Type IDs: AT-CONSTITUTION, AT-POLICY, AT-STANDARD, AT-PROCEDURE, AT-GUIDE, AT-TEMPLATE, AT-DECISION, AT-REVIEW, AT-APPROVAL, AT-RELEASE, AT-EVIDENCE, AT-REGISTER, AT-HANDOFF, and AT-BACKLOG. Policies/standards are normative; procedures are repeatable methods; records evidence events; handoffs/backlogs are non-authoritative state.

Roles are Author, Independent Reviewer, Approver, Release Authority, Record Custodian, Registry Issuer, and Project Director. AI labels are assistance labels only. Facts require evidence or source locators. Inferences, hypotheses, opinions, proposals, and decisions are labeled. Normative requirements are not empirical evidence.

**REQ-048.** A governed artifact MUST declare one primary Artifact Type ID.

**REQ-049.** A Record MUST NOT create a normative requirement.

**REQ-050.** An Author MUST NOT review the same Revision independently.

**REQ-051.** A reviewer conflict MUST be declared before review.

**REQ-052.** An unresolved reviewer conflict MUST block Approval.

**REQ-053.** A material fact MUST cite evidence or a precise locator.

**REQ-054.** A normative requirement MUST NOT be assigned an Evidence ID.

## 6. Separate Revision and Release state models

Revision states are `Proposed`, `Draft`, `Independent Review`, `Revision`, `Approval Pending`, and `Approved`. These states describe content workflow only. Release states are `Scheduled`, `Effective`, `Superseded`, `Withdrawn`, `Archived`, and `Failed`. These states describe one RAK's publication validity only.

For each RAK, Document State is calculated from Release Records: choose the verified Effective record with the greatest effective timestamp; if none exists choose the valid Scheduled record with the earliest scheduled timestamp; otherwise return `No Effective Release`. Concurrent Effective releases with non-overlapping RAK scope are valid. Concurrent Effective releases whose Scope Target, Channel, Audience, and IAP-subset member intersections are all nonempty are an overlap conflict. An overlap conflict must be resolved by an ordered correction record before any affected RAK can be released.

**REQ-055.** A Revision state MUST NOT assert release validity.

**REQ-056.** A Release state MUST NOT assert review progress.

**REQ-057.** An Approved Revision MUST be required before Release creation.

**REQ-058.** A Release Applicability Key MUST identify Scope Target Snapshot ID.

**REQ-059.** A Release Applicability Key MUST identify Channel Snapshot ID.

**REQ-060.** A Release Applicability Key MUST identify Audience Snapshot ID.

**REQ-061.** A Release Applicability Key MUST identify IAP Subset Hash.

**REQ-062.** Document state MUST be derived per Release Applicability Key.

**REQ-063.** Non-overlapping Effective releases MUST be permitted.

**REQ-064.** An overlapping Effective release conflict MUST block the affected release.

**REQ-065.** An overlap correction MUST be recorded.

**REQ-066.** A material review change MUST transition the Revision to Revision state.

**REQ-067.** A return to Independent Review MUST create a new Review Record.

## 7. Independent review, conformance, and Risk Acceptance

Review finds defects. Every finding is atomic and contains Finding ID, one defect, severity, criterion, evidence, impact, owner, disposition, and verification. Severity is Critical, Major, Minor, or Editorial. Conformance is assessed against the frozen IAP and is distinct from Approval. Risk Acceptance is distinct from Approval and waiver.

**REQ-068.** A finding MUST describe one defect.

**REQ-069.** A finding MUST state one severity.

**REQ-070.** A finding MUST state verification evidence.

**REQ-071.** An unresolved Critical finding MUST block Approval.

**REQ-072.** An unresolved Major finding MUST block Approval without Risk Acceptance.

**REQ-073.** A reviewer MUST verify each finding disposition.

**REQ-074.** An Approval Record MUST identify exact Revision ID.

**REQ-075.** An Approval Record MUST identify exact IAP ID.

**REQ-076.** A conformance assessment MUST identify its assessed requirements.

**REQ-077.** A Risk Acceptance MUST have an RAC ID.

**REQ-078.** A Risk Acceptance MUST identify its risk authority.

**REQ-079.** A Risk Acceptance MUST identify its residual risk.

**REQ-080.** A Risk Acceptance MUST identify its monitoring action.

**REQ-081.** A Risk Acceptance MUST identify its expiry timestamp.

**REQ-082.** An expired Risk Acceptance MUST block Approval.

**REQ-083.** An Approval Record MUST list active RAC IDs.

## 8. Release integrity and reproducibility

The canonical repository holds sources of record. Project Files hold released projections. An Exact Copy is content-identical source/projection publication. A Controlled Transform is a reproducible derivation. Every Release Record contains Release ID, source Revision ID, RAK, mode, source hash, projection hash, target, verifier, timestamp, mode manifest, and result.

For Exact Copy, source and projection hashes use the same declared algorithm and must equal. For Controlled Transform, the record identifies source hash, transform specification ID, transform specification hash, tool name, tool version, configuration hash, input hash, environment identity, projection hash, independent reproduction verifier, independent reproduction timestamp, and reproduced projection hash. Independent reproduction uses the recorded inputs/specification/configuration in a separate execution context. Equality of reproduced projection hash and recorded projection hash is the required successful result.

**REQ-084.** A Release Record MUST identify one release mode.

**REQ-085.** A Release Record MUST record its source hash.

**REQ-086.** A Release Record MUST record its projection hash.

**REQ-087.** An Exact Copy source hash MUST equal its projection hash.

**REQ-088.** A Controlled Transform MUST record transform specification ID.

**REQ-089.** A Controlled Transform MUST record transform specification hash.

**REQ-090.** A Controlled Transform MUST record tool name.

**REQ-091.** A Controlled Transform MUST record tool version.

**REQ-092.** A Controlled Transform MUST record configuration hash.

**REQ-093.** A Controlled Transform MUST record input hash.

**REQ-094.** A Controlled Transform MUST record environment identity.

**REQ-095.** A Controlled Transform MUST record independent reproduction verifier.

**REQ-096.** A Controlled Transform MUST record independent reproduction timestamp.

**REQ-097.** A Controlled Transform reproduced hash MUST equal its projection hash.

**REQ-098.** A mode manifest MUST list every projection.

**REQ-099.** A failed Release MUST preserve failure evidence.

**REQ-100.** A failed Release MUST NOT change the approved Revision.

## 9. Records, Project Files, and legacy migration

Records are append-only. Corrections are new linked records. Review, approval, release, decision, risk acceptance, migration, and audit records have permanent retention unless an external obligation requires longer. Nonwaivable controls include reviewer independence, draft and approved-unreleased Project Files prohibition, record integrity, Project Director subject-matter authority, external-obligation priority, and all pre-migration legacy mutation.

**REQ-101.** A controlled Record MUST have a Record ID.

**REQ-102.** A corrective Record MUST link to its predecessor Record.

**REQ-103.** A Draft MUST NOT be placed in Project Files.

**REQ-104.** An Approved-unreleased Revision MUST NOT be placed in Project Files.

**REQ-105.** A nonwaivable control MUST NOT receive Risk Acceptance.

**REQ-106.** A legacy artifact MUST NOT be mutated before Migration Plan approval.

**REQ-107.** A legacy migration MUST use a Project Director-approved Migration Plan.

**REQ-108.** A Migration Plan MUST undergo Independent Review.

**REQ-109.** A Migration Plan MUST contain a rollback plan.

## 10. Emergency amendment and restoration

An emergency amendment is a narrowly scoped urgent change. It is an immutable emergency Revision. A Project Director emergency approval record must exist before it is Effective. It names baseline Effective Release ID, restoration Revision ID, restoration IAP ID, restoration target, duration, expiry, protected controls, and post-review deadline. Maximum duration is 30 calendar days. Serial, reissued, or materially equivalent emergency releases cannot extend the same emergency condition. The Project Director may only approve a normally reviewed successor after post-review. At expiry, a verified restoration release to the named target or a normally approved successor must be Effective; otherwise the emergency release becomes Withdrawn.

**REQ-110.** An emergency amendment MUST use an immutable Revision.

**REQ-111.** An emergency amendment MUST have Project Director approval before effect.

**REQ-112.** An emergency amendment MUST identify its baseline Release ID.

**REQ-113.** An emergency amendment MUST identify restoration Revision ID.

**REQ-114.** An emergency amendment MUST identify restoration IAP ID.

**REQ-115.** An emergency amendment MUST identify restoration target.

**REQ-116.** An emergency amendment MUST have a maximum duration of 30 days.

**REQ-117.** An emergency amendment MUST have an expiry timestamp.

**REQ-118.** A serial emergency release MUST NOT extend an equivalent emergency condition.

**REQ-119.** A reissued emergency release MUST NOT extend an equivalent emergency condition.

**REQ-120.** An emergency amendment MUST specify protected controls.

**REQ-121.** An emergency amendment MUST specify a post-review deadline.

**REQ-122.** A failed restoration MUST create a Failed Release Record.

**REQ-123.** An expired emergency release MUST NOT remain Effective.

## 11. Information-governance release gate

Before every constitutional release, the Release Authority checks classification, authorized audience, handling/access restrictions, personal/confidential information, external sharing, retention, and applicable external obligations. Delegation is permitted only by a written delegation record with scope, delegate, interval, and oversight authority. An unresolved information-governance issue blocks release.

**REQ-124.** A constitutional Release Record MUST record information classification.

**REQ-125.** A constitutional Release Record MUST record authorized audience.

**REQ-126.** A constitutional Release Record MUST record handling restrictions.

**REQ-127.** A constitutional release MUST assess personal information.

**REQ-128.** A constitutional release MUST assess confidential information.

**REQ-129.** A constitutional release MUST assess external sharing.

**REQ-130.** A constitutional release MUST assess retention.

**REQ-131.** A constitutional release MUST assess external obligations.

**REQ-132.** An information-governance delegation MUST be recorded.

**REQ-133.** An unresolved information-governance issue MUST block release.

## 12. Amendment and external bootstrap

Amendments identify affected requirements and undergo Independent Review. Extensions may add profiles/checklists but cannot weaken this Constitution. This Draft cannot approve itself. Initial validity comes only from one external Project Director Decision Record, not an ordinary Release. Bootstrap records exact Revision/IAP/provenance IDs, registry issuance, initial role appointments, review disposition, canonical store, retention, effective timestamp, permitted first target, and failure/refusal. After successful bootstrap, Project Files publication uses ordinary release integrity and information-governance gates.

**REQ-134.** An amendment MUST identify affected Requirement IDs.

**REQ-135.** An amendment MUST undergo Independent Review.

**REQ-136.** An extension MUST NOT weaken this Constitution.

**REQ-137.** Bootstrap MUST use a Project Director Decision Record.

**REQ-138.** Bootstrap MUST identify exact Revision ID.

**REQ-139.** Bootstrap MUST identify exact IAP ID.

**REQ-140.** Bootstrap MUST identify exact Provenance ID.

**REQ-141.** Bootstrap MUST record initial role appointments.

**REQ-142.** Bootstrap MUST record canonical store.

**REQ-143.** Bootstrap MUST record retention.

**REQ-144.** Bootstrap MUST record effective timestamp.

**REQ-145.** Bootstrap failure MUST be recorded externally.

**REQ-146.** Bootstrap failure MUST NOT create an Effective Release.

**REQ-147.** Post-bootstrap Project Files publication MUST use normal release gates.

---

# Appendix A — Requirement lint protocol (normative)

The lint checks unique IDs, declared sequence, mapping consistency, one independently testable predicate, and one independently testable action. A human reviewer verifies ambiguous results. Lint result, tool/version/ruleset, target Revision hash, timestamp, and operator are recorded.

**REQ-148.** A lint record MUST identify the target Revision hash.

**REQ-149.** A lint record MUST identify its ruleset version.

# Appendix B — Identifier Registry schema (normative)

Required entry fields are identifier, class, canonical subject, issuer, issued timestamp, status, predecessor/successor, alias target, reservation purpose, reservation expiry, and legacy reconciliation reference when applicable.

**REQ-150.** An Identifier Registry entry MUST contain applicable schema fields.

# Appendix C — State transition matrix (normative)

| Transition | Required record | Blocker |
|---|---|---|
| Draft → Independent Review | Review Record | lint/IAP hash failure |
| Independent Review → Revision | Finding update | none |
| Revision → Independent Review | new Review Record | lint/IAP hash failure |
| Approval Pending → Approved | Approval Record | Critical/open Major without RAC |
| Approved → Scheduled/Effective | Release Record | integrity/info gate failure |
| Effective → Superseded/Withdrawn/Archived | disposition record | historical loss |

**REQ-151.** A transition MUST preserve its predecessor Record.

# Appendix D — Review and Risk Acceptance schemas (normative)

Review Record: Record ID, Revision/IAP, reviewer, conflict declaration, criteria, findings, recommendation, date, verification. Risk Acceptance: RAC ID, Revision/IAP, residual risk, authority, scope, rationale, controls, monitoring, revocation trigger, expiry, and approval effect.

**REQ-152.** A Review Record MUST retain conflict declaration.

**REQ-153.** A Risk Acceptance MUST retain its monitoring action.

# Appendix E — IAP snapshot for this Draft (normative data)

| Field | Frozen Draft value |
|---|---|
| IAP ID | IAP-DOC-CON-000-0.11.0-DRAFT |
| Parent Revision | DOC-CON-000@0.11.0-draft |
| IAP version | 1.0.0-draft |
| Scope Target Snapshot | SNP-SCOPE-0001 / v1.0 / members `TGT-DOC-GOV`, `TGT-KB-INTERFACE`, `TGT-DOC-REPO` |
| Channel Snapshot | SNP-CHANNEL-0001 / v1.0 / members `CH-DRAFT`, `CH-CANONICAL`, `CH-PROJECT-FILES`, `CH-ARCHIVE` |
| Audience Snapshot | SNP-AUDIENCE-0001 / v1.0 / members `AUD-DOC-TEAM`, `AUD-INDEPENDENT-REVIEW`, `AUD-PROJECT-DIRECTOR`, `AUD-AUTHORIZED-CONSUMER` |
| As-of | 2026-07-18T00:00:00+09:00 |
| Scope hashes | `PENDING-CALCULATION-BEFORE-REVIEW-ENTRY` |
| IAP hash | `PENDING-CALCULATION-BEFORE-REVIEW-ENTRY` |
| Exclusions | `EXC-CODE`, `EXC-RUNTIME-DATA`, `EXC-MODEL-OUTPUT`, `EXC-INVESTMENT-DECISION`, `EXC-UNAPPROVED-LEGACY-MIGRATION` |
| Applicable requirements | REQ-001–REQ-155 |

**REQ-154.** This Draft MUST NOT enter Independent Review before its pending hashes are replaced with calculated hashes.

# Appendix F — Release manifest schema (normative)

The manifest stores Release ID, RAK, source/projection hashes, mode, target, subset hash, verifier, timestamp, result, failure evidence, and all controlled-transform reproduction fields specified in Section 8.

**REQ-155.** A Release Record MUST contain a complete mode manifest.

# Appendix G — Nonwaivable controls (normative)

Reviewer independence, Draft Project Files prohibition, Approved-unreleased Project Files prohibition, record integrity, Project Director subject-matter authority, external-obligation priority, and pre-migration legacy mutation prohibition are nonwaivable in all contexts.

# Appendix H — Migration Plan schema (normative)

A Migration Plan records MIG ID, source, target, authority map, content map, status map, reference inventory, compatibility, freeze point, cutover, rollback, acceptance criteria, independent review, and Project Director approval.

# Appendix I — Emergency approval record schema (normative)

An emergency approval record records immutable Revision, Project Director approval, baseline, restoration Revision/IAP/target, protected controls, duration, expiry, no-extension declaration, post-review deadline, and failure-safe withdrawal behavior.

# Appendix J — External bootstrap checklist (normative)

The external Project Director Decision Record records identity issuance, exact Revision/IAP/provenance identities, appointments, independent-review disposition, store, retention, timestamp, first target restriction, and failure/refusal result.

# Appendix K — Information-governance checklist (normative)

The release gate checks classification, audience, handling, personal/confidential information, external sharing, retention, external obligations, delegation, and unresolved issues.

## Draft self-check (informative)

v0.11.0 retains prior drafts unchanged. It adds RAK-specific document state, controlled scope snapshots, action/predicate linting, complete release reproducibility evidence, pre-effect emergency approval and anti-extension controls, and corrected M-01–M-10 mapping. It remains a non-effective Draft outside Project Files.
