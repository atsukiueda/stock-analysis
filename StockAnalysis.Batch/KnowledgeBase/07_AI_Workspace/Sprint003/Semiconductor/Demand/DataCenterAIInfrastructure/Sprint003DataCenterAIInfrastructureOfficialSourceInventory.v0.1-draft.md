# Sprint003 Data Center / AI Infrastructure — Official Source Inventory

## 文書情報

| 項目 | 内容 |
| --- | --- |
| 文書種別 | Draft official-source inventory |
| Sprint | Sprint003 |
| Version | 0.1-draft |
| 作成日 | 2026-07-30 |
| Retrieval Date | 2026-07-30 |
| 上流設計 | `Sprint003DataCenterAIInfrastructureIndustryResearchDesign.v0.1-draft.md`（Project Director Accepted、2026-07-30） |
| Namespace決定 | `Sprint003EvidenceNamespaceDecisionRecord.v0.1-draft.md` |
| 状態 | Draft — Stage 0 independent review accepted; Source Fact assessment pending; noncanonical |
| Reviewer Status | Evidence / Knowledge / Traceability final disposition `Accepted` |
| Related Review Record | `Sprint003DataCenterAIInfrastructureStage0IndependentReview.v0.1-draft.md` |
| Evidence ID | None — this inventory is not an Evidence Register |

> **利用境界：** 本文書は公式資料の所在候補と探索状態を記録する。各行はSource Fact、Evidence、関係の存在、数値の正確性又は利用可能性を確定しない。

## 1. Inventory Rules

- 発行者公式IR、規制開示又は公式資料だけを所在候補として登録する。
- Publication EventとApplicable Periodを分離する。
- 不明値は`Unknown`、非該当は`N/A`とする。
- `Candidate relevance`はProposalであり、Evidenceではない。
- `Evidence eligibility`はSource Fact inspection前には`Not assessed`とする。
- 公式資料を発見できない場合も、検索場所・検索語・結果を記録する。
- Raw Evidence、Evidence ID及びPIT IDは本文書では作成しない。
- 各行に個別Retrieval Dateがない場合、文書情報の`Retrieval Date = 2026-07-30`を継承する。
- Cross-sprint情報は`Bridge ID / Existing EVR / Match type`の順で記録し、既存行のStatusを変更しない。

## 2. Official Source Locations

