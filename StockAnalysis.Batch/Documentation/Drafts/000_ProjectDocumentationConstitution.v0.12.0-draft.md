# 000 Project Documentation Constitution

> **DRAFT — NOT APPROVED, NOT EFFECTIVE, NOT RELEASED.** This Draft is in the Draft Workspace only. It is not a Project File, cannot alter existing documents, and has no authority until the external bootstrap in Section 15.

| Field | Value |
|---|---|
| Document / Revision | DOC-CON-000 / DOC-CON-000@0.12.0-draft |
| Provenance | PROV-DOC-CONST-000-0012 |
| Artifact type / state | AT-CONSTITUTION / Draft |
| IAP | IAP-DOC-CON-000-0.12.0-DRAFT (Appendix E) |
| Draft source | `Documentation/Drafts/000_ProjectDocumentationConstitution.v0.12.0-draft.md` |

## Review mapping

| Finding | Remediation |
|---|---|
| M-01 Release state ownership | REQ-056–REQ-067; Appendix C |
| M-02 atomicity/lint | REQ-010–REQ-020; Appendix A |
| M-03 Identifier Registry | REQ-021–REQ-032; Appendix B |
| M-04 frozen IAP | REQ-033–REQ-048; Appendix E |
| M-05 Risk Acceptance | REQ-071–REQ-080; Appendix D |
| M-06 external bootstrap | REQ-136–REQ-146; Appendix J |
| M-07 release integrity | REQ-079–REQ-095; Appendix F |
| M-08 Project Files/legacy | REQ-102–REQ-108; Appendix H |
| M-09 emergency | REQ-109–REQ-122; Appendix I |
| M-10 information governance | REQ-123–REQ-132; Appendix K |
| M-11-01 transition completeness | REQ-056–REQ-067; Appendix C |
| M-11-02 Waiver/nonwaivable controls | REQ-096–REQ-108; Appendices G–H |

**REQ-001.** The review mapping MUST list M-01 through M-11-02.

**REQ-002.** The review mapping MUST reference defined Requirement IDs.

**REQ-003.** A mapping lint MUST verify REQ-001.

**REQ-004.** A mapping lint MUST verify REQ-002.

## 1. Purpose and authority

This Constitution governs documentation identity, review, approval, release, retention, and change. It does not decide investment, research, architecture, data, code, model, or operational subject matter. Subject-matter authority decides content; documentation-governance authority decides document control. The Project Director retains highest internal subject-matter authority. `KnowledgeBase/00_Project/KnowledgeBaseRules.md` retains existing Knowledge Base authority until a Project Director-approved migration changes it. Applicable law, regulation, contract, license, security, and privacy obligations have priority.

**REQ-005.** This Constitution MUST govern documentation control within its IAP.

**REQ-006.** This Constitution MUST NOT decide subject-matter outcomes.

**REQ-007.** Documentation governance MUST NOT imply subject-matter delegation.

**REQ-008.** An external obligation MUST override an inconsistent internal obligation.

**REQ-009.** An external-obligation conflict MUST be recorded.

## 2. Atomic requirements

MUST, MUST NOT, SHOULD, and MAY are normative. One Requirement ID represents one independently testable predicate and one independently testable action.

**REQ-010.** Each normative obligation MUST have one Requirement ID.

**REQ-011.** Each Requirement ID MUST name one independently testable predicate.

**REQ-012.** Each Requirement ID MUST name one independently testable action.

**REQ-013.** A Requirement ID MUST NOT be reused.

**REQ-014.** A changed obligation MUST receive a new Requirement ID.

**REQ-015.** A lint MUST detect duplicate Requirement IDs.

**REQ-016.** A lint MUST detect missing Requirement IDs.

**REQ-017.** A lint MUST detect multiple predicates in one requirement.

**REQ-018.** A lint MUST detect multiple actions in one requirement.

**REQ-019.** A lint failure MUST block Review Entry.

**REQ-020.** A lint failure MUST block Approval.

## 3. Terms and Identifier Registry

Document means stable managed identity. Revision means immutable Document expression. Release means a controlled publication event. Record means append-only event evidence. IAP means frozen applicability profile. RAK means `(Document, Scope Target Snapshot, Channel Snapshot, Audience Snapshot, IAP Subset Hash)`. Risk Acceptance accepts a residual risk. Waiver authorizes a narrow temporary nonconformance.

