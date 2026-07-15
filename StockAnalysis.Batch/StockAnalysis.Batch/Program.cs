using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Dtos;
using StockAnalysis.Batch.Models;
using StockAnalysis.Batch.Services;
using static System.Formats.Asn1.AsnWriter;
using StockAnalysis.Batch.Factories;
using StockAnalysis.Batch.Services.Ml.Features;
using StockAnalysis.Batch.Services.Ml.Prediction;
using StockAnalysis.Batch.Models.Ml;

// ==============================
// 実行フラグ
// 必要な処理だけ true にする。
// APIを無駄に叩かないため、開発中は1つだけtrue推奨。
// ==============================

const bool RUN_FINANCIAL_IMPORT = false;
const bool RUN_PRICE_IMPORT = false;
const bool RUN_MARKET_INDEX_IMPORT = false;
const bool RUN_USDJPY_IMPORT = false;
const bool RUN_SP500_IMPORT = false;
const bool RUN_NASDAQ_IMPORT = false;
const bool RUN_VIX_IMPORT = false;
const bool RUN_MARKET_SCORE_CALCULATION = false;
const bool RUN_MARKET_SCORE_HISTORY = false;
const bool RUN_STOCK_SCORE_CALCULATION = false;
const bool RUN_ALL_STOCK_SCORE = false;
const bool RUN_PRICE_IMPORT_100 = false;
const bool RUN_FINANCIAL_IMPORT_100 = false;
const bool RUN_SWING_ADVICE = false;
const bool RUN_STOCK_SCORE_HISTORY = false;
const bool RUN_ML_TRAINING_DATA_GENERATION = false;
const bool RUN_ML_UP10_TRAINING = false;
const bool RUN_SCREENING = false;
const bool RUN_ML_TAKE_PROFIT_TRAINING = false;
const bool RUN_ML_STOP_LOSS_TRAINING = false;
const bool RUN_BACKTEST = false;
const bool RUN_TAKEPROFIT_FEATURE_IMPORTANCE = false;
const bool RUN_UP5_FEATURE_IMPORTANCE_WF = false;
const bool RUN_ML_UP5_TRAINING = false;
const bool RUN_WALK_FORWARD_UP5 = false;
const bool RUN_EXPORT_UP5_ML_CACHE = false;
const bool RUN_EXPORT_UP10_TRAINING_CACHE = false;
const bool RUN_EXPORT_TAKEPROFIT_TRAINING_CACHE = false;
const bool RUN_EXPORT_STOPLOSS_TRAINING_CACHE = false;
const bool RUN_STOPLOSS_FEATURE_IMPORTANCE = false;
// EDINET Inventory Cross-company Validationを実行する。
// Production処理ではなく、Data Acquisition及び
// Extraction StructureのResearch Validation専用。
const bool RUN_EDINET_INVENTORY_VALIDATION = false;
// Semantic Mapping Phase Aの
// EF Core Read-only Validationを実行するかを制御する。
const bool RUN_SEMANTIC_MAPPING_PHASE_A_VALIDATION = true;


// ==============================
// appsettings.json 読み込み
// ==============================

var configuration = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// ==============================
// Azure SQL Database 接続設定
// ==============================

var connectionString = configuration.GetConnectionString("DefaultConnection");

var options = new DbContextOptionsBuilder<StockAnalysisDbContext>()
    .UseSqlServer(
        connectionString,
        sqlOptions =>
        {
            // Azure SQLの一時的な接続失敗対策
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5,
                maxRetryDelay: TimeSpan.FromSeconds(10),
                errorNumbersToAdd: null);
        })
    .Options;

await using var db = new StockAnalysisDbContext(options);

// ML学習用特徴量計算サービスを作成する。
// Up5、Up10、TakeProfit、StopLossのCSVキャッシュ出力で共通利用する。
var featureCalculationService = new MlFeatureCalculationService(db);

// ML学習データCSVキャッシュサービスを作成する。
// 学習処理からAzure SQLアクセスを切り離すために使用する。
var trainingDataCacheService = new MlTrainingDataCacheService(
    db,
    featureCalculationService);

// ==============================
// DB接続確認
// ==============================

Console.WriteLine("Azure SQL Databaseへ接続確認中...");

var companyCount = await db.Companies.CountAsync();

Console.WriteLine($"Companies件数: {companyCount}");

var alphaVantageApiKey =
    configuration["AlphaVantage:ApiKey"];

//Console.WriteLine(
//    $"Alpha Vantage API Key Length: {alphaVantageApiKey?.Length}");

// ==============================
// API通信用 HttpClient
// ==============================

using var httpClient = new HttpClient();

// ==============================
// EDINET Cross-company Inventory Validation
// Renesas Electronics
// ==============================

