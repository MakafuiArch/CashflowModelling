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



        public int RetroProfileId { get { return _RetroProfileId; } }

        public int RetroProgramId { get { return _RetroProgramId; } }

        public int SPInvestorId { get { return _SPInvestorId; } }


        public int Year {  get { return _year; } }
        public DateTime LossOccurenceDay { get { return _lossOccurenceDay; } }

        public Decimal UnadjustedIncurredLoss { get { return _unadjustedIncurredLoss; } }

        public Decimal IncurredLoss { get { return _incurredLoss; } }
    }
}
