namespace StockAnalysis.Batch.Models.Ml;

/// <summary>
/// MLモデル用の銘柄別テクニカル特徴量。
/// </summary>
public class MlTechnicalFeatures
{
    public float Momentum5 { get; set; }
    public float Momentum25 { get; set; }
    public float DeviationFromMa25 { get; set; }
    public float VolumeRatio5 { get; set; }
    public float ClosePositionInRange25 { get; set; }
    public float Ma25Slope { get; set; }
    public float Ma75Slope { get; set; }
}