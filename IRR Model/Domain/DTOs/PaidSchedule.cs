namespace IRR.Domain.DTOs
{
    [Serializable]
    public class PaidSchedule(int RetroProfileId, int RetroProgramId,
        int SPInvestorId,int DayCount, DateTime LossPaymentDate,
        double UnadjustedPaid, double PaidLoss)
    {
        private readonly int _dayCount = DayCount;
        private readonly DateTime _lossPaymentDate = LossPaymentDate;
        private readonly double _unadjustedPaid = UnadjustedPaid;
        private readonly double _paidLoss = PaidLoss;
        private readonly int _RetroProfileId = RetroProfileId;
        private readonly int _RetroProgramId = RetroProgramId;
        private readonly int _SPInvestorId = SPInvestorId;



        public int RetroProfileId => _RetroProfileId;

        public int RetroProgramId => _RetroProgramId;

        public int SPInvestorId => _SPInvestorId;

        public int DayCount => _dayCount;
        public DateTime LossPaymentDate => _lossPaymentDate;

        public double UnadjustedPaid => _unadjustedPaid;

        public double PaidLoss => _paidLoss;
    }
}
