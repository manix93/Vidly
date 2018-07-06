using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private VidlyDBContext _context;

        public MoviesController()
        {
            _context = new VidlyDBContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }

        public ActionResult New()
        {
            var movieFormViewModel = new MovieFormViewModel()
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieCreateForm", movieFormViewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var movieFormViewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieEditForm", movieFormViewModel);
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            movie.DateAddedToDatabase = DateTime.Now;
            _context.Movies.Add(movie);

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [HttpPost]
        public ActionResult Modify(Movie movie)
        {
            var _movie = _context.Movies.Single(m => m.Id == movie.Id);
            _movie.Name = movie.Name;
            _movie.GenreId = movie.GenreId;
            _movie.NumberInStock = movie.NumberInStock;
            _movie.ReleaseDate = movie.ReleaseDate;

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Details(int id)
        {
            var movie = _context.Movies.Include(m => m.Genre).ToList().SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
    }
}