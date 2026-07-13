# Inventory Semantic Mapping Research Sheet

# jpigp_cor:InventoriesCAIFRS

## 1. Document Purpose

本書は、EDINET Inventory Semantic Mapping Research Designに基づき、

```text
jpigp_cor:InventoriesCAIFRS
```

をCanonical Inventory Semantic RoleへMapping可能か検証するResearch Sheetである。

Mapping Candidate：

```text
Source Concept:
jpigp_cor:InventoriesCAIFRS

Canonical Semantic Role Candidate:
InventoryTotal
```

本書の目的はProduction Mapping Masterを作成することではない。

目的は以下である。

> Initial 7-company Cross-company Validationで確認したIFRS Inventory Total Conceptについて、Source Meaning、Financial Statement Context、Taxonomy Version Variation、Cross-company ReproductionおよびPrimary Total Source Fact適格性をEvidenceに基づいて評価する。

Status：

```text
Research Sheet
Semantic Mapping Research
Reference Mapping Case
Research Reviewer Pending
Production Mapping Not Approved
```

---

# 2. Research Target

## Source Concept QName

```text
jpigp_cor:InventoriesCAIFRS
```

## Local Name

```text
InventoriesCAIFRS
```

## Prefix

```text
jpigp_cor
```

## Accounting Standard Candidate

```text
IFRS
```

## Canonical Semantic Role Candidate

```text
InventoryTotal
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
Does InventoriesCAIFRS represent total inventories?

2.
Is the concept used as a consolidated instant balance fact?

3.
Is the financial meaning reproduced across companies?

4.
Does taxonomy version variation materially change the observed meaning?

5.
Can the concept be used as the primary total inventory source fact?

6.
Is component sum reconciliation consistent with the total fact?

7.
Is there known contradictory evidence?

8.
What information loss occurs when mapping to InventoryTotal?

9.
What mapping confidence is justified?

10.
What reviewer decision is justified?
```

---

# 4. Evidence Scope

Initial Cross-company Validationでは以下2社で対象Conceptを確認した。

```text
Kioxia Holdings Corporation

Renesas Electronics Corporation
```

Accounting Standard：

```text
IFRS
```

Observed Filing Count：

```text
2
```

Observed Company Count：

```text
2
```

Observed Taxonomy Version Candidate：

```text
jpigp/2024-11-01

jpigp/2025-11-01
```

---

# 5. Evidence Case A

# Kioxia Holdings

## Company Identity

```text
Company:
キオクシアホールディングス株式会社

English Name:
Kioxia Holdings Corporation

Security Code:
285A0

EDINET Code:
E35948
```

## Filing Identity

```text
Document ID:
S100YJ18

Document Type:
120

Period Start:
2025-04-01

Period End:
2026-03-31

Submitted At:
2026-06-24 11:15
```

Accounting Standard：

```text
IFRS
```

---

# 6. Kioxia Source Concept Identity

QName：

```text
jpigp_cor:InventoriesCAIFRS
```

Namespace URI：

```text
http://disclosure.edinet-fsa.go.jp/taxonomy/jpigp/2025-11-01/jpigp_cor
```

Local Name：

```text
InventoriesCAIFRS
```

Observed Label：

```text
棚卸資産、流動資産（IFRS）
```

Taxonomy Version Candidate：

```text
2025-11-01
```

---

# 7. Kioxia Raw Financial Facts

Prior：

```text
ContextRef:
Prior1YearInstant

UnitRef:
JPY

Decimals:
-6

Raw Value:
352863000000
```

Current：

```text
ContextRef:
CurrentYearInstant

UnitRef:
JPY

Decimals:
-6

Raw Value:
412612000000
```

Classification：

```text
Numeric Fact
Instant
Consolidated Candidate
Monetary
JPY
```

Eligibility Candidate：

```text
Eligible Inventory Balance Fact
```

---

# 8. Kioxia Financial Statement Context

Inventory Noteでは以下のComponent Structureを確認した。

```text
Finished Goods

Semi-finished Products and Work in Progress

Raw Materials

Other Inventories
```

Prior Component Sum：

```text
50,549
+
283,746
+
18,486
+
82
=
352,863 million JPY
```

Reported Total Fact：

```text
352,863 million JPY
```

Result：

```text
EXACT MATCH
```

Current Component Sum：

```text
53,232
+
280,183
+
79,093
+
104
=
412,612 million JPY
```

