using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Phoenix.Features.Products
{
    [Route("products")]
    public sealed class ProductsController : Controller
    {
        public ProductsController()
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return RedirectToAction("Index");
        }


    }
}