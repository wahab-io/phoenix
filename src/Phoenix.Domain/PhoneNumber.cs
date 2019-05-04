using System;
using System.Collections.Generic;
using Phoenix.Core;

namespace Phoenix.Domain
{
    public class PhoneNumber : ValueObject
    {
        public PhoneNumber(string countryCode, string areaCode, string number)
        {
            if (string.IsNullOrEmpty(countryCode))
                throw new ArgumentNullException(nameof(countryCode));
            
            if (countryCode.Length < 2 || countryCode.Length > 5 )
                throw new ArgumentOutOfRangeException(nameof(countryCode));
            
            if (string.IsNullOrEmpty(areaCode))
                throw new ArgumentNullException(nameof(areaCode));
            
            if (areaCode.Length < 2 || areaCode.Length > 3)
                throw new ArgumentOutOfRangeException(nameof(areaCode));
            
            if (string.IsNullOrEmpty(number))
                throw new ArgumentNullException(nameof(number));
            
            if (number.Length < 6 || number.Length > 8)
                throw new ArgumentOutOfRangeException(nameof(number));

            CountryCode = countryCode;
            AreaCode = areaCode;
            Number = number;
        }

        public string CountryCode { get; private set; }
        public string AreaCode { get; private set; }
        public string Number { get; private set; }
        protected override IEnumerable<object> GetAtomicValues()
        {
            throw new NotImplementedException();
        }
    }
}