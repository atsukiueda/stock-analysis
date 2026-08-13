# Sprint003 Data Center / AI Infrastructure — Phase 2 Candidate Eligibility Inventory

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | ID-less Candidate Eligibility Inventory |
| Sprint | Sprint003 |
| Version | 0.1-draft |
| Gate | P2-1 — ID-less Candidate Eligibility Pre-check |
| Pre-check cut-off | `2026-08-11 23:59 JST` |
| Authority basis | `Sprint003DataCenterAIInfrastructurePhase2ScopeDecisionRecord.v0.1-draft.md` |
| Governing design | `Sprint003DataCenterAIInfrastructurePhase2ScopeDesign.v0.1-draft.md` |
| 状態 | Draft — six candidates conditions 1–4 Met; Gate P2-3 independent review Accepted; Namespace Option A Accepted; P2-4 Option A authorized; Micron SFI next; noncanonical |

> **権限境界：** 本InventoryはCandidate eligibilityを確認するためのDraft Recordである。Source Fact Inspection、Research synthesis、Raw Evidence、EVR、PIT又はCompany Researchではない。Candidateの記載、Author assessment又はReviewer recommendationはScope Activation、Evidence ID発行、`AvailableAt`決定、Catalog利用又は投資利用を許可しない。

## 1. Purpose

Gate P2-1で許可された限定content inspectionにより、Phase 1 Scope Design §3.2 conditions 1–3をCandidate単位で確認する。Condition 4は本Inventory又は独立Reviewerによって成立せず、Project Director又は明示的な委任記録を持つAccountable authorityのGate P2-2 Scope Activation Decision Recordでのみ成立する。

## 2. Candidate Progress

| Order | Candidate | Product family | Author assessment — conditions 1–3 | Independent review | Gate P2-2 status |
| ---: | --- | --- | --- | --- | --- |
| 1 | Micron Technology | Memory / Storage — HBM、DRAM、NAND / Data Center SSD | Met / Met / Met | Accepted — C0 / H0 / M0 / L0 | Activated — condition 4 Met |
| 2 | SK hynix | Memory — HBM / DRAM / NAND / eSSD | Met / Met / Met | Accepted — C0 / H0 / M0 / L0 | Activated — condition 4 Met |
| 3 | Samsung Electronics | Mixed Memory / Storage — HBM / DRAM / NAND / enterprise SSD | Met / Met / Met | Accepted — C0 / H0 / M0 / L0 | Activated — condition 4 Met |
| 4 | Kioxia Holdings | Memory / Storage — NAND / enterprise and Data Center SSD | Met / Met / Met | Accepted — C0 / H0 / M0 / L0 | Activated — condition 4 Met |
| 5 | Broadcom | Network / Connectivity — Ethernet switching / NIC / optical connectivity | Met / Met / Met | Accepted — C0 / H0 / M0 / L0 | Activated — condition 4 Met |
| 6 | Marvell Technology | Network / Optical — optical DSP / PCIe switching / retimer connectivity | Met / Met / Met | Accepted — C0 / H0 / M0 / L0 | Activated — condition 4 Met |

`Met`はAuthor assessmentであり、独立review又はScope Activation Decisionではない。

## 3. Candidate Record — Micron Technology

### 3.1 Candidate / product family

- Candidate: Micron Technology, Inc.
- Proposed product family: Memory / Storage Semiconductor
- Included candidate grain: HBM、DRAM / LPDDR、NAND及びData Center SSDのうち、Micron公式SourceがAI / Data Center用途又はplatform relationを直接記述するgrain
- Excluded at this Gate: market size、share、ranking、revenue series、bit shipment、wafer / stack / package、capacity、inventory、pricing、Lead / Lag、Forecast achievement及びsupplier investment signal

### 3.2 Phase 1 RQ / Gap reference

- `Sprint003DataCenterAIInfrastructureSemiconductorDemandScopeDesign.v0.1-draft.md` §3.2はMemoryをConditional Scopeとし、§4はHBM、DRAM及びNANDをCandidate範囲としている。
- 同Scope §8はHBM / DRAM / NAND需要・売上をConditionalとし、製品構成、容量、価格及び在庫の分離を要求している。
- Phase 1 Industry Research DesignのCore Company MatrixはMicrosoft、Alphabet、NVIDIA、Renesas、ROHM及びInfineonの6社であり、Memory supplier固有のCompany Researchを含まない。
- Phase 2 Local RQとの接続候補は`S3-DCAI-P2-RQ-001`、`003`、`004`及び`005`。これらはLocal RQであり、Evidence ID又はCanonical Identifierではない。

### 3.3 Materiality / Core Scopeで解消不能な理由 — condition 1

Phase 1はDemand-side、Compute supply及びPower supplyを被覆した一方、issuer固有のHBM / DRAM / NAND / Data Center SSDについて、用途定義、製品stage、数量・容量・世代・価格・revenueの非同義境界を企業単位で検証していない。Micronを追加候補として限定確認することは、この未被覆Memory / Storage grainを既存6社のFactからcross-source推定せずに検証するために必要である。

**Author assessment — condition 1: Met.** これはCandidate-specificなscope rationaleであり、Memory市場の重要性、投資魅力又はMicronの競争優位を表すResearch Factではない。

### 3.4 Official direct-relation source / event / version / position — condition 2

#### Entry Source A — primary entry relation

| Field | Record |
| --- | --- |
| Issuer | Micron Technology, Inc. |
| Official source | *Micron Powers AI Everywhere at COMPUTEX 2026* |
| Publication Event | 2026-06-01 18:00 EDT |
| Version identity | Dated issuer news release; page retrieved 2026-08-11 |
| Official URL | https://investors.micron.com/news-releases/news-release-details/micron-powers-ai-everywhere-computex-2026 |
| Source position | Section `Memory and storage as the foundation of AI data center performance` and immediately following HBM / SOCAMM / DDR5 / Data Center SSD product paragraphs |

Source-faithful candidate statement: Micronは同sectionで、Data Center memory / storage portfolioをAI infrastructure hierarchyの各layer向けとして位置付け、HBMをhigh-speed model execution及びhot KV cache、LPDDR / DDRをsystem memory、Data Center SSDをpersistent KV cache及びhigh-capacity data lakesへ対応付けている。

#### Entry Source B — named platform / AI server relation

| Field | Record |
| --- | --- |
| Issuer | Micron Technology, Inc. |
| Official source | *Micron Innovates From the Data Center to the Edge With NVIDIA* |
| Publication Event | 2025-03-18 16:24 EDT |
| Version identity | Dated issuer news release; page retrieved 2026-08-11 |
| Official URL | https://investors.micron.com/news-releases/news-release-details/micron-innovates-data-center-edge-nvidia |
| Source position | Opening paragraphs and section `Complete memory and storage solutions designed for AI from the data center to the edge` |

Source-faithful candidate statements — provisional atomic grains:

1. MicronはHBM3E及びSOCAMMをData CenterのAI server向けにshippingしていると発行者自身が述べている。
2. MicronはSOCAMMをNVIDIAと共同開発し、NVIDIA GB300 Grace Blackwell Ultra Superchipをsupportすると述べている。
3. Micronは`Micron HBM3E 12H 36GB`が`NVIDIA HGX B300 NVL16 and GB300 NVL72 platforms`にdesigned intoされていると述べている。

これら3 grainを一つのproduct-stage progressionへ統合しない。将来SFIが許可された場合もshipment、joint development及びdesigned-into relationをatomicに分離する。

#### Minimum Source Set — located, not fully inspected at P2-1

| Source family | Located official source | P2-1 treatment |
| --- | --- | --- |
| Annual filing | Micron FY2025 Form 10-K; filed 2025-10-03; period ended 2025-08-28; https://investors.micron.com/sec-filings/sec-filing/10-k/0000723125-25-000028 | Location / identity only. No full Fact inspection. |
| Latest quarterly release before cut-off | *Micron Technology, Inc. Reports Record Results for the Third Quarter of Fiscal 2026*; 2026-06-24 16:01 EDT; https://investors.micron.com/node/50671 | Location / identity only. No revenue, shipment or product-stage Fact is admitted by this record. |
| AI / Data Center product source | Entry Sources A and B above | Limited direct-relation inspection only. |
| IR / News archive | Micron Investors News Releases and SEC Filings pages | Search surface confirmed; archive completeness is not asserted. |

**Author assessment — condition 2: Met.** At least one cut-off-eligible official Source Event directly connects Micron Memory / Storage products with AI / Data Center infrastructure. This is an eligibility relation only and does not create an Evidence Fact.

### 3.5 Provisional classification / use boundary

