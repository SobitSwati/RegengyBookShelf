using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RegengyBookShelf_Web.Models;
using RegengyBookShelf_Web.Models.Dtos;
using RegengyBookShelf_Web.Services.IServices;
using System.Net.Http;
using System.Text;

namespace RegengyBookShelf_Web.Controllers
{
    public class SeriesController : Controller
    {
        private readonly ISeriesService _seriesService;
		private static HttpClient _httpClient = new HttpClient();

		public SeriesController(ISeriesService seriesService)
        {
            _seriesService = seriesService;
        }

        public async Task<IActionResult> Index()
        {
            List<SeriesDto> seriesList = new();
            var response = await _seriesService.GetAllAsync<APIResponse>();
            if (response != null)
            {
                seriesList = JsonConvert.DeserializeObject<List<SeriesDto>>(Convert.ToString(response.Result));
            }
            return View(seriesList);
        }

        public async Task<IActionResult> AddSeries()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSeries(SeriesDto seriesDto)
        {
			if (seriesDto != null)
			{
				using (var content = new StringContent(JsonConvert.SerializeObject(seriesDto), Encoding.UTF8, "application/json"))
				{
					await _httpClient.PostAsync("https://prod-01.eastus.logic.azure.com:443/workflows/cbe78857e02242b195dadd6adf76bd21/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=aIprXsPefyAl_u9P9qIbB_6K6WR7liKRlCe5Qg-23jE", content);
				}
			}
			return RedirectToAction(nameof(Index));
		}

        public async Task<IActionResult> Details(int seriesId)
        {
            if (seriesId == 0)
            {
                return BadRequest();
            }

            var response = await _seriesService.GetAsync<APIResponse>(seriesId);
            if (response != null)
            {
                SeriesDto series = JsonConvert.DeserializeObject<SeriesDto>(response.Result.ToString());
                return View(series);
            }
           return NotFound();
        }

        public async Task<IActionResult> UpdateSeries(int seriesId)
        {
            if (seriesId == 0)
            {
                return BadRequest();
            }

            var response = await _seriesService.GetAsync<APIResponse>(seriesId);
            if (response != null)
            {
                SeriesDto series = JsonConvert.DeserializeObject<SeriesDto>(response.Result.ToString());
                return View(series);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSeries(SeriesDto seriesDto)
        {
            if (seriesDto != null)
            {
                var response = await _seriesService.UpdateAsync<APIResponse>(seriesDto);
                if (response != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return RedirectToAction(nameof(UpdateSeries));
        }

        public async Task<IActionResult> DeleteSeries(int seriesId)
        {
            if (seriesId == 0)
            {
                return BadRequest();
            }

            var response = await _seriesService.GetAsync<APIResponse>(seriesId);
            if (response != null)
            {
                SeriesDto series = JsonConvert.DeserializeObject<SeriesDto>(response.Result.ToString());
                return View(series);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteSeries(SeriesDto seriesDto)
        {
            var response = await _seriesService.DeleteAsync<APIResponse>(seriesDto.Id);
            if (response != null) {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(DeleteSeries));
        }

    }
}
