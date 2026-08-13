# NVIDIA — Cross-sprint Candidate Recheck

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft candidate-level cross-sprint traceability record |
| Sprint | Sprint003 |
| 対象企業 | NVIDIA Corporation |
| Version | 0.1-draft |
| 確認日 | 2026-08-02 |
| 状態 | Draft — Independent Review Accepted; noncanonical |
| Reviewer Status | Evidence / Knowledge / Traceability final disposition `Accepted` |
| Related Review Record | `NVIDIACrossSprintCandidateRecheckIndependentReview.v0.1-draft.md` |
| 上流Inspection | `NVIDIASourceFactInspection.v0.1-draft.md` — Accepted |
| 上流Bridge | `Sprint003DataCenterAIInfrastructureCrossSprintBridge.v0.1-draft.md` — Stage 0 Accepted |
| Evidence / PIT ID | None — Local candidate recheck only |

> **利用境界：** 本記録はRaw Evidence作成前の重複・参照確認である。検索対象内でmatchがないことはRepository全体又は外部に同一資料・同一Factが存在しないことの証明ではない。Evidence採用、ID発行、`AvailableAt`確定、Catalog又は下流利用を許可しない。

## 1. Examined Sets

2026-08-02に、Stage 0の固定集合と、本Recheckで安全側に追加したread-only検索集合を区別して確認した。

### 1.1 Stage 0 Fixed Examined Set

`Sprint003DataCenterAIInfrastructureCrossSprintBridge.v0.1-draft.md` §1.1で明示され、Stage 0独立レビューAcceptedとなった11 artifactを指す。Sprint001のEvidence Register、PIT、Industry Report、Evidence Acquisition Matrix、Renesas / ROHM Company Research、及びSprint002のEvidence Register、PIT、Industry Report、Renesas / ROHM Company Researchである。

Stage 0 Bridgeは、この固定集合においてNVIDIAの既存Research Assetを確認できなかったと記録している。

### 1.2 Additional Candidate Recheck Set

| Scope | Additional read-only search content |
| --- | --- |
| Sprint001 | `KnowledgeBase/07_AI_Workspace/Sprint001/Semiconductor/Demand/Automotive`配下のDraft `.md` |
| Sprint002 | `KnowledgeBase/07_AI_Workspace/Sprint002/Semiconductor/Demand/IndustrialPower`配下のDraft `.md` |
| Legacy Research | `KnowledgeBase/01_Research`配下の既存`.md` |

追加集合は本Recheckで安全側に確認した範囲であり、Stage 0 Accepted scopeを変更・拡張又は再承認するものではない。

検索語は`NVIDIA`、`NVDA`、`Data Center platform`、`accelerated computing`、`Blackwell`、`H20`、`H200`、`datacenter-scale`、`NVLink`、`InfiniBand`及び`DPU`である。各語を上記二集合についてliteral case-insensitive検索し、該当するNVIDIA Source Factを確認できなかった。数値語の単独matchは発行者、Source identity、position又はFactが一致しない偶発一致として除外した。

no-matchは、上記二集合を2026-08-02に指定語彙で確認した結果に限定される。Stage 0固定集合の結果と整合し、追加集合は補助的なread-only corroborationである。

### 1.3 Candidate-level Search Matrix

各候補について、発行者名だけでなく、資料識別子、Source position family及び主要Fact語をliteral case-insensitiveで再検索した。

