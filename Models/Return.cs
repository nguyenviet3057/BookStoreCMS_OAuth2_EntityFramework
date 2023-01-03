using System;
using System.Collections.Generic;

#nullable disable

namespace BSI.Models
{
    public partial class Return
    {
        public string ReturnId { get; set; }
        public string ItemId { get; set; }
        public string StockId { get; set; }
        public string RetailPrice { get; set; }

        public virtual OrderItem Item { get; set; }
        public virtual Stock Stock { get; set; }
    }
}
