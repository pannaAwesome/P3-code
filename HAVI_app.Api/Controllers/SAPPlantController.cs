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
    public class SAPPlantController : ControllerBase
    {
        private readonly ISAPPlantRepository _sapPlantRepository;
        public SAPPlantController(ISAPPlantRepository sapPlantRepository)
        {
            _sapPlantRepository = sapPlantRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Sapplant>> CreateSAPPlant(Sapplant SAPPlant)
        {
            try
            {
                if (SAPPlant == null)
                {
                    return BadRequest();
                }

                var createdSAPPlant = await _sapPlantRepository.AddSAPPlant(SAPPlant);

                return CreatedAtAction(nameof(GetSAPPlant), new { id = createdSAPPlant.Id }, createdSAPPlant);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Sapplant>> DeleteSAPPlantAsync(int id)
        {
            try
            {
                var supplierToDelete = await _sapPlantRepository.DeleteSAPPlantAsync(id);

                if (supplierToDelete == null)
                {
                    return NotFound($"Supplier with id = {id} not found");
                }

                return await _sapPlantRepository.DeleteSAPPlantAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Sapplant>> GetSAPPlant(int id)
        {
            try
            {
                var result = await _sapPlantRepository.GetSAPPlant(id);
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
        public async Task<ActionResult> GetSAPPlants()
        {
            try
            {
                var result = await _sapPlantRepository.GetSAPPlants();
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
        public async Task<ActionResult<Sapplant>> UpdateSAPPlant(int id, Sapplant SAPPlant)
        {
            try
            {
                if (id != SAPPlant.Id)
                {
                    return BadRequest();
                }

                var supplierToUpdate = await _sapPlantRepository.GetSAPPlant(id);

                if (supplierToUpdate == null)
                {
                    return NotFound($"Supplier with id = {id} not found");
                }

                return await _sapPlantRepository.UpdateSAPPlant(SAPPlant);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
