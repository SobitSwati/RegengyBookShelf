using System.ComponentModel.DataAnnotations;

namespace RegengyBookShelf_Api.Models.Dtos
{
    public class SeriesDto
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
