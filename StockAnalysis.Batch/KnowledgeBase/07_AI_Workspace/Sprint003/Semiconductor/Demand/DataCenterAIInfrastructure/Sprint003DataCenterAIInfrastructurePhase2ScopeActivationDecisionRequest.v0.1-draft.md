# Sprint003 Data Center / AI Infrastructure — Phase 2 Scope Activation Decision Request

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft decision request / Gate P2-2 consideration package |
| Sprint | Sprint003 |
| Research Domain | Semiconductor — Demand — Data Center / AI Infrastructure |
| Gate | P2-2 — Eligibility Review and Scope Activation Decision |
| Version | 0.1-draft |
| 作成日 | 2026-08-11 |
| Decision Authority | Project Director又は明示的な委任記録を持つAccountable authority |
| 状態 | Draft — Independent Review Accepted; Project Director Option A subsequently recorded; noncanonical |
| Governing Design | `Sprint003DataCenterAIInfrastructurePhase2ScopeDesign.v0.1-draft.md` — Scope Accepted |
| Pre-check Authority | `Sprint003DataCenterAIInfrastructurePhase2ScopeDecisionRecord.v0.1-draft.md` — Gate P2-1 authorized |
| Eligibility Inventory | `Sprint003DataCenterAIInfrastructurePhase2CandidateEligibilityInventory.v0.1-draft.md` |
| Eligibility Review | `Sprint003DataCenterAIInfrastructurePhase2CandidateEligibilityIndependentReview.v0.1-draft.md` — six candidates conditions 1–3 Accepted |
| Review Record | `Sprint003DataCenterAIInfrastructurePhase2ScopeActivationDecisionRequestIndependentReview.v0.1-draft.md` |
| Requested Decision Record | `Sprint003DataCenterAIInfrastructurePhase2ScopeActivationDecisionRecord.v0.1-draft.md` — Option A recorded 2026-08-13 |
| AvailableAt | `TBD — no use` |
| Catalog Eligibility | No |

> **権限境界：** 本文書は6候補のGate P2-1結果を再照合し、Gate P2-2 Scope Activation Decisionを依頼するDraftである。本文書の作成、推奨又は独立reviewはcondition 4、Scope Activation、Research開始、追加Evidence、Evidence / PIT ID、AvailableAt、Catalog又は下流利用を成立させない。

## 1. 判断を依頼する事項

Phase 2 Scope Design §8 Gate P2-2に基づき、conditions 1–3の独立reviewがAcceptedとなった次の6候補を、Memory / Storage及びNetwork / Opticalの2製品群に限定したactive Research Scopeへ追加するかを判断いただきたい。

- Micron Technology
- SK hynix
- Samsung Electronics
- Kioxia Holdings / Kioxia Corporation
- Broadcom
- Marvell Technology

Project Director又は明示的な委任記録を持つAccountable authorityが、conditions 1–3の全件Metを確認し、独立した`Sprint003DataCenterAIInfrastructurePhase2ScopeActivationDecisionRecord.v0.1-draft.md`へscope delta、research cut-off、authority、date、rationale及びexclusionsを記録した場合にのみcondition 4が成立する。本Request又はReview Recordへの記入ではcondition 4は成立しない。

## 2. Gate P2-2 Reconciliation

### 2.1 Candidate result

| Candidate | Product family | Condition 1 | Condition 2 | Condition 3 | Independent review | Condition 4 |
| --- | --- | --- | --- | --- | --- | --- |
| Micron Technology | Memory / Storage — HBM、DRAM / LPDDR、NAND / Data Center SSD | Met | Met | Met | Accepted — C0 / H0 / M0 / L0 | Pending |
| SK hynix | Memory / Storage — HBM、server DRAM / SOCAMM、NAND / Data Center eSSD | Met | Met | Met | Accepted — C0 / H0 / M0 / L0 | Pending |
| Samsung Electronics | Memory / Storage — HBM、server DRAM / SOCAMM、V-NAND enterprise SSD | Met | Met | Met | Accepted — C0 / H0 / M0 / L0 | Pending |
| Kioxia Holdings / Kioxia Corporation | Memory / Storage — NAND、GP / CM Series、enterprise / Data Center SSD | Met | Met | Met | Accepted — C0 / H0 / M0 / L0 | Pending |
| Broadcom | Network / Connectivity — Ethernet switching、AI NIC、optical DSP / optics、retimer、PCIe connectivity | Met | Met | Met | Accepted — C0 / H0 / M0 / L0 | Pending |
| Marvell Technology | Network / Optical — optical DSP / SerDes、switching、PCIe / CXL switch / retimer | Met | Met | Met | Accepted — C0 / H0 / M0 / L0 | Pending |

