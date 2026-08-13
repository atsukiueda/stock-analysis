# Sprint003 Data Center / AI Infrastructure Semiconductor Demand — Scope Design

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft research scope design |
| Sprint | Sprint003 |
| 作業領域 | Semiconductor → Demand → Data Center / AI Infrastructure |
| バージョン | 0.1-draft |
| 作成日 | 2026-07-30 |
| 状態 | Draft — scope design; noncanonical; Gate 1 Accepted |
| Authoring role | Industry Research Lead |
| Accountable research role | Research Director |
| Documentation steward | Documentation Director |
| Reviewer | 独立Evidence・Knowledge・Traceability Reviewer（Review Recordで特定） |
| Reviewer Status | Independent Evidence・Knowledge・Traceability Review complete — all Recommend Accept; Gate 1 Accepted by Project Director on 2026-07-30 |

> **権限境界：** 本文書はSprint003の調査範囲を設計する非CanonicalなDraftである。Canonicalな産業分類、Knowledge Catalog、DDL、企業評価、因果関係、投資判断を定義しない。

## 1. 目的

Data Center及びAI Infrastructureへの投資・増設・稼働の変化が、どの半導体製品群と企業開示を通じて観測できるかを、一次資料に基づいて整理する。

本Sprintでは、需要指標から半導体需要へ至る伝播経路、観測定義、Lead / Lag候補、在庫及び供給制約を研究する。成果は独立レビュー可能なDraft Research基盤である。`AvailableAt`の状態記録は必須とするが、その導出・承認、Catalog、DDL、Entity、Database、ML、バックテスト、Decision Engine、Advisor及び投資利用は対象外とする。

## 2. Working Scope

```text
Semiconductor
└── Demand
    └── Data Center / AI Infrastructure
```

`Data Center / AI Infrastructure`は、データセンター及びAI計算基盤に関係する半導体需要を調査するための**作業上の範囲**である。CanonicalなSubSector又は恒久的な業界分類を決定するものではない。

本Sprintでは、次の関係を検証対象となる**Hypothesis edges**として扱う。

```text
Data Center / AI Infrastructure Investment
    ↓
Compute・Storage・Network・Power Infrastructure
    ↓
Semiconductor Product Demand
    ↓
Orders・Revenue・Inventory・Capacity
```

この図はResearch Modelであり、各矢印の関係又は因果をあらかじめ確定しない。各edgeは、`Issuer-named relationship`、`Cross-source inference`又は`Unconfirmed`に分類する。

### 2.1 Working Definition

| 用語 | Sprint003での作業上の意味 | 含める条件 | 除外・保留 |
| --- | --- | --- | --- |
| Data Center | 発行者がData Center又は同等の明示的な施設・システム用途として記述する計算、保存、接続又は電力基盤 | 発行者の用途ラベルと対象製品・事業の関係を資料内で確認できる | Cloud、Server、Infrastructureという語だけからData Centerへ自動Mappingしない |
| AI Infrastructure | 発行者がAI training、AI inference、accelerated computing又は同等のAI用途を支える基盤として明示する対象 | AI用途と対象製品、設備又は投資の関係を資料内で確認できる | 一般的なData Center又はCloud開示をAI向けへ読み替えない |
| Overlap | 発行者がData CenterとAI用途の双方を同じ対象へ明示する場合の重複領域 | 原資料の関係と粒度を保持する | AI Infrastructureを常にData Centerの部分集合とは決定しない |
| Related labels | Cloud、Server、Infrastructure、Accelerated Computing等 | 原資料のラベルとして記録し、Mapping状態を別途示す | Canonicalな同義語として統合しない |

`Data Center / AI Infrastructure`のslash表記は二つの関連作業範囲を束ねる表題であり、両者が同義又は単一分類であることを意味しない。MappingはFact、Inference又はHypothesisとして明示し、発行者の用語を優先する。

## 3. 調査対象とPhase

### 3.1 Phase 1 — Core Scope

