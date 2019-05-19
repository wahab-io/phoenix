using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Infrastructure.EFCore;

namespace Phoenix.Features.Orders
{
    public sealed class OrdersController : Controller
    {
        private readonly PhoenixContext _context;
        public OrdersController(PhoenixContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (!_context.Customers.Any())
                return RedirectToAction("add");

            var orders = _context.Orders.ToList();
            return View(orders);
        }
    }
}