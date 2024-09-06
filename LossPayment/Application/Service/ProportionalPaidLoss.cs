using LossPayment.Application.Payload.Response;
using LossPayment.Application.Interface;
using Microsoft.VisualBasic;


namespace LossPayment.Application.Service
{
    public class ProportionalPaidLoss: IPaidLoss
    {


        public IEnumerable<PaidLossResponse> GetPaidLosses(int LayerId, double LayerAmount, DateTime OccurrenceDate)
        {

            var YearEnd = new DateTime(OccurrenceDate.Year, 12, 31);
            var DateRange = Enumerable.Range(0, OccurrenceDate.Subtract(YearEnd).Days).AsParallel().Map(day 
                => OccurrenceDate.AddDays(day));

            Parallel.ForEach(DateRange, date =>
            {

            });


            throw new NotImplementedException();    

        }



    }
}
