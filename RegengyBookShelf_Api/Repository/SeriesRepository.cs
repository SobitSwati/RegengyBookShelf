using Newtonsoft.Json;
using RegengyBookShelf_Api.Data;
using RegengyBookShelf_Api.Models;
using RegengyBookShelf_Api.Repository.IRepository;
using System.Text;

namespace RegengyBookShelf_Api.Repository
{

    public class SeriesRepository : Repository<Series>, ISeriesRepository
    {
        private readonly ApplicationDbContext _db;
        private readonly HttpClient httpClient = new HttpClient();

        public SeriesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task AddAsync(Series series)
        {
            using (var content = new StringContent(JsonConvert.SerializeObject(series), Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage responseMessage = await httpClient.PostAsync("https://prod-44.eastus.logic.azure.com:443/workflows/280baa20259a4117aaa03a16eca83799/triggers/manual/paths/invoke?api-version=2016-10-01&sp=%2Ftriggers%2Fmanual%2Frun&sv=1.0&sig=67YFt4uPVUOLZg9BjH7PHnAtYi3MZ3gHbV_WkpZ0V64", content);
            }
            return;
        }

        public async Task<Series> UpdateAsync(Series series)
        {
            _db.Series.Update(series);
            await _db.SaveChangesAsync();
            return series;
        }
    }
}
