using System;
using System.Collections.Generic;

namespace CoreEcommerceUserPanal.Models
{
    public partial class Admins
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
    }
}
