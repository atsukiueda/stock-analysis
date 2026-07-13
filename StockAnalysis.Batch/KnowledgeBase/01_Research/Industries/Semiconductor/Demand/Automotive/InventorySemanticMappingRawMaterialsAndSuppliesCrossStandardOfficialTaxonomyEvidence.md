# Inventory Semantic Mapping Raw Materials And Supplies Cross-standard Official Taxonomy Evidence Review

## 1. Document Purpose

本書は、以下のJapanese GAAP及びIFRS Source Conceptについて、金融庁が公表するEDINET公式Taxonomy資料をPrimary Evidenceとして確認し、Canonical Semantic RoleへのCross-standard Semantic Mapping Researchを継続可能か判定するOfficial Taxonomy Evidence Review Artifactである。

### Japanese GAAP Source Concept

`jppfs_cor:RawMaterialsAndSupplies`

### IFRS Source Concept

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

### Canonical Semantic Role Candidate

`RawMaterialsAndSupplies`

本書の目的はProduction Mappingを承認することではない。

目的は以下である。

> Japanese GAAP及びIFRSの異なるTaxonomy Familyに属するCombined Raw Materials and Supplies Conceptについて、公式要素属性、公式ラベル、Period Type、Balance Attribute、Taxonomy Version及びAdjacent Concept Boundaryを比較し、Semantic Equivalence Research Sheetへ進むためのEvidence Gateを評価する。

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
* 2024年版EDINETタクソノミと2025年版EDINETタクソノミの差分情報

### Source Authority

Financial Services Agency

金融庁

### Evidence Classification

* Primary Source
* Official Taxonomy Evidence

---

## 3. EDINET Taxonomy Evidence Principle

EDINET Taxonomyの要素概念は、Local Nameのみから判断しない。

要素概念は、以下の情報等を用いて総合的に理解する。

* Standard Label
* Verbose Label
* Reference Information
* Definition Link Position
* Presentation Link Position
* Documentation Label
* Adjacent Concept Structure

Therefore:

`Concept Name Similarity Alone Is Not Sufficient Semantic Evidence`

本Reviewでは、`RawMaterialsAndSupplies`という名称が類似していることだけをCross-standard Mapping Evidenceとしない。

---

## 4. Semantic Concept and Fact Eligibility Boundary

Source Concept Meaningと個別Factの利用適格性は分離する。

`Semantic Concept Identity ≠ Fact Eligibility`

Fact Eligibilityでは別途以下を検証する。

* ContextRef
* Period Type
* Consolidation Scope
* Dimension
* Unit
* Decimals
* Filing Scope

Therefore:

同一Semantic Conceptであっても、

`Consolidated`

及び、

`NonConsolidated`

のFactを自動混在させない。

Original Context及びDimension Evidenceを保持する。

---

## 5. Japanese GAAP Source Concept

### QName

`jppfs_cor:RawMaterialsAndSupplies`

### Prefix

`jppfs_cor`

### Local Name

`RawMaterialsAndSupplies`

### Official Japanese Standard Label

`原材料及び貯蔵品`

### Official Japanese Verbose Label

`原材料及び貯蔵品`

### Official English Standard Label

`Raw materials and supplies`

### Official English Verbose Label

`Raw materials and supplies`

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

`原材料及び貯蔵品`

Official English Label:

`Raw materials and supplies`

### Semantic Structure

`Raw Materials + Supplies`

This is an explicitly Combined Inventory Concept.

The Official Concept does not represent:

`Raw Materials Only`

### Existing Mapping Research Result

The following Mapping was rejected:

`jppfs_cor:RawMaterialsAndSupplies → RawMaterials`

Reason:

`Material Information Loss Candidate`

The following Research Mapping was approved:

`jppfs_cor:RawMaterialsAndSupplies → RawMaterialsAndSupplies`

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

### Observed Source Concept

`jppfs_cor:RawMaterialsAndSupplies`

### Observed Financial Role

`Inventory Component`

### Observed Japanese Meaning

`原材料及び貯蔵品`

### Observed Period Type

`Instant`

### Observed Common Consolidated Context Candidates

* `Prior1YearInstant`
* `CurrentYearInstant`

### Cross-company Reproduction

`5 Companies`

### Result

`STRONG CROSS-COMPANY SOURCE CONCEPT REPRODUCTION`

Important:

This Evidence supports stability of the Combined Source Meaning.

