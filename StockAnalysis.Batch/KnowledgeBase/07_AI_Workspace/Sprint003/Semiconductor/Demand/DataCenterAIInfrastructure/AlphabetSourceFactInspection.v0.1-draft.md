# Alphabet — Data Center / AI Infrastructure Source Fact Inspection

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft Source Fact inspection |
| Sprint | Sprint003 |
| 対象企業 | Alphabet Inc. |
| Version | 0.1-draft |
| 作成日 | 2026-08-02 |
| Retrieval Date | 2026-08-02 |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Reviewer Status | Evidence / Knowledge / Traceability final disposition `Accepted` |
| Related Review Record | `AlphabetSourceFactInspectionIndependentReview.v0.1-draft.md` |
| Evidence ID | None — 本文書の`ALPH-SFI-xxx`はLocal inspection IDであり、Evidence IDではない |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md` |
| Stage 0 | `Sprint003DataCenterAIInfrastructureStage0IndependentReview.v0.1-draft.md` — Accepted |

> **利用境界：** 本文書はSource Fact候補をRaw Evidence化する前の検査記録である。候補のEvidence採用、`S3-EVR-xxx`又は`S3-PIT-xxx`の発行、`AvailableAt`の確定、Catalog / DDL / ML利用を許可しない。

## 1. Research Questions

| Research Question | Alphabetでの確認対象 |
| --- | --- |
| `S3-DCAI-RQ-001` | Technical Infrastructure、Data Center、AI Infrastructure、GPU及びTPUの発行者用語 |
| `S3-DCAI-RQ-002` | CapEx、資産構成、capacity増強及び需要の開示粒度 |
| `S3-DCAI-RQ-005` | 需要側投資とservers、network equipment、GPU、TPU又はspecialized AI chipsとの発行者明示関係 |
| `S3-DCAI-RQ-006` | Actual、Asset balance、Commitment、Plan及びNarrativeの分類差 |

## 2. Inspected Official Sources

| Source | Publication Event | Applicable Period | Official location | Inspection status |
| --- | --- | --- | --- | --- |
| Alphabet Inc., *2025 Form 10-K* | SEC filed 2026-02-05; accepted 2026-02-04 21:56:03（SEC index表示。timezoneはページ上で別途明示されない） | FY ended 2025-12-31 | [SEC filing index](https://www.sec.gov/Archives/edgar/data/1652044/000165204426000018/0001652044-26-000018-index.htm)、[SEC filing](https://www.sec.gov/Archives/edgar/data/1652044/000165204426000018/goog-20251231.htm) | Source Fact inspection completed for listed positions |
| Alphabet Inc., *2025 Q4 Earnings Call* | Event 2026-02-04 13:30 PT; transcript page publication date/time `Unknown` | Q4 / FY2025 results and FY2026 outlook | [Official event transcript](https://abc.xyz/investor/events/event-details/2026/2025-Q4-Earnings-Call-2026-Dr_C033hS6/default.aspx) | Source Fact inspection completed for listed positions |
| Alphabet Investor Relations, *FAQs and General Information* | Publication event `Unknown` | Current definitions at retrieval | [Official FAQ](https://abc.xyz/investor/faqs-and-general-information/default.aspx) | Definition cross-check completed; no standalone candidate where 2025 Form 10-K is authoritative and more current |

## 3. Source Fact Candidate Assessment

| Local ID | Source position | Classification | Source Fact candidate | Use boundary | Cross-sprint check | Raw Evidence recommendation |
| --- | --- | --- | --- | --- | --- | --- |
| `ALPH-SFI-001` | 2025 Form 10-K, Part I, Item 1, AI / technical infrastructure description | Issuer narrative / operating architecture | Alphabetはfull-stack AI approachの基盤をAI-optimized infrastructureと説明し、Google Cloud顧客へspecialized GPUs及び自社TPUsを含むAI accelerator optionsを提供すると記載する。 | 製品・architecture説明。GPU / TPU数量、購入額、外部調達比率、半導体需要又は供給者別売上を確定しない。 | Stage 0固定集合で既存Alphabet matchなし | **Proceed** — issuer-named AI infrastructure / accelerator relationship |
| `ALPH-SFI-002` | 2025 Form 10-K, Part II, Item 7, `Capital Expenditures` | Direct quantitative observation / Actual | Capital expendituresはFY2024 USD52.5bn、FY2025 USD91.4bn。FY2025 CapExは主としてtechnical infrastructureへの投資を反映すると発行者は説明する。 | Alphabet全社CapEx。全額をData Center、servers、AI又は半導体へ配賦しない。 | 既存matchなし | **Proceed** — actual investment baseline with non-allocation boundary |
| `ALPH-SFI-003` | 2025 Form 10-K, Part II, Item 7, `Capital Expenditures and Leases` | Issuer definition / construction lifecycle | Technical infrastructureはservers and network equipment、data center land、building construction and improvementsへの投資から構成される。Data center constructionは一般に複数年・複数phaseで、land / building取得、建設、servers / network equipmentの確保・設置を含む。 | 構成項目は個別金額を持たず、相互排他性又は半導体内訳を確定しない。複数年説明から固定Lead / Lagを導出しない。 | 既存matchなし | **Proceed** — issuer definition and multi-year deployment boundary |
| `ALPH-SFI-004` | 2025 Form 10-K, Note 7, `Property and Equipment, Net` | Direct quantitative observation / period-end gross in-service asset balance; not net carrying amount | `Property and equipment, in service`を構成するTechnical infrastructureのgross balanceは2024-12-31時点USD141.852bn、2025-12-31時点USD203.679bn。両時点で約60%はservers and network equipment、残余はdata center land and buildings and related assetsと注記される。 | 稼働中資産のgross balanceであり、Technical infrastructure全体、net carrying amount、CapEx、cash expenditure、購入量又は半導体需要ではない。`assets not yet in service`を含めず、全社accumulated depreciationをTechnical infrastructureへ配賦してnet値を推定しない。約60%を特定server component又はchipへ配賦しない。 | 既存matchなし | **Proceed** — in-service gross asset composition with explicit classification |
| `ALPH-SFI-005` | 2025 Form 10-K, Part II, Item 7, `Purchase Commitments and Other Contractual Obligations` | Direct quantitative observation / Commitment | 2025-12-31時点のpurchase commitments and other contractual obligationsはUSD149.1bn、そのうちshort-termはUSD113.0bnで、short-termの大部分はtechnical infrastructure and inventory orders関連と説明される。全体はenergy take-or-pay、licenses、technical infrastructure及びinventory orders等を主に含む。 | CommitmentでありActual支出・CapEx・発注済み半導体額ではない。USD149.1bn全体又はUSD113.0bnをtechnical infrastructureへ全額配賦しない。 | 既存matchなし | **Proceed** — commitment baseline with mixed-scope boundary |
| `ALPH-SFI-006` | 2025 Form 10-K, Part I, Item 1A, manufacturing / supply risk | Issuer narrative / operating dependency and risk | Alphabetはtechnical infrastructure向けservers and network equipment、特にspecialized AI chipsの製造・供給が少数のqualified suppliersに限られ、供給途絶はcustomer demandへの対応能力へ影響し得ると記載する。AI acceleratorsにはGPUs及び自社TPUsが含まれるとも説明する。 | Risk disclosureであり実際のshortage、発注量、supplier identity、発生確率又は売上影響額を示さない。 | 既存matchなし | **Proceed** — issuer-named AI chip supply / customer-demand dependency |
| `ALPH-SFI-007` | 2025 Form 10-K, Part I risk discussion and Part II `Capital Expenditures` | Plan / issuer narrative | AlphabetはAIを中心にtechnical infrastructureを拡大し、users / enterprise customersの需要及び内部researchを支えるため投資すると説明する。FY2026はFY2025比でservers and network equipment及びdata centersを含むtechnical infrastructure投資を大幅に増加させる見込みと記載する。 | 将来Plan。金額、実行時期、capacity量、半導体数量又は実現を確定しない。 | 既存matchなし | **Proceed** — demand-linked Plan separated from Actual |
| `ALPH-SFI-008` | 2025 Q4 Earnings Call, CFO results commentary | Issuer narrative with quantitative CapEx composition / Actual-period explanation | FY2025 CapExはUSD91.4bnで、そのvast majorityがtechnical infrastructureへ投資された。CFOは、そのtechnical-infrastructure investment部分の約60%がservers、40%がdata centers and networking equipmentと説明する。Technical-infrastructure investment部分の金額は未開示である。 | Earnings-call management classification。60 / 40の分母は総CapExではないため、USD91.4bnへ直接乗じてcomponent金額を導出しない。`ALPH-SFI-004`の期末asset balance構成とも異なり、servers比率をGPU / TPU / semiconductor比率へ変換しない。 | 既存matchなし | **Proceed** — management CapEx composition with strict denominator and comparability boundary |
| `ALPH-SFI-009` | 2025 Q4 Earnings Call, CEO opening and CFO outlook | Forecast / Plan | AlphabetはFY2026 CapExをUSD175bn–185bnと予想し、AI compute capacityへ投資してCloud customer demand、internal model developmentその他の需要を支えると説明する。 | ForecastでありActualではない。全額をData Center、Cloud、servers、GPU / TPU又は半導体需要へ配賦しない。 | 既存matchなし | **Proceed** — quantitative Plan with demand context |
| `ALPH-SFI-010` | 2025 Q4 Earnings Call, Cloud results commentary | Direct quantitative observation and issuer narrative / Actual-period context | Google Cloud backlogは2025 Q4末にUSD240bnへ達し、前四半期比55%増加、前年比で2倍超となり、複数顧客のenterprise AI offerings需要が増加要因と説明される。 | Backlogはrevenue、CapEx、capacity、orders for semiconductors又は半導体需要ではない。Google Cloud / enterprise AI需要contextとしてのみ保持する。 | 既存matchなし | **Proceed with caution** — demand-side context only |
| `ALPH-SFI-011` | 2025 Q4 Earnings Call, CEO response on capacity | Issuer narrative / capacity constraint and timing boundary | Alphabet CEOはcapacityを増強中でもsupply-constrainedであり、CapExとcapacity拡大には時間差があると説明する。またCloud、社内需要等の需要が強いとの文脈を示す。 | Phase 1のcapacity constraint及びtiming boundary contextに限定する。Lead / Lag分析へ使用せず、固定期間、制約対象、数量、解消時期、半導体需要又は単独因果を確定しない。 | 既存matchなし | **Proceed with caution** — Core `S3-DCAI-RQ-002` / `006` context only; no Lead / Lag analysis |

## 4. Excluded or Non-convertible Statements

| Statement family | Disposition | Reason |
| --- | --- | --- |
| Alphabet CapEx全額をData Center又はAI CapExとみなす | Excluded | 発行者はtechnical infrastructure以外の区分も持ち、全額配賦を開示していない。 |
| FY2025総CapEx USD91.4bnへ60 / 40を直接乗じる、又はtechnical-infrastructure investment部分のserver 60%をGPU / TPU・半導体購入額とみなす | Excluded | 60 / 40の分母は金額未開示のtechnical-infrastructure investment部分であり、総CapExではない。Serverにも多数の構成要素があり、accelerator別・半導体別比率は未開示。 |
| Technical infrastructure稼働中gross asset構成60%とFY2025 CapEx構成60%を同一指標とみなす | Excluded | 前者は期末の稼働中gross asset balance、後者は当年度CapExに関するmanagement classificationで測定対象が異なる。 |
| Commitments全額をtechnical infrastructure又は半導体発注額とみなす | Excluded | Energy、licenses、inventory orders等を含むmixed scopeである。 |
| Google Cloud backlog又はrevenue growthを半導体需要成長率とみなす | Excluded | Cloud commercial metricから半導体需要への変換根拠がない。 |
| Supply-constrained又はtime delayから固定Lead / Lagを設定する | Excluded | 期間・対象設備・開始点・終了点を定量的に定義していない。 |
| Alphabetの投資からNVIDIA、Renesas、ROHM又はInfineon売上を推定する | Excluded | Source Setは供給者別購入額又は売上因果を開示していない。 |

## 5. Relationship Assessment

### Confirmed Issuer-named Edges

```text
Demand from users and enterprise / Cloud customers
    ↓
