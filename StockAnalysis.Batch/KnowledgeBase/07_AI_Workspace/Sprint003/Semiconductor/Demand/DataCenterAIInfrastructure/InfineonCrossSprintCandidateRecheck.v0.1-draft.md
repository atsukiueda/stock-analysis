# Infineon Technologies — Cross-sprint Candidate Recheck

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft candidate-level cross-sprint traceability record |
| Sprint | Sprint003 |
| 対象企業 | Infineon Technologies AG |
| Version | 0.1-draft |
| 確認日 | 2026-08-09 |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Reviewer Status | Evidence / Knowledge / Traceability — Accepted |
| Related Review Record | `InfineonCrossSprintCandidateRecheckIndependentReview.v0.1-draft.md` |
| 上流Inspection | `InfineonSourceFactInspection.v0.1-draft.md` — Accepted |
| 上流Bridge | `Sprint003DataCenterAIInfrastructureCrossSprintBridge.v0.1-draft.md` — Stage 0 Accepted |
| Evidence / PIT ID | None — Local candidate recheck only |

> **利用境界：** 本記録はRaw Evidence作成前の重複・参照確認である。限定した検索対象でmatchがないことは、Repository全体又は外部に同一資料・同一Factが存在しないことの証明ではない。Evidence採用、ID発行、`AvailableAt`確定、Catalog / DDL / ML利用を許可しない。

## 1. Examined Sets and Method

### 1.1 Stage 0 Fixed Examined Set

`Sprint003DataCenterAIInfrastructureCrossSprintBridge.v0.1-draft.md` §1.1で固定され、Stage 0独立レビューAcceptedとなった11 artifactを確認した。対象はSprint001 / Sprint002のEvidence Register、PIT、Industry Report、Evidence Acquisition関連文書及びRenesas / ROHM Company Researchである。

Infineonについて上流Bridgeは次の既存matchを固定している。

- `CSB-INF-001`：Sprint001 `EVR-004`。Infineon *Annual Report 2025*のFY2025 Automotive segment revenue。

上流Inspectionの`IFX-SFI-001`は上記Evidenceの参照専用であり、本RecheckのRaw eligibility対象へ含めない。Automotive segment FactをAI Data Center又はPSSへ用途配賦しない。同じAnnual Reportの別Source position・別Factだけを新規候補として扱う。

### 1.2 Additional Read-only Search Set

| Scope | Search content |
| --- | --- |
| Sprint001 | `KnowledgeBase/07_AI_Workspace/Sprint001/Semiconductor/Demand/Automotive`配下のDraft `.md` |
| Sprint002 | `KnowledgeBase/07_AI_Workspace/Sprint002/Semiconductor/Demand/IndustrialPower`配下のDraft `.md` |
| Legacy Research | `KnowledgeBase/01_Research`配下の既存`.md` |

追加集合は安全側に確認したread-only範囲であり、Stage 0 Accepted scopeを変更又は再承認しない。

検索語は、`Infineon`、`インフィニオン`、`Annual Report 2025`、`AI data center`、`AI server`、`PSS`、`EUR 700m`、`EUR 1.5bn`、`EUR 2.5bn`、`800 V HVDC`、`NVIDIA`、`XDP710`、`Sapphire Rapids`、`Power Roadshow`、`USD 175`、`18 kW`、`30 kW`、`3.3 kW`及び`12 kW`を含むissuer・Source Event・position・Fact固有語である。Literal case-insensitive検索を行い、issuer、Source identity / event、Source position及びFact grainを組み合わせて判定した。

Stage 0で固定済みの`EVR-004`以外に、Raw対象40候補と同一のSource identity / position / Factへ解決するResearch Assetは確認できなかった。一般語の一致、同一issuer、同一文書又は同一pageだけでは同一Factと判定していない。このno-matchは上記集合を2026-08-09に確認した結果に限定する。

## 2. Candidate-level Recheck

