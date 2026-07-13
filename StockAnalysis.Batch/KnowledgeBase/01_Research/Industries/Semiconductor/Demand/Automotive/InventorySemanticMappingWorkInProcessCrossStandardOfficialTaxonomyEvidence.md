# Inventory Semantic Mapping Work In Process Cross-standard Official Taxonomy Evidence Review

## 1. Document Purpose

本書は、以下のJapanese GAAP及びIFRS Source Conceptについて、金融庁が公表するEDINET公式Taxonomy資料をPrimary Evidenceとして確認し、Canonical Semantic RoleへのCross-standard Semantic Mapping Researchを継続可能か判定するOfficial Taxonomy Evidence Review Artifactである。

### Japanese GAAP Source Concept

`jppfs_cor:WorkInProcess`

### IFRS Source Concept

`jpigp_cor:WorkInProcessCAIFRS`

### Canonical Semantic Role Candidate

`WorkInProcess`

本書の目的はProduction Mappingを承認することではない。

目的は以下である。

> Japanese GAAP及びIFRSの異なるTaxonomy Familyに属するWork In Process Conceptについて、公式要素属性、公式ラベル、Period Type、Balance Attribute、Taxonomy Version及びEDINET要素概念定義方針を比較し、Semantic Equivalence Research Sheetへ進むためのEvidence Gateを評価する。

### Status

* Research Evidence Artifact
* Official Taxonomy Review
* Cross-standard Semantic Equivalence Pre-review
* Pre-Catalog
* Pre-DDL
* Final Mapping Not Yet Approved

---

## 2. Official Source Scope

本Reviewでは、金融庁公表の以下資料をPrimary Sourceとした。

* 2025年版EDINETタクソノミ 勘定科目リスト
* 2025年版EDINETタクソノミ 国際会計基準タクソノミ要素リスト
* 2024年版EDINETタクソノミ 勘定科目リスト
* 2024年版EDINETタクソノミ 国際会計基準タクソノミ要素リスト
* 報告項目及び勘定科目の取扱いに関するガイドライン 2024年11月

### Source Authority

Financial Services Agency
金融庁

### Evidence Classification

* Primary Source
* Official Taxonomy Evidence

---

## 3. EDINET Taxonomy Evidence Principle

金融庁の「報告項目及び勘定科目の取扱いに関するガイドライン」では、EDINET Taxonomyの要素概念について、以下の情報等から総合的に理解すべきものとされている。

* 冗長ラベル
* 参照リンク情報
* 定義リンク上の位置付け
* 表示リンク上の位置付け
* ドキュメンテーションラベル

Therefore:

`Concept Local Name Similarity alone is not sufficient semantic evidence.`

本ReviewではConcept NameのみでCross-standard Mappingを判断しない。

---

## 4. EDINET Concept Difference Principle

Official Guidelineでは、以下は原則として異なる要素概念とはみなさない。

* Unit Difference
* Period / Instant Presentation Difference
* Aggregation Label Difference
* Positive / Negative Label Difference
* Matters represented by dimensions

### Dimension Example

* Consolidated
* NonConsolidated
* Segment

Important:

これは以下を意味しない。

`Context validation is unnecessary.`

Source Concept MeaningとFact Eligibilityを分離する。

`Semantic Concept Identity ≠ Fact Eligibility`

Original Context及びDimension Evidenceは保持する。

---

## 5. Japanese GAAP Source Concept

### QName

`jppfs_cor:WorkInProcess`

### Prefix

`jppfs_cor`

### Local Name

`WorkInProcess`

### Official Japanese Label

`仕掛品`

### Official English Label

`Work in process`

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

### Official Taxonomy Classification

* Japanese GAAP
* Financial Statement Primary Table Taxonomy
* Standard Concept

---

## 6. Japanese GAAP Financial Meaning Candidate

### Official Label

`仕掛品`

### English Label

`Work in process`

### Observed Financial Statement Function

`Inventory Component`

### Observed Filing Evidence

* ROHM
* Fuji Electric
* Sanken Electric
* Torex Semiconductor
* Tokyo Electron

