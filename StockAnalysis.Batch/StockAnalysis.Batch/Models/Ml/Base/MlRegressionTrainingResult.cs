using Microsoft.ML;

namespace StockAnalysis.Batch.Services.Ml.Base;

/// <summary>
/// 回帰モデルの学習結果を保持する。
/// 学習済みモデル、学習データSchema、評価用予測結果をService側へ返すために使用する。
/// </summary>
public class MlRegressionTrainingResult
{
    /// <summary>
    /// 学習済み回帰モデル。
    /// </summary>
    public required ITransformer Model { get; set; }

    /// <summary>
    /// 学習用DataView。
    /// モデル保存時にSchemaを参照するため保持する。
    /// </summary>
    public required IDataView TrainSet { get; set; }

    /// <summary>
    /// 評価用データに対する予測結果。
    /// </summary>
    public required IDataView Predictions { get; set; }
}