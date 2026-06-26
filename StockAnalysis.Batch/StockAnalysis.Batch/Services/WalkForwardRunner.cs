using StockAnalysis.Batch.Factories;
using StockAnalysis.Batch.Services.Interfaces;

namespace StockAnalysis.Batch.Services;

/// <summary>
/// ウォークフォワード検証全体を実行するサービス。
/// 現時点ではUp5モデルの期間別学習を制御する。
/// </summary>
public class WalkForwardRunner
{
    private readonly IMlWalkForwardTrainingService _up5TrainingService;
    private readonly BacktestService _backtestService;

    /// <summary>
    /// コンストラクタ。
    /// </summary>
    /// <param name="up5TrainingService">Up5モデル学習サービス。</param>
    public WalkForwardRunner(
    IMlWalkForwardTrainingService up5TrainingService,
    BacktestService backtestService)
    {
        _up5TrainingService = up5TrainingService;
        _backtestService = backtestService;
    }

    /// <summary>
    /// Up5モデルのウォークフォワード用学習をすべて実行する。
    /// </summary>
    public async Task TrainUp5AllAsync()
    {
        var periods = TrainingPeriodFactory.CreateUp5WalkForwardPeriods();

        foreach (var period in periods)
        {
            Console.WriteLine();
            Console.WriteLine("========================================");
            Console.WriteLine(" WalkForward Up5 Training");
            Console.WriteLine("========================================");
            Console.WriteLine($"Model : {period.ModelName}");
            Console.WriteLine($"Train : {period.TrainFrom:yyyy/MM/dd} ～ {period.TrainTo:yyyy/MM/dd}");
            Console.WriteLine($"Test  : {period.TestFrom:yyyy/MM/dd} ～ {period.TestTo:yyyy/MM/dd}");

            // 指定された学習期間だけでモデルを学習し、period.ModelNameで保存する。
            await _up5TrainingService.TrainAndEvaluateAsync(period);

            await _backtestService.RunAsync(
                period.TestFrom.Value,
                period.TestTo.Value,
                topCount: 5,
                up5ModelName: period.ModelName);
        }
    }
}