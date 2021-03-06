﻿using HAVI_app.Api.DatabaseClasses;

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
    public class InternalArticleInformationsController : ControllerBase
    {
        private readonly InternalArticleInformationRepository _internalArticleInformationRepository;
        public InternalArticleInformationsController(InternalArticleInformationRepository internalArticleInformationRepository)
        {
            _internalArticleInformationRepository = internalArticleInformationRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<InternalArticleInformation>> GetInternalArticleInformation(int id)
        {
            try
            {
                var result = await _internalArticleInformationRepository.GetInternalArticleInformation(id);
                if (result == null)
                {
                    return new InternalArticleInformation();
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
        public async Task<ActionResult<InternalArticleInformation>> UpdateInternalArticleInformation(int id, InternalArticleInformation internalArticleInformation)
        {
            try
            {
                if (id != internalArticleInformation.Id)
                {
                    return BadRequest();
                }

                var internalArticleInformationToUpdate = await _internalArticleInformationRepository.GetInternalArticleInformation(id);

                if (internalArticleInformationToUpdate == null)
                {
                    return NotFound($"InternalArticleInformation with id = {id} not found");
                }

                return await _internalArticleInformationRepository.UpdateInternalArticleInformation(internalArticleInformation);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
