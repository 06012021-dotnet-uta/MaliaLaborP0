using System;
using System.Collections.Generic;

namespace Project0DbContext
{
    public partial class OrderHistory
    {
        public int CustomerId { get; set; }
        public int OrderId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Order Order { get; set; }
    }
}
