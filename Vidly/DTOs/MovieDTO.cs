using System;
using System.ComponentModel.DataAnnotations;

namespace Vidly.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAddedToDatabase { get; set; }

        [Required]
        public int GenreId { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 20, ErrorMessage = "Number in stock should be between 1 and 20")]
        public int NumberInStock { get; set; }
    }
}