if (RUN_EDINET_INVENTORY_VALIDATION)
{
    Console.WriteLine();
    Console.WriteLine(
        "=== EDINET RENESAS ELECTRONICS INVENTORY VALIDATION ===");

    // Cross-company Validation Research用Prototype Serviceを生成する。
    //
    // Production Serviceではなく、
    // IFRS適用半導体企業におけるInventory Extraction Structureの
    // Variation確認に使用する。
    var edinetPrototypeService =
        new EdinetInventoryPrototypeService(
            httpClient,
            configuration);

    // ルネサス エレクトロニクス第24期有価証券報告書は、
    // 2026年3月13日付で公式IRに掲載されている。
    //
    // EDINET Filing IdentityはDocument List APIの
    // 実Responseから最終確認する。
    var filingDate = new DateTime(
        2026,
        3,
        19);

    // EDINET Responseでは証券コードが5桁形式で返却される。
    // ルネサス エレクトロニクスの上場証券コード6723に対応する
    // Document List検索Candidateとして67230を指定する。
    const string targetSecurityCode = "67230";

    var targetDocuments =
        await edinetPrototypeService.GetDocumentsBySecurityCodeAsync(
            filingDate,
            targetSecurityCode);

    Console.WriteLine();
    Console.WriteLine(
        $"Renesas Electronics Document Count: {targetDocuments.Count}");

    // 指定日にルネサス エレクトロニクスが提出した
    // EDINET書類をすべて表示する。
    //
    // Annual Securities ReportのDocument ID、
    // EDINET Code及び各取得Flagを
    // 実API ResponseからEvidenceとして確定する。
    foreach (var document in targetDocuments)
    {
        Console.WriteLine();
        Console.WriteLine("------------------------------");

        Console.WriteLine(
            $"Document ID   : {document.DocumentId}");

        Console.WriteLine(
            $"Description   : {document.DocumentDescription}");

        Console.WriteLine(
            $"EDINET Code   : {document.EdinetCode}");

        Console.WriteLine(
            $"Security Code : {document.SecurityCode}");

        Console.WriteLine(
            $"Filer Name    : {document.FilerName}");

        Console.WriteLine(
            $"Document Type : {document.DocumentTypeCode}");

        Console.WriteLine(
            $"Period Start  : {document.PeriodStart}");

        Console.WriteLine(
            $"Period End    : {document.PeriodEnd}");

        Console.WriteLine(
            $"Submitted At  : {document.SubmitDateTime}");

        Console.WriteLine(
            $"Parent Doc ID : {document.ParentDocumentId}");

        Console.WriteLine(
            $"Withdrawal    : {document.WithdrawalStatus}");

        Console.WriteLine(
            $"Disclosure    : {document.DisclosureStatus}");

        Console.WriteLine(
            $"CSV Available : {document.CsvFlag}");

        Console.WriteLine(
            $"XBRL Available: {document.XbrlFlag}");
    }

    // ルネサス エレクトロニクス第24期有価証券報告書を
    // EDINET Document List APIの実Responseから選択する。
    //
    // Document IDは推測値ではなく、
    // Filing Discoveryで確認した実API Evidenceに基づき固定する。
    var annualSecuritiesReport =
        targetDocuments.SingleOrDefault(x =>
            string.Equals(
                x.DocumentId,
                "S100XR06",
                StringComparison.Ordinal));

    if (annualSecuritiesReport == null)
    {
        throw new InvalidOperationException(
            "ルネサス エレクトロニクス第24期有価証券報告書 " +
            "S100XR06 を取得できませんでした。");
    }

    // CSV及びXBRL取得可否を確認する。
    //
    // Cross-company Validationでは、
    // Document List APIの取得Flagを確認してから
    // 書類取得APIを呼び出す。
    if (!string.Equals(
            annualSecuritiesReport.CsvFlag,
            "1",
            StringComparison.Ordinal))
    {
        throw new InvalidOperationException(
            "対象有価証券報告書はCSV取得対象ではありません。");
    }

    if (!string.Equals(
            annualSecuritiesReport.XbrlFlag,
            "1",
            StringComparison.Ordinal))
    {
        throw new InvalidOperationException(
            "対象有価証券報告書はXBRL取得対象ではありません。");
    }

    Console.WriteLine();
    Console.WriteLine(
        "=== RENESAS ELECTRONICS ANNUAL SECURITIES REPORT SELECTED ===");

    Console.WriteLine(
        $"Document ID : {annualSecuritiesReport.DocumentId}");

    Console.WriteLine(
        $"EDINET Code : {annualSecuritiesReport.EdinetCode}");

    Console.WriteLine(
        $"Submitted At: {annualSecuritiesReport.SubmitDateTime}");

    Console.WriteLine(
        $"Period End  : {annualSecuritiesReport.PeriodEnd}");

    Console.WriteLine(
        $"CSV Flag    : {annualSecuritiesReport.CsvFlag}");

    Console.WriteLine(
        $"XBRL Flag   : {annualSecuritiesReport.XbrlFlag}");

    // EDINET書類取得APIからXBRL変換CSV ZIPを取得する。
    //
    // IFRS適用企業であるルネサスについて、
    // Inventory Total及びComponent Fact Candidateを
    // CSV PrimaryでDiscoveryする。
    var csvZipBytes =
        await edinetPrototypeService.DownloadCsvZipAsync(
            annualSecuritiesReport.DocumentId!);

    // ZIP Entry一覧を表示し、
    // Annual Securities Report CSVを識別する。
    edinetPrototypeService.PrintCsvZipEntries(
        csvZipBytes);

    // CSV全体からInventory関連Candidateを検索する。
    //
    // Kioxiaで確認したIFRS Concept Patternを
    // ルネサスへ機械的に適用しない。
    // 実Filingに存在するConceptをDiscoveryする。
    edinetPrototypeService.PrintInventoryCandidateLines(
        csvZipBytes);

    // Inventory関連Concept QName Candidateを
    // 重複除去して表示する。
    //
    // Standard IFRS Taxonomy及び
    // Company Extension Candidateの双方を確認する。
    edinetPrototypeService.PrintInventoryCandidateConceptNames(
        csvZipBytes);

    // EDINET書類取得APIからRaw XBRL関連ZIPを取得する。
    //
    // CSVで確認したルネサスのIFRS Inventory Total及び
    // 3 Component Factについて、Raw XBRL Instance上の
    // Concept、Context、Unit、Decimals、ValueをCross-checkする。
    var xbrlZipBytes =
        await edinetPrototypeService.DownloadXbrlZipAsync(
            annualSecuritiesReport.DocumentId!);

    // Raw XBRL ZIP内のDirectory及びFile構造を確認する。
    //
    // PublicDoc及びAuditDocを区別し、
    // Annual Securities Report XBRL Instanceを確認する。
    edinetPrototypeService.PrintXbrlZipEntries(
        xbrlZipBytes);

    // Raw XBRL InstanceからInventory関連Fact Candidateを検索する。
    //
    // RenesasではCSV Evidenceにより、以下のIFRS Standard Conceptsを
    // Inventory Total及びComponent Candidateとして確認済み。
    //
    // jpigp_cor:InventoriesCAIFRS
    // jpigp_cor:MerchandiseAndFinishedGoodsCAIFRS
    // jpigp_cor:WorkInProcessCAIFRS
    // jpigp_cor:RawMaterialsAndSuppliesCAIFRS
    //
    // Current / PriorについてContextRef、UnitRef、Decimals、Raw Valueを確認する。
    edinetPrototypeService.PrintXbrlInventoryCandidateFacts(
        xbrlZipBytes);

    Console.WriteLine();
    Console.WriteLine(
        "=== RENESAS ELECTRONICS XBRL INVENTORY CROSS CHECK END ===");

    return;
}

// ============================================================
// Semantic Mapping Phase A
// EF Core Read-only Validation
// ============================================================

