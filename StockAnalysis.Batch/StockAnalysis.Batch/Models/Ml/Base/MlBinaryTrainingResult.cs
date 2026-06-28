using Microsoft.ML;

namespace StockAnalysis.Batch.Services.Ml.Base;

/// <summary>
/// 二値分類モデルの学習結果を保持する。
/// 複数候補モデルを比較したうえで、採用モデルと採用モデル名を返すために使用する。
/// </summary>
public class MlBinaryTrainingResult
{
    /// <summary>
    /// 採用された学習済みモデル。
    /// </summary>
    public required ITransformer BestModel { get; set; }

    /// <summary>
    /// 採用されたモデル名。
    /// 例: FastTree、SdcaLogisticRegression。
    /// </summary>
    public required string BestModelName { get; set; }

    /// <summary>
    /// 学習用DataView。
    /// モデル保存時にSchemaを参照するため保持する。
    /// </summary>
    public required IDataView TrainSet { get; set; }
}