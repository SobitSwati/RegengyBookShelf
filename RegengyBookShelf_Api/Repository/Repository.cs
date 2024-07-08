using Microsoft.EntityFrameworkCore;
using RegengyBookShelf_Api.Data;
using RegengyBookShelf_Api.Repository.IRepository;
using System.Linq.Expressions;

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

		public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
		{
			IQueryable<T> query = dbSet;
			if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.FirstOrDefaultAsync();
		}
	}
}
