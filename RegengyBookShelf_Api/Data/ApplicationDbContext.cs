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
        public DbSet<Books> Books { get; set; }

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

            modelBuilder.Entity<Books>().HasData(
               new Books
               {
                   Id = 1,
                   Author = "Sarah MacLean",
                   Title = "A Rogue by Any Other Name",
                   Description = "A decade ago, the Marquess of Bourne was cast from society with nothing but his title. Now a partner in London’s most exclusive gaming hell, the cold, ruthless Bourne will do whatever it takes to regain his inheritance—including marrying perfect, proper Lady Penelope Marbury.\r\n\r\nA broken engagement and years of disappointing courtships have left Penelope with little interest in a quiet, comfortable marriage, and a longing for something more. How lucky that her new husband has access to such unexplored pleasures.\r\n\r\nBourne may be a prince of London’s underworld, but he vows to keep Penelope untouched by its wickedness—a challenge indeed as the lady discovers her own desires, and her willingness to wager anything for them... even her heart.",
                    ISBN = "9780062068521",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1327928208i/10428803.jpg",
                    SeriesId = 1
               }, new Books
               {
                Id = 2,
                   Author = "Sarah MacLean",
                   Title = "Ten Ways to Be Adored When Landing a Lord",
                   Description = "Since being named on of London’s “Lords to Land” by a popular ladies’ magazine, Nicholas St. John has been relentlessly pursued by every matrimony-minded female in the ton.",
                    ISBN = "9780061852060",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1322231419i/7781699.jpg",
                   SeriesId = 1
               });
        }
    }
}
