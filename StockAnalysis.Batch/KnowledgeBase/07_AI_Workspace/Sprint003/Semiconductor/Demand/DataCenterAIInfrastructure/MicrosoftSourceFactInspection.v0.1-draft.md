# Microsoft — Data Center / AI Infrastructure Source Fact Inspection

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft Source Fact inspection |
| Sprint | Sprint003 |
| 対象企業 | Microsoft Corporation |
| Version | 0.1-draft |
| 作成日 | 2026-07-30 |
| Retrieval Date | 2026-07-30 |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Reviewer Status | Evidence / Knowledge / Traceability final disposition `Accepted` |
| Related Review Record | `MicrosoftSourceFactInspectionIndependentReview.v0.1-draft.md` |
| Evidence ID | None — 本文書の`MSFT-SFI-xxx`はLocal inspection IDであり、Evidence IDではない |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md` |
| Stage 0 | `Sprint003DataCenterAIInfrastructureStage0IndependentReview.v0.1-draft.md` — Accepted |

> **利用境界：** 本文書はSource Fact候補をRaw Evidence化する前の検査記録である。候補のEvidence採用、`S3-EVR-xxx`又は`S3-PIT-xxx`の発行、`AvailableAt`の確定、Catalog / DDL / ML利用を許可しない。

## 1. Research Questions

| Research Question | Microsoftでの確認対象 |
| --- | --- |
| `S3-DCAI-RQ-001` | Data Center、Cloud及びAI Infrastructureの発行者用語 |
| `S3-DCAI-RQ-002` | 投資、能力増強、設備及び需要の開示粒度 |
| `S3-DCAI-RQ-005` | 需要側投資とサーバー、GPU又は半導体関連構成要素との発行者明示関係 |
| `S3-DCAI-RQ-006` | Actual、Commitment、Plan及びNarrativeの分類差 |

## 2. Inspected Official Sources

| Source | Publication Event | Applicable Period | Official location | Inspection status |
| --- | --- | --- | --- | --- |
| Microsoft, *Annual Report / Form 10-K 2025* | SEC filed 2025-07-30; accepted 2025-07-30 16:11:40 ET | FY ended 2025-06-30 | [SEC filing index](https://www.sec.gov/Archives/edgar/data/789019/000095017025100235/0000950170-25-100235-index.html)、[Microsoft online Annual Report](https://www.microsoft.com/investor/reports/ar25/index.html) | Source Fact inspection completed for listed positions |
| Microsoft, *FY2026 Q3 Earnings Release* | 2026-04-29; release time `Unknown`; conference call 14:30 PT is a separate event | Three and nine months ended 2026-03-31 | [Official earnings release](https://www.microsoft.com/en-us/investor/earnings/FY-2026-Q3/press-release-webcast)、[Performance](https://www.microsoft.com/en-us/investor/earnings/FY-2026-Q3/performance) | Source Fact inspection completed for listed positions |
| Microsoft, *2024 Annual Shareholders Meeting Transcript* | Event 2024-12-10; page publication time/timezone `Unknown` | FY2024 results及びFY2025時点の経営説明 | [Official event transcript](https://www.microsoft.com/en-us/investor/events/fy-2025/2024-annual-shareholder-meeting) | Source Fact inspection completed for listed positions |
| Microsoft, *2025 Annual Report — Shareholder Letter* | Letter dated 2025-10-15; page publication time/timezone `Unknown` | FY2025及びletter date時点の説明 | [Official shareholder letter](https://www.microsoft.com/investor/reports/ar25/index.html) | Source Fact inspection completed for listed positions |

## 3. Source Fact Candidate Assessment

| Local ID | Source position | Classification | Source Fact candidate | Use boundary | Cross-sprint check | Raw Evidence recommendation |
| --- | --- | --- | --- | --- | --- | --- |
| MSFT-SFI-001 | 2025 Form 10-K, `Business → Operations` | Issuer narrative / Actual operating dependency | Microsoftは顧客ニーズ、特にAIサービス需要の増加を踏まえてData Center所在地及びserver capacityを調整している。Data Centerはland、energy、networking supplies及びGPUを含むservers / componentsの供給に依存すると記載する。 | Microsoft固有の運用・依存関係。GPU以外の半導体、数量、購入額、供給者又は需要因果を確定しない。 | Stage 0固定集合で既存matchなし | **Proceed** — issuer-named demand / infrastructure / GPU relationship |
| MSFT-SFI-002 | 2025 Form 10-K, `Cash Flows Statements → Investing` | Direct quantitative observation / Actual | Additions to property and equipmentはFY2025 USD64,551m、FY2024 USD44,477m、FY2023 USD28,107m。Cash Flow原表はoutflowとして括弧付き負数表示であり、ここではadditions amountの絶対額を記載する。 | 全社Property and Equipment additions。Data Center、AI又は半導体へ配賦しない。Raw Evidenceでは原表の符号表示も保持する。 | 既存matchなし | **Proceed** — investment baseline with explicit non-allocation |
| MSFT-SFI-003 | 2025 Form 10-K, `Note 6 — Property and Equipment` | Direct quantitative observation / Commitment | 2025-06-30時点で、新規建物、建物改良及びleasehold improvementsのconstruction commitmentはUSD32.1bnで、主としてData Center関連と記載する。 | CommitmentでありActual支出ではない。半導体、server又はGPU購入額ではない。 | 既存matchなし | **Proceed** — datacenter-linked commitment |
| MSFT-SFI-004 | 2025 Form 10-K, `Material Cash Requirements and Other Obligations` | Direct quantitative observation / Commitment | 2025-06-30時点のpurchase commitmentsはFY2026 USD103,940m、thereafter USD6,013m、total USD109,953m。注記は主としてData Center関連で、construction commitmentsに含まれないopen purchase orders及びtake-or-pay contractsを含むとする。 | Commitmentであり支出、Capex又は半導体購入実績ではない。対象品目の内訳は未開示。 | 既存matchなし | **Proceed** — datacenter-linked purchase commitment with strict boundary |
| MSFT-SFI-005 | 2025 Form 10-K, `Other Planned Uses of Capital` | Plan / issuer narrative | MicrosoftはCloud offeringsの成長並びにAI Infrastructure及びtrainingへの投資を支えるため、capital expendituresへの投資を継続すると記載する。 | 将来方針。金額、期間、実行又は半導体需要量を確定しない。 | 既存matchなし | **Proceed** — Plan separated from Actual |
| MSFT-SFI-006 | FY2026 Q3 Earnings Release, `Cash Flows Statements → Investing` | Direct quantitative observation / Actual | Additions to property and equipmentは3か月でUSD30,876m（前年同期USD16,745m）、9か月でUSD80,146m（前年同期USD47,472m）。Cash Flow原表はoutflowとして括弧付き負数表示であり、ここではadditions amountの絶対額を記載する。 | 全社Property and Equipment additions。Data Center、AI又は半導体へ配賦しない。未監査四半期数値。Raw Evidenceでは原表の符号表示も保持する。 | 既存matchなし | **Proceed** — latest investment baseline |
| MSFT-SFI-007 | FY2026 Q3 `Performance` | Issuer narrative / Actual-period performance explanation | MicrosoftはAI Infrastructureへの継続投資とAI product usage増加がgross margin percentage低下要因であり、R&D compute capacityへの投資等がoperating expenses増加要因と説明する。 | 費用・利益率要因の経営説明。投資額、capacity量、半導体需要又は単独因果を定量化しない。 | 既存matchなし | **Proceed** — latest infrastructure-investment narrative |
| MSFT-SFI-008 | FY2026 Q3 Earnings Release, `Business Highlights` | Direct quantitative observation and issuer narrative / Actual | Microsoft Cloud revenueはUSD54.5bn、前年比+29%であり、経営者はMicrosoft Cloudへの需要増を説明する。Azure and other cloud services revenueは前年比+40%。 | Cloud revenue / growthであり、Data Center投資、AI需要又は半導体需要の代理値として無条件に使用しない。 | 既存matchなし | **Proceed with caution** — demand-side context only |
| MSFT-SFI-009 | 2024 Annual Shareholders Meeting, CFO remarks and Q&A | Issuer narrative / Actual and forward-looking explanation | MicrosoftはCloud / AI services需要との整合のためCapexを増加させたと説明し、AI platformを構築し顧客・partner需要に対応するにはglobal infrastructureへのmeaningful capital investmentが必要と説明する。 | 2024-12-10時点の経営説明。Capex金額、製品内訳、半導体企業との関係又は将来実現を確定しない。 | 既存matchなし | **Proceed** — issuer-named demand-to-investment relationship |
| MSFT-SFI-010 | 2025 Shareholder Letter, `Our Cloud and AI Infrastructure` | Capacity observation / issuer narrative | Microsoftは400超のData Centerを70 regionsで運営し、当該年に2GW超のnew capacityを追加したと記載する。 | Shareholder Letter固有の表現。`当該年`の厳密な開始日、電力capacityの測定範囲、Data Center別内訳及び半導体需要への変換は未確認。 | 既存matchなし | **Hold** — period / measurement boundary requires Raw Evidence review before adoption |

## 4. Excluded or Non-convertible Statements

| Statement family | Disposition | Reason |
| --- | --- | --- |
| Total additions to property and equipmentをData Center Capexとみなす | Excluded | 発行者は全額をData Center、Cloud又はAIへ配賦していない。 |
| Data Center commitmentをGPU又は半導体購入額とみなす | Excluded | 建物、設備、leasehold、open purchase orders及びtake-or-payの品目内訳が不足。 |
| Microsoft Cloud / Azure growthを半導体需要成長率とみなす | Excluded | サービス売上と半導体需要を結ぶ変換根拠がない。 |
| MicrosoftのCapexからRenesas、ROHM、Infineon又はNVIDIA売上を推定する | Excluded | Microsoftは対象Source Setで供給者別購入額又は因果を開示していない。 |
| `Cloud`、`AI Infrastructure`、`Data Center`及び`AI services`を同義化する | Excluded | 発行者は文脈ごとに異なる語を使用し、相互包含関係を一意に定義していない。 |

## 5. Relationship Assessment

### Confirmed Issuer-named Relationship Candidates

```text
Growing demand for AI services
    ↓
