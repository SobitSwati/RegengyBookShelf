using Newtonsoft.Json;
using RegengyBookShelf_Utility;
using RegengyBookShelf_Web.Models;
using RegengyBookShelf_Web.Services.IServices;
using System.Text;

namespace RegengyBookShelf_Web.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }

        public BaseService(IHttpClientFactory httpClient)
        {
            this.httpClient = httpClient;
            this.responseModel = new();
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("RegenecyBookshelfApiClient");
                HttpRequestMessage httpRequest = new HttpRequestMessage();
                httpRequest.Headers.Add("Accept", "application/json");
                httpRequest.RequestUri = new Uri(apiRequest.Url);
                if (apiRequest.Data != null)
                {
                    httpRequest.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }
                switch (apiRequest.ApiType)
                {
                    case SD.ApiType.POST:
                        httpRequest.Method = HttpMethod.Post;
                        break;
                    case SD.ApiType.PUT:
                        httpRequest.Method = HttpMethod.Put;
                        break;
                    case SD.ApiType.DELETE:
                        httpRequest.Method = HttpMethod.Delete;
                        break;
                    default:
                        httpRequest.Method = HttpMethod.Get;
                        break;
                }
                HttpResponseMessage apiResponse = null;
                apiResponse = await client.SendAsync(httpRequest);

                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(apiContent);
                return result;
            }
            catch (Exception e)
            {
                var dto = new APIResponse
                {
                    ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var result = JsonConvert.DeserializeObject<T>(res);
                return result;
            }
        }
    }
}
