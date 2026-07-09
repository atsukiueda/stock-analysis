using StockAnalysis.Batch.Models;

namespace StockAnalysis.Batch.Services.Ml.Prediction;

/// <summary>
/// TakeProfit / StopLoss の回帰予測を提供するProvider。
/// 単一モデル、Weighted Ensemble、将来のVoting Ensembleを同じインターフェースで扱う。
/// </summary>
public interface IRegressionPredictionProvider
{
    /// <summary>
    /// 指定スコア行に対してTakeProfit / StopLossを予測する。
    /// </summary>
    /// <param name="score">予測対象のスコア行。</param>
    /// <returns>回帰予測結果。</returns>
    Task<RegressionPrediction> PredictAsync(
        StockScoreDaily score);
}