| Source | Provisional grain | Boundary |
| --- | --- | --- |
| Entry Source A | Issuer product / application positioning plus separate product-stage statements within one release | Application positioningをavailability、shipment、revenue、market share又はindustry demandへ変換しない。各product-stage statementは将来のSFIでatomicに分離する。 |
| Entry Source B-1 | Issuer shipment assertion — HBM3E / SOCAMM for AI servers in the Data Center; publication-event時点のcurrent / Actual assertion | shipment quantity、customer-wide adoption、order、revenue、share又はindustry demandを補完しない。 |
| Entry Source B-2 | Issuer-reported joint-development relationship — Micron / NVIDIA SOCAMM and GB300 support | joint developmentをprocurement、availability、shipment、volume、revenue又はcommercial successへ変換しない。 |
| Entry Source B-3 | Named-platform designed-into relationship — Micron HBM3E 12H 36GB / NVIDIA HGX B300 NVL16 and GB300 NVL72 | designed-intoをplatform-wide procurement、customer adoption、shipment、volume、revenue、performance superiority又はcommercial successへ変換しない。 |

Entry Source AとBを一つのcommercial progressionへ統合せず、corroborationによる確度加算又は二度の進展として数えない。HBM、DRAM / LPDDR、NAND / SSDも相互換算又は共通unit化しない。

### 3.6 Cross-sprint / Phase 1 result

2026-08-11に、次の実在するread-only local setを検索した。

- `KnowledgeBase/07_AI_Workspace/Sprint001`
- `KnowledgeBase/07_AI_Workspace/Sprint002`
- `KnowledgeBase/07_AI_Workspace/Sprint003`
- `KnowledgeBase/01_Research`
- `KnowledgeBase/02_Knowledge`

検索語、方式及びfile hitは次のとおり。検索時点の本Inventory及び本Review Recordはself-documentとして同一Fact判定から除外した。

| Query | Method | File hits | Relevant disposition |
| --- | --- | ---: | --- |
| `Micron` | literal case-insensitive | 5 | 本Inventory / Review、Phase 2 Scope Design / Decision及びPhase 1 generic Scope記述のみ。既存Micron Research / Evidence Factなし。 |
| `HBM` | literal case-insensitive | 4 | 本Inventory、Phase 1 / 2 Scope記述及び既存Industry Knowledgeのgeneric HBM記述。Entry Source A / Bと同一Source Event / position / grainなし。 |
| `high bandwidth memory` | literal case-insensitive | 1 | 本Inventoryのみ。 |
| exact token `MU` | PCRE2 case-insensitive `(?<![A-Za-z0-9])MU(?![A-Za-z0-9])` | 1 | 本Inventoryのみ。部分文字列`MU`検索は使用していない。 |

検索はerrorなしで完了した。結果はgeneric Scope / Industry記述及び今回作成したPhase 2 proposal / recordに限られ、Entry Source A又はBと同一のissuer、Source Event、position及びFact grainを持つ既存Research Assetは確認されなかった。

**Result:** New candidate within the searched local set. この結果は検索集合と確認日に限定され、repository全体又は外部世界における不存在証明ではない。

### 3.7 Candidate-specific stop condition — condition 3

次の条件でMicron P2-1作業を停止する。

1. Official direct relation 1件以上をSource Event / URL / positionとともに再現した。
2. Annual filing、最新四半期、AI / Data Center product source及びIR / News search surfaceの所在を確認した。
3. Cross-sprint / Phase 1限定検索を実施し、同一Fact再発行の有無を記録した。
4. Provisional classification、use boundary及びscope deltaを記録した。

追加Source familyの全文inspection、Fact候補列挙、数値抽出又はResearch synthesisはP2-1の必要条件を超えるため実施しない。

**Author assessment — condition 3: Met.**

### 3.8 Proposed scope delta

| Dimension | Proposed delta |
| --- | --- |
| Issuer | Micron Technology, Inc.をMemory benchmark candidateとして追加 |
| Product family | Memory / Storage — HBM、DRAM / LPDDR、NAND / Data Center SSD |
| Permitted relation | Micron公式SourceがAI / Data Center / AI server又はnamed platformへ直接結び付けるproduct / application / stage grain |
| Period | FY2021以降。主要分析期間はFY2022以降。Active research cut-offはGate P2-2 Decisionで継承又は更新を明示 |
| Geography | Global。地域別allocationはSourceが直接分離する場合のみ |
| Exclusions | 市場share / ranking、industry total、価格・容量・bit・unit換算、未開示AI専用revenue、cross-source supplier benefit、Phase 1 ID継承 |

### 3.9 Author recommendation

**Proceed to Gate P2-2 consideration package.**

Micronはconditions 1–3の独立review Accepted後、2026-08-13 Option A Decisionによりcondition 4が成立し、限定active Research Scopeへ追加された。

## 4. Candidate Record — SK hynix

### 4.1 Candidate / product family

- Candidate: SK hynix Inc.
- Proposed product family: Memory / Storage Semiconductor
- Included candidate grain: HBM、server DRAM、NAND及びenterprise / Data Center SSDのうち、SK hynix公式SourceがAI / Data Center / server用途又はplatform relationを直接記述するgrain
- Excluded at this Gate: market size、share、leadership ranking、revenue attribution、bit shipment、wafer / stack / package、capacity、inventory、pricing、Lead / Lag、Forecast achievement及びsupplier investment signal

### 4.2 Phase 1 RQ / Gap reference

- `Sprint003DataCenterAIInfrastructureSemiconductorDemandScopeDesign.v0.1-draft.md` §3.2はMemoryをConditional Scopeとし、§4はHBM、DRAM及びNANDをCandidate範囲としている。
- 同Scope §8はHBM / DRAM / NAND需要・売上をConditionalとし、製品構成、容量、価格及び在庫の分離を要求している。
- Phase 1 Core Company MatrixはMemory supplier固有のCompany Researchを含まない。
- Phase 2 Local RQとの接続候補は`S3-DCAI-P2-RQ-001`、`003`、`004`及び`005`。これらはLocal RQであり、Evidence ID又はCanonical Identifierではない。

### 4.3 Materiality / Core Scopeで解消不能な理由 — condition 1

Phase 1はissuer固有のHBM / server DRAM / NAND / eSSDについて、AI Data Center用途、product generation、product stage、customer / platform relation、quantity / capacity / pricing / revenue denominatorを企業単位で検証していない。SK hynixを追加候補として限定確認することは、既存Demand-side / Compute / Power Evidenceを組み合わせてMemory需要又はsupplier benefitを推定せず、この未被覆grainを公式issuer Sourceから検証するために必要である。

**Author assessment — condition 1: Met.** これはCandidate-specificなscope rationaleであり、SK hynixのleadership、share、競争優位、将来業績又は投資魅力を示すResearch Factではない。

### 4.4 Official direct-relation source / event / version / position — condition 2

#### Entry Source A — primary entry relation

| Field | Record |
| --- | --- |
| Issuer | SK hynix Inc. |
| Official source | *SK hynix Unveils Latest AI Memory Solutions at MWC 2026, Showcasing Its Technological Capabilities as a Full Stack AI Memory Creator* |
| Publication Event | 2026-03-05; time / timezone Unknown |
| Version identity | Dated issuer Newsroom article; English page retrieved 2026-08-11 |
| Official URL | https://news.skhynix.com/en/mwc-2026/ |
| Source position | Section `AI Memory Leadership on Display at the SK hynix Booth`, paragraphs describing the HBM zone, AI Datacenter Memory zone and eSSD lineup for AI data centers |

Source-faithful candidate statements — provisional atomic grains:

1. SK hynixはHBM4をnext-generation AI data center server platformsにadoptedされた製品として記述している。
2. SK hynixは12-layer HBM3Eをglobal customersのlatest AI data center GPU modulesでusedされている製品として記述している。
3. SK hynixはDDR5-based module productsをData Center / server markets向けとして、SOCAMM2をAI server向けのlow-power DRAM-based moduleとして記述している。
4. SK hynixはPEB210 E1.S、PS1110 E3.S及びQLC NAND-based PS1101 E3.SをAI data center market向けeSSD portfolioとして記述している。

上記4 grainを一つのadoption又はcommercial progressionへ統合しない。anonymous global customers又はunnamed platformのidentityを推定しない。

#### Minimum Source Set — located, not fully inspected at P2-1

| Source family | Located official source | P2-1 treatment |
| --- | --- | --- |
| Annual filing | SK hynix FY2025 Annual Report; filed 2026-03-17; DART receipt `20260317000635`; https://englishdart.fss.or.kr/dsbh001/main.do?rcpNo=20260317000635 | Location / identity only. No full Fact inspection. |
| Latest quarterly release before cut-off | *SK hynix Announces 2Q26 Financial Results*; 2026-07-29; https://news.skhynix.com/en/q2-2026-business-results/ | Location / identity only. No revenue、demand、shipment、contract、capacity又はinvestment Fact is admitted by this record. |
| AI / Data Center product source | Entry Source A above | Limited direct-relation inspection only. |
| IR / News archive | SK hynix Newsroom Press / IR archive and corporate IR pages | Search surface confirmed; archive completeness is not asserted. |

