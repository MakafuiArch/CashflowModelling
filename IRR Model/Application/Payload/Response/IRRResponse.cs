using IRR.Domain.DTOs;

namespace IRR.Application.Payload.Response
{


    [Serializable]
    public record IRRResponse(double irr, IEnumerable<CashFlow> cashflows)
    {
    }
}