The Identifier Registry is the global identity source of record. Entries record identifier, class, subject, issuer, issue time, status, predecessor/successor, alias target, reservation purpose/expiry, and legacy reconciliation. Classes are Document (`DOC-*`), Revision (`DOC@version`), Release (`REL-*`), Record (`REC-*`), Requirement (`REQ-*`), Finding (`FND-*`), Evidence (`EVD-*`), IAP (`IAP-*`), Snapshot (`SNP-*`), Risk Acceptance (`RAC-*`), Waiver (`WVR-*`), and Migration (`MIG-*`).

**REQ-021.** The Identifier Registry MUST be the identity source of record.

**REQ-022.** A registry entry MUST identify its issuer.

**REQ-023.** A governed identifier MUST be globally unique.

**REQ-024.** A retired identifier MUST NOT be reissued.

**REQ-025.** A reservation MUST record its purpose.

**REQ-026.** A reservation MUST record its expiry.

**REQ-027.** An alias MUST record its canonical identifier.

**REQ-028.** A legacy identity MUST be retained as alias or predecessor.

**REQ-029.** Bootstrap issuance MUST be recorded in the Registry.

**REQ-030.** A Revision ID MUST identify one immutable content state.

**REQ-031.** A Release ID MUST identify one publication event.

**REQ-032.** A Record ID MUST identify one controlled record.

## 4. Frozen IAP

An IAP freezes applicability for one Revision. It contains Artifact Type IDs, Scope Target Snapshot ID, Channel Snapshot ID, Audience Snapshot ID, exclusions, applicable Requirement IDs, version, as-of timestamp, and IAP hash. Every snapshot is an immutable controlled list with ID, version, stable members, as-of, and hash. A Release records member-ID subset and subset hash.

**REQ-033.** A governed Revision MUST reference one IAP ID.

**REQ-034.** An IAP MUST reference Artifact Type IDs.

**REQ-035.** An IAP MUST reference Scope Target Snapshot ID.

**REQ-036.** An IAP MUST reference Channel Snapshot ID.

**REQ-037.** An IAP MUST reference Audience Snapshot ID.

**REQ-038.** A snapshot MUST use stable member IDs.

**REQ-039.** A snapshot MUST record its version.

**REQ-040.** A snapshot MUST record its as-of timestamp.

**REQ-041.** A snapshot MUST record its hash.

**REQ-042.** An IAP MUST record its hash.

**REQ-043.** An IAP MUST become immutable at Review Entry.

**REQ-044.** An IAP change after Review Entry MUST create a new Revision.

**REQ-045.** A Release MUST record its IAP subset hash.

**REQ-046.** A Release subset MUST be contained by its IAP.

**REQ-047.** An IAP hash MUST be calculated before Review Entry.

**REQ-048.** A snapshot hash MUST be calculated before Review Entry.

## 5. Artifacts, roles, and evidence

Artifact types are AT-CONSTITUTION, AT-POLICY, AT-STANDARD, AT-PROCEDURE, AT-GUIDE, AT-TEMPLATE, AT-DECISION, AT-REVIEW, AT-APPROVAL, AT-RELEASE, AT-EVIDENCE, AT-REGISTER, AT-HANDOFF, and AT-BACKLOG. Records report events and cannot create rules. Author, Independent Reviewer, Approver, Release Authority, Record Custodian, Registry Issuer, and Project Director are distinct roles. AI labels do not constitute approval. Facts require evidence; inference, hypothesis, opinion, proposal, and decision are labeled; normative requirements are not evidence.

**REQ-049.** A governed artifact MUST declare one Artifact Type ID.

**REQ-050.** A Record MUST NOT create a normative rule.

**REQ-051.** An Author MUST NOT independently review the same Revision.

**REQ-052.** A reviewer conflict MUST be declared before review.

**REQ-053.** An unresolved reviewer conflict MUST block Approval.

**REQ-054.** A material fact MUST cite evidence or a precise locator.

**REQ-055.** A normative requirement MUST NOT be empirical evidence.

## 6. Revision and Release models

Revision states are Proposed, Draft, Independent Review, Revision, Approval Pending, Approved. They describe content workflow only. Release states are Scheduled, Effective, Superseded, Withdrawn, Archived, Failed. They describe RAK publication only.

For a RAK, derived Document State selects verified Effective release with greatest effective timestamp; if none, valid Scheduled with earliest scheduled timestamp; otherwise No Effective Release. Effective releases with nonoverlapping Scope Target, Channel, Audience, or IAP-subset member sets may coexist. Releases overlap if all four member intersections are nonempty. An overlap conflict blocks the affected RAK until a correction record gives ordering.

**REQ-056.** A Revision state MUST NOT assert release validity.

