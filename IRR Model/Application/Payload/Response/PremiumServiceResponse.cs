using IRR.Application.Payload.Request;
using IRR.Domain.DTOs;

namespace IRR.Application.Payload.Response
{
    public record PremiumServiceResponse(
        
        PremiumServiceRequest Request,
        IEnumerable<PremiumValue> PremiumValues
        
        )
    {



    }
}
