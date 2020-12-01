
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class ILOSOrderpickgroupRepository
    {
        private readonly HAVIdatabaseContext _context;
        public ILOSOrderpickgroupRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<Ilosorderpickgroup> AddILOSOrderpickgroup(Ilosorderpickgroup orderGroup)
        {
            var result = await _context.Ilosorderpickgroups.AddAsync(orderGroup);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Ilosorderpickgroup> DeleteILOSOrderpickgroupAsync(int orderGroupId)
        {
            var result = await _context.Ilosorderpickgroups.FirstOrDefaultAsync(s => s.Id == orderGroupId);
            if (result != null)
            {
                _context.Ilosorderpickgroups.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<Ilosorderpickgroup> GetILOSOrderpickgroup(int orderGroupId)
        {
           
                return await _context.Ilosorderpickgroups.FirstOrDefaultAsync(s => s.Id == orderGroupId);
           
        }

        public async Task<IEnumerable<Ilosorderpickgroup>> GetILOSOrderpickgroups(int countryId)
        {
            return await _context.Ilosorderpickgroups
                                 .Where(i => i.CountryId == countryId)
                                 .ToListAsync();
        }

        public async Task<Ilosorderpickgroup> UpdateILOSOrderpickgroup(Ilosorderpickgroup orderGroup)
        {
            var result = await _context.Ilosorderpickgroups.FirstOrDefaultAsync(s => s.Id == orderGroup.Id);
            if (result != null)
            {
                result.Orderpickgroup = orderGroup.Orderpickgroup;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
