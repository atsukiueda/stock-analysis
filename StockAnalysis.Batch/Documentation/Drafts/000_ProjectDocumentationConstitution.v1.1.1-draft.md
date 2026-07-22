# 000 Project Documentation Constitution

> **DRAFT — AMENDMENT UNDER INDEPENDENT REVIEW.** This is a proposed revision of the effective Project Documentation Constitution. It has no release effect and must not be placed in Project Files. Its baseline is `DOC-CON-000@0.14.0-draft` / `REL-DOC-CON-000-001`.

| Field | Value |
|---|---|
| Document / proposed revision | DOC-CON-000 / DOC-CON-000@1.1.1-draft |
| Baseline release | REL-DOC-CON-000-001 |
| Provenance | PROV-DOC-CONST-000-0014 (baseline) |
| Artifact type / publication state | AT-CONSTITUTION / Draft |
| IAP | IAP-DOC-CON-000-1.1.1-DRAFT (Appendix E) |
| Approval record | Pending — no approval record exists for this Draft |
| Release record | Not applicable — this Draft is unreleased |
| Amendment scope | AI Organization and Review Board design; REQ-156–REQ-207; Appendices L–M |

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
| M-12 hash reproducibility | REQ-152–REQ-155; Appendix E |

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

## 5A. AI Organization and Review Board

The AI Organization is a controlled collaboration model, not a delegation of legal, fiduciary, or accountable human authority. It comprises the Project Director, Documentation Team, Research Team, Codex, and Review Board. A named role is a role profile; one authorized participant may hold more than one profile only when the incompatibility controls in this section are satisfied. The role/profile matrix in Appendix L is normative.

The Project Director sets project direction, resolves subject-matter conflicts, appoints accountable authorities, and makes final substantive decisions. The Documentation Team designs and maintains the Documentation System. The Research Team produces evidence-based domain knowledge and research artifacts. Codex performs assigned implementation, analysis, and documentation-support work within approved scope. The Review Board performs independent defect discovery and gate recommendations. Review is not an approval-seeking activity; its purpose is to find defects, unsupported claims, unsafe assumptions, omissions, and governance failures.

The Documentation Team consists of Documentation Director, Lead Documentation Architect, Lead Governance Architect, Lead Workflow Architect, Lead Knowledge Architect, Chief Editor, and Chief Reviewer. The Research Team consists of Research Director, Industry Research Lead, Knowledge Base Lead, Evidence Validation Lead, Data Governance Lead, and Investment Research Lead. The Review Board consists of Chief Documentation Reviewer, Chief Architecture Reviewer, Chief Knowledge Reviewer, Chief Software Reviewer, Chief Machine Learning Reviewer, Chief Database Reviewer, Chief Investment Reviewer, Chief Model Governance Reviewer, and Chief Editorial Reviewer. These are mandatory profiles; Appendix L may define additional profiles without changing their core mandates.

The normal collaboration flow is Project Director → Documentation Team and/or Research Team → Codex, where applicable → Review Board → Project Director. This flow has mandatory feedback loops: an authoring team must address review findings; Codex must return work and evidence to its requesting team; a reviewer may return a work product to any responsible authoring role; and the Project Director may return a decision for revision or further review. The flow is not a transfer of decision authority.

Material work requires cross-review by at least two independent Review Board profiles selected for the artifact's subject matter and governance impact. One selected reviewer must cover the artifact's primary subject matter; one must cover documentation, governance, or editorial integrity. A Review Board recommendation may permit, condition, or block progression through a gate, but it does not replace the Project Director's final substantive decision or the authorized Approval/Release decision defined elsewhere in this Constitution.

Work is material by default. A work product may be classified non-material only when an authorized independent governance or Review Board profile records a specific rationale before review. The authoring team may supply context but cannot make that classification. The Review Record must identify the materiality determination, the selected cross-review profiles, their conflict declarations, and evidence that each required reviewer is independent. A participant who authored, materially designed, or materially contributed to the output cannot serve as either required cross-review profile; the required profiles must be separate independent review personas.

