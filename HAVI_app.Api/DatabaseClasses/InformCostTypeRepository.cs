using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class InformCostTypeRepository : IInformCostTypeRepository
    {
        private readonly HAVIdatabaseContext _context;
        public InformCostTypeRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<InformCostType> AddInformCostType(InformCostType costType)
        {
            var result = await _context.InformCostTypes.AddAsync(costType);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<InformCostType> DeleteInformCostTypeAsync(int costTypeId)
        {
            var result = await _context.InformCostTypes.FirstOrDefaultAsync(s => s.Id == costTypeId);
            if (result != null)
            {
                _context.InformCostTypes.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<InformCostType>> GetInformCostTypes()
        {
            return await _context.InformCostTypes.ToListAsync();
        }

        public async Task<InformCostType> UpdateInformCostType(InformCostType costType)
        {
            var result = await _context.InformCostTypes.FirstOrDefaultAsync(s => s.Id == costType.Id);
            if (result != null)
            {
                result.CostType = costType.CostType;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
