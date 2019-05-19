using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Phoenix.Models
{
    public sealed class SupplierModel
    {
        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
    }
}