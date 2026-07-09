# Naming Convention

Version: 1.0

---

# Purpose

本ドキュメントは、日本株AIシステム Knowledge Base における命名規則を定義する。

命名規則の目的は、

* 一貫性
* 可読性
* 保守性
* 検索性
* Explainable AIとの親和性

を維持することである。

Knowledge Baseは長期間利用される資産であるため、短い名前より意味が伝わる名前を優先する。

---

# General Principles

## Rule 1

略称は原則使用しない。

可能な限り正式名称を使用する。

例

NG

```
SEMI
FIN
CONS
MAT
```

OK

```
SEMICONDUCTOR
FINANCIAL
CONSUMER
MATERIALS
```

---

## Rule 2

英語を正式名称とする。

表示名は日本語を利用してよいが、識別子・Code・ファイル名は英語を採用する。

---

## Rule 3

意味の分からない名前は禁止する。

NG

```
DATA1

TEMP

NEW

OTHER

AAA
```

OK

```
SEMICONDUCTOR_EQUIPMENT

OPERATING_MARGIN

ENTERPRISE_SOFTWARE
```

---

## Rule 4

命名は将来の拡張を考慮する。

「現在だけ」を考えた名前は禁止する。

---

# Industry Naming

Industry Code

すべて大文字

単語はアンダースコア区切り

例

```
SEMICONDUCTOR

ENTERPRISE_SOFTWARE

IT_SERVICES

MEDICAL_DEVICES
```

---

# SubSector Naming

Industryを含める。

例

```
SEMICONDUCTOR_EQUIPMENT

SEMICONDUCTOR_DEVICES

SEMICONDUCTOR_MATERIALS

ENTERPRISE_SOFTWARE_ERP

ENTERPRISE_SOFTWARE_SECURITY
```

SubSector単独で見ても意味が分かる名前とする。

---

# Metric Naming

MetricCode

英語

大文字

例

```
ROE

OPERATING_MARGIN

BOOK_TO_BILL

ORDER_BACKLOG

FREE_CASH_FLOW_MARGIN
```

MetricCodeは永続的な識別子である。

原則変更しない。

---

# Rule Naming

ルール名は目的が分かる名称とする。

例

```
HIGH_DIVIDEND

LOW_PBR

QUALITY_GROWTH

CYCLICAL_BOTTOM
```

---

# File Naming

## Company Research

```
<Code>_<CompanyName>.md
```

例

```
8035_東京エレクトロン.md

6857_アドバンテスト.md
```

---

## Industry Research

```
<IndustryCode>.md
```

例

```
SEMICONDUCTOR.md

ENTERPRISE_SOFTWARE.md
```

---

## SubSector Research

```
<SubSectorCode>.md
```

例

```
SEMICONDUCTOR_EQUIPMENT.md
```

---

## Governance Documents

PascalCaseを採用する。

例

```
KnowledgeBaseRules.md

ResearchPolicy.md

ReviewPolicy.md

NamingConvention.md

DecisionLog.md

ArchitectureBacklog.md
```

---

# Folder Naming

フォルダ名は番号＋PascalCaseを採用する。

例

```
00_Governance

01_Catalog

02_Research

03_ReviewTracker

04_DDL

05_Architecture

06_DataDictionary

07_AI_Workspace
```

番号は将来変更しない。

---

# Database Naming

テーブル

複数形

PascalCase

例

```
Companies

IndustryMasters

SubSectorMasters

MetricMasters
```

カラム

PascalCase

例

```
IndustryCode

SubSectorCode

MetricCode

ReviewStatus
```

---

# Enum Naming

PascalCase

例

```
ResearchStatus

ReviewStatus

EvidenceStatus
```

Enum値

PascalCase

例

```
Researching

Reviewed

Approved

EvidenceVerified

ProductionReady
```

---

# Status Naming

Research Status

```
Researching

Reviewed

Approved

EvidenceVerified

ProductionReady
```

Evidence Status

```
Draft

OfficialIrReviewed

BacktestVerified

MlVerified

ProductionVerified
```

---

# Reserved Words

以下はKnowledge Baseで使用しない。

```
Other

General

Misc

Temp

Test

New

Unknown

Etc
```

意味のある名称を付与すること。

---

# Naming Review Checklist

命名時は以下を確認する。

□ 名前だけで意味が分かる

□ 略称を使用していない

□ 英語表記で統一されている

□ 将来も利用できる

□ Advisorで説明可能

□ Research Sheetと一致している

□ Catalogと一致している

□ DBへそのまま反映可能

---

# Rename Policy

正式採用後の名称変更は原則禁止とする。

変更が必要な場合は、

1. DecisionLogへ記録
2. 影響範囲を確認
3. Catalog更新
4. DDL・Entity・実装へ反映

の手順で実施する。

---

# Final Principle

命名はKnowledge Base全体の共通言語である。

短さではなく、

意味が伝わること

長期間保守できること

AI・人の双方が理解できること

を最優先とする。
