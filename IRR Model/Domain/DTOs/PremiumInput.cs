namespace IRR.Domain.DTOs
{
    public record PremiumInput(
        
        int LayerId,
        DateTime LayerInception,
        double TotalSubjectPremium
        
        )
    {
    }
}
