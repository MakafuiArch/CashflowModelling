
namespace IRR.Application.Payload.Request
{

    
    public record PremiumServiceRequest(

        int LayerId,
        double premium,
        int PremiumView,
        int PremiumFrequency

        )
    {


    }
}
