using Microsoft.AspNetCore.Mvc;
using IRR.Domain.DTOs;
using IRR.Application.Interface;
using IRR.Application.Payload;
using Microsoft.Spark.Sql;
using LanguageExt.Pipes;

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
        /// <param name="ids"> Special Purpose Vehicle Investor Ids</param>
        /// <returns>This returns an enumeration of all the Premium Schedules</returns>
        [HttpPost("getpremiums")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IEnumerable<IRRPremiumInputDTO> GetPremium([FromBody] List<int> ids)
        {
            IEnumerable<IRRPremiumInputDTO> PremiumInputs = _irrService.GetIRRPremiumInput(ids).GetAwaiter().GetResult();
            return PremiumInputs;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="Inputs"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("get-cashflows-for-investor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public DataFrame GetCashFlows([FromBody] IRRInputs Inputs) => _irrService.GetIRRForSPInvestor(Inputs).Result[Inputs.SPInvestorId].Item1;



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("multiyear-spid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public double GetMultiYearIRRForSPInvestor([FromBody] IRRInputs Inputs)
        {
           return _irrService.GetIRRForSPInvestor(Inputs).Result[Inputs.SPInvestorId].Item2;
        }

    }
}