| Candidate | Source identity / event or period terms | Position / key Fact terms | Result in §1.1 and §1.2 sets |
| --- | --- | --- | --- |
| `NVDA-SFI-001` | `NVIDIA Fiscal 2026 Form 10-K`; `nvda-20260125` | `Data Center platform`; `NVLink`; `InfiniBand`; `DPU` | No identical candidate |
| `NVDA-SFI-002` | `Q4 FY2025 CFO Commentary`; period end `2025-01-26`; publication event `Unknown` | `115.186`; `102.196`; `12.990` | No identical candidate |
| `NVDA-SFI-003` | `Fourth Quarter and Fiscal 2026 Results`; publication `2026-02-25`; period end `2026-01-25` | `62.3 billion`; `193.7 billion`; `Data Center` | No identical candidate |
| `NVDA-SFI-004` | `First Quarter Fiscal 2027 Results`; publication `2026-05-20`; period end `2026-04-26` | `75.2 billion`; `60.4 billion`; `14.8 billion` | No identical candidate |
| `NVDA-SFI-005` | `First Quarter Fiscal 2027 Results`; `new reporting framework` | `Hyperscale`; `ACIE`; `Edge Computing` | No identical candidate |
| `NVDA-SFI-006` | `NVIDIA Fiscal 2026 Form 10-K`; `Item 7` | `Blackwell`; `majority`; `59%`; `142%` | No identical candidate |
| `NVDA-SFI-007` | `NVIDIA Fiscal 2026 Form 10-K`; `Note 12`; `Item 7` | `95.2 billion`; `inventory purchase`; `supply and capacity obligations` | No identical candidate |
| `NVDA-SFI-008` | `NVIDIA Fiscal 2026 Form 10-K`; `Item 1A` | `complex Data Center buildout`; `one component`; `broader revenue impact` | No identical candidate |
| `NVDA-SFI-009` | `NVIDIA Fiscal 2026 Form 10-K`; `H20` | `4.5 billion`; `excess inventory`; `purchase obligations` | No identical candidate |
| `NVDA-SFI-010` | `NVIDIA Fiscal 2026 Form 10-K`; `China Data Center compute` | `effectively foreclosed`; `H200 license`; `no revenue` | No identical candidate |
| `NVDA-SFI-011` | `First Quarter Fiscal 2027 Results`; `Outlook` | `91.0 billion`; `China Data Center compute revenue` | No identical candidate |
| `NVDA-SFI-013` | `NVIDIA Fiscal 2026 Form 10-K`; `AI infrastructure buildout` | `Data Center`; `energy`; `capital`; `multi-year process` | No identical candidate |

`No identical candidate`は、Source identity / eventとposition / key Fact termsを組み合わせて候補単位で確認した結果、同一発行者・同一資料・同一位置・同一Factへ解決する既存Research Assetを確認できなかったことを示す。数値、`Data Center`、`capacity`等の一般語に他社・他用途の偶発的matchが存在しても、NVIDIAの同一Factとは判定しない。no-matchを不存在証明としても扱わない。

## 2. Candidate-level Recheck

| Local ID | Source Event / Position family | Existing cross-sprint match | Same-package relationship | Raw Evidence eligibility and required treatment |
| --- | --- | --- | --- | --- |
| `NVDA-SFI-001` | FY2026 Form 10-K、Item 1、Data Center platform architecture | None in fixed or additional examined set | 他候補のData Center measurement boundaryを支える定義context | Eligible。GPU、CPU、interconnect、networking、software / servicesを含む発行者定義に限定し、売上内訳又はBOMを作らない。 |
| `NVDA-SFI-002` | Q4 FY2025 CFO Commentary、FY2025 / Q4 Data Center Actual | None | `NVDA-SFI-003`のprior-year baselineだが期間・Source Eventが異なる | Eligible。FY2025 / Q4 FY2025 Actualとして保持し、FY2026 Actual又は業界需要と同一化しない。 |
| `NVDA-SFI-003` | Q4 / FY2026 earnings release、Data Center Actual | None | `NVDA-SFI-006`とFY2026 driver contextが関係するが測定Factは異なる | Eligible。Q4 / FY2026 Data Center Actualを一次Factとし、`006`のproduct-architecture narrativeと二重計上しない。 |
| `NVDA-SFI-004` | Q1 FY2027 earnings release、Data Center及び旧sub-market Actual | None | `NVDA-SFI-005`と同じreleaseだが、Actualとreporting transitionは別Fact | Eligible。旧Compute / Networking Actualを保持し、新Hyperscale / ACIEへ再配賦しない。 |
| `NVDA-SFI-005` | Q1 FY2027 earnings release、reporting framework transition | None | `NVDA-SFI-004`と同じreleaseの定義変更context | Eligible。新分類の発行者定義に限定し、新旧区分のidentity、restatement又は数値mappingを作らない。 |
| `NVDA-SFI-006` | FY2026 Form 10-K、Item 7、FY2026 revenue driver / Blackwell context | None | `NVDA-SFI-003`のFY2026 Data Center Actualを説明する別Source Event / position | Eligible。59% / 142%と`majority`を発行者説明として保持し、`003`の総Data Center Actualと独立の売上として加算しない。 |
| `NVDA-SFI-007` | FY2026 Form 10-K、Note 12及びItem 7、consolidated obligations / commitment context | None | 同一10-K内の二つのcommitment classを参照する | Eligible。USD95.2bnは連結obligationとして保持する。Note 12とItem 7のclassの同一性・完全対応、Data Center専用帰属又は個別構成への配賦を確定しない。 |
| `NVDA-SFI-008` | FY2026 Form 10-K、Item 1A、component availability risk | None | `NVDA-SFI-001`のplatform構成とは関係するがrisk passageは別Fact | Eligible。one component issueからbroader NVIDIA revenue impactへのissuer-named riskに限定し、現在のshortage、component又は影響額を推定しない。 |
| `NVDA-SFI-009` | FY2026 Form 10-K、H20 export-control / inventory charge | None | `NVDA-SFI-010` / `011`とChina規制contextを共有するが、特定会計event | Eligible。USD4.5bn chargeをH20固有eventとして保持し、通常のAI需要循環又は他製品へ一般化しない。 |
| `NVDA-SFI-010` | FY2026 Form 10-K、China market-access status | None | `NVDA-SFI-009`は過去のcharge、`011`は将来outlookで分類が異なる | Eligible with caution。Issuer-specific market-access statusに限定し、中国総需要、lost revenue又は将来許可を推定しない。 |
| `NVDA-SFI-011` | Q1 FY2027 earnings release、Q2全社Forecast / China exclusion | None | `NVDA-SFI-010`のmarket-access contextと関係するがForecastは別Fact | Eligible with caution。全社Forecastと明示し、Data Center Forecast、China需要減少額又はActualへ変換しない。 |
| `NVDA-SFI-013` | FY2026 Form 10-K、Data Center / energy / capital dependency | None | 他候補に同一timing Factなし | Eligible with caution。Phase 1のcapacity / timing boundaryに限定し、Lead / Lagの開始点・終了点・期間、固定Lead / Lag、capacity量又は単独因果を設定しない。Phase 2 Conditionalの分析を先取りしない。 |

