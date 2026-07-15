# Inventory Semantic Mapping Research Sheet

# jpigp_cor:OtherInventoriesCAIFRS

## 1. Document Purpose

本書は、EDINET Inventory Semantic Mapping Research Designに基づき、

`jpigp_cor:OtherInventoriesCAIFRS`

をCanonical Inventory Semantic RoleへMapping可能か検証するResearch Sheetである。

本Researchでは、既存Canonical Role Candidateである、

`Other`

のSemantic Precisionが十分かをPrimary Gateとして評価する。

### Initial Mapping Candidate

`jpigp_cor:OtherInventoriesCAIFRS → Other`

### Alternative Canonical Semantic Role Candidate

`OtherInventories`

本書の目的はProduction Mapping Masterを作成することではない。

目的は以下である。

> IFRS Standard TaxonomyのOther Inventories Conceptについて、Source Meaning、Kioxia Filing Evidence、Canonical Role Naming Precision及び将来のCross-domain Conflict Riskを評価し、`Other`へのMapping、`OtherInventories`へのRole修正、Conditional MappingまたはUnmappedのいずれがEvidence上妥当かを判断する。

### Status

* Research Sheet
* Semantic Mapping Research
* IFRS Standard Component Mapping
* Canonical Role Precision Review
* Architecture Reviewer Gate Candidate
* Production Mapping Not Approved

---

## 2. Research Target

### Source Concept QName

`jpigp_cor:OtherInventoriesCAIFRS`

### Local Name

`OtherInventoriesCAIFRS`

### Prefix

`jpigp_cor`

### Accounting Standard

`IFRS`

### Initial Canonical Semantic Role Candidate

`Other`

### Alternative Canonical Semantic Role Candidate

`OtherInventories`

### Initial Mapping Confidence Candidate

`M1 Candidate`

Important:

`M1`はSource MeaningとのDirect Mapping Candidateを示す。

しかし、Canonical Role名そのものが不適切な場合、Mapping Confidence以前にRole Boundaryを修正する必要がある。

---

## 3. Primary Research Question

Primary Question:

> Is `Other` semantically precise enough to represent `Other Inventories`, or should the Canonical Role be renamed to `OtherInventories`?

Sub Questions:

1. Source ConceptはInventory Domainを明示しているか。
2. `Other`だけでそのDomain Meaningを保持できるか。
3. 将来の`OtherAssets`、`OtherRevenue`、`OtherLiabilities`等とConflictするか。
4. Kioxia Filing Evidenceは`Other Inventories`としての意味を支持するか。
5. `OtherInventories`はSource Meaningをより正確に保持するか。
6. Existing Canonical Role `Other`を修正するArchitecture Impactは許容可能か。
7. M1 Direct MappingはどのRole名に対して妥当か。

---

## 4. Evidence Hierarchy

本Researchでは以下のEvidence Priorityを採用する。

### Priority 1

Official EDINET IFRS Taxonomy Evidence

Includes:

* Source Concept Identity
* Official Label
* Data Type
* Period Type
* Balance Attribute
* Taxonomy Position

### Priority 2

Validated Filing Evidence

Primary Company:

`Kioxia Holdings Corporation`

Document ID:

`S100YJ18`

### Priority 3

Inventory Note Context

Purpose:

* Disclosed Row Meaning
* Exact Value Match
* Component Sum Reconciliation

### Priority 4

Canonical Role Architecture Review

Purpose:

* Domain Precision
* Future Naming Conflict
* Cross-component Consistency

### Priority 5

Schema Simplicity

Classification:

`NOT PRIMARY EVIDENCE`

Shorter Role names are not automatically better.

---

## 5. Source Concept Identity

### QName

`jpigp_cor:OtherInventoriesCAIFRS`

### Namespace Family

`jpigp`

### Local Name

`OtherInventoriesCAIFRS`

### Official Japanese Standard Label Candidate

`その他の棚卸資産`

### Official English Standard Label Candidate

`Other inventories`

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

## 6. Source Semantic Structure

The Source Concept explicitly contains:

`Other`

and:

`Inventories`

