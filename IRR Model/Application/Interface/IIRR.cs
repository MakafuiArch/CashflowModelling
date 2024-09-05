global using DateTuple = (System.DateTime StartDate, System.DateTime EndDate);
global using LossPremTuple = (System.DateTime StartDate, double LossPremValue);
using IRR.Application.Payload.Request;
using IRR.Application.Payload.Response;
using IRR.Domain.DTOs;
using Microsoft.Identity.Client;


namespace IRR.Application.Interface
{


    public interface IIRR
    {
        Task<IEnumerable<IRRPremiumInputDTO>> GetIRRPremiumInput(IEnumerable<int>? ids);
        Task<Dictionary<int, double>> GetIRRForSPInvestor(IRRInputs input);

        Task<IRRResponse> TestIRR();

        //subject to change on antonio finishing the economic model
        Task<IEnumerable<LossInput>> GetLossInput(int SPInvestor, List<int> RetroProgramIds);


        Task<PremiumServiceResponse> TestGetDepositPremiums();
    }
}