**Author assessment — condition 2: Met.** cut-off前のSK hynix公式Source EventがAI Data CenterとHBM、server DRAM及びeSSD / NAND product grainを直接結び付けている。これはeligibility relationだけであり、Evidence Factを生成しない。

### 4.5 Provisional classification / use boundary

| Grain | Provisional classification | Boundary |
| --- | --- | --- |
| A-1 HBM4 | Issuer product / anonymous-platform adoption assertion | platform identity、customer、order、shipment、volume、revenue、share又はcommercial successを補完しない。 |
| A-2 12-layer HBM3E | Issuer-reported anonymous-customer / GPU-module use assertion | global customersをnamed customerへ変換せず、customer count、module quantity、revenue又はmarket-wide adoptionを補完しない。 |
| A-3 DDR5 modules / SOCAMM2 | Issuer product / application positioning | targeting / specializationをavailability、adoption、shipment、revenue又はperformance superiorityへ変換しない。 |
| A-4 eSSD portfolio | Issuer product / application positioning with product-specific capacity / technology attributes | portfolio positioningをAI専用売上、shipment、share又はuniversal configurationへ変換しない。QLC NAND、capacity、cooling及びform factorを相互換算しない。 |

Source内の製品generation、performance、power efficiency、capacity及びtechnology attributeはP2-1のdirect-relation判定に必要な範囲を超えるためFact化しない。将来SFIが許可された場合はapplication、adoption / use、performance及びproduct attributeをatomicに分離する。

### 4.6 Cross-sprint / Phase 1 result

2026-08-11に、次の実在するread-only local setを検索した。

- `KnowledgeBase/07_AI_Workspace/Sprint001`
- `KnowledgeBase/07_AI_Workspace/Sprint002`
- `KnowledgeBase/07_AI_Workspace/Sprint003`
- `KnowledgeBase/01_Research`
- `KnowledgeBase/02_Knowledge`

検索時点で作成中の`*Phase2CandidateEligibility*.md`はself-documentとしてglob除外し、次の結果を得た。

| Query | Method | File hits | Relevant disposition |
| --- | --- | ---: | --- |
| `SK hynix` | literal case-insensitive | 3 | Phase 2 Scope Design / Decision及びPhase 1 generic Scope記述のみ。既存SK hynix Research / Evidence Factなし。 |
| `hynix` | literal case-insensitive | 3 | 上記と同じ。 |
| `HBM` | literal case-insensitive | 3 | Phase 1 / 2 generic Scope及び既存Industry Knowledgeのgeneric HBM記述。Entry Source Aと同一Source Event / position / grainなし。 |
| exact token `000660` | PCRE2 case-insensitive `(?<![A-Za-z0-9])000660(?![A-Za-z0-9])` | 0 | matchなし。 |

検索はerrorなしで完了した。

**Result:** New candidate within the searched local set. この結果は検索集合と確認日に限定され、repository全体又は外部世界における不存在証明ではない。

### 4.7 Candidate-specific stop condition — condition 3

次の条件でSK hynix P2-1作業を停止する。

1. Official direct relation 1件以上をSource Event / URL / positionとともに再現した。
2. Annual filing、最新四半期、AI / Data Center product source及びIR / News search surfaceの所在を確認した。
3. Cross-sprint / Phase 1限定検索を実施し、同一Fact再発行の有無を記録した。
4. Provisional classification、use boundary及びscope deltaを記録した。

Q2 FY2026のrevenue / demand / HBM4 shipment / contract / capacity / investment、追加Newsroom event及び製品specの全文inspectionはP2-1の必要条件を超えるため実施しない。

**Author assessment — condition 3: Met.**

### 4.8 Proposed scope delta

| Dimension | Proposed delta |
| --- | --- |
| Issuer | SK hynix Inc.をHBM / Memory supply candidateとして追加 |
| Product family | Memory / Storage — HBM、server DRAM / SOCAMM、NAND / Data Center eSSD |
| Permitted relation | SK hynix公式SourceがAI / Data Center / server / GPU module又はplatformへ直接結び付けるproduct / application / stage / relation grain |
| Period | FY2021以降。主要分析期間はFY2022以降。Active research cut-offはGate P2-2 Decisionで継承又は更新を明示 |
| Geography | Global。地域又はcustomer別allocationはSourceが直接分離する場合のみ |
| Exclusions | leadership / share / ranking、industry total、価格・容量・bit・unit換算、未開示AI専用revenue、anonymous identity推定、cross-source supplier benefit、Phase 1 ID継承 |

### 4.9 Author recommendation

**Proceed to Gate P2-2 consideration package.**

SK hynixはconditions 1–3の独立review Accepted後、2026-08-13 Option A Decisionによりcondition 4が成立し、限定active Research Scopeへ追加された。

## 5. Candidate Record — Samsung Electronics

### 5.1 Candidate / product family

- Candidate: Samsung Electronics Co., Ltd.
- Proposed product family: Mixed Memory / Storage Semiconductor
- Included candidate grain: HBM、server DRAM / SOCAMM及びV-NAND-based enterprise SSDのうち、Samsung公式SourceがAI Infrastructure、Data Center、AI / HPC server又はnamed platformへ直接結び付けるgrain
- Excluded at this Gate: Device Solutions全体、Foundry / Logic / Packaging、mobile / on-device memory、market size / share / ranking、bit shipment、capacity、pricing、Lead / Lag、AI専用revenue及びinvestment signal

### 5.2 Phase 1 RQ / Gap reference

- `Sprint003DataCenterAIInfrastructureSemiconductorDemandScopeDesign.v0.1-draft.md` §3.2はMemoryをConditional Scopeとし、§4はHBM、DRAM及びNANDをCandidate範囲としている。
- 同Scope §8はHBM / DRAM / NAND需要・売上をConditionalとし、製品構成、容量、価格及び在庫の分離を要求している。
- Phase 1 Core Company MatrixはMixed Memory supplier固有のCompany Researchを含まず、SamsungのDevice Solutions全体からAI Data Center Memoryだけを配賦できない。
- Phase 2 Local RQとの接続候補は`S3-DCAI-P2-RQ-001`、`003`、`004`及び`005`。これらはLocal RQであり、Evidence ID又はCanonical Identifierではない。

### 5.3 Materiality / Core Scopeで解消不能な理由 — condition 1

Phase 1はSamsung issuer-specificのHBM / server DRAM / NAND / enterprise SSDについて、AI Infrastructure用途、product generation、mass-production / sample / demonstration stage、named platform relation及びrevenue / quantity / capacity denominatorを企業単位で検証していない。Samsungを追加候補として限定確認することは、Device Solutions全体又は既存Demand / Compute / Power FactをAI Memoryへ配賦せず、この未被覆Mixed Memory / Storage grainをissuer公式Sourceから検証するために必要である。

**Author assessment — condition 1: Met.** これはCandidate-specificなscope rationaleであり、Samsungのleadership、share、競争優位、供給能力又は将来業績を示すResearch Factではない。

### 5.4 Official direct-relation source / event / version / position — condition 2

#### Entry Source A — broad named-platform entry relation

| Field | Record |
| --- | --- |
| Issuer | Samsung Electronics Co., Ltd. |
| Official source | *Samsung Unveils HBM4E, Showcasing Comprehensive AI Solutions, NVIDIA Partnership and Vision at NVIDIA GTC 2026* |
| Publication Event | 2026-03-17; time / timezone Unknown |
| Version identity | Dated Samsung Global Newsroom press release; page retrieved 2026-08-11 |
| Official URL | https://news.samsung.com/global/samsung-unveils-hbm4e-showcasing-comprehensive-ai-solutions-nvidia-partnership-and-vision-at-nvidia-gtc-2026 |
| Source position | Opening HBM4 paragraphs and section `An Alliance Taking the AI Era to the Next Level` |

Source-faithful candidate statements — provisional atomic grains:

1. SamsungはHBM4をcurrent mass-production stageとして記述している。
2. SamsungはHBM4をNVIDIA Vera Rubin platform向けにdesignedされた製品として記述している。
3. SamsungはHBM4、SOCAMM2及びPM1763 SSDをNVIDIA AI infrastructure向けにdesignedされたtechnology lineupとして記述している。
4. SamsungはSOCAMM2をnext-generation AI infrastructure向けlow-power DRAM-based server memory moduleとして位置付け、current mass-production stageを別に述べている。
5. SamsungはPM1763 SSDをnext-generation AI storage solution向けとして位置付け、NVIDIA SCADA programming modelでのserver demonstrationを将来展示内容として記述している。

