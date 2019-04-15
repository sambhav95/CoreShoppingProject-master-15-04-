using System;
using System.Collections.Generic;

namespace CoreEcommerceUserPanal.Models
{
    public partial class Products
    {
        public Products()
        {
            OrderProducts = new HashSet<OrderProducts>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductQty { get; set; }
        public float ProductPrice { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public int VendorId { get; set; }
        public int ProductCategoryId { get; set; }
        public int BrandId { get; set; }

        public Brands Brand { get; set; }
        public Categories ProductCategory { get; set; }
        public Vendors Vendor { get; set; }
        public ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
