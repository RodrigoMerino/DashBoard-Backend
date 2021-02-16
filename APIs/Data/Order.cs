using System;
using System.Collections.Generic;

namespace APIs.Data
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public decimal? Total { get; set; }
        public DateTime? Placed { get; set; }
        public DateTime? Completed { get; set; }

        public virtual Customer CustomerIdNavigation{ get; set; }
    }
}
