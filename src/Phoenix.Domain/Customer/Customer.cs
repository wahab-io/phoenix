using System;
using Phoenix.Common;
using Phoenix.Core;
using Phoenix.Domain.Shared;

namespace Phoenix.Domain.Customer
{
    public sealed class Customer : User, IEntity
    {
        private readonly string _code;
        private readonly string _name;
        private Address _address;
        public Customer(string code, string name, Address address)
        {
            Guard.NotNullOrEmpty(code);
            Guard.NotNullOrEmpty(name);
            Guard.NotNull(address);
            
            _code = code;
            _name = name;
            _address = address;
        }

        public string Name 
        { 
            get
            {
                return _name;
            }
        }

        public Address Address 
        { 
            get
            {
                return _address;
            }
        }

        public long Id => throw new NotImplementedException();

        public void ChangeAddress(Address newAddress)
        {
            Guard.NotNull(newAddress);

            _address = newAddress;
        }
    }
}