namespace IRR.Domain.DTOs
{
    [Serializable]
    public class PaidSchedule(int RetroProfileId, int RetroProgramId,
        int SPInvestorId,int DayCount, DateTime LossPaymentDate,
        decimal UnadjustedPaid, decimal PaidLosss)
    {
        private readonly int _dayCount = DayCount;
        private readonly DateTime _lossPaymentDate = LossPaymentDate;
        private readonly decimal _unadjustedPaid = UnadjustedPaid;
        private readonly decimal _paidLoss = PaidLosss;
        private readonly int _RetroProfileId = RetroProfileId;
        private readonly int _RetroProgramId = RetroProgramId;
        private readonly int _SPInvestorId = SPInvestorId;



        public int RetroProfileId => _RetroProfileId;

        public int RetroProgramId => _RetroProgramId;

        public int SPInvestorId => _SPInvestorId;

        public int DayCount => _dayCount;
        public DateTime LossPaymentDate => _lossPaymentDate;

        public decimal UnadjustedPaid => _unadjustedPaid;

        public decimal PaidLoss => _paidLoss;
    }
}
