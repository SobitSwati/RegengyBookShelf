using RegengyBookShelf_Api.Models;

namespace RegengyBookShelf_Api.Repository.IRepository
{
    public interface ISeriesRepository : IRepository<Series>
    {
        Task AddAsync(Series series);
        Task<Series> UpdateAsync(Series series);
        Task DeleteAsync(Series series);
    }
}
