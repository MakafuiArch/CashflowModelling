global using DateTuple = (System.DateTime StartDate, System.DateTime EndDate);
global using LossPremTuple = (System.DateTime StartDate, double LossPremValue);
using IRR.Application.Payload;
using IRR.Domain.DTOs;
using Microsoft.Spark.Sql;


namespace IRR.Application.Interface
{
    
    
    public interface IIRR
    {
        Task<IEnumerable<IRRPremiumInputDTO>> GetIRRPremiumInput(IEnumerable<int>? ids);
        Task<Dictionary<int, Tuple<DataFrame, double>>> GetIRRForSPInvestor(IRRInputs input);

        Task<double> TestIRR();
    }
}
