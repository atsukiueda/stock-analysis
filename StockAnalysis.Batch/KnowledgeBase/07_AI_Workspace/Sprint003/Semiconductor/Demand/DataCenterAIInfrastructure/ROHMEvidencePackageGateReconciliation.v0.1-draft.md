# Sprint003 ROHM Evidence Package — Gate Reconciliation

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft evidence-package gate reconciliation record |
| Sprint | Sprint003 |
| 対象 | ROHM Co., Ltd. — Data Center / AI Infrastructure |
| Version | 0.1-draft |
| 作成日 | 2026-08-09 |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md` |
| Review Record | `ROHMEvidencePackageGateReconciliationIndependentReview.v0.1-draft.md` |
| Authority boundary | 本記録は既存成果物の状態を照合する。新しいFact、ID、承認権限、`AvailableAt`又はCatalog適格性を作らない。 |

> **利用境界：** 本記録のGate整合又はCompany-level exploration closureは、Knowledge Catalog、DDL、Entity、Database、ML、バックテスト、Decision Engine、Advisor又は投資利用を許可しない。

## 1. 目的と範囲

ROHMについて、公式Source探索、Cross-sprint照合、Source Fact Inspection、Raw Evidence、Evidence Register及びPIT Inventoryが、承認済みの順序・件数・識別子・利用境界で閉じているかを横断確認する。

本記録はROHMのEvidence acquisition packageだけを対象とする。Infineon、Definition and Comparability Matrix、Core Company Research、Industry Report及びSprint003 Phase 1 Closureは対象外である。

## 2. Reviewed Artifact Chain

| Stage | Artifact / ID range | Status before this reconciliation |
| --- | --- | --- |
| Research Design | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md` | Project Director Accepted; Draft / noncanonical |
| Stage 0 Cross-sprint Bridge | `Sprint003DataCenterAIInfrastructureCrossSprintBridge.v0.1-draft.md` | Independent Review Accepted |
| Official Source Inventory | `Sprint003DataCenterAIInfrastructureOfficialSourceInventory.v0.1-draft.md` | Location Search Review Accepted; content assessmentは企業別Artifactへ委譲 |
| Source Fact Inspection | `ROHMSourceFactInspection.v0.1-draft.md` | Independent Review Accepted |
| Candidate-level recheck | `ROHMCrossSprintCandidateRecheck.v0.1-draft.md` | Independent Review Accepted |
| Raw Evidence | 47 `ROHM_*RawEvidence.v0.1-draft.md` artifacts | Package Independent Review Accepted |
| Raw Package Index | `ROHMRawEvidencePackageIndex.v0.1-draft.md` | Included in `ROHMRawEvidenceIndependentReview.v0.1-draft.md` — Package Independent Review Accepted; Draft / noncanonical |
| Evidence Register | `S3-EVR-046`–`S3-EVR-092` | Independent Review Accepted |
| PIT Inventory | `S3-PIT-046`–`S3-PIT-092` | Independent Review Accepted |

## 3. Candidate and Identifier Reconciliation

| Category | Count | IDs / boundary | Result |
| --- | ---: | --- | --- |
| Inspected candidates | 62 | `ROHM-SFI-001`–`062` | Complete; no missing or duplicate local ID |
| Reference-only | 4 | `ROHM-SFI-001`–`004` | Existing Sprint001 / 002 Evidenceを参照し、Sprint003で再発行しない |
| Raw-eligible — Proceed | 11 | `013`、`015`、`031`、`033`、`037`、`040`、`046`、`047`、`055`、`058`、`062` | Accepted recheck後、一候補一Rawへ変換 |
| Raw-eligible — Proceed with caution | 36 | `005`–`007`、`009`–`011`、`016`、`018`、`019`、`026`–`030`、`032`、`034`–`036`、`038`、`039`、`041`–`043`、`045`、`048`–`054`、`056`、`057`、`059`–`061` | 各caution boundaryを保持して一候補一Rawへ変換 |
| Hold | 11 | `008`、`012`、`014`、`017`、`020`–`025`、`044` | Raw未作成、EVR / PIT ID未発行 |
| Raw Evidence | 47 | 47 `ROHM_*RawEvidence.v0.1-draft.md` artifacts | Raw-eligible集合と一対一 |
| Evidence records | 47 | `S3-EVR-046`–`092` | 一意・連続、Rawと一対一 |
| PIT records | 47 | `S3-PIT-046`–`092` | 同番号EVR及びRawと一対一 |

