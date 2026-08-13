# Sprint003 Data Center / AI Infrastructure — Cross-sprint Bridge

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft cross-sprint traceability record |
| Sprint | Sprint003 |
| Version | 0.1-draft |
| 作成日 | 2026-07-30 |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md`（Project Director Accepted、2026-07-30） |
| Namespace決定 | `Sprint003EvidenceNamespaceDecisionRecord.v0.1-draft.md` |
| 状態 | Draft — Stage 0 independent review accepted; noncanonical |
| Reviewer Status | Evidence / Knowledge / Traceability final disposition `Accepted` |
| Related Review Record | `Sprint003DataCenterAIInfrastructureStage0IndependentReview.v0.1-draft.md` |
| 対象 | Sprint001 / Sprint002とSprint003の重複・参照境界 |

> **利用境界：** 本文書は既存Research Assetとの参照関係を記録する。既存EvidenceのCanonicality、`AvailableAt`、Catalog適格性又はSprint003での採用を変更しない。

## 1. Pre-check Method

2026-07-30に、次の固定対象について、Sprint001及びSprint002のEvidence Register、PIT、Company Research、Industry Report及びEvidence Acquisition関連文書を、発行者名及び対象語で検索した。Raw Evidenceは、該当Evidence Register行から参照される範囲で確認した。

- Microsoft
- Alphabet
- NVIDIA
- Renesas / ルネサス
- ROHM / ローム
- Infineon
- Data Center / AI Infrastructure / AI Server

検索結果がないことは不存在の証明ではない。

### 1.1 Examined Artifact Set

| Sprint | Examined artifact | Version / current status | Search role |
| --- | --- | --- | --- |
| Sprint001 | `Sprint001AutomotiveEvidenceRegister.v0.1-draft.md` | `0.1-draft`; statusは行単位。Reviewable fact又はSource fact capturedであり、Released / Canonicalではない | ID、Source Event、Source position、Fact及び利用境界 |
| Sprint001 | `Sprint001AutomotiveSourceInventoryAndPIT.v0.1-draft.md` | `0.1-draft`; Draft / noncanonical | Source inventory及びPIT候補 |
| Sprint001 | `AutomotiveSemiconductorDemandIndustryReport.v0.1-draft.md` | `0.1-draft`; Reviewed Draft / noncanonical | Industry-level claim |
| Sprint001 | `AutomotiveSemiconductorEvidenceAcquisitionMatrix.v0.1-draft.md` | `0.1-draft`; Draft / noncanonical | Evidence取得計画 |
| Sprint001 | `6723_RenesasElectronics_CompanyResearch.v0.1-draft.md` | `0.1-draft`; Reviewed Draft / noncanonical | Renesas company claims |
| Sprint001 | `6963_ROHM_CompanyResearch.v0.1-draft.md` | `0.1-draft`; Reviewed Draft / noncanonical | ROHM company claims |
| Sprint002 | `Sprint002IndustrialPowerEvidenceRegister.v0.1-draft.md` | `0.1-draft`;各対象行はIndependent review accepted; Draft only | ID、Source Event、Source position、Fact及び利用境界 |
| Sprint002 | `Sprint002IndustrialPowerSourceInventoryAndPIT.v0.1-draft.md` | `0.1-draft`; Draft / noncanonical | Source inventory及びPIT候補 |
| Sprint002 | `Sprint002IndustrialPowerSemiconductorDemandIndustryReport.v0.1-draft.md` | `0.1-draft`; Reviewed Draft / noncanonical | Industry-level claim |
| Sprint002 | `6723_Renesas_IndustrialPowerCompanyResearch.v0.1-draft.md` | `0.1-draft`; Reviewed Draft / noncanonical | Renesas company claims |
| Sprint002 | `6963_ROHM_IndustrialPowerCompanyResearch.v0.1-draft.md` | `0.1-draft`; Reviewed Draft / noncanonical | ROHM company claims |

Search vocabularyは`Microsoft`、`Alphabet`、`NVIDIA`、`Renesas`、`ルネサス`、`ROHM`、`ローム`、`Infineon`、`Data Center`、`data center`、`AI Infrastructure`及び`AI Server`である。

## 2. Confirmed Cross-sprint Candidates

| Bridge Candidate | Existing artifact / ID | Existing Source Event / Claim | Sprint003 relevance | Required Sprint003 treatment |
| --- | --- | --- | --- | --- |
| CSB-REN-001 | Sprint002 `S2-EVR-012` | Renesas *Earnings Report for FY2025*。`Industrial / Infrastructure / IoT`複合区分のFY2024 / FY2025 Actual及びインフラ需要文脈 | Data Centerを含み得る複合区分の定義境界 | Existing Evidenceを参照する。同一Source FactをS3として再採番しない。Data Center単独へ配賦しない。 |
| CSB-REN-002 | Sprint002 `S2-EVR-013` | Renesas *Earnings Report for 1Q2026*。`Industrial / Infrastructure / IoT`複合区分の1Q2026 Actual及びインフラ需要文脈 | 最新四半期の複合区分 | Existing Evidenceを参照する。同一Source FactをS3として再採番しない。 |
| CSB-REN-003 | Sprint002 `S2-EVR-023` | Renesas *1Q 2026 Presentation Material*。1Q2026 ActualとしてIndustrial / Infrastructure / IoT複合区分を含むchannel inventoryのData Center向け増加を説明し、別に2Q2026 Forecastとして同複合区分のadvance shipmentを説明 | Sprint003に直接関係するが、複合区分、Actual / Forecast及び二つの説明を分離して維持する必要がある | 同一Source Factは`S2-EVR-023`を参照する。Data Center単独在庫又は2Q Actualとして扱わず、S3重複登録を禁止する。新規Claimがある場合だけSource position、差分及び理由を記録する。 |
| CSB-REN-004 | Sprint001 `EVR-003`、`EVR-010`–`EVR-014` | Renesas Automotive事業定義及び売上Source Facts | 同一発行者・同一IR archive。用途・集計方法の境界確認 | Automotive FactをData Centerへ再利用しない。Source Event又は定義変更の照合に限定する。 |
| CSB-ROH-001 | Sprint002 `S2-EVR-007`–`S2-EVR-011` | ROHM `Industrial`市場別売上、Forecast、SiC用途及び比較注記 | 同一発行者。一部は同じFY2025資料又はIntegrated Report | IndustrialをData Centerへ配賦しない。同じ資料から新しいAI Server Claimを抽出する場合は既存ID、Source position差分及び新規性を記録する。 |
| CSB-ROH-002 | Sprint001 `EVR-008`、`EVR-019`–`EVR-023` | ROHM Integrated Report及び市場別Automotive売上Source Facts | 同一発行者・一部同一資料 | Automotive FactをAI Serverへ転用しない。同一Source Factの再採番を禁止する。 |
| CSB-INF-001 | Sprint001 `EVR-004` | Infineon *Annual Report 2025*のAutomotive segment revenue | Sprint003でも同じAnnual Report 2025がData Center Power候補 | Automotive Source Factを再採番しない。Annual Report内の別Source position・別AI Data Center Claimに限り、Cross-sprint参照付きの新規S3候補とする。 |

### 2.1 Existing Evidence One-to-one Mapping

| Bridge | Existing register / version | Existing ID | Source Event / position family | Current row status | Match type / Sprint003 treatment |
| --- | --- | --- | --- | --- | --- |
| CSB-REN-001 | `Sprint002IndustrialPowerEvidenceRegister.v0.1-draft.md` | `S2-EVR-012` | *Earnings Report for FY2025*、2026-02-05、pp.8–9、Industrial / Infrastructure / IoT | Independent review accepted; Draft only; `AvailableAt = TBD — no use` | Same existing fact; reference only |
| CSB-REN-002 | 同上 | `S2-EVR-013` | *Earnings Report for 1Q2026*、2026-04-24、pp.7–8、Industrial / Infrastructure / IoT | Independent review accepted; Draft only; `AvailableAt = TBD — no use` | Same existing fact; reference only |
| CSB-REN-003 | 同上 | `S2-EVR-023` | *1Q 2026 Presentation Material*、2026-04-24、p.7 `INVENTORY` | Independent review accepted; Draft only; `AvailableAt = TBD — no use` | Same composite fact; reference only |
| CSB-REN-004 | `Sprint001AutomotiveEvidenceRegister.v0.1-draft.md` | `EVR-003` | *Annual Securities Report 2025*、2026-05-15、p.7 Automotive Business | Reviewable fact | Same issuer, different application; boundary reference |
| CSB-REN-004 | 同上 | `EVR-010` | *Financial Report 2021*、publication event未確定、Automotive revenue table | Source fact captured; Catalog / DDL / downstream ineligible; `AvailableAt = TBD — no use` | Same issuer/archive, different application; boundary reference |
| CSB-REN-004 | 同上 | `EVR-011` | *Financial Report 2022*、publication event未確定、Automotive revenue table | Source fact captured; Catalog / DDL / downstream ineligible; `AvailableAt = TBD — no use` | Same issuer/archive, different application; boundary reference |
| CSB-REN-004 | 同上 | `EVR-012` | *Financial Report 2023*、2024-03-28、p.4 / PDF p.3 Automotive revenue | Source fact captured; Catalog / DDL / downstream ineligible; `AvailableAt = TBD — no use` | Same issuer/archive, different application; boundary reference |
| CSB-REN-004 | 同上 | `EVR-013` | *1Q 2024 Presentation*、2024-04-25、pp.4/7及び*Financial Report 2024*、2025-03-26、p.4 / Note 6 | Source fact captured; Catalog / DDL / downstream ineligible; `AvailableAt = TBD — no use` | Same issuer/archive, revised Automotive basis; boundary reference |
| CSB-REN-004 | 同上 | `EVR-014` | *Financial Report 2025*、2026-03-19、p.4 / PDF p.3 Automotive revenue | Source fact captured; Catalog / DDL / downstream ineligible; `AvailableAt = TBD — no use` | Same issuer/archive, different application; boundary reference |
| CSB-ROH-001 | `Sprint002IndustrialPowerEvidenceRegister.v0.1-draft.md` | `S2-EVR-007` | *Financial Results for FY2025*、資料基準日2026-05-13、p.4 `Sales Composition / By Market` | Independent review accepted; Draft only; `AvailableAt = TBD — no use` | Same issuer/document candidate; IndustrialをData Centerへ配賦しない |
| CSB-ROH-001 | 同上 | `S2-EVR-008` | *Financial Results for FY2025*、資料基準日2026-05-13、p.8 FY2026 Plan `Industrial` | Independent review accepted; Draft only; `AvailableAt = TBD — no use` | Same issuer/document candidate; ForecastとData Centerを同一視しない |
| CSB-ROH-001 | 同上 | `S2-EVR-009` | *ROHM Integrated Report 2025*、2025-11、p.4 `Power` | Independent review accepted; Draft only; `AvailableAt = TBD — no use` | Same document candidate;別Source position / ClaimだけS3候補 |
| CSB-ROH-001 | 同上 | `S2-EVR-010` | *Financial Results for FY2024*、資料基準日2025-05-14、p.4 `Industrial` | Independent review accepted; Draft only; `AvailableAt = TBD — no use` | Same issuer; IndustrialをData Centerへ配賦しない |
| CSB-ROH-001 | 同上 | `S2-EVR-011` | *Fact Book 2026 3Q*、2026-02-04、p.3 classification note | Independent review accepted; Draft only; `AvailableAt = TBD — no use` | Same issuer; classification / comparability boundary reference |
| CSB-ROH-002 | `Sprint001AutomotiveEvidenceRegister.v0.1-draft.md` | `EVR-008` | *Integrated Report 2025*、pp.50–51、power-device applications | Reviewable fact | Same document, different Source position required |
| CSB-ROH-002 | 同上 | `EVR-019` | *Financial Results for FY2025*、2026-05-13、p.36 Automotive market sales | Source fact captured; PIT unavailable; comparability pending; `AvailableAt = TBD — no use` | Same document candidate, different application; no reuse |
| CSB-ROH-002 | 同上 | `EVR-020` | *Financial Results for FY2025*、2026-05-13、p.5 Automotive sales composition | Source fact captured; PIT unavailable; comparability pending; `AvailableAt = TBD — no use` | Same document candidate, different application; no reuse |
| CSB-ROH-002 | 同上 | `EVR-021` | *Financial Results for FY2023*、2024-05-09、p.5 Automotive market sales | Source fact captured; PIT unavailable; comparability pending; `AvailableAt = TBD — no use` | Same issuer, different application; no reuse |
| CSB-ROH-002 | 同上 | `EVR-022` | *Financial Results for FY2022*、2023-05-10、p.5 Automotive market sales | Source fact captured; PIT unavailable; comparability pending; `AvailableAt = TBD — no use` | Same issuer, different application; no reuse |
| CSB-ROH-002 | 同上 | `EVR-023` | *Financial Results for FY2024*、2025-05-14、p.5 Automotive market sales | Source fact captured; PIT unavailable; comparability pending; `AvailableAt = TBD — no use` | Same issuer, different application; no reuse |
| CSB-INF-001 | `Sprint001AutomotiveEvidenceRegister.v0.1-draft.md` | `EVR-004` | *Annual Report 2025*、p.47、Automotive segment table C04 | Reviewable fact; exact availability timestamp pending | Same document, different Source position and claim required |

## 3. No Existing Match Confirmed in Examined Set

| Issuer | Result |
| --- | --- |
| Microsoft | 確認したSprint001 / Sprint002文書群では該当Research Assetを確認できなかった。 |
| Alphabet | 確認したSprint001 / Sprint002文書群では該当Research Assetを確認できなかった。 |
| NVIDIA | 確認したSprint001 / Sprint002文書群では該当Research Assetを確認できなかった。 |

この結果は、上記固定集合を2026-07-30に上記語彙で確認した結果に限られ、Repository全体又は外部に資料が存在しないことを意味しない。

## 4. Completion Rule

本Bridge候補はOfficial Source Inventoryとの照合及び独立再レビュー後に完成させる。Raw Evidence作成又はID採番前に次を確認する。

1. 同一資料名及び公開イベント
2. 同一Source position
3. 同一Source Fact又はClaim
4. 既存EvidenceのVersion及びReview Status
5. 新規S3候補とする場合の差分及び必要性

進行順序は、`Source Fact inspection → Cross-sprint一対一確認 → Raw Evidence作成（採番条件を満たした場合に限りID付与）→ EVR登録 → PIT登録`とする。既存EvidenceのStatus、Canonicality又は利用適格性は本Bridgeによって変更しない。
