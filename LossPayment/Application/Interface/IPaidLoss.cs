using LossPayment.Application.Payload.Response;




namespace LossPayment.Application.Interface
{
    public interface IPaidLoss
    {

        IEnumerable<PaidLossResponse> GetPaidLosses(int LayerId, double LayerAmount, DateTime OccurrenceDate);
    }
}
