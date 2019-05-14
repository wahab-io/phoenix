using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Domain;
using Phoenix.Infrastructure.EFCore;
using Phoenix.Models;


namespace Phoenix.Controllers
{
    public sealed class CustomerController : Controller
    {
        private readonly PhoenixContext _context;
        public CustomerController(PhoenixContext context)
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
        public IActionResult Post(CustomerModel customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
                
            var c = new Customer();
            c.Name = customer.Name;
            c.StreetLine1 = customer.StreetLine1;
            c.StreetLine2 = customer.StreetLine2;
            c.City = customer.City;
            c.State = customer.State;
            c.ZipCode = customer.ZipCode;
            _context.Customers.Add(c);
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
