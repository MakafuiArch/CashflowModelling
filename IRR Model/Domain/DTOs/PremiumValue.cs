using Newtonsoft.Json;

namespace IRR.Domain.DTOs
{
    public class PremiumValue
    {

        private int layerId;
        private int submissionId;
        private int day;
        private DateTime date;
        private int premiumview;
        private double ratio;
        private double value;


        [JsonProperty("layerId")]
        public int LayerId { get =>  layerId; set => layerId = value;}

        [JsonProperty("submissionId")]
        public int SubmissionId { get => submissionId; set => submissionId = value;}

        [JsonProperty("day")]
        public int Day { get => day; set => day = value;}

        [JsonProperty("date")]
        public DateTime Date { get => date; set => date = value;}

        [JsonProperty("premiumView")]
        public int PremiumView { get => premiumview; set => premiumview = value;}

        [JsonProperty("ratio")]
        public double Ratio { get => ratio; set => ratio = value;}


        public double Value { get => value; set => this.value = value;}


        public PremiumValue() { }

        public PremiumValue(

        int LayerId,
        int SubmissionId,
        int Day,
        DateTime Date,
        int PremiumView,
        double Ratio,
        double Value

        )
        {
            this.LayerId = LayerId;
            this.SubmissionId = SubmissionId;
            this.Day = Day;
            this.Date = Date;
            this.PremiumView = PremiumView;
            this.Ratio = ratio;
            this.Value = Value;

        }




    }
}
