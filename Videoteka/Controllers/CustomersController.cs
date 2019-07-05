using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Video_store_app.Models;
using Video_store_app.ViewModels;
using Videoteka.Models;
using System.Data.Entity;
using Videoteka.ViewModels;

namespace Video_store_app.Controllers
{
    [Authorize(Roles = "CanManageMovies")]
    public class CustomersController : Controller
    {
        private ApplicationDbContext db; //to access db
        public CustomersController()
        {
            db = new ApplicationDbContext();
        }

        public ViewResult Index()
        {
            return View();
        }


        public ActionResult New() 
        {
            var membershipTypes = db.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }


        [HttpPost]    //create new customer
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = db.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
            {
                db.Customers.Add(customer);
            }
            else
            {
                var customerInDb = db.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubbed = customer.IsSubbed;
            }
            db.SaveChanges(); 
            return RedirectToAction("Index","Customers");
        }


        public ActionResult Edit(int id) //edit customer
        {
            var customer = db.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = db.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }


        public ActionResult Details(int id)
        {
            var customer = db.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}