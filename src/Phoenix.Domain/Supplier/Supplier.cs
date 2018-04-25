using Phoenix.Common;
using Phoenix.Domain.Shared;
using Phoenix.Core;

namespace Phoenix.Domain.Supplier
{
    public sealed class Supplier : User, IEntity
    {
        private readonly string _code;
        private Address _address;
        public Supplier(string code, Address address)
        {
            Guard.NotNullOrEmpty(code);
            Guard.NotNull(address);
            _code = code;
            _address = address;
        }

        public long Id => throw new System.NotImplementedException();
    }
}