It does not support reducing the Concept to `RawMaterials`.

---

## 8. IFRS Source Concept

### QName

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

### Prefix

`jpigp_cor`

### Local Name

`RawMaterialsAndSuppliesCAIFRS`

### Official Japanese Standard Label

`原材料及び貯蔵品`

### Official Japanese Verbose Label

`原材料及び貯蔵品、流動資産（IFRS）`

### Official English Standard Label

`Raw materials and supplies`

### Official English Verbose Label

`Raw materials and supplies - CA (IFRS)`

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

| Attribute               | J-GAAP                     | IFRS                       |
| ----------------------- | -------------------------- | -------------------------- |
| Japanese Standard Label | 原材料及び貯蔵品                   | 原材料及び貯蔵品                   |
| English Standard Label  | Raw materials and supplies | Raw materials and supplies |
| Data Type               | monetaryItemType           | monetaryItemType           |
| Substitution Group      | item                       | item                       |
| Period Type             | instant                    | instant                    |
| Balance                 | debit                      | debit                      |
| Abstract                | false                      | false                      |

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

`原材料及び貯蔵品`

English:

`Raw materials and supplies`

### IFRS

Japanese:

`原材料及び貯蔵品`

English:

`Raw materials and supplies`

### Result

`EXACT STANDARD LABEL ALIGNMENT OBSERVED`

The Combined Semantic Structure is explicitly present in both Official Standard Labels.

### Shared Semantic Structure

`Raw Materials + Supplies`

This is stronger Evidence than Local Name similarity alone.

---

## 11. Combined Semantic Structure Comparison

### Japanese GAAP Concept

`RawMaterialsAndSupplies`

### IFRS Concept

`RawMaterialsAndSuppliesCAIFRS`

Both Official Standard Labels explicitly preserve:

`Raw Materials`

and:

`Supplies`

Therefore:

`Combined Source Meaning`

is aligned at the Official Label level.

### Research Finding

Both Concepts explicitly represent a Combined Raw Materials and Supplies Inventory Component.

### Classification

`Strong Official Semantic Evidence`

---

## 12. Period Type Comparison

### Japanese GAAP

`instant`

### IFRS

`instant`

Both Concepts represent balance observations at a point in time.

### Result

`Period Type: ALIGNED`

This supports Inventory Stock Component semantic compatibility.

The Concepts are not Duration Cash Flow Change Facts.

### Semantic Boundary

`RawMaterialsAndSupplies Balance Fact ≠ Inventory Change Cash Flow Fact`

---

## 13. Data Type Comparison

### Japanese GAAP

`xbrli:monetaryItemType`

### IFRS

`xbrli:monetaryItemType`

### Result

`Financial Value Type: ALIGNED`

Both Concepts represent monetary items.

Unit validation remains mandatory at the Fact Eligibility Layer.

`Semantic Mapping Does Not Replace Unit Validation`

---

## 14. Balance Attribute Comparison

### Japanese GAAP

`debit`

### IFRS

`debit`

### Result

`Balance Attribute: ALIGNED`

This is consistent with an asset inventory component role.

Balance Attribute is Supporting Structured Evidence.

It is not used as sole Semantic Proof.

---

## 15. Abstract Status Comparison

### Japanese GAAP

`false`

### IFRS

`false`

Both Concepts are usable Fact Concepts rather than abstract title elements.

### Result

`Fact Element Eligibility Candidate: ALIGNED`

---

## 16. IFRS Current Asset Qualifier

IFRS Verbose Label:

`原材料及び貯蔵品、流動資産（IFRS）`

English:

`Raw materials and supplies - CA (IFRS)`

The Japanese GAAP Concept does not contain the same Current Asset qualifier in its Official Label.

### Research Question

> Does the Current Asset qualifier materially change the Combined Raw Materials and Supplies semantic identity?

### Official Evidence

Japanese Standard Label:

`原材料及び貯蔵品`

IFRS Standard Label:

`原材料及び貯蔵品`

English Standard Label:

`Raw materials and supplies`

for both Concepts.

### Current Reviewer Interpretation

The IFRS Current Asset qualifier represents a presentation or classification distinction within the reviewed Official Concept.

No Official Evidence currently indicates that it changes the Combined Semantic Core:

`Raw Materials + Supplies`

### Classification

`Supported Interpretation`

### Not Proven

Current Asset classification is irrelevant for all analytical use.

