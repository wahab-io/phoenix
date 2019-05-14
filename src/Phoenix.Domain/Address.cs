using System;
using System.Collections.Generic;
using Phoenix.Core;

namespace Phoenix.Domain
{
    public class Address : ValueObject
    {
        private Address (string streetLine1, string streetLine2, string city, string zipCode, string state, string country)
        {
            if (string.IsNullOrEmpty(streetLine1))
                throw new ArgumentNullException(nameof(streetLine1));
            this.StreetLine1 = streetLine1;
            this.StreetLine2 = streetLine2;

            if (string.IsNullOrEmpty(city))
                throw new ArgumentNullException(nameof(city));
            this.City = city;

            if (string.IsNullOrEmpty(zipCode))
                throw new ArgumentNullException(nameof(zipCode));
            this.ZipCode = zipCode;

            if (string.IsNullOrEmpty(state))
                throw new ArgumentNullException(nameof(state));
            this.State = state;

            if (string.IsNullOrEmpty(country))
                throw new ArgumentNullException(nameof(country));
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