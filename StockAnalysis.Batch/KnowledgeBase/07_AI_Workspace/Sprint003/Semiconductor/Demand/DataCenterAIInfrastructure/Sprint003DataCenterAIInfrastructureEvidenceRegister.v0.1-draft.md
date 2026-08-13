# Sprint003 Data Center / AI Infrastructure — Evidence Register

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft evidence register |
| Sprint | Sprint003 |
| Version | 0.1-draft |
| 作成日 | 2026-08-02 |
| 状態 | Draft — Microsoft `S3-EVR-001`–`009`, Alphabet `S3-EVR-010`–`020`, NVIDIA `S3-EVR-021`–`032`, Renesas `S3-EVR-033`–`045`, ROHM `S3-EVR-046`–`092` and Infineon `S3-EVR-093`–`132` EVR Review Accepted; noncanonical |
| Authority Source | `Sprint003EvidenceNamespaceDecisionRecord.v0.1-draft.md` |
| 識別子namespace | `S3-EVR-###`（Sprint003内のDraftローカル識別子） |
| Related Raw Reviews | `MicrosoftRawEvidenceIndependentReview.v0.1-draft.md`; `AlphabetRawEvidenceIndependentReview.v0.1-draft.md`; `NVIDIARawEvidenceIndependentReview.v0.1-draft.md`; `RenesasRawEvidenceIndependentReview.v0.1-draft.md`; `ROHMRawEvidenceIndependentReview.v0.1-draft.md`; `InfineonRawEvidenceIndependentReview.v0.1-draft.md` — Accepted |
| EVR Review Records | Microsoft: `Sprint003MicrosoftEvidenceRegisterIndependentReview.v0.1-draft.md`; Alphabet: `Sprint003AlphabetEvidenceRegisterIndependentReview.v0.1-draft.md`; NVIDIA: `Sprint003NVIDIAEvidenceRegisterIndependentReview.v0.1-draft.md`; Renesas: `Sprint003RenesasEvidenceRegisterIndependentReview.v0.1-draft.md`; ROHM: `Sprint003ROHMEvidenceRegisterIndependentReview.v0.1-draft.md`; Infineon: `Sprint003InfineonEvidenceRegisterIndependentReview.v0.1-draft.md` — Accepted |
| Related PIT Record | `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` — Microsoft `S3-PIT-001`–`009`, Alphabet `S3-PIT-010`–`020`, NVIDIA `S3-PIT-021`–`032`, Renesas `S3-PIT-033`–`045`, ROHM `S3-PIT-046`–`092` and Infineon `S3-PIT-093`–`132` Accepted |

> **権限境界：** 本Registerは、Project Directorが承認したSprint003のDraft証跡台帳である。Canonical Identifier Registry、Knowledge Catalog、DDL又は下流利用の台帳ではない。登録はEvidenceのCanonical化、Catalog採用、`AvailableAt`確定又は投資判断への利用を意味しない。

## 1. 登録原則

- 一つのEvidence IDは、一つの公式出典に明示された一つのSource Fact群へ対応する。
- Raw Evidenceで独立レビューAcceptedとなった内容と境界を短縮・拡張・再解釈せず登録する。
- 公式Source Fact、発行者の説明、算術計算、推論を混同しない。
- Publication Eventから`AvailableAt`を導出しない。全件を`TBD — no use`とする。
- Catalog Eligibilityは全件`No`とし、Catalog、DDL、Entity、Database、ML、バックテスト、Decision Engine、Advisor及び投資利用を禁止する。
- PIT IDは、EVR独立レビュー後に一対一のPIT行を作成する時点で発行する。

## 2. 登録一覧

| Evidence ID | 発行者 | Evidence概要 | Raw Evidence | Raw Review | EVR Review | PIT Mapping | AvailableAt | Catalog Eligibility |
| --- | --- | --- | --- | --- | --- | --- | --- | --- |
| `S3-EVR-001` | Microsoft Corporation | Data Center AI需要とserver供給依存 | `MSFT_DataCenterAIDemandServerDependencyRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-001` — Accepted | `TBD — no use` | No |
| `S3-EVR-002` | Microsoft Corporation | FY2023–FY2025 Property and Equipment additions | `MSFT_PropertyEquipmentAdditionsFY2023FY2025RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-002` — Accepted | `TBD — no use` | No |
| `S3-EVR-003` | Microsoft Corporation | FY2025、主としてData Center関連のconstruction commitments | `MSFT_DataCenterConstructionCommitmentsFY2025RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-003` — Accepted | `TBD — no use` | No |
| `S3-EVR-004` | Microsoft Corporation | FY2025、主としてData Center関連のpurchase commitments | `MSFT_DataCenterPurchaseCommitmentsFY2025RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-004` — Accepted | `TBD — no use` | No |
| `S3-EVR-005` | Microsoft Corporation | FY2025 Cloud / AI Infrastructure capital plan | `MSFT_CloudAIInfrastructureCapitalPlanFY2025RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-005` — Accepted | `TBD — no use` | No |
| `S3-EVR-006` | Microsoft Corporation | FY2026 Q3 Property and Equipment additions | `MSFT_PropertyEquipmentAdditionsFY2026Q3RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-006` — Accepted | `TBD — no use` | No |
| `S3-EVR-007` | Microsoft Corporation | FY2026 Q3 AI Infrastructure、margin及びcompute capacity説明 | `MSFT_AIInfrastructureMarginComputeCapacityFY2026Q3RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-007` — Accepted | `TBD — no use` | No |
| `S3-EVR-008` | Microsoft Corporation | FY2026 Q3 Microsoft Cloud / Azure需要context | `MSFT_CloudDemandMetricsFY2026Q3RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-008` — Accepted | `TBD — no use` | No |
| `S3-EVR-009` | Microsoft Corporation | FY2024 Cloud / AI services需要とinfrastructure投資の説明 | `MSFT_CloudAIInfrastructureDemandCapexFY2024RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-009` — Accepted | `TBD — no use` | No |
| `S3-EVR-010` | Alphabet Inc. | AI-optimized infrastructureとGPU / TPU options | `ALPH_AIOptimizedInfrastructureAcceleratorsRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-010` — Accepted | `TBD — no use` | No |
| `S3-EVR-011` | Alphabet Inc. | FY2024–FY2025 Capital expenditures Actual | `ALPH_CapitalExpendituresFY2024FY2025RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-011` — Accepted | `TBD — no use` | No |
| `S3-EVR-012` | Alphabet Inc. | Technical infrastructure定義とconstruction lifecycle | `ALPH_TechnicalInfrastructureConstructionLifecycleRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-012` — Accepted | `TBD — no use` | No |
| `S3-EVR-013` | Alphabet Inc. | FY2024–FY2025 Technical infrastructure gross in-service assets | `ALPH_TechnicalInfrastructureGrossInServiceAssetsFY2024FY2025RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-013` — Accepted | `TBD — no use` | No |
| `S3-EVR-014` | Alphabet Inc. | FY2025 Purchase commitments and other contractual obligations | `ALPH_PurchaseCommitmentsFY2025RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-014` — Accepted | `TBD — no use` | No |
| `S3-EVR-015` | Alphabet Inc. | Specialized AI chip supply risk | `ALPH_SpecializedAIChipSupplyRiskRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-015` — Accepted | `TBD — no use` | No |
| `S3-EVR-016` | Alphabet Inc. | FY2026 Technical infrastructure investment Plan | `ALPH_TechnicalInfrastructureInvestmentPlanFY2026RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-016` — Accepted | `TBD — no use` | No |
| `S3-EVR-017` | Alphabet Inc. | FY2025 CapEx composition management classification | `ALPH_CapExCompositionFY2025RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-017` — Accepted | `TBD — no use` | No |
| `S3-EVR-018` | Alphabet Inc. | FY2026 CapEx Forecast | `ALPH_CapExForecastFY2026RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-018` — Accepted | `TBD — no use` | No |
| `S3-EVR-019` | Alphabet Inc. | FY2025 Q4 Google Cloud backlog / AI demand context | `ALPH_GoogleCloudBacklogFY2025Q4RawEvidence.v0.1-draft.md` | Accepted with context boundary | Accepted | `S3-PIT-019` — Accepted | `TBD — no use` | No |
| `S3-EVR-020` | Alphabet Inc. | FY2025 Q4 capacity constraint / timing boundary | `ALPH_CapacityConstraintTimingFY2025Q4RawEvidence.v0.1-draft.md` | Accepted with context boundary | Accepted | `S3-PIT-020` — Accepted | `TBD — no use` | No |
| `S3-EVR-021` | NVIDIA Corporation | Data Center platform architecture definition | `NVDA_DataCenterPlatformArchitectureRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-021` — Accepted | `TBD — no use` | No |
| `S3-EVR-022` | NVIDIA Corporation | FY2024–FY2025及びQ4 FY2025 Data Center revenue Actual | `NVDA_DataCenterRevenueFY2025RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-022` — Accepted | `TBD — no use` | No |
| `S3-EVR-023` | NVIDIA Corporation | Q4 / FY2026 Data Center revenue Actual | `NVDA_DataCenterRevenueFY2026RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-023` — Accepted | `TBD — no use` | No |
| `S3-EVR-024` | NVIDIA Corporation | Q1 FY2027 Data Center及び旧sub-market revenue Actual | `NVDA_DataCenterRevenueQ1FY2027RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-024` — Accepted | `TBD — no use` | No |
| `S3-EVR-025` | NVIDIA Corporation | FY2027 Data Center reporting framework transition | `NVDA_DataCenterReportingFrameworkFY2027RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-025` — Accepted | `TBD — no use` | No |
| `S3-EVR-026` | NVIDIA Corporation | FY2026 Data Center revenue driver / Blackwell context | `NVDA_DataCenterRevenueDriversFY2026RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-026` — Accepted | `TBD — no use` | No |
| `S3-EVR-027` | NVIDIA Corporation | FY2026 consolidated inventory purchase / supply / capacity obligations | `NVDA_SupplyCapacityObligationsFY2026RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-027` — Accepted | `TBD — no use` | No |
| `S3-EVR-028` | NVIDIA Corporation | Data Center component constraint operating risk | `NVDA_DataCenterComponentConstraintRiskRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-028` — Accepted | `TBD — no use` | No |
| `S3-EVR-029` | NVIDIA Corporation | Q1 FY2026 H20 inventory / purchase-obligation charge | `NVDA_H20InventoryChargeFY2026RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-029` — Accepted | `TBD — no use` | No |
| `S3-EVR-030` | NVIDIA Corporation | FY2026 China Data Center compute market-access context | `NVDA_ChinaDataCenterMarketAccessFY2026RawEvidence.v0.1-draft.md` | Accepted with context boundary | Accepted | `S3-PIT-030` — Accepted | `TBD — no use` | No |
| `S3-EVR-031` | NVIDIA Corporation | Q2 FY2027 total-company revenue Forecast / China exclusion | `NVDA_RevenueOutlookQ2FY2027RawEvidence.v0.1-draft.md` | Accepted with context boundary | Accepted | `S3-PIT-031` — Accepted | `TBD — no use` | No |
| `S3-EVR-032` | NVIDIA Corporation | Data Center / energy / capital dependency and timing context | `NVDA_DataCenterEnergyCapitalDependencyRawEvidence.v0.1-draft.md` | Accepted with context boundary | Accepted | `S3-PIT-032` — Accepted | `TBD — no use` | No |
| `S3-EVR-033` | Renesas Electronics Corporation | 1Q 2026 front-end wafer-input utilization context | `REN_FrontEndUtilizationQ12026RawEvidence.v0.1-draft.md` | Accepted with mixed-product boundary | Accepted | `S3-PIT-033` — Accepted | `TBD — no use` | No |
| `S3-EVR-034` | Renesas Electronics Corporation | AI Infra & Compute definition / future `data center revenue` reporting | `REN_AIInfraComputeReportingDefinitionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-034` — Accepted | `TBD — no use` | No |
| `S3-EVR-035` | Renesas Electronics Corporation | AI infrastructure grid-to-core portfolio / phase labels | `REN_AIInfraGridToCorePortfolioRawEvidence.v0.1-draft.md` | Accepted with phase labels | Accepted | `S3-PIT-035` — Accepted | `TBD — no use` | No |
| `S3-EVR-036` | Renesas Electronics Corporation | AI infrastructure growth-driver relationships | `REN_AIInfraGrowthDriverRelationshipsRawEvidence.v0.1-draft.md` | Accepted with management-thesis boundary | Accepted | `S3-PIT-036` — Accepted | `TBD — no use` | No |
| `S3-EVR-037` | Renesas Electronics Corporation | Next-generation rack power scenario | `REN_NextGenerationRackPowerScenarioRawEvidence.v0.1-draft.md` | Accepted with scenario boundary | Accepted | `S3-PIT-037` — Accepted | `TBD — no use` | No |
| `S3-EVR-038` | Renesas Electronics Corporation | 800V GaN / MOSFET product and design-in assertion | `REN_800VGaNMOSFETDesignInRawEvidence.v0.1-draft.md` | Accepted with issuer-assertion boundary | Accepted | `S3-PIT-038` — Accepted | `TBD — no use` | No |
| `S3-EVR-039` | Renesas Electronics Corporation | Digital Power 2025-to-Mid-Term units / value illustration | `REN_DigitalPowerUnitsValueIllustrationRawEvidence.v0.1-draft.md` | Accepted with relative-illustration boundary | Accepted | `S3-PIT-039` — Accepted | `TBD — no use` | No |
| `S3-EVR-040` | Renesas Electronics Corporation | Memory Interface / MCU control opportunity context | `REN_MemoryControlOpportunityRawEvidence.v0.1-draft.md` | Accepted with management-thesis boundary | Accepted | `S3-PIT-040` — Accepted | `TBD — no use` | No |
| `S3-EVR-041` | Renesas Electronics Corporation | Hybrid manufacturing strategy | `REN_HybridManufacturingStrategyRawEvidence.v0.1-draft.md` | Accepted with strategy boundary | Accepted | `S3-PIT-041` — Accepted | `TBD — no use` | No |
| `S3-EVR-042` | Renesas Electronics Corporation | 800V AI data-center architecture response / product map | `REN_800VAIDataCenterArchitectureRawEvidence.v0.1-draft.md` | Accepted with procurement boundary | Accepted | `S3-PIT-042` — Accepted | `TBD — no use` | No |
| `S3-EVR-043` | Renesas Electronics Corporation | Q1 2026 decision-based capacity investment Plan | `REN_CapacityInvestmentPlanQ12026RawEvidence.v0.1-draft.md` | Accepted with Plan / non-allocation boundary | Accepted | `S3-PIT-043` — Accepted | `TBD — no use` | No |
| `S3-EVR-044` | Renesas Electronics Corporation | Anonymous customer AI board total power solution assertion | `REN_AnonymousCustomerAIBoardPowerSolutionRawEvidence.v0.1-draft.md` | Accepted with anonymous-customer boundary | Accepted | `S3-PIT-044` — Accepted | `TBD — no use` | No |
| `S3-EVR-045` | Renesas Electronics Corporation | Product-level relative ASP illustration | `REN_ProductRelativeASPIllustrationRawEvidence.v0.1-draft.md` | Accepted with relative-ASP boundary | Accepted | `S3-PIT-045` — Accepted | `TBD — no use` | No |
| `S3-EVR-046` | ROHM Co., Ltd. | AI Server Business Expansion Explanation | `ROHM_AIServerBusinessExpansionExplanationRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-046` — Accepted | `TBD — no use` | No |
| `S3-EVR-047` | ROHM Co., Ltd. | Computer / Storage SiC Sales Forecast | `ROHM_ComputerStorageSiCSalesForecastRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-047` — Accepted | `TBD — no use` | No |
| `S3-EVR-048` | ROHM Co., Ltd. | AI Server Addressable Demand Forecast | `ROHM_AIServerAddressableDemandForecastRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-048` — Accepted | `TBD — no use` | No |
| `S3-EVR-049` | ROHM Co., Ltd. | Next-Generation AI Server Architecture Scenario | `ROHM_NextGenerationAIServerArchitectureScenarioRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-049` — Accepted | `TBD — no use` | No |
| `S3-EVR-050` | ROHM Co., Ltd. | Server Business FY2025 Sales Actual | `ROHM_ServerBusinessFY2025SalesActualRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-050` — Accepted | `TBD — no use` | No |
| `S3-EVR-051` | ROHM Co., Ltd. | Server Business Sales Targets | `ROHM_ServerBusinessSalesTargetsRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-051` — Accepted | `TBD — no use` | No |
| `S3-EVR-052` | ROHM Co., Ltd. | 800VDC Architecture and Device Positioning | `ROHM_800VDCArchitectureDevicePositioningRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-052` — Accepted | `TBD — no use` | No |
| `S3-EVR-053` | ROHM Co., Ltd. | AI Server Total Solution Strategy | `ROHM_AIServerTotalSolutionStrategyRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-053` — Accepted | `TBD — no use` | No |
| `S3-EVR-054` | ROHM Co., Ltd. | Computer / Storage Application Share FY2024 | `ROHM_ComputerStorageApplicationShareFY2024RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-054` — Accepted | `TBD — no use` | No |
| `S3-EVR-055` | ROHM Co., Ltd. | AI Server Si MOSFET Strategy | `ROHM_AIServerSiMOSFETStrategyRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-055` — Accepted | `TBD — no use` | No |
| `S3-EVR-056` | ROHM Co., Ltd. | AI Server Optical Module Strategy | `ROHM_AIServerOpticalModuleStrategyRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-056` — Accepted | `TBD — no use` | No |
| `S3-EVR-057` | ROHM Co., Ltd. | Murata EcoGaN Adoption | `ROHM_MurataEcoGaNAdoptionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-057` — Accepted | `TBD — no use` | No |
| `S3-EVR-058` | ROHM Co., Ltd. | Enterprise / AI Server MOSFET Availability | `ROHM_EnterpriseAIServerMOSFETAvailabilityRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-058` — Accepted | `TBD — no use` | No |
| `S3-EVR-059` | ROHM Co., Ltd. | AI Server MOSFET Mass-Production Plan | `ROHM_AIServerMOSFETMassProductionPlanRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-059` — Accepted | `TBD — no use` | No |
| `S3-EVR-060` | ROHM Co., Ltd. | NVIDIA 800V Architecture Response | `ROHM_NVIDIA800VArchitectureResponseRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-060` — Accepted | `TBD — no use` | No |
| `S3-EVR-061` | ROHM Co., Ltd. | Anonymous Cloud Provider Endorsement | `ROHM_AnonymousCloudProviderEndorsementRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-061` — Accepted | `TBD — no use` | No |
| `S3-EVR-062` | ROHM Co., Ltd. | RY7P250BM Market Release | `ROHM_RY7P250BMMarketReleaseRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-062` — Accepted | `TBD — no use` | No |
| `S3-EVR-063` | ROHM Co., Ltd. | RS7P200BM Mass-Production | `ROHM_RS7P200BMMassProductionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-063` — Accepted | `TBD — no use` | No |
| `S3-EVR-064` | ROHM Co., Ltd. | RS7P200BM Application | `ROHM_RS7P200BMApplicationRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-064` — Accepted | `TBD — no use` | No |
| `S3-EVR-065` | ROHM Co., Ltd. | GaN Supply-System Decision and Plan | `ROHM_GaNSupplySystemDecisionPlanRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-065` — Accepted | `TBD — no use` | No |
| `S3-EVR-066` | ROHM Co., Ltd. | Fifth-Generation SiC Development | `ROHM_FifthGenerationSiCDevelopmentRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-066` — Accepted | `TBD — no use` | No |
| `S3-EVR-067` | ROHM Co., Ltd. | Fifth-Generation SiC Sample Plan | `ROHM_FifthGenerationSiCSamplePlanRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-067` — Accepted | `TBD — no use` | No |
| `S3-EVR-068` | ROHM Co., Ltd. | Fifth-Generation SiC Application | `ROHM_FifthGenerationSiCApplicationRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-068` — Accepted | `TBD — no use` | No |
| `S3-EVR-069` | ROHM Co., Ltd. | Anonymous-Customer BBU Adoption | `ROHM_AnonymousCustomerBBUAdoptionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-069` — Accepted | `TBD — no use` | No |
| `S3-EVR-070` | ROHM Co., Ltd. | Super Junction MOSFET Mass-Production | `ROHM_SuperJunctionMOSFETMassProductionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-070` — Accepted | `TBD — no use` | No |
| `S3-EVR-071` | ROHM Co., Ltd. | Super Junction MOSFET Application | `ROHM_SuperJunctionMOSFETApplicationRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-071` — Accepted | `TBD — no use` | No |
| `S3-EVR-072` | ROHM Co., Ltd. | Anonymous Cloud Provider Recommendation | `ROHM_AnonymousCloudProviderRecommendationRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-072` — Accepted | `TBD — no use` | No |
| `S3-EVR-073` | ROHM Co., Ltd. | AI Data Server Product-Development Plan | `ROHM_AIDataServerProductDevelopmentPlanRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-073` — Accepted | `TBD — no use` | No |
| `S3-EVR-074` | ROHM Co., Ltd. | AI Data Server Adoption Assertion | `ROHM_AIDataServerAdoptionAssertionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-074` — Accepted | `TBD — no use` | No |
| `S3-EVR-075` | ROHM Co., Ltd. | Murata Data Center PSU Adoption | `ROHM_MurataDataCenterPSUAdoptionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-075` — Accepted | `TBD — no use` | No |
| `S3-EVR-076` | ROHM Co., Ltd. | GaN Gate-Driver Availability | `ROHM_GaNGateDriverAvailabilityRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-076` — Accepted | `TBD — no use` | No |
| `S3-EVR-077` | ROHM Co., Ltd. | GaN Gate-Driver Server Application | `ROHM_GaNGateDriverServerApplicationRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-077` — Accepted | `TBD — no use` | No |
| `S3-EVR-078` | ROHM Co., Ltd. | Murata AI Server PSU Production Plan | `ROHM_MurataAIServerPSUProductionPlanRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-078` — Accepted | `TBD — no use` | No |
| `S3-EVR-079` | ROHM Co., Ltd. | GaN Gate Technology Development | `ROHM_GaNGateTechnologyDevelopmentRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-079` — Accepted | `TBD — no use` | No |
| `S3-EVR-080` | ROHM Co., Ltd. | GaN Sample-Shipment Plan | `ROHM_GaNSampleShipmentPlanRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-080` — Accepted | `TBD — no use` | No |
| `S3-EVR-081` | ROHM Co., Ltd. | Delta GaN Strategic Partnership | `ROHM_DeltaGaNStrategicPartnershipRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-081` — Accepted | `TBD — no use` | No |
| `S3-EVR-082` | ROHM Co., Ltd. | GaN Mass-Production System | `ROHM_GaNMassProductionSystemRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-082` — Accepted | `TBD — no use` | No |
| `S3-EVR-083` | ROHM Co., Ltd. | Delta 600V GaN Development Plan | `ROHM_Delta600VGaNDevelopmentPlanRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-083` — Accepted | `TBD — no use` | No |
| `S3-EVR-084` | ROHM Co., Ltd. | 650V GaN Mass-Production | `ROHM_650VGaNMassProductionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-084` — Accepted | `TBD — no use` | No |
| `S3-EVR-085` | ROHM Co., Ltd. | 650V GaN Server Application | `ROHM_650VGaNServerApplicationRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-085` — Accepted | `TBD — no use` | No |
| `S3-EVR-086` | ROHM Co., Ltd. | Ancora GaN Joint Development | `ROHM_AncoraGaNJointDevelopmentRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-086` — Accepted | `TBD — no use` | No |
| `S3-EVR-087` | ROHM Co., Ltd. | AI Data Server SAM Illustration | `ROHM_AIDataServerSAMIllustrationRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-087` — Accepted | `TBD — no use` | No |
| `S3-EVR-088` | ROHM Co., Ltd. | GaN Data Center Application | `ROHM_GaNDataCenterApplicationRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-088` — Accepted | `TBD — no use` | No |
| `S3-EVR-089` | ROHM Co., Ltd. | Murata Data Center PSU Production Assertion | `ROHM_MurataDataCenterPSUProductionAssertionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-089` — Accepted | `TBD — no use` | No |
| `S3-EVR-090` | ROHM Co., Ltd. | EcoGaN Application Expansion Plan | `ROHM_EcoGaNApplicationExpansionPlanRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-090` — Accepted | `TBD — no use` | No |
| `S3-EVR-091` | ROHM Co., Ltd. | GNE10xxTB Production Commencement | `ROHM_GNE10xxTBProductionCommencementRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-091` — Accepted | `TBD — no use` | No |
| `S3-EVR-092` | ROHM Co., Ltd. | GNE10xxTB Data Center Application | `ROHM_GNE10xxTBDataCenterApplicationRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-092` — Accepted | `TBD — no use` | No |
| `S3-EVR-093` | Infineon Technologies AG | AI Data Center Power Revenue Actual | `IFX_AIDataCenterRevenueActualRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-093` — Accepted | `TBD — no use` | No |
| `S3-EVR-094` | Infineon Technologies AG | AI Data Center Power Revenue Forecast FY2026 | `IFX_AIDataCenterRevenueForecastFY2026RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-094` — Accepted | `TBD — no use` | No |
| `S3-EVR-095` | Infineon Technologies AG | Superseded Addressable-Market Forecast | `IFX_AddressableMarketForecastSupersededRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-095` — Accepted | `TBD — no use` | No |
| `S3-EVR-096` | Infineon Technologies AG | NVIDIA 800V Joint Development | `IFX_NVIDIA800VJointDevelopmentRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-096` — Accepted | `TBD — no use` | No |
| `S3-EVR-097` | Infineon Technologies AG | PSS Revenue Growth Forecast | `IFX_PSSRevenueGrowthForecastRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-097` — Accepted | `TBD — no use` | No |
| `S3-EVR-098` | Infineon Technologies AG | AI Data Center Capacity Investment Context | `IFX_AIDataCenterCapacityInvestmentContextRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-098` — Accepted | `TBD — no use` | No |
| `S3-EVR-099` | Infineon Technologies AG | PSS Q2 FY2026 Actual | `IFX_PSSQ2FY2026ActualRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-099` — Accepted | `TBD — no use` | No |
| `S3-EVR-100` | Infineon Technologies AG | PSS AI and Radar Growth Driver | `IFX_PSSAIAndRadarGrowthDriverRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-100` — Accepted | `TBD — no use` | No |
| `S3-EVR-101` | Infineon Technologies AG | AI Business Allocation Condition | `IFX_AIBusinessAllocationConditionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-101` — Accepted | `TBD — no use` | No |
| `S3-EVR-102` | Infineon Technologies AG | Automotive Capacity Redeployment | `IFX_AutomotiveCapacityRedeploymentRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-102` — Accepted | `TBD — no use` | No |
| `S3-EVR-103` | Infineon Technologies AG | Dedicated AI Power Revenue FY2027 Indication | `IFX_DedicatedAIPowerRevenueFY2027IndicationRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-103` — Accepted | `TBD — no use` | No |
| `S3-EVR-104` | Infineon Technologies AG | GaN Shipment Increase Assertion | `IFX_GaNShipmentIncreaseAssertionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-104` — Accepted | `TBD — no use` | No |
| `S3-EVR-105` | Infineon Technologies AG | GaN Design-in Pipeline Expansion | `IFX_GaNDesignInPipelineExpansionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-105` — Accepted | `TBD — no use` | No |
| `S3-EVR-106` | Infineon Technologies AG | SiC Business Growth Driver | `IFX_SiCBusinessGrowthDriverRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-106` — Accepted | `TBD — no use` | No |
| `S3-EVR-107` | Infineon Technologies AG | Per-kW Content Estimate | `IFX_PerKWContentEstimateRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-107` — Accepted | `TBD — no use` | No |
| `S3-EVR-108` | Infineon Technologies AG | Grid-to-Core Architecture | `IFX_GridToCoreArchitectureRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-108` — Accepted | `TBD — no use` | No |
| `S3-EVR-109` | Infineon Technologies AG | Single-Phase PSU Availability | `IFX_SinglePhasePSUAvailabilityRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-109` — Accepted | `TBD — no use` | No |
| `S3-EVR-110` | Infineon Technologies AG | HV and MV IBC Portfolio | `IFX_HVAndMVIBCPortfolioRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-110` — Accepted | `TBD — no use` | No |
| `S3-EVR-111` | Infineon Technologies AG | Vertical Power Delivery Loss Illustration | `IFX_VerticalPowerDeliveryLossIllustrationRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-111` — Accepted | `TBD — no use` | No |
| `S3-EVR-112` | Infineon Technologies AG | AI Data Center Value-Chain Taxonomy | `IFX_AIDataCenterValueChainTaxonomyRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-112` — Accepted | `TBD — no use` | No |
| `S3-EVR-113` | Infineon Technologies AG | Rack Power and Content Scenario | `IFX_RackPowerContentScenarioRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-113` — Accepted | `TBD — no use` | No |
| `S3-EVR-114` | Infineon Technologies AG | AI Server Revenue FY2025 Forecast | `IFX_AIServerRevenueFY2025ForecastRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-114` — Accepted | `TBD — no use` | No |
| `S3-EVR-115` | Infineon Technologies AG | AI Server Revenue Two-Year Target | `IFX_AIServerRevenueTwoYearTargetRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-115` — Accepted | `TBD — no use` | No |
| `S3-EVR-116` | Infineon Technologies AG | AI Server Rack BOM Estimate | `IFX_AIServerRackBOMEstimateRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-116` — Accepted | `TBD — no use` | No |
| `S3-EVR-117` | Infineon Technologies AG | PSU Availability at 2024 Source Event | `IFX_PSUAvailability2024RawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-117` — Accepted | `TBD — no use` | No |
| `S3-EVR-118` | Infineon Technologies AG | AI Server PSU Performance Assertion | `IFX_AIServerPSUPerformanceAssertionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-118` — Accepted | `TBD — no use` | No |
| `S3-EVR-119` | Infineon Technologies AG | NVIDIA 800V Architecture Definition | `IFX_NVIDIA800VArchitectureDefinitionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-119` — Accepted | `TBD — no use` | No |
| `S3-EVR-120` | Infineon Technologies AG | AI PSU Reference-Design Introduction | `IFX_AIPSUReferenceDesignIntroductionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-120` — Accepted | `TBD — no use` | No |
| `S3-EVR-121` | Infineon Technologies AG | AI PSU Performance Assertion | `IFX_AIPSUPerformanceAssertionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-121` — Accepted | `TBD — no use` | No |
| `S3-EVR-122` | Infineon Technologies AG | AI PSU Evaluation Availability Plan | `IFX_AIPSUEvaluationAvailabilityPlanRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-122` — Accepted | `TBD — no use` | No |
| `S3-EVR-123` | Infineon Technologies AG | Intel Sapphire Rapids Power Offering | `IFX_IntelSapphireRapidsPowerOfferingRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-123` — Accepted | `TBD — no use` | No |
| `S3-EVR-124` | Infineon Technologies AG | NVIDIA XDP710 Speaker Assertion | `IFX_NVIDIAXDP710SpeakerAssertionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-124` — Accepted | `TBD — no use` | No |
| `S3-EVR-125` | Infineon Technologies AG | AI Server BOM Estimate | `IFX_AIServerBOMEstimateRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-125` — Accepted | `TBD — no use` | No |
| `S3-EVR-126` | Infineon Technologies AG | AI Server Revenue FY2024 Forecast | `IFX_AIServerRevenueFY2024ForecastRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-126` — Accepted | `TBD — no use` | No |
| `S3-EVR-127` | Infineon Technologies AG | AI Server Revenue CAGR Forecast | `IFX_AIServerRevenueCAGRForecastRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-127` — Accepted | `TBD — no use` | No |
| `S3-EVR-128` | Infineon Technologies AG | Anonymous Design-Win Assertion | `IFX_AnonymousDesignWinAssertionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-128` — Accepted | `TBD — no use` | No |
| `S3-EVR-129` | Infineon Technologies AG | AI Demand-Supply Condition | `IFX_AIDemandSupplyConditionRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-129` — Accepted | `TBD — no use` | No |
| `S3-EVR-130` | Infineon Technologies AG | Market-Sizing Method Replacement | `IFX_MarketSizingMethodReplacementRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-130` — Accepted | `TBD — no use` | No |
| `S3-EVR-131` | Infineon Technologies AG | Three-Phase PSU Roadmap | `IFX_ThreePhasePSURoadmapRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-131` — Accepted | `TBD — no use` | No |
| `S3-EVR-132` | Infineon Technologies AG | Historical PSU Availability Roadmap | `IFX_HistoricalPSUAvailabilityRoadmapRawEvidence.v0.1-draft.md` | Accepted | Accepted | `S3-PIT-132` — Accepted | `TBD — no use` | No |

