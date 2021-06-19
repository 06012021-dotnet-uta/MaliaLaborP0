using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Project1DbContext
{
    public partial class Product
    {
        public Product()
        {
            Inventories = new HashSet<Inventory>();
            OrderLines = new HashSet<OrderLine>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