```text
62 inspected candidates
= 4 reference-only
 + 47 Raw-eligible
 + 11 Hold

47 Raw-eligible
= 47 Raw Evidence
= 47 Evidence Register rows
= 47 PIT rows
```

## 4. Gate Sequence Reconciliation

| Gate | Required predecessor | Evidence | Result |
| --- | --- | --- | --- |
| Official Source location search | Accepted Research Design | Official Source Inventory / Stage 0 review | Satisfied |
| Source Fact Inspection review | Official Source Inventory | `ROHMSourceFactInspectionIndependentReview.v0.1-draft.md` | Accepted |
| Candidate-level duplicate recheck | Accepted Source Fact Inspection | `ROHMCrossSprintCandidateRecheckIndependentReview.v0.1-draft.md` | Accepted |
| Raw Evidence review | Accepted candidate-level recheck | `ROHMRawEvidenceIndependentReview.v0.1-draft.md` | Accepted |
| EVR registration and review | Accepted Raw Evidence | `S3-EVR-046`–`092`; `Sprint003ROHMEvidenceRegisterIndependentReview.v0.1-draft.md` | Accepted |
| PIT registration and review | Accepted EVR | `S3-PIT-046`–`092`; `Sprint003ROHMPITInventoryIndependentReview.v0.1-draft.md` | Accepted |
| AvailableAt determination | Applicable authority decision | 全47件`TBD — no use` | Not completed; no use |
| Catalog preparation | AvailableAt及び後続Research / approval gates | 全47件Catalog Eligibility `No` | Not permitted |

暗黙のGate遷移、先行ID発行又は自己承認は確認されない。

## 5. Fact-grain and Boundary Reconciliation

次の主要な非同義境界をInspection、Raw、EVR及びPITで維持している。

- FY2025 Results：qualitative expansion explanation、SiC sales Forecast、addressable-demand Forecast、architecture scenario、FY2025 Server Business Actual及びfuture Targets。
- Integrated Report：total-solution strategy、Computer & Storage Actual share、Si MOSFET strategy及びoptical-module R&D direction。
- `026/048`：Murata EcoGaN adoption assertionとcustomer production Plan。
- `027/028`：product development / availabilityとmass-production Plan。
- `029/030`：NVIDIA architecture responseとanonymous cloud-provider endorsement。
- `030/041`：plural-provider endorsementとsingle-provider recommended-component assertion。Party同一性又は相互corroborationを主張しない。
- `031/041`：RY7P250BM market releaseとanonymous recommendation relation。
- `032/033`、`035/036/037`、`039/040`及び`046/047`：production又はdevelopment stage、Plan及びapplication definition。
- `034`：technology移管・in-group production-system構築のDecisionと2027 establishment Plan。
- `042/057`：product-development Planとrelative SAM illustration。
- `045/059`：Murata adoption assertionとDr. Longcheng Tanのcustomer production-stage assertion。
- `049/050/058`：GaN technology development、sample Plan及びapplication definition。
- `051/052/053/060`：Delta partnership、production-system Actual、600V joint Plan及びfuture application-expansion Plan。
- `054/055/056`：650V GaN mass-production Actual、server application及びAncora joint-development relation。
- `061/062`：GNE10xxTB production commencementとapplication definition。
- `052/061`：別Source Event / 別Fact grainだが、同じ2022-03 production transitionに関係する非独立観測。二度の進展、独立需要signal又はcorroborationによる確度加算として二重計上しない。

また、次の変換を禁止したまま維持している。

