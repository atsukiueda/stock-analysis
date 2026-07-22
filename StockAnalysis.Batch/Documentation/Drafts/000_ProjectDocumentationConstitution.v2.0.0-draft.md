# 000 Project Constitution

> **DRAFT — PRINCIPLE-LEVEL REFACTOR.** This proposed Project Constitution supersedes nothing until independently reviewed, approved by the Project Director, and released. It is not a Project Files publication.

| Field | Value |
|---|---|
| Document / proposed revision | DOC-CON-000 / DOC-CON-000@2.0.0-draft |
| Baseline | DOC-CON-000@1.1.1-draft |
| Status | Draft |
| Owner | Project Director |
| Scope | Project governance, organization, and governing-document hierarchy |
| Detail delegated to | Standards, procedures, templates, and records |

## 1. Purpose and boundary

This Constitution defines enduring project principles, authority, organization, and the hierarchy of governing documents for the Japanese Equity AI System. It does not prescribe implementation details, numerical thresholds, tool configuration, lint rules, hash serialization, state schemas, record schemas, migration mechanics, or review procedure. Those controls belong in approved Standards, Procedures, Templates, and Records.

**P-001.** The project MUST operate under one approved Project Constitution.

**P-002.** The Project Constitution MUST define enduring principles and authority boundaries.

**P-003.** Detailed operational controls MUST be delegated to lower-level governing artifacts.

**P-004.** A lower-level artifact MUST NOT weaken this Constitution.

**P-005.** A Project Director decision MUST resolve an unresolved constitutional conflict.

## 2. Project principles

**P-006.** Knowledge Base First MUST govern project sequencing.

**P-007.** Evidence MUST precede opinion in governed project artifacts.

**P-008.** Architecture MUST precede implementation.

**P-009.** Review MUST precede approval for material work.

**P-010.** Approval MUST precede release of a governed artifact.

**P-011.** Traceability MUST be designed into material work.

**P-012.** Explainability MUST be preserved across project decisions.

**P-013.** Long-term maintainability MUST take priority over short-term convenience.

**P-014.** Facts, inferences, hypotheses, opinions, proposals, and decisions MUST be distinguishable.

**P-015.** A decision MUST preserve its rationale and material consequences.

**P-016.** A governed change MUST preserve relevant history.

## 3. Governance hierarchy and document hierarchy

The governance hierarchy is: Project Constitution → Documentation Governance → Research Governance → Knowledge Base Governance → Development Governance → Model Governance. Domain governance may add controls within its domain but cannot override a higher-level artifact. The current Knowledge Base rules remain authoritative within their existing domain until a Project Director-approved migration changes them.

Governing document classes are, in descending normative force: Constitution, Policy, Standard, Procedure, Guide, Template, and Record. A Policy states mandatory direction; a Standard states mandatory reusable controls; a Procedure states an approved method; a Guide provides nonbinding guidance; a Template supplies reusable structure; a Record preserves evidence of an event or decision. A Record does not create a normative rule.

**P-017.** Governance domains MUST conform to the governance hierarchy.

**P-018.** Documentation Governance MUST govern documentation lifecycle and publication controls.

**P-019.** Research Governance MUST govern research quality and evidence practice.

**P-020.** Knowledge Base Governance MUST govern curated knowledge and provenance.

**P-021.** Development Governance MUST govern software delivery controls.

**P-022.** Model Governance MUST govern model and decision-system controls.

**P-023.** Every governed artifact MUST declare its document class.

**P-024.** A Record MUST NOT create a normative rule.

**P-025.** Detailed lint, hash, lifecycle-state, record-schema, migration, and review-procedure controls MUST be defined by Standards or Procedures.

## 4. Knowledge Base First and dependency direction

The project’s principal knowledge-to-operation path is Research → Independent Review → Catalog → DDL → Entity → Database → ML → Decision Engine → Advisor. Each downstream stage consumes, validates, or operationalizes controlled upstream knowledge; it must not silently replace that knowledge. Iteration is permitted only through recorded feedback to the affected upstream stage.

**P-026.** Material downstream design MUST identify its relevant upstream knowledge source.

**P-027.** Research MUST undergo independent review before curated Catalog use.

**P-028.** A Catalog entry MUST retain provenance to reviewed research.

**P-029.** DDL MUST trace relevant concepts to Catalog definitions.

**P-030.** An Entity model MUST trace relevant structures to DDL.

**P-031.** A Database implementation MUST trace relevant structures to DDL and Entity definitions.

**P-032.** ML work MUST identify its data and knowledge lineage.

**P-033.** A Decision Engine MUST identify its model, rule, and knowledge inputs.

**P-034.** An Advisor output MUST identify its decision basis and applicable limitations.

**P-035.** Feedback from a downstream stage MUST be recorded before it changes upstream governed knowledge.

## 5. Role Organization

The Role Organization comprises the Project Director, Documentation Team, Research Team, Codex, and Review Board. A role defines a responsibility profile; an agent is a person, AI system, service, or external party appointed to perform one or more roles. Appointment does not transfer accountability unless an approved authority matrix expressly does so.

