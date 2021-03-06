﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HAVI_app.Models;
using HAVI_app.Api.DatabaseClasses;

namespace HAVI_app.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesUnitsController : ControllerBase
    {
        private readonly SalesUnitRepository _salesUnitRepository;
        public SalesUnitsController(SalesUnitRepository salesUnitRepository)
        {
            _salesUnitRepository = salesUnitRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetSalesUnits()
        {
            try
            {
                var result = await _salesUnitRepository.GetSalesUnits();
                if (result == null)
                {
                    return Ok(new List<SalesUnit>());
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
