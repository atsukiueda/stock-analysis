# Inventory Semantic Mapping Research Sheet

# jppfs_cor:WorkInProcess

## 1. Document Purpose

本書は、EDINET Inventory Semantic Mapping Research Designに基づき、

```text
jppfs_cor:WorkInProcess
```

をCanonical Inventory Semantic RoleへMapping可能か検証するResearch Sheetである。

Mapping Candidate：

```text
Source Concept:
jppfs_cor:WorkInProcess

Canonical Semantic Role Candidate:
WorkInProcess
```

本書の目的はProduction Mapping Masterを作成することではない。

目的は以下である。

> Initial Cross-company Validationで5社に再現したJapanese GAAP Standard Taxonomy Conceptについて、Source Meaning、Cross-company Reproduction、Context Stability、Taxonomy Identity、Information LossおよびComponent Role適格性をEvidenceに基づいて評価する。

Status：

```text
Research Sheet
Semantic Mapping Research
Japanese GAAP Standard Component Reference Case
Research Reviewer Pending
Production Mapping Not Approved
```

---

# 2. Research Target

## Source Concept QName

```text
jppfs_cor:WorkInProcess
```

## Local Name

```text
WorkInProcess
```

## Prefix

```text
jppfs_cor
```

## Accounting Standard Candidate

```text
Japanese GAAP
```

## Canonical Semantic Role Candidate

```text
WorkInProcess
```

## Initial Mapping Confidence Candidate

```text
M1
Direct Standard Mapping
```

Initial ConfidenceはResearch開始時点のCandidateであり、
Reviewer Approvalではない。

---

# 3. Research Questions

本Researchでは以下を確認する。

```text
1.
Does jppfs_cor:WorkInProcess directly represent work in process inventory?

2.
Is the concept reproduced across multiple Japanese GAAP companies?

3.
Is the concept consistently used as an instant inventory component fact?

4.
Is the consolidated context usage stable in the validated sample?

5.
Does the mapping cause material information loss?

6.
Can the concept be used as a canonical WorkInProcess component?

7.
What double-count risk exists?

8.
Does taxonomy version evidence introduce a conflict?

9.
Can repeated standard concept evidence support an efficient review path?

10.
What reviewer decision is justified?
```

---

# 4. Evidence Scope

Initial Cross-company Validationでは以下5社で対象Conceptを確認した。

```text
ROHM

Fuji Electric

Sanken Electric

Torex Semiconductor

Tokyo Electron
```

Accounting Standard：

```text
Japanese GAAP
```

Observed Company Count：

```text
5
```

Observed Filing Count：

```text
5
```

Observed Concept：

```text
jppfs_cor:WorkInProcess
```

Cross-company Evidence Candidate：

```text
Strong Reproduction
```

---

# 5. Evidence Case A

# ROHM

## Company

```text
ローム株式会社
ROHM Co., Ltd.
```

## Source Concept

```text
jppfs_cor:WorkInProcess
```

Observed Financial Meaning：

```text
仕掛品
```

Observed Context Candidate：

```text
Prior1YearInstant
CurrentYearInstant
```

Observed Scope：

```text
Consolidated
```

Observed Unit：

```text
JPY
```

Inventory Structure：

```text
Type B
Component Facts Only
```

Classification Candidate：

```text
Eligible Inventory Component Fact
```

---

# 6. Evidence Case B

# Fuji Electric

## Company

```text
富士電機株式会社
Fuji Electric Co., Ltd.
```

## Source Concept

```text
jppfs_cor:WorkInProcess
```

Prior：

```text
55,156,000,000 JPY
```

Current：

```text
59,797,000,000 JPY
```

Observed Context：

```text
Prior1YearInstant
CurrentYearInstant
```

Observed Scope：

```text
Consolidated
```

Raw XBRL Decimals：

```text
-6
```

The same QName also existed under：

```text
CurrentYearInstant_NonConsolidatedMember
```

with a different value.

Research Finding：

```text
QName Match Only
cannot determine
Consolidated Inventory Fact.
```

However、the consolidated fact itself consistently represented Work in Process inventory.

---

# 7. Evidence Case C

# Sanken Electric

## Company

```text
サンケン電気株式会社
Sanken Electric Co., Ltd.
```

## Source Concept

