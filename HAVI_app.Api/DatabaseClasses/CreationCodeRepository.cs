using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class CreationCodeRepository : ICreationCodeRepository
    {
        private readonly HAVIdatabaseContext _context;
        public CreationCodeRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<CreationCode> AddCreationCode(CreationCode code)
        {
            var result = await _context.CreationCodes.AddAsync(code);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<CreationCode> DeleteCreationCodeAsync(int codeId)
        {
            var result = await _context.CreationCodes.FirstOrDefaultAsync(s => s.Id == codeId);
            if (result != null)
            {
                _context.CreationCodes.Remove(result);
                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<CreationCode> GetCreationCode(int codeId)
        {
            return await _context.CreationCodes.FirstOrDefaultAsync(s => s.Id == codeId);
        }

        public async Task<IEnumerable<CreationCode>> GetCreationCodes()
        {
            return await _context.CreationCodes.ToListAsync();
        }

        public async Task<CreationCode> UpdateCreationCode(CreationCode code)
        {
            var result = await _context.CreationCodes.FirstOrDefaultAsync(s => s.Id == code.Id);
            if (result != null)
            {
                result.Code = code.Code;
                result.Active = code.Active;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}