The Documentation Team includes Documentation Director, Lead Documentation Architect, Lead Governance Architect, Lead Workflow Architect, Lead Knowledge Architect, Chief Editor, and Chief Reviewer. The Research Team includes Research Director, Industry Research Lead, Knowledge Base Lead, Evidence Validation Lead, Data Governance Lead, and Investment Research Lead. The Review Board includes Chief Documentation Reviewer, Chief Architecture Reviewer, Chief Knowledge Reviewer, Chief Software Reviewer, Chief Machine Learning Reviewer, Chief Database Reviewer, Chief Investment Reviewer, Chief Model Governance Reviewer, and Chief Editorial Reviewer.

**P-036.** A role MUST be defined independently of the agent appointed to perform it.

**P-037.** An agent appointment MUST identify scope and accountable authority.

**P-038.** The Project Director MUST retain enterprise accountability for direction, portfolio priorities, risk acceptance, and final substantive decisions.

**P-039.** The Documentation Team MUST govern project documentation architecture and quality.

**P-040.** The Research Team MUST produce and curate evidence-based research knowledge.

**P-041.** Codex MUST act within assigned scope and MUST NOT self-approve its output.

**P-042.** The Review Board MUST perform independent defect discovery.

**P-043.** Each mandatory role named in this section MUST have a maintained role profile.

**P-044.** A role profile MUST state mission, authority, responsibility, deliverables, review scope, and decision authority.

## 6. Decision Authority Matrix

| Role class | Decide | Approve | Recommend | Review | Implement | Reject / block |
|---|---|---|---|---|---|---|
| Project Director | Project direction; material subject-matter conflict | Constitutional and substantive decisions | May request any recommendation | May commission review | May delegate execution | May reject or return any proposal |
| Accountable domain lead | Delegated domain decisions | Delegated domain artifacts | Domain options and impacts | Domain self-check | Direct domain work | May block unsafe domain progression within delegation |
| Documentation / Research team role | None unless delegated | None unless delegated | Designs, evidence, and dispositions | Self-check; assigned peer work | Assigned artifacts | May raise a documented objection |
| Codex | None | None | Analysis and implementation options | Self-check only | Assigned work | May refuse out-of-scope or unsafe work |
| Review Board profile | None | None | Finding disposition and gate recommendation | Independent cross-review | None | May recommend or evidence a gate block |
| Authorized Approval / Release role | None | Artifact approval or release within delegation | Release readiness | Required control verification | Controlled publication | Must block unmet delegated gates |

**P-045.** Decision authority MUST be explicit before a material decision is finalized.

**P-046.** A recommendation MUST NOT be represented as an approval or decision.

**P-047.** An approval authority MUST act only within recorded delegation.

**P-048.** A reviewer MUST NOT exercise approval authority for the same output solely by virtue of review.

## 7. Independent review and collaboration

The collaboration path is Project Director → Documentation Team and/or Research Team → Codex where assigned → Review Board → Project Director, with documented feedback loops to the responsible authoring role. Review exists to discover defects, unsupported claims, omissions, unsafe assumptions, and governance failures; it does not exist to secure approval. Material work is cross-reviewed by independent personas with primary subject-matter coverage and documentation, governance, or editorial coverage.

**P-049.** An author MUST NOT approve the author’s own output.

**P-050.** A reviewer with a material conflict MUST not serve as a required independent reviewer.

**P-051.** A participant who authored, materially designed, or materially contributed to an output MUST NOT serve as its required cross-reviewer.

**P-052.** Material work MUST receive cross-review by separate independent personas.

**P-053.** Material cross-review MUST include primary subject-matter coverage.

**P-054.** Material cross-review MUST include documentation, governance, or editorial coverage.

**P-055.** Review findings and their dispositions MUST be recorded under the applicable review Standard or Procedure.

## 8. Scalability and stewardship

The Role Organization is extensible. AI Agents, Human Developers, External Reviewers, services, and future teams may be appointed through versioned role profiles. Extensions require conflict declarations and compatibility with this Constitution. External reviewers must declare independence, engagement scope, and confidentiality constraints.

**P-056.** A new participant class MUST use a versioned role profile.

**P-057.** An extension MUST preserve responsibility separation and independent review.

**P-058.** An external reviewer MUST declare independence and engagement scope.

## 9. Adoption and delegated controls

This Draft becomes effective only through the approved constitutional review, Project Director approval, and controlled release defined by Documentation Governance. The following controls are expressly delegated: identifier registry, applicability profile, linting, canonical hashing, review records, finding severity, approval records, release integrity, waiver handling, emergency change, retention, migration, and detailed review workflow. Their future Standards and Procedures must remain traceable to the principles in this Constitution.

## Draft self-check (informative)

Principle IDs: P-001 through P-058, intended unique and continuous. This Draft retains no detailed lint/hash/state/record schema. It is a Draft outside Project Files.
