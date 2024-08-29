namespace IRR.Domain.DTOs
{
    public class CapitalSchedule(int Id, double IncrementalCapitalAdded, DateTime date)
    {

        private readonly int _id = Id;
        private readonly double _incrementalCapitalAdded = IncrementalCapitalAdded;
        private readonly DateTime _date = date;


        public int Id => _id;
        public double IncrementalCapitalAdded => _incrementalCapitalAdded;

        public DateTime Date => _date;

    }
}
