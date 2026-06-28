using System.Globalization;
using System.Text;
using Microsoft.EntityFrameworkCore;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;

namespace StockAnalysis.Batch.Services;

/// <summary>
/// ML学習データをAzure SQLからCSVへ出力するサービス。
/// 学習・特徴量重要度分析のたびにDBへアクセスする回数を減らすために使用する。
/// </summary>
public class MlTrainingDataCacheService
{
    private readonly Dictionary<string, List<PriceDaily>> _priceHistoryCache = new();

    private readonly Dictionary<string, List<MarketIndexDaily>> _marketIndexHistoryCache = new();

    private readonly StockAnalysisDbContext _db;

    private readonly MlFeatureCalculationService _featureCalculationService;

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    /// <param name="db">DBコンテキスト。</param>
    /// <param name="featureCalculationService">ML特徴量計算サービス。</param>
    public MlTrainingDataCacheService(
        StockAnalysisDbContext db,
        MlFeatureCalculationService featureCalculationService)
    {
        _db = db;
        _featureCalculationService = featureCalculationService;
    }

    /// <summary>
    /// Up5学習用データをCSVへ出力する。
    /// </summary>
    public async Task ExportUp5TrainingDataAsync()
    {
        var outputDirectory = Path.Combine(
            AppContext.BaseDirectory,
            "MlCache");

        Directory.CreateDirectory(outputDirectory);

        var filePath = Path.Combine(
            outputDirectory,
            "up5_training_data.csv");

        var rows = await _db.MlTrainingData
            .AsNoTracking()
            .Where(x => x.FutureReturn5 != null)
            .OrderBy(x => x.TradeDate)
            .ThenBy(x => x.Code)
            .ToListAsync();

        var csv = new StringBuilder();

        csv.AppendLine(
            "TradeDate,Code,FinancialScore,GrowthScore,DividendScore,RoeScore,PerScore,PbrScore,TechnicalScore,SwingScore,MarketScore,Momentum5,Momentum25,DeviationFromMa25,VolumeRatio5,ClosePositionInRange25,Ma25Slope,Ma75Slope,TopixMomentum25,Sp500Momentum25,NasdaqMomentum25,UsdJpyMomentum25,VixMomentum25,FutureReturn5,Up5");

        foreach (var row in rows)
        {
            var technicalFeatures = await _featureCalculationService.GetTechnicalFeaturesAsync(
                row.Code,
                row.TradeDate);

            if (technicalFeatures == null)
            {
                continue;
            }

            var marketFeatures = await _featureCalculationService.GetMarketFeaturesAsync(
                row.TradeDate);

            csv.AppendLine(
                string.Join(
                    ",",
                    row.TradeDate.ToString("yyyy-MM-dd"),
                    row.Code,
                    FormatDecimal(row.FinancialScore),
                    FormatDecimal(row.GrowthScore),
                    FormatDecimal(row.DividendScore),
                    FormatDecimal(row.RoeScore),
                    FormatDecimal(row.PerScore),
                    FormatDecimal(row.PbrScore),
                    FormatDecimal(row.TechnicalScore),
                    FormatDecimal(row.SwingScore),
                    FormatDecimal(row.MarketScore),
                    FormatFloat(technicalFeatures.Momentum5),
                    FormatFloat(technicalFeatures.Momentum25),
                    FormatFloat(technicalFeatures.DeviationFromMa25),
                    FormatFloat(technicalFeatures.VolumeRatio5),
                    FormatFloat(technicalFeatures.ClosePositionInRange25),
                    FormatFloat(technicalFeatures.Ma25Slope),
                    FormatFloat(technicalFeatures.Ma75Slope),
                    FormatFloat(marketFeatures.TopixMomentum25),
                    FormatFloat(marketFeatures.Sp500Momentum25),
                    FormatFloat(marketFeatures.NasdaqMomentum25),
                    FormatFloat(marketFeatures.UsdJpyMomentum25),
                    FormatFloat(marketFeatures.VixMomentum25),
                    FormatDecimal(row.FutureReturn5),
                    row.Up5 ? "true" : "false"));
        }

        await File.WriteAllTextAsync(
            filePath,
            csv.ToString(),
            Encoding.UTF8);

        Console.WriteLine($"Up5学習データCSVを出力しました: {filePath}");
        Console.WriteLine($"出力件数: {rows.Count}");
    }