| Local ID | Source Event / Position family | Existing cross-sprint match | Related candidate / Fact-grain boundary | Raw Evidence eligibility and required treatment |
| --- | --- | --- | --- | --- |
| `IFX-SFI-002` | Annual Report 2025 p.50 / p.8、FY2024→FY2025 AI power revenue Actual | 同じAnnual ReportのAutomotive Factのみ。該当Factなし | `003` / `024` / `025` / `037` / `038`のForecast / Targetと非同義 | **Eligible with caution.** FY2024約EUR250m→FY2025 EUR700m超及びnearly tripledをSource-presented Actualとして保持し、definition未確認の将来系列へ連結しない。 |
| `IFX-SFI-003` | Annual Report 2025 p.8、FY2026 revenue Forecast | 同一Factなし | `012` passageのFY2026 EUR1.5bn再確認はcorroborationのみ。FY2027 indicationと分離 | **Eligible with caution.** 約EUR1.5bn Forecastとして保持し、再確認を別signal又は確度加算にしない。 |
| `IFX-SFI-004` | Annual Report 2025 p.8、end-of-decade SAM sizing | 同一Factなし | `042`によりmeasurement basisがreplaced。`016`のper-kW contentとも別Fact | **Eligible with caution.** EUR8bn–12bnをsuperseded historical issuer Forecastとして保持し、Current Forecast又はmarket shareへ変換しない。 |
| `IFX-SFI-005` | 2025-05-20 release / Annual Report p.8、NVIDIA joint development | 同一Factなし | `029`は同一relationshipのcorroborating Source Event。`030`はarchitecture definition | **Eligible.** `005`を唯一のFact ownerとし、`029`用の別Raw / EVR / PIT、独立signal又は確度加算を禁止する。 |
| `IFX-SFI-006` | Annual Report p.68、PSS FY2026 outlook | 同一Factなし | `007` investment、`008` Actual及びAI単独revenueと分離 | **Eligible with caution.** Mixed-segment Forecastとして保持し、AI contribution amountを作らない。 |
| `IFX-SFI-007` | Annual Report p.68、issuer investment Plan / mixed cash-flow context | 同一Factなし | PSS outlook及びQ2 capacity actionとはSource Event / scopeが異なる | **Eligible with caution.** FY2026 Free Cash Flow Forecastに含まれるinvestment Planとして保持し、total investmentをAI、site、technology、wafer又はproductへ配賦しない。 |
| `IFX-SFI-008` | Q2 FY2026 p.4、PSS segment Actual | 同一Factなし | `009` driver narrativeと別Fact | **Eligible with caution.** EUR1.260bn、EUR257m、20.4%をPSS Actualとして保持し、AI単独へ配賦しない。 |
| `IFX-SFI-009` | Q2 FY2026 p.4、PSS growth driver narrative | 同一Factなし | `008`のsegment Actual、AI / radarの個別寄与と分離 | **Eligible with caution.** Mixed driver narrativeとして保持し、寄与額・比率・因果shareを作らない。 |
| `IFX-SFI-010` | Q2 FY2026 p.4、AI allocation condition | 同一Factなし | `011` capacity action及び`041` demand / supply assertionと同一eventだが別Fact | **Eligible with caution.** Product、customer、quantity、duration、backlogを補完しない。 |
| `IFX-SFI-011` | Q2 FY2026 p.3、capacity redeployment | 同一Factなし | `010` / `041`と分離。Automotive source businessを保持 | **Eligible with caution.** High-voltage drivetrain frontend capacityからAI data-centerへのactionとして保持し、amount、site、technology又はcompletionを作らない。 |
| `IFX-SFI-012` | Q2 FY2026 p.4、FY2027 indication | 同一Factなし | 同じpassageのFY2026再確認は`003`のcorroborationのみ | **Eligible with caution.** EUR2.5bn indication only。Guidance / Target / Actualへ同義化しない。 |
| `IFX-SFI-013` | Q2 FY2026 pp.4–5、GaN shipment assertion | 同一Factなし | `014` design-in pipelineと別Fact | **Eligible with caution.** AI data-center applications向けGaNのshipmentsがselected power-supply socketsで増加しているというunquantified assertionとして保持する。Product、customer、quantity、revenue又はmarket shareを補完しない。 |
| `IFX-SFI-014` | Q2 FY2026 pp.4–5、GaN design-in pipeline | 同一Factなし | `013` shipment Factと分離 | **Eligible with caution.** Design-in pipelineが複数power-conversion stagesへ拡大しているという方向を保持し、design win、order、shipment又はrevenueへ変換しない。 |
| `IFX-SFI-015` | Q2 FY2026 p.5、SiC mixed growth assertion | 同一Factなし | AI単独Factではない | **Eligible with caution.** AI-related demandがFY2026 overall SiC businessのlow-double-digit growthを牽引するとのstatementとして保持し、AI contribution、base amount又はapplication mixを算出しない。 |
| `IFX-SFI-016` | Q2 FY2026 p.5、per-kW content estimate | 同一Factなし | `022` rack scenario、`026` rack BOM、`036` server BOMとdenominatorが異なる。`042`のnew measurement unit | **Eligible with caution.** USD100–250/kW・平均約USD175/kWをissuer estimateとして保持し、denominator間変換をしない。 |
| `IFX-SFI-017` | Q1 FY2026 p.59、grid-to-core definition | 同一Factなし | `021`はより広いvalue-chain taxonomy、`019`はHV / MV IBC scope | **Eligible.** Issuer architecture / portfolio definitionに限定する。 |
| `IFX-SFI-018` | Q1 FY2026 p.60、3.3 / 8 / 12 kW availability | 同一Factなし | `043` future three-phase roadmap、`027` / `044` historical stagesと分離 | **Eligible with caution.** 2026-02-04時点のavailable-now Actualとして保持し、volume / adoptionへ変換しない。 |
| `IFX-SFI-019` | Q1 FY2026 p.61、HV / MV IBC scope | 同一Factなし | `017` / `021`とtaxonomy grainが異なる | **Eligible.** Current / future portfolio positioningに限定し、availability又はdesign winにしない。 |
| `IFX-SFI-020` | Q1 FY2026 p.63、vertical power delivery illustration | 同一Factなし | Product availability / adoptionとは別 | **Eligible with caution.** 追加10–15% PDN loss reductionをinternal estimateとして保持する。 |
| `IFX-SFI-021` | 2025 Power Roadshow p.4、value-chain taxonomy | 同一Factなし | `017`より広いGrid / Rack / Core / Physical AI scope | **Eligible.** Issuer taxonomyに限定し、各productのavailability / revenueを作らない。 |
| `IFX-SFI-022` | 2025 Power Roadshow p.11、rack / content scenario | 同一Factなし | `016` / `026` / `036`とdenominator・eventが異なる | **Eligible with caution.** Todayは約125kW / rack・Infineon content約USD15k、2027+は約600kW+、2029+は1MW超 / rack・content USD100k超という期間対応をscenarioとして保持する。Fleet average、installed base、shipment又はrevenue Forecastにしない。 |
| `IFX-SFI-024` | Q4 FY2024 p.47、FY2025 Forecast | 同一Factなし | `002` later Actual、`025` Targetと非同義 | **Eligible with caution.** EUR500m超をhistorical Forecastとして保持し、Actualとのaccuracy評価前にseries化しない。 |
| `IFX-SFI-025` | Q4 FY2024 p.47、two-year Target | 同一Factなし | `003` Forecast / `012` indicationとdefinition・期限が異なる | **Eligible with caution.** EUR1bn TargetをTargetのまま保持する。 |
| `IFX-SFI-026` | Q4 FY2024 p.49、rack BOM estimate | 同一Factなし | `016` per-kW、`022` roadmap scenario、`036` per-serverと別denominator | **Eligible with caution.** USD12k–15k/rackをconfiguration-dependent estimateとして保持する。 |
| `IFX-SFI-027` | Q4 FY2024 p.50 / 2024-05-24 release、current products | 同一Factなし | `044` future roadmap及び`018` later availabilityと分離 | **Eligible.** 2024 Source Event時点の3 / 3.3 kW availability Actualとして保持する。 |
| `IFX-SFI-028` | 2024-05-24 release、issuer product-performance assertion / Plan | 同一Factなし | `027` availability及び`044` roadmapと別Fact | **Eligible with caution.** New-generation PSUの97.5% efficiency、8 kW PSUの300 kW超AI rack support及び100 W/in³ power densityを、製品・条件対応を維持したissuer assertion / Planとして保持する。Third-party benchmark、deployment又はall-load efficiencyにしない。 |
| `IFX-SFI-030` | 2025-05-20 release、800 V HVDC architecture | 同一Factなし | `005` relationship、`029` corroborating eventと別Fact | **Eligible.** Future architecture definitionに限定し、deployment / procurementへ変換しない。 |
| `IFX-SFI-031` | 2026-06-02 news、18 / 30 kW solution introduction | 同一Factなし | `032` performance、`033` availability Plan及び`043` prior roadmapと分離 | **Eligible.** 50 V rack向け18 kW three-phase PSU reference designと、800 VDC / ±400 VDC sidecar向け30 kW PFC evaluation boardの製品・board type対応を保持する。 |
| `IFX-SFI-032` | 2026-06-02 news、performance assertions | 同一Factなし | `031` / `033`と別grain | **Eligible with caution.** 18 kW designは97.5% peak efficiency、30 kW boardは99%超peak efficiencyという一対一対応をtest-condition-dependent assertionとして保持する。 |
| `IFX-SFI-033` | 2026-06-02 news、evaluation availability Plan | 同一Factなし | `031` introduction、`032` performanceと分離 | **Eligible with caution.** `soon available` Planとして保持し、availability Actualにしない。 |
| `IFX-SFI-034` | 2022-03-31 news、Intel Sapphire Rapids offering | 同一Factなし | `035` NVIDIA speaker assertionとplatform / eventが異なる | **Eligible.** Named-platform offering launch / availabilityに限定し、Intel procurementを確定しない。 |
| `IFX-SFI-035` | 2022-11-14 news、NVIDIA speaker assertion | 同一Factなし | `005` NVIDIA joint-development relationとSource Event / product / relation grainが異なる | **Eligible with caution.** Speaker attributionを保持し、purchase、production adoption又はexclusive design winにしない。 |
| `IFX-SFI-036` | 2023 Power Roadshow p.7、per-server BOM | 同一Factなし | `016` / `022` / `026`とdenominatorが異なる | **Eligible with caution.** USD850–1,800/serverをissuer estimateとして保持する。 |
| `IFX-SFI-037` | 2023 Power Roadshow p.11、FY2024 Forecast | 同一Factなし | `024` later Forecast、`002` Actual及び`038` CAGRと分離 | **Eligible with caution.** Low triple-digit EUR million Forecastとして保持し、definition確認なしにseries化しない。 |
| `IFX-SFI-038` | 2023 Power Roadshow p.11、FY2024–FY2029 CAGR Forecast | 同一Factなし | `037` amount Forecastと別Fact | **Eligible with caution.** CAGR 50%超をForecastとして保持し、base / endpoint amountを補完しない。 |
| `IFX-SFI-039` | 2023 Power Roadshow p.11、anonymous design-win assertion | 同一Factなし | `035` named speaker、`005` named development relationと非同義 | **Eligible with caution.** Anonymous counterparties、product、stage、date、order及びrevenueを未確定のまま保持する。 |
| `IFX-SFI-041` | Q2 FY2026 p.3、demand / supply condition | 同一Factなし | `010` allocation及び`011` capacity actionと別Fact | **Eligible with caution.** Demand strongly exceeds supplyというunquantified assertionに限定する。 |
| `IFX-SFI-042` | Q2 FY2026 p.5、measurement-basis replacement | 同一Factなし | `004` historical SAM、`016` content estimateと接続するが別Fact | **Eligible.** Method changeとして保持し、新absolute market Forecast又はgrowth seriesを作らない。 |
| `IFX-SFI-043` | Q1 FY2026 p.60、future three-phase roadmap | 同一Factなし | `018` available-now、`031` later introductionとstageが異なる | **Eligible with caution.** 16+ kWは`Ref. Board Q2 26`、27 kWは`Ref. Board Q3 26`、30 kWは`Topology Eval. Board Q2 26`として、board typeとtimingを製品別に保持する。Availability Actual、mass production、shipment又はrevenueへ変換しない。 |
| `IFX-SFI-044` | Q4 FY2024 p.50 / 2024-05-24 release、historical roadmap | 同一Factなし | `027` current products及び`018` later availabilityと分離 | **Eligible with caution.** Q4 FY2024 slideに基づき8 kW=`Available in Q1/25`、12 kW=`Available in Q2/25`、12 kW超=`Available in 26`を2024時点のPlanとして保持する。2024-05-24 releaseは8 kW Q1 2025だけのcorroborating Source Eventとし、12 kW又は12 kW超のtiming根拠へ拡張しない。 |

