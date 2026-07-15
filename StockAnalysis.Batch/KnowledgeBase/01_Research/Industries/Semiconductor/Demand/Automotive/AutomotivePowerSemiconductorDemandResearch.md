# Automotive Power Semiconductor Demand Research Sheet

**Research Domain**: Semiconductor Industry  
**Research Package**: Automotive Demand  
**Research Category**: Demand Observation  
**Knowledge Type**: SubSector Demand Context  
**Knowledge Scope**: Automotive / Power Semiconductor  
**Version**: 0.1  
**Status**: Evidence Collection  
**Reviewer Status**: Conditional Approval  
**Last Updated**: 2026-07-10  

---

# 1. Research Objective（研究目的）

Automotive Power Semiconductor Demand
（車載パワー半導体需要）が、投資判断に利用可能な
Operational Knowledge（運用可能なKnowledge）として
成立するかをEvidenceに基づいて検証する。

本Researchでは、

「EV販売が増加すればSiC企業の業績も増加する」

という一般論を前提にしない。

以下を個別に検証する。

- 車載パワー半導体需要を継続的に観測できるか
- BEV・PHEV・HEV・ICEで必要なパワー半導体がどう異なるか
- Silicon（Si）、Silicon Carbide（SiC）、Gallium Nitride（GaN）を分ける必要があるか
- EV販売から企業売上までの伝播を説明できるか
- 在庫調整・価格・地域構成・顧客構成の影響を分離できるか
- Company Score、Advisor、ML Contextに利用できるか

---

# 2. Research Success Criteria（調査成功条件）

本Researchは、以下のいずれかをEvidenceにより判断できた場合に成功とする。

## Success Pattern A

Automotive Power Semiconductor Demandを、独立したKnowledge Objectとして採用できる。

## Success Pattern B

単独の指標では成立しないが、EV普及率、企業売上、在庫、ガイダンス等を統合したComposite Observation（複合観測）として採用できる。

## Success Pattern C

理論上の重要性は高いが、継続取得性または検証可能性が不足し、説明用Contextに限定する。

## Success Pattern D

投資判断への寄与が確認できず、Knowledge Object化を見送る。

Knowledgeを作成しない判断でも、Evidenceに基づく結論であればResearch成功とする。

---

# 3. Business Value（投資価値）

| Destination | Expected Usage |
|---|---|
| SubSector Context | 車載Power Semiconductorの需要環境評価 |
| Company Score | ROHM、Infineon、STMicroelectronics、onsemi等の評価補正 |
| Advisor | EV電動化・在庫調整・製品構成の説明 |
| ML Context | AutomotivePowerDemand、SiCDemand等の特徴量候補 |
| Portfolio Engine | Power Semiconductor関連企業の配分補助 |
| Industry Score | 半導体Industry全体には限定的に反映 |

---

# 4. Research Questions（調査課題）

## RQ-001

EV・HEV・PHEVの普及は、車載Power Semiconductor需要へどの程度影響するか。

## RQ-002

Si・SiC・GaNは用途・需要サイクル・競争構造が異なるため、個別Knowledgeとして管理すべきか。

## RQ-003

EV販売台数と、Power Semiconductor企業の売上には再現性のある関係があるか。

## RQ-004

EV販売が増加してもSiC売上が伸びない場合、どの要因が考えられるか。

## RQ-005

Automotive Power Semiconductor Demandを観測する最も信頼性の高い指標は何か。

## RQ-006

車載Power Semiconductor需要はIndustry-wide Contextではなく、SubSector・Company固有Contextとして扱うべきか。

---

# 5. Definition（定義）

Automotive Power Semiconductor Demand
（車載パワー半導体需要）とは、

自動車内の電力変換・電力制御・電力分配に使用されるPower Semiconductorに対する需要を指す。

主な用途候補は以下である。

- Traction Inverter（駆動用インバーター）
- On-board Charger（車載充電器、OBC）
- DC-DC Converter（DC-DCコンバーター）
- Battery Management System（バッテリーマネジメントシステム、BMS）
- Intelligent Power Distribution（インテリジェント電力分配）
- Auxiliary Power System（補機電源）
- Charging Infrastructure（充電インフラ）

対象技術には、少なくとも以下を含む。

- Silicon Power Semiconductor（Siパワー半導体）
- Silicon Carbide Power Semiconductor（SiCパワー半導体）
- Gallium Nitride Power Semiconductor（GaNパワー半導体）

---

# 6. Current Evidence Summary（現在のEvidence要約）

## Fact-001：Infineonの車載製品範囲

