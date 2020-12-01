using HAVI_app.Api.DatabaseClasses;

using HAVI_app.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformCostTypesController : ControllerBase
    {
        private readonly InformCostTypeRepository _informCostTypeRepository;
        public InformCostTypesController(InformCostTypeRepository informCostTypeRepository)
        {
            _informCostTypeRepository = informCostTypeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetInformCostTypes()
        {
            try
            {
                var result = await _informCostTypeRepository.GetInformCostTypes();
                if (result == null)
                {
                    return null;
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InformCostType>> GetInformCostType(int id)
        {
            try
            {
                var result = await _informCostTypeRepository.GetInformCostType(id);
                if (result == null)
                {
                    return null;
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
        public async Task<ActionResult<InformCostType>> CreateInformCostType(InformCostType informCostType)
        {
            try
            {
                if (informCostType == null)
                {
                    return BadRequest();
                }

                var createdInformCostType = await _informCostTypeRepository.AddInformCostType(informCostType);

                return CreatedAtAction(nameof(GetInformCostType), new { id = createdInformCostType.Id }, createdInformCostType);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InformCostType>> UpdateInformCostType(int id, InformCostType informCostType)
        {
            try
            {
                if (id != informCostType.Id)
                {
                    return BadRequest();
                }

                var informCostTypeToUpdate = await _informCostTypeRepository.GetInformCostType(id);

                if (informCostTypeToUpdate == null)
                {
                    return NotFound($"InformCostType with id = {id} not found");
                }

                return await _informCostTypeRepository.UpdateInformCostType(informCostType);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<InformCostType>> DeleteInformCostType(int id)
        {
            try
            {
                var informCostTypeToDelete = await _informCostTypeRepository.GetInformCostType(id);

                if (informCostTypeToDelete == null)
                {
                    return NotFound($"InformCostType with id = {id} not found");
                }

                return await _informCostTypeRepository.DeleteInformCostTypeAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
