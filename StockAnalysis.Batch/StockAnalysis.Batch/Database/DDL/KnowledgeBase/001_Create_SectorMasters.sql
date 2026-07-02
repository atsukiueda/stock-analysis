/*
DDL名:
    001_Create_SectorMasters.sql

論理名:
    投資セクターマスター

概要:
    Knowledge Baseにおける投資判断用の大分類を管理する。
    本テーブルは分類マスターに徹し、景気敏感度・金利感応度・投資適性などの評価情報は保持しない。
    評価情報は将来、Evidence管理可能な評価ポリシーテーブルで管理する。

更新履歴:
    2026-07-01 新規作成

注意事項:
    SectorCodeは内部識別子であり、将来のSubSector、Policy、Evidence、Advisor、ML、APIから参照されるため原則変更禁止。
*/

-- =========================================================
-- ① CREATE TABLE
-- =========================================================

IF OBJECT_ID(N'dbo.SectorMasters', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.SectorMasters
    (
        Id INT IDENTITY(1,1) NOT NULL,
        SectorCode NVARCHAR(50) NOT NULL,
        SectorName NVARCHAR(100) NOT NULL,
        SectorNameEn NVARCHAR(100) NULL,
        Description NVARCHAR(1000) NULL,
        IsActive BIT NOT NULL,
        DisplayOrder INT NOT NULL,
        CreatedAt DATETIME2(0) NOT NULL,
        UpdatedAt DATETIME2(0) NOT NULL
    );
END
GO

-- =========================================================
-- ② PK
-- =========================================================

IF NOT EXISTS (
    SELECT 1
    FROM sys.key_constraints
    WHERE name = N'PK_SectorMasters'
)
BEGIN
    ALTER TABLE dbo.SectorMasters
    ADD CONSTRAINT PK_SectorMasters PRIMARY KEY CLUSTERED (Id);
END
GO

-- =========================================================
-- ③ INDEX
-- =========================================================

IF NOT EXISTS (
    SELECT 1
    FROM sys.indexes
    WHERE name = N'UX_SectorMasters_SectorCode'
      AND object_id = OBJECT_ID(N'dbo.SectorMasters')
)
BEGIN
    CREATE UNIQUE INDEX UX_SectorMasters_SectorCode
    ON dbo.SectorMasters (SectorCode);
END
GO

-- =========================================================
-- ④ DEFAULT
-- =========================================================

IF NOT EXISTS (
    SELECT 1
    FROM sys.default_constraints
    WHERE name = N'DF_SectorMasters_IsActive'
)
BEGIN
    ALTER TABLE dbo.SectorMasters
    ADD CONSTRAINT DF_SectorMasters_IsActive DEFAULT 1 FOR IsActive;
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.default_constraints
    WHERE name = N'DF_SectorMasters_DisplayOrder'
)
BEGIN
    ALTER TABLE dbo.SectorMasters
    ADD CONSTRAINT DF_SectorMasters_DisplayOrder DEFAULT 0 FOR DisplayOrder;
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.default_constraints
    WHERE name = N'DF_SectorMasters_CreatedAt'
)
BEGIN
    ALTER TABLE dbo.SectorMasters
    ADD CONSTRAINT DF_SectorMasters_CreatedAt DEFAULT SYSUTCDATETIME() FOR CreatedAt;
END
GO

IF NOT EXISTS (
    SELECT 1
    FROM sys.default_constraints
    WHERE name = N'DF_SectorMasters_UpdatedAt'
)
BEGIN
    ALTER TABLE dbo.SectorMasters
    ADD CONSTRAINT DF_SectorMasters_UpdatedAt DEFAULT SYSUTCDATETIME() FOR UpdatedAt;
END
GO

-- =========================================================
-- ⑥ MS_Description（テーブル）
-- =========================================================