An AI Agent, Human Developer, External Reviewer, or future participant joins the Organization only through a versioned role profile that identifies mission, authority, responsibility, deliverables, review scope, decision authority, capability boundaries, conflict controls, and accountable appointment. An external reviewer must also declare independence, engagement scope, confidentiality constraints, and any conflict. Extensions may add controls but may not reduce this Constitution's independence, evidence, approval, or release controls.

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

# Appendix E — Frozen IAP data and canonical hash serialization (normative)

The sole normative IAP field order is `iap-id|profile-version|scope-hash|channel-hash|audience-hash|artifact-type-list|exclusion-list|applicable-requirement-list|as-of`. The applicable-requirement-list uses canonical closed-range notation `REQ-001..REQ-207`, which denotes every zero-padded Requirement ID from REQ-001 through REQ-207 inclusive, in ascending ordinal order, with no omissions or additions. Historical preimages below are retained as immutable evidence of their original revisions; they do not define an alternative normative serialization.

Hash algorithm is SHA-256. Every canonical preimage is a Unicode NFC-normalized sequence encoded as UTF-8 without BOM. Fields are ASCII text only in this Draft. A literal pipe (`|`) separates fields; no whitespace surrounds a pipe; a literal comma (`,`) separates members; no final newline is present. Values are sorted in ascending Unicode code-point order unless an explicit ordinal is shown. `NULL` is the sole null token; an empty string is the sole empty token; a literal backslash is `\\`; a literal pipe is `\\|`; a literal comma is `\\,`; a literal line break is `\\n`. No other escaping is permitted. Snapshot fields, in this exact order, are `snapshot-id|version|member-1|...|member-n|as-of`. The IAP field order is the sole normative order stated in the preceding paragraph.

