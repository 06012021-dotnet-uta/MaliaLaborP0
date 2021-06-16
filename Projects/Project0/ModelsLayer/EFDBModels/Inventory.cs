using System;
using System.Collections.Generic;

namespace Project0DbContext
{
    public partial class Inventory
    {
        public int StoreId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }

        public virtual Product Product { get; set; }
        public virtual Store Store { get; set; }
    }
}