### Observed Meaning

* Goods in the production process
* Inventory Component

### Existing Research Mapping

`jppfs_cor:WorkInProcess → WorkInProcess`

Mapping Class:

`M1`

Research Reviewer Decision:

`APPROVED RESEARCH MAPPING`

---

## 7. IFRS Source Concept

### QName

`jpigp_cor:WorkInProcessCAIFRS`

### Prefix

`jpigp_cor`

### Local Name

`WorkInProcessCAIFRS`

### Official Japanese Standard Label

`仕掛品`

### Official Japanese Verbose Label

`仕掛品、流動資産（IFRS）`

### Official English Standard Label

`Work in process`

### Official English Verbose Label

`Work in process - CA (IFRS)`

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

### Official Taxonomy Classification

* IFRS
* International Accounting Standards Taxonomy
* Standard Concept

---

## 8. Official Element Attribute Comparison

| Attribute               | J-GAAP           | IFRS             |
| ----------------------- | ---------------- | ---------------- |
| Japanese Standard Label | 仕掛品              | 仕掛品              |
| English Standard Label  | Work in process  | Work in process  |
| Data Type               | monetaryItemType | monetaryItemType |
| Substitution Group      | item             | item             |
| Period Type             | instant          | instant          |
| Balance                 | debit            | debit            |
| Abstract                | false            | false            |

### Comparison Result

`Official Element Attribute Alignment: STRONG`

### Direct Differences

* Taxonomy Family
* Local Name Suffix: `CAIFRS`
* IFRS Verbose Label: `流動資産（IFRS）`

---

## 9. Standard Label Equivalence

### Japanese GAAP

Japanese:

`仕掛品`

English:

`Work in process`

### IFRS

Japanese:

`仕掛品`

English:

`Work in process`

### Result

`Standard Label: EXACT SEMANTIC ALIGNMENT OBSERVED`

This is stronger evidence than Local Name similarity alone.

However:

`Same Standard Label ≠ Accounting Measurement Rules Identical`

Measurement Equivalence is outside this Review.

---

## 10. Period Type Comparison

### Japanese GAAP

`instant`

### IFRS

`instant`

Both Concepts represent balance observations at a point in time.

### Result

`Period Type: ALIGNED`

This supports Inventory Stock Component semantic compatibility.

The following Duration Facts remain separate.

* `DecreaseIncreaseInInventoriesOpeCF`
* `DecreaseIncreaseInInventoriesOpeCFIFRS`

Therefore:

`WorkInProcess Balance Fact ≠ Inventory Change Cash Flow Fact`

---

## 11. Data Type Comparison

### Japanese GAAP

`xbrli:monetaryItemType`

### IFRS

`xbrli:monetaryItemType`

### Result

`Financial Value Type: ALIGNED`

Both Concepts are monetary items.

Unit validation remains mandatory at Fact Eligibility Layer.

`Semantic Mapping does not replace Unit Validation.`

---

## 12. Balance Attribute Comparison

### Japanese GAAP

`debit`

### IFRS

`debit`

### Result

`Balance Attribute: ALIGNED`

This is consistent with an inventory asset component role.

Balance Attribute alone is not used as Semantic Proof.

It is Supporting Structured Evidence.

---

## 13. Abstract Status Comparison

### Japanese GAAP

`false`

### IFRS

`false`

Both are usable Fact Concepts rather than abstract title elements.

### Result

`Fact Element Eligibility Candidate: ALIGNED`

---

## 14. IFRS Current Asset Qualifier

IFRS Verbose Label:

`仕掛品、流動資産（IFRS）`

English:

`Work in process - CA (IFRS)`

Japanese GAAP standard label does not contain the same Current Asset qualifier.

### Research Question

> Does the current asset qualifier materially change the inventory-stage semantic identity?

### Official Element Attribute Evidence

Japanese Standard Label:

`仕掛品`

IFRS Standard Label:

`仕掛品`

English Standard Label:

`Work in process`

for both concepts.

### Observed Filing Role

`Inventory Component`

