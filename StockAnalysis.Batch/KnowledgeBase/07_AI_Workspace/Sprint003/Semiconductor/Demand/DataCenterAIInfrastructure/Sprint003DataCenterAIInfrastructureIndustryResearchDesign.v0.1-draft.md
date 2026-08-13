# Sprint003 Data Center / AI Infrastructure Semiconductor Demand — Industry Research Design

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft industry-research design |
| Sprint | Sprint003 |
| 対象 | Semiconductor → Demand → Data Center / AI Infrastructure |
| バージョン | 0.1-draft |
| 作成日 | 2026-07-30 |
| 状態 | Draft — research design; noncanonical; Accepted for research execution |
| Authoring role | Industry Research Lead |
| Accountable research role | Research Director |
| Documentation steward | Documentation Director |
| Reviewer Status | Independent Evidence・Knowledge・Traceability Review complete — all Recommend Accept; Accepted by Project Director on 2026-07-30 |
| Upstream scope | `Sprint003DataCenterAIInfrastructureSemiconductorDemandScopeDesign.v0.1-draft.md` — Gate 1 Accepted |

> **権限境界：** 本文書は、承認済みScope内で一次資料を探索・評価する方法を設計する。Industry Reportの事実、Canonical分類、Knowledge Catalog、DDL、特徴量、因果関係又は投資判断を定義・承認しない。

## 1. 目的

Sprint003 Phase 1のCore企業について、Data Center及びAI InfrastructureからAI Compute及びPower Semiconductor / Power Managementへ至る関係を、公式一次資料から再現可能な形で探索する。

本Designの目的は、仮説を証明することではない。公式Source Setを一定の手順で確認し、確認できたSource Fact、確認できなかった関係、定義差、時点属性及び利用境界を、独立レビュー可能なResearch Assetとして残すことである。

## 2. Dependency and Stop Boundary

```text
Accepted Scope Design
    ↓
Industry Research Design
    ↓
Independent Design Review
    ↓
Project Director / Delegated Acceptance
    ↓
Cross-sprint Pre-check / IDなしOfficial Source Inventory
    ↓
Namespace Decision
    ↓
Raw Evidence / EVR / PIT
```

- Scope Designの範囲を本Designで拡張しない。
- Design Review及びAcceptance前に公式Source Inventoryの確定作業を開始しない。
- Design Acceptance後は、IDを付与しないCross-sprint Pre-check及びOfficial Source Inventoryを開始できる。
- `S3-EVR-xxx`及び`S3-PIT-xxx`は、Namespace Decision前に発行・予約・採番しない。
- Namespace Decision前は、Raw Evidence、Evidence Register及びPIT Inventoryを作成しない。
- Catalog、DDL、Entity、Database、ML、バックテスト、Decision Engine、Advisor及び投資利用を開始しない。

## 3. Phase 1 Research Questions

| Local ID | Phase | Research Question | 必要なEvidence |
| --- | --- | --- | --- |
| S3-DCAI-RQ-001 | Core | 発行者はData CenterとAI Infrastructureをどの用語、用途、製品又は事業区分で表現しているか。 | 発行者の事業定義、注記、用途説明、セグメント又は市場区分。 |
| S3-DCAI-RQ-002 | Core | Microsoft及びAlphabetは、Data Center、Cloud又はAI Infrastructureへの投資・能力増強をどの粒度で開示しているか。 | Annual Report、決算資料、公式説明のCapex、能力又は投資文脈。 |
| S3-DCAI-RQ-003 | Core | NVIDIAはAI Compute及びData Center需要を、売上、製品、供給又は需要コメントとしてどのように開示しているか。 | Annual Report、決算資料、事業説明、製品・需要定義。 |
| S3-DCAI-RQ-004 | Core | Renesas、ROHM及びInfineonは、Data Center又はAI関連のPower Semiconductor / Power Management用途をどこまで明示しているか。 | 年次・決算・戦略・公式製品資料の用途、製品、売上又は需要文脈。 |
| S3-DCAI-RQ-005 | Core | 単一の一次資料が、需要側投資と特定の半導体製品又は需要との関係を明示しているか。 | Issuer-named relationship。異なる発行者の記述を組み合わせてもDirect relationとしない。 |
| S3-DCAI-RQ-006 | Core | Actual、Forecast、Target、Plan及び発行者分類の定義差は、比較可能性へどの制約を与えるか。 | 公開イベント、対象期間、定義、再分類、比較注記。 |
| S3-DCAI-RQ-007 | Core | 日本株対象のRenesas及びROHMについて、将来の観測候補となり得る開示と利用不能なGapは何か。 | 再現可能なSource Fact、Gap記録、時点及び利用境界。 |

