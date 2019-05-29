using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Phoenix.Domain.Customers;

namespace Phoenix.Services.Controllers
{
    [Route("api/customers")]
    public class CustomersController : PhoenixBaseController
    {
        private readonly ICustomerService _service;
        private readonly IMapper _mapper;
        public CustomersController(ICustomerService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CustomerListDto> GetAll(int page = 1, int size = 10)
        {
            try
            {
                var customers = _service.GetAllCustomers(page, size);
                int total = _service.TotalCustomers;
                string next = string.Empty;
                
                if (page * size < total )
                    next = Url.Action(nameof(GetAll), new { page = page + 1, size = size });

                var data = _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);
                var response = new CustomerListDto { Data = data, Next = next, Total = total };
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
        public ActionResult<CustomerDto> Get(long id)
        {
            try 
            {
                var customer = _service.GetCustomerById(id);
                if (customer == null)
                    return NotFound();
                
                var result = _mapper.Map<Customer, CustomerDto>(customer);
                return Ok(result);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<CustomerDto> Create([FromBody] NewCustomerDto data)
        {
            try
            {
                var customer = _mapper.Map<NewCustomerDto, Customer>(data);
                var newCustomer = _service.CreateCustomer(customer);

                var result = _mapper.Map<Customer, CustomerDto>(newCustomer);
                return CreatedAtAction(nameof(Get), new { id = newCustomer.Id }, result);
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
        public ActionResult Update([FromBody] CustomerDto data)
        {
            try
            {
                var customer = _mapper.Map<CustomerDto, Customer>(data);
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