Therefore the Source Meaning is not:

`Other`

in a generic sense.

The Source Meaning is:

`Other Inventories`

### Domain

`Inventory`

### Component Position

`Residual / Other Inventory Component`

### Initial Finding

`Inventory Domain is part of the Source Semantic Identity`

---

## 7. Filing Evidence Scope

### Company

キオクシアホールディングス株式会社

`Kioxia Holdings Corporation`

### Security Code

`285A0`

### EDINET Code

`E35948`

### Document ID

`S100YJ18`

### Accounting Standard

`IFRS`

### Consolidation Scope

`Consolidated`

### Filing Identity

`CONFIRMED`

---

## 8. Kioxia Raw Financial Facts

### Prior

QName:

`jpigp_cor:OtherInventoriesCAIFRS`

ContextRef:

`Prior1YearInstant`

UnitRef:

`JPY`

Decimals:

`-6`

Raw Value:

`82000000`

### Current

QName:

`jpigp_cor:OtherInventoriesCAIFRS`

ContextRef:

`CurrentYearInstant`

UnitRef:

`JPY`

Decimals:

`-6`

Raw Value:

`104000000`

### Classification

* Numeric Fact
* Instant Fact
* Consolidated IFRS Fact
* Monetary Fact
* JPY

### Eligibility Candidate

`Eligible Inventory Component Fact`

---

## 9. Kioxia Inventory Note Context

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

`jpigp_cor:OtherInventoriesCAIFRS`

matched the Inventory Note row:

`その他`

within the Inventory Note.

### Prior Value Match

`82 million JPY`

Result:

`EXACT MATCH`

### Current Value Match

`104 million JPY`

Result:

`EXACT MATCH`

### Research Finding

The row label `その他` must be interpreted within its Inventory Note context.

The standalone display text:

`その他`

does not remove the Source Concept’s domain meaning:

`Other Inventories`

### Classification

`Strong Same-filing Contextual Semantic Evidence`

---

## 10. Component Sum Reconciliation

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

`OtherInventoriesCAIFRS`

being an Inventory Component.

It does not define the internal composition of the Other Inventories balance.

---

## 11. Inventory Component Eligibility

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

## 12. Candidate A Review

## Other

### Proposed Mapping

`OtherInventoriesCAIFRS → Other`

### Potential Benefit

* Short Canonical Role name
* Existing Role already present in the Candidate Set
* Simple implementation

### Primary Problem

`Other`

does not preserve the Domain:

`Inventories`

### Potential Future Conflicts

* `OtherAssets`
* `OtherCurrentAssets`
* `OtherNonCurrentAssets`
* `OtherRevenue`
* `OtherExpenses`
* `OtherLiabilities`
* `OtherEquity`
* `OtherCashFlowItems`

### Semantic Precision Risk

`HIGH`

### Architecture Finding

A Canonical Semantic Role should identify both:

`Domain`

and:

`Semantic Meaning`

where generic naming would create ambiguity.

### Candidate A Evaluation

`SEMANTICALLY UNDER-SPECIFIED`

---

## 13. Candidate B Review

## OtherInventories

### Proposed Mapping

`OtherInventoriesCAIFRS → OtherInventories`

### Source Meaning

`Other inventories`

### Canonical Meaning

`OtherInventories`

### Domain Preservation

`PASS`

### Component Meaning Preservation

`PASS`

### Future Cross-domain Conflict Risk

`LOWER`

### Information Loss

`NONE MATERIAL`

### Candidate B Evaluation

`SEMANTICALLY PRECISE`

---

## 14. Canonical Naming Consistency Review

Current Canonical Role Candidates include:

* `InventoryTotal`
* `FinishedGoods`
* `WorkInProcess`
* `RawMaterials`
* `MerchandiseAndFinishedGoods`
* `RawMaterialsAndSupplies`

These names are Domain-specific enough because their meanings are inherently inventory-related.

However:

`Other`

is not inherently inventory-specific.

### Naming Consistency Finding

The role:

`OtherInventories`

is more consistent with the existing Canonical Role naming philosophy than:

`Other`

