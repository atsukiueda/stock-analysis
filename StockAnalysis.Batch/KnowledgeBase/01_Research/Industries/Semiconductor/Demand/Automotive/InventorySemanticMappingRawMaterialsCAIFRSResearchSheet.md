# Inventory Semantic Mapping Research Sheet

# jpigp_cor:RawMaterialsCAIFRS

## 1. Document Purpose

本書は、EDINET Inventory Semantic Mapping Research Designに基づき、

`jpigp_cor:RawMaterialsCAIFRS`

をCanonical Inventory Semantic RoleへMapping可能か検証するResearch Sheetである。

### Mapping Candidate

`jpigp_cor:RawMaterialsCAIFRS → RawMaterials`

本書の目的はProduction Mapping Masterを作成することではない。

目的は以下である。

> IFRS Standard TaxonomyのRaw Materials Conceptについて、Official Taxonomy Evidence、Kioxia Filing Evidence、Inventory Component Position及びAdjacent Combined Concept Boundaryを確認し、Canonical Semantic Role `RawMaterials` へのMapping Approval可否をEvidenceに基づいて評価する。

### Status

* Research Sheet
* Semantic Mapping Research
* IFRS Standard Component Mapping
* Adjacent Combined Concept Boundary Review
* Research Reviewer Pending
* Production Mapping Not Approved

---

## 2. Research Target

### Source Concept QName

`jpigp_cor:RawMaterialsCAIFRS`

### Local Name

`RawMaterialsCAIFRS`

### Prefix

`jpigp_cor`

### Accounting Standard

`IFRS`

### Canonical Semantic Role Candidate

`RawMaterials`

### Initial Mapping Confidence Candidate

`M1`

`Direct Standard Mapping`

Initial ConfidenceはResearch開始時点のCandidateであり、Reviewer Approvalではない。

---

## 3. Research Questions

本Researchでは以下を確認する。

1. `RawMaterialsCAIFRS`は原材料在庫を直接表すか。
2. Official Standard Labelは`RawMaterials`と直接整合するか。
3. Official Element AttributesはInventory Stock Componentとして整合するか。
4. Kioxia Filing EvidenceはSource Concept Meaningと整合するか。
5. Inventory Component FactとしてEligibilityを満たすか。
6. `RawMaterialsAndSuppliesCAIFRS`とのSemantic Boundaryは明確か。
7. Japanese GAAP `RawMaterialsAndSupplies`とのBoundaryは維持されているか。
8. Canonical Role `RawMaterials`へのMappingでMaterial Information Lossが生じるか。
9. Metric ComparabilityとSemantic Mappingを分離できているか。
10. M1 Direct Standard Mapping Approvalは妥当か。

---

## 4. Evidence Hierarchy

本Researchでは以下のEvidence Priorityを採用する。

### Priority 1

Official EDINET IFRS Taxonomy Evidence

Includes:

* Official Japanese Label
* Official English Label
* Data Type
* Substitution Group
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
* Disclosed Component Meaning
* Source Fact Value Match
* Component Sum Reconciliation

### Priority 4

Adjacent Concept Review

Targets:

* `RawMaterialsCAIFRS`
* `RawMaterialsAndSuppliesCAIFRS`
* `ProductionSuppliesCAIFRS`
* `WorkInProcessAndRawMaterialsCAIFRS`

### Priority 5

Cross-standard Reference Concepts

Targets:

* `jppfs_cor:RawMaterialsAndSupplies`
* Future direct Japanese GAAP Raw Materials Concept if validated

### Priority 6

Concept Name Inference

Classification:

`Supporting Inference Only`

Concept Name alone cannot approve the Mapping.

---

## 5. Source Concept Identity

### QName

`jpigp_cor:RawMaterialsCAIFRS`

### Namespace Family

`jpigp`

### Local Name

`RawMaterialsCAIFRS`

### Official Japanese Standard Label

`原材料`

### Official Japanese Verbose Label

`原材料、流動資産（IFRS）`

### Official English Standard Label

`Raw materials`

### Official English Verbose Label

