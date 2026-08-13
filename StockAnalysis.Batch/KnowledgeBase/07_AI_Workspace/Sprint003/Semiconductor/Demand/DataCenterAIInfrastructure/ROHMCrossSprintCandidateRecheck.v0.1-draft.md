# ROHM — Cross-sprint Candidate Recheck

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft candidate-level cross-sprint traceability record |
| Sprint | Sprint003 |
| 対象企業 | ROHM Co., Ltd. |
| Version | 0.1-draft |
| 確認日 | 2026-08-09 |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Reviewer Status | Evidence / Knowledge / Traceability — Accepted |
| Related Review Record | `ROHMCrossSprintCandidateRecheckIndependentReview.v0.1-draft.md` |
| 上流Inspection | `ROHMSourceFactInspection.v0.1-draft.md` — Accepted |
| 上流Bridge | `Sprint003DataCenterAIInfrastructureCrossSprintBridge.v0.1-draft.md` — Stage 0 Accepted |
| Evidence / PIT ID | None — Local candidate recheck only |

> **利用境界：** 本記録はRaw Evidence作成前の重複・参照確認である。限定した検索対象でmatchがないことは、Repository全体又は外部に同一資料・同一Factが存在しないことの証明ではない。Evidence採用、ID発行、`AvailableAt`確定、Catalog / DDL / ML利用を許可しない。

## 1. Examined Sets and Method

### 1.1 Stage 0 Fixed Examined Set

`Sprint003DataCenterAIInfrastructureCrossSprintBridge.v0.1-draft.md` §1.1で固定され、Stage 0独立レビューAcceptedとなった11 artifactを確認した。対象はSprint001 / Sprint002のEvidence Register、PIT、Industry Report、Evidence Acquisition関連文書及びRenesas / ROHM Company Researchである。

ROHMについて上流Bridgeは次を既存matchとして固定している。

- `CSB-ROH-001`：Sprint002 `S2-EVR-007`–`011`。Industrial売上、Forecast、Power / SiC context及び分類注記。
- `CSB-ROH-002`：Sprint001 `EVR-008`、`019`–`023`。Power-device application及びAutomotive売上。

上流Inspectionの`ROHM-SFI-001`–`004`は上記Evidenceの参照専用であり、本RecheckのRaw eligibility対象へ含めない。Industrial及びAutomotiveのFactをData Center / AI Serverへ用途配賦しない。

### 1.2 Additional Read-only Search Set

| Scope | Search content |
| --- | --- |
| Sprint001 | `KnowledgeBase/07_AI_Workspace/Sprint001/Semiconductor/Demand/Automotive`配下のDraft `.md` |
| Sprint002 | `KnowledgeBase/07_AI_Workspace/Sprint002/Semiconductor/Demand/IndustrialPower`配下のDraft `.md` |
| Legacy Research | `KnowledgeBase/01_Research`配下の既存`.md` |

追加集合は安全側に確認したread-only範囲であり、Stage 0 Accepted scopeを変更又は再承認しない。

検索語は、`ROHM`、`ローム`、`AI server business`、`Server Business sales`、`Addressable Demand Forecast`、`800VDC`、`13kW`、`22,000`、`17,000`、`Murata Power Solutions`、`RY7P250BM`、`RS7P200BM`、`SCT4013DLL`、`BM6GD11BFJ-LB`、`EcoGaN`、`GNE10xxTB`、`GNP1070TC-Z`、`Ancora`、`Delta Electronics`及び`Data Center`を含むSource Event / position / Fact固有語である。literal case-insensitive検索を行い、発行者、Source identity / event、Source position及びFact grainを組み合わせて判定した。

Stage 0で固定済みの既存ROHM Evidence以外に、Raw対象47候補と同一のSource identity / position / Factへ解決するResearch Assetは確認できなかった。一般語の一致、同一issuer、同一文書又は同一pageだけでは同一Factと判定していない。このno-matchは上記集合を2026-08-09に確認した結果に限定する。

## 2. Candidate-level Recheck

