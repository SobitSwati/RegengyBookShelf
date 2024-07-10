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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        [HttpPut("seriesId")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> UpdateSeries(int seriesId, [FromBody] SeriesDto seriesDto)
        {
            try
            {
                if (seriesDto == null)
                {
                    return BadRequest();
                }

                Series series = _mapper.Map<Series>(seriesDto); 

                await _seriesRepository.UpdateAsync(series);
                _response.IsSuccess = true;
                _response.StatusCode= HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.StatusCode = HttpStatusCode.InternalServerError;
                _response.ErrorMessages
                  = new List<string>() { ex.ToString() };
            }
            return (_response);
          
        }

        [HttpDelete("seriesId")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<ActionResult<APIResponse>> DeleteSeries(int seriesId)
        {
            if (seriesId == 0)
            {
                return BadRequest();
            }

            var seriesToDelete = await _seriesRepository.GetAsync(u=> u.Id == seriesId);
            if (seriesToDelete == null)
            {
                return NotFound();
            }

            Series series = _mapper.Map<Series>(seriesToDelete);
            await _seriesRepository.DeleteAsync(series);
            _response.IsSuccess = true;
            _response.StatusCode = HttpStatusCode.NoContent;
            return (_response);
        }
    }
}
