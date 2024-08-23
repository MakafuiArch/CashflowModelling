using Microsoft.AspNetCore.Mvc;
using IRR.Domain.DTOs;
using IRR.Application.Interface;
using Microsoft.Data.Analysis;

namespace IRR.Presentation.Controllers
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
        [HttpPost("getpremiums")]
        public IEnumerable<IRRPremiumInputDTO> GetPremium([FromBody] List<int> ids)
        {
            IEnumerable<IRRPremiumInputDTO> PremiumInputs = _irrService.GetIRRPremiumInput(ids).GetAwaiter().GetResult();
            return PremiumInputs;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("getcashflows")]
        public DataFrame GetCashFlows([FromBody] List<int> ids)
        {
            throw new NotImplementedException();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("multiyear-spid")]
        public decimal GetMultiYearIRRForSPInvestor()
        {
            throw new NotImplementedException();
        }

    }
}
