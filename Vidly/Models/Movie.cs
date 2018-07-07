using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAddedToDatabase { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }

        [Required]
        [Display(Name = "Number in stock")]
        [Range(minimum: 1, maximum: 20, ErrorMessage = "Number in stock should be between 1 and 20")]
        public int NumberInStock { get; set; }
    }
}