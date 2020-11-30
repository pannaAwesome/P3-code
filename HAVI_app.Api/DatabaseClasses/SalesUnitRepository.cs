
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class SalesUnitRepository
    {
        private readonly HAVIdatabaseContext _context;
        public SalesUnitRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SalesUnit>> GetSalesUnits()
        {
            return await _context.SalesUnits.ToListAsync();
        }
    }
}
