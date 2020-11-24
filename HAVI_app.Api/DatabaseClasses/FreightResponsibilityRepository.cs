using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class FreightResponsibilityRepository : IFreightResponsibilityRepository
    {
        private readonly HAVIdatabaseContext _context;
        public FreightResponsibilityRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FreightResponsibility>> GetFreightResponsibilities()
        {
            return await _context.FreightResponsibilities.ToListAsync();
        }
    }
}
