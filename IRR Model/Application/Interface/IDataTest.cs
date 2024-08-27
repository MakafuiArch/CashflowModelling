namespace IRR.Application.Interface
{
    public interface IDataTest
    {

        IEnumerable<TResponseType>  ReadFileToObject<TResponseType>(string filePath, Type[] datatypes);


    }
}
