using HAVI_app.Api.DatabaseInterfaces;
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
    public class ArticleBundlesController : ControllerBase
    {
        private readonly IArticleBundleRepository _articleBundleRepository;
        public ArticleBundlesController(IArticleBundleRepository articleBundleRepository)
        {
            _articleBundleRepository = articleBundleRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetArticleBundles()
        {
            try
            {
                var result = await _articleBundleRepository.GetArticleBundles();
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