conditions 1–3はCandidate単位で全18件Met、独立Evidence / Knowledge / Traceability reviewは6社すべて最終finding 0でAcceptedである。Reference-only、Hold又はNot eligible候補はない。Reviewerはcondition 4を評価又は成立させていない。

### 2.2 Candidate decision trace

| Candidate | Condition 1 — material gap summary | Condition 2 — official direct-relation Source Event summary | Inventory / Review locator |
| --- | --- | --- | --- |
| Micron Technology | issuer-specific HBM / DRAM / NAND / Data Center SSDのdefinition、stage、platform relation及びdenominatorがPhase 1で未被覆 | Micron official AI Data Center portfolio source（2026-06-01）及びHBM3E / SOCAMM / NVIDIA platform source（2025-03-18） | Inventory §3 / Eligibility Review §§2–3 |
| SK hynix | issuer-specific HBM / server DRAM / NAND / eSSDの用途、stage、platform relation及びdenominatorが未被覆 | SK hynix official MWC 2026 source（2026-03-05） | Inventory §4 / Eligibility Review §§4–5 |
| Samsung Electronics | issuer-specific HBM / server DRAM / NAND / enterprise SSDのAI Infrastructure用途、stage及びnamed-platform relationが未被覆 | Samsung official GTC 2026 source（2026-03-17）及びPM1763 source（2026-07-08） | Inventory §5 / Eligibility Review §§6–7 |
| Kioxia Holdings / Kioxia Corporation | 日本株Memory issuerのNAND / enterprise / Data Center SSD、AI storage relation及びstageが未被覆 | Kioxia official GP Series / NVIDIA Storage-Next source（2026-03-17）及び10th-generation BiCS source（2026-07-03） | Inventory §6 / Eligibility Review §§8–9 |
| Broadcom | issuer-specific Ethernet switching / NIC / optical DSP / retimer / PCIeのAI network用途、stage及びrelationship grainが未被覆 | Broadcom official Tomahawk 6 source及びOFC 2026 connectivity source（ともに2026-03-12） | Inventory §7 / Eligibility Review §§10–11 |
| Marvell Technology | issuer-specific optical DSP / SerDes / switch / retimer / PCIe-CXL product-stage及びAEC / AOC partner-enablement grainが未被覆 | Marvell official 1.6T optical DSP source（2026-03-12）及びStructera S PCIe 6.0 source（2026-03-17） | Inventory §8 / Eligibility Review §§12–13 |

この表はP2-1 Accepted recordへのdecision traceであり、新規Source Fact、Evidence又はResearch synthesisを生成しない。Source identity、URL、position、source-exact statement及びprovisional grainの完全記録は各Inventory locatorを正とする。

### 2.3 Breadth and product-family control

| Control | Design limit | Proposed activation | Result |
| --- | ---: | ---: | --- |
| New issuer | 最大6社 | 6社 | Within cap |
| Active product family | 最大2群 | Memory / Storage、Network / Optical | Within cap |
| Deferred scope | 追加不可 | 追加なし | Preserved |

Analog / Mixed Signal / Embedded、追加Company、Semiconductor Manufacturing Equipment、材料、Cooling、Data Center construction、Value Chain、Catalog、DDL、ML、backtest及び投資利用はactive scopeへ含めない。

### 2.4 Cut-off reconciliation

- Gate P2-0 Pre-check cut-off: `2026-08-11 23:59 JST`
- Research Team recommendation: active research cut-offも同時点を継承する。
- cut-off更新は本Requestの既定推奨に含めない。
- Authorityが更新を選ぶ場合は、追加Sourceの対象範囲、Publication Event範囲、理由、重複再確認及びconditions 1–3再review要否をDecisionへ明記する。無記録の更新は認めない。

## 3. Proposed Active Scope Delta

### 3.1 Common period, geography and source boundary

