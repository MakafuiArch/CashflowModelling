namespace IRR.Domain.DTOs
{
    public class CapitalSchedule(int Id, decimal IncrementalCapitalAdded, DateTime date)
    {

        private readonly int _id = Id;
        private readonly decimal _incrementalCapitalAdded = IncrementalCapitalAdded;
        private readonly DateTime _date = date;


        public int Id => _id;
        public decimal IncrementalCapitalAdded => _incrementalCapitalAdded;

        public DateTime Date => _date;

    }
}