| Local ID | Source Event / Position family | Existing cross-sprint match | Related candidate / Fact-grain boundary | Raw Evidence eligibility and required treatment |
| --- | --- | --- | --- | --- |
| `ROHM-SFI-005` | FY2025 Results p.5、AI server business expansion explanation | 同じFY2025資料の既存Industrial / Automotive Factのみ。Source position / Factは異なる | `006`–`011`と同一資料だがqualitative Actual-period explanationは別Fact | **Eligible with caution.** 売上額、数量、顧客、製品別寄与又はData Center単独成長率を作らない。 |
| `ROHM-SFI-006` | FY2025 Results p.19、computer / storage向けSiC sales Forecast | 同じFY2025資料の既存Factのみ。該当Forecastは未登録 | `005`及び`007`と対象・測定分類が異なる | **Eligible with caution.** 2.5倍をForecastとして保持し、Actual、base amount又はAI-only売上へ変換しない。 |
| `ROHM-SFI-007` | FY2025 Results p.23、addressable-demand Forecast | 同一Factなし | `008`のthird-party contextはHoldであり取り込まない | **Eligible with caution.** CAGR +48%をissuer researchとして保持し、ROHM sales、absolute TAM又はshareを作らない。 |
| `ROHM-SFI-009` | FY2025 Results p.24、server architecture illustration | 同一Factなし | `010` / `011`のsales Factとは別grain | **Eligible with caution.** 18→72、13kW→1,000kW、600→22,000、300→17,000をscenarioとして保持し、universal BOM又はActual需要にしない。 |
| `ROHM-SFI-010` | FY2025 Results p.27、FY2025 Server Business sales | 同じ資料の既存Industrial / Automotive Factのみ | `011`の将来Targetと分離 | **Eligible with caution.** JPY17.0bnをmixed server-scope Actualとして保持し、AI server / Data Center単独へ配賦しない。 |
| `ROHM-SFI-011` | FY2025 Results p.27、Server Business targets | 同一Factなし | `010`のActual及びHold `044`のprior target setと非同義 | **Eligible with caution.** FY2026 JPY25.0bn、FY2028 JPY30.0bn、FY2030 JPY100bn超をTargetとして保持する。 |
| `ROHM-SFI-013` | 800VDC white paper p.3、architecture / device positioning | 同一Factなし | `029`のNVIDIA architecture responseとSource Event / claimが異なる | **Eligible.** Proposed architecture及びinternal analysisに限定し、deployed standard又はadoptionにしない。 |
| `ROHM-SFI-015` | Integrated Report 2025 p.26、total-solution strategy | 同じIntegrated Reportの既存Power / application Factのみ | `016`のActual mixと別Fact | **Eligible.** Portfolio strategyに限定し、adoption、revenue、units又はcustomer relationを作らない。 |
| `ROHM-SFI-016` | Integrated Report 2025 p.27、C&S application share | 同一page familyの`EVR-008`があるが、Source position / Fact grainは異なる | `015` / `018` / `019`と分類が異なる | **Eligible with caution.** JPY187bnと9.1%を保持し、金額算出及びAI server / Data Center配賦をしない。 |
| `ROHM-SFI-018` | Integrated Report 2025 p.28、Si MOSFET strategy | 同一Factなし | `015`のportfolio及び`019`のoptical-module R&Dと分離 | **Eligible with caution.** Strategyとして保持し、Actual sales growth又はavailabilityへ変換しない。 |
| `ROHM-SFI-019` | Integrated Report 2025 p.29、optical-module R&D direction | 同一Factなし | Power semiconductor Factとは別のadjacent-product strategy | **Eligible with caution.** Development / sales方針に限定し、power demand、commercial adoption又はrevenueにしない。 |
| `ROHM-SFI-026` | 2025-03-05 Murata 5.5kW PSU adoption announcement | 同一Factなし | `048`のcustomer production Planとは別Fact | **Eligible with caution.** Named-customer adoption assertionとして保持し、order、shipment、revenue又は全Murata PSUへ一般化しない。 |
| `ROHM-SFI-027` | 2025-04-10 MOSFET development / availability | 同一Factなし | `028`のproduction Planと分離 | **Eligible with caution.** 製品別12V enterprise / 48V AI-server mappingを保持し、mass-production Actualへ変換しない。 |
| `ROHM-SFI-028` | 2025-04-10 MOSFET mass-production Plan | 同一Factなし | `027`のdevelopment / availability及び後続production Factと非同義 | **Eligible with caution.** 2025年中のPlanとして保持し、実現済みproductionにしない。 |
| `ROHM-SFI-029` | 2025-06-12表示page、NVIDIA 800V architecture response | 同一Factなし | `030`のanonymous endorsementと同一Source Eventだが別Fact | **Eligible with caution.** ROHMのarchitecture-response assertionに限定し、NVIDIA procurement / design winへ変換しない。 |
| `ROHM-SFI-030` | 2025-06-12表示page、plural cloud-provider endorsement | 同一Factなし | `041`のsingle-provider recommendationとparty同一性なし | **Eligible with caution.** Anonymous third-party assertionとして保持し、identity、adoption stage、order又はrevenueを確定しない。 |
| `ROHM-SFI-031` | 2025-07-01 RY7P250BM market release | 同一Factなし | `041`のrecommendation assertionと分離 | **Eligible.** Product release / application positioningに限定し、customer adoption又はshipmentを作らない。 |
| `ROHM-SFI-032` | 2025-11-25 RS7P200BM mass-production commencement | 同一Factなし | `033`のapplication definitionと分離 | **Eligible with caution.** Product-level production開始として保持し、AI-server allocation又はrevenueにしない。 |
| `ROHM-SFI-033` | 2025-11-25 RS7P200BM application | 同一Factなし | `032`のproduction Factとは別grain | **Eligible.** 48V AI-server / industrial application definitionに限定し、adoption又はActual需要にしない。 |
| `ROHM-SFI-034` | 2026-02-26 GaN supply-system decision | 同一Factなし | 既存production FactとSource Event / classificationが異なる | **Eligible with caution.** TSMC GaN technologyの移管とin-group production system構築を決定したDecision、及び2027年のsystem establishmentを目指すPlanを両方保持する。DecisionとPlanを同義化せず、transfer / construction完了、capacity又はAI-server allocationを作らない。 |
| `ROHM-SFI-035` | 2026-04-21 5th Generation SiC development completion | 同一Factなし | `036` sample Plan、`037` applicationと分離 | **Eligible with caution.** Development-stage Actualとして保持し、mass production又はadoptionにしない。 |
| `ROHM-SFI-036` | 2026-04-21 sample provision Plan | 同一Factなし | `035` / `037`と別Fact | **Eligible with caution.** 2026-07からのPlanとして保持し、sample delivery Actualにしない。 |
| `ROHM-SFI-037` | 2026-04-21 AI-server / Data Center application examples | 同一Factなし | `035` / `036`のstage Factと分離 | **Eligible.** Issuer-defined applicationに限定し、adoption、shipment又は専用productにしない。 |
| `ROHM-SFI-038` | 2026-06-03 SCT4013DLL BBU adoption | 同一Factなし | Other adoption assertionsとcustomer / product / Source Eventが異なる | **Eligible with caution.** Anonymous-customer adoption assertionとして保持し、identity、order、production deployment又はrevenueを確定しない。 |
| `ROHM-SFI-039` | 2026-07-09 600V SJ MOSFET mass production | 同一Factなし | `040`のapplication definitionと分離 | **Eligible with caution.** Production commencementとして保持し、AI-server allocation、volume又はrevenueにしない。 |
| `ROHM-SFI-040` | 2026-07-09 AI-server / Data Center application | 同一Factなし | `039`のproduction Factとは別grain | **Eligible.** Application positioningに限定し、adoption又はActual需要にしない。 |
| `ROHM-SFI-041` | 2025-07-01 single cloud-provider recommendation assertion | 同一Factなし | `030`とは匿名party、単複、assertion typeが異なり相互corroboration禁止 | **Eligible with caution.** Identity、design、adoption stage、order又はproduction deploymentを確定しない。 |
| `ROHM-SFI-042` | FY2024 Results p.24、product-development Plan | 同じFY2024資料の既存Industrial / Automotive Factのみ | `057`のSAM illustrationと同一pageだが別Fact | **Eligible with caution.** Planとして保持し、completion、sales、adoption又はavailabilityにしない。 |
| `ROHM-SFI-043` | FY2025 H1 Results p.29、qualitative adoption assertion | 同一Factなし | Hold `044`のtarget graphicとは別Fact | **Eligible with caution.** Product、customer、stage、order、revenue及び数量を補完しない。 |
| `ROHM-SFI-045` | 2023-03-07 Murata Data Center PSU adoption | 同一Factなし | `059`のcustomer production-stage assertionと同一Source Eventだが別Fact | **Eligible with caution.** Named-customer adoption assertionに限定し、shipment、revenue又は全Murata PSUへ一般化しない。 |
| `ROHM-SFI-046` | 2025-06-25 BM6GD11BFJ-LB availability | 同一Factなし | `047`のapplication definitionと分離 | **Eligible.** Development / availability Actualに限定し、mass-production volume又はserver adoptionにしない。 |
| `ROHM-SFI-047` | 2025-06-25 server power-supply application | 同一Factなし | `046`と同一Source Eventだが別Fact | **Eligible.** Product suitabilityに限定し、AI-server専用、adoption又はActual需要にしない。 |
| `ROHM-SFI-048` | 2025-03-05 Murata 5.5kW PSU production Plan | 同一Factなし | `026` adoption assertionと分離 | **Eligible with caution.** Named-customer Planとして保持し、production commencement Actual又はorderにしない。 |
| `ROHM-SFI-049` | 2021-05-27 150V GaN technology development | 同一Factなし | `050` sample Plan及び`058` applicationと分離 | **Eligible with caution.** Technology development Actualに限定し、commercial product又はdemandにしない。 |
| `ROHM-SFI-050` | 2021-05-27 sample-shipment Plan | 同一Factなし | `049` / `058`と同一Source Eventだが別Fact | **Eligible with caution.** 2021-09 Planとして保持し、shipment Actual又はmass productionにしない。 |
| `ROHM-SFI-051` | 2022-04-28 Delta strategic partnership | 同一Factなし | `052` / `053` / `060`と同一Source Eventだがrelation grainが異なる | **Eligible with caution.** Partnership Actualに限定し、product adoption、order又はexclusive relationにしない。 |
| `ROHM-SFI-052` | 2022-04-28 150V GaN production-system statement | 同一Factなし | `061`と同じ2022-03 production transitionに関係する後続のsystem-level statement。`060` application Planとは分離 | **Eligible with caution.** System establishment Actualとして保持する。`061`と別Rawにする場合も、独立した二度のproduction進展、二重シグナル又はcorroborationによる確度加算として数えず、volume、allocation又はrevenueにしない。 |
| `ROHM-SFI-053` | 2022-04-28 Delta 600V GaN joint Plan | 同一Factなし | `051` partnership Actualと別Fact | **Eligible with caution.** Development / mass-production Planとして保持し、completion又はcommencement Actualにしない。 |
| `ROHM-SFI-054` | 2023-05-08 650V GaN HEMT production | 同一Factなし | `055` application及び`056` Ancora relationと分離 | **Eligible with caution.** Product mass-production commencementとして保持し、server allocation又はcustomer adoptionにしない。 |
| `ROHM-SFI-055` | 2023-05-08 server application | 同一Factなし | `054` / `056`と別grain | **Eligible.** Mixed server application definitionに限定し、AI-server / Data Center単独又はActual需要にしない。 |
| `ROHM-SFI-056` | 2023-05-08 Ancora joint-development relation | 同一Factなし | `051` / `053`のDelta partnershipとはSource Event / product grainが異なる | **Eligible with caution.** Direct development relationに限定し、purchase、adoption、order又はexclusive relationにしない。 |
| `ROHM-SFI-057` | FY2024 Results p.24、FY2024–FY2028 SAM illustration | 同じFY2024資料の既存Factのみ。該当illustrationは未登録 | `042`のdevelopment Plan及び後続sales targetsと非同義 | **Eligible with caution.** 4倍をrelative illustrationとして保持し、absolute SAM、sales、share又はachievementにしない。 |
| `ROHM-SFI-058` | 2021-05-27 Data Center application statement | 同一Factなし | `049` / `050`と同一Source Eventだがapplication grain | **Eligible.** Issuer-defined technology / applicationに限定し、commercial product又はActual demandにしない。 |
| `ROHM-SFI-059` | 2023-03-07 Dr. Longcheng Tan production-stage statement | 同一Factなし | `045` adoption assertionと同一Source Eventだがexternal speaker / production grain | **Eligible with caution.** Named-customer assertionとして保持し、start date、volume、ROHM shipment又はrevenueを補完しない。 |
| `ROHM-SFI-060` | 2022-04-28 EcoGaN future application expansion | 同一Factなし | `051`–`053`と同一Source Event、`062`とは別Source Event / product wording | **Eligible with caution.** Intended expansion Planとして保持し、current availability又はadoptionにしない。 |
| `ROHM-SFI-061` | 2022-03-22 GNE10xxTB production commencement | 同一Factなし | `052`は同じ2022-03 production transitionに関係する後続Source Eventのsystem-level statement | **Eligible with caution.** Direct product-series commencementとして保持する。`052`と別Rawでも二度のproduction進展、独立シグナル又は確度加算として数えず、volume、Data Center allocation又はrevenueにしない。 |
| `ROHM-SFI-062` | 2022-03-22 Data Center / base-station application | 同一Factなし | `061`と同一Source Eventだがapplication grain。`060`は後続Plan | **Eligible.** Issuer-defined applicationに限定し、Data Center専用production、adoption又はActual demandにしない。 |

