using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Phoenix.Features.Suppliers
{
    [Route("suppliers")]
    public sealed class SuppliersController : Controller
    {
        public SuppliersController()
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
        [ValidateAntiForgeryToken]
        public IActionResult Post(SupplierViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return View();
        }
    }
}