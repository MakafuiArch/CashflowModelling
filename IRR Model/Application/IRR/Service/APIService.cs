using System.Text.Json;
using System.Net.Http.Headers;



namespace IRR.Application.IRR.Service
{
    public class APIService<TDataType, TResponseType>(string ApiURL, TDataType Datatype) 
        where TDataType : class, IConvertible where TResponseType : class, IConvertible
    {

        private readonly string _apiURL = ApiURL;

        private readonly TDataType _dataType = Datatype;


        public async Task<TResponseType> GetAPIResponse()
        {

            var SerializedObject = JsonSerializer.Serialize(this._dataType);

            HttpClient client = new()
            {
                BaseAddress = new Uri(this._apiURL)
            };

            client.DefaultRequestHeaders.Accept.Add(

                new MediaTypeWithQualityHeaderValue("application/json")
                );


            HttpResponseMessage response = client.PostAsync(_apiURL,  new StringContent(SerializedObject)).Result;


            if (response.IsSuccessStatusCode) {

                return (await JsonSerializer.DeserializeAsync<TResponseType>(response.Content.ReadAsStream()).AsTask().ConfigureAwait(false))!;

            }
            else
            {
                throw new Exception("Error: Didn't get a response from the service");

            }


        }




    }
}