`S3-DCAI-RQ-xxx`は本Artifact / Versionだけが所有するLocal Research Question識別子であり、Evidence ID又はCanonical Identifierではない。他Artifactで再利用又は継続採番せず、追加時は本表内の一意性を確認する。

## 4. Research Sequence

### Stage 0 — Cross-sprint Pre-check

1. Sprint001及びSprint002のEvidence Register、PIT、Raw Evidence及びCompany Researchを検索する。
2. 同一Source Event、同一Source Fact及び同一Claim候補を記録する。
3. 既存ID、対象Version、Scope及び状態をCross-sprint Bridge候補へ記録する。
4. 既存Evidenceを複製又はS3として再採番しない。

Stage 0ではBridge候補を作成する。正式なCross-sprint Bridgeは、Stage 1のOfficial Source Inventoryとの照合後に完成させる。

### Stage 1 — Official Source Inventory

1. Core 6社について§5の最低確認Source Setの公式所在を探索する。
2. §6.3のフィールドを持つIDなしSource Inventoryへ結果を記録する。
3. 資料が存在しない又は発見できない場合も、検索場所、検索語及び結果を記録する。
4. Source Factの抽出、Raw Evidence、EVR及びPITはNamespace Decision後まで開始しない。

### Stage 2 — Demand-side Baseline

対象：Microsoft、Alphabet。

目的：

- Data Center、AI Infrastructure、Cloud及びCapexの発行者用語を確定する。
- 投資額の構成範囲と半導体需要へ直接変換できない境界を記録する。
- Actual、Forecast、能力増強及び需要コメントを分離する。

### Stage 3 — Compute Baseline

対象：NVIDIA。

目的：

- Data Center及びAI Compute事業の発行者定義を確認する。
- 売上、需要コメント、供給制約及び製品世代の記述を分離する。
- NVIDIA固有の開示をIndustry-wide demandへ一般化しない境界を記録する。

### Stage 4 — Power Baseline

対象：Renesas Electronics、ROHM、Infineon Technologies。

目的：

- Data Center又はAI用途とPower Semiconductor / Power Management製品の直接的な記述を探索する。
- 公式製品用途、事業戦略、Actual売上及び需要見通しを分離する。
- 用途別売上が開示されない場合は推定配賦せずGapとして記録する。

### Stage 5 — Definition and Relationship Reconciliation

1. 発行者用語をDefinition and Comparability Matrixへ転記する。
2. 各Hypothesis edgeを次のいずれかに分類する。
   - `Issuer-named relationship`
   - `Cross-source inference`
   - `Unconfirmed`
3. `Cross-source inference`はResearch文書だけに置き、根拠EVR IDを列挙する。
4. `Unconfirmed`は確認済みSource SetとSearch Resultを付してGapとして記録する。

### Stage 6 — Phase 1 Closure Assessment

- Core 6社すべてのMinimum Source Setが確認済みか評価する。
- Core企業の半数を超えてResearch Questionに対応する一次資料を確認できない場合、Phase 2へ進まずScope再評価を依頼する。
- Phase 2候補を確認しても、Scope差分の正式承認前には追加調査を開始しない。

## 5. Company Research Matrix