Phase 1は、Sprint003で必ず調査する最小範囲とする。

- 製品群：AI Compute及びPower Semiconductor / Power Management
- 供給側候補：Renesas Electronics、ROHM、Infineon Technologies、NVIDIA
- 需要側候補：Microsoft、Alphabet
- 研究対象：発行者が明示する用途、投資、売上、在庫又は能力の関係
- 期間：§6で定める調査期間及びcut-off

### 3.2 Phase 2 — Conditional Scope

Memory、Network / Optical、Analog / Mixed Signal / Embedded、追加企業、Lead Time及び詳細なCapacity分析はPhase 2とする。Phase 1のEvidence Reviewで、次のすべてを満たした対象だけ追加できる。

1. Core Scopeだけでは研究問いに重要な欠落が残る。
2. 公式資料で対象用途と半導体製品又は投資の直接的な関係を少なくとも1件確認できる。
3. 追加理由、重複確認及び調査停止条件をReview Recordへ記録できる。
4. Scope差分、判断者、判断日及び理由をDecision Recordへ記録し、Project Director又は明示的な委任記録を持つAccountable authorityの承認を得る。

### 3.3 需要起点

- データセンター及びAI Infrastructureへの設備投資
- 計算能力、サーバー、アクセラレーター及び関連システムの導入
- ネットワーク帯域、接続機器及び光通信の増強
- 電力供給、変換、配電及びバックアップ電源の増強
- 需要変化に伴う在庫、Lead Time、供給能力及び設備投資

### 3.4 半導体製品群

| 製品群 | Phase | 調査する需要接続 | 初期境界 |
| --- | --- | --- | --- |
| Compute | Core | GPU、CPU、AI Accelerator、Custom ASIC等 | 性能比較やモデル優劣を主題にしない。 |
| Power Semiconductor / Power Management | Core | 電力変換、配電、UPS、Server Power等 | 電力設備投資を半導体販売数量へ直接変換しない。 |
| Memory / Storage Semiconductor | Conditional | HBM、DRAM、NAND等 | 容量・世代・価格を同一需要指標として扱わない。 |
| Network / Optical Semiconductor | Conditional | Switch、PHY、DSP、Optical関連等 | 通信設備全体を半導体需要へ無断変換しない。 |
| Analog / Mixed Signal / Embedded | Conditional | 電源・制御・接続・監視用途 | Data Center向け売上が分離されない場合は推定しない。 |

製品分類は発行者ごとに異なる可能性がある。名称が一致しても、定義、集計範囲、期間及び単位を確認せずに横断比較しない。

### 3.5 AI向けと従来型Data Centerの境界

- 発行者がAI、Accelerated Computing又は同等の用途を明示した場合のみ、AI Infrastructureとして記録する。
- `Data Center`、`Infrastructure`、`Server`又は複合事業区分を、根拠なくAI需要へ読み替えない。
- AI向けと従来型Data Centerを分離できない開示は、発行者の原表記を維持する。
- Forecast、計画、受注、出荷、売上及びエンドユーザー需要を相互に代替しない。

## 4. 研究問い

1. **Core:** 一次資料上、Data Center及びAI Infrastructure向け半導体需要はどの用途・製品・事業区分として開示されるか。
2. **Core:** Data Center投資、AI計算基盤投資及び電力需要は、Core企業の売上・在庫・能力とどのような関係として発行者から説明されているか。
3. **Conditional:** Compute、Memory、Network、Analog及びPower Semiconductorでは、需要指標とLead / Lag候補にどのような違いがあるか。
4. **Core:** AI向け需要と従来型Data Center需要を、一次資料の定義に基づいてどこまで分離できるか。
5. **Core:** Data Center向け需要とIndustrial / Infrastructure / IoT等の複合開示を、どの利用境界で扱うべきか。
6. **Conditional:** 在庫、Lead Time、供給能力、設備投資及び製品世代交代は、需要観測の解釈へどのような制約を与えるか。
7. **Core:** 日本株の評価に将来利用可能となり得る観測について、必要なEvidence、時点属性、比較可能性及び利用制約は何か。

