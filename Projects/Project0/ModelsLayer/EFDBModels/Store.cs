using System;
using System.Collections.Generic;

namespace Project0DbContext
{
    public partial class Store
    {
        public Store()
        {
            Customers = new HashSet<Customer>();
            Inventories = new HashSet<Inventory>();
            Orders = new HashSet<Order>();
        }

        public int StoreId { get; set; }
        public string StoreLocation { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
