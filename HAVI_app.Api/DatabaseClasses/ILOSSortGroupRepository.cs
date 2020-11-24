using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class ILOSSortGroupRepository : IILOSSortGroupRepository
    {
        private readonly HAVIdatabaseContext _context;
        public ILOSSortGroupRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<IlossortGroup>> GetILOSSortGroups()
        {
            return await _context.IlossortGroups.ToListAsync();
        }
    }
}
