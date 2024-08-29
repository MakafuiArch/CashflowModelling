using IRR.Domain.DTOs;

namespace IRR.Application.Payload
{


    [Serializable]
    public record IRRResponse(double irr,  IEnumerable<CashFlow> cashflows)
    {
    }
}
