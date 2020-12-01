using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HAVI_app.Models;
using HAVI_app.Api.DatabaseClasses;

namespace HAVI_app.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersDeliveryUnitsController : ControllerBase
    {
        private readonly SupplierDeliveryUnitRepository _supplierDeliveryUnitRepository;
        public SuppliersDeliveryUnitsController(SupplierDeliveryUnitRepository supplierDiliveryUnitRepository)
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

                return createdSupplierDeliveryUnit;
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
                    return new SupplierDeliveryUnit();
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

        [HttpGet("country/{id}")]
        public async Task<ActionResult> GetSupplierDeliveryunits(int id)
        {
            try
            {
                var result = await _supplierDeliveryUnitRepository.GetSupplierDeliveryUnits(id);
                if (result == null)
                {
                    return Ok(new List<VailedForCustomer>());
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
