# Inventory Semantic Mapping

# Merchandise And Finished Goods Cross-standard Official Taxonomy Evidence Review

## 1. Document Purpose

本書は、以下のJapanese GAAP及びIFRS Source Conceptについて、金融庁が公表するEDINET公式Taxonomy資料をPrimary Evidenceとして確認し、Canonical Semantic RoleへのCross-standard Semantic Mapping Researchを継続可能か判定するOfficial Taxonomy Evidence Review Artifactである。

### Japanese GAAP Source Concept

`jppfs_cor:MerchandiseAndFinishedGoods`

### IFRS Source Concept

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

### Canonical Semantic Role Candidate

`MerchandiseAndFinishedGoods`

本書の目的はProduction Mappingを承認することではない。

目的は以下である。

> Japanese GAAP及びIFRSの異なるTaxonomy Familyに属するCombined Merchandise and Finished Goods Conceptについて、公式要素属性、公式ラベル、Period Type、Balance Attribute、Taxonomy Version及びAdjacent Concept Boundaryを比較し、Semantic Equivalence Research Sheetへ進むためのEvidence Gateを評価する。

### Status

* Research Evidence Artifact
* Official Taxonomy Review
* Cross-standard Semantic Equivalence Pre-review
* Combined Inventory Component Case
* Pre-Catalog
* Pre-DDL
* Final Mapping Not Yet Approved

---

## 2. Official Source Scope

本Reviewでは金融庁公表の以下資料をPrimary Sourceとした。

* 2025年版EDINETタクソノミ 勘定科目リスト
* 2025年版EDINETタクソノミ 国際会計基準タクソノミ要素リスト
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

金融庁の「報告項目及び勘定科目の取扱いに関するガイドライン」では、EDINET Taxonomyの要素概念について、主に冗長ラベルで表現しつつ、以下の情報等から総合的に理解すべきものとしている。

* 冗長ラベル
* 参照リンク情報
* 定義リンク上の位置付け
* 表示リンク上の位置付け
* ドキュメンテーションラベル

Therefore:

`Concept Local Name Similarity alone is not sufficient semantic evidence.`

本ReviewではConcept NameのみでCross-standard Mappingを判断しない。

---

## 4. Semantic Concept and Fact Eligibility Boundary

EDINET Official Guidelineでは、以下の差は原則としてそれ自体で異なる要素概念とはみなさない。

* Unit Difference
* Period / Instant Presentation Difference
* Aggregation Label Difference
* Positive / Negative Label Difference
* Matters represented by dimensions

Dimension Examples:

* Consolidated
* NonConsolidated
* Segment

Important:

これは以下を意味しない。

`Context Validation Is Unnecessary`

Source Concept MeaningとFact Eligibilityは分離する。

`Semantic Concept Identity ≠ Fact Eligibility`

Original Context及びDimension Evidenceは保持する。

---

## 5. Japanese GAAP Source Concept

### QName

`jppfs_cor:MerchandiseAndFinishedGoods`

### Prefix

`jppfs_cor`

### Local Name

`MerchandiseAndFinishedGoods`

### Official Japanese Standard Label

`商品及び製品`

### Official Japanese Verbose Label

`商品及び製品`

### Official English Standard Label

`Merchandise and finished goods`

### Official English Verbose Label

`Merchandise and finished goods`

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
* Inventory Component Candidate

---

## 6. Japanese GAAP Official Meaning

Official Japanese Label:

`商品及び製品`

Official English Label:

`Merchandise and finished goods`

Semantic Structure:

`Merchandise + Finished Goods`

This is an explicitly combined inventory concept.

The Official Concept does not represent:

`Finished Goods only`

### Existing Mapping Research Result

The following Mapping was rejected:

`jppfs_cor:MerchandiseAndFinishedGoods → FinishedGoods`

Reason:

`Material Information Loss Candidate`

The following Research Mapping was approved:

`jppfs_cor:MerchandiseAndFinishedGoods → MerchandiseAndFinishedGoods`

Mapping Class:

`M1`

Classification:

`Direct Meaning-preserving Mapping`

