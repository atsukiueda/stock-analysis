using Microsoft.EntityFrameworkCore;
using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;
using StockAnalysis.Batch.Models.Ml;

namespace StockAnalysis.Batch.Services;

/// <summary>
/// MLモデルで使用するテクニカル特徴量・市場特徴量の計算を担当するサービス。
/// Up5学習、CSVキャッシュ生成、将来のUp10/TP/SL学習で共通利用する。
/// </summary>
public class MlFeatureCalculationService
{
    private readonly StockAnalysisDbContext _db;

    private readonly Dictionary<string, List<PriceDaily>> _priceHistoryCache = new();

    private readonly Dictionary<string, List<MarketIndexDaily>> _marketIndexHistoryCache = new();

    private readonly Dictionary<string, MlTechnicalFeatures?> _technicalFeatureCache = new();

    private readonly Dictionary<DateTime, MlMarketFeatures> _marketFeatureCache = new();

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    /// <param name="db">DBコンテキスト。</param>
    public MlFeatureCalculationService(
        StockAnalysisDbContext db)
    {
        _db = db;
    }

    /// <summary>
    /// 指定銘柄・指定日のテクニカル特徴量を計算する。
    /// </summary>
    /// <param name="code">銘柄コード。</param>
    /// <param name="tradeDate">基準日。</param>
    /// <returns>テクニカル特徴量。計算不能な場合はnull。</returns>
    public async Task<MlTechnicalFeatures?> CalculateTechnicalFeaturesAsync(
        string code,
        DateTime tradeDate)
    {
        var prices = await _db.PricesDaily
            .AsNoTracking()
            .Where(x => x.Code == code)
            .Where(x => x.TradeDate <= tradeDate)
            .Where(x => x.ClosePrice != null)
            .OrderByDescending(x => x.TradeDate)
            .Take(80)
            .OrderBy(x => x.TradeDate)
            .ToListAsync();

        if (prices.Count < 25)
        {
            return null;
        }

        var latest = prices[^1];

        if (latest.ClosePrice == null ||
            latest.ClosePrice <= 0)
        {
            return null;
        }

        var close = latest.ClosePrice.Value;

        var close5Ago = prices.Count >= 6
            ? prices[^6].ClosePrice
            : null;

        var close25Ago = prices.Count >= 26
            ? prices[^26].ClosePrice
            : null;

        var momentum5 = CalculateReturn(close5Ago, close);
        var momentum25 = CalculateReturn(close25Ago, close);

        var ma25 = prices
            .TakeLast(25)
            .Where(x => x.ClosePrice != null)
            .Average(x => x.ClosePrice!.Value);

        var deviationFromMa25 =
            ma25 > 0
                ? (close - ma25) / ma25 * 100m
                : 0m;

        var volume5Average = prices
            .TakeLast(5)
            .Where(x => x.Volume != null)
            .Select(x => x.Volume!.Value)
            .DefaultIfEmpty(0)
            .Average();

        var volume25Average = prices
            .TakeLast(25)
            .Where(x => x.Volume != null)
            .Select(x => x.Volume!.Value)
            .DefaultIfEmpty(0)
            .Average();

        var volumeRatio5 =
            volume25Average > 0
                ? (decimal)(volume5Average / volume25Average)
                : 0m;

        var high25 = prices
            .TakeLast(25)
            .Where(x => x.HighPrice != null)
            .Max(x => x.HighPrice!.Value);

        var low25 = prices
            .TakeLast(25)
            .Where(x => x.LowPrice != null)
            .Min(x => x.LowPrice!.Value);

        var closePositionInRange25 =
            high25 > low25
                ? (close - low25) / (high25 - low25)
                : 0.5m;

        var ma25Slope = CalculateMaSlope(
            prices,
            25);

        var ma75Slope = CalculateMaSlope(
            prices,
            75);

        return new MlTechnicalFeatures
        {
            Momentum5 = (float)momentum5,
            Momentum25 = (float)momentum25,
            DeviationFromMa25 = (float)deviationFromMa25,
            VolumeRatio5 = (float)volumeRatio5,
            ClosePositionInRange25 = (float)closePositionInRange25,
            Ma25Slope = (float)ma25Slope,
            Ma75Slope = (float)ma75Slope
        };
    }

