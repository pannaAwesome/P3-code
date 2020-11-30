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
    public class CreationCodes : ControllerBase
    {
        private readonly CreationCodeRepository _creationCodeRepository;
        public CreationCodes(CreationCodeRepository creationCodeRepository)
        {
            _creationCodeRepository = creationCodeRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CreationCode>> GetCreationCode(int id)
        {
            try
            {
                var result = await _creationCodeRepository.GetCreationCode(id);
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
        public async Task<ActionResult<CreationCode>> CreateCreationCode(CreationCode creationCode)
        {
            try
            {
                if (creationCode == null)
                {
                    return BadRequest();
                }

                var createdCreationCode = await _creationCodeRepository.AddCreationCode(creationCode);

                return CreatedAtAction(nameof(GetCreationCode), new { id = createdCreationCode.Id }, createdCreationCode);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CreationCode>> UpdateCreationCode(int id, CreationCode creationCode)
        {
            try
            {
                if (id != creationCode.Id)
                {
                    return BadRequest();
                }

                var creationCodeToUpdate = await _creationCodeRepository.GetCreationCode(id);

                if (creationCodeToUpdate == null)
                {
                    return NotFound($"CreationCode with id = {id} not found");
                }

                return await _creationCodeRepository.UpdateCreationCode(creationCode);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
