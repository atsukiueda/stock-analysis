# Torex Semiconductor EDINET Inventory Prototype Result

## 1. Purpose

This document records the EDINET inventory extraction validation result for Torex Semiconductor Co., Ltd.

The purpose of this validation is to verify whether inventory values required for semiconductor industry research can be extracted from an EDINET annual securities report using a reusable and evidence-governed extraction strategy.

This artifact is a Research / Validation Result.

It is not a Production Architecture specification.

---

## 2. Validation Target

| Item                  | Value                         |
| --------------------- | ----------------------------- |
| Company               | Torex Semiconductor Co., Ltd. |
| Japanese Company Name | トレックス・セミコンダクター株式会社            |
| Security Code         | 66160                         |
| EDINET Code           | E30479                        |
| Document ID           | S100YFAJ                      |
| Document Type         | 120                           |
| Filing                | Annual Securities Report      |
| Filing Period Start   | 2025-04-01                    |
| Filing Period End     | 2026-03-31                    |
| Submitted At          | 2026-06-23 16:01              |
| Accounting Standard   | Japanese GAAP                 |
| Consolidation Scope   | Consolidated                  |

The target filing was identified from the EDINET Document List API response.

The filing had both CSV and XBRL availability flags enabled.

---

## 3. Filing Discovery Result

The EDINET Document List API returned three documents for Torex Semiconductor on the target filing date.

The annual securities report was identified as:

```text
Document ID   : S100YFAJ
EDINET Code   : E30479
Security Code : 66160
Document Type : 120
Period Start  : 2025-04-01
Period End    : 2026-03-31
Submitted At  : 2026-06-23 16:01
Withdrawal    : 0
Disclosure    : 0
CSV Available : 1
XBRL Available: 1
```

### Filing Discovery Reviewer Result

```text
PASS
```

No filing identity was inferred from company name alone.

The filing identity was confirmed from the EDINET API response.

---

## 4. Accounting Standard Validation

The consolidated audit opinion states that the consolidated financial statements were prepared in accordance with accounting principles generally accepted in Japan.

Therefore:

```text
Accounting Standard:
Japanese GAAP
```

### Accounting Standard Reviewer Result

```text
PASS
```

---

## 5. CSV Package Structure

The EDINET CSV ZIP contained three CSV files.

```text
XBRL_TO_CSV/jpaud-aai-cc-001_E30479-000_2026-03-31_01_2026-06-23.csv

XBRL_TO_CSV/jpaud-aar-cn-001_E30479-000_2026-03-31_01_2026-06-23.csv

XBRL_TO_CSV/jpcrp030000-asr-001_E30479-000_2026-03-31_01_2026-06-23.csv
```

The annual securities report CSV was identified as:

```text
jpcrp030000-asr-001_E30479-000_2026-03-31_01_2026-06-23.csv
```

Inventory component facts were found in the annual securities report CSV.

---

## 6. Inventory Fact Candidates

The following standard taxonomy concepts were identified.

### 6.1 Merchandise and Finished Goods

```text
QName:
jppfs_cor:MerchandiseAndFinishedGoods
```

| Context            | Scope        |             Value |
| ------------------ | ------------ | ----------------: |
| Prior1YearInstant  | Consolidated | 3,259,408,000 JPY |
| CurrentYearInstant | Consolidated | 2,122,350,000 JPY |

---

### 6.2 Work in Process

```text
QName:
jppfs_cor:WorkInProcess
```

| Context            | Scope        |             Value |
| ------------------ | ------------ | ----------------: |
| Prior1YearInstant  | Consolidated | 1,742,980,000 JPY |
| CurrentYearInstant | Consolidated | 2,106,945,000 JPY |

---

### 6.3 Raw Materials and Supplies

```text
QName:
jppfs_cor:RawMaterialsAndSupplies
```

| Context            | Scope        |             Value |
| ------------------ | ------------ | ----------------: |
| Prior1YearInstant  | Consolidated | 1,483,746,000 JPY |
| CurrentYearInstant | Consolidated | 2,257,956,000 JPY |

---

## 7. Inventory Structure Classification

No standalone consolidated total inventory fact was identified as the primary extraction target in the validated candidate set.

The required inventory value can be reconstructed from the following component facts:

```text
MerchandiseAndFinishedGoods
+
WorkInProcess
+
RawMaterialsAndSupplies
```

Therefore the inventory structure is classified as:

```text
Type B
Component Facts Only
```

### Extraction Strategy

```text
Component Sum
```

### Structure Classification Reviewer Result

```text
PASS
```

---

## 8. Derived Inventory Values

### Prior Year

```text
3,259,408,000
+ 1,742,980,000
+ 1,483,746,000
=
6,486,134,000 JPY
```

### Current Year

```text
2,122,350,000
+ 2,106,945,000
+ 2,257,956,000
=
6,487,251,000 JPY
```

Therefore:

```text
Prior Inventory:
6,486,134,000 JPY

Current Inventory:
6,487,251,000 JPY
```

These values are Derived Observations.

They are not standalone source facts.

---

## 9. Inventory YoY Derived Observation

Inventory YoY is calculated as:

```text
Current Inventory
/
Prior Inventory
-
1
```

Result:

```text
6,487,251,000
/
6,486,134,000
-
1
≈ 0.0001722
```

Therefore:

```text
Inventory YoY:
approximately +0.02%
```

