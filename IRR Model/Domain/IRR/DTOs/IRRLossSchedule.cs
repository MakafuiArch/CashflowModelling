namespace CashflowModelling.Domain.IRR.DTOs
{
    public class IRRLossSchedule(int RetroProfileId, int RetroProgramId,
        int SPInvestorId, int Year, 
        DateTime LossOccurrenceDay, 
        Decimal UnadjustedIncurredLoss, 
        Decimal IncurredLoss)
    {

        private readonly int _year = Year;
        private readonly DateTime _lossOccurenceDay = LossOccurrenceDay;
        private readonly Decimal _unadjustedIncurredLoss = UnadjustedIncurredLoss;
        private readonly Decimal _incurredLoss = IncurredLoss;
        private readonly int _RetroProfileId = RetroProfileId;
        private readonly int _RetroProgramId = RetroProgramId;
        private readonly int _SPInvestorId = SPInvestorId;



        public int RetroProfileId => _RetroProfileId;

        public int RetroProgramId => _RetroProgramId;

        public int SPInvestorId => _SPInvestorId;


        public int Year => _year;
        public DateTime LossOccurenceDay => _lossOccurenceDay;

        public Decimal UnadjustedIncurredLoss => _unadjustedIncurredLoss;

        public Decimal IncurredLoss => _incurredLoss;
    }
}
