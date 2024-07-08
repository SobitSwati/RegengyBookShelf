using System.Linq.Expressions;

namespace RegengyBookShelf_Api.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(Expression<Func<T,bool>> filter);
    }
}