`NVDA-SFI-012`はInspectionでHoldとなったため、本RecheckのRaw eligibility対象外である。既存matchの有無によってHoldを解除しない。

## 3. Reconciliation Rules for Raw Evidence

- 同じ発行者・同じ資料でも、Source position、Fact、分類又は測定対象が異なる場合だけ別Raw Evidenceとする。
- `NVDA-SFI-002`、`003`及び`004`は異なる期間のActualであり、独立観測を維持する。ただし、一つの業界需要系列へ無条件に連結しない。
- `NVDA-SFI-003`のFY2026 Data Center Actualと`006`のFY2026 driver / architecture narrativeを独立売上として二重計上しない。
- `NVDA-SFI-004`の旧Compute / Networking Actualと`005`の新Hyperscale / ACIE定義を相互配賦しない。
- `NVDA-SFI-007`のNote 12 obligation classとItem 7 commitment classの同一性・完全対応を確定せず、USD95.2bnをData Center専用額へ変換しない。
- `NVDA-SFI-009`、`010`及び`011`は同じChina / export-control contextを共有するが、会計Actual、market-access narrative、全社Forecastとして分離する。
- `NVDA-SFI-010`、`011`及び`013`はcontext限定であり、半導体需要Observation、lost revenue又はLead / Lag measurementとして扱わない。

## 4. Preliminary Disposition

| Result | Count | Treatment |
| --- | ---: | --- |
| No cross-sprint match / Raw eligible | 9 | Inspection境界を維持してRaw Evidence化可能 |
| No cross-sprint match / Raw eligible with caution | 3 | Context限定Raw Evidence化可能 |
| Existing Evidence reference only | 0 | 該当なし |
| Duplicate — do not create Raw Evidence | 0 | 候補全体の重複はなし。ただし同一period / contextの部分重複は§3で非二重計上化 |
| Hold / outside recheck eligibility | 1 | `NVDA-SFI-012`; Raw Evidence化しない |

## 5. Gate Status and Next Gate

| Gate | Status | Record / Next action |
| --- | --- | --- |
| Candidate-level Cross-sprint recheck | Completed — Accepted | `NVIDIACrossSprintCandidateRecheckIndependentReview.v0.1-draft.md` |
| Raw Evidence | Draft completed — 12 artifacts | Eligible 9件及びEligible with caution 3件を一対一でDraft化済み |
| Raw Evidence independent review | Completed — Accepted | `NVIDIARawEvidenceIndependentReview.v0.1-draft.md` |
| EVR ID / registration | Completed — Accepted | `S3-EVR-021`–`032`; `Sprint003NVIDIAEvidenceRegisterIndependentReview.v0.1-draft.md` |
| PIT ID / registration | Completed — Accepted | `S3-PIT-021`–`032`; `Sprint003NVIDIAPITInventoryIndependentReview.v0.1-draft.md` |
| AvailableAt / Catalog | Not permitted | `TBD — no use` / `No` |
