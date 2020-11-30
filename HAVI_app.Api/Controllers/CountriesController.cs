using HAVI_app.Api.DatabaseClasses;
using HAVI_app.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "admin")]
    public class CountriesController : ControllerBase
    {
        private readonly CountryRepository _countryRepository;
        public CountriesController(CountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            try
            {
                var result = await _countryRepository.GetCountry(id);
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

        [HttpGet]
        public async Task<ActionResult> GetCountries()
        {
            try
            {
                var result = await _countryRepository.GetCountries();
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
        public async Task<ActionResult<Country>> CreateCountry(Country country)
        {
            try
            {
                if (country == null)
                {
                    return BadRequest();
                }

                var createdCountry = await _countryRepository.AddCountry(country);

                return CreatedAtAction(nameof(GetCountry), new { id = createdCountry.Id }, createdCountry);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Country>> UpdateCountry(int id, Country country)
        {
            try
            {
                if (id != country.Id)
                {
                    return BadRequest();
                }

                var countryToUpdate = await _countryRepository.GetCountry(id);

                if (countryToUpdate == null)
                {
                    return NotFound($"Country with id = {id} not found");
                }

                return await _countryRepository.UpdateCountry(country);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Country>> DeleteCountry(int id)
        {
            try
            {
                var countryToDelete = await _countryRepository.GetCountry(id);

                if (countryToDelete == null)
                {
                    return NotFound($"Country with id = {id} not found");
                }

                return await _countryRepository.DeleteCountryAsync(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from the database.");
            }
        }
    }
}