```text
jppfs_cor:WorkInProcess
```

Prior：

```text
24,810,000,000 JPY
```

Current：

```text
26,462,000,000 JPY
```

Observed Context：

```text
Prior1YearInstant
CurrentYearInstant
```

Observed Scope：

```text
Consolidated
```

Raw XBRL Decimals：

```text
-6
```

Inventory Structure：

```text
Type B
```

The same concept also existed in NonConsolidated Member context.

Therefore：

```text
Concept Identity:
Stable

Extraction Eligibility:
Context-dependent
```

---

# 8. Evidence Case D

# Torex Semiconductor

## Company

```text
トレックス・セミコンダクター株式会社
Torex Semiconductor Co., Ltd.
```

## Source Concept

```text
jppfs_cor:WorkInProcess
```

Prior：

```text
1,742,980,000 JPY
```

Current：

```text
2,106,945,000 JPY
```

Observed Context：

```text
Prior1YearInstant
CurrentYearInstant
```

Observed Scope：

```text
Consolidated
```

Raw XBRL Decimals：

```text
-3
```

Important：

Torexでは、

```text
Decimals:
-3
```

であった。

Other validated companies included：

```text
Decimals:
-6
```

Therefore：

```text
Decimals variation
does not change
the semantic component role.
```

DecimalsはPrecision Metadataとして保持する。

---

# 9. Evidence Case E

# Tokyo Electron

## Company

```text
東京エレクトロン株式会社
Tokyo Electron Limited
```

## Source Concept

```text
jppfs_cor:WorkInProcess
```

Prior：

```text
190,021,000,000 JPY
```

Current：

```text
210,570,000,000 JPY
```

Observed Context：

```text
Prior1YearInstant
CurrentYearInstant
```

Observed Scope：

```text
Consolidated
```

Raw XBRL Decimals：

```text
-6
```

Financial Statement / KAM Context：

```text
仕掛品
```

Inventory Componentとして明示されている。

Classification Candidate：

```text
Eligible Inventory Component Fact
```

---

# 10. Cross-company Reproduction

Observed Companies：

```text
ROHM
Fuji Electric
Sanken Electric
Torex Semiconductor
Tokyo Electron
```

Observed QName：

```text
jppfs_cor:WorkInProcess
```

Observed Source Meaning：

```text
仕掛品
Work in Process
```

Observed Financial Role：

```text
Inventory Component
```

Observed Period Type：

```text
Instant
```

Observed Consolidated Context Candidate：

```text
Prior1YearInstant
CurrentYearInstant
```

Observed Unit：

```text
JPY
```

Cross-company Result：

```text
REPRODUCED
```

Company Count：

```text
5
```

Evidence Strength Candidate：

```text
Strong Cross-company Support
```

---

# 11. Source Label Evaluation

Source Concept：

```text
WorkInProcess
```

Observed Japanese Financial Meaning：

```text
仕掛品
```

Canonical Semantic Role Candidate：

```text
WorkInProcess
```

Meaning Compatibility：

```text
DIRECT
```

No semantic compression is required.

No combined component meaning is observed.

Comparison：

```text
MerchandiseAndFinishedGoods
```

requires information loss review.

However：

```text
WorkInProcess
→
WorkInProcess
```

does not require the same simplification.

---

# 12. Financial Statement Context Evaluation

All validated consolidated cases used the concept as anInventory Component Fact.

Observed Role：

```text
Balance Sheet Inventory Component
```

Period Type：

```text
Instant
```

The concept is distinct from：

```text
DecreaseIncreaseInInventoriesOpeCF
```

which is a Duration Cash Flow Fact.

Therefore：

```text
WorkInProcess
≠
Inventory Cash Flow Change
```

Eligibility Separation：

```text
PASS
```

---

# 13. Consolidation Context Evaluation

Validated filings demonstrate that the same QName can appear under：

```text
CurrentYearInstant
```

and：

```text
CurrentYearInstant_NonConsolidatedMember
```

Example Cases：

```text
Fuji Electric

Sanken Electric

Torex Semiconductor
```

Therefore：

```text
jppfs_cor:WorkInProcess
```

alone does not determine Consolidation Scope.

Research Finding：

```text
Semantic Mapping
and
Fact Eligibility
are separate decisions.
```

