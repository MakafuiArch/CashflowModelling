using LossPayment.Application.Payload.Response;
using LossPayment.Application.Interface;
using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Memory;
using LossPayment.Application.Payload.Request;



namespace LossPayment.Application.Service
{
    public class ProportionalPaidLoss: IPaidLoss
    {

        private readonly IQuery query;

        private readonly IMemoryCache memoryCache;

        public ProportionalPaidLoss(IQuery query, IMemoryCache memoryCache) { 

            this.query = query;
            this.memoryCache = memoryCache;
        }



        public async Task<IEnumerable<PaidLossResponse>> GetPaidLossesByLayerIds(IEnumerable<PaidLossRequest> request)
        {

            var response = new List<PaidLossResponse>();

            Parallel.ForEach(request, async req => {

                var PaidLosses = await GetPaidLossesByLayerId(req.LayerId, req.LossAmount, req.OccurrenceDate);
                lock (PaidLosses)
                {
                    response.AddRange(PaidLosses);

                }
            });

            return await Task.FromResult(response);

        }




        public async Task<IEnumerable<PaidLossResponse>> GetPaidLossesByLayerId(int LayerId, 
            double LayerAmount, DateTime OccurrenceDate, int MultiYearPeriod=0)
        {

            ConcurrentBag<PaidLossResponse> results = [];


             var PaymentPatternResult = await GetCachedObject(LayerId.ToString(),LayerId, GetPaymentPatternByLayer);
            

            var PaymentPattern = PaymentPatternResult.AsParallel().Where(pay => pay.Months == (MultiYearPeriod + 1) * 12)
                                                                  .Select(p => p.Percentage).FirstOrDefault();

            var YearEnd = new DateTime(OccurrenceDate.Year, 12, 31);

            var YearStart = new DateTime(OccurrenceDate.Year, 1, 1);

            
            var WholeYearDays = YearEnd.Subtract(YearStart).Days;


            var DateRange = Enumerable.Range(0, OccurrenceDate.Subtract(YearEnd).Days).AsParallel()
                .Select(day => OccurrenceDate.AddDays(day)).ToList();


            Parallel.ForEach(DateRange, date =>
            {

                var datediff = YearEnd.Subtract(date).Days;

                var percentage = PaymentPattern * datediff / WholeYearDays;

                results.Add(new PaidLossResponse
                {
                    LayerId = LayerId,
                    Day = DateRange.IndexOf(date) + MultiYearPeriod * 12 + 1,
                    OccurrenceDay = date,
                    Ratio = percentage,
                    PaidLoss = LayerAmount * percentage 

                });

            });


            return await Task.FromResult(results.ToList());

        }


        public IEnumerable<PaidLossResponse> GetPaidLossesByMasterKey(int MasterKey, double LayerAmount, DateTime OccurrenceDate)
        {


            throw new NotImplementedException();
        }


        private async Task<TResult> GetCachedObject<Input, TResult>(string cachekey, 
                        Input input, Func<Input, Task<TResult>> cacheFunc)
        {

#pragma warning disable CS8600 
            if (memoryCache.TryGetValue(cachekey, out TResult result))
            {
                result = await cacheFunc.Invoke(input);
                memoryCache.Set(cachekey, result);
            }
#pragma warning restore CS8600 
            return result!;
        }


        private async Task<IEnumerable<PaymentPattern>> GetPaymentPatternByLayer(int LayerId)
        {

            var QueryString = query.GetLossPaymentPatternQuery(LayerId);

            return await query.QuerySet<PaymentPattern>(QueryString);
        }
      


    }
}
