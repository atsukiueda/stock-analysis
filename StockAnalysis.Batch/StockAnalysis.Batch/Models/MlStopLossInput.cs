using Microsoft.ML.Data;

namespace StockAnalysis.Batch.Models;

public class MlStopLossInput : IMlRegressionInput
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

    public float TopixMomentum25 { get; set; }

    public float Sp500Momentum25 { get; set; }

    public float NasdaqMomentum25 { get; set; }

    public float UsdJpyMomentum25 { get; set; }

    public float VixMomentum25 { get; set; }

    [ColumnName("Label")]
    public float FutureMinReturn10 { get; set; }
}