Infineonの2025年Annual Reportでは、Automotive segmentが
Analog / Mixed-signal、MCU、センサーに加え、
Si・SiC・GaN Power Semiconductorを扱うと説明されている。

同社のAutomotive segmentは2025年度に74.02億ユーロの売上を計上し、
グループ売上の50%を占めたが、前年比では4%減少した。:contentReference[oaicite:0]{index=0}

### Interpretation

Power Semiconductorが車載半導体の主要構成要素であることは確認できる。

一方、製品上の重要性と短期売上成長は同義ではない。

---

## Fact-002：Power Technologyの用途拡大

Infineonは、車載向けGaNについて、
Traction Inverter、On-board Charger、DC-DC Converter、
電力分配等への用途を提示している。

同社は、効率向上、Power Density（電力密度）の改善、
システムコスト削減を主な価値として説明している。:contentReference[oaicite:1]{index=1}

### Interpretation

車載Power Semiconductor需要は、単にEV台数ではなく、

- 電圧アーキテクチャ
- 変換効率要求
- 搭載システム
- 車両の電子アーキテクチャ

にも左右される。

---

## Fact-003：ROHMの事業構成

ROHMの2025年Integrated Reportでは、
FY2024のDiscrete Semiconductor Device売上の57.3%がAutomotive向けだった。

同社は、EV市場の短期的な成長鈍化を認識しつつ、
SiCをPHEV・HEVやAI Server等へ展開する方針を示している。:contentReference[oaicite:2]{index=2}

### Interpretation

SiC需要をBEVだけに結び付けるのは不適切である。

PHEV・HEV、産業用途、AI Infrastructure等を分離して観測する必要がある。

---

## Fact-004：ROHMの直近事業動向

ROHMはFY2025第3四半期資料で、
自動車市場は生産台数の回復により堅調であり、
欧州を中心にInverter向けSiC Device売上が増加したと説明している。:contentReference[oaicite:3]{index=3}

一方、FY2025第1四半期資料では、
車載SiC Device売上は堅調だったものの、
外販用SiC Substrateは顧客要因により大幅な調整を受け、
BEV市場の調整によりSiC市場の成長が限定的だったと説明している。:contentReference[oaicite:4]{index=4}

### Interpretation

同一企業・同一期間でも、

- SiC Device
- SiC Substrate
- 地域
- 顧客
- Application

によって需要状況が異なる。

SiCを一つの需要指標として扱うと、重要な差異を失う。

---

## Fact-005：STMicroelectronicsのSiC戦略

STMicroelectronicsは、次世代SiC技術をEV Traction Inverter向けに展開し、
Premium EVだけでなく、中型・小型EVへの適用拡大を目指している。:contentReference[oaicite:5]{index=5}

同社は2025年から2027年の投資を、
300mm Siliconおよび200mm Silicon Carbideの製造基盤へ重点配分すると説明している。:contentReference[oaicite:6]{index=6}

### Interpretation

企業の投資計画は長期需要への経営判断を示すEvidenceになり得る。

ただし、CapEx実行は将来需要の実現を保証しないため、
売上・稼働率・在庫との検証が必要である。

---

## Fact-006：製品採用・量産Evidence

ROHMは2025年に、SchaefflerのInverter Brickへ同社SiC MOSFETが採用され、
中国の完成車メーカー向けに量産を開始したと公表している。:contentReference[oaicite:7]{index=7}

### Interpretation

Design Win（設計採用）と量産開始は、製品需要の存在を示す強い定性Evidenceである。

ただし、採用件数だけでは売上規模・利益貢献・継続期間を判断できない。

---

# 7. Evidence-Based Inferences（Evidenceに基づく推論）

## Inference-001

Automotive Power Semiconductor Demandは、
Automotive Package内で独立管理する価値がある。

**Reason**

主要企業の公式資料で、Power Semiconductorが車載電動化・電力制御の中核製品として明示されているため。

**Constraint**

需要の存在と投資収益性は別である。

---

## Inference-002

Automotive Power Semiconductor Demandは、
EV販売台数だけでは説明できない。

必要な補助Observationは以下である。

- BEV / PHEV / HEV Mix
- Power Semiconductor Revenue
- SiC Device Revenue
- SiC Substrate Revenue
- Inventory Condition
- Company Guidance
- Design Win / Mass Production
- 地域Exposure
- 顧客Exposure

---

## Inference-003

SiC Demandは、少なくとも次の単位へ分解すべき可能性が高い。

```text
Automotive SiC Demand
├── SiC Device Demand
├── SiC Module Demand
├── SiC Substrate Demand
├── Traction Inverter Demand
├── OBC / DC-DC Demand
└── BEV / PHEV / HEV Exposure