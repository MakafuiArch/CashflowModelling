using System.Net.Http.Headers;
using System.Text.Json;
using System.Text;

namespace LossPayment.Application.Service
{
    public class APIService<TDataType, TResponseType>(string ApiURL, TDataType Datatype)
    {

        private readonly string _apiURL = ApiURL;

        private readonly TDataType _dataType = Datatype;


        public async Task<TResponseType> GetAPIResponse()
        {





            var SerializedObject = JsonSerializer.Serialize(this._dataType);

            HttpClient client = new()
            {
                BaseAddress = new Uri(_apiURL)
            };

            client.DefaultRequestHeaders.Accept.Add(

                new MediaTypeWithQualityHeaderValue("application/json")
                );


            HttpResponseMessage response = await client.PostAsync(_apiURL,
                new StringContent(SerializedObject, Encoding.UTF8, "application/json"));


            if (response.IsSuccessStatusCode)
            {

                return (await response.Content.ReadFromJsonAsync<TResponseType>())!;

            }
            else
            {
                throw new Exception("Error: Didn't get a response from the service");

            }


        }




    }
}