## 5. 対象企業

対象企業は、業界全社を網羅するためではなく、需要関係を異なる立場から検証するための**候補選定Proposal**である。各社の役割記述はEvidence取得前の調査仮説であり、開示の存在又は関係をFactとして確定しない。

### Core — 半導体供給側候補

| 企業 | Sprint003での役割 | 初期境界 |
| --- | --- | --- |
| Renesas Electronics | 複合事業区分及びData Center関連開示を探索する候補 | 複合区分をData Center単独へ推定配分しない。 |
| ROHM | Power Semiconductor、Power Management及びAI Server関連用途を探索する候補 | 製品採用情報を全社売上又は市場需要へ一般化しない。 |
| Infineon Technologies | Data Center電力変換及びPower Semiconductor開示を探索する候補 | 目標市場、設計採用及びActual売上を区別する。 |
| NVIDIA | AI Compute及びData Center事業開示を探索する候補 | NVIDIA売上を半導体業界全体の需要へ一般化しない。 |

### Core — 需要・システム側候補

| 企業 | Sprint003での役割 | 初期境界 |
| --- | --- | --- |
| Microsoft | AI / Cloud Infrastructure投資及び能力需要の開示を探索する候補 | Capital Expenditure全額を半導体需要とみなさない。 |
| Alphabet | Data Center及びAI Infrastructure投資の開示を探索する候補 | 投資額を個別半導体企業の売上へ直接接続しない。 |

### Conditional — Evidence確認後に追加

次の企業又は企業群は、一次資料でSprint003の研究問いに直接対応する定義、期間又は観測を確認できた場合に限り追加する。

- Texas Instruments、AMD、Broadcom、Marvell、onsemi、STMicroelectronics
- Micron Technology、Samsung Electronics、SK hynix、Kioxia Holdings
- Amazon、NTT DATA Group、Socionext、Fujitsu、NEC
- Data Center向け電源、光通信又は冷却システムの代表企業

追加は§3.2のPhase 2入口条件を満たす場合に限る。公式資料で研究問いに直接対応する定義、期間又は観測を確認できない候補はCore対象へ昇格させない。未確認の場合は「今回確認した一次資料群では未確認」と記録し、不存在の証明とは扱わない。

## 6. 対象期間・地域・時点

- 調査cut-off：2026-07-30 23:59 JST。
- 標準対象期間：各発行者のFY2021開始日から調査cut-offまで。
- 主要分析期間：各発行者のFY2022開始日から調査cut-offまで。
- 地域：Global demandを基本とし、日本株への関係は別途明示する。
- 比較期間は各発行者の会計年度、暦年、四半期及び週次定義を維持する。
- cut-off以前に公式公開された資料だけを対象とし、公開日と対象期間を分離する。
- 訂正又は再表示が公式に確認できる場合は最新の有効資料を優先し、旧版との関係を記録する。
- 公開時刻又はタイムゾーンが不明な場合は不明と記録し、`AvailableAt`を推測しない。
- 取得日及び公式URL又は公式アーカイブ状態をPITに記録する。
- `AvailableAt`が確定しない観測は`TBD — no use`とし、下流利用を禁止する。

## 7. Evidence方針

### 7.1 優先順位

1. 統合報告書・Annual Report・有価証券報告書
2. 決算説明資料・Earnings Release・公式決算会見資料
3. Investor Day・事業戦略資料・公式IR
4. 規制当局提出資料、JPX、EDINET及び発行者の公式アーカイブ
5. 公式製品・技術資料（用途又は製品関係の確認に限定）

ニュース、調査会社推計、販売代理店資料及び二次資料は、一次資料探索の補助又は明示的な参考情報としてのみ扱う。

### 7.2 記録要件

Evidence Registerへ採用する各観測には、次を必須として記録する。

