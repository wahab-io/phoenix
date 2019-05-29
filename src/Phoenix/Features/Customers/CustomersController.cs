using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Phoenix.Client;


namespace Phoenix.Features.Customers
{
    [Route("customers")]
    public sealed class CustomersController : Controller
    {
        private readonly PhoenixClient _phoenix;
        private readonly IMapper _mapper;
        public CustomersController(PhoenixClient phoenix, IMapper mapper)
        {
            _phoenix = phoenix;
            _mapper = mapper;
        }
                
        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int size = 10)
        {
            var result = await _phoenix.Customers.GetAll(page, size);
                
            var model = _mapper.Map<GetAllCustomersResponse, CustomerListViewModel>(result); 
            model.Page = page;
            model.Size = size;               
            
            return View(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> View(long id)
        {
            var result = await _phoenix.Customers.GetCustomerById(id);
            var customer = _mapper.Map<GetCustomerResponse, CustomerViewModel>(result);
            
            return View(customer);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromForm] CustomerViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = _mapper.Map<CustomerViewModel, CreateCustomerRequest>(model);
            var result = await _phoenix.Customers.CreateCustomer(request);
            return RedirectToAction("View", new { id = result.Id });
        }

        [HttpGet("{id}/edit")]
        public async Task<IActionResult> Edit([FromRoute] long id)
        {
            var customer = await _phoenix.Customers.GetCustomerById(id);
            return View(customer);
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromRoute] long id, [FromForm] CustomerViewModel model)
        {
            var request = _mapper.Map<CustomerViewModel, UpdateCustomerRequest>(model);
            await _phoenix.Customers.UpdateCustomer(request);
            return RedirectToAction("View", new { id = id });
        }

        [HttpGet("{id}/delete")]
        public async Task<IActionResult> Delete(long id)
        {
            await _phoenix.Customers.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}