- Period: FY2021以降、主要分析期間FY2022以降。各issuerのfiscal period、Publication Event及びApplicable Periodを保持する。
- Active research cut-off: Authorityが別Decision Recordで明示する。Option A recommendationは`2026-08-11 23:59 JST`の継承である。
- Geography: Global。地域、customer又は用途別allocationは公式Sourceが直接分離する場合だけ扱い、未開示配賦を行わない。
- Source: issuer公式Annual Report、regulatory filing、results material、Investor Day、IR / Newsroom / product sourceに限定する。
- Phase 1 / cross-sprint: read-only。既存Fact / IDを再発行せず、同一Source Event / position / grainはReference-onlyとする。

### 3.2 Candidate-specific delta and exclusions

| Candidate | Permitted active scope | Required exclusions / non-claims |
| --- | --- | --- |
| Micron Technology | Micron公式SourceがAI / Data Center / AI server又はnamed platformへ直接結び付けるHBM、DRAM / LPDDR、NAND / Data Center SSDのproduct、application、stage grain | market share / ranking、industry total、price / capacity / bit / unit換算、未開示AI専用revenue、cross-source supplier benefit、Phase 1 ID継承を禁止する。 |
| SK hynix | SK hynix公式SourceがAI / Data Center / server / GPU module又はplatformへ直接結び付けるHBM、server DRAM / SOCAMM、NAND / Data Center eSSDのproduct、application、stage、relation grain | leadership / market share / ranking、industry total、price / capacity / bit / unit換算、未開示AI専用revenue、anonymous identity推定、cross-source supplier benefit、Phase 1 ID継承を禁止する。 |
| Samsung Electronics | Samsung公式SourceがAI Infrastructure / Data Center / AI-HPC server又はnamed platformへ直接結び付けるHBM、server DRAM / SOCAMM、V-NAND enterprise SSDのproduct、application、stage、relation grain | Device Solutions全体、Foundry / Logic / Packaging、mobile / edge memory、market share / ranking、industry total、未開示AI revenue、anonymous identity推定、cross-source supplier benefit、Phase 1 ID継承を禁止する。 |
| Kioxia Holdings / Kioxia Corporation | NAND flash、GP / CM Series、enterprise / Data Center SSD及びNVIDIA Storage-Next / AI storage relation。Holdingsのfinancial SourceとCorporationのproduct Sourceのissuerを保持する。 | Consumer / mobile storage、enterprise storage全体のAI配賦、market share / ranking、未開示AI revenue、Legacy inventory Fact再発行、cross-source supplier benefit、Phase 1 ID継承、sampleからmass production / adoption / revenueへの昇格を禁止する。 |
| Broadcom | Ethernet switching、AI NIC、optical DSP / optics、retimer / AEC及びPCIe connectivityで、AI scale-up / scale-out / scale-across又はend-to-end connectivityと直接結び付くgrain | Infrastructure software、enterprise / edge connectivity、custom accelerator / XPU / XDSiP product and revenue grain、customer identity、market share / ranking、cross-source supplier benefit、Phase 1 ID継承を禁止する。 |
| Marvell Technology | optical DSP / SerDes、switching、PCIe / CXL switch / retimer、end-to-end connectivity及びStructera S + Alaska PからAEC / AOC partnersへのenablement relation | AEC / AOCをMarvell製品化しない。custom AI accelerator / ASIC、storage controller、enterprise / carrier networking、acquisition economics、customer identity、market share / ranking、cross-source supplier benefit、Phase 1 ID継承を禁止する。 |

全Candidateでproduct、generation、application、availability、sample、mass production、shipment、relationship、revenue及びcapacityをatomicに分離する。Phase 1 `S3-EVR-001`–`132` / `S3-PIT-001`–`132`を再採番又はPhase 2へ自動継続しない。

## 4. Scope Activation後に許可する次工程

Option Aが明示承認された場合でも、直ちにEvidence Productionへ進まない。許可される次工程はGate P2-3の設計・判断準備に限定する。

1. 6社active scopeだけを対象とするPhase 2 Industry Research Designを作成する。
2. Phase 1 / cross-sprint Bridge Addendum及びOfficial Source Inventoryを作成する。
3. Phase 2 Namespace Decision Requestを作成し、別Decisionを得る。
4. Industry Research Design、Bridge、Source Inventory及びNamespaceの必要な独立review / Decisionが完了するまでSource Fact Inspectionを開始しない。
5. Namespace Decision前にEvidence / PIT IDを予約又は発行しない。

## 5. Scope Activation後も禁止する事項