because it preserves the Domain where the semantic term itself is generic.

---

## 15. Information Loss Evaluation

## Candidate A: Other

### Source Meaning

`Other Inventories`

### Canonical Meaning

`Other`

### Removed Meaning

`Inventories`

### Information Loss

`MATERIAL CANDIDATE`

Reason:

The Domain identity is removed.

A downstream consumer could not determine whether the value represents:

* Other Inventories
* Other Assets
* Other Revenue
* Other Financial Items

without relying on external context.

### Lineage Mitigation

Original QName and Source Label may remain available.

However:

Canonical Role itself would remain semantically ambiguous.

### Current Decision

`Information Loss concern remains material`

---

## 16. Information Loss Evaluation

## Candidate B: OtherInventories

### Source Meaning

`Other Inventories`

### Canonical Meaning

`OtherInventories`

### Removed Meaning

`None Material Identified`

### Information Loss

`NONE`

### Current Decision

`Meaning-preserving Candidate`

---

## 17. Generic Role Name Risk

Generic roles such as:

`Other`

create a hidden dependence on surrounding context.

Example:

`CanonicalRole = Other`

cannot be safely interpreted without also knowing:

`Domain = Inventory`

This increases:

* Query ambiguity
* Feature naming ambiguity
* Catalog ambiguity
* API ambiguity
* ML feature collision risk
* Advisor explanation ambiguity

### Architecture Principle Candidate

`Canonical Semantic Role names should be self-describing when the semantic token is otherwise generic.`

Examples:

Prefer:

* `OtherInventories`
* `OtherAssets`
* `OtherRevenue`

over:

* `Other`

when Domain ambiguity exists.

---

## 18. Metric Naming Risk

If the Canonical Role is:

`Other`

a Derived Metric might become:

`OtherGrowthYoY`

This is semantically unclear.

If the Canonical Role is:

`OtherInventories`

the Derived Metric becomes:

`OtherInventoriesGrowthYoY`

This is materially clearer.

### Research Finding

Canonical Role naming affects downstream:

* Metric Names
* Feature Names
* Catalog Entries
* Advisor Explanations

Therefore Role Precision is not cosmetic.

---

## 19. Investment Interpretation Boundary

`OtherInventories`

does not itself explain what is inside the balance.

Possible contents may vary by company.

Therefore:

`OtherInventories`

should not be interpreted as a stable economic subcomponent without additional disclosure.

### Semantic Mapping Result

The Role identifies:

`Residual inventory component`

It does not identify:

`Internal composition`

### Investment Interpretation

`NOT ESTABLISHED`

---

## 20. Cross-company Comparability Boundary

Even if multiple companies use:

`OtherInventories`

the internal contents may differ.

Therefore:

`OtherInventories Growth`

may have weak direct comparability across companies.

### Research Finding

`Semantic Role Consistency ≠ Internal Composition Consistency`

### Metric Comparability

`NOT EVALUATED`

### ML Use

`NOT APPROVED`

---

## 21. Double-count Risk Evaluation

### Risk A

`InventoryTotal`

and:

`OtherInventories`

included in the same Total calculation.

Result:

`Double Count`

Required Governance:

`Total and Component Roles remain separate`

---

### Risk B

A company discloses specific inventory components plus:

`OtherInventories`

The `OtherInventories` balance may already represent residual items excluding the specific components.

### Required Governance

Do not decompose or redistribute without Source Evidence.

---

### Risk C

Multiple residual concepts map to:

`OtherInventories`

within the same Filing / Period / Scope.

### Required Governance

`Conflict Review`

### Double-count Risk Classification

`Medium`

---

## 22. Contradicting Evidence Search

### Evidence that Source Concept means a non-inventory Other category

`NOT IDENTIFIED`

### Evidence that generic `Other` is the official semantic concept

`NOT IDENTIFIED`

### Evidence that Inventory Domain may be safely removed

`NOT IDENTIFIED`

### Same-filing Context Conflict

`NOT IDENTIFIED`

### Contradicting Semantic Evidence

`NONE IDENTIFIED within current reviewed scope`

