using RegengyBookShelf_Web.Models.Dtos;

namespace RegengyBookShelf_Web.Services.IServices
{
    public interface ISeriesService
    {
        Task<T> GetAllAsync<T>();
        Task<T> GetAsync<T>(int seriesId);
        Task<T> AddAsync<T>(SeriesDto Dto);
        Task<T> UpdateAsync<T>(SeriesDto dto);
        Task<T> DeleteAsync<T>(int seriesId);
    }
}
