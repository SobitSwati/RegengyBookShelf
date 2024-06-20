using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RegengyBookShelf_Web.Models;
using RegengyBookShelf_Web.Models.Dtos;
using RegengyBookShelf_Web.Services.IServices;

namespace RegengyBookShelf_Web.Controllers
{
    public class SeriesController : Controller
    {
        private readonly ISeriesService _seriesService;

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
            if (ModelState.IsValid)
            {
                var response = await _seriesService.AddAsync<APIResponse>(seriesDto);
                if (response != null) {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }
    }
}
