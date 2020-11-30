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
    public class ILOSCategoriesController : ControllerBase
    {
        private readonly ILOSCategoryRepository _categoryRepository;
        public ILOSCategoriesController(ILOSCategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet("country/{id}")]
        public async Task<ActionResult> GetILOSCategories(int id)
        {
            try
            {
                var result = await _categoryRepository.GetILOSCategories(id);
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
        public async Task<ActionResult<Iloscategory>> GetILOSCategory(int id)
        {
            try
            {
                var result = await _categoryRepository.GetILOSCategory(id);
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
        public async Task<ActionResult<Iloscategory>> CreateILOSCategory(Iloscategory category)
        {
            try
            {
                if (category == null)
                {
                    return BadRequest();
                }

                var createdILOSCategory = await _categoryRepository.AddILOSCategory(category);

                return CreatedAtAction(nameof(GetILOSCategory), new { id = createdILOSCategory.Id }, createdILOSCategory);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Iloscategory>> UpdateILOSCategory(int id, Iloscategory category)
        {
            try
            {
                if (id != category.Id)
                {
                    return BadRequest();
                }

                var ILOSCategoryToUpdate = await _categoryRepository.GetILOSCategory(id);

                if (ILOSCategoryToUpdate == null)
                {
                    return NotFound($"ILOSCategory with id = {id} not found");
                }

                return await _categoryRepository.UpdateILOSCategory(category);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Iloscategory>> DeleteILOSCategory(int id)
        {
            try
            {
                var ILOSCategoryToDelete = await _categoryRepository.GetILOSCategory(id);

                if (ILOSCategoryToDelete == null)
                {
                    return NotFound($"ILOSCategory with id = {id} not found");
                }

                return await _categoryRepository.DeleteILOSCategoryAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
