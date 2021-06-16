using System;
using System.Collections.Generic;

#nullable disable

namespace Project0DbContext
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? StoreId { get; set; }

        public virtual Store Store { get; set; }
    }
}
