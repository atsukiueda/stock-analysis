using StockAnalysis.Batch.Models;
using StockAnalysis.Batch.Models.Ml;

namespace StockAnalysis.Batch.Services.Ml.Inputs;

/// <summary>
/// StopLoss回帰モデルの入力データ生成を担当するFactory。
/// StockScoreDaily、テクニカル特徴量、市場特徴量からMlStopLossInputを生成する。
/// </summary>
public class MlStopLossInputFactory
{
    /// <summary>
    /// StopLoss予測用入力データを作成する。
    /// </summary>
    /// <param name="score">銘柄スコア行。</param>
    /// <param name="technicalFeatures">テクニカル特徴量。</param>
    /// <param name="marketFeatures">市場特徴量。</param>
    /// <returns>StopLoss予測用入力データ。</returns>
    public MlStopLossInput Create(
        StockScoreDaily score,
        MlTechnicalFeatures technicalFeatures,
        MlMarketFeatures marketFeatures)
    {
        // スコア・テクニカル特徴量・市場特徴量をStopLossモデル用の入力形式へ詰め替える。
        return new MlStopLossInput
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

            // StopLossモデルではFeature Importanceの検証結果から、
            // TOPIX・USDJPY・VIXの市場特徴量を使用する。
            TopixMomentum25 = marketFeatures.TopixMomentum25,
            UsdJpyMomentum25 = marketFeatures.UsdJpyMomentum25,
            VixMomentum25 = marketFeatures.VixMomentum25
        };
    }
}