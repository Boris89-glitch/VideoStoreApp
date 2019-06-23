using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Video_store_app.Models;

namespace Video_store_app.ViewModels
{
    public class RandomMovieViewModel
    {
        public Movie Movie { get; set; }
        public List<Customer> Customers { get; set; }
    }
}