# Sprint003 Data Center / AI Infrastructure — Phase 2 Industry Research Design

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft industry-research design |
| Sprint | Sprint003 |
| Phase | Phase 2 — Memory / Storage and Network / Optical |
| Version | 0.1-draft |
| 作成日 | 2026-08-13 |
| 状態 | Draft — Gate P2-3 package review Accepted; Namespace Option A Accepted; P2-4 Option A authorized; Micron SFI next; noncanonical |
| Scope Authority | `Sprint003DataCenterAIInfrastructurePhase2ScopeActivationDecisionRecord.v0.1-draft.md` — Option A |
| Active research cut-off | `2026-08-11 23:59 JST` |
| Package Review | `Sprint003DataCenterAIInfrastructurePhase2GateP2-3IndependentReview.v0.1-draft.md` |
| P2-4 Authorization | `Sprint003DataCenterAIInfrastructurePhase2ResearchProductionAuthorizationDecisionRecord.v0.1-draft.md` — Pending |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | No |

> **権限境界：** 本DesignはActivation済み6社の調査方法、Source境界、停止条件及び成果物順序を定義するDraftである。作成又はreviewはSource Fact、Evidence / PIT ID、AvailableAt、Catalog、Lead / Lag、特徴量又は投資判断を生成しない。

## 1. Purpose

Phase 1 Reviewed Draft Baselineをread-onlyで維持しつつ、Memory / Storage及びNetwork / Opticalのissuer-specific definition、product stage、direct relation、period、unit及びdenominatorを6社の公式Sourceから再現可能に調査する。

## 2. Active Scope

| Order | Issuer | Active family | Applicable local RQ |
| ---: | --- | --- | --- |
| 1 | Micron Technology | HBM、DRAM / LPDDR、NAND / Data Center SSD | `S3-DCAI-P2-RQ-001`、`S3-DCAI-P2-RQ-003`、`S3-DCAI-P2-RQ-004`、`S3-DCAI-P2-RQ-005` |
| 2 | SK hynix | HBM、server DRAM / SOCAMM、NAND / Data Center eSSD | `S3-DCAI-P2-RQ-001`、`S3-DCAI-P2-RQ-003`、`S3-DCAI-P2-RQ-004`、`S3-DCAI-P2-RQ-005` |
| 3 | Samsung Electronics | HBM、server DRAM / SOCAMM、V-NAND enterprise SSD | `S3-DCAI-P2-RQ-001`、`S3-DCAI-P2-RQ-003`、`S3-DCAI-P2-RQ-004`、`S3-DCAI-P2-RQ-005` |
| 4 | Kioxia Holdings / Kioxia Corporation | NAND、GP / CM Series、enterprise / Data Center SSD | `S3-DCAI-P2-RQ-001`、`S3-DCAI-P2-RQ-003`、`S3-DCAI-P2-RQ-004`、`S3-DCAI-P2-RQ-005`、`S3-DCAI-P2-RQ-006` |
| 5 | Broadcom | Ethernet switching、AI NIC、optical DSP / optics、retimer / AEC、PCIe connectivity | `S3-DCAI-P2-RQ-002`、`S3-DCAI-P2-RQ-003`、`S3-DCAI-P2-RQ-004`、`S3-DCAI-P2-RQ-005` |
| 6 | Marvell Technology | optical DSP / SerDes、switching、PCIe / CXL switch / retimer、end-to-end connectivity | `S3-DCAI-P2-RQ-002`、`S3-DCAI-P2-RQ-003`、`S3-DCAI-P2-RQ-004`、`S3-DCAI-P2-RQ-005` |

Local RQは`Sprint003DataCenterAIInfrastructurePhase2ScopeDesign.v0.1-draft.md` §4の識別子であり、Evidence IDではない。

## 3. Research Questions

