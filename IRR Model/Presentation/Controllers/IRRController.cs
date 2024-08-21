using Microsoft.AspNetCore.Mvc;
using CashflowModelling.Domain.IRR.DTOs;
using CashflowModelling.Application.IRR.Interface;
using Microsoft.Data.Analysis;

namespace CashflowModelling.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IRRController(IIRR irrService) : ControllerBase
    {
      
        private readonly IIRR _irrService = irrService;


        /// <summary>
        /// Get the Premium Schedule for all Special Purpose Vehichle Investor Id  (SPInvestorId) specified
        /// </summary>
        /// <param name="ids"> This parameter in the list of all the SPInvestorId</param>
        /// <returns>This returns an enumeration of all the Premium Schedules</returns>
        [HttpPost("GetPremiums")]
        public IEnumerable<IRRPremiumInputDTO> GetPremium([FromBody] List<int> ids)
        {
            IEnumerable<IRRPremiumInputDTO> PremiumInputs =  _irrService.GetIRRPremiumInput(ids).GetAwaiter().GetResult();
            return PremiumInputs;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("GetCashFlows")]
        public DataFrame GetCashFlows([FromBody] List<int> ids)
        {



           throw new NotImplementedException();
        }

    }
}