**REQ-057.** A Release state MUST NOT assert review progress.

**REQ-058.** A Release MUST require an Approved Revision.

**REQ-059.** A RAK MUST identify Scope Target Snapshot ID.

**REQ-060.** A RAK MUST identify Channel Snapshot ID.

**REQ-061.** A RAK MUST identify Audience Snapshot ID.

**REQ-062.** A RAK MUST identify IAP Subset Hash.

**REQ-063.** Document State MUST be derived per RAK.

**REQ-064.** A non-overlapping Effective release MUST be permitted.

**REQ-065.** An overlap conflict MUST block the affected release.

**REQ-066.** A material review change MUST enter Revision state.

**REQ-067.** A return to Independent Review MUST create a Review Record.

## 7. Review, Approval, Risk Acceptance

A finding has one defect, severity, criterion, evidence, impact, owner, disposition, and verification. Severity is Critical, Major, Minor, Editorial. Conformance assesses frozen IAP. Risk Acceptance is not Approval or Waiver; it has RAC ID, risk authority, residual risk, monitoring, expiry, and approval effect.

**REQ-068.** A finding MUST identify one defect.

**REQ-069.** A finding MUST identify one severity.

**REQ-070.** A finding MUST contain verification evidence.

**REQ-071.** An unresolved Critical finding MUST block Approval.

**REQ-072.** An unresolved Major finding MUST block Approval without valid Risk Acceptance.

**REQ-073.** A reviewer MUST verify each finding disposition.

**REQ-074.** An Approval Record MUST identify Revision ID.

**REQ-075.** An Approval Record MUST identify IAP ID.

**REQ-076.** A conformance assessment MUST identify assessed requirements.

**REQ-077.** A Risk Acceptance MUST identify risk authority.

**REQ-078.** A Risk Acceptance MUST identify monitoring action.

**REQ-079.** A Risk Acceptance MUST identify expiry timestamp.

**REQ-080.** An expired Risk Acceptance MUST block Approval.

## 8. Release integrity

Canonical repository holds source records; Project Files hold released projections. Exact Copy source/projection hashes use the same declared algorithm and must equal. Controlled Transform records source hash, specification ID/hash, tool name/version, configuration hash, input hash, environment identity, projection hash, independent reproduction verifier/timestamp, and reproduced hash; success requires reproduced hash equals projection hash. Every release has mode manifest.

**REQ-081.** A Release Record MUST identify its mode.

**REQ-082.** A Release Record MUST record source hash.

**REQ-083.** A Release Record MUST record projection hash.

**REQ-084.** An Exact Copy source hash MUST equal projection hash.

**REQ-085.** A Controlled Transform MUST record specification ID.

**REQ-086.** A Controlled Transform MUST record specification hash.

**REQ-087.** A Controlled Transform MUST record tool name.

**REQ-088.** A Controlled Transform MUST record tool version.

**REQ-089.** A Controlled Transform MUST record configuration hash.

**REQ-090.** A Controlled Transform MUST record input hash.

**REQ-091.** A Controlled Transform MUST record environment identity.

**REQ-092.** A Controlled Transform MUST record independent reproduction verifier.

**REQ-093.** A Controlled Transform MUST record independent reproduction timestamp.

**REQ-094.** A Controlled Transform reproduced hash MUST equal projection hash.

**REQ-095.** A Release Record MUST contain complete mode manifest.

## 9. Waivers, nonwaivable controls, and legacy

A Waiver is separate from Risk Acceptance. It has WVR ID, exact Requirement ID, scope, rationale, risk, compensating control, authority, expiry, review date, and renewal rule. A Waiver cannot cover a nonwaivable control. Nonwaivable controls include reviewer independence, Draft Project Files prohibition, Approved-unreleased Project Files prohibition, record integrity, Project Director subject-matter authority, external-obligation priority, and all mutation of legacy artifacts before Migration Plan approval. Legacy mutation includes edit, rename, move, merge, split, identity conversion, and status conversion. Only a Project Director-approved Migration Plan may authorize such mutation; neither Waiver nor RAC may do so.

**REQ-096.** A Waiver MUST have a WVR ID.

**REQ-097.** A Waiver MUST identify one exact Requirement ID.

**REQ-098.** A Waiver MUST identify its scope.

**REQ-099.** A Waiver MUST identify its expiry timestamp.

**REQ-100.** A Waiver MUST identify its renewal rule.

**REQ-101.** A Waiver MUST NOT cover a nonwaivable control.

