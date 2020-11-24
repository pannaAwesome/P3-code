using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class ILOSOrderpickgroupRepository : IILOSOrderpickgroupRepository
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

        public async void DeleteILOSOrderpickgroupAsync(int orderGroupId)
        {
            var result = await _context.Ilosorderpickgroups.FirstOrDefaultAsync(s => s.Id == orderGroupId);
            if (result != null)
            {
                _context.Ilosorderpickgroups.Remove(result);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Ilosorderpickgroup>> GetILOSOrderpickgroups()
        {
            return await _context.Ilosorderpickgroups.ToListAsync();
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
