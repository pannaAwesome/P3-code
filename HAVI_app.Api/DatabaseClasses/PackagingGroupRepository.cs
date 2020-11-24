using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class PackagingGroupRepository : IPackagingGroupRepository
    {
        private readonly HAVIdatabaseContext _context;
        public PackagingGroupRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PackagingGroup>> GetFreightResponsibility()
        {
            return await _context.PackagingGroups.ToListAsync();
        }
    }
}
