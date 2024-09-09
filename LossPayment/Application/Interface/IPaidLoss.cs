using LossPayment.Application.Payload.Request;
using LossPayment.Application.Payload.Response;




namespace LossPayment.Application.Interface
{
    public interface IPaidLoss
    {

        Task<IEnumerable<PaidLossResponse>> GetPaidLossesByLayerId(int LayerId, double LayerAmount, DateTime OccurrenceDate, int MultiYearPeriod);

        Task<IEnumerable<PaidLossResponse>> GetPaidLossesByLayerIds(IEnumerable<PaidLossRequest> request);

        IEnumerable<PaidLossResponse> GetPaidLossesByMasterKey(int MasterKey, double LayerAmount, DateTime OccurrenceDate);
    }
}
