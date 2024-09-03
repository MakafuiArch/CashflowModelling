
namespace IRR.Application.Payload.Request
{

    
    public record PremiumServiceRequest(

        IEnumerable<LayerPremium> layersPremiums,
        int premiumView,
        int premiumFrequency,
        bool aggregateTheResult = true

        )
    {


    }
}