`Raw materials - CA (IFRS)`

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

### Source Concept Identity

`CONFIRMED`

---

## 6. Taxonomy Version Evidence

The Concept was confirmed in the reviewed Official IFRS Element Lists.

### Reviewed Version A

`jpigp/2024-11-01`

### Reviewed Version B

`jpigp/2025-11-01`

The reviewed official attributes were aligned.

### Japanese Standard Label

`原材料`

### Japanese Verbose Label

`原材料、流動資産（IFRS）`

### English Standard Label

`Raw materials`

### English Verbose Label

`Raw materials - CA (IFRS)`

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

### Current Finding

`No Material Reviewed Attribute Difference Observed`

between the reviewed 2024 and 2025 Official IFRS Element Lists.

### Classification

`Cross-version Stability Supported within Reviewed Official Attributes`

### Not Declared

`Universal Taxonomy Definition Identity`

Future Taxonomy Versions remain subject to Version Change Review.

---

## 7. Official Label Evaluation

### Source Concept

`RawMaterialsCAIFRS`

### Japanese Standard Label

`原材料`

### English Standard Label

`Raw materials`

### Canonical Semantic Role Candidate

`RawMaterials`

### Meaning Compatibility

`DIRECT`

The Official Standard Label does not explicitly include:

* Supplies
* Production Supplies
* Work In Process
* Finished Goods
* Other Inventories

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

Consistent with an inventory asset component.

Result:

`PASS`

### Abstract Status

`false`

Usable Numeric Fact Concept Candidate.

Result:

`PASS`

### Structured Attribute Result

`CONSISTENT WITH RAW MATERIALS INVENTORY COMPONENT`

Structured attributes alone are not Semantic Proof.

They support Official Label and Filing Evidence.

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

### Filing Identity

`CONFIRMED`

---

## 10. Kioxia Raw Financial Facts

### Prior

QName:

`jpigp_cor:RawMaterialsCAIFRS`

ContextRef:

`Prior1YearInstant`

UnitRef:

`JPY`

Decimals:

`-6`

Raw Value:

`18486000000`

### Current

QName:

`jpigp_cor:RawMaterialsCAIFRS`

ContextRef:

`CurrentYearInstant`

UnitRef:

`JPY`

Decimals:

`-6`

Raw Value:

`79093000000`

### Classification

* Numeric Fact
* Instant Fact
* Consolidated IFRS Fact
* Monetary Fact
* JPY

### Eligibility Candidate

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

`jpigp_cor:RawMaterialsCAIFRS`

matched the Inventory Note row:

`原材料`

### Prior Value Match

`18,486 million JPY`

Result:

`EXACT MATCH`

### Current Value Match

`79,093 million JPY`

Result:

`EXACT MATCH`

### Research Finding

The exact Source Concept is directly associated with the disclosed:

`原材料`

Inventory Component.

### Classification

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

`RawMaterialsCAIFRS`

being an Inventory Component.

However:

`Component Sum Match ≠ Raw Materials Semantic Meaning Proven Alone`

Primary Semantic Evidence remains:

* Official Standard Label
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

## 14. Current Asset Qualifier Review

IFRS Verbose Label:

`原材料、流動資産（IFRS）`

English:

`Raw materials - CA (IFRS)`

Canonical Candidate:

`RawMaterials`

### Potential Concern

The Canonical Role does not preserve the Current Asset qualifier in its name.

### Official Evidence

Japanese Standard Label:

`原材料`

English Standard Label:

`Raw materials`

Observed Filing Role:

`Inventory Component`

### Reviewer Interpretation Candidate

The Current Asset qualifier represents a financial statement presentation or classification distinction in the reviewed Source Concept.

No Evidence currently indicates that it changes the raw-material inventory component semantic identity.

### Information Loss Candidate

`Minor`

### Mandatory Lineage Condition

Preserve:

* Accounting Standard
* Source QName
* Namespace URI
* Taxonomy Version
* Source Label

### Future Boundary Trigger

Detection of:

`Non-current Raw Materials Concept`