### Future Trigger

Detection of:

`Non-current Raw Materials and Supplies Concept`

or another materially different Combined Concept triggers:

`Canonical Role Boundary Review`

---

## 17. Adjacent RawMaterialsCAIFRS Boundary

The IFRS Taxonomy contains:

`jpigp_cor:RawMaterialsCAIFRS`

Approved Research Mapping:

`jpigp_cor:RawMaterialsCAIFRS → RawMaterials`

### Concept A

`RawMaterialsCAIFRS`

Meaning:

`Raw Materials`

### Concept B

`RawMaterialsAndSuppliesCAIFRS`

Meaning:

`Raw Materials + Supplies`

### Material Semantic Difference

`Supplies inclusion`

Therefore:

`RawMaterialsCAIFRS`

and:

`RawMaterialsAndSuppliesCAIFRS`

are not identical Source Semantic Concepts.

### Boundary Result

`DISTINCT SOURCE SEMANTIC CONCEPTS`

This Pre-review does not approve Mapping the Combined Concept to `RawMaterials`.

---

## 18. ProductionSuppliesCAIFRS Boundary

The IFRS Taxonomy contains:

`jpigp_cor:ProductionSuppliesCAIFRS`

Observed Semantic Candidate:

`Production Supplies`

Japanese Label Candidate:

`貯蔵品`

### Research Finding

The Taxonomy separately represents a Supplies-related Concept.

This weakens the assumption:

`Supplies is merely another label for Raw Materials`

### Boundary Result

`RawMaterials`

and:

`Supplies`

can occupy distinct semantic positions within the IFRS Inventory Concept structure.

Therefore:

`RawMaterialsAndSuppliesCAIFRS`

must preserve its Combined Meaning unless Source-supported decomposition exists.

---

## 19. Japanese GAAP Adjacent Concept Review

The Japanese GAAP financial statement taxonomy includes inventory Concept Candidates such as:

* `RawMaterialsAndSupplies`
* `Supplies`
* `WorkInProcess`
* `MerchandiseAndFinishedGoods`

The existence of a Supplies-related Concept alongside:

`RawMaterialsAndSupplies`

supports preservation of the Combined Meaning.

### Research Finding

`RawMaterialsAndSupplies is not merely an alternative label for RawMaterials`

Current Evidence supports:

`Independent Combined Semantic Meaning`

---

## 20. Cross-standard Semantic Comparison

### Japanese GAAP Source Meaning

* 原材料及び貯蔵品
* Raw materials and supplies
* Combined Inventory Component
* Instant Monetary Asset Fact

### IFRS Source Meaning

* 原材料及び貯蔵品
* Raw materials and supplies
* Combined Inventory Component
* Instant Monetary Asset Fact
* Current Asset Presentation Candidate

### Shared Semantic Core

`Combined raw materials and supplies inventory component`

### Observed Difference

* Accounting Standard
* Taxonomy Family
* IFRS Current Asset presentation qualifier

### Cross-standard Semantic Similarity

`VERY HIGH`

---

## 21. Cross-standard Canonical Role Candidate

Existing Approved Research Canonical Role:

`RawMaterialsAndSupplies`

### Role Meaning

`Combined raw materials and supplies inventory component`

Japanese GAAP Mapping:

`jppfs_cor:RawMaterialsAndSupplies → RawMaterialsAndSupplies`

