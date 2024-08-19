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

        [HttpPost("GetPremiums")]
        public IEnumerable<IRRPremiumInputDTO> GetPremium([FromBody] List<int> ids)
        {
            IEnumerable<IRRPremiumInputDTO> PremiumInputs =  _irrService.GetIRRPremiumInput(ids).GetAwaiter().GetResult();
            return PremiumInputs;
        }


        [HttpPost("GetCashFlows")]
        public DataFrame GetCashFlows([FromBody] List<int> ids)
        {



           throw new NotImplementedException();
        }

    }
}
