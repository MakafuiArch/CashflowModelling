using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class PortMetric
{
    public int PortMetricId { get; set; }

    public int PortfolioId { get; set; }

    public int LossView { get; set; }

    public int PortMetricType { get; set; }

    public int? EntityId { get; set; }

    public int NumberOfLayersWithShare { get; set; }

    public DateTime MinInception { get; set; }

    public DateTime MaxInception { get; set; }

    public double FirstLimit { get; set; }

    public double AggLimit { get; set; }

    public double DepositPremium { get; set; }

    public double ReinstPremium { get; set; }

    public double ExpectedGrossPremium { get; set; }

    public double AveRolOnFirstLimit { get; set; }

    public double Rpamount { get; set; }

    public double Rbamount { get; set; }

    public double El { get; set; }

    public double Elamount { get; set; }

    public double ElmodeledAmount { get; set; }

    public double ElnonModeledAmount { get; set; }

    public double EllargeLossAmount { get; set; }

    public double ElattritionalAmount { get; set; }

    public double Elmultiple { get; set; }

    public double Lr { get; set; }

    public double ProfitCommAmount { get; set; }

    public double SscommAmount { get; set; }

    public double NcbcommAmount { get; set; }

    public double ExpensesAmount { get; set; }

    public double NetPremiumToExpenses { get; set; }

    public double Er { get; set; }

    public double Cr { get; set; }

    public double ExpectedProfit { get; set; }

    public double StandaloneCapital { get; set; }

    public double StandalonePml { get; set; }

    public double PremiumFactor { get; set; }

    public double ReserveFactor { get; set; }

    public double RequiredCollateral { get; set; }

    public double CollateralPctOfAggLimit { get; set; }

    public double Leverage { get; set; }

    public double StandaloneRoe { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public string? ReasonStale { get; set; }

    public virtual Portfolio Portfolio { get; set; } = null!;
}
