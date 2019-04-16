using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShoppingAdminPortal.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public string PaymentStripeId { get; set; }
        public int Amount { get; set; }
        public DateTime Paymentdate { get; set; }
        public double CardNo { get; set; }
        public int CustomerId { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