- Scope外Source又はcut-off後Sourceの取込み
- Deferred対象又は7社目 / 3製品群目の追加
- Phase 1 Evidence / PIT IDの再発行又は自動継続
- Product announcement、sample、availability、mass production、shipment、revenue及びcustomer adoptionの同義化
- bit、wafer、stack、package、device、port、bandwidth、unit、ASP、capacity及びrevenueの相互換算
- Demand-side CapEx又はNVIDIA revenueからspecific supplier benefitをcross-source生成すること
- Lead / Lag、causality、feature、signal又はForecast achievementの採用
- `AvailableAt`決定、Catalog、DDL、Entity、Database、ML、backtest、Decision Engine、Advisor又は投資利用

Phase 1全132件は引き続き`AvailableAt = TBD — no use`、Catalog Eligibility `No`である。Phase 2候補にも利用権限を継承しない。

## 6. Disposition Options

| Option | Decision | Consequence |
| --- | --- | --- |
| A | 6社・2製品群を§3の限定scopeで一括Activationし、active research cut-offを`2026-08-11 23:59 JST`として固定するDecisionを別Scope Activation Decision Recordへ記録する。 | Decision Record完成時にcondition 4が6社について成立し、Gate P2-3のResearch Design / Bridge / Source Inventory / Namespace Decision準備へ進める。Research productionはまだ不可。 |
| B | Authorityが明示する一部CandidateだけをActivationする。 | Active / Hold / Not eligibleをCandidate別に記録し、選定理由とscope deltaを明示する。未選択Candidateのcondition 4は未成立。 |
| C | 6社又は一部CandidateをHold / Reviseへ戻す。 | 追加条件、修正対象、再review要件及び再提出条件を明記する。Scope Activationしない。 |
| D | Gate P2-2でRejectする。 | Phase 2 Researchを開始せず、Phase 1 Reviewed Draft Baselineと全利用制約を維持する。 |

## 7. Research / Documentation Team Recommendation

**Option Aを推奨する。**

6社はすべてCandidate-specific conditions 1–3を満たし、独立review Acceptedである。提案はDesignのbreadth cap 6社・2製品群に一致し、Phase 1の重要GapであるMemory / Storage及びNetwork / Opticalだけを対象とする。cut-offを更新しないため、P2-1でreviewしたSource集合との再現性も維持できる。

この推奨自体はScope Activation Decisionではない。Project Directorは独立review Accepted後の2026-08-13に別Decision RecordへOption Aを記録した。

## 8. Requested Decision Record Fields

| 項目 | RequestがDecision Recordに要求する内容 |
| --- | --- |
| Decision | Option A / B / C / D |
| Active issuer / Hold / Not eligible | Pending |
| Active product family | Pending |
| Scope delta | Pending |
| Active research cut-off | Pending |
| Exclusions | Pending |
| Decision Date | Pending |
| Decision Authority | Pending — Project Director又は明示的な委任記録を持つAccountable authority |
| Delegation Record | Not applicable for Project Director / otherwise required |
| Rationale | Pending |
| Follow-up | Pending |

上表はDecision Requestの必要項目でありDecision記録そのものではない。独立review Accepted後、authorityが別`Sprint003DataCenterAIInfrastructurePhase2ScopeActivationDecisionRecord.v0.1-draft.md`へ全項目を明示的に記録するまでcondition 4及びScope Activationは成立しない。空欄、口頭了解、Requestへの追記、review acceptance又はResearch Team recommendationをDecisionとして扱わない。

### 8.1 Subsequent Project Director Decision

Project Directorは2026-08-13に別`Sprint003DataCenterAIInfrastructurePhase2ScopeActivationDecisionRecord.v0.1-draft.md`へOption Aを記録した。6社・2製品群は§3の限定scopeでActivationされ、active research cut-offは`2026-08-11 23:59 JST`を継承する。許可される次工程はGate P2-3に限定され、P2-4 Evidence Production、ID発行、AvailableAt、Catalog又は下流利用は未承認である。

## 9. Definition of Done — This Request

- 6候補のconditions 1–3と独立review結果が一対一で再照合されている。
- issuer / product family breadth cap、scope delta、cut-off及びexclusionsが明示されている。
- Disposition optionsとRecommendationがDecisionから分離されている。
- 別Decision Recordへ要求するauthority、date、rationale、follow-up及び委任時のdelegation record項目がある。
- Scope Activation後もGate P2-3、Namespace、Evidence Production及び下流利用を分離している。
- 本Requestが独立Evidence / Knowledge / Traceability reviewへ引き渡される。