| Order | 企業 | Role | Core Questions | 最低確認Source Set | 明示的な禁止事項 |
| ---: | --- | --- | --- | --- | --- |
| 1 | Microsoft | Demand-side | S3-DCAI-RQ-001、002、005、006 | FY2021以降の年次開示、FY2024以降の通期・最新四半期、公式AI / Cloud / Capex説明 | Capex全額をData Center又は半導体需要へ配賦しない。 |
| 2 | Alphabet | Demand-side | S3-DCAI-RQ-001、002、005、006 | FY2021以降の年次開示、FY2024以降の通期・最新四半期、公式Data Center / AI / Capex説明 | 投資額を特定半導体企業の売上へ接続しない。 |
| 3 | NVIDIA | Compute supply | S3-DCAI-RQ-001、003、005、006 | FY2021以降の年次開示、FY2024以降の通期・最新四半期、公式Data Center / AI製品・戦略資料 | 一社の売上又は需要を業界全体へ一般化しない。 |
| 4 | Renesas Electronics | Power / embedded supply candidate | S3-DCAI-RQ-001、004、005、006、007 | FY2021以降の年次開示、FY2024以降の通期・最新四半期、公式Data Center / Power用途資料 | 複合Industrial / Infrastructure / IoT区分をData Center単独へ配賦しない。 |
| 5 | ROHM | Power supply candidate | S3-DCAI-RQ-001、004、005、006、007 | FY2021以降の年次開示、FY2024以降の通期・最新四半期、公式AI Server / Power用途資料 | Product adoptionを全社売上又は市場需要へ一般化しない。 |
| 6 | Infineon Technologies | Power benchmark candidate | S3-DCAI-RQ-001、004、005、006 | FY2021以降の年次開示、FY2024以降の通期・最新四半期、公式Data Center / Power用途資料 | Target market、Design win、Forecast及びActual売上を混同しない。 |

表内の用途・資料名は探索候補であり、開示が存在するというFactではない。

## 6. Official Source Search Plan

### 6.1 Source Priority

1. Annual Report、統合報告書、有価証券報告書又は規制当局提出年次資料
2. 通期・四半期決算説明資料、Earnings Release、公式会見資料
3. Investor Day、事業戦略、Capital Allocation又は公式IR資料
4. 公式IRアーカイブ及び公式Newsroom
5. 公式製品・Application・Technology資料

### 6.2 Search Vocabulary

検索語は発行者の言語と表記を保持し、少なくとも次を組み合わせる。

| Category | Candidate vocabulary |
| --- | --- |
| Infrastructure | `data center`、`datacenter`、`cloud infrastructure`、`AI infrastructure`、`accelerated computing` |
| Investment | `capital expenditure`、`capex`、`capacity`、`infrastructure investment` |
| Compute | `accelerator`、`GPU`、`AI compute`、`training`、`inference` |
| Power | `power semiconductor`、`power management`、`power supply`、`power conversion`、`server power`、`UPS` |
| Observation | `revenue`、`sales`、`orders`、`inventory`、`capacity`、`demand`、`outlook` |
| Definition | `segment`、`end market`、`application`、`reclassification`、`restatement` |

検索語の一致だけでEvidence採用しない。発行者、公式正本性、資料内位置及びSource Factを再現できる場合に限る。

### 6.3 Source Inventory Fields

Design Acceptance後、Official Source InventoryはIDを持たず、次を記録する。

| Field | Requirement |
| --- | --- |
| Issuer | Required |
| Official source title or page label | Required |
| Document type | Required |
| Publication date / time / timezone | Required field; `Unknown` allowed |
| Applicable period | Required field; `N/A` or `Unknown` allowed |
| Official URL or archive location | Required |
| Located section / page | Required field; `Unknown` until inspected |
| Search vocabulary | Required |
| Retrieval date | Required |
| Archive status | Required |
| Cross-sprint candidate | Required |
| Candidate relevance | Proposal only |
| Evidence eligibility | `Not assessed` until Source Fact inspection |

## 7. Evidence Assessment Model

### 7.1 Evidence Register Eligibility

Evidence Registerへ進めるのは、原資料から直接再現できるSource Factだけである。

| Category | Treatment |
| --- | --- |
| Direct quantitative observation | Source Fact。定義、期間、単位、Actual / Forecast等を保持する。 |
| Issuer narrative | Source Fact。発行者の記述範囲を超えて数量・因果へ変換しない。 |
| Plan / Outlook / Target | Source Fact。Actualから分離する。 |
| Definition / Reclassification | Source Fact。比較可能性の統制として保持する。 |
| Cross-source inference | Industry / Company Researchに置き、根拠EVR IDを参照する。 |
| Hypothesis / Proposal | Research文書に置き、Evidenceと明確に分離する。 |
| Unconfirmed relationship | Source Inventory又はGap / Search Resultとして保持する。 |

