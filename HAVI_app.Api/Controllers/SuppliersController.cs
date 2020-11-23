using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;

namespace HAVI_app.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierRepository _supplierRepository;
        public SuppliersController(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
        }

        //[HttpGet]
        //public async Task<ActionResult> GetSuppliers()
        //{

        //}

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Supplier>> GetSupplier(int id)
        {
            try
            {
                var result = await _supplierRepository.GetSupplier(id);
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
    }
}
