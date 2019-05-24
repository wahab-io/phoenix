using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Phoenix.Features.Orders
{
    [Route("orders")]
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

        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }
    }
}