IF EXISTS (
    SELECT 1
    FROM sys.extended_properties
    WHERE major_id = OBJECT_ID(N'dbo.SectorMasters')
      AND minor_id = 0
      AND name = N'MS_Description'
)
BEGIN
    EXEC sys.sp_updateextendedproperty
        @name = N'MS_Description',
        @value = N'Knowledge Baseにおける投資判断用の大分類を管理する分類マスター。',
        @level0type = N'SCHEMA',
        @level0name = N'dbo',
        @level1type = N'TABLE',
        @level1name = N'SectorMasters';
END
ELSE
BEGIN
    EXEC sys.sp_addextendedproperty
        @name = N'MS_Description',
        @value = N'Knowledge Baseにおける投資判断用の大分類を管理する分類マスター。',
        @level0type = N'SCHEMA',
        @level0name = N'dbo',
        @level1type = N'TABLE',
        @level1name = N'SectorMasters';
END
GO

-- =========================================================
-- ⑦ MS_Description（全カラム）
-- =========================================================

DECLARE @TableName SYSNAME = N'SectorMasters';

DECLARE @ColumnDescriptions TABLE
(
    ColumnName SYSNAME NOT NULL,
    Description NVARCHAR(1000) NOT NULL
);

INSERT INTO @ColumnDescriptions
(
    ColumnName,
    Description
)
VALUES
(N'Id', N'セクターID。投資セクターマスターの主キー。'),
(N'SectorCode', N'セクターコード。内部識別子として利用し、原則変更禁止。'),
(N'SectorName', N'セクター名。画面表示や説明生成で使用する日本語名称。'),
(N'SectorNameEn', N'セクター英語名。API、CSV、将来の多言語対応で使用する。'),
(N'Description', N'セクター説明。分類範囲や代表的な業種を記録する。'),
(N'IsActive', N'有効フラグ。0の場合は通常の分類・表示対象から除外する。'),
(N'DisplayOrder', N'表示順。画面表示や一覧出力時の並び順に使用する。'),
(N'CreatedAt', N'作成日時。レコード作成時のUTC日時。'),
(N'UpdatedAt', N'更新日時。レコード更新時のUTC日時。');

DECLARE
    @ColumnName SYSNAME,
    @Description NVARCHAR(1000);

DECLARE ColumnDescriptionCursor CURSOR LOCAL FAST_FORWARD FOR
SELECT
    ColumnName,
    Description
FROM @ColumnDescriptions;

OPEN ColumnDescriptionCursor;

FETCH NEXT FROM ColumnDescriptionCursor
INTO @ColumnName, @Description;

WHILE @@FETCH_STATUS = 0
BEGIN
    IF EXISTS (
        SELECT 1
        FROM sys.extended_properties ep
        INNER JOIN sys.columns c
            ON ep.major_id = c.object_id
           AND ep.minor_id = c.column_id
        WHERE ep.major_id = OBJECT_ID(N'dbo.SectorMasters')
          AND ep.name = N'MS_Description'
          AND c.name = @ColumnName
    )
    BEGIN
        EXEC sys.sp_updateextendedproperty
            @name = N'MS_Description',
            @value = @Description,
            @level0type = N'SCHEMA',
            @level0name = N'dbo',
            @level1type = N'TABLE',
            @level1name = @TableName,
            @level2type = N'COLUMN',
            @level2name = @ColumnName;
    END
    ELSE
    BEGIN
        EXEC sys.sp_addextendedproperty
            @name = N'MS_Description',
            @value = @Description,
            @level0type = N'SCHEMA',
            @level0name = N'dbo',
            @level1type = N'TABLE',
            @level1name = @TableName,
            @level2type = N'COLUMN',
            @level2name = @ColumnName;
    END

    FETCH NEXT FROM ColumnDescriptionCursor
    INTO @ColumnName, @Description;
END

CLOSE ColumnDescriptionCursor;
DEALLOCATE ColumnDescriptionCursor;
GO

-- =========================================================
-- ⑧ 初期データ
-- =========================================================

