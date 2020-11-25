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
    public class PurchasersController : ControllerBase
    {
        private readonly IPurchaserRepository _purchaserRepository;
        public PurchasersController(IPurchaserRepository purchaserRepository)
        {
            _purchaserRepository = purchaserRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Purchaser>> CreatePurchaser(Purchaser purchaser)
        {
            try
            {
                if (purchaser == null)
                {
                    return BadRequest();
                }

                var createdPurchaser = await _purchaserRepository.AddPurchaser(purchaser);

                return CreatedAtAction(nameof(GetPurchaser), new { id = createdPurchaser.Id }, createdPurchaser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Purchaser>> GetPurchaser(int id)
        {
            try
            {
                var result = await _purchaserRepository.GetPurchaser(id);
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

        [HttpGet]
        public async Task<ActionResult> GetPurchasers()
        {
            try
            {
                var result = await _purchaserRepository.GetPurchasers();
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<Purchaser>> DeletePurchaser(int id)
        {
            try
            {
                var supplierToDelete = await _purchaserRepository.GetPurchaser(id);

                if (supplierToDelete == null)
                {
                    return NotFound($"Purchaser with id = {id} not found");
                }

                return await _purchaserRepository.DeletePurchaserAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
