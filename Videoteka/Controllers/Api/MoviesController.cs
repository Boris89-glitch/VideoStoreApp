using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Video_store_app.Models;
using Videoteka.Models;

namespace Videoteka.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext db;
        public MoviesController()
        {
            db = new ApplicationDbContext();
        }

        //GET api/movies
        public IHttpActionResult GetMovies()
        {
            return Ok(db.Movies.Include(m => m.Genre).ToList());
        }

        //GET api/movies/1
        public IHttpActionResult GetMovies(int id)
        {
            var movie = db.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                return BadRequest();
            }
            return Ok(movie);
        }

        //POST api/movies
        [Authorize(Roles = "CanManageMovies")]
        [HttpPost]
        public IHttpActionResult CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            db.Movies.Add(movie);
            db.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        }

        //PUT api/movies/1
        [Authorize(Roles = "CanManageMovies")]
        [HttpPut]
        public IHttpActionResult UpdateMovies(int id, Movie movie)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var movieInDb = db.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
            {
                return NotFound();
            }
            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDate = movie.ReleaseDate;
            movieInDb.DateAdded = movie.DateAdded;
            movieInDb.NumberInStock = movie.NumberInStock;
            movieInDb.GenreId = movie.GenreId;

            db.SaveChanges();
            return Ok();
        }

        //DELETE api/movies/1
        [Authorize(Roles = "CanManageMovies")]
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movie = db.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            db.Movies.Remove(movie);
            db.SaveChanges();

        }
    }
}

