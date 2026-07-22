# Independent Review Record — Fuji Electric Automotive Semiconductor Evidence

## Record Information

| Item | Value |
| --- | --- |
| Record type | Draft independent-review synthesis |
| Reviewed artifacts | Fuji raw evidence, Company Research Sheet, Evidence Register EVR-015–EVR-018, Source Inventory and PIT |
| Review date | 2026-07-21 |
| Review roles | Independent Evidence Reviewer; Independent Knowledge Reviewer; Independent Traceability and Editorial Reviewer |
| Author independence | Reviewers did not author or edit the reviewed artifacts. |
| Disposition | Revision required; not ready for Approval, Catalog, DDL, ML, or investment use. |

> This record preserves review findings. It does not approve the research package and creates no canonical authority.

## Findings

| ID | Severity | Finding | Disposition after revision |
| --- | --- | --- |
| FJ-R-001 | Blocker | The draft incorrectly stated that FY2021 monetary automotive sales were unavailable. Independent evidence review located JPY73.1bn (FY2021) and JPY100.2bn (FY2022) in Fuji's FY2022 results. | Corrected in EVR-017 and raw evidence; requires independent re-review. |
| FJ-R-002 | Blocker | Several Fuji entries lacked published-at/accessed-at identity despite the Evidence Register’s required identity rule. | Corrected for EVR-015–EVR-018; `AvailableAt` remains intentionally unavailable pending approved convention. Requires re-review. |
| FJ-R-003 | Blocker | The exact measure of the `Automotive` values was insufficiently stated. | Corrected as source-defined Semiconductor-segment sales by application: Automotive; requires re-review of document interpretation. |
| FJ-R-004 | Major | The company sheet treated working subsector labels and candidate automotive observations too strongly. | Corrected: SubSector is unresolved; working scope and direct-but-definition-controlled observations are separated. Requires re-review. |
| FJ-R-005 | Major | The company-sheet inference exceeded available evidence by referring to inventory/capacity context. | Corrected: inference narrowed; no inventory/capacity fact is asserted. Requires re-review. |
| FJ-R-006 | Major | Comparability classes did not distinguish acquired observations from an approved comparable series. | Corrected as `Pending classification` and explicitly excluded from Catalog eligibility. Requires re-review. |

## Remaining Review Gates

1. Determine the comparability disposition of each FY2021–FY2025 adjacent transition, including the FY2022 restructuring note.
2. Confirm source-table interpretation and application-sales scope across all cited annual reports.
3. Retain `AvailableAt = TBD — no use` until an approved operating convention exists.
4. Confirm all downstream draft references use Evidence IDs and do not convert the source-defined sales observations into industry-wide demand facts.

## Re-review Update — 2026-07-21

Independent re-review accepted the corrected source values, document identity, application-sales scope, and the FY2021 → FY2022 restatement-qualified disposition. It requested amendment—not approval—for the FY2022 → FY2023 and FY2024 → FY2025 reorganization-context wording. Those locators and boundaries are now corrected in `6504_FujiElectricApplicationSalesDefinitionAudit.v0.1-draft.md`.

**Current review outcome:** the annual values are source-supported issuer observations; their proposed comparability dispositions remain Draft proposals until the independent reviewers formally accept the amended audit. `AvailableAt = TBD — no use` remains a separate, unresolved blocker for all governed downstream use.

## Final Narrow Re-review — 2026-07-21

Independent Evidence and Traceability reviewers accepted the amended source locations and all four **Draft** issuer-internal transition dispositions. The acceptance is limited to source interpretation and does not constitute research approval, Catalog admission, or downstream-use authorization.

**Unchanged blocker for promotion:** `AvailableAt = TBD — no use`. No Catalog, DDL, ML, backtest, or investment use is permitted. The artifacts remain Draft / Evidence Collection.

## Current Status

The Fuji evidence is **revised Draft / Evidence Collection**. It is not approved research and must not be promoted to `KnowledgeBase/01_Research`, the Knowledge Catalog, DDL, or any downstream implementation artifact.
