using StockAnalysis.Batch.Models;
using StockAnalysis.Batch.Models.Ml;

namespace StockAnalysis.Batch.Services.Ml.Inputs;

/// <summary>
/// TakeProfit回帰モデルの入力データ生成を担当するFactory。
/// StockScoreDaily、テクニカル特徴量、市場特徴量からMlTakeProfitInputを生成する。
/// </summary>
public class MlTakeProfitInputFactory
{
    /// <summary>
    /// TakeProfit予測用入力データを作成する。
    /// </summary>
    /// <param name="score">銘柄スコア行。</param>
    /// <param name="technicalFeatures">テクニカル特徴量。</param>
    /// <param name="marketFeatures">市場特徴量。</param>
    /// <returns>TakeProfit予測用入力データ。</returns>
    public MlTakeProfitInput Create(
        StockScoreDaily score,
        MlTechnicalFeatures technicalFeatures,
        MlMarketFeatures marketFeatures)
    {
        // スコア・テクニカル特徴量・市場特徴量をML入力形式へ詰め替える。
        return new MlTakeProfitInput
        {
            FinancialScore = score.FinancialScore,
            GrowthScore = score.GrowthScore,
            DividendScore = score.DividendScore,
            RoeScore = score.RoeScore,
            PerScore = score.PerScore,
            PbrScore = score.PbrScore,
            TechnicalScore = score.TechnicalScore,
            SwingScore = score.SwingScore,
            MarketScore = score.MarketScore,

            Momentum5 = technicalFeatures.Momentum5,
            Momentum25 = technicalFeatures.Momentum25,
            DeviationFromMa25 = technicalFeatures.DeviationFromMa25,
            VolumeRatio5 = technicalFeatures.VolumeRatio5,
            ClosePositionInRange25 = technicalFeatures.ClosePositionInRange25,
            Ma25Slope = technicalFeatures.Ma25Slope,
            Ma75Slope = technicalFeatures.Ma75Slope,

            // TakeProfitモデルではFeature Importanceの結果から、
            // 市場特徴量はTOPIXモメンタムのみを使用する。
            TopixMomentum25 = marketFeatures.TopixMomentum25
        };
    }
}