Investment in AI-oriented technical infrastructure
```

根拠：`ALPH-SFI-007`。需要を支えるtechnical infrastructure投資という発行者説明であり、個別構成要素への投資額配賦ではない。

```text
Technical infrastructure
    ↓ consists of
Servers and network equipment + data center land / buildings
```

根拠：`ALPH-SFI-003`。発行者定義であり、構成要素別金額を示さない。

```text
AI-optimized infrastructure
    ↓ offers accelerator options including
Specialized GPUs + custom TPUs
```

根拠：`ALPH-SFI-001`。製品・architecture説明であり、CapEx又は購入額との対応を示さない。

```text
Limited qualified supply for specialized AI chips
    ↓
Potential constraint on technical-infrastructure capacity
    ↓
Potential impact on ability to meet customer demand
```

根拠：`ALPH-SFI-006`。同一risk passage内の発行者説明である。

上記の各edgeはAlphabet自身の開示内で個別に確認できる。ただし、最初の三つは異なるSource positionのFactであり、一本の発行者明示chainとして結合しない。特にCapEx又はinvestmentからGPU / TPUへの配賦関係は未確認である。CapEx、asset balance又はcommitmentsから半導体需要量、特定製品売上又は特定供給者売上へ変換する関係も確認できない。

### Gap

2026-08-02までに確認したAlphabetの公式Source Setでは、Data Center / AI Infrastructure投資と、特定Power Semiconductor、Power Management IC、MCU又は日本株対象企業の売上・受注を直接結ぶ開示を確認できなかった。これは当該関係又は資料が存在しないことの証明ではない。

## 6. Preliminary Disposition

| Category | Count | Treatment |
| --- | ---: | --- |
| Proceed | 9 | 独立レビュー後、個別Raw Evidence化を検討 |
| Proceed with caution | 2 | Demand / capacity timing contextとしてのみRaw Evidence化を検討 |
| Hold | 0 | 現時点なし |
| Excluded transformation | 7 | Evidence化せず、禁止変換として保持 |

## 7. Gate Status and Next Gate

| Gate | Status | Record / Next action |
| --- | --- | --- |
| Source Fact Inspection Independent Review | Completed — Accepted | `AlphabetSourceFactInspectionIndependentReview.v0.1-draft.md` |
| Candidate-level Cross-sprint recheck | Completed — Accepted | `AlphabetCrossSprintCandidateRecheckIndependentReview.v0.1-draft.md` |
| Raw Evidence | Draft completed — 11 artifacts | Proceed 9件、Proceed with caution 2件を一対一で個別化 |
| Raw Evidence independent review | Completed — Accepted | `AlphabetRawEvidenceIndependentReview.v0.1-draft.md` |
| Evidence / PIT ID | Not issued | Raw及びEVRレビューゲート後にのみ発行 |
| AvailableAt / Catalog | Not permitted | `TBD — no use` / `No` |
