# Sprint003 Data Center / AI Infrastructure — Phase 2 Scope Design Proposal

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft scope design proposal |
| Sprint | Sprint003 |
| Research Domain | Semiconductor — Demand — Data Center / AI Infrastructure |
| Phase | Phase 2 — Conditional extension proposal |
| Version | 0.1-draft |
| 作成日 | 2026-08-11 |
| 状態 | Draft — Project Director Option A Scope Activation recorded; Gate P2-3 authorized; P2-4 Research production not started; noncanonical |
| Author | Documentation Team / Research Team — Authoring personas |
| Phase 1 Authority | `Sprint003DataCenterAIInfrastructureSemiconductorDemandScopeDesign.v0.1-draft.md` |
| Phase 1 Disposition | `Sprint003DataCenterAIInfrastructureReviewedDraftDispositionRequest.v0.1-draft.md` — Option A及び2026-08-11 Phase 2 Scope Proposal authoring direction |
| Phase 1 Baseline | `Sprint003DataCenterAIInfrastructureReviewedDraftBaseline.v0.1-draft.md` |
| Review Record | `Sprint003DataCenterAIInfrastructurePhase2ScopeDesignIndependentReview.v0.1-draft.md` |
| Decision Record | `Sprint003DataCenterAIInfrastructurePhase2ScopeDecisionRecord.v0.1-draft.md` — Accepted 2026-08-11 |
| Scope Activation Decision | `Sprint003DataCenterAIInfrastructurePhase2ScopeActivationDecisionRecord.v0.1-draft.md` — Option A recorded 2026-08-13 |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | No |

> **権限境界：** 本文書はPhase 2の対象、入口条件、停止条件及びGateを提案するDraftである。作成又は独立reviewは、Scope Acceptance、公式Source探索、Candidate Eligibility確認、追加Evidence、ID発行、Research実行、Catalog、DDL、ML、投資利用又はPhase 2開始を承認しない。

## 1. Purpose

Phase 1で確立したDemand-side → Compute → Power supplyのReviewed Draft Baselineに対し、重要な未被覆領域であるMemory及びNetwork / Opticalを、統制されたConditional Scopeとして追加できるかを設計する。

Phase 2はPhase 1の調査量を単純に増やす作業ではない。公式Sourceによる直接関係、Cross-sprint重複、比較可能性、停止条件及び利用制約をCandidate単位で確認し、入口条件を満たした対象だけを別GateでResearchへ進める。

## 2. Governing Constraints

Phase 1 Scope Design §3.2の4条件をPhase 2 Candidateごとに満たす必要がある。

1. Core ScopeだけではResearch Questionに重要な欠落が残る。
2. 公式資料で対象用途と半導体製品又は投資の直接的な関係を少なくとも1件確認できる。
3. 追加理由、重複確認及び調査停止条件をReview Recordへ記録できる。
4. Scope差分、判断者、判断日及び理由をDecision Recordへ記録し、Project Director又は**明示的な委任記録を持つAccountable authority**の承認を得る。

本Design段階では第2条件を新規検索で確認しない。Scope Acceptance後に限り、IDを発行しないCandidate Eligibility Pre-checkを実施できる。Pre-checkで条件を満たさないCandidateはResearch対象へ追加しない。

## 3. Proposed Working Scope

### 3.1 Priority 1 — Memory / Storage Semiconductor

| 対象 | 含める範囲 | 境界 |
| --- | --- | --- |
| HBM | AI accelerator / server用途を発行者が直接明示する製品、需要、売上、capacity、shipment又はPlan | HBM capacity、bit shipment、price及びrevenueを同一指標にしない。 |
| DRAM | Data Center / server / AI用途を発行者が分離又は明示する開示 | DRAM全体をAI需要へ配賦しない。 |
| NAND / enterprise storage semiconductor | Data Center / enterprise SSD / AI infrastructure用途を発行者が直接明示する開示 | Storage system、SSD、NAND bit、price及びrevenueを相互変換しない。 |

**Initial issuer candidates:** Micron Technology、SK hynix、Samsung Electronics、Kioxia Holdings。

