namespace IRR.Domain.DTOs
{
    public record PremiumValue(
        
        int LayerId,
        int SubmissionId,
        int Day,
        DateTime Date, 
        int PremiumView,
        double Ratio, 
        double Value
        
        )
    {
    }
}
