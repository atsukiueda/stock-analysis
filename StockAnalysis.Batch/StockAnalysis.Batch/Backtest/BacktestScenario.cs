namespace StockAnalysis.Batch.Backtest;

/// <summary>
/// バックテストシナリオ
/// </summary>
public class BacktestScenario
{
    public string Name { get; set; } = "";

    public decimal Up5Weight { get; set; }

    public decimal Up10Weight { get; set; }

    public decimal TakeProfitWeight { get; set; }

    public decimal StopLossWeight { get; set; }

    public decimal TotalScoreWeight { get; set; }

    public decimal? MinExpectedTakeProfit { get; set; }
    public decimal? MaxExpectedTakeProfit { get; set; }

    public decimal? MaxMomentum25 { get; set; }
    public decimal? MinMomentum25 { get; set; }

    // Momentum25の特定レンジを除外するための下限。
    // 例：-10 <= Momentum25 < 0 を除外したい場合、
    // ExcludeMomentum25Min = -10m を設定する。
    public decimal? ExcludeMomentum25Min { get; set; }

    // Momentum25の特定レンジを除外するための上限。
    // 例：-10 <= Momentum25 < 0 を除外したい場合、
    // ExcludeMomentum25Max = 0m を設定する。
    public decimal? ExcludeMomentum25Max { get; set; }

    // ExpectedTakeProfitの特定レンジを除外するための下限。
    // 例：20 <= ExpectedTP < 25 を除外したい場合、
    // ExcludeExpectedTakeProfitMin = 20m を設定する。
    public decimal? ExcludeExpectedTakeProfitMin { get; set; }

    // ExpectedTakeProfitの特定レンジを除外するための上限。
    // 例：20 <= ExpectedTP < 25 を除外したい場合、
    // ExcludeExpectedTakeProfitMax = 25m を設定する。
    public decimal? ExcludeExpectedTakeProfitMax { get; set; }

    public decimal? ExcludeCrossExpectedTakeProfitMin { get; set; }
    public decimal? ExcludeCrossExpectedTakeProfitMax { get; set; }

    public decimal? ExcludeCrossMomentum25Min { get; set; }
    public decimal? ExcludeCrossMomentum25Max { get; set; }

    public List<string>? AllowedRegimes { get; set; }

    public decimal? MaxMomentum5 { get; set; }

    /// <summary>
    /// ExpectedValue の下限フィルタ。
    /// 期待値が低い銘柄を除外したい場合に使用する。
    /// </summary>
    public decimal? MinExpectedValue { get; set; }

    /// <summary>
    /// ExpectedValue の上限フィルタ。
    /// 期待値が高すぎる銘柄を除外したい場合に使用する。
    /// </summary>
    public decimal? MaxExpectedValue { get; set; }

    /// <summary>
    /// Momentum5 の下限フィルタ。
    /// 直近5営業日の騰落率が低すぎる銘柄を除外したい場合に使用する。
    /// </summary>
    public decimal? MinMomentum5 { get; set; }

    /// <summary>
    /// 最大保有営業日数。
    /// 未指定の場合は既定値を使う。
    /// </summary>
    public int? MaxHoldingBusinessDays { get; set; }

    /// <summary>
    /// エントリー日の下限。
    /// ウォークフォワード検証で評価期間を絞るために使用する。
    /// </summary>
    public DateTime? EntryDateFrom { get; set; }

    /// <summary>
    /// エントリー日の上限。
    /// ウォークフォワード検証で評価期間を絞るために使用する。
    /// </summary>
    public DateTime? EntryDateTo { get; set; }
}