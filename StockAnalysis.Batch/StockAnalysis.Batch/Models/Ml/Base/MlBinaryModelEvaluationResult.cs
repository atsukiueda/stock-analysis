namespace StockAnalysis.Batch.Services.Ml.Base;

/// <summary>
/// 二値分類モデルの評価結果を保持する。
/// Up5、Up10、将来の二値分類モデルで共通利用する。
/// </summary>
public class MlBinaryModelEvaluationResult
{
    /// <summary>
    /// 評価対象モデル名。
    /// </summary>
    public required string ModelName { get; set; }

    /// <summary>
    /// 正解率。
    /// </summary>
    public double Accuracy { get; set; }

    /// <summary>
    /// AUC。
    /// </summary>
    public double Auc { get; set; }

    /// <summary>
    /// F1スコア。
    /// </summary>
    public double F1Score { get; set; }

    /// <summary>
    /// 予測結果がTrueだった件数。
    /// </summary>
    public int PredictedPositiveCount { get; set; }

    /// <summary>
    /// 予測結果がFalseだった件数。
    /// </summary>
    public int PredictedNegativeCount { get; set; }

    /// <summary>
    /// 確率上位20件のうち、実際に正例だった件数。
    /// </summary>
    public int Top20HitCount { get; set; }

    /// <summary>
    /// 確率上位20件の正例率。
    /// </summary>
    public double Top20HitRate { get; set; }
}