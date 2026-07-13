# Inventory Semantic Mapping Research Sheet

# jpigp_cor:FinishedGoodsCAIFRS

## 1. Document Purpose

本書は、EDINET Inventory Semantic Mapping Research Designに基づき、

`jpigp_cor:FinishedGoodsCAIFRS`

をCanonical Inventory Semantic RoleへMapping可能か検証するResearch Sheetである。

### Mapping Candidate

`jpigp_cor:FinishedGoodsCAIFRS → FinishedGoods`

本書の目的はProduction Mapping Masterを作成することではない。

目的は以下である。

> IFRS Standard TaxonomyのFinished Goods Conceptについて、公式Taxonomy Meaning、Kioxia Filing Evidence、Inventory Component Position及びAdjacent Combined Conceptとの境界を確認し、Canonical Semantic Role `FinishedGoods` へのMapping Approval可否をEvidenceに基づいて評価する。

### Status

* Research Sheet
* Semantic Mapping Research
* IFRS Standard Component Mapping
* Adjacent Concept Boundary Review
* Research Reviewer Pending
* Production Mapping Not Approved

---

## 2. Research Target

### Source Concept QName

`jpigp_cor:FinishedGoodsCAIFRS`

### Local Name

`FinishedGoodsCAIFRS`

### Prefix

`jpigp_cor`

### Accounting Standard

`IFRS`

### Canonical Semantic Role Candidate

`FinishedGoods`

### Initial Mapping Confidence Candidate

`M1`

`Direct Standard Mapping`

Initial ConfidenceはResearch開始時点のCandidateであり、Reviewer Approvalではない。

---

## 3. Research Questions

本Researchでは以下を確認する。

1. `FinishedGoodsCAIFRS` は完成品在庫を直接表すか。
2. Official Standard Labelは`FinishedGoods`と直接整合するか。
3. Kioxia Filing EvidenceはSource Concept Meaningと整合するか。
4. Inventory Component FactとしてEligibilityを満たすか。
5. `MerchandiseAndFinishedGoodsCAIFRS`とのSemantic Boundaryは明確か。
6. Combined Conceptとの重複・Double-count Riskはあるか。
7. Canonical Role `FinishedGoods`へのMappingでMaterial Information Lossが生じるか。
8. Accounting Standard DimensionはLineageとして十分か。
9. M1 Direct Standard Mapping Approvalは妥当か。
10. このMapping ApprovalをCombined Conceptへ拡張してよいか。

---

## 4. Evidence Hierarchy

本Researchでは以下のEvidence Priorityを採用する。

### Priority 1

Official EDINET IFRS Taxonomy Evidence

Includes:

* Official Element List
* Official Japanese Label
* Official English Label
* Data Type
* Period Type
* Balance Attribute
* Abstract Status
* Taxonomy Version

### Priority 2

Validated Filing Evidence

Primary Company:

`Kioxia Holdings Corporation`

Document ID:

`S100YJ18`

### Priority 3

Inventory Note Context

Purpose:

* Component Position
* Reported Component Meaning
* Total Reconciliation

### Priority 4

Adjacent Concept Review

Target:

* `FinishedGoodsCAIFRS`
* `MerchandiseAndFinishedGoodsCAIFRS`

### Priority 5

Concept Name Inference

Classification:

`Supporting Inference Only`

---

## 5. Source Concept Identity

### QName

`jpigp_cor:FinishedGoodsCAIFRS`

### Namespace Family

`jpigp`

### Local Name

`FinishedGoodsCAIFRS`

### Official Japanese Standard Label Candidate

`製品`

### Official English Standard Label Candidate

`Finished goods`

### Data Type

`xbrli:monetaryItemType`

### Substitution Group

`xbrli:item`

### Period Type

`instant`

### Balance Attribute

`debit`

### Abstract

`false`

### Classification

* IFRS Standard Taxonomy Concept
* Numeric Fact Concept
* Monetary Fact
* Instant Fact
* Inventory Component Candidate

Source Concept Identity:

`CONFIRMED`

---

## 6. Taxonomy Version Scope

Initial Kioxia Validation used the following Namespace Version.

`jpigp/2025-11-01`

The Source Concept was observed as:

