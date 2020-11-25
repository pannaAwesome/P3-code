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
    public class FreightResponsibilitiesController : ControllerBase {

        private readonly IFreightResponsibilityRepository _freightResponsibilityRepository;
        public FreightResponsibilitiesController(IFreightResponsibilityRepository freightResponsibilityRepository)
        {
            _freightResponsibilityRepository = freightResponsibilityRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetFreightResponsibilities()
        {
            try
            {
                var result = await _freightResponsibilityRepository.GetFreightResponsibilities();
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
