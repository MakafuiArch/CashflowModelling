
using System.Runtime.Serialization;

namespace IRR.Domain.DTOs
{
    [Serializable]
    public class PremiumSchedule(int RetroProfileId, int RetroProgramId,
        int SPInvestorId,
        DateTime EarnedDay, double UnadjustedPremium,
        double EarnedPremium, int Year)
    {
        private readonly int _Year = Year;
        private readonly DateTime _EarnedDay = EarnedDay;
        private readonly double? _UnadjustedPremium = UnadjustedPremium;
        private double? _EarnedPremium = EarnedPremium;
        private readonly int _RetroProfileId = RetroProfileId;
        private readonly int _RetroProgramId = RetroProgramId;
        private readonly int _SPInvestorId = SPInvestorId;



        public int RetroProfileId => _RetroProfileId;

        public int RetroProgramId => _RetroProgramId;

        public int SPInvestorId => _SPInvestorId;

        public int Year => _Year;
        public DateTime EarnedDay => _EarnedDay;

        public double UnadjustedPremium => _UnadjustedPremium ?? 0;

        public double EarnedPremium { get => _EarnedPremium ?? 0; set { _EarnedPremium = value; } }
    }
}
