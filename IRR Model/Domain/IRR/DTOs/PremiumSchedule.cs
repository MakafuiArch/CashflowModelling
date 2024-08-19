
namespace CashflowModelling.Domain.IRR.DTOs
{
    [Serializable]
    public class PremiumSchedule(int RetroProfileId, int RetroProgramId,
        int SPInvestorId,
        DateTime EarnedDay, decimal UnadjustedPremium,
        decimal EarnedPremium, int Year)
    {
        private readonly int _Year = Year;
        private readonly DateTime _EarnedDay = EarnedDay;
        private readonly decimal? _UnadjustedPremium = UnadjustedPremium;
        private readonly decimal? _EarnedPremium = EarnedPremium;
        private readonly int _RetroProfileId = RetroProfileId;
        private readonly int _RetroProgramId = RetroProgramId;
        private readonly int _SPInvestorId = SPInvestorId;



        public int RetroProfileId => _RetroProfileId;

        public int RetroProgramId => _RetroProgramId;

        public int SPInvestorId => _SPInvestorId;

        public int Year => _Year;
        public DateTime EarnedDay => _EarnedDay;

        public decimal UnadjustedPremium => _UnadjustedPremium ?? 0;

        public decimal EarnedPremium => _EarnedPremium ?? 0; 
    }
}
