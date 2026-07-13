# Inventory Semantic Mapping Cross-standard Equivalence Pre-review

## 1. Document Purpose

本書は、Japanese GAAP及びIFRSのInventory Component Conceptを同一Canonical Semantic RoleへMappingする前に実施するCross-standard Semantic Equivalence Pre-reviewの標準を定義するResearch Artifactである。

Initial Review Target：

```text
Japanese GAAP Source Concept:
jppfs_cor:WorkInProcess

IFRS Source Concept:
jpigp_cor:WorkInProcessCAIFRS

Canonical Semantic Role Candidate:
WorkInProcess
```

本書の目的はMappingをApproveすることではない。

目的は以下である。

> 異なるAccounting Standard及びTaxonomy Familyに属するSource Conceptを、同一Canonical Semantic Roleへ統合するために必要なEvidenceを確認し、Semantic Equivalence Research Sheetへ進めるかをReviewer判定する。

Status：

```text
Research Pre-review Artifact
Cross-standard Semantic Equivalence Gate
Pre-Catalog
Pre-DDL
Mapping Not Approved
```

---

# 2. Background

Existing Approved Research Mapping Candidate：

```text
jppfs_cor:WorkInProcess
→
WorkInProcess

Mapping Class:
M1

Research Reviewer:
APPROVE
```

Next Mapping Candidate：

```text
jpigp_cor:WorkInProcessCAIFRS
→
WorkInProcess
```

Observed Filing Evidenceでは、両ConceptはInventory Componentとして使用されている。

However：

```text
Same observed role
≠
Cross-standard semantic equivalence proven
```

したがって、IFRS Conceptを既存Japanese GAAP Canonical Roleへ統合する前にCross-standard Equivalence Gateを設ける。

---

# 3. Core Review Question

Primary Question：

```text
Can jppfs_cor:WorkInProcess
and
jpigp_cor:WorkInProcessCAIFRS

be normalized into the same
Canonical Semantic Role:
WorkInProcess?
```

Sub Questions：

```text
Do the concepts represent economically equivalent inventory stages?

Does one concept include materially broader or narrower balances?

Does IFRS current-asset classification change the semantic boundary?

Does the taxonomy definition indicate different accounting scope?

Does presentation position support equivalent meaning?

Does cross-standard normalization remove material information?

Can both concepts be used in the same downstream metric without distortion?
```

---

# 4. Evidence Hierarchy

Cross-standard Mapping Reviewでは以下のPriorityを使用する。

## Priority 1

```text
Official EDINET Taxonomy Element Information
```

Review Candidate：

```text
Namespace

Local Name

Japanese Label

English Label if available

Data Type

Period Type

Balance Attribute if available

Abstract Status

Definition / Documentation if available
```

---

## Priority 2

```text
Official EDINET Account Title / IFRS Taxonomy Element Lists
```

Purpose：

```text
Concept classification

Financial statement presentation role

Standard taxonomy identity

Adjacent concept comparison
```

---

## Priority 3

```text
Official EDINET Concept Selection Guidance
```

Purpose：

```text
Determine whether concepts are selected
for equivalent reporting circumstances.
```

---

## Priority 4

```text
Actual Filing Evidence
```

Validated Companies：

Japanese GAAP：

```text
ROHM
Fuji Electric
Sanken Electric
Torex Semiconductor
Tokyo Electron
```

IFRS：

```text
Renesas Electronics
```

Review：

```text
Inventory Note Position

Source Label

ContextRef

Period Type

Unit

Component Structure

Reported Total Reconciliation
```

---

## Priority 5

```text
Concept Name Similarity
```

Classification：

```text
Inference Evidence Only
```

Concept name similarity alone cannot approve cross-standard mapping.

---

# 5. Source Concept A

## Japanese GAAP

QName：

```text
jppfs_cor:WorkInProcess
```

Canonical Mapping Research Result：

```text
WorkInProcess
M1
APPROVED RESEARCH MAPPING
```

Observed Japanese Meaning：

```text
仕掛品
```

Observed Role：

```text
Inventory Component
```

Observed Period Type：

```text
Instant
```

Observed Consolidated Cases：

