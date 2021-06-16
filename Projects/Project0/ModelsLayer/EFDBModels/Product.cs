using System;
using System.Collections.Generic;

namespace Project0DbContext
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            OrderLines = new HashSet<OrderLine>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductDescr { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
