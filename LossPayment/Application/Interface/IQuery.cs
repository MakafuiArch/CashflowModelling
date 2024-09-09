namespace LossPayment.Application.Interface
{


    public interface IQuery
    {

        Task<IEnumerable<T>> QuerySet<T>(string query);

        Task<TResponseType> ApiResponseSet<TDataType, TResponseType>(String apiURL, TDataType datatype);

        string GetLossPaymentPatternQuery(int id);

    }
}
