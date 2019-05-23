using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Customer> Create([FromBody] Customer customer)
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Update([FromBody] Customer customer)
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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