# ROHM EDINET Inventory Prototype Plan

**Research Domain**: Semiconductor Industry
**Research Package**: Automotive Demand
**Research Category**: Data Acquisition Prototype
**Knowledge Scope**: Financial Observation / Inventory
**Target Company**: ROHM Co., Ltd.
**Security Code**: 6963
**EDINET Code**: E01953
**Version**: 0.1
**Status**: Prototype Plan
**Reviewer Status**: Approved for Prototype
**Last Updated**: 2026-07-11

---

# 1. Purpose（目的）

ROHM 1社、有価証券報告書1件、Inventory（棚卸資産）1項目だけを対象として、EDINET APIからPoint-in-time Financial Observation（時点整合財務Observation）を取得できることを検証する。

本Prototypeでは汎用XBRL基盤を作成しない。

検証対象を以下へ限定する。

```text
Company:
ROHM

Security Code:
6963

EDINET Code:
E01953

Document:
Annual Securities Report
（有価証券報告書）

Observation:
Inventory
（棚卸資産）
```

---

# 2. Prototype Success Criteria（成功条件）

以下をすべて確認できた場合、Prototype Successとする。

* EDINET API認証成功
* ROHM提出書類を取得可能
* 有価証券報告書を識別可能
* docIDを取得可能
* submitDateTimeを取得可能
* xbrlFlagを確認可能
* csvFlagを確認可能
* CSV ZIPまたはXBRL ZIPを取得可能
* Inventory候補Conceptを発見可能
* Period Endを特定可能
* Consolidated / Non-consolidatedを区別可能
* Inventory Valueを取得可能
* 原資料へTrace可能

---

# 3. Prototype Failure Criteria（失敗条件）

以下のいずれかの場合、EDINET Source採用を再評価する。

* Inventory Conceptを安定抽出できない
* Context判定が実用上困難
* Company Extension依存が大きすぎる
* CSVとXBRLの値・Contextを照合できない
* Historical Backfillコストが過大
* Reviewerによる手動確認コストが高すぎる

FailureもResearch Resultとして記録する。

---

# 4. API Authentication Requirement（API認証要件）

EDINET API Version 2ではAPIキーを必須とする。

Request Parameter：

```text
Subscription-Key
```

APIキーをソースコードへ直接記載してはならない。

Prototypeでは既存のJ-Quants API Key管理方針と同様に、Configuration経由で取得する方式を候補とする。

例：

```text
EDINET:ApiKey
```

ただし、`appsettings.json` には既に機密情報が存在するため、Git Commit対象へAPI Keyを追加しない。

正式なSecret管理方式はImplementation Phaseで確認する。

---

# 5. Prototype Step 1：API Key Acquisition（APIキー取得）

EDINET API利用アカウントを作成し、APIキーを発行する。

確認項目：

* API Key発行成功
* Key有効性
* Key再発行方法
* Key削除方法

API KeyそのものをResearch Sheetへ記録しない。

---

# 6. Prototype Step 2：Target Filing Date Selection（対象提出日の選択）

最初のPrototypeでは、最新書類を自動探索する処理を作らない。

ROHMの有価証券報告書提出日を1件確認し、その日付だけをDocument List APIへ指定する。

理由：

```text
All Dates Search
```

を最初から作るとPrototype Scopeが広がるため。

Prototypeは、

```text
Known Filing Date
↓
Document List
↓
ROHM Filter
```

とする。

---

# 7. Prototype Step 3：Document List API

Candidate Request：

```text
GET
https://api.edinet-fsa.go.jp/api/v2/documents.json
```

Parameters：

```text
date
type=2
Subscription-Key
```

`type=2`を使用し、提出書類一覧とMetadataを取得する。

Responseから以下を確認する。

```text
docID
edinetCode
secCode
filerName
docTypeCode
periodStart
periodEnd
submitDateTime
xbrlFlag
csvFlag
withdrawalStatus
docInfoEditStatus
disclosureStatus
```

---

# 8. ROHM Filing Filter（ROHM書類絞込）

Prototype Filter Candidate：

```text
edinetCode == "E01953"
```

補助確認：

```text
secCode starts with "6963"
```

提出者名は主Keyとして使用しない。

理由：

表記変更・法人名変更の可能性があるため。

Primary Identifier：

```text
EDINET Code
```

---

# 9. Annual Securities Report Filter（有価証券報告書絞込）

Document Typeは`docTypeCode`で判定する。

正式CodeはEDINET API仕様書別紙の様式・書類種別定義に従う。

Document Description文字列だけで判定する設計は避ける。

---

# 10. Filing Metadata Validation（書類Metadata確認）

対象書類について以下を表示する。

```text
docID
filerName
edinetCode
secCode
docTypeCode
periodStart
periodEnd
submitDateTime
xbrlFlag
csvFlag
```

この段階ではDB保存しない。

Console Outputのみとする。

Prototype Goal：

```text
Correct Filing Identified
```

---

# 11. Prototype Step 4：CSV Acquisition

`csvFlag == "1"`の場合、以下を取得する。