| Item | Immutable canonical preimage | SHA-256 |
|---|---|---|
| Scope `SNP-SCOPE-0001` v1.0 | `SNP-SCOPE-0001|1.0|TGT-DOC-GOV|TGT-KB-INTERFACE|TGT-DOC-REPO|2026-07-18T00:00:00+09:00` | `34700232c38c62be67c8577a005caba6bb7e6b24fbc1f220ca30e27e0fa33db4` |
| Scope `SNP-SCOPE-0002` v1.1 | `SNP-SCOPE-0002|1.1|TGT-AI-ORGANIZATION|TGT-DOC-GOV|TGT-KB-INTERFACE|TGT-DOC-REPO|2026-07-18T00:00:00+09:00` | `c0aa93cc8bab4a76914660d4729ef32d8a70a84fc09720ddbc716988d2d3da24` |
| Channel `SNP-CHANNEL-0001` v1.0 | `SNP-CHANNEL-0001|1.0|CH-DRAFT|CH-CANONICAL|CH-PROJECT-FILES|CH-ARCHIVE|2026-07-18T00:00:00+09:00` | `5ab87a4a26ceb4da8a861fc9acac57c30e2db8575482ae58989360946e67f7a9` |
| Audience `SNP-AUDIENCE-0001` v1.0 | `SNP-AUDIENCE-0001|1.0|AUD-DOC-TEAM|AUD-INDEPENDENT-REVIEW|AUD-PROJECT-DIRECTOR|AUD-AUTHORIZED-CONSUMER|2026-07-18T00:00:00+09:00` | `d1232f220cb215c8f2b187461a2ec61dc67f6e4fbc85be2edc4993a3653e7681` |
| IAP `IAP-DOC-CON-000-0.13.0-DRAFT` v1.0.0-draft | `IAP-DOC-CON-000-0.13.0-DRAFT|1.0.0-draft|34700232c38c62be67c8577a005caba6bb7e6b24fbc1f220ca30e27e0fa33db4|5ab87a4a26ceb4da8a861fc9acac57c30e2db8575482ae58989360946e67f7a9|d1232f220cb215c8f2b187461a2ec61dc67f6e4fbc85be2edc4993a3653e7681|AT-APPROVAL,AT-BACKLOG,AT-CONSTITUTION,AT-DECISION,AT-EVIDENCE,AT-GUIDE,AT-HANDOFF,AT-POLICY,AT-PROCEDURE,AT-REGISTER,AT-RELEASE,AT-REVIEW,AT-STANDARD,AT-TEMPLATE|EXC-CODE,EXC-INVESTMENT-DECISION,EXC-MODEL-OUTPUT,EXC-RUNTIME-DATA,EXC-UNAPPROVED-LEGACY-MIGRATION|2026-07-18T00:00:00+09:00` | `0c55bf22905beee7cc7f7e0812f43d5c36e9cf14ffb32174dcfda0d9e5d40412` |
| IAP `IAP-DOC-CON-000-0.14.0-DRAFT` v1.0.0-draft | `IAP-DOC-CON-000-0.14.0-DRAFT|1.0.0-draft|34700232c38c62be67c8577a005caba6bb7e6b24fbc1f220ca30e27e0fa33db4|5ab87a4a26ceb4da8a861fc9acac57c30e2db8575482ae58989360946e67f7a9|d1232f220cb215c8f2b187461a2ec61dc67f6e4fbc85be2edc4993a3653e7681|AT-APPROVAL,AT-BACKLOG,AT-CONSTITUTION,AT-DECISION,AT-EVIDENCE,AT-GUIDE,AT-HANDOFF,AT-POLICY,AT-PROCEDURE,AT-REGISTER,AT-RELEASE,AT-REVIEW,AT-STANDARD,AT-TEMPLATE|EXC-CODE,EXC-INVESTMENT-DECISION,EXC-MODEL-OUTPUT,EXC-RUNTIME-DATA,EXC-UNAPPROVED-LEGACY-MIGRATION|REQ-001..REQ-155|2026-07-18T00:00:00+09:00` | `c6929a367f3fa1bd1a2907495b4cab4b25c106a4a84ee5ccabdf37ed1dba8d81` |
| IAP `IAP-DOC-CON-000-1.1.0-DRAFT` v1.1.0-draft | `IAP-DOC-CON-000-1.1.0-DRAFT|1.1.0-draft|c0aa93cc8bab4a76914660d4729ef32d8a70a84fc09720ddbc716988d2d3da24|5ab87a4a26ceb4da8a861fc9acac57c30e2db8575482ae58989360946e67f7a9|d1232f220cb215c8f2b187461a2ec61dc67f6e4fbc85be2edc4993a3653e7681|AT-APPROVAL,AT-BACKLOG,AT-CONSTITUTION,AT-DECISION,AT-EVIDENCE,AT-GUIDE,AT-HANDOFF,AT-POLICY,AT-PROCEDURE,AT-REGISTER,AT-RELEASE,AT-REVIEW,AT-STANDARD,AT-TEMPLATE|EXC-CODE,EXC-INVESTMENT-DECISION,EXC-MODEL-OUTPUT,EXC-RUNTIME-DATA,EXC-UNAPPROVED-LEGACY-MIGRATION|REQ-001..REQ-201|2026-07-18T00:00:00+09:00` | `e2ed7e31e1465c34d5ee942ccba7717ad2692502fe050cdea138951056fa459c` |
| IAP `IAP-DOC-CON-000-1.1.1-DRAFT` v1.1.1-draft | `IAP-DOC-CON-000-1.1.1-DRAFT|1.1.1-draft|c0aa93cc8bab4a76914660d4729ef32d8a70a84fc09720ddbc716988d2d3da24|5ab87a4a26ceb4da8a861fc9acac57c30e2db8575482ae58989360946e67f7a9|d1232f220cb215c8f2b187461a2ec61dc67f6e4fbc85be2edc4993a3653e7681|AT-APPROVAL,AT-BACKLOG,AT-CONSTITUTION,AT-DECISION,AT-EVIDENCE,AT-GUIDE,AT-HANDOFF,AT-POLICY,AT-PROCEDURE,AT-REGISTER,AT-RELEASE,AT-REVIEW,AT-STANDARD,AT-TEMPLATE|EXC-CODE,EXC-INVESTMENT-DECISION,EXC-MODEL-OUTPUT,EXC-RUNTIME-DATA,EXC-UNAPPROVED-LEGACY-MIGRATION|REQ-001..REQ-207|2026-07-18T00:00:00+09:00` | `6d0fe10c5b70fed99b05465b88bdebe2009f82f67275f0c07693c6f415e25700` |

