using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class DepartmentIdRepository : IDepartmentIdRepository
    {
        private readonly HAVIdatabaseContext _context;
        public DepartmentIdRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DepartmentId>> GetDepartmentIds()
        {
            return await _context.DeparmentIds.ToListAsync();
        }
    }
}