Mapping：

```text
WorkInProcess
→
WorkInProcess
```

may be stable.

However、Canonical Observation creation still requires：

```text
Context Validation

Consolidation Scope Validation
```

Therefore：

```text
Mapping Confidence:
High

Automatic Extraction by QName:
Rejected
```

---

# 14. Unit Evaluation

Observed Unit：

```text
JPY
```

across validated consolidated cases.

Canonical Role：

```text
WorkInProcess
```

is a Monetary Inventory Component Observation.

Unit Compatibility：

```text
PASS
```

However：

```text
Semantic Mapping
does not eliminate
Unit Validation Requirement.
```

If future facts are observed in another monetary unit：

```text
USD

EUR

other currency
```

the Semantic Role may remain WorkInProcess,
while Canonical Observation normalization requires Unit Handling.

Production Unit Conversion is outside this Research Scope.

---

# 15. Decimals Evaluation

Observed Examples：

```text
Torex:
-3

Fuji Electric:
-6

Sanken Electric:
-6

Tokyo Electron:
-6
```

Research Finding：

```text
Decimals variation
does not materially change
the observed WorkInProcess meaning.
```

Decimals Classification：

```text
Source Precision Metadata
```

Mapping Decision：

```text
Preserve Decimals

Do not use Decimals
to define semantic role
```

---

# 16. Information Loss Evaluation

Source Meaning：

```text
Work in Process
仕掛品
```

Canonical Meaning：

```text
WorkInProcess
```

Potential Information Loss：

```text
None Identified
```

Classification：

```text
Information Loss:
None
```

This differs from combined concepts such as：

```text
SemiFinishedProductsAndWorkInProgress
```

where canonicalization to WorkInProcess may remove a distinction.

For `jppfs_cor:WorkInProcess` itself：

```text
Direct Meaning Preservation
```

is observed.

---

# 17. Double-count Risk Evaluation

Potential Double-count scenarios：

```text
InventoryTotal
+
WorkInProcess
```

used together in Total Calculation.

or：

```text
WorkInProcess
+
Combined WorkInProcess Component
```

mapped simultaneously from overlapping source facts.

Initial 5-company Japanese GAAP cases：

```text
Type B
Component Facts Only
```

did not contain a validated Total Source Fact in the selected Inventory Fact set.

Therefore：

```text
WorkInProcess
```

was one Component used in Derived Total calculation.

However、future Type C cases may contain both：

```text
InventoryTotal

WorkInProcess
```

Therefore：

```text
Semantic Role Mapping:
PASS

Downstream Role Usage Separation:
MANDATORY
```

Double-count Risk Candidate：

```text
Medium
```

Risk Source：

```text
Calculation misuse
not
semantic ambiguity.
```

---

# 18. Contradicting Evidence Search

Within the validated sample：

```text
Same QName used for non-inventory meaning:
NOT OBSERVED

Same QName used as Duration Fact:
NOT OBSERVED

Same QName used for Inventory Total:
NOT OBSERVED

Same QName meaning conflict across companies:
NOT OBSERVED
```

Observed Scope Variation：

```text
Consolidated

NonConsolidated
```

This is not a Semantic Meaning Conflict.

It is a Fact Eligibility / Scope Classification issue.

Contradicting Semantic Evidence：

```text
NONE IDENTIFIED
within current validated sample.
```

---

# 19. Taxonomy Identity Evaluation

Observed QName：

```text
jppfs_cor:WorkInProcess
```

Observed Namespace Family：

```text
jppfs
```

Initial Validation includes 2025-11-01 namespace evidence in multiple companies.

Renesas NonConsolidated evidence also demonstrated：

```text
jppfs/2024-11-01
```

for `jppfs_cor:WorkInProcess`.

However、Renesas consolidated reporting was IFRS and is not part of the Japanese GAAP five-company consolidated WorkInProcess evidence set.

Current Finding：

```text
WorkInProcess local name
is observed across jppfs taxonomy versions.
```

But：

```text
Formal cross-version mapping approval
is not yet completed.
```

Classification：

```text
Taxonomy Version:
RECORDED

Cross-version Meaning:
No conflict observed

Formal universal equivalence:
NOT DECLARED
```

---

# 20. Canonical Role Candidate Evaluation

