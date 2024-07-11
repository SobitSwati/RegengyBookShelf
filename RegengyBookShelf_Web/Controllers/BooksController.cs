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
                    await _httpClient.PostAsync("https://prod-48.eastus.logic.azure.com:443/workflows/570a05c4c8e640db976205a846fccb92/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=ueipxLKWctQrq4pumed4Pa3pujXV2Ve1NzObfYKGohQ", content);
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
                    await _httpClient.PostAsync("https://prod-41.eastus.logic.azure.com:443/workflows/ae9a821e5a424b6a89acb89cfb7f4934/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=EhFOmj34juZ2pMSNehcayZuKevxjAZgr67dPLDwdivw", content);
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
                    await _httpClient.PostAsync("https://prod-65.eastus.logic.azure.com:443/workflows/61d50db0b1cf4c5abaf0a02ffc32cbdc/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=68pLc7_j5mfGE5h3lWZJaamsBvT4kP72b1nWDG8Izcg", content);
                }
            }
			return RedirectToAction(nameof(Index));
		}
	}
}
