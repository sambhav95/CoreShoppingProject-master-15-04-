using System;
using System.Collections.Generic;

namespace CoreEcommerceUserPanal.Models
{
    public partial class Vendors
    {
        public Vendors()
        {
            Products = new HashSet<Products>();
        }

        public int VendorId { get; set; }
        public string VendorName { get; set; }
        public string EmailId { get; set; }
        public double PhoneNo { get; set; }
        public string VendorDescription { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
