
using System.Runtime.Serialization;

namespace IRR.Domain.DTOs
{
    [Serializable]
    public class PremiumSchedule
    {
        private  int _Year;
        private  DateTime _EarnedDay;
        private  double? _UnadjustedPremium;
        private double? _EarnedPremium;
        private  int _LayerId;


        public PremiumSchedule()
        {

        }


        public PremiumSchedule(int LayerId, int RetroProgramId,
        int SPInvestorId,
        DateTime EarnedDay, double UnadjustedPremium,
        double EarnedPremium, int Year)
        {
            _Year = Year;
            _EarnedDay = EarnedDay;
            _LayerId = LayerId;
            _UnadjustedPremium = UnadjustedPremium;
            _EarnedDay = EarnedDay;

        }



        public int LayerId {get => _LayerId; set => _LayerId = value; }

        public int Year {get => _Year; set => _Year = value; }
        public DateTime EarnedDay { get => _EarnedDay; set { _EarnedDay = value; } }

        public double UnadjustedPremium { get => _UnadjustedPremium ?? 0; set { _UnadjustedPremium = value; } }

        public double EarnedPremium { get => _EarnedPremium ?? 0; set { _EarnedPremium = value; } }
    }
}
