namespace StockAnalysis.Batch.Backtest.Analysis;

/// <summary>
/// バックテスト候補銘柄が各フィルタでどう扱われたかをCSV出力するためのDTO。
/// AIが高評価した銘柄が、TP・Momentum・EVなどのどこで除外されたかを分析する。
/// </summary>
public class FilterAnalysisRow
{
    /// <summary>
    /// シグナル発生日。
    /// </summary>
    public DateTime TradeDate { get; set; }

    /// <summary>
    /// バックテストシナリオ名。
    /// </summary>
    public string ScenarioName { get; set; } = "";

    /// <summary>
    /// 銘柄コード。
    /// </summary>
    public string Code { get; set; } = "";

    /// <summary>
    /// 会社名。
    /// </summary>
    public string CompanyName { get; set; } = "";

    /// <summary>
    /// 市場局面。
    /// </summary>
    public string Regime { get; set; } = "";

    /// <summary>
    /// Up5予測確率。
    /// </summary>
    public decimal Up5Probability { get; set; }

    /// <summary>
    /// Up10予測確率。
    /// </summary>
    public decimal Up10Probability { get; set; }

    /// <summary>
    /// 予測利確幅。
    /// </summary>
    public decimal ExpectedTakeProfit { get; set; }

    /// <summary>
    /// 予測損切幅。
    /// </summary>
    public decimal ExpectedStopLoss { get; set; }

    /// <summary>
    /// 予測期待値。
    /// </summary>
    public decimal ExpectedValue { get; set; }

    /// <summary>
    /// 直近25営業日の騰落率。
    /// </summary>
    public decimal Momentum25 { get; set; }

    /// <summary>
    /// 直近5営業日の騰落率。
    /// </summary>
    public decimal Momentum5 { get; set; }

    /// <summary>
    /// AIランキングスコア。
    /// </summary>
    public decimal AiRankingScore { get; set; }

    /// <summary>
    /// フィルタ結果。
    /// Selected / Regime / TP / M25 / M5 / EV など。
    /// </summary>
    public string Result { get; set; } = "";
}