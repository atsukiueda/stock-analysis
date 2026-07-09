using System.Globalization;
using System.Text;
using StockAnalysis.Batch.Backtest.Analysis;

namespace StockAnalysis.Batch.Backtest.Report;

/// <summary>
/// バックテスト結果をモデル比較用CSVへ出力する。
/// FastTree、LightGBM、FastForest、Ensembleの比較を継続的に蓄積するために使用する。
/// </summary>
public sealed class BacktestComparisonExporter
{
    /// <summary>
    /// 感度分析結果をモデル比較用CSVへ追記する。
    /// </summary>
    /// <param name="modelName">比較対象のモデル名。</param>
    /// <param name="results">感度分析結果。</param>
    public void Export(
        string modelName,
        IReadOnlyCollection<SensitivityResult> results)
    {
        if (results.Count == 0)
        {
            return;
        }

        var outputDirectory = Path.Combine(
            AppContext.BaseDirectory,
            "BacktestResults");

        Directory.CreateDirectory(outputDirectory);

        var path = Path.Combine(
            outputDirectory,
            "BacktestComparison.csv");

        var writeHeader = !File.Exists(path);

        var sb = new StringBuilder();

        if (writeHeader)
        {
            sb.AppendLine(
                "ExecutedAt,ModelName,Scenario,Trades,WinRate,CapitalReturn,MaxDrawdown,ProfitFactor,AvgHoldingDays");
        }

        foreach (var result in results)
        {
            // 小数点表記を環境依存にしないため、InvariantCultureでCSV文字列を作成する。
            sb.AppendLine(string.Join(
                ",",
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                EscapeCsv(modelName),
                EscapeCsv(result.ScenarioName),
                result.TradeCount.ToString(CultureInfo.InvariantCulture),
                result.WinRate.ToString("F2", CultureInfo.InvariantCulture),
                result.CapitalReturn.ToString("F2", CultureInfo.InvariantCulture),
                result.MaxDrawdown.ToString("F2", CultureInfo.InvariantCulture),
                result.ProfitFactor.ToString("F2", CultureInfo.InvariantCulture),
                result.AvgHoldingDays.ToString("F2", CultureInfo.InvariantCulture)));
        }

        File.AppendAllText(
            path,
            sb.ToString(),
            Encoding.UTF8);

        Console.WriteLine($"バックテスト比較CSV出力: {path}");
    }

    /// <summary>
    /// CSV用に文字列をエスケープする。
    /// </summary>
    /// <param name="value">CSVへ出力する文字列。</param>
    /// <returns>CSV用にエスケープ済みの文字列。</returns>
    private static string EscapeCsv(string value)
    {
        if (!value.Contains(',') &&
            !value.Contains('"') &&
            !value.Contains('\n'))
        {
            return value;
        }

        return $"\"{value.Replace("\"", "\"\"")}\"";
    }
}