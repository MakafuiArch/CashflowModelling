namespace IRR_Model.Application.IRR.Service
{
    public static class Extension
    {
        private static Func<T, TResult> Compose<T, TResultant, TResult>(this Func<TResultant,
          TResult> func1, Func<T, TResultant> func2)
        {
            return x => func1(func2(x));
        }
    }
}
