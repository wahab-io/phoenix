using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phoenix.Client;


namespace Phoenix.Features.Customers
{
    public sealed class CustomersController : Controller
    {
        private readonly PhoenixClient _phoenix;
        public CustomersController(PhoenixClient phoenix)
        {
            _phoenix = phoenix;
        }
                
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await _phoenix.Customers.GetAll();
                return View(result);
            }
            catch (HttpRequestException ex)
            {
                return View(ex.Data);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(long id)
        {
            var result = await _phoenix.Customers.GetCustomerById(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromForm] CreateCustomerRequest request)
        {
            var result = await _phoenix.Customers.CreateCustomer(request);
            return await Index();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] UpdateCustomerRequest request)
        {
            await _phoenix.Customers.UpdateCustomer(request);
            return await Index();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(long id)
        {
            await _phoenix.Customers.DeleteCustomer(id);
            return await Index();
        }
    }
}