`jpigp_cor:FinishedGoodsCAIFRS`

Current Research Scope:

`2025-11-01 validated filing evidence`

Cross-version universal approval is not declared in this Sheet.

### Version Governance

New or prior Taxonomy Versions require:

* Local Name Review
* Label Review
* Element Attribute Review
* Financial Statement Role Review

### Current Classification

`Taxonomy Version Recorded`

---

## 7. Official Label Evaluation

### Source Concept

`FinishedGoodsCAIFRS`

### Japanese Label Candidate

`製品`

### English Label Candidate

`Finished goods`

### Canonical Semantic Role Candidate

`FinishedGoods`

Meaning Compatibility:

`DIRECT`

The Source Concept does not contain:

* Merchandise
* Raw Materials
* Work In Process
* Other Inventories

in its Concept identity.

### Label Evaluation Result

`PASS`

---

## 8. Structured Element Attribute Evaluation

### Data Type

`monetaryItemType`

Compatible with a monetary inventory component observation.

Result:

`PASS`

### Period Type

`instant`

Compatible with an inventory stock balance.

Result:

`PASS`

### Balance Attribute

`debit`

Consistent with an asset inventory component.

Result:

`PASS`

### Abstract Status

`false`

Usable Numeric Fact Concept Candidate.

Result:

`PASS`

### Structured Attribute Result

`CONSISTENT WITH FINISHED GOODS INVENTORY COMPONENT`

Structured attributes alone are not Semantic Proof.

They support Label and Filing Evidence.

---

## 9. Filing Evidence Scope

### Company

キオクシアホールディングス株式会社

`Kioxia Holdings Corporation`

### Security Code

`285A0`

### EDINET Code

`E35948`

### Document ID

`S100YJ18`

### Document Type

`120`

### Period

`2025-04-01 - 2026-03-31`

### Submitted At

`2026-06-24 11:15`

### Accounting Standard

`IFRS`

### Consolidation Scope

`Consolidated`

Filing Identity:

`CONFIRMED`

---

## 10. Kioxia Raw Financial Facts

### Prior

QName:

`jpigp_cor:FinishedGoodsCAIFRS`

ContextRef:

`Prior1YearInstant`

UnitRef:

`JPY`

Decimals:

`-6`

Raw Value:

`50549000000`

### Current

QName:

`jpigp_cor:FinishedGoodsCAIFRS`

ContextRef:

`CurrentYearInstant`

UnitRef:

`JPY`

Decimals:

`-6`

Raw Value:

`53232000000`

### Classification

* Numeric Fact
* Instant Fact
* Consolidated IFRS Fact
* Monetary Fact
* JPY

Eligibility Candidate:

`Eligible Inventory Component Fact`

---

## 11. Kioxia Inventory Note Context

Kioxia Inventory Note disclosed the following components.

* 製品
* 半製品及び仕掛品
* 原材料
* その他
* 合計

### Prior

製品:

`50,549 million JPY`

半製品及び仕掛品:

`283,746 million JPY`

原材料:

`18,486 million JPY`

その他:

`82 million JPY`

Total:

`352,863 million JPY`

### Current

製品:

`53,232 million JPY`

半製品及び仕掛品:

`280,183 million JPY`

原材料:

`79,093 million JPY`

その他:

`104 million JPY`

Total:

`412,612 million JPY`

The structured Fact:

`jpigp_cor:FinishedGoodsCAIFRS`

matched the Inventory Note row:

`製品`

Prior:

`50,549 million JPY`

Current:

`53,232 million JPY`

### Same-filing Result

`EXACT VALUE MATCH`

### Research Finding

`FinishedGoodsCAIFRS`

is directly associated with the disclosed:

`製品`

inventory component in the validated Filing.

Classification:

`Strong Same-filing Semantic Evidence`

---

## 12. Component Sum Reconciliation

### Prior

`50,549 + 283,746 + 18,486 + 82 = 352,863`

Reported Inventory Total:

`352,863 million JPY`

Result:

`EXACT MATCH`

### Current

`53,232 + 280,183 + 79,093 + 104 = 412,612`

Reported Inventory Total:

`412,612 million JPY`

Result:

`EXACT MATCH`

### Research Use