Mass production Actual、application positioning、named-platform designed-for relation及びdemonstration Planを相互に同義化しない。

#### Entry Source B — enterprise SSD product-stage relation

| Field | Record |
| --- | --- |
| Issuer | Samsung Electronics Co., Ltd. |
| Official source | *Samsung Begins Mass Production of PM1763 SSD Optimized for Next-Generation AI Infrastructure* |
| Publication Event | 2026-07-08; time / timezone Unknown |
| Version identity | Dated Samsung Global Newsroom press release; page retrieved 2026-08-11 |
| Official URL | https://news.samsung.com/global/samsung-begins-mass-production-of-pm1763-ssd-optimized-for-next-generation-ai-infrastructure |
| Source position | Headline bullets and opening paragraphs through the issuer speaker statement |

Source-faithful candidate statements — provisional atomic grains:

1. SamsungはPCIe 6.0-based enterprise SSD `PM1763`のmass production開始を発表している。
2. SamsungはPM1763をnext-generation AI / HPC server environments向けにoptimizedされた製品として位置付けている。
3. Samsung speakerはPM1763がnext-generation AI platformsのvalidationを完了したと述べている。

Entry Source AのPM1763 relationとEntry Source Bを、別製品、二度のmass-production進展又はcorroborationによる確度加算として数えない。

#### Minimum Source Set — located, not fully inspected at P2-1

| Source family | Located official source | P2-1 treatment |
| --- | --- | --- |
| Annual filing | *Samsung Electronics 2025 Business Report*; 2026-04-30; https://www.samsung.com/global/ir/reports-disclosures/public-disclosure-view.84648/ ; PDF https://images.samsung.com/is/content/samsung/assets/global/ir/docs/2025_4Q_Interim_Report.pdf | Location / identity only. No full Fact inspection. |
| Latest quarterly release before cut-off | *Samsung Electronics 2Q 2026 Earnings Call*; 2026-07-30; https://images.samsung.com/is/content/samsung/assets/global/ir/docs/2026_2Q_conference_eng.pdf | Location / identity only. No revenue、demand、shipment、outlook、capacity又はpricing Fact is admitted by this record. |
| AI / Data Center product source | Entry Sources A and B above | Limited direct-relation inspection only. |
| IR / News archive | Samsung Global IR Earnings / Public Disclosures and Samsung Global Newsroom Semiconductor archive | Search surface confirmed; archive completeness is not asserted. |

**Author assessment — condition 2: Met.** cut-off前のSamsung公式Source EventがAI Infrastructure / Data CenterとHBM、server DRAM / SOCAMM及びV-NAND-based enterprise SSDを直接結び付けている。これはeligibility relationだけであり、Evidence Factを生成しない。

### 5.5 Provisional classification / use boundary

| Grain | Provisional classification | Boundary |
| --- | --- | --- |
| A-1 / A-4 product stage | Issuer current mass-production assertion | Source Aはpublication-event時点の`now / currently in mass production`に限定し、mass-production commencementへ変換しない。production quantity、capacity、shipment、revenue、customer adoption又はmarket shareを補完しない。HBM4とSOCAMM2を一つのproduction seriesにしない。Source BのPM1763 mass-production commencement Actualとは別grainとして保持する。 |
| A-2 / A-3 named relation | Issuer product / named-platform designed-for relation and grouped NVIDIA AI infrastructure lineup assertion | designed-forをprocurement、order、deployment、customer-wide adoption、shipment又はrevenueへ変換しない。grouped lineupから各製品の同一stageを推定しない。 |
| A-4 / A-5 application / Plan | Issuer application positioning; PM1763 demonstration Plan | positioning / demonstrationをavailability、adoption、shipment、revenue又はperformance superiorityへ変換しない。 |
| B-1 PM1763 stage | Issuer mass-production commencement Actual | Source Aと同一製品のcross-event relationを保持し、二度のproduction進展又は独立需要signalとして数えない。 |
| B-2 / B-3 application / validation | Issuer application positioning; issuer-speaker validation-completion assertion | validationをnamed-customer adoption、order、shipment quantity、revenue、benchmark superiority又はuniversal workload適合へ変換しない。 |

HBM、SOCAMM2及びenterprise SSDを共通unit、capacity、price又はrevenue denominatorへ換算しない。Device Solutions、Foundry、Logic及びPackagingのFactをAI Memoryへ配賦しない。

### 5.6 Cross-sprint / Phase 1 result

2026-08-11に、Micron / SK hynixと同じ実在5 rootをread-only検索した。作成中の`*Phase2CandidateEligibility*.md`はself-documentとしてglob除外した。

| Query | Method | File hits | Relevant disposition |
| --- | --- | ---: | --- |
| `Samsung Electronics` | literal case-insensitive | 3 | Phase 2 Scope Design / Decision及びPhase 1 generic Scope記述のみ。既存Samsung company-specific Research / Evidence Factなし。 |
| `Samsung` | literal case-insensitive | 4 | 上記3件と既存Industry Knowledgeのgeneric issuer記述。Entry Source A / Bと同一Source Event / position / grainなし。 |
| `HBM` | literal case-insensitive | 3 | Phase 1 / 2 generic Scope及び既存Industry Knowledgeのgeneric HBM記述。同一Source Event / position / grainなし。 |
| exact token `005930` | PCRE2 case-insensitive `(?<![A-Za-z0-9])005930(?![A-Za-z0-9])` | 0 | matchなし。 |

検索はerrorなしで完了した。

**Result:** New candidate within the searched local set. この結果は検索集合と確認日に限定され、repository全体又は外部世界における不存在証明ではない。

### 5.7 Candidate-specific stop condition — condition 3

次の条件でSamsung P2-1作業を停止する。

1. Official direct relation 1件以上をSource Event / URL / positionとともに再現した。
2. Annual filing、最新四半期、AI / Data Center product source及びIR / News search surfaceの所在を確認した。
3. Cross-sprint / Phase 1限定検索を実施し、同一Fact再発行の有無を記録した。
4. Provisional classification、use boundary及びscope deltaを記録した。

2Q FY2026の数値 / demand / HBM4E shipment / pricing / outlook、HBM4 performance、PM1763 performance / capacity / cooling及び追加Newsroom eventの全文inspectionはP2-1の必要条件を超えるため実施しない。

**Author assessment — condition 3: Met.**

### 5.8 Proposed scope delta

| Dimension | Proposed delta |
| --- | --- |
| Issuer | Samsung Electronics Co., Ltd.をMixed Memory benchmark candidateとして追加 |
| Product family | Memory / Storage — HBM、server DRAM / SOCAMM、V-NAND-based enterprise SSD |
| Permitted relation | Samsung公式SourceがAI Infrastructure / Data Center / AI-HPC server又はnamed platformへ直接結び付けるproduct / application / stage / relation grain |
| Period | FY2021以降。主要分析期間はFY2022以降。Active research cut-offはGate P2-2 Decisionで継承又は更新を明示 |
| Geography | Global。地域又はcustomer別allocationはSourceが直接分離する場合のみ |
| Exclusions | Device Solutions全体、Foundry / Logic / Packaging、mobile / edge memory、share / ranking、industry total、未開示AI revenue、anonymous identity推定、cross-source supplier benefit、Phase 1 ID継承 |

### 5.9 Author recommendation

**Proceed to the Gate P2-2 consideration package.**

Samsung Electronicsはconditions 1–3の独立review Accepted後、2026-08-13 Option A Decisionによりcondition 4が成立し、限定active Research Scopeへ追加された。

## 6. Candidate Record — Kioxia Holdings

### 6.1 Candidate / product family

- Candidate: Kioxia Holdings Corporation / Kioxia Corporation
- Proposed family: Memory / Storage — NAND flash、enterprise SSD、Data Center SSD、AI storage
- Candidate role: Japan-equity Memory candidate
- Applicable local RQ: `S3-DCAI-P2-RQ-001`、`003`、`004`、`005`、`006`

Candidate listingはKioxiaのAI revenue、market share、competitive leadership、supplier benefit又は投資利用可能性をFactとして確定しない。

### 6.2 Phase 1 RQ / Gap reference and materiality — condition 1

| Required field | Candidate record |
| --- | --- |
| Phase 1 RQ / Gap | Phase 1はDemand-side、Compute及びPower supplyを被覆したが、日本株Memory issuerであるKioxiaのNAND / enterprise and Data Center SSDについて、AI infrastructure用途、NVIDIA architecture relation、development / sample stage、capacity denominator及びissuer-specific sales scopeを企業単位で検証していない。 |
| Core Scopeで解消不能な理由 | Phase 1のhyperscaler CapEx、NVIDIA platform revenue、ROHM / Infineon / Renesas power product Factから、KioxiaのNAND / SSD product stage、shipment、revenue又はbenefitをcross-source生成できない。Legacy Kioxia inventory researchもfinancial-inventory semanticsであり、AI storage product relationを代替しない。 |
| Candidate-specific materiality | Phase 2 Memory / Storage scopeのNAND / enterprise SSD grainと、日本株follow-upのGapを公式issuer disclosureで検証するCandidateである。これはmarket importance、leadership又はinvestment meritのFactではない。 |

