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
    public class CompanyCodesController : ControllerBase
    {
        private readonly CompanyCodeRepository _codeRepository;
        public CompanyCodesController(CompanyCodeRepository codeRepository)
        {
            _codeRepository = codeRepository;
        }

        [HttpGet("country/{id}")]
        public async Task<ActionResult> GetCompanyCodes(int id)
        {
            try
            {
                var result = await _codeRepository.GetCompanyCodes(id);
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
        public async Task<ActionResult<CompanyCode>> GetCompanyCode(int id)
        {
            try
            {
                var result = await _codeRepository.GetCompanyCode(id);
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
        public async Task<ActionResult<CompanyCode>> CreateCompanyCode(CompanyCode code)
        {
            try
            {
                if (code == null)
                {
                    return BadRequest();
                }

                var createdCode = await _codeRepository.AddCompanyCode(code);

                return CreatedAtAction(nameof(GetCompanyCode), new { id = createdCode.Id }, createdCode);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyCode>> UpdateCompanyCode(int id, CompanyCode code)
        {
            try
            {
                if (id != code.Id)
                {
                    return BadRequest();
                }

                var codeToUpdate = await _codeRepository.GetCompanyCode(id);

                if (codeToUpdate == null)
                {
                    return NotFound($"ILOSCategory with id = {id} not found");
                }

                return await _codeRepository.UpdateCompanyCode(code);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<CompanyCode>> DeleteCompanyCode(int id)
        {
            try
            {
                var codeToDelete = await _codeRepository.DeleteCompanyCodeAsync(id);

                if (codeToDelete == null)
                {
                    return NotFound($"ILOSCategory with id = {id} not found");
                }

                return await _codeRepository.DeleteCompanyCodeAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
