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
    public class DepartmentIdsController : ControllerBase
    {
        private readonly DepartmentIdRepository _departmentIdRepository;
        public DepartmentIdsController(DepartmentIdRepository departmentIdRepository)
        {
            _departmentIdRepository = departmentIdRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetDepartmentIds()
        {
            try
            {
                var result = await _departmentIdRepository.GetDepartmentIds();
                if (result == null)
                {
                    return null;
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
