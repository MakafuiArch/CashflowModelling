using IRR.Application.Payload.Request;
using IRR.Domain.DTOs;
using Newtonsoft.Json;

namespace IRR.Application.Payload.Response
{
    public class PremiumServiceResponse(
        
        PremiumServiceRequest Request,
        IEnumerable<PremiumValue> PremiumValues
        
        )
    {

        [JsonProperty("request")]
        public PremiumServiceRequest request { get; set; }  = Request;

        [JsonProperty("premiumValues")]
        public IEnumerable<PremiumValue> premiumValues { get; set;}  = PremiumValues;

    }
}
