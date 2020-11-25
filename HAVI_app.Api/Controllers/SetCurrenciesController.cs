using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;

namespace HAVI_app.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SetCurrenciesController : ControllerBase
    {
        private readonly ISetCurrencyRepository _setCurrencyRepository;
        public SetCurrenciesController(ISetCurrencyRepository setCurrencyRepository)
        {
            _setCurrencyRepository = setCurrencyRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetSetCurrencies()
        {
            try
            {
                var result = await _setCurrencyRepository.GetSetCurrencies();
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
