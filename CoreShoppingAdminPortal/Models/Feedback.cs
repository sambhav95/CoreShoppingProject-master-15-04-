using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShoppingAdminPortal.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }

        public string EmailId { get; set; }
        public long PhoneNo { get; set; }
        public string Comment { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

    }
}