    /// <summary>
    /// Up10学習用データをCSVへ出力する。
    /// ML最終入力に必要な特徴量をすべて計算済みの状態で保存し、
    /// 学習・特徴量重要度分析・ウォークフォワード時のDBアクセスを削減する。
    /// </summary>
    public async Task ExportUp10TrainingDataAsync()
    {
        var outputDirectory = Path.Combine(
            AppContext.BaseDirectory,
            "MlCache");

        Directory.CreateDirectory(outputDirectory);

        var filePath = Path.Combine(
            outputDirectory,
            "up10_training_data.csv");

        var rows = await _db.MlTrainingData
            .AsNoTracking()
            .Where(x => x.FutureReturn10 != null)
            .OrderBy(x => x.TradeDate)
            .ThenBy(x => x.Code)
            .ToListAsync();

        var csv = new StringBuilder();

        csv.AppendLine(
            "TradeDate,Code,FinancialScore,GrowthScore,DividendScore,RoeScore,PerScore,PbrScore,TechnicalScore,SwingScore,MarketScore,Momentum5,Momentum25,DeviationFromMa25,VolumeRatio5,ClosePositionInRange25,Ma25Slope,Ma75Slope,TopixMomentum25,Sp500Momentum25,NasdaqMomentum25,UsdJpyMomentum25,VixMomentum25,FutureReturn10,Up10");

        var outputCount = 0;

        foreach (var row in rows)
        {
            // テクニカル特徴量を共通サービスから取得する。
            var technicalFeatures = await _featureCalculationService.GetTechnicalFeaturesAsync(
                row.Code,
                row.TradeDate);

            if (technicalFeatures == null)
            {
                continue;
            }

            // 市場特徴量を共通サービスから取得する。
            var marketFeatures = await _featureCalculationService.GetMarketFeaturesAsync(
                row.TradeDate);

            csv.AppendLine(
                string.Join(
                    ",",
                    row.TradeDate.ToString("yyyy-MM-dd"),
                    row.Code,
                    FormatDecimal(row.FinancialScore),
                    FormatDecimal(row.GrowthScore),
                    FormatDecimal(row.DividendScore),
                    FormatDecimal(row.RoeScore),
                    FormatDecimal(row.PerScore),
                    FormatDecimal(row.PbrScore),
                    FormatDecimal(row.TechnicalScore),
                    FormatDecimal(row.SwingScore),
                    FormatDecimal(row.MarketScore),
                    FormatFloat(technicalFeatures.Momentum5),
                    FormatFloat(technicalFeatures.Momentum25),
                    FormatFloat(technicalFeatures.DeviationFromMa25),
                    FormatFloat(technicalFeatures.VolumeRatio5),
                    FormatFloat(technicalFeatures.ClosePositionInRange25),
                    FormatFloat(technicalFeatures.Ma25Slope),
                    FormatFloat(technicalFeatures.Ma75Slope),
                    FormatFloat(marketFeatures.TopixMomentum25),
                    FormatFloat(marketFeatures.Sp500Momentum25),
                    FormatFloat(marketFeatures.NasdaqMomentum25),
                    FormatFloat(marketFeatures.UsdJpyMomentum25),
                    FormatFloat(marketFeatures.VixMomentum25),
                    FormatDecimal(row.FutureReturn10),
                    row.Up10 ? "true" : "false"));

            outputCount++;
        }

        await File.WriteAllTextAsync(
            filePath,
            csv.ToString(),
            Encoding.UTF8);

        Console.WriteLine($"Up10学習データCSVを出力しました: {filePath}");
        Console.WriteLine($"取得件数: {rows.Count}");
        Console.WriteLine($"出力件数: {outputCount}");
    }