Component Sum supports:

`FinishedGoodsCAIFRS`

being one Inventory Component.

However:

`Component Sum Match ≠ FinishedGoods Semantic Meaning Proven Alone`

Primary Semantic Evidence remains:

* Official Label
* Source Concept Identity
* Inventory Note Row
* Financial Statement Position

---

## 13. Inventory Component Eligibility

Candidate Fact must satisfy:

* Numeric Fact
* Instant Fact
* Validated Financial Statement Scope
* Validated Consolidation Scope
* Validated Monetary Unit
* Inventory Component Meaning

### Numeric Fact

`PASS`

### Instant Fact

`PASS`

### Consolidation Scope

`PASS within validated filing`

### Monetary Unit

`JPY`

`PASS`

### Inventory Component Meaning

`PASS`

### Eligibility Result

`Eligible Inventory Component Fact`

---

## 14. Adjacent Concept A

## MerchandiseAndFinishedGoodsCAIFRS

Adjacent Concept:

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

Semantic Candidate:

`商品及び製品`

This Concept combines:

`Merchandise`

and:

`Finished Goods`

Therefore:

`FinishedGoodsCAIFRS`

and:

`MerchandiseAndFinishedGoodsCAIFRS`

are not identical Source Concepts.

### Boundary Finding

`FinishedGoodsCAIFRS`

represents a narrower Finished Goods Concept Candidate.

`MerchandiseAndFinishedGoodsCAIFRS`

contains a broader combined inventory meaning.

Therefore:

`FinishedGoodsCAIFRS = MerchandiseAndFinishedGoodsCAIFRS`

is rejected.

---

## 15. Adjacent Concept Boundary Decision

### Concept A

`FinishedGoodsCAIFRS`

Candidate Meaning:

`Finished Goods`

### Concept B

`MerchandiseAndFinishedGoodsCAIFRS`

Candidate Meaning:

`Merchandise + Finished Goods`

Shared Meaning:

`Finished Goods component is included in both semantic descriptions.`

Material Difference:

`Merchandise inclusion`

### Reviewer Boundary Candidate

The two Concepts may both eventually contribute to a broader analytical category related to finished inventories.

However:

`Source Semantic Mapping`

must not erase the combined Concept distinction without separate Information Loss Review.

Therefore this Sheet approves only:

`FinishedGoodsCAIFRS → FinishedGoods`

This Sheet does not approve:

`MerchandiseAndFinishedGoodsCAIFRS → FinishedGoods`

---

## 16. Canonical Role Boundary

Canonical Candidate:

`FinishedGoods`

Meaning Candidate:

`Completed goods held as inventory`

The Source Concept:

`FinishedGoodsCAIFRS`

directly fits this Role.

### Alternative Candidate

`FinishedProducts`

Concern:

The existing Research Design uses:

`FinishedGoods`

and the Official English Label uses:

`Finished goods`

Decision:

`REJECT AS PRIMARY CANONICAL NAME`

### Preferred Candidate

`FinishedGoods`

Canonical Role Suitability:

`PASS`

---

## 17. Information Loss Evaluation

### Source Meaning

`Finished goods`

### Canonical Meaning

`FinishedGoods`

Removed Information:

* IFRS Accounting Standard
* Taxonomy Family
* Source Concept identity

These are retained in Lineage.

### Inventory Component Meaning Loss

`NONE IDENTIFIED`

### Overall Information Loss

`None / Minor`

Classification Candidate:

`None`

Accounting Standard identity is contextual metadata rather than Finished Goods component meaning.

### Mapping Condition

Original Source and Accounting Standard Lineage must be retained.

---

## 18. Accounting Standard Boundary

Source Concept:

`IFRS`

Canonical Role:

`FinishedGoods`

The Canonical Role does not encode:

`IFRS`

This is intentional.

### Research Boundary

`Semantic Component Identity`

is separated from:

`Accounting Standard`

The following remains in Lineage:

* Accounting Standard
* QName
* Namespace URI
* Taxonomy Version

### Not Proven

`IFRS FinishedGoods metrics`

and:

`Japanese GAAP FinishedGoods-related metrics`

are directly comparable.

### Research Finding

