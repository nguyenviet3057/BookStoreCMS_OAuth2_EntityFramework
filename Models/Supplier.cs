using System;
using System.Collections.Generic;

#nullable disable

namespace BSI.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public string SupplierId { get; set; }
        public string StockId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierCity { get; set; }
        public string SupplierStreet { get; set; }
        public string SupplierPcode { get; set; }
        public string SupplierEmail { get; set; }
        public string SupplierPhone { get; set; }

        public virtual Stock Stock { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
