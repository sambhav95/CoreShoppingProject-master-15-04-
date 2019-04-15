using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShoppingAdminPortal.Models
{
    public class Customer
    {
       
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
     
        public bool Shipping_Address { get; set; }
       
        public List<Order> Orders { get; set; }
        public List<Feedback> Feedbacks { get; set; }
    }
}
