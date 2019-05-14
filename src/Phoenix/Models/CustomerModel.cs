using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Phoenix.Models
{
    public sealed class CustomerModel
    {
        [Required]
        [DisplayName("Name")]        
        public string Name { get; set; }
        
        [Required]
        [DisplayName("Address Line 1")]
        public string StreetLine1 { get; set; }
        
        [DisplayName("Address Line 2")]
        public string StreetLine2 { get; set; }
        
        [Required]
        [DisplayName("City")]
        public string City { get; set; }
        
        [Required]
        [DisplayName("State")]
        public string State { get; set; }
        
        [Required]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }
    }
}