```text
ROHM
Fuji Electric
Sanken Electric
Torex Semiconductor
Tokyo Electron
```

Cross-company Reproduction：

```text
5 Companies
```

---

# 6. Source Concept B

## IFRS

QName：

```text
jpigp_cor:WorkInProcessCAIFRS
```

Observed Company：

```text
Renesas Electronics
```

Observed Label：

```text
仕掛品、流動資産（IFRS）
```

Observed Role：

```text
Inventory Component
```

Observed Context：

```text
Prior1YearInstant
CurrentYearInstant
```

Observed Unit：

```text
JPY
```

Observed Decimals：

```text
-6
```

Observed Values：

```text
Prior:
106,737,000,000 JPY

Current:
121,437,000,000 JPY
```

Component Sum：

```text
MerchandiseAndFinishedGoods
+
WorkInProcess
+
RawMaterialsAndSupplies
=
InventoriesCAIFRS
```

Prior：

```text
47,619
+
106,737
+
22,188
=
176,544 million JPY
```

Current：

```text
44,538
+
121,437
+
19,928
=
185,903 million JPY
```

Result：

```text
EXACT MATCH
```

This supports Inventory Component eligibility.

It does not alone prove cross-standard semantic equivalence.

---

# 7. Preliminary Similarity

Observed Similarities：

```text
Japanese Label:
仕掛品

IFRS Label:
仕掛品、流動資産（IFRS）
```

Both：

```text
Inventory Component

Instant Fact

Monetary Fact
```

Observed Financial Statement Function：

```text
Component of total inventories
```

Preliminary Result：

```text
Semantic Similarity:
HIGH CANDIDATE
```

Status：

```text
Preliminary Observation
Not Mapping Approval
```

---

# 8. Current Asset Qualifier Review

IFRS Source Label contains：

```text
流動資産（IFRS）
```

Japanese GAAP Source Label candidate does not include the same qualifier in the observed QName label.

Research Question：

```text
Does the current-asset qualifier
materially narrow the semantic meaning?
```

Potential Outcomes：

```text
A.
Presentation qualifier only

B.
Semantic scope restriction

C.
Potential conflict if non-current inventory exists

D.
Insufficient evidence
```

Current Decision：

```text
NOT YET DETERMINED
```

Do not silently discard the qualifier.

---

# 9. Accounting Standard Boundary Risk

Japanese GAAP and IFRS may differ in：

```text
Recognition

Measurement

Presentation

Classification

Disclosure Structure
```

However、Canonical Semantic Role Mapping does not necessarily require identical accounting measurement rules.

Research Question：

```text
Does Canonical Role represent
economic component identity

or

fully equivalent accounting measurement?
```

Current Architecture Candidate：

```text
Canonical Semantic Role
=
Normalized financial observation meaning

not
Accounting policy equivalence
```

This candidate requires Reviewer confirmation.

If accepted：

```text
WorkInProcess
```

may normalize economically equivalent inventory-stage observations while retaining：

```text
Accounting Standard

Source QName

Namespace

Taxonomy Version

Source Value
```

in lineage.

Status：

```text
Architecture Interpretation Candidate
```

---

# 10. Required Official Taxonomy Review

Before Cross-standard Mapping Approval, inspect official EDINET materials for both concepts.

Required Evidence：

```text
Japanese GAAP Concept Element Information

IFRS Concept Element Information

Official Labels

Period Type

Data Type

Presentation / Account Classification

Available Documentation

Adjacent Inventory Concepts
```

Taxonomy Versions in current validated evidence：

```text
jppfs:
2025-11-01

jpigp:
2024-11-01
```

Additional Version Evidence Candidate：

```text
jpigp:
2025-11-01
```

Important：

The research must record the exact official material version used.

---

# 11. Adjacent Concept Review

Japanese GAAP adjacent concepts Candidate：

```text
Merchandise

FinishedGoods

MerchandiseAndFinishedGoods

WorkInProcess

RawMaterialsAndSupplies

Supplies
```

IFRS adjacent concepts Candidate：

```text
FinishedGoodsCAIFRS

MerchandiseAndFinishedGoodsCAIFRS

WorkInProcessCAIFRS

RawMaterialsCAIFRS

RawMaterialsAndSuppliesCAIFRS

OtherInventoriesCAIFRS
```

