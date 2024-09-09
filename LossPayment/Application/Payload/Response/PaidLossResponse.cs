namespace LossPayment.Application.Payload.Response
{

    public class PaidLossResponse
    {
        private int _layerId ;
        private int _day ;
        private DateTime _occurrenceDay ;
        private double _ratio;
        private double _paidLoss ;

        public PaidLossResponse() { }

        public PaidLossResponse(int LayerId, int Day, DateTime OccurrenceDay, double Ratio, double PaidLoss)
        {
            _layerId = LayerId ;
            _day = Day ;
            _occurrenceDay = OccurrenceDay ;
            _ratio = Ratio ;
            _paidLoss = PaidLoss ;
        }

        public int LayerId { get => _layerId; set => _layerId = value; }
        public int Day { get => _day; set => _day = value; }

        public DateTime OccurrenceDay { get => _occurrenceDay; set => _occurrenceDay = value; }

        public double Ratio { get => _ratio; set => _ratio = value; }

        public double PaidLoss { get => _paidLoss; set => _paidLoss = value; }


    }

}
