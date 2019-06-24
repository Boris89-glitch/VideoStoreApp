using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Video_store_app.Models;
using Video_store_app.ViewModels;
using Videoteka.Models;
using Videoteka.ViewModels;

namespace Video_store_app.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db;

        public MoviesController()
        {
            db = new ApplicationDbContext();
        }

        // GET: Movie
        public ViewResult Index()
        {
            if (User.IsInRole("CanManageMovies"))
            {
                return View("List");
            }
            return View("ReadOnlyList");
        }

        [Authorize(Roles ="CanManageMovies")]
        public ActionResult New()
        {
            var genres = db.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Movie = new Movie(),
                Genres = genres
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Genres = db.Genres.ToList(),
                    Movie = movie
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                db.Movies.Add(movie);
            }
            else
            {
                var movieInDb = db.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            db.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = "CanManageMovies")]
        public ActionResult Edit(int id) 
        {
            var movie = db.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = db.Genres.ToList()
            };
            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var movie = db.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }
        

        //random
        public ViewResult Random()
        {
            var movie = new Movie() { Id = 1, Name = "Shrek!" };
            var customers = new List<Customer>() { new Customer { Name = "Boris Colic ", Id = 1 }, new Customer { Name = "Marko markovic", Id = 2 } };
            var randomMovie = new RandomMovieViewModel()
            {
                Movie = movie,
                Customers = customers
            };
            return View(randomMovie);
        }
    }
}