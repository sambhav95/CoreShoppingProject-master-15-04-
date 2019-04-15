using System;
using System.Collections.Generic;

namespace CoreEcommerceUserPanal.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Feedbacks = new HashSet<Feedbacks>();
            Orders = new HashSet<Orders>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
        public double PhoneNo { get; set; }
        public string Password { get; set; }
        public bool ShippingAddress { get; set; }

        public ICollection<Feedbacks> Feedbacks { get; set; }
        public ICollection<Orders> Orders { get; set; }
    }
}