Candidate：

```text
WorkInProcess
```

Alternative Candidate：

```text
WIP
```

Reject：

```text
WIP
```

as the canonical formal role name.

Reason：

```text
Abbreviation

Lower semantic explicitness
```

Preferred Candidate：

```text
WorkInProcess
```

Meaning：

```text
Inventory component representing goods
in the production process.
```

Canonical Role Suitability：

```text
PASS
```

---

# 21. Mapping Confidence Evaluation

M1 Requirement：

```text
Standard Taxonomy Concept

Source Label directly matches Canonical Role

Financial Statement Context consistent
```

Evaluation：

```text
Standard Taxonomy Concept:
PASS

Direct Meaning:
PASS

Inventory Component Role:
PASS

Cross-company Reproduction:
PASS
5 Companies

Context Eligibility:
VALIDATED WITH SCOPE CONDITION

Information Loss:
NONE

Contradicting Semantic Evidence:
NONE IDENTIFIED
```

Mapping Confidence Candidate：

```text
M1
Direct Standard Mapping
```

---

# 22. Researcher Proposal

## Proposed Mapping

```text
Source Concept:
jppfs_cor:WorkInProcess

Canonical Semantic Role:
WorkInProcess
```

Proposed Mapping Class：

```text
M1
Direct Standard Mapping
```

Proposed Accounting Scope：

```text
Japanese GAAP Inventory Component Fact
```

Proposed Usage：

```text
Canonical Inventory Component Observation
```

Eligible Usage requires：

```text
Numeric Fact

Instant Period Type

Validated Consolidation Scope

Validated Monetary Unit
```

---

# 23. Researcher Evidence Summary

Supporting Evidence：

```text
Japanese GAAP standard taxonomy concept

Direct Work in Process meaning

Five-company cross-company reproduction

Consistent inventory component role

Instant balance context

Raw XBRL cross-check

No semantic contradiction observed

No material information loss
```

Known Limitations：

```text
Formal taxonomy definition comparison
has not been independently completed.

Cross-version universal approval
has not been completed.

Validated companies are semiconductor-related.
```

Researcher Decision Candidate：

```text
APPROVE MAPPING
```

---

# 24. Independent Research Reviewer Review

## Review Question 1

Was the Mapping accepted only because the Local Name is obvious?

Decision：

```text
NO
```

Evidence：

```text
Five-company reproduction

Source financial meaning

Inventory component position

Instant balance context
```

---

## Review Question 2

Was Consolidated Scope incorrectly inferred from QName?

Decision：

```text
NO
```

The Research explicitly recognizes：

```text
CurrentYearInstant_NonConsolidatedMember
```

cases.

Reviewer Finding：

```text
Semantic Mapping is stable.

Fact Eligibility remains context-dependent.
```

This distinction is acceptable.

---

## Review Question 3

Is there Material Information Loss?

Decision：

```text
NO
```

Source Meaning：

```text
Work in Process
```

Canonical Meaning：

```text
WorkInProcess
```

Direct semantic correspondence.

---

## Review Question 4

Could repeated five-company evidence create overconfidence?

Decision：

```text
YES
Potential Risk
```

Five-company reproduction strengthens the current Mapping Candidate.

However：

```text
Five Companies
≠
Universal Japanese GAAP Proof
```

Reviewer Condition：

New conflicting taxonomy usage must trigger Mapping Conflict Review.

---

## Review Question 5

Can future identical standard concepts be approved without full Research Sheets?

Current Reviewer Judgment：

```text
NOT YET
```

Reason：

This is only the second completed Semantic Mapping Research Sheet.

The first Standard Component Reference Case should be completed in full.

After multiple M1 cases demonstrate the same review pattern,
a shortened Standard Mapping Review Procedure may be proposed.

Therefore：

```text
Review Efficiency Candidate:
BACKLOG
```

No procedural shortcut is approved yet.

---

# 25. Research Reviewer Decision

```text
APPROVE
```

Approved Mapping Candidate：

```text
jppfs_cor:WorkInProcess
→
WorkInProcess
```

Mapping Confidence：

```text
M1
Direct Standard Mapping
```

Scope：

```text
Validated Japanese GAAP
eligible inventory component facts.
```

Usage Candidate：

```text
Canonical WorkInProcess Observation
```

