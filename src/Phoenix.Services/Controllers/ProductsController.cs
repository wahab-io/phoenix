using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Domain.Products;

namespace Phoenix.Services.Controllers
{
    [Route("api/products")]
    public class ProductsController : PhoenixBaseController
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<dynamic> GetAll(int page = 1, int size = 10)
        {
            try
            {
                var suppliers = _service.GetAllProducts(page, size);
                int total = _service.TotalProducts;
                string next = string.Empty;
                
                if (page * size < total )
                    next = Url.Action(nameof(GetAll), new { page = page + 1, size = size });

                var response = new { data = suppliers, next = next, total = total };
                return Ok(response);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Product> Get(long id)
        {
            try 
            {
                var product = _service.GetProductById(id);
                if (product == null)
                    return NotFound();
                return Ok(product);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            try
            {
                var newProduct = _service.CreateProduct(product);
                return CreatedAtAction(nameof(Get), new { id = newProduct.Id }, newProduct);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public ActionResult Update(Product product)
        {
            try
            {
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