using System;
using System.Collections.Generic;

#nullable disable

namespace BSI.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public string CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerStreet { get; set; }
        public string CustomerPcode { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
