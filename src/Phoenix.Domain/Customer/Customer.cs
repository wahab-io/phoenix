using System;
using System.Collections.Generic;
using Phoenix.Common;
using Phoenix.Core;
using Phoenix.Domain.Shared;

namespace Phoenix.Domain
{
    public sealed class Customer : IEntity
    {
        public Customer(string name, Address address)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            if (address == null)
                throw new ArgumentNullException(nameof(name));
            
            Name = name;
            Address = address;
            Orders = new HashSet<Order>();
        }

        public long Id { get; }
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public PhoneNumber ContactNumber { get; private set; }
        public ICollection<Order> Orders { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public DateTime? UpdatedOn { get; private set; }
        public void ChangeAddress(Address newAddress)
        {
            if (newAddress == null)
                throw new ArgumentNullException(nameof(newAddress));
            Address = newAddress;
        }
    }
}