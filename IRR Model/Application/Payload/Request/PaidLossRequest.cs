namespace IRR.Application.Payload.Request
{
    public record PaidLossRequest(
        int LayerId, 
        double LossAmount, 
        DateTime OccurrenceDate
        
        )
    {


    }
}
