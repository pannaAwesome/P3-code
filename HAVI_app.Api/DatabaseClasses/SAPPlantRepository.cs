
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class SAPPlantRepository
    {
        private readonly HAVIdatabaseContext _context;
        public SAPPlantRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }

        public async Task<Sapplant> AddSAPPlant(Sapplant SAPPlant)
        {
            var result = await _context.Sapplants.AddAsync(SAPPlant);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Sapplant> DeleteSAPPlantAsync(int SAPPlantId)
        {
            var result = await _context.Sapplants.FirstOrDefaultAsync(s => s.Id == SAPPlantId);
            if (result != null)
            {
                _context.Sapplants.Remove(result);
                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<Sapplant> GetSAPPlant(int SAPPlantId)
        {
            return await _context.Sapplants.FirstOrDefaultAsync(s => s.Id == SAPPlantId);
        }

        public async Task<IEnumerable<Sapplant>> GetSAPPlants()
        {
            return await _context.Sapplants.ToListAsync();
        }

        public async Task<Sapplant> UpdateSAPPlant(Sapplant SAPPlant)
        {
            var result = await _context.Sapplants.FirstOrDefaultAsync(s => s.Id == SAPPlant.Id);
            if (result != null)
            {
                result.SapplantName = SAPPlant.SapplantName;
                result.SapplantValue = SAPPlant.SapplantValue;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
