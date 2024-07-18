using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegengyBookShelf_Api.Models;
using RegengyBookShelf_Api.Models.Dtos;
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
        private readonly IMapper _mapper;

        public BooksApiController(IBooksRepository booksRepository, IMapper mapper)
        {
            this._response = new();
            _booksRepository = booksRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetAllBooks()
        {
            try
            {
                IEnumerable<Books> books = await _booksRepository.GetAllAsync(includeProperties: "Series");
                _response.Result = books;
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
            }
            catch (Exception)
            {
                _response.ErrorMessages = new List<string> { "Error getting books list"};
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
            }
           
            return Ok(_response);
        }

        [HttpGet("bookId")]

        public async Task<ActionResult<APIResponse>> GetBook(int bookId)
        {
            if (bookId == 0)
            {
                return BadRequest();
            }
            try
            {
                var book = await _booksRepository.GetAsync(u => u.Id == bookId, includeProperties: "Series");

                if (book == null)
                {
                    _response.ErrorMessages = new List<string> { "Book Not Found."};
                    _response.StatusCode = HttpStatusCode.NotFound;
                    _response.IsSuccess = false;
                    return NotFound(_response);
                }
                else
                {
                    _response.Result = book;
                    _response.StatusCode = HttpStatusCode.OK;
                    _response.IsSuccess = true;
                }
            }
            catch (Exception)
            {
                _response.ErrorMessages = new List<string> { "Error getting book details" };
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
            }

			return Ok(_response);
        }

        [HttpPut("bookId")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> UpdateBook(int bookId, [FromBody] BooksDto bookDto)
        {
            try
            {
                if (bookDto == null)
                {
                    return BadRequest();
                }

                Books book = _mapper.Map<Books>(bookDto);
                await _booksRepository.UpdateAsync(book);
                _response.StatusCode = HttpStatusCode.NoContent;
                _response.IsSuccess = true;

            }
            catch (Exception ex)
            {
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.IsSuccess = false;
            }

            return Ok(_response);
        }
    }
}