### Evidence Classification

```text
Inventory Component Values:
Source Facts

Inventory Total:
Derived Observation

Inventory YoY:
Derived Observation
```

The derived values must not be represented as direct EDINET facts.

---

## 10. Raw XBRL Cross-check

The six consolidated inventory component facts identified in the CSV were cross-checked against the Raw XBRL instance.

### Validation Result

| Concept                     | Context            |     CSV Value | Raw XBRL Value | Result |
| --------------------------- | ------------------ | ------------: | -------------: | ------ |
| MerchandiseAndFinishedGoods | Prior1YearInstant  | 3,259,408,000 |  3,259,408,000 | PASS   |
| MerchandiseAndFinishedGoods | CurrentYearInstant | 2,122,350,000 |  2,122,350,000 | PASS   |
| WorkInProcess               | Prior1YearInstant  | 1,742,980,000 |  1,742,980,000 | PASS   |
| WorkInProcess               | CurrentYearInstant | 2,106,945,000 |  2,106,945,000 | PASS   |
| RawMaterialsAndSupplies     | Prior1YearInstant  | 1,483,746,000 |  1,483,746,000 | PASS   |
| RawMaterialsAndSupplies     | CurrentYearInstant | 2,257,956,000 |  2,257,956,000 | PASS   |

All six facts matched exactly.

The validated Raw XBRL facts used:

```text
Namespace:
http://disclosure.edinet-fsa.go.jp/taxonomy/jppfs/2025-11-01/jppfs_cor

UnitRef:
JPY

Decimals:
-3
```

### Raw XBRL Cross-check Reviewer Result

```text
PASS
```

---

## 11. TextBlock Cross-reference

The consolidated Key Audit Matter concerning inventory valuation states that merchandise and finished goods of:

```text
2,122,350 thousand JPY
```

were recorded in the consolidated balance sheet as of March 31, 2026.

This corresponds to:

```text
2,122,350,000 JPY
```

The amount matches the following structured fact:

```text
jppfs_cor:MerchandiseAndFinishedGoods
ContextRef: CurrentYearInstant
Value: 2122350000
```

This provides an additional financial-meaning cross-reference between the structured fact and the audit disclosure.

The Key Audit Matter also identifies excess inventory recognition and future sales forecasts as important estimation areas.

This TextBlock evidence is contextual evidence.

It is not used as the primary numeric extraction source.

---

## 12. Component Composition Observation

Although total derived inventory was approximately flat year over year, the inventory components changed materially.

Approximate component changes were:

```text
MerchandiseAndFinishedGoods:
-34.9%

WorkInProcess:
+20.9%

RawMaterialsAndSupplies:
+52.2%
```

### Research Observation

```text
Flat total inventory can coexist with
material inventory composition shifts.
```

This observation suggests that total inventory YoY alone may hide economically meaningful changes in inventory composition.

### Evidence Status

```text
Research Observation
```

This is not yet an approved MetricMaster definition.

---

## 13. Research Backlog Candidate

The following candidate should be retained for later Knowledge Transformation review:

```text
Inventory Component Composition Analysis
```

Possible future observation candidates include:

```text
Finished Goods YoY

Work In Process YoY

Raw Materials YoY

Finished Goods Ratio

Work In Process Ratio

Raw Materials Ratio

Inventory Composition Shift
```

These candidates must not be added directly to MetricMaster solely from this validation result.

They require:

```text
Cross-company evidence

Economic interpretation

Predictive / decision value validation

Reviewer approval
```

---

## 14. Cross-company Validation Finding

The following Japanese GAAP semiconductor-related validation targets have now shown the same standard inventory component taxonomy pattern:

```text
ROHM

Fuji Electric

Sanken Electric

Torex Semiconductor
```

The common concepts are:

```text
jppfs_cor:MerchandiseAndFinishedGoods

jppfs_cor:WorkInProcess

jppfs_cor:RawMaterialsAndSupplies
```

### Supported Finding

Four validated Japanese GAAP filings contained the same three standard inventory component concepts for consolidated inventory extraction.

### Not Proven

The following statement is not supported:

```text
All Japanese GAAP companies can always be
extracted using these three concepts.
```

The extraction architecture must continue to support structural variation.

---

## 15. Prototype Conclusion

The Torex Semiconductor validation result is:

```text
Filing Discovery:
PASS

Accounting Standard:
Japanese GAAP

Inventory Structure:
Type B

Extraction Strategy:
Component Sum

CSV Primary Extraction:
PASS

Raw XBRL Cross-check:
PASS

Structured Fact / TextBlock Cross-reference:
PASS
```

### Final Reviewer Decision

```text
PASS
```

Torex Semiconductor supports the current evidence that standard EDINET CSV facts can serve as the primary inventory extraction source for validated Japanese GAAP filings.

However, this result does not justify universal three-concept extraction logic.

The next validation should intentionally test a different accounting taxonomy and reporting structure.

---

## 16. Next Validation Target

The next validation target is:

```text
Kioxia Holdings Corporation
```

Validation purpose:

```text
IFRS taxonomy variation

Inventory total fact availability

Inventory component structure variation

Context structure variation

CSV primary extraction compatibility

Raw XBRL cross-check compatibility
```

The Kioxia validation must be treated as a separate taxonomy validation case.

Japanese GAAP concept assumptions must not be carried into the IFRS validation.
