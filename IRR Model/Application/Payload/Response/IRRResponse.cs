using IRR.Domain.DTOs;

namespace IRR.Application.Payload.Response
{


    [Serializable]
    public record IRRResponse(double irr, double InvestmentIncomeOnFloat, 
        double InvestmentIncomeOnCapital, 
        IEnumerable<CashFlow> cashflows)
    {


    }
}
