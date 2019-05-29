using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Phoenix.Client;

namespace Phoenix.Features.Orders
{
    [Route("orders")]
    public sealed class OrdersController : Controller
    {
        private readonly PhoenixClient _phoenix;
        private readonly IMapper _mapper;
        public OrdersController(PhoenixClient phoenix, IMapper mapper)
        {
            _phoenix = phoenix;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int size = 10)
        {
            var result = await _phoenix.Orders.GetAll(page, size);
                
            var model = _mapper.Map<GetAllOrdersResponse, OrderListViewModel>(result); 
            model.Page = page;
            model.Size = size;               
            
            return View(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> View(long id)
        {
            var result = await _phoenix.Orders.GetOrderById(id);
            var order = _mapper.Map<GetOrderResponse, OrderViewModel>(result);
            
            return View(order);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromForm] OrderViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var request = _mapper.Map<OrderViewModel, CreateOrderRequest>(model);
            var result = await _phoenix.Orders.CreateOrder(request);
            return await Index();
        }

        [HttpGet("{id}/edit")]
        public async Task<IActionResult> Edit([FromRoute] long id)
        {
            var customer = await _phoenix.Orders.GetOrderById(id);
            return View();
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromRoute] long id, [FromBody] OrderViewModel model)
        {
            var request = _mapper.Map<OrderViewModel, UpdateOrderRequest>(model);
            await _phoenix.Orders.UpdateOrder(request);
            return await Index();
        }
    }
}