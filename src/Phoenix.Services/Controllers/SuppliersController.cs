using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Phoenix.Domain.Suppliers;

namespace Phoenix.Services.Controllers
{
    [Route("api/suppliers")]
    public class SuppliersController : PhoenixBaseController
    {
        private readonly ISupplierService _service;
        public SuppliersController(ISupplierService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<dynamic> GetAll(int page = 1, int size = 10)
        {
            try
            {
                var suppliers = _service.GetAllSuppliers(page, size);
                int total = _service.TotalSuppliers;
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
        public ActionResult<Supplier> Get(long id)
        {
            try 
            {
                var supplier = _service.GetSupplierById(id);
                if (supplier == null)
                    return NotFound();
                return Ok(supplier);
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult Create(Supplier supplier)
        {
            try
            {
                var newSupplier = _service.CreateSupplier(supplier);
                return CreatedAtAction(nameof(Get), new { id = newSupplier.Id }, newSupplier);
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public ActionResult Update(Supplier supplier)
        {
            try
            {
                _service.UpdateSupplier(supplier);
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
                _service.DeleteSupplier(id);
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