### Current Reviewer Interpretation

The Current Asset qualifier is a presentation or classification distinction in the IFRS verbose label.

It does not currently contradict the `WorkInProcess` inventory-stage semantic identity.

### Classification

`Supported Interpretation`

### Not Proven

Current asset classification is economically irrelevant for all downstream analysis.

### Future Trigger

`Non-current Work In Process Concept detected → Canonical Role Boundary Review`

---

## 15. Adjacent Concept Review

Japanese GAAP Inventory Concept Set includes candidates such as:

* `Merchandise`
* `FinishedGoods`
* `MerchandiseAndFinishedGoods`
* `WorkInProcess`
* `RawMaterialsAndSupplies`
* `Supplies`

IFRS Inventory Concept Set includes candidates such as:

* `FinishedGoodsCAIFRS`
* `MerchandiseAndFinishedGoodsCAIFRS`
* `WorkInProcessCAIFRS`
* `WorkInProcessAndRawMaterialsCAIFRS`
* `RawMaterialsCAIFRS`
* `RawMaterialsAndSuppliesCAIFRS`
* `OtherInventoriesCAIFRS`

### Research Finding

Both taxonomy families distinguish Work In Process from adjacent finished goods and raw material concepts.

This supports equivalent semantic positioning within the inventory component taxonomy structure.

### Important Boundary

Combined Concepts exist.

Example:

`WorkInProcessAndRawMaterialsCAIFRS`

Therefore, the following is an invalid Generic Mapping Rule.

`All concepts containing "WorkInProcess" → WorkInProcess`

Exact Source Concept Mapping Review remains required.

---

## 16. Taxonomy Version Evidence

Validated Filing Evidence used:

### jppfs

`2025-11-01`

### jpigp

`2024-11-01`

Official List Review additionally confirmed `WorkInProcessCAIFRS` in both:

* 2024 EDINET Taxonomy
* 2025 EDINET Taxonomy

Observed attributes in both official IFRS lists:

* Japanese Standard Label: `仕掛品`
* Japanese Verbose Label: `仕掛品、流動資産（IFRS）`
* English Standard Label: `Work in process`
* English Verbose Label: `Work in process - CA (IFRS)`
* Data Type: `xbrli:monetaryItemType`
* Period Type: `instant`
* Balance: `debit`
* Abstract: `false`

### Current Finding

`No Material Attribute Difference Observed for WorkInProcessCAIFRS between the reviewed 2024 and 2025 official element lists.`

### Classification

`Cross-version Stability: SUPPORTED WITHIN REVIEWED OFFICIAL LIST ATTRIBUTES`

### Not Declared

`Universal Taxonomy Definition Identity`

---

## 17. Official Guideline and Semantic Identity

EDINET official guidance states that element concepts should be understood comprehensively from taxonomy information and positioning.

The guidance also indicates that matters represented by dimensions, including consolidated and individual distinctions, are generally not by themselves treated as differences in element concepts.

### Research Implication

`Source Concept Semantic Meaning and Fact Scope Eligibility must remain separate.`

Therefore:

`WorkInProcess → WorkInProcess`

Semantic Mapping may be stable while the following eligibility remains separately validated.

* Consolidated
* NonConsolidated

This supports the existing Raw Observation Boundary Architecture.

---

## 18. Cross-standard Semantic Comparison

### Japanese GAAP Source Meaning

* 仕掛品
* Work in process
* Inventory Component
* Instant Monetary Asset Fact

### IFRS Source Meaning

* 仕掛品
* Work in process
* Inventory Component
* Instant Monetary Asset Fact
* Current Asset Presentation Candidate

### Shared Semantic Core

`Work in process inventory component`

### Observed Difference

* Accounting Standard
* Taxonomy Family
* IFRS Current Asset Presentation Qualifier

### Cross-standard Semantic Similarity

`HIGH`

---

## 19. Semantic Identity vs Accounting Measurement

This Review distinguishes:

`Semantic Component Identity`

from:

`Accounting Measurement Equivalence`

Current Evidence supports:

> Both Concepts represent Work In Process inventory components.

