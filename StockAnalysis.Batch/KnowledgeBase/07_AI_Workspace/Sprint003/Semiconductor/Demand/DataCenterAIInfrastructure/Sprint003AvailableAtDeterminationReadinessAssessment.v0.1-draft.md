# Sprint003 AvailableAt Determination Readiness Assessment

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft readiness assessment |
| Sprint | Sprint003 |
| Version | 0.1-draft |
| 作成日 | 2026-08-02 |
| 対象 | Microsoft `S3-PIT-001`–`009`; Alphabet `S3-PIT-010`–`020` |
| 判断権者 | Project Director |
| 現在の判定 | Assessment Draft — Independent Review Accepted; Project Director Decision Pending; noncanonical |
| Review Record | `Sprint003AvailableAtDeterminationReadinessAssessmentIndependentReview.v0.1-draft.md` — Accepted |

> **権限境界：** 本Assessmentは、`AvailableAt`判定を開始できる状態かを評価するDraftである。`AvailableAt`の導出規約、個別値、Catalog Eligibility、Canonical化又は下流利用を定義・承認しない。

## 1. Purpose

AcceptedとなったSprint003の20 PIT observationsについて、公開時点証拠の充足状況、既存統制との関係及びProject Directorが次に判断すべき事項を整理する。

本Assessmentの目的は時刻を算出することではなく、推測なしに判定できる前提が存在するかを確認することである。

## 2. Authority and Evidence Basis

| 文書 | 本Assessmentにおける役割 |
| --- | --- |
| `000_ProjectDocumentationConstitution.md` | Project Directorの最終判断権限、Evidence Before Opinion及びKnowledge Base First。 |
| `KnowledgeBase/00_Project/KnowledgeBaseRules.md` | Point-in-time整合性と下流利用境界。 |
| `KnowledgeBase/00_Project/ResearchPolicy.md` | Draft Research、Review及びCatalog前提。 |
| `Sprint003DataCenterAIInfrastructureSemiconductorDemandScopeDesign.v0.1-draft.md` | `AvailableAt`を推測しないこと、導出・承認をSprint対象外とすること、Core Scope及びGate 4。 |
| `Sprint003DataCenterAIInfrastructureEvidenceRegister.v0.1-draft.md` | Accepted Evidence、Publication Event及び利用禁止状態。 |
| `Sprint003DataCenterAIInfrastructurePITInventory.v0.1-draft.md` | Accepted PIT、DisclosedAt、Applicable Period及び`AvailableAt`状態。 |
| `KnowledgeBase/07_AI_Workspace/Sprint001/Semiconductor/Demand/Automotive/Sprint001AvailableAtCatalogGateDecisionRequest.v0.1-draft.md` | Project DirectorがSprint001でOption Aを採用し、no-use状態を維持した先例。Sprint003へ自動適用する規則ではない。 |

## 3. Confirmed Facts

1. Microsoft 9件及びAlphabet 11件のRaw Evidence、EVR及びPITは、限定されたDraft範囲で独立レビューAcceptedである。
2. 全20件はDraft / noncanonical、`AvailableAt = TBD — no use`、Catalog Eligibility `No`である。
3. 既存Project文書には、Publication Event、SEC accepted timestamp、earnings event、IR掲載時刻又は取得時刻から`AvailableAt`を導出する承認済みOperating Conventionが存在しない。
4. Sprint003 Scopeは、公開時刻又はtimezoneが不明な場合の推測を禁止し、`AvailableAt`の導出・承認をSprint対象外としている。
5. Sprint003のCore Scopeには需要・システム側のMicrosoft / Alphabetに加え、供給側候補のRenesas、ROHM、Infineon及びNVIDIAが含まれる。供給側4社はOfficial Source候補をInventoryへ収録済みだが、Sprint003固有のSource Fact Inspection → Raw Evidence → EVR → PIT基盤は未作成である。Renesas、ROHM及びInfineonには過去Sprintの関連Evidenceがあり、Cross-sprint Bridgeで重複・再利用境界を管理している。NVIDIAについては確認済みの過去Sprint集合に該当Research Assetがない。
6. Reviewed Draft Baseline、Industry Report、Company Research及びCross-document Reviewは未完了である。

## 4. Source-event Metadata Assessment

この分類は`AvailableAt`判定ではなく、現在記録されている公開イベントmetadataの充足状況である。

