using Microsoft.AspNetCore.Mvc;
using CashflowModelling.Domain.IRR.DTOs;
using CashflowModelling.Application.IRR.Interface;

namespace IRR_Model.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IRRController(IIRR irrService) : ControllerBase
    {
      
        private readonly IIRR _irrService = irrService;

        [HttpPost(Name = "GetIRRPremium")]
        public IEnumerable<IRRPremiumInputDTO> Get([FromBody] List<int> ids)
        {
            IEnumerable<IRRPremiumInputDTO> PremiumInputs =  _irrService.GetIRRPremiumInput(ids).GetAwaiter().GetResult();
            return PremiumInputs;
        }

    }
}