---

## 23. Mapping Confidence Evaluation

## Candidate A

Mapping:

`jpigp_cor:OtherInventoriesCAIFRS → Other`

### Evaluation

Source Meaning Clear:

`PASS`

Canonical Meaning Direct Match:

`FAIL`

Domain Preservation:

`FAIL`

Information Loss:

`MATERIAL CANDIDATE`

Future Semantic Conflict Risk:

`HIGH`

### Candidate A Result

`FAIL`

---

## 24. Mapping Confidence Evaluation

## Candidate B

Mapping:

`jpigp_cor:OtherInventoriesCAIFRS → OtherInventories`

### Evaluation

Standard Taxonomy Concept:

`PASS`

Canonical Meaning Directly Matches Source Meaning:

`PASS`

Inventory Component Role:

`PASS`

Same-filing Evidence:

`PASS`

Exact Value Match:

`PASS`

Component Reconciliation:

`PASS`

Information Loss:

`NONE MATERIAL`

Domain Precision:

`PASS`

### Candidate B Result

`STRONGLY SUPPORTED`

### Mapping Class Candidate

`M1`

`Direct Meaning-preserving Mapping`

---

## 25. Researcher Proposal

### Reject Existing Canonical Role Mapping

`jpigp_cor:OtherInventoriesCAIFRS → Other`

### Proposed Decision

`REJECT`

### Reason

`Canonical Role is semantically under-specified`

and:

`Inventory Domain meaning is removed`

---

### Proposed Canonical Role Replacement

Replace Research Canonical Role:

`Other`

with:

`OtherInventories`

### Proposed Mapping

`jpigp_cor:OtherInventoriesCAIFRS → OtherInventories`

### Proposed Mapping Class

`M1`

`Direct Meaning-preserving Mapping`

### Architecture Impact

`Canonical Role Rename / Replacement Required`

Therefore:

`Architecture Reviewer Gate = REQUIRED`

---

## 26. Researcher Evidence Summary

### Supporting Evidence

* IFRS Standard Taxonomy Concept
* Source Concept explicitly contains Inventory Domain
* Official semantic meaning `Other inventories`
* Kioxia exact Raw XBRL Fact
* Kioxia Inventory Note context
* Exact prior value match
* Exact current value match
* Exact component sum reconciliation
* Generic `Other` creates future cross-domain ambiguity
* `OtherInventories` preserves Source Meaning
* Derived Metric naming becomes clearer

### Known Limitations

* Current Filing Evidence is Kioxia-centered.
* Internal composition of Other Inventories is unknown.
* Cross-company Metric Comparability is not established.
* Investment interpretation is not established.

### Researcher Decision

`REJECT Other`

and:

`PROPOSE OtherInventories`

---

## 27. Independent Research Reviewer Review

### Review Question 1

Is `OtherInventories` merely a more verbose name?

Decision:

`NO`

The additional word:

`Inventories`

preserves the Source Domain.

The difference is semantic, not cosmetic.

---

### Review Question 2

Could Domain be stored separately instead of in the Role name?

Decision:

`POSSIBLE IN FUTURE ARCHITECTURE`

However:

The current Canonical Role model is self-describing and does not yet define a separate mandatory Domain dimension.

Using:

`Other`

would therefore introduce ambiguity into the existing Research Architecture.

### Current Decision

`Use OtherInventories`

---

### Review Question 3

Would renaming the Role create unnecessary churn?

Decision:

`NO MATERIAL IMPLEMENTATION CHURN`

Reason:

Production Mapping Master, DDL and Entity have not yet been created.

This is precisely the correct Research phase to correct Role precision.

---

### Review Question 4

Could `Other` remain as a generic umbrella role?

Decision:

`NOT SUPPORTED`

A generic umbrella role would mix unrelated domains unless a separate hierarchical semantic model is designed.

No such Architecture is currently approved.

---

### Review Question 5

Does OtherInventories imply comparable composition across companies?

Decision:

`NO`

The Role identifies the residual Inventory domain only.

Internal composition remains company-specific.

---

## 28. Research Reviewer Decision

