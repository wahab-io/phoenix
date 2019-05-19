using System;
using System.Collections.Generic;
using Phoenix.Domain.Products;
using Phoenix.Domain.Orders;

namespace Phoenix.Domain.Suppliers
{
    public sealed class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();

            CreatedOn = DateTime.UtcNow;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Order> Orders { get; set; }
        public bool IsArchived { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
    }
}