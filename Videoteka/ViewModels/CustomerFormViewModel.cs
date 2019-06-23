using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Video_store_app.Models;
using Videoteka.Models;

namespace Videoteka.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipTypes> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public string Title
        {
            get
            {
                if (Customer != null && Customer.Id != 0)
                    return "Edit Customer";

                return "New Customer";
            }
        }
    }
}