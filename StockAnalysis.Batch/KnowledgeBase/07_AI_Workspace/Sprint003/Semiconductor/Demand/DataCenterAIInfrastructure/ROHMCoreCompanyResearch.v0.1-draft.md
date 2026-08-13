# Sprint003 ROHM Core Company Research — Data Center / AI Infrastructure

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft core company research asset |
| Sprint | Sprint003 |
| 対象企業 | ROHM Co., Ltd. |
| Research Domain | Semiconductor — Demand — Data Center / AI Infrastructure |
| Version | 0.1-draft |
| 作成日 | 2026-08-09 |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Author | Documentation Team — Research Author persona |
| Reviewer | Evidence Validation / Chief Knowledge / Traceability reviewers — Accepted |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md` |
| Evidence Gate | `ROHMEvidencePackageGateReconciliation.v0.1-draft.md` — Independent Review Accepted |
| Evidence範囲 | `S3-EVR-046`–`092` / `S3-PIT-046`–`092` |
| Review Record | `ROHMCoreCompanyResearchIndependentReview.v0.1-draft.md` |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | No |

> **利用境界：** 本文書は、独立レビュー済みEvidenceを企業単位で整理するDraft Research Assetである。Canonical Knowledge、Catalog、DDL、Entity、Database、ML、バックテスト、Decision Engine、Advisor又は投資判断への利用を許可しない。

## 1. 研究目的と責務

ROHMがData Center（データセンター）又はAI Infrastructure（AIインフラ）に関係するPower Semiconductor（パワー半導体）及びPower Management（電源管理）を、どの事業・製品・技術・関係性・将来計画として開示しているかを、Evidence IDへ追跡可能な形で統合する。

本文書は新しいSource Factを作らない。FactはEvidence Registerを参照し、Cross-source Inference（複数資料に基づく推論）はFactと分離する。未確認関係はGapとして保持する。

対象Research Questionは`S3-DCAI-RQ-001`、`004`、`005`、`006`及び`007`である。

## 2. Evidence Baseline

| 区分 | 件数 | 状態 |
| --- | ---: | --- |
| Source Fact候補 | 62 | Inspection Accepted |
| Reference-only | 4 | Sprint001 / 002 Evidenceを参照。Sprint003で再発行しない |
| Raw-eligible | 47 | Proceed 11 + Proceed with caution 36 |
| Hold | 11 | Raw / EVR / PIT未作成 |
| ROHM Raw Evidence | 47 | Package Review Accepted |
| ROHM EVR / PIT | 47 / 47 | Independent Review Accepted |

全47件は`AvailableAt = TBD — no use`、Catalog Eligibility `No`である。Evidence ID又はPIT IDの存在を、Canonical性、利用可能性又は投資上の有効性とみなさない。

## 3. Fact — 発行者が示す事業・需要文脈

### 3.1 Server Businessと将来値

- ROHMは、新製品の立上げ等を背景としてAI server businessが拡大したと説明している。ただし、売上額、数量、顧客又は製品別寄与はこの説明だけでは確定しない。根拠：`S3-EVR-046`。
- FY2025 Server Business salesはJPY17.0bnと表示される。`Server Business`はAI server単独又はData Center単独とは定義されていない。根拠：`S3-EVR-050`。
- FY2026 JPY25.0bn、FY2028 JPY30.0bn、FY2030 JPY100bn超はTargetであり、FY2025 Actualと分離する。根拠：`S3-EVR-051`。
- FY2026のComputer / Storage向けSiC sales前年比2.5倍はForecastであり、Actualではない。根拠：`S3-EVR-047`。
- AI server向けpower devicesのFY2025–FY2030 CAGR +48%は発行者調査によるaddressable-demand Forecastであり、ROHM sales又は第三者検証済み市場予測ではない。根拠：`S3-EVR-048`。
- FY2024からFY2028へのSAM 4倍はproduct lineup強化によるissuer illustrationであり、Actual achievement、sales又はshareではない。根拠：`S3-EVR-087`。

### 3.2 Actualと混合Scope

- FY2024 Discrete Semiconductor net sales JPY187bnに対するComputer & Storage application shareは9.1%と表示される。ただし金額を機械算出せず、AI server又はData Center単独へ配賦しない。根拠：`S3-EVR-054`。
- AI data serversを中心にROHM productsのadoptionが進んでいるという発行者説明はあるが、製品、顧客、stage、order、shipment、revenue及び数量は未開示である。根拠：`S3-EVR-074`。

## 4. Fact — Architecture、製品及び技術Positioning

### 4.1 ArchitectureとPortfolio

- Next-generation AI serverのissuer scenarioは、main boards 18→72、power consumption 13kW→1,000kW、power components 600→22,000、analog components 300→17,000を示す。2027年頃以降のscenarioであり、Current average又はuniversal BOMではない。根拠：`S3-EVR-049`。
- 800VDC architectureについて、ROHM internal analysisはpower-source側にSiC、IT-rack側にGaNを位置付ける。Proposed architectureであり、industry standard又はdeployed systemではない。根拠：`S3-EVR-052`。
- ROHMはhigh-voltageからlow-voltageまでICとpower devicesを組み合わせるtotal-solution strategyを示す。Strategyであり、Actual adoption又はrevenueではない。根拠：`S3-EVR-053`。
- NVIDIA 800V HVDC architectureへの対応を発行者は説明するが、NVIDIA procurement、design win又はcommercial deploymentを確定しない。根拠：`S3-EVR-060`。

### 4.2 Si / SiC / GaN / 周辺製品

| 領域 | 確認できた発行者開示 | Evidence | 利用境界 |
| --- | --- | --- | --- |
| Si MOSFET | AI server市場で高付加価値MOSFETを投入するStrategy | `S3-EVR-055` | Actual sales growth又はadoptionではない |
| Si MOSFET | RS7E200BGは12V enterprise-server、RS7N200BH / RS7N160BHは48V AI-server向けとしてavailabilityを開示 | `S3-EVR-058` | Mass production、shipment、revenueではない |
| Si MOSFET | RY7P250BMを48V AI-server hot-swap向けにmarket release | `S3-EVR-062` | Customer adoption又はshipmentではない |
| Si MOSFET | RS7P200BMは2025-09 mass production開始。AI-server / industrial向けapplicationを別Factで開示 | `S3-EVR-063`、`064` | AI-server allocation又はActual demandではない |
| Super Junction MOSFET | R60xxXNx / R60xxWNx seriesは2026-06から順次mass production。AI-server / Data Center用途例を別Factで開示 | `S3-EVR-070`、`071` | 用途別production又はadoptionではない |
| SiC | 5th Generation SiC MOSFET development完了、sample Plan、AI-server / Data Center用途例を分離 | `S3-EVR-066`–`068` | Sample、mass production又はadoption Actualへ統合しない |
| GaN | 150V GaN technology、sample Plan、Data Center用途例を分離 | `S3-EVR-079`、`080`、`088` | Technology developmentをcommercial demandへ変換しない |
| GaN | GNE10xxTB seriesのproduction commencementとData Center用途例を分離 | `S3-EVR-091`、`092` | 用途別production、shipment又はrevenueではない |
| GaN | 650V GaN HEMT mass productionとserver用途を分離 | `S3-EVR-084`、`085` | ServerをAI server / Data Center単独としない |
| Gate driver | BM6GD11BFJ-LBのavailabilityとserver power-supply用途を分離 | `S3-EVR-076`、`077` | Adoption又はActual demandではない |
| Optical module | AI server marketを見据えたdevelopment / sales方針 | `S3-EVR-056` | Power semiconductor demand又はcommercial adoptionではない |

## 5. Fact — Product Stage、Supply及びPlan

| Evidence group | Stage | 確認できる範囲 | 確認できない範囲 |
| --- | --- | --- | --- |
| `S3-EVR-059` | Plan | AI-server hot-swap向けMOSFETを2025年中に順次mass production開始する計画 | 後続Actualとの自動同一化、数量、顧客、売上 |
| `S3-EVR-065` | Decision / Plan | TSMC GaN technology移管とin-group production-system構築を決定し、2027 establishmentを目指す | 移管完了、capacity、AI-server allocation |
| `S3-EVR-066`–`068` | Development Actual / sample Plan / application | 5th Generation SiCのdevelopment、sample計画、用途例 | Mass production、採用、売上 |
| `S3-EVR-070`–`071` | Production Actual / application | Super Junction MOSFETのproduction commencementと用途例 | 用途別数量、顧客、売上 |
| `S3-EVR-073` | Product-development Plan | AI data-server向けcoverage拡大のため新製品planning / developmentを加速する方針 | Development completion、availability、adoption又はActual sales。`S3-EVR-087`のSAM illustrationと同義化しない |
| `S3-EVR-079`–`080` | Development Actual / sample Plan | 150V GaN technologyとsample計画 | Shipment Actual又はcommercial result |
| `S3-EVR-082` / `091` | System statement / product commencement | 2022-03の150V GaN production transitionを異なるSource Event / Fact grainで説明 | 二度のproduction進展、独立需要signal又は確度加算として数えない |
| `S3-EVR-090` | Product-family expansion Plan | 150V EcoGaN lineupをbase-station / Data Center等のpower circuitへ拡大する見通し | Current availability、adoption、Data Center専用production、shipment又はActual demand。`081` partnership、`082` system Actual、`083` 600V joint Planと同義化しない |

Product availability、sample Plan、mass-production Plan、production commencement及びapplication positioningは相互に置換しない。

## 6. Fact — 確認できたRelationship

### 6.1 Named-party relationship

| Party | Relationship Fact | Evidence | 境界 |
| --- | --- | --- | --- |
| Murata Power Solutions | EcoGaNが5.5kW AI-server PSUへ採用されたとのROHM発表 | `S3-EVR-057` | Order、shipment、revenue、exclusive supplyは未確認 |
| Murata Power Solutions | 当該PSUの2025 mass-production Plan | `S3-EVR-078` | Production commencement Actualではない |
| Murata Power Solutions | SiC SBD SCS308AHがData Center PSUへ採用されたとのROHM発表 | `S3-EVR-075` | 数量、売上又は全製品への採用は未確認 |
| Murata Power Solutions | Dr. Longcheng TanによるD1U PSU `now in mass production`との説明 | `S3-EVR-089` | ROHM shipment、start date、数量又は売上は未確認 |
| Delta Electronics | Next-generation GaN power devicesの共同development / mass productionに関するstrategic partnership | `S3-EVR-081` | 個別採用、order、revenue又はData Center専用relationではない |
| Delta Electronics | 600V GaN power devicesの共同development / mass-production Plan | `S3-EVR-083` | Development又はproduction completionではない |
| Ancora Semiconductors | GNP1070TC-Z / GNP1150TCA-Zのjoint-development relation | `S3-EVR-086` | Delta又はAncoraによるpurchase / adoptionではない |

### 6.2 Anonymous-party relationship

- SCT4013DLLがAI-server PSU向けBBUの±400V power sectionへ採用されたとの発行者発表がある。顧客identity、order、shipment、revenue及びproduction deploymentは未確認。根拠：`S3-EVR-069`。
- RY7P250BMについて、`major global cloud providers`によるendorsement assertionと、`a leading global cloud platform provider`によるrecommended-component assertionが別Source Eventで開示される。相手方の同一性又は相互corroborationを主張しない。根拠：`S3-EVR-061`、`072`。

### 6.3 確認できないDirect relation

確認済みEvidenceは、Microsoft又はAlphabetのinvestment、NVIDIAのsystem demand若しくはindustry-wide AI investmentから、ROHMのorder、shipment、revenue又はmarket shareへ至る定量的なDirect relationを示さない。

これは当該関係の不存在を証明しない。確認済みSource Setと調査cut-offに限定したNegative Evidenceである。

## 7. Cross-source Inference — Factではない

| Inference ID | Inference | 根拠Evidence | 制約 |
| --- | --- | --- | --- |
| ROHM-INF-001 | ROHMはAI server / Data Center向けに、Si、SiC、GaN、analog及び周辺ICを組み合わせる複数技術の供給候補として自社positioningを進めている。 | `S3-EVR-052`、`053`、`055`、`060`、`068`、`071`、`077`、`088`、`092` | Portfolio breadthの推論であり、採用率、競争優位、売上規模又はmarket shareではない |
| ROHM-INF-002 | 複数のnamed / anonymous relationshipとproduct-stage開示は、AI-server / Data Center用途でcommercializationに関係する事例が存在することを示唆する。 | `S3-EVR-057`、`069`、`072`、`075`、`078`、`089` | 全社的な需要拡大、継続受注又はcommercial magnitudeを証明しない |
| ROHM-INF-003 | Product development、production-system decision及びmass-production commencementの組合せは、将来需要への供給準備活動を示唆する。 | `S3-EVR-065`、`066`、`070`、`082`、`084`、`091` | Capacity、稼働率、用途別供給量、需要実現又は売上との因果を示さない。`082/091`を二重計上しない |

これらはResearch-level Inferenceであり、Evidence Register又はKnowledge CatalogへFactとして登録しない。

## 8. Research Question Disposition

| Research Question | Research-level answer | Evidence status |
| --- | --- | --- |
| `S3-DCAI-RQ-001` | ROHMはServer Business、Computer & Storage、AI server / AI data server、Data Center、800VDC及び各product applicationという複数Scopeを用いる。これらは同義ではない。 | Evidence supported; mixed-scope constraintあり |
| `S3-DCAI-RQ-004` | Si MOSFET、Super Junction MOSFET、SiC、GaN、gate driver及びtotal-solution strategyまで明示がある。Product stageとapplicationは個別に評価する必要がある。 | Evidence supported |
| `S3-DCAI-RQ-005` | Murata、Delta、Ancora及び匿名partyとのrelationship Factはあるが、hyperscaler investmentからROHM salesへの定量的Direct relationは確認できない。 | Partial support + bounded Negative Evidence |
| `S3-DCAI-RQ-006` | Actual、Forecast、Target、Plan、Scenario、application、product stage及びissuer assertionが混在し、単純な時系列又は横断比較は不可。 | Evidence supported; comparability controls required |
| `S3-DCAI-RQ-007` | 将来観測候補はServer Business、用途Scope、product stage、named relationship及びsupply-system progress。ただし利用可能性と取得仕様は未決定。 | Candidate observations only; no downstream use |

## 9. Candidate Observations — 未採用

| Candidate Observation | Evidence basis | 現在の状態 | 採用前に必要な確認 |
| --- | --- | --- | --- |
| Server Business sales | `S3-EVR-050`、`051` | ActualとTargetsを分離済み | 定義継続性、対象製品、更新頻度、AvailableAt authority |
| Computer / Storage SiC sales outlook | `S3-EVR-047` | Forecast | Base amount、AI-only比率、後続Actualとの対応 |
| Computer & Storage application share | `S3-EVR-054` | Mixed-scope Actual share | 分母定義、用途分類継続性、金額化禁止の維持 |
| Product-stage transition | `S3-EVR-058`–`059`、`062`–`064`、`066`–`068`、`070`–`071`、`073`、`076`–`077`、`079`–`080`、`082`、`084`–`085`、`088`、`090`–`092` | Event-level facts / Plans / application positioning | 同一product identity、stage vocabulary、Fact type、重複Event処理。Architecture、relationship又はSAM illustrationを混入しない |
| Named-party adoption / production statement | `S3-EVR-057`、`075`、`078`、`089` | Relationship / Plan / production-stage assertion | Counterparty、製品、stage、数量・売上非開示の保持 |
| Supply-system progress | `S3-EVR-065` | Decision / Plan | 2027後続Actual、capacity定義、用途別配賦禁止 |

この表はObservation採用、特徴量設計又は利用可能性を決定しない。

## 10. Open Questions and Gaps

- `ROHM-SFI-008`：hyperscaler CAPEX chartのsource-by-source provenance。
- `ROHM-SFI-012`、`020`–`022`、`024`–`025`：dynamic pageのcut-off exact-content identity。
- `ROHM-SFI-014`：topology / simulation method固有の条件。
- `ROHM-SFI-017`、`023`：Forecast definition / provenance。
- `ROHM-SFI-044`：prior Targetと後続Actual / Targetのdefinition・numeric reconciliation。
- AI server / Data Center単独のActual sales、customer quantities、ROHM shipment、revenue及びmarket share。
- Hyperscaler investment又はNVIDIA demandからROHM businessへ至る定量的なDirect relation。
- Publication time / timezoneと`AvailableAt` authority。

## 11. Update Triggers

- ROHMの通期・半期・四半期決算及びIntegrated Report更新。
- Server Business、Computer & Storage又はAI server用途定義の変更。
- FY2026 / FY2028 / FY2030 Targetに対するActual又はTarget revision。
- 2027 GaN in-group production-systemの進捗開示。
- Product sample、mass-production Plan又はapplicationから後続Actualへの遷移。
- Named customer、order、shipment、revenue又は用途別salesの追加開示。
- Hold候補のprovenance、method、version identity又はdefinition解消。

## 12. Completion and Downstream Boundary

ROHMのCompany-level Evidence acquisitionは独立レビュー済みGateにより完了している。本文書は、そのEvidenceを企業単位で統合した最初のResearch Draftである。

本文書は、著者から独立したEvidence、Knowledge及びTraceability ReviewでAcceptedとなった。Review Accepted後もDraft / noncanonical、`AvailableAt = TBD — no use`及びCatalog Eligibility `No`を維持する。

Definition and Comparability Matrix、Industry Report、Infineon research及びSprint003 Phase 1 Closureは別成果物であり、本文書の完成だけでは開始済み又は完了とみなさない。
