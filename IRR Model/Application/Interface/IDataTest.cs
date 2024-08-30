namespace IRR.Application.Interface
{
    public interface IDataTest
    {

        TResponseType  ReadFileToObject<TResponseType>(string filePath, Type[] datatypes);


    }
}
