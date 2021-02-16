using System;
using System.Collections.Generic;

namespace APIs.Data
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string State { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}