### 7.2 Minimum Evidence Fields

Evidence Registerのフィールドはすべて存在させる。値が不明又は非該当なら`Unknown`又は`N/A`を記録する。

- Evidence ID
- Issuer
- Official source title
- Publication event
- Official URL又はarchive location
- Source position
- Applicable period
- Unit / currency
- Actual / Forecast / Target / Plan
- Issuer definition / classification
- Source Fact
- Use boundary
- Cross-sprint reference
- `AvailableAt`
- Catalog Eligibility `No`
- Raw Evidence reference
- Evidence Status
- Independent Review Status
- Review Record / Finding reference

発行者、公式正本性、Source position又はSource Factを再現できない場合はEvidence Registerへ進めない。公開時点が不明な資料は`AvailableAt = TBD — no use`を維持する。

すべてのEVR及びPITは、Publication Eventが既知か否かにかかわらず、初期状態を`AvailableAt = TBD — no use`、Catalog Eligibility `No`、Evidence Status `Draft only`、Independent Review Status `Pending`とする。Publication Eventは`AvailableAt`とは別のSource Factとして保持する。適用されるauthorityによる導出規則及び承認が記録されるまで、Publication Eventを`AvailableAt`へ変換しない。

## 8. Cross-sprint Control

調査開始前に次を確認する。

| Check | Required action |
| --- | --- |
| Same issuer | Sprint001 / 002の企業別ResearchとEvidence Registerを確認する。 |
| Same document | 資料名、公開日、対象期間及びSource Eventを照合する。 |
| Same Source Fact | 既存EVRを参照し、S3として再採番しない。 |
| New claim from existing document | 既存ID、抽出差分、新規性及び採番理由を記録する。 |
| Composite disclosure | Industrial / Infrastructure / IoT等の複合範囲をCross-sprint Bridgeへ記録する。 |
| Status inheritance | 既存DraftをCanonical又は利用可能状態へ昇格させない。 |

## 9. Search Closure and Negative Evidence

### 9.1 Company-level Closure

Core企業ごとに次を満たした時点で、Phase 1探索を終了できる。

1. Company Research Matrixの最低確認Source Setについて、所定の公式場所を検索・確認し、結果を記録した。資料の存在又は発見はClosureの必須条件ではない。
2. 確認資料、検索語、対象期間、取得結果及び不足をSource Inventoryへ記録した。
3. Cross-sprint重複確認を完了した。
4. Source Fact候補とGapを分離した。
5. 追加検索が必要な場合、その資料群と理由を限定した。

### 9.2 Negative Evidence Expression

関係又は開示を確認できなかった場合は、次の形式で記録する。

> 調査cut-offまでに確認した記録済みの公式Source Setでは、対象関係を明示する資料を確認できなかった。これは当該関係又は資料が存在しないことの証明ではない。

### 9.3 Escalation Conditions

次の場合は探索を停止し、Research Director及びProject Directorへ判断を求める。

- Core企業の半数を超えて研究問いに対応する一次資料を確認できない。
- Scope外の製品群又は企業を追加しなければ主要Research Questionへ回答できない。
- 発行者の定義変更によりFY2021以降の比較が成立しない。
- 既存SprintのEvidenceと矛盾するSource Factを確認した。
- 公式アーカイブ欠落によりSource Factを再現できない。
- 実装又は投資利用に影響する新しい分類・Mapping判断が必要になった。

## 10. Draft Deliverables

Phase 1では次の順序で作成する。

1. Official Source Inventory
2. Cross-sprint Bridge
3. Raw Evidence
4. Evidence Register
5. PIT Inventory
6. Definition and Comparability Matrix
7. Core Company Research
8. Industry Report
9. Independent Review Package / Review Record
10. Reviewed Draft Baseline List
11. Project Director Disposition Request

