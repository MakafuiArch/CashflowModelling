using Dapper;
using Microsoft.Data.SqlClient;
using CashflowModelling.Application.IRR.Interface;



namespace IRR_Model.Application.IRR.Service
{
    public class IQueryService(IConfiguration configuration) : IQuery
    {

        private readonly IConfiguration _configuration = configuration;

        public FormattableString GetIRRLossScheduleQuery(double ClimateLoading) => $@"

            Use Revo;

            GO


            Declare @Climate_loading as float;

            set  @Climate_loading = {ClimateLoading};

            with irr_loss_table(RetroProfileId, SPInsurerId, RetroProgramId,Inception, 
                                    EventStartDate, GrossLoss, ReinstPremium, CummulativePremium, RowN) as (

            select

            retroprogram.RetroProfileId,
            spinvestor.SPInsurerId,
            retroprogram.RetroProgramId,
            layer.Inception,
            experienceloss.EventStartDate,
            experienceloss.ActualIncurredLoss*@Climate_loading As GrossLoss,
            layer.Premium*@Climate_loading As ReinstPremium, 

            sum(layer.Premium*@Climate_loading) over ( 
	            partition by retroprogram.RetroProfileId, spinvestor.SPInsurerId, 
	            retroprogram.RetroProgramId, layer.Inception, experienceloss.EventStartDate,
	            experienceloss.ActualIncurredLoss*@Climate_loading
	            order  by retroprogram.RetroProfileId, spinvestor.SPInsurerId, 
	            retroprogram.RetroProgramId, layer.Inception, experienceloss.EventStartDate,
	            experienceloss.ActualIncurredLoss*@Climate_loading
	            range between unbounded preceding and current row
            ) As CummulativePremium,

            ROW_NUMBER() over ( 
	            partition by retroprogram.RetroProfileId, spinvestor.SPInsurerId, 
	            retroprogram.RetroProgramId, layer.Inception, experienceloss.EventStartDate,
	            experienceloss.ActualIncurredLoss*@Climate_loading
	            order  by retroprogram.RetroProfileId, spinvestor.SPInsurerId, 
	            retroprogram.RetroProgramId, layer.Inception, experienceloss.EventStartDate,
	            experienceloss.ActualIncurredLoss*@Climate_loading
            ) As RowN

            from dbo.ExperienceLoss experienceloss
            inner join dbo.LossEstScenario lossest
            on experienceloss.LossEstScenarioId = lossest.LossEstScenarioId
            inner join dbo.Submission submission
            on lossest.SubmissionId = submission.SubmissionId
            inner join dbo.Layer layer
            on  submission.SubmissionId = layer.SubmissionId
            inner join dbo.RetroAllocation retroallocation
            on retroallocation.LayerId = layer.LayerId
            inner join dbo.RetroInvestor retroinvestor
            on retroallocation.RetroInvestorId = retroinvestor.RetroInvestorId
            inner join dbo.SPInsurer spinvestor 
            on retroinvestor.SPInsurerId = spinvestor.SPInsurerId
            inner join dbo.RetroProgram retroprogram
            on  retroprogram.RetroProgramId =spinvestor.RetroProgramId 

            where retroprogram.RetroProfileId in (1, 5, 10)

            group by retroprogram.RetroProfileId, spinvestor.SPInsurerId, 
		             retroprogram.RetroProgramId, layer.Inception, 
		             experienceloss.EventStartDate, experienceloss.ActualIncurredLoss, 
		             layer.Premium

            )

            select GrossLoss,
	               RetroProfileId, 
	               SPInsurerId, RetroProgramId, 
	               Inception, EventStartDate,
	               last_value(CummulativePremium) over ( partition by RetroProfileId, SPInsurerId, 
														              RetroProgramId, Inception, EventStartDate,
														              GrossLoss

											             order by	  RetroProfileId, SPInsurerId, 
														              RetroProgramId, Inception, EventStartDate,
														              GrossLoss

											             range between unbounded preceding and unbounded following) As TotReinstPremium,

            count(CummulativePremium) over ( partition by RetroProfileId, SPInsurerId, 
														              RetroProgramId, Inception,EventStartDate,
														              GrossLoss

											             order by	  RetroProfileId, SPInsurerId, 
														              RetroProgramId, Inception,EventStartDate,
														              GrossLoss

											             range between unbounded preceding and unbounded following) As TotalCount


            from irr_loss_table
            order by  RetroProfileId, SPInsurerId, RetroProgramId,Inception, EventStartDate, GrossLoss;


        "; 

        private readonly FormattableString _IRRPremiumQuery = $@" 

            with irr_premium_inputs( LayerInception, RetroProgramId, 
                                     TotalSubjectPremium, RetroProfileId,
                                     SPInvestor 
                                    )  
                as (

                        select 

                        distinct(convert(Date, layer.[Inception], 101)) As LayerInception,
                        retroprogram.[RetroProgramId] as RetroProgramId,
                        sum(layer.[Premium]) over (partition by layer.[Inception], 
                                 retroprogram.[RetroProfileId], 
                                 retroprogram.[RetroProgramId],
                                 spinvestor.[SPInsurerId]
				                 order by convert(Date, layer.[Inception], 101)
				                 range between current row and unbounded following 
				                        ) as TotalSubjectPremium, 

                        retroprogram.[RetroProfileId] as RetroProfileId,
                        spinvestor.[SPInsurerId] as SPInvestor
						
                        from [dbo].[Layer] layer

                        inner join [dbo].[RetroAllocation] retroallocation
                        on retroallocation.[LayerId] = layer.[LayerId]
                        inner join [dbo].[RetroInvestor] retroinvestor
                        on retroallocation.[RetroInvestorId] = retroinvestor.[RetroInvestorId]
                        inner join [dbo].[SPInsurer] spinvestor 
                        on retroinvestor.[SPInsurerId] = spinvestor.[SPInsurerId]
                        inner join [dbo].[RetroProgram] retroprogram
                        on  retroprogram.[RetroProgramId] =spinvestor.[RetroProgramId] 

                        group by layer.[Inception], 
		                         retroprogram.[RetroProgramId], 
                                 retroprogram.[RetroProfileId],
		                         layer.[Premium],
                                 spinvestor.[SPInsurerId]

                        )

                select RetroProfileId, SPInvestor,
                     RetroProgramId, Format(LayerInception, 'dd/MM/yyyy')
                     As LayerInception , 
                     TotalSubjectPremium from irr_premium_inputs 
            ";
       

        private readonly FormattableString _premiumScheduleQuery = $@"";

        private readonly FormattableString _paidLossQuery = $@"";



        public FormattableString GetIRRPremiumString() => _IRRPremiumQuery;

        public FormattableString GetPremiumScheduleQuery() => _premiumScheduleQuery;

        public FormattableString GetPaidLossQuery() => _paidLossQuery;


        public async Task<IEnumerable<T>> QuerySet<T>(FormattableString query)
        {

            using var con = new SqlConnection(_configuration.GetValue<string>("ConnectionString:Revoreader"));

            return await con.QueryAsync<T>(query.ToString());


        }


    }
}