| Issuer | Official source title / page label | Document type | Publication event | Applicable period | Official URL | Located section / page | Search vocabulary | Archive status | Cross-sprint: Bridge / Existing EVR / Match type | Candidate relevance | Evidence eligibility |
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Microsoft | Annual Reports | Official annual-report archive | Archive page; exact page publication event `Unknown` | FY2021–FY2025 listings observed | [Microsoft Annual Reports](https://www.microsoft.com/en-us/investor/annual-reports) | 2021–2025 Annual Report entries | `annual report` | Official archive located | None / None / No existing match in examined set | Minimum annual Source Set | Not assessed |
| Microsoft | Microsoft 2025 Annual Report | Annual Report | Publication date/time `Unknown` | FY2025 | [Microsoft 2025 Annual Report](https://www.microsoft.com/investor/reports/ar25/index.html) | Cloud and AI infrastructure; PP&E / datacenter lease references | `AI infrastructure`, `datacenter`, `capital expenditure` | Official report located | None / None / No existing match in examined set | Data Center / AI terminology and investment context | Not assessed |
| Microsoft | FY2026 Q3 Earnings Release | Official earnings release | 2026-04-29; conference call 14:30 PT is a separate event | Q3 FY2026, quarter ended 2026-03-31 | [Microsoft FY2026 Q3](https://www.microsoft.com/en-us/investor/earnings/FY-2026-Q3/press-release-webcast) | Cloud and AI infrastructure、Azure demand and AI investment context | `cloud and AI infrastructure`, `AI demand`, `investment` | Official release located | None / None / No existing match in examined set | Latest pre-cut-off results and demand narrative candidate | Not assessed |
| Microsoft | 2024 Annual Shareholder Meeting | Official investor event transcript/page | 2024 event; exact publication time `Unknown` | FY2025 investor-event context | [Microsoft 2024 Annual Shareholder Meeting](https://www.microsoft.com/en-us/investor/events/fy-2025/2024-annual-shareholder-meeting) | Cloud and AI infrastructure capital-expenditure discussion | `cloud and AI infrastructure`, `capital expenditures`, `demand` | Official event page located | None / None / No existing match in examined set | Issuer-named investment / demand narrative candidate | Not assessed |
| Alphabet | SEC Filings | Official filing archive | Archive page; exact page publication event `Unknown` | FY2021–cut-off filings searchable | [Alphabet SEC Filings](https://abc.xyz/investor/sec-filings/default.aspx) | Year and filing-type selector | `10-K`, `10-Q` | Official archive located | None / None / No existing match in examined set | Minimum annual and quarterly Source Set | Not assessed |
| Alphabet | Alphabet 2024 Form 10-K | SEC Form 10-K | Filed 2025-02-05; SEC accepted 2025-02-04 20:41:40 ET | FY2024, ended 2024-12-31 | [SEC filing](https://www.sec.gov/Archives/edgar/data/1652044/000165204425000014/goog-20241231.htm) | Technical infrastructure、servers、network equipment、data center assets | `technical infrastructure`, `servers`, `data center`, `capital expenditures` | Official regulatory filing located | None / None / No existing match in examined set | Capex definition and infrastructure composition candidate | Not assessed |
| Alphabet | Financial Statements Glossary / FAQ | Official investor definition page | Publication event `Unknown` | Current definitions at retrieval | [Alphabet Investor FAQ](https://abc.xyz/investor/faqs-and-general-information/default.aspx) | Google Cloud AI Infrastructure; CapEx; PP&E definitions | `AI Infrastructure`, `CapEx`, `technical infrastructure` | Official page located | None / None / No existing match in examined set | Issuer terminology and classification candidate | Not assessed |
| Alphabet | 2025 Q3 Earnings Call | Official earnings-call page | 2025-10-29 14:30 PT | Q3 FY2025 and 2026 outlook | [Alphabet 2025 Q3 Earnings Call](https://abc.xyz/investor/events/event-details/2025/2025-Q3-Earnings-Call-2025-4OI4Bac_Q9/default.aspx) | AI Infrastructure、servers / data centers / networking CapEx composition | `AI Infrastructure`, `servers`, `data center`, `CapEx` | Official event page located | None / None / No existing match in examined set | Demand, capacity and Capex narrative candidate | Not assessed |
| Alphabet | 2025 Q4 Earnings Call | Official earnings-call page | 2026-02-04 13:30 PT | Q4 / FY2025 and FY2026 outlook | [Alphabet 2025 Q4 Earnings Call](https://abc.xyz/investor/events/event-details/2026/2025-Q4-Earnings-Call-2026-Dr_C033hS6/default.aspx) | Technical-infrastructure CapEx composition and AI compute context | `CapEx`, `servers`, `data centers`, `AI compute` | Official event page located | None / None / No existing match in examined set | Latest full-year and outlook candidate | Not assessed |
| NVIDIA | Annual Reports and Proxies | Official annual-report archive | Archive page; exact page publication event `Unknown` | FY2021–FY2026 listings observed | [NVIDIA Annual Reports](https://investor.nvidia.com/financial-info/annual-reports-and-proxies/default.aspx) | FY2021–FY2026 Annual Report entries | `annual report`, `data center` | Official archive located | None / None / No existing match in examined set | Minimum annual Source Set | Not assessed |
| NVIDIA | Fiscal 2026 Q4 and Full-Year Results | Official earnings release | 2026-02-25; release time `Unknown`（14:00 PTは別イベントであるconference call時刻） | Q4 / FY2026 | [NVIDIA FY2026 Results](https://investor.nvidia.com/news/press-release-details/2026/NVIDIA-Announces-Financial-Results-for-Fourth-Quarter-and-Fiscal-2026/) | Data Center results and platform commentary | `Data Center`, `accelerated computing`, `AI` | Official release located | None / None / No existing match in examined set | Full-year Data Center Actual and narrative candidate | Not assessed |
| NVIDIA | Fiscal 2027 Q1 Results | Official earnings release | 2026-05-20; release time `Unknown`（14:00 PTは別イベントであるconference call時刻） | Q1 / FY2027, quarter ended 2026-04-26 | [NVIDIA FY2027 Q1 Results](https://investor.nvidia.com/news/press-release-details/2026/NVIDIA-Announces-Financial-Results-for-First-Quarter-Fiscal-2027/default.aspx) | Data Center results、new reporting framework and outlook | `Data Center`, `Hyperscale`, `ACIE`, `outlook` | Official release located | None / None / No existing match in examined set | Latest pre-cut-off Data Center Actual and classification candidate | Not assessed |
| NVIDIA | Q4 FY2025 CFO Commentary | Official results commentary PDF | Date `Unknown`; time `Unknown`; timezone `Unknown` | Q4 / FY2025 | [NVIDIA Q4 FY2025 CFO Commentary](https://investor.nvidia.com/files/doc_financials/2025/Q425/Q4FY25-CFO-Commentary.pdf) | Data Center revenue and demand commentary | `Data Center revenue`, `demand`, `AI` | Official PDF located | None / None / No existing match in examined set | Prior-year comparison candidate | Not assessed |
| Renesas Electronics | Presentations Archive | Official presentation archive | Archive page; exact page publication event `Unknown` | 2021–cut-off presentations searchable | [Renesas Presentations Archive](https://www.renesas.com/en/about/investor-relations/event/presentation/archive) | FY2024–FY2026 results and Capital Market Day entries | `AI Infra`, `Compute`, `Power`, `data center` | Official archive located | CSB-REN-001–004 / `S2-EVR-012`, `013`, `023`, `EVR-003`, `010`–`014` / Existing references and boundary matches | Minimum results and strategy Source Set | Not assessed |
| Renesas Electronics | 1Q 2026 Presentation Material | Official results presentation | 2026-04-24; time `Unknown`; timezone `Unknown` | 1Q FY2026 / 2Q outlook | [Renesas 1Q 2026 Presentation](https://www.renesas.com/en/document/ppt/2026-1q-presentation-material) | Inventory page and Industrial / Infrastructure / IoT sections | `data center`, `channel inventory`, `advance shipment` | Official document located | CSB-REN-003 / `S2-EVR-023` / Same document and existing composite fact; CSB-REN-002 / `S2-EVR-013` / Same issuer and source-event family, different document | Existing Source Fact recordsを参照する。既存Statusは不変。新規差分だけを検査 | Existing rows retain Draft / no-use status; new claims not assessed |
| Renesas Electronics | AI Infra & Compute — 2026 Capital Market Day | Official strategy presentation | Event date 2026-06-25; document publication date/time/timezone `Unknown` | 2026 strategy context | [Renesas AI Infra & Compute](https://www.renesas.com/en/document/ppt/ai-infra-and-compute-2026-capital-market-day) | AI servers、data center、power management and compute | `AI Infra`, `Compute`, `data center`, `power management` | Official document located | None / None / New source; existing Renesas facts require boundary check | Direct Sprint003 strategy candidate | Not assessed |
| Renesas Electronics | Capital Market Day 2026 Q&A — 2nd half | Official presentation / Q&A | Event date 2026-06-25; document publication date/time/timezone `Unknown` | 2026 strategy context | [Renesas CMD 2026 2nd-half Q&A](https://www.renesas.com/en/document/ppt/2026-capital-market-day-presentation-minutes-and-qa-2nd-half) | Data Center performance and AI inference context | `data center`, `AI inference`, `power management` | Official document located | None / None / New source; existing Renesas facts require boundary check | Issuer narrative and definition candidate | Not assessed |
| ROHM | Financial Report | Official financial-report archive | Archive page; exact page publication event `Unknown` | FY2021以降の年次・四半期資料 | [ROHM Financial Reports](https://www.rohm.com/ir/library/financial-report) | Annual and quarterly reports by fiscal year。2026-07-30時点のlatest pre-cut-off results候補として、発行者資料名*Financial Results for FY2025*（2026-05-13資料基準日）をlocated。Applicable period及びActual / Plan分類はSource Fact inspectionで確認する | `financial report` | Official archive located | CSB-ROH-001–002 / `S2-EVR-007`–`011`, `EVR-008`, `EVR-019`–`023` / Same issuer and partly same document | Minimum annual / latest available results Source Set | Not assessed |
| ROHM | ROHM Integrated Report 2025 | Integrated Report | 2025-11; day/time/timezone `Unknown` | FY2024 / 2025 corporate context | [ROHM Integrated Report 2025](https://fscdn.rohm.com/en/financial/integrated-report/rohm_group_integrated_report_2025_en_view.pdf) | Power / Analog and application discussions | `power`, `server`, `data center`, `AI` | Official PDF located | CSB-ROH-001–002 / `S2-EVR-009`, `EVR-008` / Same document, different Source position required | Same-document new-claim inspection; no duplicate Facts | Not assessed |
| ROHM | Special Dialogue: HVDC for AI Servers | Official IR dialogue | Publication date/time `Unknown` | 2026 plan / future context | [ROHM AI Server Dialogue](https://www.rohm.com/ir/dialogue/ai-server) | AI server rack power、HVDC、Delta collaboration、planned products | `AI server`, `data center`, `HVDC`, `SiC`, `power IC` | Official IR page located | None / None / New source; same issuer boundary check | Product / relationship / Plan candidate | Not assessed |
| ROHM | Server / Data Center Solution | Official solution page | Publication date/time `Unknown` | Current product/application context at retrieval | [ROHM Server / Data Center](https://www.rohm.com/solution/industry/server) | Server and Data Center applications | `AI server`, `800VDC`, `power supply` | Official product page located | None / None / New source; same issuer boundary check | Application-definition candidate | Not assessed |
| Infineon Technologies | Annual Reports | Official annual-report archive | Archive page; exact page publication event `Unknown` | FY2021–FY2025 archive located | [Infineon Annual Reports](https://www.infineon.com/about/investor/reports-presentations/annual-reports) | FY2025 and archive | `annual report`, `data center`, `AI server` | Official archive located | CSB-INF-001 / `EVR-004` / Same issuer and document candidate | Minimum annual Source Set | Not assessed |
| Infineon Technologies | Annual Report 2025 | Annual Report | Publication year 2026 per existing Sprint001 record; exact date/time/timezone `Unknown` | FY2025 | [Infineon Annual Report 2025](https://www.infineon.com/assets/row/public/documents/corporate/investors/annual-reports/2025/2025-annual-report-v01-00-en.pdf) | Data Center power chain and AI Data Center business discussion | `data center`, `AI server`, `power supply` | Official PDF located | CSB-INF-001 / `EVR-004` / Same document, different Source position required | New Source position requires cross-sprint reference | Not assessed |
| Infineon Technologies | Q1 FY2026 Investor Presentation | Official results presentation | 2026-02-04; time `Unknown` | Q1 FY2026 / forward-looking context | [Infineon Q1 FY2026 Presentation](https://www.infineon.com/assets/row/public/documents/corporate/investors/presentations/2026/2026-02-04-q1-fy26-investor-presentation-v01-00-en.pdf) | AI Server power architecture and issuer BOM estimates | `AI Server`, `PSU`, `rack`, `power` | Official PDF located | None / None / New source | Product / estimate / outlook candidate | Not assessed |
| Infineon Technologies | Q2 FY2026 Quarterly Update | Official results presentation | 2026-05-06; time `Unknown` | Q2 FY2026 and Q3 / FY2026 outlook | [Infineon Q2 FY2026 Presentation](https://www.infineon.com/row/public/documents/corporate/investors/presentations/2026/2026-05-06-q2-fy26-investor-presentation-v01-00-en.pdf) | Segment results、AI Data Center investment context and outlook | `AI data center`, `investment`, `outlook`, `power` | Official PDF located | None / None / New source | Latest pre-cut-off result and outlook candidate | Not assessed |
| Infineon Technologies | We Power AI | Official investor presentation | 2025-11-26 | 2025 strategy context | [Infineon We Power AI](https://www.infineon.com/content/dam/infineon/row/public/documents/corporate/investors/presentations/2025/2025-11-26-power-roadshow-v01-00-en.pdf) | Grid-to-core Data Center power chain | `AI power supply`, `data center`, `grid to core` | Official PDF located | None / None / New source | Value-chain and product-scope candidate | Not assessed |
| Infineon Technologies | AI Data Center PSU Solutions | Official technology news | 2026-06-02 | 2026 product / availability context | [Infineon AI Data Center PSU Solutions](https://www.infineon.com/technology-news/2026/infpss202606-094) | AI Data Center PSUs、SiC / GaN / MCU solution | `AI data center`, `PSU`, `SiC`, `GaN` | Official page located | None / None / New source | Product / availability candidate | Not assessed |

## 3. Minimum Source Set Coverage

`Location Search Closure`は公式所在と候補経路の確認だけを表し、本文、数値、Source Fact又はEvidence Eligibilityの受理を意味しない。

| Issuer | Annual / filing route | Latest pre-cut-off result located | Relevant official strategy / product source | Location Search Closure | Content Inspection |
| --- | --- | --- | --- | --- | --- |
| Microsoft | FY2021–FY2025 annual archive | FY2026 Q3 release | Cloud / AI Infrastructure event and annual report | Complete | Pending |
| Alphabet | SEC filings archive and FY2024 10-K | 2025 Q4 call | FAQ definitions and AI Infrastructure commentary | Complete | Pending |
| NVIDIA | FY2021–FY2026 annual archive | FY2027 Q1 release | Data Center result commentary | Complete | Pending |
| Renesas Electronics | FY2021–cut-off presentation archive | 1Q2026 presentation（2Q2026公表予定はcut-off後） | 2026 AI Infra & Compute materials | Complete | Pending; cross-sprint reconciliation required |
| ROHM | FY2021以降のfinancial-report archive | *Financial Results for FY2025*をlatest pre-cut-off results候補としてlocated。Applicable period及びActual / Plan分類はPending | AI Server dialogue and solution page | Complete | Pending; cross-sprint reconciliation required |
| Infineon Technologies | FY2021–FY2025 annual archive | Q2 FY2026 presentation | We Power AI and PSU sources | Complete | Pending; cross-sprint reconciliation required |

## 4. Current Findings

### Confirmed Facts

- Core 6社すべてについて、発行者公式の年次、決算又は戦略資料の所在を少なくとも1件確認した。
- Renesas、ROHM及びInfineonには、Data Center又はAI Server関連を明示する公式資料候補が存在する。
- Renesas、ROHM及びInfineonにはSprint001又はSprint002とのCross-sprint重複候補がある。

### Proposals

- Source Fact抽出は、Microsoft → Alphabet → NVIDIA → Renesas → ROHM → Infineonの承認済み順序で進める。
- 同一資料を既存Sprintが使用している場合、既存Source Factを先に照合し、新しいSource position又はClaimだけをS3候補とする。

### Gaps

- 一部資料の正確なPublication Date、time及びtimezoneは未確認。`Unknown`を維持し、推測で補完しない。
- FY2021以降の各年次資料は公式archive routeを確認したが、全年度の本文検査は未実施。
- Source position、Source Fact、Actual / Forecast分類及びEvidence Eligibilityは未評価。

## 5. Next Gate

1. 改訂Inventory及びCross-sprint Bridgeの独立Evidence・Knowledge・Traceability再レビュー
2. MicrosoftからSource Fact inspectionを開始
3. Source Fact候補ごとにCross-sprint一対一確認
4. Raw Evidenceを作成し、採番条件を満たした場合に限り`S3-EVR-xxx`を付与
5. Source Fact再現性、公式正本性及びSource positionの採番条件を満たしたDraft Raw Evidenceを、Evidence Status `Draft only`、Independent Review Status `Pending`としてEVRへ登録
6. 全EVRに一対一対応するPIT行を作成して`S3-PIT-xxx`を付与する。Publication Eventは既知値又は`Unknown`を別フィールドとして記録し、全PITの初期`AvailableAt = TBD — no use`及びCatalog Eligibility `No`を維持する。適用authorityによる導出規則と承認が記録されるまで、Publication Eventから`AvailableAt`を導出又は変換しない