Current IFRS Mapping Candidate:

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS → RawMaterialsAndSupplies`

### Semantic Compatibility Candidate

`DIRECT`

Both Official Standard Labels preserve the same Combined Meaning.

---

## 22. Semantic Identity vs Accounting Measurement

Current Official Evidence supports:

`Both Concepts represent a combined Raw Materials and Supplies inventory component`

Current Evidence does not prove:

`Japanese GAAP and IFRS measure Raw Materials and Supplies identically`

Therefore:

### Semantic Equivalence Candidate

`SUPPORTED`

### Accounting Measurement Equivalence

`NOT EVALUATED`

Accounting Standard must remain preserved in Lineage.

---

## 23. Semantic Identity vs Composition Equivalence

The Combined Semantic Role identifies:

`Raw Materials + Supplies`

However, the Fact does not provide the internal ratio between:

`Raw Materials`

and:

`Supplies`

Company A may have:

`Primarily Raw Materials`

while Company B may have:

`Material Supplies Balance`

under the same Combined Source Concept.

### Research Finding

`Semantic Equivalence ≠ Composition Equivalence`

Therefore:

Mapping both Concepts to:

`RawMaterialsAndSupplies`

does not prove identical internal inventory composition.

---

## 24. Semantic Identity vs Metric Comparability

Even if both Concepts map to:

`RawMaterialsAndSupplies`

the following is not automatically established:

> J-GAAP RawMaterialsAndSupplies Growth and IFRS RawMaterialsAndSupplies Growth have identical economic or predictive meaning.

Potential Comparability Dimensions:

* Accounting Standard
* Company
* SubSector
* Business Model
* Production Process
* Procurement Cycle
* Supplies Materiality
* Raw Materials / Supplies Internal Mix
* Inventory Accounting Policy

### Research Finding

`Semantic Equivalence ≠ Metric Comparability Proven`

### ML Boundary

Automatic Cross-standard Feature Pooling is:

`NOT APPROVED`

---

## 25. Information Loss Evaluation

### Candidate Mapping

`jppfs_cor:RawMaterialsAndSupplies → RawMaterialsAndSupplies`

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS → RawMaterialsAndSupplies`

### Source Meaning

`Raw Materials and Supplies`

### Canonical Meaning

`RawMaterialsAndSupplies`

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

## 26. Comparison with Rejected RawMaterials Mapping

Previously Rejected Mapping:

`jppfs_cor:RawMaterialsAndSupplies → RawMaterials`

Reason:

`Supplies meaning removed`

