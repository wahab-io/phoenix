using System;
using System.ComponentModel.DataAnnotations;

namespace Phoenix.Domain.Suppliers
{
    public class SupplierDto
    {
        [Required]
        public long Id { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}