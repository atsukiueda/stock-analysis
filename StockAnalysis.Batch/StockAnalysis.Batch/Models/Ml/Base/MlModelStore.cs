using Microsoft.ML;

namespace StockAnalysis.Batch.Services.Ml.Base;

/// <summary>
/// ML.NETモデルの保存・読込・キャッシュを担当するクラス。
/// Up5、Up10、TakeProfit、StopLossなど、モデル種別を問わず共通利用する。
/// </summary>
public class MlModelStore
{
    private const string ModelDirectory = "Models";

    private readonly MLContext _mlContext;

    private readonly Dictionary<string, ITransformer> _loadedModelCache = new();

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    /// <param name="mlContext">ML.NET共通コンテキスト。</param>
    public MlModelStore(MLContext mlContext)
    {
        _mlContext = mlContext;
    }

    /// <summary>
    /// 指定されたモデル名の保存パスを作成する。
    /// </summary>
    /// <param name="modelName">モデル名。拡張子なし。</param>
    /// <returns>モデルzipファイルのフルパス。</returns>
    public string CreateModelPath(string modelName)
    {
        return Path.Combine(
            AppContext.BaseDirectory,
            ModelDirectory,
            $"{modelName}.zip");
    }

    /// <summary>
    /// 学習済みモデルをzipファイルとして保存する。
    /// </summary>
    /// <param name="model">保存対象モデル。</param>
    /// <param name="schema">学習データのSchema。</param>
    /// <param name="modelName">保存するモデル名。拡張子なし。</param>
    /// <returns>保存先パス。</returns>
    public string SaveModel(
        ITransformer model,
        DataViewSchema schema,
        string modelName)
    {
        // モデル保存先ディレクトリを作成する。
        Directory.CreateDirectory(
            Path.Combine(AppContext.BaseDirectory, ModelDirectory));

        var modelPath = CreateModelPath(modelName);

        // ML.NETモデルをzip形式で保存する。
        _mlContext.Model.Save(
            model,
            schema,
            modelPath);

        // 保存直後のモデルをキャッシュへ反映する。
        _loadedModelCache[modelName] = model;

        return modelPath;
    }

    /// <summary>
    /// 指定されたモデル名の学習済みモデルを取得する。
    /// 未読込の場合はModelsフォルダからzipを読み込み、以降はキャッシュを返す。
    /// </summary>
    /// <param name="modelName">モデル名。拡張子なし。</param>
    /// <param name="modelTitle">ログ・例外表示用モデル名。例: Up5。</param>
    /// <returns>読み込み済みモデル。</returns>
    public ITransformer GetOrLoadModel(
        string modelName,
        string modelTitle)
    {
        // 既に読み込んだモデルがあれば、ファイルアクセスせずキャッシュを返す。
        if (_loadedModelCache.TryGetValue(modelName, out var cachedModel))
        {
            return cachedModel;
        }

        var modelPath = CreateModelPath(modelName);

        // モデルファイルが存在しない場合は、学習未実行として明示的に停止する。
        if (!File.Exists(modelPath))
        {
            throw new FileNotFoundException(
                $"{modelTitle}モデルが見つかりません。先に学習を実行してください: {modelPath}");
        }

        // ML.NETモデルをzipから読み込む。
        var model = _mlContext.Model.Load(modelPath, out _);

        // 次回以降の読込を避けるため、モデル名単位でキャッシュする。
        _loadedModelCache[modelName] = model;

        return model;
    }
}