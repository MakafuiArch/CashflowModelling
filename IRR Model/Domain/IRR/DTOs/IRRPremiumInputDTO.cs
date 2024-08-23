using IRR.Domain.IRR.ModelMappers;

namespace IRR.Domain.IRR.DTOs
{

    [Serializable]
    public class IRRPremiumInputDTO
    {

        [Model(ColumnName = "SPInvestor")]
        public int SPInvestor { get; set; }

        [Model(ColumnName ="RetroProfileId")]
        public int RetroProfileId { get; set; }

        [Model(ColumnName = "RetroProgramId")]
        public int RetroProgramId { get; set; }

        [Model(ColumnName = "LayerInception")]
        public String LayerInception { get; set; }

        [Model(ColumnName = "TotalSubjectPremium")]
        public Decimal TotalSubjectPremium { get; set; }

        

        public IRRPremiumInputDTO ShallowCopy()
        {
            return (IRRPremiumInputDTO)MemberwiseClone();
        }

        

        public IRRPremiumInputDTO(
            int SPInvestor,
            int RetroProfileId, 
            int RetroProgramId, 
            String LayerInception, 
            Decimal TotalSubjectPremium){

            this.RetroProfileId = RetroProfileId;
            this.SPInvestor = SPInvestor;
            this.RetroProgramId = RetroProgramId;
            this.LayerInception = LayerInception;
            this.TotalSubjectPremium = TotalSubjectPremium;
           
        }


    }
}
