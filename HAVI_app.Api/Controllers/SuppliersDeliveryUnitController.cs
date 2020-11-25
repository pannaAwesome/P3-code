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
    public class SuppliersDeliveryUnitController : ControllerBase
    {
        private readonly ISupplierDeliveryUnitRepository _supplierDeliveryUnitRepository;
        public SuppliersDeliveryUnitController(ISupplierDeliveryUnitRepository supplierDiliveryUnitRepository)
        {
            _supplierDeliveryUnitRepository = supplierDiliveryUnitRepository;
        }

        [HttpPost]
        public async Task<ActionResult<SupplierDeliveryUnit>> CreateSupplier(SupplierDeliveryUnit deliveryUnit)
        {
            try
            {
                if (deliveryUnit == null)
                {
                    return BadRequest();
                }

                var createdSupplierDeliveryUnit = await _supplierDeliveryUnitRepository.AddSupplierDeliveryUnit(deliveryUnit);

                return CreatedAtAction(nameof(GetSupplierDeliveryUnit), new { id = createdSupplierDeliveryUnit.Id }, createdSupplierDeliveryUnit);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SupplierDeliveryUnit>> GetSupplierDeliveryUnit(int id)
        {
            try
            {
                var result = await _supplierDeliveryUnitRepository.GetSupplierDeliveryUnit(id);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<SupplierDeliveryUnit>> DeleteSupplierDeliveryUnit(int id)
        {
            try
            {
                var supplierToDelete = await _supplierDeliveryUnitRepository.GetSupplierDeliveryUnit(id);

                if (supplierToDelete == null)
                {
                    return NotFound($"SupplierDeliveryUnit with id = {id} not found");
                }

                return await _supplierDeliveryUnitRepository.DeleteSupplierDeliveryUnitAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetSupplierDeliveryunits()
        {
            try
            {
                var result = await _supplierDeliveryUnitRepository.GetSupplierDeliveryUnits();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SupplierDeliveryUnit>> UpdateSupplierDeliveryUnit(int id, SupplierDeliveryUnit deliveryUnit)
        {
            try
            {
                if (id != deliveryUnit.Id)
                {
                    return BadRequest();
                }

                var supplierToUpdate = await _supplierDeliveryUnitRepository.GetSupplierDeliveryUnit(id);

                if (supplierToUpdate == null)
                {
                    return NotFound($"SupplierDeliveryUnit with id = {id} not found");
                }

                return await _supplierDeliveryUnitRepository.UpdateSupplierDeliveryUnit(deliveryUnit);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
