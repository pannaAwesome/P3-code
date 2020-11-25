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
    public class ProfileController : ControllerBase
    {
        private readonly IProfileRepository _profileRepository;
        public ProfileController(IProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Profile>> GetProfile(int id)
        {
            try
            {
                var result = await _profileRepository.GetProfile(id);
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
        public async Task<ActionResult> GetProfiles()
        {
            try
            {
                var result = await _profileRepository.GetProfiles();
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

        [HttpPost]
        public async Task<ActionResult<Profile>> CreateProfile(Profile profile)
        {
            try
            {
                if (profile == null)
                {
                    return BadRequest();
                }

                var createdSupplier = await _profileRepository.AddProfile(profile);

                return CreatedAtAction(nameof(GetProfile), new { id = createdSupplier.Id }, createdSupplier);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Profile>> DeleteSupplier(int id)
        {
            try
            {
                var supplierToDelete = await _profileRepository.GetProfile(id);

                if (supplierToDelete == null)
                {
                    return NotFound($"Supplier with id = {id} not found");
                }

                return await _profileRepository.DeleteProfileAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Profile>> UpdateProfile(int id, Profile profile)
        {
            try
            {
                if (id != profile.Id)
                {
                    return BadRequest();
                }

                var supplierToUpdate = await _profileRepository.GetProfile(id);

                if (supplierToUpdate == null)
                {
                    return NotFound($"Supplier with id = {id} not found");
                }

                return await _profileRepository.UpdateProfile(profile);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
