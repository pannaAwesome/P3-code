using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class CompanyCodeRepository
    {
        private readonly HAVIdatabaseContext _context;
        public CompanyCodeRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<CompanyCode> AddCompanyCode(CompanyCode code)
        {
            var result = await _context.CompanyCodes.AddAsync(code);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<CompanyCode> DeleteCompanyCodeAsync(int codeId)
        {
            var result = await _context.CompanyCodes.FirstOrDefaultAsync(s => s.Id == codeId);
            if (result != null)
            {
                _context.CompanyCodes.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<IEnumerable<CompanyCode>> GetCompanyCodes(int countryId)
        {
            return await _context.CompanyCodes
                                 .Where(c => c.CountryId == countryId)
                                 .ToListAsync();
        }

        public async Task<CompanyCode> GetCompanyCode(int id)
        {
            return await _context.CompanyCodes.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<CompanyCode> UpdateCompanyCode(CompanyCode code)
        {
            var result = await _context.CompanyCodes.FirstOrDefaultAsync(s => s.Id == code.Id);
            if (result != null)
            {
                result.Code = code.Code;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
