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
    public class ArticleInformationsController : ControllerBase
    {
        private readonly ArticleInformationRepository _articleInformationRepository;
        public ArticleInformationsController(ArticleInformationRepository articleInformationRepository)
        {
            _articleInformationRepository = articleInformationRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ArticleInformation>> GetArticleInformation(int id)
        {
            try
            {
                var result = await _articleInformationRepository.GetArticleInformation(id);
                if (result == null)
                {
                    return new ArticleInformation();
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
        public async Task<ActionResult<ArticleInformation>> UpdateArticleInformation(int id, ArticleInformation articleInformation)
        {
            try
            {
                if (id != articleInformation.Id)
                {
                    return BadRequest();
                }

                var articleInformationToUpdate = await _articleInformationRepository.GetArticleInformation(id);

                if (articleInformationToUpdate == null)
                {
                    return NotFound($"ArticleInformation with id = {id} not found");
                }

                return await _articleInformationRepository.UpdateArticleInformation(articleInformation);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
