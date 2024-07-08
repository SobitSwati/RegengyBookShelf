using RegengyBookShelf_Web.Models;
using RegengyBookShelf_Web.Services.IServices;
using static RegengyBookShelf_Utility.SD;

namespace RegengyBookShelf_Web.Services
{
    public class BooksService : BaseService, IBooksService
    {
        private readonly IHttpClientFactory _httpClient;
        private string booksUrl;

        public BooksService(IHttpClientFactory httpClient, IConfiguration config) : base(httpClient)
        {
            _httpClient = httpClient;
            booksUrl = config.GetValue<string>("ServiceUrls:SeriesApi");
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest
            {
                ApiType = ApiType.GET,
                Url = booksUrl + "api/BooksApi"
            });
        }

		public Task<T> GetAsync<T>(int bookId)
		{
            return SendAsync<T>(new APIRequest
            {
                ApiType = ApiType.GET,
                Data = bookId,
                Url = booksUrl + "api/BooksApi"
            });
		}
	}
}