if (RUN_SEMANTIC_MAPPING_PHASE_A_VALIDATION)
{
    // Semantic Mapping Phase A
    // EF Core Read-only Validation
    // ============================================================
    //
    // Azure SQLへ適用済みのSemantic Mapping Governance Dataを
    // EF Core Entity及びNavigation Property経由で正常に取得できることを確認する。
    //
    // 本ValidationはRead-onlyであり、
    // DatabaseへのInsert、Update、Deleteは一切行わない。
    var semanticCanonicalRoleCount =
        await db.SemanticCanonicalRoles
            .AsNoTracking()
            .CountAsync();

    var semanticMappingRuleCount =
        await db.SemanticMappingRules
            .AsNoTracking()
            .CountAsync();

    var semanticMappingScopeCount =
        await db.SemanticMappingScopes
            .AsNoTracking()
            .CountAsync();

    var semanticMappingEvidenceReferenceCount =
        await db.SemanticMappingEvidenceReferences
            .AsNoTracking()
            .CountAsync();

    var semanticRejectedMappingDecisionCount =
        await db.SemanticRejectedMappingDecisions
            .AsNoTracking()
            .CountAsync();

    // Production Activationがまだ承認されていないため、
    // Active Mapping Ruleは0件であることを確認する。
    var activeMappingRuleCount =
        await db.SemanticMappingRules
            .AsNoTracking()
            .CountAsync(x => x.StatusCode == "Active");

    Console.WriteLine();
    Console.WriteLine(
        "=== SEMANTIC MAPPING PHASE A EF CORE VALIDATION ===");

    Console.WriteLine(
        $"SemanticCanonicalRoles             : {semanticCanonicalRoleCount}");

    Console.WriteLine(
        $"SemanticMappingRules               : {semanticMappingRuleCount}");

    Console.WriteLine(
        $"SemanticMappingScopes              : {semanticMappingScopeCount}");

    Console.WriteLine(
        $"SemanticMappingEvidenceReferences  : {semanticMappingEvidenceReferenceCount}");

    Console.WriteLine(
        $"SemanticRejectedMappingDecisions   : {semanticRejectedMappingDecisionCount}");

    Console.WriteLine(
        $"Active Mapping Rules               : {activeMappingRuleCount}");

    // ============================================================
    // Mapping Rule → Canonical Role Navigation Validation
    // ============================================================
    //
    // 11件すべてのMapping Ruleについて、
    // CanonicalRole Navigationが正常に解決されることを確認する。
    var mappingRules =
        await db.SemanticMappingRules
            .AsNoTracking()
            .Include(x => x.CanonicalRole)
            .OrderBy(x => x.MappingCode)
            .ThenBy(x => x.MappingVersion)
            .ToListAsync();

    Console.WriteLine();
    Console.WriteLine(
        "=== SEMANTIC MAPPING RULE NAVIGATION VALIDATION ===");

    foreach (var mappingRule in mappingRules)
    {
        Console.WriteLine(
            $"{mappingRule.MappingCode} " +
            $"v{mappingRule.MappingVersion} | " +
            $"{mappingRule.SourceQName} -> " +
            $"{mappingRule.CanonicalRole.RoleCode} | " +
            $"Class={mappingRule.MappingClassCode} | " +
            $"Status={mappingRule.StatusCode}");
    }

    // ============================================================
    // Scope / Evidence Navigation Validation
    // ============================================================
    //
    // Mapping RuleからScope及びEvidence Referenceを
    // Navigation Property経由で取得できることを確認する。
    var mappingRulesWithGovernanceDetails =
        await db.SemanticMappingRules
            .AsNoTracking()
            .Include(x => x.Scopes)
            .Include(x => x.EvidenceReferences)
            .OrderBy(x => x.MappingCode)
            .ThenBy(x => x.MappingVersion)
            .ToListAsync();

    Console.WriteLine();
    Console.WriteLine(
        "=== SEMANTIC MAPPING GOVERNANCE NAVIGATION VALIDATION ===");

    foreach (var mappingRule in mappingRulesWithGovernanceDetails)
    {
        Console.WriteLine(
            $"{mappingRule.MappingCode} | " +
            $"Scopes={mappingRule.Scopes.Count} | " +
            $"Evidence={mappingRule.EvidenceReferences.Count}");
    }

    // ============================================================
    // Kioxia M3 Scope Validation
    // ============================================================
    //
    // Kioxia固有Extension Conceptである
    // SemiFinishedProductsAndWorkInProgressCAIFRSのM3 Mappingについて、
    // Company-specific Scopeが正常に取得できることを確認する。
    var kioxiaMappingRule =
        await db.SemanticMappingRules
            .AsNoTracking()
            .Include(x => x.CanonicalRole)
            .Include(x => x.Scopes)
            .Include(x => x.EvidenceReferences)
            .SingleAsync(x =>
                x.MappingCode == "MAP-INV-011" &&
                x.MappingVersion == 1);

    Console.WriteLine();
    Console.WriteLine(
        "=== KIOXIA M3 MAPPING VALIDATION ===");

    Console.WriteLine(
        $"Mapping Code   : {kioxiaMappingRule.MappingCode}");

    Console.WriteLine(
        $"Source QName   : {kioxiaMappingRule.SourceQName}");

    Console.WriteLine(
        $"Canonical Role : {kioxiaMappingRule.CanonicalRole.RoleCode}");

    Console.WriteLine(
        $"Mapping Class  : {kioxiaMappingRule.MappingClassCode}");

    Console.WriteLine(
        $"Scope Count    : {kioxiaMappingRule.Scopes.Count}");

    Console.WriteLine(
        $"Evidence Count : {kioxiaMappingRule.EvidenceReferences.Count}");

    foreach (var scope in kioxiaMappingRule.Scopes
                 .OrderBy(x => x.ScopeTypeCode))
    {
        Console.WriteLine(
            $"Scope: {scope.ScopeTypeCode} " +
            $"{scope.ScopeOperatorCode} " +
            $"{scope.ScopeValue}");
    }

    Console.WriteLine();
    Console.WriteLine(
        "=== SEMANTIC MAPPING PHASE A EF CORE VALIDATION END ===");

    return;
}

// ==============================
// 財務情報取得
// ==============================

if (RUN_FINANCIAL_IMPORT)
{
    Console.WriteLine();
    Console.WriteLine("=== 財務情報取得開始 ===");

    var financialService = new JQuantsFinancialService(
        httpClient,
        configuration);

    // まずはトヨタのみ
    var financials = await financialService.GetFinancialsAsync("72030");

    Console.WriteLine($"財務件数: {financials.Count}");

    foreach (var item in financials.Take(5))
    {
        Console.WriteLine(
            $"{item.Code} " +
            $"{item.DisclosedDate} " +
            $"{item.NetSales}");
    }

    Console.WriteLine("FinancialStatementsへ保存中...");

    await SaveFinancialsAsync(db, financials);

    Console.WriteLine("FinancialStatements保存完了");
}

// ==============================
// 株価取得
// ==============================

if (RUN_PRICE_IMPORT)
{
    Console.WriteLine();
    Console.WriteLine("=== 株価取得開始 ===");

    var priceService = new JQuantsPriceService(
        httpClient,
        configuration);

    // まずは代表5銘柄のみ
    var targetCodes = new[]
    {
        "72030", // トヨタ自動車
        "67580", // ソニーグループ
        "99840", // ソフトバンクグループ
        "83060", // 三菱UFJ
        "94320"  // NTT
    };

    foreach (var code in targetCodes)
    {
        Console.WriteLine($"{code} の株価取得中...");

        var prices = await priceService.GetPricesAsync(code);

        Console.WriteLine($"{code}: 取得件数 {prices.Count}");

        if (prices.Count == 0)
        {
            Console.WriteLine($"{code}: 取得データなし。スキップします。");
            continue;
        }

        await SavePricesAsync(db, prices);

        Console.WriteLine($"{code}: 保存完了");
    }
}

