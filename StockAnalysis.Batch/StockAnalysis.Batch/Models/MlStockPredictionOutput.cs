using Microsoft.ML.Data;

namespace StockAnalysis.Batch.Models;

public class MlStockPredictionOutput
{
    [ColumnName("PredictedLabel")]
    public bool PredictedLabel { get; set; }

    public float Probability { get; set; }

    public float Score { get; set; }
}