`Semantic Mapping ≠ Cross-standard Metric Comparability`

Metric Comparability remains a separate Validation Gate.

---

## 19. Double-count Risk Evaluation

### Risk A

`InventoryTotal`

and:

`FinishedGoods`

are summed into the same Total calculation.

Result:

`Double Count`

Required Governance:

`Total and Component Roles remain separate`

---

### Risk B

`FinishedGoodsCAIFRS`

and:

`MerchandiseAndFinishedGoodsCAIFRS`

both exist in the same Filing / Period / Scope.

Potential Result:

`Overlapping Finished Goods Meaning`

Required Governance:

`Conflict Review`

Do not sum automatically.

---

### Risk C

Multiple Source Facts map to:

`FinishedGoods`

within the same Filing / Period / Scope.

Required Rule Candidate:

`Same Canonical Role + Same Filing + Same Period + Same Scope → Duplicate / Overlap Review`

### Double-count Risk Classification

`Medium`

Risk arises from:

`Adjacent Combined Concept overlap`

not from the direct Source Concept meaning.

---

## 20. Combined Concept Inheritance Rule

Approval of:

`FinishedGoodsCAIFRS → FinishedGoods`

does not authorize:

`MerchandiseAndFinishedGoodsCAIFRS → FinishedGoods`

The latter requires:

* Separate Research Sheet
* Information Loss Review
* Merchandise distinction review
* Downstream Metric Impact Review
* Independent Reviewer Decision

### Prohibited Rule

`Concept contains FinishedGoods → FinishedGoods`

is rejected.

Mapping must use reviewed Source Concept Identity.

---

## 21. Contradicting Evidence Search

Within current validated scope:

### Same Concept Used as Inventory Total

`NOT OBSERVED`

### Same Concept Used as Work In Process

`NOT OBSERVED`

### Same Concept Used as Raw Materials

`NOT OBSERVED`

### Same Concept Used for Non-inventory Meaning

`NOT OBSERVED`

### Period Type Conflict

`NOT IDENTIFIED`

### Standard Label Conflict

`NOT IDENTIFIED`

### Filing Note Meaning Conflict

`NOT IDENTIFIED`

### Contradicting Semantic Evidence

`NONE IDENTIFIED within current reviewed scope`

---

## 22. Mapping Confidence Evaluation

### M1 Requirement

* Standard Taxonomy Concept
* Source Label directly matches Canonical Role
* Financial Statement Context consistent

### Evaluation

Standard Taxonomy Concept:

`PASS`

Direct Source Label:

`PASS`

English Label Alignment:

`PASS`

Instant Fact:

`PASS`

Inventory Component Role:

`PASS`

Same-filing Note Cross-reference:

`PASS`

Value Match:

`PASS`

Component Reconciliation:

`PASS`

Information Loss:

`NONE MATERIAL`

Contradicting Evidence:

`NONE IDENTIFIED`

Adjacent Combined Concept Boundary:

`REVIEWED`

### Mapping Confidence Candidate

`M1`

`Direct Standard Mapping`

---

## 23. Researcher Proposal

### Proposed Mapping

`jpigp_cor:FinishedGoodsCAIFRS → FinishedGoods`

### Proposed Mapping Class

`M1`

`Direct Standard Mapping`

### Proposed Scope

`Validated IFRS eligible Finished Goods inventory component facts`

### Proposed Usage

`Canonical FinishedGoods Observation`

### Eligible Usage Requires

* Numeric Fact
* Instant Period Type
* Validated Financial Statement Scope
* Validated Consolidation Scope for common observation
* Validated Monetary Unit
* Source Lineage Preservation

### Adjacent Concept Condition

`MerchandiseAndFinishedGoodsCAIFRS`

must be treated as a separate Mapping Research Target.

---

## 24. Researcher Evidence Summary

### Supporting Evidence

* IFRS Standard Taxonomy Concept
* Direct Finished Goods Concept name
* Direct Finished Goods label
* Monetary Item Type
* Instant Period Type
* Debit Balance Attribute
* Non-abstract Fact Element
* Kioxia Raw XBRL Fact
* Kioxia Inventory Note Row `製品`
* Prior Exact Value Match
* Current Exact Value Match
* Inventory Component Sum Reconciliation
* No contradictory meaning observed
* Adjacent Combined Concept explicitly separated

