namespace IRR.Domain.IRR.DTOs
{
    public class IRRLossSchedule(int RetroProfileId, 
        int RetroProgramId,
        int SPInvestorId, int Year, 
        DateTime LossOccurrenceDay, 
        decimal UnadjustedIncurredLoss, 
        decimal IncurredLoss)
    {

        private readonly int _year = Year;
        private readonly DateTime _lossOccurenceDay = LossOccurrenceDay;
        private readonly decimal _unadjustedIncurredLoss = UnadjustedIncurredLoss;
        private readonly decimal _incurredLoss = IncurredLoss;
        private readonly int _RetroProfileId = RetroProfileId;
        private readonly int _RetroProgramId = RetroProgramId;
        private readonly int _SPInvestorId = SPInvestorId;



        public int RetroProfileId => _RetroProfileId;

        public int RetroProgramId => _RetroProgramId;

        public int SPInvestorId => _SPInvestorId;


        public int Year => _year;
        public DateTime LossOccurenceDay => _lossOccurenceDay;

        public decimal UnadjustedIncurredLoss => _unadjustedIncurredLoss;

        public decimal IncurredLoss => _incurredLoss;
    }
}
