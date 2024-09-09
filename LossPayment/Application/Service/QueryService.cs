using LossPayment.Application.Interface;
using Dapper;
using System.Data.SqlClient;



namespace LossPayment.Application.Service
{
    public class QueryService: IQuery
    {

        private readonly IConfiguration _configuration;


        private const string LOSS_PAYMENT_PATTERN_QUERY = @"

            Select month, percentage from LossPattern lossP
            where lossP.layerId = {0}
        ";


        public QueryService(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<IEnumerable<T>> QuerySet<T>(string query)
        {

            var con = new SqlConnection(_configuration.GetValue<string>("ConnectionString:Revoreader"));

            return await con.QueryAsync<T>(query);

        }


        public string GetLossPaymentPatternQuery(int id)
        {
            return string.Format(LOSS_PAYMENT_PATTERN_QUERY, id.ToString());
        }


        public async Task<TResponseType> ApiResponseSet<TDataType, TResponseType>(String apiURL, TDataType datatype)
        {

            var Apiservice = new APIService<TDataType, TResponseType>(apiURL, datatype);

            return await Apiservice.GetAPIResponse();
        }






    }
}
