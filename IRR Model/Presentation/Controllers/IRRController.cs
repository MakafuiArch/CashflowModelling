using Microsoft.AspNetCore.Mvc;
using IRR.Domain.DTOs;
using IRR.Application.Interface;
using IRR.Application.Payload;
using Microsoft.Data.SqlClient;



namespace IRR.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IRRController(IIRR irrService, IDataTest testData) : ControllerBase
    {

        private readonly IIRR _irrService = irrService;
        private readonly IDataTest _testData = testData;


 
        [HttpPost("getpremiums")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesErrorResponseType(typeof(SqlException))]
        [ResponseCache(VaryByHeader ="User-Agent", Duration=30)]
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
        public Task<IRRResponse> IRRTestURL()
        {


            return _irrService.TestIRR();
        }



    }
}