**Author assessment — condition 1:** Met。

### 6.3 Official direct-relation sources — condition 2

#### Entry Source A

| Field | Record |
| --- | --- |
| Issuer | Kioxia Corporation |
| Official source title | *Kioxia Announces New SSD Model Optimized for AI GPU-Initiated Workloads* |
| Publication Event | 2026-03-17; time / timezone Unknown |
| Version / URL | current official HTML inspected 2026-08-11; https://www.kioxia.com/en-jp/business/news/2026/20260317-1.html |
| Source position | headline / subheadline; opening paragraphs; paragraphs describing NVIDIA Storage-Next and KIOXIA GP Series; Makoto Hamada statement; CM9 paragraph |

Source-faithful candidate statements — provisional atomic grains:

1. KioxiaはSuper High IOPS SSD / KIOXIA GP Seriesのdevelopmentを発表し、AI systemsでGPUがflash memoryへ直接accessしてHBMを拡張する製品として位置付けている。
2. KIOXIA GP Series evaluation samplesはselect customers向けに2026年末までにavailableとなるPlanである。
3. KioxiaはNVIDIA Storage-Next initiativeをKIOXIA GP Seriesでsupportすると述べ、Kioxia speakerは同relationをAI storage architectureを形作るcollaborationとして説明している。
4. KioxiaはKIOXIA CM9 Seriesをlarge-scale inference environment向けSSDとして位置付け、samplesをQ3 2026からshipping開始するPlanを述べている。

#### Entry Source B

| Field | Record |
| --- | --- |
| Issuer | Kioxia Corporation |
| Official source title | *Kioxia Commences Sample Shipments of 10th-Generation BiCS FLASH Devices Delivering High Performance, High Capacity and Low Power Consumption* |
| Publication Event | 2026-07-03; time / timezone Unknown |
| Version / URL | current official HTML inspected 2026-08-11; https://www.kioxia.com/en-jp/about/news/2026/20260703-1.html |
| Source position | headline / subheadline; opening paragraphs through enterprise / Data Center SSD and AI storage statement; sample-purpose note |

Source-faithful candidate statements — provisional atomic grains:

1. Kioxiaは1Tb TLC 10th-generation BiCS FLASH deviceのsample shipmentsを開始したと述べている。
2. Kioxiaは同deviceを主に自社enterprise and Data Center SSDへ組み込み、AI storage需要へ対応するlineupを強化すると説明している。
3. 当該sampleはfunctional check purposeであり、sample specificationsはmass-production時と異なり得る。

Entry Source Aのfuture sample PlanとEntry Source Bのdifferent product-level sample-shipment Actualを、同一製品、二度の同一stage進展、corroborationによる確度加算又は共通需要signalとして結合しない。

#### Minimum Source Set — located; only the Entry Sources above received limited P2-1 content inspection

| Source family | Located official source | P2-1 treatment |
| --- | --- | --- |
| Annual filing | *Annual Securities Report for the Fiscal Year Ended March 2026*; 2026-06-24; https://www.kioxia-holdings.com/content/dam/kioxia-hd/en-jp/ir/library/securities/asset/Annual-Securities-Report-FY2025-EN.pdf | Location / identity only. No full Fact inspection for this Candidate record. |
| Latest quarterly before cut-off | *Consolidated Financial Results for the Three Months Ended June 30, 2026 (Under IFRS)*; 2026-07-31; https://ssl4.eir-parts.net/doc/285A/tdnet/2859908/00.pdf | Location / identity only. No revenue、outlook、demand、shipment、capacity又はpricing Fact admitted. |
| Official IR / strategy search surface | Kioxia Holdings IR News / Investor Day; https://www.kioxia-holdings.com/en-jp/ir/news.html ; https://www.kioxia-holdings.com/en-jp/news/2026/20260602-1.html | Location / identity only for Minimum Source Set. No strategy number or target admitted. |
| Official product / News search surface | Kioxia Corporation News; https://www.kioxia.com/en-jp/business/news.html | Entry Source A/B identity and search surface confirmed. Additional events not fully inspected. |

**Author assessment — condition 2:** Met。cut-off前のKioxia公式SourceでNAND / SSDとAI systems、NVIDIA Storage-Next、large-scale inference、enterprise / Data Center SSD及びAI storageのdirect relationをSource positionまで再現した。ただしCandidate eligibility relationであり、Evidence Fact又はScope Activationではない。

### 6.4 Provisional classification / use boundary

| Grain | Provisional classification | Boundary |
| --- | --- | --- |
| A-1 GP Series | Issuer product-development announcement / AI-system application positioning | developmentをavailability、sample shipment、mass production、customer adoption、revenue又はperformance superiorityへ変換しない。 |
| A-2 GP Series sample | Issuer future evaluation-sample availability Plan | select customersをnamed customer、order又はadoptionへ変換せず、2026年末までのPlanをActual化しない。 |
| A-3 NVIDIA relation | Issuer-reported initiative support / collaboration relationship | support / collaborationをprocurement、design win、deployment、shipment、revenue又はcommercial successへ変換しない。 |
| A-4 CM9 | Issuer application positioning / future sample-shipment Plan | capacity / endurance / performanceをcommon AI storage denominatorへ変換せず、Q3 2026 PlanをActual化しない。 |
| B-1 10th-generation BiCS FLASH | Issuer sample-shipment commencement Actual | functional-check sampleをmass production、volume production、customer qualification、order、revenue又はmarket adoptionへ昇格しない。 |
| B-2 enterprise / Data Center SSD | Issuer intended integration / AI-storage application positioning | future integrationをcurrent product availability又はAI-specific revenueへ変換しない。enterprise storage全体をAI専用へ配賦しない。 |

GP Series、CM9、10th-generation BiCS FLASH及びenterprise / Data Center SSDを同一product、capacity、unit、price、shipment又はrevenue denominatorへ統合しない。

### 6.5 Cross-sprint / Phase 1 result — condition 3 duplicate control

2026-08-11に、Micron / SK hynix / Samsungと同じ実在5 rootをread-only検索した。作成中の`*Phase2CandidateEligibility*.md`はself-documentとしてglob除外した。

| Query | Method | File hits | Relevant disposition |
| --- | --- | ---: | --- |
| `Kioxia Holdings` | literal case-insensitive | 21 | Legacy Automotive配下のEDINET inventory / taxonomy / architecture資料とPhase 1 / Phase 2 Scope資料。既存financial-inventory Factはread-only Referenceであり、本Entry Source又はAI storage grainと同一ではない。 |
| `Kioxia` | literal case-insensitive | 31 | 上記Legacy inventory family、Scope / Decision及び関連generic設計資料。同一Source Event / position / AI storage Fact grainなし。 |
| `NAND` | literal case-insensitive | 10 | Industrial Power / Phase 1 / Phase 2及びgeneric semiconductor context。同一Kioxia Source Event / position / grainなし。 |
| exact token `285A` | PCRE2 token boundary | 1 | Legacy EDINET company-selection record。今回のEntry Source又はAI storage Factではない。 |
| `GP Series` / `Storage-Next` / `20260317-1` / `10th-generation BiCS` | literal case-insensitive; query別 | 0 / 0 / 0 / 0 | Entry Source A/Bと同一identity / position / grainの既存local Factなし。 |

検索対象、確認日及び語句に限定した結果であり、repository外又は外部世界での不存在を証明しない。Legacy Kioxia inventory Factを再発行せず、将来Researchが必要な場合も既存ID / artifactをread-only参照する。

**Author assessment — condition 3 duplicate control:** Met。

### 6.6 Candidate-specific stop condition — condition 3

次の条件を記録したため、Kioxia P2-1限定探索を停止する。

1. Official direct relation 1件以上をSource Event / URL / positionとともに再現した。
2. Annual filing、最新四半期、official IR / strategy及びproduct / News search surfaceの所在を確認した。
3. Cross-sprint / Phase 1限定検索を実施し、Legacy inventory Factとのgrain差及び同一Fact再発行の有無を記録した。
4. Provisional classification、use boundary及びscope deltaを記録した。

Annual / Q1 FY2026の数値、Investor Dayのtarget / investment、GP / CM9 performance and capacity、10th-generation BiCS performance / production Plan、追加News event及びcustomer relationの全文inspectionはP2-1の必要条件を超えるため開始しない。

**Author assessment — condition 3 stop:** Met。

### 6.7 Proposed scope delta