or another materially different Raw Materials Concept requires:

`Canonical Role Boundary Review`

---

## 15. Adjacent Concept A

## RawMaterialsAndSuppliesCAIFRS

Adjacent Concept:

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

### Official Japanese Standard Label

`原材料及び貯蔵品`

### Official English Standard Label

`Raw materials and supplies`

### Semantic Structure

`Raw Materials + Supplies`

This Concept contains a broader Combined Meaning than:

`RawMaterialsCAIFRS`

### Boundary Finding

`RawMaterialsCAIFRS`

and:

`RawMaterialsAndSuppliesCAIFRS`

are distinct Source Semantic Concepts.

Therefore:

`RawMaterialsAndSuppliesCAIFRS → RawMaterials`

is not approved by this Sheet.

---

## 16. Adjacent Concept B

## ProductionSuppliesCAIFRS

Adjacent Concept:

`jpigp_cor:ProductionSuppliesCAIFRS`

### Official Japanese Standard Label

`貯蔵品`

### Official English Standard Label

`Production supplies`

This Concept represents a supplies-related inventory candidate.

### Research Finding

The IFRS Taxonomy maintains a Concept distinction between:

`Raw Materials`

and:

`Production Supplies`

Therefore the following assumption is weakened:

`Supplies are always semantically identical to Raw Materials.`

### Boundary Result

`DISTINCT SOURCE SEMANTIC CONCEPTS`

---

## 17. Adjacent Concept C

## WorkInProcessAndRawMaterialsCAIFRS

Adjacent Concept:

`jpigp_cor:WorkInProcessAndRawMaterialsCAIFRS`

### Official Japanese Standard Label

`仕掛品及び原材料`

### Official English Standard Label

`Work in process and raw materials`

### Semantic Structure

`Work In Process + Raw Materials`

This Concept is materially broader than:

`RawMaterialsCAIFRS`

Therefore:

`WorkInProcessAndRawMaterialsCAIFRS → RawMaterials`

is not approved.

### Important

Substring or Local Name keyword Mapping is prohibited.

---

## 18. Japanese GAAP Boundary

## RawMaterialsAndSupplies

Japanese GAAP Initial Validation repeatedly observed:

`jppfs_cor:RawMaterialsAndSupplies`

Observed Japanese Meaning:

`原材料及び貯蔵品`

This is a Combined Concept.

Current IFRS Source Concept:

`RawMaterialsCAIFRS`

Meaning:

`原材料`

### Research Finding

`RawMaterials`

and:

`RawMaterialsAndSupplies`

are not directly equivalent Source Semantic Concepts.

Therefore:

`jppfs_cor:RawMaterialsAndSupplies → RawMaterials`

must not inherit the current Mapping Approval.

It requires separate Information Loss Review.

---

## 19. Canonical Role Boundary

### Candidate

`RawMaterials`

### Meaning Candidate

`Raw materials held as inventory`

The Source Concept:

`RawMaterialsCAIFRS`

directly fits this Role.

### Alternative Candidate

`Materials`

Concern:

The name is broader and may include non-inventory materials or supplies.

Decision:

`REJECT`

### Alternative Candidate

`IFRSRawMaterials`

Concern:

Accounting Standard should remain a Lineage and Context dimension.

Decision:

`REJECT`

### Preferred Candidate

`RawMaterials`

### Canonical Role Suitability

`PASS`

---

## 20. Information Loss Evaluation

### Source Meaning

`Raw materials - CA (IFRS)`

### Canonical Meaning

`RawMaterials`

### Removed from Canonical Role Name

* IFRS Accounting Standard
* Current Asset qualifier
* Taxonomy family

These remain preserved in Lineage.

### Raw Materials Component Meaning Loss

`NONE IDENTIFIED`

### Overall Information Loss

`Minor`

Reason:

The Canonical Role preserves the direct Raw Materials semantic meaning.

### Mapping Condition

Original Source and Accounting Standard Lineage must remain available.

---

## 21. Semantic Identity vs Accounting Measurement

Current Evidence supports:

`RawMaterialsCAIFRS represents Raw Materials inventory.`

