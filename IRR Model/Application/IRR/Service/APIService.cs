using System.Text.Json;
using System.Net.Http.Headers;



namespace CashflowModelling.Application.IRR.Service
{
    public class APIService<TDataType, TResponseType>(string ApiURL, TDataType Datatype)
    {

        private readonly string _apiURL = ApiURL;

        private readonly TDataType _dataType = Datatype;


        public TResponseType GetAPIResponse()
        {

            var SerializedObject = JsonSerializer.Serialize(this._dataType);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(this._apiURL);

            client.DefaultRequestHeaders.Accept.Add(

                new MediaTypeWithQualityHeaderValue("application/json")
                );


            HttpResponseMessage response = client.PostAsync(_apiURL,  new StringContent(SerializedObject)).Result;


            if (response.IsSuccessStatusCode) {

                return JsonSerializer.DeserializeAsync<TResponseType>(response.Content.ReadAsStream()).Result! ;

            }
            else
            {
                throw new Exception("Error: Didn't get a response from the service");

            }


        }




    }
}
