namespace StockAnalysis.Batch.Models.Ml;

/// <summary>
/// 回帰モデルの設定値。
/// appsettings.json から読み込み、学習アルゴリズムの切り替えに使用する。
/// </summary>
public class MlRegressionModelSettings
{
    /// <summary>
    /// TakeProfitモデルで使用する回帰アルゴリズム。
    /// </summary>
    public string TakeProfitRegressionModelType { get; set; } = "FastTree";

    /// <summary>
    /// StopLossモデルで使用する回帰アルゴリズム。
    /// </summary>
    public string StopLossRegressionModelType { get; set; } = "FastTree";
}