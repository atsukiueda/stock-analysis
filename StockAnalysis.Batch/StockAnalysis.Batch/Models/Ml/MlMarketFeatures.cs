namespace StockAnalysis.Batch.Models.Ml;

/// <summary>
/// MLモデル用の市場特徴量。
/// </summary>
public class MlMarketFeatures
{
    public float TopixMomentum25 { get; set; }
    public float Sp500Momentum25 { get; set; }
    public float NasdaqMomentum25 { get; set; }
    public float UsdJpyMomentum25 { get; set; }
    public float VixMomentum25 { get; set; }
}