    /// <summary>
    /// 指定日の市場特徴量を計算する。
    /// </summary>
    /// <param name="tradeDate">基準日。</param>
    /// <returns>市場特徴量。</returns>
    public async Task<MlMarketFeatures> CalculateMarketFeaturesAsync(
        DateTime tradeDate)
    {
        return new MlMarketFeatures
        {
            TopixMomentum25 = await CalculateMarketMomentum25Async("TOPIX", tradeDate),
            Sp500Momentum25 = await CalculateMarketMomentum25Async("SP500", tradeDate),
            NasdaqMomentum25 = await CalculateMarketMomentum25Async("NASDAQ", tradeDate),
            UsdJpyMomentum25 = await CalculateMarketMomentum25Async("USDJPY", tradeDate),
            VixMomentum25 = await CalculateMarketMomentum25Async("VIX", tradeDate)
        };
    }

    /// <summary>
    /// 指定市場指数の25営業日モメンタムを計算する。
    /// </summary>
    private async Task<float> CalculateMarketMomentum25Async(
        string indexName,
        DateTime tradeDate)
    {
        var prices = await _db.MarketIndicesDaily
            .AsNoTracking()
            .Where(x => x.IndexName == indexName)
            .Where(x => x.TradeDate <= tradeDate)
            .Where(x => x.CloseValue != null)
            .OrderByDescending(x => x.TradeDate)
            .Take(25)
            .OrderBy(x => x.TradeDate)
            .ToListAsync();

        if (prices.Count < 25)
        {
            return 0;
        }

        var first = prices[0].CloseValue;
        var latest = prices[^1].CloseValue;

        if (first == null ||
            first <= 0 ||
            latest == null)
        {
            return 0;
        }

        return (float)((latest.Value - first.Value) / first.Value * 100m);
    }

    /// <summary>
    /// 指定期間の移動平均傾きを計算する。
    /// </summary>
    private static decimal CalculateMaSlope(
        List<PriceDaily> prices,
        int period)
    {
        if (prices.Count < period + 5)
        {
            return 0m;
        }

        var latestMa = prices
            .TakeLast(period)
            .Where(x => x.ClosePrice != null)
            .Average(x => x.ClosePrice!.Value);

        var previousMa = prices
            .Skip(prices.Count - period - 5)
            .Take(period)
            .Where(x => x.ClosePrice != null)
            .Average(x => x.ClosePrice!.Value);

        if (previousMa <= 0)
        {
            return 0m;
        }

        return (latestMa - previousMa) / previousMa * 100m;
    }

    /// <summary>
    /// 騰落率を計算する。
    /// </summary>
    private static decimal CalculateReturn(
        decimal? before,
        decimal after)
    {
        if (before == null ||
            before <= 0)
        {
            return 0m;
        }

        return (after - before.Value) / before.Value * 100m;
    }

    /// <summary>
    /// 指定銘柄・指定日のテクニカル特徴量をキャッシュ付きで取得する。
    /// </summary>
    public async Task<MlTechnicalFeatures?> GetTechnicalFeaturesAsync(
        string code,
        DateTime tradeDate)
    {
        var key = $"{code}_{tradeDate:yyyyMMdd}";

        if (_technicalFeatureCache.TryGetValue(key, out var cached))
        {
            return cached;
        }

        var features = await CalculateTechnicalFeaturesAsync(
            code,
            tradeDate);

        _technicalFeatureCache[key] = features;

        return features;
    }

    /// <summary>
    /// 指定日の市場特徴量をキャッシュ付きで取得する。
    /// </summary>
    public async Task<MlMarketFeatures> GetMarketFeaturesAsync(DateTime tradeDate)
    {
        if (_marketFeatureCache.TryGetValue(tradeDate, out var cached))
        {
            return cached;
        }

        var features = await CalculateMarketFeaturesAsync(tradeDate);

        _marketFeatureCache[tradeDate] = features;

        return features;
    }
}