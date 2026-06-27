namespace StockAnalysis.Batch.Backtest.Analysis;

/// <summary>
/// バックテスト候補銘柄が各フィルタで除外された理由を記録するクラス。
/// BacktestServiceに分析用CSV生成ロジックを直接持たせないために使用する。
/// </summary>
public class FilterAnalysisRecorder
{
    private readonly List<FilterAnalysisRow> _rows = new();

    /// <summary>
    /// 記録済みのフィルタ分析行を取得する。
    /// </summary>
    /// <returns>フィルタ分析行一覧。</returns>
    public List<FilterAnalysisRow> GetRows()
    {
        return _rows;
    }

    /// <summary>
    /// 候補銘柄のフィルタ結果を記録する。
    /// </summary>
    public void Record(
        DateTime tradeDate,
        string scenarioName,
        string code,
        string companyName,
        string regime,
        decimal up5Probability,
        decimal up10Probability,
        decimal expectedTakeProfit,
        decimal expectedStopLoss,
        decimal expectedValue,
        decimal momentum25,
        decimal momentum5,
        decimal aiRankingScore,
        string result)
    {
        _rows.Add(new FilterAnalysisRow
        {
            TradeDate = tradeDate,
            ScenarioName = scenarioName,
            Code = code,
            CompanyName = companyName,
            Regime = regime,
            Up5Probability = up5Probability,
            Up10Probability = up10Probability,
            ExpectedTakeProfit = expectedTakeProfit,
            ExpectedStopLoss = expectedStopLoss,
            ExpectedValue = expectedValue,
            Momentum25 = momentum25,
            Momentum5 = momentum5,
            AiRankingScore = aiRankingScore,
            Result = result
        });
    }
}