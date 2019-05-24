using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Phoenix.Client;

namespace Phoenix.Features.Suppliers
{
    [Route("suppliers")]
    public sealed class SuppliersController : Controller
    {
        private readonly PhoenixClient _phoenix;
        private readonly IMapper _mapper;
        public SuppliersController(PhoenixClient phoenix, IMapper mapper)
        {
            _phoenix = phoenix;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int page = 1, int size = 10)
        {
            var result = await _phoenix.Suppliers.GetAll(page, size);

            var model = _mapper.Map<GetAllSuppliersResponse, SupplierListViewModel>(result);
            model.Page = page;
            model.Size = size;

            return View(model);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> View(long id)
        {
            var result = await _phoenix.Suppliers.GetSupplierById(id);
            var supplier = _mapper.Map<GetSupplierResponse, SupplierViewModel>(result);
            return View(supplier);
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Post([FromForm] SupplierViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            var supplier = _mapper.Map<SupplierViewModel, CreateSupplierRequest>(model);
            var result = await _phoenix.Suppliers.CreateSupplier(supplier);

            return await Index();
        }
    }
}