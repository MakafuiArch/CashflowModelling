namespace IRR.Domain.DTOs
{
    [Serializable]
    public class PaidSchedule
    {
        private int _dayCount;
        private DateTime _lossPaymentDate;
        private double _unadjustedPaid;
        private double _paidLoss;




        public PaidSchedule()
        {

        }

        public PaidSchedule(int DayCount, DateTime LossPaymentDate,
        double UnadjustedPaid, double PaidLoss)
        {
            _dayCount = DayCount;
            _lossPaymentDate = LossPaymentDate;
            _unadjustedPaid = UnadjustedPaid;
            _paidLoss = PaidLoss;
        }



        public int DayCount { get => _dayCount; set => _dayCount = value; }
        public DateTime LossPaymentDate { get => _lossPaymentDate; set => _lossPaymentDate = value; }

        public double UnadjustedPaid {get => _unadjustedPaid; set => _unadjustedPaid = value; }

        public double PaidLoss { get => _paidLoss; set { _paidLoss = value; } }
    }
}
