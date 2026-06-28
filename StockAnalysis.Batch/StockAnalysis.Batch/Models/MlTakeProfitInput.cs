using Microsoft.ML.Data;

namespace StockAnalysis.Batch.Models;

public class MlTakeProfitInput : IMlRegressionInput
{
    public DateTime TradeDate { get; set; }

    public float FinancialScore { get; set; }

    public float GrowthScore { get; set; }

    public float DividendScore { get; set; }

    public float RoeScore { get; set; }

    public float PerScore { get; set; }

    public float PbrScore { get; set; }

    public float TechnicalScore { get; set; }

    public float SwingScore { get; set; }

    public float MarketScore { get; set; }

    public float Momentum5 { get; set; }

    public float Momentum25 { get; set; }

    public float DeviationFromMa25 { get; set; }

    public float VolumeRatio5 { get; set; }

    public float ClosePositionInRange25 { get; set; }

    public float Ma25Slope { get; set; }

    public float Ma75Slope { get; set; }

    // 日本株市場の地合いとして利用。
    // Feature Importance は低かったが、まずは残して比較する。
    public float TopixMomentum25 { get; set; }

    [ColumnName("Label")]
    public float FutureMaxReturn10 { get; set; }
}