using System;
using System.Collections.Generic;
using Phoenix.Domain.Suppliers;

namespace Phoenix.Domain.Products
{
    public sealed class Product
    {
        public Product()
        {
            CreatedOn = DateTime.UtcNow;
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Price> Prices { get; set; }
        public bool IsArchived { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public class Price
        {
            public Price()
            {
                CreatedOn = DateTime.UtcNow;
            }
            
            public long Id { get; set; }
            public long ProductId { get; set; }
            public Product Product { get; set; }
            public long SupplierId { get; set; }
            public Supplier Supplier { get; set; }
            public decimal UnitPrice { get; set; }
            public string CurrencyCode { get; set; }
            public DateTime CreatedOn { get; set; }
            public DateTime? UpdatedOn { get; set; }
        }
    }
}