`MSFT-SFI-010`はSource Fact InspectionでHoldであり、Evidence ID未発行のため本Registerへ含めない。

`NVDA-SFI-012`はSource Fact InspectionでHoldであり、Evidence ID未発行のため本Registerへ含めない。

`REN-SFI-008`、`REN-SFI-015`及び`REN-SFI-018`はSource Fact InspectionでHoldであり、Raw Evidence未作成・Evidence ID未発行のため本Registerへ含めない。`REN-SFI-001`–`003`はSprint002 Evidence参照専用であり、Sprint003で再発行しない。

`ROHM-SFI-008`、`012`、`014`、`017`、`020`–`025`及び`044`はSource Fact InspectionでHoldであり、Raw Evidence未作成・Evidence ID未発行のため本Registerへ含めない。`ROHM-SFI-001`–`004`は既存Sprint Evidence参照専用であり、Sprint003で再発行しない。

`IFX-SFI-023`及び`IFX-SFI-040`はSource Fact InspectionでHoldであり、Raw Evidence未作成・Evidence ID未発行のため本Registerへ含めない。`IFX-SFI-001`はSprint001 Evidence参照専用であり、Sprint003で再発行しない。`IFX-SFI-029`は`IFX-SFI-005`のcorroborating Source Eventであり、別Raw又はEvidence IDを発行しない。

## 3. Evidence Records

### S3-EVR-001 — Data Center AI Demand and Server Dependency

| Field | Value |
| --- | --- |
| Issuer | Microsoft Corporation |
| Official source title | *Microsoft 2025 Form 10-K* |
| Publication Event | SEC filed 2025-07-30; accepted 2025-07-30 16:11:40 ET |
| Official URL | https://www.sec.gov/Archives/edgar/data/789019/000095017025100235/msft-20250630.htm |
| Source position | Part I, Item 1, `Business → Operations` |
| Applicable Period | FY ended 2025-06-30 / filing-date operating description |
| Unit / Currency | N/A |
| Classification | Issuer narrative / operating dependency; filing-date description, not Forecast |
| Issuer definition | Microsoft固有のData Center運用・供給依存関係 |
| Source Fact | Microsoftは、顧客ニーズ、特にAI services需要の増加を踏まえてData Center所在地及びserver capacityを調整していると記載する。またData Centerは、permitted and buildable land、predictable energy、networking supplies及びserversの供給に依存し、serversにはGPU及びother componentsが含まれると記載する。 |
| Use boundary | GPU以外の`other components`を特定製品へ展開しない。供給依存を購入量・売上・shortageへ変換せず、Microsoft固有の関係を業界全体へ一般化しない。 |
| Cross-sprint reference | Stage 0 fixed examined set: no existing Microsoft match |

### S3-EVR-002 — Property and Equipment Additions FY2023–FY2025

| Field | Value |
| --- | --- |
| Issuer | Microsoft Corporation |
| Official source title | *Microsoft 2025 Form 10-K* |
| Publication Event | SEC filed 2025-07-30; accepted 2025-07-30 16:11:40 ET |
| Official URL | https://www.sec.gov/Archives/edgar/data/789019/000095017025100235/msft-20250630.htm |
| Source position | Part II, Item 8, `Cash Flows Statements → Investing → Additions to property and equipment` |
| Applicable Period | FY2023、FY2024、FY2025（各6月30日終了年度） |
| Unit / Currency | USD million |
| Classification | Direct quantitative observation / Actual |
| Issuer definition | Consolidated `Additions to property and equipment` |
| Source Fact | 原典cash-flow表示 / 絶対額は、FY2025 `(64,551)` / 64,551、FY2024 `(44,477)` / 44,477、FY2023 `(28,107)` / 28,107（USDm）。 |
| Use boundary | 括弧付きcash outflowと絶対額を区別する。全社値をData Center、Cloud、AI又は半導体へ配賦せず、増減率を半導体需要率としない。 |
| Cross-sprint reference | Stage 0 fixed examined set: no existing Microsoft match |

### S3-EVR-003 — Primarily Data Center-related Construction Commitments FY2025

| Field | Value |
| --- | --- |
| Issuer | Microsoft Corporation |
| Official source title | *Microsoft 2025 Form 10-K* |
| Publication Event | SEC filed 2025-07-30; accepted 2025-07-30 16:11:40 ET |
| Official URL | https://www.sec.gov/Archives/edgar/data/789019/000095017025100235/msft-20250630.htm |
| Source position | Part II, Item 8, `Note 6 — Property and Equipment` |
| Applicable Period | As of 2025-06-30 |
| Unit / Currency | USD billion |
| Classification | Direct quantitative observation / Commitment; not Actual expenditure |
| Issuer definition | 新規建物、建物改良及びleasehold improvementsのconstruction commitments |
| Source Fact | 2025-06-30時点のconstruction commitmentsはUSD32.1bnであり、Microsoftはこれを主としてData Center関連と記載する。 |
| Use boundary | 支出済みCapex、稼働capacity、server・GPU・半導体購入額へ変換しない。`primarily related to datacenters`を100% Data Centerと解釈しない。 |
| Cross-sprint reference | Stage 0 fixed examined set: no existing Microsoft match |

### S3-EVR-004 — Primarily Data Center-related Purchase Commitments FY2025

| Field | Value |
| --- | --- |
| Issuer | Microsoft Corporation |
| Official source title | *Microsoft 2025 Form 10-K* |
| Publication Event | SEC filed 2025-07-30; accepted 2025-07-30 16:11:40 ET |
| Official URL | https://www.sec.gov/Archives/edgar/data/789019/000095017025100235/msft-20250630.htm |
| Source position | Part II, Item 7, `Material Cash Requirements and Other Obligations → Contractual Obligations`、purchase commitments row及びfootnote (d) |
| Applicable Period | Outstanding contractual obligations as of 2025-06-30 |
| Unit / Currency | USD million |
| Classification | Direct quantitative observation / Commitment; not Actual purchase or expenditure |
| Issuer definition | 主としてData Center関連で、construction commitmentsに含まれないopen purchase orders及びtake-or-pay contractsを含むpurchase commitments |
| Source Fact | Purchase commitmentsはFY2026 103,940、Thereafter 6,013、Total 109,953（USDm）。 |
| Use boundary | 品目へ配賦せず、受注、購入実績、設備取得又は将来需要へ置換しない。`primarily`を100%と解釈しない。 |
| Cross-sprint reference | Stage 0 fixed examined set: no existing Microsoft match |

### S3-EVR-005 — Cloud and AI Infrastructure Capital Plan FY2025

| Field | Value |
| --- | --- |
| Issuer | Microsoft Corporation |
| Official source title | *Microsoft 2025 Form 10-K* |
| Publication Event | SEC filed 2025-07-30; accepted 2025-07-30 16:11:40 ET |
| Official URL | https://www.sec.gov/Archives/edgar/data/789019/000095017025100235/msft-20250630.htm |
| Source position | Part II, Item 7, `Liquidity and Capital Resources → Other Planned Uses of Capital` |
| Applicable Period | Filing-date forward-looking capital plan |
| Unit / Currency | N/A |
| Classification | Plan / issuer narrative; not Actual |
| Issuer definition | Cloud offeringsの成長、AI Infrastructure及びtrainingを支えるcapital plan |
| Source Fact | Microsoftは、Cloud offeringsの成長並びにAI Infrastructure及びtrainingへの投資を支えるためcapital expendituresへの投資を継続すると記載する。またProperty and Equipment additionsにはnew facilities、Data Centers及びcomputer systems等が含まれると説明する。 |
| Use boundary | 実行済み投資、金額、時期、capacity又は半導体需要とせず、列挙項目を相互排他的な内訳とみなさない。 |
| Cross-sprint reference | Stage 0 fixed examined set: no existing Microsoft match |

### S3-EVR-006 — Property and Equipment Additions FY2026 Q3

| Field | Value |
| --- | --- |
| Issuer | Microsoft Corporation |
| Official source title | *FY2026 Q3 Earnings Release* |
| Publication Event | 2026-04-29; release time/timezone `Unknown` |
| Official URL | https://www.microsoft.com/en-us/investor/earnings/FY-2026-Q3/press-release-webcast |
| Source position | `Cash Flows Statements (Unaudited) → Investing → Additions to property and equipment` |
| Applicable Period | Three and nine months ended 2026-03-31 |
| Unit / Currency | USD million |
| Classification | Direct quantitative observation / Actual-period unaudited result |
| Issuer definition | Consolidated `Additions to property and equipment` |
| Source Fact | 3か月はFY2026 `(30,876)` / 30,876、FY2025比較値 `(16,745)` / 16,745。9か月はFY2026 `(80,146)` / 80,146、FY2025比較値 `(47,472)` / 47,472（原典表示 / 絶対額、USDm）。 |
| Use boundary | cash outflow表示と絶対額を区別する。全社値をData Center、Cloud、AI又は半導体へ配賦せず、前年同期比を半導体需要率としない。 |
| Cross-sprint reference | Stage 0 fixed examined set: no existing Microsoft match |

### S3-EVR-007 — AI Infrastructure Margin and Compute Capacity FY2026 Q3

| Field | Value |
| --- | --- |
| Issuer | Microsoft Corporation |
| Official source title | *FY2026 Q3 Earnings Release — Performance* |
| Publication Event | FY2026 Q3 earnings event context: 2026-04-29; Performance page publication date/time/timezone `Unknown` |
| Official URL | https://www.microsoft.com/en-us/investor/earnings/FY-2026-Q3/performance |
| Source position | `Performance`、gross margin及びoperating expenses commentary |
| Applicable Period | Q3 FY2026 / three months ended 2026-03-31 |
| Unit / Currency | N/A |
| Classification | Issuer narrative / Actual-period performance explanation; not investment-program Actual |
| Issuer definition | AI Infrastructure投資及びAI product usageを含む、margin・operating expensesに関する複数要因説明 |
| Source Fact | Microsoftは、AI Infrastructureへの継続投資及びAI product usage増加がgross margin percentage低下要因であり、R&D compute capacity、AI talent及びdataへの投資がoperating expenses増加要因であると説明する。 |
| Use boundary | 複数要因を保持する。`compute capacity`をGPU数量、server台数又は半導体需要量へ変換せず、margin又はOpExから投資額を逆算しない。 |
| Cross-sprint reference | Stage 0 fixed examined set: no existing Microsoft match |

### S3-EVR-008 — Cloud Demand Metrics FY2026 Q3

| Field | Value |
| --- | --- |
| Issuer | Microsoft Corporation |
| Official source title | *FY2026 Q3 Earnings Release* |
| Publication Event | 2026-04-29; release time/timezone `Unknown` |
| Official URL | https://www.microsoft.com/en-us/investor/earnings/FY-2026-Q3/press-release-webcast |
| Source position | `Business Highlights`及びmanagement quotation |
| Applicable Period | Three months ended 2026-03-31 |
| Unit / Currency | USD billion、year-over-year % |
| Classification | Direct quantitative observations and issuer narrative / Actual-period results |
| Issuer definition | Microsoft Cloud revenue及びAzure and other cloud services revenue growth |
| Source Fact | Microsoft Cloud revenueはUSD54.5bnで前年比29%増加した。Azure and other cloud services revenueは前年比40%増加した。Microsoft CFOは結果についてMicrosoft Cloudへの需要増を反映したものと説明する。 |
| Use boundary | Microsoft Cloud、Azure and other cloud services及びAI Infrastructureを同義化しない。Data Center投資、AI需要、server shipment又は半導体需要の直接Observationとして使用せず、特定製品・供給者へ展開しない。 |
| Cross-sprint reference | Stage 0 fixed examined set: no existing Microsoft match |
| Special caution | Cloud需要contextとしてのみ保持する。直接的なData Center / AI Infrastructure semiconductor demand proxyではない。 |

### S3-EVR-009 — Cloud and AI Infrastructure Demand / Capex FY2024

