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
    public class QIPNumbersController : ControllerBase
    {
        private readonly IQIPNumberRepository _numbersRepository;
        public QIPNumbersController(IQIPNumberRepository numbersRepository)
        {
            _numbersRepository = numbersRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetQIPNumberss()
        {
            try
            {
                var result = await _numbersRepository.GetQIPNumberss();
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
