using IRR.Domain.ModelMappers;

namespace IRR.Domain.DTOs
{

    [Serializable]
    public class IRRPremiumInputDTO(
        int SPInvestor,
        int RetroProfileId,
        int RetroProgramId,
        String LayerInception,
        double TotalSubjectPremium)
    {

        [Model(ColumnName = "SPInvestor")]
        public int SPInvestor { get; set; } = SPInvestor;

        [Model(ColumnName = "RetroProfileId")]
        public int RetroProfileId { get; set; } = RetroProfileId;

        [Model(ColumnName = "RetroProgramId")]
        public int RetroProgramId { get; set; } = RetroProgramId;

        [Model(ColumnName = "LayerInception")]
        public String LayerInception { get; set; } = LayerInception;

        [Model(ColumnName = "TotalSubjectPremium")]
        public double TotalSubjectPremium { get; set; } = TotalSubjectPremium;



        public IRRPremiumInputDTO ShallowCopy()
        {
            return (IRRPremiumInputDTO)MemberwiseClone();
        }
    }
}
