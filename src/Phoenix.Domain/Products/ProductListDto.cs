using System;
using System.Collections.Generic;

namespace Phoenix.Domain.Products
{
    public class ProductListDto
    {
        public IEnumerable<ProductDto> Data { get; set; }
        public string Next { get; set; }
        public int Total { get; set; }
    }
}