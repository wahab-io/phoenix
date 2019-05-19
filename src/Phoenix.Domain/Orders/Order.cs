using System;
using System.Collections.Generic;
using Phoenix.Domain.Customers;
using Phoenix.Domain.Suppliers;
using Phoenix.Domain.Products;

namespace Phoenix.Domain.Orders
{
    public sealed class Order
    {
        public Order()
        {
            LineItems = new HashSet<LineItem>();
        }

        public long Id { get; set; }
        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public long CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<LineItem> LineItems { get; private set; }
        public bool IsArchived { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        public class LineItem
        {
            protected LineItem()
            {

            }

            public long Id { get; set; }
            public long ProductId { get; set; }
            public Product Product { get; set; }
            public float Quantity { get; set; }
            public float Discount { get; set; }
        }

    }  

}