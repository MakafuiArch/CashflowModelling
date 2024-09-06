namespace LossPayment.Application.Payload.Response
{

    public class PaidLossResponse(

        int LayerId,
        int Day,
        DateTime OccurrenceDay,
        double Ratio,
        double PaidLoss

        )
    {
        private int _layerId = LayerId;
        private int _day = Day;
        private DateTime _occurrenceDay = OccurrenceDay;
        private double _ratio = Ratio;
        private double _paidLoss = PaidLoss;



        public int LayerId { get => _layerId; set => _layerId = value; }
        public int Day { get => _day; set => _day = value; }

        public DateTime OccurrenceDay { get => _occurrenceDay; set => _occurrenceDay = value; }

        public double Ratio { get => _ratio; set => _ratio = value; }

        public double PaidLoss { get => _paidLoss; set => _paidLoss = value; }


    }

}
