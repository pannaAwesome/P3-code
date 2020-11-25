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
    public class DepartmentIdsController : ControllerBase
    {
        private readonly IDepartmentIdRepository _departmentIdRepository;
        public DepartmentIdsController(IDepartmentIdRepository departmentIdRepository)
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
