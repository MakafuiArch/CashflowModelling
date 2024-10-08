using Microsoft.AspNetCore.Mvc;
using IRR.Domain.DTOs;
using IRR.Application.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.OutputCaching;
using IRR.Application.Payload.Request;
using IRR.Application.Payload.Response;



namespace IRR.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IRRController(IIRR irrService, IDataTest testData) : ControllerBase
    {

        private readonly IIRR _irrService = irrService;
        private readonly IDataTest _testData = testData;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Inputs"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("get-cashflows-for-investor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesErrorResponseType(typeof(SqlException))]
        public double GetCashFlows([FromBody] IRRInputs Inputs) => 
            _irrService.GetIRRForSPInvestor(Inputs).Result[Inputs.SPInvestorId];



        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpPost("multiyear-spid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesErrorResponseType(typeof(SqlException))]
        public double GetMultiYearIRRForSPInvestor([FromBody] IRRInputs Inputs)
        {
           return _irrService.GetIRRForSPInvestor(Inputs).Result[Inputs.SPInvestorId];
        }




        [HttpPost("test-multiyear-spid")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        [OutputCache]
        public Task<IRRResponse> IRRTestURL()
        {


            return _irrService.TestIRR();
        }

        [HttpPost("test-premiumservice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
        [OutputCache]
        public Task<PremiumServiceResponse> PremiumServiceResponse() {
            return _irrService.TestGetDepositPremiums();
        }


    }
}