Reported Total Fact：

```text
412,612 million JPY
```

Result：

```text
EXACT MATCH
```

Research Finding：

```text
InventoriesCAIFRS
is consistent with
the total of disclosed inventory components.
```

Classification：

```text
Supporting Evidence
```

Component SumだけでSemantic Meaningを証明するものではない。

---

# 9. Evidence Case B

# Renesas Electronics

## Company Identity

```text
Company:
ルネサスエレクトロニクス株式会社

English Name:
Renesas Electronics Corporation

Security Code:
67230

EDINET Code:
E02081
```

## Filing Identity

```text
Document ID:
S100XR06

Document Type:
120

Period Start:
2025-01-01

Period End:
2025-12-31

Submitted At:
2026-03-19 14:22
```

Accounting Standard：

```text
IFRS
```

---

# 10. Renesas Source Concept Identity

QName：

```text
jpigp_cor:InventoriesCAIFRS
```

Namespace URI：

```text
http://disclosure.edinet-fsa.go.jp/taxonomy/jpigp/2024-11-01/jpigp_cor
```

Local Name：

```text
InventoriesCAIFRS
```

Observed Label：

```text
棚卸資産、流動資産（IFRS）
```

Taxonomy Version Candidate：

```text
2024-11-01
```

---

# 11. Renesas Raw Financial Facts

Prior：

```text
ContextRef:
Prior1YearInstant

UnitRef:
JPY

Decimals:
-6

Raw Value:
176544000000
```

Current：

```text
ContextRef:
CurrentYearInstant

UnitRef:
JPY

Decimals:
-6

Raw Value:
185903000000
```

Classification：

```text
Numeric Fact
Instant
Consolidated Candidate
Monetary
JPY
```

Eligibility Candidate：

```text
Eligible Inventory Balance Fact
```

---

# 12. Renesas Financial Statement Context

Inventory Noteでは以下のComponent Structureを確認した。

```text
Merchandise and Finished Goods

Work in Process

Raw Materials and Supplies
```

Prior Component Sum：

```text
47,619
+
106,737
+
22,188
=
176,544 million JPY
```

Reported Total Fact：

```text
176,544 million JPY
```

Result：

```text
EXACT MATCH
```

Current Component Sum：

```text
44,538
+
121,437
+
19,928
=
185,903 million JPY
```

Reported Total Fact：

```text
185,903 million JPY
```

Result：

```text
EXACT MATCH
```

Raw XBRL Inventory Note TextBlockでも、

```text
商品及び製品

仕掛品

原材料及び貯蔵品

合計
```

の構成及びTotal Valueを確認した。

Research Finding：

```text
InventoriesCAIFRS
is consistent with
the total inventory disclosed in the inventory note.
```

Classification：

```text
Supporting Evidence
```

---

# 13. Cross-company Reproduction

Kioxia Holdings：

```text
QName:
jpigp_cor:InventoriesCAIFRS

Label:
棚卸資産、流動資産（IFRS）

Context:
Prior1YearInstant
CurrentYearInstant

Unit:
JPY
```

Renesas Electronics：

```text
QName:
jpigp_cor:InventoriesCAIFRS

Label:
棚卸資産、流動資産（IFRS）

Context:
Prior1YearInstant
CurrentYearInstant

Unit:
JPY
```

Observed Meaning：

```text
Consolidated Current Inventory Total
```

Cross-company Result：

```text
REPRODUCED
```

Observed Company Count：

```text
2
```

Evidence Strength Candidate：

```text
Cross-company Supported
```

Limitation：

```text
Only two IFRS companies validated.
```

---

# 14. Taxonomy Version Comparison

## Kioxia

```text
Namespace Version:
2025-11-01
```

## Renesas

```text
Namespace Version:
2024-11-01
```

Local Name：

```text
InventoriesCAIFRS
```

同一。

Observed Label：

```text
棚卸資産、流動資産（IFRS）
```

同一。

Observed Financial Statement Role：

```text
Inventory Total
```

整合。

Observed Context Pattern：

```text
Prior1YearInstant
CurrentYearInstant
```

整合。

Observed Unit：

```text
JPY
```

整合。

## Current Taxonomy Version Finding

```text
No material observed meaning difference
between the 2024-11-01 and 2025-11-01
validated filing cases.
```

Classification：

```text
Cross-version Mapping Candidate
```

Important：

