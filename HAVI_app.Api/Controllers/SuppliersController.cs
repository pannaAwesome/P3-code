using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;

namespace HAVI_app.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepository;
        public SuppliersController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Supplier>> GetSuppliers()
        {
            var result = await _supplierRepository.GetSuppliers();
                
            return result;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            try
            {
                var result = await _supplierRepository.GetSupplier(id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return result;
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Supplier>> CreateSupplier(Supplier supplier)
        {
            try
            {
                if (supplier == null)
                {
                    return BadRequest();
                }

                var createdSupplier = await _supplierRepository.AddSupplier(supplier);

                return CreatedAtAction(nameof(GetSupplier), new { id = createdSupplier.Id }, createdSupplier);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Supplier>> UpdateSupplier(int id, Supplier supplier)
        {
            try
            {
                if (id != supplier.Id)
                {
                    return BadRequest();
                }

                var supplierToUpdate = await _supplierRepository.GetSupplier(id);

                if (supplierToUpdate == null)
                {
                    return NotFound($"Supplier with id = {id} not found");
                }

                return await _supplierRepository.UpdateSupplier(supplier);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Supplier>> DeleteSupplier(int id)
        {
            try
            {
                var supplierToDelete = await _supplierRepository.GetSupplier(id);

                if (supplierToDelete == null)
                {
                    return NotFound($"Supplier with id = {id} not found");
                }

                return await _supplierRepository.DeleteSupplierAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