// ==============================
// 市場指数取得
// ==============================

if (RUN_MARKET_INDEX_IMPORT)
{
    Console.WriteLine();
    Console.WriteLine("=== 市場指数取得開始 ===");

    var topixService = new JQuantsTopixService(
        httpClient,
        configuration);

    var topixItems = await topixService.GetTopixAsync();

    Console.WriteLine($"TOPIX取得件数: {topixItems.Count}");

    foreach (var item in topixItems.Take(5))
    {
        Console.WriteLine(
            $"{item.Date} " +
            $"{item.Close}");
    }

    Console.WriteLine("MarketIndicesDailyへ保存中...");

    await SaveTopixAsync(db, topixItems);

    Console.WriteLine("MarketIndicesDaily保存完了");
}

// ==============================
// USDJPY取得
// ==============================

if (RUN_USDJPY_IMPORT)
{
    Console.WriteLine();
    Console.WriteLine("=== USDJPY取得開始 ===");

    var fxService = new AlphaVantageFxService(
        httpClient,
        configuration);

    var usdJpyItems = await fxService.GetUsdJpyDailyAsync();

    Console.WriteLine($"USDJPY取得件数: {usdJpyItems.Count}");

    foreach (var item in usdJpyItems.Take(5))
    {
        Console.WriteLine(
            $"{item.Key} " +
            $"{item.Value.Close}");
    }

    Console.WriteLine(
    "MarketIndicesDailyへ保存中...");

    await SaveUsdJpyAsync(
        db,
        usdJpyItems);

    Console.WriteLine(
        "USDJPY保存完了");
}

// ==============================
// SP500取得
// ==============================

if (RUN_SP500_IMPORT)
{
    Console.WriteLine();
    Console.WriteLine("=== SP500取得開始 ===");

    var indexService = new AlphaVantageIndexService(
        httpClient,
        configuration);

    var sp500Items = await indexService.GetDailyAsync("SPY");

    Console.WriteLine($"SP500取得件数: {sp500Items.Count}");

    foreach (var item in sp500Items.Take(5))
    {
        Console.WriteLine(
            $"{item.Key} " +
            $"{item.Value.Close}");
    }

    Console.WriteLine(
    "MarketIndicesDailyへ保存中...");

    await SaveSp500Async(
        db,
        sp500Items);

    Console.WriteLine(
        "SP500保存完了");
}

// ==============================
// NASDAQ取得
// ==============================

if (RUN_NASDAQ_IMPORT)
{
    Console.WriteLine();
    Console.WriteLine("=== NASDAQ取得開始 ===");

    var indexService = new AlphaVantageIndexService(
        httpClient,
        configuration);

    // QQQはNASDAQ100連動ETF。
    // 開発初期のNASDAQ系市況 proxy として利用する。
    var nasdaqItems = await indexService.GetDailyAsync("QQQ");

    Console.WriteLine($"NASDAQ取得件数: {nasdaqItems.Count}");

    foreach (var item in nasdaqItems.Take(5))
    {
        Console.WriteLine(
            $"{item.Key} " +
            $"{item.Value.Close}");
    }

    Console.WriteLine("MarketIndicesDailyへ保存中...");

    await SaveNasdaqAsync(
        db,
        nasdaqItems);

    Console.WriteLine("NASDAQ保存完了");
}

// ==============================
// VIX取得
// ==============================

if (RUN_VIX_IMPORT)
{
    Console.WriteLine();
    Console.WriteLine("=== VIX取得開始 ===");

    var vixService = new FredVixService(
        httpClient,
        configuration);

    var vixItems = await vixService.GetVixAsync();

    Console.WriteLine($"VIX取得件数: {vixItems.Count}");

    foreach (var item in vixItems
                 .Where(x => x.Value != ".")
                 .TakeLast(5))
    {
        Console.WriteLine(
            $"{item.Date} {item.Value}");
    }

    Console.WriteLine("MarketIndicesDailyへ保存中...");

    await SaveVixAsync(db, vixItems);

    Console.WriteLine("VIX保存完了");
}

// ==============================
// 市場スコア計算
// ==============================

if (RUN_MARKET_SCORE_CALCULATION)
{
    Console.WriteLine();
    Console.WriteLine("=== 市場スコア計算開始 ===");

    var marketScoreService =
        new MarketScoreService(db);

    var score =
        await marketScoreService.CalculateLatestAsync();

    if (score == null)
    {
        Console.WriteLine("市場スコアを計算できませんでした。");
    }
    else
    {
        Console.WriteLine(
            $"ScoreDate: {score.ScoreDate:yyyy-MM-dd}");

        Console.WriteLine(
            $"TotalScore: {score.TotalScore}");

        Console.WriteLine(
            $"MarketRegime: {score.MarketRegime}");

        Console.WriteLine(
            $"Comment: {score.Comment}");

        await marketScoreService.SaveAsync(score);

        Console.WriteLine("MarketScoresDaily保存完了");
    }
}

// ==============================
// スクリーニング
// ==============================

if (RUN_SCREENING)
{
    Console.WriteLine();
    Console.WriteLine(
        "=== スクリーニング開始 ===");

    var service =
        new ScreeningService(db);

    var latestMarket = await db.MarketScoresDaily
    .OrderByDescending(x => x.ScoreDate)
    .FirstAsync();

    Console.WriteLine();
    Console.WriteLine("=== 市場環境 ===");
    Console.WriteLine(
        $"Regime : {latestMarket.MarketRegime}");

    Console.WriteLine(
        $"Score  : {latestMarket.TotalScore}");

    Console.WriteLine(
        $"Comment: {latestMarket.Comment ?? "-"}");

    var results =
        await service.GetTopStocksAsync(
            new ScreeningCondition
            {
                TopCount = 20,
                MinSwingScore = 60,
                MinTechnicalScore = 20
            });

    foreach (var item in results)
    {
        Console.WriteLine(
            $"{item.Code} " +
            $"{item.CompanyName} " +
            $"AiRank:{item.AiRankingScore:F2} " +
            $"Up5:{item.Up5Probability:F2}% " +
            $"Up10:{item.Up10Probability:F2}% " +
            $"TP:{item.ExpectedTakeProfit:F2}% " +
            $"SL:{item.ExpectedStopLoss:F2}% " +
            $"Entry:{item.EntryPrice:F2} " +
            $"TakeProfit:{item.TakeProfitPrice:F2} " +
            $"StopLoss:{item.StopLossPrice:F2} " +
            $"Total:{item.TotalScore} " +
            $"Swing:{item.SwingScore}");
    }
}