Current Evidence does not prove:

`IFRS and Japanese GAAP measure Raw Materials identically.`

Therefore:

### Semantic Identity

`SUPPORTED`

### Accounting Measurement Equivalence

`NOT EVALUATED`

Semantic Mapping normalizes the financial component meaning.

It does not erase the Accounting Standard dimension.

---

## 22. Semantic Identity vs Metric Comparability

Candidate Mapping:

`RawMaterialsCAIFRS → RawMaterials`

may allow Canonical Observation creation.

However, it does not establish:

`RawMaterialsGrowthYoY`

having identical economic or predictive meaning across companies.

Potential Comparability Dimensions:

* Accounting Standard
* Company
* SubSector
* Business Model
* Production Process
* Procurement Cycle
* Inventory Accounting Policy
* Material Mix

### Kioxia Observation Example

Raw Materials Prior:

`18,486 million JPY`

Raw Materials Current:

`79,093 million JPY`

Derived YoY Candidate:

`approximately +327.83%`

This is a Derived Observation.

The Mapping does not establish the cause of the increase.

Potential explanations such as:

* Production ramp
* Supply constraint hedge
* Demand acceleration
* Strategic procurement

remain:

`NOT ESTABLISHED`

### Research Finding

`Semantic Mapping ≠ Investment Interpretation`

and:

`Semantic Mapping ≠ Metric Comparability Approval`

---

## 23. Double-count Risk Evaluation

### Risk A

`InventoryTotal`

and:

`RawMaterials`

are included in the same Total calculation.

Result:

`Double Count`

Required Governance:

`Total and Component Roles remain separate`

---

### Risk B

`RawMaterialsCAIFRS`

and:

`RawMaterialsAndSuppliesCAIFRS`

appear in the same Filing / Period / Scope.

Potential Overlap:

`HIGH`

Required Governance:

`Conflict Review`

Do not sum automatically.

---

### Risk C

`RawMaterialsCAIFRS`

and:

`WorkInProcessAndRawMaterialsCAIFRS`

coexist.

Potential Overlap:

`HIGH`

Required Governance:

`Conflict Review`

---

### Risk D

A combined Source Fact is decomposed into Raw Materials and Supplies without Source-supported split.

Result:

`Unsupported Synthetic Decomposition`

### Double-count Risk Classification

`HIGH if adjacent combined concepts are not governed`

The risk does not reject the direct Mapping.

---

## 24. Combined Concept Inheritance Rule

Approval of:

`RawMaterialsCAIFRS → RawMaterials`

does not authorize:

`RawMaterialsAndSuppliesCAIFRS → RawMaterials`

or:

`jppfs_cor:RawMaterialsAndSupplies → RawMaterials`

or:

`WorkInProcessAndRawMaterialsCAIFRS → RawMaterials`

Each Combined Concept requires separate Research.

### Prohibited Rule

`Concept contains RawMaterials → RawMaterials`

is rejected.

Mapping must use reviewed:

`Namespace URI + Local Name`

and approved Research Evidence.

---

## 25. Atomic Combined Concept Boundary

This Research reinforces the Principle:

`Combined Source Concept → Atomic Canonical Observation`

unless:

`Source-supported decomposition exists`

Examples requiring separate review:

* `RawMaterialsAndSuppliesCAIFRS`
* `jppfs_cor:RawMaterialsAndSupplies`
* `WorkInProcessAndRawMaterialsCAIFRS`

The current Source Concept:

`RawMaterialsCAIFRS`

is not a Combined Concept.

Therefore Direct Mapping is possible without synthetic decomposition.

---

## 26. Contradicting Evidence Search

Within current reviewed scope:

### Same Concept Used as Inventory Total

`NOT OBSERVED`

### Same Concept Used as Work In Process

`NOT OBSERVED`

### Same Concept Used as Supplies

`NOT OBSERVED`

### Same Concept Used for Non-inventory Meaning

`NOT OBSERVED`

### Standard Label Conflict

`NOT IDENTIFIED`

### English Label Conflict

