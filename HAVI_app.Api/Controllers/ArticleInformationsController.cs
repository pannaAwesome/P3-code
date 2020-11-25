using HAVI_app.Api.DatabaseInterfaces;
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
        private readonly IArticleInformationRepository _articleInformationRepository;
        public ArticleInformationsController(IArticleInformationRepository articleInformationRepository)
        {
            _articleInformationRepository = articleInformationRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetArticleInformations()
        {
            try
            {
                var result = await _articleInformationRepository.GetArticleInformations();
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

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ArticleInformation>> GetArticleInformation(int id)
        {
            try
            {
                var result = await _articleInformationRepository.GetArticleInformation(id);
                if (result == null)
                {
                    return NotFound();
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

        [HttpPost]
        public async Task<ActionResult<ArticleInformation>> CreateArticleInformation(ArticleInformation articleInformation)
        {
            try
            {
                if (articleInformation == null)
                {
                    return BadRequest();
                }

                var createdArticleInformation = await _articleInformationRepository.AddArticleInformation(articleInformation);

                return CreatedAtAction(nameof(GetArticleInformation), new { id = createdArticleInformation.Id }, createdArticleInformation);
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

        [HttpDelete("{id}")]
        public async Task<ActionResult<ArticleInformation>> DeleteArticleInformation(int id)
        {
            try
            {
                var articleInformationToDelete = await _articleInformationRepository.GetArticleInformation(id);

                if (articleInformationToDelete == null)
                {
                    return NotFound($"ArticleInformation with id = {id} not found");
                }

                return await _articleInformationRepository.DeleteArticleInformationAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
