using System.Text;
using StockAnalysis.Batch.Backtest.Analysis;

namespace StockAnalysis.Batch.Backtest.Report;

/// <summary>
/// バックテスト結果の出力を担当するクラス
/// </summary>
public class BacktestReporter
{
    /// <summary>
    /// 感度分析サマリーのヘッダーを表示する
    /// </summary>
    public void PrintSensitivityHeader()
    {
        Console.WriteLine();
        Console.WriteLine("=== 感度分析サマリー ===");
    }

    /// <summary>
    /// 感度分析用の短いバックテスト結果を表示する
    /// </summary>
    public void PrintCompactSummary(
        SensitivityResult result)
    {
        Console.WriteLine(
            $"{result.ScenarioName,-35} " +
            $"Trades:{result.TradeCount,4} " +
            $"WinRate:{result.WinRate,7:F2}% " +
            $"CapitalReturn:{result.CapitalReturn,7:F2}% " +
            $"MaxDD:{result.MaxDrawdown,7:F2}% " +
            $"PF:{result.ProfitFactor,6:F2} " +
            $"AvgHold:{result.AvgHoldingDays,5:F2}");
    }

    /// <summary>
    /// 感度分析結果をCSVファイルに出力する
    /// </summary>
    public void ExportSensitivityResultsToCsv(
        List<SensitivityResult> results)
    {
        if (results.Count == 0)
        {
            return;
        }

        var outputDirectory = Path.Combine(
            AppContext.BaseDirectory,
            "BacktestResults");

        Directory.CreateDirectory(outputDirectory);

        var filePath = Path.Combine(
            outputDirectory,
            $"sensitivity_results_{DateTime.Now:yyyyMMdd_HHmmss}.csv");

        var csv = new StringBuilder();

        csv.AppendLine(
            "Scenario,TradeCount,WinRate,CapitalReturn,MaxDrawdown,ProfitFactor,AvgHoldingDays");

        foreach (var result in results)
        {
            csv.AppendLine(
                $"{EscapeCsv(result.ScenarioName)}," +
                $"{result.TradeCount}," +
                $"{result.WinRate:F2}," +
                $"{result.CapitalReturn:F2}," +
                $"{result.MaxDrawdown:F2}," +
                $"{result.ProfitFactor:F2}," +
                $"{result.AvgHoldingDays:F2}");
        }

        File.WriteAllText(
            filePath,
            csv.ToString(),
            Encoding.UTF8);

        Console.WriteLine();
        Console.WriteLine($"感度分析CSVを出力しました: {filePath}");
    }

    /// <summary>
    /// CSV用に文字列をエスケープする
    /// </summary>
    private static string EscapeCsv(string value)
    {
        if (value.Contains(',') ||
            value.Contains('"') ||
            value.Contains('\n') ||
            value.Contains('\r'))
        {
            return $"\"{value.Replace("\"", "\"\"")}\"";
        }

        return value;
    }
}