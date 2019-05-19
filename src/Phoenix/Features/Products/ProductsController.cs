using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Infrastructure.EFCore;
using Phoenix.Models;

namespace Phoenix.Features.Products
{
    public sealed class ProductsController : Controller
    {
        private readonly PhoenixContext _context;
        public ProductsController(PhoenixContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            if (products.Any())
                return View(products);
            return RedirectToAction("Add");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return RedirectToAction("Index");
        }


    }
}