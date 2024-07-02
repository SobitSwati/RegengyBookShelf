using Microsoft.AspNetCore.Mvc;
using RegengyBookShelf_Api.Models;
using RegengyBookShelf_Api.Repository.IRepository;
using System.Net;

namespace RegengyBookShelf_Api.Controllers
{
    [Route("api/BooksApi")]
    [ApiController]
    public class BooksApiController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IBooksRepository _booksRepository;

        public BooksApiController(IBooksRepository booksRepository)
        {
            this._response = new();
            _booksRepository = booksRepository;
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetAllBooks()
        {
            IEnumerable<Books> books = await _booksRepository.GetAllAsync();
            _response.Result = books;
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        } 
    }
}