Current Evidence does not prove:

> Japanese GAAP and IFRS measure Work In Process identically.

Therefore:

`Semantic Equivalence Candidate: SUPPORTED`

`Measurement Equivalence: NOT EVALUATED`

---

## 20. Semantic Identity vs Metric Comparability

Even if both Concepts map to:

`WorkInProcess`

the following is not automatically established:

> J-GAAP WorkInProcess Growth and IFRS WorkInProcess Growth have identical economic or predictive interpretation.

Possible future control dimensions:

* Accounting Standard
* Company
* SubSector
* Inventory Accounting Policy
* Business Model

### Research Finding

`Semantic Equivalence ≠ Metric Comparability Proven`

This distinction is mandatory.

---

## 21. Information Loss Evaluation

### Candidate Mapping

`jppfs_cor:WorkInProcess → WorkInProcess`

`jpigp_cor:WorkInProcessCAIFRS → WorkInProcess`

### Information Removed from Canonical Role

* Accounting Standard Identity
* Taxonomy Family
* IFRS Current Asset Presentation Qualifier

However, these remain available through lineage.

* Source QName
* Namespace URI
* Taxonomy Version
* Accounting Standard
* Source Label

### Reviewer Question

> After lineage preservation, does the Canonical Role remove material inventory-stage meaning?

### Current Decision

`NO MATERIAL INVENTORY-STAGE SEMANTIC LOSS IDENTIFIED`

### Information Loss Classification

`Minor`

### Mandatory Condition

Accounting Standard and Source Concept lineage must be preserved.

---

## 22. Combined Concept Conflict Risk

IFRS Taxonomy contains:

`WorkInProcessCAIFRS`

and:

`WorkInProcessAndRawMaterialsCAIFRS`

Therefore the following is prohibited:

`Concept Name contains WorkInProcess → Map to WorkInProcess`

Mapping must operate on reviewed Source Concept Identity.

### Conflict Candidate

* `WorkInProcessCAIFRS`
* `WorkInProcessAndRawMaterialsCAIFRS`

If both appear in the same Filing, Period and Scope:

`Potential Overlap → Conflict Review`

Do not automatically sum them.

---

## 23. Company Extension Conflict Risk

Kioxia Validation confirmed:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

as a Company Extension Concept.

Canonical Semantic Role Candidate:

`WorkInProcess`

However:

`WorkInProcessCAIFRS`

and:

`SemiFinishedProductsAndWorkInProgressCAIFRS`

must not automatically be treated as additive observations.

Same Filing, Period, Scope and Canonical Role Candidate:

`Potential Semantic Overlap`

requires Conflict Review.

This supports:

`One Raw Fact → 0 or 1 Primary Semantic Role`

but does not imply:

`Multiple Raw Facts with same Semantic Role → Sum Automatically`

---

## 24. Contradicting Evidence Review

### Official Element Attribute Conflict

`NOT IDENTIFIED`

### Standard Label Conflict

`NOT IDENTIFIED`

### English Label Conflict

`NOT IDENTIFIED`

### Period Type Conflict

`NOT IDENTIFIED`

### Financial Statement Role Conflict in Validated Filings

`NOT IDENTIFIED`

### Known Difference

`IFRS Current Asset Presentation Qualifier`

### Current Evaluation

Not a contradiction to `WorkInProcess` inventory-stage identity.

### Contradicting Semantic Evidence

`NONE IDENTIFIED within current official and filing evidence scope.`

---

## 25. Pre-review Gate Evaluation

| Review Item                                         | Result                  |
| --------------------------------------------------- | ----------------------- |
| Official Concept Information                        | PASS                    |
| Official Labels                                     | PASS                    |
| Data Type Comparison                                | PASS                    |
| Period Type Comparison                              | PASS                    |
| Balance Attribute Comparison                        | PASS                    |
| Adjacent Concept Review                             | PASS                    |
| Current Asset Qualifier Review                      | PASS WITH BOUNDARY NOTE |
| Accounting Standard Lineage Preservation            | REQUIRED / DEFINED      |
| Semantic Identity / Metric Comparability Separation | PASS                    |
| Double-count Conflict Risk                          | RECORDED                |
| Taxonomy Version Review                             | PASS                    |

