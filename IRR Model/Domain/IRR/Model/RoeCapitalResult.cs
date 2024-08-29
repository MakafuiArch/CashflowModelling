using System;
using System.Collections.Generic;

namespace CashflowModelling.Domain.IRR.Model;

public partial class RoeCapitalResult
{
    public int RoeCapitalResultId { get; set; }

    public int LayerId { get; set; }

    public int FieldStatus { get; set; }

    public int LossView { get; set; }

    public int RoeResultBasis { get; set; }

    public double? PresentValueUnderwritingProfit { get; set; }

    public double? DiscountedCombinedRatio { get; set; }

    public double? DiscountedLossRatio { get; set; }

    public double? PremiumCharge { get; set; }

    public double? ReserveCharge { get; set; }

    public double? CatastropheCharge { get; set; }

    public double? AssetCharge { get; set; }

    public double? TotalCharge { get; set; }

    public double? AgencyCapitalCharge { get; set; }

    public double? ReturnOnEquity { get; set; }

    public double? DiscountRateOnReserves { get; set; }

    public double? DiscountRateOnPremiums { get; set; }

    public double? InvestmentYield { get; set; }

    public double? PaymentDuration { get; set; }

    public DateTimeOffset? YieldCurveDate { get; set; }

    public double? OverallPremiumToSurplus { get; set; }

    public double? ImpliedMinimumCatastrophePremium { get; set; }

    public double? ImpliedCatastropheMargin { get; set; }

    public double? ImpliedMinimumCatastropheCapital { get; set; }

    public double? ImpliedCatastropheReserveCharge { get; set; }

    public double? OverallMinimumPremiumToSurplus { get; set; }

    public double? OverallMinimumCapital { get; set; }

    public double? OverallMinimumCapitalReturnOnEquity { get; set; }

    public double? MaximumCatastrophePremiumToSurplus { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public virtual Layer Layer { get; set; } = null!;
}
