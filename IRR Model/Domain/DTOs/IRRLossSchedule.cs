namespace IRR.Domain.DTOs
{
    public class IRRLossSchedule(int RetroProfileId, 
        int RetroProgramId,
        int SPInvestorId, int Year, 
        DateTime LossOccurrenceDay, 
        double UnadjustedIncurredLoss, 
        double IncurredLoss)
    {

        private readonly int _year = Year;
        private readonly DateTime _lossOccurenceDay = LossOccurrenceDay;
        private readonly double _unadjustedIncurredLoss = UnadjustedIncurredLoss;
        private double _incurredLoss = IncurredLoss;
        private readonly int _RetroProfileId = RetroProfileId;
        private readonly int _RetroProgramId = RetroProgramId;
        private readonly int _SPInvestorId = SPInvestorId;



        public int RetroProfileId => _RetroProfileId;

        public int RetroProgramId => _RetroProgramId;

        public int SPInvestorId => _SPInvestorId;


        public int Year => _year;
        public DateTime LossOccurenceDay => _lossOccurenceDay;

        public double UnadjustedIncurredLoss => _unadjustedIncurredLoss;

        public double IncurredLoss { get => _incurredLoss; set { _incurredLoss = value; } }
    }
}
