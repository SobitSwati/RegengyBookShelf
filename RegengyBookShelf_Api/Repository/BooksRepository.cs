using RegengyBookShelf_Api.Data;
using RegengyBookShelf_Api.Models;
using RegengyBookShelf_Api.Repository.IRepository;

namespace RegengyBookShelf_Api.Repository
{
    public class BooksRepository: Repository<Books>, IBooksRepository
    {
        private readonly ApplicationDbContext _db;

        public BooksRepository(ApplicationDbContext db): base (db)
        {
            _db = db;
        }
    }
}