// ==============================
// 株価保存
// ==============================

static async Task SavePricesAsync(
    StockAnalysisDbContext db,
    List<JQuantsPriceDto> prices)
{
    var now = DateTime.Now;

    foreach (var item in prices)
    {
        if (string.IsNullOrWhiteSpace(item.Code) ||
            string.IsNullOrWhiteSpace(item.Date))
        {
            continue;
        }

        var tradeDate = DateTime.Parse(item.Date);

        var price = await db.PricesDaily.FindAsync(
            item.Code,
            tradeDate);

        if (price == null)
        {
            db.PricesDaily.Add(new PriceDaily
            {
                Code = item.Code,
                TradeDate = tradeDate,
                OpenPrice = item.Open,
                HighPrice = item.High,
                LowPrice = item.Low,
                ClosePrice = item.Close,
                Volume = item.Volume.HasValue ? (long)item.Volume.Value : null,
                TurnoverValue = item.TurnoverValue,
                AdjustmentClose = item.AdjustmentClose,
                AdjustmentVolume = item.AdjustmentVolume.HasValue
                    ? (long)item.AdjustmentVolume.Value
                    : null,
                CreatedAt = now,
                UpdatedAt = now
            });
        }
        else
        {
            price.OpenPrice = item.Open;
            price.HighPrice = item.High;
            price.LowPrice = item.Low;
            price.ClosePrice = item.Close;
            price.Volume = item.Volume.HasValue ? (long)item.Volume.Value : null;
            price.TurnoverValue = item.TurnoverValue;
            price.AdjustmentClose = item.AdjustmentClose;
            price.AdjustmentVolume = item.AdjustmentVolume.HasValue
                ? (long)item.AdjustmentVolume.Value
                : null;
            price.UpdatedAt = now;
        }
    }

    await db.SaveChangesAsync();
}

// ==============================
// 財務保存
// ==============================

static async Task SaveFinancialsAsync(
    StockAnalysisDbContext db,
    List<JQuantsFinancialDto> financials)
{
    var now = DateTime.Now;

    foreach (var item in financials)
    {
        if (string.IsNullOrWhiteSpace(item.DisclosureNumber) ||
            string.IsNullOrWhiteSpace(item.Code))
        {
            continue;
        }

        var financial = await db.FinancialStatements.FindAsync(
            item.DisclosureNumber);

        if (financial == null)
        {
            db.FinancialStatements.Add(new FinancialStatement
            {
                DisclosureNumber = item.DisclosureNumber,
                Code = item.Code,
                DisclosedDate = ParseDate(item.DisclosedDate),
                TypeOfDocument = item.TypeOfDocument,
                NetSales = ParseDecimal(item.NetSales),
                OperatingProfit = ParseDecimal(item.OperatingProfit),
                Profit = ParseDecimal(item.Profit),
                EarningsPerShare = ParseDecimal(item.EarningsPerShare),
                EquityToAssetRatio = ParseDecimal(item.EquityToAssetRatio),
                BookValuePerShare = ParseDecimal(item.BookValuePerShare),
                ResultDividendPerShareAnnual = ParseDecimal(item.ResultDividendPerShareAnnual),
                ForecastDividendPerShareAnnual = ParseDecimal(item.ForecastDividendPerShareAnnual),
                CreatedAt = now,
                UpdatedAt = now
            });
        }
        else
        {
            financial.Code = item.Code;
            financial.DisclosedDate = ParseDate(item.DisclosedDate);
            financial.TypeOfDocument = item.TypeOfDocument;
            financial.NetSales = ParseDecimal(item.NetSales);
            financial.OperatingProfit = ParseDecimal(item.OperatingProfit);
            financial.Profit = ParseDecimal(item.Profit);
            financial.EarningsPerShare = ParseDecimal(item.EarningsPerShare);
            financial.EquityToAssetRatio = ParseDecimal(item.EquityToAssetRatio);
            financial.BookValuePerShare = ParseDecimal(item.BookValuePerShare);
            financial.ResultDividendPerShareAnnual = ParseDecimal(item.ResultDividendPerShareAnnual);
            financial.ForecastDividendPerShareAnnual = ParseDecimal(item.ForecastDividendPerShareAnnual);
            financial.UpdatedAt = now;
        }
    }

    await db.SaveChangesAsync();
}

// ==============================
// TOPIX保存
// ==============================

static async Task SaveTopixAsync(
    StockAnalysisDbContext db,
    List<JQuantsTopixDto> topixItems)
{
    var now = DateTime.Now;

    foreach (var item in topixItems)
    {
        if (string.IsNullOrWhiteSpace(item.Date))
        {
            continue;
        }

        var tradeDate = DateTime.Parse(item.Date);

        var index = await db.MarketIndicesDaily.FindAsync(
            "TOPIX",
            tradeDate);

        if (index == null)
        {
            db.MarketIndicesDaily.Add(new MarketIndexDaily
            {
                IndexCode = "TOPIX",
                IndexName = "TOPIX",
                TradeDate = tradeDate,
                OpenValue = item.Open,
                HighValue = item.High,
                LowValue = item.Low,
                CloseValue = item.Close,
                Volume = null,
                Source = "J-Quants",
                CreatedAt = now,
                UpdatedAt = now
            });
        }
        else
        {
            index.IndexName = "TOPIX";
            index.OpenValue = item.Open;
            index.HighValue = item.High;
            index.LowValue = item.Low;
            index.CloseValue = item.Close;
            index.Source = "J-Quants";
            index.UpdatedAt = now;
        }
    }

    await db.SaveChangesAsync();
}

// ==============================
// USDJPY保存
// ==============================

static async Task SaveUsdJpyAsync(
    StockAnalysisDbContext db,
    Dictionary<string, AlphaVantageFxDailyDto> usdJpyItems)
{
    var now = DateTime.Now;

    foreach (var item in usdJpyItems)
    {
        var tradeDate =
            DateTime.Parse(item.Key);

        var index =
            await db.MarketIndicesDaily.FindAsync(
                "USDJPY",
                tradeDate);

        var open =
            ParseDecimal(item.Value.Open);

        var high =
            ParseDecimal(item.Value.High);

        var low =
            ParseDecimal(item.Value.Low);

        var close =
            ParseDecimal(item.Value.Close);

        if (index == null)
        {
            db.MarketIndicesDaily.Add(
                new MarketIndexDaily
                {
                    IndexCode = "USDJPY",
                    IndexName = "USD/JPY",

                    TradeDate = tradeDate,

                    OpenValue = open,
                    HighValue = high,
                    LowValue = low,
                    CloseValue = close,

                    Volume = null,

                    Source = "AlphaVantage",

                    CreatedAt = now,
                    UpdatedAt = now
                });
        }
        else
        {
            index.OpenValue = open;
            index.HighValue = high;
            index.LowValue = low;
            index.CloseValue = close;

            index.Source = "AlphaVantage";

            index.UpdatedAt = now;
        }
    }

    await db.SaveChangesAsync();
}