1. `S3-DCAI-P2-RQ-001` — Memory / Storage issuerはAI / Data Center用途をどの製品、世代、stage及びperiodで定義するか。
2. `S3-DCAI-P2-RQ-002` — Network / Optical issuerはAI clusterのswitching、NIC、DSP、SerDes、retimer及びinterconnectをどのgrainで開示するか。
3. `S3-DCAI-P2-RQ-003` — Actual、Forecast、Plan、sample、availability、mass production、shipment、capacity及びrevenueの差は比較をどう制約するか。
4. `S3-DCAI-P2-RQ-004` — 単一の公式Sourceがspecific productとAI / Data Center system、platform又はapplicationを直接接続するか。
5. `S3-DCAI-P2-RQ-005` — Inventory、backlog、shipment、capacity及びgeneration transitionを需要観測へ使えない条件は何か。
6. `S3-DCAI-P2-RQ-006` — Kioxiaの日本株follow-up候補と利用不能Gapは何か。

## 4. Work Sequence and Gates

```text
P2-3 Package Draft
  ↓
Independent Evidence / Knowledge / Traceability Review
  ↓
Research Design Acceptance + Namespace Decision
  ↓
Explicit P2-4 Authorization Decision
  ↓
P2-4 Source Fact Inspection
  ↓
Candidate Recheck → Raw → EVR → PIT → Company Research
```

1. Phase 2 Bridge AddendumでPhase 1 / cross-sprint重複を固定する。
2. Official Source Inventoryでcut-off内Source identityと所在をIDなしで記録する。
3. Namespace Decisionが記録されるまでEvidence / PIT IDを予約・発行しない。Namespace Decisionはidentifier形式だけを決定し、P2-4開始を承認しない。
4. P2-4ではIssuer順にMicron → SK hynix → Samsung → Kioxia → Broadcom → Marvellを基本順序とする。
5. 1社ごとにInspection → Recheck → Raw reviewを閉じてからEVRへ進める。複数社Factを一候補へ統合しない。
6. EVR review Accepted後にのみPITを作成し、PIT review Accepted後にCompany Researchへ進む。
7. Package review Accepted、Namespace Decision及び別P2-4 Authorization Decisionの全てが揃うまでSource Fact Inspectionを開始しない。

## 5. Minimum Source Set

各社についてcut-off以前の次を確認する。

- FY2021以降のAnnual Report又はregulatory annual filing
- FY2024以降の最新通期及び最新四半期決算Source
- AI / Data Centerとactive productを直接結ぶ公式IR / Newsroom / product Source
- 公式IR archive / News search surface

所在確認はFact受理ではない。資料未発見は記録済みSource Set内のNegative Evidenceに限定し、不存在証明にしない。

## 6. Source Inspection Fields

| Field | Required treatment |
| --- | --- |
| Issuer / source owner | Holdings、operating company、speaker又はpartner attributionを保持 |
| Source identity | official title、document type、version、URL |
| Publication Event | date / time / timezone。Unknownを許容し推測しない |
| Applicable Period | fiscal year、quarter、event-time又はfuture periodを分離 |
| Source position | section、physical / viewer page又はparagraph locator |
| Classification | Actual、Forecast、Target、Plan、Scenario、assertion、relationship、definition change |
| Product stage | development、sample、availability、mass production、shipment、revenueを分離 |
| Unit / denominator | bit、stack、device、capacity、port、lane、bandwidth、unit、currencyを非変換 |
| Source Fact | 一候補一Fact、source-faithful |
| Use boundary | 禁止変換、anonymous party、same-event / cross-event control |
| Cross-sprint result | existing ID / reference / new grain / no-match limited |

## 7. Company-specific Controls

Activation Request §3.1 / §3.2 / §5を全量・非縮退で採用する。§2の表記はshorthandであり、scope又はexclusionsを変更しない。