```text
GET
https://api.edinet-fsa.go.jp/api/v2/documents/{docID}
?type=5
&Subscription-Key={API_KEY}
```

取得結果のContent-Typeを確認する。

Success Candidate：

```text
application/octet-stream
```

Error Candidate：

```text
application/json
```

HTTP 200だけで成功判定しない。

---

# 12. Prototype Step 5：ZIP Inspection

CSV ZIPを解凍する。

確認項目：

* File Count
* File Name
* Directory Structure
* Encoding
* CSV Header
* Row Count

最初のPrototypeでは、すべてのCSVをDatabaseへ保存しない。

Raw ZIPを一時保存し、Inventory候補行を検索する。

---

# 13. Inventory Candidate Search（棚卸資産候補検索）

検索候補：

```text
棚卸資産
Inventories
Inventory
```

ただし文字列一致のみで最終Concept確定しない。

候補行について以下を表示する。

```text
Element ID / QName
Japanese Label
English Label
Context
Period
Unit
Value
```

CSV列名は実ファイル確認後に確定する。

---

# 14. Concept Validation（Concept検証）

候補Conceptについて以下を確認する。

* Total Inventoriesか
* Inventory内訳ではないか
* Consolidatedか
* Non-consolidatedか
* Current Periodか
* Prior Periodか
* Instant Contextか
* Period EndがResearch対象期間と一致するか

以下を誤採用しない。

```text
Finished Goods
Work in Process
Raw Materials
Merchandise
Supplies
```

初期対象は、

```text
Total Inventories
```

のみ。

---

# 15. Prototype Step 6：XBRL Comparison

同一`docID`について、

```text
type=1
```

でXBRL ZIPを取得する。

CSVで取得したInventory候補について、XBRL Instanceと以下を比較する。

```text
Concept
Context
Period
Unit
Value
```

## Success Candidate

```text
CSV Value
=
XBRL Instance Value
```

かつ、

```text
Context Meaning
=
Expected Consolidated Current Period End
```

の場合、

CSV Primary Extraction Candidateとする。

---

# 16. Prototype Output（Prototype出力）

Prototypeでは以下だけをConsole表示する。

```text
=== EDINET ROHM INVENTORY PROTOTYPE ===

Company       : ROHM
Security Code : 6963
EDINET Code   : E01953

Document ID   :
Document Type :
Period End    :
Submitted At  :
CSV Available :
XBRL Available:

Inventory Concept :
Inventory Label   :
Context ID        :
Consolidated      :
Period End        :
Unit              :
Value             :

CSV / XBRL Match  :
```

DB保存は行わない。

---

# 17. Prohibited Scope（Prototype禁止範囲）

Prototypeでは以下を実装しない。

* 全企業取得
* 日次EDINET監視Batch
* Database Entity
* Migration
* Generic XBRL Parser
* Taxonomy Mapping Master
* Company Extension自動Mapping
* Knowledge Transformation
* ML Feature生成
* Historical Backfill

目的は、

```text
ROHM 1 Filing
+
Inventory 1 Concept
```

を正しく取得できることの証明である。

---

# 18. Evidence Collection（Evidence収集）

Prototype実行後、以下をResearch Sheetへ追記する。

## Fact

実際に取得できた内容。

## Inference

取得結果から論理的に導ける内容。

## Limitation

確認できなかった内容。

## Operational Cost

実装・確認に要した工数。

## Next Decision

* CSV Primary
* XBRL Primary
* EDINET Conditional
* EDINET Rejected

---

# 19. Reviewer Judgment（レビュアー判定）

## Research Reviewer

**判定：Prototype進行承認**

調査範囲を1社・1書類・1Observationへ限定した判断を支持する。

## Engineering Reviewer

**判定：強く承認**

DB・Entity・Migrationを作成する前に、Console PrototypeでSource Feasibilityを確認する。

Prototypeコードも将来のProduction設計を前提に過剰抽象化しない。

## ADR Reviewer

**判定：承認**

EDINETをProduction Sourceとして採用する判断はまだ行わない。

Prototype Evidence取得後に再レビューする。

---

# 20. Final Decision（現時点の決定）

次のImplementation Research Taskは、

```text
ROHM
+
Known Annual Securities Report Filing Date
+
Document List API
+
CSV Acquisition
+
Inventory Candidate Search
+
XBRL Cross-check
```

とする。

成功後にのみ、複数年度・複数企業へScopeを拡大する。

---

# 21. Next Actions（次の作業）

1. EDINET API Keyを発行する。
2. ROHMの対象有価証券報告書提出日を1件確認する。
3. Document List APIでROHM提出書類を取得する。
4. 対象書類の`docID`を確認する。
5. `csvFlag` / `xbrlFlag`を確認する。
6. CSV ZIPを取得する。
7. Inventory候補Conceptを検索する。
8. XBRL Instanceと値・Contextを比較する。
9. Prototype Evidenceを本Research Sheetへ追記する。
10. EDINET Source採用可否を再レビューする。
