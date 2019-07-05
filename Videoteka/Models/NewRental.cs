using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Videoteka.Models
{
    public class NewRental
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}