The actual artifact type, exclusion, and applicable-requirement lists are canonically sorted as shown in the IAP preimage. To recompute any item: copy only its preimage between backticks, normalize NFC, encode UTF-8 without BOM, ensure no trailing newline, then calculate SHA-256 lowercase hexadecimal. Recalculation must equal the table value before Review Entry.

**REQ-152.** A Snapshot hash MUST use this canonical serialization.

**REQ-153.** An IAP hash MUST use this canonical serialization.

**REQ-154.** A hash preimage MUST be retained immutably.

**REQ-155.** A hash recomputation mismatch MUST block Review Entry.

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

# Appendix L — AI Organization role/profile matrix (normative)

| Profile | Mission | Authority | Responsibility | Deliverables | Review scope | Decision authority |
|---|---|---|---|---|---|---|
| Project Director | Direct the project | Highest internal subject-matter authority | Set direction; resolve conflicts; appoint authorities | Decisions; appointments; approved direction | Any material work | Final substantive decision |
| Documentation Director | Govern documentation system | Documentation-program authority | Accountable documentation operation and release readiness | Documentation plan; governance reports | Documentation system | Recommends documentation disposition; no subject-matter override |
| Lead Documentation Architect | Design documentation architecture | Documentation architecture authority | Maintain information architecture and interfaces | Architecture designs; dependency maps | Documentation architecture | Recommends architecture changes |
| Lead Governance Architect | Design documentation controls | Governance design authority | Maintain lifecycle, control, and conformance design | Control designs; conformance analysis | Governance controls | Recommends control changes |
| Lead Workflow Architect | Design controlled workflows | Workflow design authority | Maintain handoff, review, and release workflows | Workflow specifications | Workflow artifacts | Recommends workflow changes |
| Lead Knowledge Architect | Design knowledge structures | Knowledge-structure authority | Maintain taxonomy, traceability, and knowledge interfaces | Taxonomies; knowledge models | Knowledge structures | Recommends knowledge-structure changes |
| Chief Editor | Ensure editorial coherence | Editorial coordination authority | Maintain clarity, consistency, and style | Edited artifacts; editorial findings | Readability and consistency | Recommends editorial disposition |
| Chief Reviewer | Coordinate independent review | Review coordination authority | Assign independent reviewers and consolidate findings | Review plans; consolidated review records | Assigned artifacts and process integrity | Recommends gate disposition; cannot approve authored work |
| Research Director | Direct research program | Research-program authority | Set research priorities and evidence quality expectations | Research plans; research decisions | Research program | Recommends research disposition |
| Industry Research Lead | Develop industry knowledge | Industry-research authority | Produce industry analysis and source maps | Industry research artifacts | Industry claims | Recommends industry findings |
| Knowledge Base Lead | Maintain Knowledge Base integrity | Knowledge Base stewardship authority | Curate approved knowledge and provenance links | Knowledge Base updates; lineage records | Knowledge Base artifacts | Recommends KB disposition |
| Evidence Validation Lead | Validate evidence fitness | Evidence-validation authority | Test source reliability, locators, and claim support | Evidence assessments; validation findings | Evidence and provenance | Recommends evidence acceptance |
| Data Governance Lead | Govern research data | Data-governance authority | Define data quality, lineage, retention, and access expectations | Data governance assessments | Data assets and controls | Recommends data disposition |
| Investment Research Lead | Develop investment research | Investment-research authority | Produce investment hypotheses and research reasoning | Investment research artifacts | Investment claims and assumptions | Recommends research disposition; no investment execution authority |
| Codex | Execute authorized work | Assigned task authority only | Produce scoped implementation, analysis, and support evidence | Assigned work products; execution evidence | Self-check only; not independent review of own output | No approval or final substantive decision |
| Chief Documentation Reviewer | Find documentation defects | Independent review authority | Assess structure, lifecycle, traceability, and conformance | Documentation findings; recommendations | Constitutions, policies, standards, procedures | Recommend/block review gates |
| Chief Architecture Reviewer | Find architecture defects | Independent review authority | Assess architectural coherence, boundaries, and impacts | Architecture findings; recommendations | Architecture and interfaces | Recommend/block review gates |
| Chief Knowledge Reviewer | Find knowledge defects | Independent review authority | Assess knowledge validity, taxonomy, and provenance | Knowledge findings; recommendations | Knowledge Base and research knowledge | Recommend/block review gates |
| Chief Software Reviewer | Find software defects | Independent review authority | Assess software design, implementation evidence, and testability | Software findings; recommendations | Code and software architecture | Recommend/block review gates |
| Chief Machine Learning Reviewer | Find ML defects | Independent review authority | Assess data/model assumptions, validation, and reproducibility | ML findings; recommendations | ML artifacts and controls | Recommend/block review gates |
| Chief Database Reviewer | Find database defects | Independent review authority | Assess schema, lineage, integrity, and operations | Database findings; recommendations | Data stores and database design | Recommend/block review gates |
| Chief Investment Reviewer | Find investment-research defects | Independent review authority | Assess evidence, assumptions, risks, and reasoning | Investment findings; recommendations | Investment research artifacts | Recommend/block review gates; no investment execution authority |
| Chief Model Governance Reviewer | Find model-governance defects | Independent review authority | Assess accountability, monitoring, risk, and model controls | Governance findings; recommendations | Model governance and decision controls | Recommend/block review gates |
| Chief Editorial Reviewer | Find editorial defects | Independent review authority | Assess clarity, consistency, terminology, and ambiguity | Editorial findings; recommendations | Any artifact's editorial quality | Recommend/block review gates |

