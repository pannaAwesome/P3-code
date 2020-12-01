
using HAVI_app.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HAVI_app.Api.DatabaseClasses
{
    public class ProfileRepository 
    {
        private readonly HAVIdatabaseContext _context;
        public ProfileRepository(HAVIdatabaseContext context)
        {
            _context = context;
        }

        public async Task<Profile> GetProfileForCountry(int profileId)
        {
            return await _context.Profiles.Where(p => p.Id == profileId).FirstOrDefaultAsync();
        }

        public async Task<Profile> AddProfile(Profile profile)
        {
            var result = await _context.Profiles.AddAsync(profile);
            await _context.SaveChangesAsync();

            return result.Entity;
        }

        public async Task<Profile> DeleteProfileAsync(int profileId)
        {
            var profile = await _context.Profiles
                                        .Where(p => p.Id == profileId)
                                        .FirstOrDefaultAsync();
            if (profile != null)
            {
                _context.Profiles.Remove(profile);
                await _context.SaveChangesAsync();
                return profile;
            }

            return null;
        }

        public async Task<Profile> GetProfile(int profileId)
        {
            return await _context.Profiles.FirstOrDefaultAsync(s => s.Id == profileId);
        }

        public async Task<Profile> GetProfileWithUsernameAndPassword(string username, string password)
        {
            return await _context.Profiles.FromSqlRaw($"SELECT * from Profile where Username like '{username}'").FirstOrDefaultAsync();
        }

        public async Task<List<Profile>> GetProfiles()
        {
            return await _context.Profiles.ToListAsync();
        }

        public async Task<Profile> UpdateProfile(Profile profile)
        {
            var result = await _context.Profiles.FirstOrDefaultAsync(s => s.Id == profile.Id);
            if (result != null)
            {
                result.Username = profile.Username;
                result.Password = profile.Password;
                await _context.SaveChangesAsync();
                return result;
            }

            return null;
        }
    }
}

