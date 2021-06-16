using System;
using System.Collections.Generic;

namespace Project0DbContext
{
    public partial class OrderLine
    {
        public int LineId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public int OrderId { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
