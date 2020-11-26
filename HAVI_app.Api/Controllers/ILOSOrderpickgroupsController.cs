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
    public class ILOSOrderpickgroupsController : ControllerBase
    {
        private readonly IILOSOrderpickgroupRepository _orderpickgroup;
        public ILOSOrderpickgroupsController(IILOSOrderpickgroupRepository orderpickgroup)
        {
            _orderpickgroup = orderpickgroup;
        }

        [HttpGet]
        public async Task<ActionResult> GetILOSOrderpickgroups()
        {
            try
            {
                var result = await _orderpickgroup.GetILOSOrderpickgroups();
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

                return CreatedAtAction(nameof(CreateILOSOrderpickgroup), new { id = createdILOSOrderpickgroup.Id }, createdILOSOrderpickgroup);
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
