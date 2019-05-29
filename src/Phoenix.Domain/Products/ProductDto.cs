using System;
using System.ComponentModel.DataAnnotations;

namespace Phoenix.Domain.Products
{
    public class ProductDto
    {
        [Required]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}