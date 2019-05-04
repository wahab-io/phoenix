using System;
using Phoenix.Common;
using Phoenix.Core;
using Phoenix.Domain.Shared;

namespace Phoenix.Domain.Customer
{
    public sealed class Customer : IEntity
    {
        public Customer(string name, Address address)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (address == null)
                throw new ArgumentNullException(nameof(name));
            
            Name = name;
            Address = address;
        }

        public long Id { get; }
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public void ChangeAddress(Address newAddress)
        {
            if (newAddress == null)
                throw new ArgumentNullException(nameof(newAddress));
            Address = newAddress;
        }
    }
}