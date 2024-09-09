using CsvHelper.Configuration;
using LossPayment.Application.Payload.Response;

namespace LossPayment.Application.Mapping
{
    public class PaymentPatternMap : ClassMap<PaymentPattern>
    {



        public PaymentPatternMap() {



            Map(pattern => pattern.Months).Index(0);
            Map(pattern => pattern.Percentage).Index(1);
        
        
        
        }




    }
}