### Existing Candidate

`jpigp_cor:OtherInventoriesCAIFRS → Other`

Decision:

`REJECT`

Reason:

`Semantic Under-specification`

---

### Replacement Candidate

`jpigp_cor:OtherInventoriesCAIFRS → OtherInventories`

Research Reviewer Decision:

`CONDITIONAL APPROVE PENDING ARCHITECTURE REVIEW`

### Mapping Confidence Candidate

`M1`

`Direct Meaning-preserving Mapping`

---

## 29. Architecture Reviewer Gate

### Canonical Role Addition

`YES`

Proposed Role:

`OtherInventories`

### Existing Role Removal / Replacement

`YES`

Replace:

`Other`

with:

`OtherInventories`

### Semantic Role Set Change

`YES`

### Production Migration Impact

`NONE`

Reason:

Production Mapping Master is not yet implemented.

### Potential Downstream Impact

* Research Canonical Role List
* Future Catalog
* Future DDL
* Future Entity
* Derived Metric Names
* ML Feature Names
* Advisor Explanation Names

Therefore:

`Architecture Reviewer Gate = REQUIRED`

---

## 30. Architecture Reviewer Evaluation

### Question 1

Does `OtherInventories` directly preserve Source Meaning?

Decision:

`YES`

---

### Question 2

Is `Other` sufficiently self-describing?

Decision:

`NO`

---

### Question 3

Could future cross-domain collisions occur?

Decision:

`YES`

Examples:

* Other Assets
* Other Revenue
* Other Expenses
* Other Liabilities

---

### Question 4

Is this the correct phase to change the Role?

Decision:

`YES`

The project is still:

* Pre-Catalog
* Pre-DDL
* Pre-Entity
* Pre-Production Mapping

---

### Question 5

Does Role precision improve long-term architecture?

Decision:

`YES`

It improves:

* Catalog clarity
* Data lineage readability
* Feature naming
* Advisor explanations
* Conflict avoidance

---

## 31. Architecture Reviewer Decision

`APPROVE CANONICAL ROLE REPLACEMENT`

### Remove Research Canonical Role

`Other`

### Add Research Canonical Role

`OtherInventories`

### Role Meaning

`Residual or other inventory component`

### Status

`APPROVED RESEARCH CANONICAL ROLE`

### Production Master Status

`NOT APPROVED`

---

## 32. Final Mapping Research Result

### Rejected Mapping

`jpigp_cor:OtherInventoriesCAIFRS → Other`

Decision:

`REJECT`

---

### Approved Research Mapping

`jpigp_cor:OtherInventoriesCAIFRS → OtherInventories`

### Mapping Class

`M1`

`DIRECT MEANING-PRESERVING MAPPING`

### Research Reviewer

`APPROVE`

### Architecture Reviewer

`APPROVE CANONICAL ROLE REPLACEMENT`

### Mapping Gate

`PASS`

### Internal Composition

`UNKNOWN / COMPANY-SPECIFIC`

### Metric Comparability

`NOT EVALUATED`

### Production Mapping

`NOT YET APPROVED`

---

## 33. Reviewer Conditions

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
11. `OtherInventories` must remain within the Inventory domain.
12. Internal composition must not be inferred without Source Evidence.
13. `OtherInventories` must not be treated as semantically equivalent to other `Other*` financial concepts.
14. InventoryTotal and OtherInventories roles must remain separate.
15. Multiple residual Inventory Concepts require Conflict Review.
16. New Taxonomy Versions require Version Change Review.
17. Mapping Approval does not prove Composition Equivalence.
18. Mapping Approval does not prove Metric Comparability.
19. Mapping Approval does not establish Investment Interpretation.
20. Mapping Approval does not authorize Production implementation.

---

## 34. Mapping Approval Gate Result

### Existing Candidate

| Gate Item                | Result             |
| ------------------------ | ------------------ |
| Source Concept Identity  | CONFIRMED          |
| Eligibility              | PASS               |
| Canonical Role Precision | FAIL               |
| Domain Preservation      | FAIL               |
| Information Loss         | MATERIAL CANDIDATE |
| Reviewer Decision        | REJECT             |

