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
    public class VatTaxCodeController : ControllerBase
    {
        private readonly IVatTaxCodeRepository _vatTaxCodeRepository;
        public VatTaxCodeController(IVatTaxCodeRepository vatTaxCodeRepository)
        {
            _vatTaxCodeRepository = vatTaxCodeRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetVatTaxCodes()
        {
            try
            {
                var result = await _vatTaxCodeRepository.GetVatTaxCodes();
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
        public async Task<ActionResult<VatTaxCode>> DeleteVatTaxCodeAsync(int codeId)
        {
            try
            {
                var vatTaxCodeToDelete = await _vatTaxCodeRepository.GetVatTaxCodes();

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

                var vatTaxCodeToUpdate = await _vatTaxCodeRepository.GetVatTaxCodes();

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

                return CreatedAtAction(nameof(GetVatTaxCodes), new { id = createdVatTaxCode.Id }, createdVatTaxCode);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
