using System;
using System.Collections.Generic;

#nullable disable

namespace Project0DbContext
{
    public partial class Product
    {
        public Product()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string ProductDescr { get; set; }

        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
