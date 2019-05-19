using System;
using System.ComponentModel.DataAnnotations;

namespace Phoenix.Models
{
    public sealed class ProductModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}