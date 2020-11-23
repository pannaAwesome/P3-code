using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HAVI_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly HAVIdatabaseContext _context;

        public SupplierController(HAVIdatabaseContext context)
        {
            _context = context;
        }

        #region Gets all suppliers from supplier table
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var suppliers = await _context.Suppliers.ToListAsync();
            return Ok(suppliers);
        }
        #endregion

        #region Gets the supplier with the specific id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var suppliers = await _context.Suppliers.FirstOrDefaultAsync(a => a.Id == id);
            return Ok(suppliers);
        }
        #endregion

        #region Adds a new supplier to the supplier table
        
        [HttpPost]
        public async Task<IActionResult> Post(Supplier supplier)
        {
            _context.Add(supplier);
            await _context.SaveChangesAsync();
            return Ok(supplier.Id);
        }
        #endregion

        // PUT api/<SupplierController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SupplierController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
