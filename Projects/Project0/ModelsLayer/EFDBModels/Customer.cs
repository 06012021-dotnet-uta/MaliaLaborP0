using System;
using System.Collections.Generic;

namespace Project0DbContext
{
    public partial class Customer
    {
        public Customer()
        {
            OrderHistories = new HashSet<OrderHistory>();
        }

        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? StoreId { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
    }
}
