using IRR.Application.Interface;
using IRR.Domain.DTOs;

using Microsoft.Data.Analysis;
using Newtonsoft.Json;



namespace IRR.Application.Service
{
    public class TestDataRead: IDataTest
    {


        public TResponseType ReadFileToObject<TResponseType>(string filePath, Type[] datatypes)
        {

            try
            {

                var dataframe = DataFrame.LoadCsv(filePath, ',', true, dataTypes: datatypes);

                var dfData =
                        dataframe.Rows
                        .Select(row => {
                            var columnNames = dataframe.Columns.Select(col => col.Name);
                            return columnNames.Zip(row).ToDictionary(kv => kv.Item1, kv => kv.Item2);
                                 });

                var json = JsonConvert.SerializeObject(dfData, Formatting.Indented);


                return JsonConvert.DeserializeObject<TResponseType>(json);

            }
            catch (IOException ex)
            {

                throw new Exception(ex.Message);

            }



        }




    }
}
