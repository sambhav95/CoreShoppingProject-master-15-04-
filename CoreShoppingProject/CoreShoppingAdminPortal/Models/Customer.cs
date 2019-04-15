using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShoppingAdminPortal.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }

        public string Gender { get; set; }
        public double PhoneNo { get; set; }
        public string Password { get; set; }

        public List<Order> Orders { get; set; }
    }
}
