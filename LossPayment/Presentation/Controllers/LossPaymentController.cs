using LossPayment.Application.Interface;
using LossPayment.Application.Payload.Request;
using LossPayment.Application.Payload.Response;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace LossPayment.Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LossPaymentController : ControllerBase
    {

        private readonly ILogger<LossPaymentController> _logger;
        private readonly IPaidLoss _paidLossInterface;

        public LossPaymentController(ILogger<LossPaymentController> logger, IPaidLoss paidlossInterface)
        {
            _logger = logger;
            _paidLossInterface = paidlossInterface;
        }


        [HttpPost("get-paid-losses")]
        public async Task<IEnumerable<PaidLossResponse>> GetPaidLosses([FromBody] IEnumerable<PaidLossRequest> requests)
        {

            return await _paidLossInterface.GetPaidLossesByLayerIds(requests);


        }






    }
}