InspectionでHoldとなった`ROHM-SFI-008`、`012`、`014`、`017`、`020`–`025`及び`044`は本RecheckのRaw eligibility対象外である。No-matchを理由にHoldを解除しない。Reference-onlyの`ROHM-SFI-001`–`004`も再発行しない。

## 3. Reconciliation Rules for Raw Evidence

- Reference-only 4件は既存Sprint Evidenceを参照し、S3 Raw / EVR / PITを作成しない。
- 同じFY2025 ResultsをSourceとするRaw対象`005`–`007`及び`009`–`011`は、qualitative explanation、Forecast、scenario、Actual、Targetを別Rawへ一対一化し、既存Industrial / Automotive Factを再利用しない。`008`はHoldでありRaw化しない。
- `010`のFY2025 Actualと`011`のfuture Targetを結合しない。Hold `044`のprior target setも取り込まない。
- `015` / `016` / `018` / `019`は同じIntegrated Reportのstrategy、Actual mix、product strategy、adjacent-product R&Dを分離する。
- `029`のNVIDIA architecture responseをprocurement / design winへ変換しない。`030`と`041`の匿名partyを同一化又は相互corroborationしない。
- Product development、availability、sample Plan、mass-production Plan、mass-production commencement及びapplication definitionを、同一Source Eventでも別Rawへ一対一化する。
- `026` / `048`、`027` / `028`、`032` / `033`、`035`–`037`、`039` / `040`、`045` / `059`、`046` / `047`、`049` / `050` / `058`、`051`–`053` / `060`、`054`–`056`及び`061` / `062`のFact grainを相互に混ぜない。
- `051`のpartnership、`053`のjoint Plan及び`056`のproduct-level joint developmentを一つのDelta commercial relationへ統合しない。
- `052`の後続production-system statementと`061`の直接product-production commencementを同一Source Eventとして扱わない。一方、両方が同じ2022-03 production transitionに関係するため、二度のproduction進展、独立した需要シグナル又はcorroborationによる確度加算として二重計上しない。
- 数値、ratio、application又はrelationshipを、customer order、shipment、revenue、market share、AI-server単独値又はData Center単独値へ変換しない。
- InspectionのHold及びExcluded transformationをRaw Evidenceへ混入させない。

