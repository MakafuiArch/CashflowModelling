namespace CashflowModelling.Domain.IRR.ModelMappers
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    [Serializable]
    public class ModelAttribute: Attribute
    {
        public string ColumnName { get; set; }

    }
}
