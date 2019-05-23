using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Create([FromBody] Product product)
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
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult Update([FromBody] Product product)
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