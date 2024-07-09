using RegengyBookShelf_Web.Models;
using RegengyBookShelf_Web.Models.Dtos;
using RegengyBookShelf_Web.Services.IServices;
using static RegengyBookShelf_Utility.SD.ApiType;

namespace RegengyBookShelf_Web.Services
{
	public class SeriesService : BaseService, ISeriesService
    {
        private readonly IHttpClientFactory _httpClient;
        private string seriesUrl;

        public SeriesService(IHttpClientFactory httpClient, IConfiguration configuration) : base(httpClient)
        {
            _httpClient = httpClient;
            seriesUrl = configuration.GetValue<string>("ServiceUrls:SeriesApi");
        }

        public Task<T> AddAsync<T>(SeriesDto Dto)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = POST,
                Url = seriesUrl + "api/SeriesApi",
                Data = Dto
            });
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = GET,
                Url = seriesUrl + "api/SeriesApi"
            });
        }

        public Task<T> GetAsync<T>(int seriesId)
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = GET,
                Url = seriesUrl + "api/SeriesApi/seriesId?seriesId=" + seriesId
            });
        }
    }
}
