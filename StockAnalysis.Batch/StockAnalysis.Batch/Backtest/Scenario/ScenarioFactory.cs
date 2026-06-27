using StockAnalysis.Batch.Backtest;

namespace StockAnalysis.Batch.Backtest.Scenario;

/// <summary>
/// バックテストシナリオの生成を担当するクラス
/// </summary>
public class ScenarioFactory
{
    /// <summary>
    /// StrongRiskOff専用リバウンド戦略のMomentum25感度分析シナリオを作成する
    /// </summary>
    public List<BacktestScenario> CreateReboundM25SensitivityScenarios()
    {
        return CreateDecimalSensitivityScenarios(
            "M25",
            new decimal[]
            {
            -5m,
            -10m,
            -15m,
            -20m,
            -25m,
            -30m
            },
            (scenario, threshold) =>
            {
                scenario.MaxMomentum25 = threshold;
            });
    }

    /// <summary>
    /// StrongRiskOff専用リバウンド戦略のMomentum5感度分析シナリオを作成する
    /// </summary>
    public List<BacktestScenario> CreateReboundM5SensitivityScenarios()
    {
        return CreateDecimalSensitivityScenarios(
            "M5",
            new decimal[]
            {
            -10m,
            -15m,
            -20m,
            -25m,
            -30m
            },
            (scenario, threshold) =>
            {
                scenario.MaxMomentum5 = threshold;
            });
    }

    /// <summary>
    /// StrongRiskOff専用リバウンド戦略のExpectedValue感度分析シナリオを作成する
    /// </summary>
    public List<BacktestScenario> CreateReboundEvSensitivityScenarios()
    {
        return CreateDecimalSensitivityScenarios(
            "EV",
            new decimal[]
            {
            0m,
            3m,
            6m,
            9m,
            12m
            },
            (scenario, threshold) =>
            {
                scenario.MinExpectedValue = threshold;
            });
    }

    /// <summary>
    /// StrongRiskOff専用リバウンド戦略の基本シナリオを作成する
    /// </summary>
    private BacktestScenario CreateBaseReboundStrongRiskOffScenario(
        string name)
    {
        return new BacktestScenario
        {
            Name = name,

            Up5Weight = 0.1m,
            Up10Weight = 0.1m,
            TakeProfitWeight = 0.8m,
            StopLossWeight = 0.1m,
            TotalScoreWeight = 0.5m,

            AllowedRegimes = new List<string>
        {
            "StrongRiskOff"
        },

            MaxMomentum25 = -10m,
            MaxMomentum5 = -20m,
            MinExpectedTakeProfit = 25m,
            MinExpectedValue = 9m,
            MaxHoldingBusinessDays = 10
        };
    }

    /// <summary>
    /// decimal型の閾値を使う感度分析シナリオを作成する
    /// </summary>
    private List<BacktestScenario> CreateDecimalSensitivityScenarios(
        string parameterName,
        decimal[] thresholds,
        Action<BacktestScenario, decimal> applyThreshold)
    {
        return thresholds
            .Select(threshold =>
            {
                var scenario = CreateBaseReboundStrongRiskOffScenario(
                    $"Rebound_StrongRiskOff_{parameterName}_{Math.Abs(threshold):0}");

                applyThreshold(
                    scenario,
                    threshold);

                return scenario;
            })
            .ToList();
    }

    /// <summary>
    /// StrongRiskOff専用リバウンド戦略のExpectedTP感度分析シナリオを作成する
    /// </summary>
    public List<BacktestScenario> CreateReboundTpSensitivityScenarios()
    {
        return CreateDecimalSensitivityScenarios(
            "TP",
            new decimal[]
            {
            20m,
            25m,
            30m,
            35m
            },
            (scenario, threshold) =>
            {
                scenario.MinExpectedTakeProfit = threshold;
            });
    }