| Field | Value |
| --- | --- |
| Issuer | Microsoft Corporation |
| Official source title | *Microsoft 2024 Annual Shareholders Meeting Transcript* |
| Publication Event | Event 2024-12-10; page publication time/timezone `Unknown` |
| Official URL | https://www.microsoft.com/en-us/investor/events/fy-2025/2024-annual-shareholder-meeting |
| Source position | CFO business review及びQ&Aのcapital expenditures for cloud and AI infrastructure |
| Applicable Period | FY2024 results及び2024-12-10時点の経営説明 |
| Unit / Currency | N/A |
| Classification | Issuer narrative / Actual and forward-looking explanation; not quantitative Actual / Forecast |
| Issuer definition | Cloud / AI services需要とinfrastructure投資に関するMicrosoft CFOの説明 |
| Source Fact | Microsoft CFOは、Cloud / AI services需要との整合のためcapital expenditureを大幅に増加させたと説明する。またAI platformをglobalに構築し顧客及びpartner需要へ対応するには、infrastructureへのmeaningful capital investmentが必要と説明する。 |
| Use boundary | 過去説明と将来必要性を同一Actualとして扱わず、Capex金額、Data Center比率又は半導体購入額を推定しない。顧客・partner需要を特定製品・供給者へ展開しない。 |
| Cross-sprint reference | Stage 0 fixed examined set: no existing Microsoft match |

### S3-EVR-010 — AI-optimized Infrastructure and Accelerator Options

| Field | Value |
| --- | --- |
| Issuer | Alphabet Inc. |
| Official source title | *Alphabet 2025 Form 10-K* |
| Publication Event | SEC filed 2026-02-05; accepted 2026-02-04 21:56:03（SEC index表示。timezoneはページ上で別途明示されない） |
| Official URL | https://www.sec.gov/Archives/edgar/data/1652044/000165204426000018/goog-20251231.htm |
| Source position | Part I, Item 1, AI / technical infrastructure description |
| Applicable Period | FY ended 2025-12-31 / filing-date operating architecture description |
| Unit / Currency | N/A |
| Classification | Issuer narrative / operating architecture; not quantitative Actual / Forecast |
| Issuer definition | Full-stack AI approachの基盤となるAI-optimized infrastructureとaccelerator options |
| Source Fact | AlphabetはGoogle Cloud顧客へspecialized GPUs及び自社custom-built TPUsを含むAI accelerator optionsを提供すると記載する。 |
| Use boundary | AI-optimized infrastructure、technical infrastructure、Data Center、GPU及びTPUを同義化しない。Accelerator optionsをGPU / TPU数量、購入額、稼働量、market share、外部調達比率、半導体需要又は供給者別売上へ変換せず、`S3-EVR-015`の供給risk Factとして重複登録しない。 |
| Cross-sprint reference | `AlphabetCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-011 — Capital Expenditures FY2024–FY2025

| Field | Value |
| --- | --- |
| Issuer | Alphabet Inc. |
| Official source title | *Alphabet 2025 Form 10-K* |
| Publication Event | SEC filed 2026-02-05; accepted 2026-02-04 21:56:03（SEC index表示。timezoneはページ上で別途明示されない） |
| Official URL | https://www.sec.gov/Archives/edgar/data/1652044/000165204426000018/goog-20251231.htm |
| Source position | Part II, Item 7, `Capital Expenditures` |
| Applicable Period | FY2024 and FY2025（各12月31日終了年度） |
| Unit / Currency | USD billion |
| Classification | Direct quantitative observation / Actual and issuer classification |
| Issuer definition | Alphabet全社Capital expenditures |
| Source Fact | Capital expendituresはFY2024 USD52.5bn、FY2025 USD91.4bn。FY2025 CapExは主としてtechnical infrastructureへの投資を反映すると発行者は説明する。 |
| Use boundary | 全額をData Center、servers、AI又は半導体へ配賦しない。FY2025 USD91.4bnは`S3-EVR-017`で再掲されるため、独立Actualとして二重計上しない。FY2024からFY2025への増減額又は増減率を半導体需要の増減へ変換しない。 |
| Cross-sprint reference | `AlphabetCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-012 — Technical Infrastructure and Construction Lifecycle

| Field | Value |
| --- | --- |
| Issuer | Alphabet Inc. |
| Official source title | *Alphabet 2025 Form 10-K* |
| Publication Event | SEC filed 2026-02-05; accepted 2026-02-04 21:56:03（SEC index表示。timezoneはページ上で別途明示されない） |
| Official URL | https://www.sec.gov/Archives/edgar/data/1652044/000165204426000018/goog-20251231.htm |
| Source position | Part II, Item 7, `Capital Expenditures and Leases → Capital Expenditures` |
| Applicable Period | FY ended 2025-12-31 / filing-date definition and lifecycle description |
| Unit / Currency | N/A |
| Classification | Issuer definition / construction lifecycle; not measured Actual / Forecast |
| Issuer definition | Technical infrastructure及び一般的なData Center construction process |
| Source Fact | Technical infrastructureはservers and network equipment、data center land、building construction and improvementsへの投資から構成される。Data Center construction projectsは一般に複数年・複数phaseで、land / buildings取得、建設、servers / network equipmentの確保・設置を含む。 |
| Use boundary | 構成別金額、相互排他性、半導体内訳又は固定Lead / Lagを導出せず、Alphabetのprocessを業界全体へ一般化しない。 |
| Cross-sprint reference | `AlphabetCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-013 — Technical Infrastructure Gross In-service Assets FY2024–FY2025

| Field | Value |
| --- | --- |
| Issuer | Alphabet Inc. |
| Official source title | *Alphabet 2025 Form 10-K* |
| Publication Event | SEC filed 2026-02-05; accepted 2026-02-04 21:56:03（SEC index表示。timezoneはページ上で別途明示されない） |
| Official URL | https://www.sec.gov/Archives/edgar/data/1652044/000165204426000018/goog-20251231.htm |
| Source position | Note 7, `Property and Equipment, Net` |
| Applicable Period | As of 2024-12-31 and 2025-12-31 |
| Unit / Currency | USD million、approximate composition % |
| Classification | Direct quantitative observation / period-end gross in-service asset balance; not net carrying amount |
| Issuer definition | `Property and equipment, in service`を構成するTechnical infrastructure gross balance |
| Source Fact | Gross in-service balanceは2024-12-31時点USD141,852m、2025-12-31時点USD203,679m。両時点で約60%はservers and network equipment、残余はdata center land and buildings and related assetsと注記される。 |
| Use boundary | `assets not yet in service`を含めず、全社accumulated depreciationの配賦によるnet推定、CapEx構成との同一化又はGPU / TPUへの配賦をしない。 |
| Cross-sprint reference | `AlphabetCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-014 — Purchase Commitments and Other Contractual Obligations FY2025

| Field | Value |
| --- | --- |
| Issuer | Alphabet Inc. |
| Official source title | *Alphabet 2025 Form 10-K* |
| Publication Event | SEC filed 2026-02-05; accepted 2026-02-04 21:56:03（SEC index表示。timezoneはページ上で別途明示されない） |
| Official URL | https://www.sec.gov/Archives/edgar/data/1652044/000165204426000018/goog-20251231.htm |
| Source position | Part II, Item 7, `Purchase Commitments and Other Contractual Obligations` |
| Applicable Period | As of 2025-12-31 |
| Unit / Currency | USD billion |
| Classification | Direct quantitative observation / Commitment; not Actual expenditure |
| Issuer definition | Energy take-or-pay、licenses、technical infrastructure and inventory orders等を含むmixed-scope obligations |
| Source Fact | TotalはUSD149.1bn、short-termはUSD113.0bn。全体は主としてenergy take-or-pay contracts、licenses、technical infrastructure and inventory ordersに関連し、short-termの大部分はtechnical infrastructure and inventory orders関連と説明される。 |
| Use boundary | `primarily`及び`mostly`の限定を維持する。Total又はshort-termをtechnical infrastructureへ全額配賦せず、支出済みCapEx、受領済み設備・inventory又は半導体購入額へ変換しない。 |
| Cross-sprint reference | `AlphabetCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-015 — Specialized AI Chip Supply Risk

| Field | Value |
| --- | --- |
| Issuer | Alphabet Inc. |
| Official source title | *Alphabet 2025 Form 10-K* |
| Publication Event | SEC filed 2026-02-05; accepted 2026-02-04 21:56:03（SEC index表示。timezoneはページ上で別途明示されない） |
| Official URL | https://www.sec.gov/Archives/edgar/data/1652044/000165204426000018/goog-20251231.htm |
| Source position | Part I, Item 1A, manufacturing and supply-chain risk discussion |
| Applicable Period | FY ended 2025-12-31 / filing-date risk disclosure |
| Unit / Currency | N/A |
| Classification | Issuer narrative / operating dependency and risk; not realized shortage / Forecast |
| Issuer definition | Technical infrastructure向けservers / network equipment、特にspecialized AI chipsのsupplier risk |
| Source Fact | 製造・供給は少数のqualified suppliersに限られ、長期又は予期しないdisruptionはcustomer demandへの対応能力へ影響し得ると記載する。 |
| Use boundary | Actual shortage、発注量、supplier数・identity・purchase share、発生確率、売上影響額又は特定企業売上を確定・推定せず、GPU / TPU options定義は`S3-EVR-010`へ委ねる。 |
| Cross-sprint reference | `AlphabetCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-016 — Technical Infrastructure Investment Plan FY2026

| Field | Value |
| --- | --- |
| Issuer | Alphabet Inc. |
| Official source title | *Alphabet 2025 Form 10-K* |
| Publication Event | SEC filed 2026-02-05; accepted 2026-02-04 21:56:03（SEC index表示。timezoneはページ上で別途明示されない） |
| Official URL | https://www.sec.gov/Archives/edgar/data/1652044/000165204426000018/goog-20251231.htm |
| Source position | Part I, Item 1A, `Increased Investment in Technical Infrastructure`; Part II, Item 7, `Capital Expenditures` |
| Applicable Period | Filing-date FY2026 investment plan |
| Unit / Currency | N/A |
| Classification | Plan / issuer narrative; Actualではない |
| Issuer definition | AIを中心とするtechnical infrastructureへの定性的investment Plan |
| Source Fact | Users / enterprise customersの需要及び内部researchを支えるため投資し、FY2026はFY2025比でservers / network equipment及びdata centersを含むtechnical infrastructure投資を大幅に増加させる見込みと記載する。 |
| Use boundary | Planから金額、実行時期、capacity量、半導体数量又は実現を確定せず、列挙項目へ投資額を配賦しない。`S3-EVR-011` Actual及び`S3-EVR-018`定量Forecastと同一化しない。 |
| Cross-sprint reference | `AlphabetCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-017 — CapEx Composition FY2025

| Field | Value |
| --- | --- |
| Issuer | Alphabet Inc. |
| Official source title | *Alphabet 2025 Q4 Earnings Call* |
| Publication Event | Event 2026-02-04 13:30 PT; transcript page publication date/time `Unknown` |
| Official URL | https://abc.xyz/investor/events/event-details/2026/2025-Q4-Earnings-Call-2026-Dr_C033hS6/default.aspx |
| Source position | CFO results commentary on FY2025 CapEx composition |
| Applicable Period | Q4 / FY2025 results commentary |
| Unit / Currency | USD billion、approximate composition % |
| Classification | Issuer narrative with quantitative CapEx classification / Actual-period explanation |
| Issuer definition | FY2025総CapExと、金額未開示technical-infrastructure investment部分のmanagement classification |
| Source Fact | FY2025 CapExはUSD91.4bnで、そのvast majorityをtechnical infrastructureへ投資した。その金額未開示部分の約60%がservers、40%がdata centers and networking equipmentとCFOは説明する。 |
| Use boundary | 60 / 40を総CapEx USD91.4bnへ直接乗じず、component金額又はGPU / TPU・半導体購入額を導出しない。`S3-EVR-011`とActualを二重計上せず、`S3-EVR-013`のasset構成とも同一化しない。 |
| Cross-sprint reference | `AlphabetCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-018 — CapEx Forecast FY2026

| Field | Value |
| --- | --- |
| Issuer | Alphabet Inc. |
| Official source title | *Alphabet 2025 Q4 Earnings Call* |
| Publication Event | Event 2026-02-04 13:30 PT; transcript page publication date/time `Unknown` |
| Official URL | https://abc.xyz/investor/events/event-details/2026/2025-Q4-Earnings-Call-2026-Dr_C033hS6/default.aspx |
| Source position | CEO opening remarks and CFO FY2026 investment outlook |
| Applicable Period | FY2026 outlook |
| Unit / Currency | USD billion range |
| Classification | Forecast / Plan with issuer demand context; Actualではない |
| Issuer definition | FY2026 CapEx range and AI compute capacity investment context |
| Source Fact | FY2026 CapExをUSD175bn–185bnと予想する。AI compute capacity投資がGoogle DeepMind、Google Services、Cloud customer demand及びその他の投資対象を支えると説明する。 |
| Use boundary | 実行済みCapEx又は確定予算とせず、全額をData Center、Cloud、servers、GPU / TPU又は半導体へ配賦しない。列挙された需要・投資対象を相互排他的な内訳とみなさない。 |
| Cross-sprint reference | `AlphabetCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-019 — Google Cloud Backlog FY2025 Q4

| Field | Value |
| --- | --- |
| Issuer | Alphabet Inc. |
| Official source title | *Alphabet 2025 Q4 Earnings Call* |
| Publication Event | Event 2026-02-04 13:30 PT; transcript page publication date/time `Unknown` |
| Official URL | https://abc.xyz/investor/events/event-details/2026/2025-Q4-Earnings-Call-2026-Dr_C033hS6/default.aspx |
| Source position | Google Cloud results and backlog commentary |
| Applicable Period | Q4 FY2025 / quarter-end backlog context |
| Unit / Currency | USD billion、sequential %、year-over-year qualitative comparison |
| Classification | Direct quantitative observation and issuer narrative / commercial demand context |
| Issuer definition | Google Cloud backlog及びenterprise AI offerings需要context |
| Source Fact | BacklogはUSD240bn、前四半期比55%増加、前年比で2倍超。複数顧客のenterprise AI offerings需要が増加要因と説明される。 |
| Use boundary | Revenue、CapEx、capacity又はsemiconductor ordersへ変換せず、Data Center投資・AI Infrastructure semiconductor demandの直接Observation / proxyとして使用しない。Enterprise AI demandをData Center、GPU / TPU又は特定供給者需要へ展開せず、`more than doubled`から未開示の前年値を逆算しない。 |
| Cross-sprint reference | `AlphabetCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-020 — Capacity Constraint and Timing Boundary FY2025 Q4

| Field | Value |
| --- | --- |
| Issuer | Alphabet Inc. |
| Official source title | *Alphabet 2025 Q4 Earnings Call* |
| Publication Event | Event 2026-02-04 13:30 PT; transcript page publication date/time `Unknown` |
| Official URL | https://abc.xyz/investor/events/event-details/2026/2025-Q4-Earnings-Call-2026-Dr_C033hS6/default.aspx |
| Source position | CEO response on compute capacity, demand and investment timing |
| Applicable Period | Q4 FY2025 / FY2026 management context |
| Unit / Currency | N/A |
| Classification | Issuer narrative / capacity constraint and timing boundary; not measured lag / Forecast |
| Issuer definition | Phase 1のcapacity constraint及びtiming context |
| Source Fact | Capacity増強中でもsupply-constrainedであり、当年CapExは将来を見据え、投資がcapacityとして利用可能になるまで時間差があると説明する。Cloud、社内需要その他の需要が強いとの文脈を示す。 |
| Use boundary | Specialized AI chipsだけの制約又は単独因果とせず、固定Lead / Lagの開始点・終了点、数量又は解消時期を設定しない。Phase 2分析又は半導体需要へ変換しない。 |
| Cross-sprint reference | `AlphabetCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-021 — Data Center Platform Architecture

| Field | Value |
| --- | --- |
| Issuer | NVIDIA Corporation |
| Official source title | *NVIDIA Fiscal 2026 Form 10-K* |
| Publication Event | SEC filed 2026-02-25; accepted 2026-02-25 16:42:19（timezoneはページ上で別途明示されない） |
| Official URL | https://www.sec.gov/Archives/edgar/data/1045810/000104581026000021/nvda-20260125.htm |
| Source position | Part I, Item 1, `Data Center` |
| Applicable Period | FY ended 2026-01-25 / issuer definition as filed |
| Unit / Currency | N/A |
| Classification | Issuer definition / platform architecture; neither Actual nor Forecast |
| Issuer definition | NVIDIA Data Center platformのcompute / networking infrastructure及びsoftware / services構成 |
| Source Fact | NVIDIAはData Center platformをcompute-intensive workloadsを加速するplatformと説明する。Compute / networking infrastructureはrack-scale systems、subsystems又はmodulesにsoftware / servicesを伴い、systemsはGPU、CPU、interconnect及びAI / HPC software等、networkingはNVLink、InfiniBand / Ethernet、adapters、cables、DPU並びにswitch chips / systems等を含む。 |
| Use boundary | Data Center revenueをGPU又は半導体単体売上とみなさず、列挙要素を売上内訳、数量、BOM又はsupplier関係へ変換しない。 |
| Cross-sprint reference | `NVIDIACrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-022 — Data Center Revenue FY2024–FY2025

| Field | Value |
| --- | --- |
| Issuer | NVIDIA Corporation |
| Official source title | *CFO Commentary on Fourth Quarter and Fiscal 2025 Results* |
| Publication Event | Publication date/time/timezone `Unknown` |
| Official URL | https://investor.nvidia.com/files/doc_financials/2025/Q425/Q4FY25-CFO-Commentary.pdf |
| Source position | pp.1–3, `Revenue by Market Platform` and revenue commentary |
| Applicable Period | Q4 / FY2025, quarter and year ended 2025-01-26; FY2024 comparison |
| Unit / Currency | USD billion |
| Classification | Direct quantitative observation / Actual with issuer demand explanation |
| Issuer definition | NVIDIA固有のData Center / Compute / Networking Market Platform revenue |
| Source Fact | Data Center revenueはFY2024 USD47.525bn、FY2025 USD115.186bn。FY2025内訳はCompute USD102.196bn、Networking USD12.990bn。Q4 FY2025はData Center USD35.580bn、Compute USD32.556bn、Networking USD3.024bn。FY2025成長をaccelerated computing platformへの需要と関連付ける。 |
| Use boundary | FY2024 Compute / Networking値は本Accepted Raw scopeに未収容でありUnknownではない。Publication EventはUnknownを維持し、半導体業界需要、shipment又は連続系列へ無条件に変換しない。 |
| Cross-sprint reference | `NVIDIACrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-023 — Data Center Revenue Q4 and FY2026

| Field | Value |
| --- | --- |
| Issuer | NVIDIA Corporation |
| Official source title | *NVIDIA Announces Financial Results for Fourth Quarter and Fiscal 2026* |
| Publication Event | 2026-02-25; release time/timezone `Unknown` |
| Official URL | https://investor.nvidia.com/news/press-release-details/2026/NVIDIA-Announces-Financial-Results-for-Fourth-Quarter-and-Fiscal-2026/ |
| Source position | `Data Center` highlights |
| Applicable Period | Q4 / FY2026, quarter and year ended 2026-01-25 |
| Unit / Currency | USD billion、sequential / year-over-year % |
| Classification | Direct quantitative observation / Actual with issuer driver explanation |
| Issuer definition | NVIDIA Data Center Market Platform revenue |
| Source Fact | Q4 FY2026 Data Center revenueはUSD62.3bn、前四半期比22%増、前年比75%増。FY2026はUSD193.7bn、前年比68%増。Q4増加をaccelerated computing及びAIへのmajor platform shiftsと関連付ける。 |
| Use boundary | GPU又は半導体単体売上へ変換せず、`S3-EVR-026`のdriver narrativeを独立売上として加算せず、業界需要成長率へ一般化しない。 |
| Cross-sprint reference | `NVIDIACrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-024 — Data Center Revenue Q1 FY2027

| Field | Value |
| --- | --- |
| Issuer | NVIDIA Corporation |
| Official source title | *NVIDIA Announces Financial Results for First Quarter Fiscal 2027* |
| Publication Event | 2026-05-20; release time/timezone `Unknown` |
| Official URL | https://investor.nvidia.com/news/press-release-details/2026/NVIDIA-Announces-Financial-Results-for-First-Quarter-Fiscal-2027/default.aspx |
| Source position | Headline, reporting framework and `Data Center` highlights |
| Applicable Period | Q1 FY2027, quarter ended 2026-04-26 |
| Unit / Currency | USD billion、sequential / year-over-year % |
| Classification | Direct quantitative observation / Actual |
| Issuer definition | Q1 FY2027 Data Center及び旧sub-market reporting |
| Source Fact | Data Center revenueはUSD75.2bn、前四半期比21%増、前年比92%増。旧sub-market表示ではCompute USD60.4bn、Networking USD14.8bn。 |
| Use boundary | 旧Compute / Networkingを新Hyperscale / ACIEへ再配賦せず、Data Center合計を半導体業界需要又はGPU単体売上へ一般化しない。 |
| Cross-sprint reference | `NVIDIACrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-025 — Data Center Reporting Framework FY2027

| Field | Value |
| --- | --- |
| Issuer | NVIDIA Corporation |
| Official source title | *NVIDIA Announces Financial Results for First Quarter Fiscal 2027* |
| Publication Event | 2026-05-20; release time/timezone `Unknown` |
| Official URL | https://investor.nvidia.com/news/press-release-details/2026/NVIDIA-Announces-Financial-Results-for-First-Quarter-Fiscal-2027/default.aspx |
| Source position | New reporting framework |
| Applicable Period | Reporting framework announced with Q1 FY2027 results |
| Unit / Currency | N/A |
| Classification | Issuer definition / reporting transition; not an Actual trend |
| Issuer definition | Market platformsをData Center / Edge Computingへ、Data CenterをHyperscale / ACIEへ分ける新分類 |
| Source Fact | Hyperscaleはpublic clouds及び最大規模のconsumer internet companies、ACIEはAI Clouds、Industrial、Enterpriseを含むpurpose-built data centers / AI factoriesを対象とする。 |
| Use boundary | 新旧区分のidentity、継続性、restatement又は数値mappingを推定せず、区分変更だけから需要構造変化を推定しない。 |
| Cross-sprint reference | `NVIDIACrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-026 — Data Center Revenue Drivers FY2026