**REQ-102.** A Draft MUST NOT be placed in Project Files.

**REQ-103.** An Approved-unreleased Revision MUST NOT be placed in Project Files.

**REQ-104.** A legacy artifact MUST NOT be mutated before Migration Plan approval.

**REQ-105.** A Waiver MUST NOT authorize legacy mutation.

**REQ-106.** A Risk Acceptance MUST NOT authorize legacy mutation.

**REQ-107.** A legacy mutation MUST require Project Director-approved Migration Plan.

**REQ-108.** A Migration Plan MUST undergo Independent Review.

## 10. Emergency amendment

An emergency amendment is an immutable urgent Revision. It requires Project Director approval before effect. It names baseline release, restoration Revision/IAP/target, protected controls, post-review deadline, expiry, and 30-day maximum duration. Serial, reissued, or materially equivalent emergency releases cannot extend the condition. At expiry, named restoration or normally approved successor must be Effective; otherwise emergency becomes Withdrawn.

**REQ-109.** An emergency amendment MUST use immutable Revision.

**REQ-110.** An emergency amendment MUST have Project Director approval before effect.

**REQ-111.** An emergency amendment MUST identify baseline Release ID.

**REQ-112.** An emergency amendment MUST identify restoration Revision ID.

**REQ-113.** An emergency amendment MUST identify restoration IAP ID.

**REQ-114.** An emergency amendment MUST identify restoration target.

**REQ-115.** An emergency amendment MUST have maximum duration of 30 days.

**REQ-116.** An emergency amendment MUST have expiry timestamp.

**REQ-117.** A serial emergency release MUST NOT extend equivalent condition.

**REQ-118.** A reissued emergency release MUST NOT extend equivalent condition.

**REQ-119.** An emergency amendment MUST specify protected controls.

**REQ-120.** An emergency amendment MUST specify post-review deadline.

**REQ-121.** A failed restoration MUST create Failed Release Record.

**REQ-122.** An expired emergency release MUST NOT remain Effective.

## 11. Information governance

Before constitutional release, Release Authority checks classification, audience, handling restrictions, personal/confidential information, external sharing, retention, external obligations, and delegation. Unresolved issue blocks release.

**REQ-123.** A constitutional Release Record MUST record classification.

**REQ-124.** A constitutional Release Record MUST record audience.

**REQ-125.** A constitutional Release Record MUST record handling restrictions.

**REQ-126.** A constitutional release MUST assess personal information.

**REQ-127.** A constitutional release MUST assess confidential information.

**REQ-128.** A constitutional release MUST assess external sharing.

**REQ-129.** A constitutional release MUST assess retention.

**REQ-130.** A constitutional release MUST assess external obligations.

**REQ-131.** An information delegation MUST be recorded.

**REQ-132.** An unresolved information issue MUST block release.

## 12. Amendment and bootstrap

An amendment identifies affected requirements and gets Independent Review. An extension cannot weaken this Constitution. Initial validity comes only from external Project Director Decision Record, not ordinary release. Bootstrap records exact Revision/IAP/provenance, registry issuance, roles, review disposition, canonical store, retention, timestamp, target restriction, and failure/refusal. Project Files publication after bootstrap uses normal gates.

**REQ-133.** An amendment MUST identify affected Requirement IDs.

**REQ-134.** An amendment MUST undergo Independent Review.

**REQ-135.** An extension MUST NOT weaken this Constitution.

**REQ-136.** Bootstrap MUST use Project Director Decision Record.

**REQ-137.** Bootstrap MUST identify exact Revision ID.

**REQ-138.** Bootstrap MUST identify exact IAP ID.

**REQ-139.** Bootstrap MUST identify exact Provenance ID.

**REQ-140.** Bootstrap MUST record role appointments.

**REQ-141.** Bootstrap MUST record canonical store.

**REQ-142.** Bootstrap MUST record retention.

**REQ-143.** Bootstrap MUST record effective timestamp.

**REQ-144.** Bootstrap failure MUST be recorded externally.

**REQ-145.** Bootstrap failure MUST NOT create Effective Release.

**REQ-146.** Post-bootstrap Project Files publication MUST use normal gates.

---

# Appendix A — Lint protocol (normative)

Lint checks mapping, unique IDs, sequence, one predicate, and one action. The lint record retains Revision hash, tool/version, ruleset, timestamp, and operator.

**REQ-147.** A lint record MUST identify target Revision hash.

# Appendix B — Identifier Registry schema (normative)

Applicable fields are identifier, class, canonical subject, issuer, issued timestamp, status, predecessor/successor, alias target, reservation purpose/expiry, and legacy reconciliation.

