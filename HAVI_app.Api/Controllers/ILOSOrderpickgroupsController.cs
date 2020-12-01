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
    public class ILOSOrderpickgroupsController : ControllerBase
    {
        private readonly ILOSOrderpickgroupRepository _orderpickgroup;
        public ILOSOrderpickgroupsController(ILOSOrderpickgroupRepository orderpickgroup)
        {
            _orderpickgroup = orderpickgroup;
        }

        [HttpGet("country/{id}")]
        public async Task<ActionResult> GetILOSOrderpickgroups(int id)
        {
            try
            {
                var result = await _orderpickgroup.GetILOSOrderpickgroups(id);
                if (result == null)
                {
                    return Ok(new List<Ilosorderpickgroup>());
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Ilosorderpickgroup>> GetILOSOrderpickgroup(int id)
        {
            try
            {
                var result = await _orderpickgroup.GetILOSOrderpickgroup(id);
                if (result == null)
                {
                    return new Ilosorderpickgroup();
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
        public async Task<ActionResult<Ilosorderpickgroup>> CreateILOSOrderpickgroup(Ilosorderpickgroup orderpickgroup)
        {
            try
            {
                if (orderpickgroup == null)
                {
                    return BadRequest();
                }

                var createdILOSOrderpickgroup = await _orderpickgroup.AddILOSOrderpickgroup(orderpickgroup);

                return CreatedAtAction(nameof(GetILOSOrderpickgroup), new { id = createdILOSOrderpickgroup.Id }, createdILOSOrderpickgroup);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Ilosorderpickgroup>> UpdateILOSOrderpickgroup(int id, Ilosorderpickgroup orderpickgroup)
        {
            try
            {
                if (id != orderpickgroup.Id)
                {
                    return BadRequest();
                }

                var orderpickgroupToUpdate = await _orderpickgroup.GetILOSOrderpickgroup(id);

                if (orderpickgroupToUpdate == null)
                {
                    return NotFound($"ILOSOrderpickgroup with id = {id} not found");
                }

                return await _orderpickgroup.UpdateILOSOrderpickgroup(orderpickgroup);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Ilosorderpickgroup>> DeleteILOSOrderpickgroup(int id)
        {
            try
            {
                var orderpickgroupToDelete = await _orderpickgroup.GetILOSOrderpickgroup(id);

                if (orderpickgroupToDelete == null)
                {
                    return NotFound($"ILOSOrderpickgroup with id = {id} not found");
                }

                return await _orderpickgroup.DeleteILOSOrderpickgroupAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