Architecture Reviewer:

`APPROVE CANONICAL ROLE ADDITION`

---

## 7. Japanese GAAP Filing Evidence

The Source Concept was confirmed in the following validated companies.

* ROHM
* Fuji Electric
* Sanken Electric
* Torex Semiconductor
* Tokyo Electron

Observed Source Concept:

`jppfs_cor:MerchandiseAndFinishedGoods`

Observed Financial Role:

`Inventory Component`

Observed Japanese Meaning:

`商品及び製品`

Observed Period Type:

`Instant`

Observed Common Consolidated Context Candidate:

* `Prior1YearInstant`
* `CurrentYearInstant`

### Cross-company Reproduction

`5 Companies`

### Result

`STRONG CROSS-COMPANY SOURCE CONCEPT REPRODUCTION`

Important:

This Evidence supports the stability of the Combined Source Meaning.

It does not support reducing the Concept to `FinishedGoods`.

---

## 8. IFRS Source Concept

### QName

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

### Prefix

`jpigp_cor`

### Local Name

`MerchandiseAndFinishedGoodsCAIFRS`

### Official Japanese Standard Label

`商品及び製品`

### Official Japanese Verbose Label

`商品及び製品、流動資産（IFRS）`

### Official English Standard Label

`Merchandise and finished goods`

### Official English Verbose Label

`Merchandise and finished goods - CA (IFRS)`

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
* Inventory Component Candidate

---

## 9. Official Element Attribute Comparison

| Attribute               | J-GAAP                         | IFRS                           |
| ----------------------- | ------------------------------ | ------------------------------ |
| Japanese Standard Label | 商品及び製品                         | 商品及び製品                         |
| English Standard Label  | Merchandise and finished goods | Merchandise and finished goods |
| Data Type               | monetaryItemType               | monetaryItemType               |
| Substitution Group      | item                           | item                           |
| Period Type             | instant                        | instant                        |
| Balance                 | debit                          | debit                          |
| Abstract                | false                          | false                          |

### Comparison Result

`Official Element Attribute Alignment: STRONG`

### Direct Differences

* Accounting Standard
* Taxonomy Family
* IFRS Local Name suffix `CAIFRS`
* IFRS Current Asset presentation qualifier

---

## 10. Standard Label Equivalence

### Japanese GAAP

Japanese:

`商品及び製品`

English:

`Merchandise and finished goods`

### IFRS

Japanese:

`商品及び製品`

English:

`Merchandise and finished goods`

### Result

`EXACT STANDARD LABEL ALIGNMENT OBSERVED`

The Combined Semantic Structure is present in both Official Standard Labels.

This is stronger than Local Name similarity alone.

### Shared Semantic Structure

`Merchandise + Finished Goods`

---

## 11. Combined Semantic Structure Comparison

Japanese GAAP Concept:

`MerchandiseAndFinishedGoods`

IFRS Concept:

`MerchandiseAndFinishedGoodsCAIFRS`

Both Official Standard Labels explicitly contain:

`Merchandise`

and:

`Finished Goods`

Therefore:

`Combined Source Meaning`

is aligned at the Official Label level.

### Research Finding

`Both concepts explicitly preserve Merchandise and Finished Goods as a combined inventory meaning.`

Classification:

`Strong Official Semantic Evidence`

---

## 12. Period Type Comparison

Japanese GAAP:

`instant`

IFRS:

`instant`

Both Concepts represent balance observations at a point in time.

### Result

`Period Type: ALIGNED`

This supports inventory stock component semantic compatibility.

The Concepts are not Duration Cash Flow Change Facts.

### Semantic Boundary

`MerchandiseAndFinishedGoods Balance Fact ≠ Inventory Change Cash Flow Fact`

---

## 13. Data Type Comparison

Japanese GAAP:

`xbrli:monetaryItemType`

IFRS:

`xbrli:monetaryItemType`

### Result

`Financial Value Type: ALIGNED`

Both Concepts represent monetary items.

Unit validation remains mandatory at the Fact Eligibility Layer.

`Semantic Mapping does not replace Unit Validation.`