AI Agent, Human Developer, and External Reviewer are extension profile classes. Their appointed profiles must use these same seven columns. Human Developer profiles may author or implement but must not self-approve. External Reviewer profiles may review only within their declared engagement and must remain independent of the output under review.

# Appendix M — Collaboration and cross-review workflow (normative)

```text
Project Director
    ↓ direction / decision request
Documentation Team and/or Research Team
    ↓ scoped assignment with evidence expectations
Codex (when assigned)
    ↓ work product and execution evidence
Review Board cross-review
    ↓ findings, verification, and gate recommendation
Project Director
    ↓ final substantive decision or return for revision
Authoring team ←──── feedback loop ──── Review Board
```

Work is material unless an authorized independent governance or Review Board profile records a non-material rationale. The initiating team may provide context, but cannot classify its own work as non-material. For material work, the Review Record records the materiality determination, primary subject-matter reviewer, second documentation/governance/editorial reviewer, conflict declarations, and independence evidence. An authoring participant may answer findings and revise work, but may not independently approve its own output or serve as a required cross-review profile. A reviewer verifies dispositions and may recommend that a gate be blocked. An authorized approver and Release Authority continue to act under Sections 6 through 8; Review Board participation does not merge those roles. Any participant may escalate an unresolved conflict or a material governance concern to the Project Director.

**REQ-156.** The AI Organization MUST include the Project Director.

**REQ-157.** The AI Organization MUST include the Documentation Team.

**REQ-158.** The AI Organization MUST include the Research Team.

**REQ-159.** The AI Organization MUST include Codex.

