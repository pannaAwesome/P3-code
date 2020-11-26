using HAVI_app.Api.DatabaseInterfaces;
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
    public class InternalArticleInformationsController : ControllerBase
    {
        private readonly IInternalArticleInformationRepository _internalArticleInformationRepository;
        public InternalArticleInformationsController(IInternalArticleInformationRepository internalArticleInformationRepository)
        {
            _internalArticleInformationRepository = internalArticleInformationRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetInternalArticleInformations()
        {
            try
            {
                var result = await _internalArticleInformationRepository.GetInternalArticleInformations();
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InternalArticleInformation>> GetInternalArticleInformation(int id)
        {
            try
            {
                var result = await _internalArticleInformationRepository.GetInternalArticleInformation(id);
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
        public async Task<ActionResult<InternalArticleInformation>> CreateInternalArticleInformation(InternalArticleInformation internalArticleInformation)
        {
            try
            {
                if (internalArticleInformation == null)
                {
                    return BadRequest();
                }

                var createdInternalArticleInformation = await _internalArticleInformationRepository.AddInternalArticleInformation(internalArticleInformation);

                return CreatedAtAction(nameof(GetInternalArticleInformation), new { id = createdInternalArticleInformation.Id }, createdInternalArticleInformation);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<InternalArticleInformation>> UpdateInternalArticleInformation(int id, InternalArticleInformation internalArticleInformation)
        {
            try
            {
                if (id != internalArticleInformation.Id)
                {
                    return BadRequest();
                }

                var internalArticleInformationToUpdate = await _internalArticleInformationRepository.GetInternalArticleInformation(id);

                if (internalArticleInformationToUpdate == null)
                {
                    return NotFound($"InternalArticleInformation with id = {id} not found");
                }

                return await _internalArticleInformationRepository.UpdateInternalArticleInformation(internalArticleInformation);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<InternalArticleInformation>> DeleteInternalArticleInformation(int id)
        {
            try
            {
                var internalArticleInformationToDelete = await _internalArticleInformationRepository.GetInternalArticleInformation(id);

                if (internalArticleInformationToDelete == null)
                {
                    return NotFound($"InternalArticleInformation with id = {id} not found");
                }

                return await _internalArticleInformationRepository.DeleteInternalArticleInformationAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
