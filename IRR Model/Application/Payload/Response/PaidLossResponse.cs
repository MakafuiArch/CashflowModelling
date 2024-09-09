

namespace IRR.Application.Payload.Response
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



        public int LayerId { get => this._layerId; set => this._layerId = value; }
        public int Day { get => this._day; set => this._day = value; }

        public DateTime OccurrenceDay { get => this._occurrenceDay; set => this._occurrenceDay = value; }

        public double Ratio { get => this._ratio; set => this._ratio = value; }

        public double PaidLoss {  get => this._paidLoss; set => this._paidLoss = value;}


    }
}
