﻿using HAVI_app.Api.DatabaseInterfaces;
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
    public class PackagingGroupsController : ControllerBase
    {
        private readonly IPackagingGroupRepository _packagingGroupRepository;
        public PackagingGroupsController(IPackagingGroupRepository packagingGroupRepository)
        {
            _packagingGroupRepository = packagingGroupRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetPackagingGroups()
        {
            try
            {
                var result = await _packagingGroupRepository.GetPackagingGroups();
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