**REQ-148.** A Registry entry MUST contain applicable schema fields.

# Appendix C — Transition matrix (normative)

| Transition | Entry criteria | Required record |
|---|---|---|
| Draft → Independent Review | hashes/lint pass | Review Record |
| Independent Review → Revision | a finding needs change | Finding update |
| Revision → Independent Review | hashes/lint pass | new Review Record |
| Independent Review → Approval Pending | every Critical resolved; every Major resolved or valid RAC; reviewer verified dispositions/RAC; Minor and Editorial have recorded disposition; conformance assessed | completed Review Record |
| Approval Pending → Approved | authorized Approval | Approval Record |
| Approved → Scheduled/Effective | integrity and information gates pass | Release Record |
| Effective → Superseded/Withdrawn/Archived | history retained | disposition Record |

**REQ-149.** An unlisted normal transition MUST be prohibited.

**REQ-150.** A defined emergency transition MUST use Section 10.

**REQ-151.** A defined migration transition MUST use Section 9.

# Appendix D — Review/Risk/Waiver schemas (normative)

Review Record: target Revision/IAP, reviewer, conflict declaration, criteria, findings, recommendation, verification. RAC: residual risk, authority, monitoring, expiry. Waiver: WVR ID, exact REQ, scope, rationale, risk, control, authority, expiry, review, renewal.

# Appendix E — Frozen IAP data (normative)

| Snapshot | Canonical UTF-8 SHA-256 |
|---|---|
| Scope `SNP-SCOPE-0001` v1.0 (`TGT-DOC-GOV`,`TGT-KB-INTERFACE`,`TGT-DOC-REPO`) | `34700232c38c62be67c8577a005caba6bb7e6b24fbc1f220ca30e27e0fa33db4` |
| Channel `SNP-CHANNEL-0001` v1.0 (`CH-DRAFT`,`CH-CANONICAL`,`CH-PROJECT-FILES`,`CH-ARCHIVE`) | `5ab87a4a26ceb4da8a861fc9acac57c30e2db8575482ae58989360946e67f7a9` |
| Audience `SNP-AUDIENCE-0001` v1.0 (`AUD-DOC-TEAM`,`AUD-INDEPENDENT-REVIEW`,`AUD-PROJECT-DIRECTOR`,`AUD-AUTHORIZED-CONSUMER`) | `d1232f220cb215c8f2b187461a2ec61dc67f6e4fbc85be2edc4993a3653e7681` |
| IAP `IAP-DOC-CON-000-0.12.0-DRAFT` v1.0.0-draft | `d234155c8d9acf047657785d67d168bd9d2ea354be3b9c7b5675dcaee9745a79` |

As-of timestamp is `2026-07-18T00:00:00+09:00`; exclusions are `EXC-CODE`, `EXC-RUNTIME-DATA`, `EXC-MODEL-OUTPUT`, `EXC-INVESTMENT-DECISION`, `EXC-UNAPPROVED-LEGACY-MIGRATION`; applicable requirements are REQ-001–REQ-151.

# Appendix F — Release manifest (normative)

Release manifest stores RAK, mode, hashes, target, subset, verifier, timestamp, result, failure evidence, and every Controlled Transform reproduction field.

# Appendix G — Waiver prohibition (normative)

No Waiver covers nonwaivable controls listed in Section 9. A Waiver has no effect on an unlisted legacy action.

# Appendix H — Migration Plan (normative)

Plan records MIG ID, source/target, authority/content/status maps, reference inventory, compatibility, freeze, cutover, rollback, acceptance, review, and Project Director approval.

# Appendix I — Emergency Record (normative)

Record contains immutable Revision, pre-effect Director approval, baseline, restoration Revision/IAP/target, protected controls, duration, no-extension declaration, deadline, and failure-safe withdrawal.

# Appendix J — Bootstrap record (normative)

External Decision Record contains identity issuance, exact identity values, appointments, review result, store, retention, timestamp, first target restriction, and refusal/failure.

# Appendix K — Information governance gate (normative)

Gate verifies classification, audience, handling, personal/confidential information, sharing, retention, external obligations, delegation, and unresolved issues.

## Draft self-check (informative)

Prior drafts are preserved. v0.12.0 adds the explicit Review-to-Approval Pending gate, normal-transition prohibition, a separate Waiver model and complete legacy protection. IAP snapshot hashes were computed using UTF-8 SHA-256 canonical strings and are not pending. This file remains a Draft outside Project Files.