// ==============================
// SP500保存
// ==============================

static async Task SaveSp500Async(
    StockAnalysisDbContext db,
    Dictionary<string, AlphaVantageDailyDto> sp500Items)
{
    var now = DateTime.Now;

    foreach (var item in sp500Items)
    {
        var tradeDate =
            DateTime.Parse(item.Key);

        var index =
            await db.MarketIndicesDaily.FindAsync(
                "SP500",
                tradeDate);

        var open =
            ParseDecimal(item.Value.Open);

        var high =
            ParseDecimal(item.Value.High);

        var low =
            ParseDecimal(item.Value.Low);

        var close =
            ParseDecimal(item.Value.Close);

        long? volume =
            long.TryParse(
                item.Value.Volume,
                out var vol)
                ? vol
                : null;

        if (index == null)
        {
            db.MarketIndicesDaily.Add(
                new MarketIndexDaily
                {
                    IndexCode = "SP500",
                    IndexName = "S&P500",

                    TradeDate = tradeDate,

                    OpenValue = open,
                    HighValue = high,
                    LowValue = low,
                    CloseValue = close,

                    Volume = volume,

                    Source = "AlphaVantage",

                    CreatedAt = now,
                    UpdatedAt = now
                });
        }
        else
        {
            index.OpenValue = open;
            index.HighValue = high;
            index.LowValue = low;
            index.CloseValue = close;
            index.Volume = volume;

            index.UpdatedAt = now;
        }
    }

    await db.SaveChangesAsync();
}

// ==============================
// NASDAQ保存
// ==============================

static async Task SaveNasdaqAsync(
    StockAnalysisDbContext db,
    Dictionary<string, AlphaVantageDailyDto> nasdaqItems)
{
    var now = DateTime.Now;

    foreach (var item in nasdaqItems)
    {
        var tradeDate = DateTime.Parse(item.Key);

        var index = await db.MarketIndicesDaily.FindAsync(
            "NASDAQ",
            tradeDate);

        var open = ParseDecimal(item.Value.Open);
        var high = ParseDecimal(item.Value.High);
        var low = ParseDecimal(item.Value.Low);
        var close = ParseDecimal(item.Value.Close);

        long? volume =
            long.TryParse(
                item.Value.Volume,
                out var vol)
                ? vol
                : null;

        if (index == null)
        {
            db.MarketIndicesDaily.Add(
                new MarketIndexDaily
                {
                    IndexCode = "NASDAQ",
                    IndexName = "NASDAQ100 / QQQ",
                    TradeDate = tradeDate,
                    OpenValue = open,
                    HighValue = high,
                    LowValue = low,
                    CloseValue = close,
                    Volume = volume,
                    Source = "AlphaVantage",
                    CreatedAt = now,
                    UpdatedAt = now
                });
        }
        else
        {
            index.IndexName = "NASDAQ100 / QQQ";
            index.OpenValue = open;
            index.HighValue = high;
            index.LowValue = low;
            index.CloseValue = close;
            index.Volume = volume;
            index.Source = "AlphaVantage";
            index.UpdatedAt = now;
        }
    }

    await db.SaveChangesAsync();
}

// ==============================
// VIX保存
// ==============================

static async Task SaveVixAsync(
    StockAnalysisDbContext db,
    List<FredObservationDto> vixItems)
{
    var now = DateTime.Now;

    foreach (var item in vixItems)
    {
        if (string.IsNullOrWhiteSpace(item.Date) ||
            string.IsNullOrWhiteSpace(item.Value) ||
            item.Value == ".")
        {
            continue;
        }

        var tradeDate = DateTime.Parse(item.Date);
        var close = ParseDecimal(item.Value);

        var index = await db.MarketIndicesDaily.FindAsync(
            "VIX",
            tradeDate);

        if (index == null)
        {
            db.MarketIndicesDaily.Add(
                new MarketIndexDaily
                {
                    IndexCode = "VIX",
                    IndexName = "CBOE Volatility Index",
                    TradeDate = tradeDate,
                    OpenValue = null,
                    HighValue = null,
                    LowValue = null,
                    CloseValue = close,
                    Volume = null,
                    Source = "FRED",
                    CreatedAt = now,
                    UpdatedAt = now
                });
        }
        else
        {
            index.IndexName = "CBOE Volatility Index";
            index.CloseValue = close;
            index.Source = "FRED";
            index.UpdatedAt = now;
        }
    }

    await db.SaveChangesAsync();
}

// ==============================
// 市場スコア履歴保存
// ==============================

if (RUN_MARKET_SCORE_HISTORY)
{
    Console.WriteLine();
    Console.WriteLine(
        "=== 市場スコア履歴作成開始 ===");

    var marketScoreService =
        new MarketScoreService(db);

    await marketScoreService.GenerateAllAsync();

    Console.WriteLine(
        "市場スコア履歴作成完了");
}


// ==============================
// 単一銘柄スコア計算
// ==============================

if (RUN_STOCK_SCORE_CALCULATION)
{
    Console.WriteLine();
    Console.WriteLine("=== 銘柄スコア計算開始 ===");

    var stockScoreService =
        new StockScoreService(db);

    var score =
        await stockScoreService.CalculateAsync("72030");

    if (score == null)
    {
        Console.WriteLine("銘柄スコアを計算できませんでした。");
    }
    else
    {
        Console.WriteLine(
            $"{score.Code} {score.ScoreDate:yyyy-MM-dd} Total:{score.TotalScore}");

        Console.WriteLine(
            $"Dividend:{score.DividendScore}, " +
            $"ROE:{score.RoeScore}, " +
            $"PER:{score.PerScore}, " +
            $"PBR:{score.PbrScore}, " +
            $"Technical:{score.TechnicalScore}, " +
            $"Swing:{score.SwingScore}, " +
            $"Market:{score.MarketScore}");

        await stockScoreService.SaveAsync(score);

        Console.WriteLine("StockScoresDaily保存完了");
    }
}

// ==============================
// 全銘柄スコア計算
// ==============================

if (RUN_ALL_STOCK_SCORE)
{
    Console.WriteLine();
    Console.WriteLine(
        "=== 全銘柄スコア計算開始 ===");

    var stockScoreService =
        new StockScoreService(db);

    await stockScoreService.GenerateAllAsync();

    Console.WriteLine(
        "全銘柄スコア計算完了");
}

