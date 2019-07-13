using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Video_store_app.Models;
using Videoteka.Models;
using Videoteka.ViewModels;

namespace Videoteka.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext db;
        public NewRentalsController()
        {
            db = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRental newRental)
        {
            var customer = db.Customers.Single(c => c.Id == newRental.CustomerId);

            var movies = db.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();
            //var customer = db.Customers.Where(c => c.Id == x.Id).First();

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                {
                    return BadRequest();
                }
                movie.NumberAvailable--;

                var rental = new Rentals
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                db.Rentals.Add(rental);
            }
            try
            {
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                Exception raise = dbEx;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string message = string.Format("{0}:{1}",
                            validationErrors.Entry.Entity.ToString(),
                            validationError.ErrorMessage);
                        // raise a new exception nesting
                        // the current instance as InnerException
                        raise = new InvalidOperationException(message, raise);
                    }
                }
                throw raise;
            }
            return Ok();
        }
    }
}
