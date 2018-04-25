using System;
using System.Collections.Generic;
using Phoenix.Core;

namespace Phoenix.Domain
{
    public class Address : ValueObject
    {
        public Address (string streetLine1, string streetLine2, string city, string zipCode, string state, string country)
        {
            this.StreetLine1 = streetLine1;
            this.StreetLine2 = streetLine2;
            this.City = city;
            this.ZipCode = zipCode;
            this.State = state;
            this.Country = country;
        }
        
        public string StreetLine1 { get; }
        public string StreetLine2 { get; }
        public string City { get; }
        public string ZipCode { get; }
        public string State { get; }
        public string Country { get; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return StreetLine1;
            yield return StreetLine2;
            yield return City;
            yield return ZipCode;
            yield return State;
            yield return Country;
        }
    }
}