InspectionでHoldとなった`IFX-SFI-023`及び`040`はRaw eligibility対象外である。No-matchを理由にHoldを解除しない。Reference-onlyの`001`は再発行しない。Duplicate / corroborating Source Eventの`029`も別Rawへ進めず、`005`のSource provenanceとしてだけ保持する。

## 3. Reconciliation Rules for Raw Evidence

- Reference-only `001`はSprint001 `EVR-004`を参照し、S3 Raw / EVR / PITを作成しない。
- `005`をNVIDIA 800 V HVDC joint-development relationの唯一のFact ownerとし、`029`はcorroborating Source Eventに限定する。別Raw、二度のrelationship進展、独立signal又は確度加算を禁止する。
- `003`のFY2026 Forecastと`012`のFY2027 indicationを別Rawへ一対一化する。Q2で再確認されたFY2026 EUR1.5bnは`003`のprovenanceとして保持し、別Factにしない。
- `002` Actual、`003` / `024` / `037` Forecast、`012` indication、`025` Target及び`038` CAGR Forecastを相互に置換又は未確認definitionのまま単一時系列へ統合しない。
- `004`のhistorical SAM、`016`のper-kW content及び`042`のmeasurement-basis replacementを分離し、旧新measureから成長率又はmarket shareを作らない。
- `008` / `009`、`010` / `011` / `041`、`013` / `014`、`031` / `032` / `033`は同一Source Event内でもFact grain別のRawへ一対一化する。
- `017` / `019` / `021`のarchitecture / portfolio / value-chain taxonomyを一つのuniversal architectureへ統合しない。
- `018` / `043`及び`027` / `044`はavailability Actualとfuture roadmap Planを分離する。2026-06-02の`031`–`033`へ接続する場合も、後続eventを過去時点のActualへ遡及しない。
- `016` / `022` / `026` / `036`はper-kW、rack scenario、rack BOM及びserver BOMのdenominator / configurationが異なる。相互変換又は同一series化を禁止する。
- `005` / `035` / `039`はnamed development relation、named external-speaker assertion及びanonymous design-win assertionであり、同じNVIDIA / compute contextを理由に一つのcommercial relationへ統合しない。
- Actual、Plan、Forecast、Target、indication、estimate、scenario、relationship、application definition及びmanagement assertionを相互に置換しない。
- PSS、Automotive、SiC及びmixed investment / fab contextをAI server又はData Center単独値へ用途配賦しない。
- InspectionのHold及びExcluded transformationをRaw Evidenceへ混入させない。

