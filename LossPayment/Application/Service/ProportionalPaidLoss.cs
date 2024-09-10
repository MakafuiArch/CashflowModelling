using LossPayment.Application.Payload.Response;
using LossPayment.Application.Interface;
using System.Collections.Concurrent;
using Microsoft.Extensions.Caching.Memory;
using LossPayment.Application.Payload.Request;
using CsvHelper.Configuration;
using System.Globalization;
using CsvHelper;
using LossPayment.Application.Mapping;
using Microsoft.VisualBasic;




namespace LossPayment.Application.Service
{
    public class ProportionalPaidLoss: IPaidLoss
    {

        private readonly IQuery query;

        private readonly IMemoryCache memoryCache;

        private readonly IConfiguration configuration;

       

        public ProportionalPaidLoss(IQuery query, IMemoryCache memoryCache, IConfiguration configuration) { 

            this.query = query;
            this.memoryCache = memoryCache;
            this.configuration = configuration;
           
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

            return await Task.FromResult(response.OrderBy(p => p.Day));

        }




        public async Task<IEnumerable<PaidLossResponse>> GetPaidLossesByLayerId(int LayerId, 
            double LayerAmount, DateTime OccurrenceDate, int MultiYearPeriod=0)
        {

            ConcurrentBag<PaidLossResponse> results = [];
            var PaymentDictionary = new ConcurrentDictionary<int, double>();


            var PaymentPatternResult = (await GetPaymentPatternByLayerCSV<PaymentPattern, PaymentPatternMap>(LayerId)).ToList();


            var lastPaymentMonth = PaymentPatternResult.AsParallel().Where(p => 
                            p.Percentage ==1).OrderBy(p => p.Months).Select(p => p.Months).FirstOrDefault();


            PaymentPatternResult = PaymentPatternResult.AsParallel().Where(p => (p.Months <= lastPaymentMonth)).ToList();


            var RangeDate = Enumerable.Range(0, OccurrenceDate.AddYears(lastPaymentMonth/12).Subtract(OccurrenceDate).Days)
                                      .Select(day => OccurrenceDate.AddDays(day)).ToList();  

            
       
            Parallel.ForEach(PaymentPatternResult, req =>
            {

                var totalYearDays = OccurrenceDate.AddYears(req.Months/12).Subtract(OccurrenceDate).Days;

                if(req.Months == 12)
                {
                    PaymentDictionary.TryAdd(req.Months/12, req.Percentage/totalYearDays);

                }
                else{

                    PaymentDictionary.TryAdd(req.Months / 12, (req.Percentage 
                                            - PaymentPatternResult.Find(p => p.Months == req.Months - 12)!.Percentage)/totalYearDays);
                }

            });

            var nextLayerAmount = LayerAmount;


            for(int i=0; i < RangeDate.Count; i++)
            {


                int dictKey = (((int) Math.Floor((decimal) DateAndTime.DateDiff(DateInterval.Year, OccurrenceDate, RangeDate[i]))) * 12)/12 ;
               
                if(i == 0)
                {
                    results.Add(new PaidLossResponse

                    {

                        LayerId = LayerId,
                        Day = i,
                        OccurrenceDay = RangeDate[i],
                        Ratio = PaymentDictionary[dictKey],
                        PaidLoss =  PaymentDictionary[dictKey] * LayerAmount
                    }

                 );

                    continue;
                }

                results.Add(new PaidLossResponse

                    {

                        LayerId = LayerId,
                        Day = i, 
                        OccurrenceDay = RangeDate[i],
                        Ratio = PaymentDictionary[dictKey],
                        PaidLoss = (double) results.ElementAt(i-1).PaidLoss + PaymentDictionary[dictKey] * LayerAmount
                    }

                    );

                
            }

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
            if (!memoryCache.TryGetValue(cachekey, out TResult result))
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

        private async Task<IEnumerable<T>> GetPaymentPatternByLayerCSV<T, MapType>(int LayerId) where MapType: ClassMap
        {

            var FilePath = configuration.GetValue<string>("ConnectionString:PaymentPatternPath") + $"PaymentPattern_{LayerId}.csv";

            StreamReader streamReader = new StreamReader(FilePath);


            var csvconf = new CsvConfiguration(cultureInfo: CultureInfo.InvariantCulture)
            {

                HasHeaderRecord = true,
                Delimiter = ",",
                Comment = '%'
            };

            var csvFileReader = new CsvReader(streamReader, csvconf);


            csvFileReader.Context.RegisterClassMap<MapType>();

            var records = csvFileReader.GetRecords<T>();
            


            return await Task.FromResult(records);
        }
      


    }
}