本ResearchはTaxonomy Definition全文比較を完了したものではない。

したがって、

```text
Taxonomy Meaning Proven Identical
```

とは記載しない。

Observed Filing Evidence上、

```text
No Material Meaning Difference Observed
```

とする。

---

# 15. Source Label Evaluation

Observed Label：

```text
棚卸資産、流動資産（IFRS）
```

Canonical Candidate：

```text
InventoryTotal
```

Label Meaningは、

```text
Inventories
```

に直接対応する。

また、

```text
流動資産
```

はFinancial Statement Classificationであり、
Inventory Component Typeではない。

Mapping Candidate：

```text
InventoriesCAIFRS
→
InventoryTotal
```

Source Meaning Compatibility：

```text
DIRECT
```

---

# 16. Accounting Context Evaluation

対象Factは両社で、

```text
Instant
```

である。

InventoryはBalance Sheet / Statement of Financial Position上のStock Value Candidateである。

以下のDuration Factとは明確に異なる。

```text
jpigp_cor:
DecreaseIncreaseInInventoriesOpeCFIFRS
```

Duration Fact：

```text
Prior1YearDuration
CurrentYearDuration
```

Financial Meaning：

```text
Cash Flow Inventory Change
```

Therefore：

```text
InventoriesCAIFRS
≠
DecreaseIncreaseInInventoriesOpeCFIFRS
```

Eligibility Separation：

```text
PASS
```

---

# 17. Consolidation Scope Evaluation

対象FactのObserved ContextRef：

```text
Prior1YearInstant

CurrentYearInstant
```

同一Filing内には個別財務諸表のInventory-related `jppfs_cor` Factが存在する場合がある。

Example：

Renesas：

```text
jppfs_cor:FinishedGoods

ContextRef:
CurrentYearInstant_NonConsolidatedMember
```

したがって、

```text
Inventory Concept Search
```

だけでは連結・個別を分離できない。

対象`InventoriesCAIFRS` FactについてはValidated Filing上、

```text
Consolidated Financial Statements
```

のInventory Totalとして使用されている。

Consolidation Eligibility Candidate：

```text
PASS
```

Important：

```text
CurrentYearInstant
=
Always Consolidated
```

というGeneric Context Ruleを本Researchで確定しない。

Source Filing Structure及びContext SemanticsのValidationを維持する。

---

# 18. Unit Evaluation

Observed Unit：

```text
JPY
```

Kioxia：

```text
JPY
```

Renesas：

```text
JPY
```

Canonical Observation Candidate：

```text
InventoryTotal
```

はMonetary Observationである。

Unit Compatibility：

```text
PASS
```

Production Candidate Rule：

```text
Monetary Inventory Total
requires validated monetary unit.
```

ただしProduction Unit Conversion Ruleは本Research Scope外。

---

# 19. Decimals Evaluation

Observed Decimals：

```text
-6
```

Kioxia：

```text
-6
```

Renesas：

```text
-6
```

DecimalsはSemantic Mappingそのものを決定するEvidenceではない。

しかし、

```text
Source Fact Precision
```

および、

```text
Component Reconciliation
```

のValidation Metadataとして重要である。

Mapping Decision：

```text
Decimals do not change
InventoryTotal semantic role.
```

Lineage Requirement Candidate：

```text
Preserve Decimals.
```

---

# 20. Information Loss Evaluation

Source Concept：

```text
InventoriesCAIFRS
```

Canonical Role：

```text
InventoryTotal
```

Source Meaning Candidate：

```text
Total inventories classified as current assets under IFRS presentation.
```

Canonical Meaning：

```text
Total inventory observation.
```

Potential Information Loss：

```text
Current asset presentation classification
is not represented directly in the semantic role name.
```

Evaluation：

```text
Information Loss:
Minor
```

Reason：

本ComponentのPrimary PurposeはInventory Adjustment Observationであり、

```text
Current vs Non-current Inventory Classification
```

を現時点のCanonical Roleで分析対象としていない。

ただし将来、Non-current Inventory Conceptが確認された場合は再評価が必要。

---

# 21. Double-count Risk Evaluation

Kioxia及びRenesasでは、

```text
InventoryTotal
```

とComponent Factsが同時に存在する。

したがって以下は禁止。

```text
InventoryTotal
+
FinishedGoods
+
WorkInProcess
+
RawMaterials
```

Inventory Total Strategy Candidate：