Alignment of datacenter locations and server capacity
    ↓
Dependence on energy, networking supplies and servers
    ↓
Servers include GPUs and other components
```

```text
Cloud / AI services demand
    ↓
Capital investment in global infrastructure
```

上記はMicrosoft自身の記述内で確認できる関係候補である。ただし、Data Center投資額から半導体需要量、特定製品売上又は特定供給者売上へ接続する関係は確認できない。

### Gap

2026-07-30までに確認したMicrosoftの公式Source Setでは、Data Center / AI Infrastructure投資と、特定Power Semiconductor、Power Management IC、MCU又は日本株対象企業の売上・受注を直接結ぶ開示を確認できなかった。これは当該関係又は資料が存在しないことの証明ではない。

## 6. Preliminary Disposition

| Category | Count | Treatment |
| --- | ---: | --- |
| Proceed | 8 | 独立レビュー後、個別Raw Evidence化を検討 |
| Proceed with caution | 1 | Demand contextとしてのみRaw Evidence化を検討 |
| Hold | 1 | Applicable period / measurement boundaryを追加確認 |
| Excluded transformation | 5 | Evidence化せず、禁止変換として保持 |

## 7. Next Gate

1. 本InspectionのEvidence・Knowledge・Traceability独立レビュー
2. `Proceed`及び`Proceed with caution`候補の一対一Cross-sprint再確認
3. 受理された候補ごとに個別Draft Raw Evidenceを作成
4. 採番条件を満たしたRaw Evidenceに限り`S3-EVR-xxx`を付与し、Evidence Status `Draft only`、Independent Review Status `Pending`でEVR登録
5. 全EVRに一対一の`S3-PIT-xxx`を作成し、初期`AvailableAt = TBD — no use`、Catalog Eligibility `No`を維持