`NOT IDENTIFIED`

### Period Type Conflict

`NOT IDENTIFIED`

### Filing Note Meaning Conflict

`NOT IDENTIFIED`

### Contradicting Semantic Evidence

`NONE IDENTIFIED within current reviewed scope`

---

## 27. Mapping Confidence Evaluation

### M1 Requirement

* Standard Taxonomy Concept
* Source Label directly matches Canonical Role
* Financial Statement Context consistent

### Evaluation

Standard Taxonomy Concept:

`PASS`

Japanese Standard Label:

`PASS`

English Standard Label:

`PASS`

Structured Element Attributes:

`PASS`

Instant Fact:

`PASS`

Inventory Component Role:

`PASS`

Same-filing Note Cross-reference:

`PASS`

Prior Exact Value Match:

`PASS`

Current Exact Value Match:

`PASS`

Component Reconciliation:

`PASS`

Information Loss:

`NONE MATERIAL`

Adjacent Combined Concept Boundary:

`REVIEWED`

Contradicting Semantic Evidence:

`NONE IDENTIFIED`

### Mapping Confidence Candidate

`M1`

`Direct Standard Mapping`

---

## 28. Researcher Proposal

### Proposed Mapping

`jpigp_cor:RawMaterialsCAIFRS → RawMaterials`

### Proposed Mapping Class

`M1`

`Direct Standard Mapping`

### Proposed Scope

`Validated IFRS eligible Raw Materials inventory component facts`

### Proposed Usage

`Canonical RawMaterials Observation`

### Eligible Usage Requires

* Numeric Fact
* Instant Period Type
* Validated Financial Statement Scope
* Validated Consolidation Scope for common observation
* Validated Monetary Unit
* Source Lineage Preservation

### Adjacent Concept Condition

The following remain separate Research Targets:

* `RawMaterialsAndSuppliesCAIFRS`
* `jppfs_cor:RawMaterialsAndSupplies`
* `WorkInProcessAndRawMaterialsCAIFRS`

---

## 29. Researcher Evidence Summary

### Supporting Evidence

* Official IFRS Standard Taxonomy Concept
* Official Japanese Label `原材料`
* Official English Label `Raw materials`
* Monetary Item Type
* Instant Period Type
* Debit Balance
* Non-abstract Fact Element
* 2024 Official Taxonomy Evidence
* 2025 Official Taxonomy Evidence
* Kioxia Raw XBRL Fact
* Kioxia Inventory Note row `原材料`
* Prior Exact Value Match
* Current Exact Value Match
* Exact Component Sum Reconciliation
* No contradictory semantic evidence identified
* Adjacent Combined Concepts explicitly separated

### Known Limitations

* Current exact Source Concept Filing Evidence is Kioxia-centered.
* Cross-company reproduction is not yet established for this exact Source Concept.
* Accounting Measurement Equivalence is not evaluated.
* Metric Comparability is not evaluated.
* Combined Raw Materials Concepts require separate Research.
* Production Procurement Meaning is not inferred from the Mapping.

### Researcher Decision Candidate

`APPROVE MAPPING`

---

## 30. Independent Research Reviewer Review

### Review Question 1

Was the Mapping accepted only because the Local Name contains `RawMaterials`?

Decision:

`NO`

Evidence includes:

* Official Japanese Standard Label
* Official English Standard Label
* Structured Element Attributes
* Inventory Note Position
* Exact Value Match
* Component Reconciliation

---

### Review Question 2

Were Supplies silently included in RawMaterials?

Decision:

`NO`

The Research explicitly separates:

`RawMaterialsCAIFRS`

from:

`RawMaterialsAndSuppliesCAIFRS`

and:

`ProductionSuppliesCAIFRS`

---

### Review Question 3

Was the Japanese GAAP Combined Concept automatically mapped to RawMaterials?

Decision:

`NO`

`jppfs_cor:RawMaterialsAndSupplies`

remains a separate Research Target.

---

### Review Question 4

Is there Material Information Loss?

Decision:

`NO MATERIAL LOSS IDENTIFIED`

