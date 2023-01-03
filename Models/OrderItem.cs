using System;
using System.Collections.Generic;

#nullable disable

namespace BSI.Models
{
    public partial class OrderItem
    {
        public OrderItem()
        {
            Returns = new HashSet<Return>();
        }

        public string ItemId { get; set; }
        public string OrderId { get; set; }
        public string StockId { get; set; }
        public string Isbn { get; set; }
        public string SupplierId { get; set; }
        public string RetailPrice { get; set; }
        public string QtySold { get; set; }

        public virtual Order Order { get; set; }
        public virtual Stock Stock { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<Return> Returns { get; set; }
    }
}
