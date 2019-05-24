using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Phoenix.Client;

namespace Phoenix.Features.Products
{
    [Route("products")]
    public sealed class ProductsController : Controller
    {
        private readonly PhoenixClient _phoenix;
        private readonly IMapper _mapper;
        public ProductsController(PhoenixClient phoenix, IMapper mapper)
        {
            _phoenix = phoenix;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int size = 10)
        {
            var result = await _phoenix.Products.GetAll(page, size);
            
            var model = _mapper.Map<GetAllProductsResponse, ProductListViewModel>(result);
            model.Page = page;
            model.Size = size;

            return View(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> View(long id)
        {
            var result = await _phoenix.Products.GetProductById(id);
            var product = _mapper.Map<GetProductResponse, ProductViewModel>(result);
            return View(product);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }        

        [HttpPost]
        public IActionResult Add(ProductViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            return RedirectToAction("Index");
        }


    }
}