| Field | Value |
| --- | --- |
| Issuer | NVIDIA Corporation |
| Official source title | *NVIDIA Fiscal 2026 Form 10-K* |
| Publication Event | SEC filed 2026-02-25; accepted 2026-02-25 16:42:19（timezoneはページ上で別途明示されない） |
| Official URL | https://www.sec.gov/Archives/edgar/data/1045810/000104581026000021/nvda-20260125.htm |
| Source position | Part II, Item 7, Overview and revenue discussion |
| Applicable Period | FY ended 2026-01-25 |
| Unit / Currency | Year-over-year %、qualitative `majority` |
| Classification | Issuer narrative with Actual-period quantitative explanation |
| Issuer definition | Data Center compute / networking growth及びBlackwell architecture context |
| Source Fact | FY2026 revenue growthはData Center compute / networking platforms for accelerated computing and AI solutionsが牽引し、Blackwell architecturesはData Center revenueのmajorityを占めた。Data Center computeは前年比59%増、networkingは142%増。 |
| Use boundary | `majority`の比率・金額を推定せず、BlackwellをGPU単体又は特定製品だけの売上とみなさず、`S3-EVR-023`のData Center Actualと独立売上として加算しない。 |
| Cross-sprint reference | `NVIDIACrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-027 — Supply and Capacity Obligations FY2026

| Field | Value |
| --- | --- |
| Issuer | NVIDIA Corporation |
| Official source title | *NVIDIA Fiscal 2026 Form 10-K* |
| Publication Event | SEC filed 2026-02-25; accepted 2026-02-25 16:42:19（timezoneはページ上で別途明示されない） |
| Official URL | https://www.sec.gov/Archives/edgar/data/1045810/000104581026000021/nvda-20260125.htm |
| Source position | Note 12, `Commitments`; Part II, Item 7, inventory and capacity purchase commitments discussion |
| Applicable Period | Balance as of 2026-01-25 / FY2026 discussion |
| Unit / Currency | USD billion |
| Classification | Direct quantitative observation / Consolidated obligation with issuer narrative; not Actual purchase or Forecast revenue |
| Issuer definition | Outstanding inventory purchase and long-term supply / capacity obligations |
| Source Fact | 連結obligationsはUSD95.2bnで、substantially allがFY2027までに支払われる。Note 12はdatacenter-scale productionとlong ordering horizonsを、Item 7はcustomer-demand forecast及びmanufacturing lead times / constraintsを説明する。 |
| Use boundary | Data Center専用額、CapEx、半導体発注額、Actual purchase、shipment又はrevenueへ変換しない。両sectionのclassの同一性・完全対応を確定せず、Item 7 relationをUSD95.2bn全体へ因果・金額配賦せず、component / supplierへ配賦しない。 |
| Cross-sprint reference | `NVIDIACrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-028 — Data Center Component Constraint Risk

| Field | Value |
| --- | --- |
| Issuer | NVIDIA Corporation |
| Official source title | *NVIDIA Fiscal 2026 Form 10-K* |
| Publication Event | SEC filed 2026-02-25; accepted 2026-02-25 16:42:19（timezoneはページ上で別途明示されない） |
| Official URL | https://www.sec.gov/Archives/edgar/data/1045810/000104581026000021/nvda-20260125.htm |
| Source position | Part I, Item 1A, `Risks Related to Demand, Supply, and Manufacturing` |
| Applicable Period | Risk disclosure as filed for FY2026 |
| Unit / Currency | N/A |
| Classification | Issuer narrative / realized and prospective operating risk; not quantified Actual / Forecast |
| Issuer definition | Complex Data Center buildoutにおけるcomponent availability risk |
| Source Fact | 一つのcomponentのsupply constraint又はavailability issueがより広いrevenue impactを持ったことがあり、完成品に必要なthird-party componentsの不足が販売を妨げ得ると記載する。 |
| Use boundary | 現在のshortage、失注額、component数量、発生確率、特定component又はsupplierを確定・推定せず、継続的な実測関係へ変換しない。 |
| Cross-sprint reference | `NVIDIACrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-029 — H20 Inventory Charge FY2026

| Field | Value |
| --- | --- |
| Issuer | NVIDIA Corporation |
| Official source title | *NVIDIA Fiscal 2026 Form 10-K* |
| Publication Event | SEC filed 2026-02-25; accepted 2026-02-25 16:42:19（timezoneはページ上で別途明示されない） |
| Official URL | https://www.sec.gov/Archives/edgar/data/1045810/000104581026000021/nvda-20260125.htm |
| Source position | Part I and Part II, Item 7, H20 export-control and inventory discussion |
| Applicable Period | Q1 FY2026 charge / FY2026 disclosure |
| Unit / Currency | USD billion |
| Classification | Direct quantitative observation / regulatory demand shock and inventory provision Actual |
| Issuer definition | 2025年4月の輸出license要件後のH20固有会計event |
| Source Fact | H20需要減少に伴い、Q1 FY2026にH20 excess inventory and purchase obligationsについてUSD4.5bn chargeを計上した。 |
| Use boundary | Data Center全体又はGlobal AI需要の通常循環へ一般化せず、inventory数量、通常需要、将来回復又は他製品への代替を推定しない。 |
| Cross-sprint reference | `NVIDIACrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-030 — China Data Center Market Access FY2026

| Field | Value |
| --- | --- |
| Issuer | NVIDIA Corporation |
| Official source title | *NVIDIA Fiscal 2026 Form 10-K* |
| Publication Event | SEC filed 2026-02-25; accepted 2026-02-25 16:42:19（timezoneはページ上で別途明示されない） |
| Official URL | https://www.sec.gov/Archives/edgar/data/1045810/000104581026000021/nvda-20260125.htm |
| Source position | Part I, export-control discussion |
| Applicable Period | FY2026 year-end / filing-date market-access status |
| Unit / Currency | N/A |
| Classification | Issuer narrative / market-access status and risk |
| Issuer definition | NVIDIA固有のChina Data Center compute market-access context |
| Source Fact | FY2026末時点でChinaのData Center compute marketで実質的に競争できない状態と説明し、H200 license programでは提出時点までrevenueを計上していないと記載する。 |
| Use boundary | China総需要、市場規模、競合売上、lost revenue又は将来license / revenueを推定せず、H20 charge又はForecastと同一Factにしない。 |
| Cross-sprint reference | `NVIDIACrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Special caution | Issuer-specific geographic access contextとしてのみ保持する。 |

### S3-EVR-031 — Revenue Outlook Q2 FY2027

| Field | Value |
| --- | --- |
| Issuer | NVIDIA Corporation |
| Official source title | *NVIDIA Announces Financial Results for First Quarter Fiscal 2027* |
| Publication Event | 2026-05-20; release time/timezone `Unknown` |
| Official URL | https://investor.nvidia.com/news/press-release-details/2026/NVIDIA-Announces-Financial-Results-for-First-Quarter-Fiscal-2027/default.aspx |
| Source position | `Outlook` |
| Applicable Period | Q2 FY2027 outlook |
| Unit / Currency | USD billion ±% |
| Classification | Forecast / Plan with explicit exclusion assumption |
| Issuer definition | Total-company revenue outlook |
| Source Fact | Q2 FY2027全社revenue outlookはUSD91.0bn±2%で、Data Center compute revenue from Chinaを想定していない。 |
| Use boundary | Data Center Forecast、China需要減少額、Global demand又はActualへ変換せず、market-access narrative又はH20 chargeと同一Factにしない。 |
| Cross-sprint reference | `NVIDIACrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Special caution | Total-company Forecastであり、Data Center Forecastではない。 |

### S3-EVR-032 — Data Center Energy and Capital Dependency

| Field | Value |
| --- | --- |
| Issuer | NVIDIA Corporation |
| Official source title | *NVIDIA Fiscal 2026 Form 10-K* |
| Publication Event | SEC filed 2026-02-25; accepted 2026-02-25 16:42:19（timezoneはページ上で別途明示されない） |
| Official URL | https://www.sec.gov/Archives/edgar/data/1045810/000104581026000021/nvda-20260125.htm |
| Source position | Recent Developments and demand-risk discussion |
| Applicable Period | FY2026 filing-date dependency and timing context |
| Unit / Currency | N/A |
| Classification | Issuer narrative / capacity dependency and timing boundary; not measured lag / Forecast |
| Issuer definition | AI infrastructure buildoutのData Center / energy / capital dependency |
| Source Fact | NVIDIAは顧客・partnerによるAI infrastructure buildoutにData Center、energy及びcapitalのavailabilityが重要であり、energy capacity拡大は規制・技術・建設課題を伴う複雑なmulti-year processと説明する。 |
| Use boundary | Lead / Lagの開始点・終了点・期間・固定値、capacity量、半導体需要量又は単独因果を設定せず、Phase 2分析を先取りしない。 |
| Cross-sprint reference | `NVIDIACrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Special caution | Phase 1のdependency / timing contextとしてのみ保持する。 |

### S3-EVR-033 — Front-end Utilization Q1 2026

| Field | Value |
| --- | --- |
| Issuer | Renesas Electronics Corporation |
| Official source title | *2026 1Q Presentation Minutes and Q&A* |
| Publication Event | Event 2026-04-24; document publication time / timezone `Unknown` |
| Official URL | https://www.renesas.com/en/document/ppt/2026-1q-presentation-minutes-and-qa |
| Source position | Prepared remarks `utilization rate and CAPEX status`; PDF p.7（viewer P6） |
| Applicable Period | 1Q 2026 Actual-period context |
| Unit / Currency | Percent / percentage-point change |
| Classification | Management-reported operating observation / Actual-period context |
| Issuer definition | Front-end wafer input基準のutilization |
| Source Fact | Front-end wafer input基準の1Q稼働率は約55%、前四半期比約6pt上昇。Nakaの12-inch MCU / 40nm MCU及びSaijoのdigital power製品の需要増加に対応してwafer inputを増加したと説明する。 |
| Use boundary | 全工場又は全設備の稼働率とみなさず、Data Center向けwafer、製品、shipment、revenue又はcapacityを推定しない。`S3-EVR-043`のinvestment Planと混在させない。 |
| Cross-sprint reference | Same event family as Sprint002 `S2-EVR-013` / `023`; Source Fact is different |

### S3-EVR-034 — AI Infra & Compute Reporting Definition

| Field | Value |
| --- | --- |
| Issuer | Renesas Electronics Corporation |
| Official source title | *2026 Capital Market Day Presentation, Minutes and Q&A — 2nd Half* |
| Publication Event | Event 2026-06-25; document publication time / timezone `Unknown` |
| Official URL | https://www.renesas.com/en/document/ppt/2026-capital-market-day-presentation-minutes-and-qa-2nd-half |
| Source position | AI Infra & Compute prepared remarks; PDF pp.31–32（viewer P30–P31） |
| Applicable Period | Current strategy and prospective reporting definition |
| Unit / Currency | N/A |
| Classification | Issuer definition / reporting transition |
| Issuer definition | AI Infra & ComputeはDigital Power、Memory Interface、Control Plane、その他analog componentsを含み、AI / general serversへ提供する |
| Source Fact | AI / non-AIの区別が曖昧になるため、今後は当該businessを`data center revenue`としてreporting and discussingすると説明する。 |
| Use boundary | 過去のIIoT、AI Infra & Compute又は2025 revenueを遡及再分類せず、AI-only、general server及びData Center全体を同一視しない。 |
| Cross-sprint reference | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-035 — AI Infrastructure Grid-to-Core Portfolio

| Field | Value |
| --- | --- |
| Issuer | Renesas Electronics Corporation |
| Official source title | *AI Infra and Compute — 2026 Capital Market Day* |
| Publication Event | Document / event date 2026-06-25; publication time / timezone `Unknown` |
| Official URL | https://www.renesas.com/en/document/ppt/ai-infra-and-compute-2026-capital-market-day |
| Source position | PDF slides 2, 5–6; portfolio at-a-glance and grid-to-core maps |
| Applicable Period | Issuer-labeled Today and Mid-to-Long-Term portfolio strategy |
| Unit / Currency | N/A |
| Classification | Issuer product / architecture definition with phase labels |
| Issuer definition | Grid、ESS / UPS、PSU、rack、xPU board及びcore powerに沿うAI infrastructure portfolio |
| Source Fact | Slide 5は`PORTFOLIO (TODAY)`、slide 6は`PORTFOLIO (MID-TO-LONG TERM)`として、Digital Power、Memory Interface、Control Plane及び関連analog productsをgrid-to-core pathへ配置する。 |
| Use boundary | Phase間の配置を統合しない。Mid-to-Long-Termをcurrent availability / adoptionへ変換せず、Today表示もavailability、shipment、design win又はmarket shareのActual証拠とみなさない。 |
| Cross-sprint reference | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-036 — AI Infrastructure Growth-Driver Relationships

| Field | Value |
| --- | --- |
| Issuer | Renesas Electronics Corporation |
| Official source title | *AI Infra and Compute — 2026 Capital Market Day*; *2026 Capital Market Day Presentation, Minutes and Q&A — 2nd Half* |
| Publication Event | Event / document date 2026-06-25; publication time / timezone `Unknown` |
| Official URL | https://www.renesas.com/en/document/ppt/ai-infra-and-compute-2026-capital-market-day ; https://www.renesas.com/en/document/ppt/2026-capital-market-day-presentation-minutes-and-qa-2nd-half |
| Source position | Deck slide 3; prepared remarks PDF pp.31–32 |
| Applicable Period | Forward-looking management strategy |
| Unit / Currency | N/A |
| Classification | Management strategy / forward-looking relationships |
| Issuer definition | 800V / vertical power、AI xPU / server及びgrid-to-rack complexityに関する三つのgrowth-driver edges |
| Source Fact | 発行者は、800V / vertical architectureからpower content / module opportunity、AI xPU / server増加からmemory solutions、grid-to-rack complexityからMCU / control opportunityへの三つの関係を示す。 |
| Use boundary | 三edgeを結合せず、Actual、測定済み因果、revenue、unit、market share又はLead / Lagへ変換しない。 |
| Cross-sprint reference | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-037 — Next-Generation Rack Power Scenario

| Field | Value |
| --- | --- |
| Issuer | Renesas Electronics Corporation |
| Official source title | *AI Infra and Compute — 2026 Capital Market Day* |
| Publication Event | Document / event date 2026-06-25; publication time / timezone `Unknown` |
| Official URL | https://www.renesas.com/en/document/ppt/ai-infra-and-compute-2026-capital-market-day |
| Source position | PDF slide 7, `Order-of-Magnitude Increase in AI Rack Power Content` |
| Applicable Period | Next-generation / forward-looking scenario |
| Unit / Currency | MW threshold / relative multiplier |
| Classification | Management scenario with third-party market context |
| Issuer definition | Next-generation AI rack power context |
| Source Fact | Next-generation AI rackが1MW超へ向かい、power content per rackが10倍超になるとのforward-looking contextを示す。 |
| Use boundary | 現在のrack population、installed base、market average又は実測需要とみなさず、component又はrevenue数量を算出しない。`S3-EVR-044`と分離する。 |
| Cross-sprint reference | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-038 — 800V GaN / MOSFET Design-in Assertion

| Field | Value |
| --- | --- |
| Issuer | Renesas Electronics Corporation |
| Official source title | *AI Infra and Compute — 2026 Capital Market Day* |
| Publication Event | Document / event date 2026-06-25; publication time / timezone `Unknown` |
| Official URL | https://www.renesas.com/en/document/ppt/ai-infra-and-compute-2026-capital-market-day |
| Source position | PDF slide 8, GaN / MOSFET for 800V architecture |
| Applicable Period | Current product / strategy assertion at event date |
| Unit / Currency | N/A; product specifications are not aggregated |
| Classification | Issuer product / strategy and design-in assertion |
| Issuer definition | 800V architecture向けGaN / MOSFET strategy |
| Source Fact | Renesasは800V向けGaN / MOSFETへ投資し、D-mode GaN及びefficiency / power-density characteristicsを示す。Latest MOSFETがnext-generation boardsへ`designed into`されたと説明する。 |
| Use boundary | Customer / board identity、量産、shipment、revenue、market share又はNVIDIA採用を確定せず、第三者確認済みdesign winとみなさない。 |
| Cross-sprint reference | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-039 — Digital Power Units / Value Illustration

| Field | Value |
| --- | --- |
| Issuer | Renesas Electronics Corporation |
| Official source title | *AI Infra and Compute — 2026 Capital Market Day* |
| Publication Event | Document / event date 2026-06-25; publication time / timezone `Unknown` |
| Official URL | https://www.renesas.com/en/document/ppt/ai-infra-and-compute-2026-capital-market-day |
| Source position | PDF slide 9, `Digital Power Is Our Growth Engine` |
| Applicable Period | 2025-to-Mid-Term management illustration |
| Unit / Currency | Relative multipliers; absolute denominator / value `Unknown` |
| Classification | Issuer management relative-value illustration |
| Issuer definition | Slide-defined units / value comparison |
| Source Fact | Slideは2025からMid-Termへの比較として`>2x More units`及び`>5x More value`を示す。 |
| Use boundary | Entity、currency、absolute base又は実現時期を補完せず、2030 xPU volume、power content、product ASP、revenue forecast又はActual growthと同義化しない。 |
| Cross-sprint reference | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-040 — Memory Interface / Control Opportunity

| Field | Value |
| --- | --- |
| Issuer | Renesas Electronics Corporation |
| Official source title | *AI Infra and Compute — 2026 Capital Market Day* |
| Publication Event | Document / event date 2026-06-25; publication time / timezone `Unknown` |
| Official URL | https://www.renesas.com/en/document/ppt/ai-infra-and-compute-2026-capital-market-day |
| Source position | PDF slide 10, Memory Interface and Control Plane |
| Applicable Period | Forward-looking product opportunity context |
| Unit / Currency | N/A — example component counts are not adopted as quantitative observation |
| Classification | Management strategy / illustrative product-content relationship |
| Issuer definition | AI inferenceに伴うmemory-interface / MCU-control opportunity |
| Source Fact | AI inferenceがCPU / DRAM需要を促しmemory-interface contentを増加させるとの見方と、MCU-based controlの採用が拡大するとの見方を示す。製品構成例の存在contextも提示する。 |
| Use boundary | Renesas shipment、attach rate、revenue、universal BOM、customer configuration又はActual unit demandを推定せず、component countsを数量Factとして採用しない。 |
| Cross-sprint reference | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-041 — Hybrid Manufacturing Strategy

| Field | Value |
| --- | --- |
| Issuer | Renesas Electronics Corporation |
| Official source title | *AI Infra and Compute — 2026 Capital Market Day*; *2026 Capital Market Day Presentation, Minutes and Q&A — 2nd Half* |
| Publication Event | Event / document date 2026-06-25; publication time / timezone `Unknown` |
| Official URL | https://www.renesas.com/en/document/ppt/ai-infra-and-compute-2026-capital-market-day ; https://www.renesas.com/en/document/ppt/2026-capital-market-day-presentation-minutes-and-qa-2nd-half |
| Source position | Deck slide 11; prepared remarks PDF pp.38–39（viewer P37–P38） |
| Applicable Period | Current operating strategy / future capacity response |
| Unit / Currency | N/A |
| Classification | Issuer operating strategy / capacity response narrative |
| Issuer definition | In-house manufacturingとexternal foundriesを組み合わせるhybrid model |
| Source Fact | AI需要がvolatileであり得るとの文脈で、in-house manufacturingとexternal foundriesを組み合わせ、需要に応じてcapacityを追加するmodelを説明する。 |
| Use boundary | Capacity量、foundry identity、wafer commitment、utilization、product allocation又は実現時期を推定せず、供給確保又はcapacity Actualとみなさない。 |
| Cross-sprint reference | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-042 — 800V AI Data Center Architecture Response

| Field | Value |
| --- | --- |
| Issuer | Renesas Electronics Corporation |
| Official source title | *Renesas Powers 800-Volt Direct Current AI Data Center Architecture with Next-Generation Power Semiconductors* |
| Publication Event | 2025-10-13; publication time / timezone `Unknown` |
| Official URL | https://www.renesas.com/en/about/newsroom/renesas-powers-800-volt-direct-current-ai-data-center-architecture-next-generation-power |
| Source position | Announcement body; 800V DC architecture and Renesas product portfolio sections |
| Applicable Period | Product / architecture announcement at publication |
| Unit / Currency | Voltage range / architecture context |
| Classification | Official product / architecture response announcement |
| Issuer definition | NVIDIA発表の800V DC architectureへのRenesas product response |
| Source Fact | 48V–400VのGaN solutions、800Vへ構成可能なstack、MOSFET、drivers及びcontrollersを含むpower portfolioを説明する。 |
| Use boundary | NVIDIA procurement、design win、production deployment、shipment、sales又はcustomer-specific BOMを確定せず、stack可能性を単一productの800V ratingとみなさない。 |
| Cross-sprint reference | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-043 — Capacity Investment Plan Q1 2026

| Field | Value |
| --- | --- |
| Issuer | Renesas Electronics Corporation |
| Official source title | *2026 1Q Presentation Minutes and Q&A* |
| Publication Event | Event 2026-04-24; document publication time / timezone `Unknown` |
| Official URL | https://www.renesas.com/en/document/ppt/2026-1q-presentation-minutes-and-qa |
| Source position | Prepared remarks `utilization rate and CAPEX status`; PDF p.7（viewer P6） |
| Applicable Period | 1Q 2026 decision-based investment / prospective capacity Plan |
| Unit / Currency | JPY billion / percent of decision-based investment |
| Classification | Decision-based investment Plan |
| Issuer definition | AI / data center / digital powerを含むmixed-scope capacity investment decision |
| Source Fact | 1Q decision-based investmentはJPY94bn、その80%はcapacity expansion。AI、data center、digital power applicationsをin-houseで製造するためfront-endを中心に投資し、back-end packages / modules capacityも増加させる計画を説明する。 |
| Use boundary | JPY75.2bnを算出せず、金額又は比率を用途、製品、工程又はfactoryへ配賦しない。Actual cash expenditure、completed capacity又はcommitted productionとみなさない。 |
| Cross-sprint reference | Same event family as Sprint002 `S2-EVR-013` / `023`; Source Fact is different |

### S3-EVR-044 — Anonymous Customer AI Board Power Solution

| Field | Value |
| --- | --- |
| Issuer | Renesas Electronics Corporation |
| Official source title | *AI Infra and Compute — 2026 Capital Market Day*; *2026 Capital Market Day Presentation, Minutes and Q&A — 2nd Half* |
| Publication Event | Event / document date 2026-06-25; publication time / timezone `Unknown` |
| Official URL | https://www.renesas.com/en/document/ppt/ai-infra-and-compute-2026-capital-market-day ; https://www.renesas.com/en/document/ppt/2026-capital-market-day-presentation-minutes-and-qa-2nd-half |
| Source position | Deck slide 7 / PDF p.7（viewer P6）; prepared remarks PDF pp.34–35（viewer P33–P34） |
| Applicable Period | Current issuer assertion at event date |
| Unit / Currency | Illustrative component counts; universal measureではない |
| Classification | Issuer assertion / anonymous customer-board direct product relationship |
| Issuer definition | Leading next-generation AI boardにおけるRenesas total power solution example |
| Source Fact | Digital multiphase core power、IBC及びMOSFETを含むtotal power solutionを提供し、そのperformanceを`our customer`が測定したと説明する。48V IBC例は`>5 Digital controllers` / `>30 MOSFETs`、GPU Power例は`>10 Digital controllers` / `>100 Smart power stages`。 |
| Use boundary | Customer / board identity、test condition、adoption stage、order、shipment、revenue又はproduction deploymentを確定せず、customer測定を第三者独立benchmark又は数量例をuniversal BOMとみなさない。 |
| Cross-sprint reference | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-045 — Product Relative ASP Illustration

| Field | Value |
| --- | --- |
| Issuer | Renesas Electronics Corporation |
| Official source title | *AI Infra and Compute — 2026 Capital Market Day* |
| Publication Event | Document / event date 2026-06-25; publication time / timezone `Unknown` |
| Official URL | https://www.renesas.com/en/document/ppt/ai-infra-and-compute-2026-capital-market-day |
| Source position | PDF slide 9, product-level relative ASP examples |
| Applicable Period | Product / architecture illustration at event date |
| Unit / Currency | Relative ASP multiplier |
| Classification | Issuer management relative-ASP illustration |
| Issuer definition | Standard smart power stageを1xとするproduct comparison |
| Source Fact | `Standard smart power stage (2009-present) = 1x ASP`を基準に、`Dual smart power stage >1.5x`、`Integrated vertical power stage >3x`、`Quad-Phase power tower >8x`を示す。 |
| Use boundary | Currency ASP、realized transaction price、customer mix、shipment、revenue又はmarket shareを算出せず、units / value又はpower content per xPUと同義化しない。 |
| Cross-sprint reference | `RenesasCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |

### S3-EVR-046 — AI Server Business Expansion Explanation

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *Financial Results for FY2025* |
| Publication Event | Document date 2026-05-13; publication time / timezone `Unknown` |
| Official URL | https://fscdn.rohm.com/en/financial/account/2603_presentation_en.pdf |
| Source position | FY2025 Results p.5、operating-profit change explanation |
| Applicable Period | FY2025 Actual / FY2026 Plan / mid-term target context |
| Unit / Currency | N/A — qualitative explanation |
| Classification | Management-reported Actual-period explanation |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMは新製品の立上げ等を背景にAI server businessが拡大したと説明する。 |
| Use boundary | 売上額、数量、顧客、製品別寄与、利益額又はData Center単独成長率を確定しない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `006`–`011`と同一資料だがqualitative Actual-period explanationは別Fact |

### S3-EVR-047 — Computer / Storage SiC Sales Forecast

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *Financial Results for FY2025* |
| Publication Event | Document date 2026-05-13; publication time / timezone `Unknown` |
| Official URL | https://fscdn.rohm.com/en/financial/account/2603_presentation_en.pdf |
| Source position | FY2025 Results p.19、SiC Business Sales Trend |
| Applicable Period | FY2025 Actual / FY2026 Plan / mid-term target context |
| Unit / Currency | Relative multiple (`2.5x`) |
| Classification | Issuer Forecast |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | FY2026にcomputer / storage向け（AI server power supply向け）salesが前年比2.5倍になるとROHMは予測する。 |
| Use boundary | ForecastでありActualではない。Base amount、AI-only比率、customer、units又はmarket shareを補完しない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `005`及び`007`と対象・測定分類が異なる |

### S3-EVR-048 — AI Server Addressable Demand Forecast

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *Financial Results for FY2025* |
| Publication Event | Document date 2026-05-13; publication time / timezone `Unknown` |
| Official URL | https://fscdn.rohm.com/en/financial/account/2603_presentation_en.pdf |
| Source position | FY2025 Results p.23、`ROHM's Addressable Demand Forecast` |
| Applicable Period | FY2025 Actual / FY2026 Plan / mid-term target context |
| Unit / Currency | CAGR (`+48%`) |
| Classification | Issuer research / Forecast |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | AI server向けpower devices（DrMOSを含む）のROHM addressable demandはFY2025–FY2030 CAGR +48%との発行者調査を示す。 |
| Use boundary | ROHM sales、TAM Actual又はthird-party validated forecastではない。Absolute values、share及びrevenueへ変換しない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `008`のthird-party contextはHoldであり取り込まない |

### S3-EVR-049 — Next-Generation AI Server Architecture Scenario

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *Financial Results for FY2025* |
| Publication Event | Document date 2026-05-13; publication time / timezone `Unknown` |
| Official URL | https://fscdn.rohm.com/en/financial/account/2603_presentation_en.pdf |
| Source position | FY2025 Results p.24、current server / next-generation AI server illustration |
| Applicable Period | FY2025 Actual / FY2026 Plan / mid-term target context |
| Unit / Currency | Illustrative board count / kW / component count |
| Classification | Issuer management architecture scenario |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | Illustrationはmain boards 18→72、power consumption 13kW→1,000kW、power components 600→22,000、analog components 300→17,000を示す。 |
| Use boundary | Next generationは2027年頃以降のscenario。Current average、universal BOM、shipment、installed base又は実現済み需要とみなさない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `010` / `011`のsales Factとは別grain |

### S3-EVR-050 — Server Business FY2025 Sales Actual

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *Financial Results for FY2025* |
| Publication Event | Document date 2026-05-13; publication time / timezone `Unknown` |
| Official URL | https://fscdn.rohm.com/en/financial/account/2603_presentation_en.pdf |
| Source position | FY2025 Results p.27、Server Business sales target |
| Applicable Period | FY2025 Actual / FY2026 Plan / mid-term target context |
| Unit / Currency | JPY billion |
| Classification | Source-presented Actual |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | FY2025 Server Business salesはJPY17.0bnと表示される。 |
| Use boundary | `Server Business`はAI server単独又はData Center単独と定義されていない。C&S segment又はAI server revenueと同一視しない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `011`の将来Targetと分離 |

### S3-EVR-051 — Server Business Sales Targets

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *Financial Results for FY2025* |
| Publication Event | Document date 2026-05-13; publication time / timezone `Unknown` |
| Official URL | https://fscdn.rohm.com/en/financial/account/2603_presentation_en.pdf |
| Source position | FY2025 Results p.27、Server Business sales target |
| Applicable Period | FY2025 Actual / FY2026 Plan / mid-term target context |
| Unit / Currency | JPY billion |
| Classification | Issuer Plan / Target |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | Server Business salesはFY2026 JPY25.0bn、FY2028 JPY30.0bn、FY2030 JPY100bn超を目指すと表示される。 |
| Use boundary | Actualではない。FY2028値は2025-11時点planとされ、各targetのassumption、AI-only比率及び達成確率を補完しない。FY2025 Actualと分離する。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `010`のActual及びHold `044`のprior target setと非同義 |

### S3-EVR-052 — 800VDC Architecture and Device Positioning

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM’s 800VDC Architecture Solutions for AI Servers* |
| Publication Event | Official release page display 2025-10-13; publication time / timezone `Unknown` |
| Official URL | https://fscdn.rohm.com/en/products/databook/white_paper/common/800vdc_architecture_solution_for_ai_server_wp-e.pdf |
| Source position | 800VDC white paper p.3、abstract / proposed architecture |
| Applicable Period | Technical architecture / internal analysis at publication |
| Unit / Currency | VDC architecture / qualitative device positioning |
| Classification | Issuer technical architecture definition / internal analysis |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | 800VDC architectureではAC-DC converterをside power rackへ移し、DC-DC converterをIT rackに残す構成を説明し、ROHM internal analysisとしてpower-source側にSiC、IT-rack側にGaNを位置付ける。 |
| Use boundary | Proposed architecture / internal analysisであり、industry standard、deployed system、採用、売上又は優位性の第三者検証ではない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `029`のNVIDIA architecture responseとSource Event / claimが異なる |

### S3-EVR-053 — AI Server Total Solution Strategy

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Group Integrated Report 2025* |
| Publication Event | 2025-11 (month only); publication day / time / timezone `Unknown` |
| Official URL | https://fscdn.rohm.com/en/financial/integrated-report/rohm_group_integrated_report_2025_en_view.pdf |
| Source position | Integrated Report 2025 physical p.26（printed pp.48–49）、IC segment |
| Applicable Period | FY2024 Actual context / medium-term strategy |
| Unit / Currency | N/A — strategy |
| Classification | Issuer strategy / portfolio relationship |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはAI server向けにICとpower devicesをhigh-voltageからlow-voltageまで組み合わせたtotal solutionへ注力すると説明する。 |
| Use boundary | Strategy / portfolio positioningであり、Actual adoption、revenue、unit、customer又はmarket shareではない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `016`のActual mixと別Fact |

### S3-EVR-054 — Computer / Storage Application Share FY2024

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Group Integrated Report 2025* |
| Publication Event | 2025-11 (month only); publication day / time / timezone `Unknown` |
| Official URL | https://fscdn.rohm.com/en/financial/integrated-report/rohm_group_integrated_report_2025_en_view.pdf |
| Source position | Integrated Report 2025 physical p.27（printed pp.50–51）、FY2024 application mix |
| Applicable Period | FY2024 Actual context / medium-term strategy |
| Unit / Currency | JPY billion and application share (%) |
| Classification | Source-presented Actual mix |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | FY2024のDiscrete Semiconductor net sales JPY187bnに対しComputer & Storage application shareは9.1%と表示される。 |
| Use boundary | Shareのみを保持し、金額を機械算出しない。Computer & StorageをAI server又はData Center単独へ配賦しない。既存`EVR-008`のapplication narrativeと同一Factではない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `015` / `018` / `019`と分類が異なる |

### S3-EVR-055 — AI Server Si MOSFET Strategy

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Group Integrated Report 2025* |
| Publication Event | 2025-11 (month only); publication day / time / timezone `Unknown` |
| Official URL | https://fscdn.rohm.com/en/financial/integrated-report/rohm_group_integrated_report_2025_en_view.pdf |
| Source position | Integrated Report 2025 physical p.28（printed pp.52–53）、Si Power Devices |
| Applicable Period | FY2024 Actual context / medium-term strategy |
| Unit / Currency | N/A — strategy |
| Classification | Issuer strategy / product positioning |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはAI server市場でSi MOSFET salesを増加させ、高付加価値MOSFETを投入する方針を示す。 |
| Use boundary | Strategyであり、Actual sales growth、customer adoption、product availability又はcompetitive performanceを確定しない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `015`のportfolio及び`019`のoptical-module R&Dと分離 |

### S3-EVR-056 — AI Server Optical Module Strategy

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Group Integrated Report 2025* |
| Publication Event | 2025-11 (month only); publication day / time / timezone `Unknown` |
| Official URL | https://fscdn.rohm.com/en/financial/integrated-report/rohm_group_integrated_report_2025_en_view.pdf |
| Source position | Integrated Report 2025 physical p.29（printed pp.54–55）、Modules |
| Applicable Period | FY2024 Actual context / medium-term strategy |
| Unit / Currency | N/A — R&D direction |
| Classification | Issuer strategy / R&D direction |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはAI server market拡大を見据え、optical moduleのdevelopment / salesを進める方針を示す。 |
| Use boundary | Power semiconductor demand、commercial adoption、revenue、volume又はnamed customer relationを示さない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Power semiconductor Factとは別のadjacent-product strategy |

### S3-EVR-057 — Murata EcoGaN Adoption

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM’s EcoGaN has been Adopted for AI Server Power Supplies by Murata Power Solutions* |
| Publication Event | 2025-03-05; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?news-title=2025-03-05_news_murata&defaultGroupId=false |
| Source position | 2025-03-05 official news、Murata Power Solutions adoption announcement |
| Applicable Period | Named-customer announcement at publication |
| Unit / Currency | N/A — adoption relationship |
| Classification | Issuer-reported named-customer product adoption |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはEcoGaNがMurata Power Solutionsの5.5kW AI-server power supplyへ採用されたと発表する。 |
| Use boundary | Issuer announcementであり、order、shipment quantity、revenue、market share、exclusive supply又は全Murata PSUへの採用を確定しない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `048`のcustomer production Planとは別Fact |

### S3-EVR-058 — Enterprise / AI Server MOSFET Availability

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Develops Class-Leading Low ON-Resistance, High-Power MOSFETs for High-Performance Enterprise and AI Servers* |
| Publication Event | 2025-04-10; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2025-04-10_news_mosfet |
| Source position | 2025-04-10 official news、product development / availability |
| Applicable Period | Product development / availability / Plan at publication |
| Unit / Currency | Product / voltage / application mapping |
| Classification | Product development Actual / market availability |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはRS7E200BGを12V enterprise-server power supplyのsecondary AC-DC / HSC向け、RS7N200BH及びRS7N160BHを48V AI-server power supplyのsecondary AC-DC向けとして開発し、sourceはonline availabilityを`now`と示す。 |
| Use boundary | 製品別application mappingを保持する。Development / sample availabilityであり、mass-production volume、customer adoption、shipment又はrevenueを示さない。2025 mass-production Planと分離する。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `028`のproduction Planと分離 |

### S3-EVR-059 — AI Server MOSFET Mass-Production Plan

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Develops Class-Leading Low ON-Resistance, High-Power MOSFETs for High-Performance Enterprise and AI Servers* |
| Publication Event | 2025-04-10; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2025-04-10_news_mosfet |
| Source position | 2025-04-10 official news、future production statement |
| Applicable Period | Product development / availability / Plan at publication |
| Unit / Currency | Planned timing (2025) |
| Classification | Issuer Plan |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはAI-server hot-swap circuit向けpower MOSFETのmass productionを2025年中に順次開始する計画を示す。 |
| Use boundary | Planであり実現済みmass productionではない。後続Source Eventによる製品別Actualと自動的に同一化しない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `027`のdevelopment / availability及び後続production Factと非同義 |

### S3-EVR-060 — NVIDIA 800V Architecture Response

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Delivers High-Performance Power Solutions Aligned with NVIDIA 800V HVDC Architecture* |
| Publication Event | Official page display 2025-06-12; URL slug is `2025-06-13_nvidia`; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2025-06-13_nvidia |
| Source position | Official page display 2025-06-12（URL slug `2025-06-13_nvidia`）、NVIDIA 800V HVDC architecture response |
| Applicable Period | Architecture response / assertion at publication |
| Unit / Currency | 800V architecture / portfolio statement |
| Classification | Issuer architecture / portfolio response assertion |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはNVIDIA 800V HVDC architectureをsupportするkey silicon providerの一社であると自社発表し、Si、SiC、GaN及びanalog / module portfolioとの対応関係を示す。 |
| Use boundary | ROHM issuer assertionであり、NVIDIA procurement、design win、shipment、revenue又はexclusive partnershipを確定しない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `030`のanonymous endorsementと同一Source Eventだが別Fact |

### S3-EVR-061 — Anonymous Cloud Provider Endorsement

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Delivers High-Performance Power Solutions Aligned with NVIDIA 800V HVDC Architecture* |
| Publication Event | Official page display 2025-06-12; URL slug is `2025-06-13_nvidia`; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2025-06-13_nvidia |
| Source position | Official page display 2025-06-12（URL slug `2025-06-13_nvidia`）、RY7P250BM passage |
| Applicable Period | Architecture response / assertion at publication |
| Unit / Currency | N/A — anonymous endorsement assertion |
| Classification | Issuer-reported anonymous third-party endorsement assertion |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはRY7P250BMが`major global cloud providers`からendorsedされたと発表する。 |
| Use boundary | Provider数、identity、対象design、評価条件、adoption stage、order、shipment、revenue及びproduction deploymentを確定しない。`ROHM-SFI-041`の単数provider / recommended-component assertionと同一party又はcorroborationとみなさない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `041`のsingle-provider recommendationとparty同一性なし |

### S3-EVR-062 — RY7P250BM Market Release

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Introduces a New MOSFET for AI Servers with Industry-Leading SOA Performance and Low ON-Resistance* |
| Publication Event | 2025-07-01; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2025-07-01_news_mosfet |
| Source position | 2025-07-01 official news、RY7P250BM launch / sales information |
| Applicable Period | Product release / assertion at publication |
| Unit / Currency | Product / voltage / sales-launch date |
| Classification | Product market-release Actual / application positioning |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMは100V MOSFET RY7P250BMをAI-server 48V hot-swap circuit向けにmarket releaseし、Sales Launch Dateを2025-05と表示する。 |
| Use boundary | Product release / issuer application positioningであり、customer adoption、shipment quantity、revenue又はmarket shareを示さない。`030`のrecommendation relationと分離する。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `041`のrecommendation assertionと分離 |

### S3-EVR-063 — RS7P200BM Mass-Production

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM launches wide SOA MOSFET for AI servers in compact 5×6mm package* |
| Publication Event | 2025-11-25; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?news-title=2025-11-25_news_mosfet |
| Source position | 2025-11-25 official news、RS7P200BM mass-production passage |
| Applicable Period | Product production / application at publication |
| Unit / Currency | Production commencement month |
| Classification | Product mass-production Actual |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはRS7P200BMのmass productionを2025-09に開始したと発表する。 |
| Use boundary | Company-wide production volume、shipment、revenue、customer adoption又はAI-server allocationを示さない。Application positioningは`033`へ分離する。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `033`のapplication definitionと分離 |

### S3-EVR-064 — RS7P200BM Application

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM launches wide SOA MOSFET for AI servers in compact 5×6mm package* |
| Publication Event | 2025-11-25; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?news-title=2025-11-25_news_mosfet |
| Source position | 2025-11-25 official news、RS7P200BM application passage |
| Applicable Period | Product production / application at publication |
| Unit / Currency | Product / application mapping |
| Classification | Issuer product / application definition |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはRS7P200BMを48V AI-server hot-swap circuit及びindustrial power supply向けproductとして位置付ける。 |
| Use boundary | Product suitabilityであり、AI-server adoption、shipment、revenue又はActual demandを示さない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `032`のproduction Factとは別grain |

### S3-EVR-065 — GaN Supply-System Decision and Plan

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Strengthens Supply Capability for GaN Power Devices* |
| Publication Event | 2026-02-26; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2026-02-26_news_gan |
| Source position | 2026-02-26 official news、GaN supply capability decision |
| Applicable Period | Supply-system decision / 2027 Plan |
| Unit / Currency | Decision / target year |
| Classification | Issuer supply-system decision / Plan |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはTSMC GaN technologyをROHM Hamamatsuへ移管してin-group production systemを構築することを決定し、AI-server等の需要に対応するため2027年のsystem establishmentを目指す。 |
| Use boundary | Decision / Planであり、technology transfer完了、capacity、wafer volume、AI-server allocation、shipment又はrevenueを示さない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | 既存production FactとSource Event / classificationが異なる |

### S3-EVR-066 — Fifth-Generation SiC Development

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Develops 5th Generation SiC MOSFETs with Approx. 30% Lower On-Resistance at High Temperatures* |
| Publication Event | 2026-04-21; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2026-04-21_news_sic-mosfet |
| Source position | 2026-04-21 official news、5th Generation SiC development passage |
| Applicable Period | Development Actual / sample Plan / application at publication |
| Unit / Currency | Development completion month |
| Classification | Product-development Actual |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMは5th Generation SiC MOSFETのdevelopmentを2026-03に完了したと発表する。 |
| Use boundary | Development completionであり、packaged-product mass production、AI-server adoption、shipment又はrevenueではない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `036` sample Plan、`037` applicationと分離 |

### S3-EVR-067 — Fifth-Generation SiC Sample Plan

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Develops 5th Generation SiC MOSFETs with Approx. 30% Lower On-Resistance at High Temperatures* |
| Publication Event | 2026-04-21; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2026-04-21_news_sic-mosfet |
| Source position | 2026-04-21 official news、sample provision passage |
| Applicable Period | Development Actual / sample Plan / application at publication |
| Unit / Currency | Planned sample timing |
| Classification | Issuer Plan |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMは5th Generation SiC MOSFETを搭載するdiscrete devices / modulesのsamplesを2026-07から提供する計画を示す。 |
| Use boundary | Planでありsample delivery Actualを確定しない。Mass production、customer adoption、shipment又はrevenueへ変換しない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `035` / `037`と別Fact |

### S3-EVR-068 — Fifth-Generation SiC Application

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Develops 5th Generation SiC MOSFETs with Approx. 30% Lower On-Resistance at High Temperatures* |
| Publication Event | 2026-04-21; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2026-04-21_news_sic-mosfet |
| Source position | 2026-04-21 official news、Application Examples |
| Applicable Period | Development Actual / sample Plan / application at publication |
| Unit / Currency | Product / application mapping |
| Classification | Issuer product / application definition |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMは5th Generation SiC MOSFETのapplication exampleにAI-server / Data Center power suppliesを含める。 |
| Use boundary | Application positioningであり、採用、volume、shipment、revenue又はData Center専用productを示さない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `035` / `036`のstage Factと分離 |

### S3-EVR-069 — Anonymous-Customer BBU Adoption

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM’s SiC MOSFET Adopted in BBU for AI Servers as HVDC Architectures Advance* |
| Publication Event | 2026-06-03; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2026-06-03_news_sic-mosfet |
| Source position | 2026-06-03 official news、BBU adoption announcement |
| Applicable Period | Anonymous-customer adoption announcement at publication |
| Unit / Currency | Product / voltage / application relation |
| Classification | Issuer-reported anonymous-customer product adoption |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMは750V SiC MOSFET SCT4013DLLがAI-server power supply向けBBUの±400V power sectionに採用されたと発表する。 |
| Use boundary | Customer / BBU maker identity、order、volume、shipment、revenue、production deployment及びexclusive supplyを確定しない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Other adoption assertionsとcustomer / product / Source Eventが異なる |

### S3-EVR-070 — Super Junction MOSFET Mass-Production

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Launches 600V Super Junction MOSFETs in Surface-Mount Package with High Thermal Performance* |
| Publication Event | 2026-07-09; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2026-07-09_news_super-junction-mosfet |
| Source position | 2026-07-09 official news、600V Super Junction MOSFET production passage |
| Applicable Period | Mass-production Actual / application at publication |
| Unit / Currency | Production commencement month |
| Classification | Product mass-production Actual |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはR60xxXNx / R60xxWNx seriesのmass productionを2026-06から順次開始したと発表する。 |
| Use boundary | Product-family production commencementであり、AI-server allocation、shipment quantity、revenue、customer adoption又はcapacityを示さない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `040`のapplication definitionと分離 |