Source Meaning:

`Raw materials`

Canonical Meaning:

`RawMaterials`

Direct semantic correspondence.

---

### Review Question 5

Does Mapping Approval imply that the Kioxia Raw Materials increase is positive or negative?

Decision:

`NO`

The Mapping records financial component identity only.

Investment Interpretation remains separate.

---

### Review Question 6

Is M1 too strong with one validated exact Source Concept Filing?

Reviewer Concern:

`LIMITED CROSS-COMPANY REPRODUCTION`

However M1 is justified by:

* Standard Taxonomy Concept
* Direct Standard Labels
* Structured Attributes
* Strong Same-filing Evidence

Reviewer Condition:

`New contradictory filing usage triggers Mapping Review`

---

### Review Question 7

Does Approval imply cross-company or cross-standard Metric Comparability?

Decision:

`NO`

Metric Comparability remains:

`NOT EVALUATED`

---

## 31. Research Reviewer Decision

`APPROVE`

### Approved Research Mapping Candidate

`jpigp_cor:RawMaterialsCAIFRS → RawMaterials`

### Mapping Confidence

`M1`

`Direct Standard Mapping`

### Scope

`Validated IFRS eligible Raw Materials inventory component facts`

### Usage Candidate

`Canonical RawMaterials Observation`

### Combined Raw Materials Concepts

`NOT APPROVED BY THIS SHEET`

### Metric Comparability

`NOT EVALUATED`

---

## 32. Reviewer Conditions

Approval is subject to the following conditions.

1. Original QName must be preserved.
2. Namespace URI must be preserved.
3. Taxonomy Version must be preserved.
4. Accounting Standard must be preserved.
5. Source Label must remain traceable.
6. Original ContextRef must be preserved.
7. Instant balance semantics must be validated.
8. Consolidated and NonConsolidated observations must remain separate.
9. Monetary Unit must be validated.
10. Decimals must be preserved.
11. InventoryTotal and RawMaterials roles must remain separate.
12. `RawMaterialsAndSuppliesCAIFRS` must not inherit this Mapping.
13. `jppfs_cor:RawMaterialsAndSupplies` must not inherit this Mapping.
14. `WorkInProcessAndRawMaterialsCAIFRS` must not inherit this Mapping.
15. Substring or keyword-based Mapping is prohibited.
16. Multiple RawMaterials-related candidates in the same Filing / Period / Scope require Conflict Review.
17. Unsupported synthetic decomposition is prohibited.
18. Future non-current Raw Materials evidence triggers Boundary Review.
19. New Taxonomy Versions require Version Change Review.
20. Mapping Approval does not prove Accounting Measurement Equivalence.
21. Mapping Approval does not prove Metric Comparability.
22. Mapping Approval does not establish Investment Interpretation.
23. Mapping Approval does not authorize Production implementation.

---

## 33. Mapping Approval Gate Result

| Gate Item                     | Result        |
| ----------------------------- | ------------- |
| Source Concept Identity       | CONFIRMED     |
| Eligibility                   | PASS          |
| Financial Meaning Evidence    | SUFFICIENT    |
| Official Taxonomy Evidence    | PASS          |
| Canonical Role Candidate      | DEFINED       |
| Information Loss              | NONE MATERIAL |
| Adjacent Concept Boundary     | REVIEWED      |
| Double-count Risk             | EVALUATED     |
| Contradicting Evidence        | REVIEWED      |
| Taxonomy Version              | RECORDED      |
| Accounting Standard Boundary  | RECORDED      |
| Metric Comparability Boundary | RECORDED      |
| Reviewer Decision             | APPROVE       |

### Gate Result

`PASS`

---

## 34. Architecture Reviewer Requirement

### Canonical Role Addition

`NO`

`RawMaterials` already exists in the Research Canonical Role Candidate Set.

### Canonical Role Split

`NO`

### Mapping Model Change

`NO`

### Lineage Requirement Change

`NO`

### Adjacent Combined Concept Governance

Already defined in the Semantic Mapping Research Design.

Therefore:

