using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Domain.Customers;
using Phoenix.Infrastructure.EFCore;
using Phoenix.Models;


namespace Phoenix.Features.Customers
{
    public sealed class CustomersController : Controller
    {
        private readonly PhoenixContext _context;
        public CustomersController(PhoenixContext context)
        {
            _context = context;
        }
                
        [HttpGet]
        public IActionResult Index()
        {
            if (!_context.Customers.Any())
                return RedirectToAction("add");

            var customers = _context.Customers.ToList();
            return View(customers);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Post(CustomerModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = model.ToCustomer();
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        [HttpGet]
        public IActionResult Delete(long id)
        {
            var customer = _context.Customers.FirstOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();
            _context.Customers.Remove(customer);
            _context.SaveChanges();

            if (_context.Customers.Any())
                return RedirectToAction("index");
            else
                return RedirectToAction("add");
        }
    }
}