候補列挙は開示又は関係の存在をFactとして確定しない。各社はEligibility Pre-checkを通過した場合だけResearch対象になる。

### 3.2 Priority 1 — Network / Optical Semiconductor

| 対象 | 含める範囲 | 境界 |
| --- | --- | --- |
| Data Center networking silicon | Switch ASIC、network processor、NIC / DPU、PHY等でData Center / AI cluster用途が直接明示される開示 | Telecom、Enterprise、Wireless及びData Centerを無断配賦しない。 |
| Optical / connectivity semiconductor | DSP、SerDes、optical interconnect、retimer等でAI / Data Center用途が直接明示される開示 | Optical system、module、component及びsemiconductor contentを同義化しない。 |
| Existing Compute-network context | Phase 1 NVIDIA Evidenceのnetworking definition / revenue / driverをread-only baselineとして参照 | 同一Source FactをPhase 2で再採番しない。 |

**Initial issuer candidates:** Broadcom、Marvell Technology。NVIDIAは新規Company candidateではなくPhase 1 read-only referenceとする。

### 3.3 Priority 2 — Detailed Capacity and Supply-stage Context

Priority 1でEligibleとなった発行者についてのみ、次をResearch-level contextとして扱える。

- Fab / packaging / HBM stack / test等のissuer-defined capacity
- Capacity investment Decision / Plan / commencement / ramp stage
- Inventory、backlog、shipment、allocation及びsupply constraint
- Product generation transition

投資額を用途別capacity、shipment、bit、unit又はrevenueへ推定変換しない。Capacityの所在地・工程・製品用途が分離されない場合は原表記を維持する。

### 3.4 Priority 3 — Lead / Lag Candidate Assessment

Lead / LagはResearch Factではなく、比較可能性と運用可能性を評価するCandidate Assessmentに限定する。

- 最低3時点の同一定義seriesが公式Sourceで再現できること
- Publication Event、Applicable Period及び`AvailableAt`を区別できること
- Demand、order、shipment、revenue、inventory、capacity及びpriceのgrainを分離できること
- fixed lag、causality、feature adoption又は投資signalを主張しないこと

全既存Evidenceが`AvailableAt = TBD — no use`であるため、Phase 2でもLead / LagをDDL / ML / backtestへ接続しない。

### 3.5 Deferred — Not Active in This Proposal

- Analog / Mixed Signal / Embeddedの横断拡張
- AMD、Texas Instruments、onsemi、STMicroelectronics、Amazon、NTT DATA、Fujitsu、NEC等の追加Company Research
- Semiconductor Manufacturing Equipment、材料、後工程産業の網羅
- Cooling、power utility、Data Center construction又はtelecom serviceの独立Industry Research
- Value Chain、feature、Catalog、DDL、ML、backtest又は投資利用

Deferred対象を追加するには本Designのrevision、独立review及び新たなProject Director Decisionを必要とする。

## 4. Phase 2 Research Questions

| Local ID | Research Question | 必要なEvidence |
| --- | --- | --- |
| S3-DCAI-P2-RQ-001 | 発行者はHBM、DRAM、NAND又はenterprise storageをData Center / AI Infrastructure需要とどの定義・製品・期間で接続するか。 | 公式年次・決算・IR・製品資料のissuer-defined relation。 |
| S3-DCAI-P2-RQ-002 | Network / Optical semiconductor需要は、Data Center / AI cluster、bandwidth、switching又はinterconnectとどのgrainで開示されるか。 | 公式売上、用途、product、capacity、shipment、Forecast又はPlan。 |
| S3-DCAI-P2-RQ-003 | MemoryとNetworkでは、Actual、Forecast、Plan、shipment、capacity及びproduct generationの定義差が比較可能性をどう制約するか。 | Publication Event、Applicable Period、unit、denominator及びstage。 |
| S3-DCAI-P2-RQ-004 | 単一の公式Sourceが、AI / Data Center投資又はsystem demandとspecific Memory / Network productを直接接続するか。 | Issuer-named relation。cross-source synthesisをDirect relationにしない。 |
| S3-DCAI-P2-RQ-005 | Inventory、backlog、shipment、capacity及びproduct transitionは需要観測の解釈へどの制約を与えるか。 | 同一定義series、stage及び利用境界。 |
| S3-DCAI-P2-RQ-006 | 日本株対象のKioxiaについて、将来観測候補となり得る開示と利用不能なGapは何か。 | 再現可能なSource Fact、PIT、Gap及びnon-use境界。 |

