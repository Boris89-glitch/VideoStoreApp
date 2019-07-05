using Microsoft.AspNet.Identity.EntityFramework;
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
    [Authorize(Roles = "CanManageMovies")]
    public class CustomersController : ApiController
    {
        private ApplicationDbContext db;
        public CustomersController()
        {
            db = new ApplicationDbContext();
        }

        //GET api/customers
        public IEnumerable<Customer> GetCustomers()
        {
            return db.Customers.Include(c => c.MembershipType).ToList();
        }

        //GET api/customers/1
        public IHttpActionResult GetCustomers(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return BadRequest();
            }
            return Ok(customer);
        }

        //POST api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            db.Customers.Add(customer);
            db.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customer);
        }

        //PUT api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customerInDb = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            customerInDb.Name = customer.Name;
            customerInDb.Birthday = customer.Birthday;
            customerInDb.IsSubbed = customer.IsSubbed;
            customerInDb.MembershipType = customer.MembershipType;

            db.SaveChanges();
        }

        //DELETE api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            db.Customers.Remove(customer);
            db.SaveChanges();
            return Ok();
        }
    }
}
