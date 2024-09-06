using LossPayment.Application.Payload.Response;
using LossPayment.Application.Interface;



namespace LossPayment.Application.Service
{
    public class ProportionalPaidLoss: IPaidLoss
    {


        public IEnumerable<PaidLossResponse> GetPaidLossesByLayerId(int LayerId, double LayerAmount, DateTime OccurrenceDate)
        {

            var YearEnd = new DateTime(OccurrenceDate.Year, 12, 31);
            var DateRange = Enumerable.Range(0, OccurrenceDate.Subtract(YearEnd).Days).AsParallel()
                .Select(day => OccurrenceDate.AddDays(day)).ToList();

            Parallel.ForEach(DateRange, date =>
            {

            });


            throw new NotImplementedException();    

        }


        public IEnumerable<PaidLossResponse> GetPaidLossesByMasterKey(int MasterKey, double LayerAmount, DateTime OccurrenceDate)
        {


            throw new NotImplementedException();
        }


        


    }
}
