using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = new List<Movie>()
            {
                new Movie() {Id = 1, Name = "Deadpool"},
                new Movie() {Id = 2, Name = "Pulp Fiction"},
                new Movie() {Id = 3, Name = "Birdman"}
            };

            return View(movies);
        }

        public ActionResult Details(int id)
        {
            var movies = new List<Movie>()
            {
                new Movie() {Id = 1, Name = "Deadpool"},
                new Movie() {Id = 2, Name = "Pulp Fiction"},
                new Movie() {Id = 3, Name = "Birdman"}
            };

            return View(movies[id - 1]);
        }
    }
}