### S3-EVR-071 — Super Junction MOSFET Application

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Launches 600V Super Junction MOSFETs in Surface-Mount Package with High Thermal Performance* |
| Publication Event | 2026-07-09; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2026-07-09_news_super-junction-mosfet |
| Source position | 2026-07-09 official news、Application Examples |
| Applicable Period | Mass-production Actual / application at publication |
| Unit / Currency | Product / application mapping |
| Classification | Issuer product / application definition |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMは600V Super Junction MOSFET seriesのapplication exampleにAI-server / Data Center power suppliesを含める。 |
| Use boundary | Application positioningであり、採用、shipment、revenue、Data Center専用production又はActual demandを示さない。`039`のproduction Factと分離する。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `039`のproduction Factとは別grain |

### S3-EVR-072 — Anonymous Cloud Provider Recommendation

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Introduces a New MOSFET for AI Servers with Industry-Leading SOA Performance and Low ON-Resistance* |
| Publication Event | 2025-07-01; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2025-07-01_news_mosfet |
| Source position | 2025-07-01 official news、RY7P250BM recommended-component passage |
| Applicable Period | Product release / assertion at publication |
| Unit / Currency | N/A — anonymous recommendation assertion |
| Classification | Issuer-reported anonymous third-party recommendation assertion |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはRY7P250BMが`leading global cloud platform provider`によりrecommended componentとしてcertifiedされたと発表する。 |
| Use boundary | Provider identity、対象design、評価条件、adoption stage、order、shipment、revenue及びproduction deploymentを確定しない。`ROHM-SFI-030`の複数provider endorsement assertionと同一party又はcorroborationとみなさない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `030`とは匿名party、単複、assertion typeが異なり相互corroboration禁止 |

### S3-EVR-073 — AI Data Server Product-Development Plan

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *Financial Results for FY2024* |
| Publication Event | Document date 2025-05-14; publication time / timezone `Unknown` |
| Official URL | https://micro.rohm.com/en/financial/account/2503_41811104_presentation_en.pdf |
| Source position | FY2024 Results p.24、`Solutions for Servers` |
| Applicable Period | FY2024 Actual / FY2025 Plan context |
| Unit / Currency | N/A — development Plan |
| Classification | Issuer product-development Plan |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはAI data-server market向けcoverageを拡大するため、新製品planning / developmentを加速する方針を示す。 |
| Use boundary | Planであり、development completion、Actual sales、customer adoption又はproduct availabilityを示さない。SAM illustrationは`057`へ分離する。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `057`のSAM illustrationと同一pageだが別Fact |

### S3-EVR-074 — AI Data Server Adoption Assertion

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *Financial Results for the First Half of FY2025* |
| Publication Event | Document date 2025-11-07; publication time / timezone `Unknown` |
| Official URL | https://fscdn.rohm.com/en/financial/account/2509_10200916_presentation_en.pdf |
| Source position | FY2025 H1 Results p.29、`Solutions for Servers` |
| Applicable Period | FY2025 H1 / then-current context |
| Unit / Currency | N/A — qualitative adoption assertion |
| Classification | Management-reported current-period qualitative assertion |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはAI data serversを中心にROHM productsのadoptionが急速に進んでいると説明する。 |
| Use boundary | Adoptionの製品、customer、stage、order、shipment、revenue及び数量は未開示。Actual sales growth又はmarket shareとみなさない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Hold `044`のtarget graphicとは別Fact |

### S3-EVR-075 — Murata Data Center PSU Adoption

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *SiC SBDs from ROHM chosen by Murata Power Solutions for Data Center PSUs* |
| Publication Event | 2023-03-07; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2023-03-07_news_murata |
| Source position | 2023-03-07 official news、Murata Power Solutions adoption announcement |
| Applicable Period | Named-customer adoption / production-stage statement at publication |
| Unit / Currency | N/A — adoption relationship |
| Classification | Issuer-reported named-customer product adoption |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはSiC SBD SCS308AHがMurata Power SolutionsのData Center PSUへ採用されたと発表する。 |
| Use boundary | Customer product family、order、shipment quantity、revenue、market share、exclusive supply又は全Murata PSUへの採用を確定しない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `059`のcustomer production-stage assertionと同一Source Eventだが別Fact |

### S3-EVR-076 — GaN Gate-Driver Availability

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Launches an Isolated Gate Driver IC Optimized for High-Voltage GaN Devices* |
| Publication Event | 2025-06-25; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2025-06-25_topics_gate-driver |
| Source position | 2025-06-25 official news、BM6GD11BFJ-LB product status |
| Applicable Period | Development / availability / application at publication |
| Unit / Currency | Product availability |
| Classification | Product-development / availability Actual |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはhigh-voltage GaN向けisolated gate-driver IC BM6GD11BFJ-LBを開発し、sourceは`now available`と示す。 |
| Use boundary | Availabilityであり、mass-production volume、server adoption、shipment、revenue又はGaN-device shareを示さない。Application positioningは`047`へ分離する。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `047`のapplication definitionと分離 |

### S3-EVR-077 — GaN Gate-Driver Server Application

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Launches an Isolated Gate Driver IC Optimized for High-Voltage GaN Devices* |
| Publication Event | 2025-06-25; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2025-06-25_topics_gate-driver |
| Source position | 2025-06-25 official news、Application Examples |
| Applicable Period | Development / availability / application at publication |
| Unit / Currency | Product / application mapping |
| Classification | Issuer product / application definition |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはBM6GD11BFJ-LBとGaN deviceの組合せをserver power supplyを含むhigh-current application向けに位置付ける。 |
| Use boundary | Product suitabilityであり、AI-server専用、adoption、shipment、revenue又はActual demandを示さない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `046`と同一Source Eventだが別Fact |

### S3-EVR-078 — Murata AI Server PSU Production Plan

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM’s EcoGaN has been Adopted for AI Server Power Supplies by Murata Power Solutions* |
| Publication Event | 2025-03-05; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?news-title=2025-03-05_news_murata&defaultGroupId=false |
| Source position | 2025-03-05 official news、Murata 5.5kW PSU production passage |
| Applicable Period | Named-customer announcement at publication |
| Unit / Currency | Planned production year |
| Classification | Named-customer production Plan |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | Murata Power Solutionsの5.5kW AI-server PSUは2025年にmass production開始予定とsourceは説明する。 |
| Use boundary | Planであり、production commencement、order、shipment、volume又はrevenueのActualを示さない。`026`のproduct adoption Factと分離する。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `026` adoption assertionと分離 |

### S3-EVR-079 — GaN Gate Technology Development

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM’s High 8V Gate Withstand Voltage Marking Technology Breakthrough for 150V GaN HEMT* |
| Publication Event | 2021-05-27; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=150v-gan-hemt |
| Source position | 2021-05-27 official news、150V GaN HEMT technology passage |
| Applicable Period | Product-development Actual / sample Plan |
| Unit / Currency | Technology / voltage |
| Classification | Product-development Actual |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMは150V GaN HEMT向け8V gate withstand-voltage technologyを開発したと発表する。 |
| Use boundary | Technology developmentであり、commercial product、adoption、shipment、revenue又はData Center demandを示さない。Sample Planは`050`、application positioningは`058`へ分離する。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `050` sample Plan及び`058` applicationと分離 |

### S3-EVR-080 — GaN Sample-Shipment Plan

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM’s High 8V Gate Withstand Voltage Marking Technology Breakthrough for 150V GaN HEMT* |
| Publication Event | 2021-05-27; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=150v-gan-hemt |
| Source position | 2021-05-27 official news、sample timing passage |
| Applicable Period | Product-development Actual / sample Plan |
| Unit / Currency | Planned sample-shipment month |
| Classification | Issuer Plan |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMは当該150V GaN deviceのsample shipmentを2021-09に予定すると説明する。 |
| Use boundary | Planであり、sample shipment Actual、mass production、customer adoption、revenue又はData Center allocationを示さない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `049` / `058`と同一Source Eventだが別Fact |

### S3-EVR-081 — Delta GaN Strategic Partnership

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM and Delta Electronics Form a Strategic Partnership on Developing Power Devices for Power Supply Systems* |
| Publication Event | 2022-04-28; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2022-04-28_news_ecogan |
| Source position | 2022-04-28 official news、strategic-partnership announcement |
| Applicable Period | Partnership Actual / development and mass-production Plan |
| Unit / Currency | N/A — partnership relation |
| Classification | Named-party development / mass-production partnership Actual |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMとDelta Electronicsはnext-generation GaN power devicesの共同development / mass productionに関するstrategic partnershipを締結した。 |
| Use boundary | Partnership Actualであり、個別customer order、製品採用、shipment、revenue、exclusive supply又はData Center専用relationを示さない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `052` / `053` / `060`と同一Source Eventだがrelation grainが異なる |

### S3-EVR-082 — GaN Mass-Production System

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM and Delta Electronics Form a Strategic Partnership on Developing Power Devices for Power Supply Systems* |
| Publication Event | 2022-04-28; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2022-04-28_news_ecogan |
| Source position | 2022-04-28 official news、150V GaN production-system passage |
| Applicable Period | Partnership Actual / development and mass-production Plan |
| Unit / Currency | Production-system establishment month |
| Classification | Production-system Actual |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMは150V GaN HEMTのmass-production systemを2022-03に確立したと説明する。 |
| Use boundary | Production-system establishmentであり、production volume、Data Center allocation、shipment、customer adoption又はrevenueを示さない。Application positioningは`060`へ分離する。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `061`と同じ2022-03 production transitionに関係する後続のsystem-level statement。`060` application Planとは分離 |

### S3-EVR-083 — Delta 600V GaN Development Plan

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM and Delta Electronics Form a Strategic Partnership on Developing Power Devices for Power Supply Systems* |
| Publication Event | 2022-04-28; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2022-04-28_news_ecogan |
| Source position | 2022-04-28 official news、600V GaN partnership plan |
| Applicable Period | Partnership Actual / development and mass-production Plan |
| Unit / Currency | Voltage / development and mass-production Plan |
| Classification | Named-party development / mass-production Plan |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMとDeltaはpower-supply system向け600V GaN power devicesを共同development / mass productionする方針を示す。 |
| Use boundary | Planであり、development completion、mass-production commencement、Data Center adoption、shipment又はrevenueを示さない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `051` partnership Actualと別Fact |

### S3-EVR-084 — 650V GaN Mass-Production

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Begins Mass Production of 650V GaN HEMTs That Deliver Class-Leading Performance* |
| Publication Event | 2023-05-08; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2023-05-08_news_gan |
| Source position | 2023-05-08 official news、650V GaN HEMT production passage |
| Applicable Period | Mass-production Actual / application / development relation at publication |
| Unit / Currency | Product voltage / production commencement |
| Classification | Product mass-production Actual |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMは650V GaN HEMT GNP1070TC-Z及びGNP1150TCA-Zのmass productionを開始したと発表する。 |
| Use boundary | Product-level commencementであり、production volume、server allocation、shipment quantity、revenue又はcustomer adoptionを示さない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `055` application及び`056` Ancora relationと分離 |

### S3-EVR-085 — 650V GaN Server Application

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Begins Mass Production of 650V GaN HEMTs That Deliver Class-Leading Performance* |
| Publication Event | 2023-05-08; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2023-05-08_news_gan |
| Source position | 2023-05-08 official news、Application Examples |
| Applicable Period | Mass-production Actual / application / development relation at publication |
| Unit / Currency | Product / application mapping |
| Classification | Issuer product / application definition |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMは当該650V GaN HEMTsをserver及びAC adapter等のpower-supply system向けに位置付ける。 |
| Use boundary | ServerはAI server又はData Center単独ではない。Product suitabilityであり、adoption、shipment、revenue又はActual demandを示さない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `054` / `056`と別grain |

### S3-EVR-086 — Ancora GaN Joint Development

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM Begins Mass Production of 650V GaN HEMTs That Deliver Class-Leading Performance* |
| Publication Event | 2023-05-08; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2023-05-08_news_gan |
| Source position | 2023-05-08 official news、joint-development statement |
| Applicable Period | Mass-production Actual / application / development relation at publication |
| Unit / Currency | N/A — joint-development relation |
| Classification | Named-party product-development relationship |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはGNP1070TC-Z / GNP1150TCA-ZをDelta Electronics affiliateのAncora Semiconductorsと共同開発したと発表する。 |
| Use boundary | Direct development relationであり、Deltaによるpurchase、adoption、order、shipment、revenue又はexclusive relationshipを示さない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `051` / `053`のDelta partnershipとはSource Event / product grainが異なる |

### S3-EVR-087 — AI Data Server SAM Illustration

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *Financial Results for FY2024* |
| Publication Event | Document date 2025-05-14; publication time / timezone `Unknown` |
| Official URL | https://micro.rohm.com/en/financial/account/2503_41811104_presentation_en.pdf |
| Source position | FY2024 Results p.24、FY2024–FY2028 SAM illustration |
| Applicable Period | FY2024 Actual / FY2025 Plan context |
| Unit / Currency | Relative multiple (`4x`) |
| Classification | Issuer management relative-market illustration |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはproduct lineup強化によりAI data-server向けserviceable available marketをFY2024からFY2028に4倍へ拡大するillustrationを示す。 |
| Use boundary | SAM definition、absolute value、Actual achievement、sales、share又はcustomer adoptionを示さない。`042`のdevelopment Plan及び後続server-sales targetと同義化しない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `042`のdevelopment Plan及び後続sales targetsと非同義 |

### S3-EVR-088 — GaN Data Center Application

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM’s High 8V Gate Withstand Voltage Marking Technology Breakthrough for 150V GaN HEMT* |
| Publication Event | 2021-05-27; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=150v-gan-hemt |
| Source position | 2021-05-27 official news、application statement |
| Applicable Period | Product-development Actual / sample Plan |
| Unit / Currency | Voltage / application mapping |
| Classification | Issuer technology / application definition |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMは150V GaN HEMT technologyをbase-station / Data Center power-supply circuit向けに位置付ける。 |
| Use boundary | Application positioningであり、commercial product、adoption、shipment、revenue又はActual demandを示さない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `049` / `050`と同一Source Eventだがapplication grain |

### S3-EVR-089 — Murata Data Center PSU Production Assertion

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *SiC SBDs from ROHM chosen by Murata Power Solutions for Data Center PSUs* |
| Publication Event | 2023-03-07; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2023-03-07_news_murata |
| Source position | 2023-03-07 official news、Dr. Longcheng Tan（Murata Power Solutions Senior Electrical Engineer / project leader）statement |
| Applicable Period | Named-customer adoption / production-stage statement at publication |
| Unit / Currency | N/A — production-stage assertion |
| Classification | Named-customer production-stage assertion |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | TanはSCS308AHを採用したD1U front-end AC-DC PSUが`now in mass production`であると説明する。 |
| Use boundary | Named customer statementである。Production volume、ROHM shipment、order、revenue、start date、exclusive supply又は全D1U productへの採用を確定しない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `045` adoption assertionと同一Source Eventだがexternal speaker / production grain |

### S3-EVR-090 — EcoGaN Application Expansion Plan

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM and Delta Electronics Form a Strategic Partnership on Developing Power Devices for Power Supply Systems* |
| Publication Event | 2022-04-28; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=2022-04-28_news_ecogan |
| Source position | 2022-04-28 official news、EcoGaN application passage |
| Applicable Period | Partnership Actual / development and mass-production Plan |
| Unit / Currency | N/A — intended application expansion |
| Classification | Issuer product-family expansion Plan / intended application scope |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMは150V EcoGaN lineupをbase-station / Data Center等のpower circuitへ拡大する見通しを説明する。 |
| Use boundary | Future expansion Planであり、Current availability、Data Center専用production、adoption、shipment、revenue又はActual demandを示さない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `051`–`053`と同一Source Event、`062`とは別Source Event / product wording |

### S3-EVR-091 — GNE10xxTB Production Commencement

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM starts Production of 150V GaN HEMTs: Featuring Breakthrough 8V Withstand Gate Voltage* |
| Publication Event | 2022-03-22; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=150v-gan-hemts |
| Source position | 2022-03-22 official news、GNE10xxTB production passage |
| Applicable Period | Product-production commencement / application at publication |
| Unit / Currency | Product-series production commencement |
| Classification | Product-production commencement Actual |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMは150V GaN HEMT GNE10xxTB seriesのproduction開始を発表する。 |
| Use boundary | Product-series commencementであり、production volume、Data Center allocation、shipment quantity、revenue又はcustomer adoptionを示さない。`052`の後続production-system statementとは別Source Eventで保持する。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `052`は同じ2022-03 production transitionに関係する後続Source Eventのsystem-level statement |

### S3-EVR-092 — GNE10xxTB Data Center Application

| Field | Value |
| --- | --- |
| Issuer | ROHM Co., Ltd. |
| Official source title | *ROHM starts Production of 150V GaN HEMTs: Featuring Breakthrough 8V Withstand Gate Voltage* |
| Publication Event | 2022-03-22; publication time / timezone `Unknown` |
| Official URL | https://www.rohm.com/news-detail?defaultGroupId=false&news-title=150v-gan-hemts |
| Source position | 2022-03-22 official news、Application Examples |
| Applicable Period | Product-production commencement / application at publication |
| Unit / Currency | Product / voltage / application mapping |
| Classification | Issuer product / application definition |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | ROHMはGNE10xxTB seriesをData Center / base-station向け48V input buck-converter circuit等に位置付ける。 |
| Use boundary | Product suitabilityであり、Data Center専用production、adoption、shipment、revenue又はActual demandを示さない。 |
| Cross-sprint reference | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `061`と同一Source Eventだがapplication grain。`060`は後続Plan |