| Dimension | Proposed addition / boundary |
| --- | --- |
| Issuer | Kioxia Holdings Corporation / Kioxia CorporationをJapan-equity Memory candidateとして追加 |
| Product | NAND flash、GP / CM Series、enterprise / Data Center SSD及びAI storage relation。Research activation時はproduct / generation / stageをatomicに分離する。 |
| Period | FY2021以降、主要分析期間FY2022以降。Issuer fiscal year、Publication Event及びApplicable Periodを保持。 |
| Relation | NVIDIA Storage-Next support / collaboration、AI systems、large-scale inference及びAI storage application。関係をadoption / procurement / revenueへ昇格しない。 |
| Exclusions | Consumer / mobile storage、enterprise storage全体のAI配賦、market share / ranking、未開示AI revenue、Legacy inventory Fact再発行、cross-source supplier benefit、Phase 1 ID継承 |

### 6.8 Author recommendation

**Proceed to the Gate P2-2 consideration package.**

Kioxia Holdings / Kioxia Corporationはconditions 1–3の独立review Accepted後、2026-08-13 Option A Decisionによりcondition 4が成立し、限定active Research Scopeへ追加された。

## 7. Candidate Record — Broadcom

### 7.1 Candidate / product family

- Candidate: Broadcom Inc.
- Proposed family: Network / Connectivity — Ethernet switching、AI NIC、optical DSP / optics、retimer / AEC、PCIe connectivity
- Candidate role: Network / connectivity candidate
- Applicable local RQ: `S3-DCAI-P2-RQ-002`、`003`、`004`、`005`

Candidate listingはBroadcom AI revenue、customer identity、market share、product leadership、supplier benefit又は投資利用可能性をFactとして確定しない。

### 7.2 Phase 1 RQ / Gap reference and materiality — condition 1

| Required field | Candidate record |
| --- | --- |
| Phase 1 RQ / Gap | Phase 1はDemand-side、Compute及びPower supplyを被覆したが、AI cluster / Data Center向けEthernet switching、NIC、optical DSP / optics、retimer / AEC及びPCIe connectivityのissuer-specific product、stage、bandwidth denominator、shipment / production及びrelationship grainを企業単位で検証していない。 |
| Core Scopeで解消不能な理由 | Microsoft / Alphabet CapEx、NVIDIA platform revenue又はPower supplier Factから、Broadcom networking product、production shipment、AI semiconductor revenue、customer又はoptical contentをcross-source生成できない。Phase 1 NVIDIAのEthernet記述もBroadcom製品Factを代替しない。 |
| Candidate-specific materiality | Phase 2 Network / Optical scopeのswitch、NIC及びoptical-connectivity grainを公式issuer disclosureで検証するCandidateである。これはmarket leadership、share又はinvestment meritのFactではない。 |

**Author assessment — condition 1:** Met。

### 7.3 Official direct-relation sources — condition 2

#### Entry Source A

| Field | Record |
| --- | --- |
| Issuer | Broadcom Inc. |
| Official source title | *Broadcom Now Shipping World’s First 102.4 Tbps Switch in Production Volume* |
| Publication Event | 2026-03-12; time / timezone Unknown |
| Version / URL | current official investor-relations HTML inspected 2026-08-11; https://investors.broadcom.com/news-releases/news-release-details/broadcom-now-shipping-worlds-first-1024-tbps-switch-production |
| Source position | headline / subheadline; opening issuer paragraphs through Tomahawk 6 AI-network application statement |

Source-faithful candidate statements — provisional atomic grains:

1. BroadcomはTomahawk 6 family switch seriesがproduction volumeでshipping中であると発表している。
2. BroadcomはTomahawk 6をtraining / inference向けscale-out and scale-up AI networksにoptimizedされたswitchとして位置付けている。
3. Broadcom speakerはTomahawk 6のproduction移行をAI infrastructure design及びcustomer networking needsの文脈で説明している。

#### Entry Source B

| Field | Record |
| --- | --- |
| Issuer | Broadcom Inc. |
| Official source title | *Broadcom Showcases Industry-Leading Solutions for Scaling AI Infrastructure at OFC 2026* |
| Publication Event | 2026-03-12; time / timezone Unknown |
| Version / URL | current official investor-relations HTML inspected 2026-08-11; https://investors.broadcom.com/news-releases/news-release-details/broadcom-showcases-industry-leading-solutions-scaling-ai |
| Source position | headline / subheadline; opening portfolio paragraphs; Taurus paragraph; AI-infrastructure technology list; OCI MSA paragraph |

Source-faithful candidate statements — provisional atomic grains:

1. Broadcomはgigawatt-scale AI clusters向けのopen / scalable / power-efficient AI infrastructure portfolio expansionを発表している。
2. BroadcomはEthernet switch with CPO、optical DSP、Ethernet retimer / AEC及びPCIe switch / retimerをOFC 2026でshowcaseするPlanとして列挙している。
3. BroadcomはTaurus 400G/lane optical DSPと400G EML / PDをdebutし、1.6T transceiver及びfuture 3.2T transceiver / 204.8T switching platform向けproduct positioningを述べている。
4. BroadcomはTomahawk 6をproduction volumeでshipping中と再掲している。これはEntry Source Aの同日product-stage Factのcorroborating restatementであり、別のproduction進展又は独立signalではない。
5. BroadcomはThor Ultra AI NIC、optics、NPO、Ethernet retimer / AEC及びPCIe Gen6 switch / retimerをAI infrastructure向けportfolio / applicationとして列挙している。

Source B内の3.5D XPU / XDSiP及びそのproduction statementはNetwork / Connectivity candidate scope外のcontextであり、本Candidate grainへ収載しない。対象化にはScope Design revision、独立review及び別Decisionを必要とする。

Entry Source A/Bは同じPublication dateだが別Source Eventである。Tomahawk 6 current shipping statementを二度のproduction進展、二つの独立需要signal又はcorroborationによる確度加算として数えない。portfolio列挙から各製品が同一stage、shipment、customer又はrevenueを持つと推定しない。

#### Minimum Source Set — located; only the Entry Sources above received limited P2-1 content inspection

| Source family | Located official source | P2-1 treatment |
| --- | --- | --- |
| Annual filing | Broadcom 2025 Annual Report on Form 10-K; filed 2025-12-18; fiscal year ended 2025-11-02; https://investors.broadcom.com/sec-filings/sec-filing/10-k/0001730168-25-000121 | Location / identity only. No full Fact inspection. |
| Latest quarterly release before cut-off | *Broadcom Inc. Announces Second Quarter Fiscal Year 2026 Financial Results and Quarterly Dividend*; 2026-06-03; https://investors.broadcom.com/news-releases/news-release-details/broadcom-inc-announces-second-quarter-fiscal-year-2026-financial | Location / identity only. No AI revenue、guidance、customer、demand又はproduct allocation admitted. |
| Latest quarterly filing before cut-off | Broadcom Form 10-Q; filed 2026-06-09; official Financial Reports surface https://investors.broadcom.com/financial-information/financial-reports | Location / identity only. No full Fact inspection. |
| Official product / News search surface | Broadcom Financial News / product releases; https://investors.broadcom.com/financial-information/financial-news-releases | Entry Source A/B identity and search surface confirmed. Additional events not fully inspected. |

**Author assessment — condition 2:** Met。cut-off前のBroadcom公式SourceでTomahawk 6、Ethernet switching、AI NIC、optical DSP / optics、retimer / AEC及びPCIe connectivityとAI networks / AI infrastructureのdirect relationをSource positionまで再現した。ただしCandidate eligibility relationであり、Evidence Fact又はScope Activationではない。

### 7.4 Provisional classification / use boundary

| Grain | Provisional classification | Boundary |
| --- | --- | --- |
| A-1 Tomahawk 6 stage | Issuer current production-volume shipment assertion | shipment volume、customer、order、revenue、share、deployment count又はindustry demandを補完しない。 |
| A-2 Tomahawk 6 application | Issuer AI-network product / application positioning | optimizedをbenchmark superiority、adoption、shipment quantity又はcustomer resultへ変換しない。 |
| A-3 speaker statement | Issuer-speaker execution / customer-needs narrative | production移行の説明をcustomer adoption、commercial success又はAI revenueへ変換しない。 |
| B-1 portfolio | Issuer AI-infrastructure portfolio-expansion announcement | portfolio breadthをavailability、product-stage score、shipment、revenue、share又はcommon architectureへ変換しない。 |
| B-2 OFC showcase | Issuer event-demonstration Plan | showcase予定をavailability、customer deployment、production又はrevenueへ変換しない。 |
| B-3 Taurus | Issuer product introduction / current and future application positioning | debutをvolume availabilityへ昇格せず、future 3.2T / 204.8T positioningをActual化しない。 |
| B-4 Tomahawk 6 | Corroborating restatement of Entry Source A current shipment stage | 別Raw / Evidence候補、二度の進展、独立signal又は確度加算にしない。 |
| B-5 connectivity lineup | Issuer product / application positioning | Thor Ultra、optics、NPO、retimer / AEC、PCIeを同一stage、unit、bandwidth、customer、shipment又はrevenueへ統合しない。3.5D XPU / XDSiPはout-of-scope contextであり収載しない。 |

