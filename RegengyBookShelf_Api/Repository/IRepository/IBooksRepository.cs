using RegengyBookShelf_Api.Models;

namespace RegengyBookShelf_Api.Repository.IRepository
{
    public interface IBooksRepository: IRepository<Books>
    {
        Task<Books> UpdateAsync(Books book);
    }
}
