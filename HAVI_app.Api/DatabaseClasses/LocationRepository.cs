using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class LocationRepository : ILocationRepository
    {
        private readonly HAVIdatabaseContext _context;
        public LocationRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Location>> GetLocations()
        {
            return await _context.Locations.ToListAsync();
        }
    }
}
