using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RegengyBookShelf_Api.Models;
using RegengyBookShelf_Api.Models.Dtos;
using RegengyBookShelf_Api.Repository.IRepository;
using System.Net;

namespace RegengyBookShelf_Api.Controllers
{
    [Route("api/SeriesApi")]
    [ApiController]
    public class SeriesApiController : ControllerBase
    {
        protected APIResponse _response;        
        private readonly ISeriesRepository _seriesRepository;
        private readonly IMapper _mapper;
        
        public SeriesApiController(IMapper mapper, ISeriesRepository seriesRepository)
        {
           
            this._response = new();
            _mapper = mapper;         
            _seriesRepository = seriesRepository;
        }
        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetAllSeries()
        {
            IEnumerable<Series> seriesDtos = await _seriesRepository.GetAllAsync();
            _response.Result = _mapper.Map<List<SeriesDto>>(seriesDtos);
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response) ;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<APIResponse>> AddSeries([FromBody]SeriesDto seriesDto)
        {
            if (seriesDto == null)
            {
                return BadRequest();
            }
            Series seriesToAdd = _mapper.Map<Series>(seriesDto);

            _response.Result = _seriesRepository.AddAsync(seriesToAdd);
            _response.StatusCode = HttpStatusCode.Created;
            _response.IsSuccess = true;
          
            return Ok(_response);
        }

        [HttpGet("seriesId")]
        public async Task<ActionResult<APIResponse>> GetSeries(int seriesId)
        {
            if (seriesId == 0)
            {
                return BadRequest();
            }

            Series series = await _seriesRepository.GetAsync(u => u.Id == seriesId);

            if (series == null)
            {
                return NotFound();
            }

            _response.Result = series;
            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            return Ok(_response);
        }
    }
}
