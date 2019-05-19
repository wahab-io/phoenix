using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Domain.Customers;

namespace Phoenix.Services.Controllers
{
    [Route("api/customers")]
    public class CustomersController : PhoenixBaseController
    {
        private readonly ICustomerService _service;
        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<dynamic> GetAll(int page = 1, int size = 10)
        {
            try
            {
                var customers = _service.GetAllCustomers(page, size);
                int total = _service.TotalCustomers;
                string next = string.Empty;
                
                if (page * size < total )
                    next = Url.Action(nameof(GetAll), new { page = page + 1, size = size });

                var response = new { data = customers, next = next, total = total };
                return Ok(response);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(long id)
        {
            try 
            {
                var customer = _service.GetCustomerById(id);
                if (customer == null)
                    return NotFound();
                return Ok(customer);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                var newCustomer = _service.CreateCustomer(customer);
                return CreatedAtAction(nameof(Get), new { id = newCustomer.Id }, newCustomer);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public ActionResult Update(Customer customer)
        {
            try
            {
                _service.UpdateCustomer(customer);
                return NoContent();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            try
            {
                _service.DeleteCustomer(id);
                return NoContent();
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}