
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class PrimaryDCILOSCodeRepository
    {
        private readonly HAVIdatabaseContext _context;
        public PrimaryDCILOSCodeRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<PrimaryDciloscode> AddPrimaryDCILOSCode(PrimaryDciloscode ilosCode)
        {
            var result = await _context.PrimaryDciloscodes.AddAsync(ilosCode);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<PrimaryDciloscode> DeletePrimaryDCILOSCodeAsync(int ilosCodeId)
        {
            var result = await _context.PrimaryDciloscodes.FirstOrDefaultAsync(s => s.Id == ilosCodeId);
            if (result != null)
            {
                _context.PrimaryDciloscodes.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<PrimaryDciloscode> GetPrimaryDCILOSCode(int id)
        {
            return await _context.PrimaryDciloscodes.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<PrimaryDciloscode>> GetPrimaryDCILOSCodes(int countryId)
        {
            return await _context.PrimaryDciloscodes
                                 .Where(p => p.CountryId == countryId)
                                 .ToListAsync();
        }

        public async Task<PrimaryDciloscode> UpdatePrimaryDCILOSCode(PrimaryDciloscode ilosCode)
        {
            var result = await _context.PrimaryDciloscodes.FirstOrDefaultAsync(s => s.Id == ilosCode.Id);
            if (result != null)
            {
                result.PrimaryCode = ilosCode.PrimaryCode;
                result.Sapplant = ilosCode.Sapplant;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
