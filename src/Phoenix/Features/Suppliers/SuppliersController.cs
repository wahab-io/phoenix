using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Phoenix.Features.Suppliers
{
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

        [HttpGet]
        public IActionResult Add()
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