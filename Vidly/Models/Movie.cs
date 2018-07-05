using System;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberInStock { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime DateAddedToDatabase { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
    }
}