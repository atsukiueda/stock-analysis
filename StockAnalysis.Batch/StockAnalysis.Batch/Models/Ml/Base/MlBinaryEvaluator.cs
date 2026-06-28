using Microsoft.ML;
using StockAnalysis.Batch.Models.Ml;

namespace StockAnalysis.Batch.Services.Ml.Base;

/// <summary>
/// 二値分類モデルの評価処理を担当するクラス。
/// Accuracy、AUC、F1、Top20HitRateなど、売買候補選定に必要な評価指標を計算する。
/// </summary>
public class MlBinaryEvaluator
{
    private readonly MLContext _mlContext;

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    /// <param name="mlContext">ML.NET共通コンテキスト。</param>
    public MlBinaryEvaluator(MLContext mlContext)
    {
        _mlContext = mlContext;
    }

    /// <summary>
    /// 二値分類モデルを評価する。
    /// Accuracy、AUC、F1、予測True/False件数、Top20 HitRateを出力する。
    /// </summary>
    /// <param name="modelName">評価対象モデル名。</param>
    /// <param name="model">学習済みモデル。</param>
    /// <param name="testSet">評価用データ。</param>
    /// <returns>評価結果。</returns>
    public MlBinaryModelEvaluationResult Evaluate(
        string modelName,
        ITransformer model,
        IDataView testSet)
    {
        // 評価用データに対して予測を実行する。
        var predictions = model.Transform(testSet);

        // Top20評価や予測件数集計のため、予測結果をオブジェクトへ展開する。
        var predictionRows = _mlContext.Data
            .CreateEnumerable<MlStockPredictionWithLabel>(
                predictions,
                reuseRowObject: false)
            .ToList();

        // 予測ラベルのTrue/False件数を集計する。
        var predictedPositiveCount = predictionRows.Count(x => x.PredictedLabel);
        var predictedNegativeCount = predictionRows.Count - predictedPositiveCount;

        // 確率上位20件の命中率を確認する。
        var top20 = predictionRows
            .OrderByDescending(x => x.Probability)
            .Take(20)
            .ToList();

        var top20HitCount = top20.Count(x => x.Label);
        var top20HitRate = top20.Count == 0
            ? 0
            : (double)top20HitCount / top20.Count;

        // ML.NET標準指標を計算する。
        var metrics = _mlContext.BinaryClassification.Evaluate(
            predictions,
            labelColumnName: "Label");

        Console.WriteLine();
        Console.WriteLine($"=== {modelName} 評価結果 ===");
        Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
        Console.WriteLine($"AUC     : {metrics.AreaUnderRocCurve:P2}");
        Console.WriteLine($"F1Score : {metrics.F1Score:P2}");
        Console.WriteLine($"Predicted True : {predictedPositiveCount}");
        Console.WriteLine($"Predicted False: {predictedNegativeCount}");
        Console.WriteLine($"Test Top20 HitCount: {top20HitCount}");
        Console.WriteLine($"Test Top20 HitRate : {top20HitRate:P2}");

        return new MlBinaryModelEvaluationResult
        {
            ModelName = modelName,
            Accuracy = metrics.Accuracy,
            Auc = metrics.AreaUnderRocCurve,
            F1Score = metrics.F1Score,
            PredictedPositiveCount = predictedPositiveCount,
            PredictedNegativeCount = predictedNegativeCount,
            Top20HitCount = top20HitCount,
            Top20HitRate = top20HitRate
        };
    }

    /// <summary>
    /// ML.NETの二値分類予測結果を評価用に受け取る内部クラス。
    /// </summary>
    private class MlStockPredictionWithLabel
    {
        /// <summary>
        /// 実際の正解ラベル。
        /// </summary>
        public bool Label { get; set; }

        /// <summary>
        /// 予測ラベル。
        /// </summary>
        public bool PredictedLabel { get; set; }

        /// <summary>
        /// 正例である確率。
        /// </summary>
        public float Probability { get; set; }

        /// <summary>
        /// モデル内部スコア。
        /// </summary>
        public float Score { get; set; }
    }
}