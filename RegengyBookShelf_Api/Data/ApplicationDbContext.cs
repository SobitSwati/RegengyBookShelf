using Microsoft.EntityFrameworkCore;
using RegengyBookShelf_Api.Models;

namespace RegengyBookShelf_Api.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }

        public DbSet<Series> Series { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Series>().HasData(
                new Series
                {
                    Id = 1,
                    Name = "The Rules of Scoundrels",
                    CreatedDate = DateTime.Now,
                },
                new Series
                {
                    Id = 2,
                    Name = "Bridgerton",
                    CreatedDate = DateTime.Now,
                });
        }
    }
}