Current Candidate:

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS → RawMaterialsAndSupplies`

The current Candidate preserves:

`Supplies`

Therefore the Primary Information Loss concern identified in the Japanese GAAP Research is not reproduced.

### Result

`Meaning-preserving Mapping Candidate`

---

## 27. Analytical Grouping Boundary

A future Analytical Group may be considered.

Example:

`RawMaterialRelatedInventoryGroup`

Possible Members:

* `RawMaterials`
* `RawMaterialsAndSupplies`

Alternative Candidate:

`InputInventoryGroup`

However:

`Analytical Grouping`

is not:

`Canonical Semantic Mapping`

### Architecture Boundary

`Source Semantic Mapping`

↓

`Canonical Semantic Role`

↓

`Analytical Grouping`

Therefore:

`RawMaterialsAndSupplies`

may remain independent while later being analytically evaluated with:

`RawMaterials`

### Analytical Grouping Status

`NOT APPROVED`

Separate Comparability Research is required.

---

## 28. Double-count Risk Evaluation

### Risk A

`RawMaterialsCAIFRS`

and:

`RawMaterialsAndSuppliesCAIFRS`

appear in the same Filing / Period / Scope.

### Potential Overlap

`HIGH`

Reason:

The Combined Concept includes Raw Materials meaning.

### Required Governance

`Conflict Review`

Do not sum automatically.

---

### Risk B

`ProductionSuppliesCAIFRS`

and:

`RawMaterialsAndSuppliesCAIFRS`

coexist.

### Potential Overlap

`HIGH`

The Combined Concept includes Supplies meaning.

### Required Governance

`Conflict Review`

---

### Risk C

The Combined Concept is synthetically decomposed.

Example:

`RawMaterialsAndSupplies`

↓

`RawMaterials`

*

`Supplies`

without Source-supported split.

### Result

`Unsupported Synthetic Decomposition`

### Decision

`PROHIBITED`

---

## 29. Atomic Combined Concept Principle

Existing Research Principle:

`Combined Source Concept → Atomic Canonical Observation`

unless:

`Source-supported decomposition exists`

Current Official Taxonomy Evidence supports applying this Principle to:

`RawMaterialsAndSuppliesCAIFRS`

### Candidate Result

`RawMaterialsAndSuppliesCAIFRS`

remains atomic under:

`RawMaterialsAndSupplies`

### Decomposition Status

`NOT APPROVED`

---

## 30. Taxonomy Version Evidence

The 2024 and 2025 Official IFRS Element Lists were reviewed for:

`RawMaterialsAndSuppliesCAIFRS`

The reviewed attributes were aligned.

* Japanese Standard Label: `原材料及び貯蔵品`
* Japanese Verbose Label: `原材料及び貯蔵品、流動資産（IFRS）`
* English Standard Label: `Raw materials and supplies`
* English Verbose Label: `Raw materials and supplies - CA (IFRS)`
* Data Type: `xbrli:monetaryItemType`
* Substitution Group: `xbrli:item`
* Period Type: `instant`
* Balance: `debit`
* Abstract: `false`

### Current Finding

`No Material Reviewed Attribute Difference Observed`

between:

`2024 Official IFRS Element List`

and:

`2025 Official IFRS Element List`

for:

`RawMaterialsAndSuppliesCAIFRS`

### Classification

`Cross-version Stability Supported within Reviewed Official Attributes`

### Not Declared

`Universal Taxonomy Definition Identity`

New Taxonomy Versions remain subject to Version Change Review.

---

## 31. Actual Filing Evidence Scope

Initial Cross-company Validation confirmed the exact IFRS Source Concept in:

`Renesas Electronics Corporation`

### Document ID

`S100XR06`

### Accounting Standard

`IFRS`

### Consolidation Scope

`Consolidated`

### Prior Raw Fact

QName:

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

ContextRef:

`Prior1YearInstant`

UnitRef:

`JPY`

Decimals:

`-6`

Raw Value:

`22188000000`

### Current Raw Fact

QName:

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

ContextRef:

`CurrentYearInstant`

UnitRef:

`JPY`

Decimals:

`-6`

Raw Value:

`19928000000`

### Filing Note Meaning

`原材料及び貯蔵品`

### Prior Disclosed Value

`22,188 million JPY`

### Current Disclosed Value

`19,928 million JPY`

### Same-filing Result

`EXACT VALUE MATCH`

### Filing Evidence Classification

`Strong Same-filing Semantic Evidence`

---

## 32. Renesas Component Sum Reconciliation

### Prior

`47,619 + 106,737 + 22,188 = 176,544`

Reported Inventory Total:

`176,544 million JPY`

Result:

`EXACT MATCH`

### Current

`44,538 + 121,437 + 19,928 = 185,903`

Reported Inventory Total:

`185,903 million JPY`

Result:

`EXACT MATCH`

### Research Use

Component Sum supports:

`RawMaterialsAndSuppliesCAIFRS`

being an Inventory Component.

It does not independently prove its detailed semantic meaning.

Primary Semantic Evidence remains:

* Official Standard Label
* Source Concept Identity
* Inventory Note Row
* Cross-standard Official Taxonomy Evidence

---

## 33. Contradicting Evidence Review

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

### Filing Note Meaning Conflict

`NOT IDENTIFIED`

### Evidence that IFRS Concept means Raw Materials only

`NOT IDENTIFIED`

### Evidence that Supplies may be removed

`NOT IDENTIFIED`

### Contradicting Semantic Evidence

`NONE IDENTIFIED within current official and filing evidence scope`

---

## 34. Pre-review Gate Evaluation

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
| RawMaterials Boundary              | DISTINCT                        |
| ProductionSupplies Boundary        | DISTINCT                        |
| Current Asset Qualifier            | PASS WITH BOUNDARY NOTE         |
| Actual IFRS Filing Evidence        | PASS                            |
| Same-filing Value Match            | PASS                            |
| Component Reconciliation           | PASS                            |
| Information Loss                   | MINOR                           |
| Accounting Standard Lineage        | REQUIRED                        |
| Composition Equivalence Boundary   | RECORDED                        |
| Metric Comparability Boundary      | RECORDED                        |
| Atomic Combined Concept Boundary   | RECORDED                        |
| Double-count Risk                  | RECORDED                        |
| Taxonomy Version Review            | PASS WITHIN REVIEWED ATTRIBUTES |

---

## 35. Independent Research Reviewer Decision

Current Official Taxonomy and Filing Evidence strongly support the following Concepts:

`jppfs_cor:RawMaterialsAndSupplies`

and:

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

sharing the same Combined Semantic Core:

`Raw Materials and Supplies Inventory Component`

### Reviewer Decision

`CROSS-STANDARD SEMANTIC EQUIVALENCE PRE-REVIEW = PASS`

### Approved Scope

Proceed to Final Semantic Mapping Research Sheet for:

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

### Canonical Semantic Role Candidate

`RawMaterialsAndSupplies`

### Not Approved

* Production Mapping
* `RawMaterials` Mapping
* Synthetic Decomposition
* Analytical Grouping
* Accounting Measurement Equivalence
* Composition Equivalence
* Metric Comparability
* Automatic Cross-standard ML Pooling

---

## 36. Cross-standard Mapping Gate Status

### Existing Japanese GAAP Mapping

`jppfs_cor:RawMaterialsAndSupplies → RawMaterialsAndSupplies`

Status:

`APPROVED RESEARCH MAPPING`

Architecture Reviewer:

`APPROVED CANONICAL ROLE ADDITION`

### IFRS Candidate

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS → RawMaterialsAndSupplies`