### S3-EVR-093 — AI Data Center Power Revenue Actual

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Annual Report 2025* |
| Publication Event | PDF copy deadline 2025-11-27; publication time / timezone `Unknown` |
| Official URL | [Infineon official Annual Report](https://www.infineon.com/row/public/documents/corporate/investors/annual-reports/2025/2025-annual-report-v01-00-en.pdf) |
| Source position | Annual Report 2025, physical PDF p.50 / viewer P49及びp.8 / P7 |
| Applicable Period | FY2024 / FY2025 |
| Unit / Currency | EUR million / qualitative growth ratio |
| Classification | Source-presented Actual |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | AI-server power-supply components / AI data-center power-supply solutions revenueはFY2024約EUR250mからFY2025 EUR700m超へ増加し、nearly tripledと発行者は説明する。 |
| Use boundary | Source wording差を保持し、PSS segment全体、AI server全体又はindustry revenueへ拡張しない。二期間のSource-presented Actualだが、Forecast / Targetと連結しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | FY2025 results releaseがcorroborating Source Event |

### S3-EVR-094 — AI Data Center Power Revenue Forecast FY2026

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Annual Report 2025* |
| Publication Event | PDF copy deadline 2025-11-27; publication time / timezone `Unknown` |
| Official URL | [Infineon official Annual Report](https://www.infineon.com/row/public/documents/corporate/investors/annual-reports/2025/2025-annual-report-v01-00-en.pdf) |
| Source position | Annual Report 2025, physical PDF p.8 / viewer P7 |
| Applicable Period | FY2026 |
| Unit / Currency | EUR billion |
| Classification | Issuer Forecast |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | FY2026 revenue Forecastを約EUR1bnから約EUR1.5bnへ引き上げたと発行者は説明する。 |
| Use boundary | Actualではない。為替、customer mix、product mix又は達成確率を補完しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `002`のfuture period |
| Corroborating Source Event | Q2 FY2026 Analyst Call Intro Statement — 2026-05-06; [official statement](https://www.infineon.com/row/public/documents/corporate/investors/presentations/2026/2026-05-06-q2-fy26-intro-statement-analyst-call-v01-00-en.pdf), physical PDF p.4 / viewer P3。FY2026 EUR1.5bn再確認のみ。別Fact・独立signal・確度加算なし |

### S3-EVR-095 — Superseded Addressable-Market Forecast

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Annual Report 2025* |
| Publication Event | PDF copy deadline 2025-11-27; publication time / timezone `Unknown` |
| Official URL | [Infineon official Annual Report](https://www.infineon.com/row/public/documents/corporate/investors/annual-reports/2025/2025-annual-report-v01-00-en.pdf) |
| Source position | Annual Report 2025, physical PDF p.8 / viewer P7 |
| Applicable Period | End of decade; superseded on 2026-05-06 |
| Unit / Currency | EUR billion addressable market |
| Classification | Historical issuer addressable-market Forecast |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | Infineon addressable marketはend of decadeにEUR8bn–12bnと発行者は予測した。 |
| Use boundary | Infineon revenue、TAM Actual、market share又はthird-party validated Forecastとみなさない。2026-05-06に`IFX-SFI-042`のper-kW assessmentがこのSAM sizingをreplacedしたため、Current Forecastとして使用しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Power Roadshowにも同じfigure |

### S3-EVR-096 — NVIDIA 800V Joint Development

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG / NVIDIA, *800 V power delivery architecture for future AI server racks*; Infineon Technologies AG, *Annual Report 2025* |
| Publication Event | Official release: 2025-05-20; Annual Report: PDF copy deadline 2025-11-27; publication time / timezone `Unknown` |
| Official URL | [Infineon official release](https://www.infineon.com/press-release/2025/INFXX202505-107); [Infineon official Annual Report](https://www.infineon.com/row/public/documents/corporate/investors/annual-reports/2025/2025-annual-report-v01-00-en.pdf) |
| Source position | 2025-05-20 release and Annual Report 2025 physical PDF p.8 / viewer P7 |
| Applicable Period | At 2025-05-20 publication / future development relation |
| Unit / Currency | Named-party development relationship |
| Classification | Named-party architecture-development relation |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | InfineonとNVIDIAはAI data center向け800 V HVDC power architectureを共同開発している。 |
| Use boundary | Development relationであり、NVIDIA procurement、exclusive supply、order、shipment又はrevenueを確定しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Two official Infineon Source Events; same relationship Fact |

### S3-EVR-097 — PSS Revenue Growth Forecast

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Annual Report 2025* |
| Publication Event | PDF copy deadline 2025-11-27; publication time / timezone `Unknown` |
| Official URL | [Infineon official Annual Report](https://www.infineon.com/row/public/documents/corporate/investors/annual-reports/2025/2025-annual-report-v01-00-en.pdf) |
| Source position | Annual Report 2025, physical PDF p.68 / viewer P67 |
| Applicable Period | FY2026 |
| Unit / Currency | Qualitative segment growth Forecast |
| Classification | Issuer segment Forecast / driver narrative |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | FY2026 PSS revenueはAI data-center power-supply productsのstrong demand momentumによりGroup平均より大幅に速く成長すると発行者はForecastする。 |
| Use boundary | Segment Forecastであり、AI contribution amount、Actual growth又はproduct-level revenueを確定しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Existing S3 matchなし |

### S3-EVR-098 — AI Data Center Capacity Investment Context

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Annual Report 2025* |
| Publication Event | PDF copy deadline 2025-11-27; publication time / timezone `Unknown` |
| Official URL | [Infineon official Annual Report](https://www.infineon.com/row/public/documents/corporate/investors/annual-reports/2025/2025-annual-report-v01-00-en.pdf) |
| Source position | Annual Report 2025, physical PDF p.68 / viewer P67 |
| Applicable Period | FY2026 Forecast / investment Plan |
| Unit / Currency | Mixed investment / cash-flow context |
| Classification | Issuer investment Plan / mixed cash-flow context |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | FY2026 Free Cash Flow Forecastは、Dresden frontend manufacturing及びAI data-center power-supply capacity expansionへのsignificant investment cash outflowsを含む。 |
| Use boundary | Total investmentをAIへ配賦せず、capacity amount、wafer volume、product又はcustomerを補完しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Existing S3 matchなし |

### S3-EVR-099 — PSS Q2 FY2026 Actual

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Q2 FY2026 Analyst Call Intro Statement* |
| Publication Event | 2026-05-06; publication time / timezone `Unknown` |
| Official URL | [Infineon official statement](https://www.infineon.com/row/public/documents/corporate/investors/presentations/2026/2026-05-06-q2-fy26-intro-statement-analyst-call-v01-00-en.pdf) |
| Source position | Q2 FY2026 statement, physical PDF p.4 / viewer P3 |
| Applicable Period | Q2 FY2026 |
| Unit / Currency | EUR billion / EUR million / percent |
| Classification | Segment Actual |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | Q2 FY2026 PSS revenueはEUR1.260bn、Segment Result EUR257m、margin 20.4%と表示される。 |
| Use boundary | PSSはAI単独ではない。AI revenue、product mix又はcustomer contributionへ配賦しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Existing S3 matchなし |

### S3-EVR-100 — PSS AI and Radar Growth Driver

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Q2 FY2026 Analyst Call Intro Statement* |
| Publication Event | 2026-05-06; publication time / timezone `Unknown` |
| Official URL | [Infineon official statement](https://www.infineon.com/row/public/documents/corporate/investors/presentations/2026/2026-05-06-q2-fy26-intro-statement-analyst-call-v01-00-en.pdf) |
| Source position | Q2 FY2026 statement, physical PDF p.4 / viewer P3 |
| Applicable Period | Q2 FY2026 Actual-period explanation |
| Unit / Currency | Qualitative mixed driver |
| Classification | Management-reported Actual-period explanation |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | PSS sequential growthは主にAI power及びradar sensor businessにより牽引されたと発行者は説明する。 |
| Use boundary | AIとradarの寄与を分離せず、amount、growth rate又はcausal shareを算出しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Same event as `008` |

### S3-EVR-101 — AI Business Allocation Condition

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Q2 FY2026 Analyst Call Intro Statement* |
| Publication Event | 2026-05-06; publication time / timezone `Unknown` |
| Official URL | [Infineon official statement](https://www.infineon.com/row/public/documents/corporate/investors/presentations/2026/2026-05-06-q2-fy26-intro-statement-analyst-call-v01-00-en.pdf) |
| Source position | Q2 FY2026 statement, physical PDF p.4 / viewer P3 |
| Applicable Period | Q2 FY2026 current operating condition |
| Unit / Currency | Unquantified allocation condition |
| Classification | Management-reported current operating condition |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | InfineonはAI businessがallocation状態にあると説明する。 |
| Use boundary | Allocationのproduct、customer、quantity、duration、backlog又はunmet demandを補完しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Existing S3 matchなし |

### S3-EVR-102 — Automotive Capacity Redeployment

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Q2 FY2026 Analyst Call Intro Statement* |
| Publication Event | 2026-05-06; publication time / timezone `Unknown` |
| Official URL | [Infineon official statement](https://www.infineon.com/row/public/documents/corporate/investors/presentations/2026/2026-05-06-q2-fy26-intro-statement-analyst-call-v01-00-en.pdf) |
| Source position | Q2 FY2026 statement, physical PDF p.3 / viewer P2 |
| Applicable Period | Q2 FY2026 current action |
| Unit / Currency | Capacity redeployment action |
| Classification | Management capacity redeployment action |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | Infineonはautomotive high-voltage drivetrain向けfrontend manufacturing capacityをAI data-center businessへredeployしていると説明する。 |
| Use boundary | Source businessとdestinationを保持する。Capacity amount、technology、site、product、AI allocation又はcompletionを補完せず、Automotive revenue減少額をAI revenueへ移し替えない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `010` / `041`と同じevent、別Fact |

### S3-EVR-103 — Dedicated AI Power Revenue FY2027 Indication

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Q2 FY2026 Analyst Call Intro Statement* |
| Publication Event | 2026-05-06; publication time / timezone `Unknown` |
| Official URL | [Infineon official statement](https://www.infineon.com/row/public/documents/corporate/investors/presentations/2026/2026-05-06-q2-fy26-intro-statement-analyst-call-v01-00-en.pdf) |
| Source position | Q2 FY2026 statement, physical PDF p.4 / viewer P3 |
| Applicable Period | FY2027 indication |
| Unit / Currency | EUR billion |
| Classification | Issuer indication |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | Dedicated AI power revenueについてFY2027 EUR2.5bn indicationを示す。 |
| Use boundary | Actual又はFY2026 guidanceではない。`indication`をguidance又はTargetへ同義化しない。同時に再確認されたFY2026 EUR1.5bnは`003`のcross-event corroborationに限定し、別Raw又は独立signalとしない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `003`のFY2026 Forecast再確認と同じpassage |

### S3-EVR-104 — GaN Shipment Increase Assertion

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Q2 FY2026 Analyst Call Intro Statement* |
| Publication Event | 2026-05-06; publication time / timezone `Unknown` |
| Official URL | [Infineon official statement](https://www.infineon.com/row/public/documents/corporate/investors/presentations/2026/2026-05-06-q2-fy26-intro-statement-analyst-call-v01-00-en.pdf) |
| Source position | Q2 FY2026 statement, physical PDF pp.4–5 / viewer P3–P4 |
| Applicable Period | Q2 FY2026 current assertion |
| Unit / Currency | Qualitative shipment direction |
| Classification | Management-reported shipment assertion |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | AI data-center applications向けGaNはselected power-supply socketsへshipmentsが増えていると発行者は説明する。 |
| Use boundary | Product、customer、quantity、revenue、production site又はmarket shareを確定しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Existing S3 matchなし |

### S3-EVR-105 — GaN Design-in Pipeline Expansion

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Q2 FY2026 Analyst Call Intro Statement* |
| Publication Event | 2026-05-06; publication time / timezone `Unknown` |
| Official URL | [Infineon official statement](https://www.infineon.com/row/public/documents/corporate/investors/presentations/2026/2026-05-06-q2-fy26-intro-statement-analyst-call-v01-00-en.pdf) |
| Source position | Q2 FY2026 statement, physical PDF pp.4–5 / viewer P3–P4 |
| Applicable Period | Q2 FY2026 current assertion |
| Unit / Currency | Qualitative pipeline direction |
| Classification | Management-reported design-in pipeline assertion |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | GaN design-in pipelineは複数power-conversion stagesへ拡大していると発行者は説明する。 |
| Use boundary | Design-in pipelineをdesign win、order、shipment、revenue又はnamed customer adoptionとみなさない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Same event as `013` |

### S3-EVR-106 — SiC Business Growth Driver

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Q2 FY2026 Analyst Call Intro Statement* |
| Publication Event | 2026-05-06; publication time / timezone `Unknown` |
| Official URL | [Infineon official statement](https://www.infineon.com/row/public/documents/corporate/investors/presentations/2026/2026-05-06-q2-fy26-intro-statement-analyst-call-v01-00-en.pdf) |
| Source position | Q2 FY2026 statement, physical PDF p.5 / viewer P4 |
| Applicable Period | FY2026 |
| Unit / Currency | Qualitative growth range / mixed scope |
| Classification | Mixed-scope growth assertion |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | AI-related demandがFY2026 overall SiC businessのlow-double-digit growthを牽引すると発行者は説明する。 |
| Use boundary | Overall SiC businessはAI単独ではない。AI contribution、base amount又はapplication mixを算出しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Existing S3 matchなし |

### S3-EVR-107 — Per-kW Content Estimate

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Q2 FY2026 Analyst Call Intro Statement* |
| Publication Event | 2026-05-06; publication time / timezone `Unknown` |
| Official URL | [Infineon official statement](https://www.infineon.com/row/public/documents/corporate/investors/presentations/2026/2026-05-06-q2-fy26-intro-statement-analyst-call-v01-00-en.pdf) |
| Source position | Q2 FY2026 statement, physical PDF p.5 / viewer P4 |
| Applicable Period | Current assessment at 2026-05-06 |
| Unit / Currency | USD per kW |
| Classification | Issuer content estimate |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | Rack configurationによりInfineon contentはUSD100–250/kW、current averageは約USD175/kWとのissuer estimateを示す。 |
| Use boundary | Transaction price、universal BOM、revenue、installed capacity又はmarket shareへ変換しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Prior BOM estimates exist with different denominator |

### S3-EVR-108 — Grid-to-Core Architecture

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *First Quarter FY 2026 Quarterly Update* |
| Publication Event | 2026-02-04; publication time / timezone `Unknown` |
| Official URL | [Infineon official presentation](https://www.infineon.com/assets/row/public/documents/corporate/investors/presentations/2026/2026-02-04-q1-fy26-investor-presentation-v01-00-en.pdf) |
| Source position | Q1 FY2026 presentation, physical PDF p.59 / viewer P58 |
| Applicable Period | At 2026-02-04 publication |
| Unit / Currency | Architecture stages / portfolio definition |
| Classification | Issuer architecture / portfolio definition |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | InfineonはAI-related power conversionをgrid-to-coreで扱い、AC/DC、48V / 12V DC/DC及びcore voltage conversionを示す。 |
| Use boundary | Portfolio / architecture definitionであり、Actual adoption、revenue又はindustry-standard architectureではない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Q4 FY2024 / Power Roadshow同family |

### S3-EVR-109 — Single-Phase PSU Availability

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *First Quarter FY 2026 Quarterly Update* |
| Publication Event | 2026-02-04; publication time / timezone `Unknown` |
| Official URL | [Infineon official presentation](https://www.infineon.com/assets/row/public/documents/corporate/investors/presentations/2026/2026-02-04-q1-fy26-investor-presentation-v01-00-en.pdf) |
| Source position | Q1 FY2026 presentation, physical PDF p.60 / viewer P59 |
| Applicable Period | Available at 2026-02-04 publication |
| Unit / Currency | kW / product availability |
| Classification | Product availability Actual at publication |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | 3.3 / 8 / 12 kW single-phase PSUを2026-02-04時点でavailable nowと表示する。 |
| Use boundary | Publication Event時点のavailabilityであり、production volume、adoption、shipment又はrevenueを示さない。Future reference-board roadmapは`043`へ分離する。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | 2024 roadmap及び2026 releaseとcross-event reconciliation required |

### S3-EVR-110 — HV and MV IBC Portfolio

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *First Quarter FY 2026 Quarterly Update* |
| Publication Event | 2026-02-04; publication time / timezone `Unknown` |
| Official URL | [Infineon official presentation](https://www.infineon.com/assets/row/public/documents/corporate/investors/presentations/2026/2026-02-04-q1-fy26-investor-presentation-v01-00-en.pdf) |
| Source position | Q1 FY2026 presentation, physical PDF p.61 / viewer P60 |
| Applicable Period | Current / future portfolio at 2026-02-04 publication |
| Unit / Currency | Portfolio / application definition |
| Classification | Issuer product / application definition |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | Infineonはcurrent / future AI-server rack向けHV / MV IBC portfolioを示す。 |
| Use boundary | Portfolio positioningであり、availability、design win、shipment、revenue又はuniversal architectureを示さない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Existing S3 matchなし |

### S3-EVR-111 — Vertical Power Delivery Loss Illustration

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *First Quarter FY 2026 Quarterly Update* |
| Publication Event | 2026-02-04; publication time / timezone `Unknown` |
| Official URL | [Infineon official presentation](https://www.infineon.com/assets/row/public/documents/corporate/investors/presentations/2026/2026-02-04-q1-fy26-investor-presentation-v01-00-en.pdf) |
| Source position | Q1 FY2026 presentation, physical PDF p.63 / viewer P62 |
| Applicable Period | At 2026-02-04 publication |
| Unit / Currency | Percent engineering illustration |
| Classification | Internal engineering illustration |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | Vertical power deliveryによりsubstrate PDN lossesを追加10–15%削減するとのissuer illustrationを示す。 |
| Use boundary | Internal architecture estimateであり、customer system測定、universal saving、revenue又はadoptionではない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Existing S3 matchなし |

### S3-EVR-112 — AI Data Center Value-Chain Taxonomy

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Powering AI — from the panel to the token* |
| Publication Event | 2025-11-26; publication time / timezone `Unknown` |
| Official URL | [Infineon official presentation](https://www.infineon.com/content/dam/infineon/row/public/documents/corporate/investors/presentations/2025/2025-11-26-power-roadshow-v01-00-en.pdf) |
| Source position | 2025 Power Roadshow, physical PDF p.4 / viewer P3 |
| Applicable Period | At 2025-11-26 publication |
| Unit / Currency | Issuer taxonomy / stages |
| Classification | Issuer value-chain / portfolio taxonomy |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | InfineonはAI data-center power supplyをGrid、Rack、Core、Physical AIへ広げ、SST、SSCB、UPS / ESS、cooling等を配置する。 |
| Use boundary | Issuer taxonomyであり、各productのavailability、adoption、revenue又はsingle segment mappingではない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `017`より広い value-chain scope |

### S3-EVR-113 — Rack Power and Content Scenario

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Powering AI — from the panel to the token* |
| Publication Event | 2025-11-26; publication time / timezone `Unknown` |
| Official URL | [Infineon official presentation](https://www.infineon.com/content/dam/infineon/row/public/documents/corporate/investors/presentations/2025/2025-11-26-power-roadshow-v01-00-en.pdf) |
| Source position | 2025 Power Roadshow, physical PDF p.11 / viewer P10 |
| Applicable Period | Today / 2027+ / 2029+ scenario |
| Unit / Currency | kW per rack / USD per rack |
| Classification | Issuer architecture / content scenario |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | Today約125kW / rack・Infineon content約USD15k、2027+約600kW+、2029+ 1MW超 / rack・content USD100k超というscenarioを示す。 |
| Use boundary | Scenarioであり、fleet average、installed base、shipment、revenue Forecast又はuniversal BOMではない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `016`とdenominator / eventが異なる |

### S3-EVR-114 — AI Server Revenue FY2025 Forecast

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Fourth Quarter FY 2024 Investor Presentation* |
| Publication Event | 2024-11-12; publication time / timezone `Unknown` |
| Official URL | [Infineon official presentation](https://www.infineon.com/content/dam/infineon/row/public/documents/corporate/investors/presentations/2024/2024-11-12-q4-fy24-investor-presentation-v01-00-en.pdf) |
| Source position | Q4 FY2024 presentation, physical PDF p.47 / viewer P46 |
| Applicable Period | FY2025 Forecast |
| Unit / Currency | EUR million |
| Classification | Historical issuer Forecast |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | FY2025 AI revenue in server businessはEUR500m超とのForecastを示す。 |
| Use boundary | Historical Forecastであり、later FY2025 Actualと同義化せず、forecast accuracyの評価前にseries化しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Later `002` Actual exists |

### S3-EVR-115 — AI Server Revenue Two-Year Target

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Fourth Quarter FY 2024 Investor Presentation* |
| Publication Event | 2024-11-12; publication time / timezone `Unknown` |
| Official URL | [Infineon official presentation](https://www.infineon.com/content/dam/infineon/row/public/documents/corporate/investors/presentations/2024/2024-11-12-q4-fy24-investor-presentation-v01-00-en.pdf) |
| Source position | Q4 FY2024 presentation, physical PDF p.47 / viewer P46 |
| Applicable Period | Next two years from 2024-11-12 |
| Unit / Currency | EUR billion / target horizon |
| Classification | Historical issuer Target |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | AI server revenue EUR1bnをnext two years内に達成するTargetを示す。 |
| Use boundary | Targetであり、FY2026 Forecast又はFY2027 indicationと自動的に同一定義・期限へ接続しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Later `003` / `012` require reconciliation |

### S3-EVR-116 — AI Server Rack BOM Estimate

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Fourth Quarter FY 2024 Investor Presentation* |
| Publication Event | 2024-11-12; publication time / timezone `Unknown` |
| Official URL | [Infineon official presentation](https://www.infineon.com/content/dam/infineon/row/public/documents/corporate/investors/presentations/2024/2024-11-12-q4-fy24-investor-presentation-v01-00-en.pdf) |
| Source position | Q4 FY2024 presentation, physical PDF p.49 / viewer P48 |
| Applicable Period | At 2024-11-12 scenario |
| Unit / Currency | USD per rack |
| Classification | Issuer BOM estimate / rack illustration |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | Infineon BOM per AI-server rackはUSD12k–15kまでとのissuer estimateを示す。 |
| Use boundary | Simplified rack configuration依存。Transaction price、universal BOM、shipment、revenue又はmarket shareではない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `016` / `022`とdenominator / configurationが異なる |

### S3-EVR-117 — PSU Availability at 2024 Source Event

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Fourth Quarter FY 2024 Investor Presentation* and *AI data-center PSU roadmap* |
| Publication Event | 2024-11-12 / 2024-05-24; publication time / timezone `Unknown` |
| Official URL | [Infineon official Q4 presentation](https://www.infineon.com/content/dam/infineon/row/public/documents/corporate/investors/presentations/2024/2024-11-12-q4-fy24-investor-presentation-v01-00-en.pdf); [official roadmap release](https://www.infineon.com/press-release/2024/infpss202405-105) |
| Source position | Q4 FY2024 presentation p.50 and 2024-05-24 release |
| Applicable Period | Available at 2024 Source Events |
| Unit / Currency | kW / product availability |
| Classification | Product availability Actual at publication |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | 3 / 3.3 kW PSUは2024 Source Event時点でavailableと示される。 |
| Use boundary | Publication Event時点のstageを保持し、後続availabilityへ遡及更新しない。Future 8 / 12 / >12 kW roadmapは`044`へ分離する。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Q1 FY2026 / 2026 releaseとcross-event reconciliation required |

### S3-EVR-118 — AI Server PSU Performance Assertion

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *AI data-center PSU roadmap* |
| Publication Event | 2024-05-24; publication time / timezone `Unknown` |
| Official URL | [Infineon official release](https://www.infineon.com/press-release/2024/infpss202405-105) |
| Source position | 2024-05-24 release, PSU performance passages |
| Applicable Period | At 2024-05-24 publication / future product Plan |
| Unit / Currency | Percent / kW / W per cubic inch |
| Classification | Issuer product-performance assertion / Plan |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | New-generation PSUは97.5% efficiency、8kW PSUは300kW以上のAI rackをsupport可能、power densityは100 W/in³との発行者説明を示す。 |
| Use boundary | Product / demonstrator condition依存。Third-party benchmark、deployment、shipment、revenue又はall-load efficiencyへ一般化しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Existing S3 matchなし |

### S3-EVR-119 — NVIDIA 800V Architecture Definition

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG / NVIDIA, *800 V power delivery architecture for future AI server racks* |
| Publication Event | 2025-05-20; publication time / timezone `Unknown` |
| Official URL | [Infineon official release](https://www.infineon.com/press-release/2025/INFXX202505-107) |
| Source position | 2025-05-20 release, architecture passage |
| Applicable Period | Future architecture at 2025-05-20 publication |
| Unit / Currency | Voltage / architecture definition |
| Classification | Issuer / named-party technical architecture definition |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | Central 800 V HVDC generationからserver board上のAI chip近傍でpower conversionするarchitectureを説明する。 |
| Use boundary | Future architectureであり、deployment、standard adoption、product purchase又はrevenueではない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `029`とsame event、別Fact grain |

### S3-EVR-120 — AI PSU Reference-Design Introduction

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *AI data center PSU solutions to 30 kW* |
| Publication Event | 2026-06-02; publication time / timezone `Unknown` |
| Official URL | [Infineon official technology news](https://www.infineon.com/technology-news/2026/infpss202606-094) |
| Source position | 2026-06-02 news, solution introduction |
| Applicable Period | At 2026-06-02 publication |
| Unit / Currency | kW / board type |
| Classification | Product / reference-design introduction |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | 50 V rack向け18 kW three-phase PSU reference designと800 VDC / ±400 VDC sidecar向け30 kW PFC evaluation boardを発表する。 |
| Use boundary | Reference design / evaluation boardであり、customer deployment、shipment又はrevenueではない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Q1 roadmapのlater Source Event |

### S3-EVR-121 — AI PSU Performance Assertion

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *AI data center PSU solutions to 30 kW* |
| Publication Event | 2026-06-02; publication time / timezone `Unknown` |
| Official URL | [Infineon official technology news](https://www.infineon.com/technology-news/2026/infpss202606-094) |
| Source position | 2026-06-02 news, performance passages |
| Applicable Period | At 2026-06-02 publication |
| Unit / Currency | kW / peak efficiency percent |
| Classification | Issuer engineering / product-performance assertion |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | 18 kW designは97.5% peak efficiency、30 kW boardは99%超peak efficiency等を発行者は示す。 |
| Use boundary | Topology、load及びtest conditions依存。System-wide efficiency、third-party benchmark、commercial result又はuniversal performanceへ変換しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Same event as `031` |

### S3-EVR-122 — AI PSU Evaluation Availability Plan

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *AI data center PSU solutions to 30 kW* |
| Publication Event | 2026-06-02; publication time / timezone `Unknown` |
| Official URL | [Infineon official technology news](https://www.infineon.com/technology-news/2026/infpss202606-094) |
| Source position | 2026-06-02 news, availability section |
| Applicable Period | Future from 2026-06-02 publication |
| Unit / Currency | Evaluation availability Plan |
| Classification | Evaluation availability Plan |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | 18 kW reference designと30 kW evaluation boardはevaluation向けにsoon availableとされる。 |
| Use boundary | Planであり、availability Actual、mass production、shipment又はcustomer adoptionではない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Same event as `031` / `032` |

### S3-EVR-123 — Intel Sapphire Rapids Power Offering

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Complete power management solutions for next-generation Intel Xeon processors* |
| Publication Event | 2022-03-31; publication time / timezone `Unknown` |
| Official URL | [Infineon official technology news](https://www.infineon.com/technology-news/2022/infpss202203-066) |
| Source position | 2022-03-31 news |
| Applicable Period | Launch / availability at 2022-03-31 publication |
| Unit / Currency | Named-platform offering / availability |
| Classification | Named-platform product-offering launch / availability |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | Intel Sapphire Rapids compute servers向けにXDP controllers、OptiMOS integrated power stages及びIPOL regulatorからなるofferingをlaunchし、available nowと発表する。 |
| Use boundary | Platform-oriented offeringであり、Intel procurement、customer adoption、shipment、revenue又はexclusive relationを確定しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Existing S3 matchなし |

### S3-EVR-124 — NVIDIA XDP710 Speaker Assertion

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *XDP710 Digital hot-swap controller* |
| Publication Event | 2022-11-14; publication time / timezone `Unknown` |
| Official URL | [Infineon official technology news](https://www.infineon.com/technology-news/2022/infpss202211-023) |
| Source position | 2022-11-14 news, Abhijit Datta / NVIDIA statement |
| Applicable Period | At 2022-11-14 publication |
| Unit / Currency | Named external-speaker assertion |
| Classification | Named external-speaker product-requirement assertion |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | NVIDIA speakerはXDP710がHGX Platform product requirementに適合し、design-inしやすいと説明する。 |
| Use boundary | Speaker attributionを保持する。Purchase、production adoption、order、shipment、revenue又はexclusive design winを確定しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Existing S3 matchなし |

### S3-EVR-125 — AI Server BOM Estimate

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Expanding our leadership in Power Systems* |
| Publication Event | 2023-11-27; publication time / timezone `Unknown` |
| Official URL | [Infineon official presentation](https://www.infineon.com/content/dam/infineon/row/public/documents/corporate/investors/presentations/2023/20231127-presentation-power-roadshow-v01-00-en.pdf) |
| Source position | 2023 Power Roadshow, physical PDF p.7 / viewer P6 |
| Applicable Period | At 2023-11-27 publication |
| Unit / Currency | USD per server |
| Classification | Issuer BOM estimate |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | Average Infineon BOM per AI serverはUSD850–1,800とのissuer estimateを示す。 |
| Use boundary | Server configuration依存。`026` rack BOM又は`016` per-kW contentと同義化せず、transaction price、revenue又はmarket shareへ変換しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Different denominator from later estimates |

### S3-EVR-126 — AI Server Revenue FY2024 Forecast

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Expanding our leadership in Power Systems* |
| Publication Event | 2023-11-27; publication time / timezone `Unknown` |
| Official URL | [Infineon official presentation](https://www.infineon.com/content/dam/infineon/row/public/documents/corporate/investors/presentations/2023/20231127-presentation-power-roadshow-v01-00-en.pdf) |
| Source position | 2023 Power Roadshow, physical PDF p.11 / viewer P10 |
| Applicable Period | FY2024 Forecast |
| Unit / Currency | EUR million |
| Classification | Historical issuer Forecast |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | FY2024 AI revenue in server businessはlow triple-digit EUR million amountとのForecastを示す。 |
| Use boundary | Historical ForecastでありActualではない。Later revenue disclosuresとdefinition / period確認なしにseries化しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Earlier event for `024` / `002` |

### S3-EVR-127 — AI Server Revenue CAGR Forecast

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Expanding our leadership in Power Systems* |
| Publication Event | 2023-11-27; publication time / timezone `Unknown` |
| Official URL | [Infineon official presentation](https://www.infineon.com/content/dam/infineon/row/public/documents/corporate/investors/presentations/2023/20231127-presentation-power-roadshow-v01-00-en.pdf) |
| Source position | 2023 Power Roadshow, physical PDF p.11 / viewer P10 |
| Applicable Period | FY2024–FY2029 Forecast |
| Unit / Currency | Percent CAGR |
| Classification | Historical issuer growth Forecast |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | FY2024–FY2029 AI server revenue CAGRは50%超とのForecastを示す。 |
| Use boundary | Actual CAGR、industry growth又はmarket shareではない。Base / endpoint amountを補完しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Existing S3 matchなし |

### S3-EVR-128 — Anonymous Design-Win Assertion

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Expanding our leadership in Power Systems* |
| Publication Event | 2023-11-27; publication time / timezone `Unknown` |
| Official URL | [Infineon official presentation](https://www.infineon.com/content/dam/infineon/row/public/documents/corporate/investors/presentations/2023/20231127-presentation-power-roadshow-v01-00-en.pdf) |
| Source position | 2023 Power Roadshow, physical PDF p.11 / viewer P10 |
| Applicable Period | At 2023-11-27 publication |
| Unit / Currency | Anonymous design-win relationship assertion |
| Classification | Issuer-reported anonymous design-win assertion |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | 複数のNorth American CPU / GPU manufacturers及びcloud providersについてAI server businessのcustomer design winsをgraphicで示す。 |
| Use boundary | Customer identity、product、stage、order、shipment、revenue、win date又はexclusive relationを確定しない。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Existing S3 matchなし |

### S3-EVR-129 — AI Demand-Supply Condition

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Q2 FY2026 Analyst Call Intro Statement* |
| Publication Event | 2026-05-06; publication time / timezone `Unknown` |
| Official URL | [Infineon official statement](https://www.infineon.com/row/public/documents/corporate/investors/presentations/2026/2026-05-06-q2-fy26-intro-statement-analyst-call-v01-00-en.pdf) |
| Source position | Q2 FY2026 statement, physical PDF p.3 / viewer P2 |
| Applicable Period | Q2 FY2026 current condition |
| Unit / Currency | Unquantified demand / supply condition |
| Classification | Management-reported demand / supply condition |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | AI data-center businessではdemandがsupplyをstrongly exceedしていると発行者は説明する。 |
| Use boundary | Product、customer、quantity、period、shortfall、backlog又はrevenue impactを補完しない。`allocation`又はcapacity redeploymentと別Factを維持する。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `010` / `011`と同じevent、別Fact |

### S3-EVR-130 — Market-Sizing Method Replacement

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Q2 FY2026 Analyst Call Intro Statement* |
| Publication Event | 2026-05-06; publication time / timezone `Unknown` |
| Official URL | [Infineon official statement](https://www.infineon.com/row/public/documents/corporate/investors/presentations/2026/2026-05-06-q2-fy26-intro-statement-analyst-call-v01-00-en.pdf) |
| Source position | Q2 FY2026 statement, physical PDF p.5 / viewer P4 |
| Applicable Period | At 2026-05-06 publication |
| Unit / Currency | Measurement-basis change / USD per kW |
| Classification | Issuer measurement / market-sizing method change |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | USD100–250/kW・current average約USD175/kWのcontent assessmentが、従来のend-of-decade EUR8bn–12bn SAM sizingをreplacesすると発行者は説明する。 |
| Use boundary | 新しいabsolute market-size Forecastを作らず、旧SAMと新assessmentを同一series又はgrowth rateへ変換しない。`016`のcontent estimateを測定単位として参照する。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | `004` historical sizing / `016` current content estimate |

### S3-EVR-131 — Three-Phase PSU Roadmap

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *First Quarter FY 2026 Quarterly Update* |
| Publication Event | 2026-02-04; publication time / timezone `Unknown` |
| Official URL | [Infineon official presentation](https://www.infineon.com/assets/row/public/documents/corporate/investors/presentations/2026/2026-02-04-q1-fy26-investor-presentation-v01-00-en.pdf) |
| Source position | Q1 FY2026 presentation, physical PDF p.60 / viewer P59 |
| Applicable Period | Q2 / Q3 2026 roadmap |
| Unit / Currency | kW / board type / quarter |
| Classification | Product roadmap / future reference-board Plan |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | 16+ kWは`Ref. Board Q2 26`、27 kWは`Ref. Board Q3 26`、30 kWは`Topology Eval. Board Q2 26`として、three-phase solutionsのfuture roadmapに表示される。 |
| Use boundary | Source記載のboard typeとtimingを製品別に保持する。Availability Actual、mass production、customer adoption、shipment又はrevenueを示さない。`018`のavailable-now productsと分離する。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | 2026-06-02 later introduction requires stage reconciliation |

### S3-EVR-132 — Historical PSU Availability Roadmap

| Field | Value |
| --- | --- |
| Issuer | Infineon Technologies AG |
| Official source title | Infineon Technologies AG, *Fourth Quarter FY 2024 Investor Presentation* and *AI data-center PSU roadmap* |
| Publication Event | 2024-11-12 / 2024-05-24; publication time / timezone `Unknown` |
| Official URL | [Infineon official Q4 presentation](https://www.infineon.com/content/dam/infineon/row/public/documents/corporate/investors/presentations/2024/2024-11-12-q4-fy24-investor-presentation-v01-00-en.pdf); [official roadmap release](https://www.infineon.com/press-release/2024/infpss202405-105) |
| Source position | Q4 FY2024 presentation p.50 and 2024-05-24 release |
| Applicable Period | Q1 / Q2 2025 and 2026 Plan as of 2024 |
| Unit / Currency | kW / quarter / year |
| Classification | Product availability Plan / roadmap |
| Issuer definition | Upstream Inspection-defined Fact grain; no additional definition inferred |
| Source Fact | 8 kWは`Available in Q1/25`、12 kWは`Available in Q2/25`、12 kW超は`Available in 26`と表示される。2024-05-24 releaseは8 kWのQ1 2025 availability Planをcorroborateする。 |
| Use boundary | Source-exactな製品別timingを保持する。2024 Source Event時点のPlanであり、後続availability Actualへ遡及変換しない。`027`の3 / 3.3 kW current productsと分離する。 |
| Cross-sprint reference | `InfineonCrossSprintCandidateRecheck.v0.1-draft.md` — no identical candidate |
| Related-candidate boundary | Q1 FY2026 / 2026 releaseとcross-event stage reconciliation required |

## 4. 共通状態

### 4.1 Microsoft

以下は`S3-EVR-001`から`S3-EVR-009`の全件に適用する。

| Field | Value |
| --- | --- |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |
| Evidence Status | Draft only; noncanonical |
| Raw Evidence Review | Accepted |
| EVR Independent Review | Accepted |
| Review Record / Finding Reference | `Sprint003MicrosoftEvidenceRegisterIndependentReview.v0.1-draft.md` |
| PIT Mapping | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md`; Independent Review Accepted |

### 4.2 Alphabet

以下は`S3-EVR-010`から`S3-EVR-020`の全件に適用する。

| Field | Value |
| --- | --- |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |
| Evidence Status | Draft only; noncanonical |
| Raw Evidence Review | Accepted — `AlphabetRawEvidenceIndependentReview.v0.1-draft.md` |
| EVR Independent Review | Accepted |
| Review Record / Finding Reference | `Sprint003AlphabetEvidenceRegisterIndependentReview.v0.1-draft.md` |
| PIT Mapping | Registered — `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md`; Independent Review Accepted |

### 4.3 NVIDIA

以下は`S3-EVR-021`から`S3-EVR-032`の全件に適用する。

| Field | Value |
| --- | --- |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |
| Evidence Status | Draft only; noncanonical |
| Raw Evidence Review | Accepted — `NVIDIARawEvidenceIndependentReview.v0.1-draft.md` |
| EVR Independent Review | Accepted |
| Review Record / Finding Reference | `Sprint003NVIDIAEvidenceRegisterIndependentReview.v0.1-draft.md` |
| PIT Mapping | Registered — `S3-PIT-021`–`032`; Independent Review Accepted |

### 4.4 Renesas Electronics

以下は`S3-EVR-033`から`S3-EVR-045`の全件に適用する。

| Field | Value |
| --- | --- |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |
| Evidence Status | Draft only; noncanonical |
| Raw Evidence Review | Accepted — `RenesasRawEvidenceIndependentReview.v0.1-draft.md` |
| EVR Independent Review | Accepted |
| Review Record / Finding Reference | `Sprint003RenesasEvidenceRegisterIndependentReview.v0.1-draft.md` |
| PIT Mapping | Registered — `S3-PIT-033`–`045`; Independent Review Accepted — `Sprint003RenesasPITInventoryIndependentReview.v0.1-draft.md` |

### 4.5 ROHM

以下は`S3-EVR-046`から`S3-EVR-092`の全件に適用する。

| Field | Value |
| --- | --- |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |
| Evidence Status | Draft only; noncanonical |
| Raw Evidence Review | Accepted — `ROHMRawEvidenceIndependentReview.v0.1-draft.md` |
| EVR Independent Review | Accepted |
| Review Record / Finding Reference | `Sprint003ROHMEvidenceRegisterIndependentReview.v0.1-draft.md` |
| PIT Mapping | Registered — `S3-PIT-046`–`092`; Independent Review Accepted — `Sprint003ROHMPITInventoryIndependentReview.v0.1-draft.md` |

### 4.6 Infineon Technologies

以下は`S3-EVR-093`から`S3-EVR-132`の全件に適用する。

| Field | Value |
| --- | --- |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | `No` |
| Evidence Status | Draft only; noncanonical |
| Raw Evidence Review | Accepted — `InfineonRawEvidenceIndependentReview.v0.1-draft.md` |
| EVR Independent Review | Accepted |
| Review Record / Finding Reference | `Sprint003InfineonEvidenceRegisterIndependentReview.v0.1-draft.md` |
| PIT Mapping | Registered — `S3-PIT-093`–`132`; Independent Review Accepted — `Sprint003InfineonPITInventoryIndependentReview.v0.1-draft.md` |

## 5. 禁止変換

- Cloud revenue、Azure revenue又はその成長率をData Center投資、AI需要又は半導体需要の直接指標にしない。
- Property and Equipment additions又はcommitmentsをData Center、server、GPU、networking、power又は半導体へ未開示比率で配賦しない。
- Commitment、Plan、Forecast、Actual-period explanation及びActualを相互に置換しない。
- Microsoft固有の関係を他社又は業界全体へ一般化しない。
- Alphabetの総CapEx、technical infrastructure、gross in-service assets、commitments及びCloud backlogを相互に置換しない。
- Technical-infrastructure investment部分の60 / 40を総CapExへ直接乗じず、GPU / TPU又は半導体購入額を導出しない。
- AlphabetのPlan、Forecast、risk disclosure又はcapacity contextをActual、固定Lead / Lag又は半導体需要Observationへ変換しない。
- Alphabet固有の関係を他社又は業界全体へ一般化しない。
- NVIDIA Data Center revenueをGPU又は半導体単体売上と同一化せず、単一発行者の成長率を業界需要率へ一般化しない。
- NVIDIAの旧Compute / Networkingと新Hyperscale / ACIEを相互配賦せず、FY2026 Actualとdriver narrativeを二重計上しない。
- NVIDIAの連結obligationsをData Center専用額、CapEx、半導体発注、Actual purchase、shipment又はrevenueへ変換しない。
- H20 charge、China market-access narrative及び全社Forecastを相互に置換せず、通常のAI需要循環又はChina総需要へ一般化しない。
- NVIDIAのcapacity / timing contextからLead / Lag又は半導体需要を導出しない。
- RenesasのIndustrial / Infrastructure / IoT ActualをData Center単独売上へ配賦せず、将来の`data center revenue`定義を過去数値へ遡及適用しない。
- Renesasのfront-end utilization、decision-based investment、portfolio、management scenario、relative illustration及びcommercial assertionをActual売上・shipment・capacity又は半導体需要へ相互変換しない。
- JPY94bn / 80%からJPY75.2bnを算出せず、用途、製品、工程又はfactoryへ配賦しない。
- Today / Mid-to-Long-Term portfolioを統合せず、将来map又はproduct掲載をcurrent availability、design win、adoption又はshipment Actualとみなさない。
- NVIDIA 800V architectureへの対応又は`designed into`をNVIDIA procurement、named-customer adoption、量産、shipment又はrevenueとみなさない。
- Anonymous customer-boardのcomponent exampleをuniversal BOM又は需要量へ一般化せず、customer測定を第三者独立benchmarkとみなさない。
- Units / value、relative ASP、power content及びthird-party market forecastを相互に同義化しない。
- ROHMのServer Business、Computer & Storage、Industrial及びAutomotiveを相互配賦せず、AI server又はData Center単独値へ変換しない。
- ROHMのActual、Forecast、Target、Plan、Scenario、Simulation、application definition、product stage及びrelationship assertionを相互に置換しない。
- Anonymous cloud provider、anonymous BBU customer、Murata、Delta及びAncoraの関係を相互に同一化せず、order、shipment、revenue、exclusive supply又はmarket shareへ拡張しない。
- `S3-EVR-082`と`S3-EVR-091`は同じ2022-03 production transitionに関係する非独立観測であり、二度のproduction進展、独立需要signal又はcorroborationによる確度加算として二重計上しない。
- Product availability、sample Plan、mass-production Plan、mass-production commencement及びapplication positioningを、同一Source Eventでも同一Factとみなさない。
- InfineonのPSS、Automotive、SiC及びmixed investment contextをAI server又はData Center単独値へ配賦しない。
- InfineonのActual、Forecast、Target、indication、estimate、scenario、Plan、relationship、application definition及びmanagement assertionを相互に置換しない。
- `S3-EVR-095`のhistorical SAM、`S3-EVR-107`のper-kW content及び`S3-EVR-130`のmeasurement-basis replacementを同一series、growth rate又はmarket shareへ変換しない。
- `S3-EVR-113`、`116`及び`125`のrack scenario、rack BOM及びserver BOMを相互変換せず、configuration / denominator差を維持する。
- `S3-EVR-094`のFY2026 Forecastに対するQ2再確認を別signal又は確度加算とせず、`S3-EVR-103`のFY2027 indicationと同一Factにしない。
- `S3-EVR-096`だけをNVIDIA 800 V HVDC joint-development relationshipのFact ownerとし、`IFX-SFI-029`から別Evidence、二度のrelationship進展又は確度加算を作らない。
- Product availability Actualとfuture roadmap Planを相互置換せず、後続Source Eventを過去時点へ遡及適用しない。
- `AvailableAt`をPublication Event、Applicable Period又はRetrieval Dateから推測しない。
- Evidence IDの発行又はEVR登録を、承認、Canonical化、Catalog採用又は下流利用許可として扱わない。

## 6. ゲート状態

| Gate | Status | Record |
| --- | --- | --- |
| Raw Evidence Independent Review | Completed — Accepted | `MicrosoftRawEvidenceIndependentReview.v0.1-draft.md` |
| EVR Independent Review | Completed — Accepted | `Sprint003MicrosoftEvidenceRegisterIndependentReview.v0.1-draft.md` |
| One-to-one PIT registration | Completed | `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` |
| PIT Independent Review | Completed — Accepted | `Sprint003MicrosoftPITInventoryIndependentReview.v0.1-draft.md` |
| Alphabet Raw Evidence Independent Review | Completed — Accepted | `AlphabetRawEvidenceIndependentReview.v0.1-draft.md` |
| Alphabet EVR Independent Review | Completed — Accepted | `Sprint003AlphabetEvidenceRegisterIndependentReview.v0.1-draft.md` |
| Alphabet one-to-one PIT registration | Completed — Accepted | `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` / `S3-PIT-010`–`020`; `Sprint003AlphabetPITInventoryIndependentReview.v0.1-draft.md` |
| NVIDIA Raw Evidence Independent Review | Completed — Accepted | `NVIDIARawEvidenceIndependentReview.v0.1-draft.md` |
| NVIDIA EVR registration | Completed — Accepted | `S3-EVR-021`–`032` |
| NVIDIA EVR Independent Review | Completed — Accepted | `Sprint003NVIDIAEvidenceRegisterIndependentReview.v0.1-draft.md` |
| NVIDIA one-to-one PIT registration | Completed — Accepted | `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md`; `S3-PIT-021`–`032`; `Sprint003NVIDIAPITInventoryIndependentReview.v0.1-draft.md` |
| Renesas Raw Evidence Independent Review | Completed — Accepted | `RenesasRawEvidenceIndependentReview.v0.1-draft.md` |
| Renesas EVR registration | Completed — Accepted | `S3-EVR-033`–`045` |
| Renesas EVR Independent Review | Completed — Accepted | `Sprint003RenesasEvidenceRegisterIndependentReview.v0.1-draft.md` |
| Renesas one-to-one PIT registration | Completed — Accepted | `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md`; `S3-PIT-033`–`045`; `Sprint003RenesasPITInventoryIndependentReview.v0.1-draft.md` |
| ROHM Raw Evidence Independent Review | Completed — Accepted | `ROHMRawEvidenceIndependentReview.v0.1-draft.md` |
| ROHM EVR registration | Completed — Accepted | `S3-EVR-046`–`092` |
| ROHM EVR Independent Review | Completed — Accepted | `Sprint003ROHMEvidenceRegisterIndependentReview.v0.1-draft.md` |
| ROHM one-to-one PIT registration | Completed — Accepted | `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md`; `S3-PIT-046`–`092`; `Sprint003ROHMPITInventoryIndependentReview.v0.1-draft.md` |
| Infineon Raw Evidence Independent Review | Completed — Accepted | `InfineonRawEvidenceIndependentReview.v0.1-draft.md` |
| Infineon EVR registration | Completed — Accepted | `S3-EVR-093`–`132` |
| Infineon EVR Independent Review | Completed — Accepted | `Sprint003InfineonEvidenceRegisterIndependentReview.v0.1-draft.md` |
| Infineon one-to-one PIT registration | Completed — Accepted | `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md`; `S3-PIT-093`–`132`; `Sprint003InfineonPITInventoryIndependentReview.v0.1-draft.md` |
| AvailableAt determination | Not completed — authority decision required | 全件`TBD — no use` |
| Catalog preparation | Not permitted | Catalog Eligibility `No` |