Value Chain、Lead / Lag Indicator Candidate Inventory及びConditional企業Researchは、Phase 2が承認された場合だけ作成する。

## 11. Intended Industry Report Structure

1. Scope、authority及びstatus boundary
2. Data CenterとAI Infrastructureのissuer-defined terminology
3. Demand-side investment and capacity context
4. AI Compute disclosure structure
5. Power Semiconductor / Power Management disclosure structure
6. Issuer-named relationships and unconfirmed edges
7. Definition、period、unit and comparability controls
8. Japan-equity relevance and explicit use restrictions
9. Gaps、risks and explicit non-claims
10. Evidence routes and review status

## 12. Explicit Non-Claims

- Data Center又はAI Infrastructure市場の規模、成長率、半導体需要量又は将来値を、一次資料なしに主張しない。
- Hyperscaler Capexを、Data Center、AI又は半導体購入額へ推定配賦しない。
- NVIDIAの売上又は需要コメントを、半導体業界全体の需要へ一般化しない。
- 需要側企業の投資から、Renesas、ROHM又はInfineonの売上・受注への因果を推測しない。
- 公式製品用途又はDesign winを、Actual売上、顧客構成又は市場シェアへ変換しない。
- AI、Data Center、Cloud、Server及びInfrastructureを無条件に同義化しない。
- Forecast、Target、Plan、Backlog、Order、Shipment及びRevenueを相互に代替しない。
- Phase 2、Catalog、DDL又は下流利用を先取りしない。

## 13. Design Review Readiness

本Designは、次を満たす場合に独立Reviewへ提出できる。

1. Scope DesignのCore / Conditional境界と対象企業が保持されている。
2. Research Questions、Company Matrix及びResearch Sequenceが対応している。
3. Source Set、Search vocabulary、closure及びnegative evidenceの処理が再現可能である。
4. EVR、Reasoning及びGapの記録先が分離されている。
5. Cross-sprint重複とNamespace Decisionの停止境界が明確である。
6. 著者から独立したEvidence、Knowledge及びTraceability Reviewerを割り当てられる。

## 14. Namespace Decision

本Designの初稿時点では、`S3-EVR-xxx`及び`S3-PIT-xxx`は候補であり、採番権限は確定していなかった。

Project Director又は適用されるIdentifier authorityは、ID発行及びRaw Evidence作成の開始前に次を判断する必要がある。

1. Sprint003固有namespaceとして`S3-EVR-xxx`及び`S3-PIT-xxx`を使用してよいか。
2. Evidence Register及びPIT InventoryをSprint003固有台帳として作成してよいか。

Design Acceptance後、IDなしのOfficial Source Inventory及びCross-sprint Pre-checkは開始できる。Namespace Decisionが記録されるまでは、ID発行、Raw Evidence、Evidence Register及びPIT Inventoryの作成を開始しない。

### Project Director Decision — 2026-07-30

Project Directorは本Research DesignをAcceptedとし、Sprint003固有namespace `S3-EVR-xxx`及び`S3-PIT-xxx`、ならびにSprint003固有のEvidence Register及びPIT Inventoryの作成を承認した。

- 本承認はIDを予約又は発行するものではない。
- IDは実際のRaw Evidenceが受理可能な状態になった時点で、重複確認後に採番する。
- Sprint001及びSprint002のIDを再利用又は継続採番しない。
- すべてのEvidence及びPITはDraft-local、noncanonical、`AvailableAt = TBD — no use`、Catalog Eligibility `No`から開始する。
- Decision Record：`Sprint003EvidenceNamespaceDecisionRecord.v0.1-draft.md`

## 15. Definition of Done

- Independent Evidence、Knowledge及びTraceability ReviewでBlocking findingが解消されている。
- Project Director又は明示的な委任記録を持つAccountable authorityがResearch DesignをAcceptedとしている。
- Stage 0 Cross-sprint Pre-check及びStage 1 Official Source Inventoryを、IDなしで範囲逸脱なく開始できる。
- Namespace Decisionが、Raw Evidence、Evidence Register及びPIT Inventory開始前の独立した後続Gateとして明示されている。
- 本DesignがDraft、noncanonicalかつ下流利用不可であることが維持されている。
