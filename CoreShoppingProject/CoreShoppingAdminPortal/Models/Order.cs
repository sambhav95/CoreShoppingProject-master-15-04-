using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShoppingAdminPortal.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int ProductQty { get; set; }
        public int Units { get; set; }
        public float Billamount { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int ProductId { get; set; }

        public Product Product { get; set; }

    }
}