**REQ-160.** The AI Organization MUST include the Review Board.

**REQ-161.** The Project Director MUST retain final substantive decision authority.

**REQ-162.** The Documentation Team MUST own Documentation System design and maintenance.

**REQ-163.** The Research Team MUST own evidence-based research artifact production.

**REQ-164.** Codex MUST operate within assigned and approved scope.

**REQ-165.** The Review Board MUST perform independent defect discovery.

**REQ-166.** Review MUST NOT be defined as an activity whose purpose is approval.

**REQ-167.** A Documentation Team profile MUST include Documentation Director.

**REQ-168.** A Documentation Team profile MUST include Lead Documentation Architect.

**REQ-169.** A Documentation Team profile MUST include Lead Governance Architect.

**REQ-170.** A Documentation Team profile MUST include Lead Workflow Architect.

**REQ-171.** A Documentation Team profile MUST include Lead Knowledge Architect.

**REQ-172.** A Documentation Team profile MUST include Chief Editor.

**REQ-173.** A Documentation Team profile MUST include Chief Reviewer.

**REQ-174.** A Research Team profile MUST include Research Director.

**REQ-175.** A Research Team profile MUST include Industry Research Lead.

**REQ-176.** A Research Team profile MUST include Knowledge Base Lead.

**REQ-177.** A Research Team profile MUST include Evidence Validation Lead.

**REQ-178.** A Research Team profile MUST include Data Governance Lead.

**REQ-179.** A Research Team profile MUST include Investment Research Lead.

**REQ-180.** The Review Board MUST include Chief Documentation Reviewer.

**REQ-181.** The Review Board MUST include Chief Architecture Reviewer.

**REQ-182.** The Review Board MUST include Chief Knowledge Reviewer.

**REQ-183.** The Review Board MUST include Chief Software Reviewer.

**REQ-184.** The Review Board MUST include Chief Machine Learning Reviewer.

**REQ-185.** The Review Board MUST include Chief Database Reviewer.

**REQ-186.** The Review Board MUST include Chief Investment Reviewer.

**REQ-187.** The Review Board MUST include Chief Model Governance Reviewer.

**REQ-188.** The Review Board MUST include Chief Editorial Reviewer.

**REQ-189.** A role profile MUST define its mission.

**REQ-190.** A role profile MUST define its authority.

**REQ-191.** A role profile MUST define its responsibility.

**REQ-192.** A role profile MUST define its deliverables.

**REQ-193.** A role profile MUST define its review scope.

**REQ-194.** A role profile MUST define its decision authority.

**REQ-195.** An Author MUST NOT approve the Author's own output.

**REQ-196.** A material work product MUST undergo cross-review by two independent Review Board profiles.

**REQ-197.** A cross-review selection MUST include primary subject-matter coverage.

**REQ-198.** A cross-review selection MUST include documentation, governance, or editorial-integrity coverage.

**REQ-199.** A reviewer MUST declare a conflict before accepting a review.

**REQ-200.** A future participant MUST be appointed through a versioned role profile.

**REQ-201.** An Organization extension MUST NOT weaken constitutional controls.

**REQ-202.** A work product MUST be classified as material by default.

**REQ-203.** A non-material classification MUST be recorded by an authorized independent governance or Review Board profile with rationale.

**REQ-204.** A Review Record for material work MUST identify the selected cross-review profiles.

**REQ-205.** A Review Record for material work MUST contain independence evidence for each required cross-review profile.

**REQ-206.** A participant who authored, materially designed, or materially contributed to an output MUST NOT serve as a required cross-review profile for that output.

**REQ-207.** Required cross-review profiles MUST be separate independent review personas.

## Draft self-check (informative)

Prior drafts are preserved. v1.1.1 resolves the IAP field-order ambiguity and strengthens material-work classification and cross-review independence. IAP snapshot hashes were computed using UTF-8 SHA-256 canonical strings and are not pending. This file remains a Draft outside Project Files.
