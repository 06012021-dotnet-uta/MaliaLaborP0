using System;
using System.Collections.Generic;

namespace Project0DbContext
{
    public partial class Order
    {
        public Order()
        {
            OrderHistories = new HashSet<OrderHistory>();
            OrderLines = new HashSet<OrderLine>();
        }

        public int OrderId { get; set; }
        public int StoreId { get; set; }
        public DateTime OrderDate { get; set; }

        public virtual Store Store { get; set; }
        public virtual ICollection<OrderHistory> OrderHistories { get; set; }
        public virtual ICollection<OrderLine> OrderLines { get; set; }
    }
}
