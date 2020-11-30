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
    public class ILOSSortGroupsController : ControllerBase
    {
        private readonly ILOSSortGroupRepository _sortGroup;
        public ILOSSortGroupsController(ILOSSortGroupRepository sortGroup)
        {
            _sortGroup = sortGroup;
        }

        [HttpGet]
        public async Task<ActionResult> GetILOSSortGroups()
        {
            try
            {
                var result = await _sortGroup.GetILOSSortGroups();
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
