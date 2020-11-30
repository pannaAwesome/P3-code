
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class VatTaxCodeRepository
    {
        private readonly HAVIdatabaseContext _context;
        public VatTaxCodeRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<VatTaxCode> AddVatTaxCode(VatTaxCode code)
        {
            var result = await _context.VatTaxCodes.AddAsync(code);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<VatTaxCode> DeleteVatTaxCodeAsync(int codeId)
        {
            var result = await _context.VatTaxCodes.FirstOrDefaultAsync(s => s.Id == codeId);
            if (result != null)
            {
                _context.VatTaxCodes.Remove(result);
                await _context.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<VatTaxCode> GetVatTaxCode(int VatTaxId)
        {
            return await _context.VatTaxCodes.FirstOrDefaultAsync(s => s.Id == VatTaxId);
        }

        public async Task<IEnumerable<VatTaxCode>> GetVatTaxCodes(int countryId)
        {
            return await _context.VatTaxCodes
                                 .Where(v => v.CountryId == countryId)
                                 .ToListAsync();
        }

        public async Task<VatTaxCode> UpdateVatTaxCode(VatTaxCode code)
        {
            var result = await _context.VatTaxCodes.FirstOrDefaultAsync(s => s.Id == code.Id);
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
