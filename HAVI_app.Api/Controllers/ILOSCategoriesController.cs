﻿using HAVI_app.Api.DatabaseInterfaces;
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
        public ILOSCategoriesController(IILOSCategoryRepository ILOSCategoryRepository)
        {
            _ILOSCategoryRepository = ILOSCategoryRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetILOSCategories()
        {
            try
            {
                var result = await _ILOSCategoryRepository.GetILOSCategories();
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
                var result = await _ILOSCategoryRepository.GetILOSCategory(id);
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
        public async Task<ActionResult<Iloscategory>> CreateILOSCategory(Iloscategory ILOSCategory)
        {
            try
            {
                if (ILOSCategory == null)
                {
                    return BadRequest();
                }

                var createdILOSCategory = await _ILOSCategoryRepository.AddILOSCategory(ILOSCategory);

                return CreatedAtAction(nameof(GetILOSCategory), new { id = createdILOSCategory.Id }, createdILOSCategory);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Iloscategory>> UpdateILOSCategory(int id, Iloscategory ILOSCategory)
        {
            try
            {
                if (id != ILOSCategory.Id)
                {
                    return BadRequest();
                }

                var ILOSCategoryToUpdate = await _ILOSCategoryRepository.GetILOSCategory(id);

                if (ILOSCategoryToUpdate == null)
                {
                    return NotFound($"ILOSCategory with id = {id} not found");
                }

                return await _ILOSCategoryRepository.UpdateILOSCategory(ILOSCategory);
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
                var ILOSCategoryToDelete = await _ILOSCategoryRepository.GetILOSCategory(id);

                if (ILOSCategoryToDelete == null)
                {
                    return NotFound($"ILOSCategory with id = {id} not found");
                }

                return await _ILOSCategoryRepository.DeleteILOSCategoryAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}