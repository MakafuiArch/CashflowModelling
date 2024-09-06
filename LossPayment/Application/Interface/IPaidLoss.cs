using LossPayment.Application.Payload.Response;




namespace LossPayment.Application.Interface
{
    public interface IPaidLoss
    {

        IEnumerable<PaidLossResponse> GetPaidLossesByLayerId(int LayerId, double LayerAmount, DateTime OccurrenceDate);

        IEnumerable<PaidLossResponse> GetPaidLossesByMasterKey(int MasterKey, double LayerAmount, DateTime OccurrenceDate);
    }
}