## 4. Preliminary Disposition

| Result | Count | Treatment |
| --- | ---: | --- |
| Existing Evidence reference only | 4 | `ROHM-SFI-001`–`004`; 既存Evidence参照、S3再発行なし |
| No identical cross-sprint match / Raw eligible | 11 | `013`、`015`、`031`、`033`、`037`、`040`、`046`、`047`、`055`、`058`、`062` |
| No identical cross-sprint match / Raw eligible with caution | 36 | `005`–`007`、`009`–`011`、`016`、`018`、`019`、`026`–`030`、`032`、`034`–`036`、`038`、`039`、`041`–`043`、`045`、`048`–`054`、`056`、`057`、`059`–`061` |
| Duplicate — do not create new Raw Evidence | 0 | Raw対象47件には完全重複なし |
| Hold / outside recheck eligibility | 11 | `008`、`012`、`014`、`017`、`020`–`025`、`044`; Raw Evidence化しない |

## 5. Gate Status and Next Gate

| Gate | Status | Record / Next action |
| --- | --- | --- |
| Candidate-level Cross-sprint recheck | Completed — Accepted | `ROHMCrossSprintCandidateRecheckIndependentReview.v0.1-draft.md` |
| Raw Evidence | Draft completed — 47 artifacts; Independent Review Accepted | `ROHMRawEvidenceIndependentReview.v0.1-draft.md` |
| EVR ID / registration | Not issued / not registered | Raw review Accepted後、EVR行作成時に発行 |
| PIT ID / registration | Not issued / not registered | EVR review Accepted後、一対一PIT行作成時に発行 |
| AvailableAt / Catalog | Not permitted | `TBD — no use` / `No` |
