using System;
using System.Collections.Generic;

namespace CoreEcommerceUserPanal.Models
{
    public partial class Categories
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public int ProductCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        public ICollection<Products> Products { get; set; }
    }
}
