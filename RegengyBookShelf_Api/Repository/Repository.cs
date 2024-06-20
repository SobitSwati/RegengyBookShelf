using Microsoft.EntityFrameworkCore;
using RegengyBookShelf_Api.Data;
using RegengyBookShelf_Api.Repository.IRepository;

namespace RegengyBookShelf_Api.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _db;
        internal DbSet<T> dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            this.dbSet = _db.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            IQueryable<T> query = dbSet;
            return await query.ToListAsync();
        }
    }
}
