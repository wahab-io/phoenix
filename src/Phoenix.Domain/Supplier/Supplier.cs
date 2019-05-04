using System;
using Phoenix.Core;

namespace Phoenix.Domain.Supplier
{
    public sealed class Supplier : IEntity
    {
        public Supplier(string name, Address address)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));
            
            if (address == null)
                throw new ArgumentNullException(nameof(address));

            Name = name;
            Address = address;
        }

        public long Id { get; }

        public string Name { get; private set; }
        public Address Address { get; private set; }
    }
}