Switch bandwidth、SerDes lane rate、optical lane rate、transceiver rate、cluster XPU count及びAI semiconductor revenueを相互換算又は共通denominator化しない。

### 7.5 Cross-sprint / Phase 1 result — condition 3 duplicate control

2026-08-11に、先行4社と同じ実在5 rootをread-only検索した。作成中の`*Phase2CandidateEligibility*.md`はself-documentとしてglob除外した。

| Query | Method | File hits | Relevant disposition |
| --- | --- | ---: | --- |
| `Broadcom` | literal case-insensitive | 3 | Phase 2 Scope Design / Decision及びPhase 1 generic Scope記述のみ。既存Broadcom company-specific Research / Evidence Factなし。 |
| exact token `AVGO` | PCRE2 token boundary | 0 | ticker一致なし。 |
| `Tomahawk` | literal case-insensitive | 0 | Entry Source A/Bと同一product / Source Event / position / grainなし。 |
| `Ethernet` | literal case-insensitive | 4 | Phase 1 NVIDIA Raw / SFI / Company Research / EVRのissuer-defined platform context。Broadcom Source Event / product Factではなく、read-only upstream contextとして保持する。 |
| `Jericho` | literal case-insensitive | 0 | 同一product relationなし。 |

検索対象、確認日及び語句に限定した結果であり、repository外又は外部世界での不存在を証明しない。NVIDIA Ethernet contextをBroadcom adoption、customer relation、shipment又はrevenueへ変換しない。

**Author assessment — condition 3 duplicate control:** Met。

### 7.6 Candidate-specific stop condition — condition 3

次の条件を記録したため、Broadcom P2-1限定探索を停止する。

1. Official direct relation 1件以上をSource Event / URL / positionとともに再現した。
2. Annual filing、最新四半期release / filing及びofficial product / News search surfaceの所在を確認した。
3. Cross-sprint / Phase 1限定検索を実施し、NVIDIA Ethernet contextとのgrain差及び同一Fact再発行の有無を記録した。
4. Provisional classification、use boundary及びscope deltaを記録した。

Q2 FY2026のAI semiconductor revenue / guidance / customer / demand、Tomahawk / Taurus / Thor / optical performance、product availability、additional partner quotes、Jericho / custom accelerator及び追加News eventの全文inspectionはP2-1の必要条件を超えるため開始しない。

**Author assessment — condition 3 stop:** Met。

### 7.7 Proposed scope delta

| Dimension | Proposed addition / boundary |
| --- | --- |
| Issuer | Broadcom Inc.をNetwork / Connectivity candidateとして追加 |
| Product | Ethernet switching、AI NIC、optical DSP / optics、retimer / AEC及びPCIe connectivity。Research activation時はproduct / generation / stageをatomicに分離する。 |
| Period | FY2021以降、主要分析期間FY2022以降。Broadcom fiscal period、Publication Event及びApplicable Periodを保持。 |
| Relation | AI scale-up / scale-out / scale-across network、gigawatt-scale AI cluster及びend-to-end connectivity。関係をcustomer adoption / revenueへ昇格しない。 |
| Exclusions | Infrastructure software、enterprise / edge connectivity、custom accelerator / XPU / XDSiP product and revenue grain、customer identity、market share / ranking、cross-source supplier benefit、Phase 1 ID継承 |

### 7.8 Author recommendation

**Proceed to the Gate P2-2 consideration package.**

Broadcomはconditions 1–3の独立review Accepted後、2026-08-13 Option A Decisionによりcondition 4が成立し、限定active Research Scopeへ追加された。

## 8. Candidate Record — Marvell Technology

### 8.1 Candidate / product family

- Candidate: Marvell Technology, Inc.
- Proposed family: Network / Optical — optical DSP / SerDes、Ethernet / optical interconnect、PCIe / CXL switch、PCIe retimer、AEC / AOC partner-enablement relation
- Candidate role: Network / optical candidate
- Applicable local RQ: `S3-DCAI-P2-RQ-002`、`003`、`004`、`005`

Candidate listingはMarvell data-center revenue、customer identity、market share、product leadership、supplier benefit又は投資利用可能性をFactとして確定しない。

### 8.2 Phase 1 RQ / Gap reference and materiality — condition 1

| Required field | Candidate record |
| --- | --- |
| Phase 1 RQ / Gap | Phase 1はDemand-side、Compute及びPower supplyを被覆したが、AI Data Center向けMarvell optical DSP、SerDes、switch、retimer及びPCIe / CXL connectivityのissuer-specific product、stage、bandwidth denominator、shipment / sample、ならびにAEC / AOC partner-enablement relationship grainを企業単位で検証していない。 |
| Core Scopeで解消不能な理由 | hyperscaler CapEx、NVIDIA platform revenue又はPower supplier Factから、Marvell optical / PCIe product、customer adoption、shipment、revenue又はsupplier benefitをcross-source生成できない。Phase 1 architecture記述もMarvell製品Factを代替しない。 |
| Candidate-specific materiality | Phase 2 Network / Optical scopeのoptical DSP及びscale-up interconnect grainを公式issuer disclosureで検証するCandidateである。これはmarket leadership、share又はinvestment meritのFactではない。 |

**Author assessment — condition 1:** Met。

### 8.3 Official direct-relation sources — condition 2

#### Entry Source A

| Field | Record |
| --- | --- |
| Issuer | Marvell Technology, Inc. |
| Official source title | *Marvell Ushers In the 1.6T Era with Expanded Optical DSP Platform Portfolio, Redefining AI Data Center End-to-End Connectivity* |
| Publication Event | 2026-03-12; time / timezone Unknown |
| Version / URL | current official HTML inspected 2026-08-11; https://www.marvell.com/company/newsroom/marvell-1-6t-optical-dsp-ai-data-center-connectivity.html |
| Source position | headline / subheadline; opening through Ara shipment paragraph; new-product list; AI-infrastructure / connectivity paragraphs; portfolio and Availability sections |

Source-faithful candidate statements — provisional atomic grains:

1. Marvellは1.6T optical DSP platform portfolioのexpansionを発表し、next-generation AI Data Center end-to-end connectivityへ直接位置付けている。
2a. MarvellはAraがglobal customers向けにmass volumeでshipping中であると述べている。
2b. MarvellはAraがhyperscalers / cloud providersによるAI Data Center向け1.6T pluggable connectivity deploymentをenableしていると述べている。
3. MarvellはAra T、Ara X、Petra及びAquila Mを3nm 1.6T optical DSP platform portfolioのnext waveとしてintroductionしている。
4. MarvellはDSP / SerDes / switching / interconnect / driver / TIAをscale-up、scale-out and scale-across AI infrastructure向けconnectivity portfolioとして位置付けている。
5. Ara X、Ara T、Petra及びAquila M DSPはcustomers向けにQ1 2026からsampling中であるとのissuer assertionを記載している。

#### Entry Source B

| Field | Record |
| --- | --- |
| Issuer | Marvell Technology, Inc. |
| Official source title | *Marvell Launches Industry’s First 260-lane PCIe 6.0 Switch for AI Data Center Scale-up Infrastructure* |
| Publication Event | 2026-03-17; time / timezone Unknown |
| Version / URL | current official HTML inspected 2026-08-11; https://www.marvell.com/company/newsroom/marvell-260-lane-pcie-6-switch-ai-data-center-scale-up.html |
| Source position | headline / subheadline; opening Structera S paragraphs; expanded PCIe portfolio; Availability section |

Source-faithful candidate statements — provisional atomic grains:

1. MarvellはStructera S 60260 PCIe 6.0 switchをlaunchし、scale-up AI Data Center performance / design flexibilityへ直接位置付けている。
2. MarvellはAlaska P PCIe retimer product lineをAI accelerator、GPU、XPU、CPU、SSD及びCXL device間のconnectionとaccelerated AI Data Center infrastructure向けとして記述している。
3. MarvellはStructera S PCIe 60260のcustomer samplingをcalendar Q3 2026に開始する予定と述べている。
4. MarvellはStructera S PCIe 6.0 engineering test samplesがpublication-event時点でavailableであると述べている。
5. MarvellはStructera S PCIe 5.0 switchesがpublication-event時点でavailableであると述べている。
6. MarvellはStructera SとAlaska Pのcombined solutionがAEC partnersによるPCIe 6.0 cable reach up to 7 meters及びAOC partnersによるreach beyond 7 metersをenableすると述べている。

