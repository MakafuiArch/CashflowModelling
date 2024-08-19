
namespace CashflowModelling.Domain.IRR.DTOs
{
    [Serializable]
    public class PremiumSchedule(DateTime EarnedDay, decimal UnadjustedPremium,
        decimal EarnedPremium, int Year)
    {
        private readonly int _Year = Year;
        private readonly DateTime _EarnedDay = EarnedDay;
        private readonly decimal? _UnadjustedPremium = UnadjustedPremium;
        private readonly decimal? _EarnedPremium = EarnedPremium;

        public int Year {  get { return _Year; } }
        public DateTime EarnedDay { get { return _EarnedDay; } }

        public decimal UnadjustedPremium { get { return _UnadjustedPremium ?? 0; } }

        public decimal EarnedPremium { get { return _EarnedPremium ?? 0; } }
    }
}
