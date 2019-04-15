using System;
using System.Collections.Generic;

namespace CoreEcommerceUserPanal.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderProducts = new HashSet<OrderProducts>();
        }

        public int OrderId { get; set; }
        public float OrderPrice { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }

        public Customers Customer { get; set; }
        public ICollection<OrderProducts> OrderProducts { get; set; }
    }
}
