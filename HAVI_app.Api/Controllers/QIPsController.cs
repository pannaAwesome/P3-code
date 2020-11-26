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
    public class QIPsController : ControllerBase
    {
        private readonly IQIPRepository _qipRepository;
        public QIPsController(IQIPRepository qipRepository)
        {
            _qipRepository = qipRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetQIPs()
        {
            try
            {
                var result = await _qipRepository.GetQIPs();
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
        public async Task<ActionResult<Qip>> GetQIP(int id)
        {
            try
            {
                var result = await _qipRepository.GetQIP(id);
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
        public async Task<ActionResult<Qip>> CreateQIP(Qip qip)
        {
            try
            {
                if (qip == null)
                {
                    return BadRequest();
                }

                var createdQIP = await _qipRepository.AddQIP(qip);

                return CreatedAtAction(nameof(GetQIP), new { id = createdQIP.Id }, createdQIP);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Qip>> UpdateQIP(int id, Qip qip)
        {
            try
            {
                if (id != qip.Id)
                {
                    return BadRequest();
                }

                var qipToUpdate = await _qipRepository.GetQIP(id);

                if (qipToUpdate == null)
                {
                    return NotFound($"QIP with id = {id} not found");
                }

                return await _qipRepository.UpdateQIP(qip);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Qip>> DeleteQIP(int id)
        {
            try
            {
                var qipToDelete = await _qipRepository.GetQIP(id);

                if (qipToDelete == null)
                {
                    return NotFound($"QIP with id = {id} not found");
                }

                return await _qipRepository.DeleteQIPAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