- Evidence ID
- 発行者
- 資料名
- 公開日
- 公式URL又は公式アーカイブ位置
- ページ、表、行又はセクション
- 対象期間
- 単位及び通貨
- Actual / Forecast / Target / Plan
- 発行者の定義及び分類
- Source Fact（Evidence RegisterではFactに限定）
- 利用境界
- `AvailableAt`

Evidence Registerは原資料から直接再現できるSource Factだけを収容する。Inference、Hypothesis及びProposalはIndustry Research又はCompany Researchに記録し、根拠となるEvidence IDを参照する。`Cross-source inference`をEvidenceとして登録しない。`Unconfirmed`はSource Inventory又はResearch文書のGap / Search Resultとして記録する。

フィールドの存在は必須とし、値を確認できない又は適用できない場合は`Unknown`又は`N/A`を明示する。公開日又は時刻が不明な公式資料は、取得日、公式URL又は公式アーカイブ状態を保持し、`AvailableAt = TBD — no use`かつCatalog Eligibility `No`とする。発行者、公式資料としての正本性、資料内位置又はSource Fact自体を再現できない資料はEvidence Registerへ昇格させず、Source Inventoryへ未確認状態と不足項目を記録する。

PITには、対応Evidence ID、公開日・時刻・タイムゾーン、対象期間、取得日、公式アーカイブ状態、`AvailableAt`、定義・比較可能性及びCatalog Eligibility `No`を保持する。未確認項目は`Unknown`又は`TBD — no use`とし、空欄で確定したように見せない。

Sprint003のEvidence IDは`S3-EVR-xxx`、PIT行は`S3-PIT-xxx`を作業用識別子候補とする。Project Director又は適用されるIdentifier authorityによるNamespace Decisionが記録されるまで、IDを発行・採番しない。採番時は重複を検証し、Draft-localかつnoncanonicalであることを台帳に記録する。

### 7.3 Cross-sprint Evidence Control

- Sprint001及びSprint002のEvidence、PIT及びSource Eventは参照のみとし、既存の同一Source Fact又は同一ClaimをS3として複製・再採番しない。
- 既存資料からSprint003固有の新しいClaimを抽出する必要がある場合は、既存Evidence IDとの関係、抽出差分及び新規採番の理由を記録する。
- 新しいSource Event又は新しいClaimだけをS3候補とする。
- 複合`Industrial / Infrastructure / IoT`、Power Semiconductor等の重複領域はCross-sprint Bridgeで参照関係と差異を記録する。
- Cross-sprint参照は既存DraftをCanonical又は利用可能状態へ昇格させない。

## 8. Candidate Observations

以下は調査候補であり、利用可能なKnowledge又は特徴量ではない。Phase 1ではCore製品群とCore企業に直接関係する観測だけを必須とし、それ以外はPhase 2候補とする。

| 観測候補 | Phase | 主な役割 | 初期制約 |
| --- | --- | --- | --- |
| Data Center / AI Infrastructure Capex | Core | 上流投資文脈 | 建物、土地、電力、冷却等を含み得る。 |
| Data Center Segment Revenue | Core | 供給側の需要観測 | 企業ごとの製品範囲が異なる。 |
| AI Accelerator / Compute Revenue | Core | AI Compute需要 | 単一企業・製品への集中と価格構成の影響が大きい。 |
| Power Semiconductor / Power Management Revenue | Core | 電力変換需要 | 用途別売上が非開示の場合は推定しない。 |
| Inventory / DOI / WOI | Core if disclosed | 循環・需給候補 | 定義、所有主体及びチャネル範囲が異なる。 |
| HBM / DRAM / NAND需要・売上 | Conditional | Memory需要 | 製品構成、容量、価格及び在庫を分離する必要がある。 |
| Network / Optical Revenue | Conditional | 接続需要 | Telecom、Enterprise及びData Centerの混在に注意する。 |
| Orders / Backlog | Conditional | 先行候補 | Cancellation、供給制約、認識時期の影響を受ける。 |
| Lead Time | Conditional | 供給制約候補 | 一貫した公式時系列の入手可能性を確認する。 |
| Capacity / Capital Expenditure | Conditional | 供給対応候補 | 投資決定と実際の供給開始にはLagがある。 |
| Power Consumption / Capacity | Conditional | インフラ制約候補 | 半導体需要との因果は別Evidenceを必要とする。 |

