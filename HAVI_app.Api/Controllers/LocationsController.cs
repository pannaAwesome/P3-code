using HAVI_app.Api.DatabaseClasses;

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
    public class LocationsController : ControllerBase
    {
        private readonly LocationRepository _locationRepository;
        public LocationsController(LocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetLocations()
        {
            try
            {
                var result = await _locationRepository.GetLocations();
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
    }
}