- Server Business、Computer & Storage、Industrial及びAutomotiveを相互配賦せず、AI server又はData Center単独値へ変換しない。
- Actual、Forecast、Target、Plan、Scenario、Simulation、application、product stage及びrelationship assertionを相互に置換しない。
- Anonymous provider / customer、Murata、Delta及びAncoraの関係を、order、shipment、revenue、exclusive supply又はmarket shareへ拡張しない。
- NVIDIA architecture responseをprocurement、design win又はcommercial deploymentへ変換しない。
- Product availability、sample Plan、production Plan、production commencement及びapplication positioningを同一化しない。
- Relative multiplier、CAGR、component illustration又はmixed-scope valueからabsolute demand、BOM、sales又はsupplier shareを導出しない。

## 6. Company-level Exploration Closure Assessment

| Closure criterion | Evidence | Assessment |
| --- | --- | --- |
| Minimum Source Setの公式場所を確認した | Official Source Inventory、FY2024 / FY2025 results、Integrated Report、white paper及び2021–2026 official newsroom | Satisfied |
| 確認資料、検索語、対象期間、結果及び不足を記録した | Official Source Inventory、Source Fact Inspection §2 / §2.1 | Satisfied |
| Cross-sprint重複確認を完了した | Stage 0 Bridge及びcandidate-level recheck | Satisfied |
| Source Fact候補とGapを分離した | 62候補のDisposition、Excluded transformations、Relationship Assessment及びGap | Satisfied |
| 追加検索を限定した | Hold 11件をprovenance、method、scope、target reconciliation又はcut-off version identityへ限定 | Satisfied |

**Assessment:** ROHMのCompany-level Phase 1 exploration closure criteriaはEvidence acquisitionの範囲で満たされている。

これはCore Company Research、Definition and Comparability Matrix、Industry Report又はSprint003 Phase 1全体の完了を意味しない。

## 7. Residual Gaps and Non-blocking Holds

| Item | Current state | Effect |
| --- | --- | --- |
| Publication time / timezone | 公式資料で`Unknown` | `AvailableAt = TBD — no use`を維持する。Evidence package completionを妨げない。 |
| `ROHM-SFI-008` | Hold — hyperscaler CAPEX chartのsource-by-source provenance未照合 | ROHM demand / sales又はcross-issuer Factへ変換しない。 |
| `ROHM-SFI-012`、`020`–`022`、`024`–`025` | Hold — dynamic pageのcut-off exact-content identity未解決 | 2026-08-09取得本文を2026-07-30時点FactとしてRaw化しない。 |
| `ROHM-SFI-023` | Hold — forecast definition / provenance不足 | Forecast source、base year、geography、product scope、currency basis又は`additional market` definitionを補完せず、ROHM demand又はsalesへ変換しない。 |
| `ROHM-SFI-014` | Hold — topology / simulation method固有 | Measured system performance又は単一efficiency Factへ統合しない。 |
| `ROHM-SFI-017` | Hold — forecast definition / provenance不足 | ROHM addressable demand又はsalesへ変換しない。 |
| `ROHM-SFI-044` | Hold — prior target graphicと後続Actual / Targetのdefinition・numeric reconciliation未完了 | Continuous target seriesとしてRaw化しない。 |
| AI server / Data Center単独Actual売上 | Server Business及びComputer & Storageはmixed scope | 未開示配賦を行わずGapとして保持する。 |
| Customer quantities / revenue | Adoption、endorsement、recommendation又はproduction-stage assertionはあるが数量・売上未開示 | Commercial magnitudeを推定しない。 |
| Hyperscaler investmentからROHM salesへの定量関係 | 記録済みSource Setでは確認できない | 直接因果、倍率又はLead / Lagを作らない。 |

Negative Evidenceは、調査cut-offまでに記録した公式Source Setで確認できなかったことだけを意味し、当該関係又は資料の不存在を証明しない。

## 8. Reconciliation Disposition

**Disposition: Evidence Package Gate Accepted — Independent Review Accepted**

ROHMのEvidence acquisition chainはSource探索からPITまで順序どおり完了し、各下位独立レビューはAcceptedである。件数、ID、相互参照、Fact grain及び利用境界に作成者確認上の不整合はない。

本Gateの独立レビューAccepted後もPackageはDraft / noncanonicalであり、全47件は`AvailableAt = TBD — no use`、Catalog Eligibility `No`である。Core Company Research等の後続Researchへ接続できるが、Catalog、DDL又は下流利用へは進めない。
