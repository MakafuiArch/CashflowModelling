namespace IRR.Domain.DTOs
{
    public class LossSchedule
    {

        private  int _year;
        private  DateTime _lossOccurenceDay;
        private  double _unadjustedIncurredLoss;
        private  double _incurredLoss;


        public LossSchedule() { }

        public LossSchedule(int Year,
        DateTime LossOccurrenceDay,
        double UnadjustedIncurredLoss,
        double IncurredLoss)
        {
            _year = Year;
            _unadjustedIncurredLoss = UnadjustedIncurredLoss;
            _lossOccurenceDay = LossOccurrenceDay;
            _incurredLoss = IncurredLoss;
        }

        public int Year {get => _year; set => _year = value; }
        public DateTime LossOccurenceDay { get => _lossOccurenceDay; set => _lossOccurenceDay = value; }

        public double UnadjustedIncurredLoss { get => _unadjustedIncurredLoss; set => _unadjustedIncurredLoss = value; }

        public double IncurredLoss { get => _incurredLoss; set { _incurredLoss = value; } }
    }
}
