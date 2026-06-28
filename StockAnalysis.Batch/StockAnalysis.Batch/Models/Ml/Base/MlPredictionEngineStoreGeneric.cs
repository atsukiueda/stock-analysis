using Microsoft.ML;

namespace StockAnalysis.Batch.Services.Ml.Base;

/// <summary>
/// PredictionEngineの作成・キャッシュを担当するジェネリッククラス。
/// TakeProfit、StopLossなど、入力・出力型が異なるMLモデルで共通利用する。
/// </summary>
/// <typeparam name="TInput">ML.NET予測入力型。</typeparam>
/// <typeparam name="TOutput">ML.NET予測出力型。</typeparam>
public class MlPredictionEngineStore<TInput, TOutput>
    where TInput : class
    where TOutput : class, new()
{
    private readonly MLContext _mlContext;
    private readonly MlModelStore _modelStore;

    private readonly Dictionary<string, PredictionEngine<TInput, TOutput>> _predictionEngineCache = new();

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
    /// <param name="modelTitle">ログ・例外表示用モデル名。例: TakeProfit。</param>
    /// <returns>PredictionEngine。</returns>
    public PredictionEngine<TInput, TOutput> GetOrCreatePredictionEngine(
        string modelName,
        string modelTitle)
    {
        // 既に作成済みのPredictionEngineがあれば再利用する。
        if (_predictionEngineCache.TryGetValue(modelName, out var cachedEngine))
        {
            return cachedEngine;
        }

        // 共通ModelStoreから学習済みモデルを取得する。
        var model = _modelStore.GetOrLoadModel(
            modelName,
            modelTitle);

        // 入力・出力型に応じたPredictionEngineを作成する。
        var predictionEngine =
            _mlContext.Model.CreatePredictionEngine<TInput, TOutput>(model);

        // 次回以降の作成コストを避けるため、モデル名単位でキャッシュする。
        _predictionEngineCache[modelName] = predictionEngine;

        return predictionEngine;
    }
}