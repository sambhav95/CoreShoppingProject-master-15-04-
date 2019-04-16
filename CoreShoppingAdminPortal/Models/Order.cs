using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShoppingAdminPortal.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        
        public float OrderPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public List<OrderProduct> OrderProducts { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
