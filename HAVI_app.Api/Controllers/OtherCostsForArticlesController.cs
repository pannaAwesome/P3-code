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
    public class OtherCostsForArticlesController : ControllerBase
    {
        private readonly IOtherCostsForArticleRepository _otherCostsForArticleRepository;
        public OtherCostsForArticlesController(IOtherCostsForArticleRepository otherCostsForArticleRepository)
        {
            _otherCostsForArticleRepository = otherCostsForArticleRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetOtherCostsForArticles()
        {
            try
            {
                var result = await _otherCostsForArticleRepository.GetOtherCostsForArticles();
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
        public async Task<ActionResult<OtherCostsForArticle>> GetOtherCostsForArticle(int id)
        {
            try
            {
                var result = await _otherCostsForArticleRepository.GetOtherCostsForArticle(id);
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
        public async Task<ActionResult<OtherCostsForArticle>> CreateOtherCostsForArticle(OtherCostsForArticle otherCostsForArticle)
        {
            try
            {
                if (otherCostsForArticle == null)
                {
                    return BadRequest();
                }

                var createdOtherCostsForArticle = await _otherCostsForArticleRepository.AddOtherCostsForArticle(otherCostsForArticle);

                return CreatedAtAction(nameof(GetOtherCostsForArticle), new { id = createdOtherCostsForArticle.Id }, createdOtherCostsForArticle);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OtherCostsForArticle>> UpdateOtherCostsForArticle(int id, OtherCostsForArticle otherCostsForArticle)
        {
            try
            {
                if (id != otherCostsForArticle.Id)
                {
                    return BadRequest();
                }

                var otherCostsForArticleToUpdate = await _otherCostsForArticleRepository.GetOtherCostsForArticle(id);

                if (otherCostsForArticleToUpdate == null)
                {
                    return NotFound($"OtherCostsForArticle with id = {id} not found");
                }

                return await _otherCostsForArticleRepository.UpdateOtherCostsForArticle(otherCostsForArticle);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OtherCostsForArticle>> DeleteOtherCostsForArticle(int id)
        {
            try
            {
                var otherCostsForArticleToDelete = await _otherCostsForArticleRepository.GetOtherCostsForArticle(id);

                if (otherCostsForArticleToDelete == null)
                {
                    return NotFound($"OtherCostsForArticle with id = {id} not found");
                }

                return await _otherCostsForArticleRepository.DeleteOtherCostsForArticleAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