---

## 14. Balance Attribute Comparison

Japanese GAAP:

`debit`

IFRS:

`debit`

### Result

`Balance Attribute: ALIGNED`

This is consistent with an asset inventory component role.

Balance Attribute is Supporting Structured Evidence.

It is not used as sole Semantic Proof.

---

## 15. Abstract Status Comparison

Japanese GAAP:

`false`

IFRS:

`false`

Both Concepts are usable Fact Concepts rather than abstract title elements.

### Result

`Fact Element Eligibility Candidate: ALIGNED`

---

## 16. IFRS Current Asset Qualifier

IFRS Verbose Label:

`商品及び製品、流動資産（IFRS）`

English:

`Merchandise and finished goods - CA (IFRS)`

Japanese GAAP Concept does not contain the same Current Asset qualifier in its Official Label.

### Research Question

> Does the Current Asset qualifier materially change the Combined Inventory Component semantic identity?

### Official Evidence

Japanese Standard Label:

`商品及び製品`

IFRS Standard Label:

`商品及び製品`

English Standard Label:

`Merchandise and finished goods`

for both Concepts.

### Current Reviewer Interpretation

The IFRS Current Asset qualifier represents a presentation or classification distinction within the reviewed Official Concept.

No Official Evidence currently indicates that it changes the Combined Semantic Core:

`Merchandise + Finished Goods`

### Classification

`Supported Interpretation`

### Not Proven

Current Asset classification is irrelevant for all analytical use.

### Future Trigger

Detection of:

`Non-current Merchandise and Finished Goods Concept`

or another materially different Combined Concept triggers:

`Canonical Role Boundary Review`

---

## 17. Adjacent Finished Goods Concept Review

The IFRS Taxonomy also contains:

`jpigp_cor:FinishedGoodsCAIFRS`

Official Semantic Candidate:

`Finished Goods`

This Concept is narrower than:

`MerchandiseAndFinishedGoodsCAIFRS`

### Concept A

`FinishedGoodsCAIFRS`

Meaning:

`Finished Goods`

### Concept B

`MerchandiseAndFinishedGoodsCAIFRS`

Meaning:

`Merchandise + Finished Goods`

### Material Semantic Difference

`Merchandise inclusion`

Therefore:

`FinishedGoodsCAIFRS`

and:

`MerchandiseAndFinishedGoodsCAIFRS`

must not automatically map to the same Source Semantic Role.

### Boundary Result

`DISTINCT SOURCE SEMANTIC CONCEPTS`

---

## 18. Japanese GAAP Adjacent Concept Review

The Japanese GAAP financial statement taxonomy contains Concept Candidates including:

* `Merchandise`
* `FinishedGoods`
* `MerchandiseAndFinishedGoods`
* `WorkInProcess`
* `RawMaterialsAndSupplies`
* `Supplies`

The existence of:

`MerchandiseAndFinishedGoods`

alongside narrower Concept Candidates supports preservation of the Combined Meaning.

### Research Finding

`MerchandiseAndFinishedGoods is not merely an alternative text label for FinishedGoods.`

Current Evidence supports:

`Independent Combined Semantic Meaning`

---

## 19. Cross-standard Semantic Comparison

### Japanese GAAP Source Meaning

* 商品及び製品
* Merchandise and finished goods
* Combined Inventory Component
* Instant Monetary Asset Fact

### IFRS Source Meaning

* 商品及び製品
* Merchandise and finished goods
* Combined Inventory Component
* Instant Monetary Asset Fact
* Current Asset Presentation Candidate

### Shared Semantic Core

`Combined merchandise and finished goods inventory component`

### Observed Difference

* Accounting Standard
* Taxonomy Family
* IFRS Current Asset presentation qualifier

### Cross-standard Semantic Similarity

`VERY HIGH`

---

## 20. Cross-standard Canonical Role Candidate

Existing Approved Research Canonical Role:

`MerchandiseAndFinishedGoods`

Role Meaning:

`Combined merchandise and finished goods inventory component`

Japanese GAAP Mapping:

`jppfs_cor:MerchandiseAndFinishedGoods → MerchandiseAndFinishedGoods`

Current IFRS Mapping Candidate:

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS → MerchandiseAndFinishedGoods`

### Semantic Compatibility Candidate

`DIRECT`

Both Official Standard Labels preserve the same Combined Meaning.

---

## 21. Semantic Identity vs Accounting Measurement

Current Official Evidence supports:

`Both Concepts represent a combined Merchandise and Finished Goods inventory component.`

Current Evidence does not prove:

`Japanese GAAP and IFRS measure Merchandise and Finished Goods identically.`

Therefore:

### Semantic Equivalence Candidate

`SUPPORTED`

### Accounting Measurement Equivalence

`NOT EVALUATED`

The Accounting Standard must remain preserved in Lineage.

---

## 22. Semantic Identity vs Metric Comparability

Even if both Concepts map to:

`MerchandiseAndFinishedGoods`

the following is not automatically established:

> J-GAAP MerchandiseAndFinishedGoods Growth and IFRS MerchandiseAndFinishedGoods Growth have identical predictive meaning.

Potential Comparability Dimensions:

* Accounting Standard
* Company
* Business Model
* SubSector
* Inventory Accounting Policy
* Merchandise Share
* Finished Goods Share

### Important Risk

The Combined Fact does not provide:

`Merchandise / Finished Goods split`

Therefore companies with materially different internal composition may show different economic meaning under the same Combined Semantic Role.

### Research Finding

`Semantic Equivalence ≠ Composition Equivalence`

and:

`Semantic Equivalence ≠ Metric Comparability Proven`

---

## 23. Information Loss Evaluation

### Candidate Mapping

`jppfs_cor:MerchandiseAndFinishedGoods → MerchandiseAndFinishedGoods`

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS → MerchandiseAndFinishedGoods`

### Source Meaning

`Merchandise and Finished Goods`

### Canonical Meaning

`MerchandiseAndFinishedGoods`

### Removed from Canonical Role Name

* Accounting Standard
* Taxonomy Family
* IFRS Current Asset presentation qualifier

These remain available through Lineage.

### Combined Inventory Meaning Loss

`NONE IDENTIFIED`

### Overall Information Loss

`Minor`

Reason:

The Canonical Role preserves the explicit Combined Semantic Structure.

### Mandatory Condition

Accounting Standard and Source Concept Lineage must be preserved.

---

## 24. Comparison with Rejected FinishedGoods Mapping

Previously Rejected Mapping:

`jppfs_cor:MerchandiseAndFinishedGoods → FinishedGoods`

Reason:

`Merchandise meaning removed`