Local IDは本Artifact / Versionだけが所有し、Evidence ID又はCanonical Identifierではない。

## 5. Candidate Company Matrix

| Priority | Candidate | Proposed role | Entry evidence required | Initial prohibition |
| ---: | --- | --- | --- | --- |
| 1 | Micron Technology | Memory benchmark candidate | AI / Data CenterとHBM / DRAM / NANDの公式direct relation | 全社MemoryをAIへ配賦しない。 |
| 2 | SK hynix | HBM / Memory supply candidate | AI / server用途とproduct / shipment / capacityの公式direct relation | HBM leadership又はshareを推定しない。 |
| 3 | Samsung Electronics | Mixed Memory benchmark candidate | Data Center / AIとMemory productの公式direct relation | Device Solutions全体を対象用途へ配賦しない。 |
| 4 | Kioxia Holdings | Japan-equity Memory candidate | Data Center / enterprise / AIとNAND / SSDの公式direct relation | enterprise storageをAI専用へ変換しない。 |
| 5 | Broadcom | Network / connectivity candidate | AI / Data Centerとnetworking / connectivity semiconductorの公式direct relation | AI revenue、customer又はproduct scopeを推定しない。 |
| 6 | Marvell Technology | Network / optical candidate | AI / Data Centerとnetworking / optical productの公式direct relation | Design winをshipment / revenueへ変換しない。 |

**Breadth cap:** 新規issuerは最大6社、active product familyはMemoryとNetwork / Opticalの2群までとする。超過にはDesign revisionと新たなDecisionを必要とする。

## 6. Period, Geography and Source Boundary

- Eligibility Pre-check cut-off: Gate P2-0のPre-check Authorization Decisionで固定する。Design作成日を自動的なcut-offにしない。
- Active research cut-off: Gate P2-2のScope Activation Decisionで、Pre-check cut-offの継承又は更新を明示して固定する。更新する場合は追加Sourceの対象範囲と理由をDecision Recordへ記録する。
- Standard lookback: FY2021以降。主要分析期間はFY2022以降を候補とし、各issuerの会計年度を維持する。
- Geography: Global demand。日本株relevanceはKioxiaを別grainで扱う。
- Source: issuer公式Annual Report、決算資料、規制提出、Investor Day、公式IR / Newsroom / product資料。
- cut-off以前の公式Sourceだけを対象とし、Publication EventとApplicable Periodを分離する。
- publication time / timezone不明はUnknown、`AvailableAt = TBD — no use`とし推測しない。

## 7. Cross-sprint and Phase 1 Control

- Sprint001、Sprint002及びSprint003 Phase 1のEvidence / PIT / Raw / Company Researchをread-only検索する。
- 同一Source Event、Source position及びFact grainは既存IDを参照し、再採番しない。
- NVIDIA、Microsoft、Alphabet、Renesas、ROHM及びInfineonはPhase 1 baselineとして参照し、Scope revisionなしにPhase 2 Company Researchを再発行しない。
- Phase 1 `S3-EVR-001`–`132` / `S3-PIT-001`–`132` namespaceをPhase 2へ自動継続しない。
- Phase 2 Evidence / PIT IDは、Scope Acceptance後の別Namespace Decisionまで予約・発行しない。

## 8. Entry Gates and Work Sequence

### Gate P2-0 — Scope Proposal Review / Pre-check Authorization Decision

- 本DesignをEvidence / Knowledge / Traceabilityの独立personaがreviewする。
- Project Director又は明示的な委任記録を持つAccountable authorityは、Accept、Revise、Reject又はHoldを別Decision Recordへ記録する。委任による場合はdelegation recordを参照する。
- Accept時はEligibility Pre-check cut-offをDecision Recordで固定する。
- Accepted前にEligibility Pre-checkを開始しない。