    /// <summary>
    /// decimal値をCSV用文字列に変換する。
    /// </summary>
    private static string FormatDecimal(decimal value)
    {
        return value.ToString("0.####", CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// nullable decimal値をCSV用文字列に変換する。
    /// </summary>
    private static string FormatDecimal(decimal? value)
    {
        return value?.ToString("0.####", CultureInfo.InvariantCulture) ?? "";
    }

    /// <summary>
    /// float値をCSV用文字列に変換する。
    /// </summary>
    private static string FormatFloat(float value)
    {
        return value.ToString("0.####", CultureInfo.InvariantCulture);
    }

    private async Task<TechnicalFeatureValues?> CalculateTechnicalFeaturesAsync(
    string code,
    DateTime tradeDate)
    {
        var allPrices = await GetPriceHistoryWithCacheAsync(code);

        var prices = allPrices
            .Where(x => x.TradeDate <= tradeDate)
            .TakeLast(80)
            .ToList();

        if (prices.Count < 80)
        {
            return null;
        }

        var latest = prices[^1];

        if (latest.ClosePrice == null || latest.ClosePrice <= 0)
        {
            return null;
        }

        var latestClose = latest.ClosePrice.Value;

        var close5Ago = prices[^6].ClosePrice;
        var close25Ago = prices[^26].ClosePrice;

        if (close5Ago == null || close5Ago <= 0 ||
            close25Ago == null || close25Ago <= 0)
        {
            return null;
        }

        var latest25Prices = prices.TakeLast(25).ToList();
        var previous25Prices = prices.Skip(prices.Count - 30).Take(25).ToList();

        var latest75Prices = prices.TakeLast(75).ToList();
        var previous75Prices = prices.Skip(prices.Count - 80).Take(75).ToList();

        var ma25 = latest25Prices.Average(x => x.ClosePrice!.Value);
        var previousMa25 = previous25Prices.Average(x => x.ClosePrice!.Value);

        var ma75 = latest75Prices.Average(x => x.ClosePrice!.Value);
        var previousMa75 = previous75Prices.Average(x => x.ClosePrice!.Value);

        var avgVolume5 = prices
            .TakeLast(5)
            .Where(x => x.Volume != null)
            .Average(x => x.Volume!.Value);

        var avgVolume25 = latest25Prices
            .Where(x => x.Volume != null)
            .Average(x => x.Volume!.Value);

        var high25 = latest25Prices
            .Where(x => x.HighPrice != null)
            .Max(x => x.HighPrice!.Value);

        var low25 = latest25Prices
            .Where(x => x.LowPrice != null)
            .Min(x => x.LowPrice!.Value);

        var range25 = high25 - low25;

        return new TechnicalFeatureValues
        {
            Momentum5 = (float)((latestClose - close5Ago.Value) / close5Ago.Value * 100m),
            Momentum25 = (float)((latestClose - close25Ago.Value) / close25Ago.Value * 100m),
            DeviationFromMa25 = ma25 <= 0
                ? 0
                : (float)((latestClose - ma25) / ma25 * 100m),
            VolumeRatio5 = avgVolume25 <= 0
                ? 0
                : (float)(avgVolume5 / avgVolume25),
            ClosePositionInRange25 = range25 <= 0
                ? 0.5f
                : (float)((latestClose - low25) / range25),
            Ma25Slope = previousMa25 <= 0
                ? 0
                : (float)((ma25 - previousMa25) / previousMa25 * 100m),
            Ma75Slope = previousMa75 <= 0
                ? 0
                : (float)((ma75 - previousMa75) / previousMa75 * 100m)
        };
    }

    private async Task<MarketFeatureValues> CalculateMarketFeaturesAsync(
    DateTime tradeDate)
    {
        return new MarketFeatureValues
        {
            TopixMomentum25 = await CalculateMarketMomentum25Async(
                "TOPIX",
                tradeDate),

            Sp500Momentum25 = await CalculateMarketMomentum25Async(
                "S&P500",
                tradeDate),

            NasdaqMomentum25 = await CalculateMarketMomentum25Async(
                "NASDAQ100 / QQQ",
                tradeDate),

            UsdJpyMomentum25 = await CalculateMarketMomentum25Async(
                "USD/JPY",
                tradeDate),

            VixMomentum25 = await CalculateMarketMomentum25Async(
                "CBOE Volatility Index",
                tradeDate)
        };
    }

    private async Task<List<PriceDaily>> GetPriceHistoryWithCacheAsync(string code)
    {
        if (_priceHistoryCache.TryGetValue(code, out var cached))
        {
            return cached;
        }

        var prices = await _db.PricesDaily
            .Where(x => x.Code == code)
            .Where(x => x.ClosePrice != null)
            .OrderBy(x => x.TradeDate)
            .ToListAsync();

        _priceHistoryCache[code] = prices;

        return prices;
    }

    private async Task<List<MarketIndexDaily>> GetMarketIndexHistoryWithCacheAsync(
    string indexName)
    {
        if (_marketIndexHistoryCache.TryGetValue(indexName, out var cached))
        {
            return cached;
        }

        var prices = await _db.MarketIndicesDaily
            .Where(x => x.IndexName == indexName)
            .Where(x => x.CloseValue != null)
            .OrderBy(x => x.TradeDate)
            .ToListAsync();

        _marketIndexHistoryCache[indexName] = prices;

        return prices;
    }

    private async Task<float> CalculateMarketMomentum25Async(
    string indexName,
    DateTime tradeDate)
    {
        var allPrices = await GetMarketIndexHistoryWithCacheAsync(indexName);

        var prices = allPrices
            .Where(x => x.TradeDate <= tradeDate)
            .TakeLast(25)
            .ToList();

        if (prices.Count < 25)
        {
            return 0;
        }

        var first = prices[0].CloseValue;
        var latest = prices[^1].CloseValue;

        if (first == null || first <= 0 || latest == null)
        {
            return 0;
        }

        return (float)((latest.Value - first.Value) / first.Value * 100m);
    }

    private class TechnicalFeatureValues
    {
        public float Momentum5 { get; set; }

        public float Momentum25 { get; set; }

        public float DeviationFromMa25 { get; set; }

        public float VolumeRatio5 { get; set; }

        public float ClosePositionInRange25 { get; set; }

        public float Ma25Slope { get; set; }

        public float Ma75Slope { get; set; }
    }

    private class MarketFeatureValues
    {
        public float TopixMomentum25 { get; set; }

        public float Sp500Momentum25 { get; set; }

        public float NasdaqMomentum25 { get; set; }

        public float UsdJpyMomentum25 { get; set; }

        public float VixMomentum25 { get; set; }
    }
}