### Existing Candidate Gate Result

`FAIL`

---

### Replacement Candidate

| Gate Item                  | Result        |
| -------------------------- | ------------- |
| Source Concept Identity    | CONFIRMED     |
| Eligibility                | PASS          |
| Financial Meaning Evidence | SUFFICIENT    |
| Canonical Role Precision   | PASS          |
| Domain Preservation        | PASS          |
| Information Loss           | NONE MATERIAL |
| Filing Evidence            | PASS          |
| Component Reconciliation   | PASS          |
| Research Reviewer          | APPROVE       |
| Architecture Reviewer      | APPROVE       |

### Replacement Candidate Gate Result

`PASS`

---

## 35. Research Architecture Finding

This Research identifies a new Architecture Principle.

### Principle

`Generic Canonical Role names should not remove the financial domain when the remaining term becomes ambiguous.`

Example:

Reject:

`Other`

Prefer:

`OtherInventories`

### Reason

Canonical Semantic Roles are used downstream in:

* Catalog
* Dataset
* Metrics
* ML Features
* Decision Logic
* Advisor Explanation

Semantic precision at the Canonical Layer reduces ambiguity throughout the system.

### Status

`Approved Research Architecture Finding`

### Production Rule Status

`NOT YET APPROVED`

---

## 36. Updated Canonical Semantic Role Set

Approved Research Canonical Roles:

* `InventoryTotal`
* `FinishedGoods`
* `WorkInProcess`
* `RawMaterials`
* `OtherInventories`
* `MerchandiseAndFinishedGoods`
* `RawMaterialsAndSupplies`

### Removed Role

`Other`

### Replacement Role

`OtherInventories`

### Production Status

`NOT APPROVED`

---

## 37. Current Mapping Research State

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

### 8

`jppfs_cor:RawMaterialsAndSupplies → RawMaterialsAndSupplies`

Class:

`M1`

Status:

`APPROVED`

### 9

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS → RawMaterialsAndSupplies`

Class:

`M1`

Status:

`APPROVED`

### 10

`jpigp_cor:OtherInventoriesCAIFRS → OtherInventories`

Class:

`M1`

Status:

`APPROVED`

### Rejected Candidates

`jppfs_cor:MerchandiseAndFinishedGoods → FinishedGoods`

`jppfs_cor:RawMaterialsAndSupplies → RawMaterials`

`jpigp_cor:OtherInventoriesCAIFRS → Other`

Important:

`Approved Research Mapping ≠ Production Mapping Master Entry`

---

## 38. Exact Next Task

次のMapping Research Targetは以下とする。

`SemiFinishedProductsAndWorkInProgressCAIFRS`

### Source Type

`Company Extension Concept`

### Observed Company

`Kioxia Holdings`

### Canonical Semantic Role Candidate

`WorkInProcess`

### Mapping Class Candidate

`M3`

`Company Extension Reviewed`

### Research Purpose

> Initial 7-company Validationで確認した最初のCompany Extension Inventory Componentについて、Company Extension Research Procedureを実際に適用し、`WorkInProcess`へのMappingがEvidence上妥当か判定する。

### Mandatory Research Gates

* Extension Namespace Confirmation
* Exact Filing Identity
* Source Label Review
* Inventory Note Cross-reference
* Component Sum Reconciliation
* Official Standard Concept Comparison
* Information Loss Review
* `SemiFinishedProducts` Meaning Review
* `WorkInProcessCAIFRS` Boundary
* Atomic Combined Concept Principle
* Company-specific Scope Review
* Architecture Reviewer Review if Canonical Role Boundary changes

### Important

以下を前提にしない。

`SemiFinishedProductsAndWorkInProgressCAIFRS → WorkInProcess`

The following outcomes remain open:

* `WorkInProcess`
* `SemiFinishedProductsAndWorkInProgress`
* New Canonical Role
* Conditional Company-specific Mapping
* Unmapped

### Primary Gate

`Company Extension Semantic Meaning Review`

### Mapping Approval Status

`NOT STARTED`