| Issuer | Permitted scope / relation | Accepted exclusions and controls |
| --- | --- | --- |
| Micron | AI / Data Center / AI server又はnamed platformへ直接結び付くHBM、DRAM / LPDDR、NAND / Data Center SSD | 全社Memory配賦、share / ranking、industry total、price / capacity / bit / unit換算、未開示AI revenue、supplier benefit、Phase 1 ID継承を禁止。shipment、joint development、designed-intoを分離 |
| SK hynix | AI / Data Center / server / GPU moduleへ直接結び付くHBM、server DRAM / SOCAMM、NAND / eSSD | leadership / share / ranking、industry total、換算、未開示AI revenue、anonymous identity、supplier benefit、Phase 1 ID継承を禁止 |
| Samsung | AI Infrastructure / Data Center / AI-HPC server又はnamed platformへ直接結び付くHBM、server DRAM / SOCAMM、V-NAND enterprise SSD | Device Solutions全体、Foundry / Logic / Packaging、mobile / edge、share / ranking、industry total、未開示AI revenue、anonymous identity、supplier benefit、Phase 1 ID継承を禁止。current mass productionとcommencementを分離 |
| Kioxia | NAND、GP / CM Series、enterprise / Data Center SSD、NVIDIA Storage-Next / AI storage relation | consumer / mobile、enterprise storage全体のAI配賦、share / ranking、未開示AI revenue、Legacy再発行、supplier benefit、Phase 1 ID継承を禁止。functional-check sampleをmass productionへ昇格しない |
| Broadcom | Ethernet switching、AI NIC、optical DSP / optics、retimer / AEC、PCIe connectivity | Infrastructure software、enterprise / edge、XPU / XDSiP product / revenue、customer identity、share / ranking、supplier benefit、Phase 1 ID継承を禁止。Tomahawk同日Sourceを二重計上しない |
| Marvell | optical DSP / SerDes、switching、PCIe / CXL switch / retimer、end-to-end connectivity及びAEC / AOC partner-enablement relation | AEC / AOCをMarvell製品化しない。custom ASIC、storage controller、enterprise / carrier、acquisition economics、customer identity、share / ranking、supplier benefit、Phase 1 ID継承を禁止。Ara shipment / anonymous relationを分離 |

## 8. Cross-sprint / Phase 1 Control

- Phase 1 `S3-EVR-001`–`132` / `S3-PIT-001`–`132`はread-onlyとし、再採番しない。
- Same issuerだけではduplicateとせず、Source identity、Publication Event、position及びFact grainで判定する。
- Existing generic HBM / Ethernet記述をPhase 2 issuer Factへ変換しない。
- Kioxia Legacy EDINET inventoryはfinancial-inventory semanticsのReferenceに限定する。
- NVIDIA network contextはBroadcom / Marvell product Factを代替しない。

## 9. Search and Company Closure

会社単位で次を満たしたら探索を終了できる。

1. Minimum Source Setの所在・検索結果を記録した。
2. Source Fact候補、Reference、Duplicate / corroboration、Hold及びGapを分離した。
3. Product stage、period、unit、denominator及びparty attributionを記録した。
4. 追加Source familyが3つを超えて必要なら探索を停止しreviewへ上げた。
5. Candidate-specific RQへ回答可能なFact又は限定Negative Evidenceを得た。

## 10. Explicit Non-Claims

- market share、ranking、industry total、CAGR又はForecast achievementを補完しない。
- CapEx、NVIDIA revenue又はrack powerからspecific Memory / Network shipment又はsupplier revenueを導出しない。
- bit、wafer、stack、package、device、port、lane、bandwidth、unit、ASP、capacity及びrevenueを相互変換しない。
- announcement、sample、availability、mass production、shipment、adoption及びrevenueを同義化しない。
- anonymous customer / platform / partner identityを推定しない。
- Phase 1 ID又は利用権限を継承しない。
- Lead / Lag、feature、signal、Catalog又は投資判断を採用しない。

## 11. Deliverables

1. Phase 2 Industry Research Design
2. Phase 2 Cross-sprint / Phase 1 Bridge Addendum
3. Phase 2 Official Source Inventory
4. Phase 2 Namespace Decision Request / Record
5. Source Fact Inspection / Recheck
6. Raw Evidence Package
7. EVR / PIT Addenda
8. Six Company Research documents
9. Definition and Comparability Matrix Addendum
10. Industry Report Addendum
11. Reviewed Draft Baseline Addendum / Closure package

## 12. Definition of Done — Design

- Active 6社・2製品群、RQ、Source Set、sequence、stop rule及びnon-claimsが対応する。
- Bridge、Inventory及びnamespaceがPhase 1から分離される。
- Independent review Accepted、Namespace Decision及び別P2-4 Authorization Decision前にP2-4を開始しない。
- 全Candidateの初期`AvailableAt = TBD — no use`、Catalog Eligibility `No`を維持する。
