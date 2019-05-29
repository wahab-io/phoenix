using System;
using System.Collections.Generic;

namespace Phoenix.Domain.Orders
{
    public class OrderListDto
    {
        public IEnumerable<OrderDto> Data { get; set; }
        public string Next { get; set; }
        public int Total { get; set; }
    }
}