### Known Limitations

* Current validated Filing Evidence for this exact Concept is Kioxia-centered.
* Cross-company reproduction is not yet established for this exact Source Concept.
* Cross-standard Metric Comparability is not evaluated.
* Combined Finished Goods Concepts require separate Research.

### Researcher Decision Candidate

`APPROVE MAPPING`

---

## 25. Independent Research Reviewer Review

### Review Question 1

Was the Mapping approved only because the Local Name contains `FinishedGoods`?

Decision:

`NO`

Evidence includes:

* Source Label
* Inventory Note Position
* Exact Value Match
* Structured Element Attributes
* Component Reconciliation

---

### Review Question 2

Was the adjacent combined Concept ignored?

Decision:

`NO`

`MerchandiseAndFinishedGoodsCAIFRS`

was explicitly reviewed as an adjacent Semantic Boundary.

Reviewer Finding:

`FinishedGoodsCAIFRS is semantically narrower.`

---

### Review Question 3

Should both Concepts map to the same Canonical Role for convenience?

Decision:

`NOT DECIDED`

This Sheet does not approve the Combined Concept Mapping.

Convenience is not sufficient evidence.

---

### Review Question 4

Is there Material Information Loss?

Decision:

`NO MATERIAL LOSS IDENTIFIED`

Source Meaning:

`Finished goods`

Canonical Meaning:

`FinishedGoods`

Direct semantic correspondence.

---

### Review Question 5

Is M1 too strong with one validated company?

Reviewer Concern:

`LIMITED CROSS-COMPANY REPRODUCTION`

However M1 is justified by:

* Standard Taxonomy Concept
* Direct Standard Label
* Direct English Label
* Same-filing Primary Evidence

M1 does not require multi-company reproduction when Direct Standard Mapping Evidence is sufficiently strong.

Reviewer Condition:

`New contradictory filing usage triggers Mapping Review`

---

### Review Question 6

Does Approval imply cross-standard comparability?

Decision:

`NO`

Metric Comparability remains:

`NOT EVALUATED`

---

## 26. Research Reviewer Decision

`APPROVE`

### Approved Research Mapping Candidate

`jpigp_cor:FinishedGoodsCAIFRS → FinishedGoods`

### Mapping Confidence

`M1`

`Direct Standard Mapping`

### Scope

`Validated IFRS eligible Finished Goods inventory component facts`

### Usage Candidate

`Canonical FinishedGoods Observation`

### Adjacent Combined Concept

`NOT APPROVED BY THIS SHEET`

### Metric Comparability

`NOT EVALUATED`

---

## 27. Reviewer Conditions

Approval is subject to the following conditions.

1. Original QName must be preserved.
2. Namespace URI must be preserved.
3. Taxonomy Version must be preserved.
4. Accounting Standard must be preserved.
5. Original ContextRef must be preserved.
6. Instant balance semantics must be validated.
7. Consolidated and NonConsolidated observations must remain separate.
8. Monetary Unit must be validated.
9. Decimals must be preserved.
10. InventoryTotal and FinishedGoods roles must remain separate.
11. `MerchandiseAndFinishedGoodsCAIFRS` must not inherit this Mapping.
12. Substring or keyword-based Mapping is prohibited.
13. Multiple FinishedGoods role candidates in the same Filing / Period / Scope require Conflict Review.
14. New contradictory filing usage requires Mapping Review.
15. New Taxonomy Versions require Version Change Review.
16. Mapping Approval does not prove Metric Comparability.
17. Mapping Approval does not authorize Production implementation.

---

## 28. Mapping Approval Gate Result

| Gate Item                    | Result        |
| ---------------------------- | ------------- |
| Source Concept Identity      | CONFIRMED     |
| Eligibility                  | PASS          |
| Financial Meaning Evidence   | SUFFICIENT    |
| Canonical Role Candidate     | DEFINED       |
| Information Loss             | NONE MATERIAL |
| Adjacent Concept Boundary    | REVIEWED      |
| Double-count Risk            | EVALUATED     |
| Contradicting Evidence       | REVIEWED      |
| Taxonomy Version             | RECORDED      |
| Accounting Standard Boundary | RECORDED      |
| Reviewer Decision            | APPROVE       |

