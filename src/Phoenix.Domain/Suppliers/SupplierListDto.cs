using System;
using System.Collections.Generic;

namespace Phoenix.Domain.Suppliers
{
    public class SupplierListDto
    {
        public IEnumerable<SupplierDto> Data { get; set; }
        public string Next { get; set; }
        public int Total { get; set; }
    }
}