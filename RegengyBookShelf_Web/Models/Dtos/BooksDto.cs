﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace RegengyBookShelf_Web.Models.Dtos
{
    public class BooksDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }

        public SeriesDto Series { get; set; }
    }
}
