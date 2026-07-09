using StockAnalysis.Batch.Data;
using StockAnalysis.Batch.Models;
using StockAnalysis.Batch.Models.Ml;

namespace StockAnalysis.Batch.Services.Ml.Prediction;

/// <summary>
/// 単一の回帰モデル種別でTakeProfit / StopLossを予測するProvider。
/// FastTree、LightGBM、FastForestなどを同じインターフェースで扱うために使用する。
/// </summary>
public sealed class MlSingleModelPredictionProvider : IRegressionPredictionProvider
{
    private readonly MlTakeProfitPredictionService _takeProfitPredictionService;

    private readonly MlStopLossPredictionService _stopLossPredictionService;

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    /// <param name="db">StockAnalysis用DBコンテキスト。</param>
    /// <param name="regressionModelType">使用する回帰モデル種別。</param>
    public MlSingleModelPredictionProvider(
        StockAnalysisDbContext db,
        MlRegressionModelType regressionModelType)
    {
        _takeProfitPredictionService =
            new MlTakeProfitPredictionService(
                db,
                regressionModelType);

        _stopLossPredictionService =
            new MlStopLossPredictionService(
                db,
                regressionModelType);
    }

    /// <summary>
    /// 指定スコア行に対して、単一モデル種別のTakeProfit / StopLossを予測する。
    /// </summary>
    /// <param name="score">予測対象のスコア行。</param>
    /// <returns>回帰予測結果。</returns>
    public async Task<RegressionPrediction> PredictAsync(
        StockScoreDaily score)
    {
        // TakeProfitとStopLossは別モデルのため、それぞれ予測する。
        var takeProfit =
            await _takeProfitPredictionService.PredictAsync(score);

        var stopLoss =
            await _stopLossPredictionService.PredictAsync(score);

        return new RegressionPrediction
        {
            TakeProfit = takeProfit,
            StopLoss = stopLoss
        };
    }
}