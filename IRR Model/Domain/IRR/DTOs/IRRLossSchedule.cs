namespace CashflowModelling.Domain.IRR.DTOs
{
    public class IRRLossSchedule(int Year, DateTime LossOccurrenceDay, Decimal UnadjustedIncurredLoss, Decimal IncurredLoss)
    {

        private readonly int _year = Year;
        private readonly DateTime _lossOccurenceDay = LossOccurrenceDay;
        private readonly Decimal _unadjustedIncurredLoss = UnadjustedIncurredLoss;
        private readonly Decimal _incurredLoss = IncurredLoss;


        public int Year {  get { return _year; } }
        public DateTime LossOccurenceDay { get { return _lossOccurenceDay; } }

        public Decimal UnadjustedIncurredLoss { get { return _unadjustedIncurredLoss; } }

        public Decimal IncurredLoss { get { return _incurredLoss; } }
    }
}