`Architecture Reviewer Additional Gate: NOT REQUIRED`

Existing Research Architecture Boundary内でApproval可能。

---

## 35. Final Mapping Research Result

### Source Concept

`jpigp_cor:RawMaterialsCAIFRS`

### Canonical Semantic Role

`RawMaterials`

### Mapping Class

`M1`

`DIRECT STANDARD MAPPING`

### Research Reviewer

`APPROVE`

### Mapping Gate

`PASS`

### Combined Raw Materials Concept Mapping

`NOT APPROVED`

### Metric Comparability

`NOT EVALUATED`

### Investment Interpretation

`NOT EVALUATED`

### Production Mapping

`NOT YET APPROVED`

---

## 36. Direct Raw Materials Mapping Procedure Evaluation

This Sheet is the first Direct Raw Materials Standard Concept Mapping Case.

### Procedure Evaluation

Official Taxonomy Evidence Review:

`WORKED`

Source Identity Review:

`WORKED`

Eligibility Review:

`WORKED`

Filing Note Cross-reference:

`WORKED`

Adjacent Supplies Boundary Review:

`WORKED`

Combined Concept Boundary Review:

`WORKED`

Information Loss Review:

`WORKED`

Metric Comparability Separation:

`WORKED`

Investment Interpretation Separation:

`WORKED`

Double-count Conflict Review:

`WORKED`

Reviewer Independence Review:

`WORKED`

### Result

`PASS`

---

## 37. Current Canonical Semantic Role Set

Approved Research Canonical Roles:

* `InventoryTotal`
* `FinishedGoods`
* `WorkInProcess`
* `RawMaterials`
* `Other`
* `MerchandiseAndFinishedGoods`

### Current `RawMaterials` Support

Approved Research Mapping:

`jpigp_cor:RawMaterialsCAIFRS → RawMaterials`

### Research Status

`IFRS STANDARD ROLE SUPPORTED`

### Cross-standard Support

`NOT YET ESTABLISHED`

Reason:

Japanese GAAP Initial Validation primarily observed:

`jppfs_cor:RawMaterialsAndSupplies`

which is a Combined Concept.

---

## 38. Current Mapping Research State

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

### 5

`jppfs_cor:MerchandiseAndFinishedGoods → MerchandiseAndFinishedGoods`

Class:

`M1`

Status:

`APPROVED`

### 6

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS → MerchandiseAndFinishedGoods`

Class:

`M1`

Status:

`APPROVED`

### 7

`jpigp_cor:RawMaterialsCAIFRS → RawMaterials`

Class:

`M1`

Status:

`APPROVED`

Important:

`Approved Research Mapping ≠ Production Mapping Master Entry`

Catalog / DDL / Entityへの登録はまだ行わない。

---

## 39. Exact Next Task

次のMapping Research Targetは以下とする。

`jppfs_cor:RawMaterialsAndSupplies`

### Initial Canonical Semantic Role Candidate

`RawMaterials`

### Alternative Canonical Semantic Role Candidate

`RawMaterialsAndSupplies`

### Initial Mapping Class Candidate

`M2`

`Strongly Supported Semantic Mapping`

### Research Purpose

> Japanese GAAPで5社に再現したCombined Inventory Concept `原材料及び貯蔵品`について、`RawMaterials`へCanonical SimplificationすることによるInformation Lossが許容可能かを検証する。

### Research Focus

* Official Standard Label
* Raw Materials / Supplies combined meaning
* Five-company cross-company reproduction
* `RawMaterialsCAIFRS`とのSemantic Boundary
* Information Loss materiality
* Inventory composition metric distortion
* Production Supplies distinction
* Independent Canonical Role necessity
* Atomic Combined Concept Principle
* M2 Approval可否

### Important

以下を既定路線としない。

`jppfs_cor:RawMaterialsAndSupplies → RawMaterials`

The following candidates remain open:

* `RawMaterials`
* `RawMaterialsAndSupplies`
* New Canonical Role
* Conditional Mapping
* Unmapped

### Primary Reviewer Gate

`Information Loss Review`