// ==============================
// 100銘柄情報取得
// ==============================

if (RUN_PRICE_IMPORT_100)
{
    Console.WriteLine();
    Console.WriteLine("=== 100銘柄 株価取得開始 ===");

    var priceService = new JQuantsPriceService(
        httpClient,
        configuration);

    var targetCodes = await db.Companies
        .Where(x => x.IsActive)
        .OrderBy(x => x.Code)
        .Select(x => x.Code)
        .Take(100)
        .ToListAsync();

    Console.WriteLine($"対象銘柄数: {targetCodes.Count}");

    foreach (var code in targetCodes)
    {
        Console.WriteLine($"{code} の株価取得中...");

        var prices = await priceService.GetPricesAsync(code);

        Console.WriteLine($"{code}: 取得件数 {prices.Count}");

        if (prices.Count == 0)
        {
            Console.WriteLine($"{code}: データなし。スキップします。");
            continue;
        }

        await SavePricesAsync(db, prices);

        await Task.Delay(300);

        Console.WriteLine($"{code}: 保存完了");
    }

    Console.WriteLine("100銘柄 株価取得完了");
}

// ==============================
// 100財務情報取得
// ==============================

if (RUN_FINANCIAL_IMPORT_100)
{
    Console.WriteLine();
    Console.WriteLine("=== 100銘柄 財務情報取得開始 ===");

    var financialService = new JQuantsFinancialService(
        httpClient,
        configuration);

    var priceCodes = await db.PricesDaily
    .Select(x => x.Code)
    .Distinct()
    .ToListAsync();

    var alreadyImportedCodes = await db.FinancialStatements
        .Select(x => x.Code)
        .Distinct()
        .ToListAsync();

    var targetCodes = await db.Companies
        .Where(x => x.IsActive)
        .Where(x => priceCodes.Contains(x.Code))
        .Where(x => !alreadyImportedCodes.Contains(x.Code))
        .Where(x => x.MarketName != "その他")
        .Where(x => x.MarketName != "TOKYO PRO MARKET")
        .OrderBy(x => x.Code)
        .Select(x => x.Code)
        .Take(500)
        .ToListAsync();

    Console.WriteLine($"取得済み財務銘柄数: {alreadyImportedCodes.Count}");
    Console.WriteLine($"今回の対象銘柄数: {targetCodes.Count}");

    foreach (var code in targetCodes.Take(20))
    {
        Console.WriteLine($"対象: {code}");
    }

    Console.WriteLine($"対象銘柄数: {targetCodes.Count}");

    foreach (var code in targetCodes)
    {
        Console.WriteLine($"{code} の財務情報取得中...");

        var retryCount = 0;
        var success = false;

        // 429が出た場合、同じ銘柄を最大3回まで再試行する。
        while (!success && retryCount < 3)
        {
            try
            {
                var financials =
                    await financialService.GetFinancialsAsync(code);

                Console.WriteLine($"{code}: 取得件数 {financials.Count}");

                // ETFや投信など、財務データがない銘柄はここでスキップする。
                if (financials.Count == 0)
                {
                    Console.WriteLine($"{code}: 財務データなし。スキップします。");
                    success = true;
                    break;
                }

                await SaveFinancialsAsync(db, financials);

                Console.WriteLine($"{code}: 保存完了");

                success = true;
            }
            catch (HttpRequestException ex) when (ex.Message.Contains("429"))
            {
                retryCount++;

                Console.WriteLine(
                    $"{code}: レート制限です。{retryCount}回目。60秒待機します。");

                await Task.Delay(TimeSpan.FromSeconds(60));
            }
        }

        if (!success)
        {
            Console.WriteLine($"{code}: リトライ上限に達したためスキップします。");
        }

        // API連続呼び出しを避けるため、通常時も少し待機する。
        await Task.Delay(3000);
    }

    Console.WriteLine("100銘柄 財務情報取得完了");
}

// ==============================
// スイング売買アドバイス
// ==============================

if (RUN_SWING_ADVICE)
{
    Console.WriteLine();
    Console.WriteLine("=== スイング売買アドバイス ===");

    var service =
        new ScreeningService(db);

    var advices =
        await service.GetSwingTradeAdvicesAsync(10);

    foreach (var item in advices)
    {
        Console.WriteLine(
            $"{item.Code} {item.CompanyName} " +
            $"Date:{item.TradeDate:yyyy-MM-dd} " +
            $"Swing:{item.SwingScore} " +
            $"Entry:{item.EntryPrice:N2} " +
            $"TP:{item.TakeProfitPrice:N2} " +
            $"SL:{item.StopLossPrice:N2}");

        Console.WriteLine($"  {item.Comment}");
    }
}

// ==============================
// ML学習データ生成
// ==============================

if (RUN_STOCK_SCORE_HISTORY)
{
    Console.WriteLine();
    Console.WriteLine("=== 株式スコア履歴生成開始 ===");

    var stockScoreService =
        new StockScoreService(db);

    await stockScoreService.GenerateHistoryAsync(
        new DateTime(2024, 1, 1),
        new DateTime(2024, 12, 31));

    Console.WriteLine("=== 株式スコア履歴生成完了 ===");
}

if (RUN_ML_TRAINING_DATA_GENERATION)
{
    Console.WriteLine();
    Console.WriteLine("=== ML学習データ生成開始 ===");

    var service =
        new MlTrainingDataService(db);

    await service.GenerateAsync();

    Console.WriteLine("=== ML学習データ生成終了 ===");
}

// ==============================
// up5学習
// ==============================

if (RUN_ML_UP5_TRAINING)
{
    Console.WriteLine();
    Console.WriteLine("=== Up5 ML.NET 学習開始 ===");

    var service = new MlUp5PredictionService(db);

    await service.TrainAndEvaluateAsync();

    Console.WriteLine("=== Up5 ML.NET 学習終了 ===");

    return;
}

var mlTrainingDataSummary = await db.MlTrainingData
    .GroupBy(x => x.TradeDate.Year)
    .Select(g => new
    {
        Year = g.Key,
        Count = g.Count(),
        Up5Count = g.Count(x => x.Up5),
        FutureReturn5Count = g.Count(x => x.FutureReturn5 != null),
        MinDate = g.Min(x => x.TradeDate),
        MaxDate = g.Max(x => x.TradeDate)
    })
    .OrderBy(x => x.Year)
    .ToListAsync();

Console.WriteLine();
Console.WriteLine("=== MlTrainingData 年別件数 ===");

