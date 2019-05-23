using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Phoenix.Features.Orders
{
    public sealed class OrdersController : Controller
    {
        public OrdersController()
        {

        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}