### Gate P2-1 — ID-less Candidate Eligibility Pre-check

- Candidateごとに、公式Source Setの所在及びentry conditionとなるdirect relationの存在・source positionだけを限定確認する。
- 許可するinspectionは、source identity、Publication Event、version、official URL、source position、source-exact candidate statement、provisional classification及びuse boundaryの記録に限る。
- Phase 1 Scope §3.2のdirect relation 1件以上を再現できるCandidateだけをEligibleとする。
- 全文Fact inspection、Research synthesis、Source Fact Inspection、Raw、EVR、PIT又はCompany Researchを作成しない。

Candidate Eligibility RecordはCandidateごとに次を必須記録とする。

| Required field | Purpose |
| --- | --- |
| Candidate / product family | 判定単位を固定する。 |
| Phase 1 RQ / Gap reference | Core Scopeに残る重要Gapを特定する。 |
| Materiality / Core Scopeで解消不能な理由 | §3.2 condition 1と追加理由をCandidate単位で示す。 |
| Official direct-relation source / event / version / position | §3.2 condition 2を再現する。 |
| Source-exact candidate statement | relationの意味を推測で拡張しない。 |
| Provisional classification / use boundary | Actual、Forecast、Plan、product stage等を分離する。 |
| Cross-sprint / Phase 1 result | 重複、Reference-only又は新規性を示す。 |
| Candidate-specific stop condition | §3.2 condition 3を固定する。 |
| Proposed scope delta | 追加issuer、product、period及び除外を明示する。 |
| Reviewer result | conditions 1–3の独立review結果を記録する。condition 4はScope Activation Decision Recordでのみ成立する。 |

### Gate P2-2 — Eligibility Review and Scope Activation Decision

- Eligible Candidate一覧を独立reviewし、Candidateごとに§3.2 conditions 1–3のMet / Not met / Holdを記録する。
- Project Director又は明示的な委任記録を持つAccountable authorityは、Candidateごとのconditions 1–3が全件Metであることを確認し、active issuer、product family、scope delta、research cut-off、Decision authority、Decision date、rationale及び除外をDecision Recordへ記録することでcondition 4を満たす。委任による場合はdelegation recordを参照する。
- 1条件でも未達のCandidateはNot eligible又はHoldとし、active scopeへ追加しない。
- Candidate不足時はScopeを拡張せず、Hold又はDesign revisionへ戻す。

### Gate P2-3 — Research Design and Namespace Decision

- Active scopeだけのIndustry Research Design、Source Inventory及びCross-sprint Bridgeを作成する。
- Namespace Decision後にのみRaw / EVR / PITを発行する。

### Gate P2-4 — Evidence and Research Production

- Inspection → Candidate Recheck → Raw → EVR → PIT → Company Research → Matrix extension → Report addendumの順を維持する。
- 各Gateで独立review Accepted前に次へ進まない。

### Gate P2-5 — Phase 2 Closure and Disposition

- Reviewed Draft Baseline Addendumを作成する。
- Phase 2 Closure Assessmentを作成する。
- Baseline Addendum及びClosure Assessmentに対するIndependent Closure Review Recordを作成し、Acceptedを得る。
- Accepted後にProject Director Disposition Requestを作成する。
- Project Director又は明示的な委任記録を持つAccountable authorityがDecision、date、rationale及びfollow-upをDecision Recordへ記録する。委任による場合はdelegation recordを参照する。
- Project Director Disposition前にCatalog、Phase 3又は下流利用へ進まない。

## 9. Minimum Source Set and Stop Rules

各Candidateについて次を確認し、結果を記録した時点で探索を終了できる。

1. FY2021以降のAnnual Report又は規制提出年次資料
2. FY2024以降の通期及び最新四半期決算資料
3. Data Center / AI / server / Memory / Network / Opticalを明示する公式戦略又は製品資料
4. 公式IR archive / Newsroom内の関連Source Event

Candidate単位のStop Rule:

