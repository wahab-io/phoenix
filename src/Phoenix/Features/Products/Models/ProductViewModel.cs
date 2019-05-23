using System;
using System.ComponentModel.DataAnnotations;

namespace Phoenix.Features.Products
{
    public sealed class ProductViewModel
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}