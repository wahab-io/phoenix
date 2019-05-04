using System;
using Phoenix.Core;

namespace Phoenix.Domain
{
    public sealed class Product : IEntity
    {
        public Product(string name, Supplier supplier, Price price)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            Name = name;

            if (supplier == null)
                throw new ArgumentNullException(nameof(supplier));
            Supplier = supplier;

            if (price == null)
                throw new ArgumentNullException(nameof(price));
            Price = price;

            CreatedOn = DateTime.UtcNow;
        }

        public long Id { get; }
        public string Name { get; private set; }
        public Supplier Supplier { get; private set; }
        public Price Price { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
    }
}