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
    public class VailedForCustomersController : ControllerBase
    {
        private readonly VailedForCustomerRepository _vailedForCustomerRepository;
        public VailedForCustomersController(VailedForCustomerRepository vailedForCustomerRepository)
        {
            _vailedForCustomerRepository = vailedForCustomerRepository;
        }

        [HttpGet("country/{id}")]
        public async Task<ActionResult> GetVailedForCustomers(int id)
        {
            try
            {
                var result = await _vailedForCustomerRepository.GetVailedForCustomers(id);
                if (result == null)
                {
                    return Ok(new List<VailedForCustomer>());
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<VailedForCustomer>> GetVailedForCustomer(int id)
        {
            try
            {
                var result = await _vailedForCustomerRepository.GetVailedForCustomer(id);
                if (result == null)
                {
                    return new VailedForCustomer();
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
        public async Task<ActionResult<VailedForCustomer>> CreateVailedForCustomer(VailedForCustomer vailedForCustomer)
        {
            try
            {
                if (vailedForCustomer == null)
                {
                    return BadRequest();
                }

                var createdVailedForCustomer = await _vailedForCustomerRepository.AddVailedForCustomer(vailedForCustomer);

                return createdVailedForCustomer;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<VailedForCustomer>> UpdateVailedForCustomer(int id, VailedForCustomer vailedForCustomer)
        {
            try
            {
                if (id != vailedForCustomer.Id)
                {
                    return BadRequest();
                }

                var vailedForCustomerToUpdate = await _vailedForCustomerRepository.GetVailedForCustomer(id);

                if (vailedForCustomerToUpdate == null)
                {
                    return NotFound($"VailedForCustomer with id = {id} not found");
                }

                return await _vailedForCustomerRepository.UpdateVailedForCustomer(vailedForCustomer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<VailedForCustomer>> DeleteVailedForCustomer(int id)
        {
            try
            {
                var vailedForCustomerToDelete = await _vailedForCustomerRepository.GetVailedForCustomer(id);

                if (vailedForCustomerToDelete == null)
                {
                    return NotFound($"VailedForCustomer with id = {id} not found");
                }

                return await _vailedForCustomerRepository.DeleteVailedForCustomerAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