- direct relationを確認できない場合はNot eligibleとして終了し、存在しないとの証明にしない。
- 同一FactがPhase 1又は既存Sprintにある場合はReference-onlyとして終了する。
- publication date / version identityがcut-off inclusionを確立できない場合はHoldとする。
- source definition、denominator又はspeaker attributionが解決しない場合はHoldとする。
- 1社の探索で追加Source familyが3つを超えて必要になった場合は探索を停止し、Reviewへ上げる。
- breadth capを超えるCandidate又はproduct familyを追加しない。

## 10. Explicit Non-Claims

- Memory又はNetwork市場の規模、share、ranking、CAGR又はForecast achievementを推測しない。
- Hyperscaler Capex、NVIDIA revenue又はrack powerからHBM、DRAM、NAND、switch、DSP又はoptical shipmentを導出しない。
- bit shipment、wafer、stack、package、device、port、bandwidth、unit、ASP及びrevenueを相互変換しない。
- Demand-side investmentとspecific supplier revenueをcross-sourceでDirect relationにしない。
- product announcement、recommendation、design win、sample、availability、mass production、shipment及びrevenueを同義化しない。
- Capacity PlanをActual capacity又はData Center / AI専用capacityへ変換しない。
- Candidate listing又はEligibilityをCatalog candidate、feature、Lead / Lag、投資signal又はAvailableAtへ昇格しない。
- Phase 1 Evidenceのreview acceptanceをPhase 2利用可能性へ継承しない。

## 11. Proposed Deliverables

1. Phase 2 Scope Design及びIndependent Review Record
2. Project Director Scope Acceptance / Revision Decision Record
3. ID-less Candidate Eligibility Inventory及びIndependent Review Record
4. Scope Activation Decision Record
5. Phase 2 Industry Research Design
6. Cross-sprint / Phase 1 Bridge Addendum
7. Official Source Inventory
8. Namespace Decision Request / Record
9. Raw Evidence、Evidence Register Addendum及びPIT Inventory Addendum
10. Definition and Comparability Matrix Addendum
11. Eligible Company Research
12. Industry Report Addendum
13. Independent Review Package
14. Reviewed Draft Baseline Addendum
15. Phase 2 Closure Assessment
16. Independent Closure Review Record
17. Project Director Disposition Request
18. Project Director Decision Record

Lead / Lag Candidate AssessmentはPriority 1 Evidenceと時点属性のreview後に作成可否を別途判断し、必須成果物にしない。

## 12. Review Gates

- **Scope:** priority、breadth cap、deferred範囲、入口条件及び停止条件が明確である。
- **Evidence:** issuer、Source Event、position、period、unit、denominator及びstageを再現できる。
- **Knowledge:** Fact、Inference、Hypothesis、Gap、Proposal及びDecisionを分離する。
- **Traceability:** Phase 1 / cross-sprint重複、ID、review、Decision及びfollow-upが一対一で解決する。
- **Authority:** Reviewerはrecommendationだけを記録し、Project Director又は**明示的な委任記録を持つAccountable authority**がScope / activation / closureをDecisionする。委任によるDecisionはdelegation recordを参照する。

## 13. Definition of Done — This Design Proposal

- Phase 2のactive proposal、deferred範囲及びbreadth capが明示されている。
- Phase 1 §3.2の4条件をCandidate単位で検証するGateが定義されている。
- Research Questions、Candidate Matrix、Source Set、Stop Rule、deliverables及びreview sequenceが明示されている。
- Phase 1 Evidence、namespace、AvailableAt、Catalog及び利用境界を自動継承していない。
- 独立Evidence / Knowledge / Traceability reviewへ提出できる。
- Project Director Scope Acceptance前にEligibility Pre-check又はResearchを開始していない。

## 14. Scope Acceptance Status

Project Directorは2026-08-11に本Scope Design ProposalをAcceptedとし、Eligibility Pre-check cut-offを`2026-08-11 23:59 JST`に固定した。Gate P2-1のIDなしCandidate Eligibility Pre-checkは開始可能である。

このAcceptanceはGate P2-2 Scope Activation、Phase 2 Industry Research Design、Namespace Decision、Source Fact Inspection、Raw Evidence、EVR / PIT、Company Research、Catalog又は下流利用を承認しない。