Entry Source A/Bのoptical DSPとPCIe switch / retimerを、同一product、同一sample stage、共通shipment又はcommon demand signalへ統合しない。Aのmass-volume shipping、Aのsampling、Bのfuture sampling Plan、Bのengineering-test sample availability及びBのcurrent product availabilityを別stageとして保持する。

#### Minimum Source Set — located; only the Entry Sources above received limited P2-1 content inspection

| Source family | Located official source | P2-1 treatment |
| --- | --- | --- |
| Annual filing | Marvell Form 10-K for fiscal year ended 2026-01-31; filed 2026-03-11; https://investor.marvell.com/sec-filings/all-sec-filings/content/0001835632-26-000011/mrvl-20260131.htm | Location / identity only. No full Fact inspection. |
| Latest quarterly release before cut-off | *Marvell Technology, Inc. Reports First Quarter of Fiscal Year 2027 Financial Results*; 2026-05-27; https://investor.marvell.com/news-events/press-releases/detail/1023/marvell-technology-inc-reports-first-quarter-of-fiscal-year-2027-financial-results | Location / identity only. No revenue、outlook、customer、demand又はproduct allocation admitted. |
| Latest quarterly filing before cut-off | Marvell Form 10-Q; filed 2026-05-28; official Quarterly Reports surface https://investor.marvell.com/sec-filings/quarterly-reports | Location / identity only. No full Fact inspection. |
| Official product / News search surface | Marvell Newsroom / Press Releases; https://www.marvell.com/company/newsroom/press-releases.html | Entry Source A/B identity and search surface confirmed. Additional events not fully inspected. |

**Author assessment — condition 2:** Met。cut-off前のMarvell公式Sourceでoptical DSP / SerDes、switching、PCIe switch / retimer、AEC / AOC partner-enablement及びend-to-end connectivityとAI Data Center / AI infrastructureのdirect relationをSource positionまで再現した。ただしCandidate eligibility relationであり、Evidence Fact又はScope Activationではない。

### 8.4 Provisional classification / use boundary

| Grain | Provisional classification | Boundary |
| --- | --- | --- |
| A-1 optical DSP portfolio | Issuer portfolio-expansion announcement / AI Data Center application positioning | expansionをavailability、shipment、revenue、share又はcommon customer deploymentへ変換しない。 |
| A-2a Ara shipment stage | Issuer current mass-volume shipment assertion | global customersをhyperscalers / cloud providersと同一party又はnamed customerへ変換せず、volume、order、revenue、share又はcustomer countを補完しない。 |
| A-2b Ara relation | Issuer-reported anonymous-party deployment-enablement assertion | hyperscalers / cloud providersをglobal customersと同一party又はnamed customerへ変換せず、adoption count、order、shipment、revenue又はcommercial successを補完しない。 |
| A-3 new DSP products | Issuer product introduction | introductionをavailability、mass production、shipment又はadoptionへ昇格しない。 |
| A-4 connectivity portfolio | Issuer product / AI-infrastructure application positioning | portfolio breadthをstage、unit、revenue、share又はcommon architectureへ変換しない。 |
| A-5 sampling | Issuer current customer-sampling assertion with quarter-level start timing | sample quantity、customer identity、qualification、order、volume production、revenue又はadoptionを補完しない。 |
| B-1 Structera S 60260 | Issuer product launch / AI Data Center application positioning | launchをcurrent volume availability、adoption、shipment又はrevenueへ変換しない。 |
| B-2 Alaska P | Issuer product / application positioning | product relationをcustomer deployment、shipment、revenue又はuniversal system configurationへ変換しない。 |
| B-3 future sample | Issuer future customer-sampling Plan | Q3 2026 PlanをActual化しない。 |
| B-4 engineering test sample | Issuer current engineering-test-sample availability assertion | engineering sampleをcustomer qualification、commercial availability、mass production、shipment又はrevenueへ昇格しない。 |
| B-5 PCIe 5.0 switch | Issuer current product-availability assertion | availabilityをcustomer adoption、shipment volume、revenue又はAI-only useへ変換しない。 |
| B-6 AEC / AOC relation | Issuer partner-enablement / application relationship | AEC / AOCをMarvell製品へ変換せず、partner identity、adoption、availability、shipment又はrevenueを補完しない。reachをperformance benchmark又はcommon deployment denominatorへ変換しない。 |

Optical lane rate、module rate、PCIe lane count、switch radix、AEC / AOC reach、installed lane count、shipment volume及びData Center revenueを相互換算又は共通denominator化しない。

### 8.5 Cross-sprint / Phase 1 result — condition 3 duplicate control

2026-08-11に、先行5社と同じ実在5 rootをread-only検索した。作成中の`*Phase2CandidateEligibility*.md`はself-documentとしてglob除外した。

| Query | Method | File hits | Relevant disposition |
| --- | --- | ---: | --- |
| `Marvell Technology` | literal case-insensitive | 1 | Phase 2 Scope DesignのCandidate記述のみ。既存Marvell company-specific Research / Evidence Factなし。 |
| `Marvell` | literal case-insensitive | 3 | Phase 2 Scope Design / Decision及びPhase 1 generic Scope記述のみ。 |
| exact token `MRVL` | PCRE2 token boundary | 0 | ticker一致なし。 |
| `optical DSP` | literal case-insensitive | 0 | Entry Source Aと同一product / Source Event / position / grainなし。 |
| `Structera` | literal case-insensitive | 0 | Entry Source Bと同一product / Source Event / position / grainなし。 |
| exact token `Ara` | PCRE2 token boundary | 0 | Entry Source Aと同一product grainなし。 |

検索対象、確認日及び語句に限定した結果であり、repository外又は外部世界での不存在を証明しない。Phase 1 architecture contextをMarvell adoption、customer relation、shipment又はrevenueへ変換しない。

**Author assessment — condition 3 duplicate control:** Met。

### 8.6 Candidate-specific stop condition — condition 3

次の条件を記録したため、Marvell P2-1限定探索を停止する。

1. Official direct relation 1件以上をSource Event / URL / positionとともに再現した。
2. Annual filing、最新四半期release / filing及びofficial product / News search surfaceの所在を確認した。
3. Cross-sprint / Phase 1限定検索を実施し、同一Fact再発行の有無を記録した。
4. Provisional classification、use boundary及びscope deltaを記録した。

Q1 FY2027のrevenue / outlook / customer / demand、Ara shipment volume、DSP / PCIe performance、installed base、additional partner statements、acquisition economics、custom AI accelerator及び追加News eventの全文inspectionはP2-1の必要条件を超えるため開始しない。

**Author assessment — condition 3 stop:** Met。

### 8.7 Proposed scope delta

| Dimension | Proposed addition / boundary |
| --- | --- |
| Issuer | Marvell Technology, Inc.をNetwork / Optical candidateとして追加 |
| Product | optical DSP / SerDes、switching、PCIe / CXL switch、PCIe retimer及びend-to-end connectivity。Research activation時はproduct / generation / stageをatomicに分離する。 |
| Period | FY2021以降、主要分析期間FY2022以降。Marvell fiscal period、Publication Event及びApplicable Periodを保持。 |
| Relation | AI Data Center / AI infrastructure、scale-up / scale-out / scale-across、hyperscaler / cloud anonymous relation、Structera S + Alaska PからAEC / AOC partnersへのenablement relation。AEC / AOCをMarvell製品へ変換せず、関係をnamed-customer adoption / revenueへ昇格しない。 |
| Exclusions | custom AI accelerator / ASIC、storage controller、enterprise / carrier networking、acquisition economics、customer identity、market share / ranking、cross-source supplier benefit、Phase 1 ID継承 |

### 8.8 Author recommendation

**Proceed to the Gate P2-2 consideration package.**

Marvell Technologyはconditions 1–3の独立review Accepted後、2026-08-13 Option A Decisionによりcondition 4が成立し、限定active Research Scopeへ追加された。

## 9. Common Non-use Boundary

- 本InventoryはEvidence Register又はPIT Inventoryではない。
- Phase 2 Evidence / PIT namespaceは未発行である。
- `AvailableAt = TBD — no use`。
- Catalog Eligibility = `No`。
- Candidate又はAuthor assessmentをObservation、Feature、Lead / Lag、投資signal、Catalog candidate又はCanonical Factへ変換しない。
- Gate P2-2の明示Decision前にIndustry Research Design、Source Fact Inspection、Raw、EVR、PIT又はCompany Researchを開始しない。

## 10. Next

1. Phase 2 Industry Research Design、Bridge Addendum、Official Source Inventory及びNamespace Decision Requestの独立reviewを行う。
2. finding解消とreview Accepted後にNamespace DecisionをProject Director又は適用されるIdentifier authorityへ依頼する。
3. 別Namespace Decision前はEvidence / PIT ID又はP2-4 Evidence Productionを開始しない。
