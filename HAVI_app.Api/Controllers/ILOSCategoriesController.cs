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
    public class ILOSCategoriesController : ControllerBase
    {
        private readonly IILOSCategoryRepository _ILOSCategoryRepository;
        public ILOSCategoriesController(ÍIloscategory ILOSCategoryRepository)
        {
            _ILOSCategoryRepository = ILOSCategoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetILOSCategories()
        {
            try
            {
                var result = await _ILOSCategoryrRepository.GetILOSCategories();
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
                var result = await _ILOSCategoryrRepository.GetILOSCategory(id);
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
        public async Task<ActionResult<Iloscategory>> CreateILOSCategory(Iloscategory ILOSCategoryr)
        {
            try
            {
                if (ILOSCategoryr == null)
                {
                    return BadRequest();
                }

                var createdILOSCategory = await _ILOSCategoryrRepository.AddILOSCategory(ILOSCategoryr);

                return CreatedAtAction(nameof(GetILOSCategory), new { id = createdILOSCategory.Id }, createdILOSCategory);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Iloscategory>> UpdateILOSCategory(int id, Iloscategory ILOSCategoryr)
        {
            try
            {
                if (id != ILOSCategoryr.Id)
                {
                    return BadRequest();
                }

                var ILOSCategoryrToUpdate = await _ILOSCategoryrRepository.GetILOSCategory(id);

                if (ILOSCategoryrToUpdate == null)
                {
                    return NotFound($"ILOSCategory with id = {id} not found");
                }

                return await _ILOSCategoryrRepository.UpdateILOSCategory(ILOSCategoryr);
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
                var ILOSCategoryrToDelete = await _ILOSCategoryrRepository.GetILOSCategory(id);

                if (ILOSCategoryrToDelete == null)
                {
                    return NotFound($"ILOSCategory with id = {id} not found");
                }

                return await _ILOSCategoryrRepository.DeleteILOSCategoryAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
