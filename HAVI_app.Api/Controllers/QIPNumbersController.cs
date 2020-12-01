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
    public class QIPNumbersController : ControllerBase
    {
        private readonly QIPNumberRepository _numbersRepository;
        public QIPNumbersController(QIPNumberRepository numbersRepository)
        {
            _numbersRepository = numbersRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetQIPNumbers()
        {
            try
            {
                var result = await _numbersRepository.GetQIPNumbers();
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
