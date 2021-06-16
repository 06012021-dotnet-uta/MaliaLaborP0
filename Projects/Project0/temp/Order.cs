using System;
using System.Collections.Generic;

#nullable disable

namespace Project0DbContext
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Store Store { get; set; }
    }
}