## 4. Preliminary Disposition

| Result | Count | Treatment |
| --- | ---: | --- |
| Existing Evidence reference only | 1 | `IFX-SFI-001`; Sprint001 Evidence参照、S3再発行なし |
| Duplicate / corroborating Source Event | 1 | `IFX-SFI-029`; `005`のprovenanceとして保持し、別Rawなし |
| No identical cross-sprint match / Raw eligible | 9 | `005`、`017`、`019`、`021`、`027`、`030`、`031`、`034`、`042` |
| No identical cross-sprint match / Raw eligible with caution | 31 | `002`–`004`、`006`–`016`、`018`、`020`、`022`、`024`–`026`、`028`、`032`–`033`、`035`–`039`、`041`、`043`–`044` |
| Hold / outside recheck eligibility | 2 | `023`、`040`; Raw Evidence化しない |
| **Total candidates** | **44** | Reference 1 + Duplicate 1 + Raw eligible 40 + Hold 2 |

## 5. Gate Status and Next Gate

| Gate | Status | Record / Next action |
| --- | --- | --- |
| Candidate-level Cross-sprint recheck | Completed — Accepted | `InfineonCrossSprintCandidateRecheckIndependentReview.v0.1-draft.md` |
| Raw Evidence | Not created | Recheck Accepted後、40 unique Factを一候補一Rawで作成 |
| EVR ID / registration | Not issued / not registered | Raw review Accepted後、EVR行作成時に発行 |
| PIT ID / registration | Not issued / not registered | EVR review Accepted後、一対一PIT行作成時に発行 |
| AvailableAt / Catalog | Not permitted | `TBD — no use` / `No` |
