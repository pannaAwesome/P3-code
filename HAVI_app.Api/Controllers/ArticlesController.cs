using HAVI_app.Api.DatabaseClasses;

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
    public class ArticlesController : ControllerBase
    {
        private readonly ArticleRepository _articleRepository;
        public ArticlesController(ArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        [HttpGet("country/{state}/{id}")]
        public async Task<ActionResult> GetArticlesWithCertainState(int id, int state)
        {
            try
            {
                var result = await _articleRepository.GetArticlesWithCertainState(state, id);
                if(result == null)
                {
                    return Ok(new List<Article>());
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("country/{id}")]
        public async Task<ActionResult> GetArticlesForCountry(int id)
        {
            try
            {
                var result = await _articleRepository.GetArticlesForCountry(id);
                if(result == null)
                {
                    return Ok(new List<Article>());
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("supplier/{id}")]
        public async Task<ActionResult> GetArticlesForSupplier(int id)
        {
            try
            {
                var result = await _articleRepository.GetArticlesForSupplier(id);
                if (result == null)
                {
                    return Ok(new List<Article>());
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            try
            {
                var result = await _articleRepository.GetArticle(id);
                if (result == null)
                {
                    return Ok(new List<Article>());
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

        [HttpGet]
        public async Task<ActionResult> GetArticles()
        {
            try
            {
                var result = await _articleRepository.GetArticles();
                if (result == null)
                {
                    return Ok(new List<Article>());
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Article>> CreateArticle(Article article)
        {
            try
            {
                if (article == null)
                {
                    return BadRequest();
                }

                var createdArticle = await _articleRepository.AddArticle(article);

                return CreatedAtAction(nameof(GetArticle), new { id = createdArticle.Id }, createdArticle);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Article>> UpdateArticle(int id, Article article)
        {
            try
            {
                if (id != article.Id)
                {
                    return BadRequest();
                }

                var articleToUpdate = await _articleRepository.GetArticle(id);

                if (articleToUpdate == null)
                {
                    return NotFound($"Article with id = {id} not found");
                }

                return await _articleRepository.UpdateArticle(article);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Article>> DeleteArticle(int id)
        {
            try
            {
                var articleToDelete = await _articleRepository.GetArticle(id);

                if (articleToDelete == null)
                {
                    return NotFound($"Article with id = {id} not found");
                }

                return await _articleRepository.DeleteArticleAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
