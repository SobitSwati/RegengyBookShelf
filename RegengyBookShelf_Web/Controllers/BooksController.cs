using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RegengyBookShelf_Web.Models;
using RegengyBookShelf_Web.Models.Dtos;
using RegengyBookShelf_Web.Services.IServices;

namespace RegengyBookShelf_Web.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksService _booksService;

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
    }
}
