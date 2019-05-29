using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Phoenix.Domain.Products;

namespace Phoenix.Services.Controllers
{
    [Route("api/products")]
    public class ProductsController : PhoenixBaseController
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;
        public ProductsController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ProductListDto> GetAll(int page = 1, int size = 10)
        {
            try
            {
                var products = _service.GetAllProducts(page, size);
                int total = _service.TotalProducts;
                string next = string.Empty;
                
                if (page * size < total )
                    next = Url.Action(nameof(GetAll), new { page = page + 1, size = size });

                var data = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDto>>(products);

                var response = new ProductListDto { Data = data, Next = next, Total = total };
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
        public ActionResult<ProductDto> Get(long id)
        {
            try 
            {
                var product = _service.GetProductById(id);
                if (product == null)
                    return NotFound();
                
                var result = _mapper.Map<Product, ProductDto>(product);
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
        public ActionResult<ProductDto> Create([FromBody] NewProductDto data)
        {
            try
            {
                var product = _mapper.Map<NewProductDto, Product>(data);
                var newProduct = _service.CreateProduct(product);
                
                var result = _mapper.Map<Product, ProductDto>(newProduct);
                return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, result);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Update([FromBody] ProductDto data)
        {
            try
            {
                var product = _mapper.Map<ProductDto, Product>(data);
                _service.UpdateProduct(product);
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
                _service.DeleteProduct(id);
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