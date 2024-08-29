namespace CashflowModelling.Domain.IRR.DTOs
{
    [Serializable]
    public class PaidSchedule(int DayCount, DateTime LossPaymentDate,
        decimal UnadjustedPaid, decimal PaidLosss)
    {
        private readonly int _dayCount = DayCount;
        private readonly DateTime _lossPaymentDate = LossPaymentDate;
        private readonly decimal _unadjustedPaid = UnadjustedPaid;
        private readonly decimal _paidLoss = PaidLosss;

        public int DayCount => _dayCount;
        public DateTime LossPaymentDate => _lossPaymentDate;

        public decimal UnadjustedPaid => _unadjustedPaid;

        public decimal PaidLoss => _paidLoss;
    }
}
