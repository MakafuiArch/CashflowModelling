namespace CashflowModelling.Application.IRR.Interface
{
    public interface IQuery
    {

        Task<IEnumerable<T>> QuerySet<T>(FormattableString query);
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
