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
    public class VatTaxCodesController : ControllerBase
    {
        private readonly VatTaxCodeRepository _vatTaxCodeRepository;
        public VatTaxCodesController(VatTaxCodeRepository vatTaxCodeRepository)
        {
            _vatTaxCodeRepository = vatTaxCodeRepository;
        }

        [HttpGet("country/{id}")]
        public async Task<ActionResult> GetVatTaxCodes(int id)
        {
            try
            {
                var result = await _vatTaxCodeRepository.GetVatTaxCodes(id);
                if (result == null)
                {
                    return Ok(new List<VatTaxCode>());
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VatTaxCode>> DeleteVatTaxCodeAsync(int codeId)
        {
            try
            {
                var vatTaxCodeToDelete = await _vatTaxCodeRepository.GetVatTaxCode(codeId);

                if (vatTaxCodeToDelete == null)
                {
                    return NotFound($"VatTaxCode with id = {codeId} not found");
                }

                return await _vatTaxCodeRepository.DeleteVatTaxCodeAsync(codeId);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VatTaxCode>> UpdateVatTaxCode(int id, VatTaxCode code)
        {
            try
            {
                if (id != code.Id)
                {
                    return BadRequest();
                }

                var vatTaxCodeToUpdate = await _vatTaxCodeRepository.GetVatTaxCode(id);

                if (vatTaxCodeToUpdate == null)
                {
                    return NotFound($"VatTaxCode with id = {id} not found");
                }

                return await _vatTaxCodeRepository.UpdateVatTaxCode(code);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<VatTaxCode>> CreateVatTaxCode(VatTaxCode code)
        {
            try
            {
                if (code == null)
                {
                    return BadRequest();
                }

                var createdVatTaxCode = await _vatTaxCodeRepository.AddVatTaxCode(code);

                return createdVatTaxCode;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
