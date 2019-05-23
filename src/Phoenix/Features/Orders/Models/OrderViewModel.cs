using System;
using System.ComponentModel.DataAnnotations;

namespace Phoenix.Features.Orders
{
    public sealed class OrderViewModel
    {
        public long Id { get; set; }
        public string SupplierName { get; set; }
        public string CustomerName { get; set; }
    }
}