```text
InventoriesCAIFRS
=
Primary Total Source Fact
```

Component Facts：

```text
Composition Observation
or
Reconciliation Evidence
```

Double-count Risk：

```text
HIGH if role usage is not separated.
```

Mapping itself：

```text
InventoryTotal
```

へ割り当てることでTotal Roleを明確化する。

Reviewer Requirement：

```text
Downstream calculation must distinguish
Total and Component semantic roles.
```

---

# 22. Contradicting Evidence Search

Initial Validation Evidence内で以下を確認した。

```text
Same Concept used as a Duration Cash Flow Fact:
NOT OBSERVED

Same Concept used as a NonConsolidated Inventory Component:
NOT OBSERVED

Same Concept used for a non-inventory financial meaning:
NOT OBSERVED

Same Concept mapped to a component subtotal:
NOT OBSERVED
```

Observed Kioxia Meaning：

```text
Inventory Total
```

Observed Renesas Meaning：

```text
Inventory Total
```

Contradicting Evidence：

```text
NONE IDENTIFIED
within current validated sample.
```

Important：

```text
No Contradicting Evidence Identified
≠
Universal Meaning Proven
```

---

# 23. Primary Total Source Fact Evaluation

Kioxia：

```text
Source Total Fact exists.

Component Sum matches Total.
```

Renesas：

```text
Source Total Fact exists.

Component Sum matches Total.
```

Therefore：

```text
Use validated InventoriesCAIFRS
as Primary Total Source Fact Candidate.
```

This is preferred over：

```text
Recalculate Total from Components
and replace source total.
```

Reason：

```text
Source Fact
>
Equivalent Derived Observation
```

Primary Total Source Fact Eligibility：

```text
PASS
```

---

# 24. Canonical Role Candidate Evaluation

Candidate：

```text
InventoryTotal
```

Alternative Candidate：

```text
CurrentInventoryTotal
```

Concern：

Source Labelには、

```text
流動資産
```

が含まれる。

しかしInitial Inventory Adjustment Componentでは、

```text
Total Inventories
```

をPrimary Common Observationとしている。

Current SampleでNon-current Inventory Total ConceptとのConflictは確認していない。

Reviewer Candidate：

```text
InventoryTotal
```

を維持する。

However：

```text
Non-current inventory concept detected
```

の場合、

```text
Canonical Role Boundary Review
```

を必須とする。

---

# 25. Mapping Confidence Evaluation

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

Source Label:
PASS

Financial Statement Context:
PASS

Cross-company Reproduction:
PASS

Component Reconciliation:
PASS

Contradicting Evidence:
NONE IDENTIFIED
```

Mapping Confidence Candidate：

```text
M1
Direct Standard Mapping
```

---

# 26. Researcher Proposal

## Proposed Mapping

```text
Source Concept:
jpigp_cor:InventoriesCAIFRS

Canonical Semantic Role:
InventoryTotal
```

Proposed Mapping Class：

```text
M1
Direct Standard Mapping
```

Proposed Scope：

```text
Validated IFRS Inventory Total Fact
```

Taxonomy Version Scope Candidate：

```text
jpigp/2024-11-01

jpigp/2025-11-01
```

Proposed Usage：

```text
Primary Inventory Total Source Fact
```

Subject to：

```text
Eligibility Validation

Consolidation Validation

Instant Period Validation

Monetary Unit Validation
```

---

# 27. Researcher Evidence Summary

Supporting Evidence：

```text
Standard IFRS presentation taxonomy concept

Direct inventory total label

Kioxia filing evidence

Renesas filing evidence

Two taxonomy versions observed

Instant context

JPY monetary unit

Component sum reconciliation in both companies

No contradictory meaning observed
```

Known Limitation：

```text
Only two IFRS companies validated.

Taxonomy formal definition comparison
has not been independently completed.

Non-current inventory concept conflict
has not been broadly researched.
```

Researcher Decision Candidate：

```text
APPROVE MAPPING
```

---

# 28. Independent Research Reviewer Review

## Review Question 1

Was the Mapping accepted only because the Concept name looks obvious?

Decision：

```text
NO
```

Evidence includes：

```text
Official source label

Financial statement context

Inventory note reconciliation

Cross-company reproduction
```

---

## Review Question 2

Was Component Sum misused as sole Semantic Evidence?

Decision：

```text
NO
```

Component Sum is Supporting Evidence only.

Primary Evidence：

```text
Structured Concept