### Taxonomy Version Review Scope

`2024 / 2025 OFFICIAL LIST ATTRIBUTES REVIEWED`

---

## 26. Independent Research Reviewer Decision

Current Evidence supports the following Source Concepts:

`jppfs_cor:WorkInProcess`

and:

`jpigp_cor:WorkInProcessCAIFRS`

having a shared inventory-stage semantic core:

`Work In Process`

### Reviewer Decision

`CROSS-STANDARD SEMANTIC EQUIVALENCE PRE-REVIEW = PASS`

### Approved Scope

Proceed to final Semantic Mapping Research Sheet for:

`jpigp_cor:WorkInProcessCAIFRS`

### Not Approved

* Production Mapping
* Metric Comparability
* Accounting Measurement Equivalence
* Automatic Cross-standard Feature Pooling

---

## 27. Cross-standard Mapping Gate Status

### Previous Status

`DEFER`

Reason:

`Pending Official Taxonomy Review`

### Current Status

`PRE-REVIEW PASS`

### Next Mapping Candidate

`jpigp_cor:WorkInProcessCAIFRS → WorkInProcess`

### Expected Mapping Class Candidate

`M1`

`Direct Standard Mapping`

Important:

Expected Mapping Class is not Final Approval.

The final Research Sheet must still evaluate:

* Source Eligibility
* Canonical Role
* Information Loss
* Cross-standard Lineage
* Double-count Risk
* Contradicting Evidence
* Reviewer Conditions

---

## 28. Research Process Finding

The Cross-standard Pre-review Gate detected an important distinction:

> Same Semantic Financial Component can exist across accounting standards while measurement and predictive comparability remain unproven.

Therefore future Architecture must distinguish:

`Semantic Normalization`

from:

`Analytical Comparability Validation`

### Candidate Layers

`Raw Fact`

↓

`Semantic Mapping`

↓

`Canonical Observation`

↓

`Accounting Standard / Business Context`

↓

`Derived Metric`

↓

`Comparability Validation`

↓

`ML / Decision Use`

This is a Research Architecture Finding.

Production Architecture is not yet approved.

---

## 29. Final Pre-review Result

| Item                                           | Result                              |
| ---------------------------------------------- | ----------------------------------- |
| Target A                                       | `jppfs_cor:WorkInProcess`           |
| Target B                                       | `jpigp_cor:WorkInProcessCAIFRS`     |
| Shared Semantic Core                           | Work In Process Inventory Component |
| Official Taxonomy Attribute Alignment          | STRONG                              |
| Cross-standard Semantic Equivalence Pre-review | PASS                                |
| Final IFRS Mapping Research                    | NEXT                                |
| Production Mapping                             | NOT APPROVED                        |
| Metric Comparability                           | NOT EVALUATED                       |

---

## 30. Exact Next Task

### Next Task

Inventory Semantic Mapping Research Sheet for:

`jpigp_cor:WorkInProcessCAIFRS`

### Canonical Semantic Role Candidate

`WorkInProcess`

### Research Evidence

* Official 2024 EDINET IFRS Element List
* Official 2025 EDINET IFRS Element List
* Official EDINET Concept Handling Guideline
* Renesas Filing Evidence
* Japanese GAAP WorkInProcess Reference Mapping
* Cross-standard Official Taxonomy Evidence Review

### Reviewer Focus

1. Can M1 Direct Standard Mapping be approved?
2. What cross-standard lineage conditions are mandatory?
3. Does Current Asset qualification require conditional scope?
4. How should Semantic Mapping remain separate from Metric Comparability?
5. What Conflict Gate is required for overlapping WorkInProcess concepts?

---

## Reviewer Status

`APPROVE`

## Next Project State

`Inventory Semantic Mapping Research Sheet for jpigp_cor:WorkInProcessCAIFRS`

Mapping Approval remains pending until completion of the final Research Sheet.
