# EDINET / XBRL Inventory Acquisition Research

**Research Domain**: Semiconductor Industry  
**Research Package**: Automotive Demand  
**Research Category**: Data Source / Acquisition Feasibility  
**Knowledge Scope**: Financial Observation / Inventory  
**Version**: 0.1  
**Status**: Evidence Collection  
**Reviewer Status**: Conditional Approval  
**Last Updated**: 2026-07-11  

---

# 1. Research Objective（研究目的）

EDINET APIおよびXBRL / CSVデータを利用して、

Inventory（棚卸資産）をPoint-in-time
（時点整合）で継続取得できるかを検証する。

本Researchでは以下を確認する。

- 書類提出時点を取得できるか
- 有価証券報告書・半期報告書等を識別できるか
- XBRLまたはCSVを取得できるか
- Inventories（棚卸資産）を抽出できるか
- 企業間の勘定科目差を吸収できるか
- 訂正・取下げ・書類情報修正を追跡できるか
- Historical Dataset構築が現実的か
- J-Quants Premiumと比較して運用コストが妥当か

---

# 2. Research Success Criteria（調査成功条件）

以下のいずれかを判断できた場合、
本Researchは成功とする。

## Success Pattern A

EDINET API + XBRL / CSVにより、
Inventory Observationを継続取得できる。

## Success Pattern B

一部企業・会計基準で取得可能であり、
Conditional Data Sourceとして採用できる。

## Success Pattern C

取得可能だがTaxonomy差・運用コストが高く、
J-Quants Premiumの方が合理的である。

## Success Pattern D

Point-in-time Dataset構築に必要な履歴・Version情報が不足し、
Production Sourceとして採用しない。

---

# 3. EDINET API Architecture（EDINET API構造）

EDINET API Version 2は、
以下の2 APIを提供する。

```text
Document List API
（書類一覧API）

Document Acquisition API
（書類取得API）

基本取得フロー候補は以下とする。
Target Date
↓
Document List API
↓
Document Metadata取得
↓
Target Filing判定
↓
docID取得
↓
Document Acquisition API
↓
XBRL / CSV ZIP取得
↓
Inventory Concept抽出
↓
Raw Observation保存
↓
Normalization
↓
Review