Source Label

Financial Statement Role
```

---

## Review Question 3

Is the Canonical Role overly simplified?

Potential Issue：

```text
Current asset classification
is omitted from InventoryTotal role.
```

Reviewer Judgment：

```text
ACCEPTABLE WITH BOUNDARY NOTE
```

Reason：

Current Research Scope targets total inventory for Inventory Adjustment Observation.

Future non-current inventory evidence requires Canonical Role Boundary Review.

---

## Review Question 4

Is there Double-count Risk?

Decision：

```text
YES
```

However Mapping itself is not rejected.

Required Governance：

```text
InventoryTotal
must remain distinct from
Inventory Component roles.
```

---

## Review Question 5

Does Taxonomy Version Variation create a Conflict?

Observed：

```text
2024-11-01

2025-11-01
```

Reviewer Judgment：

```text
NO MATERIAL OBSERVED MEANING DIFFERENCE
```

Formal universal cross-version equivalence is not declared.

---

# 29. Research Reviewer Decision

```text
APPROVE
```

Approved Mapping Candidate：

```text
jpigp_cor:InventoriesCAIFRS
→
InventoryTotal
```

Mapping Confidence：

```text
M1
Direct Standard Mapping
```

Approved Observed Taxonomy Versions：

```text
jpigp/2024-11-01

jpigp/2025-11-01
```

Scope：

```text
Validated IFRS consolidated
instant monetary inventory total facts.
```

Usage Candidate：

```text
Primary Inventory Total Source Fact
```

---

# 30. Reviewer Conditions

Approval is subject to the following conditions.

```text
1.
Original QName and Namespace URI must be preserved.

2.
Original ContextRef must be preserved.

3.
Eligibility validation must confirm instant balance semantics.

4.
Consolidated and NonConsolidated facts must not be mixed.

5.
Unit must be validated before canonical observation creation.

6.
Decimals must be preserved as source evidence.

7.
InventoryTotal must not be added to component values.

8.
Future non-current inventory concept detection triggers boundary review.

9.
New taxonomy versions require version change review.

10.
Mapping approval does not authorize Production implementation.
```

---

# 31. Mapping Approval Gate Result

```text
Source Concept Identity:
CONFIRMED

Eligibility:
PASS

Financial Meaning Evidence:
SUFFICIENT

Canonical Role Candidate:
DEFINED

Information Loss:
EVALUATED
MINOR

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

# 32. Architecture Reviewer Requirement

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

Existing Research Architecture Boundary内でApproval可能。

---

# 33. Final Mapping Research Result

```text
SOURCE CONCEPT:
jpigp_cor:InventoriesCAIFRS

CANONICAL SEMANTIC ROLE:
InventoryTotal

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

# 34. Research Procedure Validation Result

本SheetはInventory Semantic Mapping Research Designの最初のReference Mapping Caseである。

Procedure Evaluation：

```text
Source Identity Review:
WORKED

Eligibility Review:
WORKED

Financial Context Review:
WORKED

Cross-company Reproduction Review:
WORKED

Taxonomy Version Review:
WORKED

Information Loss Review:
WORKED

Double-count Review:
WORKED

Reviewer Independence Check:
WORKED
```

Research Procedure Result：

```text
PASS
```

Current Procedureは次のMapping Research Caseへ使用可能。

---

# 35. Current Mapping Research State

```text
Approved Research Mapping Candidates:

1.
jpigp_cor:InventoriesCAIFRS
→
InventoryTotal
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

# 36. Exact Next Task

次のMapping Research Targetは以下とする。

```text
jppfs_cor:WorkInProcess
```

Canonical Role Candidate：

```text
WorkInProcess
```

Purpose：

> Japanese GAAP 5-company Cross-company Evidenceを使用し、Standard Taxonomy Component MappingのReference CaseをValidationする。

Observed Companies：

```text
ROHM

Fuji Electric

Sanken Electric

Torex Semiconductor

Tokyo Electron
```

Research Focus：

```text
Cross-company reproduction

J-GAAP standard taxonomy meaning

Context stability

Taxonomy version evidence

Information loss

Double-count risk

Component role eligibility
```

Expected Mapping Confidence Candidate：

```text
M1
Direct Standard Mapping
```

ただしExpected Resultを前提にApproveしない。

Evidence及びReviewer Gateを通す。
