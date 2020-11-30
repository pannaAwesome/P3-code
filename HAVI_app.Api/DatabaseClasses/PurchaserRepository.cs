
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class PurchaserRepository
    {
        private readonly HAVIdatabaseContext _context;
        public PurchaserRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }

        public async Task<Purchaser> GetPurchaserForProfile(int profileId)
        {
            return await _context.Purchasers
                                 .Where(p => p.ProfileId == profileId)
                                 .Include(p => p.Profile)
                                 .FirstOrDefaultAsync();
        }

        public async Task<List<Purchaser>> GetPurchasersForCountry(int countryId)
        {
            return await _context.Purchasers
                          .Where(p => p.CountryId == countryId)
                          .Include(p => p.Profile)
                          .ToListAsync();
        }

        public async Task<Purchaser> AddPurchaser(Purchaser purchaser)
        {
            await _context.Profiles.AddAsync(purchaser.Profile);
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
                                 .Include(p => p.Articles)
                                 .FirstOrDefaultAsync(s => s.Id == purchaserId);
        }

        public async Task<IEnumerable<Purchaser>> GetPurchasers()
        {
            return await _context.Purchasers
                                 .Include(p => p.Profile)
                                 .ToListAsync();
        }

        public async Task<Purchaser> UpdatePurchaser(Purchaser purchaser)
        {
            var resultPurchaser = await _context.Purchasers.FirstOrDefaultAsync(c => c.Id == purchaser.Id);
            var resultProfile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id == resultPurchaser.ProfileId);

            if (resultPurchaser != null && resultProfile != null)
            {
                resultProfile.Username = purchaser.Profile.Username;
                resultProfile.Password = purchaser.Profile.Password;
                await _context.SaveChangesAsync();
                return resultPurchaser;
            }

            return null;
        }

        public async Task<Purchaser> DeletePurchaserForProfile(int profileId)
        {
            var purchaser = await _context.Purchasers.FirstOrDefaultAsync(p => p.ProfileId == profileId);
            var profile = await _context.Profiles.FirstOrDefaultAsync(p => p.Id == purchaser.ProfileId);
            if (purchaser != null && profile != null)
            {
                _context.Profiles.Remove(profile);
                await _context.SaveChangesAsync();
                return purchaser;
            }

            return null;
        }
    }
}