## 9. 明確な対象外

- Data Center建設、不動産、電力調達、冷却設備又は通信サービスを独立した投資対象として網羅する研究
- Semiconductor Manufacturing Equipment、材料、後工程を主題とする研究
- AIモデル、クラウドサービス又はソフトウェアの機能・性能比較
- 半導体企業の技術優位性、競争順位又は将来シェアの推測
- Capex、電力消費、サーバー台数から半導体販売数量又は企業売上への根拠のない変換
- Data Center、AI、Cloud、Infrastructure、Serverという語の無条件な同義化
- 発行者が分離していない地域、用途、製品又は顧客の推定配分
- Forecast、Target又はPlanをActualとして扱うこと
- Sprint001 Automotive又はSprint002 Industrial PowerのEvidence ID及び観測の無断再利用
- Catalog、DDL、Entity、Database、ML、バックテスト、Decision Engine、Advisor及び投資利用

## 10. Workstreams

| Workstream | 主対象 | Draft成果 | 停止境界 |
| --- | --- | --- | --- |
| WS-1 Core demand and investment | Microsoft、Alphabet | 投資・能力・需要文脈 | Capexから半導体需要量を推定しない。 |
| WS-2 Core compute | NVIDIA | Compute需要構造 | 製品性能又は市場シェア評価へ拡張しない。 |
| WS-3 Core power | Renesas、ROHM、Infineon | Power需要構造 | 用途非分離売上をData Centerへ配賦しない。 |
| WS-4 Definition and comparability | Core全対象 | 用語・区分・期間の比較表 | AIとData Centerを根拠なく統合しない。 |
| WS-5 Conditional extension | Phase 2承認対象 | Memory・Network・Analog・Lead / Lag候補 | §3.2のGate前に開始しない。 |

### 10.1 Minimum Source Set and Stop Rule

各Core企業について、cut-off以前に公式公開された次の資料群を確認する。

1. FY2021以降のAnnual Report、統合報告書又は同等の年次開示
2. FY2024以降の通期及び最新四半期の公式決算資料
3. Data Center又はAI Infrastructureを明示する公式戦略・Investor Day・製品資料
4. 発行者公式IRアーカイブ内の関連資料

Core企業ごとに、確認資料、検索語、期間、取得結果及び不足をSource Inventoryへ記録した時点で探索を終了できる。関係を確認できなかった場合は「今回確認した一次資料群では未確認」と記録し、不存在の証明とは扱わない。

Phase 1完了には、各Core企業について最低1件のEvidenceを得ることではなく、上記Source Setの確認と結果記録を要求する。Core企業の半数を超えて研究問いに対応する一次資料を確認できない場合は、Phase 2へ進まず、Scopeの再評価をProject Directorへ求める。

## 11. 成果物と進行順序

```text
Scope Design
    ↓
Scope Independent Review / Acceptance Decision
    ↓
Industry Research Design
    ↓
Official Source Inventory
    ↓
Raw Evidence
    ↓
Evidence Register
    ↓
PIT
    ↓
Industry and Company Research
    ↓
Independent Review
    ↓
Reviewed Draft Baseline
    ↓
Project Director Disposition
```

予定するDraft成果物：

1. Official Source Inventory
2. Raw Evidence、Evidence Register及びPIT Inventory
3. Definition and Comparability Matrix
4. Core企業のCompany Research
5. Data Center / AI Infrastructure Semiconductor Demand Industry Report
6. Conditional Value Chain及びLead / Lag Indicator Candidate Inventory
7. Independent Review Package及びReview Record
8. Reviewed Draft Baseline一覧
9. Disposition Request及びProject Director Decision参照

