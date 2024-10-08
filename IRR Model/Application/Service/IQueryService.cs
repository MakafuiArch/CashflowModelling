﻿using Dapper;
using Microsoft.Data.SqlClient;
using IRR.Application.Interface;
using Microsoft.Extensions.Caching.Memory;



namespace IRR.Application.Service
{
    public class IQueryService(IConfiguration configuration, IMemoryCache memoryCache) : IQuery
    {

        private readonly IConfiguration _configuration = configuration;

        private readonly IMemoryCache _memoryCache = memoryCache;

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

                select SPInvestor, RetroProfileId, 
                     RetroProgramId, Format(LayerInception, 'dd/MM/yyyy')
                     As LayerInception , 
                     TotalSubjectPremium from irr_premium_inputs 
            ";



        public FormattableString FloatRecursionQuery(float AccumulationFactor) => $@"
                
                select 

                    *, 

                    Coalesce(lag([Ending Float]) over (order by [Row Number]), 0) As [Starting Float], 
                    greatest(Coalesce([Starting Float], 0) + 0.5*[Float Change] , 0) As [Average Investment Float],

                    Coalesce([Average Investment Float], 0)*{AccumulationFactor} As [Investment Income On Float], 

                    Coalesce([Float Change] + [Starting Float] + [Investment Income On Float], 0) As [Ending Float]

                from IRRTable
             
               ";



        private readonly FormattableString _premiumScheduleQuery = $@"";

        private readonly FormattableString _paidLossQuery = $@"";

        private readonly FormattableString _capitalQuery = $@"";

        private readonly FormattableString _bufferScheduleQuery = $"";


        public FormattableString CapitalRecursionQuery(float AccumulationFactor) => $@"


            with recursive_cte as (
                 
                select top 1 * 

                    [Capital Contribution] + cast(Case when [Incremental Cashflow] < 0 
                            then [Incremental Cashflow] else 0 end as float) As [Starting Capital],

                    ([Capital Contribution] + cast(Case when [Incremental Cashflow] < 0 
                            then [Incremental Cashflow] 
                            else 0 end as float) As [Starting Capital]) * {AccumulationFactor} As [Investment Income Capital],

                    [Capital Contribution] + cast(Case when [Incremental Cashflow] < 0 
                            then [Incremental Cashflow] else 0 end as float) As [Starting Capital] + 
                    ([Capital Contribution] + cast(Case when [Incremental Cashflow] < 0 
                            then [Incremental Cashflow] 
                            else 0 end as float) As [Starting Capital]) * {AccumulationFactor}  As [Ending Capital],
                
                from IRRTable 

                union all

                select 
                    
                    irrtable.*, 

                    recurs.[Ending Capital] + irrtable.[Capital Contribution] + cast(Case when 
                            irrtable.[Incremental Cashflow] < 0 
                            then irrtable.[Incremental Cashflow] else 0 end as float) As [Starting Capital]

                     (irrtable.[Capital Contribution] + recurs.[Ending Capital] + 
                            irrtable.[Capital Contribution] + cast(Case when 
                            irrtable.[Incremental Cashflow] < 0 
                            then irrtable.[Incremental Cashflow] else 0 end as float)*{AccumulationFactor}  
                            As [Investment Income Capital],

                    recurs.[Ending Capital] + irrtable.[Capital Contribution] + cast(Case when 
                            irrtable.[Incremental Cashflow] < 0 
                            then irrtable.[Incremental Cashflow] else 0 end as float) + 
                      
                      (irrtable.[Capital Contribution] + recurs.[Ending Capital] + 
                            irrtable.[Capital Contribution] + cast(Case when 
                            irrtable.[Incremental Cashflow] < 0 
                            then irrtable.[Incremental Cashflow] else 0 end as float)*{AccumulationFactor}   


                    As [Ending Capital]


                from IRRtable irrtable 
                
                inner join recursive_cte recurs

                on  irrtable.[Row Number] = recursive_cte.[Row Number] + 1

             )
             select * from recursive_cte;
             option(maxrecursion 0)

           ";


        



        public FormattableString GetIRRPremiumString() => _IRRPremiumQuery;

        public FormattableString GetPremiumScheduleQuery() => _premiumScheduleQuery;

        public FormattableString GetPaidLossQuery() => _paidLossQuery;


        public FormattableString GetBufferQuery() => _bufferScheduleQuery;


        public async Task<IEnumerable<T>> QuerySet<T>(FormattableString query)
        {

            var con = new SqlConnection(_configuration.GetValue<string>("ConnectionString:Revoreader"));

            return await con.QueryAsync<T>(query.ToString());
            
        }


        public async Task<TResponseType> ApiResponseSet<TDataType, TResponseType>(String apiURL, TDataType datatype)
        {

            var Apiservice = new APIService<TDataType, TResponseType>(apiURL, datatype);

            return await Apiservice.GetAPIResponse();
        }

        public FormattableString GetCapitalScheduleQuery() => _capitalQuery;
    }
}
