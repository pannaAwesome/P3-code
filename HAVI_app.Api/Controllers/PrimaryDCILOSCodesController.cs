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
    public class PrimaryDCILOSCodesController : ControllerBase
    {
        private readonly PrimaryDCILOSCodeRepository _primaryDCILOSCodeRepository;
        public PrimaryDCILOSCodesController(PrimaryDCILOSCodeRepository primaryDCILOSCodeRepository)
        {
            _primaryDCILOSCodeRepository = primaryDCILOSCodeRepository;
        }

        [HttpGet("country/{id}")]
        public async Task<ActionResult> GetPrimaryDCILOSCodes(int id)
        {
            try
            {
                var result = await _primaryDCILOSCodeRepository.GetPrimaryDCILOSCodes(id);
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
        public async Task<ActionResult<PrimaryDciloscode>> GetPrimaryDCILOSCode(int id)
        {
            try
            {
                var result = await _primaryDCILOSCodeRepository.GetPrimaryDCILOSCode(id);
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
        public async Task<ActionResult<PrimaryDciloscode>> CreatePrimaryDCILOSCode(PrimaryDciloscode primaryDCILOSCode)
        {
            try
            {
                if (primaryDCILOSCode == null)
                {
                    return BadRequest();
                }

                var createdPrimaryDCILOSCode = await _primaryDCILOSCodeRepository.AddPrimaryDCILOSCode(primaryDCILOSCode);

                return CreatedAtAction(nameof(GetPrimaryDCILOSCode), new { id = createdPrimaryDCILOSCode.Id }, createdPrimaryDCILOSCode);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PrimaryDciloscode>> UpdatePrimaryDCILOSCode(int id, PrimaryDciloscode primaryDCILOSCode)
        {
            try
            {
                if (id != primaryDCILOSCode.Id)
                {
                    return BadRequest();
                }

                var primaryDCILOSCodeToUpdate = await _primaryDCILOSCodeRepository.GetPrimaryDCILOSCode(id);

                if (primaryDCILOSCodeToUpdate == null)
                {
                    return NotFound($"PrimaryDciloscode with id = {id} not found");
                }

                return await _primaryDCILOSCodeRepository.UpdatePrimaryDCILOSCode(primaryDCILOSCode);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PrimaryDciloscode>> DeletePrimaryDCILOSCode(int id)
        {
            try
            {
                var primaryDCILOSCodeToDelete = await _primaryDCILOSCodeRepository.GetPrimaryDCILOSCode(id);

                if (primaryDCILOSCodeToDelete == null)
                {
                    return NotFound($"PrimaryDciloscode with id = {id} not found");
                }

                return await _primaryDCILOSCodeRepository.DeletePrimaryDCILOSCodeAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