Current Candidate:

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS → MerchandiseAndFinishedGoods`

The current Candidate does not remove:

`Merchandise`

Therefore the Primary Information Loss concern identified in the Japanese GAAP Research is not reproduced.

### Result

`Meaning-preserving Mapping Candidate`

---

## 25. Analytical Grouping Boundary

Future Analytical Group Candidate:

`FinishedInventoryGroup`

Possible Members:

* `FinishedGoods`
* `MerchandiseAndFinishedGoods`

However:

`FinishedInventoryGroup`

would be an Analytical Group.

It is not a Canonical Semantic Role.

### Architecture Boundary

`Source Semantic Mapping`

↓

`Canonical Semantic Role`

↓

`Analytical Grouping`

Therefore:

`MerchandiseAndFinishedGoods`

may remain independent while later being evaluated alongside:

`FinishedGoods`

### Analytical Grouping Status

`NOT APPROVED`

Separate Comparability Research is required.

---

## 26. Double-count Risk Evaluation

### Risk A

`FinishedGoodsCAIFRS`

and:

`MerchandiseAndFinishedGoodsCAIFRS`

appear in the same Filing / Period / Scope.

Potential Overlap:

`HIGH`

Reason:

The Combined Concept includes Finished Goods meaning.

### Required Governance

`Conflict Review`

Do not sum automatically.

---

### Risk B

Separate `Merchandise` Concept and Combined Concept coexist.

Potential Overlap:

`HIGH`

Do not sum automatically.

---

### Risk C

Combined Concept is synthetically decomposed.

Example:

`MerchandiseAndFinishedGoods`

↓

`Merchandise`

*

`FinishedGoods`

without Source-supported split.

Result:

`Unsupported Synthetic Decomposition`

### Decision

`PROHIBITED`

---

## 27. Atomic Combined Concept Principle

Existing Research Principle Candidate:

`Combined Source Concept → Atomic Canonical Observation`

unless:

`Source-supported decomposition exists`

Current Official Taxonomy Evidence supports applying this Principle to:

`MerchandiseAndFinishedGoodsCAIFRS`

### Candidate Result

`MerchandiseAndFinishedGoodsCAIFRS`

remains atomic under:

`MerchandiseAndFinishedGoods`

### Decomposition Status

`NOT APPROVED`

---

## 28. Taxonomy Version Evidence

2025 Official IFRS Element List confirmed:

`MerchandiseAndFinishedGoodsCAIFRS`

with the following attributes:

* Japanese Standard Label: `商品及び製品`
* Japanese Verbose Label: `商品及び製品、流動資産（IFRS）`
* English Standard Label: `Merchandise and finished goods`
* English Verbose Label: `Merchandise and finished goods - CA (IFRS)`
* Data Type: `xbrli:monetaryItemType`
* Period Type: `instant`
* Balance: `debit`
* Abstract: `false`

The 2024 Official IFRS Element List confirmed the same Local Name and the same reviewed element attributes.

### Current Finding

`No Material Reviewed Attribute Difference Observed`

between:

`2024 Official IFRS Element List`

and:

`2025 Official IFRS Element List`

for:

`MerchandiseAndFinishedGoodsCAIFRS`

### Classification

`Cross-version Stability Supported within Reviewed Official Attributes`

### Not Declared

`Universal Taxonomy Definition Identity`

New versions remain subject to Version Change Review.

---

## 29. Contradicting Evidence Review

### Official Standard Label Conflict

`NOT IDENTIFIED`

### English Label Conflict

`NOT IDENTIFIED`

### Combined Semantic Structure Conflict

`NOT IDENTIFIED`

### Period Type Conflict

`NOT IDENTIFIED`

### Data Type Conflict

`NOT IDENTIFIED`

### Balance Attribute Conflict

`NOT IDENTIFIED`

### Evidence that IFRS Concept means Finished Goods only

`NOT IDENTIFIED`

### Evidence that Merchandise can be removed

`NOT IDENTIFIED`

### Contradicting Semantic Evidence

`NONE IDENTIFIED within current official evidence scope`

---

## 30. Pre-review Gate Evaluation

| Review Item                        | Result                          |
| ---------------------------------- | ------------------------------- |
| Official J-GAAP Concept Identity   | PASS                            |
| Official IFRS Concept Identity     | PASS                            |
| Japanese Standard Label Comparison | EXACT ALIGNMENT                 |
| English Standard Label Comparison  | EXACT ALIGNMENT                 |
| Data Type Comparison               | PASS                            |
| Period Type Comparison             | PASS                            |
| Balance Attribute Comparison       | PASS                            |
| Abstract Status Comparison         | PASS                            |
| Combined Semantic Structure        | ALIGNED                         |
| Adjacent FinishedGoods Boundary    | REVIEWED                        |
| Current Asset Qualifier            | PASS WITH BOUNDARY NOTE         |
| Information Loss                   | MINOR                           |
| Accounting Standard Lineage        | REQUIRED                        |
| Metric Comparability Boundary      | RECORDED                        |
| Atomic Combined Concept Boundary   | RECORDED                        |
| Double-count Risk                  | RECORDED                        |
| Taxonomy Version Review            | PASS WITHIN REVIEWED ATTRIBUTES |

---

## 31. Independent Research Reviewer Decision

Current Official Taxonomy Evidence strongly supports the following Concepts:

`jppfs_cor:MerchandiseAndFinishedGoods`

and:

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

sharing the same Combined Semantic Core:

`Merchandise and Finished Goods Inventory Component`

### Reviewer Decision

`CROSS-STANDARD SEMANTIC EQUIVALENCE PRE-REVIEW = PASS`

### Approved Scope

Proceed to final Semantic Mapping Research Sheet for:

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

### Canonical Semantic Role Candidate

`MerchandiseAndFinishedGoods`

### Not Approved

* Production Mapping
* FinishedGoods Mapping
* Analytical Grouping
* Accounting Measurement Equivalence
* Metric Comparability
* Automatic Cross-standard ML Pooling

---

## 32. Cross-standard Mapping Gate Status

### Previous Mapping State

Japanese GAAP:

`jppfs_cor:MerchandiseAndFinishedGoods → MerchandiseAndFinishedGoods`

Status:

`APPROVED RESEARCH MAPPING`

Architecture Reviewer:

`APPROVED CANONICAL ROLE ADDITION`

### IFRS Candidate

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS → MerchandiseAndFinishedGoods`

### Current Status

`PRE-REVIEW PASS`

### Expected Mapping Class Candidate

`M1`

`Direct Meaning-preserving Mapping`

Important:

Expected Mapping Class is not Final Approval.

The final Research Sheet must still evaluate:

* Source Eligibility
* Filing Evidence
* Canonical Role
* Information Loss
* Current Asset qualifier
* Cross-standard Lineage
* Atomic Combined Concept treatment
* Overlap Conflict Risk
* Contradicting Evidence
* Reviewer Conditions

---

## 33. Research Architecture Finding

This Cross-standard Review strengthens the following Principle:

`Preserve combined source semantics before analytical grouping.`

Japanese GAAP and IFRS both contain an Official Standard Concept whose label explicitly preserves:

`Merchandise + Finished Goods`

Therefore the Combined Semantic Role is not merely a workaround for Japanese GAAP Source variation.

### Stronger Finding

`MerchandiseAndFinishedGoods`

is now supported as a Cross-standard Canonical Semantic Role Candidate.

### Status

`Research Architecture Finding`

Production Canonical Master remains unapproved.

---

## 34. Final Pre-review Result

| Item                                           | Result                                             |
| ---------------------------------------------- | -------------------------------------------------- |
| J-GAAP Target                                  | `jppfs_cor:MerchandiseAndFinishedGoods`            |
| IFRS Target                                    | `jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`      |
| Shared Semantic Core                           | Merchandise and Finished Goods Inventory Component |
| Official Standard Label Alignment              | EXACT                                              |
| Official Element Attribute Alignment           | STRONG                                             |
| Adjacent FinishedGoods Boundary                | DISTINCT                                           |
| Combined Semantic Preservation                 | SUPPORTED                                          |
| Cross-standard Semantic Equivalence Pre-review | PASS                                               |
| Final IFRS Mapping Research                    | NEXT                                               |
| Production Mapping                             | NOT APPROVED                                       |
| Metric Comparability                           | NOT EVALUATED                                      |

---

## 35. Exact Next Task

### Next Task

Inventory Semantic Mapping Research Sheet for:

`jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS`

### Canonical Semantic Role Candidate

`MerchandiseAndFinishedGoods`

### Research Evidence

* Official 2025 EDINET Account List
* Official 2025 EDINET IFRS Element List
* Official 2024 EDINET IFRS Element List
* Official EDINET Concept Handling Guideline
* Japanese GAAP MerchandiseAndFinishedGoods Mapping Research
* Kioxia / Renesas IFRS Inventory Structure Evidence where relevant
* Cross-standard Official Taxonomy Evidence Review

### Reviewer Focus

1. Can M1 Direct Meaning-preserving Mapping be approved?
2. Is actual Filing Evidence sufficient for this exact IFRS Concept?
3. Does Current Asset qualification require conditional scope?
4. Must the Combined Concept remain atomic?
5. What conflict gate is required with `FinishedGoodsCAIFRS`?
6. Does Approval remain separate from Analytical Grouping?
7. Does Approval remain separate from Metric Comparability?

### Mapping Approval Status

`PENDING FINAL RESEARCH SHEET`