Purpose：

> Determine whether WorkInProcess concepts occupy equivalent semantic positions within their respective taxonomy inventory concept sets.

A concept must not be reviewed in isolation when adjacent concept boundaries may differ.

---

# 12. Information Loss Gate

Candidate Mapping：

```text
jppfs_cor:WorkInProcess
→
WorkInProcess

jpigp_cor:WorkInProcessCAIFRS
→
WorkInProcess
```

Potential Information Loss：

```text
Accounting Standard identity
```

Mitigation Candidate：

```text
Preserve Accounting Standard in lineage.
```

Potential Information Loss：

```text
IFRS current-asset presentation qualifier
```

Mitigation Candidate：

```text
Preserve Source Concept and Label.
```

Reviewer Question：

```text
After lineage preservation,
does canonicalization still remove
material investment-relevant meaning?
```

Decision：

```text
PENDING OFFICIAL TAXONOMY REVIEW
```

---

# 13. Measurement Difference Boundary

Possible accounting measurement differences between standards must not be confused withSemantic Component Identity.

Example Conceptual Separation：

```text
Semantic Role:
WorkInProcess

Accounting Standard:
Japanese GAAP
or
IFRS
```

Downstream Research may compare normalized observations across standards.

However、if measurement differences materially distort：

```text
Inventory Growth

Inventory Ratio

Composition Ratio
```

then Accounting Standard may need to become：

```text
Feature Dimension

Normalization Dimension

Model Control Variable

Comparison Restriction
```

This is not decided in Semantic Mapping alone.

Research Finding Candidate：

```text
Semantic Equivalence
does not automatically prove
metric comparability.
```

This distinction is mandatory.

---

# 14. Cross-standard Double-count Risk

Potential Conflict：

```text
WorkInProcessCAIFRS
```

and Company Extension：

```text
SemiFinishedProductsAndWorkInProgressCAIFRS
```

may both map to：

```text
WorkInProcess
```

Across different filings this may be acceptable.

Within the same filing, overlapping concepts could cause double counting.

Required Rule Candidate：

```text
Same Canonical Role
+
Same Filing
+
Same Period
+
Potentially overlapping source concepts

↓
Conflict Review
```

Do not sum all facts mapped to the same Canonical Role automatically.

This issue must be reviewed before Production Mapping Architecture approval.

---

# 15. Pre-review Gate

Cross-standard Mapping Research Sheet may proceed only if：

```text
Official concept information collected

Adjacent concepts reviewed

Current asset qualifier evaluated

Accounting standard lineage preservation confirmed

Semantic identity and metric comparability separated

Double-count conflict risk recorded
```

Gate Result Candidate：

```text
PASS
DEFER
REJECT
```

---

# 16. Research Reviewer Current Decision

Current Filing Evidence supports：

```text
High semantic similarity
```

between：

```text
jppfs_cor:WorkInProcess

jpigp_cor:WorkInProcessCAIFRS
```

However、the following official taxonomy review is not yet recorded in a Research Artifact：

```text
Official element comparison

Adjacent concept boundary comparison

Current asset qualifier interpretation
```

Therefore：

```text
CROSS-STANDARD MAPPING APPROVAL:
DEFER
```

This is not a rejection.

Decision：

```text
Proceed to Official Taxonomy Evidence Review
before creating the final Mapping Research Sheet.
```

---

# 17. Exact Next Task

Next Task：

```text
Official EDINET Taxonomy Evidence Review
for WorkInProcess Cross-standard Mapping
```

Research Target：

```text
jppfs_cor:WorkInProcess

jpigp_cor:WorkInProcessCAIFRS
```

Required Official Materials：

```text
EDINET Taxonomy Account Title List

EDINET Taxonomy Element Information

Designated International Accounting Standards Taxonomy Element List

Concept Selection Guidance

Taxonomy Version Difference Information
where relevant
```

Output：

```text
Official Taxonomy Evidence Summary
```

Only after the Evidence Summary is completed should the following be created：

```text
Inventory Semantic Mapping Research Sheet
jpigp_cor:WorkInProcessCAIFRS
```

Mapping Approval remains：

```text
DEFER
```
