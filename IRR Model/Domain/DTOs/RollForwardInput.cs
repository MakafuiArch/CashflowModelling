using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace IRR.Domain.DTOs
{
    public class RollForwardInput(DateTime RollForwardDate, bool ApplyRollForward = true)
    {

        private readonly DateTime _rollForwardDate = RollForwardDate;

        private readonly bool _applyRollForward = ApplyRollForward;


        public DateTime RollForwardDate => _rollForwardDate;   
        public bool ApplyRollForward => _applyRollForward;


    }
}
