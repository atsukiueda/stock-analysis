using StockAnalysis.Batch.Models;

namespace StockAnalysis.Batch.Services.Ml.Prediction;

/// <summary>
/// 複数回帰モデルの予測結果を重み付き平均で統合するProvider。
/// </summary>
public sealed class MlWeightedEnsemblePredictionProvider
    : IRegressionPredictionProvider
{
    private readonly IReadOnlyList<RegressionPredictionProviderWeight> _providerWeights;

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    /// <param name="providerWeights">回帰予測Providerと重みの一覧。</param>
    public MlWeightedEnsemblePredictionProvider(
        IReadOnlyList<RegressionPredictionProviderWeight> providerWeights)
    {
        if (providerWeights.Count == 0)
        {
            throw new ArgumentException(
                "Weighted Ensembleに使用するProviderが指定されていません。",
                nameof(providerWeights));
        }

        _providerWeights = providerWeights;
    }

    /// <summary>
    /// 複数Providerの予測結果を重み付き平均で統合する。
    /// TakeProfitまたはStopLossがnullのProviderは、その銘柄では平均計算から除外する。
    /// </summary>
    /// <param name="score">予測対象のスコア行。</param>
    /// <returns>重み付き平均後の回帰予測結果。</returns>
    public async Task<RegressionPrediction> PredictAsync(
        StockScoreDaily score)
    {
        var takeProfitWeightedSum = 0m;
        var stopLossWeightedSum = 0m;
        var totalWeight = 0m;

        foreach (var providerWeight in _providerWeights)
        {
            // 0以下の重みは無効として扱う。
            if (providerWeight.Weight <= 0)
            {
                continue;
            }

            var prediction =
                await providerWeight.Provider.PredictAsync(score);

            if (prediction.TakeProfit == null ||
                prediction.StopLoss == null)
            {
                continue;
            }

            takeProfitWeightedSum +=
                prediction.TakeProfit.Value * providerWeight.Weight;

            stopLossWeightedSum +=
                prediction.StopLoss.Value * providerWeight.Weight;

            totalWeight += providerWeight.Weight;
        }

        if (totalWeight <= 0)
        {
            return new RegressionPrediction();
        }

        return new RegressionPrediction
        {
            TakeProfit = Math.Round(
                takeProfitWeightedSum / totalWeight,
                4),

            StopLoss = Math.Round(
                stopLossWeightedSum / totalWeight,
                4)
        };
    }
}