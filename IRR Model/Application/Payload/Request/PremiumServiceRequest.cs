
using Newtonsoft.Json;


namespace IRR.Application.Payload.Request
{

    
    public class PremiumServiceRequest
    {
        private int premiumView;
        private double premium;
        private int layerId;
        private int premiumFrequency;

        [JsonProperty("layerId")]
        public int LayerId { get => layerId; set => layerId = value; }

        [JsonProperty("premium")]
        public double Premium { get => premium; set => premium = value; }

        [JsonProperty("premiumView")]
        public int PremiumView { get => premiumView; set => premiumView = value; }

        [JsonProperty("premiumFrequency")]
        public int PremiumFrequency { get => premiumFrequency; set => premiumFrequency = value; }


        public PremiumServiceRequest() { }

        public PremiumServiceRequest(

        int LayerId,
        double premium,
        int PremiumView,
        int PremiumFrequency

        )
        {
            this.LayerId = LayerId;
            this.Premium = premium;
            this.PremiumView = PremiumView;
            this.PremiumFrequency = PremiumFrequency;
        }

    }
}
