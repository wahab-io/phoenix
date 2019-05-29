using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Phoenix.Domain.Orders;

namespace Phoenix.Services.Controllers
{
    [Route("api/orders")]
    public sealed class OrdersController : PhoenixBaseController
    {
        private readonly IOrderService _service;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<OrderListDto> GetAll(int page = 1, int size = 10)
        {
            try
            {
                var orders = _service.GetAllOrders(page, size);
                int total = _service.TotalOrders;
                string next = string.Empty;
                
                if (page * size < total )
                    next = Url.Action(nameof(GetAll), new { page = page + 1, size = size });

                var data = _mapper.Map<IEnumerable<Order>, IEnumerable<OrderDto>>(orders);
                var response = new OrderListDto { Data = data, Next = next, Total = total };
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
        public ActionResult<OrderDto> Get(long id)
        {
            try 
            {
                var order = _service.GetOrderById(id);
                if (order == null)
                    return NotFound();
                
                var result = _mapper.Map<Order, OrderDto>(order);
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
        public ActionResult<OrderDto> Create([FromBody] NewOrderDto data)
        {
            try
            {
                var order = _mapper.Map<NewOrderDto, Order>(data);
                var newOrder = _service.CreateOrder(order);

                var result = _mapper.Map<Order, OrderDto>(newOrder);
                return CreatedAtAction(nameof(Get), new { id = newOrder.Id }, result);
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
        public ActionResult Update([FromBody] OrderDto data)
        {
            try
            {
                var order = _mapper.Map<OrderDto, Order>(data);
                _service.UpdateOrder(order);
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
                _service.DeleteOrder(id);
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