各成果物は上流ArtifactとVersionを参照する。Review Recordは少なくとも、対象Artifact / Version、Reviewer identity、独立性、Review date、Finding ID、Reviewer recommendation及びFollow-upを保持する。Findingへの対応とDispositionはAuthoring role及びAccountable research roleが記録する。Disposition Requestは、Reviewed Draft集合、Decision authority、Decision date、Decision、Rationale及びFollow-upへの参照を保持する。

Catalog準備以降は、Reviewed Draft Baseline完成後のProject Directorによる明示的なDispositionだけでは開始しない。Canonical範囲、`AvailableAt`、Catalog Eligibility及び適用Governanceの上流条件が別途満たされ、正式なCatalog準備判断が記録された場合に限る。

## 12. Review Gates

### Gate 1 — Scope Review

- 対象が半導体需要の研究へ限定されている。
- AIとData Centerの定義境界が明確である。
- 対象企業が供給側と需要側の役割を混同していない。
- Sprint001及びSprint002との重複・再利用境界が明確である。
- 独立ReviewerはFindingと`Recommend Accept`又は`Changes Required`をReview Recordへ記録し、自ら承認しない。
- Authoring role及びAccountable research roleはFindingへの対応とDispositionを記録する。
- Project Director又は明示的な委任記録を持つAccountable authorityがGate 1 Acceptance Decisionを記録する。
- Gate 1が正式にAcceptedとなるまでEvidence収集を開始しない。

### Gate 2 — Evidence Review

- 一次資料の発行者、公開日、対象期間及び位置を再現できる。
- Fact、Inference、Hypothesis及びProposalが区別されている。
- ForecastとActual、需要と供給、在庫と売上が区別されている。
- `AvailableAt = TBD — no use`が下流利用を防止している。
- Namespace Decisionが記録されるまでEvidence ID及びPIT IDを発行しない。

### Gate 3 — Cross-document Review

- Evidence Register、PIT、Industry Report及びCompany Researchの参照が一致する。
- 用語、期間、単位及び企業区分の差異が保持されている。
- Evidence、Knowledge及びTraceabilityを、著者と独立した人格がレビューする。

### Gate 4 — Disposition

- Reviewed Draft Baselineの完成後、Project Directorが維持、追加調査、修正又はCatalog準備のいずれかを判断する。
- Author及びReviewerはCatalog昇格を自己承認しない。
- Catalog準備のDispositionはCatalog採用又は下流利用の承認を意味せず、別途上流条件の充足を必要とする。

## 13. Definition of Done

- Working Scope、対象製品、対象企業、期間、地域及び対象外が明確である。
- Phase 1のCore Scope、Phase 2の入口条件及びSource Setの停止条件が明確である。
- Data CenterとAI Infrastructureの定義差及び複合開示の利用境界が明確である。
- 調査開始に必要なResearch Questions、Workstreams、Evidence方針及び成果物が定義されている。
- 主要主張を一次資料又は明示的なInferenceとして記録できる設計になっている。
- 日本株への投資関連性とGlobal demand evidenceを混同しない。
- Sprint001及びSprint002との重複Source Fact、再採番、Cross-sprint参照を統制できる。
- 著者から独立したEvidence、Knowledge及びTraceabilityレビューへ提出できる。
- 本文書がDraft、noncanonicalかつ下流利用不可であることが明確である。

## 14. Open Questions for Independent Review

1. `Data Center / AI Infrastructure`の作業範囲は、半導体需要研究として十分に限定されているか。
2. Compute、Memory、Network、Analog及びPowerを一つのSprintで扱うことは広すぎないか。
3. Tier 1 / Tier 2企業は、需要伝播を検証する代表企業として適切か。
4. 日本企業とGlobal demand-side企業の役割境界は明確か。
5. AI向けと従来型Data Centerを分離できない開示に対する統制は十分か。
6. Candidate Observations及び成果物は、Catalog又はML利用を先取りしていないか。
7. `S3-EVR-xxx`及び`S3-PIT-xxx`の作業用識別子候補は既存運用と整合するか。
