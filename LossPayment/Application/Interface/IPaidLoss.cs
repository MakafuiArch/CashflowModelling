using LossPayment.Application.Payload.Response;




namespace LossPayment.Application.Interface
{
    public interface IPaidLoss
    {

        Task<IEnumerable<PaidLossResponse>> GetPaidLossesByLayerId(int LayerId, double LayerAmount, DateTime OccurrenceDate, int MultiYearPeriod);

        IEnumerable<PaidLossResponse> GetPaidLossesByMasterKey(int MasterKey, double LayerAmount, DateTime OccurrenceDate);
    }
}
