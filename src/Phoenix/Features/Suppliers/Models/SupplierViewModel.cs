using System;
using System.ComponentModel.DataAnnotations;

namespace Phoenix.Features.Suppliers
{
    public sealed class SupplierViewModel
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Phone { get; set; }
        public string Fax { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}