using Microsoft.ML;

namespace StockAnalysis.Batch.Services.Ml.Base;

/// <summary>
/// 二値分類モデルで使用するML.NETパイプライン生成を担当するクラス。
/// 特徴量列の結合と正規化を共通化し、Baseクラスの肥大化を防ぐ。
/// </summary>
public class MlBinaryPipelineFactory
{
    private readonly MLContext _mlContext;

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    /// <param name="mlContext">ML.NET共通コンテキスト。</param>
    public MlBinaryPipelineFactory(MLContext mlContext)
    {
        _mlContext = mlContext;
    }

    /// <summary>
    /// 二値分類モデルで共通利用する基本パイプラインを作成する。
    /// 指定された特徴量列をFeatures列へ結合し、MinMax正規化を行う。
    /// </summary>
    /// <param name="featureColumns">学習に使用する特徴量列名。</param>
    /// <returns>特徴量変換パイプライン。</returns>
    public IEstimator<ITransformer> CreateBasePipeline(
        string[] featureColumns)
    {
        // 特徴量未指定はモデル設計ミスなので明示的に停止する。
        if (featureColumns.Length == 0)
        {
            throw new InvalidOperationException("学習に使用する特徴量列が定義されていません。");
        }

        // 複数の特徴量列をML.NETのFeatures列へ結合し、スケール差を抑えるためMinMax正規化する。
        return _mlContext.Transforms.Concatenate(
                "Features",
                featureColumns)
            .Append(_mlContext.Transforms.NormalizeMinMax("Features"));
    }
}