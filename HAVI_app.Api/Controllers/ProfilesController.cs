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
    public class ProfilesController : ControllerBase
    {
        private readonly ProfileRepository _profileRepository;
        public ProfilesController(ProfileRepository profileRepository)
        {
            _profileRepository = profileRepository;
        }

        [HttpGet("country/{id:int}")]
        public async Task<ActionResult<Profile>> GetProfileForCountry(int id)
        {
            try
            {
                var result = await _profileRepository.GetProfileForCountry(id);
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

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Profile>> DeleteProfile(int id)
        {
            try
            {
                var result = await _profileRepository.DeleteProfileAsync(id);
                if(result != null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
