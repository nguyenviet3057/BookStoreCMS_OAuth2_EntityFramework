using System;
using System.Collections.Generic;

#nullable disable

namespace BSI.Models
{
    public partial class Stock
    {
        public Stock()
        {
            OrderItems = new HashSet<OrderItem>();
            Returns = new HashSet<Return>();
            Suppliers = new HashSet<Supplier>();
        }

        public string StockId { get; set; }
        public string Isbn { get; set; }
        public string AuthorName { get; set; }
        public string TitleName { get; set; }
        public string PublisherName { get; set; }
        public string PublishedYear { get; set; }
        public string SupplierId { get; set; }
        public string RetailPrice { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public virtual ICollection<Return> Returns { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}
