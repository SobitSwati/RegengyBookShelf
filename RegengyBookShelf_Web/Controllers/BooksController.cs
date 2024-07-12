using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RegengyBookShelf_Web.Models;
using RegengyBookShelf_Web.Models.Dtos;
using RegengyBookShelf_Web.Services.IServices;
using System.Text;

namespace RegengyBookShelf_Web.Controllers
{
	public class BooksController : Controller
    {
        private readonly IBooksService _booksService;
        private static HttpClient _httpClient = new HttpClient();

        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        public async Task<IActionResult> Index()
        {
            List<BooksDto> booksList = new();
            var response = await _booksService.GetAllAsync<APIResponse>();
            if (response != null)
            {
                booksList = JsonConvert.DeserializeObject<List<BooksDto>>(Convert.ToString(response.Result));
            }

            return View(booksList);
        }

        public async Task<IActionResult> AddBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BooksDto book) {
            if (book != null) {
                using (var content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json"))
                {
                    await _httpClient.PostAsync("https://prod-63.eastus.logic.azure.com:443/workflows/22d4df8ae0a046f298a2115b2b902b9c/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=8OVLf3NxUv0czs-CzdTUkS1-4-3Xu9L3ltiLepFwa9w", content);
                }
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int bookId)
        {
			BooksDto book = new();
			if (bookId != 0)
            {
                var response= await _booksService.GetAsync<APIResponse>(bookId);
                if (response != null)
                {
					book = JsonConvert.DeserializeObject<BooksDto>(Convert.ToString(response.Result));
				}
            }
            return View(book);
        }

        public async Task<IActionResult> UpdateBook(int bookId)
        {
            if (bookId == 0)
            {
                return BadRequest();
            }
			BooksDto book = new();
			var response = await _booksService.GetAsync<APIResponse>(bookId);
            if (response != null) {
				book = JsonConvert.DeserializeObject<BooksDto>(Convert.ToString(response.Result));
			}

			return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBook(BooksDto booksDto)
        {
            if (booksDto != null)
            {
                using (var content = new StringContent(JsonConvert.SerializeObject(booksDto), Encoding.UTF8, "application/json"))
                {
                    await _httpClient.PostAsync("https://prod-60.eastus.logic.azure.com:443/workflows/eefbdb5afd6847c4a98079e3b7176ab4/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=Jl4n5v6JHdvxDvzZq88Lqa_ZGBYIRY42PFzrju_b-Lc", content);
                }
            }
            return RedirectToAction(nameof(Index));
		}

        public async Task<IActionResult> DeleteBook(int bookId)
        {
			if (bookId == 0)
			{
				return BadRequest();
			}
			BooksDto book = new();
			var response = await _booksService.GetAsync<APIResponse>(bookId);
			if (response != null)
			{
				book = JsonConvert.DeserializeObject<BooksDto>(Convert.ToString(response.Result));
			}

			return View(book);
		}

        [HttpPost]
        public async Task<IActionResult> DeleteBook(BooksDto booksDto)
        {
            if (booksDto != null)
            {
                using (var content = new StringContent(JsonConvert.SerializeObject(booksDto), Encoding.UTF8, "application/json"))
                {
                    await _httpClient.PostAsync("https://prod-22.eastus.logic.azure.com:443/workflows/a0519efefe334ee4852404d6fc5b1315/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=Fdqwwam1SNifFFlX1JD_1F-1tt5G1TPgSyj7TkdEv94", content);
                }
            }
			return RedirectToAction(nameof(Index));
		}
	}
}