    /// <summary>
    /// リバウンド戦略のRegime感度分析シナリオを作成する
    /// </summary>
    public List<BacktestScenario> CreateReboundRegimeSensitivityScenarios()
    {
        var regimePatterns = new[]
        {
        new
        {
            Name = "StrongRiskOff",
            Regimes = new List<string>
            {
                "StrongRiskOff"
            }
        },
        new
        {
            Name = "RiskOffPlus",
            Regimes = new List<string>
            {
                "RiskOff",
                "StrongRiskOff"
            }
        },
        new
        {
            Name = "NeutralPlus",
            Regimes = new List<string>
            {
                "Neutral",
                "RiskOff",
                "StrongRiskOff"
            }
        },
        new
        {
            Name = "AllRegime",
            Regimes = new List<string>
            {
                "StrongRiskOn",
                "RiskOn",
                "Neutral",
                "RiskOff",
                "StrongRiskOff"
            }
        }
    };

        return regimePatterns
            .Select(pattern =>
            {
                var scenario = CreateBaseReboundStrongRiskOffScenario(
                    $"Rebound_Regime_{pattern.Name}");

                scenario.AllowedRegimes = pattern.Regimes;

                return scenario;
            })
            .ToList();
    }

    /// <summary>
    /// リバウンド戦略のウォークフォワード検証シナリオを作成する
    /// </summary>
    public List<BacktestScenario> CreateReboundWalkForwardScenarios()
    {
        var scenarios = new List<BacktestScenario>();

        var testPeriods = new[]
        {
        new
        {
            Name = "Test2024",
            From = new DateTime(2024, 1, 1),
            To = new DateTime(2024, 12, 31)
        },
        new
        {
            Name = "Test2025",
            From = new DateTime(2025, 1, 1),
            To = new DateTime(2025, 12, 31)
        },
        new
        {
            Name = "Test2026",
            From = new DateTime(2026, 1, 1),
            To = new DateTime(2026, 12, 31)
        }
    };

        foreach (var period in testPeriods)
        {
            var scenario = CreateBaseReboundStrongRiskOffScenario(
                $"Rebound_WF_{period.Name}");

            scenario.EntryDateFrom = period.From;
            scenario.EntryDateTo = period.To;

            scenarios.Add(scenario);
        }

        return scenarios;
    }

    /// <summary>
    /// 指定されたテスト期間で使用するリバウンド戦略シナリオを作成する。
    /// BacktestService.RunAsync側で期間を絞るため、シナリオにはEntryDateFrom/Toを設定しない。
    /// </summary>
    /// <returns>期間固定なしのウォークフォワード用シナリオ一覧。</returns>
    public List<BacktestScenario> CreateReboundWalkForwardBaseScenarios()
    {
        return new List<BacktestScenario>
        {
            new BacktestScenario
            {
                Name = "WF_NoFilter",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,
                MaxHoldingBusinessDays = 10
            },

            CreateBaseReboundStrongRiskOffScenario("WF_Strict_Best"),

            new BacktestScenario
            {
                Name = "WF_RiskOff_M25_10_M5_10_TP25_EV9",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,
                AllowedRegimes = new List<string>
                {
                    "RiskOff",
                    "StrongRiskOff"
                },
                MaxMomentum25 = -10m,
                MaxMomentum5 = -10m,
                MinExpectedTakeProfit = 25m,
                MinExpectedValue = 9m,
                MaxHoldingBusinessDays = 10
            },

            new BacktestScenario
            {
                Name = "WF_RiskOff_M25_10_M5_15_TP25_EV6",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,
                AllowedRegimes = new List<string>
                {
                    "RiskOff",
                    "StrongRiskOff"
                },
                MaxMomentum25 = -10m,
                MaxMomentum5 = -15m,
                MinExpectedTakeProfit = 25m,
                MinExpectedValue = 6m,
                MaxHoldingBusinessDays = 10
            },

            new BacktestScenario
            {
                Name = "WF_StrongRiskOff_M25_10_M5_10_TP25_EV6",
                Up5Weight = 0.1m,
                Up10Weight = 0.1m,
                TakeProfitWeight = 0.8m,
                StopLossWeight = 0.1m,
                TotalScoreWeight = 0.5m,
                AllowedRegimes = new List<string>
                {
                    "StrongRiskOff"
                },
                MaxMomentum25 = -10m,
                MaxMomentum5 = -10m,
                MinExpectedTakeProfit = 25m,
                MinExpectedValue = 6m,
                MaxHoldingBusinessDays = 10
            }
        };
    }
}