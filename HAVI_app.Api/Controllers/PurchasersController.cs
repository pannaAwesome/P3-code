﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using HAVI_app.Models;
using HAVI_app.Api.DatabaseClasses;

namespace HAVI_app.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchasersController : ControllerBase
    {
        private readonly PurchaserRepository _purchaserRepository;
        public PurchasersController(PurchaserRepository purchaserRepository)
        {
            _purchaserRepository = purchaserRepository;
        }

        [HttpGet("profile/{id}")]
        public async Task<ActionResult<Purchaser>> GetPurchaserForProfile(int id)
        {
            try
            {
                var result = await _purchaserRepository.GetPurchaserForProfile(id);
                if (result == null)
                {
                    return new Purchaser();
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

        [HttpPut("{id}")]
        public async Task<ActionResult<Purchaser>> UpdatePurchaser(int id, Purchaser purchaser)
        {
            try
            {
                if (id != purchaser.Id)
                {
                    return BadRequest();
                }

                var supplierToUpdate = await _purchaserRepository.GetPurchaser(id);

                if (supplierToUpdate == null)
                {
                    return NotFound($"Purchaser with id = {id} not found");
                }

                return await _purchaserRepository.UpdatePurchaser(purchaser);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpDelete("profile/{id}")]
        public async Task<ActionResult<Purchaser>> DeletePurchaserForProfile(int id)
        {
            try
            {
                var purchaserToDelete = await _purchaserRepository.GetPurchaserForProfile(id);

                if (purchaserToDelete == null)
                {
                    return NotFound($"Purchaser with id = {id} not found");
                }

                return await _purchaserRepository.DeletePurchaserForProfile(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("country/{id}")]
        public async Task<ActionResult> GetPurchasersForCountry(int id)
        {
            try
            {
                var result = await _purchaserRepository.GetPurchasersForCountry(id);
                if (result == null)
                {
                    return Ok(new List<Purchaser>());
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
        
        [HttpPost]
        public async Task<ActionResult<Purchaser>> CreatePurchaser(Purchaser purchaser)
        {
            try
            {
                if (purchaser == null)
                {
                    return BadRequest();
                }

                var createdPurchaser = await _purchaserRepository.AddPurchaser(purchaser);

                return createdPurchaser;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Purchaser>> GetPurchaser(int id)
        {
            try
            {
                var result = await _purchaserRepository.GetPurchaser(id);
                if (result == null)
                {
                    return Ok(new Purchaser());
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
        public async Task<ActionResult> GetPurchasers()
        {
            try
            {
                var result = await _purchaserRepository.GetPurchasers();
                if (result == null)
                {
                    return Ok(new List<Purchaser>());
                }
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
