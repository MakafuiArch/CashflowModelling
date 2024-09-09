namespace LossPayment.Application.Payload.Response
{
    public class PaymentPattern
    {
        private int PaymentMonths;

        private double PaymentPercentage;


        public PaymentPattern() { }

        public PaymentPattern(int paymentMonths, double paymentPercentage)
        {

            PaymentMonths = paymentMonths;
            PaymentPercentage = paymentPercentage;
        }



        public int Months { get => PaymentMonths; set => PaymentMonths = value; }

        public double Percentage { get => PaymentPercentage; set => PaymentPercentage = value; }



    }
}
