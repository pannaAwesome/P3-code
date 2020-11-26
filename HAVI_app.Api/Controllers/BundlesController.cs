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
    public class BundlesController : ControllerBase
    {
        private readonly IBundleRepository _bundleRepository;
        public BundlesController(IBundleRepository bundleRepository)
        {
            _bundleRepository = bundleRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetBundles()
        {
            try
            {
                var result = await _bundleRepository.GetBundles();
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
        public async Task<ActionResult<Bundle>> GetBundle(int id)
        {
            try
            {
                var result = await _bundleRepository.GetBundle(id);
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

        [HttpPut("{id}")]
        public async Task<ActionResult<Bundle>> UpdateBundle(int id, Bundle bundle)
        {
            try
            {
                if (id != bundle.Id)
                {
                    return BadRequest();
                }

                var bundleToUpdate = await _bundleRepository.GetBundle(id);

                if (bundleToUpdate == null)
                {
                    return NotFound($"Bundle with id = {id} not found");
                }

                return await _bundleRepository.UpdateBundle(bundle);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