| Classification | PIT IDs | Count | Confirmed metadata | Missing / unresolved | Current use status |
| --- | --- | ---: | --- | --- | --- |
| Regulatory filing event recorded | `S3-PIT-001`–`005`; `S3-PIT-010`–`016` | 12 | SEC filed date及びaccepted timestamp | Accepted timestampを`AvailableAt`とする承認済み規約がない。Alphabet SEC indexのtimestamp timezoneはページ上で別途明示されない。 | `TBD — no use` |
| Date/event context only or publication time incomplete | `S3-PIT-006`–`009` | 4 | 公式日付又はevent context | Release / page publication time又はtimezoneの全部又は一部がUnknown。 | `TBD — no use` |
| Earnings event time recorded; transcript publication event incomplete | `S3-PIT-017`–`020` | 4 | Event 2026-02-04 13:30 PT | Transcript page publication date/timeがUnknown。Event timeとtranscript availabilityを同一視できない。 | `TBD — no use` |

## 5. Readiness Evaluation

| Evaluation area | Status | Basis |
| --- | --- | --- |
| Accepted PIT source interpretation | Ready for current Draft scope | 20件の独立レビューAccepted。 |
| Source-event metadata completeness | Partial | 12件はregulatory filing eventを記録するが、そのうちAlphabet 7件はaccepted timestampのtimezoneが未解決。非filing 8件はrelease、page又はtranscript publication time / timezoneの全部又は一部が不足。 |
| Approved `AvailableAt` operating convention | Not Ready | 既存文書に導出規約がない。 |
| Individual `AvailableAt` determination | Not Permitted | 規約なしでPublication Eventを変換できない。 |
| Sprint003 Reviewed Draft Baseline | Not Ready | 供給側4社のSprint003固有Evidence工程及び後続成果物が未完了。過去Sprint EvidenceはCross-sprint参照であり、この工程完了を代替しない。 |
| Catalog preparation | Not Permitted | `AvailableAt`、Catalog Eligibility及びGate 4条件が未充足。 |

## 6. Uncertainties Requiring Authority

1. `AvailableAt` Operating Conventionが必要か、既存委任の範囲で扱えるか、又はMaterial Governance Changeに該当するかを、適用authorityがどの経路で分類・判断するか。
2. 開始する場合、どのGovernance domain、Accountable Owner及びReview Board構成を適用するか。
3. SEC accepted timestamp、発行者IR release、earnings event、transcript publication及び取得確認の優先関係をどの文書クラスで統制するか。
4. 時刻又はtimezoneが不完全なSourceを、追加Evidence取得まで利用不可とするか、保守的な利用時点を許容するか。

本Assessmentはこれらを決定しない。

## 7. Options

| Option | 内容 | 影響 |
| --- | --- | --- |
| A | `AvailableAt = TBD — no use`を維持し、Sprint003 Core供給側Researchへ戻る。 | 現行統制を変更せず、Reviewed Draft Baseline完成を優先する。 |
| B | Project Directorが、`AvailableAt` Operating Conventionの必要性、変更区分及び適用authorityを判断する正式経路の開始可否を別途判断する。 | Option AのResearchと並行可能。直ちに個別値、Catalog又は下流利用を許可しない。Material Governance Changeに分類された場合は、適用されるADR / Decision、独立レビュー、Approval及びRelease経路へ進む。 |
| C | 文書ごとにPublication Eventを個別判断で`AvailableAt`へ置換する。 | 一貫性、再現性及び監査性を損ない、既存の推測禁止境界と衝突するため採用しない。 |

## 8. Documentation Team Recommendation

**Option Aを推奨する。**

Microsoft / Alphabetの20件は、Source FactとPIT構造のDraft基盤としては受容できる。しかし、`AvailableAt`の導出・承認はSprint003 Scope外であり、承認済みOperating Conventionもないため、個別`AvailableAt`を現在決定できない。

また、Core供給側のSprint003固有Evidence工程とReviewed Draft Baselineが未完成であるため、Catalog準備も開始できない。全件の`AvailableAt = TBD — no use`及びCatalog Eligibility `No`を維持し、運用上は承認済み順序に従ってCore供給側Researchを優先する。Option Bの必要性・変更区分に関するProject Director判断は、Researchと別途又は並行して行うことができる。Material Governance Changeに該当する場合に限り、その正式経路へ進む。

## 9. Current Disposition

| 項目 | 状態 |
| --- | --- |
| Readiness recommendation | Not Ready for `AvailableAt` determination |
| Individual timestamps | 未決定。全件`TBD — no use`を維持。 |
| Catalog preparation | Not Permitted |
| Recommended operational next step | 承認済み順序に従うCore供給側Source Fact Inspection（NVIDIAから開始し、Renesas、ROHM、Infineonへ進む） |
| Project Director decision | Pending |

## 10. Non-actions

- `AvailableAt`を算出・推測しない。
- `DisclosedAt`、SEC accepted timestamp又はearnings eventを`AvailableAt`として代用しない。
- Catalog Eligibilityを変更しない。
- Catalog、DDL、Entity、Database、ML、バックテスト、Decision Engine、Advisor又は投資利用を開始しない。
- 本Assessmentを新しいPolicy、Standard又はProcedureとして扱わない。
