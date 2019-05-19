using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Domain.Suppliers;
using Phoenix.Infrastructure.EFCore;
using Phoenix.Models;

namespace Phoenix.Features.Suppliers
{
    public sealed class SuppliersController : Controller
    {
        private readonly PhoenixContext _context;
        public SuppliersController(PhoenixContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (_context.Suppliers.Any())
            {
                var suppliers = _context.Suppliers.ToList();
                return View(suppliers);
            }
            return RedirectToAction("add");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(SupplierModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var supplier = new Supplier()
            {
                Name = model.Name,
                StreetAddress1 = model.AddressLine1,
                StreetAddress2 = model.AddressLine2,
                City = model.City,
                State = model.State,
                ZipCode = model.ZipCode
            };

            _context.Suppliers.Add(supplier);
            _context.SaveChanges();

            return RedirectToAction("index");
        }
    }
}