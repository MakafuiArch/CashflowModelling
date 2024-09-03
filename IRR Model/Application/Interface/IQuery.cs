namespace IRR.Application.Interface
{
    public interface IQuery
    {

        Task<IEnumerable<T>> QuerySet<T>(FormattableString query);

        Task<TResponseType> ApiResponseSet<TDataType, TResponseType>(String apiURL, TDataType datatype);

        FormattableString GetIRRPremiumString();
        FormattableString GetIRRLossScheduleQuery(double ClimateLoading);

        FormattableString GetPremiumScheduleQuery();

        FormattableString GetPaidLossQuery();

        FormattableString GetCapitalScheduleQuery();

        FormattableString CapitalRecursionQuery(float AccumulationFactor);

        FormattableString FloatRecursionQuery(float AccumulationFactor);

        FormattableString GetBufferQuery();


    }
}
