using System;
using System.ComponentModel.DataAnnotations;

namespace Phoenix.Domain.Products
{
    public class NewProductDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}