﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegengyBookShelf_Api.Models.Dtos
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
		[Required]
		public int SeriesId { get; set; }

		public Series Series { get; set; }
	}
}