foreach (var item in mlTrainingDataSummary)
{
    Console.WriteLine(
        $"{item.Year}: Count:{item.Count}, Up5:{item.Up5Count}, FutureReturn5:{item.FutureReturn5Count}, " +
        $"Date:{item.MinDate:yyyy-MM-dd} - {item.MaxDate:yyyy-MM-dd}");
}

var stockScoreSummary = await db.StockScoresDaily
    .GroupBy(x => x.ScoreDate.Year)
    .Select(g => new
    {
        Year = g.Key,
        Count = g.Count(),
        MinDate = g.Min(x => x.ScoreDate),
        MaxDate = g.Max(x => x.ScoreDate)
    })
    .OrderBy(x => x.Year)
    .ToListAsync();

Console.WriteLine();
Console.WriteLine("=== StockScoresDaily 年別件数 ===");

foreach (var item in stockScoreSummary)
{
    Console.WriteLine(
        $"{item.Year}: Count:{item.Count}, Date:{item.MinDate:yyyy-MM-dd} - {item.MaxDate:yyyy-MM-dd}");
}

// ==============================
// Up5 ウォークフォワード学習
// ==============================

if (RUN_WALK_FORWARD_UP5)
{
    Console.WriteLine();
    Console.WriteLine("=== Up5 ウォークフォワード学習開始 ===");

    var up5Service =
        new MlUp5PredictionService(db);

    var backtestService =
    new BacktestService(db);

    var walkForwardRunner =
        new WalkForwardRunner(
            up5Service,
            backtestService);

    await walkForwardRunner.TrainUp5AllAsync();

    Console.WriteLine("=== Up5 ウォークフォワード学習終了 ===");

    return;
}

if (RUN_UP5_FEATURE_IMPORTANCE_WF)
{
    Console.WriteLine();
    Console.WriteLine("=== Up5 WF Feature Importance 開始 ===");

    var service = new MlUp5PredictionService(db);

    foreach (var period in TrainingPeriodFactory.CreateUp5WalkForwardPeriods())
    {
        await service.AnalyzeFeatureImportanceAsync(period);
    }

    Console.WriteLine("=== Up5 WF Feature Importance 終了 ===");

    return;
}

// ==============================
// up10学習
// ==============================

if (RUN_ML_UP10_TRAINING)
{
    Console.WriteLine();
    Console.WriteLine("=== Up10 ML.NET 学習開始 ===");

    var service = new MlUp10PredictionService(db);

    await service.TrainAndEvaluateAsync();

    Console.WriteLine("=== Up10 ML.NET 学習終了 ===");

}

if (RUN_EXPORT_UP10_TRAINING_CACHE)
{
    Console.WriteLine();
    Console.WriteLine("=== Up10 学習CSVキャッシュ出力開始 ===");

    await trainingDataCacheService.ExportUp10TrainingDataAsync();

    Console.WriteLine("=== Up10 学習CSVキャッシュ出力終了 ===");

    return;
}

if (RUN_EXPORT_TAKEPROFIT_TRAINING_CACHE)
{
    Console.WriteLine();
    Console.WriteLine("=== TakeProfit 学習CSVキャッシュ出力開始 ===");

    await trainingDataCacheService.ExportTakeProfitTrainingDataAsync();

    Console.WriteLine("=== TakeProfit 学習CSVキャッシュ出力終了 ===");

    return;
}

if (RUN_EXPORT_STOPLOSS_TRAINING_CACHE)
{
    Console.WriteLine();
    Console.WriteLine("=== StopLoss 学習CSVキャッシュ出力開始 ===");

    await trainingDataCacheService.ExportStopLossTrainingDataAsync();

    Console.WriteLine("=== StopLoss 学習CSVキャッシュ出力終了 ===");

    return;
}

// ==============================
// 利益確定学習
// ==============================

if (RUN_ML_TAKE_PROFIT_TRAINING)
{
    Console.WriteLine();
    Console.WriteLine("=== TakeProfit ML.NET 学習開始 ===");

    var service = new MlTakeProfitPredictionService(db);

    await service.TrainAndEvaluateAsync();

    Console.WriteLine("=== TakeProfit ML.NET 学習終了 ===");
}

if (RUN_EXPORT_UP5_ML_CACHE)
{
    Console.WriteLine();
    Console.WriteLine("=== Up5 MLキャッシュCSV出力開始 ===");

    await trainingDataCacheService.ExportUp5TrainingDataAsync();

    Console.WriteLine("=== Up5 MLキャッシュCSV出力終了 ===");

    return;
}

// ==============================
// 損切学習
// ==============================


if (RUN_ML_STOP_LOSS_TRAINING)
{
    Console.WriteLine();
    Console.WriteLine("=== StopLoss ML.NET 学習開始 ===");

    var service = new MlStopLossPredictionService(db);

    await service.TrainAndEvaluateAsync();

    Console.WriteLine("=== StopLoss ML.NET 学習終了 ===");
}

// ==============================
// バックテスト
// ==============================

if (RUN_BACKTEST)
{
    Console.WriteLine();
    Console.WriteLine("=== バックテスト開始 ===");

    var service = new BacktestService(db);

    await service.RunAsync(
        new DateTime(2024, 1, 1),
        new DateTime(2025, 12, 31),
        topCount: 5);

    Console.WriteLine("=== バックテスト終了 ===");
}

if (RUN_TAKEPROFIT_FEATURE_IMPORTANCE)
{
    Console.WriteLine();
    Console.WriteLine("=== TP特徴量重要度分析開始 ===");

    var service = new MlTakeProfitPredictionService(db);

    await service.AnalyzeFeatureImportanceAsync();

    Console.WriteLine();
    Console.WriteLine("=== TP特徴量重要度分析終了 ===");

    return;
}

if (RUN_STOPLOSS_FEATURE_IMPORTANCE)
{
    Console.WriteLine();
    Console.WriteLine("=== SL特徴量重要度分析開始 ===");

    var stopLossService = new MlStopLossPredictionService(db);

    await stopLossService.AnalyzeFeatureImportanceAsync();

    Console.WriteLine();
    Console.WriteLine("=== SL特徴量重要度分析終了 ===");

    return;
}

// ==============================
// 文字列→decimal変換
// J-Quants V2の財務数値は文字列で返るため。
// 空文字はnull扱い。
// ==============================

static decimal? ParseDecimal(string? value)
{
    if (string.IsNullOrWhiteSpace(value))
    {
        return null;
    }

    return decimal.TryParse(value, out var result)
        ? result
        : null;
}

// ==============================
// 文字列→DateTime変換
// ==============================

static DateTime? ParseDate(string? value)
{
    if (string.IsNullOrWhiteSpace(value))
    {
        return null;
    }

    return DateTime.TryParse(value, out var result)
        ? result
        : null;
}