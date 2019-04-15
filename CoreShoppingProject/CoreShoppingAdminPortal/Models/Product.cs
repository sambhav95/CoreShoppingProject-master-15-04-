using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShoppingAdminPortal.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }

        public int ProductQty { get; set; }

        public float ProductPrice { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int VendorId { get; set; }
        public Vendor Vendor { get; set; }
    }
}