### Current Status

`PRE-REVIEW PASS`

### Expected Mapping Class Candidate

`M1`

`Direct Meaning-preserving Mapping`

Important:

Expected Mapping Class is not Final Approval.

The Final Research Sheet must still evaluate:

* Source Eligibility
* Exact Filing Evidence
* Canonical Role
* Information Loss
* Current Asset qualifier
* Cross-standard Lineage
* Atomic Combined Concept treatment
* RawMaterials overlap risk
* ProductionSupplies overlap risk
* Contradicting Evidence
* Reviewer Conditions

---

## 37. Research Architecture Finding

This Cross-standard Review independently reproduces the Combined Concept Pattern already observed for:

`MerchandiseAndFinishedGoods`

### Pattern

`J-GAAP Combined Standard Concept`

and:

`IFRS Combined Standard Concept`

↓

`Exact Standard Label Alignment`

↓

`Same Combined Semantic Core`

↓

`Meaning-preserving Cross-standard Canonical Role Candidate`

### Current Supported Combined Role Families

1. `MerchandiseAndFinishedGoods`
2. `RawMaterialsAndSupplies`

### Stronger Research Architecture Finding

`Meaning-preserving Combined Canonical Roles are not merely J-GAAP normalization workarounds.`

Equivalent Combined Semantic Structures can exist in multiple Accounting Standard Taxonomy Families.

Therefore:

`Preserve Combined Source Semantics Before Analytical Grouping`

has stronger Cross-standard Evidence.

### Status

`Research Architecture Finding`

Production Canonical Master remains unapproved.

---

## 38. Final Pre-review Result

| Item                                           | Result                                         |
| ---------------------------------------------- | ---------------------------------------------- |
| J-GAAP Target                                  | `jppfs_cor:RawMaterialsAndSupplies`            |
| IFRS Target                                    | `jpigp_cor:RawMaterialsAndSuppliesCAIFRS`      |
| Shared Semantic Core                           | Raw Materials and Supplies Inventory Component |
| Official Standard Label Alignment              | EXACT                                          |
| Official Element Attribute Alignment           | STRONG                                         |
| Actual IFRS Filing Evidence                    | PASS                                           |
| RawMaterials Boundary                          | DISTINCT                                       |
| ProductionSupplies Boundary                    | DISTINCT                                       |
| Combined Semantic Preservation                 | SUPPORTED                                      |
| Cross-standard Semantic Equivalence Pre-review | PASS                                           |
| Final IFRS Mapping Research                    | NEXT                                           |
| Production Mapping                             | NOT APPROVED                                   |
| Composition Equivalence                        | NOT EVALUATED                                  |
| Metric Comparability                           | NOT EVALUATED                                  |

---

## 39. Exact Next Task

### Next Task

Inventory Semantic Mapping Research Sheet for:

`jpigp_cor:RawMaterialsAndSuppliesCAIFRS`

### Canonical Semantic Role Candidate

`RawMaterialsAndSupplies`

### Research Evidence

* Official 2025 EDINET Account List
* Official 2025 EDINET IFRS Element List
* Official 2024 EDINET IFRS Element List
* Official EDINET Concept Handling Guideline
* Japanese GAAP RawMaterialsAndSupplies Mapping Research
* Renesas Raw XBRL Inventory Evidence
* Renesas Inventory Note Evidence
* Cross-standard Official Taxonomy Evidence Review

### Reviewer Focus

1. Can M1 Direct Meaning-preserving Mapping be approved?
2. Is exact IFRS Filing Evidence sufficient?
3. Does Current Asset qualification require Conditional Scope?
4. Must the Combined Concept remain atomic?
5. What Conflict Gate is required with `RawMaterialsCAIFRS`?
6. What Conflict Gate is required with `ProductionSuppliesCAIFRS`?
7. Does Approval remain separate from Analytical Grouping?
8. Does Approval remain separate from Composition Equivalence?
9. Does Approval remain separate from Metric Comparability?

### Mapping Approval Status

`PENDING FINAL RESEARCH SHEET`