---

# 26. Reviewer Conditions

Approval is subject to the following conditions.

```text
1.
Original QName and Namespace URI must be preserved.

2.
Original ContextRef must be preserved.

3.
Instant balance semantics must be validated.

4.
Consolidated and NonConsolidated facts must remain separate.

5.
Monetary Unit must be validated.

6.
Decimals must be preserved.

7.
WorkInProcess must not be treated as InventoryTotal.

8.
Total and component role usage must be separated.

9.
Overlapping combined component concepts must trigger double-count review.

10.
New taxonomy versions require version review.

11.
Mapping approval does not authorize Production implementation.
```

---

# 27. Mapping Approval Gate Result

```text
Source Concept Identity:
CONFIRMED

Eligibility:
PASS WITH CONTEXT VALIDATION

Financial Meaning Evidence:
SUFFICIENT

Canonical Role Candidate:
DEFINED

Information Loss:
NONE IDENTIFIED

Double-count Risk:
EVALUATED

Contradicting Evidence:
REVIEWED

Taxonomy Version:
RECORDED

Reviewer Decision:
APPROVE
```

Gate Result：

```text
PASS
```

---

# 28. Architecture Reviewer Requirement

Canonical Role Addition：

```text
NO
```

Canonical Role Split：

```text
NO
```

Mapping Model Change：

```text
NO
```

Lineage Requirement Change：

```text
NO
```

Therefore：

```text
Architecture Reviewer Additional Gate:
NOT REQUIRED
```

Existing Semantic Mapping Research Design内でApproval可能。

---

# 29. Final Mapping Research Result

```text
SOURCE CONCEPT:
jppfs_cor:WorkInProcess

CANONICAL SEMANTIC ROLE:
WorkInProcess

MAPPING CLASS:
M1
DIRECT STANDARD MAPPING

RESEARCH REVIEWER:
APPROVE

MAPPING GATE:
PASS

PRODUCTION MAPPING:
NOT YET APPROVED
```

---

# 30. Standard Mapping Procedure Evaluation

This Sheet is the first Japanese GAAP Standard Component Reference Case.

Procedure Evaluation：

```text
Source Identity Review:
WORKED

Eligibility Review:
WORKED

Cross-company Reproduction Review:
WORKED

Context Scope Review:
WORKED

Information Loss Review:
WORKED

Double-count Review:
WORKED

Reviewer Independence Review:
WORKED
```

Result：

```text
PASS
```

However：

```text
Shortened Standard Mapping Review Procedure
=
NOT YET APPROVED
```

Reason：

```text
Completed Mapping Research Sheets:
2

Completed Standard Component Reference Cases:
1
```

Additional direct standard mappings should be reviewed before procedure compression.

---

# 31. Current Mapping Research State

```text
Approved Research Mapping Candidates:

1.
jpigp_cor:InventoriesCAIFRS
→
InventoryTotal
M1
APPROVED

2.
jppfs_cor:WorkInProcess
→
WorkInProcess
M1
APPROVED
```

Important：

```text
Approved Research Mapping
≠
Production Mapping Master Entry
```

Catalog / DDL / Entityへの登録はまだ行わない。

---

# 32. Exact Next Task

次のMapping Research Targetは以下とする。

```text
jpigp_cor:WorkInProcessCAIFRS
```

Canonical Role Candidate：

```text
WorkInProcess
```

Observed Company：

```text
Renesas Electronics
```

Research Purpose：

> IFRS Standard Taxonomy Work In Process Conceptを、Japanese GAAP WorkInProcess Reference Mappingと比較し、Accounting Standardを跨いだCanonical Semantic Role統合が妥当か検証する。

Research Focus：

```text
IFRS standard concept meaning

J-GAAP semantic comparison

Canonical role equivalence

Accounting standard information loss

Context eligibility

Taxonomy version evidence

Cross-standard double-count risk
```

Expected Mapping Confidence Candidate：

```text
M1
Direct Standard Mapping
```

However：

```text
J-GAAP WorkInProcess
and
IFRS WorkInProcessCAIFRS
```

を同一Canonical Roleへ統合することは、
Accounting Standard Boundaryを跨ぐ。

Expected Resultを前提にApproveしない。

Independent Reviewer Gateを通す。
