using System;
using System.Collections.Generic;

namespace IRR.Domain.IRR.Model;

public partial class DeltaPxResult
{
    public int DeltaPxResultId { get; set; }

    public int SubmissionPxPortfolioId { get; set; }

    public int LayerId { get; set; }

    public double? GrossCapitalVarQuote { get; set; }

    public double? GrossCapitalVarAuth { get; set; }

    public double? GrossCapitalVarSigned { get; set; }

    public double? NetCapitalVarQuote { get; set; }

    public double? NetCapitalVarAuth { get; set; }

    public double? NetCapitalVarSigned { get; set; }

    public double? GrossCapitalTvarQuote { get; set; }

    public double? GrossCapitalTvarAuth { get; set; }

    public double? GrossCapitalTvarSigned { get; set; }

    public double? GrossRoevarQuote { get; set; }

    public double? GrossRoevarAuth { get; set; }

    public double? GrossRoevarSigned { get; set; }

    public double? NetRoevarQuote { get; set; }

    public double? NetRoevarAuth { get; set; }

    public double? NetRoevarSigned { get; set; }

    public double? GrossRoetvarQuote { get; set; }

    public double? GrossRoetvarAuth { get; set; }

    public double? GrossRoetvarSigned { get; set; }

    public DateTime CreateDate { get; set; }

    public string? CreateUser { get; set; }

    public DateTime ModifyDate { get; set; }

    public string? ModifyUser { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public double? NetRoevarWithFeesQuote { get; set; }

    public double? NetRoevarWithFeesAuth { get; set; }

    public double? NetRoevarWithFeesSigned { get; set; }

    public double? NetExcessReturnQuote { get; set; }

    public double? NetExcessReturnAuth { get; set; }

    public double? NetExcessReturnSigned { get; set; }

    public double? NetExcessReturnWithFeesQuote { get; set; }

    public double? NetExcessReturnWithFeesAuth { get; set; }

    public double? NetExcessReturnWithFeesSigned { get; set; }

    public double? GrossCatPmlVarArlQuote { get; set; }

    public double? GrossCatPmlVarArlAuth { get; set; }

    public double? GrossCatPmlVarArlSigned { get; set; }

    public double? NetCatPmlArlQuote { get; set; }

    public double? NetCatPmlArlAuth { get; set; }

    public double? NetCatPmlArlSigned { get; set; }

    public double? GrossCatPmlTvarArlQuote { get; set; }

    public double? GrossCatPmlTvarArlAuth { get; set; }

    public double? GrossCatPmlTvarArlSigned { get; set; }

    public double? TargetRoeQuote { get; set; }

    public double? TargetRoeAuth { get; set; }

    public double? TargetRoeSigned { get; set; }

    public double? GrossRoevarCorreQuote { get; set; }

    public double? GrossRoevarCorreAuth { get; set; }

    public string? ReasonStaleQuote { get; set; }

    public string? ReasonStaleAuth { get; set; }

    public string? ReasonStaleSigned { get; set; }

    public byte[] RowVersion { get; set; } = null!;

    public double? NetMinCapitalVarQuote { get; set; }

    public double? NetMinCapitalVarAuth { get; set; }

    public double? NetMinCapitalVarSigned { get; set; }

    public double? NetMinRoevarQuote { get; set; }

    public double? NetMinRoevarAuth { get; set; }

    public double? NetMinRoevarSigned { get; set; }

    public double? MaxCatPts { get; set; }

    public double? NetCatPmlTvarArlQuote { get; set; }

    public double? NetCatPmlTvarArlAuth { get; set; }

    public double? NetCatPmlTvarArlSigned { get; set; }

    public double? NetRoetvarQuote { get; set; }

    public double? NetRoetvarAuth { get; set; }

    public double? NetRoetvarSigned { get; set; }

    public double? NetCapitalTvarQuote { get; set; }

    public double? NetCapitalTvarAuth { get; set; }

    public double? NetCapitalTvarSigned { get; set; }

    public virtual Layer Layer { get; set; } = null!;

    public virtual SubmissionPxPortfolio SubmissionPxPortfolio { get; set; } = null!;
}