### Gate Result

`PASS`

---

## 29. Architecture Reviewer Requirement

### Canonical Role Addition

`NO`

### Canonical Role Split

`NO`

### Mapping Model Change

`NO`

### Lineage Requirement Change

`NO`

### Adjacent Concept Conflict Governance

Already defined in Semantic Mapping Research Design.

Therefore:

`Architecture Reviewer Additional Gate: NOT REQUIRED`

---

## 30. Final Mapping Research Result

### Source Concept

`jpigp_cor:FinishedGoodsCAIFRS`

### Canonical Semantic Role

`FinishedGoods`

### Mapping Class

`M1`

`DIRECT STANDARD MAPPING`

### Research Reviewer

`APPROVE`

### Mapping Gate

`PASS`

### Adjacent Combined Concept Mapping

`NOT APPROVED`

### Metric Comparability

`NOT EVALUATED`

### Production Mapping

`NOT YET APPROVED`

---

## 31. Direct Standard Mapping Procedure Evaluation

This Sheet is an IFRS Direct Standard Component Mapping Case.

### Procedure Evaluation

Source Identity Review:

`WORKED`

Official Label Review:

`WORKED`

Eligibility Review:

`WORKED`

Filing Note Cross-reference:

`WORKED`

Adjacent Concept Boundary Review:

`WORKED`

Information Loss Review:

`WORKED`

Double-count Review:

`WORKED`

Reviewer Independence Review:

`WORKED`

### Result

`PASS`

### Procedure Compression Decision

Completed Direct Standard Mapping Cases now include:

* `InventoriesCAIFRS → InventoryTotal`
* `jppfs WorkInProcess → WorkInProcess`
* `WorkInProcessCAIFRS → WorkInProcess`
* `FinishedGoodsCAIFRS → FinishedGoods`

However:

`Shortened Standard Mapping Review Procedure = NOT YET APPROVED`

Reason:

The next Mapping Candidates include combined semantic concepts where the direct procedure no longer applies cleanly.

---

## 32. Current Mapping Research State

Approved Research Mapping Candidates:

### 1

`jpigp_cor:InventoriesCAIFRS → InventoryTotal`

Class:

`M1`

Status:

`APPROVED`

### 2

`jppfs_cor:WorkInProcess → WorkInProcess`

Class:

`M1`

Status:

`APPROVED`

### 3

`jpigp_cor:WorkInProcessCAIFRS → WorkInProcess`

Class:

`M1`

Status:

`APPROVED`

### 4

`jpigp_cor:FinishedGoodsCAIFRS → FinishedGoods`

Class:

`M1`

Status:

`APPROVED`

Important:

`Approved Research Mapping ≠ Production Mapping Master Entry`

Catalog / DDL / Entityへの登録はまだ行わない。

---

## 33. Exact Next Task

次のMapping Research Targetは以下とする。

`jppfs_cor:MerchandiseAndFinishedGoods`

### Canonical Semantic Role Candidate

`FinishedGoods`

### Initial Mapping Class Candidate

`M2`

`Strongly Supported Semantic Mapping`

### Research Purpose

> Japanese GAAPで5社に再現したCombined Inventory Conceptについて、`Merchandise + Finished Goods`を`FinishedGoods`へCanonicalizeすることによるInformation Lossが許容可能かを検証する。

### Research Focus

* Official Standard Label
* Merchandise / Finished Goods combined meaning
* Five-company cross-company reproduction
* Canonical simplification risk
* Information Loss materiality
* Downstream composition metric distortion
* Alternative Canonical Role Candidate
* `MerchandiseAndFinishedGoods`独立Roleの必要性
* M2 Approval可否

### Important

ここからはDirect Mapping Caseではない。

`jppfs_cor:MerchandiseAndFinishedGoods → FinishedGoods`

を既定路線としない。

以下も候補として維持する。

* `FinishedGoods`
* `MerchandiseAndFinishedGoods`
* New Canonical Role
* Conditional Mapping
* Unmapped

### Reviewer Gate

`Information Loss Review`

をPrimary Gateとする。
