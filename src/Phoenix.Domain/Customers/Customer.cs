using System;
using System.Collections.Generic;
using Phoenix.Domain.Orders;
using Phoenix.Domain.Products;

namespace Phoenix.Domain.Customers
{
    public sealed class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
            CreatedOn = DateTime.UtcNow;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string StreetLine1 { get; set; }
        public string StreetLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
        public ICollection<Order> Orders { get; set; }
        public bool IsArchived { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}