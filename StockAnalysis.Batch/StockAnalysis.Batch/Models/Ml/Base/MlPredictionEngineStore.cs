using Microsoft.ML;
using StockAnalysis.Batch.Models;
using StockAnalysis.Batch.Models.Ml;

namespace StockAnalysis.Batch.Services.Ml.Base;

/// <summary>
/// PredictionEngineの作成・キャッシュを担当するクラス。
/// 同じモデル名のPredictionEngineを再利用し、Baseクラスの肥大化を防ぐ。
/// </summary>
public class MlPredictionEngineStore
{
    private readonly MLContext _mlContext;
    private readonly MlModelStore _modelStore;

    private readonly Dictionary<string, PredictionEngine<MlStockPredictionInput, MlStockPredictionOutput>> _predictionEngineCache = new();

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    /// <param name="mlContext">ML.NET共通コンテキスト。</param>
    /// <param name="modelStore">モデル保存・読込処理。</param>
    public MlPredictionEngineStore(
        MLContext mlContext,
        MlModelStore modelStore)
    {
        _mlContext = mlContext;
        _modelStore = modelStore;
    }

    /// <summary>
    /// 指定されたモデル名のPredictionEngineを取得する。
    /// 未作成の場合はモデルを読み込み、PredictionEngineを作成してキャッシュする。
    /// </summary>
    /// <param name="modelName">モデル名。拡張子なし。</param>
    /// <param name="modelTitle">ログ・例外表示用モデル名。例: Up5。</param>
    /// <returns>PredictionEngine。</returns>
    public PredictionEngine<MlStockPredictionInput, MlStockPredictionOutput> GetOrCreatePredictionEngine(
        string modelName,
        string modelTitle)
    {
        // 既に作成済みのPredictionEngineがあれば再利用する。
        if (_predictionEngineCache.TryGetValue(modelName, out var cachedEngine))
        {
            return cachedEngine;
        }

        // モデルを取得し、PredictionEngineを作成する。
        var model = _modelStore.GetOrLoadModel(
            modelName,
            modelTitle);

        var predictionEngine =
            _mlContext.Model.CreatePredictionEngine<MlStockPredictionInput, MlStockPredictionOutput>(model);

        // 次回以降の作成コストを避けるため、モデル名単位でキャッシュする。
        _predictionEngineCache[modelName] = predictionEngine;

        return predictionEngine;
    }
}