using StockAnalysis.Batch.Models;
using StockAnalysis.Batch.Services;
using StockAnalysis.Batch.Backtest;

namespace StockAnalysis.Batch.Backtest.Analysis;

/// <summary>
/// バックテスト結果の分析を担当するクラス
/// </summary>
public class BacktestAnalyzer
{
    /// <summary>
    /// 感度分析用の集計結果を作成する
    /// </summary>
    /// <param name="scenario">バックテストシナリオ</param>
    /// <param name="results">バックテスト取引結果</param>
    /// <returns>感度分析結果</returns>
    public SensitivityResult AnalyzeSensitivity(
        BacktestScenario scenario,
        List<BacktestTradeResult> results)
    {
        if (results.Count == 0)
        {
            return new SensitivityResult
            {
                ScenarioName = scenario.Name,
                TradeCount = 0,
                WinRate = 0,
                CapitalReturn = 0,
                MaxDrawdown = 0,
                ProfitFactor = 0,
                AvgHoldingDays = 0
            };
        }

        var executionSettings = new BacktestExecutionSettings();

        var winCount = results.Count(x => x.ReturnRate > 0);
        var winRate = (decimal)winCount / results.Count * 100m;

        var grossProfit = results
            .Where(x => x.NetProfitAmount > 0)
            .Sum(x => x.NetProfitAmount);

        var grossLoss = results
            .Where(x => x.NetProfitAmount < 0)
            .Sum(x => Math.Abs(x.NetProfitAmount));

        var profitFactor = grossLoss > 0
            ? grossProfit / grossLoss
            : 999m;

        var capital = executionSettings.InitialCapital;
        var equityPeak = capital;
        var maxDrawdown = 0m;

        foreach (var result in results.OrderBy(x => x.EntryDate))
        {
            capital += result.NetProfitAmount;

            if (capital > equityPeak)
            {
                equityPeak = capital;
            }

            var drawdown = equityPeak > 0
                ? (equityPeak - capital) / equityPeak * 100m
                : 0m;

            if (drawdown > maxDrawdown)
            {
                maxDrawdown = drawdown;
            }
        }

        var netProfit = capital - executionSettings.InitialCapital;

        var capitalReturn =
            netProfit / executionSettings.InitialCapital * 100m;

        var avgHoldingDays =
            results.Average(x => x.HoldingDays);

        return new SensitivityResult
        {
            ScenarioName = scenario.Name,
            TradeCount = results.Count,
            WinRate = winRate,
            CapitalReturn = capitalReturn,
            MaxDrawdown = maxDrawdown,
            ProfitFactor = profitFactor,
            AvgHoldingDays = avgHoldingDays
        };
    }

    /// <summary>
    /// フィルタ分析行を生成する。
    /// バックテスト候補がどのフィルタで除外されたかを分析するために使用する。
    /// </summary>
    /// <param name="row">分析対象。</param>
    /// <param name="rows">格納先。</param>
    public void AddFilterAnalysisRow(
        FilterAnalysisRow row,
        List<FilterAnalysisRow> rows)
    {
        rows.Add(row);
    }
}