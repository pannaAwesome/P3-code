using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class QIPNumberRepository : IQIPNumberRepository
    {
        private readonly HAVIdatabaseContext _context;
        public QIPNumberRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Qipnumber>> GetQIPNumbers()
        {
            return await _context.Qipnumbers.ToListAsync();
        }
    }
}
