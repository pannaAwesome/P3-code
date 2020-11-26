using HAVI_app.Api.DatabaseInterfaces;
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class PurchaserRepository : IPurchaserRepository
    {
        private readonly HAVIdatabaseContext _context;
        public PurchaserRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }
        public async Task<Purchaser> AddPurchaser(Purchaser purchaser)
        {
            var profile = await _context.Profiles.AddAsync(purchaser.Profile);
            await _context.SaveChangesAsync();

            var result = await _context.Purchasers.AddAsync(purchaser);
            await _context.SaveChangesAsync();
            

            return result.Entity;
        }

        public async Task<Purchaser> DeletePurchaserAsync(int purchaserId)
        {
            var purchaser = await _context.Purchasers.FirstOrDefaultAsync(p => p.Id == purchaserId);
            var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id == purchaser.ProfileId);
            if (purchaser != null && profile != null)
            {
                _context.Profiles.Remove(profile);
                await _context.SaveChangesAsync();
                return purchaser;
            }

            return null;
        }

        public async Task<Purchaser> GetPurchaser(int purchaserId)
        {
            return await _context.Purchasers
                                 .Include(p => p.Profile)
                                 .FirstOrDefaultAsync(s => s.Id == purchaserId);
        }

        public async Task<IEnumerable<Purchaser>> GetPurchasers()
        {
            return await _context.Purchasers
                                 .Include(p => p.Profile)
                                 .ToListAsync();
        }
    }
}