MERGE dbo.SectorMasters AS target
USING
(
    VALUES
        (N'TECHNOLOGY', N'テクノロジー', N'Technology', N'ソフトウェア、ITサービス、半導体、電子部品、デジタル基盤など、技術革新と設備投資サイクルの影響を受ける企業群を管理する。', 1, 10),
        (N'CONSUMER', N'消費関連', N'Consumer', N'食品、小売、外食、日用品、アパレル、生活サービスなど、個人消費とブランド力の影響を受ける企業群を管理する。', 1, 20),
        (N'INDUSTRIAL', N'産業・製造', N'Industrial', N'機械、輸送機器、精密機器、工場設備、FA、製造業向け製品など、設備投資や製造業景気の影響を受ける企業群を管理する。', 1, 30),
        (N'HEALTHCARE', N'ヘルスケア', N'Healthcare', N'医薬品、医療機器、介護、医療サービス、バイオなど、医療需要や研究開発の影響を受ける企業群を管理する。', 1, 40),
        (N'FINANCIAL', N'金融', N'Financial', N'銀行、証券、保険、リース、決済、その他金融サービスなど、金利・信用サイクル・市場環境の影響を受ける企業群を管理する。', 1, 50),
        (N'REAL_ASSETS', N'不動産・実物資産', N'Real Assets', N'不動産開発、賃貸、管理、REIT周辺、資産運用型事業など、地価・金利・賃料市況の影響を受ける企業群を管理する。', 1, 60),
        (N'ENERGY_RESOURCES', N'エネルギー・資源', N'Energy and Resources', N'石油、ガス、鉱業、資源開発、燃料、資源商流など、資源価格と需給サイクルの影響を受ける企業群を管理する。', 1, 70),
        (N'INFRASTRUCTURE', N'インフラ・公益', N'Infrastructure and Utilities', N'電力、ガス、鉄道、通信インフラ、物流インフラなど、社会基盤と規制環境の影響を受ける企業群を管理する。', 1, 80),
        (N'MATERIALS', N'素材', N'Materials', N'化学、鉄鋼、非鉄金属、ガラス、セメント、紙・パルプなど、素材市況と製造業需要の影響を受ける企業群を管理する。', 1, 90),
        (N'SERVICES', N'サービス', N'Services', N'人材、教育、業務支援、専門サービス、BPO、生活関連サービスなど、労働市場や企業活動の影響を受ける企業群を管理する。', 1, 100),
        (N'MEDIA_ENTERTAINMENT', N'メディア・エンタメ', N'Media and Entertainment', N'広告、メディア、ゲーム、コンテンツ、イベント、IPビジネスなど、広告市況・ヒット作・コンテンツ価値の影響を受ける企業群を管理する。', 1, 110),
        (N'TRADING_DISTRIBUTION', N'商社・流通', N'Trading and Distribution', N'総合商社、専門商社、卸売、流通ネットワークなど、商流・資源・需給調整・在庫循環の影響を受ける企業群を管理する。', 1, 120)
)
AS source
(
    SectorCode,
    SectorName,
    SectorNameEn,
    Description,
    IsActive,
    DisplayOrder
)
ON target.SectorCode = source.SectorCode
WHEN MATCHED THEN
    UPDATE SET
        target.SectorName = source.SectorName,
        target.SectorNameEn = source.SectorNameEn,
        target.Description = source.Description,
        target.IsActive = source.IsActive,
        target.DisplayOrder = source.DisplayOrder,
        target.UpdatedAt = SYSUTCDATETIME()
WHEN NOT MATCHED THEN
    INSERT
    (
        SectorCode,
        SectorName,
        SectorNameEn,
        Description,
        IsActive,
        DisplayOrder,
        CreatedAt,
        UpdatedAt
    )
    VALUES
    (
        source.SectorCode,
        source.SectorName,
        source.SectorNameEn,
        source.Description,
        source.IsActive,
        source.DisplayOrder,
        SYSUTCDATETIME(),
        SYSUTCDATETIME()
    )

WHEN NOT MATCHED BY SOURCE THEN
    DELETE;
GO