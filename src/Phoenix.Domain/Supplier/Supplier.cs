using System;
using System.Collections.Generic;
using Phoenix.Core;

namespace Phoenix.Domain
{
    public sealed class Supplier : IEntity
    {
        public Supplier(string name, Address address, PhoneNumber number = null)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (address == null)
                throw new ArgumentNullException(nameof(address));
            
            Name = name;
            Address = address;
            ContactNumber = number;
            Account = new Account();
            Products = new HashSet<Product>();
            Orders = new HashSet<Order>();
            CreatedOn = DateTime.UtcNow;
        }

        public long Id { get; }
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public PhoneNumber ContactNumber { get; private set; }
        public Account Account { get; private set; }
        public ICollection<Product> Products { get; private set; }
        public ICollection<Order> Orders { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
    }
}