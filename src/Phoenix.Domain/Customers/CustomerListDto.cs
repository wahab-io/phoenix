using System;
using System.Collections.Generic;

namespace Phoenix.Domain.Customers
{
    public class CustomerListDto
    {
        public IEnumerable<CustomerDto> Data { get; set; }
        public string Next { get; set; }
        public int Total { get; set; }
    }
}